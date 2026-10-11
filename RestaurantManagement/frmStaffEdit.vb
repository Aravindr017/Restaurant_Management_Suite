Imports System.Data.OleDb

Public Class frmStaffEdit

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim fn As String = txtFullName.Text.Trim()
        Dim un As String = txtUserName.Text.Trim()
        Dim pw As String = txtPassword.Text.Trim()
        Dim ph As String = txtPhone.Text.Trim()
        Dim salVal As Double

        If String.IsNullOrEmpty(fn) Then
            MessageBox.Show("Please enter the waiter's full name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFullName.Focus()
            Return
        End If

        If String.IsNullOrEmpty(un) Then
            MessageBox.Show("Please enter a login username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUserName.Focus()
            Return
        End If

        If String.IsNullOrEmpty(pw) Then
            MessageBox.Show("Please set a password for the waiter.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return
        End If

        If Not Double.TryParse(txtSalary.Text.Trim(), salVal) OrElse salVal < 0 Then
            salVal = 26000
        End If

        If DbConnect() Then
            Try
                ' Check if username already exists
                Dim checkCmd As New OleDbCommand("SELECT COUNT(*) FROM tblStaff WHERE LCase(UserName) = @un", cn)
                checkCmd.Parameters.AddWithValue("@un", un.ToLower())
                Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                If count > 0 Then
                    MessageBox.Show("Username '" & un & "' already exists. Please choose a different username.", "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtUserName.Focus()
                    Return
                End If

                ' Encrypt password with Base64
                Dim encPw As String = Encrypt(pw)

                Dim insCmd As New OleDbCommand("INSERT INTO tblStaff (UserName, UnPassword, AccessLevel, FullName, Role, Phone, Salary) " &
                                              "VALUES (@un, @pw, @acc, @fn, @ro, @ph, @sal)", cn)
                insCmd.Parameters.AddWithValue("@un", un)
                insCmd.Parameters.AddWithValue("@pw", encPw)
                insCmd.Parameters.AddWithValue("@acc", 2) ' AccessLevel 2 = Waiter
                insCmd.Parameters.AddWithValue("@fn", fn)
                insCmd.Parameters.AddWithValue("@ro", "Waiter")
                insCmd.Parameters.AddWithValue("@ph", ph)
                insCmd.Parameters.AddWithValue("@sal", CDec(salVal))
                insCmd.ExecuteNonQuery()

                MessageBox.Show("Waiter '" & fn & "' successfully added to the staff roster!", "Waiter Registered", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DialogResult = DialogResult.OK
                Me.Close()

            Catch ex As Exception
                MessageBox.Show("Error saving waiter: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                DbClose()
            End Try
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class
