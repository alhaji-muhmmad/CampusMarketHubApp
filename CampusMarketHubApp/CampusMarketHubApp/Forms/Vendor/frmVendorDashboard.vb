Imports System.Data.SqlClient

Public Class frmVendorDashboard
    Inherits frmBaseDashboard

    Private activeMenuItem As Label = Nothing
    Private Sub frmVendorDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUserInfo()
        BuildSidebarMenu()
        ' Load dashboard home by default
        LoadDashboardHome()
    End Sub

    Private Sub SetActiveMenuItem(selected As Label)
        ' Reset previous active item
        If activeMenuItem IsNot Nothing Then
            activeMenuItem.BackColor = Color.FromArgb(26, 26, 26)
            activeMenuItem.ForeColor = Color.FromArgb(189, 189, 189)
        End If

        ' Set new active item
        selected.BackColor = Color.FromArgb(40, 40, 40)
        selected.ForeColor = Color.White
        activeMenuItem = selected

        ' Update red accent — remove old one and add new one
        Dim toRemove As New List(Of Control)
        For Each ctrl As Control In pnlMenuItems.Controls
            If TypeOf ctrl Is Panel Then
                toRemove.Add(ctrl)
            End If
        Next
        For Each ctrl As Control In toRemove
            pnlMenuItems.Controls.Remove(ctrl)
        Next

        Dim accent As New Panel()
        accent.Size = New Size(3, 44)
        accent.Location = New Point(0, selected.Location.Y)
        accent.BackColor = Color.FromArgb(219, 68, 68)
        pnlMenuItems.Controls.Add(accent)
        accent.BringToFront()
    End Sub

    ' -------------------------------------------------------
    ' Build the vendor sidebar menu
    ' -------------------------------------------------------
    Private Sub BuildSidebarMenu()
        pnlMenuItems.Controls.Clear()

        Dim dashboardItem = AddMenuItem("Dashboard", 0, True)
        Dim productsItem = AddMenuItem("My Products", 44)
        Dim addProductItem = AddMenuItem("Add Product", 88)
        Dim ordersItem = AddMenuItem("Orders", 132)
        Dim analyticsItem = AddMenuItem("Sales Analytics", 176)
        Dim earningsItem = AddMenuItem("Earnings", 220)
        Dim profileItem = AddMenuItem("My Profile", 264)

        ' Set dashboard as default active
        activeMenuItem = dashboardItem

        ' Wire up click events
        AddHandler dashboardItem.Click, Sub(s, e)
                                            SetActiveMenuItem(dashboardItem)
                                            LoadDashboardHome()
                                        End Sub

        AddHandler productsItem.Click, Sub(s, e)
                                           SetActiveMenuItem(productsItem)
                                           MessageBox.Show("Coming soon.", "My Products")
                                       End Sub

        AddHandler addProductItem.Click, Sub(s, e)
                                             SetActiveMenuItem(addProductItem)
                                             LoadChildForm(New frmAddProduct())
                                         End Sub

        AddHandler ordersItem.Click, Sub(s, e)
                                         SetActiveMenuItem(ordersItem)
                                         MessageBox.Show("Coming soon.", "Vendor Orders")
                                     End Sub

        AddHandler analyticsItem.Click, Sub(s, e)
                                            SetActiveMenuItem(analyticsItem)
                                            MessageBox.Show("Coming soon.", "Sales Analytics")
                                        End Sub

        AddHandler earningsItem.Click, Sub(s, e)
                                           SetActiveMenuItem(earningsItem)
                                           MessageBox.Show("Coming soon.", "Earnings")
                                       End Sub

        AddHandler profileItem.Click, Sub(s, e)
                                          SetActiveMenuItem(profileItem)
                                          MessageBox.Show("Coming soon.", "Profile")
                                      End Sub
    End Sub

    ' -------------------------------------------------------
    ' Load the dashboard home panel
    ' -------------------------------------------------------
    Private Sub LoadDashboardHome()
        pnlMainContent.Controls.Clear()

        ' Welcome label
        Dim lblWelcome As New Label()
        lblWelcome.Text = "Welcome back, " & SessionManager.Username & "!"
        lblWelcome.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        lblWelcome.ForeColor = Color.FromArgb(0, 0, 0)
        lblWelcome.AutoSize = True
        lblWelcome.Location = New Point(24, 24)
        pnlMainContent.Controls.Add(lblWelcome)

        ' Summary cards row
        Dim yPos As Integer = 50
        AddSummaryCard("Total Products", GetTotalProducts().ToString(), "#DB4444", 24, 80)
        AddSummaryCard("Pending Orders", GetPendingOrders().ToString(), "#FF9800", 244, 80)
        AddSummaryCard("Completed Orders", GetCompletedOrders().ToString(), "#00A651", 464, 80)
        AddSummaryCard("Total Revenue", "₦" & GetTotalRevenue().ToString("N2"), "#2196F3", 684, 80)
    End Sub

    ' -------------------------------------------------------
    ' Summary card builder
    ' -------------------------------------------------------
    Private Sub AddSummaryCard(title As String, value As String,
                                hexColor As String, x As Integer, y As Integer)
        Dim card As New Panel()
        card.Size = New Size(200, 100)
        card.Location = New Point(x, y)
        card.BackColor = Color.White

        Dim lblValue As New Label()
        lblValue.Text = value
        lblValue.Font = New Font("Segoe UI", 20, FontStyle.Bold)
        lblValue.ForeColor = ColorTranslator.FromHtml(hexColor)
        lblValue.AutoSize = True
        lblValue.Location = New Point(16, 16)

        Dim lblTitle As New Label()
        lblTitle.Text = title
        lblTitle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        lblTitle.ForeColor = Color.FromArgb(125, 129, 132)
        lblTitle.AutoSize = True
        lblTitle.Location = New Point(16, 56)

        card.Controls.Add(lblValue)
        card.Controls.Add(lblTitle)
        pnlMainContent.Controls.Add(card)
    End Sub

    ' -------------------------------------------------------
    ' Dashboard data queries
    ' -------------------------------------------------------
    Private Function GetTotalProducts() As Integer
        Try
            Dim sql As String =
                "SELECT COUNT(*) FROM Products WHERE vendorId = @vendorId"
            Dim result = DataAccess.ExecuteScalar(sql,
                New SqlParameter("@vendorId", SessionManager.RoleId))
            Return If(result Is Nothing, 0, CInt(result))
        Catch
            Return 0
        End Try
    End Function

    Private Function GetPendingOrders() As Integer
        Try
            Dim sql As String =
                "SELECT COUNT(*) FROM Orders o
                 INNER JOIN OrderItems oi ON o.orderId = oi.orderId
                 INNER JOIN Products p ON oi.productId = p.productId
                 WHERE p.vendorId = @vendorId AND o.status = 'Pending'"
            Dim result = DataAccess.ExecuteScalar(sql,
                New SqlParameter("@vendorId", SessionManager.RoleId))
            Return If(result Is Nothing, 0, CInt(result))
        Catch
            Return 0
        End Try
    End Function

    Private Function GetCompletedOrders() As Integer
        Try
            Dim sql As String =
                "SELECT COUNT(*) FROM Orders o
                 INNER JOIN OrderItems oi ON o.orderId = oi.orderId
                 INNER JOIN Products p ON oi.productId = p.productId
                 WHERE p.vendorId = @vendorId AND o.status = 'Completed'"
            Dim result = DataAccess.ExecuteScalar(sql,
                New SqlParameter("@vendorId", SessionManager.RoleId))
            Return If(result Is Nothing, 0, CInt(result))
        Catch
            Return 0
        End Try
    End Function

    Private Function GetTotalRevenue() As Decimal
        Try
            Dim sql As String =
                "SELECT ISNULL(SUM(oi.price * oi.quantity), 0)
                 FROM OrderItems oi
                 INNER JOIN Products p ON oi.productId = p.productId
                 INNER JOIN Orders o ON oi.orderId = o.orderId
                 WHERE p.vendorId = @vendorId AND o.status = 'Completed'"
            Dim result = DataAccess.ExecuteScalar(sql,
                New SqlParameter("@vendorId", SessionManager.RoleId))
            Return If(result Is Nothing, 0D, CDec(result))
        Catch
            Return 0D
        End Try
    End Function

End Class