Public Class SessionManager

    ' Holds current logged-in user details
    Public Shared Property UserId As Integer = 0
    Public Shared Property Username As String = ""
    Public Shared Property Role As String = ""
    Public Shared Property RoleId As Integer = 0
    ' RoleId = vendorId if Vendor, buyerId if Buyer, 0 if Admin

    Public Shared ReadOnly Property IsLoggedIn As Boolean
        Get
            Return UserId > 0
        End Get
    End Property

    ' Call this on successful login
    Public Shared Sub SetSession(id As Integer, name As String,
                              role As String, Optional roleId As Integer = 0)
        UserId = id
        Username = name
        role = role
        SessionManager.RoleId = roleId
    End Sub

    ' Call this on logout
    Public Shared Sub ClearSession()
        UserId = 0
        Username = ""
        Role = ""
        RoleId = 0
    End Sub

End Class