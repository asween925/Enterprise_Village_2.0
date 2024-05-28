Imports System.Data.SqlClient

Public Class Class_SchoolData
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

	'Populates a DDL with schools scheduled to come on an entered visit date
	Function LoadVisitDateSchoolsDDL(visitDate As String, schoolNameDDL As DropDownList)
		Dim errorString As String
		'Dim schoolNameDDL As DropDownList

		'Check if visit date has a date
		If visitDate <> Nothing Then

			'Clear out teacher and school DDLs
			schoolNameDDL.Items.Clear()

			'Populate school DDL from entered visit date
			Try
				con.ConnectionString = connection_string
				con.Open()
				cmd.CommandText = "SELECT s.schoolName as 'schoolName'
											  FROM schoolInfo s 
											  JOIN visitInfo v ON v.school = s.id OR v.school2 = s.id OR v.school3 = s.id OR v.school4 = s.id OR v.school5 = s.id
											  WHERE v.visitDate='" & visitDate & "' AND NOT s.id=505 
											  ORDER BY schoolName"
				cmd.Connection = con
				dr = cmd.ExecuteReader

				While dr.Read()
					schoolNameDDL.Items.Add(dr(0).ToString)
				End While

				schoolNameDDL.Items.Insert(0, "")

				cmd.Dispose()
				con.Close()

			Catch
				errorString = "Error in visitDate. Could not get school names."
				Return errorString
				Exit Function
			End Try

		End If

		Return schoolNameDDL.Items

	End Function

	'Populates a DDL with all schools in the DB
	Function LoadSchoolsDDL(schoolNameDDL As DropDownList)
		Dim errorString As String
		'Dim schoolNameDDL As DropDownList

		'Clear out teacher and school DDLs
		schoolNameDDL.Items.Clear()

		'Populate school DDL from entered visit date
		Try
			con.ConnectionString = connection_string
			con.Open()
			cmd.CommandText = "SELECT schoolname FROM schoolInfo  WHERE NOT schoolName = 'A1 No School Scheduled' AND NOT id='505' ORDER BY schoolName"
			cmd.Connection = con
			dr = cmd.ExecuteReader

			While dr.Read()
				schoolNameDDL.Items.Add(dr(0).ToString)
			End While

			schoolNameDDL.Items.Insert(0, "")

			cmd.Dispose()
			con.Close()

		Catch
			errorString = "Error in visitDate. Could not get school names."
			Return errorString
			Exit Function
		End Try

		Return schoolNameDDL.Items
	End Function

	'Gets data from a passed through column name and school name.
	Function LoadSchoolInfoFromSchool(schoolName As String, column As String)
		Dim returnData As String = ""

		'Get school info from school name
		con.ConnectionString = connection_string
		con.Open()
		cmd.CommandText = "SELECT " & column & " FROM schoolInfo WHERE schoolName = '" & schoolName & "'"
		cmd.Connection = con
		dr = cmd.ExecuteReader

		While dr.Read()
			returnData = dr(column).ToString()
			cmd.Dispose()
			con.Close()
			Return returnData
		End While

		cmd.Dispose()
		con.Close()

		Return returnData

	End Function

	'Gets the ID of a school name
	Function GetSchoolID(schoolName As String)
		Dim returnSchoolID As String = ""

		'Get school info from school name
		con.ConnectionString = connection_string
		con.Open()
		cmd.CommandText = "SELECT ID FROM schoolInfo WHERE schoolName = '" & schoolName & "'"
		cmd.Connection = con
		dr = cmd.ExecuteReader

		While dr.Read()
			returnSchoolID = dr("ID").ToString()
			cmd.Dispose()
			con.Close()
			Return returnSchoolID
		End While

		cmd.Dispose()
		con.Close()

		Return returnSchoolID
	End Function

	'Populates a DDL with schools scheduled to come on a entered visit date
	Function LoadVisitingSchoolsDDL(visitDate As String, DDL As DropDownList)
		Dim sqlStatement As String = "SELECT s.schoolName as 'schoolName'
											  FROM schoolInfo s 
											  JOIN visitInfo v ON v.school = s.id OR v.school2 = s.id OR v.school3 = s.id OR v.school4 = s.id OR v.school5 = s.id
											  WHERE v.visitDate='" & visitDate & "' AND NOT s.id=505 
											  ORDER BY schoolName"

		'Clear out business DDL
		DDL.Items.Clear()

		'Populate DDL
		con.ConnectionString = connection_string
		con.Open()
		cmd.CommandText = sqlStatement
		cmd.Connection = con
		dr = cmd.ExecuteReader

		While dr.Read()
			DDL.Items.Add(dr("schoolName").ToString)
		End While

		DDL.Items.Insert(0, "")

		cmd.Dispose()
		con.Close()

		Return DDL.Items

	End Function

	'Returns a list of all schools from a visit ID with commas seperating them and trims the end comma
	Function GetSchoolsString(VisitDate As String)
		Dim ReturnSchools As String = ""
		Dim School1 As String = ""
		Dim School2 As String = ""
		Dim School3 As String = ""
		Dim School4 As String = ""
		Dim School5 As String = ""
		Dim SQLStatement As String = "SELECT s.schoolName as 'School #1', s2.schoolName as 'School #2', s3.schoolName as 'School #3'
											, s4.schoolName as 'School #4', s5.schoolName as 'School #5'
                                            FROM visitInfo v 
                                            LEFT JOIN schoolInfo s ON s.ID = v.school
                                            LEFT JOIN schoolInfo s2 ON s2.ID = v.school2
                                            LEFT JOIN schoolInfo s3 ON s3.ID = v.school3
                                            LEFT JOIN schoolInfo s4 ON s4.ID = v.school4
                                            LEFT JOIN schoolInfo s5 ON s5.ID = v.school5
											 WHERE v.visitDate='" & VisitDate & "' AND NOT v.school=1 ORDER BY v.visitDate DESC"

		con.ConnectionString = connection_string
		con.Open()
		cmd.CommandText = SQLStatement
		cmd.Connection = con
		dr = cmd.ExecuteReader

		While dr.Read()
			School1 = dr(0).ToString
			School2 = dr(1).ToString
			School3 = dr(2).ToString
			School4 = dr(3).ToString
			School5 = dr(4).ToString
		End While

		If School2 <> " " Then
			School1 &= ", "
		End If

		If School3 <> " " Then
			School2 &= ", "
		End If

		If School4 <> " " Then
			School3 &= ", "
		End If

		If School5 <> " " Then
			School4 &= ", "
		End If

		cmd.Dispose()
		con.Close()

		ReturnSchools = School1 & School2 & School3 & School4 & School5
		Return ReturnSchools

	End Function

	'Returns a list of sharing schools
	Function GetSharedSchoolsString(VisitDate As String, SchoolName As String)
		Dim ReturnSchools As String
		Dim School1 As String = ""
		Dim School2 As String = ""
		Dim School3 As String = ""
		Dim School4 As String = ""
		Dim School5 As String = ""
		Dim SQLStatement As String = "SELECT s.schoolName as 'School #1', s2.schoolName as 'School #2', s3.schoolName as 'School #3'
											, s4.schoolName as 'School #4', s5.schoolName as 'School #5'
                                            FROM visitInfo v 
                                            LEFT JOIN schoolInfo s ON s.ID = v.school
                                            LEFT JOIN schoolInfo s2 ON s2.ID = v.school2
                                            LEFT JOIN schoolInfo s3 ON s3.ID = v.school3
                                            LEFT JOIN schoolInfo s4 ON s4.ID = v.school4
                                            LEFT JOIN schoolInfo s5 ON s5.ID = v.school5
											 WHERE v.visitDate='" & VisitDate & "' AND NOT v.school=1 ORDER BY v.visitDate DESC"

		con.ConnectionString = connection_string
		con.Open()
		cmd.CommandText = SQLStatement
		cmd.Connection = con
		dr = cmd.ExecuteReader

		While dr.Read()
			School1 = dr(0).ToString
			School2 = dr(1).ToString
			School3 = dr(2).ToString
			School4 = dr(3).ToString
			School5 = dr(4).ToString
		End While

		If School1 = SchoolName Then
			School1 = ""
		ElseIf School2 = SchoolName Then
			School2 = ""
		ElseIf School3 = SchoolName Then
			School3 = ""
		ElseIf School4 = SchoolName Then
			School4 = ""
		ElseIf School5 = SchoolName Then
			School5 = ""
		End If

		If School2 <> "" And School1 <> "" Then
			School1 &= ", "
		ElseIf School3 <> " " Then
			School2 &= ", "
		ElseIf School4 <> " " Then
			School3 &= ", "
		ElseIf School5 <> " " Then
			School4 &= ", "
		End If

		cmd.Dispose()
		con.Close()

		ReturnSchools = School1 & School2 & School3 & School4 & School5

		Return ReturnSchools

	End Function

	'Returns all school names from a visit date
	Function GetSchoolsIndividual(VisitDate As String) As (School1 As String, School2 As String, School3 As String, School4 As String, School5 As String)
		Dim S1 As String = ""
		Dim S2 As String = ""
		Dim S3 As String = ""
		Dim S4 As String = ""
		Dim S5 As String = ""
		Dim SQLStatement As String = "SELECT s.schoolName as 'School #1', s2.schoolName as 'School #2', s3.schoolName as 'School #3'
											, s4.schoolName as 'School #4', s5.schoolName as 'School #5'
                                            FROM visitInfo v 
                                            LEFT JOIN schoolInfo s ON s.ID = v.school
                                            LEFT JOIN schoolInfo s2 ON s2.ID = v.school2
                                            LEFT JOIN schoolInfo s3 ON s3.ID = v.school3
                                            LEFT JOIN schoolInfo s4 ON s4.ID = v.school4
                                            LEFT JOIN schoolInfo s5 ON s5.ID = v.school5
											 WHERE v.visitDate='" & VisitDate & "' AND NOT v.school=1 ORDER BY v.visitDate DESC"

		con.ConnectionString = connection_string
		con.Open()
		cmd.CommandText = SQLStatement
		cmd.Connection = con
		dr = cmd.ExecuteReader

		While dr.Read()
			S1 = dr(0).ToString
			S2 = dr(1).ToString
			S3 = dr(2).ToString
			S4 = dr(3).ToString
			S5 = dr(4).ToString
		End While

		cmd.Dispose()
		con.Close()

		Return (S1, S2, S3, S4, S5)
	End Function

	'Returns the minimum volunteer count and maximum volunteer count of a school
	Function GetVolunteerRange(VisitDate As String, Optional SchoolID As String = Nothing) As (VMin As String, VMax As String)
		Dim Min As String = "0"
		Dim Max As String = "0"
		Dim SQLStatment As String = "SELECT SUM(o.businessVMinCount) as vMin, SUM(o.businessVMaxCount) as vMax FROM onlineBanking o"

		If SchoolID <> Nothing Then
			SQLStatment += " WHERE o.visitDate='" & VisitDate & "' AND o.school='" & SchoolID & "' AND o.openstatus=1"
		Else
			SQLStatment += " WHERE o.visitDate='" & VisitDate & "' AND o.openstatus=1"
		End If

		con.ConnectionString = connection_string
		con.Open()
		cmd.CommandText = SQLStatment
		cmd.Connection = con
		dr = cmd.ExecuteReader

		While dr.Read()
			Min = dr("vMin").ToString
			Max = dr("vMax").ToString
		End While

		cmd.Dispose()
		con.Close()

		Return (Min, Max)
	End Function

	'Gets the school name from a school ID
	Function GetSchoolNameFromID(SchoolID As String)
		Dim returnSchoolName As String = ""

		'Get school info from school name
		con.ConnectionString = connection_string
		con.Open()
		cmd.CommandText = "SELECT schoolName FROM schoolInfo WHERE id = '" & SchoolID & "'"
		cmd.Connection = con
		dr = cmd.ExecuteReader

		While dr.Read()
			returnSchoolName = dr("schoolName").ToString()
			cmd.Dispose()
			con.Close()
			Return returnSchoolName
		End While

		cmd.Dispose()
		con.Close()

		Return returnSchoolName
	End Function

	'Moves current visit date to previous visit date
	Sub UpdatePreviousVisitDate(SchoolID As String)

		Using con As New SqlConnection(connection_string)
			Using cmd As New SqlCommand("UPDATE schoolInfo SET previousVisitDate=currentVisitDate WHERE id=@school")
				cmd.Parameters.AddWithValue("@school", SchoolID)
				cmd.Connection = con
				con.Open()
				cmd.ExecuteNonQuery()
				con.Close()
			End Using
		End Using

	End Sub

	'Updates current visit date in school Info
	Sub UpdateCurrentVisitDate(SchoolID As String, VisitDate As String)

		Using con As New SqlConnection(connection_string)
				Using cmd As New SqlCommand("UPDATE schoolInfo SET currentVisitDate=@VisitDate WHERE id=@school")
					cmd.Parameters.AddWithValue("@school", SchoolID)
					cmd.Parameters.AddWithValue("@VisitDate", VisitDate)
					cmd.Connection = con
					con.Open()
					cmd.ExecuteNonQuery()
					con.Close()
				End Using
			End Using

	End Sub

End Class
