Imports System.IO
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Drawing

Public Class Template_Staff
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
	Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
	Dim con As New SqlConnection
	Dim cmd As New SqlCommand
	Dim dr As SqlDataReader
	Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
	Dim VisitData As New Class_VisitData
	Dim VisitID As Integer = VisitData.GetVisitID

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

		'Highlight row being edited
		'For Each row As GridViewRow In visit_dgv.Rows
		'	If row.RowIndex = visit_dgv.EditIndex Then
		'		row.BackColor = ColorTranslator.FromHtml("#ebe534")
		'		'row.BorderColor = ColorTranslator.FromHtml("#ffffff")
		'		row.BorderWidth = 2
		'	End If
		'Next
	End Sub

	'Private Sub notes_dgv_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles notes_dgv.RowUpdating
	'	Dim row As GridViewRow = notes_dgv.Rows(0)                           'Code is used to enable the editing prodecure
	'	Dim ID As Integer = Convert.ToInt32(notes_dgv.DataKeys(e.RowIndex).Values(0)) 'Gets id number

	'	Dim SchoolName As String = TryCast(notes_dgv.Rows(e.RowIndex).FindControl("schoolNameDGV_ddl"), DropDownList).SelectedValue.ToString
	'	Dim Note As String = TryCast(notes_dgv.Rows(e.RowIndex).FindControl("noteDGV_tb"), TextBox).Text
	'	Dim NoteUser As String = TryCast(notes_dgv.Rows(e.RowIndex).FindControl("noteUserDGV_lbl"), Label).Text
	'	Dim NoteTimestamp As String = TryCast(notes_dgv.Rows(e.RowIndex).FindControl("noteTimestampDGV_lbl"), Label).Text

	'	Try
	'		Using con As New SqlConnection(connection_string)
	'			Using cmd As New SqlCommand("UPDATE schoolNotes SET schoolName=@schoolName, note=@note, noteUser=@noteUser, noteTimestamp=@noteTimestamp WHERE ID=@Id")
	'				cmd.Parameters.AddWithValue("@ID", ID)
	'				cmd.Parameters.AddWithValue("@schoolName", SchoolName)
	'				cmd.Parameters.AddWithValue("@note", Note)
	'				cmd.Parameters.AddWithValue("@noteUser", NoteUser)
	'				cmd.Parameters.AddWithValue("@noteTimestamp", NoteTimestamp)
	'				cmd.Connection = con
	'				con.Open()
	'				cmd.ExecuteNonQuery()
	'				con.Close()
	'			End Using
	'		End Using
	'		notes_dgv.EditIndex = -1       'reset the grid after editing
	'		LoadData()

	'	Catch ex As Exception
	'		error_lbl.Text = "Error in rowUpdating. Cannot update row."
	'		Exit Sub
	'	End Try

	'End Sub

	'Private Sub notes_dgv_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles notes_dgv.RowDeleting
	'	Dim row As GridViewRow = notes_dgv.Rows(0)                           'Code is used to enable the editing prodecure
	'	Dim ID As Integer = Convert.ToInt32(notes_dgv.DataKeys(e.RowIndex).Values(0)) 'Gets id number

	'	Try
	'		Using con As New SqlConnection(connection_string)
	'			Using cmd As New SqlCommand("DELETE FROM schoolNotes WHERE id=@ID")
	'				cmd.Parameters.AddWithValue("@ID", ID)
	'				cmd.Connection = con
	'				con.Open()
	'				cmd.ExecuteNonQuery()
	'				con.Close()
	'			End Using
	'		End Using
	'		notes_dgv.EditIndex = -1       'reset the grid after editing

	'		LoadData()

	'	Catch ex As Exception
	'		error_lbl.Text = "Error in rowDeleting. Cannot delete row."
	'		Exit Sub
	'	End Try


	'End Sub

	'Private Sub notes_dgv_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles notes_dgv.RowEditing
	'	notes_dgv.EditIndex = e.NewEditIndex
	'	LoadData()
	'End Sub

	'Private Sub notes_dgv_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles notes_dgv.RowCancelingEdit
	'	notes_dgv.EditIndex = -1
	'	LoadData()
	'End Sub

	'Private Sub notes_dgv_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles notes_dgv.PageIndexChanging
	'	notes_dgv.PageIndex = e.NewPageIndex
	'	LoadData()
	'End Sub

	'Private Sub notes_dgv_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles notes_dgv.RowDataBound
	'	If (e.Row.RowType = DataControlRowType.DataRow) Then

	'		'School name DGV Dropdown
	'		Dim ddlSchoolName As DropDownList = CType(e.Row.FindControl("schoolNameDGV_ddl"), DropDownList)
	'		ddlSchoolName.DataSource = GetData("SELECT schoolname FROM schoolInfo WHERE NOT (schoolName = 'A1 No School Scheduled') AND NOT id='505' ORDER BY schoolName ASC")
	'		ddlSchoolName.DataTextField = "schoolName"
	'		'ddlSchool.DataValueField = "Businessid"
	'		ddlSchoolName.DataBind()
	'		Dim lblSchoolName As String = CType(e.Row.FindControl("schoolNameDGV_lbl"), Label).Text

	'		ddlSchoolName.Items.FindByValue(lblSchoolName).Selected = True
	'		'Dim businessID As String = ddlSchool.SelectedValue

	'	End If
	'End Sub

	Private Function GetData(query As String) As DataSet
		Dim cmd As New SqlCommand(query)
		Using con As New SqlConnection(connection_string)
			Using sda As New SqlDataAdapter()
				cmd.Connection = con
				sda.SelectCommand = cmd
				Using ds As New DataSet()
					sda.Fill(ds)
					Return ds
				End Using
			End Using
		End Using
	End Function

End Class