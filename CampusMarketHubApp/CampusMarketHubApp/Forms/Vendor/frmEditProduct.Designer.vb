<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditProduct
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
        lblCategory = New Label()
        cboCategory = New ComboBox()
        lblPrice = New Label()
        txtPrice = New TextBox()
        pnlPriceLine = New Panel()
        lblStock = New Label()
        txtStock = New TextBox()
        pnlStockLine = New Panel()
        Panel1 = New Panel()
        txtDescription = New TextBox()
        lblDescription = New Label()
        lblError = New Label()
        btnSave = New Button()
        btnCancel = New Button()
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
        lblTitle.Size = New Size(179, 38)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Edit Product"
        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.AutoSize = True
        lblSubtitle.Font = New Font("Segoe UI", 10F)
        lblSubtitle.ForeColor = Color.FromArgb(CByte(125), CByte(129), CByte(132))
        lblSubtitle.Location = New Point(0, 35)
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.Size = New Size(224, 23)
        lblSubtitle.TabIndex = 1
        lblSubtitle.Text = "Update your product details"
        ' 
        ' pnlForm
        ' 
        pnlForm.BackColor = Color.White
        pnlForm.Controls.Add(btnCancel)
        pnlForm.Controls.Add(btnSave)
        pnlForm.Controls.Add(lblError)
        pnlForm.Controls.Add(Panel1)
        pnlForm.Controls.Add(txtDescription)
        pnlForm.Controls.Add(lblDescription)
        pnlForm.Controls.Add(pnlStockLine)
        pnlForm.Controls.Add(txtStock)
        pnlForm.Controls.Add(lblStock)
        pnlForm.Controls.Add(pnlPriceLine)
        pnlForm.Controls.Add(txtPrice)
        pnlForm.Controls.Add(lblPrice)
        pnlForm.Controls.Add(cboCategory)
        pnlForm.Controls.Add(lblCategory)
        pnlForm.Controls.Add(pnlProductNameLine)
        pnlForm.Controls.Add(txtProductName)
        pnlForm.Controls.Add(lblProductName)
        pnlForm.Location = New Point(0, 70)
        pnlForm.Name = "pnlForm"
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
        cboCategory.FormattingEnabled = True
        cboCategory.Location = New Point(24, 115)
        cboCategory.Name = "cboCategory"
        cboCategory.Size = New Size(300, 28)
        cboCategory.TabIndex = 4
        ' 
        ' lblPrice
        ' 
        lblPrice.AutoSize = True
        lblPrice.ForeColor = Color.FromArgb(CByte(125), CByte(129), CByte(132))
        lblPrice.Location = New Point(344, 95)
        lblPrice.Name = "lblPrice"
        lblPrice.Size = New Size(65, 20)
        lblPrice.TabIndex = 5
        lblPrice.Text = "Price (₦)"
        ' 
        ' txtPrice
        ' 
        txtPrice.BackColor = Color.White
        txtPrice.BorderStyle = BorderStyle.None
        txtPrice.Font = New Font("Segoe UI", 10F)
        txtPrice.Location = New Point(344, 115)
        txtPrice.Name = "txtPrice"
        txtPrice.Size = New Size(300, 23)
        txtPrice.TabIndex = 6
        ' 
        ' pnlPriceLine
        ' 
        pnlPriceLine.BackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        pnlPriceLine.Location = New Point(344, 146)
        pnlPriceLine.Name = "pnlPriceLine"
        pnlPriceLine.Size = New Size(300, 1)
        pnlPriceLine.TabIndex = 7
        ' 
        ' lblStock
        ' 
        lblStock.AutoSize = True
        lblStock.ForeColor = Color.FromArgb(CByte(125), CByte(129), CByte(132))
        lblStock.Location = New Point(24, 165)
        lblStock.Name = "lblStock"
        lblStock.Size = New Size(105, 20)
        lblStock.TabIndex = 8
        lblStock.Text = "Stock Quantity"
        ' 
        ' txtStock
        ' 
        txtStock.BackColor = Color.White
        txtStock.BorderStyle = BorderStyle.None
        txtStock.Font = New Font("Segoe UI", 10F)
        txtStock.Location = New Point(24, 185)
        txtStock.Name = "txtStock"
        txtStock.Size = New Size(300, 23)
        txtStock.TabIndex = 9
        ' 
        ' pnlStockLine
        ' 
        pnlStockLine.BackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        pnlStockLine.Location = New Point(24, 216)
        pnlStockLine.Name = "pnlStockLine"
        pnlStockLine.Size = New Size(300, 1)
        pnlStockLine.TabIndex = 10
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        Panel1.Location = New Point(200, 285)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(300, 1)
        Panel1.TabIndex = 13
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
        txtDescription.TabIndex = 12
        ' 
        ' lblDescription
        ' 
        lblDescription.AutoSize = True
        lblDescription.ForeColor = Color.FromArgb(CByte(125), CByte(129), CByte(132))
        lblDescription.Location = New Point(24, 235)
        lblDescription.Name = "lblDescription"
        lblDescription.Size = New Size(155, 20)
        lblDescription.TabIndex = 11
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
        ' btnSave
        ' 
        btnSave.BackColor = Color.FromArgb(CByte(219), CByte(68), CByte(68))
        btnSave.Cursor = Cursors.Hand
        btnSave.FlatAppearance.BorderSize = 0
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.Font = New Font("Segoe UI", 10F)
        btnSave.ForeColor = Color.White
        btnSave.Location = New Point(24, 395)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(180, 44)
        btnSave.TabIndex = 15
        btnSave.Text = "Save Changes"
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' btnCancel
        ' 
        btnCancel.Cursor = Cursors.Hand
        btnCancel.FlatAppearance.BorderColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.Font = New Font("Segoe UI", 10F)
        btnCancel.ForeColor = Color.FromArgb(CByte(51), CByte(51), CByte(51))
        btnCancel.Location = New Point(216, 395)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(120, 44)
        btnCancel.TabIndex = 16
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' frmEditProduct
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.WhiteSmoke
        ClientSize = New Size(800, 590)
        Controls.Add(pnlForm)
        Controls.Add(lblSubtitle)
        Controls.Add(lblTitle)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmEditProduct"
        Text = "Edit Product"
        pnlForm.ResumeLayout(False)
        pnlForm.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents pnlForm As Panel
    Friend WithEvents lblPrice As Label
    Friend WithEvents cboCategory As ComboBox
    Friend WithEvents lblCategory As Label
    Friend WithEvents pnlProductNameLine As Panel
    Friend WithEvents txtProductName As TextBox
    Friend WithEvents lblProductName As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents lblDescription As Label
    Friend WithEvents pnlStockLine As Panel
    Friend WithEvents txtStock As TextBox
    Friend WithEvents lblStock As Label
    Friend WithEvents pnlPriceLine As Panel
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents lblError As Label
End Class
