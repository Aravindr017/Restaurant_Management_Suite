Imports System.Data.OleDb
Imports System.IO
Imports System.Text
Imports System.Windows.Forms

Module ModMain
    Private DatabaseFileName As String = "RestaurantDB.mdb"
    Public cn As OleDbConnection
    Private ActiveConnectionString As String = ""

    Public LogedIn As Boolean = False
    Public CurrentUserID As Integer = -1
    Public CurrentUserName As String = ""
    Public CurrentUserFullName As String = ""
    Public CurrentUserRole As String = ""
    Public UserAccessLevel As Integer = 99
    Public SelectedTableNumber As Integer = 1
    Public ActiveCustomerName As String = "Guest Table"

    Private Function GetDatabaseFullPath() As String
        Dim appDir As String = Application.StartupPath
        Dim directPath As String = Path.Combine(appDir, DatabaseFileName)
        If File.Exists(directPath) Then Return directPath
        Dim parentDirInfo As DirectoryInfo = Directory.GetParent(appDir)
        If parentDirInfo IsNot Nothing Then
            Dim parentDir As String = parentDirInfo.FullName
            Dim parentPath As String = Path.Combine(parentDir, DatabaseFileName)
            If File.Exists(parentPath) Then Return parentPath
            Dim grandParentDirInfo As DirectoryInfo = Directory.GetParent(parentDir)
            If grandParentDirInfo IsNot Nothing Then
                Dim grandParentDir As String = grandParentDirInfo.FullName
                Dim grandParentPath As String = Path.Combine(grandParentDir, DatabaseFileName)
                If File.Exists(grandParentPath) Then Return grandParentPath
            End If
        End If
        Return directPath
    End Function

    Public Function DbConnect() As Boolean
        Try
            If cn IsNot Nothing AndAlso cn.State = ConnectionState.Open Then Return True
            Dim dbFile As String = GetDatabaseFullPath()
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
                    MessageBox.Show("Unable to open Restaurant database: " & vbCrLf & exAce.Message & vbCrLf & "Checked path: " & dbFile, "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Try
        Catch ex As Exception
            MessageBox.Show("Database connection error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Sub DbClose()
        Try
            If cn IsNot Nothing AndAlso cn.State = ConnectionState.Open Then cn.Close()
        Catch
        End Try
    End Sub

    Public Sub InitializeDatabase()
        If Not DbConnect() Then Return
        Try
            ExecuteDdlSafe("CREATE TABLE tblStaff (StaffID AUTOINCREMENT PRIMARY KEY, UserName TEXT(50), UnPassword TEXT(100), AccessLevel INTEGER, FullName TEXT(100), Role TEXT(50), Phone TEXT(50), Salary CURRENCY)")
            ExecuteDdlSafe("CREATE TABLE tblTables (TableID AUTOINCREMENT PRIMARY KEY, TableNumber INTEGER, Capacity INTEGER, TableStatus TEXT(30), AssignedWaiterID INTEGER, AssignedWaiterName TEXT(100))")
            ExecuteDdlSafe("CREATE TABLE tblMenuItems (ItemID AUTOINCREMENT PRIMARY KEY, ItemName TEXT(100), Category TEXT(50), Price CURRENCY, PrepTimeMinutes INTEGER, Description TEXT(255), Ingredients TEXT(255), Recipe TEXT(255))")
            ExecuteDdlSafe("CREATE TABLE tblOrders (OrderID AUTOINCREMENT PRIMARY KEY, TableNumber INTEGER, CustomerName TEXT(100), WaiterID INTEGER, WaiterName TEXT(100), OrderStatus TEXT(30), OrderTime DATETIME, EstWaitMinutes INTEGER, TotalAmount CURRENCY, Notes TEXT(255))")
            ExecuteDdlSafe("CREATE TABLE tblOrderItems (DetailID AUTOINCREMENT PRIMARY KEY, OrderID INTEGER, ItemID INTEGER, ItemName TEXT(100), Quantity INTEGER, UnitPrice CURRENCY, SubTotal CURRENCY, ItemStatus TEXT(30), Customization TEXT(255))")
            ExecuteDdlSafe("CREATE TABLE tblCustomers (CustomerID AUTOINCREMENT PRIMARY KEY, CustomerName TEXT(100), Phone TEXT(50), Email TEXT(100), Address TEXT(255), City TEXT(100), VisitCount INTEGER, TotalSpent CURRENCY, RegisteredOn DATETIME, Notes TEXT(255))")

            ' Upgrade existing DB schema (safe - ignored if columns already exist)
            ExecuteDdlSafe("ALTER TABLE tblMenuItems ADD COLUMN Ingredients TEXT(255)")
            ExecuteDdlSafe("ALTER TABLE tblMenuItems ADD COLUMN Recipe TEXT(255)")
            ExecuteDdlSafe("ALTER TABLE tblOrderItems ADD COLUMN Customization TEXT(255)")

            Dim checkCmd As New OleDbCommand("SELECT COUNT(*) FROM tblStaff", cn)
            Dim staffCount As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
            If staffCount = 0 Then SeedStaffAndTables()

            ' Ensure customers table is populated with Indian sample data
            Try
                Dim custCheck As New OleDbCommand("SELECT COUNT(*) FROM tblCustomers", cn)
                Dim custCount As Integer = Convert.ToInt32(custCheck.ExecuteScalar())
                If custCount = 0 Then SeedCustomers()
            Catch
            End Try

            ' Ensure menu items with ingredients & recipes are populated
            Try
                Dim menuCheck As New OleDbCommand("SELECT COUNT(*) FROM tblMenuItems", cn)
                Dim menuCount As Integer = Convert.ToInt32(menuCheck.ExecuteScalar())
                If menuCount = 0 Then
                    SeedMenuItems()
                Else
                    SyncMenuRecipes()
                End If
            Catch
            End Try
        Catch ex As Exception
        Finally
            DbClose()
        End Try
    End Sub

    Private Sub ExecuteDdlSafe(sql As String)
        Try
            Dim cmd As New OleDbCommand(sql, cn)
            cmd.ExecuteNonQuery()
        Catch
        End Try
    End Sub

    Private Sub SeedStaffAndTables()
        Try
            Dim encOwnerPw As String = Encrypt("admin123")
            Dim encWaiterPw As String = Encrypt("waiter123")

            InsertStaffRecord("owner", encOwnerPw, 1, "Ramesh Agarwal (Owner)", "Owner", "+91-98765-43210", 120000)
            InsertStaffRecord("waiter1", encWaiterPw, 2, "Suresh Kumar", "Waiter", "+91-98111-22334", 18000)
            InsertStaffRecord("waiter2", encWaiterPw, 2, "Priya Nair", "Waiter", "+91-97222-33445", 18000)
            InsertStaffRecord("waiter3", encWaiterPw, 2, "Arjun Singh", "Waiter", "+91-96333-44556", 18000)

            Dim w1 As Integer = GetStaffIDByUsername("waiter1")
            Dim w2 As Integer = GetStaffIDByUsername("waiter2")
            Dim w3 As Integer = GetStaffIDByUsername("waiter3")

            InsertTableRecord(1, 2, "Occupied", w1, "Suresh Kumar")
            InsertTableRecord(2, 4, "Occupied", w1, "Suresh Kumar")
            InsertTableRecord(3, 4, "Free", w2, "Priya Nair")
            InsertTableRecord(4, 6, "Free", w2, "Priya Nair")
            InsertTableRecord(5, 2, "Free", w3, "Arjun Singh")
            InsertTableRecord(6, 8, "Reserved", w3, "Arjun Singh")

            InsertSampleOrder()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SeedMenuItems()
        Try
            ' STARTERS
            InsertMenuItem("Veg Samosa (2 pcs)", "Starters", 60, 10, "Crispy golden pastry stuffed with spiced potato and peas, served with mint chutney", "Potato, Green Peas, Flour, Cumin, Coriander, Ginger, Chilli, Oil", "Deep-fry stuffed pastry until golden brown; serve with chutney")
            InsertMenuItem("Paneer Tikka", "Starters", 220, 18, "Cubes of fresh cottage cheese marinated in tandoor spices and charcoal-grilled", "Paneer, Yoghurt, Ginger-Garlic Paste, Tandoori Masala, Bell Peppers, Onion, Lemon", "Marinate paneer overnight; skewer and grill in tandoor at high heat")
            InsertMenuItem("Onion Bhaji", "Starters", 90, 8, "Crispy chickpea-battered onion fritters with green chilli and coriander", "Onion, Besan (Chickpea Flour), Green Chilli, Coriander, Turmeric, Chaat Masala", "Mix batter, fold in onion slices, deep-fry until crisp")
            InsertMenuItem("Chicken Seekh Kebab", "Starters", 280, 20, "Minced spiced chicken moulded on skewers and grilled in tandoor oven", "Minced Chicken, Onion, Green Chilli, Ginger, Garlic, Garam Masala, Coriander", "Mix spiced mince, wrap on skewers, grill in tandoor 12-15 minutes")
            InsertMenuItem("Aloo Tikki Chaat", "Starters", 110, 12, "Spiced mashed potato patties topped with yoghurt, tamarind, and sev", "Potato, Chickpeas, Yoghurt, Tamarind Chutney, Mint Chutney, Sev, Chaat Masala", "Pan-fry potato patties; assemble with toppings just before serving")

            ' MAINS
            InsertMenuItem("Butter Chicken (Murgh Makhani)", "Mains", 340, 22, "Tender chicken in a rich tomato-butter-cream sauce", "Chicken, Tomato Puree, Butter, Cream, Onion, Ginger-Garlic, Kashmiri Chilli, Kasoori Methi", "Marinate and grill chicken; simmer in makhani gravy; finish with cream")
            InsertMenuItem("Dal Makhani", "Mains", 240, 25, "Black lentils slow-cooked overnight with butter, cream, and secret spices", "Black Urad Dal, Kidney Beans, Butter, Cream, Tomato, Onion, Garam Masala", "Soak dal overnight; pressure cook; simmer for 4 hours with butter")
            InsertMenuItem("Palak Paneer", "Mains", 260, 18, "Fresh cottage cheese in a velvety spinach and spice gravy", "Paneer, Spinach, Onion, Tomato, Cream, Ginger-Garlic, Cumin, Garam Masala", "Blanch and puree spinach; cook with spices; add paneer cubes")
            InsertMenuItem("Lamb Rogan Josh", "Mains", 390, 30, "Tender slow-braised lamb in a bold Kashmiri spice and yoghurt gravy", "Lamb, Yoghurt, Kashmiri Chilli, Fennel, Ginger, Garlic, Cloves, Cardamom", "Brown lamb; add whole spices; slow braise in yoghurt sauce 45 min")
            InsertMenuItem("Chicken Biryani", "Mains", 360, 28, "Aromatic basmati rice slow-cooked with marinated chicken (Dum style)", "Basmati Rice, Chicken, Onion, Saffron, Mint, Yoghurt, Biryani Masala, Ghee", "Layer marinated chicken with par-cooked rice; seal and dum cook 25 min")
            InsertMenuItem("Chole Bhature", "Mains", 180, 20, "Tangy chickpea curry served with fluffy deep-fried bread", "Chickpeas, Tomato, Onion, Ginger, Garlic, Chole Masala, Amchur, Bhature Dough", "Pressure cook chickpeas in spicy gravy; serve with fresh hot bhature")
            InsertMenuItem("Fish Masala Curry", "Mains", 380, 22, "Coastal spiced fish curry in tangy coconut-tamarind masala", "Fresh Fish, Coconut Milk, Tamarind, Tomato, Onion, Mustard, Curry Leaves, Kokum", "Fry fish in spiced paste; simmer in coconut-tamarind gravy 15 min")
            InsertMenuItem("Veg Thali", "Mains", 220, 20, "Complete Indian meal: 2 curries, dal, rice, roti, raita, pickle, papad", "Seasonal Vegetables, Dal, Basmati Rice, Wheat Flour, Yoghurt, Pickle", "Prepare all components fresh; assemble on stainless steel thali plate")

            ' BREADS
            InsertMenuItem("Garlic Naan", "Breads", 60, 8, "Soft leavened bread topped with garlic butter and coriander, baked in tandoor", "Maida, Yeast, Yoghurt, Milk, Garlic, Butter, Coriander", "Ferment dough; top with garlic butter; bake in tandoor 4-5 minutes")
            InsertMenuItem("Laccha Paratha", "Breads", 55, 10, "Multi-layered flaky whole wheat bread, cooked on a cast-iron tawa with ghee", "Whole Wheat Flour, Ghee, Water, Salt", "Roll layered dough; cook on tawa with ghee until golden flaky layers form")
            InsertMenuItem("Puri (3 pcs)", "Breads", 50, 6, "Small puffed deep-fried bread, served with bhaji or curry", "Wheat Flour, Salt, Oil", "Knead stiff dough; roll small rounds; deep-fry until golden and puffed")

            ' RICE
            InsertMenuItem("Steamed Basmati Rice", "Rice", 90, 12, "Aged long-grain basmati rice, perfectly steamed and fragrant", "Basmati Rice, Water, Salt", "Wash and soak rice; boil with salt; drain and steam finish")
            InsertMenuItem("Jeera Rice", "Rice", 120, 15, "Fragrant cumin-tempered basmati rice cooked with whole spices", "Basmati Rice, Cumin Seeds, Ghee, Bay Leaf, Cloves, Salt", "Temper cumin in ghee; add rice; cook in spiced water until fluffy")

            ' DESSERTS
            InsertMenuItem("Gulab Jamun (2 pcs)", "Desserts", 90, 5, "Soft milk-solid dumplings soaked in rose and cardamom sugar syrup", "Khoya, Maida, Milk, Sugar, Rose Water, Cardamom, Saffron", "Shape khoya dough balls; deep-fry on low heat; soak in warm syrup")
            InsertMenuItem("Rasmalai (2 pcs)", "Desserts", 110, 8, "Soft chenna dumplings floating in chilled saffron-cardamom milk", "Chenna, Sugar, Milk, Saffron, Cardamom, Pistachios, Rose Water", "Cook chenna discs in syrup; simmer in reduced saffron milk; chill")
            InsertMenuItem("Kheer (Rice Pudding)", "Desserts", 100, 15, "Creamy slow-cooked rice pudding with saffron, cardamom, and dry fruits", "Basmati Rice, Full Cream Milk, Sugar, Saffron, Cardamom, Cashews, Almonds", "Simmer rice in milk on low heat 30 min until thick; add sugar and dry fruits")
            InsertMenuItem("Kulfi Falooda", "Desserts", 130, 5, "Traditional Indian ice cream with rose syrup, basil seeds, and vermicelli", "Kulfi (Cream, Sugar, Cardamom, Pistachio), Rose Syrup, Basil Seeds, Falooda Sev", "Unmould kulfi; assemble with soaked basil seeds, falooda, rose syrup")

            ' BEVERAGES
            InsertMenuItem("Masala Chai", "Beverages", 40, 5, "Spiced Indian milk tea with ginger, cardamom, and cinnamon", "Tea Leaves, Milk, Ginger, Cardamom, Cinnamon, Sugar", "Boil spices in water; add tea leaves; add milk; strain and serve hot")
            InsertMenuItem("Mango Lassi", "Beverages", 90, 4, "Thick chilled yoghurt drink blended with Alphonso mango pulp", "Fresh Yoghurt, Alphonso Mango Pulp, Sugar, Cardamom, Saffron, Ice", "Blend yoghurt, mango pulp and spices; serve chilled with ice")
            InsertMenuItem("Fresh Lime Soda", "Beverages", 60, 3, "Refreshing fresh lime juice with soda water - sweet, salty or both", "Fresh Lime, Soda Water, Sugar Syrup, Black Salt, Ice", "Squeeze fresh lime; mix with soda; add sweetener or salt as preferred")
            InsertMenuItem("Rooh Afza Sharbat", "Beverages", 70, 3, "Chilled rose water sherbet drink with basil seeds and chilled milk", "Rooh Afza Syrup, Chilled Milk, Basil Seeds (Sabja), Ice", "Mix Rooh Afza with chilled milk; add soaked basil seeds; serve over ice")
            InsertMenuItem("Fresh Coconut Water", "Beverages", 80, 2, "Tender green coconut served fresh with straw - naturally refreshing", "Green Coconut", "Select fresh tender coconut; serve with straw; scoop malai on request")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SeedCustomers()
        Try
            InsertCustomerRecord("Ananya Krishnan", "+91-94440-11223", "ananya.k@gmail.com", "12, Anna Nagar, 3rd Street", "Chennai", 5, 2400, "Regular - prefers less spicy; vegetarian")
            InsertCustomerRecord("Vikram Rajan", "+91-98849-55667", "vikram.rajan@outlook.com", "45, T Nagar, Panagal Park Road", "Chennai", 3, 1800, "Likes Chicken Biryani; family of 4")
            InsertCustomerRecord("Deepa Subramaniam", "+91-99400-33445", "deepa.sub@yahoo.co.in", "8, Adyar Main Road", "Chennai", 8, 5600, "VIP; allergy to nuts; prefers window table")
            InsertCustomerRecord("Karthik Murugan", "+91-87540-22113", "", "67, Velachery Main Road", "Chennai", 2, 950, "Jain food required (no onion/garlic)")
            InsertCustomerRecord("Meenakshi Pillai", "+91-96005-78901", "meenakshi.p@hotmail.com", "23, Besant Nagar, ECR Road", "Chennai", 12, 8200, "Loyal customer since 2019; birthday in March")
            InsertCustomerRecord("Rohan Mehta", "+91-91760-44332", "rohan.mehta@gmail.com", "102, Nungambakkam High Road", "Chennai", 1, 450, "New customer; visited once; online booking")
            InsertCustomerRecord("Lakshmi Venkataraman", "+91-98410-56789", "", "34, Mylapore, R K Mutt Road", "Chennai", 6, 3700, "Prefers vegetarian; loves Rasmalai; Table 3")
            InsertCustomerRecord("Sanjay Iyer", "+91-94444-87654", "sanjay.iyer@corporate.in", "56, Guindy Industrial Estate", "Chennai", 4, 6800, "Corporate client; books Table 6 for team lunches")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SyncMenuRecipes()
        Try
            UpdateItemRecipeIfEmpty("Butter Chicken (Murgh Makhani)", "Chicken, Tomato Puree, Butter, Cream, Onion, Ginger-Garlic, Kashmiri Chilli, Kasoori Methi", "Marinate and grill chicken; simmer in makhani gravy; finish with cream")
            UpdateItemRecipeIfEmpty("Dal Makhani", "Black Urad Dal, Kidney Beans, Butter, Cream, Tomato, Onion, Garam Masala", "Soak dal overnight; pressure cook; simmer for 4 hours with butter")
            UpdateItemRecipeIfEmpty("Paneer Tikka", "Paneer, Yoghurt, Ginger-Garlic Paste, Tandoori Masala, Bell Peppers, Onion, Lemon", "Marinate paneer overnight; skewer and grill in tandoor at high heat")
            UpdateItemRecipeIfEmpty("Chicken Biryani", "Basmati Rice, Chicken, Onion, Saffron, Mint, Yoghurt, Biryani Masala, Ghee", "Layer marinated chicken with par-cooked rice; seal and dum cook 25 min")
            UpdateItemRecipeIfEmpty("Veg Samosa (2 pcs)", "Potato, Green Peas, Flour, Cumin, Coriander, Ginger, Chilli, Oil", "Deep-fry stuffed pastry until golden brown; serve with chutney")
            UpdateItemRecipeIfEmpty("Garlic Naan", "Maida, Yeast, Yoghurt, Milk, Garlic, Butter, Coriander", "Ferment dough; top with garlic butter; bake in tandoor 4-5 minutes")
            UpdateItemRecipeIfEmpty("Palak Paneer", "Paneer, Spinach, Onion, Tomato, Cream, Ginger-Garlic, Cumin, Garam Masala", "Blanch and puree spinach; cook with spices; add paneer cubes")
            UpdateItemRecipeIfEmpty("Gulab Jamun (2 pcs)", "Khoya, Maida, Milk, Sugar, Rose Water, Cardamom, Saffron", "Shape khoya dough balls; deep-fry on low heat; soak in warm syrup")
        Catch
        End Try
    End Sub

    Private Sub UpdateItemRecipeIfEmpty(name As String, ingredients As String, recipe As String)
        Try
            Dim cmd As New OleDbCommand("UPDATE tblMenuItems SET Ingredients = @ing, Recipe = @rec WHERE ItemName = @nm AND (Ingredients IS NULL OR Ingredients = '')", cn)
            cmd.Parameters.AddWithValue("@ing", ingredients)
            cmd.Parameters.AddWithValue("@rec", recipe)
            cmd.Parameters.AddWithValue("@nm", name)
            cmd.ExecuteNonQuery()
        Catch
        End Try
    End Sub

    Private Function GetStaffIDByUsername(username As String) As Integer
        Try
            Dim cmd As New OleDbCommand("SELECT StaffID FROM tblStaff WHERE UserName = @un", cn)
            cmd.Parameters.AddWithValue("@un", username)
            Dim result As Object = cmd.ExecuteScalar()
            If result IsNot Nothing Then Return Convert.ToInt32(result)
        Catch
        End Try
        Return 0
    End Function

    Private Sub InsertStaffRecord(un As String, pw As String, acc As Integer, fn As String, ro As String, ph As String, sal As Double)
        Dim cmd As New OleDbCommand("INSERT INTO tblStaff (UserName, UnPassword, AccessLevel, FullName, Role, Phone, Salary) VALUES (@un, @pw, @acc, @fn, @ro, @ph, @sal)", cn)
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
        Dim cmd As New OleDbCommand("INSERT INTO tblTables (TableNumber, Capacity, TableStatus, AssignedWaiterID, AssignedWaiterName) VALUES (@num, @cap, @stat, @wid, @wname)", cn)
        cmd.Parameters.AddWithValue("@num", num)
        cmd.Parameters.AddWithValue("@cap", cap)
        cmd.Parameters.AddWithValue("@stat", stat)
        cmd.Parameters.AddWithValue("@wid", wId)
        cmd.Parameters.AddWithValue("@wname", wName)
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub InsertMenuItem(name As String, cat As String, price As Double, prepMins As Integer, desc As String, Optional ingredients As String = "", Optional recipe As String = "")
        Dim cmd As New OleDbCommand("INSERT INTO tblMenuItems (ItemName, Category, Price, PrepTimeMinutes, Description, Ingredients, Recipe) VALUES (@name, @cat, @price, @prep, @desc, @ing, @rec)", cn)
        cmd.Parameters.AddWithValue("@name", name)
        cmd.Parameters.AddWithValue("@cat", cat)
        cmd.Parameters.AddWithValue("@price", price)
        cmd.Parameters.AddWithValue("@prep", prepMins)
        cmd.Parameters.AddWithValue("@desc", desc)
        cmd.Parameters.AddWithValue("@ing", ingredients)
        cmd.Parameters.AddWithValue("@rec", recipe)
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub InsertCustomerRecord(name As String, phone As String, email As String, address As String, city As String, visits As Integer, totalSpent As Double, notes As String)
        Try
            Dim cmd As New OleDbCommand("INSERT INTO tblCustomers (CustomerName, Phone, Email, Address, City, VisitCount, TotalSpent, RegisteredOn, Notes) VALUES (@nm, @ph, @em, @ad, @ci, @vi, @ts, @ro, @nt)", cn)
            cmd.Parameters.AddWithValue("@nm", name)
            cmd.Parameters.AddWithValue("@ph", phone)
            cmd.Parameters.AddWithValue("@em", email)
            cmd.Parameters.AddWithValue("@ad", address)
            cmd.Parameters.AddWithValue("@ci", city)
            cmd.Parameters.AddWithValue("@vi", visits)
            cmd.Parameters.AddWithValue("@ts", totalSpent)
            cmd.Parameters.AddWithValue("@ro", DateTime.Now.AddDays(-visits * 15))
            cmd.Parameters.AddWithValue("@nt", notes)
            cmd.ExecuteNonQuery()
        Catch
        End Try
    End Sub

    Private Sub InsertSampleOrder()
        Dim orderTime As DateTime = DateTime.Now.AddMinutes(-8)
        Dim cmd As New OleDbCommand("INSERT INTO tblOrders (TableNumber, CustomerName, WaiterID, WaiterName, OrderStatus, OrderTime, EstWaitMinutes, TotalAmount, Notes) VALUES (@tab, @cust, @wid, @wname, @stat, @otime, @wait, @tot, @notes)", cn)
        cmd.Parameters.AddWithValue("@tab", 1)
        cmd.Parameters.AddWithValue("@cust", "Vikram Rajan")
        cmd.Parameters.AddWithValue("@wid", GetStaffIDByUsername("waiter1"))
        cmd.Parameters.AddWithValue("@wname", "Suresh Kumar")
        cmd.Parameters.AddWithValue("@stat", "Preparing in Kitchen")
        cmd.Parameters.AddWithValue("@otime", orderTime)
        cmd.Parameters.AddWithValue("@wait", 22)
        cmd.Parameters.AddWithValue("@tot", 700.0)
        cmd.Parameters.AddWithValue("@notes", "Dal Makhani extra spicy; Biryani full portion; no onion in raita")
        cmd.ExecuteNonQuery()
    End Sub

    Public Function Encrypt(PlainText As String) As String
        If String.IsNullOrEmpty(PlainText) Then Return ""
        Dim dat As Byte() = Encoding.UTF8.GetBytes(PlainText)
        Return Convert.ToBase64String(dat)
    End Function

    Public Function Decrypt(CipherText As String) As String
        If String.IsNullOrEmpty(CipherText) Then Return ""
        Try
            Dim uData As Byte() = Convert.FromBase64String(CipherText)
            Return Encoding.UTF8.GetString(uData)
        Catch
            Return CipherText
        End Try
    End Function

    Public Function FormatRupees(amount As Double) As String
        Return Chr(8377) & amount.ToString("N0")
    End Function

    Public Sub LogOut()
        LogedIn = False
        CurrentUserID = -1
        CurrentUserName = ""
        CurrentUserFullName = ""
        CurrentUserRole = ""
        UserAccessLevel = 99
    End Sub

End Module
