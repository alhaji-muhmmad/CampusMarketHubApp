Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class DataAccess

    ' Reads connection string from App.config - single source of truth
    Private Shared ReadOnly ConnectionString As String =
        ConfigurationManager.ConnectionStrings("CampusMarketHub").ConnectionString

    ' -------------------------------------------------------
    ' ExecuteNonQuery
    ' Use for: INSERT, UPDATE, DELETE
    ' Returns number of rows affected
    ' -------------------------------------------------------
    Public Shared Function ExecuteNonQuery(sql As String,
                                           ParamArray params() As SqlParameter) As Integer
        Using conn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand(sql, conn)
                If params IsNot Nothing Then
                    cmd.Parameters.AddRange(params)
                End If
                conn.Open()
                Return cmd.ExecuteNonQuery()
            End Using
        End Using
    End Function

    ' -------------------------------------------------------
    ' ExecuteScalar
    ' Use for: queries that return a single value
    ' e.g. SELECT COUNT(*), SELECT userId after INSERT
    ' -------------------------------------------------------
    Public Shared Function ExecuteScalar(sql As String,
                                         ParamArray params() As SqlParameter) As Object
        Using conn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand(sql, conn)
                If params IsNot Nothing Then
                    cmd.Parameters.AddRange(params)
                End If
                conn.Open()
                Return cmd.ExecuteScalar()
            End Using
        End Using
    End Function

    ' -------------------------------------------------------
    ' ExecuteQuery
    ' Use for: SELECT queries that return multiple rows
    ' Returns a DataTable you can bind to grids or loop through
    ' -------------------------------------------------------
    Public Shared Function ExecuteQuery(sql As String,
                                        ParamArray params() As SqlParameter) As DataTable
        Using conn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand(sql, conn)
                If params IsNot Nothing Then
                    cmd.Parameters.AddRange(params)
                End If
                Using adapter As New SqlDataAdapter(cmd)
                    Dim table As New DataTable()
                    adapter.Fill(table)
                    Return table
                End Using
            End Using
        End Using
    End Function

    ' -------------------------------------------------------
    ' TestConnection
    ' Use this on startup to verify DB is reachable
    ' -------------------------------------------------------
    Public Shared Function TestConnection() As Boolean
        Try
            Using conn As New SqlConnection(ConnectionString)
                conn.Open()
                Return True
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class