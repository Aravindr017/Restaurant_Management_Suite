Imports System.Data.OleDb

Public Class frmOwnerDashboard
    Private SelectedTableID As Integer = -1
    Private SelectedTableNumber As Integer = -1

    Private Sub frmOwnerDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblOwnerInfo.Text = "Logged In: " & CurrentUserFullName & " (Owner) | Full Administrative Control"
        LoadTables()
        LoadWaiters()
        LoadMenu()
        LoadOrdersAndStats()

        If cboCategory.Items.Count > 0 Then cboCategory.SelectedIndex = 0
        If cboTableStatus.Items.Count > 0 Then cboTableStatus.SelectedIndex = 0
    End Sub

    ' =========================================================================
    ' 1. TABLES & WAITER ASSIGNMENT
    ' =========================================================================
    Public Sub LoadTables()
        If Not DbConnect() Then Return
        Try
            Dim dt As New DataTable()
            Dim da As New OleDbDataAdapter("SELECT TableID, TableNumber, Capacity, TableStatus, AssignedWaiterID, AssignedWaiterName FROM tblTables ORDER BY TableNumber ASC", cn)
            da.Fill(dt)
            dgvTables.DataSource = dt

            If dgvTables.Columns.Contains("TableID") Then dgvTables.Columns("TableID").Visible = False
            If dgvTables.Columns.Contains("AssignedWaiterID") Then dgvTables.Columns("AssignedWaiterID").Visible = False
            If dgvTables.Columns.Contains("TableNumber") Then dgvTables.Columns("TableNumber").HeaderText = "Table #"
            If dgvTables.Columns.Contains("Capacity") Then dgvTables.Columns("Capacity").HeaderText = "Seating Seats"
            If dgvTables.Columns.Contains("TableStatus") Then dgvTables.Columns("TableStatus").HeaderText = "Current Status"
            If dgvTables.Columns.Contains("AssignedWaiterName") Then dgvTables.Columns("AssignedWaiterName").HeaderText = "Assigned Waiter"
        Catch ex As Exception
            MessageBox.Show("Error loading tables: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DbClose()
        End Try
    End Sub

    Private Sub dgvTables_SelectionChanged(sender As Object, e As EventArgs) Handles dgvTables.SelectionChanged
        If dgvTables.SelectedRows.Count > 0 Then
            Dim row As DataGridViewRow = dgvTables.SelectedRows(0)
            SelectedTableID = Convert.ToInt32(row.Cells("TableID").Value)
            SelectedTableNumber = Convert.ToInt32(row.Cells("TableNumber").Value)
            Dim status As String = row.Cells("TableStatus").Value.ToString()
            Dim waiter As String = row.Cells("AssignedWaiterName").Value.ToString()

            lblSelectedTableInfo.Text = "Selected: Table #" & SelectedTableNumber & " (Capacity: " & row.Cells("Capacity").Value.ToString() &
                                       " seats) | Current Waiter: " & If(String.IsNullOrEmpty(waiter), "None", waiter)

            If cboTableStatus.Items.Contains(status) Then
                cboTableStatus.SelectedItem = status
            End If

            If cboWaitersForAssign.Items.Contains(waiter) Then
                cboWaitersForAssign.SelectedItem = waiter
            End If
        End If
    End Sub

    Private Sub btnAssignWaiter_Click(sender As Object, e As EventArgs) Handles btnAssignWaiter.Click
        If SelectedTableID = -1 Then
            MessageBox.Show("Please select a table from the list first.", "Select Table", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If cboWaitersForAssign.SelectedIndex = -1 Then
            MessageBox.Show("Please select a waiter to assign.", "Select Waiter", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim chosenWaiterName As String = cboWaitersForAssign.SelectedItem.ToString()

        If DbConnect() Then
            Try
                ' Find waiter ID
                Dim widCmd As New OleDbCommand("SELECT StaffID FROM tblStaff WHERE FullName = @fn", cn)
                widCmd.Parameters.AddWithValue("@fn", chosenWaiterName)
                Dim waiterIDObj As Object = widCmd.ExecuteScalar()
                Dim waiterID As Integer = If(waiterIDObj IsNot Nothing, Convert.ToInt32(waiterIDObj), 0)

                Dim updateCmd As New OleDbCommand("UPDATE tblTables SET AssignedWaiterID = @wid, AssignedWaiterName = @wname WHERE TableID = @tid", cn)
                updateCmd.Parameters.AddWithValue("@wid", waiterID)
                updateCmd.Parameters.AddWithValue("@wname", chosenWaiterName)
                updateCmd.Parameters.AddWithValue("@tid", SelectedTableID)
                updateCmd.ExecuteNonQuery()

                MessageBox.Show("Waiter '" & chosenWaiterName & "' successfully assigned to Table #" & SelectedTableNumber & "!",
                                "Assignment Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadTables()
            Catch ex As Exception
                MessageBox.Show("Error assigning waiter: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                DbClose()
            End Try
        End If
    End Sub

    Private Sub btnUpdateTableStatus_Click(sender As Object, e As EventArgs) Handles btnUpdateTableStatus.Click
        If SelectedTableID = -1 Then
            MessageBox.Show("Please select a table from the list first.", "Select Table", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If cboTableStatus.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a valid table status from the dropdown.", "Select Status", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim newStatus As String = cboTableStatus.SelectedItem.ToString()

        If DbConnect() Then
            Try
                Dim cmd As New OleDbCommand("UPDATE tblTables SET TableStatus = @st WHERE TableID = @tid", cn)
                cmd.Parameters.AddWithValue("@st", newStatus)
                cmd.Parameters.AddWithValue("@tid", SelectedTableID)
                cmd.ExecuteNonQuery()

                MessageBox.Show("Table #" & SelectedTableNumber & " status updated to '" & newStatus & "'!", "Status Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadTables()
            Catch ex As Exception
                MessageBox.Show("Error updating table status: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                DbClose()
            End Try
        End If
    End Sub

    ' =========================================================================
    ' 2. WAITER ROSTER & STAFF MANAGEMENT
    ' =========================================================================
    Public Sub LoadWaiters()
        If Not DbConnect() Then Return
        Try
            Dim dt As New DataTable()
            Dim da As New OleDbDataAdapter("SELECT StaffID, FullName, UserName, Role, Phone, Salary FROM tblStaff WHERE Role = 'Waiter' ORDER BY FullName ASC", cn)
            da.Fill(dt)
            dgvWaiters.DataSource = dt

            If dgvWaiters.Columns.Contains("StaffID") Then dgvWaiters.Columns("StaffID").Visible = False
            If dgvWaiters.Columns.Contains("FullName") Then dgvWaiters.Columns("FullName").HeaderText = "Waiter Name"
            If dgvWaiters.Columns.Contains("UserName") Then dgvWaiters.Columns("UserName").HeaderText = "Login Username"
            If dgvWaiters.Columns.Contains("Phone") Then dgvWaiters.Columns("Phone").HeaderText = "Phone"
            If dgvWaiters.Columns.Contains("Salary") Then
                dgvWaiters.Columns("Salary").HeaderText = "Annual Salary"
                dgvWaiters.Columns("Salary").DefaultCellStyle.Format = "c"
            End If

            ' Populate Assign combo
            cboWaitersForAssign.Items.Clear()
            For Each row As DataRow In dt.Rows
                cboWaitersForAssign.Items.Add(row("FullName").ToString())
            Next
            If cboWaitersForAssign.Items.Count > 0 Then cboWaitersForAssign.SelectedIndex = 0

        Catch ex As Exception
            MessageBox.Show("Error loading waiters: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DbClose()
        End Try
    End Sub

    Private Sub btnAddNewWaiter_Click(sender As Object, e As EventArgs) Handles btnAddNewWaiter.Click
        Dim editForm As New frmStaffEdit()
        If editForm.ShowDialog() = DialogResult.OK Then
            LoadWaiters()
            LoadTables()
        End If
    End Sub

    Private Sub btnDeleteWaiter_Click(sender As Object, e As EventArgs) Handles btnDeleteWaiter.Click
        If dgvWaiters.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a waiter to delete from the list.", "Select Waiter", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim staffID As Integer = Convert.ToInt32(dgvWaiters.SelectedRows(0).Cells("StaffID").Value)
        Dim waiterName As String = dgvWaiters.SelectedRows(0).Cells("FullName").Value.ToString()

        Dim confirm As DialogResult = MessageBox.Show("Are you sure you want to remove waiter '" & waiterName & "' from the restaurant staff?",
                                                      "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If confirm = DialogResult.Yes Then
            If DbConnect() Then
                Try
                    ' Clear assignments on tables
                    Dim clrCmd As New OleDbCommand("UPDATE tblTables SET AssignedWaiterID = 0, AssignedWaiterName = 'Unassigned' WHERE AssignedWaiterID = @sid", cn)
                    clrCmd.Parameters.AddWithValue("@sid", staffID)
                    clrCmd.ExecuteNonQuery()

                    ' Delete waiter record
                    Dim delCmd As New OleDbCommand("DELETE FROM tblStaff WHERE StaffID = @sid", cn)
                    delCmd.Parameters.AddWithValue("@sid", staffID)
                    delCmd.ExecuteNonQuery()

                    MessageBox.Show("Waiter '" & waiterName & "' removed successfully.", "Waiter Removed", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadWaiters()
                    LoadTables()
                Catch ex As Exception
                    MessageBox.Show("Error deleting waiter: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    DbClose()
                End Try
            End If
        End If
    End Sub

    Private Sub btnRefreshWaiters_Click(sender As Object, e As EventArgs) Handles btnRefreshWaiters.Click
        LoadWaiters()
    End Sub

    ' =========================================================================
    ' 3. MENU CATALOG & PREPARATION TIME MANAGEMENT
    ' =========================================================================
    Public Sub LoadMenu()
        If Not DbConnect() Then Return
        Try
            Dim dt As New DataTable()
            Dim da As New OleDbDataAdapter("SELECT ItemID, ItemName, Category, Price, PrepTimeMinutes, Description FROM tblMenuItems ORDER BY Category, ItemName", cn)
            da.Fill(dt)
            dgvMenu.DataSource = dt

            If dgvMenu.Columns.Contains("ItemID") Then dgvMenu.Columns("ItemID").Visible = False
            If dgvMenu.Columns.Contains("ItemName") Then dgvMenu.Columns("ItemName").HeaderText = "Dish / Item Name"
            If dgvMenu.Columns.Contains("Category") Then dgvMenu.Columns("Category").HeaderText = "Category"
            If dgvMenu.Columns.Contains("Price") Then
                dgvMenu.Columns("Price").HeaderText = "Price"
                dgvMenu.Columns("Price").DefaultCellStyle.Format = "c"
            End If
            If dgvMenu.Columns.Contains("PrepTimeMinutes") Then dgvMenu.Columns("PrepTimeMinutes").HeaderText = "Prep Time (Mins)"
            If dgvMenu.Columns.Contains("Description") Then dgvMenu.Columns("Description").HeaderText = "Description / Ingredients"
        Catch ex As Exception
            MessageBox.Show("Error loading menu: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DbClose()
        End Try
    End Sub

    Private Sub btnAddMenuItem_Click(sender As Object, e As EventArgs) Handles btnAddMenuItem.Click
        Dim itemName As String = txtItemName.Text.Trim()
        Dim category As String = If(cboCategory.SelectedItem IsNot Nothing, cboCategory.SelectedItem.ToString(), "Mains")
        Dim desc As String = txtItemDescription.Text.Trim()
        Dim priceVal As Double
        Dim prepMinsVal As Integer

        If String.IsNullOrEmpty(itemName) Then
            MessageBox.Show("Please enter the dish / food item name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtItemName.Focus()
            Return
        End If

        If Not Double.TryParse(txtPrice.Text.Trim(), priceVal) OrElse priceVal <= 0 Then
            MessageBox.Show("Please enter a valid positive price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPrice.Focus()
            Return
        End If

        If Not Integer.TryParse(txtPrepTime.Text.Trim(), prepMinsVal) OrElse prepMinsVal <= 0 Then
            MessageBox.Show("Please enter a valid preparation time in minutes.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPrepTime.Focus()
            Return
        End If

        If DbConnect() Then
            Try
                Dim cmd As New OleDbCommand("INSERT INTO tblMenuItems (ItemName, Category, Price, PrepTimeMinutes, Description) " &
                                            "VALUES (@name, @cat, @pr, @prep, @desc)", cn)
                cmd.Parameters.AddWithValue("@name", itemName)
                cmd.Parameters.AddWithValue("@cat", category)
                cmd.Parameters.AddWithValue("@pr", priceVal)
                cmd.Parameters.AddWithValue("@prep", prepMinsVal)
                cmd.Parameters.AddWithValue("@desc", desc)
                cmd.ExecuteNonQuery()

                MessageBox.Show("Dish '" & itemName & "' added to menu successfully!", "Menu Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtItemName.Text = ""
                txtPrice.Text = ""
                txtPrepTime.Text = ""
                txtItemDescription.Text = ""
                LoadMenu()
            Catch ex As Exception
                MessageBox.Show("Error adding menu item: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                DbClose()
            End Try
        End If
    End Sub

    Private Sub btnDeleteItem_Click(sender As Object, e As EventArgs) Handles btnDeleteItem.Click
        If dgvMenu.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an item from the menu grid to delete.", "Select Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim itemID As Integer = Convert.ToInt32(dgvMenu.SelectedRows(0).Cells("ItemID").Value)
        Dim itemName As String = dgvMenu.SelectedRows(0).Cells("ItemName").Value.ToString()

        Dim confirm As DialogResult = MessageBox.Show("Remove '" & itemName & "' from the restaurant menu?", "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If confirm = DialogResult.Yes Then
            If DbConnect() Then
                Try
                    Dim cmd As New OleDbCommand("DELETE FROM tblMenuItems WHERE ItemID = @id", cn)
                    cmd.Parameters.AddWithValue("@id", itemID)
                    cmd.ExecuteNonQuery()

                    MessageBox.Show("Item removed from menu.", "Item Removed", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadMenu()
                Catch ex As Exception
                    MessageBox.Show("Error removing item: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    DbClose()
                End Try
            End If
        End If
    End Sub

    ' =========================================================================
    ' 4. LIVE ORDERS & STATS
    ' =========================================================================
    Public Sub LoadOrdersAndStats()
        If Not DbConnect() Then Return
        Try
            Dim dt As New DataTable()
            Dim da As New OleDbDataAdapter("SELECT OrderID, TableNumber, CustomerName, WaiterName, OrderStatus, OrderTime, EstWaitMinutes, TotalAmount FROM tblOrders ORDER BY OrderID DESC", cn)
            da.Fill(dt)
            dgvAllOrders.DataSource = dt

            If dgvAllOrders.Columns.Contains("OrderID") Then dgvAllOrders.Columns("OrderID").HeaderText = "Order #"
            If dgvAllOrders.Columns.Contains("TableNumber") Then dgvAllOrders.Columns("TableNumber").HeaderText = "Table #"
            If dgvAllOrders.Columns.Contains("CustomerName") Then dgvAllOrders.Columns("CustomerName").HeaderText = "Customer"
            If dgvAllOrders.Columns.Contains("WaiterName") Then dgvAllOrders.Columns("WaiterName").HeaderText = "Assigned Waiter"
            If dgvAllOrders.Columns.Contains("OrderStatus") Then dgvAllOrders.Columns("OrderStatus").HeaderText = "Kitchen / Food Status"
            If dgvAllOrders.Columns.Contains("OrderTime") Then dgvAllOrders.Columns("OrderTime").HeaderText = "Order Placed At"
            If dgvAllOrders.Columns.Contains("EstWaitMinutes") Then dgvAllOrders.Columns("EstWaitMinutes").HeaderText = "Total Wait (Min)"
            If dgvAllOrders.Columns.Contains("TotalAmount") Then
                dgvAllOrders.Columns("TotalAmount").HeaderText = "Bill Total"
                dgvAllOrders.Columns("TotalAmount").DefaultCellStyle.Format = "c"
            End If

            ' Compute Revenue & Active Count
            Dim totalRevenue As Double = 0
            Dim activeCount As Integer = 0

            For Each row As DataRow In dt.Rows
                Dim status As String = row("OrderStatus").ToString()
                Dim amount As Double = Convert.ToDouble(row("TotalAmount"))
                totalRevenue += amount

                If status = "Preparing in Kitchen" OrElse status = "Pending" OrElse status = "Order Placed" OrElse status = "Ready to Serve" Then
                    activeCount += 1
                End If
            Next

            lblTotalSalesValue.Text = totalRevenue.ToString("c")
            lblActiveOrdersValue.Text = activeCount.ToString()

        Catch ex As Exception
            MessageBox.Show("Error loading orders: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DbClose()
        End Try
    End Sub

    Private Sub btnRefreshOrders_Click(sender As Object, e As EventArgs) Handles btnRefreshOrders.Click
        LoadOrdersAndStats()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        LogOut()
        Me.Close()
    End Sub

End Class
