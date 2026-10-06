<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOwnerDashboard
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
        Me.lblOwnerInfo = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.tabTables = New System.Windows.Forms.TabPage()
        Me.grpAssignWaiter = New System.Windows.Forms.GroupBox()
        Me.btnUpdateTableStatus = New System.Windows.Forms.Button()
        Me.cboTableStatus = New System.Windows.Forms.ComboBox()
        Me.lblTableStatus = New System.Windows.Forms.Label()
        Me.btnAssignWaiter = New System.Windows.Forms.Button()
        Me.cboWaitersForAssign = New System.Windows.Forms.ComboBox()
        Me.lblSelectWaiter = New System.Windows.Forms.Label()
        Me.lblSelectedTableInfo = New System.Windows.Forms.Label()
        Me.dgvTables = New System.Windows.Forms.DataGridView()
        Me.tabWaiters = New System.Windows.Forms.TabPage()
        Me.pnlWaiterActions = New System.Windows.Forms.Panel()
        Me.btnRefreshWaiters = New System.Windows.Forms.Button()
        Me.btnDeleteWaiter = New System.Windows.Forms.Button()
        Me.btnAddNewWaiter = New System.Windows.Forms.Button()
        Me.dgvWaiters = New System.Windows.Forms.DataGridView()
        Me.tabMenu = New System.Windows.Forms.TabPage()
        Me.grpMenuItemEdit = New System.Windows.Forms.GroupBox()
        Me.txtItemDescription = New System.Windows.Forms.TextBox()
        Me.lblDesc = New System.Windows.Forms.Label()
        Me.btnDeleteItem = New System.Windows.Forms.Button()
        Me.btnAddMenuItem = New System.Windows.Forms.Button()
        Me.txtPrepTime = New System.Windows.Forms.TextBox()
        Me.lblPrepTime = New System.Windows.Forms.Label()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.lblPrice = New System.Windows.Forms.Label()
        Me.cboCategory = New System.Windows.Forms.ComboBox()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.txtItemName = New System.Windows.Forms.TextBox()
        Me.lblItemName = New System.Windows.Forms.Label()
        Me.dgvMenu = New System.Windows.Forms.DataGridView()
        Me.tabOrdersAndStats = New System.Windows.Forms.TabPage()
        Me.pnlStatsCards = New System.Windows.Forms.Panel()
        Me.lblTotalSalesValue = New System.Windows.Forms.Label()
        Me.lblTotalSalesTitle = New System.Windows.Forms.Label()
        Me.lblActiveOrdersValue = New System.Windows.Forms.Label()
        Me.lblActiveOrdersTitle = New System.Windows.Forms.Label()
        Me.btnRefreshOrders = New System.Windows.Forms.Button()
        Me.dgvAllOrders = New System.Windows.Forms.DataGridView()
        Me.pnlHeader.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.tabTables.SuspendLayout()
        Me.grpAssignWaiter.SuspendLayout()
        CType(Me.dgvTables, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabWaiters.SuspendLayout()
        Me.pnlWaiterActions.SuspendLayout()
        CType(Me.dgvWaiters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabMenu.SuspendLayout()
        Me.grpMenuItemEdit.SuspendLayout()
        CType(Me.dgvMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabOrdersAndStats.SuspendLayout()
        Me.pnlStatsCards.SuspendLayout()
        CType(Me.dgvAllOrders, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.pnlHeader.Controls.Add(Me.btnLogout)
        Me.pnlHeader.Controls.Add(Me.lblOwnerInfo)
        Me.pnlHeader.Controls.Add(Me.lblTitle)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(944, 65)
        Me.pnlHeader.TabIndex = 0
        '
        'btnLogout
        '
        Me.btnLogout.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLogout.BackColor = System.Drawing.Color.IndianRed
        Me.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnLogout.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogout.Location = New System.Drawing.Point(825, 16)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(100, 32)
        Me.btnLogout.TabIndex = 2
        Me.btnLogout.Text = "Sign Out"
        Me.btnLogout.UseVisualStyleBackColor = False
        '
        'lblOwnerInfo
        '
        Me.lblOwnerInfo.AutoSize = True
        Me.lblOwnerInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOwnerInfo.ForeColor = System.Drawing.Color.LightGray
        Me.lblOwnerInfo.Location = New System.Drawing.Point(20, 38)
        Me.lblOwnerInfo.Name = "lblOwnerInfo"
        Me.lblOwnerInfo.Size = New System.Drawing.Size(250, 15)
        Me.lblOwnerInfo.TabIndex = 1
        Me.lblOwnerInfo.Text = "Logged In: Owner | Full Administrative Control"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(18, 12)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(273, 25)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Restaurant Executive Manager"
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.tabTables)
        Me.tabMain.Controls.Add(Me.tabWaiters)
        Me.tabMain.Controls.Add(Me.tabMenu)
        Me.tabMain.Controls.Add(Me.tabOrdersAndStats)
        Me.tabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabMain.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabMain.Location = New System.Drawing.Point(0, 65)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(944, 526)
        Me.tabMain.TabIndex = 1
        '
        'tabTables
        '
        Me.tabTables.Controls.Add(Me.grpAssignWaiter)
        Me.tabTables.Controls.Add(Me.dgvTables)
        Me.tabTables.Location = New System.Drawing.Point(4, 25)
        Me.tabTables.Name = "tabTables"
        Me.tabTables.Padding = New System.Windows.Forms.Padding(10)
        Me.tabTables.Size = New System.Drawing.Size(936, 497)
        Me.tabTables.TabIndex = 0
        Me.tabTables.Text = "Tables & Waiter Assignment"
        Me.tabTables.UseVisualStyleBackColor = True
        '
        'grpAssignWaiter
        '
        Me.grpAssignWaiter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpAssignWaiter.Controls.Add(Me.btnUpdateTableStatus)
        Me.grpAssignWaiter.Controls.Add(Me.cboTableStatus)
        Me.grpAssignWaiter.Controls.Add(Me.lblTableStatus)
        Me.grpAssignWaiter.Controls.Add(Me.btnAssignWaiter)
        Me.grpAssignWaiter.Controls.Add(Me.cboWaitersForAssign)
        Me.grpAssignWaiter.Controls.Add(Me.lblSelectWaiter)
        Me.grpAssignWaiter.Controls.Add(Me.lblSelectedTableInfo)
        Me.grpAssignWaiter.Location = New System.Drawing.Point(10, 370)
        Me.grpAssignWaiter.Name = "grpAssignWaiter"
        Me.grpAssignWaiter.Size = New System.Drawing.Size(916, 115)
        Me.grpAssignWaiter.TabIndex = 1
        Me.grpAssignWaiter.TabStop = False
        Me.grpAssignWaiter.Text = "Assign Waiter / Update Selected Table"
        '
        'btnUpdateTableStatus
        '
        Me.btnUpdateTableStatus.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnUpdateTableStatus.Location = New System.Drawing.Point(745, 60)
        Me.btnUpdateTableStatus.Name = "btnUpdateTableStatus"
        Me.btnUpdateTableStatus.Size = New System.Drawing.Size(150, 32)
        Me.btnUpdateTableStatus.TabIndex = 6
        Me.btnUpdateTableStatus.Text = "Set Table Status"
        Me.btnUpdateTableStatus.UseVisualStyleBackColor = True
        '
        'cboTableStatus
        '
        Me.cboTableStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTableStatus.FormattingEnabled = True
        Me.cboTableStatus.Items.AddRange(New Object() {"Free", "Occupied", "Reserved", "Cleaning"})
        Me.cboTableStatus.Location = New System.Drawing.Point(595, 64)
        Me.cboTableStatus.Name = "cboTableStatus"
        Me.cboTableStatus.Size = New System.Drawing.Size(140, 24)
        Me.cboTableStatus.TabIndex = 5
        '
        'lblTableStatus
        '
        Me.lblTableStatus.AutoSize = True
        Me.lblTableStatus.Location = New System.Drawing.Point(505, 68)
        Me.lblTableStatus.Name = "lblTableStatus"
        Me.lblTableStatus.Size = New System.Drawing.Size(81, 17)
        Me.lblTableStatus.TabIndex = 4
        Me.lblTableStatus.Text = "Table Status:"
        '
        'btnAssignWaiter
        '
        Me.btnAssignWaiter.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnAssignWaiter.Location = New System.Drawing.Point(315, 60)
        Me.btnAssignWaiter.Name = "btnAssignWaiter"
        Me.btnAssignWaiter.Size = New System.Drawing.Size(160, 32)
        Me.btnAssignWaiter.TabIndex = 3
        Me.btnAssignWaiter.Text = "Assign Waiter"
        Me.btnAssignWaiter.UseVisualStyleBackColor = True
        '
        'cboWaitersForAssign
        '
        Me.cboWaitersForAssign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboWaitersForAssign.FormattingEnabled = True
        Me.cboWaitersForAssign.Location = New System.Drawing.Point(105, 64)
        Me.cboWaitersForAssign.Name = "cboWaitersForAssign"
        Me.cboWaitersForAssign.Size = New System.Drawing.Size(195, 24)
        Me.cboWaitersForAssign.TabIndex = 2
        '
        'lblSelectWaiter
        '
        Me.lblSelectWaiter.AutoSize = True
        Me.lblSelectWaiter.Location = New System.Drawing.Point(15, 67)
        Me.lblSelectWaiter.Name = "lblSelectWaiter"
        Me.lblSelectWaiter.Size = New System.Drawing.Size(87, 17)
        Me.lblSelectWaiter.TabIndex = 1
        Me.lblSelectWaiter.Text = "Select Waiter:"
        '
        'lblSelectedTableInfo
        '
        Me.lblSelectedTableInfo.AutoSize = True
        Me.lblSelectedTableInfo.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectedTableInfo.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblSelectedTableInfo.Location = New System.Drawing.Point(15, 30)
        Me.lblSelectedTableInfo.Name = "lblSelectedTableInfo"
        Me.lblSelectedTableInfo.Size = New System.Drawing.Size(275, 17)
        Me.lblSelectedTableInfo.TabIndex = 0
        Me.lblSelectedTableInfo.Text = "Select a table from the grid above to modify."
        '
        'dgvTables
        '
        Me.dgvTables.AllowUserToAddRows = False
        Me.dgvTables.AllowUserToDeleteRows = False
        Me.dgvTables.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTables.Location = New System.Drawing.Point(10, 10)
        Me.dgvTables.MultiSelect = False
        Me.dgvTables.Name = "dgvTables"
        Me.dgvTables.ReadOnly = True
        Me.dgvTables.RowHeadersWidth = 51
        Me.dgvTables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTables.Size = New System.Drawing.Size(916, 350)
        Me.dgvTables.TabIndex = 0
        '
        'tabWaiters
        '
        Me.tabWaiters.Controls.Add(Me.pnlWaiterActions)
        Me.tabWaiters.Controls.Add(Me.dgvWaiters)
        Me.tabWaiters.Location = New System.Drawing.Point(4, 25)
        Me.tabWaiters.Name = "tabWaiters"
        Me.tabWaiters.Padding = New System.Windows.Forms.Padding(10)
        Me.tabWaiters.Size = New System.Drawing.Size(936, 497)
        Me.tabWaiters.TabIndex = 1
        Me.tabWaiters.Text = "Staff / Waiter Roster"
        Me.tabWaiters.UseVisualStyleBackColor = True
        '
        'pnlWaiterActions
        '
        Me.pnlWaiterActions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlWaiterActions.Controls.Add(Me.btnRefreshWaiters)
        Me.pnlWaiterActions.Controls.Add(Me.btnDeleteWaiter)
        Me.pnlWaiterActions.Controls.Add(Me.btnAddNewWaiter)
        Me.pnlWaiterActions.Location = New System.Drawing.Point(10, 435)
        Me.pnlWaiterActions.Name = "pnlWaiterActions"
        Me.pnlWaiterActions.Size = New System.Drawing.Size(916, 50)
        Me.pnlWaiterActions.TabIndex = 1
        '
        'btnRefreshWaiters
        '
        Me.btnRefreshWaiters.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefreshWaiters.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnRefreshWaiters.Location = New System.Drawing.Point(760, 8)
        Me.btnRefreshWaiters.Name = "btnRefreshWaiters"
        Me.btnRefreshWaiters.Size = New System.Drawing.Size(150, 34)
        Me.btnRefreshWaiters.TabIndex = 2
        Me.btnRefreshWaiters.Text = "Refresh Roster"
        Me.btnRefreshWaiters.UseVisualStyleBackColor = True
        '
        'btnDeleteWaiter
        '
        Me.btnDeleteWaiter.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnDeleteWaiter.Location = New System.Drawing.Point(190, 8)
        Me.btnDeleteWaiter.Name = "btnDeleteWaiter"
        Me.btnDeleteWaiter.Size = New System.Drawing.Size(170, 34)
        Me.btnDeleteWaiter.TabIndex = 1
        Me.btnDeleteWaiter.Text = "Remove Selected Waiter"
        Me.btnDeleteWaiter.UseVisualStyleBackColor = True
        '
        'btnAddNewWaiter
        '
        Me.btnAddNewWaiter.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnAddNewWaiter.Location = New System.Drawing.Point(10, 8)
        Me.btnAddNewWaiter.Name = "btnAddNewWaiter"
        Me.btnAddNewWaiter.Size = New System.Drawing.Size(165, 34)
        Me.btnAddNewWaiter.TabIndex = 0
        Me.btnAddNewWaiter.Text = "Add New Waiter..."
        Me.btnAddNewWaiter.UseVisualStyleBackColor = True
        '
        'dgvWaiters
        '
        Me.dgvWaiters.AllowUserToAddRows = False
        Me.dgvWaiters.AllowUserToDeleteRows = False
        Me.dgvWaiters.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvWaiters.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvWaiters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvWaiters.Location = New System.Drawing.Point(10, 10)
        Me.dgvWaiters.MultiSelect = False
        Me.dgvWaiters.Name = "dgvWaiters"
        Me.dgvWaiters.ReadOnly = True
        Me.dgvWaiters.RowHeadersWidth = 51
        Me.dgvWaiters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvWaiters.Size = New System.Drawing.Size(916, 415)
        Me.dgvWaiters.TabIndex = 0
        '
        'tabMenu
        '
        Me.tabMenu.Controls.Add(Me.grpMenuItemEdit)
        Me.tabMenu.Controls.Add(Me.dgvMenu)
        Me.tabMenu.Location = New System.Drawing.Point(4, 25)
        Me.tabMenu.Name = "tabMenu"
        Me.tabMenu.Padding = New System.Windows.Forms.Padding(10)
        Me.tabMenu.Size = New System.Drawing.Size(936, 497)
        Me.tabMenu.TabIndex = 2
        Me.tabMenu.Text = "Menu Catalog & Prep Times"
        Me.tabMenu.UseVisualStyleBackColor = True
        '
        'grpMenuItemEdit
        '
        Me.grpMenuItemEdit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpMenuItemEdit.Controls.Add(Me.txtItemDescription)
        Me.grpMenuItemEdit.Controls.Add(Me.lblDesc)
        Me.grpMenuItemEdit.Controls.Add(Me.btnDeleteItem)
        Me.grpMenuItemEdit.Controls.Add(Me.btnAddMenuItem)
        Me.grpMenuItemEdit.Controls.Add(Me.txtPrepTime)
        Me.grpMenuItemEdit.Controls.Add(Me.lblPrepTime)
        Me.grpMenuItemEdit.Controls.Add(Me.txtPrice)
        Me.grpMenuItemEdit.Controls.Add(Me.lblPrice)
        Me.grpMenuItemEdit.Controls.Add(Me.cboCategory)
        Me.grpMenuItemEdit.Controls.Add(Me.lblCategory)
        Me.grpMenuItemEdit.Controls.Add(Me.txtItemName)
        Me.grpMenuItemEdit.Controls.Add(Me.lblItemName)
        Me.grpMenuItemEdit.Location = New System.Drawing.Point(10, 310)
        Me.grpMenuItemEdit.Name = "grpMenuItemEdit"
        Me.grpMenuItemEdit.Size = New System.Drawing.Size(916, 175)
        Me.grpMenuItemEdit.TabIndex = 1
        Me.grpMenuItemEdit.TabStop = False
        Me.grpMenuItemEdit.Text = "Add / Manage Dishes & Preparation Times"
        '
        'txtItemDescription
        '
        Me.txtItemDescription.Location = New System.Drawing.Point(105, 100)
        Me.txtItemDescription.Multiline = True
        Me.txtItemDescription.Name = "txtItemDescription"
        Me.txtItemDescription.Size = New System.Drawing.Size(565, 55)
        Me.txtItemDescription.TabIndex = 9
        '
        'lblDesc
        '
        Me.lblDesc.AutoSize = True
        Me.lblDesc.Location = New System.Drawing.Point(15, 103)
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Size = New System.Drawing.Size(77, 17)
        Me.lblDesc.TabIndex = 8
        Me.lblDesc.Text = "Description:"
        '
        'btnDeleteItem
        '
        Me.btnDeleteItem.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnDeleteItem.Location = New System.Drawing.Point(710, 100)
        Me.btnDeleteItem.Name = "btnDeleteItem"
        Me.btnDeleteItem.Size = New System.Drawing.Size(185, 36)
        Me.btnDeleteItem.TabIndex = 11
        Me.btnDeleteItem.Text = "Delete Selected Dish"
        Me.btnDeleteItem.UseVisualStyleBackColor = True
        '
        'btnAddMenuItem
        '
        Me.btnAddMenuItem.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnAddMenuItem.Location = New System.Drawing.Point(710, 50)
        Me.btnAddMenuItem.Name = "btnAddMenuItem"
        Me.btnAddMenuItem.Size = New System.Drawing.Size(185, 36)
        Me.btnAddMenuItem.TabIndex = 10
        Me.btnAddMenuItem.Text = "Save / Add to Menu"
        Me.btnAddMenuItem.UseVisualStyleBackColor = True
        '
        'txtPrepTime
        '
        Me.txtPrepTime.Location = New System.Drawing.Point(545, 63)
        Me.txtPrepTime.Name = "txtPrepTime"
        Me.txtPrepTime.Size = New System.Drawing.Size(125, 24)
        Me.txtPrepTime.TabIndex = 7
        '
        'lblPrepTime
        '
        Me.lblPrepTime.AutoSize = True
        Me.lblPrepTime.Location = New System.Drawing.Point(425, 66)
        Me.lblPrepTime.Name = "lblPrepTime"
        Me.lblPrepTime.Size = New System.Drawing.Size(107, 17)
        Me.lblPrepTime.TabIndex = 6
        Me.lblPrepTime.Text = "Prep Time (min):"
        '
        'txtPrice
        '
        Me.txtPrice.Location = New System.Drawing.Point(315, 63)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(95, 24)
        Me.txtPrice.TabIndex = 5
        '
        'lblPrice
        '
        Me.lblPrice.AutoSize = True
        Me.lblPrice.Location = New System.Drawing.Point(245, 66)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.Size = New System.Drawing.Size(62, 17)
        Me.lblPrice.TabIndex = 4
        Me.lblPrice.Text = "Price ($):"
        '
        'cboCategory
        '
        Me.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Items.AddRange(New Object() {"Starters", "Mains", "Desserts", "Beverages"})
        Me.cboCategory.Location = New System.Drawing.Point(105, 63)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(125, 24)
        Me.cboCategory.TabIndex = 3
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Location = New System.Drawing.Point(15, 66)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(64, 17)
        Me.lblCategory.TabIndex = 2
        Me.lblCategory.Text = "Category:"
        '
        'txtItemName
        '
        Me.txtItemName.Location = New System.Drawing.Point(105, 28)
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.Size = New System.Drawing.Size(565, 24)
        Me.txtItemName.TabIndex = 1
        '
        'lblItemName
        '
        Me.lblItemName.AutoSize = True
        Me.lblItemName.Location = New System.Drawing.Point(15, 31)
        Me.lblItemName.Name = "lblItemName"
        Me.lblItemName.Size = New System.Drawing.Size(75, 17)
        Me.lblItemName.TabIndex = 0
        Me.lblItemName.Text = "Dish Name:"
        '
        'dgvMenu
        '
        Me.dgvMenu.AllowUserToAddRows = False
        Me.dgvMenu.AllowUserToDeleteRows = False
        Me.dgvMenu.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvMenu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMenu.Location = New System.Drawing.Point(10, 10)
        Me.dgvMenu.MultiSelect = False
        Me.dgvMenu.Name = "dgvMenu"
        Me.dgvMenu.ReadOnly = True
        Me.dgvMenu.RowHeadersWidth = 51
        Me.dgvMenu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMenu.Size = New System.Drawing.Size(916, 290)
        Me.dgvMenu.TabIndex = 0
        '
        'tabOrdersAndStats
        '
        Me.tabOrdersAndStats.Controls.Add(Me.pnlStatsCards)
        Me.tabOrdersAndStats.Controls.Add(Me.dgvAllOrders)
        Me.tabOrdersAndStats.Location = New System.Drawing.Point(4, 25)
        Me.tabOrdersAndStats.Name = "tabOrdersAndStats"
        Me.tabOrdersAndStats.Padding = New System.Windows.Forms.Padding(10)
        Me.tabOrdersAndStats.Size = New System.Drawing.Size(936, 497)
        Me.tabOrdersAndStats.TabIndex = 3
        Me.tabOrdersAndStats.Text = "Live Orders & Revenue Stats"
        Me.tabOrdersAndStats.UseVisualStyleBackColor = True
        '
        'pnlStatsCards
        '
        Me.pnlStatsCards.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlStatsCards.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.pnlStatsCards.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlStatsCards.Controls.Add(Me.lblTotalSalesValue)
        Me.pnlStatsCards.Controls.Add(Me.lblTotalSalesTitle)
        Me.pnlStatsCards.Controls.Add(Me.lblActiveOrdersValue)
        Me.pnlStatsCards.Controls.Add(Me.lblActiveOrdersTitle)
        Me.pnlStatsCards.Controls.Add(Me.btnRefreshOrders)
        Me.pnlStatsCards.Location = New System.Drawing.Point(10, 415)
        Me.pnlStatsCards.Name = "pnlStatsCards"
        Me.pnlStatsCards.Size = New System.Drawing.Size(916, 70)
        Me.pnlStatsCards.TabIndex = 1
        '
        'lblTotalSalesValue
        '
        Me.lblTotalSalesValue.AutoSize = True
        Me.lblTotalSalesValue.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalSalesValue.ForeColor = System.Drawing.Color.ForestGreen
        Me.lblTotalSalesValue.Location = New System.Drawing.Point(340, 32)
        Me.lblTotalSalesValue.Name = "lblTotalSalesValue"
        Me.lblTotalSalesValue.Size = New System.Drawing.Size(51, 21)
        Me.lblTotalSalesValue.TabIndex = 4
        Me.lblTotalSalesValue.Text = "$0.00"
        '
        'lblTotalSalesTitle
        '
        Me.lblTotalSalesTitle.AutoSize = True
        Me.lblTotalSalesTitle.ForeColor = System.Drawing.Color.DimGray
        Me.lblTotalSalesTitle.Location = New System.Drawing.Point(340, 10)
        Me.lblTotalSalesTitle.Name = "lblTotalSalesTitle"
        Me.lblTotalSalesTitle.Size = New System.Drawing.Size(126, 17)
        Me.lblTotalSalesTitle.TabIndex = 3
        Me.lblTotalSalesTitle.Text = "Total Gross Revenue:"
        '
        'lblActiveOrdersValue
        '
        Me.lblActiveOrdersValue.AutoSize = True
        Me.lblActiveOrdersValue.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActiveOrdersValue.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblActiveOrdersValue.Location = New System.Drawing.Point(30, 32)
        Me.lblActiveOrdersValue.Name = "lblActiveOrdersValue"
        Me.lblActiveOrdersValue.Size = New System.Drawing.Size(19, 21)
        Me.lblActiveOrdersValue.TabIndex = 2
        Me.lblActiveOrdersValue.Text = "0"
        '
        'lblActiveOrdersTitle
        '
        Me.lblActiveOrdersTitle.AutoSize = True
        Me.lblActiveOrdersTitle.ForeColor = System.Drawing.Color.DimGray
        Me.lblActiveOrdersTitle.Location = New System.Drawing.Point(30, 10)
        Me.lblActiveOrdersTitle.Name = "lblActiveOrdersTitle"
        Me.lblActiveOrdersTitle.Size = New System.Drawing.Size(189, 17)
        Me.lblActiveOrdersTitle.TabIndex = 1
        Me.lblActiveOrdersTitle.Text = "Active Cooking / Serving Queue:"
        '
        'btnRefreshOrders
        '
        Me.btnRefreshOrders.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefreshOrders.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnRefreshOrders.Location = New System.Drawing.Point(745, 18)
        Me.btnRefreshOrders.Name = "btnRefreshOrders"
        Me.btnRefreshOrders.Size = New System.Drawing.Size(155, 34)
        Me.btnRefreshOrders.TabIndex = 0
        Me.btnRefreshOrders.Text = "Refresh Monitor"
        Me.btnRefreshOrders.UseVisualStyleBackColor = True
        '
        'dgvAllOrders
        '
        Me.dgvAllOrders.AllowUserToAddRows = False
        Me.dgvAllOrders.AllowUserToDeleteRows = False
        Me.dgvAllOrders.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAllOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvAllOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAllOrders.Location = New System.Drawing.Point(10, 10)
        Me.dgvAllOrders.MultiSelect = False
        Me.dgvAllOrders.Name = "dgvAllOrders"
        Me.dgvAllOrders.ReadOnly = True
        Me.dgvAllOrders.RowHeadersWidth = 51
        Me.dgvAllOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAllOrders.Size = New System.Drawing.Size(916, 395)
        Me.dgvAllOrders.TabIndex = 0
        '
        'frmOwnerDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(944, 591)
        Me.Controls.Add(Me.tabMain)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "frmOwnerDashboard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Owner Control Panel - Restaurant Management"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.tabMain.ResumeLayout(False)
        Me.tabTables.ResumeLayout(False)
        Me.grpAssignWaiter.ResumeLayout(False)
        Me.grpAssignWaiter.PerformLayout()
        CType(Me.dgvTables, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabWaiters.ResumeLayout(False)
        Me.pnlWaiterActions.ResumeLayout(False)
        CType(Me.dgvWaiters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabMenu.ResumeLayout(False)
        Me.grpMenuItemEdit.ResumeLayout(False)
        Me.grpMenuItemEdit.PerformLayout()
        CType(Me.dgvMenu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabOrdersAndStats.ResumeLayout(False)
        Me.pnlStatsCards.ResumeLayout(False)
        Me.pnlStatsCards.PerformLayout()
        CType(Me.dgvAllOrders, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents btnLogout As Button
    Friend WithEvents lblOwnerInfo As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents tabMain As TabControl
    Friend WithEvents tabTables As TabPage
    Friend WithEvents dgvTables As DataGridView
    Friend WithEvents grpAssignWaiter As GroupBox
    Friend WithEvents btnAssignWaiter As Button
    Friend WithEvents cboWaitersForAssign As ComboBox
    Friend WithEvents lblSelectWaiter As Label
    Friend WithEvents lblSelectedTableInfo As Label
    Friend WithEvents btnUpdateTableStatus As Button
    Friend WithEvents cboTableStatus As ComboBox
    Friend WithEvents lblTableStatus As Label
    Friend WithEvents tabWaiters As TabPage
    Friend WithEvents dgvWaiters As DataGridView
    Friend WithEvents pnlWaiterActions As Panel
    Friend WithEvents btnDeleteWaiter As Button
    Friend WithEvents btnAddNewWaiter As Button
    Friend WithEvents btnRefreshWaiters As Button
    Friend WithEvents tabMenu As TabPage
    Friend WithEvents dgvMenu As DataGridView
    Friend WithEvents grpMenuItemEdit As GroupBox
    Friend WithEvents txtItemDescription As TextBox
    Friend WithEvents lblDesc As Label
    Friend WithEvents btnDeleteItem As Button
    Friend WithEvents btnAddMenuItem As Button
    Friend WithEvents txtPrepTime As TextBox
    Friend WithEvents lblPrepTime As Label
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents lblPrice As Label
    Friend WithEvents cboCategory As ComboBox
    Friend WithEvents lblCategory As Label
    Friend WithEvents txtItemName As TextBox
    Friend WithEvents lblItemName As Label
    Friend WithEvents tabOrdersAndStats As TabPage
    Friend WithEvents dgvAllOrders As DataGridView
    Friend WithEvents pnlStatsCards As Panel
    Friend WithEvents btnRefreshOrders As Button
    Friend WithEvents lblTotalSalesValue As Label
    Friend WithEvents lblTotalSalesTitle As Label
    Friend WithEvents lblActiveOrdersValue As Label
    Friend WithEvents lblActiveOrdersTitle As Label
End Class
