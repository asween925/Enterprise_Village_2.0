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
	Dim SchoolData As New Class_SchoolData
	Dim VisitID As New Class_VisitData
	Dim Visit As Integer = VisitID.GetVisitID

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Session("LoggedIn") <> "1" Then
			Response.Redirect(".\default.aspx")
		End If

		If Not (IsPostBack) Then

			'Check if visit date exitsts for today
			If Visit <> 0 Then
				visitdate_hf.Value = Visit
			End If

			'Populating school header
			Dim header As New Class_SchoolHeader
			headerSchoolName_lbl.Text = header.GetSchoolHeader()

			'Populate schools 1-5 DDL
			SchoolData.LoadSchoolsDDL(schools_ddl)
			SchoolData.LoadSchoolsDDL(schools2_ddl)
			SchoolData.LoadSchoolsDDL(schools3_ddl)
			SchoolData.LoadSchoolsDDL(schools4_ddl)
			SchoolData.LoadSchoolsDDL(schools5_ddl)

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
			con.ConnectionString = connection_string
			con.Open()
			cmd.CommandText = "SELECT visitDate FROM visitInfo WHERE visitDate = '" & VisitDate & "'"
			cmd.Connection = con
			dr = cmd.ExecuteReader

			While dr.Read()
				If dr.HasRows = True Then
					error_lbl.Text = "A visit date has already been created for that day, please go to the 'Edit Visit' page to edit the visit for your inputted date."
					con.Close()
					cmd.Dispose()
					Exit Sub
				End If
			End While

			con.Close()
			cmd.Dispose()
		Catch
			error_lbl.Text = "Error in Submit(). Could not check if visit date has been created."
			Exit Sub
		End Try

		'Inserting new visit date into DB
		'Try
		Using con As New SqlConnection(connection_string)
				Using cmd As New SqlCommand("INSERT INTO visitInfo(
											school, vTrainingTime, replyBy, visitDate, studentCount, school2, school3, school4, visitTime, school5, teacherCompleted, deposit2Enable, deposit3Enable)
										SELECT (SELECT ID FROM schoolInfo WHERE schoolname = @schoolname), 
											@vTrainingTime, @replyBy, @visitdate, @studentcount, (SELECT ID FROM schoolInfo WHERE schoolname = @schoolname2), (SELECT ID FROM schoolInfo WHERE schoolname = @schoolname3), (SELECT ID FROM schoolInfo WHERE schoolname = @schoolname4), @visittime, (SELECT ID FROM schoolInfo WHERE schoolname = @schoolname5), teacherCompleted=0, deposit2Enable=0, deposit3Enable=0

										INSERT INTO onlineBanking(
											 visitID
											,visitDate
											,businessID
											,openstatus
											,startingAmount
											,loanAmount
											,deposit1
											,deposit2
											,deposit3
											,deposit4
											,profit
											,sales
											,school
											,businessVMinCount
											,businessVMaxCount
										)
										SELECT 
											 (SELECT ID FROM visitInfo WHERE visitDate = @visitdate)
											,@visitdate
											,businessID
											,1
											,startingAmount
											,loanAmount
											,deposit1
											,deposit2
											,deposit3
											,deposit4
											,profit
											,sales
											,(SELECT ID FROM schoolInfo WHERE schoolName = @schoolname)
											,0
											,0
										FROM onlineBanking_template t

										INSERT INTO studentInfo (
											 employeeNumber
											,firstName
											,lastName
											,school
											,business
											,job
											,visit
											,netDeposit1
											,netDeposit2
										)
										SELECT 
											 employeeNumber
											,firstName
											,lastName
											,(SELECT ID FROM schoolInfo WHERE schoolName = @schoolname)
											,business
											,job
											,(SELECT ID FROM visitInfo WHERE visitDate = @visitdate)
											,netDeposit1
											,netDeposit2
										FROM studentInfo_template t ")

					'Date that is inputed in the textbox
					cmd.Parameters.Add("@visitdate", SqlDbType.Date).Value = VisitDate
					cmd.Parameters.Add("@replyBy", SqlDbType.VarChar).Value = ReplyBy
					cmd.Parameters.Add("@schoolname", SqlDbType.VarChar).Value = School1
					cmd.Parameters.Add("@schoolname2", SqlDbType.VarChar).Value = School2
					cmd.Parameters.Add("@schoolname3", SqlDbType.VarChar).Value = School3
					cmd.Parameters.Add("@schoolname4", SqlDbType.VarChar).Value = School4
					cmd.Parameters.Add("@schoolname5", SqlDbType.VarChar).Value = School5
					cmd.Parameters.Add("@visittime", SqlDbType.Time).Value = VisitTime
					cmd.Parameters.Add("@vTrainingTime", SqlDbType.Time).Value = VTrainingStart
					cmd.Parameters.Add("@studentcount", SqlDbType.Int).Value = StudentCount
					'cmd.Parameters.Add("@invoice", SqlDbType.Int).Value = invoiceNum_tb.Text
					cmd.Connection = con
					con.Open()
					cmd.ExecuteNonQuery()
					con.Close()
				End Using

				'Move current visit date to previous visit date
				Using cmd As New SqlCommand("UPDATE schoolInfo SET previousVisitDate=currentVisitDate WHERE schoolName=@schoolName OR schoolName=@schoolName2 OR schoolName=@schoolName3 OR schoolName=@schoolName4 OR schoolName=@schoolName5")
					cmd.Parameters.Add("@schoolname", SqlDbType.VarChar).Value = School1
					cmd.Parameters.Add("@schoolname2", SqlDbType.VarChar).Value = School2
					cmd.Parameters.Add("@schoolname3", SqlDbType.VarChar).Value = School3
					cmd.Parameters.Add("@schoolname4", SqlDbType.VarChar).Value = School4
					cmd.Parameters.Add("@schoolname5", SqlDbType.VarChar).Value = School5
					cmd.Connection = con
					con.Open()
					cmd.ExecuteNonQuery()
					con.Close()
				End Using

				'Update schoolinfo current visit dates
				Using cmd As New SqlCommand("UPDATE schoolInfo SET currentVisitDate=@currentVisitDate WHERE schoolName=@schoolName OR schoolName=@schoolName2 OR schoolName=@schoolName3 OR schoolName=@schoolName4 OR schoolName=@schoolName5")
					cmd.Parameters.Add("@schoolname", SqlDbType.VarChar).Value = School1
					cmd.Parameters.Add("@schoolname2", SqlDbType.VarChar).Value = School2
					cmd.Parameters.Add("@schoolname3", SqlDbType.VarChar).Value = School3
					cmd.Parameters.Add("@schoolname4", SqlDbType.VarChar).Value = School4
					cmd.Parameters.Add("@schoolname5", SqlDbType.VarChar).Value = School5
					cmd.Parameters.Add("@currentVisitDate", SqlDbType.Date).Value = VisitDate
					cmd.Connection = con
					con.Open()
					cmd.ExecuteNonQuery()
					con.Close()

					'Refresh page
					Dim meta As New HtmlMeta()
					meta.HttpEquiv = "Refresh"
					meta.Content = "4;url=database.aspx"
					Me.Page.Controls.Add(meta)
					error_lbl.Text = "Submission Successful!"
				End Using
			End Using
		'Catch
		'	error_lbl.Text = "Error in Submit(). Could not execute SQL query."  'Code 1: Could be a visit date has already been made, or error in SQL cmd
		'	Exit Sub
		'End Try

	End Sub

	Protected Sub Submit_btn_Click(sender As Object, e As EventArgs) Handles Submit_btn.Click
		Submit()
	End Sub

	Protected Sub visitTime_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles visitTime_ddl.SelectedIndexChanged
		volunteerTime_tb.Text = SchoolScheduleData.GetVolArrivalTime(visitTime_ddl.SelectedValue)
	End Sub
End Class