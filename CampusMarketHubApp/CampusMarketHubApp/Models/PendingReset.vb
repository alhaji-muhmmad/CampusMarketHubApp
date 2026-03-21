Public Class PendingReset
    Public Shared Property UserId As Integer = 0
    Public Shared Property Email As String = ""

    Public Shared Sub Clear()
        UserId = 0
        Email = ""
    End Sub
End Class