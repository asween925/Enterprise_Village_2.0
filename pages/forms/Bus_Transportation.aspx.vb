Imports System.IO
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class Bus_Transportation
	Inherits System.Web.UI.Page
	Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
	Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
	Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
	Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
	Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
	Dim con As New SqlConnection
	Dim cmd As New SqlCommand
	Dim dr As SqlDataReader
	Dim VisitData As New Class_VisitData
	Dim StudentData As New Class_StudentData
	Dim VisitID As Integer = VisitData.GetVisitID

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Session("LoggedIn") <> "1" Then
			Response.Redirect("../../default.aspx")
		End If

		If Not (IsPostBack) Then
			'Assign current visit ID to hidden field
			If VisitID <> 0 Then
				currentVisitID_hf.Value = VisitID
			End If

			'Populating school header
			Dim header As New Class_SchoolHeader
			headerSchoolName_lbl.Text = header.GetSchoolHeader()
		End If
	End Sub

	Sub LoadData()
		Dim VisitDate As String = visitDate_tb.Text
		Dim CurrentDate As String = DateTime.Now.Date.ToLongDateString().Replace(DateTime.Now.DayOfWeek.ToString() + ", ", "")
		Dim SchoolName As String
		Dim Address As String
		Dim Address2 As String
		Dim StudentCount As String
		Dim TotalMilegeOneWay As String
		Dim TotalMileageBarn As String
		Dim TotalTimeOneWay As String
		Dim TotalTimeBarn As String
		Dim TotalOneBus As String
		Dim TotalTwoBus As String
		Dim TotalThreeBus As String
		Dim SQLStatement As String = "SELECT s.schoolName, s.address, s.state, s.city, s.zip, s.totalMilageOneWay, s.totalMilageBarn, s.totalTimeOneWay, s.totalTimeBarn, s.amountDueOneBus, s.amountDueTwoBus, s.amountDueThreeBus
									  FROM visitInfo v
									  LEFT JOIN schoolInfo s ON s.ID = v.school
									  LEFT JOIN schoolInfo s2 ON s2.ID = v.school2
									  LEFT JOIN schoolInfo s3 ON s3.ID = v.school3
									  LEFT JOIN schoolInfo s4 ON s4.ID = v.school4
									  LEFT JOIN schoolInfo s5 ON s5.ID = v.school5
									  WHERE v.visitDate = '" & VisitDate & "'"

		'Clear error label
		error_lbl.Text = ""

		'get Student Count
		StudentCount = StudentData.GetStudentCount(VisitDate)

		'Get data
		Try
			con.ConnectionString = connection_string
			con.Open()
			cmd.CommandText = SQLStatement
			cmd.Connection = con
			dr = cmd.ExecuteReader

			While dr.Read()
				SchoolName = dr("schoolName").ToString
				Address = dr("address").ToString
				Address2 = dr("city").ToString & ", " & dr("state").ToString & " " & dr("zip").ToString
				TotalMilegeOneWay = dr("totalMilageOneWay").ToString
				TotalMileageBarn = dr("totalMilageBarn").ToString
				TotalTimeOneWay = dr("totalTimeOneWay").ToString
				TotalTimeBarn = dr("totalTimeBarn").ToString
				TotalOneBus = dr("amountDueOneBus").ToString
				TotalTwoBus = dr("amountDueTwoBus").ToString
				TotalThreeBus = dr("amountDueThreeBus").ToString
			End While

			cmd.Dispose()
			con.Close()
		Catch
			error_lbl.Text = "Error in LoadData. Cannot get school name."
			Exit Sub
		End Try

		'Assign labels
		schoolName_lbl.Text = SchoolName
		address_lbl.Text = Address
		address2_lbl.Text = Address2
		totalMileageOneWay_lbl.Text = TotalMilegeOneWay
		totalMileageBarn_lbl.Text = TotalMileageBarn
		totalTimeOneWay_lbl.Text = TotalTimeOneWay
		totalTimeBarn_lbl.Text = TotalTimeBarn
		visitDate_lbl.Text = FormatDateTime(VisitDate, DateFormat.ShortDate)
		studentCount_lbl.Text = StudentCount
		currentDate_lbl.Text = CurrentDate

		'If totals are not NOT NULL, then convert to currency
		If TotalOneBus <> Nothing And TotalTwoBus <> Nothing And TotalThreeBus <> Nothing Then
			totalOneBus_lbl.Text = FormatCurrency(TotalOneBus)
			totalTwoBus_lbl.Text = FormatCurrency(TotalTwoBus)
			totalThreeBus_lbl.Text = FormatCurrency(TotalThreeBus)
		Else
			totalOneBus_lbl.Text = TotalOneBus
			totalTwoBus_lbl.Text = TotalTwoBus
			totalThreeBus_lbl.Text = TotalThreeBus
		End If


		'Make divs visible
		letter_div.Visible = True
		EVLogo_img.Visible = True
		calculations_div.Visible = True
	End Sub

	Sub Calculations()
		Dim VisitDate As String = visitDate_tb.Text
		Dim SchoolName As String = schoolName_lbl.Text
		Dim TotalMilegeOneWay As String
		Dim TotalMileageBarn As String
		Dim TotalTimeOneWay As String
		Dim TotalTimeBarn As String
		Dim TotalOneBus As String
		Dim TotalTwoBus As String
		Dim TotalThreeBus As String
		Dim SQLStatement As String = ""

		'Check if textboxes are not empty
		If totalTimeOneWay_tb.Text <> Nothing And totalMileageOneWay_tb.Text <> Nothing Then
			TotalMilegeOneWay = totalMileageOneWay_tb.Text
			TotalTimeOneWay = totalTimeOneWay_tb.Text
		Else
			error_lbl.Text = "Please enter both the total mileage one way amount AND the total time one way amount before calculating."
			Exit Sub
		End If

		'Check if school name is not blank
		If SchoolName = Nothing Then
			error_lbl.Text = "A visit date has not been created for the entered date. Please go to the 'Create a Visit' page under the 'Tools' category."
			Exit Sub
		End If

		'Calculate other variables
		TotalMileageBarn = TotalMilegeOneWay * 4
		TotalTimeBarn = TotalTimeOneWay * 4

		TotalOneBus = (TotalMileageBarn * 1.75) + (TotalTimeBarn * 38)
		TotalTwoBus = TotalOneBus * 2
		TotalThreeBus = TotalOneBus * 3

		'Save data to the database
		Try
			Using con As New SqlConnection(connection_string)
				Using cmd As New SqlCommand("UPDATE schoolInfo SET totalMilageOneWay=@totalMilageOneWay, totalMilageBarn=@totalMilageBarn, totalTimeOneWay=@totalTimeOneWay, totalTimeBarn=@totalTimeBarn, amountDueOneBus=@amountDueOneBus, amountDueTwoBus=@amountDueTwoBus, amountDueThreeBus=@amountDueThreeBus WHERE schoolName='" & SchoolName & "'")
					cmd.Parameters.AddWithValue("@schoolName", SchoolName)
					cmd.Parameters.AddWithValue("@totalMilageOneWay", TotalMilegeOneWay)
					cmd.Parameters.AddWithValue("@totalMilageBarn", TotalMileageBarn)
					cmd.Parameters.AddWithValue("@totalTimeOneWay", TotalTimeOneWay)
					cmd.Parameters.AddWithValue("@totalTimeBarn", TotalTimeBarn)
					cmd.Parameters.AddWithValue("@amountDueOneBus", TotalOneBus)
					cmd.Parameters.AddWithValue("@amountDueTwoBus", TotalTwoBus)
					cmd.Parameters.AddWithValue("@amountDueThreeBus", TotalThreeBus)
					cmd.Connection = con
					con.Open()
					cmd.ExecuteNonQuery()
					con.Close()
				End Using
			End Using
		Catch
			error_lbl.Text = "Error in Calculations(). Cannot save calculations to database."
			Exit Sub
		End Try

		'Load data
		LoadData()
	End Sub

	Protected Sub visitDate_tb_TextChanged(sender As Object, e As EventArgs) Handles visitDate_tb.TextChanged
		LoadData()
	End Sub

	Protected Sub print_btn_Click(sender As Object, e As EventArgs) Handles print_btn.Click
		Page.ClientScript.RegisterStartupScript(Me.GetType(), "Print", "Print();", True)
	End Sub

	Protected Sub calculate_btn_Click(sender As Object, e As EventArgs) Handles calculate_btn.Click
		Calculations()
	End Sub
End Class