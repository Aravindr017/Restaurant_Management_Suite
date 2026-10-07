Imports System.Data.OleDb

Public Class frmOwnerDashboard
    Private SelectedMenuItemID As Integer = -1

    Private Sub frmOwnerDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Spice Garden - Owner Management Control Panel"
        lblTitle.Text = "Spice Garden - Owner Management Control Panel"
        lblOwnerInfo.Text = "Logged In: " & CurrentUserFullName & " | Spice Garden, Chennai"
        LoadTables()
        LoadWaiters()
        LoadMenu()
        LoadOrdersAndStats()
        LoadCustomers()
    End Sub

    ' =========================================================================
    ' 1. TABLE & WAITER ASSIGNMENT MANAGEMENT
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
            If dgvTables.Columns.Contains("Capacity") Then dgvTables.Columns("Capacity").HeaderText = "Seating Capacity"
            If dgvTables.Columns.Contains("TableStatus") Then dgvTables.Columns("TableStatus").HeaderText = "Status"
            If dgvTables.Columns.Contains("AssignedWaiterName") Then dgvTables.Columns("AssignedWaiterName").HeaderText = "Assigned Waiter"

            ' Populate Assign Waiter combobox
            Dim waiterDt As New DataTable()
            Dim wDa As New OleDbDataAdapter("SELECT StaffID, FullName FROM tblStaff WHERE AccessLevel = 2 ORDER BY FullName", cn)
            wDa.Fill(waiterDt)
            cboWaitersForAssign.DataSource = waiterDt
            cboWaitersForAssign.DisplayMember = "FullName"
            cboWaitersForAssign.ValueMember = "StaffID"

        Catch ex As Exception
            MessageBox.Show("Error loading tables: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DbClose()
        End Try
    End Sub

    Private Sub dgvTables_SelectionChanged(sender As Object, e As EventArgs) Handles dgvTables.SelectionChanged
        If dgvTables.SelectedRows.Count = 0 Then Return
        Try
            Dim row As DataGridViewRow = dgvTables.SelectedRows(0)
            Dim tNum As String = row.Cells("TableNumber").Value.ToString()
            Dim status As String = row.Cells("TableStatus").Value.ToString()
            Dim waiterName As String = If(IsDBNull(row.Cells("AssignedWaiterName").Value), "None", row.Cells("AssignedWaiterName").Value.ToString())

            lblSelectedTableInfo.Text = "Selected: Table #" & tNum & " | Current Status: " & status & " | Assigned: " & waiterName
            cboTableStatus.SelectedItem = status
        Catch
        End Try
    End Sub

    Private Sub btnAssignWaiter_Click(sender As Object, e As EventArgs) Handles btnAssignWaiter.Click
        If dgvTables.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a table from the list above.", "Select Table", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If cboWaitersForAssign.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a waiter to assign.", "Select Waiter", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim tableID As Integer = Convert.ToInt32(dgvTables.SelectedRows(0).Cells("TableID").Value)
        Dim tableNum As Integer = Convert.ToInt32(dgvTables.SelectedRows(0).Cells("TableNumber").Value)
        Dim waiterID As Integer = Convert.ToInt32(cboWaitersForAssign.SelectedValue)
        Dim waiterName As String = cboWaitersForAssign.Text

        If DbConnect() Then
            Try
                Dim cmd As New OleDbCommand("UPDATE tblTables SET AssignedWaiterID = @wid, AssignedWaiterName = @wname WHERE TableID = @tid", cn)
                cmd.Parameters.AddWithValue("@wid", waiterID)
                cmd.Parameters.AddWithValue("@wname", waiterName)
                cmd.Parameters.AddWithValue("@tid", tableID)
                cmd.ExecuteNonQuery()

                MessageBox.Show("Assigned " & waiterName & " to Table #" & tableNum & "!", "Assignment Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadTables()
            Catch ex As Exception
                MessageBox.Show("Error updating table: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                DbClose()
            End Try
        End If
    End Sub

    Private Sub btnUpdateTableStatus_Click(sender As Object, e As EventArgs) Handles btnUpdateTableStatus.Click
        If dgvTables.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a table first.", "Select Table", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim tableID As Integer = Convert.ToInt32(dgvTables.SelectedRows(0).Cells("TableID").Value)
        Dim newStatus As String = If(cboTableStatus.SelectedItem IsNot Nothing, cboTableStatus.SelectedItem.ToString(), "")
        If String.IsNullOrEmpty(newStatus) Then Return

        If DbConnect() Then
            Try
                Dim cmd As New OleDbCommand("UPDATE tblTables SET TableStatus = @st WHERE TableID = @tid", cn)
                cmd.Parameters.AddWithValue("@st", newStatus)
                cmd.Parameters.AddWithValue("@tid", tableID)
                cmd.ExecuteNonQuery()

                MessageBox.Show("Table status updated to '" & newStatus & "'!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadTables()
            Catch ex As Exception
                MessageBox.Show("Error updating status: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                DbClose()
            End Try
        End If
    End Sub

    ' =========================================================================
    ' 2. WAITER / STAFF MANAGEMENT
    ' =========================================================================
    Public Sub LoadWaiters()
        If Not DbConnect() Then Return
        Try
            Dim dt As New DataTable()
            Dim da As New OleDbDataAdapter("SELECT StaffID, UserName, FullName, Role, Phone, Salary FROM tblStaff WHERE AccessLevel = 2 ORDER BY FullName", cn)
            da.Fill(dt)
            dgvWaiters.DataSource = dt

            If dgvWaiters.Columns.Contains("StaffID") Then dgvWaiters.Columns("StaffID").Visible = False
            If dgvWaiters.Columns.Contains("UserName") Then dgvWaiters.Columns("UserName").HeaderText = "Login Username"
            If dgvWaiters.Columns.Contains("FullName") Then dgvWaiters.Columns("FullName").HeaderText = "Full Name"
            If dgvWaiters.Columns.Contains("Role") Then dgvWaiters.Columns("Role").HeaderText = "Role"
            If dgvWaiters.Columns.Contains("Phone") Then dgvWaiters.Columns("Phone").HeaderText = "Phone Number"
            If dgvWaiters.Columns.Contains("Salary") Then
                dgvWaiters.Columns("Salary").HeaderText = "Salary (Rs.)"
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading wait staff: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DbClose()
        End Try
    End Sub

    Private Sub btnAddNewWaiter_Click(sender As Object, e As EventArgs) Handles btnAddNewWaiter.Click
        Dim addForm As New frmStaffEdit()
        If addForm.ShowDialog() = DialogResult.OK Then
            LoadWaiters()
            LoadTables()
        End If
    End Sub

    Private Sub btnDeleteWaiter_Click(sender As Object, e As EventArgs) Handles btnDeleteWaiter.Click
        If dgvWaiters.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a waiter to delete.", "Select Waiter", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim staffID As Integer = Convert.ToInt32(dgvWaiters.SelectedRows(0).Cells("StaffID").Value)
        Dim staffName As String = dgvWaiters.SelectedRows(0).Cells("FullName").Value.ToString()

        If MessageBox.Show("Remove '" & staffName & "' from the wait staff roster?", "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            If DbConnect() Then
                Try
                    ' Clear table assignments for this waiter
                    Dim unassignCmd As New OleDbCommand("UPDATE tblTables SET AssignedWaiterID = 0, AssignedWaiterName = 'Unassigned' WHERE AssignedWaiterID = @wid", cn)
                    unassignCmd.Parameters.AddWithValue("@wid", staffID)
                    unassignCmd.ExecuteNonQuery()

                    ' Delete staff record
                    Dim delCmd As New OleDbCommand("DELETE FROM tblStaff WHERE StaffID = @sid", cn)
                    delCmd.Parameters.AddWithValue("@sid", staffID)
                    delCmd.ExecuteNonQuery()

                    MessageBox.Show("Staff member removed.", "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadWaiters()
                    LoadTables()
                Catch ex As Exception
                    MessageBox.Show("Error removing waiter: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
    ' 3. MENU CATALOG & INGREDIENTS MANAGEMENT
    ' =========================================================================
    Public Sub LoadMenu()
        If Not DbConnect() Then Return
        Try
            Dim dt As New DataTable()
            Dim da As New OleDbDataAdapter("SELECT ItemID, ItemName, Category, Price, PrepTimeMinutes, Description, Ingredients, Recipe FROM tblMenuItems ORDER BY Category, ItemName", cn)
            da.Fill(dt)
            dgvMenu.DataSource = dt

            If dgvMenu.Columns.Contains("ItemID") Then dgvMenu.Columns("ItemID").Visible = False
            If dgvMenu.Columns.Contains("Recipe") Then dgvMenu.Columns("Recipe").Visible = False
            If dgvMenu.Columns.Contains("ItemName") Then dgvMenu.Columns("ItemName").HeaderText = "Dish / Item Name"
            If dgvMenu.Columns.Contains("Category") Then dgvMenu.Columns("Category").HeaderText = "Category"
            If dgvMenu.Columns.Contains("Price") Then dgvMenu.Columns("Price").HeaderText = "Price (Rs.)"
            If dgvMenu.Columns.Contains("PrepTimeMinutes") Then dgvMenu.Columns("PrepTimeMinutes").HeaderText = "Prep (Min)"
            If dgvMenu.Columns.Contains("Description") Then dgvMenu.Columns("Description").HeaderText = "Description"
            If dgvMenu.Columns.Contains("Ingredients") Then dgvMenu.Columns("Ingredients").HeaderText = "Ingredients"
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
        Dim ingredients As String = txtIngredients.Text.Trim()
        Dim priceVal As Double
        Dim prepMinsVal As Integer

        If String.IsNullOrEmpty(itemName) Then
            MessageBox.Show("Please enter the dish name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtItemName.Focus()
            Return
        End If
        If Not Double.TryParse(txtPrice.Text.Trim(), priceVal) OrElse priceVal <= 0 Then
            MessageBox.Show("Please enter a valid price in Rupees.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPrice.Focus()
            Return
        End If
        If Not Integer.TryParse(txtPrepTime.Text.Trim(), prepMinsVal) OrElse prepMinsVal <= 0 Then
            MessageBox.Show("Please enter a valid preparation time (in minutes).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPrepTime.Focus()
            Return
        End If

        If DbConnect() Then
            Try
                If SelectedMenuItemID > 0 Then
                    ' Update existing menu item
                    Dim updCmd As New OleDbCommand("UPDATE tblMenuItems SET ItemName = @name, Category = @cat, Price = @pr, PrepTimeMinutes = @prep, Description = @desc, Ingredients = @ing WHERE ItemID = @id", cn)
                    updCmd.Parameters.AddWithValue("@name", itemName)
                    updCmd.Parameters.AddWithValue("@cat", category)
                    updCmd.Parameters.AddWithValue("@pr", priceVal)
                    updCmd.Parameters.AddWithValue("@prep", prepMinsVal)
                    updCmd.Parameters.AddWithValue("@desc", desc)
                    updCmd.Parameters.AddWithValue("@ing", ingredients)
                    updCmd.Parameters.AddWithValue("@id", SelectedMenuItemID)
                    updCmd.ExecuteNonQuery()

                    MessageBox.Show("Dish '" & itemName & "' updated successfully!", "Menu Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    ' Insert brand new menu item
                    Dim insCmd As New OleDbCommand("INSERT INTO tblMenuItems (ItemName, Category, Price, PrepTimeMinutes, Description, Ingredients, Recipe) VALUES (@name, @cat, @pr, @prep, @desc, @ing, @rec)", cn)
                    insCmd.Parameters.AddWithValue("@name", itemName)
                    insCmd.Parameters.AddWithValue("@cat", category)
                    insCmd.Parameters.AddWithValue("@pr", priceVal)
                    insCmd.Parameters.AddWithValue("@prep", prepMinsVal)
                    insCmd.Parameters.AddWithValue("@desc", desc)
                    insCmd.Parameters.AddWithValue("@ing", ingredients)
                    insCmd.Parameters.AddWithValue("@rec", "")
                    insCmd.ExecuteNonQuery()

                    MessageBox.Show("Dish '" & itemName & "' added to menu!", "Menu Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                btnClearMenuFields_Click(Nothing, Nothing)
                LoadMenu()
            Catch ex As Exception
                MessageBox.Show("Error saving menu item: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                DbClose()
            End Try
        End If
    End Sub

    Private Sub btnDeleteItem_Click(sender As Object, e As EventArgs) Handles btnDeleteItem.Click
        If dgvMenu.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a menu item to delete.", "Select Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim itemID As Integer = Convert.ToInt32(dgvMenu.SelectedRows(0).Cells("ItemID").Value)
        Dim itemName As String = dgvMenu.SelectedRows(0).Cells("ItemName").Value.ToString()

        If MessageBox.Show("Remove '" & itemName & "' from the menu?", "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            If DbConnect() Then
                Try
                    Dim cmd As New OleDbCommand("DELETE FROM tblMenuItems WHERE ItemID = @id", cn)
                    cmd.Parameters.AddWithValue("@id", itemID)
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Item removed from menu.", "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    btnClearMenuFields_Click(Nothing, Nothing)
                    LoadMenu()
                Catch ex As Exception
                    MessageBox.Show("Error removing item: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    DbClose()
                End Try
            End If
        End If
    End Sub

    Private Sub btnClearMenuFields_Click(sender As Object, e As EventArgs) Handles btnClearMenuFields.Click
        SelectedMenuItemID = -1
        txtItemName.Text = ""
        txtPrice.Text = ""
        txtPrepTime.Text = ""
        txtItemDescription.Text = ""
        txtIngredients.Text = ""
        If cboCategory.Items.Count > 0 Then cboCategory.SelectedIndex = 0
        btnAddMenuItem.Text = "Save / Add to Menu"
        dgvMenu.ClearSelection()
    End Sub

    ''' <summary>
    ''' When an existing menu row is selected, load its data into the edit fields for updating
    ''' </summary>
    Private Sub dgvMenu_SelectionChanged(sender As Object, e As EventArgs) Handles dgvMenu.SelectionChanged
        If dgvMenu.SelectedRows.Count = 0 Then Return
        Try
            Dim row As DataGridViewRow = dgvMenu.SelectedRows(0)
            SelectedMenuItemID = Convert.ToInt32(row.Cells("ItemID").Value)
            txtItemName.Text = If(row.Cells("ItemName").Value IsNot Nothing, row.Cells("ItemName").Value.ToString(), "")
            txtPrice.Text = Convert.ToDouble(row.Cells("Price").Value).ToString("N0")
            txtPrepTime.Text = If(row.Cells("PrepTimeMinutes").Value IsNot Nothing, row.Cells("PrepTimeMinutes").Value.ToString(), "")
            txtItemDescription.Text = If(row.Cells("Description").Value IsNot Nothing, row.Cells("Description").Value.ToString(), "")
            Dim ingVal As String = ""
            If dgvMenu.Columns.Contains("Ingredients") AndAlso row.Cells("Ingredients").Value IsNot Nothing Then
                ingVal = row.Cells("Ingredients").Value.ToString()
            End If
            txtIngredients.Text = ingVal
            Dim catVal As String = If(row.Cells("Category").Value IsNot Nothing, row.Cells("Category").Value.ToString(), "")
            If cboCategory.Items.Contains(catVal) Then
                cboCategory.SelectedItem = catVal
            End If
            btnAddMenuItem.Text = "Update Dish (#" & SelectedMenuItemID & ")"
        Catch
        End Try
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
            If dgvAllOrders.Columns.Contains("TableNumber") Then dgvAllOrders.Columns("TableNumber").HeaderText = "Table"
            If dgvAllOrders.Columns.Contains("CustomerName") Then dgvAllOrders.Columns("CustomerName").HeaderText = "Customer"
            If dgvAllOrders.Columns.Contains("WaiterName") Then dgvAllOrders.Columns("WaiterName").HeaderText = "Assigned Waiter"
            If dgvAllOrders.Columns.Contains("OrderStatus") Then dgvAllOrders.Columns("OrderStatus").HeaderText = "Kitchen Status"
            If dgvAllOrders.Columns.Contains("OrderTime") Then dgvAllOrders.Columns("OrderTime").HeaderText = "Order Time"
            If dgvAllOrders.Columns.Contains("EstWaitMinutes") Then dgvAllOrders.Columns("EstWaitMinutes").HeaderText = "Wait (Min)"
            If dgvAllOrders.Columns.Contains("TotalAmount") Then dgvAllOrders.Columns("TotalAmount").HeaderText = "Bill (Rs.)"

            Dim totalRevenue As Double = 0
            Dim activeCount As Integer = 0
            For Each row As DataRow In dt.Rows
                Dim status As String = row("OrderStatus").ToString()
                Dim amount As Double = Convert.ToDouble(row("TotalAmount"))
                totalRevenue += amount
                If status = "Preparing in Kitchen" OrElse status = "Pending" OrElse status = "Ready to Serve" Then activeCount += 1
            Next

            lblTotalSalesValue.Text = "Rs." & totalRevenue.ToString("N0")
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

    ' =========================================================================
    ' 5. CUSTOMER MANAGEMENT
    ' =========================================================================
    Public Sub LoadCustomers()
        If Not DbConnect() Then Return
        Try
            Dim dt As New DataTable()
            Dim da As New OleDbDataAdapter("SELECT CustomerID, CustomerName, Phone, Email, City, VisitCount, TotalSpent, Notes FROM tblCustomers ORDER BY TotalSpent DESC", cn)
            da.Fill(dt)
            dgvCustomers.DataSource = dt

            If dgvCustomers.Columns.Contains("CustomerID") Then dgvCustomers.Columns("CustomerID").Visible = False
            If dgvCustomers.Columns.Contains("CustomerName") Then dgvCustomers.Columns("CustomerName").HeaderText = "Customer Name"
            If dgvCustomers.Columns.Contains("Phone") Then dgvCustomers.Columns("Phone").HeaderText = "Phone"
            If dgvCustomers.Columns.Contains("Email") Then dgvCustomers.Columns("Email").HeaderText = "Email"
            If dgvCustomers.Columns.Contains("City") Then dgvCustomers.Columns("City").HeaderText = "City"
            If dgvCustomers.Columns.Contains("VisitCount") Then dgvCustomers.Columns("VisitCount").HeaderText = "Visits"
            If dgvCustomers.Columns.Contains("TotalSpent") Then dgvCustomers.Columns("TotalSpent").HeaderText = "Total Spent (Rs.)"
            If dgvCustomers.Columns.Contains("Notes") Then dgvCustomers.Columns("Notes").HeaderText = "Preferences / Notes"
        Catch ex As Exception
        Finally
            DbClose()
        End Try
    End Sub

    Private Sub dgvCustomers_SelectionChanged(sender As Object, e As EventArgs) Handles dgvCustomers.SelectionChanged
        If dgvCustomers.SelectedRows.Count = 0 Then Return
        Try
            Dim row As DataGridViewRow = dgvCustomers.SelectedRows(0)
            txtCustName.Text = If(row.Cells("CustomerName").Value IsNot Nothing, row.Cells("CustomerName").Value.ToString(), "")
            txtCustPhone.Text = If(row.Cells("Phone").Value IsNot Nothing, row.Cells("Phone").Value.ToString(), "")
            txtCustEmail.Text = If(row.Cells("Email").Value IsNot Nothing, row.Cells("Email").Value.ToString(), "")
            txtCustCity.Text = If(row.Cells("City").Value IsNot Nothing, row.Cells("City").Value.ToString(), "")
            txtCustNotes.Text = If(row.Cells("Notes").Value IsNot Nothing, row.Cells("Notes").Value.ToString(), "")
        Catch
        End Try
    End Sub

    Private Sub btnAddCustomer_Click(sender As Object, e As EventArgs) Handles btnAddCustomer.Click
        Dim custName As String = txtCustName.Text.Trim()
        Dim custPhone As String = txtCustPhone.Text.Trim()
        Dim custEmail As String = txtCustEmail.Text.Trim()
        Dim custCity As String = If(String.IsNullOrEmpty(txtCustCity.Text.Trim()), "Chennai", txtCustCity.Text.Trim())
        Dim custNotes As String = txtCustNotes.Text.Trim()

        If String.IsNullOrEmpty(custName) Then
            MessageBox.Show("Please enter the customer's name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCustName.Focus()
            Return
        End If

        If DbConnect() Then
            Try
                ' Check if exists to update or insert
                Dim checkCmd As New OleDbCommand("SELECT CustomerID FROM tblCustomers WHERE CustomerName = @nm AND (Phone = @ph OR @ph = '')", cn)
                checkCmd.Parameters.AddWithValue("@nm", custName)
                checkCmd.Parameters.AddWithValue("@ph", custPhone)
                Dim res As Object = checkCmd.ExecuteScalar()

                If res IsNot Nothing Then
                    Dim existingId As Integer = Convert.ToInt32(res)
                    Dim updCmd As New OleDbCommand("UPDATE tblCustomers SET CustomerName = @nm, Phone = @ph, Email = @em, City = @ci, Notes = @nt WHERE CustomerID = @id", cn)
                    updCmd.Parameters.AddWithValue("@nm", custName)
                    updCmd.Parameters.AddWithValue("@ph", custPhone)
                    updCmd.Parameters.AddWithValue("@em", custEmail)
                    updCmd.Parameters.AddWithValue("@ci", custCity)
                    updCmd.Parameters.AddWithValue("@nt", custNotes)
                    updCmd.Parameters.AddWithValue("@id", existingId)
                    updCmd.ExecuteNonQuery()
                    MessageBox.Show("Customer '" & custName & "' profile updated successfully!", "Customer Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Dim insCmd As New OleDbCommand("INSERT INTO tblCustomers (CustomerName, Phone, Email, Address, City, VisitCount, TotalSpent, RegisteredOn, Notes) VALUES (@nm, @ph, @em, @ad, @ci, 1, 0, @ro, @nt)", cn)
                    insCmd.Parameters.AddWithValue("@nm", custName)
                    insCmd.Parameters.AddWithValue("@ph", custPhone)
                    insCmd.Parameters.AddWithValue("@em", custEmail)
                    insCmd.Parameters.AddWithValue("@ad", "")
                    insCmd.Parameters.AddWithValue("@ci", custCity)
                    insCmd.Parameters.AddWithValue("@ro", DateTime.Now)
                    insCmd.Parameters.AddWithValue("@nt", custNotes)
                    insCmd.ExecuteNonQuery()
                    MessageBox.Show("Customer '" & custName & "' added to the registry!", "Customer Added", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                LoadCustomers()
            Catch ex As Exception
                MessageBox.Show("Error saving customer: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                DbClose()
            End Try
        End If
    End Sub

    Private Sub btnDeleteCustomer_Click(sender As Object, e As EventArgs) Handles btnDeleteCustomer.Click
        If dgvCustomers.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a customer to remove.", "Select Customer", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Dim custID As Integer = Convert.ToInt32(dgvCustomers.SelectedRows(0).Cells("CustomerID").Value)
        Dim custName As String = dgvCustomers.SelectedRows(0).Cells("CustomerName").Value.ToString()
        If MessageBox.Show("Remove customer '" & custName & "' from the registry?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            If DbConnect() Then
                Try
                    Dim delCmd As New OleDbCommand("DELETE FROM tblCustomers WHERE CustomerID = @id", cn)
                    delCmd.Parameters.AddWithValue("@id", custID)
                    delCmd.ExecuteNonQuery()
                    MessageBox.Show("Customer removed.", "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtCustName.Text = ""
                    txtCustPhone.Text = ""
                    txtCustEmail.Text = ""
                    txtCustCity.Text = "Chennai"
                    txtCustNotes.Text = ""
                    LoadCustomers()
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    DbClose()
                End Try
            End If
        End If
    End Sub

    Private Sub btnRefreshCustomers_Click(sender As Object, e As EventArgs) Handles btnRefreshCustomers.Click
        LoadCustomers()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        LogOut()
        Me.Close()
    End Sub

End Class
