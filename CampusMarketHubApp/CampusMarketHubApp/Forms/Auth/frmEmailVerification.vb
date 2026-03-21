Imports System.Data.SqlClient

Public Class frmEmailVerification

    Private secondsRemaining As Integer = 600 ' 10 minutes

    Private Sub frmEmailVerification_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblError.Text = ""
        lblEmail.Text = PendingRegistration.Email
        txtCode.Text = ""

        ' Start countdown timer
        secondsRemaining = 600
        tmrCountdown.Enabled = True

        txtCode.Focus()
    End Sub
    Private Sub frmEmailVerification_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.ActiveControl = Nothing
    End Sub

    ' -------------------------------------------------------
    ' Countdown Timer
    ' -------------------------------------------------------
    Private Sub tmrCountdown_Tick(sender As Object, e As EventArgs) Handles tmrCountdown.Tick
        secondsRemaining -= 1

        Dim minutes As Integer = secondsRemaining \ 60
        Dim seconds As Integer = secondsRemaining Mod 60
        lblTimer.Text = $"Code expires in {minutes}:{seconds:D2}"

        If secondsRemaining <= 60 Then
            lblTimer.ForeColor = Color.FromArgb(219, 68, 68)
        End If

        If secondsRemaining <= 0 Then
            tmrCountdown.Enabled = False
            lblTimer.Text = "Code has expired. Please request a new one."
            btnVerify.Enabled = False
        End If
    End Sub

    ' -------------------------------------------------------
    ' Focus events — Code field
    ' -------------------------------------------------------
    Private Sub txtCode_Enter(sender As Object, e As EventArgs) Handles txtCode.Enter
        pnlCodeLine.BackColor = Color.FromArgb(219, 68, 68)
    End Sub
    Private Sub txtCode_Leave(sender As Object, e As EventArgs) Handles txtCode.Leave
        pnlCodeLine.BackColor = Color.FromArgb(224, 224, 224)
    End Sub

    ' -------------------------------------------------------
    ' Only allow numeric input in code field
    ' -------------------------------------------------------
    Private Sub txtCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCode.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    ' -------------------------------------------------------
    ' Auto-submit when 6 digits entered
    ' -------------------------------------------------------
    Private Sub txtCode_TextChanged(sender As Object, e As EventArgs) Handles txtCode.TextChanged
        If txtCode.Text.Length = 6 Then
            btnVerify_Click(sender, e)
        End If
    End Sub

    ' -------------------------------------------------------
    ' Verify Button
    ' -------------------------------------------------------
    Private Sub btnVerify_Click(sender As Object, e As EventArgs) Handles btnVerify.Click
        lblError.Text = ""
        Dim enteredCode As String = txtCode.Text.Trim()

        If String.IsNullOrWhiteSpace(enteredCode) OrElse enteredCode.Length < 6 Then
            ShowError("Please enter the 6-digit code.") : Return
        End If

        Try
            ' Check code in DB
            Dim sql As String =
                "SELECT COUNT(*) FROM EmailVerifications
                 WHERE email = @email
                 AND code = @code
                 AND isUsed = 0
                 AND expiresAt > GETDATE()"

            Dim isValid As Integer = CInt(DataAccess.ExecuteScalar(sql,
                New SqlParameter("@email", PendingRegistration.Email),
                New SqlParameter("@code", enteredCode)))

            If isValid = 0 Then
                ShowError("Invalid or expired code. Please try again.")
                Return
            End If

            ' Mark code as used
            Dim markUsedSql As String =
                "UPDATE EmailVerifications SET isUsed = 1
                 WHERE email = @email AND code = @code"
            DataAccess.ExecuteNonQuery(markUsedSql,
                New SqlParameter("@email", PendingRegistration.Email),
                New SqlParameter("@code", enteredCode))

            ' Create the account
            CreateAccount()

        Catch ex As Exception
            ShowError("Verification failed: " & ex.Message)
        End Try
    End Sub

    ' -------------------------------------------------------
    ' Create account after successful verification
    ' -------------------------------------------------------
    Private Sub CreateAccount()
        Try
            tmrCountdown.Enabled = False

            ' Insert into Users
            Dim insertUserSql As String =
                "INSERT INTO Users (username, password, role, email)
                 OUTPUT INSERTED.userId
                 VALUES (@username, @password, @role, @email)"

            Dim newUserId As Integer = CInt(DataAccess.ExecuteScalar(insertUserSql,
                New SqlParameter("@username", PendingRegistration.Username),
                New SqlParameter("@password", PendingRegistration.Password),
                New SqlParameter("@role", PendingRegistration.Role),
                New SqlParameter("@email", PendingRegistration.Email)))

            ' Insert into role-specific table
            If PendingRegistration.Role = "Buyer" Then
                Dim insertBuyerSql As String =
                    "INSERT INTO Buyers (userId, fullName)
                     VALUES (@userId, @fullName)"
                DataAccess.ExecuteNonQuery(insertBuyerSql,
                    New SqlParameter("@userId", newUserId),
                    New SqlParameter("@fullName", PendingRegistration.FullName))

            ElseIf PendingRegistration.Role = "Vendor" Then
                Dim insertVendorSql As String =
                    "INSERT INTO Vendors (userId, shopName)
                     VALUES (@userId, @shopName)"
                DataAccess.ExecuteNonQuery(insertVendorSql,
                    New SqlParameter("@userId", newUserId),
                    New SqlParameter("@shopName", PendingRegistration.FullName))
            End If

            ' Send welcome email
            EmailService.SendWelcomeEmail(
                PendingRegistration.Email,
                PendingRegistration.FullName,
                PendingRegistration.Role)

            ' Log registration
            LogManager.Log(newUserId, "Register",
                "Email verified — " & PendingRegistration.Role & " account created")

            ' Set session for vendor setup
            If PendingRegistration.Role = "Vendor" Then
                SessionManager.SetSession(newUserId,
                    PendingRegistration.Username,
                    PendingRegistration.Role, 0)
            End If

            ' Clear pending data
            PendingRegistration.Clear()

            ' Redirect
            If SessionManager.Role = "Vendor" Then
                Dim setup As New frmVendorSetup()
                setup.Show()
                Me.Hide()
            Else
                MessageBox.Show("Account created successfully! Please log in.",
                                "Welcome to Campus Market Hub",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
                Dim login As New frmLogin()
                login.Show()
                Me.Hide()
            End If

        Catch ex As Exception
            ShowError("Account creation failed: " & ex.Message)
        End Try
    End Sub

    ' -------------------------------------------------------
    ' Resend Code
    ' -------------------------------------------------------
    Private Sub lblResendLink_Click(sender As Object, e As EventArgs) Handles lblResendLink.Click
        Try
            ' Generate new code
            Dim rng As New Random()
            Dim newCode As String = rng.Next(100000, 999999).ToString()

            ' Invalidate old codes
            Dim invalidateSql As String =
                "UPDATE EmailVerifications SET isUsed = 1
                 WHERE email = @email AND isUsed = 0"
            DataAccess.ExecuteNonQuery(invalidateSql,
                New SqlParameter("@email", PendingRegistration.Email))

            ' Insert new code
            Dim insertSql As String =
                "INSERT INTO EmailVerifications (email, code, expiresAt)
                 VALUES (@email, @code, @expiresAt)"
            DataAccess.ExecuteNonQuery(insertSql,
                New SqlParameter("@email", PendingRegistration.Email),
                New SqlParameter("@code", newCode),
                New SqlParameter("@expiresAt", DateTime.Now.AddMinutes(10)))

            ' Resend email
            Dim sent As Boolean = EmailService.SendVerificationCode(
                PendingRegistration.Email,
                PendingRegistration.FullName,
                newCode)

            If sent Then
                ' Reset timer
                secondsRemaining = 600
                tmrCountdown.Enabled = True
                btnVerify.Enabled = True
                lblTimer.ForeColor = Color.FromArgb(125, 129, 132)
                txtCode.Text = ""
                lblError.Text = ""
                MessageBox.Show("A new code has been sent to your email.",
                                "Code Resent",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
            Else
                ShowError("Failed to resend code. Check your internet connection.")
            End If

        Catch ex As Exception
            ShowError("Something went wrong: " & ex.Message)
        End Try
    End Sub

    ' -------------------------------------------------------
    ' Button hover
    ' -------------------------------------------------------
    Private Sub btnVerify_MouseEnter(sender As Object, e As EventArgs) Handles btnVerify.MouseEnter
        btnVerify.BackColor = Color.FromArgb(193, 51, 51)
    End Sub
    Private Sub btnVerify_MouseLeave(sender As Object, e As EventArgs) Handles btnVerify.MouseLeave
        btnVerify.BackColor = Color.FromArgb(219, 68, 68)
    End Sub

    ' -------------------------------------------------------
    ' Helper
    ' -------------------------------------------------------
    Private Sub ShowError(message As String)
        lblError.Text = message
    End Sub

End Class