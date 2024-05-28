Imports System.IO
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class EV_Lunch_Forms
	Inherits System.Web.UI.Page
	Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
	Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
	Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
	Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
	Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
	Dim VisitID As New Class_VisitData
	Dim Visit As Integer = VisitID.GetVisitID

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
		Dim con As New SqlConnection
		Dim cmd As New SqlCommand

		If Session("LoggedIn") <> "1" Then
			Response.Redirect("../../default.aspx")
		End If

		If Not (IsPostBack) Then

			'Assign current visit ID to hidden field
			If Visit <> 0 Then
				currentVisitID_hf.Value = Visit
			End If

			'Populating school header
			Dim header As New Class_SchoolHeader
			headerSchoolName_lbl.Text = header.GetSchoolHeader()
		End If
	End Sub

	Sub YearDDL()
		Dim yearDDLSQL As String = "SELECT DISTINCT DATENAME(YEAR, visitDate) As Year FROM visitInfo"
		Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
		Dim con As New SqlConnection
		Dim cmd As New SqlCommand
		Dim dr As SqlDataReader

		'Make date div invisible
		date_div.Visible = False

		'Make receipt section visible, letter section invisible
		letterSection_div.Visible = True
		dailyReceipt_div.Visible = False

		'Clear DDL
		year_ddl.Items.Clear()

		'Populate year DDL
		Try
			con.ConnectionString = connection_string
			con.Open()
			cmd.CommandText = yearDDLSQL
			cmd.Connection = con
			dr = cmd.ExecuteReader

			While dr.Read()
				year_ddl.Items.Add(dr(0).ToString)
			End While
			year_ddl.Items.Insert(0, "")

		Catch ex As Exception
			error_lbl.Text = "Error in Letter(). Could not populate year DDL."
			Exit Sub
		End Try
	End Sub

	Sub Letter()
		Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
		Dim con As New SqlConnection
		Dim cmd As New SqlCommand
		Dim dayDateSQL As String = "  SELECT v.id, CONCAT(SUBSTRING(DATENAME(WEEKDAY, v.visitDate), 1, 3), ' - ', FORMAT(v.visitDate, 'M/d/yy')) as DateAndDay
									, (CASE
										WHEN v.visitTime = '07:25' THEN '10:15'
										WHEN v.visitTime = '07:45' THEN '10:40'
										WHEN v.visitTime = '07:55' THEN '10:50'
										WHEN v.visitTime = '08:00' THEN '10:55'
										WHEN v.visitTime = '08:15' THEN '11:10'
										WHEN v.visitTime = '08:25' THEN '11:10'
										WHEN v.visitTime = '08:30' THEN '11:15'
										WHEN v.visitTime = '08:40' THEN '11:20'
										WHEN v.visitTime >= '08:45' THEN '11:25'
									 END) AS pickUpTime
									 FROM visitInfo v
									 INNER JOIN schoolInfo s
									 ON s.id = v.school
									 INNER JOIN schoolInfo s2
									 ON s2.id = v.school2
									 INNER JOIN schoolInfo s3
									 ON s3.id = v.school3
									 INNER JOIN schoolInfo s4
									 ON s4.id = v.school4
									 INNER JOIN schoolInfo s5
									 ON s5.id = v.school5
									 WHERE DATENAME(MONTH, v.visitDate) = '" & month_ddl.SelectedValue & "'
									 AND YEAR(v.visitDate) = '" & year_ddl.SelectedValue & "'
									 AND NOT DATENAME(WEEKDAY, v.visitDate)='Saturday' AND NOT DATENAME(WEEKDAY, v.visitDate)='Sunday'
									 AND NOT v.school=1
									 ORDER BY v.visitDate"

		'Get month and assign to label
		month_lbl.Text = month_ddl.SelectedValue

		'Get date and assign to label
		longDate_lbl.Text = DateTime.Now.Date.ToLongDateString().Replace(DateTime.Now.DayOfWeek.ToString() + ", ", "")

		'Make letter visible
		letter_div.Visible = True

		'Make print button visible
		print_btn.Visible = True

		'Populate table
		Try
			con.ConnectionString = connection_string
			con.Open()
			cmd.Connection = con
			cmd.CommandText = dayDateSQL

			Dim da As New SqlDataAdapter
			da.SelectCommand = cmd
			Dim dt As New DataTable
			da.Fill(dt)
			lunches_dgv.DataSource = dt
			lunches_dgv.DataBind()

			cmd.Dispose()
			con.Close()

		Catch
			error_lbl.Text = "Error in Letter(). Cannot get load data for lunches table."
			Exit Sub
		End Try

	End Sub

	Sub DeliveryReceipt()
		Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
		Dim con As New SqlConnection
		Dim cmd As New SqlCommand
		Dim dr As SqlDataReader
		Dim studentCount As String
		Dim vMin As String
		Dim vMax As String
		Dim st As New Class_StudentData
		Dim sc As New Class_SchoolData
		Dim visitDate As String = visitDate_tb.Text
		Dim pickupTimeSQL As String = "SELECT (CASE
										WHEN visitTime = '07:25' THEN '10:15'
										WHEN visitTime = '07:45' THEN '10:40'
										WHEN visitTime = '07:55' THEN '10:50'
										WHEN visitTime = '08:00' THEN '10:55'
										WHEN visitTime = '08:15' THEN '11:10'
										WHEN visitTime = '08:25' THEN '11:10'
										WHEN visitTime = '08:30' THEN '11:15'
										WHEN visitTime = '08:40' THEN '11:20'
										WHEN visitTime >= '08:45' THEN '11:25'
									 END) AS pickUpTime
									 FROM visitInfo
									 WHERE visitDate = '" & visitDate & "'								 
									 ORDER BY visitDate"

		'Make receipt section visible, letter section invisible
		letterSection_div.Visible = False
		dailyReceipt_div.Visible = True

		'Make print button visible
		print_btn.Visible = True

		'Assign visit date
		visitDate_lbl.Text = Convert.ToDateTime(visitDate).ToString("MM/dd/yyyy")

		'Get Student Count
		studentCount = st.GetStudentCount(visitDate_tb.Text)
		studentCount_lbl.Text = studentCount

		'Get volunteer count
		vMin = sc.GetVolunteerRange(visitDate_tb.Text).VMin
		vMax = sc.GetVolunteerRange(visitDate_tb.Text).VMax
		volunteerCount_lbl.Text = vMin & "-" & vMax

		'Get pick up time
		Try
			con.ConnectionString = connection_string
			con.Open()
			cmd.CommandText = pickupTimeSQL
			cmd.Connection = con
			dr = cmd.ExecuteReader

			While dr.Read()
				pickupTime_lbl.Text = dr("pickUpTime").ToString
			End While

			cmd.Dispose()
			con.Close()

		Catch ex As Exception
			error_lbl.Text = "Error in DeliveryReceipt(). Could not get pick up time."
			Exit Sub
		End Try

		cmd.Dispose()
		con.Close()
	End Sub

	Protected Sub visitDate_tb_TextChanged(sender As Object, e As EventArgs) Handles visitDate_tb.TextChanged

		If visitDate_tb.Text <> Nothing Then
			DeliveryReceipt()
		End If

	End Sub

	Protected Sub dailyReceipt_btn_Click(sender As Object, e As EventArgs) Handles dailyReceipt_btn.Click

		'Make divs visible and invisible
		date_div.Visible = True
		letterSection_div.Visible = False
		dailyReceipt_div.Visible = False

	End Sub

	Protected Sub letter_btn_Click(sender As Object, e As EventArgs) Handles letter_btn.Click
		YearDDL()
	End Sub

	Protected Sub print_btn_Click(sender As Object, e As EventArgs) Handles print_btn.Click

		'Make logos visible
		StavrosLogo_img.Visible = True

		Page.ClientScript.RegisterStartupScript(Me.GetType(), "Print", "Print();", True)
	End Sub

	Protected Sub month_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles month_ddl.SelectedIndexChanged
		If month_ddl.SelectedIndex <> 0 Then
			If year_ddl.SelectedIndex <> 0 Then
				Letter()
			End If
		End If
	End Sub

	Protected Sub year_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles year_ddl.SelectedIndexChanged
		If year_ddl.SelectedIndex <> 0 Then
			If month_ddl.SelectedIndex <> 0 Then
				Letter()
			End If
		End If
	End Sub
End Class