Imports System.Data.SqlClient

Public Class frmSignUp

    Private Sub frmSignUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblError.Text = ""
        pnlFocus.Focus()

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

        ' Validate
        If String.IsNullOrWhiteSpace(fullName) OrElse fullName = "Full Name" Then
            ShowError("Please enter your full name.") : Return
        End If

        If String.IsNullOrWhiteSpace(username) OrElse username = "Username" Then
            ShowError("Please enter a username.") : Return
        End If

        If String.IsNullOrWhiteSpace(password) OrElse password = "Password" Then
            ShowError("Please enter a password.") : Return
        End If

        If password.Length < 6 Then
            ShowError("Password must be at least 6 characters.") : Return
        End If

        ' Clean up optional email placeholder
        If String.IsNullOrWhiteSpace(email) OrElse email = "Email Address" Then
            ShowError("Please enter your email address.") : Return
        End If

        ' Basic email format check
        If Not email.Contains("@") OrElse Not email.Contains(".") Then
            ShowError("Please enter a valid email address.") : Return
        End If

        Try
            ' Check if username already exists
            Dim checkSql As String = "SELECT COUNT(*) FROM Users WHERE username = @username"
            Dim exists As Integer = CInt(DataAccess.ExecuteScalar(checkSql,
                New SqlParameter("@username", username)))

            If exists > 0 Then
                ShowError("Username already taken. Please choose another.")
                Return
            End If

            ' Insert into Users table
            Dim insertUserSql As String =
                "INSERT INTO Users (username, password, role, email)
                 OUTPUT INSERTED.userId
                 VALUES (@username, @password, @role, @email)"

            Dim newUserId As Integer = CInt(DataAccess.ExecuteScalar(insertUserSql,
                New SqlParameter("@username", username),
                New SqlParameter("@password", password),
                New SqlParameter("@role", selectedRole),
                New SqlParameter("@email", If(String.IsNullOrWhiteSpace(email),
                                              DBNull.Value, CObj(email)))))

            ' Insert into role-specific table
            If selectedRole = "Buyer" Then
                Dim insertBuyerSql As String =
                    "INSERT INTO Buyers (userId, fullName) VALUES (@userId, @fullName)"
                DataAccess.ExecuteNonQuery(insertBuyerSql,
                    New SqlParameter("@userId", newUserId),
                    New SqlParameter("@fullName", fullName))

            ElseIf selectedRole = "Vendor" Then
                Dim insertVendorSql As String =
                    "INSERT INTO Vendors (userId, shopName) VALUES (@userId, @shopName)"
                DataAccess.ExecuteNonQuery(insertVendorSql,
                    New SqlParameter("@userId", newUserId),
                    New SqlParameter("@shopName", fullName))
            End If

            ' Log activity
            LogManager.Log(newUserId, "Register", "New " & selectedRole & " account created")

            ' Success — go to login
            MessageBox.Show("Account created successfully! Please log in.",
                            "Welcome to Campus Market Hub",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)

            GoToLogin()

        Catch ex As Exception
            ShowError("Registration failed: " & ex.Message)
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