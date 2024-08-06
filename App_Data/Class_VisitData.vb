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

    'Gets the current visit ID of today (if any)
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

    'Gets the id of a visit date
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

    'Gets the date of a visit ID
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

    'Returns a named column from the visit info table from a visit date
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

    'Loads the visit info table with optional where clauses
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

    'Loads the Edit Visit table
    Function LoadEditVisitTable(VisitDate As String)
        Dim da As New SqlDataAdapter
        Dim dt As New DataTable
        Dim SQLStatement As String = "SELECT v.id, s.id as 'schoolid1', s2.id as 'schoolid2', s3.id as 'schoolid3', s4.id as 'schoolid4', s5.id as 'schoolid5', s.schoolName as 'schoolname1', s2.schoolName as 'schoolname2', s3.schoolName as 'schoolname3', s4.schoolName as 'schoolname4', s5.schoolName as 'schoolname5', v.vTrainingTime, v.vMinCount, v.vMaxCount, v.replyBy, v.visitDate, v.studentCount, v.visitTime
                                  FROM visitInfo v 
                                  LEFT JOIN schoolInfo s ON s.ID = v.school
								  LEFT JOIN schoolInfo s2 ON s2.ID = v.school2
								  LEFT JOIN schoolInfo s3 ON s3.ID = v.school3
								  LEFT JOIN schoolInfo s4 ON s4.ID = v.school4
								  LEFT JOIN schoolInfo s5 ON s5.ID = v.school5
                                  WHERE v.visitDate = '" & VisitDate & "'"

        con.ConnectionString = connection_string
        con.Open()
        cmd = New SqlCommand
        cmd.Connection = con
        cmd.CommandText = SQLStatement
        da.SelectCommand = cmd
        da.Fill(dt)

        Return dt
    End Function

    'Returns a DDL of visit dates from a specific school ID
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

    'Moves the current visit date into the previous visit date in the school info table, adds a new current visit date
    Sub MoveVisitDate(School1 As String, School2 As String, School3 As String, School4 As String, School5 As String, VisitDate As String)
        Dim SQLStatement As String = "UPDATE schoolInfo SET previousVisitDate=currentVisitDate WHERE schoolName=@schoolName OR schoolName=@schoolName2 OR schoolName=@schoolName3 OR schoolName=@schoolName4 OR schoolName=@schoolName5"
        Dim SQLStatement2 As String = "UPDATE schoolInfo SET currentVisitDate=@currentVisitDate WHERE schoolName=@schoolNameB OR schoolName=@schoolName2B OR schoolName=@schoolName3B OR schoolName=@schoolName4B OR schoolName=@schoolName5B"

        'Move old visit date to previous visit date in visitInfo in DB
        con.ConnectionString = connection_string
        con.Open()
        cmd.CommandText = SQLStatement
        cmd.Parameters.Add("@schoolname", SqlDbType.VarChar).Value = School1
        cmd.Parameters.Add("@schoolname2", SqlDbType.VarChar).Value = School2
        cmd.Parameters.Add("@schoolname3", SqlDbType.VarChar).Value = School3
        cmd.Parameters.Add("@schoolname4", SqlDbType.VarChar).Value = School4
        cmd.Parameters.Add("@schoolname5", SqlDbType.VarChar).Value = School5
        cmd.Connection = con
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        con.Close()

        'Update currentVisitDate in visitInfo
        con.ConnectionString = connection_string
        con.Open()
        cmd.CommandText = SQLStatement2
        cmd.Parameters.Add("@schoolnameB", SqlDbType.VarChar).Value = School1
        cmd.Parameters.Add("@schoolname2B", SqlDbType.VarChar).Value = School2
        cmd.Parameters.Add("@schoolname3B", SqlDbType.VarChar).Value = School3
        cmd.Parameters.Add("@schoolname4B", SqlDbType.VarChar).Value = School4
        cmd.Parameters.Add("@schoolname5B", SqlDbType.VarChar).Value = School5
        cmd.Parameters.Add("@currentVisitDate", SqlDbType.Date).Value = VisitDate
        cmd.Connection = con
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        con.Close()

    End Sub

    'Creates a new visit date
    Sub CreateVisit(VisitDate As String, ReplyBy As String, SchoolName1 As String, SchoolName2 As String, SchoolName3 As String, SchoolName4 As String, SchoolName5 As String, VisitTime As String, TrainingTime As String, StudentCount As Integer)
        Dim SQLVisitInfo As String = "INSERT INTO visitInfo(school, vTrainingTime, replyBy, visitDate, studentCount, school2, school3, school4, visitTime, school5, teacherCompleted, deposit2Enable, deposit3Enable)
						SELECT (SELECT ID FROM schoolInfo WHERE schoolname = '" & SchoolName1 & "'), '" & TrainingTime & "', '" & ReplyBy & "', '" & VisitDate & "', '" & StudentCount & "', 
                        (SELECT ID FROM schoolInfo WHERE schoolname = '" & SchoolName2 & "'), 
                        (SELECT ID FROM schoolInfo WHERE schoolname = '" & SchoolName3 & "'), 
                        (SELECT ID FROM schoolInfo WHERE schoolname = '" & SchoolName4 & "'), '" & VisitTime & "', 
                        (SELECT ID FROM schoolInfo WHERE schoolname = '" & SchoolName5 & "'), teacherCompleted=0, deposit2Enable=0, deposit3Enable=0"

        Dim SQLBusinessVisitInfo As String = "INSERT INTO businessVisitInfo(visitID, schoolID, businessID, openstatus, minVolCount, maxVolCount, loanAmount, deposit1, deposit2, deposit3, deposit4, profit)
										SELECT (SELECT ID FROM visitInfo WHERE visitDate = '" & VisitDate & "'), 
                                        (SELECT ID FROM schoolInfo WHERE schoolName = '" & SchoolName1 & "'), businessID, 1, 0, 0, 
                                        loanAmount, deposit1, deposit2, deposit3, deposit4, profit 
                                        FROM businessVisitInfo_template t"

        Dim SQLStudentInfo As String = "INSERT INTO studentInfo (accountNumber, firstName, lastName, schoolID, businessID, jobID, visitID, netDeposit1, netDeposit2)
										SELECT accountNumber, firstName, lastName, 
                                        (SELECT ID FROM schoolInfo WHERE schoolName = '" & SchoolName1 & "'), businessID, jobID, 
                                        (SELECT ID FROM visitInfo WHERE visitDate = '" & VisitDate & "'), netDeposit1, netDeposit2
										FROM studentInfo_template t "

        Dim VisitID As String
        Dim SQLProfits As String

        'Insert data into visitInfo in DB
        con.ConnectionString = connection_string
        con.Open()
        cmd.CommandText = SQLVisitInfo
        cmd.Connection = con
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        con.Close()

        'Insert data into businessVisitInfo in DB
        con.ConnectionString = connection_string
        con.Open()
        cmd.CommandText = SQLBusinessVisitInfo
        cmd.Connection = con
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        con.Close()

        'Insert data into studentInfo in DB
        con.ConnectionString = connection_string
        con.Open()
        cmd.CommandText = SQLStudentInfo
        cmd.Connection = con
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        con.Close()

        'Get new visit ID
        VisitID = GetVisitIDFromDate(VisitDate)

        'Profit SQL with new visit ID
        SQLProfits = "UPDATE businessVisitInfo SET profit = b.startingBalance FROM businessVisitInfo o JOIN businessInfo b ON o.businessID= b.id WHERE visitID='" & VisitID & "'"

        'Change profit number to starting balance amount in businessVisitInfo table
        con.ConnectionString = connection_string
        con.Open()
        cmd.CommandText = SQLProfits
        cmd.Connection = con
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        con.Close()

    End Sub

    'Updates business info with updated schools after changing them in Edit Visit
    Sub UpdateBusinessVisitInfo(SchoolID1 As String, SchoolID2 As String, SchoolID3 As String, SchoolID4 As String, SchoolID5 As String, VisitID As String)
        Dim SQL1 As String = "UPDATE businessVisitInfo SET schoolID='" & SchoolID1 & "' WHERE visitID='" & VisitID & "' AND NOT (schoolID = '" & SchoolID2 & "' OR schoolID = '" & SchoolID3 & "' OR schoolID = '" & SchoolID4 & "' OR schoolID = '" & SchoolID5 & "')"
        Dim SQL2 As String = "UPDATE businessVisitInfo SET schoolID='" & SchoolID2 & "' WHERE visitID='" & VisitID & "' AND NOT (schoolID = '" & SchoolID1 & "' OR schoolID = '" & SchoolID3 & "' OR schoolID = '" & SchoolID4 & "' OR schoolID = '" & SchoolID5 & "')"
        Dim SQL3 As String = "UPDATE businessVisitInfo SET schoolID='" & SchoolID3 & "' WHERE visitID='" & VisitID & "' AND NOT (schoolID = '" & SchoolID2 & "' OR schoolID = '" & SchoolID1 & "' OR schoolID = '" & SchoolID4 & "' OR schoolID = '" & SchoolID5 & "')"
        Dim SQL4 As String = "UPDATE businessVisitInfo SET schoolID='" & SchoolID4 & "' WHERE visitID='" & VisitID & "' AND NOT (schoolID = '" & SchoolID3 & "' OR schoolID = '" & SchoolID1 & "' OR schoolID = '" & SchoolID2 & "' OR schoolID = '" & SchoolID5 & "')"
        Dim SQL5 As String = "UPDATE businessVisitInfo SET schoolID='" & SchoolID5 & "' WHERE visitID='" & VisitID & "' AND NOT (schoolID = '" & SchoolID4 & "' OR schoolID = '" & SchoolID1 & "' OR schoolID = '" & SchoolID2 & "' OR schoolID = '" & SchoolID3 & "')"

        'Update with 1st school ID
        Using con As New SqlConnection(connection_string)
            Using cmd As New SqlCommand(SQL1)
                cmd.Connection = con
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using

        'Update with 2nd school ID
        Using con As New SqlConnection(connection_string)
            Using cmd As New SqlCommand(SQL2)
                cmd.Connection = con
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using

        'Update with 3rd school ID
        Using con As New SqlConnection(connection_string)
            Using cmd As New SqlCommand(SQL3)
                cmd.Connection = con
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using

        'Update with 4th school ID
        Using con As New SqlConnection(connection_string)
            Using cmd As New SqlCommand(SQL4)
                cmd.Connection = con
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using

        'Update with 5th school ID
        Using con As New SqlConnection(connection_string)
            Using cmd As New SqlCommand(SQL5)
                cmd.Connection = con
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using
    End Sub

    'Gets the visit ID from a school ID
    Function GetVisitIDFromSchoolID(SchoolID As Integer)
        Dim visitIDSQL As String = "SELECT id FROM visitInfo WHERE school = '" & SchoolID & "' OR school2 = '" & SchoolID & "' OR school3 = '" & SchoolID & "' OR school4 = '" & SchoolID & "' OR school5 = '" & SchoolID & "'"
        Dim returnValue As Integer

        con.ConnectionString = connection_string
        con.Open()
        cmd.CommandText = visitIDSQL
        cmd.Connection = con
        dr = cmd.ExecuteReader

        While dr.Read
            returnValue = dr("id").ToString
        End While

        cmd.Dispose()
        con.Close()

        Return returnValue
    End Function


End Class
