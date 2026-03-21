Imports System.Data.SqlClient

Public Class frmForgotPassword

    Private Sub frmForgotPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblError.Text = ""
        Me.ActiveControl = Nothing
        SetPlaceholder(txtUsername, "Username")
        SetPlaceholder(txtEmail, "Email Address")
    End Sub
    Private Sub frmForgotPassword_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.ActiveControl = Nothing
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

    Private Sub RemovePlaceholder(txt As TextBox)
        If txt.ForeColor = Color.FromArgb(189, 189, 189) Then
            txt.Text = ""
            txt.ForeColor = Color.FromArgb(51, 51, 51)
        End If
    End Sub

    ' -------------------------------------------------------
    ' Focus events — Username
    ' -------------------------------------------------------
    Private Sub txtUsername_Enter(sender As Object, e As EventArgs) Handles txtUsername.Enter
        RemovePlaceholder(txtUsername)
        pnlUsernameLine.BackColor = Color.FromArgb(219, 68, 68)
    End Sub
    Private Sub txtUsername_Leave(sender As Object, e As EventArgs) Handles txtUsername.Leave
        SetPlaceholder(txtUsername, "Username")
        pnlUsernameLine.BackColor = Color.FromArgb(224, 224, 224)
    End Sub

    ' -------------------------------------------------------
    ' Focus events — Email
    ' -------------------------------------------------------
    Private Sub txtEmail_Enter(sender As Object, e As EventArgs) Handles txtEmail.Enter
        RemovePlaceholder(txtEmail)
        pnlEmailLine.BackColor = Color.FromArgb(219, 68, 68)
    End Sub
    Private Sub txtEmail_Leave(sender As Object, e As EventArgs) Handles txtEmail.Leave
        SetPlaceholder(txtEmail, "Email Address")
        pnlEmailLine.BackColor = Color.FromArgb(224, 224, 224)
    End Sub

    ' -------------------------------------------------------
    ' Send Reset Code
    ' -------------------------------------------------------
    Private Sub btnSendCode_Click(sender As Object, e As EventArgs) Handles btnSendCode.Click
        lblError.Text = ""

        Dim username As String = txtUsername.Text.Trim()
        Dim email As String = txtEmail.Text.Trim()

        ' Validate
        If String.IsNullOrWhiteSpace(username) OrElse username = "Username" Then
            ShowError("Please enter your username.") : Return
        End If

        If String.IsNullOrWhiteSpace(email) OrElse email = "Email Address" Then
            ShowError("Please enter your email address.") : Return
        End If

        Try
            ' Verify username and email match
            Dim sql As String =
                "SELECT userId FROM Users
                 WHERE username = @username AND email = @email"

            Dim result As Object = DataAccess.ExecuteScalar(sql,
                New SqlParameter("@username", username),
                New SqlParameter("@email", email))

            If result Is Nothing OrElse result Is DBNull.Value Then
                ShowError("No account found with that username and email.")
                Return
            End If

            Dim userId As Integer = CInt(result)

            ' Generate reset code
            Dim rng As New Random()
            Dim resetCode As String = rng.Next(100000, 999999).ToString()

            ' Invalidate old codes
            Dim invalidateSql As String =
                "UPDATE PasswordResets SET isUsed = 1
                 WHERE userId = @userId AND isUsed = 0"
            DataAccess.ExecuteNonQuery(invalidateSql,
                New SqlParameter("@userId", userId))

            ' Insert new code (expires in 15 minutes)
            Dim insertSql As String =
                "INSERT INTO PasswordResets (userId, resetCode, expiresAt)
                 VALUES (@userId, @resetCode, @expiresAt)"
            DataAccess.ExecuteNonQuery(insertSql,
                New SqlParameter("@userId", userId),
                New SqlParameter("@resetCode", resetCode),
                New SqlParameter("@expiresAt", DateTime.Now.AddMinutes(15)))

            ' Send email
            btnSendCode.Enabled = False
            btnSendCode.Text = "Sending..."

            Dim sent As Boolean = EmailService.SendResetCode(email, username, resetCode)

            If sent Then
                LogManager.Log(userId, "ForgotPassword", "Reset code sent to " & email)

                ' Navigate to reset password screen passing the userId
                PendingReset.UserId = userId
                PendingReset.Email = email

                Dim reset As New frmResetPassword()
                reset.Show()
                Me.Hide()
            Else
                ShowError("Failed to send email. Check your internet connection.")
                btnSendCode.Enabled = True
                btnSendCode.Text = "Send Reset Code"
            End If

        Catch ex As Exception
            ShowError("Something went wrong: " & ex.Message)
            btnSendCode.Enabled = True
            btnSendCode.Text = "Send Reset Code"
        End Try
    End Sub

    ' -------------------------------------------------------
    ' Button hover
    ' -------------------------------------------------------
    Private Sub btnSendCode_MouseEnter(sender As Object, e As EventArgs) Handles btnSendCode.MouseEnter
        btnSendCode.BackColor = Color.FromArgb(193, 51, 51)
    End Sub
    Private Sub btnSendCode_MouseLeave(sender As Object, e As EventArgs) Handles btnSendCode.MouseLeave
        btnSendCode.BackColor = Color.FromArgb(219, 68, 68)
    End Sub

    ' -------------------------------------------------------
    ' Back to Login
    ' -------------------------------------------------------
    Private Sub lblBackToLogin_Click(sender As Object, e As EventArgs) Handles lblBackToLogin.Click
        Dim login As New frmLogin()
        login.Show()
        Me.Hide()
    End Sub

    ' -------------------------------------------------------
    ' Helper
    ' -------------------------------------------------------
    Private Sub ShowError(message As String)
        lblError.Text = message
    End Sub

End Class