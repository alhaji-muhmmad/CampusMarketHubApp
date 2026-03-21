Public Class PendingRegistration

    ' Holds signup data temporarily until email is verified
    Public Shared Property FullName As String = ""
    Public Shared Property Username As String = ""
    Public Shared Property Email As String = ""
    Public Shared Property Password As String = ""
    Public Shared Property Role As String = ""

    Public Shared Sub Clear()
        FullName = ""
        Username = ""
        Email = ""
        Password = ""
        Role = ""
    End Sub

End Class