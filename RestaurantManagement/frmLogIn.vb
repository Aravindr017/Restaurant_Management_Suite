Imports System.Data.OleDb

Public Class frmLogIn

    Private Sub frmLogIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Ensure the database tables and seed records are prepared
        InitializeDatabase()
        ClearLogInFields()
        If cboTableSelect.Items.Count > 0 Then
            cboTableSelect.SelectedIndex = 0
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

        ' Retrieve stored encrypted password and user info from tblStaff
        Dim retrievedPassword As String = GetStaffCredentials(username)

        If retrievedPassword = "USER_NOT_FOUND" Then
            Return
        End If

        ' Use recursive verification matching the academic requirement
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

            ' Upon closing dashboard, return to login form
            Me.Show()
            ClearLogInFields()
        Else
            UserAccessLevel = 99
            LogedIn = False
        End If
    End Sub

    ''' <summary>
    ''' Recursively verifies the user's password with up to 3 failed retry attempts
    ''' </summary>
    Public Function recursivePasswordCheck(AttemptCount As Integer, UserPw As String, RetrievedPW As String) As Boolean
        If UserPw = RetrievedPW Then
            ' Authentication successful
            LogedIn = True
            Return True
        End If

        ' Track failed attempt count (1st attempt failed = 1)
        Dim failedAttempts As Integer = AttemptCount + 1
        If failedAttempts >= 3 Then
            MessageBox.Show("You have reached 3 failed login attempts. Access is temporarily locked.",
                            "Security Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            LogedIn = False
            Return False
        End If

        Dim newAttempt As String = InputBox("Invalid password. Please re-enter password." & vbCrLf &
                                            "Attempt " & (failedAttempts + 1) & " of 3:", "Authentication Retry")
        If String.IsNullOrEmpty(newAttempt) Then
            ' User cancelled retry prompt
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
                Dim cmd As New OleDbCommand("SELECT StaffID, UserName, UnPassword, AccessLevel, FullName, Role FROM tblStaff WHERE UserName = @un", cn)
                cmd.Parameters.AddWithValue("@un", usrName)
                Dim reader As OleDbDataReader = cmd.ExecuteReader()

                If reader.Read() Then
                    CurrentUserID = Convert.ToInt32(reader("StaffID"))
                    CurrentUserName = reader("UserName").ToString()
                    CurrentUserFullName = reader("FullName").ToString()
                    CurrentUserRole = reader("Role").ToString()
                    UserAccessLevel = Convert.ToInt32(reader("AccessLevel"))

                    ' Decrypt Base64 encoded password
                    Dim encPassword As String = reader("UnPassword").ToString()
                    plainPassword = Decrypt(encPassword)
                Else
                    MessageBox.Show("User '" & usrName & "' was not found in the staff registry.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
        SelectedTableNumber = cboTableSelect.SelectedIndex + 1
        ActiveCustomerName = "Table " & SelectedTableNumber & " Guest"

        Me.Hide()
        Dim orderForm As New frmCustomerOrder()
        orderForm.ShowDialog()
        Me.Show()
    End Sub

    Private Sub ClearLogInFields()
        txtUserName.Text = ""
        txtPassword.Text = ""
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub

End Class
