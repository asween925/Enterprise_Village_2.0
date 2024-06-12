Imports System.IO
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Drawing

Public Class Schedule_Request_Form_Checklist
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

			LoadData()
		End If
	End Sub

	Sub LoadData()
		Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
		Dim con As New SqlConnection
		Dim cmd As New SqlCommand
		Dim sql As String = "SELECT s.id, s.schoolName, TRIM(t.firstName)+' '+TRIM(t.lastName) as teacherName, t.futureRequestsEmail,  s.spfReturned
								FROM teacherInfo t
								INNER JOIN schoolInfo s
								ON s.ID = t.schoolID
								WHERE t.isContact=1 AND NOT t.schoolID IS NULL
								ORDER BY s.schoolName ASC"

		Try
			con.ConnectionString = connection_string
			con.Open()
			cmd = New SqlCommand
			cmd.Connection = con
			cmd.CommandText = sql

			Dim da As New SqlDataAdapter
			da.SelectCommand = cmd
			Dim dt As New DataTable
			da.Fill(dt)
			schools_dgv.DataSource = dt
			schools_dgv.DataBind()

			cmd.Dispose()
			con.Close()

		Catch
			error_lbl.Text = "Error in LoadData(). Cannot load checklist."
			Exit Sub
		End Try

		'Highlight row being edited
		For Each row As GridViewRow In schools_dgv.Rows
			If row.RowIndex = schools_dgv.EditIndex Then
				row.BackColor = ColorTranslator.FromHtml("#ebe534")
				'row.BorderColor = ColorTranslator.FromHtml("#ffffff")
				row.BorderWidth = 2
			End If
		Next
	End Sub

	Private Sub schools_dgv_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles schools_dgv.RowUpdating
		Dim row As GridViewRow = schools_dgv.Rows(0)                           'Code is used to enable the editing prodecure
		Dim ID As Integer = Convert.ToInt32(schools_dgv.DataKeys(e.RowIndex).Values(0)) 'Code is used to enable the editing procedure

		Dim spfReturned As Boolean = TryCast(schools_dgv.Rows(e.RowIndex).FindControl("spfReturned_chk"), CheckBox).Checked  'Try cast is used to try to convert - gets item from ddl

		Using con As New SqlConnection(connection_string)
			Using cmd As New SqlCommand("UPDATE schoolInfo SET spfReturned=@spfReturned WHERE ID=@Id")
				cmd.Parameters.AddWithValue("@ID", ID)
				cmd.Parameters.AddWithValue("@spfReturned", spfReturned)
				cmd.Connection = con
				con.Open()
				cmd.ExecuteNonQuery()
				con.Close()
			End Using
		End Using

		schools_dgv.EditIndex = -1       'reset the grid after editing
		LoadData()

	End Sub

	Private Sub schools_dgv_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles schools_dgv.RowEditing
		schools_dgv.EditIndex = e.NewEditIndex
		LoadData()
	End Sub

	Private Sub schools_dgv_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles schools_dgv.RowCancelingEdit
		schools_dgv.EditIndex = -1
		LoadData()
	End Sub

	Protected Sub print_btn_Click(sender As Object, e As EventArgs) Handles print_btn.Click
		Page.ClientScript.RegisterStartupScript(Me.GetType(), "Print", "Print();", True)
	End Sub

	Protected Sub clear_btn_Click(sender As Object, e As EventArgs) Handles clear_btn.Click

		'Reveal confirm div
		confirmClear_div.Visible = True

	End Sub

	Protected Sub confirmClear_btn_Click(sender As Object, e As EventArgs) Handles confirmClear_btn.Click
		Using con As New SqlConnection(connection_string)
			Using cmd As New SqlCommand("UPDATE schoolInfo SET spfReturned=0")
				cmd.Connection = con
				con.Open()
				cmd.ExecuteNonQuery()
				con.Close()
			End Using
		End Using

		'Make confirm div invisible
		confirmClear_div.Visible = False

		LoadData()
	End Sub

	Protected Sub cancelClear_btn_Click(sender As Object, e As EventArgs) Handles cancelClear_btn.Click
		Response.Redirect("schedule_request_form_checklist.aspx")
	End Sub
End Class