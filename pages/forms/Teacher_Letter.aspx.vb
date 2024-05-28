Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls

Public Class Teacher_Letter
	Inherits System.Web.UI.Page
	Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
	Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
	Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
	Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
	Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
	Dim DBConnection As New DatabaseConection
	Dim dr As SqlDataReader
	Dim StudentData As New Class_StudentData
	Dim TeacherData As New Class_TeacherData
	Dim SchoolData As New Class_SchoolData
	Dim VisitData As New Class_VisitData
	Dim Visit As Integer = VisitData.GetVisitID

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Session("LoggedIn") <> "1" Then
			Response.Redirect("../../default.aspx")
		End If

		If Not (IsPostBack) Then
			If Visit <> 0 Then
				visitdate_hf.Value = Visit
			End If

			'Populating school header
			Dim header As New Class_SchoolHeader
			headerSchoolName_lbl.Text = header.GetSchoolHeader()
		End If

	End Sub

	Sub LoadSchoolsDDL()
		Dim visitDate As String = visitDate_tb.Text

		'Check if visit date has a date
		If visitDate_tb.Text <> Nothing Then

			'Made school name DDL and header visible
			schoolName_ddl.Visible = True
			school_p.Visible = True

			'Clear out teacher and school DDLs
			schoolName_ddl.Items.Clear()
			teacherName_ddl.Items.Clear()

			'Populate school DDL from entered visit date
			Try
				SchoolData.LoadVisitDateSchoolsDDL(visitDate, schoolName_ddl)
			Catch
				error_lbl.Text = "Error in LoadSchoolsDDL(). Could not get school names."
				Exit Sub
			End Try

		End If
	End Sub

	Sub LoadTeachersDDL()
		Dim SchoolName As String

		'Check if school DDL has a selected school
		If schoolName_ddl.SelectedIndex <> 0 Then

			'Make teacher DDL and header visible
			teacherName_ddl.Visible = True
			teacher_p.Visible = True

			'Clear out teacher DDL
			teacherName_ddl.Items.Clear()

			'Assign varible
			SchoolName = schoolName_ddl.SelectedValue

			'Populate teacher names DDL
			Try
				TeacherData.LoadTeacherNameDDL(SchoolName, teacherName_ddl)
			Catch
				error_lbl.Text = "Error in LoadTeachersDDL. Could not get teacher names."
				Exit Sub
			End Try

			'Check if school is public or out of county
			Try
				schoolType_hf.Value = SchoolData.LoadSchoolInfoFromSchool(SchoolName, "schoolType")
			Catch
				error_lbl.Text = "Error in LoadTeachersDDL. Could not get school type."
				Exit Sub
			End Try

		Else
			'Make info div, print buttons, and teacher name DDL invisible
			info_div.Visible = False
			print_btn.Visible = False
			teacherName_ddl.Visible = False
		End If
	End Sub

	Sub LoadStudentCount()
		Dim SchoolName As String = schoolName_ddl.SelectedValue
		Dim VisitDate As String = visitDate_tb.Text

		'Check if teacher DDL has something selected
		If teacherName_ddl.SelectedIndex <> 0 Then

			'Get student count
			'Try
			studentCount_lbl.Text = StudentData.GetSVCStudentCount(VisitDate, SchoolName)

				If studentCount_lbl.Text = "" Or studentCount_lbl.Text = Nothing Or studentCount_lbl.Text = "0" Then
				'Exit Try
			Else
					'Load all data
					LoadData()
					Exit Sub
				End If

			'Catch
			'	error_lbl.Text = "Error in LoadStudentCount. Could not get school's student count."
			'	Exit Sub
			'End Try

			'If student count is blank or null, run this SQL
			Try
				studentCount_lbl.Text = VisitData.LoadVisitInfoFromDate(VisitDate, "studentCount")
				LoadData()
			Catch
				error_lbl.Text = "Error in LoadStudentCount. Could not find visit date student count."
				Exit Sub
			End Try

		Else
			info_div.Visible = False
			print_btn.Visible = False
		End If
	End Sub

	Sub LoadData()
		Dim con As New SqlConnection
		Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
		Dim cmd As New SqlCommand
		Dim dr As SqlDataReader
		Dim VisitFormat As Date = visitDate_tb.Text
		Dim visitFormat2 As Date = visitDate_tb.Text
		Dim vTrainingTime As Date
		Dim ReplyBy As Date
		Dim count As Integer = 1
		Dim sharingSchoolsString As String
		Dim SchoolName As String = schoolName_ddl.SelectedValue
		Dim VisitDate As String = visitDate_tb.Text
		Dim TeacherName As String = teacherName_ddl.SelectedValue
		Dim VisitTime As String
		Dim DismissalTime As Date
		Dim ArrivalTime As Date

		'Clear check boxes
		bucs_chk.Checked = False
		rays_chk.Checked = False
		cvs_chk.Checked = False
		kanes_chk.Checked = False
		bic_chk.Checked = False
		td_chk.Checked = False
		hsn_chk.Checked = False
		bbb_chk.Checked = False
		astro_chk.Checked = False
		ditek_chk.Checked = False
		ach_chk.Checked = False
		baycare_chk.Checked = False
		city_chk.Checked = False
		dali_chk.Checked = False
		duke_chk.Checked = False
		mcdonalds_chk.Checked = False
		mix_chk.Checked = False
		pcsw_chk.Checked = False
		pcu_chk.Checked = False
		know_chk.Checked = False
		times_chk.Checked = False
		ups_chk.Checked = False
		united_chk.Checked = False

		'Clear sharing schools label
		sharingSchoolString_lbl.Text = ""
		sharingSchoolsString = ""

		'Make info div and print button visible
		info_div.Visible = True
		print_btn.Visible = True

		'Make certain divs visible based on the school type
		If schoolType_hf.Value = "Public" Or schoolType_hf.Value = "PC Charter" Then
			inCountyLetter_div.Visible = True
			outOfCountyLetter_div.Visible = False
		Else
			outOfCountyLetter_div.Visible = True
			inCountyLetter_div.Visible = False
		End If

		'Get school ID
		Try
			schoolID_hf.Value = SchoolData.GetSchoolID(SchoolName)
		Catch
			error_lbl.Text = "Error in loaddata(). Could not get school ID."
			Exit Sub
		End Try

		'Get volunteer count for school
		Try
			con.ConnectionString = connection_string
			con.Open()
			cmd.CommandText = "SELECT SUM(o.businessVMinCount) as vMin, SUM(o.businessVMaxCount) as vMax
								FROM onlineBanking o
								WHERE o.visitDate='" & visitDate_tb.Text & "' AND o.school='" & schoolID_hf.Value & "' AND o.openstatus=1"
			cmd.Connection = con
			dr = cmd.ExecuteReader

			While dr.Read()
				vMin_lbl.Text = dr("vMin").ToString
				vMax_lbl.Text = dr("vMax").ToString
				vMin2_lbl.Text = dr("vMin").ToString
				vMax2_lbl.Text = dr("vMax").ToString
			End While

			cmd.Dispose()
			con.Close()
		Catch
			error_lbl.Text = "Error in loaddata(). Could not get volunteer count."
			cmd.Dispose()
			con.Close()
			Exit Sub
		End Try

		'get visit time, training time, reply by date
		Try
			vTrainingTime = VisitData.LoadVisitInfoFromDate(VisitDate, "vTrainingTime")
			replyBy = VisitData.LoadVisitInfoFromDate(VisitDate, "replyBy")
			VisitTime = VisitData.LoadVisitInfoFromDate(VisitDate, "visitTime")

			'Assign to labels
			schoolName_lbl.Text = SchoolName
			visitDate_lbl.Text = VisitFormat.ToShortDateString()
			vTrainingTime_lbl.Text = vTrainingTime.ToShortTimeString()
			vTrainingTime2_lbl.Text = vTrainingTime.ToShortTimeString()
			replyBy_lbl.Text = replyBy.ToShortDateString()
			replyBy2_lbl.Text = replyBy.ToShortDateString()
			teacherName_lbl.Text = TeacherName

		Catch
			error_lbl.Text = "Error in loaddata(). Could not get letter information."
			Exit Sub
		End Try

		'Get student arrival/dismisal time
		Try
			con.ConnectionString = connection_string
			con.Open()
			cmd.CommandText = "SELECT timeStudentsArrive, leaveEV FROM schoolSchedule WHERE schoolSchedule='" & VisitTime & "'"
			cmd.Connection = con
			dr = cmd.ExecuteReader

			While dr.Read()
				ArrivalTime = dr("timeStudentsArrive").ToString
				DismissalTime = dr("leaveEV").ToString
			End While

			studentArrivalTime_lbl.Text = ArrivalTime.ToShortTimeString()
			studentDismissalTime_lbl.Text = DismissalTime.ToString("HH:mm") & " PM"

			cmd.Dispose()
			con.Close()
		Catch
			error_lbl.Text = "Error in loaddata(). Could not get student arrival time/dismissal time."
			Exit Sub
		End Try

		'Get sharing schools
		Try
			sharingSchoolsString = SchoolData.GetSharedSchoolsString(VisitDate, SchoolName)
			sharingSchoolString_lbl.Text = sharingSchoolsString

			'This dont work
			If sharingSchoolString_lbl.Text = " " Or sharingSchoolString_lbl.Text = Nothing Then
				sharingSchoolString_lbl.Text = "None"
			End If
		Catch
			error_lbl.Text = "Error in LoadData(). Could not load sharing schools."
			Exit Sub
		End Try

		cmd.Dispose()
		con.Close()

		'Get business open status
		While count < 25
			If count = 4 Then
				count = count + 1
			Else
				Try
					con.ConnectionString = connection_string
					con.Open()
					cmd.CommandText = "SELECT o.businessID, o.openstatus
								FROM onlineBanking o
								INNER JOIN schoolInfo s
								ON s.id = o.school
								WHERE o.visitDate='" & visitDate_lbl.Text & "' AND o.businessID='" & count & "' 
								AND s.schoolName = '" & schoolName_ddl.SelectedValue & "' AND o.openstatus=1
								ORDER BY o.businessID"
					cmd.Connection = con
					dr = cmd.ExecuteReader

					While dr.Read()

						'Check for rows
						If dr.HasRows = True Then

							'If business ID equals the count number then check the boxes
							If dr("businessID") = count Then
								businessCount_ddl.SelectedValue = count

								Select Case businessCount_ddl.SelectedValue
									Case "1"
										bucs_chk.Checked = True
									Case "2"
										rays_chk.Checked = True
									Case "3"
										cvs_chk.Checked = True
									Case "5"
										kanes_chk.Checked = True
									Case "6"
										bic_chk.Checked = True
									Case "7"
										td_chk.Checked = True
									Case "8"
										hsn_chk.Checked = True
									Case "9"
										bbb_chk.Checked = True
									Case "10"
										astro_chk.Checked = True
									Case "11"
										ditek_chk.Checked = True
									Case "12"
										ach_chk.Checked = True
									Case "13"
										baycare_chk.Checked = True
									Case "14"
										city_chk.Checked = True
									Case "15"
										dali_chk.Checked = True
									Case "16"
										duke_chk.Checked = True
									Case "17"
										mcdonalds_chk.Checked = True
									Case "18"
										mix_chk.Checked = True
									Case "19"
										pcsw_chk.Checked = True
									Case "20"
										pcu_chk.Checked = True
									Case "21"
										know_chk.Checked = True
									Case "22"
										times_chk.Checked = True
									Case "23"
										ups_chk.Checked = True
									Case "24"
										united_chk.Checked = True
								End Select
							End If
						Else

							Exit While
						End If

					End While

					cmd.Dispose()
					con.Close()

				Catch
					error_lbl.Text = "Error in loaddata(). Could not get business open information. " & count
					cmd.Dispose()
					con.Close()
					Exit Sub
				End Try

				cmd.Dispose()
				con.Close()

				'Increase count number
				count = count + 1
			End If
		End While

	End Sub

	Protected Sub visitDate_tb_TextChanged(sender As Object, e As EventArgs) Handles visitDate_tb.TextChanged
		LoadSchoolsDDL()
	End Sub

	Protected Sub schoolName_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles schoolName_ddl.SelectedIndexChanged
		LoadTeachersDDL()
	End Sub

	Protected Sub print_btn_Click(sender As Object, e As EventArgs) Handles print_btn.Click
		Page.ClientScript.RegisterStartupScript(Me.GetType(), "Print", "PrintBadges();", True)
	End Sub

	Protected Sub teacherName_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles teacherName_ddl.SelectedIndexChanged
		LoadStudentCount()
	End Sub
End Class