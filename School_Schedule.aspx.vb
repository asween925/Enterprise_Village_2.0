Imports System.IO
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Drawing

Public Class School_Schedule
	Inherits System.Web.UI.Page
	Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
	Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
	Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
	Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
	Dim con As New SqlConnection
	Dim cmd As New SqlCommand
	Dim dr As SqlDataReader
	Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
	Dim SchoolScheduleData As New Class_SchoolSchedule
	Dim VisitData As New Class_VisitData
	Dim VisitID As Integer = VisitData.GetVisitID

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Session("LoggedIn") <> "1" Then
			Response.Redirect(".\default.aspx")
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

		LoadData()
	End Sub

	Sub LoadData()

		'Clear out table
		schedule_dgv.DataSource = Nothing
		schedule_dgv.DataBind()

		'Clear out error label
		error_lbl.Text = ""

		'Load data 
		Try
			schedule_dgv.DataSource = SchoolScheduleData.LoadSchoolSchedule()
			schedule_dgv.DataBind()
		Catch
			error_lbl.Text = "Error in LoadData(). Could not load school schedule."
			Exit Sub
		End Try

		'Load print table
		Try
			schoolNotesPrint_dgv.DataSource = SchoolScheduleData.LoadSchoolSchedule()
			schoolNotesPrint_dgv.DataBind()
		Catch
			error_lbl.Text = "Error in LoadData(). Could not load print school schedule."
			Exit Sub
		End Try

		'Highlight row being edited
		For Each row As GridViewRow In schedule_dgv.Rows
			If row.RowIndex = schedule_dgv.EditIndex Then
				row.BackColor = ColorTranslator.FromHtml("#ebe534")
				'row.BorderColor = ColorTranslator.FromHtml("#ffffff")
				row.BorderWidth = 2
			End If
		Next

	End Sub

	Sub Print()

		'Make print table visible
		schoolNotesPrint_dgv.Visible = True

		'Make edit table invisible
		schedule_dgv.Visible = False

		'Open print window
		Page.ClientScript.RegisterStartupScript(Me.GetType(), "Print", "Print();", True)

	End Sub

	Private Sub schedule_dgv_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles schedule_dgv.RowUpdating
		Dim row As GridViewRow = schedule_dgv.Rows(0)                           'Code is used to enable the editing prodecure
		Dim ID As Integer = Convert.ToInt32(schedule_dgv.DataKeys(e.RowIndex).Values(0)) 'Gets id number

		Dim SchoolSchedule As String = TryCast(schedule_dgv.Rows(e.RowIndex).FindControl("schoolSchedule_tb"), TextBox).Text
		Dim TimeVolArrive As String = TryCast(schedule_dgv.Rows(e.RowIndex).FindControl("timeVolArrive_tb"), TextBox).Text
		Dim TimeStudentsArrive As String = TryCast(schedule_dgv.Rows(e.RowIndex).FindControl("timeStudentsArrive_tb"), TextBox).Text
		Dim TimeClassBegins As String = TryCast(schedule_dgv.Rows(e.RowIndex).FindControl("timeClassBegins_tb"), TextBox).Text
		Dim StudentsLunch As String = TryCast(schedule_dgv.Rows(e.RowIndex).FindControl("studentsLunch_tb"), TextBox).Text
		Dim TownMeetingBegins As String = TryCast(schedule_dgv.Rows(e.RowIndex).FindControl("townMeetingBegins_tb"), TextBox).Text
		Dim LeaveEV As String = TryCast(schedule_dgv.Rows(e.RowIndex).FindControl("leaveEV_tb"), TextBox).Text

		Try
			Using con As New SqlConnection(connection_string)
				Using cmd As New SqlCommand("UPDATE schoolSchedule SET schoolSchedule=@schoolSchedule, timeVolArrive=@timeVolArrive, timeStudentsArrive=@timeStudentsArrive, timeClassBegins=@timeClassBegins, studentsLunch=@studentsLunch, townMeetingBegins=@townMeetingBegins, leaveEV=@leaveEV WHERE ID=@ID")
					cmd.Parameters.AddWithValue("@ID", ID)
					cmd.Parameters.AddWithValue("@schoolSchedule", SchoolSchedule)
					cmd.Parameters.AddWithValue("@timeVolArrive", TimeVolArrive)
					cmd.Parameters.AddWithValue("@timeStudentsArrive", TimeStudentsArrive)
					cmd.Parameters.AddWithValue("@timeClassBegins", TimeClassBegins)
					cmd.Parameters.AddWithValue("@studentsLunch", StudentsLunch)
					cmd.Parameters.AddWithValue("@townMeetingBegins", TownMeetingBegins)
					cmd.Parameters.AddWithValue("@leaveEV", LeaveEV)

					cmd.Connection = con
					con.Open()
					cmd.ExecuteNonQuery()
					con.Close()
				End Using
			End Using

			schedule_dgv.EditIndex = -1       'reset the grid after editing
			LoadData()

		Catch
			error_lbl.Text = "Error in rowUpdating. Cannot update row."
			Exit Sub
		End Try

	End Sub

	Private Sub schedule_dgv_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles schedule_dgv.RowEditing
		schedule_dgv.EditIndex = e.NewEditIndex
		LoadData()
	End Sub

	Private Sub schedule_dgv_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles schedule_dgv.RowCancelingEdit
		schedule_dgv.EditIndex = -1
		LoadData()
	End Sub

	Protected Sub print_btn_Click(sender As Object, e As EventArgs) Handles print_btn.Click
		Print()
	End Sub
End Class