<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
        lblBrand = New Label()
        pnlRight = New Panel()
        lblShowPassword = New Label()
        lblSignUp = New Label()
        lblSignUpText = New Label()
        lblForgotPassword = New Label()
        btnLogin = New Button()
        lblError = New Label()
        pnlPasswordLine = New Panel()
        txtPassword = New TextBox()
        pnlUsernameLine = New Panel()
        txtUsername = New TextBox()
        lblSubtitle = New Label()
        lblTitle = New Label()
        pnlLeft.SuspendLayout()
        pnlRight.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlLeft
        ' 
        pnlLeft.Controls.Add(lblBrand)
        pnlLeft.Location = New Point(0, 0)
        pnlLeft.Name = "pnlLeft"
        pnlLeft.Size = New Size(380, 600)
        pnlLeft.TabIndex = 0
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
        pnlRight.Controls.Add(lblSignUp)
        pnlRight.Controls.Add(lblSignUpText)
        pnlRight.Controls.Add(lblForgotPassword)
        pnlRight.Controls.Add(btnLogin)
        pnlRight.Controls.Add(lblError)
        pnlRight.Controls.Add(pnlPasswordLine)
        pnlRight.Controls.Add(txtPassword)
        pnlRight.Controls.Add(pnlUsernameLine)
        pnlRight.Controls.Add(txtUsername)
        pnlRight.Controls.Add(lblSubtitle)
        pnlRight.Controls.Add(lblTitle)
        pnlRight.Location = New Point(380, 0)
        pnlRight.Name = "pnlRight"
        pnlRight.Size = New Size(520, 600)
        pnlRight.TabIndex = 1
        ' 
        ' lblShowPassword
        ' 
        lblShowPassword.AutoSize = True
        lblShowPassword.Cursor = Cursors.Hand
        lblShowPassword.Font = New Font("Segoe UI", 12F)
        lblShowPassword.ForeColor = Color.FromArgb(CByte(125), CByte(129), CByte(132))
        lblShowPassword.Location = New Point(381, 250)
        lblShowPassword.Name = "lblShowPassword"
        lblShowPassword.Size = New Size(39, 28)
        lblShowPassword.TabIndex = 11
        lblShowPassword.Text = "👁"
        ' 
        ' lblSignUp
        ' 
        lblSignUp.AutoSize = True
        lblSignUp.Cursor = Cursors.Hand
        lblSignUp.Font = New Font("Segoe UI", 10F)
        lblSignUp.ForeColor = Color.FromArgb(CByte(219), CByte(68), CByte(68))
        lblSignUp.Location = New Point(255, 391)
        lblSignUp.Name = "lblSignUp"
        lblSignUp.Size = New Size(70, 23)
        lblSignUp.TabIndex = 10
        lblSignUp.Text = "Sign Up"
        ' 
        ' lblSignUpText
        ' 
        lblSignUpText.AutoSize = True
        lblSignUpText.Font = New Font("Segoe UI", 10F)
        lblSignUpText.ForeColor = Color.FromArgb(CByte(125), CByte(129), CByte(132))
        lblSignUpText.Location = New Point(60, 391)
        lblSignUpText.Name = "lblSignUpText"
        lblSignUpText.Size = New Size(191, 23)
        lblSignUpText.TabIndex = 9
        lblSignUpText.Text = "Don't have an account?"
        ' 
        ' lblForgotPassword
        ' 
        lblForgotPassword.AutoSize = True
        lblForgotPassword.Cursor = Cursors.Hand
        lblForgotPassword.Font = New Font("Segoe UI", 10F)
        lblForgotPassword.ForeColor = Color.FromArgb(CByte(219), CByte(68), CByte(68))
        lblForgotPassword.Location = New Point(260, 343)
        lblForgotPassword.Name = "lblForgotPassword"
        lblForgotPassword.Size = New Size(143, 23)
        lblForgotPassword.TabIndex = 8
        lblForgotPassword.Text = "Forgot Password?"
        ' 
        ' btnLogin
        ' 
        btnLogin.BackColor = Color.FromArgb(CByte(219), CByte(68), CByte(68))
        btnLogin.Cursor = Cursors.Hand
        btnLogin.FlatAppearance.BorderSize = 0
        btnLogin.FlatStyle = FlatStyle.Flat
        btnLogin.Font = New Font("Segoe UI", 10F)
        btnLogin.ForeColor = Color.White
        btnLogin.Location = New Point(60, 330)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(170, 44)
        btnLogin.TabIndex = 7
        btnLogin.Text = "Log In"
        btnLogin.UseVisualStyleBackColor = False
        ' 
        ' lblError
        ' 
        lblError.AutoSize = True
        lblError.ForeColor = Color.FromArgb(CByte(219), CByte(68), CByte(68))
        lblError.Location = New Point(60, 300)
        lblError.Name = "lblError"
        lblError.Size = New Size(0, 20)
        lblError.TabIndex = 6
        ' 
        ' pnlPasswordLine
        ' 
        pnlPasswordLine.BackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        pnlPasswordLine.ForeColor = SystemColors.Window
        pnlPasswordLine.Location = New Point(60, 286)
        pnlPasswordLine.Name = "pnlPasswordLine"
        pnlPasswordLine.Size = New Size(360, 1)
        pnlPasswordLine.TabIndex = 5
        ' 
        ' txtPassword
        ' 
        txtPassword.BackColor = Color.White
        txtPassword.BorderStyle = BorderStyle.None
        txtPassword.Font = New Font("Segoe UI", 10F)
        txtPassword.Location = New Point(60, 255)
        txtPassword.Name = "txtPassword"
        txtPassword.PasswordChar = "*"c
        txtPassword.Size = New Size(360, 23)
        txtPassword.TabIndex = 4
        ' 
        ' pnlUsernameLine
        ' 
        pnlUsernameLine.BackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        pnlUsernameLine.Location = New Point(60, 216)
        pnlUsernameLine.Name = "pnlUsernameLine"
        pnlUsernameLine.Size = New Size(360, 1)
        pnlUsernameLine.TabIndex = 3
        ' 
        ' txtUsername
        ' 
        txtUsername.BackColor = Color.White
        txtUsername.BorderStyle = BorderStyle.None
        txtUsername.Font = New Font("Segoe UI", 10F)
        txtUsername.Location = New Point(60, 185)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(360, 23)
        txtUsername.TabIndex = 2
        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.AutoSize = True
        lblSubtitle.Font = New Font("Segoe UI", 10F)
        lblSubtitle.ForeColor = Color.FromArgb(CByte(125), CByte(129), CByte(132))
        lblSubtitle.Location = New Point(60, 130)
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
        lblTitle.Location = New Point(60, 80)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(441, 41)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Log in to Campus Market Hub"
        ' 
        ' frmLogin
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.WhiteSmoke
        ClientSize = New Size(882, 598)
        Controls.Add(pnlRight)
        Controls.Add(pnlLeft)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmLogin"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Campus Market Hub — Login"
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
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents pnlPasswordLine As Panel
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents pnlUsernameLine As Panel
    Friend WithEvents btnLogin As Button
    Friend WithEvents lblError As Label
    Friend WithEvents lblForgotPassword As Label
    Friend WithEvents lblSignUp As Label
    Friend WithEvents lblSignUpText As Label
    Friend WithEvents lblShowPassword As Label
End Class
