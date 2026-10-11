Imports System.Data.OleDb

Public Class frmOwnerDashboard
    Private SelectedMenuItemID As Integer = -1
    Private SelectedStaffID As Integer = -1

    Private Sub frmOwnerDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Spice Garden - Owner Management Control Panel"
        lblTitle.Text = "Spice Garden - Owner Management Control Panel"
        lblOwnerInfo.Text = "Logged In: " & CurrentUserFullName & " | Spice Garden, London"
        LoadTables()
        LoadAllStaff()
        LoadMenu()
        LoadOrdersAndStats()
        LoadCustomers()
        LoadSignupQueue()
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
            lblSelectedTableInfo.Text = "Selected: Table #" & tNum & " | Status: " & status & " | Waiter: " & waiterName
            cboTableStatus.SelectedItem = status
        Catch
        End Try
    End Sub

    Private Sub btnAssignWaiter_Click(sender As Object, e As EventArgs) Handles btnAssignWaiter.Click
        If dgvTables.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a table first.", "Select Table", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                MessageBox.Show("Status updated to '" & newStatus & "'!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadTables()
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                DbClose()
            End Try
        End If
    End Sub

    ' Owner can add a new table to increase restaurant capacity
    Private Sub btnAddTable_Click(sender As Object, e As EventArgs) Handles btnAddTable.Click
        Dim capStr As String = InputBox("Enter seating capacity for the new table:", "Add New Table", "4")
        If String.IsNullOrEmpty(capStr) Then Return
        Dim cap As Integer = 4
        If Not Integer.TryParse(capStr, cap) OrElse cap < 1 Then
            MessageBox.Show("Invalid capacity.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If DbConnect() Then
            Try
                Dim maxCmd As New OleDbCommand("SELECT MAX(TableNumber) FROM tblTables", cn)
                Dim maxObj As Object = maxCmd.ExecuteScalar()
                Dim nextNum As Integer = If(IsDBNull(maxObj), 1, Convert.ToInt32(maxObj) + 1)
                Dim insCmd As New OleDbCommand("INSERT INTO tblTables (TableNumber, Capacity, TableStatus, AssignedWaiterID, AssignedWaiterName) VALUES (@num, @cap, @stat, @wid, @wname)", cn)
                insCmd.Parameters.AddWithValue("@num", nextNum)
                insCmd.Parameters.AddWithValue("@cap", cap)
                insCmd.Parameters.AddWithValue("@stat", "Free")
                insCmd.Parameters.AddWithValue("@wid", 0)
                insCmd.Parameters.AddWithValue("@wname", "Unassigned")
                insCmd.ExecuteNonQuery()
                MessageBox.Show("Table #" & nextNum & " with " & cap & " seats added!", "Table Added", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadTables()
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                DbClose()
            End Try
        End If
    End Sub

    ' Owner can remove a table
    Private Sub btnDeleteTable_Click(sender As Object, e As EventArgs) Handles btnDeleteTable.Click
        If dgvTables.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a table to remove.", "Select Table", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Dim tableID As Integer = Convert.ToInt32(dgvTables.SelectedRows(0).Cells("TableID").Value)
        Dim tableNum As Integer = Convert.ToInt32(dgvTables.SelectedRows(0).Cells("TableNumber").Value)
        If MessageBox.Show("Remove Table #" & tableNum & " from the layout?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            If DbConnect() Then
                Try
                    Dim delCmd As New OleDbCommand("DELETE FROM tblTables WHERE TableID = @tid", cn)
                    delCmd.Parameters.AddWithValue("@tid", tableID)
                    delCmd.ExecuteNonQuery()
                    MessageBox.Show("Table #" & tableNum & " removed.", "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadTables()
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    DbClose()
                End Try
            End If
        End If
    End Sub

    ' =========================================================================
    ' 2. ALL STAFF MANAGEMENT
    ' =========================================================================
    Public Sub LoadAllStaff()
        If Not DbConnect() Then Return
        Try
            Dim dt As New DataTable()
            Dim da As New OleDbDataAdapter("SELECT StaffID, UserName, FullName, Role, Phone, Salary, WorkHoursPerWeek, Shift, IsApproved FROM tblStaff ORDER BY AccessLevel ASC, FullName ASC", cn)
            da.Fill(dt)
            dgvWaiters.DataSource = dt

            If dgvWaiters.Columns.Contains("StaffID") Then dgvWaiters.Columns("StaffID").Visible = False
            If dgvWaiters.Columns.Contains("UserName") Then dgvWaiters.Columns("UserName").HeaderText = "Username"
            If dgvWaiters.Columns.Contains("FullName") Then dgvWaiters.Columns("FullName").HeaderText = "Full Name"
            If dgvWaiters.Columns.Contains("Role") Then dgvWaiters.Columns("Role").HeaderText = "Role"
            If dgvWaiters.Columns.Contains("Phone") Then dgvWaiters.Columns("Phone").HeaderText = "Phone"
            If dgvWaiters.Columns.Contains("Salary") Then
                dgvWaiters.Columns("Salary").HeaderText = "Salary (£)"
                dgvWaiters.Columns("Salary").DefaultCellStyle.Format = "£#,##0.00"
            End If
            If dgvWaiters.Columns.Contains("WorkHoursPerWeek") Then dgvWaiters.Columns("WorkHoursPerWeek").HeaderText = "Hrs/Week"
            If dgvWaiters.Columns.Contains("Shift") Then dgvWaiters.Columns("Shift").HeaderText = "Shift"
            If dgvWaiters.Columns.Contains("IsApproved") Then dgvWaiters.Columns("IsApproved").HeaderText = "Approved"
        Catch ex As Exception
            MessageBox.Show("Error loading staff: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DbClose()
        End Try
    End Sub

    Public Sub LoadWaiters()
        LoadAllStaff()
    End Sub

    Private Sub dgvWaiters_SelectionChanged(sender As Object, e As EventArgs) Handles dgvWaiters.SelectionChanged
        If dgvWaiters.SelectedRows.Count = 0 Then
            SelectedStaffID = -1
            Return
        End If
        Try
            SelectedStaffID = Convert.ToInt32(dgvWaiters.SelectedRows(0).Cells("StaffID").Value)
        Catch
        End Try
    End Sub

    Private Sub btnAddNewWaiter_Click(sender As Object, e As EventArgs) Handles btnAddNewWaiter.Click
        Dim addForm As New frmStaffEdit()
        If addForm.ShowDialog() = DialogResult.OK Then
            LoadAllStaff()
            LoadTables()
        End If
    End Sub

    Private Sub btnEditStaff_Click(sender As Object, e As EventArgs) Handles btnEditStaff.Click
        If SelectedStaffID <= 0 Then
            MessageBox.Show("Please select a staff member to edit.", "Select Staff", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Dim editForm As New frmStaffEdit()
        editForm.LoadStaffForEdit(SelectedStaffID)
        If editForm.ShowDialog() = DialogResult.OK Then
            LoadAllStaff()
        End If
    End Sub

    Private Sub btnDeleteWaiter_Click(sender As Object, e As EventArgs) Handles btnDeleteWaiter.Click
        If dgvWaiters.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a staff member to remove.", "Select Staff", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Dim staffID As Integer = Convert.ToInt32(dgvWaiters.SelectedRows(0).Cells("StaffID").Value)
        Dim staffName As String = dgvWaiters.SelectedRows(0).Cells("FullName").Value.ToString()
        Dim staffUser As String = dgvWaiters.SelectedRows(0).Cells("UserName").Value.ToString()
        If staffUser.ToLower() = "owner" OrElse staffUser.ToLower() = "admin" Then
            MessageBox.Show("The owner and admin accounts cannot be deleted.", "Protected Account", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If MessageBox.Show("Remove '" & staffName & "' from the staff roster?", "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            If DbConnect() Then
                Try
                    Dim unassignCmd As New OleDbCommand("UPDATE tblTables SET AssignedWaiterID = 0, AssignedWaiterName = 'Unassigned' WHERE AssignedWaiterID = @wid", cn)
                    unassignCmd.Parameters.AddWithValue("@wid", staffID)
                    unassignCmd.ExecuteNonQuery()
                    Dim delCmd As New OleDbCommand("DELETE FROM tblStaff WHERE StaffID = @sid", cn)
                    delCmd.Parameters.AddWithValue("@sid", staffID)
                    delCmd.ExecuteNonQuery()
                    MessageBox.Show("Staff member removed.", "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadAllStaff()
                    LoadTables()
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    DbClose()
                End Try
            End If
        End If
    End Sub

    Private Sub btnRefreshWaiters_Click(sender As Object, e As EventArgs) Handles btnRefreshWaiters.Click
        LoadAllStaff()
    End Sub

    ' =========================================================================
    ' 3. STAFF SIGNUP APPROVAL QUEUE
    ' =========================================================================
    Public Sub LoadSignupQueue()
        If Not DbConnect() Then Return
        Try
            Dim dt As New DataTable()
            Dim da As New OleDbDataAdapter("SELECT SignupID, FullName, UserName, Role, Phone, Email, AppliedOn, Status, Notes FROM tblStaffSignup ORDER BY AppliedOn DESC", cn)
            da.Fill(dt)
            Try
                dgvSignupQueue.DataSource = dt
                If dgvSignupQueue.Columns.Contains("SignupID") Then dgvSignupQueue.Columns("SignupID").Visible = False
                If dgvSignupQueue.Columns.Contains("FullName") Then dgvSignupQueue.Columns("FullName").HeaderText = "Full Name"
                If dgvSignupQueue.Columns.Contains("UserName") Then dgvSignupQueue.Columns("UserName").HeaderText = "Username"
                If dgvSignupQueue.Columns.Contains("Role") Then dgvSignupQueue.Columns("Role").HeaderText = "Role Applied"
                If dgvSignupQueue.Columns.Contains("Phone") Then dgvSignupQueue.Columns("Phone").HeaderText = "Phone"
                If dgvSignupQueue.Columns.Contains("Email") Then dgvSignupQueue.Columns("Email").HeaderText = "Email"
                If dgvSignupQueue.Columns.Contains("AppliedOn") Then dgvSignupQueue.Columns("AppliedOn").HeaderText = "Applied On"
                If dgvSignupQueue.Columns.Contains("Status") Then dgvSignupQueue.Columns("Status").HeaderText = "Status"
                If dgvSignupQueue.Columns.Contains("Notes") Then dgvSignupQueue.Columns("Notes").HeaderText = "Notes"
                Dim pendingCount As Integer = 0
                For Each row As DataRow In dt.Rows
                    If row("Status").ToString() = "Pending" Then pendingCount += 1
                Next
                lblPendingCount.Text = If(pendingCount > 0, pendingCount & " Application(s) Awaiting Approval", "No pending applications.")
                lblPendingCount.ForeColor = If(pendingCount > 0, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkGreen)
            Catch
            End Try
        Catch ex As Exception
        Finally
            DbClose()
        End Try
    End Sub

    Private Sub btnApproveSignup_Click(sender As Object, e As EventArgs) Handles btnApproveSignup.Click
        If dgvSignupQueue.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a staff application to approve.", "Select Application", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Dim signupID As Integer = Convert.ToInt32(dgvSignupQueue.SelectedRows(0).Cells("SignupID").Value)
        Dim fullName As String = dgvSignupQueue.SelectedRows(0).Cells("FullName").Value.ToString()
        Dim userName As String = dgvSignupQueue.SelectedRows(0).Cells("UserName").Value.ToString()
        Dim role As String = dgvSignupQueue.SelectedRows(0).Cells("Role").Value.ToString()
        Dim phone As String = dgvSignupQueue.SelectedRows(0).Cells("Phone").Value.ToString()
        Dim status As String = dgvSignupQueue.SelectedRows(0).Cells("Status").Value.ToString()
        If status <> "Pending" Then
            MessageBox.Show("This application has already been processed (Status: " & status & ").", "Already Processed", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Dim salStr As String = InputBox("Enter starting annual salary (£) for " & fullName & ":", "Set Salary", "24000")
        If String.IsNullOrEmpty(salStr) Then Return
        Dim salary As Double = 24000
        If Not Double.TryParse(salStr, salary) OrElse salary < 0 Then salary = 24000
        Dim hoursStr As String = InputBox("Enter weekly work hours for " & fullName & ":", "Set Work Hours", "40")
        Dim workHours As Integer = 40
        If Not Integer.TryParse(hoursStr, workHours) OrElse workHours < 1 Then workHours = 40
        Dim shiftResult As String = InputBox("Shift for " & fullName & " (Morning / Evening / Night / Flexible):", "Set Shift", "Morning")
        If String.IsNullOrEmpty(shiftResult) Then shiftResult = "Morning"
        If DbConnect() Then
            Try
                Dim checkCmd As New OleDbCommand("SELECT COUNT(*) FROM tblStaff WHERE LCase(UserName) = @un", cn)
                checkCmd.Parameters.AddWithValue("@un", userName.ToLower())
                If Convert.ToInt32(checkCmd.ExecuteScalar()) > 0 Then
                    MessageBox.Show("Username '" & userName & "' already exists in the staff table.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
                Dim pwCmd As New OleDbCommand("SELECT UnPassword FROM tblStaffSignup WHERE SignupID = @id", cn)
                pwCmd.Parameters.AddWithValue("@id", signupID)
                Dim encPw As String = Convert.ToString(pwCmd.ExecuteScalar())
                Dim insCmd As New OleDbCommand("INSERT INTO tblStaff (UserName, UnPassword, AccessLevel, FullName, Role, Phone, Salary, WorkHoursPerWeek, Shift, IsApproved, JoinDate) VALUES (@un, @pw, @acc, @fn, @ro, @ph, @sal, @wh, @sh, 1, @jd)", cn)
                insCmd.Parameters.AddWithValue("@un", userName)
                insCmd.Parameters.AddWithValue("@pw", encPw)
                insCmd.Parameters.AddWithValue("@acc", 2)
                insCmd.Parameters.AddWithValue("@fn", fullName)
                insCmd.Parameters.AddWithValue("@ro", role)
                insCmd.Parameters.AddWithValue("@ph", phone)
                insCmd.Parameters.AddWithValue("@sal", CDec(salary))
                insCmd.Parameters.AddWithValue("@wh", workHours)
                insCmd.Parameters.AddWithValue("@sh", shiftResult)
                insCmd.Parameters.AddWithValue("@jd", DateTime.Now)
                insCmd.ExecuteNonQuery()
                Dim updCmd As New OleDbCommand("UPDATE tblStaffSignup SET Status = 'Approved' WHERE SignupID = @id", cn)
                updCmd.Parameters.AddWithValue("@id", signupID)
                updCmd.ExecuteNonQuery()
                MessageBox.Show("Application approved!" & vbCrLf & fullName & " (" & userName & ") has been added to the staff roster." & vbCrLf &
                                "Role: " & role & " | Salary: £" & salary.ToString("N0") & " | Hours: " & workHours & "/wk | Shift: " & shiftResult,
                                "Staff Approved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadSignupQueue()
                LoadAllStaff()
                LoadTables()
            Catch ex As Exception
                MessageBox.Show("Error approving: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                DbClose()
            End Try
        End If
    End Sub

    Private Sub btnRejectSignup_Click(sender As Object, e As EventArgs) Handles btnRejectSignup.Click
        If dgvSignupQueue.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an application to reject.", "Select Application", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Dim signupID As Integer = Convert.ToInt32(dgvSignupQueue.SelectedRows(0).Cells("SignupID").Value)
        Dim fullName As String = dgvSignupQueue.SelectedRows(0).Cells("FullName").Value.ToString()
        If dgvSignupQueue.SelectedRows(0).Cells("Status").Value.ToString() <> "Pending" Then
            MessageBox.Show("This application has already been processed.", "Already Processed", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If MessageBox.Show("Reject the application from '" & fullName & "'?", "Confirm Rejection", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            If DbConnect() Then
                Try
                    Dim updCmd As New OleDbCommand("UPDATE tblStaffSignup SET Status = 'Rejected' WHERE SignupID = @id", cn)
                    updCmd.Parameters.AddWithValue("@id", signupID)
                    updCmd.ExecuteNonQuery()
                    MessageBox.Show("Application rejected.", "Rejected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadSignupQueue()
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    DbClose()
                End Try
            End If
        End If
    End Sub

    Private Sub btnRefreshSignups_Click(sender As Object, e As EventArgs) Handles btnRefreshSignups.Click
        LoadSignupQueue()
    End Sub

    ' =========================================================================
    ' 4. MENU CATALOG & INGREDIENTS MANAGEMENT
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
            If dgvMenu.Columns.Contains("Price") Then
                dgvMenu.Columns("Price").HeaderText = "Price (£)"
                dgvMenu.Columns("Price").DefaultCellStyle.Format = "£#,##0.00"
            End If
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
            txtItemName.Focus() : Return
        End If
        If Not Double.TryParse(txtPrice.Text.Trim(), priceVal) OrElse priceVal <= 0 Then
            MessageBox.Show("Please enter a valid price in Pounds (£).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPrice.Focus() : Return
        End If
        If Not Integer.TryParse(txtPrepTime.Text.Trim(), prepMinsVal) OrElse prepMinsVal <= 0 Then
            MessageBox.Show("Please enter a valid prep time (minutes).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPrepTime.Focus() : Return
        End If
        If DbConnect() Then
            Try
                If SelectedMenuItemID > 0 Then
                    Dim updCmd As New OleDbCommand("UPDATE tblMenuItems SET ItemName = @name, Category = @cat, Price = @pr, PrepTimeMinutes = @prep, Description = @desc, Ingredients = @ing WHERE ItemID = @id", cn)
                    updCmd.Parameters.AddWithValue("@name", itemName)
                    updCmd.Parameters.AddWithValue("@cat", category)
                    updCmd.Parameters.AddWithValue("@pr", CDec(priceVal))
                    updCmd.Parameters.AddWithValue("@prep", prepMinsVal)
                    updCmd.Parameters.AddWithValue("@desc", desc)
                    updCmd.Parameters.AddWithValue("@ing", ingredients)
                    updCmd.Parameters.AddWithValue("@id", SelectedMenuItemID)
                    updCmd.ExecuteNonQuery()
                    MessageBox.Show("Dish updated!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Dim insCmd As New OleDbCommand("INSERT INTO tblMenuItems (ItemName, Category, Price, PrepTimeMinutes, Description, Ingredients, Recipe) VALUES (@name, @cat, @pr, @prep, @desc, @ing, @rec)", cn)
                    insCmd.Parameters.AddWithValue("@name", itemName)
                    insCmd.Parameters.AddWithValue("@cat", category)
                    insCmd.Parameters.AddWithValue("@pr", CDec(priceVal))
                    insCmd.Parameters.AddWithValue("@prep", prepMinsVal)
                    insCmd.Parameters.AddWithValue("@desc", desc)
                    insCmd.Parameters.AddWithValue("@ing", ingredients)
                    insCmd.Parameters.AddWithValue("@rec", "")
                    insCmd.ExecuteNonQuery()
                    MessageBox.Show("Dish '" & itemName & "' added!", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                btnClearMenuFields_Click(Nothing, Nothing)
                LoadMenu()
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                DbClose()
            End Try
        End If
    End Sub

    Private Sub btnDeleteItem_Click(sender As Object, e As EventArgs) Handles btnDeleteItem.Click
        If dgvMenu.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a menu item.", "Select Item", MessageBoxButtons.OK, MessageBoxIcon.Information) : Return
        End If
        Dim itemID As Integer = Convert.ToInt32(dgvMenu.SelectedRows(0).Cells("ItemID").Value)
        Dim itemName As String = dgvMenu.SelectedRows(0).Cells("ItemName").Value.ToString()
        If MessageBox.Show("Remove '" & itemName & "' from the menu?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            If DbConnect() Then
                Try
                    Dim cmd As New OleDbCommand("DELETE FROM tblMenuItems WHERE ItemID = @id", cn)
                    cmd.Parameters.AddWithValue("@id", itemID)
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Item removed.", "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    btnClearMenuFields_Click(Nothing, Nothing)
                    LoadMenu()
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub dgvMenu_SelectionChanged(sender As Object, e As EventArgs) Handles dgvMenu.SelectionChanged
        If dgvMenu.SelectedRows.Count = 0 Then Return
        Try
            Dim row As DataGridViewRow = dgvMenu.SelectedRows(0)
            SelectedMenuItemID = Convert.ToInt32(row.Cells("ItemID").Value)
            txtItemName.Text = If(row.Cells("ItemName").Value IsNot Nothing, row.Cells("ItemName").Value.ToString(), "")
            txtPrice.Text = Convert.ToDouble(row.Cells("Price").Value).ToString("F2")
            txtPrepTime.Text = If(row.Cells("PrepTimeMinutes").Value IsNot Nothing, row.Cells("PrepTimeMinutes").Value.ToString(), "")
            txtItemDescription.Text = If(row.Cells("Description").Value IsNot Nothing, row.Cells("Description").Value.ToString(), "")
            Dim ingVal As String = ""
            If dgvMenu.Columns.Contains("Ingredients") AndAlso row.Cells("Ingredients").Value IsNot Nothing Then ingVal = row.Cells("Ingredients").Value.ToString()
            txtIngredients.Text = ingVal
            Dim catVal As String = If(row.Cells("Category").Value IsNot Nothing, row.Cells("Category").Value.ToString(), "")
            If cboCategory.Items.Contains(catVal) Then cboCategory.SelectedItem = catVal
            btnAddMenuItem.Text = "Update Dish (#" & SelectedMenuItemID & ")"
        Catch
        End Try
    End Sub

    ' =========================================================================
    ' 5. LIVE ORDERS & STATS
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
            If dgvAllOrders.Columns.Contains("TotalAmount") Then
                dgvAllOrders.Columns("TotalAmount").HeaderText = "Bill (£)"
                dgvAllOrders.Columns("TotalAmount").DefaultCellStyle.Format = "£#,##0.00"
            End If
            Dim totalRevenue As Double = 0
            Dim activeCount As Integer = 0
            For Each row As DataRow In dt.Rows
                totalRevenue += Convert.ToDouble(row("TotalAmount"))
                Dim s As String = row("OrderStatus").ToString()
                If s = "Preparing in Kitchen" OrElse s = "Pending" OrElse s = "Ready to Serve" Then activeCount += 1
            Next
            lblTotalSalesValue.Text = FormatCurrency(totalRevenue)
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
    ' 6. CUSTOMER MANAGEMENT
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
            If dgvCustomers.Columns.Contains("TotalSpent") Then
                dgvCustomers.Columns("TotalSpent").HeaderText = "Total Spent (£)"
                dgvCustomers.Columns("TotalSpent").DefaultCellStyle.Format = "£#,##0.00"
            End If
            If dgvCustomers.Columns.Contains("Notes") Then dgvCustomers.Columns("Notes").HeaderText = "Preferences / Notes"
        Catch
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
        Dim custCity As String = If(String.IsNullOrEmpty(txtCustCity.Text.Trim()), "London", txtCustCity.Text.Trim())
        Dim custNotes As String = txtCustNotes.Text.Trim()
        If String.IsNullOrEmpty(custName) Then
            MessageBox.Show("Please enter the customer's name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCustName.Focus() : Return
        End If
        If DbConnect() Then
            Try
                Dim checkCmd As New OleDbCommand("SELECT CustomerID FROM tblCustomers WHERE CustomerName = @nm AND (Phone = @ph OR @ph = '')", cn)
                checkCmd.Parameters.AddWithValue("@nm", custName)
                checkCmd.Parameters.AddWithValue("@ph", custPhone)
                Dim res As Object = checkCmd.ExecuteScalar()
                If res IsNot Nothing Then
                    Dim updCmd As New OleDbCommand("UPDATE tblCustomers SET CustomerName = @nm, Phone = @ph, Email = @em, City = @ci, Notes = @nt WHERE CustomerID = @id", cn)
                    updCmd.Parameters.AddWithValue("@nm", custName)
                    updCmd.Parameters.AddWithValue("@ph", custPhone)
                    updCmd.Parameters.AddWithValue("@em", custEmail)
                    updCmd.Parameters.AddWithValue("@ci", custCity)
                    updCmd.Parameters.AddWithValue("@nt", custNotes)
                    updCmd.Parameters.AddWithValue("@id", Convert.ToInt32(res))
                    updCmd.ExecuteNonQuery()
                    MessageBox.Show("Customer updated!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
                    MessageBox.Show("Customer added!", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                LoadCustomers()
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                DbClose()
            End Try
        End If
    End Sub

    Private Sub btnDeleteCustomer_Click(sender As Object, e As EventArgs) Handles btnDeleteCustomer.Click
        If dgvCustomers.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a customer.", "Select Customer", MessageBoxButtons.OK, MessageBoxIcon.Information) : Return
        End If
        Dim custID As Integer = Convert.ToInt32(dgvCustomers.SelectedRows(0).Cells("CustomerID").Value)
        Dim custName As String = dgvCustomers.SelectedRows(0).Cells("CustomerName").Value.ToString()
        If MessageBox.Show("Remove customer '" & custName & "'?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            If DbConnect() Then
                Try
                    Dim delCmd As New OleDbCommand("DELETE FROM tblCustomers WHERE CustomerID = @id", cn)
                    delCmd.Parameters.AddWithValue("@id", custID)
                    delCmd.ExecuteNonQuery()
                    MessageBox.Show("Customer removed.", "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtCustName.Text = "" : txtCustPhone.Text = "" : txtCustEmail.Text = "" : txtCustCity.Text = "London" : txtCustNotes.Text = ""
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
