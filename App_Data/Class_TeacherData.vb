Imports System.Data.SqlClient

Public Class Class_TeacherData
	Dim VisitID As New Class_VisitData
	Dim Visit As Integer = VisitID.GetVisitID
	Dim con As New SqlConnection
	Dim cmd As New SqlCommand
	Dim dr As SqlDataReader
	Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
	Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
	Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
	Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
	Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
	Dim volRange As String
	Dim vMin As String
	Dim vMax As String
	Dim errorStr As String

	'Gets the contact teacher name
	Function GetContactTeacher(SchoolID As String)
		Dim returnData As String = ""

		'Get school info from school name
		con.ConnectionString = connection_string
		con.Open()
		cmd.CommandText = "SELECT TRIM(firstName) + ' ' + TRIM(lastName) as teacherName FROM teacherInfo WHERE schoolID = '" & SchoolID & "' AND isContact=1"
		cmd.Connection = con
		dr = cmd.ExecuteReader

		While dr.Read()
			returnData = dr("teacherName").ToString()
			cmd.Dispose()
			con.Close()
			Return returnData
		End While

		cmd.Dispose()
		con.Close()

		Return returnData
	End Function


	'Gets first and last name of teacher from a school name
	Function LoadTeacherNameDDL(SchoolID As String, DDL As DropDownList)
		con.ConnectionString = connection_string
		con.Open()
		cmd.CommandText = "SELECT firstName, lastName FROM teacherInfo WHERE schoolID='" & SchoolID & "'"
		cmd.Connection = con
		dr = cmd.ExecuteReader

		While dr.Read()
			DDL.Items.Add(dr(0).ToString & " " & dr(1).ToString)
		End While

		DDL.Items.Insert(0, "")

		cmd.Dispose()
		con.Close()

		Return DDL
	End Function


	'Loads teacher info table
	Function LoadTeacherInfoTable(Table As GridView, Optional SchoolName As String = "", Optional SearchTerm As String = "")
		Dim dt As New DataTable
		Dim da As New SqlDataAdapter
		Dim SQLStatement As String = "SELECT DISTINCT t.id, t.isContact, t.studentCount, t.password, t.county, s.schoolName, t.futureRequestsEmail, t.firstName, t.lastName FROM teacherInfo t JOIN schoolInfo s ON s.id=t.schoolID"

		'If school name is not blank, add a where clause to the statement
		If SchoolName <> "" Then
			SQLStatement = SQLStatement & " WHERE s.schoolName='" & SchoolName & "'"
		ElseIf SearchTerm <> "" Then
			SQLStatement = SQLStatement & " WHERE s.schoolName Like '%" & SearchTerm & "%'
											 Or t.county Like '%" & SearchTerm & "%'
											 Or t.futureRequestsEmail Like '%" & SearchTerm & "%'
											 Or t.firstName Like '%" & SearchTerm & "%'
											 Or t.lastName Like '%" & SearchTerm & "%'
											 ORDER BY t.lastName"
		End If

		'Return teacherinfo table
		con.ConnectionString = connection_string
		con.Open()
		cmd.CommandText = SQLStatement
		cmd.Connection = con
		da.SelectCommand = cmd
		da.Fill(dt)
		Table.DataSource = dt
		Table.DataBind()

		cmd.Dispose()
		con.Close()

		Return Table
	End Function


	'Get teacher first and last name
	Function GetTeacherFullName(TeacherID As String)
		Dim TeacherName As String = ""

		'Get school info from school name
		con.ConnectionString = connection_string
		con.Open()
		cmd.CommandText = "SELECT TRIM(firstName) + ' ' + TRIM(lastName) as teacherName FROM teacherInfo WHERE id = '" & TeacherID & "'"
		cmd.Connection = con
		dr = cmd.ExecuteReader

		While dr.Read()
			TeacherName = dr("teacherName").ToString()
			cmd.Dispose()
			con.Close()
			Return TeacherName
		End While

		cmd.Dispose()
		con.Close()

		Return TeacherName
	End Function

End Class
