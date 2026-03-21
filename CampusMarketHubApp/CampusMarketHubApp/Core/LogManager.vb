Imports System.Data.SqlClient

Public Class LogManager

    ' Call this anywhere in the system to log a user action
    Public Shared Sub Log(userId As Integer, action As String,
                          Optional description As String = "")
        Try
            Dim sql As String = "INSERT INTO ActivityLogs (userId, action, description)
                                 VALUES (@userId, @action, @description)"

            DataAccess.ExecuteNonQuery(sql,
                New SqlParameter("@userId", userId),
                New SqlParameter("@action", action),
                New SqlParameter("@description", description))
        Catch ex As Exception
            ' Log silently - never crash the app because of a logging failure
        End Try
    End Sub

End Class