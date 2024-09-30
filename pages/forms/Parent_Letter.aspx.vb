Imports System.IO
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Runtime.CompilerServices

Public Class Parent_Letter
	Inherits System.Web.UI.Page
	Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
	Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
	Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
	Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
	Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
	Dim Visits As New Class_VisitData
	Dim SchoolData As New Class_SchoolData
	Dim VisitID As Integer = Visits.GetVisitID
	Dim Teacher As New Class_TeacherData
	Dim Schedule As New Class_SchoolSchedule

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
		Dim con As New SqlConnection
		Dim cmd As New SqlCommand

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
		Dim VisitDate As String = Convert.ToDateTime(visitDate_tb.Text)
		Dim VIDOfDate As Integer = Visits.GetVisitIDFromDate(VisitDate)
		Dim vTrainingTime As String = Visits.LoadVisitInfoFromDate(VisitDate, "vTrainingTime")
		Dim vArrival As DateTime = DateTime.Parse(vTrainingTime).AddMinutes(-15)
		Dim vDismissal As String = Schedule.GetDismissalTime(vArrival)
		Dim SchoolName As String = schoolName_ddl.SelectedValue
		Dim SchoolID As String = SchoolData.GetSchoolID(SchoolName)
		Dim vMin As String = SchoolData.GetVolunteerRange(VIDOfDate, SchoolID).VMin
		Dim vMax As String = SchoolData.GetVolunteerRange(VIDOfDate, SchoolID).VMax

		'Reveal divs
		letter_div.Visible = True
		returnSlip_div.Visible = True

		'Assign visit date labels
		visitDate_lbl.Text = VisitDate
		visitDateLetter_lbl.Text = VisitDate
		visitDateSlip1_lbl.Text = VisitDate

		'Assign volunteer labels
		volRange_lbl.Text = vMin & "-" & vMax

		'Assign training time
		trainingTimeSlip_lbl.Text = DateTime.Parse(vTrainingTime).ToString("t")

		'Assign arrival and dismissal times
		'volArrive_lbl.Text = DateTime.Parse(vArrival).ToString("t")
		'volDepart_lbl.Text = DateTime.Parse(vDismissal).ToString("t")

	End Sub

	Protected Sub visitDate_tb_TextChanged(sender As Object, e As EventArgs) Handles visitDate_tb.TextChanged
		If visitDate_tb.Text <> Nothing Then
			Dim visitDate As String = visitDate_tb.Text

			'Clear school name ddl
			schoolName_ddl.Items.Clear()

			'Reveal school name DDL
			schoolName_p.Visible = True
			schoolName_ddl.Visible = True

			'Populate school name DDL
			SchoolData.LoadVisitDateSchoolsDDL(visitDate, schoolName_ddl)
		Else
			'Hide school name DDL
			schoolName_p.Visible = False
			schoolName_ddl.Visible = False
			letter_div.Visible = False
			returnSlip_div.Visible = False
		End If
	End Sub

	Protected Sub print_btn_Click(sender As Object, e As EventArgs) Handles print_btn.Click
		Page.ClientScript.RegisterStartupScript(Me.GetType(), "Print", "Print();", True)
	End Sub

	Protected Sub schoolName_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles schoolName_ddl.SelectedIndexChanged
		If schoolName_ddl.SelectedIndex <> 0 Then
			LoadData()
		End If

	End Sub

End Class