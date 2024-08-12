Imports System.IO
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class Break_Schedules
	Inherits System.Web.UI.Page
	Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
	Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
	Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
	Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
	Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
	Dim VisitID As New Class_VisitData
	Dim Visit As Integer = VisitID.GetVisitID
	Dim BusinessData As New Class_BusinessData

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

			'Populate business names DDL
			BusinessData.LoadBusinessNamesDDL(businessName_ddl)
		End If
	End Sub

	Sub LoadData()
		Dim BusinessName As String = businessName_ddl.SelectedValue
		Dim SchoolScheduleTime As String = schoolScheduleTime_ddl.SelectedValue
		Dim BusinessID As String = BusinessData.GetBusinessID(BusinessName)

		'Clear error label
		error_lbl.Text = ""

		'Assign business name to label
		businessName_lbl.Text = BusinessName

		'Get school schedule period and break times based on selected time
		SchedulePeriod(SchoolScheduleTime)

		'Get job titles for business
		Jobs(BusinessID)
	End Sub

	Sub SchedulePeriod(SchoolScheduleTime As String)
		Dim SchoolSchedulePeriod As String = ""
		Dim Break1A As String = ""
		Dim Break2A As String = ""
		Dim Break3A As String = ""
		Dim Break1B As String = ""
		Dim Break2B As String = ""
		Dim Break3B As String = ""
		Dim Break1C As String = ""
		Dim Break2C As String = ""
		Dim Break3C As String = ""

		Select Case SchoolScheduleTime
			Case "7:25"
				SchoolSchedulePeriod = "7:25 - 12:45"
				Break1A = "9:15 - 9:25"
				Break2A = "9:55 - 10:15"
				Break3A = "11:05 - 11:30"
				Break1B = "9:25 - 9:35"
				Break2B = "10:15 - 10:35"
				Break3B = "11:30 - 11:55"
				Break1C = "9:35 - 9:45"
				Break2C = "10:35 - 10:55"
				Break3C = "11:55 - 12:20"
			Case "7:45"
				SchoolSchedulePeriod = "7:45 - 1:05"
				Break1A = "9:35 - 9:45"
				Break2A = "10:15 - 10:35"
				Break3A = "11:25 - 11:50"
				Break1B = "9:45 - 9:55"
				Break2B = "10:35 - 10:55"
				Break3B = "11:50 - 12:15"
				Break1C = "9:55 - 10:05"
				Break2C = "10:55 - 11:15"
				Break3C = "12:15 - 12:40"
			Case "7:55"
				SchoolSchedulePeriod = "7:55 - 1:15"
				Break1A = "9:45 - 9:55"
				Break2A = "10:25 - 10:45"
				Break3A = "11:35 - 12:00"
				Break1B = "9:55 - 10:05"
				Break2B = "10:45 - 11:05"
				Break3B = "12:00 - 12:25"
				Break1C = "10:05 - 10:15"
				Break2C = "11:05 - 11:25"
				Break3C = "12:25 - 12:50"
			Case "8:00"
				SchoolSchedulePeriod = "8:00 - 1:20"
				Break1A = "9:15 - 9:25"
				Break2A = "9:55 - 10:15"
				Break3A = "11:05 - 11:30"
				Break1B = "9:25 - 9:35"
				Break2B = "10:15 - 10:35"
				Break3B = "11:30 - 11:55"
				Break1C = "9:35 - 9:45"
				Break2C = "10:35 - 10:55"
				Break3C = "11:55 - 12:20"
			Case "8:15"
				SchoolSchedulePeriod = "8:15 - 1:35"
				Break1A = "10:05 - 10:15"
				Break2A = "10:45 - 11:05"
				Break3A = "11:55 - 12:20"
				Break1B = "10:15 - 10:25"
				Break2B = "11:05 - 11:25"
				Break3B = "12:20 - 12:45"
				Break1C = "10:25 - 10:25"
				Break2C = "11:25 - 11:45"
				Break3C = "12:45 - 1:10"
			Case "8:25"
				SchoolSchedulePeriod = "8:25 - 1:45"
				Break1A = "10:15 - 10:25"
				Break2A = "10:55 - 11:15"
				Break3A = "12:05 - 12:30"
				Break1B = "10:25 - 10:35"
				Break2B = "11:15 - 11:35"
				Break3B = "12:30 - 12:55"
				Break1C = "10:35 - 10:45"
				Break2C = "11:35 - 11:55"
				Break3C = "12:55 - 1:20"
			Case "8:30"
				SchoolSchedulePeriod = "8:30 - 1:50"
				Break1A = "10:20 - 10:30"
				Break2A = "11:00 - 11:20"
				Break3A = "12:10 - 12:35"
				Break1B = "10:30 - 10:40"
				Break2B = "11:20 - 11:40"
				Break3B = "12:35 - 1:00"
				Break1C = "10:40 - 10:50"
				Break2C = "11:40 - 12:55"
				Break3C = "1:00 - 1:25"
			Case "8:40"
				SchoolSchedulePeriod = "8:40 - 2:00"
				Break1A = "10:35 - 10:45"
				Break2A = "11:15 - 11:35"
				Break3A = "12:25 - 12:50"
				Break1B = "10:45 - 10:55"
				Break2B = "11:35 - 11:55"
				Break3B = "12:50 - 1:15"
				Break1C = "10:55 - 11:05"
				Break2C = "11:55 - 12:15"
				Break3C = "1:15 - 1:40"
			Case "8:45"
				SchoolSchedulePeriod = "8:45 - 2:05"
				Break1A = "9:15 - 9:25"
				Break2A = "9:55 - 10:15"
				Break3A = "11:05 - 11:30"
				Break1B = "9:25 - 9:35"
				Break2B = "10:15 - 10:35"
				Break3B = "11:30 - 11:55"
				Break1C = "9:35 - 9:45"
				Break2C = "10:35 - 10:55"
				Break3C = "11:55 - 12:20"
			Case "8:50"
				SchoolSchedulePeriod = "8:50 - 2:10"
				Break1A = "10:40 - 10:50"
				Break2A = "11:20 - 11:40"
				Break3A = "12:30 - 12:55"
				Break1B = "10:50 - 11:00"
				Break2B = "11:40 - 12:00"
				Break3B = "12:55 - 1:20"
				Break1C = "11:00 - 11:10"
				Break2C = "12:00 - 12:20"
				Break3C = "1:20 - 1:45"
			Case "8:55"
				SchoolSchedulePeriod = "8:55 - 2:15"
				Break1A = "10:45 - 10:55"
				Break2A = "11:25 - 11:45"
				Break3A = "12:35 - 1:00"
				Break1B = "10:55 - 11:05"
				Break2B = "11:45 - 12:05"
				Break3B = "1:00 - 1:25"
				Break1C = "11:05 - 11:15"
				Break2C = "12:05 - 12:25"
				Break3C = "1:25 - 1:50"
			Case "9:10"
				SchoolSchedulePeriod = "9:10 - 2:30"
				Break1A = "11:00 - 11:10"
				Break2A = "11:40 - 12:00"
				Break3A = "12:50 - 1:15"
				Break1B = "11;10 - 11:20"
				Break2B = "12:00 - 12:20"
				Break3B = "1:15 - 1:40"
				Break1C = "11:20 - 11:30"
				Break2C = "12:20 - 12:40"
				Break3C = "1:40 - 2:05"
			Case "9:30"
				SchoolSchedulePeriod = "9:30 - 2:50"
				Break1A = "11:20 - 11:30"
				Break2A = "12:00 - 12:20"
				Break3A = "1:10 - 11:35"
				Break1B = "11:30 - 11:40"
				Break2B = "12:20 - 12:40"
				Break3B = "1:35 - 2:00"
				Break1C = "12:40 - 12:50"
				Break2C = "1:40 - 1:55"
				Break3C = "2:00 - 2:25"
			Case "9:40"
				SchoolSchedulePeriod = "9:40 - 3:00"
				Break1A = "11:35 - 11:45"
				Break2A = "12:15 - 12:35"
				Break3A = "1:25 - 1:50"
				Break1B = "11:45 - 11:55"
				Break2B = "12:35 - 12:55"
				Break3B = "1:50 - 2:15"
				Break1C = "11:55 - 12:05"
				Break2C = "12:55 - 1:15"
				Break3C = "2:15 - 2:40"
		End Select

		'Assign varibles to labels
		schoolSchedule_lbl.Text = SchoolSchedulePeriod
		break1ATime_lbl.Text = Break1A
		break2ATime_lbl.Text = Break2A
		break3ATime_lbl.Text = Break3A
		break1BTime_lbl.Text = Break1B
		break2BTime_lbl.Text = Break2B
		break3BTime_lbl.Text = Break3B
		break1CTime_lbl.Text = Break1C
		break2CTime_lbl.Text = Break2C
		break3CTime_lbl.Text = Break3C

	End Sub

	Sub Jobs(BusinessID As String)
		Dim Job1A As String = ""
		Dim Job2A As String = ""
		Dim Job3A As String = ""
		Dim Job4A As String = ""
		Dim Job5A As String = ""
		Dim Job1B As String = ""
		Dim Job2B As String = ""
		Dim Job3B As String = ""
		Dim Job4B As String = ""
		Dim Job1C As String = ""
		Dim Job2C As String = ""
		Dim Job3C As String = ""

		'Make all job sections invisible
		job1A_p.Visible = False
		job2A_p.Visible = False
		job3A_p.Visible = False
		job4A_p.Visible = False
		job5A_p.Visible = False
		job1B_p.Visible = False
		job2B_p.Visible = False
		job3B_p.Visible = False
		job4B_p.Visible = False
		job1C_p.Visible = False
		job2C_p.Visible = False
		job3C_p.Visible = False

		Select Case BusinessID
			Case 1 'Bucs
				Job1A = "Financial Officer"
				Job1B = "Sales Associate #1"
				Job1C = "Manager"
				Job2C = "Sales Associate #2"

				job1A_p.Visible = True
				job1B_p.Visible = True
				job1C_p.Visible = True
				job2C_p.Visible = True
			Case 2 'Rays
				Job1A = "Video Engineer #1"
				Job2A = "Financial Officer"
				Job3A = "Audio Engineer #2"
				Job1B = "Sales Associate"
				Job2B = "Video Engineer #2"
				Job1C = "Manager"
				Job2C = "Audio Engineer #1"

				job1A_p.Visible = True
				job2A_p.Visible = True
				job3A_p.Visible = True
				job1B_p.Visible = True
				job2B_p.Visible = True
				job1C_p.Visible = True
				job2C_p.Visible = True
			Case 3 'CVS
				Job1A = "Sales Associate #1"
				Job2A = "Financial Officer"
				Job1B = "Sales Associate #2"
				Job2B = "Sales Associate #3"
				Job3B = "Customer Service Rep #1"
				Job1C = "Customer Service Rep #2"
				Job2C = "Manager"

				job1A_p.Visible = True
				job2A_p.Visible = True
				job1B_p.Visible = True
				job2B_p.Visible = True
				job3B_p.Visible = True
				job1C_p.Visible = True
				job2C_p.Visible = True
			Case 5 'Kanes
				Job1A = "Sales Associate #2"
				Job2A = "Financial Officer"
				Job1B = "Sales Associate #1"
				Job2B = "Sales Associate #3"
				Job1C = "Sales Associate #4"
				Job2C = "Manager"

				job1A_p.Visible = True
				job2A_p.Visible = True
				job1B_p.Visible = True
				job2B_p.Visible = True
				job1C_p.Visible = True
				job2C_p.Visible = True
			Case 6 'Koozie Group
				Job1A = "Sales Associate #1"
				Job2A = "Financial Officer"
				Job3A = "Customer Service Associate #2"
				Job1B = "Sales Associate #2"
				Job2B = "Manager"
				Job3B = "Customer Service Associate #1"
				Job1C = "Mechanical Engineer #1"
				Job2C = "Mechanical Engineer #2"

				job1A_p.Visible = True
				job2A_p.Visible = True
				job3A_p.Visible = True
				job1B_p.Visible = True
				job2B_p.Visible = True
				job3B_p.Visible = True
				job1C_p.Visible = True
				job2C_p.Visible = True
			Case 7 'TD
				Job1A = "Corporate Communications"
				Job2A = "CFO / Financial Officer"
				Job1B = "Logisitcs Architect #1"
				Job1C = "CEO / Manager"
				Job2C = "Logistics Architect #2"

				job1A_p.Visible = True
				job2A_p.Visible = True
				job1B_p.Visible = True
				job2B_p.Visible = True
				job1C_p.Visible = True
				job2C_p.Visible = True
			Case 8 'HSN
				Job1A = "Inventory Control Specialist #1"
				Job2A = "Financial Officer"
				Job3A = "Customer Service Rep #1"
				Job1B = "Customer Service Rep #2"
				Job2B = "TV Host #1"
				Job1C = "Manager"
				Job2C = "TV Host #2"

				job1A_p.Visible = True
				job2A_p.Visible = True
				job3A_p.Visible = True
				job1B_p.Visible = True
				job2B_p.Visible = True
				job1C_p.Visible = True
				job2C_p.Visible = True
			Case 9 'BBB
				Job1A = "Dispute Resolution Specialist"
				Job2A = "Financial Officer"
				Job1B = "Accreditation Specialist"
				Job2B = "Manager"
				Job1C = "Business Relations Specialist"
				Job2C = "information Specialist"

				job1A_p.Visible = True
				job2A_p.Visible = True
				job1B_p.Visible = True
				job2B_p.Visible = True
				job1C_p.Visible = True
				job2C_p.Visible = True
			Case 10 'Astro
				Job1A = "Skate Attendant"
				Job2A = "Financial Officer"
				Job1B = "Front Door Cashier Sales"
				Job2B = "Rink Manager"
				Job1C = "Floor Guard Reporter"
				Job2C = "Floor Guard Videographer"

				job1A_p.Visible = True
				job2A_p.Visible = True
				job1B_p.Visible = True
				job2B_p.Visible = True
				job1C_p.Visible = True
				job2C_p.Visible = True
			Case 11 'Ditek
				Job1A = "3D Graphic Designer #1"
				Job2A = "Financial Officer"
				Job1B = "Inventory Control Specialist #2"
				Job2B = "Manager"
				Job1C = "3D Designer #2"
				Job2C = "Inventory Control Specialist #1"

				job1A_p.Visible = True
				job2A_p.Visible = True
				job1B_p.Visible = True
				job2B_p.Visible = True
				job1C_p.Visible = True
				job2C_p.Visible = True
			Case 12 'Bank
				Job1A = "Teller #3"
				Job2A = "Teller #6"
				Job3A = "Branch Manager"
				Job4A = "Savings Officer #2"
				Job5A = "Customer Service Representative #2"
				Job1B = "Savings Officer #1"
				Job2B = "Teller #2"
				Job3B = "Teller #4"
				Job4B = "Customer Service Representative #1"
				Job1C = "Teller #1"
				Job2C = "Teller #5"
				Job3C = "Financial Officer"

				job1A_p.Visible = True
				job2A_p.Visible = True
				job3A_p.Visible = True
				job4A_p.Visible = True
				job5A_p.Visible = True
				job1B_p.Visible = True
				job2B_p.Visible = True
				job3B_p.Visible = True
				job4B_p.Visible = True
				job1C_p.Visible = True
				job2C_p.Visible = True
				job3C_p.Visible = True
			Case 13 'BayCare
				Job1A = "Medical Assistant"
				Job2A = "Financial Officer"
				Job1B = "Medical Technician #2"
				Job2B = "Manager"
				Job1C = "Medical Technician #1"
				Job2C = "Administrative Assistant"

				job1A_p.Visible = True
				job2A_p.Visible = True
				job1B_p.Visible = True
				job2B_p.Visible = True
				job1C_p.Visible = True
				job2C_p.Visible = True
			Case 14 'City Hall
				Job1A = "Art Curator"
				Job2A = "Enviromentalist"
				Job3A = "Attorney"
				Job4A = "Package Handler"
				Job5A = "Assistant Package Handler"
				Job1B = "Mayor"
				Job2B = "Assistant Art Curator #1"
				'Job3B = "City Planner" 8/9/2024: omitting city planner
				Job4B = "Supervisor of Elections"
				Job1C = "PCU Manager"
				Job2C = "Treasurer"

				job1A_p.Visible = True
				job2A_p.Visible = True
				job3A_p.Visible = True
				job4A_p.Visible = True
				job5A_p.Visible = True
				job1B_p.Visible = True
				job2B_p.Visible = True
				'job3B_p.Visible = True  8/9/2024: omitting city planner
				job4B_p.Visible = True
				job1C_p.Visible = True
				job2C_p.Visible = True
			Case 15 'Dali
				Job1A = "Art Curator"
				Job1B = "Assistant Art Curator #1"

				job1A_p.Visible = True
				job1B_p.Visible = True
			Case 16 'Duke
				Job1A = "Meter Reader #2"
				Job2A = "Financial Officer"
				Job1B = "Utility Engineer"
				Job2B = "Manager"
				Job1C = "Meter Reader #1"

				job1A_p.Visible = True
				job2A_p.Visible = True
				job1B_p.Visible = True
				job2B_p.Visible = True
				job1C_p.Visible = True
			Case 17 'McDonalds
				Job1A = "Sales Associate #2"
				Job2A = "Customer Service Representative #1"
				Job3A = "Financial Officer"
				Job1B = "Sales Associate #4"
				Job2B = "Customer Service Representative #2"
				Job3B = "Manager"
				Job1C = "Sales Associate #1"
				Job2C = "Sales Associate #3"
				Job3C = "Customer Service Representative #3"

				job1A_p.Visible = True
				job2A_p.Visible = True
				job3A_p.Visible = True
				job1B_p.Visible = True
				job2B_p.Visible = True
				job3B_p.Visible = True
				job1C_p.Visible = True
				job2C_p.Visible = True
				job3C_p.Visible = True
			Case 18 'Mix
				Job1A = "Financial Officer"
				Job2A = "Customer Service Representative"
				Job1B = "Station Manager"
				Job2B = "Marketing Representative #2"
				Job3B = "Disc Jockey #2"
				Job1C = "Disc Jockey #1"
				Job2C = "Market Representative #1"

				job1A_p.Visible = True
				job2A_p.Visible = True
				job1B_p.Visible = True
				job2B_p.Visible = True
				job3B_p.Visible = True
				job1C_p.Visible = True
				job2C_p.Visible = True
			Case 19 'PCSW
				Job1A = "Financial Officer"
				Job1B = "Manager"

				job1A_p.Visible = True
				job1B_p.Visible = True
			Case 20 'PCW
			Case 21 'Knowbe4
				Job1A = "Developer of Fun and Shenanigans"
				Job2A = "IT Support Specialist"
				Job1B = "Manager"
				Job1C = "Finanical Officer"
				Job2C = "Sales Representative"

				job1A_p.Visible = True
				job2A_p.Visible = True
				job1B_p.Visible = True
				job1C_p.Visible = True
				job2C_p.Visible = True
			Case 22 'Times / Newspaper
				Job1A = "All Employees Break"
				Job1B = "WORK TIME (All Employees Working)"
				Job1C = "WORK TIME (All Employees Working)"

				job1A_p.Visible = True
				job1B_p.Visible = True
				job1C_p.Visible = True
			Case 23 'UPS
				Job1A = "Package Handler"
				Job2A = "Assistant Package Handler"

				job1A_p.Visible = True
				job2A_p.Visible = True
			Case 24 'United way
				Job1A = "Resource Development Director"
				Job2A = "Financial Officer"
				Job1B = "Resource Development Assistant"
				Job2B = "Manager"
				Job1C = "Community Impact Director"
				Job2C = "Public Relations Director"

				job1A_p.Visible = True
				job2A_p.Visible = True
				job1B_p.Visible = True
				job2B_p.Visible = True
				job1C_p.Visible = True
				job2C_p.Visible = True
		End Select

		'Assign Variables to Labels
		job1A_lbl.Text = Job1A
		job2A_lbl.Text = Job2A
		job3A_lbl.Text = Job3A
		job4A_lbl.Text = Job4A
		job5A_lbl.Text = Job5A
		job1B_lbl.Text = Job1B
		job2B_lbl.Text = Job2B
		job3B_lbl.Text = Job3B
		job4B_lbl.Text = Job4B
		job1C_lbl.Text = Job1C
		job2C_lbl.Text = Job2C
		job3C_lbl.Text = Job3C

	End Sub

	Protected Sub businessName_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles businessName_ddl.SelectedIndexChanged
		If businessName_ddl.SelectedIndex <> 0 Then
			schoolSch_div.Visible = True
			LoadData()
		Else
			schoolSch_div.Visible = False
		End If
	End Sub

	Protected Sub schoolScheduleTime_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles schoolScheduleTime_ddl.SelectedIndexChanged
		If schoolScheduleTime_ddl.SelectedIndex <> 0 Then
			breakSchedule_div.Visible = True
			LoadData()
		Else
			breakSchedule_div.Visible = False
		End If
	End Sub

	Protected Sub print_btn_Click(sender As Object, e As EventArgs) Handles print_btn.Click
		Page.ClientScript.RegisterStartupScript(Me.GetType(), "Print", "Print();", True)
	End Sub
End Class