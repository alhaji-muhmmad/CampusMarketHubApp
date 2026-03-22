Imports System.Data.SqlClient

Public Class frmManageProducts

    Private Sub frmManageProducts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupGrid()
        LoadProducts()
        SetPlaceholder(txtSearch, "Search products...")
    End Sub

    ' -------------------------------------------------------
    ' Style the DataGridView
    ' -------------------------------------------------------
    Private Sub SetupGrid()
        dgvProducts.BackgroundColor = Color.White
        dgvProducts.BorderStyle = BorderStyle.None
        dgvProducts.GridColor = Color.FromArgb(224, 224, 224)
        dgvProducts.RowHeadersVisible = False
        dgvProducts.AllowUserToAddRows = False
        dgvProducts.AllowUserToDeleteRows = False
        dgvProducts.ReadOnly = True
        dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvProducts.MultiSelect = False

        ' Header style
        dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245)
        dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(51, 51, 51)
        dgvProducts.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        dgvProducts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        dgvProducts.ColumnHeadersHeight = 44
        dgvProducts.EnableHeadersVisualStyles = False

        ' Row style
        dgvProducts.DefaultCellStyle.BackColor = Color.White
        dgvProducts.DefaultCellStyle.ForeColor = Color.FromArgb(51, 51, 51)
        dgvProducts.DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        dgvProducts.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 235, 235)
        dgvProducts.DefaultCellStyle.SelectionForeColor = Color.FromArgb(51, 51, 51)
        dgvProducts.RowTemplate.Height = 44
        dgvProducts.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250)
    End Sub

    ' -------------------------------------------------------
    ' Load vendor's products
    ' -------------------------------------------------------
    Private Sub LoadProducts(Optional searchTerm As String = "")
        Try
            Dim sql As String =
                "SELECT p.productId, p.productName, c.categoryName,
                        p.price, p.stockQty, p.createdAt
                 FROM Products p
                 INNER JOIN Categories c ON p.categoryId = c.categoryId
                 WHERE p.vendorId = @vendorId"

            If Not String.IsNullOrWhiteSpace(searchTerm) Then
                sql &= " AND p.productName LIKE @search"
            End If

            sql &= " ORDER BY p.createdAt DESC"

            Dim params As New List(Of SqlParameter)
            params.Add(New SqlParameter("@vendorId", SessionManager.RoleId))

            If Not String.IsNullOrWhiteSpace(searchTerm) Then
                params.Add(New SqlParameter("@search", "%" & searchTerm & "%"))
            End If

            Dim result As DataTable = DataAccess.ExecuteQuery(sql, params.ToArray())

            dgvProducts.DataSource = result

            ' Rename columns for display
            If dgvProducts.Columns.Count > 0 Then
                dgvProducts.Columns("productId").Visible = False
                dgvProducts.Columns("productName").HeaderText = "Product Name"
                dgvProducts.Columns("categoryName").HeaderText = "Category"
                dgvProducts.Columns("price").HeaderText = "Price (₦)"
                dgvProducts.Columns("stockQty").HeaderText = "Stock"
                dgvProducts.Columns("createdAt").HeaderText = "Date Added"
                dgvProducts.Columns("createdAt").DefaultCellStyle.Format = "dd MMM yyyy"

                ' Set column widths
                dgvProducts.Columns("productName").FillWeight = 35
                dgvProducts.Columns("categoryName").FillWeight = 20
                dgvProducts.Columns("price").FillWeight = 15
                dgvProducts.Columns("stockQty").FillWeight = 10
                dgvProducts.Columns("createdAt").FillWeight = 20
            End If

            ' Add action buttons if not already added
            If Not dgvProducts.Columns.Contains("Edit") Then
                Dim editBtn As New DataGridViewButtonColumn()
                editBtn.Name = "Edit"
                editBtn.HeaderText = ""
                editBtn.Text = "Edit"
                editBtn.UseColumnTextForButtonValue = True
                editBtn.FillWeight = 8
                editBtn.DefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243)
                editBtn.DefaultCellStyle.ForeColor = Color.White
                editBtn.FlatStyle = FlatStyle.Flat
                dgvProducts.Columns.Add(editBtn)
            End If

            If Not dgvProducts.Columns.Contains("Delete") Then
                Dim deleteBtn As New DataGridViewButtonColumn()
                deleteBtn.Name = "Delete"
                deleteBtn.HeaderText = ""
                deleteBtn.Text = "Delete"
                deleteBtn.UseColumnTextForButtonValue = True
                deleteBtn.FillWeight = 8
                deleteBtn.DefaultCellStyle.BackColor = Color.FromArgb(219, 68, 68)
                deleteBtn.DefaultCellStyle.ForeColor = Color.White
                deleteBtn.FlatStyle = FlatStyle.Flat
                dgvProducts.Columns.Add(deleteBtn)
            End If

            ' Show product count
            lblSubtitle.Text = $"Manage your product listings  ({result.Rows.Count} products)"

        Catch ex As Exception
            MessageBox.Show("Failed to load products: " & ex.Message)
        End Try
    End Sub

    ' -------------------------------------------------------
    ' Handle Edit and Delete button clicks in grid
    ' -------------------------------------------------------
    Private Sub dgvProducts_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProducts.CellClick
        If e.RowIndex < 0 Then Return

        Dim productId As Integer = CInt(dgvProducts.Rows(e.RowIndex).Cells("productId").Value)
        Dim productName As String = dgvProducts.Rows(e.RowIndex).Cells("productName").Value.ToString()

        If e.ColumnIndex = dgvProducts.Columns("Edit").Index Then
            ' Open edit form
            Dim editForm As New frmEditProduct()
            editForm.ProductId = productId

            Dim dashboard As frmVendorDashboard =
            TryCast(Me.ParentForm, frmVendorDashboard)
            If dashboard IsNot Nothing Then
                dashboard.LoadChildForm(editForm)
            End If

        ElseIf e.ColumnIndex = dgvProducts.Columns("Delete").Index Then
            ' Confirm delete
            Dim confirm As DialogResult = MessageBox.Show(
            "Are you sure you want to delete """ & productName & """?" &
            vbNewLine & "This cannot be undone.",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning)

            If confirm = DialogResult.Yes Then
                DeleteProduct(productId, productName)
            End If
        End If
    End Sub

    ' -------------------------------------------------------
    ' Delete product
    ' -------------------------------------------------------
    Private Sub DeleteProduct(productId As Integer, productName As String)
        Try
            Dim sql As String = "DELETE FROM Products WHERE productId = @productId
                                 AND vendorId = @vendorId"
            DataAccess.ExecuteNonQuery(sql,
                New SqlParameter("@productId", productId),
                New SqlParameter("@vendorId", SessionManager.RoleId))

            LogManager.Log(SessionManager.UserId, "DeleteProduct",
                "Deleted product: " & productName)

            MessageBox.Show("Product deleted successfully.",
                            "Deleted",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)

            LoadProducts()

        Catch ex As Exception
            MessageBox.Show("Failed to delete product: " & ex.Message)
        End Try
    End Sub

    ' -------------------------------------------------------
    ' Search
    ' -------------------------------------------------------
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim term As String = txtSearch.Text.Trim()
        If term = "Search products..." Then term = ""
        LoadProducts(term)
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then btnSearch_Click(sender, e)
    End Sub

    ' -------------------------------------------------------
    ' Add New Product button — navigate to Add Product
    ' -------------------------------------------------------
    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        ' Navigate parent dashboard to Add Product
        Dim dashboard As frmVendorDashboard = TryCast(Me.ParentForm, frmVendorDashboard)
        If dashboard IsNot Nothing Then
            dashboard.NavigateToAddProduct()
        End If
    End Sub

    ' -------------------------------------------------------
    ' Placeholder helpers
    ' -------------------------------------------------------
    Private Sub SetPlaceholder(txt As TextBox, placeholder As String)
        If String.IsNullOrWhiteSpace(txt.Text) Then
            txt.Text = placeholder
            txt.ForeColor = Color.FromArgb(189, 189, 189)
        End If
    End Sub

    Private Sub txtSearch_Enter(sender As Object, e As EventArgs) Handles txtSearch.Enter
        If txtSearch.ForeColor = Color.FromArgb(189, 189, 189) Then
            txtSearch.Text = ""
            txtSearch.ForeColor = Color.FromArgb(51, 51, 51)
        End If
    End Sub

    Private Sub txtSearch_Leave(sender As Object, e As EventArgs) Handles txtSearch.Leave
        SetPlaceholder(txtSearch, "Search products...")
    End Sub

End Class