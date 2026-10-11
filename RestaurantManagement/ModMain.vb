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
            ' 1. Check if legacy tblStaff exists without StaffID; if so, recreate it cleanly
            Try
                Dim testStaffCmd As New OleDbCommand("SELECT TOP 1 StaffID FROM tblStaff", cn)
                testStaffCmd.ExecuteScalar()
            Catch ex As Exception
                ' StaffID column missing in tblStaff - recreate table
                ExecuteDdlSafe("DROP TABLE tblStaff")
            End Try

            ' 2. Create required tables with Jet-compliant COUNTER PK syntax
            ExecuteDdlSafe("CREATE TABLE tblStaff ([StaffID] COUNTER CONSTRAINT PK_tblStaff PRIMARY KEY, [UserName] TEXT(50), [UnPassword] TEXT(100), [AccessLevel] INTEGER, [FullName] TEXT(100), [Role] TEXT(50), [Phone] TEXT(50), [Salary] CURRENCY)")
            ExecuteDdlSafe("CREATE TABLE tblTables ([TableID] COUNTER CONSTRAINT PK_tblTables PRIMARY KEY, [TableNumber] INTEGER, [Capacity] INTEGER, [TableStatus] TEXT(30), [AssignedWaiterID] INTEGER, [AssignedWaiterName] TEXT(100))")
            ExecuteDdlSafe("CREATE TABLE tblMenuItems ([ItemID] COUNTER CONSTRAINT PK_tblMenuItems PRIMARY KEY, [ItemName] TEXT(100), [Category] TEXT(50), [Price] CURRENCY, [PrepTimeMinutes] INTEGER, [Description] TEXT(255), [Ingredients] TEXT(255), [Recipe] TEXT(255))")
            ExecuteDdlSafe("CREATE TABLE tblOrders ([OrderID] COUNTER CONSTRAINT PK_tblOrders PRIMARY KEY, [TableNumber] INTEGER, [CustomerName] TEXT(100), [WaiterID] INTEGER, [WaiterName] TEXT(100), [OrderStatus] TEXT(30), [OrderTime] DATETIME, [EstWaitMinutes] INTEGER, [TotalAmount] CURRENCY, [Notes] TEXT(255))")
            ExecuteDdlSafe("CREATE TABLE tblOrderItems ([DetailID] COUNTER CONSTRAINT PK_tblOrderItems PRIMARY KEY, [OrderID] INTEGER, [ItemID] INTEGER, [ItemName] TEXT(100), [Quantity] INTEGER, [UnitPrice] CURRENCY, [SubTotal] CURRENCY, [ItemStatus] TEXT(30), [Customization] TEXT(255))")
            ExecuteDdlSafe("CREATE TABLE tblCustomers ([CustomerID] COUNTER CONSTRAINT PK_tblCustomers PRIMARY KEY, [CustomerName] TEXT(100), [Phone] TEXT(50), [Email] TEXT(100), [Address] TEXT(255), [City] TEXT(100), [VisitCount] INTEGER, [TotalSpent] CURRENCY, [RegisteredOn] DATETIME, [Notes] TEXT(255))")

            ' Safe upgrades for older schema versions
            ExecuteDdlSafe("ALTER TABLE tblMenuItems ADD COLUMN Ingredients TEXT(255)")
            ExecuteDdlSafe("ALTER TABLE tblMenuItems ADD COLUMN Recipe TEXT(255)")
            ExecuteDdlSafe("ALTER TABLE tblOrderItems ADD COLUMN Customization TEXT(255)")
            ExecuteDdlSafe("ALTER TABLE tblStaff ADD COLUMN WorkHoursPerWeek INTEGER")
            ExecuteDdlSafe("ALTER TABLE tblStaff ADD COLUMN Shift TEXT(50)")
            ExecuteDdlSafe("ALTER TABLE tblStaff ADD COLUMN IsApproved INTEGER")
            ExecuteDdlSafe("ALTER TABLE tblStaff ADD COLUMN JoinDate DATETIME")
            ExecuteDdlSafe("ALTER TABLE tblStaff ADD COLUMN Address TEXT(255)")
            ExecuteDdlSafe("ALTER TABLE tblStaff ADD COLUMN EmergencyContact TEXT(100)")

            ' Staff signup queue (pending owner approval)
            ExecuteDdlSafe("CREATE TABLE tblStaffSignup ([SignupID] COUNTER CONSTRAINT PK_tblStaffSignup PRIMARY KEY, [FullName] TEXT(100), [UserName] TEXT(50), [UnPassword] TEXT(100), [Role] TEXT(50), [Phone] TEXT(50), [Email] TEXT(100), [Address] TEXT(255), [AppliedOn] DATETIME, [Status] TEXT(30), [Notes] TEXT(255))")

            ' 3. Seed tblStaff if empty or owner missing
            Try
                Dim checkCmd As New OleDbCommand("SELECT COUNT(*) FROM tblStaff WHERE UserName = 'owner' OR UserName = 'admin'", cn)
                Dim ownerCount As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                If ownerCount = 0 Then SeedStaff()
            Catch
                SeedStaff()
            End Try

            ' 4. Seed tblTables if empty (Tables 1 to 6)
            Try
                Dim tableCheck As New OleDbCommand("SELECT COUNT(*) FROM tblTables", cn)
                Dim tableCount As Integer = Convert.ToInt32(tableCheck.ExecuteScalar())
                If tableCount = 0 Then SeedTables()
            Catch
                SeedTables()
            End Try

            ' 5. Seed tblMenuItems with realistic British Pound prices
            Try
                Dim menuCheck As New OleDbCommand("SELECT COUNT(*) FROM tblMenuItems", cn)
                Dim menuCount As Integer = Convert.ToInt32(menuCheck.ExecuteScalar())
                If menuCount = 0 Then
                    SeedMenuItems()
                Else
                    SyncMenuRecipesAndPrices()
                End If
            Catch
            End Try

            ' 6. Seed sample international customers
            Try
                Dim custCheck As New OleDbCommand("SELECT COUNT(*) FROM tblCustomers", cn)
                Dim custCount As Integer = Convert.ToInt32(custCheck.ExecuteScalar())
                If custCount = 0 Then SeedCustomers()
            Catch
            End Try

            ' 7. Seed sample active order if tblOrders is empty
            Try
                Dim orderCheck As New OleDbCommand("SELECT COUNT(*) FROM tblOrders", cn)
                Dim orderCount As Integer = Convert.ToInt32(orderCheck.ExecuteScalar())
                If orderCount = 0 Then InsertSampleOrder()
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

    Public Sub SeedStaff()
        Try
            Dim encOwnerPw As String = Encrypt("admin123")
            Dim encWaiterPw As String = Encrypt("waiter123")

            ' Insert Owner and Admin accounts (AccessLevel 1)
            InsertStaffRecord("owner", encOwnerPw, 1, "James Sterling (Owner)", "Owner", "+44 20 7946 0912", 45000, 40, "Flexible", 1)
            InsertStaffRecord("admin", encOwnerPw, 1, "System Administrator", "Manager", "+44 20 7946 0913", 45000, 40, "Flexible", 1)

            ' Insert Waiter accounts (AccessLevel 2)
            InsertStaffRecord("waiter1", encWaiterPw, 2, "Oliver Smith", "Head Waiter", "+44 7700 900123", 26000, 40, "Morning", 1)
            InsertStaffRecord("waiter2", encWaiterPw, 2, "Emily Davies", "Waiter", "+44 7700 900456", 24000, 35, "Evening", 1)
            InsertStaffRecord("waiter3", encWaiterPw, 2, "Arjun Singh", "Waiter", "+44 7700 900789", 24000, 35, "Evening", 1)
        Catch ex As Exception
        End Try
    End Sub

    Public Sub SeedTables()
        Try
            Dim w1 As Integer = GetStaffIDByUsername("waiter1")
            Dim w2 As Integer = GetStaffIDByUsername("waiter2")
            Dim w3 As Integer = GetStaffIDByUsername("waiter3")
            If w1 = 0 Then w1 = 3
            If w2 = 0 Then w2 = 4
            If w3 = 0 Then w3 = 5

            InsertTableRecord(1, 2, "Occupied", w1, "Oliver Smith")
            InsertTableRecord(2, 4, "Occupied", w1, "Oliver Smith")
            InsertTableRecord(3, 4, "Free", w2, "Emily Davies")
            InsertTableRecord(4, 6, "Free", w2, "Emily Davies")
            InsertTableRecord(5, 2, "Free", w3, "Arjun Singh")
            InsertTableRecord(6, 8, "Reserved", w3, "Arjun Singh")
        Catch ex As Exception
        End Try
    End Sub

    Public Sub SeedMenuItems()
        Try
            ' STARTERS (£)
            InsertMenuItem("Veg Samosa (2 pcs)", "Starters", 4.5, 10, "Crispy golden pastry stuffed with spiced potato and peas, served with mint chutney", "Potato, Green Peas, Flour, Cumin, Coriander, Ginger, Chilli, Oil", "Deep-fry stuffed pastry until golden brown; serve with chutney")
            InsertMenuItem("Paneer Tikka", "Starters", 7.95, 18, "Cubes of fresh cottage cheese marinated in tandoor spices and charcoal-grilled", "Paneer, Yoghurt, Ginger-Garlic Paste, Tandoori Masala, Bell Peppers, Onion, Lemon", "Marinate paneer overnight; skewer and grill in tandoor at high heat")
            InsertMenuItem("Onion Bhaji", "Starters", 4.95, 8, "Crispy chickpea-battered onion fritters with green chilli and coriander", "Onion, Besan (Chickpea Flour), Green Chilli, Coriander, Turmeric, Chaat Masala", "Mix batter, fold in onion slices, deep-fry until crisp")
            InsertMenuItem("Chicken Seekh Kebab", "Starters", 8.5, 20, "Minced spiced chicken moulded on skewers and grilled in tandoor oven", "Minced Chicken, Onion, Green Chilli, Ginger, Garlic, Garam Masala, Coriander", "Mix spiced mince, wrap on skewers, grill in tandoor 12-15 minutes")
            InsertMenuItem("Aloo Tikki Chaat", "Starters", 5.25, 12, "Spiced mashed potato patties topped with yoghurt, tamarind, and sev", "Potato, Chickpeas, Yoghurt, Tamarind Chutney, Mint Chutney, Sev, Chaat Masala", "Pan-fry potato patties; assemble with toppings just before serving")

            ' MAINS (£)
            InsertMenuItem("Butter Chicken (Murgh Makhani)", "Mains", 13.5, 22, "Tender chicken in a rich tomato-butter-cream sauce", "Chicken, Tomato Puree, Butter, Cream, Onion, Ginger-Garlic, Kashmiri Chilli, Kasoori Methi", "Marinate and grill chicken; simmer in makhani gravy; finish with cream")
            InsertMenuItem("Dal Makhani", "Mains", 9.95, 25, "Black lentils slow-cooked overnight with butter, cream, and secret spices", "Black Urad Dal, Kidney Beans, Butter, Cream, Tomato, Onion, Garam Masala", "Soak dal overnight; pressure cook; simmer for 4 hours with butter")
            InsertMenuItem("Palak Paneer", "Mains", 10.5, 18, "Fresh cottage cheese in a velvety spinach and spice gravy", "Paneer, Spinach, Onion, Tomato, Cream, Ginger-Garlic, Cumin, Garam Masala", "Blanch and puree spinach; cook with spices; add paneer cubes")
            InsertMenuItem("Lamb Rogan Josh", "Mains", 14.95, 30, "Tender slow-braised lamb in a bold Kashmiri spice and yoghurt gravy", "Lamb, Yoghurt, Kashmiri Chilli, Fennel, Ginger, Garlic, Cloves, Cardamom", "Brown lamb; add whole spices; slow braise in yoghurt sauce 45 min")
            InsertMenuItem("Chicken Biryani", "Mains", 13.95, 28, "Aromatic basmati rice slow-cooked with marinated chicken (Dum style)", "Basmati Rice, Chicken, Onion, Saffron, Mint, Yoghurt, Biryani Masala, Ghee", "Layer marinated chicken with par-cooked rice; seal and dum cook 25 min")
            InsertMenuItem("Chole Bhature", "Mains", 8.95, 20, "Tangy chickpea curry served with fluffy deep-fried bread", "Chickpeas, Tomato, Onion, Ginger, Garlic, Chole Masala, Amchur, Bhature Dough", "Pressure cook chickpeas in spicy gravy; serve with fresh hot bhature")
            InsertMenuItem("Fish Masala Curry", "Mains", 14.5, 22, "Coastal spiced fish curry in tangy coconut-tamarind masala", "Fresh Fish, Coconut Milk, Tamarind, Tomato, Onion, Mustard, Curry Leaves, Kokum", "Fry fish in spiced paste; simmer in coconut-tamarind gravy 15 min")
            InsertMenuItem("Veg Thali", "Mains", 12.5, 20, "Complete Indian meal: 2 curries, dal, rice, roti, raita, pickle, papad", "Seasonal Vegetables, Dal, Basmati Rice, Wheat Flour, Yoghurt, Pickle", "Prepare all components fresh; assemble on stainless steel thali plate")

            ' BREADS (£)
            InsertMenuItem("Garlic Naan", "Breads", 3.5, 8, "Soft leavened bread topped with garlic butter and coriander, baked in tandoor", "Maida, Yeast, Yoghurt, Milk, Garlic, Butter, Coriander", "Ferment dough; top with garlic butter; bake in tandoor 4-5 minutes")
            InsertMenuItem("Laccha Paratha", "Breads", 3.25, 10, "Multi-layered flaky whole wheat bread, cooked on a cast-iron tawa with ghee", "Whole Wheat Flour, Ghee, Water, Salt", "Roll layered dough; cook on tawa with ghee until golden flaky layers form")
            InsertMenuItem("Puri (3 pcs)", "Breads", 2.95, 6, "Small puffed deep-fried bread, served with bhaji or curry", "Wheat Flour, Salt, Oil", "Knead stiff dough; roll small rounds; deep-fry until golden and puffed")

            ' RICE (£)
            InsertMenuItem("Steamed Basmati Rice", "Rice", 3.5, 12, "Aged long-grain basmati rice, perfectly steamed and fragrant", "Basmati Rice, Water, Salt", "Wash and soak rice; boil with salt; drain and steam finish")
            InsertMenuItem("Jeera Rice", "Rice", 4.25, 15, "Fragrant cumin-tempered basmati rice cooked with whole spices", "Basmati Rice, Cumin Seeds, Ghee, Bay Leaf, Cloves, Salt", "Temper cumin in ghee; add rice; cook in spiced water until fluffy")

            ' DESSERTS (£)
            InsertMenuItem("Gulab Jamun (2 pcs)", "Desserts", 4.5, 5, "Soft milk-solid dumplings soaked in rose and cardamom sugar syrup", "Khoya, Maida, Milk, Sugar, Rose Water, Cardamom, Saffron", "Shape khoya dough balls; deep-fry on low heat; soak in warm syrup")
            InsertMenuItem("Rasmalai (2 pcs)", "Desserts", 4.95, 8, "Soft chenna dumplings floating in chilled saffron-cardamom milk", "Chenna, Sugar, Milk, Saffron, Cardamom, Pistachios, Rose Water", "Cook chenna discs in syrup; simmer in reduced saffron milk; chill")
            InsertMenuItem("Kheer (Rice Pudding)", "Desserts", 4.5, 15, "Creamy slow-cooked rice pudding with saffron, cardamom, and dry fruits", "Basmati Rice, Full Cream Milk, Sugar, Saffron, Cardamom, Cashews, Almonds", "Simmer rice in milk on low heat 30 min until thick; add sugar and dry fruits")
            InsertMenuItem("Kulfi Falooda", "Desserts", 5.5, 5, "Traditional Indian ice cream with rose syrup, basil seeds, and vermicelli", "Kulfi (Cream, Sugar, Cardamom, Pistachio), Rose Syrup, Basil Seeds, Falooda Sev", "Unmould kulfi; assemble with soaked basil seeds, falooda, rose syrup")

            ' BEVERAGES (£)
            InsertMenuItem("Masala Chai", "Beverages", 2.5, 5, "Spiced Indian milk tea with ginger, cardamom, and cinnamon", "Tea Leaves, Milk, Ginger, Cardamom, Cinnamon, Sugar", "Boil spices in water; add tea leaves; add milk; strain and serve hot")
            InsertMenuItem("Mango Lassi", "Beverages", 3.75, 4, "Thick chilled yoghurt drink blended with Alphonso mango pulp", "Fresh Yoghurt, Alphonso Mango Pulp, Sugar, Cardamom, Saffron, Ice", "Blend yoghurt, mango pulp and spices; serve chilled with ice")
            InsertMenuItem("Fresh Lime Soda", "Beverages", 2.95, 3, "Refreshing fresh lime juice with soda water - sweet, salty or both", "Fresh Lime, Soda Water, Sugar Syrup, Black Salt, Ice", "Squeeze fresh lime; mix with soda; add sweetener or salt as preferred")
            InsertMenuItem("Rooh Afza Sharbat", "Beverages", 3.25, 3, "Chilled rose water sherbet drink with basil seeds and chilled milk", "Rooh Afza Syrup, Chilled Milk, Basil Seeds (Sabja), Ice", "Mix Rooh Afza with chilled milk; add soaked basil seeds; serve over ice")
            InsertMenuItem("Fresh Coconut Water", "Beverages", 3.5, 2, "Tender green coconut served fresh with straw - naturally refreshing", "Green Coconut", "Select fresh tender coconut; serve with straw; scoop malai on request")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SyncMenuRecipesAndPrices()
        Try
            ' Ensure realistic Pound (£) prices and recipe details exist
            UpdateItemPriceAndRecipe("Veg Samosa (2 pcs)", 4.5, "Potato, Green Peas, Flour, Cumin, Coriander, Ginger, Chilli, Oil", "Deep-fry stuffed pastry until golden brown; serve with chutney")
            UpdateItemPriceAndRecipe("Paneer Tikka", 7.95, "Paneer, Yoghurt, Ginger-Garlic Paste, Tandoori Masala, Bell Peppers, Onion, Lemon", "Marinate paneer overnight; skewer and grill in tandoor at high heat")
            UpdateItemPriceAndRecipe("Onion Bhaji", 4.95, "Onion, Besan (Chickpea Flour), Green Chilli, Coriander, Turmeric, Chaat Masala", "Mix batter, fold in onion slices, deep-fry until crisp")
            UpdateItemPriceAndRecipe("Chicken Seekh Kebab", 8.5, "Minced Chicken, Onion, Green Chilli, Ginger, Garlic, Garam Masala, Coriander", "Mix spiced mince, wrap on skewers, grill in tandoor 12-15 minutes")
            UpdateItemPriceAndRecipe("Aloo Tikki Chaat", 5.25, "Potato, Chickpeas, Yoghurt, Tamarind Chutney, Mint Chutney, Sev, Chaat Masala", "Pan-fry potato patties; assemble with toppings just before serving")
            UpdateItemPriceAndRecipe("Butter Chicken (Murgh Makhani)", 13.5, "Chicken, Tomato Puree, Butter, Cream, Onion, Ginger-Garlic, Kashmiri Chilli, Kasoori Methi", "Marinate and grill chicken; simmer in makhani gravy; finish with cream")
            UpdateItemPriceAndRecipe("Dal Makhani", 9.95, "Black Urad Dal, Kidney Beans, Butter, Cream, Tomato, Onion, Garam Masala", "Soak dal overnight; pressure cook; simmer for 4 hours with butter")
            UpdateItemPriceAndRecipe("Palak Paneer", 10.5, "Paneer, Spinach, Onion, Tomato, Cream, Ginger-Garlic, Cumin, Garam Masala", "Blanch and puree spinach; cook with spices; add paneer cubes")
            UpdateItemPriceAndRecipe("Lamb Rogan Josh", 14.95, "Lamb, Yoghurt, Kashmiri Chilli, Fennel, Ginger, Garlic, Cloves, Cardamom", "Brown lamb; add whole spices; slow braise in yoghurt sauce 45 min")
            UpdateItemPriceAndRecipe("Chicken Biryani", 13.95, "Basmati Rice, Chicken, Onion, Saffron, Mint, Yoghurt, Biryani Masala, Ghee", "Layer marinated chicken with par-cooked rice; seal and dum cook 25 min")
            UpdateItemPriceAndRecipe("Chole Bhature", 8.95, "Chickpeas, Tomato, Onion, Ginger, Garlic, Chole Masala, Amchur, Bhature Dough", "Pressure cook chickpeas in spicy gravy; serve with fresh hot bhature")
            UpdateItemPriceAndRecipe("Fish Masala Curry", 14.5, "Fresh Fish, Coconut Milk, Tamarind, Tomato, Onion, Mustard, Curry Leaves, Kokum", "Fry fish in spiced paste; simmer in coconut-tamarind gravy 15 min")
            UpdateItemPriceAndRecipe("Veg Thali", 12.5, "Seasonal Vegetables, Dal, Basmati Rice, Wheat Flour, Yoghurt, Pickle", "Prepare all components fresh; assemble on stainless steel thali plate")
            UpdateItemPriceAndRecipe("Garlic Naan", 3.5, "Maida, Yeast, Yoghurt, Milk, Garlic, Butter, Coriander", "Ferment dough; top with garlic butter; bake in tandoor 4-5 minutes")
            UpdateItemPriceAndRecipe("Laccha Paratha", 3.25, "Whole Wheat Flour, Ghee, Water, Salt", "Roll layered dough; cook on tawa with ghee until golden flaky layers form")
            UpdateItemPriceAndRecipe("Puri (3 pcs)", 2.95, "Wheat Flour, Salt, Oil", "Knead stiff dough; roll small rounds; deep-fry until golden and puffed")
            UpdateItemPriceAndRecipe("Steamed Basmati Rice", 3.5, "Basmati Rice, Water, Salt", "Wash and soak rice; boil with salt; drain and steam finish")
            UpdateItemPriceAndRecipe("Jeera Rice", 4.25, "Basmati Rice, Cumin Seeds, Ghee, Bay Leaf, Cloves, Salt", "Temper cumin in ghee; add rice; cook in spiced water until fluffy")
            UpdateItemPriceAndRecipe("Gulab Jamun (2 pcs)", 4.5, "Khoya, Maida, Milk, Sugar, Rose Water, Cardamom, Saffron", "Shape khoya dough balls; deep-fry on low heat; soak in warm syrup")
            UpdateItemPriceAndRecipe("Rasmalai (2 pcs)", 4.95, "Chenna, Sugar, Milk, Saffron, Cardamom, Pistachios, Rose Water", "Cook chenna discs in syrup; simmer in reduced saffron milk; chill")
            UpdateItemPriceAndRecipe("Kheer (Rice Pudding)", 4.5, "Basmati Rice, Full Cream Milk, Sugar, Saffron, Cardamom, Cashews, Almonds", "Simmer rice in milk on low heat 30 min until thick; add sugar and dry fruits")
            UpdateItemPriceAndRecipe("Kulfi Falooda", 5.5, "Kulfi (Cream, Sugar, Cardamom, Pistachio), Rose Syrup, Basil Seeds, Falooda Sev", "Unmould kulfi; assemble with soaked basil seeds, falooda, rose syrup")
            UpdateItemPriceAndRecipe("Masala Chai", 2.5, "Tea Leaves, Milk, Ginger, Cardamom, Cinnamon, Sugar", "Boil spices in water; add tea leaves; add milk; strain and serve hot")
            UpdateItemPriceAndRecipe("Mango Lassi", 3.75, "Fresh Yoghurt, Alphonso Mango Pulp, Sugar, Cardamom, Saffron, Ice", "Blend yoghurt, mango pulp and spices; serve chilled with ice")
            UpdateItemPriceAndRecipe("Fresh Lime Soda", 2.95, "Fresh Lime, Soda Water, Sugar Syrup, Black Salt, Ice", "Squeeze fresh lime; mix with soda; add sweetener or salt as preferred")
            UpdateItemPriceAndRecipe("Rooh Afza Sharbat", 3.25, "Rooh Afza Syrup, Chilled Milk, Basil Seeds (Sabja), Ice", "Mix Rooh Afza with chilled milk; add soaked basil seeds; serve over ice")
            UpdateItemPriceAndRecipe("Fresh Coconut Water", 3.5, "Green Coconut", "Select fresh tender coconut; serve with straw; scoop malai on request")
        Catch
        End Try
    End Sub

    Private Sub UpdateItemPriceAndRecipe(name As String, price As Double, ingredients As String, recipe As String)
        Try
            Dim cmd As New OleDbCommand("UPDATE tblMenuItems SET Price = @pr, Ingredients = @ing, Recipe = @rec WHERE ItemName = @nm", cn)
            cmd.Parameters.AddWithValue("@pr", CDec(price))
            cmd.Parameters.AddWithValue("@ing", ingredients)
            cmd.Parameters.AddWithValue("@rec", recipe)
            cmd.Parameters.AddWithValue("@nm", name)
            cmd.ExecuteNonQuery()
        Catch
        End Try
    End Sub

    Public Sub SeedCustomers()
        Try
            InsertCustomerRecord("Alexander Wright", "+44 20 7123 4567", "alex.wright@ukmail.com", "14 Baker Street", "London", 5, 185.5, "Regular - prefers mild spice; vegetarian")
            InsertCustomerRecord("Charlotte Evans", "+44 20 7987 6543", "c.evans@outlook.co.uk", "28 Kensington High St", "London", 3, 124.0, "Likes Chicken Biryani; family of 4")
            InsertCustomerRecord("David Campbell", "+44 161 234 5678", "david.c@scotmail.com", "8 Deansgate", "Manchester", 8, 360.0, "VIP; nut allergy; prefers window table")
            InsertCustomerRecord("Fiona MacLeod", "+44 131 496 0123", "fiona.m@edinburgh.org", "45 Princes Street", "Edinburgh", 2, 65.5, "Corporate account - Table 4")
            InsertCustomerRecord("Sophie Turner", "+44 121 555 7890", "sophie.t@bham.co.uk", "12 Colmore Row", "Birmingham", 12, 520.0, "Loyal customer since 2021; loves Rasmalai")
            InsertCustomerRecord("George Harrison", "+44 151 496 0234", "george.h@liverpool.co.uk", "10 Albert Dock", "Liverpool", 4, 145.0, "Books Table 6 for team dinners")
        Catch ex As Exception
        End Try
    End Sub

    Public Function GetStaffIDByUsername(username As String) As Integer
        Try
            Dim cmd As New OleDbCommand("SELECT StaffID FROM tblStaff WHERE LCase(UserName) = @un", cn)
            cmd.Parameters.AddWithValue("@un", username.Trim().ToLower())
            Dim result As Object = cmd.ExecuteScalar()
            If result IsNot Nothing AndAlso Not IsDBNull(result) Then Return Convert.ToInt32(result)
        Catch
        End Try
        Return 0
    End Function

    Private Sub InsertStaffRecord(un As String, pw As String, acc As Integer, fn As String, ro As String, ph As String, sal As Double, Optional wh As Integer = 40, Optional shift As String = "Morning", Optional approved As Integer = 1)
        Try
            Dim cmd As New OleDbCommand("INSERT INTO tblStaff (UserName, UnPassword, AccessLevel, FullName, Role, Phone, Salary, WorkHoursPerWeek, Shift, IsApproved, JoinDate) VALUES (@un, @pw, @acc, @fn, @ro, @ph, @sal, @wh, @sh, @ap, @jd)", cn)
            cmd.Parameters.AddWithValue("@un", un)
            cmd.Parameters.AddWithValue("@pw", pw)
            cmd.Parameters.AddWithValue("@acc", acc)
            cmd.Parameters.AddWithValue("@fn", fn)
            cmd.Parameters.AddWithValue("@ro", ro)
            cmd.Parameters.AddWithValue("@ph", ph)
            cmd.Parameters.AddWithValue("@sal", CDec(sal))
            cmd.Parameters.AddWithValue("@wh", wh)
            cmd.Parameters.AddWithValue("@sh", shift)
            cmd.Parameters.AddWithValue("@ap", approved)
            cmd.Parameters.AddWithValue("@jd", DateTime.Now)
            cmd.ExecuteNonQuery()
        Catch
        End Try
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
        cmd.Parameters.AddWithValue("@price", CDec(price))
        cmd.Parameters.AddWithValue("@prep", prepMins)
        cmd.Parameters.AddWithValue("@desc", desc)
        cmd.Parameters.AddWithValue("@ing", ingredients)
        cmd.Parameters.AddWithValue("@rec", recipe)
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub InsertCustomerRecord(name As String, phone As String, email As String, address As String, city As String, visits As Integer, totalSpent As Double, notes As String)
        Try
            Dim cmd As New OleDbCommand("INSERT INTO tblCustomers (CustomerName, Phone, Email, Address, City, VisitCount, TotalSpent, RegisteredOn, Notes) VALUES (@nm, @ph, @em, @ad, @ci, @vi, @ts, Now(), @nt)", cn)
            cmd.Parameters.AddWithValue("@nm", name)
            cmd.Parameters.AddWithValue("@ph", phone)
            cmd.Parameters.AddWithValue("@em", email)
            cmd.Parameters.AddWithValue("@ad", address)
            cmd.Parameters.AddWithValue("@ci", city)
            cmd.Parameters.AddWithValue("@vi", visits)
            cmd.Parameters.AddWithValue("@ts", CDec(totalSpent))
            cmd.Parameters.AddWithValue("@nt", notes)
            cmd.ExecuteNonQuery()
        Catch
        End Try
    End Sub

    Private Sub InsertSampleOrder()
        Try
            Dim wId As Integer = GetStaffIDByUsername("waiter1")
            If wId = 0 Then wId = 3
            Dim cmd As New OleDbCommand("INSERT INTO tblOrders (TableNumber, CustomerName, WaiterID, WaiterName, OrderStatus, OrderTime, EstWaitMinutes, TotalAmount, Notes) VALUES (@tab, @cust, @wid, @wname, @stat, Now(), @wait, @tot, @notes)", cn)
            cmd.Parameters.AddWithValue("@tab", 1)
            cmd.Parameters.AddWithValue("@cust", "Charlotte Evans")
            cmd.Parameters.AddWithValue("@wid", wId)
            cmd.Parameters.AddWithValue("@wname", "Oliver Smith")
            cmd.Parameters.AddWithValue("@stat", "Preparing in Kitchen")
            cmd.Parameters.AddWithValue("@wait", 25)
            cmd.Parameters.AddWithValue("@tot", CDec(34.2))
            cmd.Parameters.AddWithValue("@notes", "Dal Makhani medium spice; Garlic Naan crispy; Mango Lassi chilled")
            cmd.ExecuteNonQuery()

            cmd.Parameters.Clear()
            cmd.CommandText = "SELECT @@IDENTITY"
            Dim sampleOid As Integer = Convert.ToInt32(cmd.ExecuteScalar())

            ' Insert sample items
            Dim itemCmd As New OleDbCommand("INSERT INTO tblOrderItems (OrderID, ItemID, ItemName, Quantity, UnitPrice, SubTotal, ItemStatus, Customization) VALUES (@oid, @iid, @inm, @qty, @pr, @sub, @stat, @cust)", cn)
            itemCmd.Parameters.AddWithValue("@oid", sampleOid)
            itemCmd.Parameters.AddWithValue("@iid", 7)
            itemCmd.Parameters.AddWithValue("@inm", "Dal Makhani")
            itemCmd.Parameters.AddWithValue("@qty", 1)
            itemCmd.Parameters.AddWithValue("@pr", CDec(9.95))
            itemCmd.Parameters.AddWithValue("@sub", CDec(9.95))
            itemCmd.Parameters.AddWithValue("@stat", "Preparing in Kitchen")
            itemCmd.Parameters.AddWithValue("@cust", "Medium spice")
            itemCmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try
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

    ''' <summary>
    ''' Formats monetary figures in British Pounds (£) with 2 decimal places.
    ''' </summary>
    Public Function FormatCurrency(amount As Double) As String
        Return ChrW(163) & amount.ToString("N2")
    End Function

    ''' <summary>
    ''' Backwards-compatible alias for FormatCurrency.
    ''' </summary>
    Public Function FormatRupees(amount As Double) As String
        Return FormatCurrency(amount)
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
