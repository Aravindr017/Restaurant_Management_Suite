Imports System.Data.OleDb
Imports System.Text.RegularExpressions

Public Class frmLogIn

    Private Sub frmLogIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Spice Garden - Staff & Customer Portal"
        ' Ensure the database tables and seed records are prepared
        InitializeDatabase()
        ClearLogInFields()
        ' Populate table selector from DB
        PopulateTableSelector()
        If cboTableSelect.Items.Count > 0 Then
            cboTableSelect.SelectedIndex = 0
        End If
    End Sub

    Public Sub PopulateTableSelector()
        If Not DbConnect() Then
            If cboTableSelect.Items.Count = 0 Then
                For i As Integer = 1 To 6
                    cboTableSelect.Items.Add("Table " & i)
                Next
            End If
            Return
        End If

        Try
            Dim cmd As New OleDbCommand("SELECT TableNumber, Capacity, TableStatus FROM tblTables ORDER BY TableNumber ASC", cn)
            Dim reader As OleDbDataReader = cmd.ExecuteReader()
            Dim hasRows As Boolean = False
            Dim list As New List(Of String)()
            While reader.Read()
                hasRows = True
                Dim tNum As Integer = Convert.ToInt32(reader("TableNumber"))
                Dim cap As Integer = Convert.ToInt32(reader("Capacity"))
                Dim stat As String = reader("TableStatus").ToString()
                list.Add("Table " & tNum & " (" & cap & " seats - " & stat & ")")
            End While
            reader.Close()

            If hasRows Then
                cboTableSelect.Items.Clear()
                For Each item In list
                    cboTableSelect.Items.Add(item)
                Next
            Else
                If cboTableSelect.Items.Count = 0 Then
                    For i As Integer = 1 To 6
                        cboTableSelect.Items.Add("Table " & i)
                    Next
                End If
            End If
        Catch
            If cboTableSelect.Items.Count = 0 Then
                For i As Integer = 1 To 6
                    cboTableSelect.Items.Add("Table " & i)
                Next
            End If
        Finally
            DbClose()
        End Try
    End Sub

    Private Sub chkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
        If chkShowPassword.Checked Then
            txtPassword.PasswordChar = ControlChars.NullChar
        Else
            txtPassword.PasswordChar = "*"c
        End If
    End Sub

    Private Sub btnLogIn_Click(sender As Object, e As EventArgs) Handles btnLogIn.Click
        Dim username As String = txtUserName.Text.Trim()
        Dim enteredPassword As String = txtPassword.Text.Trim()

        If String.IsNullOrEmpty(username) Then
            MessageBox.Show("Please enter your staff username.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUserName.Focus()
            Return
        End If

        If String.IsNullOrEmpty(enteredPassword) Then
            MessageBox.Show("Please enter your password.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return
        End If

        ' Retrieve stored encrypted password and user info from tblStaff
        Dim retrievedPassword As String = GetStaffCredentials(username)

        If retrievedPassword = "USER_NOT_FOUND" Then
            Return
        End If

        ' Use recursive verification matching the academic recursion requirement
        If recursivePasswordCheck(0, enteredPassword, retrievedPassword) Then
            ClearLogInFields()
            Me.Hide()

            If UserAccessLevel = 1 Then
                ' Owner / Manager Dashboard
                Dim ownerForm As New frmOwnerDashboard()
                ownerForm.ShowDialog()
            ElseIf UserAccessLevel = 2 Then
                ' Waiter Dashboard
                Dim waiterForm As New frmWaiterDashboard()
                waiterForm.ShowDialog()
            Else
                MessageBox.Show("Unknown staff role level: " & UserAccessLevel, "Role Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            ' Upon closing dashboard, return to login form and refresh tables
            Me.Show()
            ClearLogInFields()
            PopulateTableSelector()
        Else
            UserAccessLevel = 99
            LogedIn = False
        End If
    End Sub

    ''' <summary>
    ''' Recursively verifies the user's password with up to 3 failed retry attempts.
    ''' UserPw = plain text typed by user; RetrievedPW = decrypted password from DB.
    ''' </summary>
    Public Function recursivePasswordCheck(AttemptCount As Integer, UserPw As String, RetrievedPW As String) As Boolean
        ' Direct comparison: entered plain text vs decrypted stored password
        If UserPw = RetrievedPW Then
            LogedIn = True
            Return True
        End If

        Dim failedAttempts As Integer = AttemptCount + 1
        If failedAttempts >= 3 Then
            MessageBox.Show("You have reached 3 failed login attempts. Access is temporarily locked." & vbCrLf &
                            "Please contact your restaurant system administrator for assistance.",
                            "Security Notice - Access Locked", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            LogedIn = False
            Return False
        End If

        Dim newAttempt As String = InputBox("Incorrect password. Please re-enter your password." & vbCrLf &
                                            "Attempt " & (failedAttempts + 1) & " of 3:", "Staff Authentication Retry")
        If String.IsNullOrEmpty(newAttempt) Then
            ' User cancelled the retry dialog
            LogedIn = False
            Return False
        End If

        txtPassword.Text = newAttempt
        Return recursivePasswordCheck(failedAttempts, newAttempt, RetrievedPW)
    End Function

    ''' <summary>
    ''' Queries tblStaff for username, decrypts password, and sets session variables
    ''' </summary>
    Private Function GetStaffCredentials(usrName As String) As String
        Dim plainPassword As String = "USER_NOT_FOUND"

        If DbConnect() Then
            Try
                Dim cmd As New OleDbCommand("SELECT StaffID, UserName, UnPassword, AccessLevel, FullName, Role, IsApproved FROM tblStaff WHERE LCase(UserName) = @un", cn)
                cmd.Parameters.AddWithValue("@un", usrName.Trim().ToLower())
                Dim reader As OleDbDataReader = cmd.ExecuteReader()

                If reader.Read() Then
                    Dim isApproved As Integer = 1
                    If Not IsDBNull(reader("IsApproved")) Then
                        isApproved = Convert.ToInt32(reader("IsApproved"))
                    End If

                    If isApproved = 0 Then
                        reader.Close()
                        MessageBox.Show("Your account is pending owner approval." & vbCrLf &
                                        "Please wait for the restaurant owner to approve your registration before logging in.",
                                        "Account Pending Approval", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return "USER_NOT_FOUND"
                    End If

                    CurrentUserID = Convert.ToInt32(reader("StaffID"))
                    CurrentUserName = reader("UserName").ToString()
                    CurrentUserFullName = reader("FullName").ToString()
                    CurrentUserRole = reader("Role").ToString()
                    UserAccessLevel = Convert.ToInt32(reader("AccessLevel"))

                    ' Decrypt Base64 encoded password
                    Dim encPassword As String = reader("UnPassword").ToString()
                    plainPassword = Decrypt(encPassword)
                Else
                    MessageBox.Show("Staff user '" & usrName & "' was not found in the staff registry." & vbCrLf &
                                    "Please check the username and try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

                reader.Close()
            Catch ex As Exception
                MessageBox.Show("Error retrieving user record: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                DbClose()
            End Try
        End If

        Return plainPassword
    End Function

    Private Sub btnCustomerEnter_Click(sender As Object, e As EventArgs) Handles btnCustomerEnter.Click
        ' Configure session for customer/table guest ordering
        CurrentUserRole = "Customer"
        UserAccessLevel = 99
        If cboTableSelect.SelectedIndex < 0 Then
            cboTableSelect.SelectedIndex = 0
        End If

        Dim tNum As Integer = cboTableSelect.SelectedIndex + 1
        If cboTableSelect.SelectedItem IsNot Nothing Then
            Dim selectedText As String = cboTableSelect.SelectedItem.ToString()
            Dim m As Match = Regex.Match(selectedText, "\d+")
            If m.Success Then
                Integer.TryParse(m.Value, tNum)
            End If
        End If

        SelectedTableNumber = tNum
        ActiveCustomerName = "Table " & SelectedTableNumber & " Guest"

        Me.Hide()
        Dim orderForm As New frmCustomerOrder()
        orderForm.ShowDialog()
        Me.Show()
        ClearLogInFields()
        PopulateTableSelector()
    End Sub

    Private Sub ClearLogInFields()
        txtUserName.Text = ""
        txtPassword.Text = ""
        If chkShowPassword IsNot Nothing Then chkShowPassword.Checked = False
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub

    Private Sub btnStaffSignup_Click(sender As Object, e As EventArgs) Handles btnStaffSignup.Click
        Dim signupForm As New frmStaffSignup()
        signupForm.ShowDialog()
    End Sub

End Class
