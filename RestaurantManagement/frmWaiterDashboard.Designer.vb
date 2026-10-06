<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWaiterDashboard
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
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.lblAssignedTables = New System.Windows.Forms.Label()
        Me.lblWaiterName = New System.Windows.Forms.Label()
        Me.splMain = New System.Windows.Forms.SplitContainer()
        Me.grpTables = New System.Windows.Forms.GroupBox()
        Me.btnSetTableFree = New System.Windows.Forms.Button()
        Me.btnTakeOrder = New System.Windows.Forms.Button()
        Me.dgvMyTables = New System.Windows.Forms.DataGridView()
        Me.grpOrders = New System.Windows.Forms.GroupBox()
        Me.grpOrderDetails = New System.Windows.Forms.GroupBox()
        Me.dgvOrderItems = New System.Windows.Forms.DataGridView()
        Me.pnlWorkflow = New System.Windows.Forms.Panel()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnSetCompleted = New System.Windows.Forms.Button()
        Me.btnSetServed = New System.Windows.Forms.Button()
        Me.btnSetReady = New System.Windows.Forms.Button()
        Me.btnSetPreparing = New System.Windows.Forms.Button()
        Me.dgvOrders = New System.Windows.Forms.DataGridView()
        Me.pnlHeader.SuspendLayout()
        CType(Me.splMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splMain.Panel1.SuspendLayout()
        Me.splMain.Panel2.SuspendLayout()
        Me.splMain.SuspendLayout()
        Me.grpTables.SuspendLayout()
        CType(Me.dgvMyTables, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpOrders.SuspendLayout()
        Me.grpOrderDetails.SuspendLayout()
        CType(Me.dgvOrderItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlWorkflow.SuspendLayout()
        CType(Me.dgvOrders, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.pnlHeader.Controls.Add(Me.btnLogout)
        Me.pnlHeader.Controls.Add(Me.lblAssignedTables)
        Me.pnlHeader.Controls.Add(Me.lblWaiterName)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(964, 65)
        Me.pnlHeader.TabIndex = 0
        '
        'btnLogout
        '
        Me.btnLogout.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLogout.BackColor = System.Drawing.Color.IndianRed
        Me.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnLogout.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogout.Location = New System.Drawing.Point(850, 16)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(100, 32)
        Me.btnLogout.TabIndex = 2
        Me.btnLogout.Text = "Sign Out"
        Me.btnLogout.UseVisualStyleBackColor = False
        '
        'lblAssignedTables
        '
        Me.lblAssignedTables.AutoSize = True
        Me.lblAssignedTables.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAssignedTables.ForeColor = System.Drawing.Color.LightCyan
        Me.lblAssignedTables.Location = New System.Drawing.Point(20, 38)
        Me.lblAssignedTables.Name = "lblAssignedTables"
        Me.lblAssignedTables.Size = New System.Drawing.Size(175, 15)
        Me.lblAssignedTables.TabIndex = 1
        Me.lblAssignedTables.Text = "Your Assigned Tables: Loading..."
        '
        'lblWaiterName
        '
        Me.lblWaiterName.AutoSize = True
        Me.lblWaiterName.Font = New System.Drawing.Font("Segoe UI Semibold", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWaiterName.ForeColor = System.Drawing.Color.White
        Me.lblWaiterName.Location = New System.Drawing.Point(18, 12)
        Me.lblWaiterName.Name = "lblWaiterName"
        Me.lblWaiterName.Size = New System.Drawing.Size(200, 25)
        Me.lblWaiterName.TabIndex = 0
        Me.lblWaiterName.Text = "Waiter Service Station"
        '
        'splMain
        '
        Me.splMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splMain.Location = New System.Drawing.Point(0, 65)
        Me.splMain.Name = "splMain"
        '
        'splMain.Panel1
        '
        Me.splMain.Panel1.Controls.Add(Me.grpTables)
        Me.splMain.Panel1.Padding = New System.Windows.Forms.Padding(10)
        '
        'splMain.Panel2
        '
        Me.splMain.Panel2.Controls.Add(Me.grpOrders)
        Me.splMain.Panel2.Padding = New System.Windows.Forms.Padding(10)
        Me.splMain.Size = New System.Drawing.Size(964, 526)
        Me.splMain.SplitterDistance = 320
        Me.splMain.TabIndex = 1
        '
        'grpTables
        '
        Me.grpTables.Controls.Add(Me.btnSetTableFree)
        Me.grpTables.Controls.Add(Me.btnTakeOrder)
        Me.grpTables.Controls.Add(Me.dgvMyTables)
        Me.grpTables.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpTables.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTables.Location = New System.Drawing.Point(10, 10)
        Me.grpTables.Name = "grpTables"
        Me.grpTables.Padding = New System.Windows.Forms.Padding(8)
        Me.grpTables.Size = New System.Drawing.Size(300, 506)
        Me.grpTables.TabIndex = 0
        Me.grpTables.TabStop = False
        Me.grpTables.Text = "My Assigned Tables"
        '
        'btnSetTableFree
        '
        Me.btnSetTableFree.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSetTableFree.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSetTableFree.Location = New System.Drawing.Point(8, 465)
        Me.btnSetTableFree.Name = "btnSetTableFree"
        Me.btnSetTableFree.Size = New System.Drawing.Size(284, 32)
        Me.btnSetTableFree.TabIndex = 2
        Me.btnSetTableFree.Text = "Mark Table as Free"
        Me.btnSetTableFree.UseVisualStyleBackColor = True
        '
        'btnTakeOrder
        '
        Me.btnTakeOrder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTakeOrder.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnTakeOrder.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTakeOrder.Location = New System.Drawing.Point(8, 425)
        Me.btnTakeOrder.Name = "btnTakeOrder"
        Me.btnTakeOrder.Size = New System.Drawing.Size(284, 34)
        Me.btnTakeOrder.TabIndex = 1
        Me.btnTakeOrder.Text = "+ Take Order for Selected Table"
        Me.btnTakeOrder.UseVisualStyleBackColor = True
        '
        'dgvMyTables
        '
        Me.dgvMyTables.AllowUserToAddRows = False
        Me.dgvMyTables.AllowUserToDeleteRows = False
        Me.dgvMyTables.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvMyTables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvMyTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMyTables.Location = New System.Drawing.Point(8, 26)
        Me.dgvMyTables.MultiSelect = False
        Me.dgvMyTables.Name = "dgvMyTables"
        Me.dgvMyTables.ReadOnly = True
        Me.dgvMyTables.RowHeadersWidth = 35
        Me.dgvMyTables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMyTables.Size = New System.Drawing.Size(284, 390)
        Me.dgvMyTables.TabIndex = 0
        '
        'grpOrders
        '
        Me.grpOrders.Controls.Add(Me.grpOrderDetails)
        Me.grpOrders.Controls.Add(Me.pnlWorkflow)
        Me.grpOrders.Controls.Add(Me.dgvOrders)
        Me.grpOrders.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpOrders.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpOrders.Location = New System.Drawing.Point(10, 10)
        Me.grpOrders.Name = "grpOrders"
        Me.grpOrders.Padding = New System.Windows.Forms.Padding(8)
        Me.grpOrders.Size = New System.Drawing.Size(620, 506)
        Me.grpOrders.TabIndex = 0
        Me.grpOrders.TabStop = False
        Me.grpOrders.Text = "Active Table Orders & Food Status Workflow"
        '
        'grpOrderDetails
        '
        Me.grpOrderDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpOrderDetails.Controls.Add(Me.dgvOrderItems)
        Me.grpOrderDetails.Location = New System.Drawing.Point(8, 360)
        Me.grpOrderDetails.Name = "grpOrderDetails"
        Me.grpOrderDetails.Size = New System.Drawing.Size(604, 138)
        Me.grpOrderDetails.TabIndex = 2
        Me.grpOrderDetails.TabStop = False
        Me.grpOrderDetails.Text = "Items in Selected Order"
        '
        'dgvOrderItems
        '
        Me.dgvOrderItems.AllowUserToAddRows = False
        Me.dgvOrderItems.AllowUserToDeleteRows = False
        Me.dgvOrderItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOrderItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvOrderItems.Location = New System.Drawing.Point(3, 20)
        Me.dgvOrderItems.MultiSelect = False
        Me.dgvOrderItems.Name = "dgvOrderItems"
        Me.dgvOrderItems.ReadOnly = True
        Me.dgvOrderItems.RowHeadersWidth = 35
        Me.dgvOrderItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvOrderItems.Size = New System.Drawing.Size(598, 115)
        Me.dgvOrderItems.TabIndex = 0
        '
        'pnlWorkflow
        '
        Me.pnlWorkflow.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlWorkflow.Controls.Add(Me.btnRefresh)
        Me.pnlWorkflow.Controls.Add(Me.btnSetCompleted)
        Me.pnlWorkflow.Controls.Add(Me.btnSetServed)
        Me.pnlWorkflow.Controls.Add(Me.btnSetReady)
        Me.pnlWorkflow.Controls.Add(Me.btnSetPreparing)
        Me.pnlWorkflow.Location = New System.Drawing.Point(8, 305)
        Me.pnlWorkflow.Name = "pnlWorkflow"
        Me.pnlWorkflow.Size = New System.Drawing.Size(604, 48)
        Me.pnlWorkflow.TabIndex = 1
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnRefresh.Location = New System.Drawing.Point(515, 6)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(85, 34)
        Me.btnRefresh.TabIndex = 4
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'btnSetCompleted
        '
        Me.btnSetCompleted.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSetCompleted.Location = New System.Drawing.Point(380, 6)
        Me.btnSetCompleted.Name = "btnSetCompleted"
        Me.btnSetCompleted.Size = New System.Drawing.Size(120, 34)
        Me.btnSetCompleted.TabIndex = 3
        Me.btnSetCompleted.Text = "Paid / Clear"
        Me.btnSetCompleted.UseVisualStyleBackColor = True
        '
        'btnSetServed
        '
        Me.btnSetServed.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSetServed.Location = New System.Drawing.Point(255, 6)
        Me.btnSetServed.Name = "btnSetServed"
        Me.btnSetServed.Size = New System.Drawing.Size(115, 34)
        Me.btnSetServed.TabIndex = 2
        Me.btnSetServed.Text = "Mark Served"
        Me.btnSetServed.UseVisualStyleBackColor = True
        '
        'btnSetReady
        '
        Me.btnSetReady.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSetReady.Location = New System.Drawing.Point(140, 6)
        Me.btnSetReady.Name = "btnSetReady"
        Me.btnSetReady.Size = New System.Drawing.Size(105, 34)
        Me.btnSetReady.TabIndex = 1
        Me.btnSetReady.Text = "Food Ready"
        Me.btnSetReady.UseVisualStyleBackColor = True
        '
        'btnSetPreparing
        '
        Me.btnSetPreparing.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSetPreparing.Location = New System.Drawing.Point(5, 6)
        Me.btnSetPreparing.Name = "btnSetPreparing"
        Me.btnSetPreparing.Size = New System.Drawing.Size(125, 34)
        Me.btnSetPreparing.TabIndex = 0
        Me.btnSetPreparing.Text = "Set Preparing"
        Me.btnSetPreparing.UseVisualStyleBackColor = True
        '
        'dgvOrders
        '
        Me.dgvOrders.AllowUserToAddRows = False
        Me.dgvOrders.AllowUserToDeleteRows = False
        Me.dgvOrders.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOrders.Location = New System.Drawing.Point(8, 26)
        Me.dgvOrders.MultiSelect = False
        Me.dgvOrders.Name = "dgvOrders"
        Me.dgvOrders.ReadOnly = True
        Me.dgvOrders.RowHeadersWidth = 35
        Me.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvOrders.Size = New System.Drawing.Size(604, 270)
        Me.dgvOrders.TabIndex = 0
        '
        'frmWaiterDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 591)
        Me.Controls.Add(Me.splMain)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "frmWaiterDashboard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Waiter Service Station - Restaurant Management"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.splMain.Panel1.ResumeLayout(False)
        Me.splMain.Panel2.ResumeLayout(False)
        CType(Me.splMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splMain.ResumeLayout(False)
        Me.grpTables.ResumeLayout(False)
        CType(Me.dgvMyTables, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpOrders.ResumeLayout(False)
        Me.grpOrderDetails.ResumeLayout(False)
        CType(Me.dgvOrderItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlWorkflow.ResumeLayout(False)
        CType(Me.dgvOrders, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents btnLogout As Button
    Friend WithEvents lblAssignedTables As Label
    Friend WithEvents lblWaiterName As Label
    Friend WithEvents splMain As SplitContainer
    Friend WithEvents grpTables As GroupBox
    Friend WithEvents dgvMyTables As DataGridView
    Friend WithEvents btnSetTableFree As Button
    Friend WithEvents btnTakeOrder As Button
    Friend WithEvents grpOrders As GroupBox
    Friend WithEvents dgvOrders As DataGridView
    Friend WithEvents pnlWorkflow As Panel
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnSetCompleted As Button
    Friend WithEvents btnSetServed As Button
    Friend WithEvents btnSetReady As Button
    Friend WithEvents btnSetPreparing As Button
    Friend WithEvents grpOrderDetails As GroupBox
    Friend WithEvents dgvOrderItems As DataGridView
End Class
