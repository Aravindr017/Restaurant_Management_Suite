<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOwnerDashboard
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
        Me.txtIngredients = New System.Windows.Forms.TextBox()
        Me.lblIngredients = New System.Windows.Forms.Label()
        Me.txtItemDescription = New System.Windows.Forms.TextBox()
        Me.lblDesc = New System.Windows.Forms.Label()
        Me.btnDeleteItem = New System.Windows.Forms.Button()
        Me.btnClearMenuFields = New System.Windows.Forms.Button()
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
        Me.tabCustomers = New System.Windows.Forms.TabPage()
        Me.grpAddCustomer = New System.Windows.Forms.GroupBox()
        Me.txtCustNotes = New System.Windows.Forms.TextBox()
        Me.lblCustNotes = New System.Windows.Forms.Label()
        Me.txtCustCity = New System.Windows.Forms.TextBox()
        Me.lblCustCity = New System.Windows.Forms.Label()
        Me.txtCustEmail = New System.Windows.Forms.TextBox()
        Me.lblCustEmail = New System.Windows.Forms.Label()
        Me.txtCustPhone = New System.Windows.Forms.TextBox()
        Me.lblCustPhone = New System.Windows.Forms.Label()
        Me.txtCustName = New System.Windows.Forms.TextBox()
        Me.lblCustName = New System.Windows.Forms.Label()
        Me.btnAddCustomer = New System.Windows.Forms.Button()
        Me.btnDeleteCustomer = New System.Windows.Forms.Button()
        Me.btnRefreshCustomers = New System.Windows.Forms.Button()
        Me.dgvCustomers = New System.Windows.Forms.DataGridView()
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
        Me.tabCustomers.SuspendLayout()
        Me.grpAddCustomer.SuspendLayout()
        CType(Me.dgvCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()

        ' pnlHeader
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(24, 32, 42)
        Me.pnlHeader.Controls.Add(Me.btnLogout)
        Me.pnlHeader.Controls.Add(Me.lblOwnerInfo)
        Me.pnlHeader.Controls.Add(Me.lblTitle)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1020, 65)
        Me.pnlHeader.TabIndex = 0

        ' btnLogout
        Me.btnLogout.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLogout.BackColor = System.Drawing.Color.IndianRed
        Me.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnLogout.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnLogout.ForeColor = System.Drawing.Color.White
        Me.btnLogout.Location = New System.Drawing.Point(900, 16)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(105, 32)
        Me.btnLogout.TabIndex = 2
        Me.btnLogout.Text = "Sign Out"
        Me.btnLogout.UseVisualStyleBackColor = False

        ' lblOwnerInfo
        Me.lblOwnerInfo.AutoSize = True
        Me.lblOwnerInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblOwnerInfo.ForeColor = System.Drawing.Color.LightGray
        Me.lblOwnerInfo.Location = New System.Drawing.Point(20, 38)
        Me.lblOwnerInfo.Name = "lblOwnerInfo"
        Me.lblOwnerInfo.Size = New System.Drawing.Size(350, 15)
        Me.lblOwnerInfo.TabIndex = 1
        Me.lblOwnerInfo.Text = "Logged In: Owner | Spice Garden, Chennai"

        ' lblTitle
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(18, 10)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(350, 25)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Spice Garden - Owner Control Panel"

        ' tabMain
        Me.tabMain.Controls.Add(Me.tabTables)
        Me.tabMain.Controls.Add(Me.tabWaiters)
        Me.tabMain.Controls.Add(Me.tabMenu)
        Me.tabMain.Controls.Add(Me.tabOrdersAndStats)
        Me.tabMain.Controls.Add(Me.tabCustomers)
        Me.tabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabMain.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.tabMain.Location = New System.Drawing.Point(0, 65)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(1020, 560)
        Me.tabMain.TabIndex = 1

        ' tabTables
        Me.tabTables.Controls.Add(Me.grpAssignWaiter)
        Me.tabTables.Controls.Add(Me.dgvTables)
        Me.tabTables.Location = New System.Drawing.Point(4, 25)
        Me.tabTables.Name = "tabTables"
        Me.tabTables.Padding = New System.Windows.Forms.Padding(10)
        Me.tabTables.Size = New System.Drawing.Size(1012, 531)
        Me.tabTables.TabIndex = 0
        Me.tabTables.Text = "Tables & Waiter Assignment"
        Me.tabTables.UseVisualStyleBackColor = True

        ' grpAssignWaiter
        Me.grpAssignWaiter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpAssignWaiter.Controls.Add(Me.btnUpdateTableStatus)
        Me.grpAssignWaiter.Controls.Add(Me.cboTableStatus)
        Me.grpAssignWaiter.Controls.Add(Me.lblTableStatus)
        Me.grpAssignWaiter.Controls.Add(Me.btnAssignWaiter)
        Me.grpAssignWaiter.Controls.Add(Me.cboWaitersForAssign)
        Me.grpAssignWaiter.Controls.Add(Me.lblSelectWaiter)
        Me.grpAssignWaiter.Controls.Add(Me.lblSelectedTableInfo)
        Me.grpAssignWaiter.Location = New System.Drawing.Point(10, 408)
        Me.grpAssignWaiter.Name = "grpAssignWaiter"
        Me.grpAssignWaiter.Size = New System.Drawing.Size(992, 115)
        Me.grpAssignWaiter.TabIndex = 1
        Me.grpAssignWaiter.TabStop = False
        Me.grpAssignWaiter.Text = "Assign Waiter / Update Selected Table"

        ' btnUpdateTableStatus
        Me.btnUpdateTableStatus.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnUpdateTableStatus.Location = New System.Drawing.Point(810, 60)
        Me.btnUpdateTableStatus.Name = "btnUpdateTableStatus"
        Me.btnUpdateTableStatus.Size = New System.Drawing.Size(160, 32)
        Me.btnUpdateTableStatus.TabIndex = 6
        Me.btnUpdateTableStatus.Text = "Set Table Status"
        Me.btnUpdateTableStatus.UseVisualStyleBackColor = True

        ' cboTableStatus
        Me.cboTableStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTableStatus.FormattingEnabled = True
        Me.cboTableStatus.Items.AddRange(New Object() {"Free", "Occupied", "Reserved", "Cleaning"})
        Me.cboTableStatus.Location = New System.Drawing.Point(640, 64)
        Me.cboTableStatus.Name = "cboTableStatus"
        Me.cboTableStatus.Size = New System.Drawing.Size(155, 24)
        Me.cboTableStatus.TabIndex = 5

        ' lblTableStatus
        Me.lblTableStatus.AutoSize = True
        Me.lblTableStatus.Location = New System.Drawing.Point(545, 68)
        Me.lblTableStatus.Name = "lblTableStatus"
        Me.lblTableStatus.Size = New System.Drawing.Size(81, 17)
        Me.lblTableStatus.TabIndex = 4
        Me.lblTableStatus.Text = "Table Status:"

        ' btnAssignWaiter
        Me.btnAssignWaiter.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnAssignWaiter.Location = New System.Drawing.Point(340, 60)
        Me.btnAssignWaiter.Name = "btnAssignWaiter"
        Me.btnAssignWaiter.Size = New System.Drawing.Size(185, 32)
        Me.btnAssignWaiter.TabIndex = 3
        Me.btnAssignWaiter.Text = "Assign Waiter to Table"
        Me.btnAssignWaiter.UseVisualStyleBackColor = True

        ' cboWaitersForAssign
        Me.cboWaitersForAssign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboWaitersForAssign.FormattingEnabled = True
        Me.cboWaitersForAssign.Location = New System.Drawing.Point(115, 64)
        Me.cboWaitersForAssign.Name = "cboWaitersForAssign"
        Me.cboWaitersForAssign.Size = New System.Drawing.Size(210, 24)
        Me.cboWaitersForAssign.TabIndex = 2

        ' lblSelectWaiter
        Me.lblSelectWaiter.AutoSize = True
        Me.lblSelectWaiter.Location = New System.Drawing.Point(15, 67)
        Me.lblSelectWaiter.Name = "lblSelectWaiter"
        Me.lblSelectWaiter.Size = New System.Drawing.Size(90, 17)
        Me.lblSelectWaiter.TabIndex = 1
        Me.lblSelectWaiter.Text = "Select Waiter:"

        ' lblSelectedTableInfo
        Me.lblSelectedTableInfo.AutoSize = True
        Me.lblSelectedTableInfo.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblSelectedTableInfo.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblSelectedTableInfo.Location = New System.Drawing.Point(15, 30)
        Me.lblSelectedTableInfo.Name = "lblSelectedTableInfo"
        Me.lblSelectedTableInfo.Size = New System.Drawing.Size(295, 17)
        Me.lblSelectedTableInfo.TabIndex = 0
        Me.lblSelectedTableInfo.Text = "Select a table from the grid above to modify."

        ' dgvTables
        Me.dgvTables.AllowUserToAddRows = False
        Me.dgvTables.AllowUserToDeleteRows = False
        Me.dgvTables.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTables.Location = New System.Drawing.Point(10, 10)
        Me.dgvTables.MultiSelect = False
        Me.dgvTables.Name = "dgvTables"
        Me.dgvTables.ReadOnly = True
        Me.dgvTables.RowHeadersWidth = 35
        Me.dgvTables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTables.Size = New System.Drawing.Size(992, 390)
        Me.dgvTables.TabIndex = 0

        ' tabWaiters
        Me.tabWaiters.Controls.Add(Me.pnlWaiterActions)
        Me.tabWaiters.Controls.Add(Me.dgvWaiters)
        Me.tabWaiters.Location = New System.Drawing.Point(4, 25)
        Me.tabWaiters.Name = "tabWaiters"
        Me.tabWaiters.Padding = New System.Windows.Forms.Padding(10)
        Me.tabWaiters.Size = New System.Drawing.Size(1012, 531)
        Me.tabWaiters.TabIndex = 1
        Me.tabWaiters.Text = "Staff / Waiter Roster"
        Me.tabWaiters.UseVisualStyleBackColor = True

        ' pnlWaiterActions
        Me.pnlWaiterActions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlWaiterActions.Controls.Add(Me.btnRefreshWaiters)
        Me.pnlWaiterActions.Controls.Add(Me.btnDeleteWaiter)
        Me.pnlWaiterActions.Controls.Add(Me.btnAddNewWaiter)
        Me.pnlWaiterActions.Location = New System.Drawing.Point(10, 470)
        Me.pnlWaiterActions.Name = "pnlWaiterActions"
        Me.pnlWaiterActions.Size = New System.Drawing.Size(992, 50)
        Me.pnlWaiterActions.TabIndex = 1

        ' btnRefreshWaiters
        Me.btnRefreshWaiters.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefreshWaiters.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnRefreshWaiters.Location = New System.Drawing.Point(825, 8)
        Me.btnRefreshWaiters.Name = "btnRefreshWaiters"
        Me.btnRefreshWaiters.Size = New System.Drawing.Size(160, 34)
        Me.btnRefreshWaiters.TabIndex = 2
        Me.btnRefreshWaiters.Text = "Refresh Roster"
        Me.btnRefreshWaiters.UseVisualStyleBackColor = True

        ' btnDeleteWaiter
        Me.btnDeleteWaiter.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnDeleteWaiter.Location = New System.Drawing.Point(200, 8)
        Me.btnDeleteWaiter.Name = "btnDeleteWaiter"
        Me.btnDeleteWaiter.Size = New System.Drawing.Size(185, 34)
        Me.btnDeleteWaiter.TabIndex = 1
        Me.btnDeleteWaiter.Text = "Remove Selected Waiter"
        Me.btnDeleteWaiter.UseVisualStyleBackColor = True

        ' btnAddNewWaiter
        Me.btnAddNewWaiter.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnAddNewWaiter.Location = New System.Drawing.Point(10, 8)
        Me.btnAddNewWaiter.Name = "btnAddNewWaiter"
        Me.btnAddNewWaiter.Size = New System.Drawing.Size(175, 34)
        Me.btnAddNewWaiter.TabIndex = 0
        Me.btnAddNewWaiter.Text = "Add New Waiter..."
        Me.btnAddNewWaiter.UseVisualStyleBackColor = True

        ' dgvWaiters
        Me.dgvWaiters.AllowUserToAddRows = False
        Me.dgvWaiters.AllowUserToDeleteRows = False
        Me.dgvWaiters.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvWaiters.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvWaiters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvWaiters.Location = New System.Drawing.Point(10, 10)
        Me.dgvWaiters.MultiSelect = False
        Me.dgvWaiters.Name = "dgvWaiters"
        Me.dgvWaiters.ReadOnly = True
        Me.dgvWaiters.RowHeadersWidth = 35
        Me.dgvWaiters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvWaiters.Size = New System.Drawing.Size(992, 450)
        Me.dgvWaiters.TabIndex = 0

        ' tabMenu
        Me.tabMenu.Controls.Add(Me.grpMenuItemEdit)
        Me.tabMenu.Controls.Add(Me.dgvMenu)
        Me.tabMenu.Location = New System.Drawing.Point(4, 25)
        Me.tabMenu.Name = "tabMenu"
        Me.tabMenu.Padding = New System.Windows.Forms.Padding(10)
        Me.tabMenu.Size = New System.Drawing.Size(1012, 531)
        Me.tabMenu.TabIndex = 2
        Me.tabMenu.Text = "Menu Catalog & Ingredients"
        Me.tabMenu.UseVisualStyleBackColor = True

        ' grpMenuItemEdit
        Me.grpMenuItemEdit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpMenuItemEdit.Controls.Add(Me.txtIngredients)
        Me.grpMenuItemEdit.Controls.Add(Me.lblIngredients)
        Me.grpMenuItemEdit.Controls.Add(Me.txtItemDescription)
        Me.grpMenuItemEdit.Controls.Add(Me.lblDesc)
        Me.grpMenuItemEdit.Controls.Add(Me.btnDeleteItem)
        Me.grpMenuItemEdit.Controls.Add(Me.btnClearMenuFields)
        Me.grpMenuItemEdit.Controls.Add(Me.btnAddMenuItem)
        Me.grpMenuItemEdit.Controls.Add(Me.txtPrepTime)
        Me.grpMenuItemEdit.Controls.Add(Me.lblPrepTime)
        Me.grpMenuItemEdit.Controls.Add(Me.txtPrice)
        Me.grpMenuItemEdit.Controls.Add(Me.lblPrice)
        Me.grpMenuItemEdit.Controls.Add(Me.cboCategory)
        Me.grpMenuItemEdit.Controls.Add(Me.lblCategory)
        Me.grpMenuItemEdit.Controls.Add(Me.txtItemName)
        Me.grpMenuItemEdit.Controls.Add(Me.lblItemName)
        Me.grpMenuItemEdit.Location = New System.Drawing.Point(10, 305)
        Me.grpMenuItemEdit.Name = "grpMenuItemEdit"
        Me.grpMenuItemEdit.Size = New System.Drawing.Size(992, 215)
        Me.grpMenuItemEdit.TabIndex = 1
        Me.grpMenuItemEdit.TabStop = False
        Me.grpMenuItemEdit.Text = "Add / Edit Dishes, Ingredients & Preparation Times"

        ' lblItemName
        Me.lblItemName.AutoSize = True
        Me.lblItemName.Location = New System.Drawing.Point(15, 28)
        Me.lblItemName.Name = "lblItemName"
        Me.lblItemName.Size = New System.Drawing.Size(78, 17)
        Me.lblItemName.TabIndex = 0
        Me.lblItemName.Text = "Dish Name:"

        ' txtItemName
        Me.txtItemName.Location = New System.Drawing.Point(110, 25)
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.Size = New System.Drawing.Size(480, 24)
        Me.txtItemName.TabIndex = 1

        ' lblCategory
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Location = New System.Drawing.Point(15, 62)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(66, 17)
        Me.lblCategory.TabIndex = 2
        Me.lblCategory.Text = "Category:"

        ' cboCategory
        Me.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Items.AddRange(New Object() {"Starters", "Mains", "Breads", "Rice", "Desserts", "Beverages"})
        Me.cboCategory.Location = New System.Drawing.Point(110, 59)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(130, 24)
        Me.cboCategory.TabIndex = 3

        ' lblPrice
        Me.lblPrice.AutoSize = True
        Me.lblPrice.Location = New System.Drawing.Point(260, 62)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.Size = New System.Drawing.Size(75, 17)
        Me.lblPrice.TabIndex = 4
        Me.lblPrice.Text = "Price (Rs.):"

        ' txtPrice
        Me.txtPrice.Location = New System.Drawing.Point(350, 59)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(95, 24)
        Me.txtPrice.TabIndex = 5

        ' lblPrepTime
        Me.lblPrepTime.AutoSize = True
        Me.lblPrepTime.Location = New System.Drawing.Point(462, 62)
        Me.lblPrepTime.Name = "lblPrepTime"
        Me.lblPrepTime.Size = New System.Drawing.Size(107, 17)
        Me.lblPrepTime.TabIndex = 6
        Me.lblPrepTime.Text = "Prep Time (min):"

        ' txtPrepTime
        Me.txtPrepTime.Location = New System.Drawing.Point(580, 59)
        Me.txtPrepTime.Name = "txtPrepTime"
        Me.txtPrepTime.Size = New System.Drawing.Size(80, 24)
        Me.txtPrepTime.TabIndex = 7

        ' lblDesc
        Me.lblDesc.AutoSize = True
        Me.lblDesc.Location = New System.Drawing.Point(15, 98)
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Size = New System.Drawing.Size(80, 17)
        Me.lblDesc.TabIndex = 8
        Me.lblDesc.Text = "Description:"

        ' txtItemDescription
        Me.txtItemDescription.Location = New System.Drawing.Point(110, 95)
        Me.txtItemDescription.Multiline = True
        Me.txtItemDescription.Name = "txtItemDescription"
        Me.txtItemDescription.Size = New System.Drawing.Size(480, 45)
        Me.txtItemDescription.TabIndex = 9

        ' lblIngredients
        Me.lblIngredients.AutoSize = True
        Me.lblIngredients.Location = New System.Drawing.Point(15, 152)
        Me.lblIngredients.Name = "lblIngredients"
        Me.lblIngredients.Size = New System.Drawing.Size(80, 17)
        Me.lblIngredients.TabIndex = 10
        Me.lblIngredients.Text = "Ingredients:"

        ' txtIngredients
        Me.txtIngredients.Location = New System.Drawing.Point(110, 149)
        Me.txtIngredients.Name = "txtIngredients"
        Me.txtIngredients.Size = New System.Drawing.Size(480, 24)
        Me.txtIngredients.TabIndex = 11
        Me.txtIngredients.PlaceholderText = "e.g. Chicken, Tomato, Cream, Ginger-Garlic..."

        ' btnAddMenuItem
        Me.btnAddMenuItem.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnAddMenuItem.Location = New System.Drawing.Point(710, 55)
        Me.btnAddMenuItem.Name = "btnAddMenuItem"
        Me.btnAddMenuItem.Size = New System.Drawing.Size(265, 38)
        Me.btnAddMenuItem.TabIndex = 12
        Me.btnAddMenuItem.Text = "Save / Add to Menu"
        Me.btnAddMenuItem.UseVisualStyleBackColor = True

        ' btnDeleteItem
        Me.btnDeleteItem.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnDeleteItem.Location = New System.Drawing.Point(710, 110)
        Me.btnDeleteItem.Name = "btnDeleteItem"
        Me.btnDeleteItem.Size = New System.Drawing.Size(265, 38)
        Me.btnDeleteItem.TabIndex = 13
        Me.btnDeleteItem.Text = "Delete Selected Dish"
        Me.btnDeleteItem.UseVisualStyleBackColor = True
        '
        ' btnClearMenuFields
        '
        Me.btnClearMenuFields.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnClearMenuFields.Location = New System.Drawing.Point(710, 160)
        Me.btnClearMenuFields.Name = "btnClearMenuFields"
        Me.btnClearMenuFields.Size = New System.Drawing.Size(265, 36)
        Me.btnClearMenuFields.TabIndex = 14
        Me.btnClearMenuFields.Text = "Reset / New Dish Form"
        Me.btnClearMenuFields.UseVisualStyleBackColor = True

        ' dgvMenu
        Me.dgvMenu.AllowUserToAddRows = False
        Me.dgvMenu.AllowUserToDeleteRows = False
        Me.dgvMenu.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvMenu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMenu.Location = New System.Drawing.Point(10, 10)
        Me.dgvMenu.MultiSelect = False
        Me.dgvMenu.Name = "dgvMenu"
        Me.dgvMenu.ReadOnly = True
        Me.dgvMenu.RowHeadersWidth = 35
        Me.dgvMenu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMenu.Size = New System.Drawing.Size(992, 285)
        Me.dgvMenu.TabIndex = 0

        ' tabOrdersAndStats
        Me.tabOrdersAndStats.Controls.Add(Me.pnlStatsCards)
        Me.tabOrdersAndStats.Controls.Add(Me.dgvAllOrders)
        Me.tabOrdersAndStats.Location = New System.Drawing.Point(4, 25)
        Me.tabOrdersAndStats.Name = "tabOrdersAndStats"
        Me.tabOrdersAndStats.Padding = New System.Windows.Forms.Padding(10)
        Me.tabOrdersAndStats.Size = New System.Drawing.Size(1012, 531)
        Me.tabOrdersAndStats.TabIndex = 3
        Me.tabOrdersAndStats.Text = "Live Orders & Revenue"
        Me.tabOrdersAndStats.UseVisualStyleBackColor = True

        ' pnlStatsCards
        Me.pnlStatsCards.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlStatsCards.BackColor = System.Drawing.Color.FromArgb(245, 248, 250)
        Me.pnlStatsCards.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlStatsCards.Controls.Add(Me.lblTotalSalesValue)
        Me.pnlStatsCards.Controls.Add(Me.lblTotalSalesTitle)
        Me.pnlStatsCards.Controls.Add(Me.lblActiveOrdersValue)
        Me.pnlStatsCards.Controls.Add(Me.lblActiveOrdersTitle)
        Me.pnlStatsCards.Controls.Add(Me.btnRefreshOrders)
        Me.pnlStatsCards.Location = New System.Drawing.Point(10, 448)
        Me.pnlStatsCards.Name = "pnlStatsCards"
        Me.pnlStatsCards.Size = New System.Drawing.Size(992, 72)
        Me.pnlStatsCards.TabIndex = 1

        ' lblTotalSalesValue
        Me.lblTotalSalesValue.AutoSize = True
        Me.lblTotalSalesValue.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalSalesValue.ForeColor = System.Drawing.Color.ForestGreen
        Me.lblTotalSalesValue.Location = New System.Drawing.Point(360, 28)
        Me.lblTotalSalesValue.Name = "lblTotalSalesValue"
        Me.lblTotalSalesValue.Size = New System.Drawing.Size(75, 23)
        Me.lblTotalSalesValue.TabIndex = 4
        Me.lblTotalSalesValue.Text = "Rs.0"

        ' lblTotalSalesTitle
        Me.lblTotalSalesTitle.AutoSize = True
        Me.lblTotalSalesTitle.ForeColor = System.Drawing.Color.DimGray
        Me.lblTotalSalesTitle.Location = New System.Drawing.Point(360, 8)
        Me.lblTotalSalesTitle.Name = "lblTotalSalesTitle"
        Me.lblTotalSalesTitle.Size = New System.Drawing.Size(135, 17)
        Me.lblTotalSalesTitle.TabIndex = 3
        Me.lblTotalSalesTitle.Text = "Total Gross Revenue:"

        ' lblActiveOrdersValue
        Me.lblActiveOrdersValue.AutoSize = True
        Me.lblActiveOrdersValue.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblActiveOrdersValue.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblActiveOrdersValue.Location = New System.Drawing.Point(30, 28)
        Me.lblActiveOrdersValue.Name = "lblActiveOrdersValue"
        Me.lblActiveOrdersValue.Size = New System.Drawing.Size(25, 23)
        Me.lblActiveOrdersValue.TabIndex = 2
        Me.lblActiveOrdersValue.Text = "0"

        ' lblActiveOrdersTitle
        Me.lblActiveOrdersTitle.AutoSize = True
        Me.lblActiveOrdersTitle.ForeColor = System.Drawing.Color.DimGray
        Me.lblActiveOrdersTitle.Location = New System.Drawing.Point(30, 8)
        Me.lblActiveOrdersTitle.Name = "lblActiveOrdersTitle"
        Me.lblActiveOrdersTitle.Size = New System.Drawing.Size(205, 17)
        Me.lblActiveOrdersTitle.TabIndex = 1
        Me.lblActiveOrdersTitle.Text = "Active Kitchen / Serving Queue:"

        ' btnRefreshOrders
        Me.btnRefreshOrders.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefreshOrders.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnRefreshOrders.Location = New System.Drawing.Point(815, 18)
        Me.btnRefreshOrders.Name = "btnRefreshOrders"
        Me.btnRefreshOrders.Size = New System.Drawing.Size(165, 34)
        Me.btnRefreshOrders.TabIndex = 0
        Me.btnRefreshOrders.Text = "Refresh Monitor"
        Me.btnRefreshOrders.UseVisualStyleBackColor = True

        ' dgvAllOrders
        Me.dgvAllOrders.AllowUserToAddRows = False
        Me.dgvAllOrders.AllowUserToDeleteRows = False
        Me.dgvAllOrders.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAllOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvAllOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAllOrders.Location = New System.Drawing.Point(10, 10)
        Me.dgvAllOrders.MultiSelect = False
        Me.dgvAllOrders.Name = "dgvAllOrders"
        Me.dgvAllOrders.ReadOnly = True
        Me.dgvAllOrders.RowHeadersWidth = 35
        Me.dgvAllOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAllOrders.Size = New System.Drawing.Size(992, 428)
        Me.dgvAllOrders.TabIndex = 0

        ' tabCustomers
        Me.tabCustomers.Controls.Add(Me.grpAddCustomer)
        Me.tabCustomers.Controls.Add(Me.btnDeleteCustomer)
        Me.tabCustomers.Controls.Add(Me.btnRefreshCustomers)
        Me.tabCustomers.Controls.Add(Me.dgvCustomers)
        Me.tabCustomers.Location = New System.Drawing.Point(4, 25)
        Me.tabCustomers.Name = "tabCustomers"
        Me.tabCustomers.Padding = New System.Windows.Forms.Padding(10)
        Me.tabCustomers.Size = New System.Drawing.Size(1012, 531)
        Me.tabCustomers.TabIndex = 4
        Me.tabCustomers.Text = "Customer Registry"
        Me.tabCustomers.UseVisualStyleBackColor = True

        ' dgvCustomers
        Me.dgvCustomers.AllowUserToAddRows = False
        Me.dgvCustomers.AllowUserToDeleteRows = False
        Me.dgvCustomers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCustomers.Location = New System.Drawing.Point(10, 10)
        Me.dgvCustomers.MultiSelect = False
        Me.dgvCustomers.Name = "dgvCustomers"
        Me.dgvCustomers.ReadOnly = True
        Me.dgvCustomers.RowHeadersWidth = 35
        Me.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCustomers.Size = New System.Drawing.Size(992, 295)
        Me.dgvCustomers.TabIndex = 0

        ' grpAddCustomer
        Me.grpAddCustomer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpAddCustomer.Controls.Add(Me.txtCustNotes)
        Me.grpAddCustomer.Controls.Add(Me.lblCustNotes)
        Me.grpAddCustomer.Controls.Add(Me.txtCustCity)
        Me.grpAddCustomer.Controls.Add(Me.lblCustCity)
        Me.grpAddCustomer.Controls.Add(Me.txtCustEmail)
        Me.grpAddCustomer.Controls.Add(Me.lblCustEmail)
        Me.grpAddCustomer.Controls.Add(Me.txtCustPhone)
        Me.grpAddCustomer.Controls.Add(Me.lblCustPhone)
        Me.grpAddCustomer.Controls.Add(Me.txtCustName)
        Me.grpAddCustomer.Controls.Add(Me.lblCustName)
        Me.grpAddCustomer.Controls.Add(Me.btnAddCustomer)
        Me.grpAddCustomer.Location = New System.Drawing.Point(10, 315)
        Me.grpAddCustomer.Name = "grpAddCustomer"
        Me.grpAddCustomer.Size = New System.Drawing.Size(992, 165)
        Me.grpAddCustomer.TabIndex = 1
        Me.grpAddCustomer.TabStop = False
        Me.grpAddCustomer.Text = "Add New Customer to Registry"

        ' lblCustName
        Me.lblCustName.AutoSize = True
        Me.lblCustName.Location = New System.Drawing.Point(15, 30)
        Me.lblCustName.Name = "lblCustName"
        Me.lblCustName.Size = New System.Drawing.Size(105, 17)
        Me.lblCustName.TabIndex = 0
        Me.lblCustName.Text = "Customer Name:"

        ' txtCustName
        Me.txtCustName.Location = New System.Drawing.Point(130, 27)
        Me.txtCustName.Name = "txtCustName"
        Me.txtCustName.Size = New System.Drawing.Size(250, 24)
        Me.txtCustName.TabIndex = 1

        ' lblCustPhone
        Me.lblCustPhone.AutoSize = True
        Me.lblCustPhone.Location = New System.Drawing.Point(400, 30)
        Me.lblCustPhone.Name = "lblCustPhone"
        Me.lblCustPhone.Size = New System.Drawing.Size(105, 17)
        Me.lblCustPhone.TabIndex = 2
        Me.lblCustPhone.Text = "Phone (+91...):"

        ' txtCustPhone
        Me.txtCustPhone.Location = New System.Drawing.Point(515, 27)
        Me.txtCustPhone.Name = "txtCustPhone"
        Me.txtCustPhone.Size = New System.Drawing.Size(200, 24)
        Me.txtCustPhone.TabIndex = 3

        ' lblCustEmail
        Me.lblCustEmail.AutoSize = True
        Me.lblCustEmail.Location = New System.Drawing.Point(15, 68)
        Me.lblCustEmail.Name = "lblCustEmail"
        Me.lblCustEmail.Size = New System.Drawing.Size(90, 17)
        Me.lblCustEmail.TabIndex = 4
        Me.lblCustEmail.Text = "Email:"

        ' txtCustEmail
        Me.txtCustEmail.Location = New System.Drawing.Point(130, 65)
        Me.txtCustEmail.Name = "txtCustEmail"
        Me.txtCustEmail.Size = New System.Drawing.Size(250, 24)
        Me.txtCustEmail.TabIndex = 5

        ' lblCustCity
        Me.lblCustCity.AutoSize = True
        Me.lblCustCity.Location = New System.Drawing.Point(400, 68)
        Me.lblCustCity.Name = "lblCustCity"
        Me.lblCustCity.Size = New System.Drawing.Size(80, 17)
        Me.lblCustCity.TabIndex = 6
        Me.lblCustCity.Text = "City:"

        ' txtCustCity
        Me.txtCustCity.Location = New System.Drawing.Point(515, 65)
        Me.txtCustCity.Name = "txtCustCity"
        Me.txtCustCity.Size = New System.Drawing.Size(200, 24)
        Me.txtCustCity.TabIndex = 7
        Me.txtCustCity.Text = "Chennai"

        ' lblCustNotes
        Me.lblCustNotes.AutoSize = True
        Me.lblCustNotes.Location = New System.Drawing.Point(15, 108)
        Me.lblCustNotes.Name = "lblCustNotes"
        Me.lblCustNotes.Size = New System.Drawing.Size(110, 17)
        Me.lblCustNotes.TabIndex = 8
        Me.lblCustNotes.Text = "Preferences/Notes:"

        ' txtCustNotes
        Me.txtCustNotes.Location = New System.Drawing.Point(130, 105)
        Me.txtCustNotes.Name = "txtCustNotes"
        Me.txtCustNotes.Size = New System.Drawing.Size(480, 24)
        Me.txtCustNotes.TabIndex = 9
        Me.txtCustNotes.PlaceholderText = "e.g. Vegetarian, Less spicy, Nut allergy, Regular..."

        ' btnAddCustomer
        Me.btnAddCustomer.BackColor = System.Drawing.Color.FromArgb(33, 150, 83)
        Me.btnAddCustomer.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnAddCustomer.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnAddCustomer.ForeColor = System.Drawing.Color.White
        Me.btnAddCustomer.Location = New System.Drawing.Point(730, 60)
        Me.btnAddCustomer.Name = "btnAddCustomer"
        Me.btnAddCustomer.Size = New System.Drawing.Size(240, 40)
        Me.btnAddCustomer.TabIndex = 10
        Me.btnAddCustomer.Text = "Add Customer to Registry"
        Me.btnAddCustomer.UseVisualStyleBackColor = False

        ' btnDeleteCustomer
        Me.btnDeleteCustomer.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnDeleteCustomer.Location = New System.Drawing.Point(10, 490)
        Me.btnDeleteCustomer.Name = "btnDeleteCustomer"
        Me.btnDeleteCustomer.Size = New System.Drawing.Size(200, 32)
        Me.btnDeleteCustomer.TabIndex = 2
        Me.btnDeleteCustomer.Text = "Remove Selected Customer"
        Me.btnDeleteCustomer.UseVisualStyleBackColor = True

        ' btnRefreshCustomers
        Me.btnRefreshCustomers.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefreshCustomers.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnRefreshCustomers.Location = New System.Drawing.Point(835, 490)
        Me.btnRefreshCustomers.Name = "btnRefreshCustomers"
        Me.btnRefreshCustomers.Size = New System.Drawing.Size(167, 32)
        Me.btnRefreshCustomers.TabIndex = 3
        Me.btnRefreshCustomers.Text = "Refresh Registry"
        Me.btnRefreshCustomers.UseVisualStyleBackColor = True

        ' frmOwnerDashboard
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1020, 625)
        Me.Controls.Add(Me.tabMain)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "frmOwnerDashboard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Spice Garden - Owner Control Panel"
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
        Me.tabCustomers.ResumeLayout(False)
        Me.grpAddCustomer.ResumeLayout(False)
        Me.grpAddCustomer.PerformLayout()
        CType(Me.dgvCustomers, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents txtIngredients As TextBox
    Friend WithEvents lblIngredients As Label
    Friend WithEvents txtItemDescription As TextBox
    Friend WithEvents lblDesc As Label
    Friend WithEvents btnDeleteItem As Button
    Friend WithEvents btnClearMenuFields As Button
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
    Friend WithEvents tabCustomers As TabPage
    Friend WithEvents dgvCustomers As DataGridView
    Friend WithEvents grpAddCustomer As GroupBox
    Friend WithEvents txtCustNotes As TextBox
    Friend WithEvents lblCustNotes As Label
    Friend WithEvents txtCustCity As TextBox
    Friend WithEvents lblCustCity As Label
    Friend WithEvents txtCustEmail As TextBox
    Friend WithEvents lblCustEmail As Label
    Friend WithEvents txtCustPhone As TextBox
    Friend WithEvents lblCustPhone As Label
    Friend WithEvents txtCustName As TextBox
    Friend WithEvents lblCustName As Label
    Friend WithEvents btnAddCustomer As Button
    Friend WithEvents btnDeleteCustomer As Button
    Friend WithEvents btnRefreshCustomers As Button
End Class
