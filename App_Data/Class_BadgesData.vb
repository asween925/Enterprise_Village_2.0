Imports System.Data.SqlClient

Public Class Class_BadgesData
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
    Dim studentCount As String


    'Loads a table of saved badges from a passed through visit ID. Optional where and order by clauses
    Function LoadExistingBadgesTable(VisitID As String, Optional SQLWhere As String = "", Optional SQLOrderBy As String = "")
        Dim SQLStatement As String = "SELECT b.id, s.accountNumber, CONCAT(s.firstName, ' ', s.lastName) as employeeName, CONCAT('~/media/', b.photoPath) as photoPath, bi.businessName, j.jobTitle
                                        FROM badges b
                                        INNER JOIN studentInfo s
                                        ON b.studentID = s.id
                                        INNER JOIN businessInfo bi
                                        ON bi.id = s.businessID
                                        INNER JOIN jobs j
                                        ON j.id = s.jobID
                                        WHERE b.visitID = '" & VisitID & "'"

        'Check if where clause and order by clause is not blank
        If SQLWhere <> "" Then
            SQLStatement &= SQLWhere & SQLOrderBy
        Else
            SQLStatement &= SQLOrderBy
        End If

        'Populate existing badges table
        cmd.Dispose()
        con.Close()
        con.ConnectionString = connection_string
        con.Open()
        cmd.CommandText = SQLStatement
        cmd.Connection = con


        Dim da As New SqlDataAdapter
        da.SelectCommand = cmd
        Dim dt As New DataTable
        da.Fill(dt)

        cmd.Dispose()
        con.Close()

        Return dt

    End Function


    'Populates a gridview with student names that have a badge saved in the DB
    Function LoadExistingBadgesNamesDDL(VisitID As String, StudentNamesDDL As DropDownList)
        Dim SQLStatement As String = " SELECT CONCAT(s.accountNumber, '. ', + s.firstName, ' ', s.lastName)
                                        FROM badges b
										INNER JOIN studentInfo s
										ON b.studentID = s.id
                                        WHERE b.visitID='" & VisitID & "'
                                        ORDER BY s.accountNumber DESC"

        'Add student names who have a saved badge to DDL
        con.ConnectionString = connection_string
        con.Open()
        cmd.CommandText = SQLStatement
        cmd.Connection = con
        dr = cmd.ExecuteReader

        While dr.Read()
            StudentNamesDDL.Items.Add(dr(0).ToString)
        End While

        StudentNamesDDL.Items.Insert(0, "")

        cmd.Dispose()
        con.Close()

        Return StudentNamesDDL
    End Function


    'Checks if a badge exists
    Function CheckIfBadgeExists(VisitID As String, AccountNumber As String)
        Dim NumberCheck As Boolean = False

        cmd.Connection = con
        con.ConnectionString = connection_string
        con.Open()
        cmd.CommandText = "SELECT s.accountNumber FROM badges b INNER JOIN studentInfo s ON b.studentID = s.id WHERE b.visitID='" + VisitID + "' AND s.accountNumber='" + AccountNumber + "'"
        dr = cmd.ExecuteReader

        While dr.Read()
            If dr.HasRows = True Then
                NumberCheck = True
            End If
        End While

        dr.Close()
        cmd.Dispose()
        con.Close()

        Return NumberCheck
    End Function


    'Insert new badge into database
    Sub CreateBadge(VisitID As Integer, StudentID As Integer, PhotoPath As String)
        con.ConnectionString = connection_string
        con.Open()
        cmd = New SqlCommand
        cmd.Connection = con
        cmd.CommandText = "INSERT INTO badges (visitID, studentID, photoPath) VALUES ('" & VisitID & "', '" & StudentID & "', '" & PhotoPath & "')"
        cmd.ExecuteNonQuery()

        cmd.Dispose()
        con.Close()
    End Sub


End Class
