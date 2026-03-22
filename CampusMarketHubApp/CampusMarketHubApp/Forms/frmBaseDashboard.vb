Public Class frmBaseDashboard

    ' -------------------------------------------------------
    ' Form Load — populate user info from session
    ' -------------------------------------------------------
    Private Sub frmBaseDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUserInfo()
    End Sub

    ' -------------------------------------------------------
    ' Load logged-in user info into top nav
    ' -------------------------------------------------------
    Protected Sub LoadUserInfo()
        lblLoggedInUser.Text = "Hi, " & SessionManager.Username

        ' Only show badge if role exists
        If Not String.IsNullOrWhiteSpace(SessionManager.Role) Then
            lblRoleBadge.Text = "  " & SessionManager.Role.ToUpper() & "  "
            lblRoleBadge.Visible = True
        Else
            lblRoleBadge.Visible = False
        End If
    End Sub

    ' -------------------------------------------------------
    ' Add a menu item to the sidebar dynamically
    ' Call this from child forms to build their menu
    ' -------------------------------------------------------
    Protected Function AddMenuItem(text As String,
                                    yPosition As Integer,
                                    Optional isActive As Boolean = False) As Label
        Dim item As New Label()
        item.Text = "  " & text
        item.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        item.ForeColor = If(isActive,
                            Color.White,
                            Color.FromArgb(189, 189, 189))
        item.BackColor = If(isActive,
                            Color.FromArgb(40, 40, 40),
                            Color.FromArgb(26, 26, 26))
        item.Size = New Size(220, 44)
        item.Location = New Point(0, yPosition)
        item.TextAlign = ContentAlignment.MiddleLeft
        item.Cursor = Cursors.Hand
        item.Tag = text

        ' Active indicator — red left border simulation using a panel
        If isActive Then
            Dim accent As New Panel()
            accent.Size = New Size(3, 44)
            accent.Location = New Point(0, yPosition)
            accent.BackColor = Color.FromArgb(219, 68, 68)
            pnlMenuItems.Controls.Add(accent)
        End If

        ' Hover effects
        AddHandler item.MouseEnter, Sub(s, e)
                                        If Not CBool(item.Tag?.ToString() = GetActiveMenuText()) Then
                                            item.BackColor = Color.FromArgb(40, 40, 40)
                                            item.ForeColor = Color.White
                                        End If
                                    End Sub

        AddHandler item.MouseLeave, Sub(s, e)
                                        If Not CBool(item.Tag?.ToString() = GetActiveMenuText()) Then
                                            item.BackColor = Color.FromArgb(26, 26, 26)
                                            item.ForeColor = Color.FromArgb(189, 189, 189)
                                        End If
                                    End Sub

        pnlMenuItems.Controls.Add(item)
        Return item
    End Function

    ' -------------------------------------------------------
    ' Override in child forms to return current active menu
    ' -------------------------------------------------------
    Protected Overridable Function GetActiveMenuText() As String
        Return ""
    End Function

    ' -------------------------------------------------------
    ' Load a child form into the main content panel
    ' This is how navigation works inside the dashboard
    ' -------------------------------------------------------
    Public Sub LoadChildForm(childForm As Form)
        ' Close any existing child form
        For Each ctrl As Control In pnlMainContent.Controls
            If TypeOf ctrl Is Form Then
                CType(ctrl, Form).Close()
            End If
        Next

        childForm.TopLevel = False
        childForm.FormBorderStyle = FormBorderStyle.None
        childForm.Dock = DockStyle.Fill
        pnlMainContent.Controls.Add(childForm)
        pnlMainContent.Tag = childForm
        childForm.BringToFront()
        childForm.Show()
    End Sub

    ' -------------------------------------------------------
    ' Logout — from top nav
    ' -------------------------------------------------------
    Private Sub lblLogout_Click(sender As Object, e As EventArgs) Handles lblLogout.Click
        ConfirmLogout()
    End Sub

    ' -------------------------------------------------------
    ' Logout — from sidebar
    ' -------------------------------------------------------
    Private Sub lblSidebarLogout_Click(sender As Object, e As EventArgs) Handles lblSidebarLogout.Click
        ConfirmLogout()
    End Sub

    ' -------------------------------------------------------
    ' Logout logic
    ' -------------------------------------------------------
    Private Sub ConfirmLogout()
        Dim confirm As DialogResult = MessageBox.Show(
            "Are you sure you want to logout?",
            "Logout",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)

        If confirm = DialogResult.Yes Then
            LogManager.Log(SessionManager.UserId, "Logout", "User logged out")
            SessionManager.ClearSession()
            Dim login As New frmLogin()
            login.Show()
            Me.Close()
        End If
    End Sub

    ' -------------------------------------------------------
    ' Hover effects for logout labels
    ' -------------------------------------------------------
    Private Sub lblLogout_MouseEnter(sender As Object, e As EventArgs) Handles lblLogout.MouseEnter
        lblLogout.ForeColor = Color.FromArgb(193, 51, 51)
    End Sub
    Private Sub lblLogout_MouseLeave(sender As Object, e As EventArgs) Handles lblLogout.MouseLeave
        lblLogout.ForeColor = Color.FromArgb(219, 68, 68)
    End Sub

End Class