<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmResetPassword
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
        pnlRight = New Panel()
        lblBackToLogin = New Label()
        btnReset = New Button()
        lblError = New Label()
        lblShowConfirmPassword = New Label()
        pnlConfirmPasswordLine = New Panel()
        txtConfirmPassword = New TextBox()
        lblShowNewPassword = New Label()
        pnlNewPasswordLine = New Panel()
        pnlCodeLine = New Panel()
        txtNewPassword = New TextBox()
        txtCode = New TextBox()
        lblEmail = New Label()
        lblSubtitle = New Label()
        lblTitle = New Label()
        pnlLeft = New Panel()
        lblBrand = New Label()
        pnlRight.SuspendLayout()
        pnlLeft.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlRight
        ' 
        pnlRight.BackColor = Color.White
        pnlRight.Controls.Add(lblBackToLogin)
        pnlRight.Controls.Add(btnReset)
        pnlRight.Controls.Add(lblError)
        pnlRight.Controls.Add(lblShowConfirmPassword)
        pnlRight.Controls.Add(pnlConfirmPasswordLine)
        pnlRight.Controls.Add(txtConfirmPassword)
        pnlRight.Controls.Add(lblShowNewPassword)
        pnlRight.Controls.Add(pnlNewPasswordLine)
        pnlRight.Controls.Add(pnlCodeLine)
        pnlRight.Controls.Add(txtNewPassword)
        pnlRight.Controls.Add(txtCode)
        pnlRight.Controls.Add(lblEmail)
        pnlRight.Controls.Add(lblSubtitle)
        pnlRight.Controls.Add(lblTitle)
        pnlRight.Location = New Point(380, 0)
        pnlRight.Name = "pnlRight"
        pnlRight.Size = New Size(520, 580)
        pnlRight.TabIndex = 0
        ' 
        ' lblBackToLogin
        ' 
        lblBackToLogin.AutoSize = True
        lblBackToLogin.Font = New Font("Segoe UI", 10F)
        lblBackToLogin.ForeColor = Color.FromArgb(CByte(125), CByte(129), CByte(132))
        lblBackToLogin.Location = New Point(165, 405)
        lblBackToLogin.Name = "lblBackToLogin"
        lblBackToLogin.Size = New Size(113, 23)
        lblBackToLogin.TabIndex = 14
        lblBackToLogin.Text = "Back to Login"
        ' 
        ' btnReset
        ' 
        btnReset.BackColor = Color.FromArgb(CByte(219), CByte(68), CByte(68))
        btnReset.Cursor = Cursors.Hand
        btnReset.FlatAppearance.BorderSize = 0
        btnReset.FlatStyle = FlatStyle.Flat
        btnReset.Font = New Font("Segoe UI", 10F)
        btnReset.ForeColor = Color.White
        btnReset.Location = New Point(60, 345)
        btnReset.Name = "btnReset"
        btnReset.Size = New Size(360, 44)
        btnReset.TabIndex = 13
        btnReset.Text = "Reset Password"
        btnReset.UseVisualStyleBackColor = False
        ' 
        ' lblError
        ' 
        lblError.AutoSize = True
        lblError.ForeColor = Color.FromArgb(CByte(219), CByte(68), CByte(68))
        lblError.Location = New Point(60, 325)
        lblError.Name = "lblError"
        lblError.Size = New Size(0, 20)
        lblError.TabIndex = 12
        ' 
        ' lblShowConfirmPassword
        ' 
        lblShowConfirmPassword.AutoSize = True
        lblShowConfirmPassword.Cursor = Cursors.Hand
        lblShowConfirmPassword.Font = New Font("Segoe UI", 12F)
        lblShowConfirmPassword.ForeColor = Color.FromArgb(CByte(125), CByte(129), CByte(132))
        lblShowConfirmPassword.Location = New Point(390, 283)
        lblShowConfirmPassword.Name = "lblShowConfirmPassword"
        lblShowConfirmPassword.Size = New Size(39, 28)
        lblShowConfirmPassword.TabIndex = 11
        lblShowConfirmPassword.Text = "👁"
        ' 
        ' pnlConfirmPasswordLine
        ' 
        pnlConfirmPasswordLine.BackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        pnlConfirmPasswordLine.Location = New Point(60, 311)
        pnlConfirmPasswordLine.Name = "pnlConfirmPasswordLine"
        pnlConfirmPasswordLine.Size = New Size(360, 1)
        pnlConfirmPasswordLine.TabIndex = 10
        ' 
        ' txtConfirmPassword
        ' 
        txtConfirmPassword.BorderStyle = BorderStyle.None
        txtConfirmPassword.Font = New Font("Segoe UI", 10F)
        txtConfirmPassword.ForeColor = Color.FromArgb(CByte(51), CByte(51), CByte(51))
        txtConfirmPassword.Location = New Point(60, 280)
        txtConfirmPassword.Name = "txtConfirmPassword"
        txtConfirmPassword.Size = New Size(360, 23)
        txtConfirmPassword.TabIndex = 9
        ' 
        ' lblShowNewPassword
        ' 
        lblShowNewPassword.AutoSize = True
        lblShowNewPassword.Cursor = Cursors.Hand
        lblShowNewPassword.Font = New Font("Segoe UI", 12F)
        lblShowNewPassword.ForeColor = Color.FromArgb(CByte(125), CByte(129), CByte(132))
        lblShowNewPassword.Location = New Point(390, 228)
        lblShowNewPassword.Name = "lblShowNewPassword"
        lblShowNewPassword.Size = New Size(39, 28)
        lblShowNewPassword.TabIndex = 8
        lblShowNewPassword.Text = "👁"
        ' 
        ' pnlNewPasswordLine
        ' 
        pnlNewPasswordLine.BackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        pnlNewPasswordLine.Location = New Point(60, 256)
        pnlNewPasswordLine.Name = "pnlNewPasswordLine"
        pnlNewPasswordLine.Size = New Size(360, 1)
        pnlNewPasswordLine.TabIndex = 7
        ' 
        ' pnlCodeLine
        ' 
        pnlCodeLine.BackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        pnlCodeLine.Location = New Point(60, 201)
        pnlCodeLine.Name = "pnlCodeLine"
        pnlCodeLine.Size = New Size(360, 1)
        pnlCodeLine.TabIndex = 6
        ' 
        ' txtNewPassword
        ' 
        txtNewPassword.BorderStyle = BorderStyle.None
        txtNewPassword.Font = New Font("Segoe UI", 10F)
        txtNewPassword.ForeColor = Color.FromArgb(CByte(51), CByte(51), CByte(51))
        txtNewPassword.Location = New Point(60, 225)
        txtNewPassword.Name = "txtNewPassword"
        txtNewPassword.Size = New Size(360, 23)
        txtNewPassword.TabIndex = 5
        ' 
        ' txtCode
        ' 
        txtCode.BorderStyle = BorderStyle.None
        txtCode.Font = New Font("Segoe UI", 14F)
        txtCode.ForeColor = Color.FromArgb(CByte(51), CByte(51), CByte(51))
        txtCode.Location = New Point(60, 165)
        txtCode.MaxLength = 6
        txtCode.Name = "txtCode"
        txtCode.Size = New Size(360, 32)
        txtCode.TabIndex = 3
        txtCode.TextAlign = HorizontalAlignment.Center
        ' 
        ' lblEmail
        ' 
        lblEmail.AutoSize = True
        lblEmail.Font = New Font("Segoe UI", 10F)
        lblEmail.ForeColor = Color.FromArgb(CByte(51), CByte(51), CByte(51))
        lblEmail.Location = New Point(60, 128)
        lblEmail.Name = "lblEmail"
        lblEmail.Size = New Size(0, 23)
        lblEmail.TabIndex = 2
        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.AutoSize = True
        lblSubtitle.Font = New Font("Segoe UI", 10F)
        lblSubtitle.ForeColor = Color.FromArgb(CByte(125), CByte(129), CByte(132))
        lblSubtitle.Location = New Point(60, 105)
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.Size = New Size(291, 23)
        lblSubtitle.TabIndex = 1
        lblSubtitle.Text = "Enter the code we sent to your email"
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.ForeColor = Color.Black
        lblTitle.Location = New Point(60, 60)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(308, 41)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Reset your password"
        ' 
        ' pnlLeft
        ' 
        pnlLeft.BackColor = Color.WhiteSmoke
        pnlLeft.Controls.Add(lblBrand)
        pnlLeft.Location = New Point(0, 0)
        pnlLeft.Name = "pnlLeft"
        pnlLeft.Size = New Size(380, 577)
        pnlLeft.TabIndex = 1
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
        ' frmResetPassword
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.WhiteSmoke
        ClientSize = New Size(882, 577)
        Controls.Add(pnlLeft)
        Controls.Add(pnlRight)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmResetPassword"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Campus Market Hub — Reset Password"
        pnlRight.ResumeLayout(False)
        pnlRight.PerformLayout()
        pnlLeft.ResumeLayout(False)
        pnlLeft.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlRight As Panel
    Friend WithEvents txtCode As TextBox
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents pnlLeft As Panel
    Friend WithEvents lblBrand As Label
    Friend WithEvents pnlCodeLine As Panel
    Friend WithEvents txtNewPassword As TextBox
    Friend WithEvents btnReset As Button
    Friend WithEvents lblError As Label
    Friend WithEvents lblShowConfirmPassword As Label
    Friend WithEvents pnlConfirmPasswordLine As Panel
    Friend WithEvents txtConfirmPassword As TextBox
    Friend WithEvents lblShowNewPassword As Label
    Friend WithEvents pnlNewPasswordLine As Panel
    Friend WithEvents lblBackToLogin As Label
End Class
