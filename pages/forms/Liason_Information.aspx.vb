Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls

Public Class Liason_Information
	Inherits System.Web.UI.Page
	Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
	Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
	Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
	Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
	Dim con As New SqlConnection
	Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
	Dim cmd As New SqlCommand
	Dim dr As SqlDataReader
	Dim DBConnection As New DatabaseConection
	Dim Visits As New Class_VisitData
	Dim VisitID As Integer = Visits.GetVisitID
	Dim SchoolData As New Class_SchoolData
	Dim SchoolScheduleData As New Class_SchoolSchedule

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Session("LoggedIn") <> "1" Then
			Response.Redirect("../../default.aspx")
		End If

		If Not (IsPostBack) Then

			If VisitID <> 0 Then
				visitdate_hf.Value = VisitID
			End If

			'Populating school header
			Dim header As New Class_SchoolHeader
			headerSchoolName_lbl.Text = header.GetSchoolHeader()

		End If

	End Sub

	Sub LoadData()
		Dim VisitDate As Date = visitDate_tb.Text
		Dim VIDOfDate As Integer = Visits.GetVisitIDFromDate(VisitDate)
		Dim VTrainingTime As Date
		Dim ReplyBy As Date
		Dim SchoolName As String = schoolName_ddl.SelectedValue
		Dim SchoolID As String = SchoolData.GetSchoolID(SchoolName)
		Dim VMin As String
		Dim VMax As String
		Dim LiaisonName As String
		Dim DismissalTime As Date

		info_div.Visible = True
		print_btn.Visible = True

		'Get volunteer count, training time, and reply by
		VMin = SchoolData.GetVolunteerRange(VIDOfDate, SchoolID).VMin
		VMax = SchoolData.GetVolunteerRange(VIDOfDate, SchoolID).VMax
		'VMin = VisitData.LoadVisitInfoFromDate(VisitDate, "vMinCount")
		'VMax = VisitData.LoadVisitInfoFromDate(VisitDate, "vMaxCount")
		VTrainingTime = Visits.LoadVisitInfoFromDate(VisitDate, "vTrainingTime")
		ReplyBy = Visits.LoadVisitInfoFromDate(VisitDate, "replyBy")
		DismissalTime = SchoolScheduleData.GetDismissalTime(VTrainingTime)

		'Get liaison information
		Try
			con.ConnectionString = connection_string
			con.Open()
			cmd.CommandText = "SELECT liaisonName
								FROM schoolInfo
								WHERE schoolName='" & schoolName_ddl.SelectedValue & "'"
			cmd.Connection = con
			dr = cmd.ExecuteReader

			While dr.Read()
				LiaisonName = dr("liaisonName").ToString
			End While

			cmd.Dispose()
			con.Close()
		Catch
			error_lbl.Text = "Error in loaddata(). Could not get liaison information."
			cmd.Dispose()
			con.Close()
			Exit Sub
		End Try

		'Assign labels
		schoolName_lbl.Text = SchoolName
		visitDate_lbl.Text = VisitDate.ToShortDateString()
		visitDate2_lbl.Text = VisitDate.ToShortDateString()
		volunteerTime_lbl.Text = VTrainingTime.ToString("h:mm")
		replyBy_lbl.Text = ReplyBy.ToShortDateString
		liaison_lbl.Text = LiaisonName
		vMinCount_lbl.Text = VMin
		vMaxCount_lbl.Text = VMax
		volunteerDismisal_lbl.Text = DismissalTime.ToString("h:mm")

	End Sub

	Protected Sub visitDate_tb_TextChanged(sender As Object, e As EventArgs) Handles visitDate_tb.TextChanged
		If visitDate_tb.Text <> Nothing Then
			schoolName_ddl.Visible = True
			school_p.Visible = True

			SchoolData.LoadVisitDateSchoolsDDL(visitDate_tb.Text, schoolName_ddl)

		End If
	End Sub

	Protected Sub schoolName_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles schoolName_ddl.SelectedIndexChanged
		If schoolName_ddl.SelectedIndex <> 0 Then
			LoadData()
		Else
			info_div.Visible = False
			print_btn.Visible = False
		End If
	End Sub

	Protected Sub print_btn_Click(sender As Object, e As EventArgs) Handles print_btn.Click
		EVLogo_img.Visible = True
		Page.ClientScript.RegisterStartupScript(Me.GetType(), "Print", "PrintBadges();", True)
	End Sub
End Class