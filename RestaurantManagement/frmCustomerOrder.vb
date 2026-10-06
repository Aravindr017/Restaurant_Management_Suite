Imports System.Data.OleDb

Public Class frmCustomerOrder
    Private CartTable As DataTable
    Private CurrentActiveOrderID As Integer = -1

    Private Sub frmCustomerOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblTableInfo.Text = "Ordering for: Table #" & SelectedTableNumber & " | " & ActiveCustomerName
        InitializeCartTable()
        LoadMenuCatalog()
        If cboFilterCategory.Items.Count > 0 Then cboFilterCategory.SelectedIndex = 0

        ' Check if there is already an active order for this table
        CheckActiveOrder()
        tmrWaitCountdown.Start()
    End Sub

    ' =========================================================================
    ' 1. MENU BROWSING & CART
    ' =========================================================================
    Private Sub InitializeCartTable()
        CartTable = New DataTable()
        CartTable.Columns.Add("ItemID", GetType(Integer))
        CartTable.Columns.Add("ItemName", GetType(String))
        CartTable.Columns.Add("Quantity", GetType(Integer))
        CartTable.Columns.Add("UnitPrice", GetType(Double))
        CartTable.Columns.Add("SubTotal", GetType(Double))
        CartTable.Columns.Add("PrepTimeMinutes", GetType(Integer))

        dgvCart.DataSource = CartTable

        If dgvCart.Columns.Contains("ItemID") Then dgvCart.Columns("ItemID").Visible = False
        If dgvCart.Columns.Contains("PrepTimeMinutes") Then dgvCart.Columns("PrepTimeMinutes").Visible = False
        If dgvCart.Columns.Contains("ItemName") Then dgvCart.Columns("ItemName").HeaderText = "Dish"
        If dgvCart.Columns.Contains("Quantity") Then dgvCart.Columns("Quantity").HeaderText = "Qty"
        If dgvCart.Columns.Contains("UnitPrice") Then
            dgvCart.Columns("UnitPrice").HeaderText = "Price"
            dgvCart.Columns("UnitPrice").DefaultCellStyle.Format = "c"
        End If
        If dgvCart.Columns.Contains("SubTotal") Then
            dgvCart.Columns("SubTotal").HeaderText = "Subtotal"
            dgvCart.Columns("SubTotal").DefaultCellStyle.Format = "c"
        End If
    End Sub

    Private Sub LoadMenuCatalog()
        If Not DbConnect() Then Return
        Try
            Dim categoryFilter As String = If(cboFilterCategory.SelectedItem IsNot Nothing, cboFilterCategory.SelectedItem.ToString(), "All Categories")
            Dim sql As String = "SELECT ItemID, ItemName, Category, Price, PrepTimeMinutes, Description FROM tblMenuItems"

            If categoryFilter <> "All Categories" Then
                sql &= " WHERE Category = @cat"
            End If
            sql &= " ORDER BY Category, ItemName"

            Dim cmd As New OleDbCommand(sql, cn)
            If categoryFilter <> "All Categories" Then
                cmd.Parameters.AddWithValue("@cat", categoryFilter)
            End If

            Dim da As New OleDbDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)
            dgvMenuCatalog.DataSource = dt

            If dgvMenuCatalog.Columns.Contains("ItemID") Then dgvMenuCatalog.Columns("ItemID").Visible = False
            If dgvMenuCatalog.Columns.Contains("ItemName") Then dgvMenuCatalog.Columns("ItemName").HeaderText = "Dish Name"
            If dgvMenuCatalog.Columns.Contains("Category") Then dgvMenuCatalog.Columns("Category").HeaderText = "Category"
            If dgvMenuCatalog.Columns.Contains("Price") Then
                dgvMenuCatalog.Columns("Price").HeaderText = "Price"
                dgvMenuCatalog.Columns("Price").DefaultCellStyle.Format = "c"
            End If
            If dgvMenuCatalog.Columns.Contains("PrepTimeMinutes") Then dgvMenuCatalog.Columns("PrepTimeMinutes").HeaderText = "Prep Time (Min)"
            If dgvMenuCatalog.Columns.Contains("Description") Then dgvMenuCatalog.Columns("Description").HeaderText = "Description"
        Catch ex As Exception
            MessageBox.Show("Error loading menu: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DbClose()
        End Try
    End Sub

    Private Sub cboFilterCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFilterCategory.SelectedIndexChanged
        LoadMenuCatalog()
    End Sub

    Private Sub btnAddToCart_Click(sender As Object, e As EventArgs) Handles btnAddToCart.Click
        If dgvMenuCatalog.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a dish from the menu first.", "Select Dish", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim row As DataGridViewRow = dgvMenuCatalog.SelectedRows(0)
        Dim itemID As Integer = Convert.ToInt32(row.Cells("ItemID").Value)
        Dim itemName As String = row.Cells("ItemName").Value.ToString()
        Dim unitPrice As Double = Convert.ToDouble(row.Cells("Price").Value)
        Dim prepMins As Integer = Convert.ToInt32(row.Cells("PrepTimeMinutes").Value)
        Dim qty As Integer = Convert.ToInt32(numQty.Value)

        ' Check if already in cart
        Dim existingRow As DataRow = Nothing
        For Each r As DataRow In CartTable.Rows
            If Convert.ToInt32(r("ItemID")) = itemID Then
                existingRow = r
                Exit For
            End If
        Next

        If existingRow IsNot Nothing Then
            Dim newQty As Integer = Convert.ToInt32(existingRow("Quantity")) + qty
            existingRow("Quantity") = newQty
            existingRow("SubTotal") = newQty * unitPrice
        Else
            Dim newRow As DataRow = CartTable.NewRow()
            newRow("ItemID") = itemID
            newRow("ItemName") = itemName
            newRow("Quantity") = qty
            newRow("UnitPrice") = unitPrice
            newRow("SubTotal") = qty * unitPrice
            newRow("PrepTimeMinutes") = prepMins
            CartTable.Rows.Add(newRow)
        End If

        UpdateCartTotals()
        numQty.Value = 1
    End Sub

    Private Sub UpdateCartTotals()
        Dim totalBill As Double = 0
        Dim maxPrepTime As Integer = 0

        For Each r As DataRow In CartTable.Rows
            totalBill += Convert.ToDouble(r("SubTotal"))
            Dim itemPrep As Integer = Convert.ToInt32(r("PrepTimeMinutes"))
            If itemPrep > maxPrepTime Then maxPrepTime = itemPrep
        Next

        ' Add 3 minutes kitchen queuing offset if cart not empty
        Dim estWait As Integer = If(CartTable.Rows.Count > 0, maxPrepTime + 3, 0)

        lblTotalAmount.Text = "Total Bill: " & totalBill.ToString("c")
        lblEstWaitInfo.Text = "Estimated Prep Time: ~" & estWait & " minutes (Kitchen queuing included)"
    End Sub

    Private Sub btnClearCart_Click(sender As Object, e As EventArgs) Handles btnClearCart.Click
        CartTable.Rows.Clear()
        UpdateCartTotals()
    End Sub

    ' =========================================================================
    ' 2. SUBMITTING ORDER
    ' =========================================================================
    Private Sub btnPlaceOrder_Click(sender As Object, e As EventArgs) Handles btnPlaceOrder.Click
        If CartTable.Rows.Count = 0 Then
            MessageBox.Show("Your cart is empty! Please add dishes to the cart before submitting.", "Empty Order", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If DbConnect() Then
            Try
                ' 1. Lookup assigned waiter for this table
                Dim waiterID As Integer = 0
                Dim waiterName As String = "Unassigned"

                Dim tCmd As New OleDbCommand("SELECT AssignedWaiterID, AssignedWaiterName FROM tblTables WHERE TableNumber = @tn", cn)
                tCmd.Parameters.AddWithValue("@tn", SelectedTableNumber)
                Dim reader As OleDbDataReader = tCmd.ExecuteReader()
                If reader.Read() Then
                    waiterID = If(IsDBNull(reader("AssignedWaiterID")), 0, Convert.ToInt32(reader("AssignedWaiterID")))
                    waiterName = If(IsDBNull(reader("AssignedWaiterName")), "Staff", reader("AssignedWaiterName").ToString())
                End If
                reader.Close()

                ' 2. Calculate Total & Estimated Wait Time
                Dim totalBill As Double = 0
                Dim maxPrepTime As Integer = 0
                For Each r As DataRow In CartTable.Rows
                    totalBill += Convert.ToDouble(r("SubTotal"))
                    Dim p As Integer = Convert.ToInt32(r("PrepTimeMinutes"))
                    If p > maxPrepTime Then maxPrepTime = p
                Next
                Dim estWaitMins As Integer = maxPrepTime + 3

                ' 3. Insert into tblOrders
                Dim orderCmd As New OleDbCommand("INSERT INTO tblOrders (TableNumber, CustomerName, WaiterID, WaiterName, OrderStatus, OrderTime, EstWaitMinutes, TotalAmount, Notes) " &
                                                 "VALUES (@tn, @cust, @wid, @wname, @stat, @otime, @wait, @tot, @notes)", cn)
                orderCmd.Parameters.AddWithValue("@tn", SelectedTableNumber)
                orderCmd.Parameters.AddWithValue("@cust", ActiveCustomerName)
                orderCmd.Parameters.AddWithValue("@wid", waiterID)
                orderCmd.Parameters.AddWithValue("@wname", waiterName)
                orderCmd.Parameters.AddWithValue("@stat", "Preparing in Kitchen")
                orderCmd.Parameters.AddWithValue("@otime", DateTime.Now)
                orderCmd.Parameters.AddWithValue("@wait", estWaitMins)
                orderCmd.Parameters.AddWithValue("@tot", totalBill)
                orderCmd.Parameters.AddWithValue("@notes", "Ordered directly via table portal")
                orderCmd.ExecuteNonQuery()

                ' Get newly generated OrderID
                orderCmd.Parameters.Clear()
                orderCmd.CommandText = "SELECT @@IDENTITY"
                Dim newOrderID As Integer = Convert.ToInt32(orderCmd.ExecuteScalar())
                CurrentActiveOrderID = newOrderID

                ' 4. Insert each dish into tblOrderItems
                For Each r As DataRow In CartTable.Rows
                    Dim itemCmd As New OleDbCommand("INSERT INTO tblOrderItems (OrderID, ItemID, ItemName, Quantity, UnitPrice, SubTotal, ItemStatus) " &
                                                   "VALUES (@oid, @iid, @iname, @qty, @pr, @sub, @stat)", cn)
                    itemCmd.Parameters.AddWithValue("@oid", newOrderID)
                    itemCmd.Parameters.AddWithValue("@iid", Convert.ToInt32(r("ItemID")))
                    itemCmd.Parameters.AddWithValue("@iname", r("ItemName").ToString())
                    itemCmd.Parameters.AddWithValue("@qty", Convert.ToInt32(r("Quantity")))
                    itemCmd.Parameters.AddWithValue("@pr", Convert.ToDouble(r("UnitPrice")))
                    itemCmd.Parameters.AddWithValue("@sub", Convert.ToDouble(r("SubTotal")))
                    itemCmd.Parameters.AddWithValue("@stat", "Preparing in Kitchen")
                    itemCmd.ExecuteNonQuery()
                Next

                ' 5. Mark Table status as Occupied
                Dim occCmd As New OleDbCommand("UPDATE tblTables SET TableStatus = 'Occupied' WHERE TableNumber = @tn", cn)
                occCmd.Parameters.AddWithValue("@tn", SelectedTableNumber)
                occCmd.ExecuteNonQuery()

                MessageBox.Show("Your food order (Order #" & newOrderID & ") has been submitted to the kitchen!" & vbCrLf &
                                "Estimated preparation time: ~" & estWaitMins & " minutes." & vbCrLf &
                                "Assigned Waiter: " & waiterName, "Order Placed Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Clear Cart
                CartTable.Rows.Clear()
                UpdateCartTotals()

                ' Switch directly to Live Kitchen Status Tracker tab
                tabCustomer.SelectedTab = tabTrackOrder
                CheckActiveOrder()

            Catch ex As Exception
                MessageBox.Show("Error placing order: " & ex.Message, "Order Submission Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                DbClose()
            End Try
        End If
    End Sub

    ' =========================================================================
    ' 3. LIVE KITCHEN STATUS & ESTIMATED WAIT TIME COUNTDOWN
    ' =========================================================================
    Public Sub CheckActiveOrder()
        If Not DbConnect() Then Return
        Try
            Dim cmd As New OleDbCommand("SELECT TOP 1 OrderID, TableNumber, CustomerName, WaiterName, OrderStatus, OrderTime, EstWaitMinutes, TotalAmount " &
                                        "FROM tblOrders WHERE TableNumber = @tn AND OrderStatus <> 'Completed / Paid' ORDER BY OrderID DESC", cn)
            cmd.Parameters.AddWithValue("@tn", SelectedTableNumber)
            Dim reader As OleDbDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                CurrentActiveOrderID = Convert.ToInt32(reader("OrderID"))
                Dim status As String = reader("OrderStatus").ToString()
                Dim waiterName As String = reader("WaiterName").ToString()
                Dim orderTime As DateTime = Convert.ToDateTime(reader("OrderTime"))
                Dim estWaitMinutes As Integer = Convert.ToInt32(reader("EstWaitMinutes"))
                Dim totalBill As Double = Convert.ToDouble(reader("TotalAmount"))

                lblOrderMeta.Text = "Order #" & CurrentActiveOrderID & " for Table " & SelectedTableNumber & " | Assigned Waiter: " & waiterName & " | Total: " & totalBill.ToString("c")

                ' Format Status Badge
                lblStatusBadge.Text = status
                Select Case status
                    Case "Preparing in Kitchen"
                        lblStatusBadge.BackColor = Color.FromArgb(254, 235, 200)
                        lblStatusBadge.ForeColor = Color.FromArgb(180, 83, 9)
                        lblStatusBadge.Text = "Preparing in Kitchen 👨‍🍳"
                    Case "Ready to Serve"
                        lblStatusBadge.BackColor = Color.FromArgb(220, 252, 231)
                        lblStatusBadge.ForeColor = Color.FromArgb(22, 101, 52)
                        lblStatusBadge.Text = "Food is Ready to Serve! 🍽️"
                    Case "Served to Customer"
                        lblStatusBadge.BackColor = Color.FromArgb(219, 234, 254)
                        lblStatusBadge.ForeColor = Color.FromArgb(30, 64, 175)
                        lblStatusBadge.Text = "Served at Table - Enjoy Your Meal! ✅"
                    Case Else
                        lblStatusBadge.BackColor = Color.FromArgb(243, 244, 246)
                        lblStatusBadge.ForeColor = Color.FromArgb(55, 65, 81)
                        lblStatusBadge.Text = status
                End Select

                ' Wait time calculations
                Dim elapsedSpan As TimeSpan = DateTime.Now - orderTime
                Dim elapsedMins As Integer = Math.Max(0, CInt(Math.Floor(elapsedSpan.TotalMinutes)))
                Dim remainingMins As Integer = Math.Max(0, estWaitMinutes - elapsedMins)

                lblElapsedWait.Text = "Cooking Elapsed: " & elapsedMins & " min(s) | Total Estimated Time: " & estWaitMinutes & " min(s)"

                If status = "Ready to Serve" OrElse status = "Served to Customer" Then
                    lblRemainingWaitValue.Text = "0 mins (Ready!)"
                    lblRemainingWaitValue.ForeColor = Color.ForestGreen
                    prgWaitProgress.Value = 100
                Else
                    lblRemainingWaitValue.Text = "~" & remainingMins & " mins"
                    lblRemainingWaitValue.ForeColor = Color.FromArgb(180, 83, 9)

                    Dim pct As Integer = 0
                    If estWaitMinutes > 0 Then
                        pct = CInt((CDbl(elapsedMins) / CDbl(estWaitMinutes)) * 100)
                        If pct > 95 Then pct = 95
                    End If
                    prgWaitProgress.Value = Math.Max(0, Math.Min(100, pct))
                End If

                reader.Close()

                ' Load itemized dish breakdown
                LoadTrackedItems(CurrentActiveOrderID)
            Else
                reader.Close()
                lblOrderMeta.Text = "No active food preparation order for Table #" & SelectedTableNumber & " right now."
                lblStatusBadge.Text = "No Active Order"
                lblStatusBadge.BackColor = Color.FromArgb(243, 244, 246)
                lblStatusBadge.ForeColor = Color.FromArgb(107, 114, 128)
                lblElapsedWait.Text = "You can place a new food order from the 'Browse Menu' tab."
                lblRemainingWaitValue.Text = "--"
                prgWaitProgress.Value = 0
            End If

        Catch ex As Exception
            ' Ignore live poll errors
        Finally
            DbClose()
        End Try
    End Sub

    Private Sub LoadTrackedItems(orderID As Integer)
        If Not DbConnect() Then Return
        Try
            Dim dt As New DataTable()
            Dim cmd As New OleDbCommand("SELECT ItemName, Quantity, UnitPrice, SubTotal, ItemStatus FROM tblOrderItems WHERE OrderID = @oid", cn)
            cmd.Parameters.AddWithValue("@oid", orderID)
            Dim da As New OleDbDataAdapter(cmd)
            da.Fill(dt)
            dgvTrackedItems.DataSource = dt

            If dgvTrackedItems.Columns.Contains("ItemName") Then dgvTrackedItems.Columns("ItemName").HeaderText = "Dish Name"
            If dgvTrackedItems.Columns.Contains("Quantity") Then dgvTrackedItems.Columns("Quantity").HeaderText = "Qty"
            If dgvTrackedItems.Columns.Contains("UnitPrice") Then
                dgvTrackedItems.Columns("UnitPrice").HeaderText = "Price"
                dgvTrackedItems.Columns("UnitPrice").DefaultCellStyle.Format = "c"
            End If
            If dgvTrackedItems.Columns.Contains("SubTotal") Then
                dgvTrackedItems.Columns("SubTotal").HeaderText = "Subtotal"
                dgvTrackedItems.Columns("SubTotal").DefaultCellStyle.Format = "c"
            End If
            If dgvTrackedItems.Columns.Contains("ItemStatus") Then dgvTrackedItems.Columns("ItemStatus").HeaderText = "Dish Prep Status"
        Catch ex As Exception
            ' Ignore items load
        Finally
            DbClose()
        End Try
    End Sub

    Private Sub tmrWaitCountdown_Tick(sender As Object, e As EventArgs) Handles tmrWaitCountdown.Tick
        CheckActiveOrder()
    End Sub

    Private Sub btnRefreshTracker_Click(sender As Object, e As EventArgs) Handles btnRefreshTracker.Click
        CheckActiveOrder()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        tmrWaitCountdown.Stop()
        Me.Close()
    End Sub

    Private Sub frmCustomerOrder_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        tmrWaitCountdown.Stop()
    End Sub

End Class
