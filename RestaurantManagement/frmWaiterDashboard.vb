Imports System.Data.OleDb

Public Class frmWaiterDashboard

    Private Sub frmWaiterDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Spice Garden - Waiter Service Station"
        lblWaiterName.Text = "Waiter Service Station | " & CurrentUserFullName
        LoadMyTables()
        LoadMyOrders()
    End Sub

    Public Sub LoadMyTables()
        If Not DbConnect() Then Return
        Try
            Dim dt As New DataTable()
            Dim cmd As New OleDbCommand("SELECT TableID, TableNumber, Capacity, TableStatus FROM tblTables WHERE AssignedWaiterID = @wid ORDER BY TableNumber ASC", cn)
            cmd.Parameters.AddWithValue("@wid", CurrentUserID)
            Dim da As New OleDbDataAdapter(cmd)
            da.Fill(dt)
            dgvMyTables.DataSource = dt

            If dgvMyTables.Columns.Contains("TableID") Then dgvMyTables.Columns("TableID").Visible = False
            If dgvMyTables.Columns.Contains("TableNumber") Then dgvMyTables.Columns("TableNumber").HeaderText = "Table #"
            If dgvMyTables.Columns.Contains("Capacity") Then dgvMyTables.Columns("Capacity").HeaderText = "Seats"
            If dgvMyTables.Columns.Contains("TableStatus") Then dgvMyTables.Columns("TableStatus").HeaderText = "Status"

            ' Update banner with list of assigned tables
            If dt.Rows.Count > 0 Then
                Dim tableList As New List(Of String)
                For Each r As DataRow In dt.Rows
                    tableList.Add("Table " & r("TableNumber").ToString())
                Next
                lblAssignedTables.Text = "Your Assigned Tables: " & String.Join(", ", tableList)
            Else
                lblAssignedTables.Text = "Your Assigned Tables: None assigned yet. (Owner can assign tables to you)"
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading assigned tables: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DbClose()
        End Try
    End Sub

    Public Sub LoadMyOrders()
        If Not DbConnect() Then Return
        Try
            Dim dt As New DataTable()
            Dim cmd As New OleDbCommand("SELECT OrderID, TableNumber, CustomerName, OrderStatus, OrderTime, EstWaitMinutes, TotalAmount " &
                                        "FROM tblOrders WHERE WaiterID = @wid OR TableNumber IN (SELECT TableNumber FROM tblTables WHERE AssignedWaiterID = @wid) ORDER BY OrderID DESC", cn)
            cmd.Parameters.AddWithValue("@wid", CurrentUserID)
            Dim da As New OleDbDataAdapter(cmd)
            da.Fill(dt)
            dgvOrders.DataSource = dt

            If dgvOrders.Columns.Contains("OrderID") Then dgvOrders.Columns("OrderID").HeaderText = "Order #"
            If dgvOrders.Columns.Contains("TableNumber") Then dgvOrders.Columns("TableNumber").HeaderText = "Table #"
            If dgvOrders.Columns.Contains("CustomerName") Then dgvOrders.Columns("CustomerName").HeaderText = "Guest"
            If dgvOrders.Columns.Contains("OrderStatus") Then dgvOrders.Columns("OrderStatus").HeaderText = "Live Status"
            If dgvOrders.Columns.Contains("OrderTime") Then dgvOrders.Columns("OrderTime").HeaderText = "Time Placed"
            If dgvOrders.Columns.Contains("EstWaitMinutes") Then dgvOrders.Columns("EstWaitMinutes").HeaderText = "Wait (Mins)"
            If dgvOrders.Columns.Contains("TotalAmount") Then
                dgvOrders.Columns("TotalAmount").HeaderText = "Total (£)"
                dgvOrders.Columns("TotalAmount").DefaultCellStyle.Format = "£#,##0.00"
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading orders: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DbClose()
        End Try
    End Sub

    Private Sub dgvOrders_SelectionChanged(sender As Object, e As EventArgs) Handles dgvOrders.SelectionChanged
        If dgvOrders.SelectedRows.Count > 0 Then
            Dim orderID As Integer = Convert.ToInt32(dgvOrders.SelectedRows(0).Cells("OrderID").Value)
            LoadOrderItems(orderID)
        End If
    End Sub

    Private Sub LoadOrderItems(orderID As Integer)
        If Not DbConnect() Then Return
        Try
            Dim dt As New DataTable()
            Dim cmd As New OleDbCommand("SELECT ItemName, Quantity, UnitPrice, SubTotal, ItemStatus, Customization FROM tblOrderItems WHERE OrderID = @oid", cn)
            cmd.Parameters.AddWithValue("@oid", orderID)
            Dim da As New OleDbDataAdapter(cmd)
            Try
                da.Fill(dt)
            Catch
                ' Fallback if Customization column is not present in older schema
                Dim cmd2 As New OleDbCommand("SELECT ItemName, Quantity, UnitPrice, SubTotal, ItemStatus FROM tblOrderItems WHERE OrderID = @oid", cn)
                cmd2.Parameters.AddWithValue("@oid", orderID)
                Dim da2 As New OleDbDataAdapter(cmd2)
                da2.Fill(dt)
            End Try
            dgvOrderItems.DataSource = dt

            If dgvOrderItems.Columns.Contains("ItemName") Then dgvOrderItems.Columns("ItemName").HeaderText = "Dish"
            If dgvOrderItems.Columns.Contains("Quantity") Then dgvOrderItems.Columns("Quantity").HeaderText = "Qty"
            If dgvOrderItems.Columns.Contains("UnitPrice") Then
                dgvOrderItems.Columns("UnitPrice").HeaderText = "Price (£)"
                dgvOrderItems.Columns("UnitPrice").DefaultCellStyle.Format = "£#,##0.00"
            End If
            If dgvOrderItems.Columns.Contains("SubTotal") Then
                dgvOrderItems.Columns("SubTotal").HeaderText = "Subtotal (£)"
                dgvOrderItems.Columns("SubTotal").DefaultCellStyle.Format = "£#,##0.00"
            End If
            If dgvOrderItems.Columns.Contains("ItemStatus") Then dgvOrderItems.Columns("ItemStatus").HeaderText = "Item Status"
            If dgvOrderItems.Columns.Contains("Customization") Then
                dgvOrderItems.Columns("Customization").HeaderText = "Customer Wish / Customization"
                dgvOrderItems.Columns("Customization").Width = 200
            End If
        Catch ex As Exception
            ' Ignore details error
        Finally
            DbClose()
        End Try
    End Sub

    ' =========================================================================
    ' FOOD STATUS WORKFLOW (Preparing -> Ready -> Served -> Paid)
    ' =========================================================================
    Private Sub UpdateOrderStatus(newStatus As String)
        If dgvOrders.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an order from the list.", "Select Order", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim orderID As Integer = Convert.ToInt32(dgvOrders.SelectedRows(0).Cells("OrderID").Value)
        Dim tableNumber As Integer = Convert.ToInt32(dgvOrders.SelectedRows(0).Cells("TableNumber").Value)

        If DbConnect() Then
            Try
                Dim cmd As New OleDbCommand("UPDATE tblOrders SET OrderStatus = @st WHERE OrderID = @oid", cn)
                cmd.Parameters.AddWithValue("@st", newStatus)
                cmd.Parameters.AddWithValue("@oid", orderID)
                cmd.ExecuteNonQuery()

                ' Also update order items
                Dim itemCmd As New OleDbCommand("UPDATE tblOrderItems SET ItemStatus = @st WHERE OrderID = @oid", cn)
                itemCmd.Parameters.AddWithValue("@st", newStatus)
                itemCmd.Parameters.AddWithValue("@oid", orderID)
                itemCmd.ExecuteNonQuery()

                ' If paid/completed, mark table as Free
                If newStatus = "Completed / Paid" Then
                    Dim freeCmd As New OleDbCommand("UPDATE tblTables SET TableStatus = 'Free' WHERE TableNumber = @tn", cn)
                    freeCmd.Parameters.AddWithValue("@tn", tableNumber)
                    freeCmd.ExecuteNonQuery()
                End If

                MessageBox.Show("Order #" & orderID & " for Table " & tableNumber & " is now marked as '" & newStatus & "'!",
                                "Order Status Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)

                LoadMyOrders()
                LoadMyTables()
            Catch ex As Exception
                MessageBox.Show("Error updating order status: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                DbClose()
            End Try
        End If
    End Sub

    Private Sub btnSetPreparing_Click(sender As Object, e As EventArgs) Handles btnSetPreparing.Click
        UpdateOrderStatus("Preparing in Kitchen")
    End Sub

    Private Sub btnSetReady_Click(sender As Object, e As EventArgs) Handles btnSetReady.Click
        UpdateOrderStatus("Ready to Serve")
    End Sub

    Private Sub btnSetServed_Click(sender As Object, e As EventArgs) Handles btnSetServed.Click
        UpdateOrderStatus("Served to Customer")
    End Sub

    Private Sub btnSetCompleted_Click(sender As Object, e As EventArgs) Handles btnSetCompleted.Click
        UpdateOrderStatus("Completed / Paid")
    End Sub

    Private Sub btnTakeOrder_Click(sender As Object, e As EventArgs) Handles btnTakeOrder.Click
        If dgvMyTables.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select one of your assigned tables to take an order.", "Select Table", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim tableNum As Integer = Convert.ToInt32(dgvMyTables.SelectedRows(0).Cells("TableNumber").Value)
        SelectedTableNumber = tableNum
        ActiveCustomerName = "Table " & tableNum & " (" & CurrentUserFullName & ")"

        Dim orderForm As New frmCustomerOrder()
        orderForm.ShowDialog()

        LoadMyOrders()
        LoadMyTables()
    End Sub

    Private Sub btnSetTableFree_Click(sender As Object, e As EventArgs) Handles btnSetTableFree.Click
        If dgvMyTables.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a table to mark as free.", "Select Table", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim tableNum As Integer = Convert.ToInt32(dgvMyTables.SelectedRows(0).Cells("TableNumber").Value)
        If DbConnect() Then
            Try
                Dim cmd As New OleDbCommand("UPDATE tblTables SET TableStatus = 'Free' WHERE TableNumber = @tn", cn)
                cmd.Parameters.AddWithValue("@tn", tableNum)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Table #" & tableNum & " marked as Free.", "Table Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadMyTables()
            Catch ex As Exception
                MessageBox.Show("Error updating table: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                DbClose()
            End Try
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadMyTables()
        LoadMyOrders()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        LogOut()
        Me.Close()
    End Sub

End Class
