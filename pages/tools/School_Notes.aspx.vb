Imports System.IO
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Drawing

Public Class School_Notes
	Inherits System.Web.UI.Page
	Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
	Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
	Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
	Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
	Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
	Dim VisitID As New Class_VisitData
	Dim Visit As Integer = VisitID.GetVisitID
	Dim SchoolData As New Class_SchoolData
	Dim TeacherData As New Class_TeacherData
	Dim SQLCommand As New Class_SQLCommands


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

			'Populate schools DDL
			SchoolData.LoadSchoolsDDL(schoolName_ddl)
		End If
	End Sub

	Sub Submit()
		Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
		Dim con As New SqlConnection
		Dim cmd As New SqlCommand
		Dim SchoolName As String = schoolName_ddl.SelectedValue
		Dim SchoolID As Integer = SchoolData.GetSchoolID(SchoolName)
		Dim note As String = note_tb.Text
		Dim Username As String = Session("username")

		'Check for blanks or errors
		If note_tb.Text = Nothing Or note_tb.Text = "" Then
			error_lbl.Text = "Please enter a note."
			Exit Sub
		End If

		'Insert data into DB
		Try
			con.ConnectionString = connection_string
			con.Open()
			cmd.Connection = con
			cmd.CommandText = "INSERT INTO schoolNotes (schoolID, note, noteUser, noteTimestamp) VALUES ('" & SchoolID & "', '" & note & "', '" & Username & "', '" & Date.Now() & "')"
			cmd.ExecuteNonQuery()
			cmd.Dispose()
			con.Close()

			LoadData()
		Catch
			error_lbl.Text = "Error in Submit(). Could not enter note."
			Exit Sub
		End Try

	End Sub

	Sub LoadData()
		Dim SchoolName As String = schoolName_ddl.SelectedValue
		Dim SchoolID As Integer = SchoolData.GetSchoolID(SchoolName)
		Dim columnSort As String = "id"
		Dim orderSort As String = "DESC"
		Dim Address As String = SchoolData.LoadSchoolInfoFromSchool(SchoolName, "address")
		Dim State As String = SchoolData.LoadSchoolInfoFromSchool(SchoolName, "state")
		Dim City As String = SchoolData.LoadSchoolInfoFromSchool(SchoolName, "city")
		Dim Zip As String = SchoolData.LoadSchoolInfoFromSchool(SchoolName, "zip")

		'Clear out notes_dgv
		notes_dgv.DataSource = Nothing
		notes_dgv.DataBind()

		'Clear out error label
		error_lbl.Text = ""

		'Clear out notes textbox
		note_tb.Text = ""

		'Make div info and table visible
		schoolInfo_div.Visible = True
		newEntry_div.Visible = True
		schoolNotes_div.Visible = True

		'Populate labels
		schoolName_lbl.Text = SchoolData.LoadSchoolInfoFromSchool(SchoolName, "schoolName") 'in this function, we pass in the school name as the schoolName varible, as well as a string of the column name we want from the DB
		schoolPhone_lbl.Text = SchoolData.LoadSchoolInfoFromSchool(SchoolName, "phone")
		contactTeacher_lbl.Text = TeacherData.GetContactTeacher(SchoolName)
		schoolType_lbl.Text = SchoolData.LoadSchoolInfoFromSchool(SchoolName, "schoolType")
		schoolNumber_lbl.Text = SchoolData.LoadSchoolInfoFromSchool(SchoolName, "schoolNum")
		schoolAddress_lbl.Text = Address & ", " & City & ", " & State & " " & Zip

		'Load school notes table
		Try
			notes_dgv.DataSource = SQLCommand.LoadSchoolNotes(SchoolID, "noteTimestamp", "DESC")
			notes_dgv.DataBind()
		Catch
			error_lbl.Text = "Error in LoadData(). Could not load school notes."
			Exit Sub
		End Try

		'Highlight row being edited
		For Each row As GridViewRow In notes_dgv.Rows
			If row.RowIndex = notes_dgv.EditIndex Then
				row.BackColor = ColorTranslator.FromHtml("#ebe534")
				'row.BorderColor = ColorTranslator.FromHtml("#ffffff")
				row.BorderWidth = 2
			End If
		Next

	End Sub

	Protected Sub schoolName_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles schoolName_ddl.SelectedIndexChanged
		If schoolName_ddl.SelectedIndex <> 0 Then
			LoadData()
		End If
	End Sub

	Protected Sub submit_btn_Click(sender As Object, e As EventArgs) Handles submit_btn.Click
		Submit()
	End Sub

	Private Sub notes_dgv_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles notes_dgv.RowUpdating
        Dim row As GridViewRow = notes_dgv.Rows(0)                           'Code is used to enable the editing prodecure
        Dim ID As Integer = Convert.ToInt32(notes_dgv.DataKeys(e.RowIndex).Values(0)) 'Gets id number

		Dim SchoolID As String = TryCast(notes_dgv.Rows(e.RowIndex).FindControl("schoolNameDGV_ddl"), DropDownList).SelectedValue.ToString
		Dim Note As String = TryCast(notes_dgv.Rows(e.RowIndex).FindControl("noteDGV_tb"), TextBox).Text
		Dim NoteUser As String = TryCast(notes_dgv.Rows(e.RowIndex).FindControl("noteUserDGV_lbl"), Label).Text
		Dim NoteTimestamp As String = TryCast(notes_dgv.Rows(e.RowIndex).FindControl("noteTimestampDGV_lbl"), Label).Text

		Try
            Using con As New SqlConnection(connection_string)
				Using cmd As New SqlCommand("UPDATE schoolNotes SET schoolID=@schoolID, note=@note, noteUser=@noteUser, noteTimestamp=@noteTimestamp WHERE ID=@Id")
					cmd.Parameters.AddWithValue("@ID", ID)
					cmd.Parameters.AddWithValue("@schoolID", SchoolID)
					cmd.Parameters.AddWithValue("@note", Note)
					cmd.Parameters.AddWithValue("@noteUser", NoteUser)
					cmd.Parameters.AddWithValue("@noteTimestamp", NoteTimestamp)
					cmd.Connection = con
					con.Open()
					cmd.ExecuteNonQuery()
					con.Close()
				End Using
			End Using
            notes_dgv.EditIndex = -1       'reset the grid after editing
            LoadData()

        Catch ex As Exception
            error_lbl.Text = "Error in rowUpdating. Cannot update row."
            Exit Sub
        End Try

    End Sub

	Private Sub notes_dgv_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles notes_dgv.RowDeleting
		Dim row As GridViewRow = notes_dgv.Rows(0)                           'Code is used to enable the editing prodecure
		Dim ID As Integer = Convert.ToInt32(notes_dgv.DataKeys(e.RowIndex).Values(0)) 'Gets id number

		Try
			Using con As New SqlConnection(connection_string)
				Using cmd As New SqlCommand("DELETE FROM schoolNotes WHERE id=@ID")
					cmd.Parameters.AddWithValue("@ID", ID)
					cmd.Connection = con
					con.Open()
					cmd.ExecuteNonQuery()
					con.Close()
				End Using
			End Using
			notes_dgv.EditIndex = -1       'reset the grid after editing

			LoadData()

		Catch ex As Exception
			error_lbl.Text = "Error in rowDeleting. Cannot delete row."
			Exit Sub
		End Try


	End Sub

	Private Sub notes_dgv_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles notes_dgv.RowEditing
        notes_dgv.EditIndex = e.NewEditIndex
        LoadData()
    End Sub

    Private Sub notes_dgv_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles notes_dgv.RowCancelingEdit
        notes_dgv.EditIndex = -1
        LoadData()
    End Sub

    Private Sub notes_dgv_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles notes_dgv.PageIndexChanging
        notes_dgv.PageIndex = e.NewPageIndex
        LoadData()
    End Sub

    Private Sub notes_dgv_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles notes_dgv.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then

            'School name DGV Dropdown
            Dim ddlSchoolName As DropDownList = CType(e.Row.FindControl("schoolNameDGV_ddl"), DropDownList)
			ddlSchoolName.DataSource = GetData("SELECT id, schoolname FROM schoolInfo WHERE NOT (schoolName = 'A1 No School Scheduled') AND NOT id='505' ORDER BY schoolName ASC")
			ddlSchoolName.DataTextField = "schoolName"
			ddlSchoolName.DataValueField = "id"
			ddlSchoolName.DataBind()
            Dim lblSchoolName As String = CType(e.Row.FindControl("schoolNameDGV_lbl"), Label).Text

            ddlSchoolName.Items.FindByValue(lblSchoolName).Selected = True
            'Dim businessID As String = ddlSchool.SelectedValue

        End If
    End Sub

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