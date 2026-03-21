Imports System.Data.SqlClient

Public Class frmLogin

    ' -------------------------------------------------------
    ' Placeholder text simulation
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
    ' Form Load
    ' -------------------------------------------------------
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SessionManager.ClearSession()
        lblError.Text = ""
        SetPlaceholder(txtUsername, "Username")
        SetPlaceholder(txtPassword, "Password")

        ' Prevent auto-focus on textbox at startup
        Me.ActiveControl = Nothing
    End Sub

    ' -------------------------------------------------------
    ' Placeholder focus events — Username
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
    ' Placeholder focus events — Password
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
    ' Login Button
    ' -------------------------------------------------------
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        lblError.Text = ""

        ' Validate inputs
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text

        If String.IsNullOrWhiteSpace(username) OrElse
           username = "Username" Then
            ShowError("Please enter your username.")
            Return
        End If

        If String.IsNullOrWhiteSpace(password) OrElse
           password = "Password" Then
            ShowError("Please enter your password.")
            Return
        End If

        ' Query database
        Try
            Dim sql As String = "SELECT userId, username, role, password
                                 FROM Users
                                 WHERE username = @username"

            Dim result As DataTable = DataAccess.ExecuteQuery(sql,
                New SqlParameter("@username", username))

            If result.Rows.Count = 0 Then
                ShowError("Invalid username or password.")
                Return
            End If

            Dim row As DataRow = result.Rows(0)

            If row("password").ToString() <> password Then
                ShowError("Invalid username or password.")
                Return
            End If

            ' Set session
            Dim userId As Integer = CInt(row("userId"))
            Dim role As String = row("role").ToString()
            Dim roleId As Integer = GetRoleId(userId, role)

            SessionManager.SetSession(userId, row("username").ToString(), role, roleId)
            LogManager.Log(userId, "Login", "Logged in as " & role)

            ' Redirect
            RedirectToDashboard(role)

        Catch ex As Exception
            ShowError("Login failed: " & ex.Message)
        End Try
    End Sub

    ' -------------------------------------------------------
    ' Get vendorId or buyerId
    ' -------------------------------------------------------
    Private Function GetRoleId(userId As Integer, role As String) As Integer
        Dim sql As String = ""

        Select Case role
            Case "Vendor"
                sql = "SELECT vendorId FROM Vendors WHERE userId = @userId"
            Case "Buyer"
                sql = "SELECT buyerId FROM Buyers WHERE userId = @userId"
            Case Else
                Return 0
        End Select

        Dim result As Object = DataAccess.ExecuteScalar(sql,
            New SqlParameter("@userId", userId))

        If result IsNot Nothing AndAlso result IsNot DBNull.Value Then
            Return CInt(result)
        End If

        Return 0
    End Function

    ' -------------------------------------------------------
    ' Redirect to correct dashboard
    ' -------------------------------------------------------
    Private Sub RedirectToDashboard(role As String)
        Me.Hide()
        Select Case role
            Case "Admin"
                ' frmAdminDashboard.Show() ← uncomment when built
                MessageBox.Show("Welcome, Admin!", "Login Successful")
            Case "Vendor"
                ' frmVendorDashboard.Show() ← uncomment when built
                MessageBox.Show("Welcome, Vendor!", "Login Successful")
            Case "Buyer"
                ' frmBuyerDashboard.Show() ← uncomment when built
                MessageBox.Show("Welcome, Buyer!", "Login Successful")
        End Select
    End Sub

    ' -------------------------------------------------------
    ' Button hover effects
    ' -------------------------------------------------------
    Private Sub btnLogin_MouseEnter(sender As Object, e As EventArgs) Handles btnLogin.MouseEnter
        btnLogin.BackColor = Color.FromArgb(193, 51, 51)
    End Sub

    Private Sub btnLogin_MouseLeave(sender As Object, e As EventArgs) Handles btnLogin.MouseLeave
        btnLogin.BackColor = Color.FromArgb(219, 68, 68)
    End Sub

    ' -------------------------------------------------------
    ' Enter key on password triggers login
    ' -------------------------------------------------------
    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then btnLogin_Click(sender, e)
    End Sub

    ' -------------------------------------------------------
    ' Navigation links
    ' -------------------------------------------------------
    Private Sub lblForgotPassword_Click(sender As Object, e As EventArgs) Handles lblForgotPassword.Click
        ' frmForgotPassword.Show() ← uncomment when built
        MessageBox.Show("Coming soon.", "Forgot Password")
    End Sub

    Private Sub lblSignUp_Click(sender As Object, e As EventArgs) Handles lblSignUp.Click
        Dim signUp As New frmSignUp()
        signUp.Show()
        Me.Hide()
    End Sub

    ' -------------------------------------------------------
    ' Helper
    ' -------------------------------------------------------
    Private Sub ShowError(message As String)
        lblError.Text = message
    End Sub

End Class