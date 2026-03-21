<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSignUp
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
        pnlLeft = New Panel()
        pnlFocus = New Panel()
        lblBrand = New Label()
        pnlRight = New Panel()
        lblLogin = New Label()
        lblLoginText = New Label()
        btnCreateAccount = New Button()
        lblError = New Label()
        cboRole = New ComboBox()
        lblRole = New Label()
        pnlPasswordLine = New Panel()
        txtPassword = New TextBox()
        pnlEmailLine = New Panel()
        txtEmail = New TextBox()
        pnlUsernameLine = New Panel()
        txtUsername = New TextBox()
        pnlFullNameLine = New Panel()
        txtFullName = New TextBox()
        lblSubtitle = New Label()
        lblTitle = New Label()
        lblShowPassword = New Label()
        pnlLeft.SuspendLayout()
        pnlRight.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlLeft
        ' 
        pnlLeft.Controls.Add(pnlFocus)
        pnlLeft.Controls.Add(lblBrand)
        pnlLeft.Location = New Point(0, 0)
        pnlLeft.Name = "pnlLeft"
        pnlLeft.Size = New Size(380, 650)
        pnlLeft.TabIndex = 0
        ' 
        ' pnlFocus
        ' 
        pnlFocus.Location = New Point(0, 0)
        pnlFocus.Name = "pnlFocus"
        pnlFocus.Size = New Size(1, 1)
        pnlFocus.TabIndex = 0
        ' 
        ' lblBrand
        ' 
        lblBrand.AutoSize = True
        lblBrand.Font = New Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblBrand.ForeColor = Color.FromArgb(CByte(219), CByte(68), CByte(68))
        lblBrand.Location = New Point(40, 40)
        lblBrand.Name = "lblBrand"
        lblBrand.Size = New Size(348, 46)
        lblBrand.TabIndex = 0
        lblBrand.Text = "Campus Market Hub"
        ' 
        ' pnlRight
        ' 
        pnlRight.BackColor = Color.White
        pnlRight.Controls.Add(lblShowPassword)
        pnlRight.Controls.Add(lblLogin)
        pnlRight.Controls.Add(lblLoginText)
        pnlRight.Controls.Add(btnCreateAccount)
        pnlRight.Controls.Add(lblError)
        pnlRight.Controls.Add(cboRole)
        pnlRight.Controls.Add(lblRole)
        pnlRight.Controls.Add(pnlPasswordLine)
        pnlRight.Controls.Add(txtPassword)
        pnlRight.Controls.Add(pnlEmailLine)
        pnlRight.Controls.Add(txtEmail)
        pnlRight.Controls.Add(pnlUsernameLine)
        pnlRight.Controls.Add(txtUsername)
        pnlRight.Controls.Add(pnlFullNameLine)
        pnlRight.Controls.Add(txtFullName)
        pnlRight.Controls.Add(lblSubtitle)
        pnlRight.Controls.Add(lblTitle)
        pnlRight.Location = New Point(380, 0)
        pnlRight.Name = "pnlRight"
        pnlRight.Size = New Size(520, 650)
        pnlRight.TabIndex = 1
        ' 
        ' lblLogin
        ' 
        lblLogin.AutoSize = True
        lblLogin.Cursor = Cursors.Hand
        lblLogin.Font = New Font("Segoe UI", 10F)
        lblLogin.ForeColor = Color.FromArgb(CByte(219), CByte(68), CByte(68))
        lblLogin.Location = New Point(275, 525)
        lblLogin.Name = "lblLogin"
        lblLogin.Size = New Size(58, 23)
        lblLogin.TabIndex = 12
        lblLogin.Text = "Log In"
        ' 
        ' lblLoginText
        ' 
        lblLoginText.AutoSize = True
        lblLoginText.Font = New Font("Segoe UI", 10F)
        lblLoginText.ForeColor = Color.FromArgb(CByte(125), CByte(129), CByte(132))
        lblLoginText.Location = New Point(60, 525)
        lblLoginText.Name = "lblLoginText"
        lblLoginText.Size = New Size(206, 23)
        lblLoginText.TabIndex = 11
        lblLoginText.Text = "Already have an account?"
        ' 
        ' btnCreateAccount
        ' 
        btnCreateAccount.BackColor = Color.FromArgb(CByte(219), CByte(68), CByte(68))
        btnCreateAccount.Cursor = Cursors.Hand
        btnCreateAccount.FlatAppearance.BorderSize = 0
        btnCreateAccount.FlatStyle = FlatStyle.Flat
        btnCreateAccount.Font = New Font("Segoe UI", 10F)
        btnCreateAccount.ForeColor = Color.White
        btnCreateAccount.Location = New Point(60, 460)
        btnCreateAccount.Name = "btnCreateAccount"
        btnCreateAccount.Size = New Size(360, 44)
        btnCreateAccount.TabIndex = 10
        btnCreateAccount.Text = "Create Account"
        btnCreateAccount.UseVisualStyleBackColor = False
        ' 
        ' lblError
        ' 
        lblError.AutoSize = True
        lblError.ForeColor = Color.FromArgb(CByte(219), CByte(68), CByte(68))
        lblError.Location = New Point(60, 438)
        lblError.Name = "lblError"
        lblError.Size = New Size(0, 20)
        lblError.TabIndex = 9
        ' 
        ' cboRole
        ' 
        cboRole.DropDownStyle = ComboBoxStyle.DropDownList
        cboRole.FlatStyle = FlatStyle.Flat
        cboRole.FormattingEnabled = True
        cboRole.Location = New Point(60, 400)
        cboRole.Name = "cboRole"
        cboRole.Size = New Size(360, 28)
        cboRole.TabIndex = 8
        ' 
        ' lblRole
        ' 
        lblRole.AutoSize = True
        lblRole.Font = New Font("Segoe UI", 10F)
        lblRole.ForeColor = Color.FromArgb(CByte(125), CByte(129), CByte(132))
        lblRole.Location = New Point(60, 378)
        lblRole.Name = "lblRole"
        lblRole.Size = New Size(82, 23)
        lblRole.TabIndex = 7
        lblRole.Text = "I want to:"
        ' 
        ' pnlPasswordLine
        ' 
        pnlPasswordLine.BackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        pnlPasswordLine.Location = New Point(60, 361)
        pnlPasswordLine.Name = "pnlPasswordLine"
        pnlPasswordLine.Size = New Size(360, 1)
        pnlPasswordLine.TabIndex = 6
        ' 
        ' txtPassword
        ' 
        txtPassword.BackColor = Color.White
        txtPassword.BorderStyle = BorderStyle.None
        txtPassword.Font = New Font("Segoe UI", 10F)
        txtPassword.Location = New Point(60, 330)
        txtPassword.Name = "txtPassword"
        txtPassword.PasswordChar = "*"c
        txtPassword.Size = New Size(360, 23)
        txtPassword.TabIndex = 6
        ' 
        ' pnlEmailLine
        ' 
        pnlEmailLine.BackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        pnlEmailLine.Location = New Point(60, 301)
        pnlEmailLine.Name = "pnlEmailLine"
        pnlEmailLine.Size = New Size(360, 1)
        pnlEmailLine.TabIndex = 5
        ' 
        ' txtEmail
        ' 
        txtEmail.BackColor = Color.White
        txtEmail.BorderStyle = BorderStyle.None
        txtEmail.Font = New Font("Segoe UI", 10F)
        txtEmail.Location = New Point(60, 270)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(360, 23)
        txtEmail.TabIndex = 5
        ' 
        ' pnlUsernameLine
        ' 
        pnlUsernameLine.BackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        pnlUsernameLine.Location = New Point(60, 241)
        pnlUsernameLine.Name = "pnlUsernameLine"
        pnlUsernameLine.Size = New Size(360, 1)
        pnlUsernameLine.TabIndex = 4
        ' 
        ' txtUsername
        ' 
        txtUsername.BackColor = Color.White
        txtUsername.BorderStyle = BorderStyle.None
        txtUsername.Font = New Font("Segoe UI", 10F)
        txtUsername.Location = New Point(60, 210)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(360, 23)
        txtUsername.TabIndex = 4
        ' 
        ' pnlFullNameLine
        ' 
        pnlFullNameLine.BackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        pnlFullNameLine.Location = New Point(60, 181)
        pnlFullNameLine.Name = "pnlFullNameLine"
        pnlFullNameLine.Size = New Size(360, 1)
        pnlFullNameLine.TabIndex = 3
        ' 
        ' txtFullName
        ' 
        txtFullName.BorderStyle = BorderStyle.None
        txtFullName.Font = New Font("Segoe UI", 10F)
        txtFullName.ForeColor = Color.White
        txtFullName.Location = New Point(60, 150)
        txtFullName.Name = "txtFullName"
        txtFullName.Size = New Size(360, 23)
        txtFullName.TabIndex = 2
        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.AutoSize = True
        lblSubtitle.Font = New Font("Segoe UI", 10F)
        lblSubtitle.ForeColor = Color.FromArgb(CByte(125), CByte(129), CByte(132))
        lblSubtitle.Location = New Point(60, 105)
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.Size = New Size(193, 23)
        lblSubtitle.TabIndex = 1
        lblSubtitle.Text = "Enter your details below"
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.ForeColor = Color.Black
        lblTitle.Location = New Point(60, 60)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(269, 41)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Create an account"
        ' 
        ' lblShowPassword
        ' 
        lblShowPassword.AutoSize = True
        lblShowPassword.Cursor = Cursors.Hand
        lblShowPassword.Font = New Font("Segoe UI", 12F)
        lblShowPassword.ForeColor = Color.FromArgb(CByte(125), CByte(129), CByte(132))
        lblShowPassword.Location = New Point(381, 325)
        lblShowPassword.Name = "lblShowPassword"
        lblShowPassword.Size = New Size(39, 28)
        lblShowPassword.TabIndex = 13
        lblShowPassword.Text = "👁"
        ' 
        ' frmSignUp
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.WhiteSmoke
        ClientSize = New Size(882, 647)
        Controls.Add(pnlRight)
        Controls.Add(pnlLeft)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmSignUp"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Campus Market Hub — Sign Up"
        pnlLeft.ResumeLayout(False)
        pnlLeft.PerformLayout()
        pnlRight.ResumeLayout(False)
        pnlRight.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlLeft As Panel
    Friend WithEvents lblBrand As Label
    Friend WithEvents pnlRight As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents pnlFullNameLine As Panel
    Friend WithEvents txtFullName As TextBox
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents pnlUsernameLine As Panel
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents pnlPasswordLine As Panel
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents pnlEmailLine As Panel
    Friend WithEvents btnCreateAccount As Button
    Friend WithEvents lblError As Label
    Friend WithEvents cboRole As ComboBox
    Friend WithEvents lblRole As Label
    Friend WithEvents lblLogin As Label
    Friend WithEvents lblLoginText As Label
    Friend WithEvents pnlFocus As Panel
    Friend WithEvents lblShowPassword As Label
End Class
