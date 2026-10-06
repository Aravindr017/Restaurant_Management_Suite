<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogIn
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblSubtitle = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.grpStaffLogin = New System.Windows.Forms.GroupBox()
        Me.lblHint = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnLogIn = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.grpCustomerOrder = New System.Windows.Forms.GroupBox()
        Me.btnCustomerEnter = New System.Windows.Forms.Button()
        Me.lblTablePrompt = New System.Windows.Forms.Label()
        Me.cboTableSelect = New System.Windows.Forms.ComboBox()
        Me.lblCustomerNote = New System.Windows.Forms.Label()
        Me.pnlHeader.SuspendLayout()
        Me.grpStaffLogin.SuspendLayout()
        Me.grpCustomerOrder.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(43, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.pnlHeader.Controls.Add(Me.lblSubtitle)
        Me.pnlHeader.Controls.Add(Me.lblTitle)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(584, 80)
        Me.pnlHeader.TabIndex = 0
        '
        'lblSubtitle
        '
        Me.lblSubtitle.AutoSize = True
        Me.lblSubtitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubtitle.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblSubtitle.Location = New System.Drawing.Point(22, 48)
        Me.lblSubtitle.Name = "lblSubtitle"
        Me.lblSubtitle.Size = New System.Drawing.Size(325, 15)
        Me.lblSubtitle.TabIndex = 1
        Me.lblSubtitle.Text = "Multi-Role Portal: Owner, Waiter & Real-Time Table Ordering"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(20, 15)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(306, 30)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Restaurant Management Suite"
        '
        'grpStaffLogin
        '
        Me.grpStaffLogin.Controls.Add(Me.lblHint)
        Me.grpStaffLogin.Controls.Add(Me.btnExit)
        Me.grpStaffLogin.Controls.Add(Me.btnLogIn)
        Me.grpStaffLogin.Controls.Add(Me.txtPassword)
        Me.grpStaffLogin.Controls.Add(Me.txtUserName)
        Me.grpStaffLogin.Controls.Add(Me.lblPassword)
        Me.grpStaffLogin.Controls.Add(Me.lblUserName)
        Me.grpStaffLogin.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpStaffLogin.Location = New System.Drawing.Point(25, 95)
        Me.grpStaffLogin.Name = "grpStaffLogin"
        Me.grpStaffLogin.Size = New System.Drawing.Size(534, 215)
        Me.grpStaffLogin.TabIndex = 1
        Me.grpStaffLogin.TabStop = False
        Me.grpStaffLogin.Text = "Staff Authentication (Owner / Waiters)"
        '
        'lblHint
        '
        Me.lblHint.AutoSize = True
        Me.lblHint.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHint.ForeColor = System.Drawing.Color.DimGray
        Me.lblHint.Location = New System.Drawing.Point(125, 120)
        Me.lblHint.Name = "lblHint"
        Me.lblHint.Size = New System.Drawing.Size(325, 13)
        Me.lblHint.TabIndex = 6
        Me.lblHint.Text = "Defaults: Owner = owner / admin123  |  Waiter = waiter1 / waiter123"
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnExit.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(340, 150)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(110, 36)
        Me.btnExit.TabIndex = 5
        Me.btnExit.Text = "Exit System"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'btnLogIn
        '
        Me.btnLogIn.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnLogIn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnLogIn.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogIn.Location = New System.Drawing.Point(128, 150)
        Me.btnLogIn.Name = "btnLogIn"
        Me.btnLogIn.Size = New System.Drawing.Size(195, 36)
        Me.btnLogIn.TabIndex = 4
        Me.btnLogIn.Text = "Sign In (Verify & Enter)"
        Me.btnLogIn.UseVisualStyleBackColor = False
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(128, 80)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(322, 24)
        Me.txtPassword.TabIndex = 3
        '
        'txtUserName
        '
        Me.txtUserName.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserName.Location = New System.Drawing.Point(128, 40)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(322, 24)
        Me.txtUserName.TabIndex = 1
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPassword.Location = New System.Drawing.Point(25, 83)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(67, 17)
        Me.lblPassword.TabIndex = 2
        Me.lblPassword.Text = "Password:"
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = True
        Me.lblUserName.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserName.Location = New System.Drawing.Point(25, 43)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(70, 17)
        Me.lblUserName.TabIndex = 0
        Me.lblUserName.Text = "Username:"
        '
        'grpCustomerOrder
        '
        Me.grpCustomerOrder.Controls.Add(Me.btnCustomerEnter)
        Me.grpCustomerOrder.Controls.Add(Me.lblTablePrompt)
        Me.grpCustomerOrder.Controls.Add(Me.cboTableSelect)
        Me.grpCustomerOrder.Controls.Add(Me.lblCustomerNote)
        Me.grpCustomerOrder.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpCustomerOrder.Location = New System.Drawing.Point(25, 325)
        Me.grpCustomerOrder.Name = "grpCustomerOrder"
        Me.grpCustomerOrder.Size = New System.Drawing.Size(534, 130)
        Me.grpCustomerOrder.TabIndex = 2
        Me.grpCustomerOrder.TabStop = False
        Me.grpCustomerOrder.Text = "Customer / Table Self-Service (Food Order & Live Wait Time)"
        '
        'btnCustomerEnter
        '
        Me.btnCustomerEnter.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCustomerEnter.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCustomerEnter.Location = New System.Drawing.Point(280, 70)
        Me.btnCustomerEnter.Name = "btnCustomerEnter"
        Me.btnCustomerEnter.Size = New System.Drawing.Size(235, 36)
        Me.btnCustomerEnter.TabIndex = 3
        Me.btnCustomerEnter.Text = "Open Menu & Order for Table"
        Me.btnCustomerEnter.UseVisualStyleBackColor = True
        '
        'lblTablePrompt
        '
        Me.lblTablePrompt.AutoSize = True
        Me.lblTablePrompt.Location = New System.Drawing.Point(25, 78)
        Me.lblTablePrompt.Name = "lblTablePrompt"
        Me.lblTablePrompt.Size = New System.Drawing.Size(81, 17)
        Me.lblTablePrompt.TabIndex = 1
        Me.lblTablePrompt.Text = "Select Table:"
        '
        'cboTableSelect
        '
        Me.cboTableSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTableSelect.FormattingEnabled = True
        Me.cboTableSelect.Items.AddRange(New Object() {"Table 1 (2 Seats)", "Table 2 (4 Seats)", "Table 3 (4 Seats)", "Table 4 (6 Seats)", "Table 5 (2 Seats)", "Table 6 (8 Seats)"})
        Me.cboTableSelect.Location = New System.Drawing.Point(128, 75)
        Me.cboTableSelect.Name = "cboTableSelect"
        Me.cboTableSelect.Size = New System.Drawing.Size(140, 24)
        Me.cboTableSelect.TabIndex = 2
        '
        'lblCustomerNote
        '
        Me.lblCustomerNote.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomerNote.ForeColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.lblCustomerNote.Location = New System.Drawing.Point(25, 28)
        Me.lblCustomerNote.Name = "lblCustomerNote"
        Me.lblCustomerNote.Size = New System.Drawing.Size(490, 36)
        Me.lblCustomerNote.TabIndex = 0
        Me.lblCustomerNote.Text = "Customers can select their table, order dishes directly from the interactive menu" &
    ", and watch real-time kitchen preparation status and wait time countdowns."
        '
        'frmLogIn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(584, 475)
        Me.Controls.Add(Me.grpCustomerOrder)
        Me.Controls.Add(Me.grpStaffLogin)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmLogIn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Restaurant Management Suite - Sign In"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.grpStaffLogin.ResumeLayout(False)
        Me.grpStaffLogin.PerformLayout()
        Me.grpCustomerOrder.ResumeLayout(False)
        Me.grpCustomerOrder.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents grpStaffLogin As GroupBox
    Friend WithEvents btnExit As Button
    Friend WithEvents btnLogIn As Button
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtUserName As TextBox
    Friend WithEvents lblPassword As Label
    Friend WithEvents lblUserName As Label
    Friend WithEvents lblHint As Label
    Friend WithEvents grpCustomerOrder As GroupBox
    Friend WithEvents btnCustomerEnter As Button
    Friend WithEvents lblTablePrompt As Label
    Friend WithEvents cboTableSelect As ComboBox
    Friend WithEvents lblCustomerNote As Label
End Class
