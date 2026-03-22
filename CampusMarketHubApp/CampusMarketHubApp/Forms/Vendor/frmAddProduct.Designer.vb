<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddProduct
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        lblTitle = New Label()
        lblSubtitle = New Label()
        pnlForm = New Panel()
        lblProductName = New Label()
        txtProductName = New TextBox()
        pnlProductNameLine = New Panel()
        pnlPriceLine = New Panel()
        lblCategory = New Label()
        cboCategory = New ComboBox()
        txtPrice = New TextBox()
        lblPrice = New Label()
        txtStock = New TextBox()
        lblStock = New Label()
        pnlStockLine = New Panel()
        txtDescription = New TextBox()
        lblDescription = New Label()
        lblError = New Label()
        btnAddProduct = New Button()
        btnClear = New Button()
        pnlForm.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.ForeColor = Color.Black
        lblTitle.Location = New Point(0, 0)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(249, 38)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Add New Product"
        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.AutoSize = True
        lblSubtitle.Font = New Font("Segoe UI", 10F)
        lblSubtitle.ForeColor = Color.FromArgb(CByte(125), CByte(129), CByte(132))
        lblSubtitle.Location = New Point(0, 35)
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.Size = New Size(345, 23)
        lblSubtitle.TabIndex = 1
        lblSubtitle.Text = "Fill in the details below to list a new product"
        ' 
        ' pnlForm
        ' 
        pnlForm.BackColor = Color.White
        pnlForm.Controls.Add(btnClear)
        pnlForm.Controls.Add(btnAddProduct)
        pnlForm.Controls.Add(lblError)
        pnlForm.Controls.Add(txtDescription)
        pnlForm.Controls.Add(lblDescription)
        pnlForm.Controls.Add(txtStock)
        pnlForm.Controls.Add(lblStock)
        pnlForm.Controls.Add(pnlStockLine)
        pnlForm.Controls.Add(txtPrice)
        pnlForm.Controls.Add(lblPrice)
        pnlForm.Controls.Add(cboCategory)
        pnlForm.Controls.Add(pnlPriceLine)
        pnlForm.Controls.Add(lblCategory)
        pnlForm.Controls.Add(pnlProductNameLine)
        pnlForm.Controls.Add(txtProductName)
        pnlForm.Controls.Add(lblProductName)
        pnlForm.Location = New Point(0, 70)
        pnlForm.Name = "pnlForm"
        pnlForm.Padding = New Padding(24)
        pnlForm.Size = New Size(700, 520)
        pnlForm.TabIndex = 2
        ' 
        ' lblProductName
        ' 
        lblProductName.AutoSize = True
        lblProductName.ForeColor = Color.FromArgb(CByte(125), CByte(129), CByte(132))
        lblProductName.Location = New Point(24, 24)
        lblProductName.Name = "lblProductName"
        lblProductName.Size = New Size(104, 20)
        lblProductName.TabIndex = 0
        lblProductName.Text = "Product Name"
        ' 
        ' txtProductName
        ' 
        txtProductName.BackColor = Color.White
        txtProductName.BorderStyle = BorderStyle.None
        txtProductName.Font = New Font("Segoe UI", 10F)
        txtProductName.Location = New Point(24, 44)
        txtProductName.Name = "txtProductName"
        txtProductName.Size = New Size(620, 23)
        txtProductName.TabIndex = 1
        ' 
        ' pnlProductNameLine
        ' 
        pnlProductNameLine.BackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        pnlProductNameLine.Location = New Point(24, 75)
        pnlProductNameLine.Name = "pnlProductNameLine"
        pnlProductNameLine.Size = New Size(620, 1)
        pnlProductNameLine.TabIndex = 2
        ' 
        ' pnlPriceLine
        ' 
        pnlPriceLine.BackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        pnlPriceLine.Location = New Point(344, 146)
        pnlPriceLine.Name = "pnlPriceLine"
        pnlPriceLine.Size = New Size(300, 1)
        pnlPriceLine.TabIndex = 5
        ' 
        ' lblCategory
        ' 
        lblCategory.AutoSize = True
        lblCategory.ForeColor = Color.FromArgb(CByte(125), CByte(129), CByte(132))
        lblCategory.Location = New Point(24, 95)
        lblCategory.Name = "lblCategory"
        lblCategory.Size = New Size(69, 20)
        lblCategory.TabIndex = 3
        lblCategory.Text = "Category"
        ' 
        ' cboCategory
        ' 
        cboCategory.BackColor = Color.White
        cboCategory.DropDownStyle = ComboBoxStyle.DropDownList
        cboCategory.FlatStyle = FlatStyle.Flat
        cboCategory.Font = New Font("Segoe UI", 10F)
        cboCategory.FormattingEnabled = True
        cboCategory.Location = New Point(24, 115)
        cboCategory.Name = "cboCategory"
        cboCategory.Size = New Size(300, 31)
        cboCategory.TabIndex = 6
        ' 
        ' txtPrice
        ' 
        txtPrice.BackColor = Color.White
        txtPrice.BorderStyle = BorderStyle.None
        txtPrice.Font = New Font("Segoe UI", 10F)
        txtPrice.Location = New Point(344, 115)
        txtPrice.Name = "txtPrice"
        txtPrice.Size = New Size(300, 23)
        txtPrice.TabIndex = 8
        ' 
        ' lblPrice
        ' 
        lblPrice.AutoSize = True
        lblPrice.ForeColor = Color.FromArgb(CByte(125), CByte(129), CByte(132))
        lblPrice.Location = New Point(344, 95)
        lblPrice.Name = "lblPrice"
        lblPrice.Size = New Size(65, 20)
        lblPrice.TabIndex = 7
        lblPrice.Text = "Price (₦)"
        ' 
        ' txtStock
        ' 
        txtStock.BackColor = Color.White
        txtStock.BorderStyle = BorderStyle.None
        txtStock.Font = New Font("Segoe UI", 10F)
        txtStock.Location = New Point(24, 185)
        txtStock.Name = "txtStock"
        txtStock.Size = New Size(300, 23)
        txtStock.TabIndex = 11
        ' 
        ' lblStock
        ' 
        lblStock.AutoSize = True
        lblStock.ForeColor = Color.FromArgb(CByte(125), CByte(129), CByte(132))
        lblStock.Location = New Point(24, 165)
        lblStock.Name = "lblStock"
        lblStock.Size = New Size(105, 20)
        lblStock.TabIndex = 10
        lblStock.Text = "Stock Quantity"
        ' 
        ' pnlStockLine
        ' 
        pnlStockLine.BackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        pnlStockLine.Location = New Point(24, 216)
        pnlStockLine.Name = "pnlStockLine"
        pnlStockLine.Size = New Size(300, 1)
        pnlStockLine.TabIndex = 9
        ' 
        ' txtDescription
        ' 
        txtDescription.BackColor = Color.White
        txtDescription.BorderStyle = BorderStyle.FixedSingle
        txtDescription.Font = New Font("Segoe UI", 10F)
        txtDescription.Location = New Point(24, 255)
        txtDescription.Name = "txtDescription"
        txtDescription.ScrollBars = ScrollBars.Vertical
        txtDescription.Size = New Size(620, 30)
        txtDescription.TabIndex = 13
        ' 
        ' lblDescription
        ' 
        lblDescription.AutoSize = True
        lblDescription.ForeColor = Color.FromArgb(CByte(125), CByte(129), CByte(132))
        lblDescription.Location = New Point(24, 235)
        lblDescription.Name = "lblDescription"
        lblDescription.Size = New Size(155, 20)
        lblDescription.TabIndex = 12
        lblDescription.Text = "Description (optional)"
        ' 
        ' lblError
        ' 
        lblError.AutoSize = True
        lblError.ForeColor = Color.FromArgb(CByte(219), CByte(68), CByte(68))
        lblError.Location = New Point(24, 368)
        lblError.Name = "lblError"
        lblError.Size = New Size(0, 20)
        lblError.TabIndex = 14
        ' 
        ' btnAddProduct
        ' 
        btnAddProduct.BackColor = Color.FromArgb(CByte(219), CByte(68), CByte(68))
        btnAddProduct.Cursor = Cursors.Hand
        btnAddProduct.FlatAppearance.BorderSize = 0
        btnAddProduct.FlatStyle = FlatStyle.Flat
        btnAddProduct.Font = New Font("Segoe UI", 10F)
        btnAddProduct.ForeColor = Color.White
        btnAddProduct.Location = New Point(24, 395)
        btnAddProduct.Name = "btnAddProduct"
        btnAddProduct.Size = New Size(180, 44)
        btnAddProduct.TabIndex = 15
        btnAddProduct.Text = "Add Product"
        btnAddProduct.UseVisualStyleBackColor = False
        ' 
        ' btnClear
        ' 
        btnClear.Cursor = Cursors.Hand
        btnClear.FlatAppearance.BorderColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        btnClear.FlatStyle = FlatStyle.Flat
        btnClear.Font = New Font("Segoe UI", 10F)
        btnClear.ForeColor = Color.FromArgb(CByte(51), CByte(51), CByte(51))
        btnClear.Location = New Point(216, 395)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(120, 44)
        btnClear.TabIndex = 16
        btnClear.Text = "Clear"
        btnClear.UseVisualStyleBackColor = True
        ' 
        ' frmAddProduct
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.WhiteSmoke
        ClientSize = New Size(800, 589)
        Controls.Add(pnlForm)
        Controls.Add(lblSubtitle)
        Controls.Add(lblTitle)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmAddProduct"
        Text = "Add Product"
        pnlForm.ResumeLayout(False)
        pnlForm.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents pnlForm As Panel
    Friend WithEvents lblProductName As Label
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents lblPrice As Label
    Friend WithEvents cboCategory As ComboBox
    Friend WithEvents pnlPriceLine As Panel
    Friend WithEvents lblCategory As Label
    Friend WithEvents pnlProductNameLine As Panel
    Friend WithEvents txtProductName As TextBox
    Friend WithEvents lblError As Label
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents lblDescription As Label
    Friend WithEvents txtStock As TextBox
    Friend WithEvents lblStock As Label
    Friend WithEvents pnlStockLine As Panel
    Friend WithEvents btnClear As Button
    Friend WithEvents btnAddProduct As Button
End Class
