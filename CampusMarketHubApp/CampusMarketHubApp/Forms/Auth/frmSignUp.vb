Imports System.Data.SqlClient

Public Class frmSignUp

    Private Sub frmSignUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblError.Text = ""

        ' Populate role dropdown
        cboRole.Items.Clear()
        cboRole.Items.Add("Buy products (Buyer)")
        cboRole.Items.Add("Sell products (Vendor)")
        cboRole.SelectedIndex = 0

        ' Set placeholders
        SetPlaceholder(txtFullName, "Full Name")
        SetPlaceholder(txtUsername, "Username")
        SetPlaceholder(txtEmail, "Email Address")
        SetPlaceholder(txtPassword, "Password")
    End Sub
    Private Sub frmSignUp_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.ActiveControl = Nothing
    End Sub

    Private isPasswordVisible As Boolean = False

    ' -------------------------------------------------------
    ' Show password icon
    ' -------------------------------------------------------
    Private Sub lblShowPassword_Click(sender As Object, e As EventArgs) Handles lblShowPassword.Click
        isPasswordVisible = Not isPasswordVisible
        txtPassword.PasswordChar = If(isPasswordVisible, Nothing, "*"c)
        lblShowPassword.Text = If(isPasswordVisible, "🙈", "👁")
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
    ' Focus events — Full Name
    ' -------------------------------------------------------
    Private Sub txtFullName_Enter(sender As Object, e As EventArgs) Handles txtFullName.Enter
        RemovePlaceholder(txtFullName, False)
        pnlFullNameLine.BackColor = Color.FromArgb(219, 68, 68)
    End Sub
    Private Sub txtFullName_Leave(sender As Object, e As EventArgs) Handles txtFullName.Leave
        SetPlaceholder(txtFullName, "Full Name")
        pnlFullNameLine.BackColor = Color.FromArgb(224, 224, 224)
    End Sub

    ' -------------------------------------------------------
    ' Focus events — Username
    ' -------------------------------------------------------
    Private Sub txtUsername_Enter(sender As Object, e As EventArgs) Handles txtUsername.Enter
        RemovePlaceholder(txtUsername, False)
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
        RemovePlaceholder(txtEmail, False)
        pnlEmailLine.BackColor = Color.FromArgb(219, 68, 68)
    End Sub
    Private Sub txtEmail_Leave(sender As Object, e As EventArgs) Handles txtEmail.Leave
        SetPlaceholder(txtEmail, "Email Address")
        pnlEmailLine.BackColor = Color.FromArgb(224, 224, 224)
    End Sub

    ' -------------------------------------------------------
    ' Focus events — Password
    ' -------------------------------------------------------
    Private Sub txtPassword_Enter(sender As Object, e As EventArgs) Handles txtPassword.Enter
        RemovePlaceholder(txtPassword, True)
        pnlPasswordLine.BackColor = Color.FromArgb(219, 68, 68)
    End Sub
    Private Sub txtPassword_Leave(sender As Object, e As EventArgs) Handles txtPassword.Leave
        SetPlaceholder(txtPassword, "Password")
        pnlPasswordLine.BackColor = Color.FromArgb(224, 224, 224)
    End Sub

    ' -------------------------------------------------------
    ' Create Account Button
    ' -------------------------------------------------------
    Private Sub btnCreateAccount_Click(sender As Object, e As EventArgs) Handles btnCreateAccount.Click
        lblError.Text = ""

        ' Get values
        Dim fullName As String = txtFullName.Text.Trim()
        Dim username As String = txtUsername.Text.Trim()
        Dim email As String = txtEmail.Text.Trim()
        Dim password As String = txtPassword.Text
        Dim selectedRole As String = If(cboRole.SelectedIndex = 1, "Vendor", "Buyer")

        ' Validate — Full Name
        If String.IsNullOrWhiteSpace(fullName) OrElse fullName = "Full Name" Then
            ShowError("Please enter your full name.") : Return
        End If

        ' Validate — Username
        If String.IsNullOrWhiteSpace(username) OrElse username = "Username" Then
            ShowError("Please enter a username.") : Return
        End If

        If username.Contains(" ") Then
            ShowError("Username cannot contain spaces.") : Return
        End If

        Dim allowedChars As Boolean = username.All(Function(c)
                                                       Return Char.IsLetterOrDigit(c) OrElse c = "_"c OrElse c = "."c
                                                   End Function)

        If Not allowedChars Then
            ShowError("Username can only contain letters, numbers, _ and .") : Return
        End If

        ' Validate — Email
        If String.IsNullOrWhiteSpace(email) OrElse email = "Email Address" Then
            ShowError("Please enter your email address.") : Return
        End If

        If Not email.Contains("@") OrElse Not email.Contains(".") Then
            ShowError("Please enter a valid email address.") : Return
        End If

        ' Validate — Password
        If String.IsNullOrWhiteSpace(password) OrElse password = "Password" Then
            ShowError("Please enter a password.") : Return
        End If

        If password.Length < 6 Then
            ShowError("Password must be at least 6 characters.") : Return
        End If

        Try
            ' Check if username already exists
            Dim checkUserSql As String =
            "SELECT COUNT(*) FROM Users WHERE username = @username"
            Dim userExists As Integer = CInt(DataAccess.ExecuteScalar(checkUserSql,
            New SqlParameter("@username", username)))

            If userExists > 0 Then
                ShowError("Username already taken. Please choose another.")
                Return
            End If

            ' Check if email already exists
            Dim checkEmailSql As String =
            "SELECT COUNT(*) FROM Users WHERE email = @email"
            Dim emailExists As Integer = CInt(DataAccess.ExecuteScalar(checkEmailSql,
            New SqlParameter("@email", email)))

            If emailExists > 0 Then
                ShowError("An account with this email already exists.")
                Return
            End If

            ' Generate 6-digit verification code
            Dim rng As New Random()
            Dim code As String = rng.Next(100000, 999999).ToString()

            ' Invalidate any existing unused codes for this email
            Dim invalidateSql As String =
            "UPDATE EmailVerifications SET isUsed = 1
             WHERE email = @email AND isUsed = 0"
            DataAccess.ExecuteNonQuery(invalidateSql,
            New SqlParameter("@email", email))

            ' Store verification code in DB (expires in 10 minutes)
            Dim insertCodeSql As String =
            "INSERT INTO EmailVerifications (email, code, expiresAt)
             VALUES (@email, @code, @expiresAt)"
            DataAccess.ExecuteNonQuery(insertCodeSql,
            New SqlParameter("@email", email),
            New SqlParameter("@code", code),
            New SqlParameter("@expiresAt", DateTime.Now.AddMinutes(10)))

            ' Send verification email
            btnCreateAccount.Enabled = False
            btnCreateAccount.Text = "Sending code..."

            Dim emailSent As Boolean = EmailService.SendVerificationCode(
            email, fullName, code)

            If Not emailSent Then
                ShowError("Failed to send verification email. Check your internet connection.")
                btnCreateAccount.Enabled = True
                btnCreateAccount.Text = "Create Account"
                Return
            End If

            ' Save pending registration data
            PendingRegistration.FullName = fullName
            PendingRegistration.Username = username
            PendingRegistration.Email = email
            PendingRegistration.Password = password
            PendingRegistration.Role = selectedRole

            ' Navigate to verification screen
            Dim verify As New frmEmailVerification()
            verify.Show()
            Me.Hide()

        Catch ex As Exception
            ShowError("Something went wrong: " & ex.Message)
            btnCreateAccount.Enabled = True
            btnCreateAccount.Text = "Create Account"
        End Try
    End Sub

    ' -------------------------------------------------------
    ' Button hover effects
    ' -------------------------------------------------------
    Private Sub btnCreateAccount_MouseEnter(sender As Object, e As EventArgs) Handles btnCreateAccount.MouseEnter
        btnCreateAccount.BackColor = Color.FromArgb(193, 51, 51)
    End Sub
    Private Sub btnCreateAccount_MouseLeave(sender As Object, e As EventArgs) Handles btnCreateAccount.MouseLeave
        btnCreateAccount.BackColor = Color.FromArgb(219, 68, 68)
    End Sub

    ' -------------------------------------------------------
    ' Navigate to Login
    ' -------------------------------------------------------
    Private Sub lblLogin_Click(sender As Object, e As EventArgs) Handles lblLogin.Click
        GoToLogin()
    End Sub

    Private Sub GoToLogin()
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