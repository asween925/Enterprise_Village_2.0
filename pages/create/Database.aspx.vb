Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls
Public Class Database
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim DBConnection As New DatabaseConection
	Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
	Dim con As New SqlConnection
	Dim cmd As New SqlCommand
	Dim dr As SqlDataReader
	Dim SchoolScheduleData As New Class_SchoolSchedule
	Dim Schools As New Class_SchoolData
	Dim Visits As New Class_VisitData
	Dim SH As New Class_SchoolHeader
	Dim VisitID As Integer = Visits.GetVisitID

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		If Session("LoggedIn") <> "1" Then
			Response.Redirect("../../default.aspx")
		End If

		If Not (IsPostBack) Then

			'Populating school header
			headerSchoolName_lbl.Text = SH.GetSchoolHeader()

			'Populate schools 1-5 DDL
			Schools.LoadSchoolsDDL(schools_ddl)
			Schools.LoadSchoolsDDL(schools2_ddl)
			Schools.LoadSchoolsDDL(schools3_ddl)
			Schools.LoadSchoolsDDL(schools4_ddl)
			Schools.LoadSchoolsDDL(schools5_ddl)

			'Populate visit time DDL
			SchoolScheduleData.LoadVisitTimeDDL(visitTime_ddl)

			'insert no school scheduled into first school ddl
			schools_ddl.Items.Insert(1, "A1 No School Scheduled")

		End If
	End Sub

	Sub Submit()
		Dim VisitDate As String
		Dim ReplyBy As String = replyBy_tb.Text
		Dim VisitTime As String = visitTime_ddl.SelectedValue
		Dim StudentCount As String = studentCount_tb.Text
		Dim VTrainingStart As String = volunteerTime_tb.Text
		Dim School1 As String
		Dim School2 As String = schools2_ddl.SelectedValue
		Dim School3 As String = schools3_ddl.SelectedValue
		Dim School4 As String = schools4_ddl.SelectedValue
		Dim School5 As String = schools5_ddl.SelectedValue

		'Check for empty fields
		If visit_tb.Text = Nothing Or schools_ddl.SelectedIndex = 0 Then
			error_lbl.Text = "Please enter a visit date and school 1 name."
			Exit Sub
		Else
			VisitDate = visit_tb.Text
			School1 = schools_ddl.SelectedValue
		End If

		If replyBy_tb.Text = Nothing Then
			ReplyBy = "01/01/1900"
		End If

		If studentCount_tb.Text = Nothing Then
			StudentCount = "0"
		ElseIf studentCount_tb.Text < 0 Then
			error_lbl.Text = "Please enter a student count 0 or higher."
			Exit Sub
		End If

		If volunteerTime_tb.Text = Nothing Then
			VTrainingStart = "00:00"
		End If

		'Check if visit date has already been created
		Try
			If Visits.GetVisitIDFromDate(VisitDate) <> 0 Then
				error_lbl.Text = "A visit date has already been created for that day, please go to the 'Edit Visit' page to edit the visit for your inputted date."
				Exit Sub
			End If
		Catch
			error_lbl.Text = "Error in Submit(). Could not check if visit date has been created."
			Exit Sub
		End Try

		'Insert visit data into visitInfo, studentInfo, businessVisitInfo
		Try
			Visits.CreateVisit(VisitDate, ReplyBy, School1, School2, School3, School4, School5, VisitTime, VTrainingStart, StudentCount)
		Catch ex As Exception
			error_lbl.Text = "Error in Submit(). Could not create visit."
			Exit Sub
		End Try

		'Move current visit date to previous visit date
		Try
			Visits.MoveVisitDate(School1, School2, School3, School4, School5, VisitDate)
		Catch ex As Exception
			error_lbl.Text = "Error in Submit(). Could not move visit date."
			Exit Sub
		End Try

		'Refresh page after 4 seconds
		Dim meta As New HtmlMeta()
		meta.HttpEquiv = "Refresh"
		meta.Content = "4;url=database.aspx"
		Me.Page.Controls.Add(meta)
		error_lbl.Text = "Submission Successful!"

	End Sub

	Protected Sub Submit_btn_Click(sender As Object, e As EventArgs) Handles Submit_btn.Click
		Submit()
	End Sub

	Protected Sub visitTime_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles visitTime_ddl.SelectedIndexChanged
		volunteerTime_tb.Text = SchoolScheduleData.GetVolArrivalTime(visitTime_ddl.SelectedValue)
	End Sub
End Class