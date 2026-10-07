<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustomerOrder
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
        Me.components = New System.ComponentModel.Container()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblTableInfo = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.tabCustomer = New System.Windows.Forms.TabControl()
        Me.tabMenuOrder = New System.Windows.Forms.TabPage()
        Me.splOrder = New System.Windows.Forms.SplitContainer()
        Me.pnlLeftMenu = New System.Windows.Forms.Panel()
        Me.grpMenu = New System.Windows.Forms.GroupBox()
        Me.pnlAddToCart = New System.Windows.Forms.Panel()
        Me.btnAddToCart = New System.Windows.Forms.Button()
        Me.numQty = New System.Windows.Forms.NumericUpDown()
        Me.lblQty = New System.Windows.Forms.Label()
        Me.dgvMenuCatalog = New System.Windows.Forms.DataGridView()
        Me.pnlCategory = New System.Windows.Forms.Panel()
        Me.cboFilterCategory = New System.Windows.Forms.ComboBox()
        Me.lblFilterCat = New System.Windows.Forms.Label()
        Me.grpRecipe = New System.Windows.Forms.GroupBox()
        Me.lblRecipeTitle = New System.Windows.Forms.Label()
        Me.lblRecipeDesc = New System.Windows.Forms.Label()
        Me.lblIngredientsHead = New System.Windows.Forms.Label()
        Me.txtIngredients = New System.Windows.Forms.TextBox()
        Me.lblRecipeHead = New System.Windows.Forms.Label()
        Me.txtRecipeSteps = New System.Windows.Forms.TextBox()
        Me.lblCustomNote = New System.Windows.Forms.Label()
        Me.txtCustomization = New System.Windows.Forms.TextBox()
        Me.grpCart = New System.Windows.Forms.GroupBox()
        Me.pnlCheckout = New System.Windows.Forms.Panel()
        Me.lblCustNameLabel = New System.Windows.Forms.Label()
        Me.txtCustomerName = New System.Windows.Forms.TextBox()
        Me.btnPlaceOrder = New System.Windows.Forms.Button()
        Me.btnClearCart = New System.Windows.Forms.Button()
        Me.btnRemoveFromCart = New System.Windows.Forms.Button()
        Me.lblEstWaitInfo = New System.Windows.Forms.Label()
        Me.lblTotalAmount = New System.Windows.Forms.Label()
        Me.dgvCart = New System.Windows.Forms.DataGridView()
        Me.tabTrackOrder = New System.Windows.Forms.TabPage()
        Me.pnlLiveTracker = New System.Windows.Forms.Panel()
        Me.btnRefreshTracker = New System.Windows.Forms.Button()
        Me.lblCountdownNotice = New System.Windows.Forms.Label()
        Me.lblRemainingWaitValue = New System.Windows.Forms.Label()
        Me.lblRemainingWaitTitle = New System.Windows.Forms.Label()
        Me.prgWaitProgress = New System.Windows.Forms.ProgressBar()
        Me.lblElapsedWait = New System.Windows.Forms.Label()
        Me.lblStatusBadge = New System.Windows.Forms.Label()
        Me.lblStatusTitle = New System.Windows.Forms.Label()
        Me.lblOrderMeta = New System.Windows.Forms.Label()
        Me.grpOrderedItems = New System.Windows.Forms.GroupBox()
        Me.dgvTrackedItems = New System.Windows.Forms.DataGridView()
        Me.tmrWaitCountdown = New System.Windows.Forms.Timer(Me.components)
        Me.pnlHeader.SuspendLayout()
        Me.tabCustomer.SuspendLayout()
        Me.tabMenuOrder.SuspendLayout()
        CType(Me.splOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splOrder.Panel1.SuspendLayout()
        Me.splOrder.Panel2.SuspendLayout()
        Me.splOrder.SuspendLayout()
        Me.pnlLeftMenu.SuspendLayout()
        Me.grpMenu.SuspendLayout()
        Me.pnlAddToCart.SuspendLayout()
        CType(Me.numQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMenuCatalog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCategory.SuspendLayout()
        Me.grpRecipe.SuspendLayout()
        Me.grpCart.SuspendLayout()
        Me.pnlCheckout.SuspendLayout()
        CType(Me.dgvCart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabTrackOrder.SuspendLayout()
        Me.pnlLiveTracker.SuspendLayout()
        Me.grpOrderedItems.SuspendLayout()
        CType(Me.dgvTrackedItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()

        ' pnlHeader
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(139, 69, 19)
        Me.pnlHeader.Controls.Add(Me.btnClose)
        Me.pnlHeader.Controls.Add(Me.lblTableInfo)
        Me.pnlHeader.Controls.Add(Me.lblTitle)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1100, 65)
        Me.pnlHeader.TabIndex = 0

        ' btnClose
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(245, 245, 245)
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnClose.Location = New System.Drawing.Point(975, 16)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(110, 32)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Back / Exit"
        Me.btnClose.UseVisualStyleBackColor = False

        ' lblTableInfo
        Me.lblTableInfo.AutoSize = True
        Me.lblTableInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTableInfo.ForeColor = System.Drawing.Color.LemonChiffon
        Me.lblTableInfo.Location = New System.Drawing.Point(20, 38)
        Me.lblTableInfo.Name = "lblTableInfo"
        Me.lblTableInfo.Size = New System.Drawing.Size(220, 15)
        Me.lblTableInfo.TabIndex = 1
        Me.lblTableInfo.Text = "Ordering for: Table #1 | Guest User"

        ' lblTitle
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(18, 10)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(380, 25)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Spice Garden - Table Menu & Order Tracker"

        ' tabCustomer
        Me.tabCustomer.Controls.Add(Me.tabMenuOrder)
        Me.tabCustomer.Controls.Add(Me.tabTrackOrder)
        Me.tabCustomer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabCustomer.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.tabCustomer.Location = New System.Drawing.Point(0, 65)
        Me.tabCustomer.Name = "tabCustomer"
        Me.tabCustomer.SelectedIndex = 0
        Me.tabCustomer.Size = New System.Drawing.Size(1100, 596)
        Me.tabCustomer.TabIndex = 1

        ' tabMenuOrder
        Me.tabMenuOrder.Controls.Add(Me.splOrder)
        Me.tabMenuOrder.Location = New System.Drawing.Point(4, 25)
        Me.tabMenuOrder.Name = "tabMenuOrder"
        Me.tabMenuOrder.Padding = New System.Windows.Forms.Padding(8)
        Me.tabMenuOrder.Size = New System.Drawing.Size(1092, 567)
        Me.tabMenuOrder.TabIndex = 0
        Me.tabMenuOrder.Text = "1. Browse Menu & Add to Cart"
        Me.tabMenuOrder.UseVisualStyleBackColor = True

        ' splOrder
        Me.splOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splOrder.Location = New System.Drawing.Point(8, 8)
        Me.splOrder.Name = "splOrder"
        Me.splOrder.Panel1.Controls.Add(Me.pnlLeftMenu)
        Me.splOrder.Panel2.Controls.Add(Me.grpCart)
        Me.splOrder.Size = New System.Drawing.Size(1076, 551)
        Me.splOrder.SplitterDistance = 640
        Me.splOrder.TabIndex = 0

        ' pnlLeftMenu (left panel: menu + recipe)
        Me.pnlLeftMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLeftMenu.Controls.Add(Me.grpRecipe)
        Me.pnlLeftMenu.Controls.Add(Me.grpMenu)
        Me.pnlLeftMenu.Controls.Add(Me.pnlCategory)

        ' pnlCategory
        Me.pnlCategory.Controls.Add(Me.cboFilterCategory)
        Me.pnlCategory.Controls.Add(Me.lblFilterCat)
        Me.pnlCategory.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCategory.Location = New System.Drawing.Point(0, 0)
        Me.pnlCategory.Name = "pnlCategory"
        Me.pnlCategory.Size = New System.Drawing.Size(640, 45)
        Me.pnlCategory.TabIndex = 0

        ' cboFilterCategory
        Me.cboFilterCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilterCategory.FormattingEnabled = True
        Me.cboFilterCategory.Items.AddRange(New Object() {"All Categories", "Starters", "Mains", "Breads", "Rice", "Desserts", "Beverages"})
        Me.cboFilterCategory.Location = New System.Drawing.Point(125, 10)
        Me.cboFilterCategory.Name = "cboFilterCategory"
        Me.cboFilterCategory.Size = New System.Drawing.Size(200, 24)
        Me.cboFilterCategory.TabIndex = 1

        ' lblFilterCat
        Me.lblFilterCat.AutoSize = True
        Me.lblFilterCat.Location = New System.Drawing.Point(12, 13)
        Me.lblFilterCat.Name = "lblFilterCat"
        Me.lblFilterCat.Size = New System.Drawing.Size(107, 17)
        Me.lblFilterCat.TabIndex = 0
        Me.lblFilterCat.Text = "Filter by Course:"

        ' grpMenu
        Me.grpMenu.Controls.Add(Me.pnlAddToCart)
        Me.grpMenu.Controls.Add(Me.dgvMenuCatalog)
        Me.grpMenu.Location = New System.Drawing.Point(0, 45)
        Me.grpMenu.Name = "grpMenu"
        Me.grpMenu.Padding = New System.Windows.Forms.Padding(8)
        Me.grpMenu.Size = New System.Drawing.Size(640, 290)
        Me.grpMenu.TabIndex = 1
        Me.grpMenu.TabStop = False
        Me.grpMenu.Text = "Available Dishes & Preparation Times"

        ' pnlAddToCart
        Me.pnlAddToCart.Controls.Add(Me.btnAddToCart)
        Me.pnlAddToCart.Controls.Add(Me.numQty)
        Me.pnlAddToCart.Controls.Add(Me.lblQty)
        Me.pnlAddToCart.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlAddToCart.Location = New System.Drawing.Point(8, 240)
        Me.pnlAddToCart.Name = "pnlAddToCart"
        Me.pnlAddToCart.Size = New System.Drawing.Size(624, 42)
        Me.pnlAddToCart.TabIndex = 1

        ' btnAddToCart
        Me.btnAddToCart.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddToCart.BackColor = System.Drawing.Color.FromArgb(180, 83, 9)
        Me.btnAddToCart.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnAddToCart.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnAddToCart.ForeColor = System.Drawing.Color.White
        Me.btnAddToCart.Location = New System.Drawing.Point(180, 5)
        Me.btnAddToCart.Name = "btnAddToCart"
        Me.btnAddToCart.Size = New System.Drawing.Size(430, 32)
        Me.btnAddToCart.TabIndex = 2
        Me.btnAddToCart.Text = "+ Add Selected Dish to Cart (with Customization Below)"
        Me.btnAddToCart.UseVisualStyleBackColor = False

        ' numQty
        Me.numQty.Location = New System.Drawing.Point(85, 9)
        Me.numQty.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numQty.Name = "numQty"
        Me.numQty.Size = New System.Drawing.Size(75, 24)
        Me.numQty.TabIndex = 1
        Me.numQty.Value = New Decimal(New Integer() {1, 0, 0, 0})

        ' lblQty
        Me.lblQty.AutoSize = True
        Me.lblQty.Location = New System.Drawing.Point(15, 12)
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Size = New System.Drawing.Size(60, 17)
        Me.lblQty.TabIndex = 0
        Me.lblQty.Text = "Quantity:"

        ' dgvMenuCatalog
        Me.dgvMenuCatalog.AllowUserToAddRows = False
        Me.dgvMenuCatalog.AllowUserToDeleteRows = False
        Me.dgvMenuCatalog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvMenuCatalog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvMenuCatalog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMenuCatalog.Location = New System.Drawing.Point(8, 22)
        Me.dgvMenuCatalog.MultiSelect = False
        Me.dgvMenuCatalog.Name = "dgvMenuCatalog"
        Me.dgvMenuCatalog.ReadOnly = True
        Me.dgvMenuCatalog.RowHeadersWidth = 35
        Me.dgvMenuCatalog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMenuCatalog.Size = New System.Drawing.Size(624, 215)
        Me.dgvMenuCatalog.TabIndex = 0

        ' grpRecipe (recipe card + ingredient customization)
        Me.grpRecipe.Controls.Add(Me.lblRecipeTitle)
        Me.grpRecipe.Controls.Add(Me.lblRecipeDesc)
        Me.grpRecipe.Controls.Add(Me.lblIngredientsHead)
        Me.grpRecipe.Controls.Add(Me.txtIngredients)
        Me.grpRecipe.Controls.Add(Me.lblRecipeHead)
        Me.grpRecipe.Controls.Add(Me.txtRecipeSteps)
        Me.grpRecipe.Controls.Add(Me.lblCustomNote)
        Me.grpRecipe.Controls.Add(Me.txtCustomization)
        Me.grpRecipe.Location = New System.Drawing.Point(0, 335)
        Me.grpRecipe.Name = "grpRecipe"
        Me.grpRecipe.Size = New System.Drawing.Size(640, 216)
        Me.grpRecipe.TabIndex = 2
        Me.grpRecipe.TabStop = False
        Me.grpRecipe.Text = "Recipe Card, Ingredients & Customization"

        ' lblRecipeTitle
        Me.lblRecipeTitle.AutoSize = True
        Me.lblRecipeTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblRecipeTitle.ForeColor = System.Drawing.Color.FromArgb(139, 69, 19)
        Me.lblRecipeTitle.Location = New System.Drawing.Point(8, 22)
        Me.lblRecipeTitle.Name = "lblRecipeTitle"
        Me.lblRecipeTitle.Size = New System.Drawing.Size(300, 17)
        Me.lblRecipeTitle.TabIndex = 0
        Me.lblRecipeTitle.Text = "Select a dish to see its recipe & ingredients"

        ' lblRecipeDesc
        Me.lblRecipeDesc.Location = New System.Drawing.Point(8, 42)
        Me.lblRecipeDesc.Name = "lblRecipeDesc"
        Me.lblRecipeDesc.Size = New System.Drawing.Size(622, 30)
        Me.lblRecipeDesc.TabIndex = 1
        Me.lblRecipeDesc.Text = ""
        Me.lblRecipeDesc.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Italic)
        Me.lblRecipeDesc.ForeColor = System.Drawing.Color.DimGray

        ' lblIngredientsHead
        Me.lblIngredientsHead.AutoSize = True
        Me.lblIngredientsHead.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblIngredientsHead.Location = New System.Drawing.Point(8, 74)
        Me.lblIngredientsHead.Name = "lblIngredientsHead"
        Me.lblIngredientsHead.Size = New System.Drawing.Size(80, 15)
        Me.lblIngredientsHead.TabIndex = 2
        Me.lblIngredientsHead.Text = "Ingredients:"

        ' txtIngredients
        Me.txtIngredients.BackColor = System.Drawing.Color.FromArgb(255, 252, 245)
        Me.txtIngredients.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIngredients.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.txtIngredients.Location = New System.Drawing.Point(8, 92)
        Me.txtIngredients.Multiline = True
        Me.txtIngredients.Name = "txtIngredients"
        Me.txtIngredients.ReadOnly = True
        Me.txtIngredients.Size = New System.Drawing.Size(310, 38)
        Me.txtIngredients.TabIndex = 3

        ' lblRecipeHead
        Me.lblRecipeHead.AutoSize = True
        Me.lblRecipeHead.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblRecipeHead.Location = New System.Drawing.Point(330, 74)
        Me.lblRecipeHead.Name = "lblRecipeHead"
        Me.lblRecipeHead.Size = New System.Drawing.Size(60, 15)
        Me.lblRecipeHead.TabIndex = 4
        Me.lblRecipeHead.Text = "Recipe:"

        ' txtRecipeSteps
        Me.txtRecipeSteps.BackColor = System.Drawing.Color.FromArgb(245, 255, 245)
        Me.txtRecipeSteps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRecipeSteps.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.txtRecipeSteps.Location = New System.Drawing.Point(330, 92)
        Me.txtRecipeSteps.Multiline = True
        Me.txtRecipeSteps.Name = "txtRecipeSteps"
        Me.txtRecipeSteps.ReadOnly = True
        Me.txtRecipeSteps.Size = New System.Drawing.Size(300, 38)
        Me.txtRecipeSteps.TabIndex = 5

        ' lblCustomNote
        Me.lblCustomNote.AutoSize = True
        Me.lblCustomNote.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblCustomNote.ForeColor = System.Drawing.Color.FromArgb(22, 101, 52)
        Me.lblCustomNote.Location = New System.Drawing.Point(8, 140)
        Me.lblCustomNote.Name = "lblCustomNote"
        Me.lblCustomNote.Size = New System.Drawing.Size(350, 15)
        Me.lblCustomNote.TabIndex = 6
        Me.lblCustomNote.Text = "Customization / Special Requests (e.g. less spicy, no onion):"

        ' txtCustomization
        Me.txtCustomization.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtCustomization.Location = New System.Drawing.Point(8, 158)
        Me.txtCustomization.Name = "txtCustomization"
        Me.txtCustomization.Size = New System.Drawing.Size(622, 24)
        Me.txtCustomization.TabIndex = 7

        ' grpCart (right panel)
        Me.grpCart.Controls.Add(Me.pnlCheckout)
        Me.grpCart.Controls.Add(Me.dgvCart)
        Me.grpCart.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpCart.Location = New System.Drawing.Point(0, 0)
        Me.grpCart.Name = "grpCart"
        Me.grpCart.Padding = New System.Windows.Forms.Padding(8)
        Me.grpCart.Size = New System.Drawing.Size(432, 551)
        Me.grpCart.TabIndex = 0
        Me.grpCart.TabStop = False
        Me.grpCart.Text = "Your Table Order Cart"

        ' pnlCheckout
        Me.pnlCheckout.Controls.Add(Me.lblCustNameLabel)
        Me.pnlCheckout.Controls.Add(Me.txtCustomerName)
        Me.pnlCheckout.Controls.Add(Me.btnPlaceOrder)
        Me.pnlCheckout.Controls.Add(Me.btnClearCart)
        Me.pnlCheckout.Controls.Add(Me.btnRemoveFromCart)
        Me.pnlCheckout.Controls.Add(Me.lblEstWaitInfo)
        Me.pnlCheckout.Controls.Add(Me.lblTotalAmount)
        Me.pnlCheckout.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlCheckout.Location = New System.Drawing.Point(8, 385)
        Me.pnlCheckout.Name = "pnlCheckout"
        Me.pnlCheckout.Size = New System.Drawing.Size(416, 158)
        Me.pnlCheckout.TabIndex = 1

        ' lblTotalAmount
        Me.lblTotalAmount.AutoSize = True
        Me.lblTotalAmount.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(20, 40, 60)
        Me.lblTotalAmount.Location = New System.Drawing.Point(8, 8)
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Size = New System.Drawing.Size(150, 21)
        Me.lblTotalAmount.TabIndex = 0
        Me.lblTotalAmount.Text = "Total Bill: Rs.0"

        ' lblEstWaitInfo
        Me.lblEstWaitInfo.AutoSize = True
        Me.lblEstWaitInfo.ForeColor = System.Drawing.Color.DarkGoldenrod
        Me.lblEstWaitInfo.Location = New System.Drawing.Point(8, 32)
        Me.lblEstWaitInfo.Name = "lblEstWaitInfo"
        Me.lblEstWaitInfo.Size = New System.Drawing.Size(220, 17)
        Me.lblEstWaitInfo.TabIndex = 1
        Me.lblEstWaitInfo.Text = "Est. Preparation Time: ~0 mins"

        ' lblCustNameLabel
        Me.lblCustNameLabel.AutoSize = True
        Me.lblCustNameLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblCustNameLabel.Location = New System.Drawing.Point(8, 55)
        Me.lblCustNameLabel.Name = "lblCustNameLabel"
        Me.lblCustNameLabel.Size = New System.Drawing.Size(100, 15)
        Me.lblCustNameLabel.TabIndex = 2
        Me.lblCustNameLabel.Text = "Your Name:"

        ' txtCustomerName
        Me.txtCustomerName.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtCustomerName.Location = New System.Drawing.Point(115, 52)
        Me.txtCustomerName.Name = "txtCustomerName"
        Me.txtCustomerName.Size = New System.Drawing.Size(295, 24)
        Me.txtCustomerName.TabIndex = 3

        ' btnRemoveFromCart
        Me.btnRemoveFromCart.Anchor = System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left
        Me.btnRemoveFromCart.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnRemoveFromCart.Location = New System.Drawing.Point(8, 85)
        Me.btnRemoveFromCart.Name = "btnRemoveFromCart"
        Me.btnRemoveFromCart.Size = New System.Drawing.Size(115, 34)
        Me.btnRemoveFromCart.TabIndex = 4
        Me.btnRemoveFromCart.Text = "Remove Item"
        Me.btnRemoveFromCart.UseVisualStyleBackColor = True

        ' btnClearCart
        Me.btnClearCart.Anchor = System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left
        Me.btnClearCart.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnClearCart.Location = New System.Drawing.Point(132, 85)
        Me.btnClearCart.Name = "btnClearCart"
        Me.btnClearCart.Size = New System.Drawing.Size(90, 34)
        Me.btnClearCart.TabIndex = 5
        Me.btnClearCart.Text = "Clear Cart"
        Me.btnClearCart.UseVisualStyleBackColor = True

        ' btnPlaceOrder
        Me.btnPlaceOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPlaceOrder.BackColor = System.Drawing.Color.FromArgb(33, 150, 83)
        Me.btnPlaceOrder.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnPlaceOrder.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnPlaceOrder.ForeColor = System.Drawing.Color.White
        Me.btnPlaceOrder.Location = New System.Drawing.Point(232, 82)
        Me.btnPlaceOrder.Name = "btnPlaceOrder"
        Me.btnPlaceOrder.Size = New System.Drawing.Size(178, 40)
        Me.btnPlaceOrder.TabIndex = 6
        Me.btnPlaceOrder.Text = "Submit Order to Kitchen"
        Me.btnPlaceOrder.UseVisualStyleBackColor = False

        ' dgvCart
        Me.dgvCart.AllowUserToAddRows = False
        Me.dgvCart.AllowUserToDeleteRows = False
        Me.dgvCart.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCart.Location = New System.Drawing.Point(8, 22)
        Me.dgvCart.MultiSelect = False
        Me.dgvCart.Name = "dgvCart"
        Me.dgvCart.ReadOnly = True
        Me.dgvCart.RowHeadersWidth = 35
        Me.dgvCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCart.Size = New System.Drawing.Size(416, 360)
        Me.dgvCart.TabIndex = 0

        ' tabTrackOrder
        Me.tabTrackOrder.Controls.Add(Me.pnlLiveTracker)
        Me.tabTrackOrder.Controls.Add(Me.grpOrderedItems)
        Me.tabTrackOrder.Location = New System.Drawing.Point(4, 25)
        Me.tabTrackOrder.Name = "tabTrackOrder"
        Me.tabTrackOrder.Padding = New System.Windows.Forms.Padding(10)
        Me.tabTrackOrder.Size = New System.Drawing.Size(1092, 567)
        Me.tabTrackOrder.TabIndex = 1
        Me.tabTrackOrder.Text = "2. Live Kitchen Status & Wait Time"
        Me.tabTrackOrder.UseVisualStyleBackColor = True

        ' pnlLiveTracker
        Me.pnlLiveTracker.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlLiveTracker.BackColor = System.Drawing.Color.FromArgb(254, 249, 235)
        Me.pnlLiveTracker.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlLiveTracker.Controls.Add(Me.btnRefreshTracker)
        Me.pnlLiveTracker.Controls.Add(Me.lblCountdownNotice)
        Me.pnlLiveTracker.Controls.Add(Me.lblRemainingWaitValue)
        Me.pnlLiveTracker.Controls.Add(Me.lblRemainingWaitTitle)
        Me.pnlLiveTracker.Controls.Add(Me.prgWaitProgress)
        Me.pnlLiveTracker.Controls.Add(Me.lblElapsedWait)
        Me.pnlLiveTracker.Controls.Add(Me.lblStatusBadge)
        Me.pnlLiveTracker.Controls.Add(Me.lblStatusTitle)
        Me.pnlLiveTracker.Controls.Add(Me.lblOrderMeta)
        Me.pnlLiveTracker.Location = New System.Drawing.Point(10, 10)
        Me.pnlLiveTracker.Name = "pnlLiveTracker"
        Me.pnlLiveTracker.Size = New System.Drawing.Size(1072, 215)
        Me.pnlLiveTracker.TabIndex = 0

        ' btnRefreshTracker
        Me.btnRefreshTracker.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefreshTracker.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnRefreshTracker.Location = New System.Drawing.Point(910, 15)
        Me.btnRefreshTracker.Name = "btnRefreshTracker"
        Me.btnRefreshTracker.Size = New System.Drawing.Size(148, 32)
        Me.btnRefreshTracker.TabIndex = 8
        Me.btnRefreshTracker.Text = "Refresh Status"
        Me.btnRefreshTracker.UseVisualStyleBackColor = True

        ' lblCountdownNotice
        Me.lblCountdownNotice.AutoSize = True
        Me.lblCountdownNotice.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Italic)
        Me.lblCountdownNotice.ForeColor = System.Drawing.Color.DimGray
        Me.lblCountdownNotice.Location = New System.Drawing.Point(20, 185)
        Me.lblCountdownNotice.Name = "lblCountdownNotice"
        Me.lblCountdownNotice.Size = New System.Drawing.Size(360, 15)
        Me.lblCountdownNotice.TabIndex = 7
        Me.lblCountdownNotice.Text = "Status updates automatically every 5 seconds as chefs prepare your food."

        ' lblRemainingWaitValue
        Me.lblRemainingWaitValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRemainingWaitValue.AutoSize = True
        Me.lblRemainingWaitValue.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblRemainingWaitValue.ForeColor = System.Drawing.Color.FromArgb(180, 83, 9)
        Me.lblRemainingWaitValue.Location = New System.Drawing.Point(860, 120)
        Me.lblRemainingWaitValue.Name = "lblRemainingWaitValue"
        Me.lblRemainingWaitValue.Size = New System.Drawing.Size(130, 32)
        Me.lblRemainingWaitValue.TabIndex = 6
        Me.lblRemainingWaitValue.Text = "--"

        ' lblRemainingWaitTitle
        Me.lblRemainingWaitTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRemainingWaitTitle.AutoSize = True
        Me.lblRemainingWaitTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblRemainingWaitTitle.ForeColor = System.Drawing.Color.DimGray
        Me.lblRemainingWaitTitle.Location = New System.Drawing.Point(860, 100)
        Me.lblRemainingWaitTitle.Name = "lblRemainingWaitTitle"
        Me.lblRemainingWaitTitle.Size = New System.Drawing.Size(130, 15)
        Me.lblRemainingWaitTitle.TabIndex = 5
        Me.lblRemainingWaitTitle.Text = "Remaining Wait Time:"

        ' prgWaitProgress
        Me.prgWaitProgress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.prgWaitProgress.Location = New System.Drawing.Point(20, 132)
        Me.prgWaitProgress.Name = "prgWaitProgress"
        Me.prgWaitProgress.Size = New System.Drawing.Size(820, 28)
        Me.prgWaitProgress.TabIndex = 4

        ' lblElapsedWait
        Me.lblElapsedWait.AutoSize = True
        Me.lblElapsedWait.Location = New System.Drawing.Point(20, 108)
        Me.lblElapsedWait.Name = "lblElapsedWait"
        Me.lblElapsedWait.Size = New System.Drawing.Size(280, 17)
        Me.lblElapsedWait.TabIndex = 3
        Me.lblElapsedWait.Text = "Cooking Elapsed: 0 mins | Total Est: 0 mins"

        ' lblStatusBadge
        Me.lblStatusBadge.AutoSize = True
        Me.lblStatusBadge.BackColor = System.Drawing.Color.FromArgb(254, 235, 200)
        Me.lblStatusBadge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatusBadge.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblStatusBadge.ForeColor = System.Drawing.Color.FromArgb(180, 83, 9)
        Me.lblStatusBadge.Location = New System.Drawing.Point(20, 64)
        Me.lblStatusBadge.Name = "lblStatusBadge"
        Me.lblStatusBadge.Padding = New System.Windows.Forms.Padding(8, 3, 8, 3)
        Me.lblStatusBadge.Size = New System.Drawing.Size(250, 30)
        Me.lblStatusBadge.TabIndex = 2
        Me.lblStatusBadge.Text = "No Active Order"

        ' lblStatusTitle
        Me.lblStatusTitle.AutoSize = True
        Me.lblStatusTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblStatusTitle.Location = New System.Drawing.Point(20, 43)
        Me.lblStatusTitle.Name = "lblStatusTitle"
        Me.lblStatusTitle.Size = New System.Drawing.Size(165, 17)
        Me.lblStatusTitle.TabIndex = 1
        Me.lblStatusTitle.Text = "Current Kitchen Status:"

        ' lblOrderMeta
        Me.lblOrderMeta.AutoSize = True
        Me.lblOrderMeta.Font = New System.Drawing.Font("Segoe UI Semibold", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblOrderMeta.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblOrderMeta.Location = New System.Drawing.Point(18, 12)
        Me.lblOrderMeta.Name = "lblOrderMeta"
        Me.lblOrderMeta.Size = New System.Drawing.Size(400, 19)
        Me.lblOrderMeta.TabIndex = 0
        Me.lblOrderMeta.Text = "No active order for this table right now."

        ' grpOrderedItems
        Me.grpOrderedItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpOrderedItems.Controls.Add(Me.dgvTrackedItems)
        Me.grpOrderedItems.Location = New System.Drawing.Point(10, 235)
        Me.grpOrderedItems.Name = "grpOrderedItems"
        Me.grpOrderedItems.Padding = New System.Windows.Forms.Padding(8)
        Me.grpOrderedItems.Size = New System.Drawing.Size(1072, 320)
        Me.grpOrderedItems.TabIndex = 1
        Me.grpOrderedItems.TabStop = False
        Me.grpOrderedItems.Text = "Dishes in This Order"

        ' dgvTrackedItems
        Me.dgvTrackedItems.AllowUserToAddRows = False
        Me.dgvTrackedItems.AllowUserToDeleteRows = False
        Me.dgvTrackedItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvTrackedItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTrackedItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTrackedItems.Location = New System.Drawing.Point(8, 23)
        Me.dgvTrackedItems.MultiSelect = False
        Me.dgvTrackedItems.Name = "dgvTrackedItems"
        Me.dgvTrackedItems.ReadOnly = True
        Me.dgvTrackedItems.RowHeadersWidth = 35
        Me.dgvTrackedItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTrackedItems.Size = New System.Drawing.Size(1056, 289)
        Me.dgvTrackedItems.TabIndex = 0

        ' tmrWaitCountdown
        Me.tmrWaitCountdown.Interval = 5000

        ' frmCustomerOrder
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1100, 661)
        Me.Controls.Add(Me.tabCustomer)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "frmCustomerOrder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Spice Garden - Table Menu & Order Status Tracker"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.tabCustomer.ResumeLayout(False)
        Me.tabMenuOrder.ResumeLayout(False)
        Me.splOrder.Panel1.ResumeLayout(False)
        Me.splOrder.Panel2.ResumeLayout(False)
        CType(Me.splOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splOrder.ResumeLayout(False)
        Me.pnlLeftMenu.ResumeLayout(False)
        Me.grpMenu.ResumeLayout(False)
        Me.pnlAddToCart.ResumeLayout(False)
        Me.pnlAddToCart.PerformLayout()
        CType(Me.numQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMenuCatalog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCategory.ResumeLayout(False)
        Me.pnlCategory.PerformLayout()
        Me.grpRecipe.ResumeLayout(False)
        Me.grpRecipe.PerformLayout()
        Me.grpCart.ResumeLayout(False)
        Me.pnlCheckout.ResumeLayout(False)
        Me.pnlCheckout.PerformLayout()
        CType(Me.dgvCart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabTrackOrder.ResumeLayout(False)
        Me.pnlLiveTracker.ResumeLayout(False)
        Me.pnlLiveTracker.PerformLayout()
        Me.grpOrderedItems.ResumeLayout(False)
        CType(Me.dgvTrackedItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents btnClose As Button
    Friend WithEvents lblTableInfo As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents tabCustomer As TabControl
    Friend WithEvents tabMenuOrder As TabPage
    Friend WithEvents tabTrackOrder As TabPage
    Friend WithEvents splOrder As SplitContainer
    Friend WithEvents pnlLeftMenu As Panel
    Friend WithEvents grpMenu As GroupBox
    Friend WithEvents pnlAddToCart As Panel
    Friend WithEvents btnAddToCart As Button
    Friend WithEvents numQty As NumericUpDown
    Friend WithEvents lblQty As Label
    Friend WithEvents dgvMenuCatalog As DataGridView
    Friend WithEvents pnlCategory As Panel
    Friend WithEvents cboFilterCategory As ComboBox
    Friend WithEvents lblFilterCat As Label
    Friend WithEvents grpRecipe As GroupBox
    Friend WithEvents lblRecipeTitle As Label
    Friend WithEvents lblRecipeDesc As Label
    Friend WithEvents lblIngredientsHead As Label
    Friend WithEvents txtIngredients As TextBox
    Friend WithEvents lblRecipeHead As Label
    Friend WithEvents txtRecipeSteps As TextBox
    Friend WithEvents lblCustomNote As Label
    Friend WithEvents txtCustomization As TextBox
    Friend WithEvents grpCart As GroupBox
    Friend WithEvents pnlCheckout As Panel
    Friend WithEvents lblCustNameLabel As Label
    Friend WithEvents txtCustomerName As TextBox
    Friend WithEvents btnPlaceOrder As Button
    Friend WithEvents btnClearCart As Button
    Friend WithEvents btnRemoveFromCart As Button
    Friend WithEvents lblEstWaitInfo As Label
    Friend WithEvents lblTotalAmount As Label
    Friend WithEvents dgvCart As DataGridView
    Friend WithEvents pnlLiveTracker As Panel
    Friend WithEvents lblCountdownNotice As Label
    Friend WithEvents lblRemainingWaitValue As Label
    Friend WithEvents lblRemainingWaitTitle As Label
    Friend WithEvents prgWaitProgress As ProgressBar
    Friend WithEvents lblElapsedWait As Label
    Friend WithEvents lblStatusBadge As Label
    Friend WithEvents lblStatusTitle As Label
    Friend WithEvents lblOrderMeta As Label
    Friend WithEvents btnRefreshTracker As Button
    Friend WithEvents grpOrderedItems As GroupBox
    Friend WithEvents dgvTrackedItems As DataGridView
    Friend WithEvents tmrWaitCountdown As Timer
End Class
