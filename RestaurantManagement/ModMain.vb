Imports System.Data.OleDb
Imports System.IO
Imports System.Text
Imports System.Windows.Forms

Module ModMain
    ' Database Path with dynamic location support (checks current directory and bin\Debug)
    Private DatabaseFileName As String = "RestaurantDB.mdb"
    Public cn As OleDbConnection
    Private ActiveConnectionString As String = ""

    ' Global User Session State
    Public LogedIn As Boolean = False
    Public CurrentUserID As Integer = -1
    Public CurrentUserName As String = ""
    Public CurrentUserFullName As String = ""
    Public CurrentUserRole As String = "" ' "Owner", "Waiter", "Customer"
    Public UserAccessLevel As Integer = 99 ' 1: Owner, 2: Waiter, 99: Customer/Guest
    Public SelectedTableNumber As Integer = 1
    Public ActiveCustomerName As String = "Guest Table"

    ''' <summary>
    ''' Resolves the full path to the RestaurantDB.mdb file
    ''' </summary>
    Private Function GetDatabaseFullPath() As String
        Dim appDir As String = Application.StartupPath
        Dim directPath As String = Path.Combine(appDir, DatabaseFileName)
        If File.Exists(directPath) Then
            Return directPath
        End If

        ' Check parent directories if running from bin\Debug
        Dim parentDir As String = Directory.GetParent(appDir)?.FullName
        If parentDir IsNot Nothing Then
            Dim parentPath As String = Path.Combine(parentDir, DatabaseFileName)
            If File.Exists(parentPath) Then Return parentPath

            Dim grandParentDir As String = Directory.GetParent(parentDir)?.FullName
            If grandParentDir IsNot Nothing Then
                Dim grandParentPath As String = Path.Combine(grandParentDir, DatabaseFileName)
                If File.Exists(grandParentPath) Then Return grandParentPath
            End If
        End If

        Return directPath
    End Function

    ''' <summary>
    ''' Connects to the Microsoft Access database using Jet 4.0 or ACE OLEDB fallback
    ''' </summary>
    Public Function DbConnect() As Boolean
        Try
            If cn IsNot Nothing AndAlso cn.State = ConnectionState.Open Then
                Return True
            End If

            Dim dbFile As String = GetDatabaseFullPath()

            ' Attempt Jet 4.0 (32-bit standard) first, then ACE 12.0 (64-bit compatible)
            Dim jetConnStr As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & dbFile & "';Persist Security Info=False;"
            Dim aceConnStr As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & dbFile & "';Persist Security Info=False;"

            Try
                cn = New OleDbConnection(jetConnStr)
                cn.Open()
                ActiveConnectionString = jetConnStr
                Return True
            Catch exJet As Exception
                Try
                    cn = New OleDbConnection(aceConnStr)
                    cn.Open()
                    ActiveConnectionString = aceConnStr
                    Return True
                Catch exAce As Exception
                    MessageBox.Show("Unable to open Restaurant database: " & vbCrLf & exAce.Message & vbCrLf &
                                    "Checked path: " & dbFile, "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Try
        Catch ex As Exception
            MessageBox.Show("Database connection error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Closes the active database connection safely
    ''' </summary>
    Public Sub DbClose()
        Try
            If cn IsNot Nothing AndAlso cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        Catch
        End Try
    End Sub

    ''' <summary>
    ''' Initializes database tables (tblStaff, tblTables, tblMenuItems, tblOrders, tblOrderItems)
    ''' and seeds default data on first run.
    ''' </summary>
    Public Sub InitializeDatabase()
        If Not DbConnect() Then Return

        Try
            ' 1. tblStaff Table
            ExecuteDdlSafe("CREATE TABLE tblStaff (" &
                           "StaffID AUTOINCREMENT PRIMARY KEY, " &
                           "UserName TEXT(50), " &
                           "UnPassword TEXT(100), " &
                           "AccessLevel INTEGER, " &
                           "FullName TEXT(100), " &
                           "Role TEXT(50), " &
                           "Phone TEXT(50), " &
                           "Salary CURRENCY)")

            ' 2. tblTables Table
            ExecuteDdlSafe("CREATE TABLE tblTables (" &
                           "TableID AUTOINCREMENT PRIMARY KEY, " &
                           "TableNumber INTEGER, " &
                           "Capacity INTEGER, " &
                           "TableStatus TEXT(30), " &
                           "AssignedWaiterID INTEGER, " &
                           "AssignedWaiterName TEXT(100))")

            ' 3. tblMenuItems Table
            ExecuteDdlSafe("CREATE TABLE tblMenuItems (" &
                           "ItemID AUTOINCREMENT PRIMARY KEY, " &
                           "ItemName TEXT(100), " &
                           "Category TEXT(50), " &
                           "Price CURRENCY, " &
                           "PrepTimeMinutes INTEGER, " &
                           "Description TEXT(255))")

            ' 4. tblOrders Table
            ExecuteDdlSafe("CREATE TABLE tblOrders (" &
                           "OrderID AUTOINCREMENT PRIMARY KEY, " &
                           "TableNumber INTEGER, " &
                           "CustomerName TEXT(100), " &
                           "WaiterID INTEGER, " &
                           "WaiterName TEXT(100), " &
                           "OrderStatus TEXT(30), " &
                           "OrderTime DATETIME, " &
                           "EstWaitMinutes INTEGER, " &
                           "TotalAmount CURRENCY, " &
                           "Notes TEXT(255))")

            ' 5. tblOrderItems Table
            ExecuteDdlSafe("CREATE TABLE tblOrderItems (" &
                           "DetailID AUTOINCREMENT PRIMARY KEY, " &
                           "OrderID INTEGER, " &
                           "ItemID INTEGER, " &
                           "ItemName TEXT(100), " &
                           "Quantity INTEGER, " &
                           "UnitPrice CURRENCY, " &
                           "SubTotal CURRENCY, " &
                           "ItemStatus TEXT(30))")

            ' Seed default data if tblStaff is empty
            Dim checkCmd As New OleDbCommand("SELECT COUNT(*) FROM tblStaff", cn)
            Dim staffCount As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

            If staffCount = 0 Then
                SeedDefaultData()
            End If

        Catch ex As Exception
            ' Silent continue if tables exist
        Finally
            DbClose()
        End Try
    End Sub

    Private Sub ExecuteDdlSafe(sql As String)
        Try
            Dim cmd As New OleDbCommand(sql, cn)
            cmd.ExecuteNonQuery()
        Catch
            ' Already exists or schema already set
        End Try
    End Sub

    ''' <summary>
    ''' Populates the database with default owner, waiters, tables, and menu items
    ''' </summary>
    Private Sub SeedDefaultData()
        Try
            ' Default Staff (Owner & Waiters)
            ' owner: admin123 -> Encrypted
            ' waiter1, waiter2, waiter3: waiter123 -> Encrypted
            Dim encOwnerPw As String = Encrypt("admin123")
            Dim encWaiterPw As String = Encrypt("waiter123")

            Dim insStaffSql As String = "INSERT INTO tblStaff (UserName, UnPassword, AccessLevel, FullName, Role, Phone, Salary) VALUES (@un, @pw, @acc, @fn, @ro, @ph, @sal)"

            InsertStaffRecord("owner", encOwnerPw, 1, "Marco Bellini (Owner)", "Owner", "555-0100", 65000)
            InsertStaffRecord("waiter1", encWaiterPw, 2, "John Smith", "Waiter", "555-0101", 28000)
            InsertStaffRecord("waiter2", encWaiterPw, 2, "Emily Davis", "Waiter", "555-0102", 28000)
            InsertStaffRecord("waiter3", encWaiterPw, 2, "Carlos Mendez", "Waiter", "555-0103", 28000)

            ' Default Tables (Tables 1 - 6)
            InsertTableRecord(1, 2, "Occupied", 2, "John Smith")
            InsertTableRecord(2, 4, "Occupied", 2, "John Smith")
            InsertTableRecord(3, 4, "Free", 3, "Emily Davis")
            InsertTableRecord(4, 6, "Free", 3, "Emily Davis")
            InsertTableRecord(5, 2, "Free", 4, "Carlos Mendez")
            InsertTableRecord(6, 8, "Reserved", 4, "Carlos Mendez")

            ' Default Menu Items with realistic prep times and pricing
            InsertMenuItem("Garlic Butter Herb Bread", "Starters", 6.5, 8, "Warm artisan baguette with roasted garlic and fresh parsley butter")
            InsertMenuItem("Crispy Salt & Pepper Calamari", "Starters", 12.0, 12, "Tender calamari with lime aioli and sea salt")
            InsertMenuItem("Classic Bruschetta Pomodoro", "Starters", 8.5, 10, "Grilled ciabatta topped with heirloom tomatoes, basil, and balsamic glaze")
            InsertMenuItem("Caprese Salad Skewers", "Starters", 9.0, 7, "Cherry tomatoes, fresh mozzarella, basil, and extra virgin olive oil")

            InsertMenuItem("Grilled Prime Ribeye Steak (10oz)", "Mains", 28.5, 22, "Cooked to preference, served with truffle butter and mashed potatoes")
            InsertMenuItem("Fettuccine Chicken Alfredo", "Mains", 18.0, 15, "Handcrafted pasta in creamy parmesan garlic alfredo sauce with chicken")
            InsertMenuItem("Pan-Seared Atlantic Salmon", "Mains", 24.0, 18, "Crisp skin fillet served over wild asparagus and lemon beurre blanc")
            InsertMenuItem("Wood-Fired Margherita Pizza", "Mains", 15.0, 14, "San Marzano tomatoes, fresh mozzarella fior di latte, and basil leaves")
            InsertMenuItem("BBQ Bacon Angus Smash Burger", "Mains", 16.5, 15, "Double beef patties, smoked bacon, aged cheddar, and house fries")

            InsertMenuItem("Traditional Italian Tiramisu", "Desserts", 9.0, 5, "Espresso soaked savoiardi layers with mascarpone and cocoa powder")
            InsertMenuItem("Warm Molten Chocolate Lava Cake", "Desserts", 10.5, 12, "Gooey chocolate center served with Madagascar vanilla gelato")
            InsertMenuItem("Classic New York Cheesecake", "Desserts", 8.0, 5, "Creamy cheesecake served with strawberry compote")

            InsertMenuItem("Signature Berry Mojito (Mocktail)", "Beverages", 5.5, 3, "Fresh mint, blackberries, sparkling club soda, and cane sugar")
            InsertMenuItem("Handcrafted Iced Caramel Macchiato", "Beverages", 4.5, 4, "Double espresso shot, chilled whole milk, and caramel drizzle")
            InsertMenuItem("San Pellegrino Sparkling Water (750ml)", "Beverages", 3.5, 2, "Imported Italian sparkling mineral water")

            ' Sample active order to immediately demonstrate real-time status and wait time calculation
            InsertSampleOrder()

        Catch ex As Exception
            ' Ignore seeding duplicates
        End Try
    End Sub

    Private Sub InsertStaffRecord(un As String, pw As String, acc As Integer, fn As String, ro As String, ph As String, sal As Double)
        Dim cmd As New OleDbCommand("INSERT INTO tblStaff (UserName, UnPassword, AccessLevel, FullName, Role, Phone, Salary) " &
                                    "VALUES (@un, @pw, @acc, @fn, @ro, @ph, @sal)", cn)
        cmd.Parameters.AddWithValue("@un", un)
        cmd.Parameters.AddWithValue("@pw", pw)
        cmd.Parameters.AddWithValue("@acc", acc)
        cmd.Parameters.AddWithValue("@fn", fn)
        cmd.Parameters.AddWithValue("@ro", ro)
        cmd.Parameters.AddWithValue("@ph", ph)
        cmd.Parameters.AddWithValue("@sal", sal)
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub InsertTableRecord(num As Integer, cap As Integer, stat As String, wId As Integer, wName As String)
        Dim cmd As New OleDbCommand("INSERT INTO tblTables (TableNumber, Capacity, TableStatus, AssignedWaiterID, AssignedWaiterName) " &
                                    "VALUES (@num, @cap, @stat, @wid, @wname)", cn)
        cmd.Parameters.AddWithValue("@num", num)
        cmd.Parameters.AddWithValue("@cap", cap)
        cmd.Parameters.AddWithValue("@stat", stat)
        cmd.Parameters.AddWithValue("@wid", wId)
        cmd.Parameters.AddWithValue("@wname", wName)
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub InsertMenuItem(name As String, cat As String, price As Double, prepMins As Integer, desc As String)
        Dim cmd As New OleDbCommand("INSERT INTO tblMenuItems (ItemName, Category, Price, PrepTimeMinutes, Description) " &
                                    "VALUES (@name, @cat, @price, @prep, @desc)", cn)
        cmd.Parameters.AddWithValue("@name", name)
        cmd.Parameters.AddWithValue("@cat", cat)
        cmd.Parameters.AddWithValue("@price", price)
        cmd.Parameters.AddWithValue("@prep", prepMins)
        cmd.Parameters.AddWithValue("@desc", desc)
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub InsertSampleOrder()
        ' Order placed 6 minutes ago for Table 1, currently Preparing
        Dim orderTime As DateTime = DateTime.Now.AddMinutes(-6)
        Dim cmd As New OleDbCommand("INSERT INTO tblOrders (TableNumber, CustomerName, WaiterID, WaiterName, OrderStatus, OrderTime, EstWaitMinutes, TotalAmount, Notes) " &
                                    "VALUES (@tab, @cust, @wid, @wname, @stat, @otime, @wait, @tot, @notes)", cn)
        cmd.Parameters.AddWithValue("@tab", 1)
        cmd.Parameters.AddWithValue("@cust", "Guest Table 1")
        cmd.Parameters.AddWithValue("@wid", 2)
        cmd.Parameters.AddWithValue("@wname", "John Smith")
        cmd.Parameters.AddWithValue("@stat", "Preparing in Kitchen")
        cmd.Parameters.AddWithValue("@otime", orderTime)
        cmd.Parameters.AddWithValue("@wait", 18)
        cmd.Parameters.AddWithValue("@tot", 35.0)
        cmd.Parameters.AddWithValue("@notes", "Steak cooked medium-rare, no dressing on salad")
        cmd.ExecuteNonQuery()
    End Sub

    ''' <summary>
    ''' Encrypts plain text string to Base64 UTF-8 (Consistent with HolyScrap architecture)
    ''' </summary>
    Public Function Encrypt(PlainText As String) As String
        Dim CipherText As String = PlainText
        If String.IsNullOrEmpty(PlainText) Then
            Return ""
        Else
            Dim dat As Byte() = Encoding.UTF8.GetBytes(PlainText)
            CipherText = Convert.ToBase64String(dat)
        End If
        Return CipherText
    End Function

    ''' <summary>
    ''' Decrypts Base64 UTF-8 cipher text back into plain text string
    ''' </summary>
    Public Function Decrypt(CipherText As String) As String
        Dim PlainText As String = CipherText
        If String.IsNullOrEmpty(CipherText) Then
            Return ""
        Else
            Try
                Dim uData As Byte() = Convert.FromBase64String(CipherText)
                PlainText = Encoding.UTF8.GetString(uData)
            Catch
                PlainText = CipherText
            End Try
        End If
        Return PlainText
    End Function

    ''' <summary>
    ''' Resets the current login session
    ''' </summary>
    Public Sub LogOut()
        LogedIn = False
        CurrentUserID = -1
        CurrentUserName = ""
        CurrentUserFullName = ""
        CurrentUserRole = ""
        UserAccessLevel = 99
    End Sub

End Module
