<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageProducts
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
        txtSearch = New TextBox()
        btnSearch = New Button()
        btnAddNew = New Button()
        dgvProducts = New DataGridView()
        CType(dgvProducts, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.ForeColor = Color.Black
        lblTitle.Location = New Point(0, 0)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(182, 38)
        lblTitle.TabIndex = 0
        lblTitle.Text = "My Products"
        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.AutoSize = True
        lblSubtitle.Font = New Font("Segoe UI", 10F)
        lblSubtitle.ForeColor = Color.FromArgb(CByte(125), CByte(129), CByte(132))
        lblSubtitle.Location = New Point(0, 35)
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.Size = New Size(233, 23)
        lblSubtitle.TabIndex = 1
        lblSubtitle.Text = "Manage your product listings"
        ' 
        ' txtSearch
        ' 
        txtSearch.BackColor = Color.White
        txtSearch.BorderStyle = BorderStyle.FixedSingle
        txtSearch.Font = New Font("Segoe UI", 10F)
        txtSearch.Location = New Point(0, 75)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(280, 30)
        txtSearch.TabIndex = 2
        ' 
        ' btnSearch
        ' 
        btnSearch.BackColor = Color.FromArgb(CByte(219), CByte(68), CByte(68))
        btnSearch.Cursor = Cursors.Hand
        btnSearch.FlatAppearance.BorderSize = 0
        btnSearch.FlatStyle = FlatStyle.Flat
        btnSearch.ForeColor = Color.White
        btnSearch.Location = New Point(288, 74)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(100, 32)
        btnSearch.TabIndex = 3
        btnSearch.Text = "Search"
        btnSearch.UseVisualStyleBackColor = False
        ' 
        ' btnAddNew
        ' 
        btnAddNew.BackColor = Color.White
        btnAddNew.Cursor = Cursors.Hand
        btnAddNew.FlatAppearance.BorderColor = Color.FromArgb(CByte(219), CByte(68), CByte(68))
        btnAddNew.FlatStyle = FlatStyle.Flat
        btnAddNew.ForeColor = Color.FromArgb(CByte(219), CByte(68), CByte(68))
        btnAddNew.Location = New Point(540, 74)
        btnAddNew.Name = "btnAddNew"
        btnAddNew.Size = New Size(160, 32)
        btnAddNew.TabIndex = 4
        btnAddNew.Text = "+ Add New Product"
        btnAddNew.UseVisualStyleBackColor = False
        ' 
        ' dgvProducts
        ' 
        dgvProducts.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvProducts.Location = New Point(0, 120)
        dgvProducts.Name = "dgvProducts"
        dgvProducts.RowHeadersWidth = 51
        dgvProducts.Size = New Size(1258, 802)
        dgvProducts.TabIndex = 5
        ' 
        ' frmManageProducts
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.WhiteSmoke
        ClientSize = New Size(1158, 802)
        Controls.Add(dgvProducts)
        Controls.Add(btnAddNew)
        Controls.Add(btnSearch)
        Controls.Add(txtSearch)
        Controls.Add(lblSubtitle)
        Controls.Add(lblTitle)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmManageProducts"
        Text = "v"
        CType(dgvProducts, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnAddNew As Button
    Friend WithEvents dgvProducts As DataGridView
End Class
