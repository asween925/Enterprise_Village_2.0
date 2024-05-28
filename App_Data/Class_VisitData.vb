Imports System.Data.Common
Imports System.Data.SqlClient

Public Class Class_VisitData
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim DBConnection As New DatabaseConection
    Dim dr As SqlDataReader
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"

    Function GetVisitID() As Integer
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim dr As SqlDataReader
        Dim dateSQL As String = "SELECT ID FROM visitInfo WHERE visitDate = '" & Date.Now.ToShortDateString & "'"
        Dim returnValue As Integer = 0
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand

        con.ConnectionString = connection_string
        con.Open()
        cmd.CommandText = dateSQL
        cmd.Connection = con
        dr = cmd.ExecuteReader


        If dr.HasRows Then
            While dr.Read
                returnValue = dr("ID")
            End While
        Else
            'No visit on current date
            returnValue = 0

        End If
        cmd.Dispose()
        con.Close()


        Return returnValue
    End Function

    Function GetVisitIDFromDate(visitDate As String)
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim dr As SqlDataReader
        Dim dateSQL As String = "SELECT ID FROM visitInfo WHERE visitDate = '" & visitDate & "'"
        Dim returnValue As Integer = 0
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand

        con.ConnectionString = connection_string
        con.Open()
        cmd.CommandText = dateSQL
        cmd.Connection = con
        dr = cmd.ExecuteReader

        If dr.HasRows Then
            While dr.Read
                returnValue = dr("ID")
            End While
        Else
            'No visit on current date
            returnValue = 0

        End If
        cmd.Dispose()
        con.Close()


        Return returnValue
    End Function

    Function GetVisitDateFromID(VisitID As String)
        Dim dateSQL As String = "SELECT visitDate FROM visitInfo WHERE id = '" & VisitID & "'"
        Dim returnValue As String

        con.ConnectionString = connection_string
        con.Open()
        cmd.CommandText = dateSQL
        cmd.Connection = con
        dr = cmd.ExecuteReader

        If dr.HasRows Then
            While dr.Read
                returnValue = dr("visitDate").ToString
            End While
        Else
            'No visit on current date
            returnValue = ""

        End If
        cmd.Dispose()
        con.Close()


        Return returnValue
    End Function

    Function LoadVisitInfoFromDate(VisitDate As String, Column As String)
        Dim ReturnData As String = ""

        'Get school info from school name
        con.ConnectionString = connection_string
        con.Open()
        cmd.CommandText = "SELECT " & Column & " FROM visitInfo WHERE visitDate = '" & VisitDate & "'"
        cmd.Connection = con
        dr = cmd.ExecuteReader

        While dr.Read()
            ReturnData = dr(Column).ToString()
            cmd.Dispose()
            con.Close()
            Return ReturnData
        End While

        cmd.Dispose()
        con.Close()

        Return ReturnData
    End Function

    Function LoadVisitInfoTable(Optional SQLWhereVisitDate As String = Nothing, Optional SQLWhereSchool As String = Nothing, Optional SQLWhereMonth As String = Nothing, Optional SQLWhereNot As String = Nothing)
        Dim SQLStatement As String = "SELECT v.id, IIF(s.id='505', s.schoolName, CONCAT(s.schoolName, ' (', s.id, ')')) as 'School #1',
		                                    IIF(s2.id='505', s2.schoolName, CONCAT(s2.schoolName, ' (', s2.id, ')')) as 'School #2', 
                                             IIF(s3.id='505', s3.schoolName, CONCAT(s3.schoolName, ' (', s3.id, ')')) as 'School #3', 
                                             IIF(s4.id='505', s4.schoolName, CONCAT(s4.schoolName, ' (', s4.id, ')')) as 'School #4', 
                                             IIF(s5.id='505', s5.schoolName, CONCAT(s5.schoolName, ' (', s5.id, ')')) as 'School #5',
                                            v.vTrainingTime, v.vMinCount, v.vMaxCount, v.replyBy, v.visitDate, v.studentCount, v.vLead
                                            ,v.floorFacilitator, v.backupTeacher, v.visitTime, v.teacherCompleted, v.lastEdited
                                            FROM visitInfo v 
                                            LEFT JOIN schoolInfo s ON s.ID = v.school
                                            LEFT JOIN schoolInfo s2 ON s2.ID = v.school2
                                            LEFT JOIN schoolInfo s3 ON s3.ID = v.school3
                                            LEFT JOIN schoolInfo s4 ON s4.ID = v.school4
                                            LEFT JOIN schoolInfo s5 ON s5.ID = v.school5"

        If SQLWhereVisitDate <> Nothing Then
            SQLStatement &= SQLWhereVisitDate
        End If

        If SQLWhereSchool <> Nothing Then
            SQLStatement &= SQLWhereSchool
        End If

        If SQLWhereMonth <> Nothing Then
            SQLStatement &= SQLWhereMonth
        End If

        If SQLWhereSchool = Nothing And SQLWhereVisitDate = Nothing Then
            SQLStatement &= SQLWhereNot
        End If

        con.ConnectionString = connection_string
        con.Open()
        cmd = New SqlCommand
        cmd.Connection = con
        cmd.CommandText = SQLStatement

        Dim da As New SqlDataAdapter
        da.SelectCommand = cmd
        Dim dt As New DataTable
        da.Fill(dt)

        Return dt
    End Function

    Function LoadVisitDatesFromSchool(SchoolID As String, VisitDateDDL As DropDownList)
        Dim ReturnData As String = ""

        'Get school info from school name
        con.ConnectionString = connection_string
        con.Open()
        cmd.CommandText = "SELECT FORMAT (visitDate, 'MM/dd/yyyy') FROM visitInfo WHERE school = '" & SchoolID & "' Or school2 = '" & SchoolID & "' Or school3 = '" & SchoolID & "' Or school4 = '" & SchoolID & "' Or school5 = '" & SchoolID & "'"
        cmd.Connection = con
        dr = cmd.ExecuteReader

        While dr.Read()
            While dr.Read()
                VisitDateDDL.Items.Add(dr(0).ToString)
            End While

            VisitDateDDL.Items.Insert(0, "")
        End While

        cmd.Dispose()
        con.Close()

        Return ReturnData
    End Function

End Class
