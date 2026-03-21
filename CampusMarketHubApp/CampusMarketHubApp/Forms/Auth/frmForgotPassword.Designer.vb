<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmForgotPassword
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
        lblTitle = New Label()
        lblSubtitle = New Label()
        txtUsername = New TextBox()
        pnlUsernameLine = New Panel()
        txtEmail = New TextBox()
        pnlEmailLine = New Panel()
        lblError = New Label()
        btnSendCode = New Button()
        lblBackToLogin = New Label()
        pnlLeft.SuspendLayout()
        pnlRight.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlLeft
        ' 
        pnlLeft.BackColor = Color.WhiteSmoke
        pnlLeft.Controls.Add(lblBrand)
        pnlLeft.Location = New Point(0, 0)
        pnlLeft.Name = "pnlLeft"
        pnlLeft.Size = New Size(380, 560)
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
        pnlRight.Controls.Add(lblBackToLogin)
        pnlRight.Controls.Add(btnSendCode)
        pnlRight.Controls.Add(lblError)
        pnlRight.Controls.Add(pnlEmailLine)
        pnlRight.Controls.Add(txtEmail)
        pnlRight.Controls.Add(pnlUsernameLine)
        pnlRight.Controls.Add(txtUsername)
        pnlRight.Controls.Add(lblSubtitle)
        pnlRight.Controls.Add(lblTitle)
        pnlRight.Location = New Point(380, 0)
        pnlRight.Name = "pnlRight"
        pnlRight.Size = New Size(520, 560)
        pnlRight.TabIndex = 1
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.ForeColor = Color.Black
        lblTitle.Location = New Point(60, 60)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(340, 41)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Forgot your password?"
        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.AutoSize = True
        lblSubtitle.Font = New Font("Segoe UI", 10F)
        lblSubtitle.ForeColor = Color.FromArgb(CByte(125), CByte(129), CByte(132))
        lblSubtitle.Location = New Point(60, 105)
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.Size = New Size(312, 23)
        lblSubtitle.TabIndex = 1
        lblSubtitle.Text = "Enter your username and email address"
        ' 
        ' txtUsername
        ' 
        txtUsername.BorderStyle = BorderStyle.None
        txtUsername.Font = New Font("Segoe UI", 10F)
        txtUsername.ForeColor = Color.Black
        txtUsername.Location = New Point(60, 155)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(360, 23)
        txtUsername.TabIndex = 2
        ' 
        ' pnlUsernameLine
        ' 
        pnlUsernameLine.BackColor = Color.FromArgb(CByte(125), CByte(129), CByte(132))
        pnlUsernameLine.ForeColor = SystemColors.Window
        pnlUsernameLine.Location = New Point(60, 186)
        pnlUsernameLine.Name = "pnlUsernameLine"
        pnlUsernameLine.Size = New Size(360, 1)
        pnlUsernameLine.TabIndex = 3
        ' 
        ' txtEmail
        ' 
        txtEmail.BorderStyle = BorderStyle.None
        txtEmail.Font = New Font("Segoe UI", 10F)
        txtEmail.ForeColor = Color.Black
        txtEmail.Location = New Point(60, 215)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(360, 23)
        txtEmail.TabIndex = 4
        ' 
        ' pnlEmailLine
        ' 
        pnlEmailLine.BackColor = Color.FromArgb(CByte(125), CByte(129), CByte(132))
        pnlEmailLine.ForeColor = SystemColors.Window
        pnlEmailLine.Location = New Point(60, 246)
        pnlEmailLine.Name = "pnlEmailLine"
        pnlEmailLine.Size = New Size(360, 1)
        pnlEmailLine.TabIndex = 4
        ' 
        ' lblError
        ' 
        lblError.AutoSize = True
        lblError.ForeColor = Color.FromArgb(CByte(219), CByte(68), CByte(68))
        lblError.Location = New Point(60, 260)
        lblError.Name = "lblError"
        lblError.Size = New Size(0, 20)
        lblError.TabIndex = 5
        ' 
        ' btnSendCode
        ' 
        btnSendCode.BackColor = Color.FromArgb(CByte(219), CByte(68), CByte(68))
        btnSendCode.Cursor = Cursors.Hand
        btnSendCode.FlatAppearance.BorderSize = 0
        btnSendCode.FlatStyle = FlatStyle.Flat
        btnSendCode.Font = New Font("Segoe UI", 10F)
        btnSendCode.ForeColor = Color.White
        btnSendCode.Location = New Point(60, 285)
        btnSendCode.Name = "btnSendCode"
        btnSendCode.Size = New Size(360, 44)
        btnSendCode.TabIndex = 6
        btnSendCode.Text = "Send Reset Code"
        btnSendCode.UseVisualStyleBackColor = False
        ' 
        ' lblBackToLogin
        ' 
        lblBackToLogin.AutoSize = True
        lblBackToLogin.Cursor = Cursors.Hand
        lblBackToLogin.Font = New Font("Segoe UI", 10F)
        lblBackToLogin.ForeColor = Color.FromArgb(CByte(125), CByte(129), CByte(132))
        lblBackToLogin.Location = New Point(165, 345)
        lblBackToLogin.Name = "lblBackToLogin"
        lblBackToLogin.Size = New Size(113, 23)
        lblBackToLogin.TabIndex = 7
        lblBackToLogin.Text = "Back to Login"
        ' 
        ' frmForgotPassword
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(882, 557)
        Controls.Add(pnlRight)
        Controls.Add(pnlLeft)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmForgotPassword"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Campus Market Hub — Forgot Password"
        pnlLeft.ResumeLayout(False)
        pnlLeft.PerformLayout()
        pnlRight.ResumeLayout(False)
        pnlRight.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlLeft As Panel
    Friend WithEvents lblBrand As Label
    Friend WithEvents pnlRight As Panel
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents pnlEmailLine As Panel
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents pnlUsernameLine As Panel
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents lblBackToLogin As Label
    Friend WithEvents btnSendCode As Button
    Friend WithEvents lblError As Label
End Class
