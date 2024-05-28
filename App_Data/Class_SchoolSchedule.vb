Imports System.Data.SqlClient

Public Class Class_SchoolSchedule
	Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
	Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
	Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
	Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
	Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
	Dim con As New SqlConnection
	Dim cmd As New SqlCommand
	Dim dr As SqlDataReader

	'Load school schedule table
	Function LoadSchoolSchedule()
		Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
		Dim con As New SqlConnection
		Dim cmd As New SqlCommand
		Dim sqlStatement As String = "SELECT * FROM schoolSchedule"

		'Search and load kit inv table
		con.ConnectionString = connection_string
		con.Open()
		cmd = New SqlCommand()
		cmd.Connection = con
		cmd.CommandText = sqlStatement

		Dim da As New SqlDataAdapter
		da.SelectCommand = cmd
		Dim dt As New DataTable
		da.Fill(dt)

		cmd.Dispose()
		con.Close()

		Return dt

	End Function

	'Populates a DDL with all the available visit times
	Function LoadVisitTimeDDL(VisitTimeDDL As DropDownList)
		Dim errorString As String
		'Dim schoolNameDDL As DropDownList

		'Clear out teacher and school DDLs
		VisitTimeDDL.Items.Clear()

		'Populate visit time DDL
		Try
			con.ConnectionString = connection_string
			con.Open()
			cmd.CommandText = "SELECT CONVERT(VARCHAR(5), schoolSchedule, 108) as schoolSchedule FROM schoolSchedule"
			cmd.Connection = con
			dr = cmd.ExecuteReader

			While dr.Read()
				VisitTimeDDL.Items.Add(dr(0).ToString)
			End While

			cmd.Dispose()
			con.Close()

		Catch
			errorString = "Error in visitTime. Could not get school schedule times."
			Return errorString
			Exit Function
		End Try

		Return VisitTimeDDL.Items
	End Function

	'Get volunteer time based on the visit time
	Function GetVolArrivalTime(VisitTime As String)
		Dim errorString As String
		Dim VolArrivalTime As String

		'Populate visit time DDL
		Try
			con.ConnectionString = connection_string
			con.Open()
			cmd.CommandText = "SELECT CONVERT(VARCHAR(5), timeVolArrive, 108) as timeVolArrive FROM schoolSchedule WHERE schoolSchedule = '" & VisitTime & "'"
			cmd.Connection = con
			dr = cmd.ExecuteReader

			While dr.Read()
				VolArrivalTime = dr("timeVolArrive").ToString
			End While

			cmd.Dispose()
			con.Close()

		Catch
			errorString = "Error in visitTime. Could not get school schedule times."
			Return errorString
			Exit Function
		End Try

		Return VolArrivalTime
	End Function

	'Get volunteer dismissal time from visit time
	Function GetDismissalTime(ArrivalTime As String)
		Dim errorString As String
		Dim DismissalTime As String

		'Populate visit time DDL
		Try
			con.ConnectionString = connection_string
			con.Open()
			cmd.CommandText = "SELECT CONVERT(VARCHAR(5), leaveEV, 108) as leaveEV FROM schoolSchedule WHERE timeVolArrive = '" & ArrivalTime & "'"
			cmd.Connection = con
			dr = cmd.ExecuteReader

			While dr.Read()
				DismissalTime = dr("leaveEV").ToString
			End While

			cmd.Dispose()
			con.Close()

		Catch
			errorString = "Error in visitTime. Could not get school schedule times."
			Return errorString
			Exit Function
		End Try

		Return DismissalTime
	End Function
End Class
