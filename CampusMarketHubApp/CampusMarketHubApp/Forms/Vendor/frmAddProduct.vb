Imports System.Data.SqlClient

Public Class frmAddProduct

    Private Sub frmAddProduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblError.Text = ""
        LoadCategories()
    End Sub

    ' -------------------------------------------------------
    ' Load categories from database into dropdown
    ' -------------------------------------------------------
    Private Sub LoadCategories()
        Try
            Dim sql As String = "SELECT categoryId, categoryName FROM Categories ORDER BY categoryName"
            Dim result As DataTable = DataAccess.ExecuteQuery(sql)

            cboCategory.Items.Clear()
            cboCategory.Items.Add("-- Select Category --")
            cboCategory.SelectedIndex = 0

            For Each row As DataRow In result.Rows
                cboCategory.Items.Add(New CategoryItem(CInt(row("categoryId")),
                                                        row("categoryName").ToString()))
            Next

        Catch ex As Exception
            ShowError("Failed to load categories: " & ex.Message)
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
    ' Only allow numeric input for price and stock
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
    ' Add Product Button
    ' -------------------------------------------------------
    Private Sub btnAddProduct_Click(sender As Object, e As EventArgs) Handles btnAddProduct.Click
        lblError.Text = ""

        ' Validate
        If String.IsNullOrWhiteSpace(txtProductName.Text) Then
            ShowError("Please enter a product name.") : Return
        End If

        If cboCategory.SelectedIndex = 0 Then
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

        Dim stock As Integer
        If Not Integer.TryParse(txtStock.Text, stock) OrElse stock < 0 Then
            ShowError("Please enter a valid stock quantity.") : Return
        End If

        ' Get selected category ID
        Dim selectedCategory As CategoryItem = CType(cboCategory.SelectedItem, CategoryItem)

        Try
            ' Insert product
            Dim sql As String =
                "INSERT INTO Products (vendorId, categoryId, productName, price, stockQty)
                 OUTPUT INSERTED.productId
                 VALUES (@vendorId, @categoryId, @productName, @price, @stockQty)"

            Dim newProductId As Integer = CInt(DataAccess.ExecuteScalar(sql,
                New SqlParameter("@vendorId", SessionManager.RoleId),
                New SqlParameter("@categoryId", selectedCategory.Id),
                New SqlParameter("@productName", txtProductName.Text.Trim()),
                New SqlParameter("@price", price),
                New SqlParameter("@stockQty", stock)))

            ' Log inventory addition
            Dim logSql As String =
                "INSERT INTO InventoryLogs (productId, changeQty, actionType)
                 VALUES (@productId, @changeQty, 'Add')"
            DataAccess.ExecuteNonQuery(logSql,
                New SqlParameter("@productId", newProductId),
                New SqlParameter("@changeQty", stock))

            ' Log activity
            LogManager.Log(SessionManager.UserId, "AddProduct",
                "Added product: " & txtProductName.Text.Trim())

            MessageBox.Show("Product added successfully!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)

            ClearForm()

        Catch ex As Exception
            ShowError("Failed to add product: " & ex.Message)
        End Try
    End Sub

    ' -------------------------------------------------------
    ' Clear form
    ' -------------------------------------------------------
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearForm()
    End Sub

    Private Sub ClearForm()
        txtProductName.Text = ""
        txtPrice.Text = ""
        txtStock.Text = ""
        txtDescription.Text = ""
        cboCategory.SelectedIndex = 0
        lblError.Text = ""
    End Sub

    ' -------------------------------------------------------
    ' Button hover effects
    ' -------------------------------------------------------
    Private Sub btnAddProduct_MouseEnter(sender As Object, e As EventArgs) Handles btnAddProduct.MouseEnter
        btnAddProduct.BackColor = Color.FromArgb(193, 51, 51)
    End Sub
    Private Sub btnAddProduct_MouseLeave(sender As Object, e As EventArgs) Handles btnAddProduct.MouseLeave
        btnAddProduct.BackColor = Color.FromArgb(219, 68, 68)
    End Sub

    ' -------------------------------------------------------
    ' Helper
    ' -------------------------------------------------------
    Private Sub ShowError(message As String)
        lblError.Text = message
    End Sub

End Class

' -------------------------------------------------------
' Helper class for ComboBox category items
' -------------------------------------------------------
Public Class CategoryItem
    Public Property Id As Integer
    Public Property Name As String

    Public Sub New(id As Integer, name As String)
        Me.Id = id
        Me.Name = name
    End Sub

    Public Overrides Function ToString() As String
        Return Name
    End Function
End Class