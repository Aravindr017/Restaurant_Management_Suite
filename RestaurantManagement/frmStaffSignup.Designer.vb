<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStaffSignup
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then components.Dispose()
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblSubtitle = New System.Windows.Forms.Label()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.txtFullName = New System.Windows.Forms.TextBox()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.lblRole = New System.Windows.Forms.Label()
        Me.cboRole = New System.Windows.Forms.ComboBox()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.lblNotice = New System.Windows.Forms.Label()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.pnlHeader.SuspendLayout()
        Me.SuspendLayout()

        ' pnlHeader
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(30, 64, 175)
        Me.pnlHeader.Controls.Add(Me.lblTitle)
        Me.pnlHeader.Controls.Add(Me.lblSubtitle)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(480, 70)
        Me.pnlHeader.TabIndex = 0

        ' lblTitle
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(18, 10)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Text = "Staff Job Application - Spice Garden"

        ' lblSubtitle
        Me.lblSubtitle.AutoSize = True
        Me.lblSubtitle.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblSubtitle.ForeColor = System.Drawing.Color.LightBlue
        Me.lblSubtitle.Location = New System.Drawing.Point(20, 46)
        Me.lblSubtitle.Name = "lblSubtitle"
        Me.lblSubtitle.Text = "Submit your application — owner will review and approve your account"

        ' lblFullName
        Me.lblFullName.AutoSize = True
        Me.lblFullName.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.lblFullName.Location = New System.Drawing.Point(20, 88)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Text = "Full Name: *"

        ' txtFullName
        Me.txtFullName.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtFullName.Location = New System.Drawing.Point(155, 85)
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.Size = New System.Drawing.Size(295, 24)

        ' lblUserName
        Me.lblUserName.AutoSize = True
        Me.lblUserName.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.lblUserName.Location = New System.Drawing.Point(20, 126)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Text = "Username: *"

        ' txtUserName
        Me.txtUserName.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtUserName.Location = New System.Drawing.Point(155, 123)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(295, 24)

        ' lblPassword
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.lblPassword.Location = New System.Drawing.Point(20, 164)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Text = "Password: *"

        ' txtPassword
        Me.txtPassword.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtPassword.Location = New System.Drawing.Point(155, 161)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = "*"c
        Me.txtPassword.Size = New System.Drawing.Size(295, 24)

        ' lblRole
        Me.lblRole.AutoSize = True
        Me.lblRole.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.lblRole.Location = New System.Drawing.Point(20, 202)
        Me.lblRole.Name = "lblRole"
        Me.lblRole.Text = "Applying For: *"

        ' cboRole
        Me.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRole.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.cboRole.FormattingEnabled = True
        Me.cboRole.Items.AddRange(New Object() {"Waiter", "Head Waiter", "Kitchen Staff", "Chef", "Bartender", "Cashier", "Cleaner", "Delivery Driver"})
        Me.cboRole.Location = New System.Drawing.Point(155, 199)
        Me.cboRole.Name = "cboRole"
        Me.cboRole.Size = New System.Drawing.Size(295, 24)
        Me.cboRole.SelectedIndex = 0

        ' lblPhone
        Me.lblPhone.AutoSize = True
        Me.lblPhone.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.lblPhone.Location = New System.Drawing.Point(20, 240)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Text = "Phone: *"

        ' txtPhone
        Me.txtPhone.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtPhone.Location = New System.Drawing.Point(155, 237)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(295, 24)

        ' lblEmail
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.lblEmail.Location = New System.Drawing.Point(20, 278)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Text = "Email:"

        ' txtEmail
        Me.txtEmail.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtEmail.Location = New System.Drawing.Point(155, 275)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(295, 24)

        ' lblAddress
        Me.lblAddress.AutoSize = True
        Me.lblAddress.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.lblAddress.Location = New System.Drawing.Point(20, 316)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Text = "Address:"

        ' txtAddress
        Me.txtAddress.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtAddress.Location = New System.Drawing.Point(155, 313)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(295, 24)

        ' lblNotes
        Me.lblNotes.AutoSize = True
        Me.lblNotes.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.lblNotes.Location = New System.Drawing.Point(20, 354)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Text = "Message / Notes:"

        ' txtNotes
        Me.txtNotes.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNotes.Location = New System.Drawing.Point(155, 351)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(295, 50)

        ' lblNotice
        Me.lblNotice.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Italic)
        Me.lblNotice.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.lblNotice.Location = New System.Drawing.Point(20, 415)
        Me.lblNotice.Name = "lblNotice"
        Me.lblNotice.Size = New System.Drawing.Size(430, 32)
        Me.lblNotice.Text = "Note: Your application will be reviewed by the restaurant owner. You can log in only after approval."

        ' btnSubmit
        Me.btnSubmit.BackColor = System.Drawing.Color.FromArgb(30, 64, 175)
        Me.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSubmit.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnSubmit.ForeColor = System.Drawing.Color.White
        Me.btnSubmit.Location = New System.Drawing.Point(155, 460)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(185, 36)
        Me.btnSubmit.Text = "Submit Application"
        Me.btnSubmit.UseVisualStyleBackColor = False

        ' btnCancel
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnCancel.Location = New System.Drawing.Point(350, 460)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 36)
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True

        ' frmStaffSignup
        Me.AcceptButton = Me.btnSubmit
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(480, 515)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.lblNotice)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.lblNotes)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.lblAddress)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.lblEmail)
        Me.Controls.Add(Me.txtPhone)
        Me.Controls.Add(Me.lblPhone)
        Me.Controls.Add(Me.cboRole)
        Me.Controls.Add(Me.lblRole)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.txtUserName)
        Me.Controls.Add(Me.lblUserName)
        Me.Controls.Add(Me.txtFullName)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStaffSignup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Staff Job Application - Spice Garden"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents lblFullName As Label
    Friend WithEvents txtFullName As TextBox
    Friend WithEvents lblUserName As Label
    Friend WithEvents txtUserName As TextBox
    Friend WithEvents lblPassword As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents lblRole As Label
    Friend WithEvents cboRole As ComboBox
    Friend WithEvents lblPhone As Label
    Friend WithEvents txtPhone As TextBox
    Friend WithEvents lblEmail As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents lblAddress As Label
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents lblNotes As Label
    Friend WithEvents txtNotes As TextBox
    Friend WithEvents lblNotice As Label
    Friend WithEvents btnSubmit As Button
    Friend WithEvents btnCancel As Button
End Class
