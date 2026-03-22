Imports System.Data.SqlClient

Public Class frmVendorSetup

    Private Sub frmVendorSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblError.Text = ""
        Me.ActiveControl = Nothing

        ' Pre-fill shop name with their registered name as a suggestion
        txtShopName.Text = SessionManager.Username & "'s Shop"
        txtShopName.ForeColor = Color.FromArgb(51, 51, 51)

        SetPlaceholder(txtContact, "Contact Number")
        SetPlaceholder(txtDescription, "Tell buyers what you sell...")
    End Sub
    Private Sub frmVendorSetup_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
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
    ' Focus events — Shop Name
    ' -------------------------------------------------------
    Private Sub txtShopName_Enter(sender As Object, e As EventArgs) Handles txtShopName.Enter
        pnlShopNameLine.BackColor = Color.FromArgb(219, 68, 68)
    End Sub
    Private Sub txtShopName_Leave(sender As Object, e As EventArgs) Handles txtShopName.Leave
        pnlShopNameLine.BackColor = Color.FromArgb(224, 224, 224)
    End Sub

    ' -------------------------------------------------------
    ' Focus events — Contact
    ' -------------------------------------------------------
    Private Sub txtContact_Enter(sender As Object, e As EventArgs) Handles txtContact.Enter
        RemovePlaceholder(txtContact)
        pnlContactLine.BackColor = Color.FromArgb(219, 68, 68)
    End Sub
    Private Sub txtContact_Leave(sender As Object, e As EventArgs) Handles txtContact.Leave
        SetPlaceholder(txtContact, "Contact Number")
        pnlContactLine.BackColor = Color.FromArgb(224, 224, 224)
    End Sub

    ' -------------------------------------------------------
    ' Focus events — Description
    ' -------------------------------------------------------
    Private Sub txtDescription_Enter(sender As Object, e As EventArgs) Handles txtDescription.Enter
        RemovePlaceholder(txtDescription)
    End Sub
    Private Sub txtDescription_Leave(sender As Object, e As EventArgs) Handles txtDescription.Leave
        SetPlaceholder(txtDescription, "Tell buyers what you sell...")
    End Sub

    ' -------------------------------------------------------
    ' Save & Continue
    ' -------------------------------------------------------
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        lblError.Text = ""

        Dim shopName As String = txtShopName.Text.Trim()
        Dim contact As String = txtContact.Text.Trim()
        Dim description As String = txtDescription.Text.Trim()

        ' Validate
        If String.IsNullOrWhiteSpace(shopName) Then
            ShowError("Please enter your shop name.") : Return
        End If

        If String.IsNullOrWhiteSpace(contact) OrElse contact = "Contact Number" Then
            ShowError("Please enter a contact number.") : Return
        End If

        ' Clean up placeholders
        If description = "Tell buyers what you sell..." Then description = ""

        Try
            ' Update Vendors table with shop details
            Dim sql As String =
                "UPDATE Vendors
                 SET shopName = @shopName,
                     contact = @contact,
                     description = @description
                 WHERE userId = @userId"

            DataAccess.ExecuteNonQuery(sql,
                New SqlParameter("@shopName", shopName),
                New SqlParameter("@contact", contact),
                New SqlParameter("@description", If(String.IsNullOrWhiteSpace(description),
                                                    DBNull.Value, CObj(description))),
                New SqlParameter("@userId", SessionManager.UserId))

            LogManager.Log(SessionManager.UserId, "ShopSetup", "Shop profile saved: " & shopName)

            ' Go to Vendor Dashboard
            GoToDashboard()

        Catch ex As Exception
            ShowError("Failed to save shop details: " & ex.Message)
        End Try
    End Sub

    ' -------------------------------------------------------
    ' Skip — go straight to dashboard without saving
    ' -------------------------------------------------------
    Private Sub lblSkip_Click(sender As Object, e As EventArgs) Handles lblSkip.Click
        GoToDashboard()
    End Sub

    ' -------------------------------------------------------
    ' Navigate to Vendor Dashboard
    ' -------------------------------------------------------
    Private Sub GoToDashboard()
        ' Refresh RoleId with actual vendorId from DB
        Dim sql As String = "SELECT vendorId FROM Vendors WHERE userId = @userId"
        Dim result As Object = DataAccess.ExecuteScalar(sql,
        New SqlParameter("@userId", SessionManager.UserId))

        If result IsNot Nothing AndAlso result IsNot DBNull.Value Then
            SessionManager.SetSession(
            SessionManager.UserId,
            SessionManager.Username,
            SessionManager.Role,
            CInt(result))
        End If

        Dim dashboard As New frmVendorDashboard()
        dashboard.Show()
        Me.Hide()
    End Sub

    ' -------------------------------------------------------
    ' Button hover
    ' -------------------------------------------------------
    Private Sub btnSave_MouseEnter(sender As Object, e As EventArgs) Handles btnSave.MouseEnter
        btnSave.BackColor = Color.FromArgb(193, 51, 51)
    End Sub
    Private Sub btnSave_MouseLeave(sender As Object, e As EventArgs) Handles btnSave.MouseLeave
        btnSave.BackColor = Color.FromArgb(219, 68, 68)
    End Sub

    ' -------------------------------------------------------
    ' Helper
    ' -------------------------------------------------------
    Private Sub ShowError(message As String)
        lblError.Text = message
    End Sub

End Class