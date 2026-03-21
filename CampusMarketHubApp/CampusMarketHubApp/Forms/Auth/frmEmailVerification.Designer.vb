<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmailVerification
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
        components = New ComponentModel.Container()
        pnlLeft = New Panel()
        lblBrand = New Label()
        pnlRight = New Panel()
        lblTitle = New Label()
        lblSubtitle = New Label()
        lblEmail = New Label()
        txtCode = New TextBox()
        pnlCodeLine = New Panel()
        lblTimer = New Label()
        lblError = New Label()
        btnVerify = New Button()
        lblResend = New Label()
        lblResendLink = New Label()
        tmrCountdown = New Timer(components)
        pnlLeft.SuspendLayout()
        pnlRight.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlLeft
        ' 
        pnlLeft.Controls.Add(lblBrand)
        pnlLeft.Location = New Point(0, 0)
        pnlLeft.Name = "pnlLeft"
        pnlLeft.Size = New Size(380, 580)
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
        pnlRight.Controls.Add(lblResendLink)
        pnlRight.Controls.Add(lblResend)
        pnlRight.Controls.Add(btnVerify)
        pnlRight.Controls.Add(lblError)
        pnlRight.Controls.Add(lblTimer)
        pnlRight.Controls.Add(pnlCodeLine)
        pnlRight.Controls.Add(txtCode)
        pnlRight.Controls.Add(lblEmail)
        pnlRight.Controls.Add(lblSubtitle)
        pnlRight.Controls.Add(lblTitle)
        pnlRight.Location = New Point(380, 0)
        pnlRight.Name = "pnlRight"
        pnlRight.Size = New Size(520, 580)
        pnlRight.TabIndex = 1
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.ForeColor = Color.Black
        lblTitle.Location = New Point(60, 60)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(259, 41)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Verify your email"
        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.AutoSize = True
        lblSubtitle.Font = New Font("Segoe UI", 10F)
        lblSubtitle.ForeColor = Color.FromArgb(CByte(125), CByte(129), CByte(132))
        lblSubtitle.Location = New Point(60, 105)
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.Size = New Size(288, 23)
        lblSubtitle.TabIndex = 1
        lblSubtitle.Text = "We sent a 6-digit code to your email"
        ' 
        ' lblEmail
        ' 
        lblEmail.AutoSize = True
        lblEmail.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblEmail.ForeColor = Color.FromArgb(CByte(51), CByte(51), CByte(51))
        lblEmail.Location = New Point(60, 128)
        lblEmail.Name = "lblEmail"
        lblEmail.Size = New Size(0, 23)
        lblEmail.TabIndex = 2
        ' 
        ' txtCode
        ' 
        txtCode.BackColor = Color.White
        txtCode.BorderStyle = BorderStyle.None
        txtCode.Font = New Font("Segoe UI", 18F)
        txtCode.Location = New Point(60, 180)
        txtCode.MaxLength = 6
        txtCode.Name = "txtCode"
        txtCode.Size = New Size(360, 40)
        txtCode.TabIndex = 3
        txtCode.TextAlign = HorizontalAlignment.Center
        ' 
        ' pnlCodeLine
        ' 
        pnlCodeLine.BackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        pnlCodeLine.ForeColor = SystemColors.Window
        pnlCodeLine.Location = New Point(60, 221)
        pnlCodeLine.Name = "pnlCodeLine"
        pnlCodeLine.Size = New Size(360, 1)
        pnlCodeLine.TabIndex = 4
        ' 
        ' lblTimer
        ' 
        lblTimer.AutoSize = True
        lblTimer.ForeColor = Color.FromArgb(CByte(125), CByte(129), CByte(132))
        lblTimer.Location = New Point(60, 235)
        lblTimer.Name = "lblTimer"
        lblTimer.Size = New Size(150, 20)
        lblTimer.TabIndex = 5
        lblTimer.Text = "Code expires in 10:00"
        ' 
        ' lblError
        ' 
        lblError.AutoSize = True
        lblError.ForeColor = Color.FromArgb(CByte(219), CByte(68), CByte(68))
        lblError.Location = New Point(60, 258)
        lblError.Name = "lblError"
        lblError.Size = New Size(0, 20)
        lblError.TabIndex = 6
        ' 
        ' btnVerify
        ' 
        btnVerify.BackColor = Color.FromArgb(CByte(219), CByte(68), CByte(68))
        btnVerify.Cursor = Cursors.Hand
        btnVerify.FlatAppearance.BorderSize = 0
        btnVerify.FlatStyle = FlatStyle.Flat
        btnVerify.Font = New Font("Segoe UI", 10F)
        btnVerify.ForeColor = Color.White
        btnVerify.Location = New Point(60, 280)
        btnVerify.Name = "btnVerify"
        btnVerify.Size = New Size(360, 44)
        btnVerify.TabIndex = 7
        btnVerify.Text = "Verify Email"
        btnVerify.UseVisualStyleBackColor = False
        ' 
        ' lblResend
        ' 
        lblResend.AutoSize = True
        lblResend.Font = New Font("Segoe UI", 10F)
        lblResend.ForeColor = Color.FromArgb(CByte(125), CByte(129), CByte(132))
        lblResend.Location = New Point(95, 345)
        lblResend.Name = "lblResend"
        lblResend.Size = New Size(194, 23)
        lblResend.TabIndex = 8
        lblResend.Text = "Didn't receive the code?"
        ' 
        ' lblResendLink
        ' 
        lblResendLink.AutoSize = True
        lblResendLink.Cursor = Cursors.Hand
        lblResendLink.Font = New Font("Segoe UI", 10F)
        lblResendLink.ForeColor = Color.FromArgb(CByte(219), CByte(68), CByte(68))
        lblResendLink.Location = New Point(308, 345)
        lblResendLink.Name = "lblResendLink"
        lblResendLink.Size = New Size(65, 23)
        lblResendLink.TabIndex = 9
        lblResendLink.Text = "Resend"
        ' 
        ' tmrCountdown
        ' 
        tmrCountdown.Interval = 1000
        ' 
        ' frmEmailVerification
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.WhiteSmoke
        ClientSize = New Size(882, 577)
        Controls.Add(pnlRight)
        Controls.Add(pnlLeft)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmEmailVerification"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Campus Market Hub — Verify Email"
        pnlLeft.ResumeLayout(False)
        pnlLeft.PerformLayout()
        pnlRight.ResumeLayout(False)
        pnlRight.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlLeft As Panel
    Friend WithEvents lblBrand As Label
    Friend WithEvents pnlRight As Panel
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents btnVerify As Button
    Friend WithEvents lblError As Label
    Friend WithEvents lblTimer As Label
    Friend WithEvents pnlCodeLine As Panel
    Friend WithEvents txtCode As TextBox
    Friend WithEvents lblResendLink As Label
    Friend WithEvents lblResend As Label
    Friend WithEvents tmrCountdown As Timer
End Class
