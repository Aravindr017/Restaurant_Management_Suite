Imports System.Data.OleDb

Public Class frmStaffSignup

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim fullName As String = txtFullName.Text.Trim()
        Dim userName As String = txtUserName.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()
        Dim role As String = If(cboRole.SelectedItem IsNot Nothing, cboRole.SelectedItem.ToString(), "Waiter")
        Dim phone As String = txtPhone.Text.Trim()
        Dim email As String = txtEmail.Text.Trim()
        Dim address As String = txtAddress.Text.Trim()
        Dim notes As String = txtNotes.Text.Trim()

        ' Validation
        If String.IsNullOrEmpty(fullName) Then
            MessageBox.Show("Please enter your full name.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFullName.Focus()
            Return
        End If
        If String.IsNullOrEmpty(userName) Then
            MessageBox.Show("Please choose a login username.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUserName.Focus()
            Return
        End If
        If userName.Length < 4 Then
            MessageBox.Show("Username must be at least 4 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUserName.Focus()
            Return
        End If
        If String.IsNullOrEmpty(password) Then
            MessageBox.Show("Please set a password for your account.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return
        End If
        If password.Length < 6 Then
            MessageBox.Show("Password must be at least 6 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return
        End If
        If String.IsNullOrEmpty(phone) Then
            MessageBox.Show("Please enter your phone number.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPhone.Focus()
            Return
        End If

        ' Check for reserved system usernames
        Dim reservedNames As String() = {"owner", "admin", "administrator", "system", "customer", "guest"}
        For Each rn As String In reservedNames
            If userName.ToLower() = rn Then
                MessageBox.Show("The username '" & userName & "' is reserved and cannot be used. Please choose a different username.",
                                "Reserved Username", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtUserName.Focus()
                Return
            End If
        Next

        If Not DbConnect() Then Return
        Try
            ' Check if username is already taken (staff table or signup queue)
            Dim checkCmd As New OleDbCommand("SELECT COUNT(*) FROM tblStaff WHERE LCase(UserName) = @un", cn)
            checkCmd.Parameters.AddWithValue("@un", userName.ToLower())
            Dim staffCount As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
            If staffCount > 0 Then
                MessageBox.Show("Username '" & userName & "' is already taken by an existing staff member. Please choose a different username.",
                                "Username Taken", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtUserName.Focus()
                Return
            End If

            ' Check signup queue too
            Dim checkSignupCmd As New OleDbCommand("SELECT COUNT(*) FROM tblStaffSignup WHERE LCase(UserName) = @un AND Status = 'Pending'", cn)
            checkSignupCmd.Parameters.AddWithValue("@un", userName.ToLower())
            Dim signupCount As Integer = Convert.ToInt32(checkSignupCmd.ExecuteScalar())
            If signupCount > 0 Then
                MessageBox.Show("An application with username '" & userName & "' is already pending review. Please wait for owner response.",
                                "Application Pending", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ' Insert into signup queue
            Dim encPw As String = Encrypt(password)
            Dim insCmd As New OleDbCommand("INSERT INTO tblStaffSignup (FullName, UserName, UnPassword, Role, Phone, Email, Address, AppliedOn, Status, Notes) " &
                                           "VALUES (@fn, @un, @pw, @ro, @ph, @em, @ad, @dt, @st, @nt)", cn)
            insCmd.Parameters.AddWithValue("@fn", fullName)
            insCmd.Parameters.AddWithValue("@un", userName)
            insCmd.Parameters.AddWithValue("@pw", encPw)
            insCmd.Parameters.AddWithValue("@ro", role)
            insCmd.Parameters.AddWithValue("@ph", phone)
            insCmd.Parameters.AddWithValue("@em", email)
            insCmd.Parameters.AddWithValue("@ad", address)
            insCmd.Parameters.AddWithValue("@dt", DateTime.Now)
            insCmd.Parameters.AddWithValue("@st", "Pending")
            insCmd.Parameters.AddWithValue("@nt", notes)
            insCmd.ExecuteNonQuery()

            MessageBox.Show("Your application has been submitted successfully!" & vbCrLf & vbCrLf &
                            "Name: " & fullName & vbCrLf &
                            "Username: " & userName & vbCrLf &
                            "Role Applied For: " & role & vbCrLf & vbCrLf &
                            "The restaurant owner will review your application." & vbCrLf &
                            "You will be able to log in once your account is approved.",
                            "Application Submitted - Spice Garden", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error submitting application: " & ex.Message, "Submission Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DbClose()
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class
