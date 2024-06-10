Imports System.IO
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

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
		Dim SchoolName As String = schoolName_ddl.SelectedValue
		Dim SchoolID As String = SchoolData.GetSchoolID(SchoolName)
		Dim vMin As String = SchoolData.GetVolunteerRange(VIDOfDate, SchoolID).VMin
		Dim vMax As String = SchoolData.GetVolunteerRange(VIDOfDate, SchoolID).VMax

		'Reveal divs
		letter_div.Visible = True
		returnSlip_div.Visible = True

		'Assign visit date labels
		visitDateLetter_lbl.Text = VisitDate
		visitDateSlip1_lbl.Text = VisitDate
		visitDateSlip2_lbl.Text = VisitDate

		'Assign volunteer labels
		volRange_lbl.Text = vMin & "-" & vMax

		'Assign training time
		trainingTime_lbl.Text = vTrainingTime
		trainingTimeSlip_lbl.Text = vTrainingTime

	End Sub

	Protected Sub visitDate_tb_TextChanged(sender As Object, e As EventArgs) Handles visitDate_tb.TextChanged
		Dim visitDate As String = visitDate_tb.Text

		'Reveal school name DDL
		schoolName_p.Visible = True
		schoolName_ddl.Visible = True

		'Populate school name DDL
		SchoolData.LoadVisitDateSchoolsDDL(visitDate, schoolName_ddl)
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