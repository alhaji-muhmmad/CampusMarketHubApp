Imports System.Data.SqlClient

Public Class frmResetPassword

    Private isNewPasswordVisible As Boolean = False
    Private isConfirmPasswordVisible As Boolean = False

    Private Sub frmResetPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblError.Text = ""
        lblEmail.Text = PendingReset.Email
        Me.ActiveControl = Nothing
        SetPlaceholder(txtCode, "Enter 6-digit code")
        SetPlaceholder(txtNewPassword, "New Password")
        SetPlaceholder(txtConfirmPassword, "Confirm Password")
    End Sub
    Private Sub frmResetPassword_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.ActiveControl = Nothing
    End Sub

    ' -------------------------------------------------------
    ' Placeholder helpers
    ' -------------------------------------------------------
    Private Sub SetPlaceholder(txt As TextBox, placeholder As String)
        If String.IsNullOrWhiteSpace(txt.Text) Then
            txt.Text = placeholder
            txt.ForeColor = Color.FromArgb(189, 189, 189)
            txt.PasswordChar = Nothing
        End If
    End Sub

    Private Sub RemovePlaceholder(txt As TextBox, isPassword As Boolean)
        If txt.ForeColor = Color.FromArgb(189, 189, 189) Then
            txt.Text = ""
            txt.ForeColor = Color.FromArgb(51, 51, 51)
            If isPassword Then txt.PasswordChar = "*"c
        End If
    End Sub

    ' -------------------------------------------------------
    ' Focus events — Code
    ' -------------------------------------------------------
    Private Sub txtCode_Enter(sender As Object, e As EventArgs) Handles txtCode.Enter
        RemovePlaceholder(txtCode, False)
        pnlCodeLine.BackColor = Color.FromArgb(219, 68, 68)
    End Sub
    Private Sub txtCode_Leave(sender As Object, e As EventArgs) Handles txtCode.Leave
        pnlCodeLine.BackColor = Color.FromArgb(224, 224, 224)
    End Sub

    Private Sub txtCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCode.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    ' -------------------------------------------------------
    ' Focus events — New Password
    ' -------------------------------------------------------
    Private Sub txtNewPassword_Enter(sender As Object, e As EventArgs) Handles txtNewPassword.Enter
        RemovePlaceholder(txtNewPassword, True)
        pnlNewPasswordLine.BackColor = Color.FromArgb(219, 68, 68)
    End Sub
    Private Sub txtNewPassword_Leave(sender As Object, e As EventArgs) Handles txtNewPassword.Leave
        If String.IsNullOrWhiteSpace(txtNewPassword.Text) Then
            SetPlaceholder(txtNewPassword, "New Password")
        End If
        pnlNewPasswordLine.BackColor = Color.FromArgb(224, 224, 224)
    End Sub

    ' -------------------------------------------------------
    ' Focus events — Confirm Password
    ' -------------------------------------------------------
    Private Sub txtConfirmPassword_Enter(sender As Object, e As EventArgs) Handles txtConfirmPassword.Enter
        RemovePlaceholder(txtConfirmPassword, True)
        pnlConfirmPasswordLine.BackColor = Color.FromArgb(219, 68, 68)
    End Sub
    Private Sub txtConfirmPassword_Leave(sender As Object, e As EventArgs) Handles txtConfirmPassword.Leave
        If String.IsNullOrWhiteSpace(txtConfirmPassword.Text) Then
            SetPlaceholder(txtConfirmPassword, "Confirm Password")
        End If
        pnlConfirmPasswordLine.BackColor = Color.FromArgb(224, 224, 224)
    End Sub

    ' -------------------------------------------------------
    ' Show/Hide password toggles
    ' -------------------------------------------------------
    Private Sub lblShowNewPassword_Click(sender As Object, e As EventArgs) Handles lblShowNewPassword.Click
        isNewPasswordVisible = Not isNewPasswordVisible
        txtNewPassword.PasswordChar = If(isNewPasswordVisible, Nothing, "*"c)
        lblShowNewPassword.Text = If(isNewPasswordVisible, "🙈", "👁")
    End Sub

    Private Sub lblShowConfirmPassword_Click(sender As Object, e As EventArgs) Handles lblShowConfirmPassword.Click
        isConfirmPasswordVisible = Not isConfirmPasswordVisible
        txtConfirmPassword.PasswordChar = If(isConfirmPasswordVisible, Nothing, "*"c)
        lblShowConfirmPassword.Text = If(isConfirmPasswordVisible, "🙈", "👁")
    End Sub

    ' -------------------------------------------------------
    ' Reset Password Button
    ' -------------------------------------------------------
    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        lblError.Text = ""

        Dim code As String = txtCode.Text.Trim()
        Dim newPassword As String = txtNewPassword.Text
        Dim confirmPassword As String = txtConfirmPassword.Text

        ' Validate
        If String.IsNullOrWhiteSpace(code) OrElse code = "Enter 6-digit code" Then
            ShowError("Please enter your reset code.") : Return
        End If

        If String.IsNullOrWhiteSpace(newPassword) OrElse newPassword = "New Password" Then
            ShowError("Please enter a new password.") : Return
        End If

        If newPassword.Length < 6 Then
            ShowError("Password must be at least 6 characters.") : Return
        End If

        If confirmPassword = "Confirm Password" OrElse
           String.IsNullOrWhiteSpace(confirmPassword) Then
            ShowError("Please confirm your password.") : Return
        End If

        If newPassword <> confirmPassword Then
            ShowError("Passwords do not match.") : Return
        End If

        Try
            ' Verify reset code
            Dim sql As String =
                "SELECT COUNT(*) FROM PasswordResets
                 WHERE userId = @userId
                 AND resetCode = @resetCode
                 AND isUsed = 0
                 AND expiresAt > GETDATE()"

            Dim isValid As Integer = CInt(DataAccess.ExecuteScalar(sql,
                New SqlParameter("@userId", PendingReset.UserId),
                New SqlParameter("@resetCode", code)))

            If isValid = 0 Then
                ShowError("Invalid or expired reset code.") : Return
            End If

            ' Update password
            Dim updateSql As String =
                "UPDATE Users SET password = @password
                 WHERE userId = @userId"
            DataAccess.ExecuteNonQuery(updateSql,
                New SqlParameter("@password", newPassword),
                New SqlParameter("@userId", PendingReset.UserId))

            ' Mark reset code as used
            Dim markUsedSql As String =
                "UPDATE PasswordResets SET isUsed = 1
                 WHERE userId = @userId AND resetCode = @resetCode"
            DataAccess.ExecuteNonQuery(markUsedSql,
                New SqlParameter("@userId", PendingReset.UserId),
                New SqlParameter("@resetCode", code))

            LogManager.Log(PendingReset.UserId, "ResetPassword", "Password reset successfully")

            ' Clear pending reset data
            PendingReset.Clear()

            MessageBox.Show("Password reset successfully! Please log in with your new password.",
                            "Password Reset",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)

            Dim login As New frmLogin()
            login.Show()
            Me.Hide()

        Catch ex As Exception
            ShowError("Reset failed: " & ex.Message)
        End Try
    End Sub

    ' -------------------------------------------------------
    ' Button hover
    ' -------------------------------------------------------
    Private Sub btnReset_MouseEnter(sender As Object, e As EventArgs) Handles btnReset.MouseEnter
        btnReset.BackColor = Color.FromArgb(193, 51, 51)
    End Sub
    Private Sub btnReset_MouseLeave(sender As Object, e As EventArgs) Handles btnReset.MouseLeave
        btnReset.BackColor = Color.FromArgb(219, 68, 68)
    End Sub

    ' -------------------------------------------------------
    ' Back to Login
    ' -------------------------------------------------------
    Private Sub lblBackToLogin_Click(sender As Object, e As EventArgs) Handles lblBackToLogin.Click
        PendingReset.Clear()
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