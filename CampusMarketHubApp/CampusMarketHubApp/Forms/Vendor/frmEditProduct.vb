Imports System.Data.SqlClient

Public Class frmEditProduct

    ' Product ID passed in from manage products grid
    Public Property ProductId As Integer = 0

    Private Sub frmEditProduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblError.Text = ""
        LoadCategories()
        If ProductId > 0 Then
            LoadProductDetails()
        End If
    End Sub

    ' -------------------------------------------------------
    ' Load categories into dropdown
    ' -------------------------------------------------------
    Private Sub LoadCategories()
        Try
            Dim sql As String =
                "SELECT categoryId, categoryName FROM Categories ORDER BY categoryName"
            Dim result As DataTable = DataAccess.ExecuteQuery(sql)

            cboCategory.Items.Clear()
            For Each row As DataRow In result.Rows
                cboCategory.Items.Add(New CategoryItem(CInt(row("categoryId")),
                                                        row("categoryName").ToString()))
            Next

        Catch ex As Exception
            ShowError("Failed to load categories: " & ex.Message)
        End Try
    End Sub

    ' -------------------------------------------------------
    ' Load existing product details into form
    ' -------------------------------------------------------
    Private Sub LoadProductDetails()
        Try
            Dim sql As String =
                "SELECT p.productName, p.categoryId, p.price,
                        p.stockQty, p.description
                 FROM Products p
                 WHERE p.productId = @productId
                 AND p.vendorId = @vendorId"

            Dim result As DataTable = DataAccess.ExecuteQuery(sql,
                New SqlParameter("@productId", ProductId),
                New SqlParameter("@vendorId", SessionManager.RoleId))

            If result.Rows.Count = 0 Then
                ShowError("Product not found.")
                Return
            End If

            Dim row As DataRow = result.Rows(0)

            ' Fill form fields
            txtProductName.Text = row("productName").ToString()
            txtPrice.Text = row("price").ToString()
            txtStock.Text = row("stockQty").ToString()
            txtDescription.Text = If(IsDBNull(row("description")), "", row("description").ToString())

            ' Select matching category in dropdown
            Dim categoryId As Integer = CInt(row("categoryId"))
            For i As Integer = 0 To cboCategory.Items.Count - 1
                Dim item As CategoryItem = CType(cboCategory.Items(i), CategoryItem)
                If item.Id = categoryId Then
                    cboCategory.SelectedIndex = i
                    Exit For
                End If
            Next

        Catch ex As Exception
            ShowError("Failed to load product: " & ex.Message)
        End Try
    End Sub

    ' -------------------------------------------------------
    ' Focus events
    ' -------------------------------------------------------
    Private Sub txtProductName_Enter(sender As Object, e As EventArgs) Handles txtProductName.Enter
        pnlProductNameLine.BackColor = Color.FromArgb(219, 68, 68)
    End Sub
    Private Sub txtProductName_Leave(sender As Object, e As EventArgs) Handles txtProductName.Leave
        pnlProductNameLine.BackColor = Color.FromArgb(224, 224, 224)
    End Sub

    Private Sub txtPrice_Enter(sender As Object, e As EventArgs) Handles txtPrice.Enter
        pnlPriceLine.BackColor = Color.FromArgb(219, 68, 68)
    End Sub
    Private Sub txtPrice_Leave(sender As Object, e As EventArgs) Handles txtPrice.Leave
        pnlPriceLine.BackColor = Color.FromArgb(224, 224, 224)
    End Sub

    Private Sub txtStock_Enter(sender As Object, e As EventArgs) Handles txtStock.Enter
        pnlStockLine.BackColor = Color.FromArgb(219, 68, 68)
    End Sub
    Private Sub txtStock_Leave(sender As Object, e As EventArgs) Handles txtStock.Leave
        pnlStockLine.BackColor = Color.FromArgb(224, 224, 224)
    End Sub

    ' -------------------------------------------------------
    ' Only allow numeric input
    ' -------------------------------------------------------
    Private Sub txtPrice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrice.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso
           e.KeyChar <> "."c AndAlso
           e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtStock_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtStock.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso
           e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    ' -------------------------------------------------------
    ' Save Changes Button
    ' -------------------------------------------------------
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        lblError.Text = ""

        ' Validate
        If String.IsNullOrWhiteSpace(txtProductName.Text) Then
            ShowError("Please enter a product name.") : Return
        End If

        If cboCategory.SelectedIndex < 0 Then
            ShowError("Please select a category.") : Return
        End If

        If String.IsNullOrWhiteSpace(txtPrice.Text) Then
            ShowError("Please enter a price.") : Return
        End If

        Dim price As Decimal
        If Not Decimal.TryParse(txtPrice.Text, price) OrElse price <= 0 Then
            ShowError("Please enter a valid price.") : Return
        End If

        If String.IsNullOrWhiteSpace(txtStock.Text) Then
            ShowError("Please enter stock quantity.") : Return
        End If

        Dim newStock As Integer
        If Not Integer.TryParse(txtStock.Text, newStock) OrElse newStock < 0 Then
            ShowError("Please enter a valid stock quantity.") : Return
        End If

        Dim selectedCategory As CategoryItem = CType(cboCategory.SelectedItem, CategoryItem)

        Try
            ' Get old stock qty for inventory log
            Dim oldStockSql As String =
                "SELECT stockQty FROM Products WHERE productId = @productId"
            Dim oldStockResult As Object = DataAccess.ExecuteScalar(oldStockSql,
                New SqlParameter("@productId", ProductId))
            Dim oldStock As Integer = If(oldStockResult IsNot Nothing, CInt(oldStockResult), 0)

            ' Update product
            Dim updateSql As String =
                "UPDATE Products
                 SET productName = @productName,
                     categoryId = @categoryId,
                     price = @price,
                     stockQty = @stockQty,
                     description = @description
                 WHERE productId = @productId
                 AND vendorId = @vendorId"

            DataAccess.ExecuteNonQuery(updateSql,
                New SqlParameter("@productName", txtProductName.Text.Trim()),
                New SqlParameter("@categoryId", selectedCategory.Id),
                New SqlParameter("@price", price),
                New SqlParameter("@stockQty", newStock),
                New SqlParameter("@description",
                    If(String.IsNullOrWhiteSpace(txtDescription.Text),
                       CObj(DBNull.Value), CObj(txtDescription.Text.Trim()))),
                New SqlParameter("@productId", ProductId),
                New SqlParameter("@vendorId", SessionManager.RoleId))

            ' Log inventory change if stock changed
            Dim stockDiff As Integer = newStock - oldStock
            If stockDiff <> 0 Then
                Dim logSql As String =
                    "INSERT INTO InventoryLogs (productId, changeQty, actionType)
                     VALUES (@productId, @changeQty, @actionType)"
                DataAccess.ExecuteNonQuery(logSql,
                    New SqlParameter("@productId", ProductId),
                    New SqlParameter("@changeQty", stockDiff),
                    New SqlParameter("@actionType",
                        If(stockDiff > 0, "Add", "Remove")))
            End If

            LogManager.Log(SessionManager.UserId, "EditProduct",
                "Updated product: " & txtProductName.Text.Trim())

            MessageBox.Show("Product updated successfully!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)

            ' Go back to manage products
            Dim dashboard As frmVendorDashboard =
                TryCast(Me.ParentForm, frmVendorDashboard)
            If dashboard IsNot Nothing Then
                dashboard.NavigateToManageProducts()
            End If

        Catch ex As Exception
            ShowError("Failed to update product: " & ex.Message)
        End Try
    End Sub

    ' -------------------------------------------------------
    ' Cancel — go back to manage products
    ' -------------------------------------------------------
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim dashboard As frmVendorDashboard =
            TryCast(Me.ParentForm, frmVendorDashboard)
        If dashboard IsNot Nothing Then
            dashboard.NavigateToManageProducts()
        End If
    End Sub

    ' -------------------------------------------------------
    ' Button hover
    ' -------------------------------------------------------
    Private Sub btnSave_MouseEnter(sender As Object, e As EventArgs) Handles btnSave.MouseEnter
        btnSave.BackColor = Color.FromArgb(193, 51, 51)
    End Sub
    Private Sub btnSave_MouseLeave(sender As Object, e As EventArgs) Handles btnSave.MouseLeave
        btnSave.BackColor = Color.FromArgb(219, 68, 68)
    End Sub

    ' -------------------------------------------------------
    ' Helper
    ' -------------------------------------------------------
    Private Sub ShowError(message As String)
        lblError.Text = message
    End Sub

End Class