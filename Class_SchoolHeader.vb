Imports System.Data.SqlClient
Public Class Class_SchoolHeader
    Dim VisitID As New Class_VisitData
    Dim Visit As Integer = VisitID.GetVisitID
    Dim schoolHeader As String = "SELECT s.SchoolName FROM Schoolinfo s INNER JOIN visitInfo v on s.ID = v.School WHERE v.id='" & Visit & "'"
    Dim schoolHeader2 As String = "SELECT s.SchoolName FROM Schoolinfo s INNER JOIN visitInfo v on s.ID = v.School2 WHERE v.id='" & Visit & "'"
    Dim schoolHeader3 As String = "SELECT s.SchoolName FROM Schoolinfo s INNER JOIN visitInfo v on s.ID = v.School3 WHERE v.id='" & Visit & "'"
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
    Dim returnSchool1 As String
    Dim returnSchool2 As String
    Dim returnSchool3 As String
    Dim returnSchool As String = "No School Scheduled"

    Function GetSchoolHeader()

        'Populating header school and school name label
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd.CommandText = schoolHeader
            cmd.Connection = con
            dr = cmd.ExecuteReader

            While dr.Read()
                returnSchool1 = dr("schoolName").ToString
            End While

            cmd.Dispose()
            con.Close()

        Catch

        Finally
            cmd.Dispose()
            con.Close()

        End Try

        'School 2
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd.CommandText = schoolHeader2
            cmd.Connection = con
            dr = cmd.ExecuteReader

            While dr.Read()
                returnSchool2 = " And " & dr("schoolName").ToString

                If returnSchool2 = " And " & " " Then
                    returnSchool2 = ""
                End If
            End While

            cmd.Dispose()
            con.Close()

        Catch

        Finally
            cmd.Dispose()
            con.Close()

        End Try

        'School 3
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd.CommandText = schoolHeader3
            cmd.Connection = con
            dr = cmd.ExecuteReader

            While dr.Read()
                returnSchool3 = " And " & dr("schoolName").ToString

                If returnSchool3 = " And " & " " Then
                    returnSchool3 = ""
                End If
            End While

            cmd.Dispose()
            con.Close()

        Catch

        Finally
            cmd.Dispose()
            con.Close()

        End Try

        returnSchool = returnSchool1 & returnSchool2 & returnSchool3

        If Visit = 0 Or Visit = Nothing Then
            returnSchool = "No School Scheduled"
        End If

        Return returnSchool

    End Function

End Class
