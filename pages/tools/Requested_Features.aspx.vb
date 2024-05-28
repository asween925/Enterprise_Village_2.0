Imports System.IO
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Drawing

Public Class Requested_Features
	Inherits System.Web.UI.Page
	Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
	Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
	Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
	Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
	Dim con As New SqlConnection
	Dim cmd As New SqlCommand
	Dim dr As SqlDataReader
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
    Dim SQLCommandsData As New Class_SQLCommands
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

            'Load community table data
            LoadData()

        End If

    End Sub

    Sub LoadData()
        Dim SQLStatement As String = "SELECT * FROM community"

        'Load community notes
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd.Connection = con
            cmd.CommandText = SQLStatement

            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)
            community_dgv.DataSource = dt
            community_dgv.DataBind()

            cmd.Dispose()
            con.Close()
        Catch
            error_lbl.Text = "Error in LoadData(). Could not load community data into table."
            Exit Sub
        End Try

        'Highlight row being edited
        For Each row As GridViewRow In community_dgv.Rows
            If row.RowIndex = community_dgv.EditIndex Then
                row.BackColor = ColorTranslator.FromHtml("#ebe534")
                'row.BorderColor = ColorTranslator.FromHtml("#ffffff")
                row.BorderWidth = 2
            End If
        Next

    End Sub

    Sub Submit()
        Dim Type As String
        Dim Note As String
        Dim PageName As String
        Dim Urgency As String
        Dim Username As String = Session("username")
        Dim Timestamp As String = DateTime.Now()

        'Check for empty fields
        If type_ddl.SelectedIndex = 0 Or note_tb.Text = Nothing Or pageName_tb.Text = Nothing Then
            error_lbl.Text = "Please enter all fields in before submitting an issue or request."
            Exit Sub
        End If

        'Assign fields to variables
        Type = type_ddl.SelectedValue
        Note = note_tb.Text
        PageName = pageName_tb.Text
        Urgency = urgency_ddl.SelectedValue

        'Insert data into DB
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "INSERT INTO community (type, communityNote, pageName, urgency, username, timestamp)
                                VALUES ('" & Type & "', '" & Note & "', '" & PageName & "', '" & Urgency & "', '" & Username & "', '" & Timestamp & "')"

            cmd.ExecuteNonQuery()
            cmd.Dispose()
            con.Close()
        Catch
            error_lbl.Text = "Error in Submit(). Could not add the note."
            Exit Sub
        End Try

        'If sucessful, display message, clear out fields.
        error_lbl.Text = "Submission sucessful! Openning email..."
        ScriptManager.RegisterStartupScript(Me.Page, Me.Page.[GetType](), "OpenEmail", "javascript:window.location.href='mailto:sweeneya@pcsb.org ?subject=Requested Feature and Bug Reports: New Post Created&body=I have submitted a new request/bug report in EV 2.0.", True)

    End Sub

    Private Sub community_dgv_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles community_dgv.RowUpdating
        Dim row As GridViewRow = community_dgv.Rows(0)                           'Code is used to enable the editing prodecure
        Dim ID As Integer = Convert.ToInt32(community_dgv.DataKeys(e.RowIndex).Values(0)) 'Gets id number

        Dim Type As String = TryCast(community_dgv.Rows(e.RowIndex).FindControl("typeDGV_ddl"), DropDownList).SelectedValue.ToString
        Dim CommunityNote As String = TryCast(community_dgv.Rows(e.RowIndex).FindControl("noteDGV_tb"), TextBox).Text
        Dim PageName As String = TryCast(community_dgv.Rows(e.RowIndex).FindControl("pageNameDGV_tb"), TextBox).Text
        Dim Urgency As String = TryCast(community_dgv.Rows(e.RowIndex).FindControl("urgencyLevelDGV_ddl"), DropDownList).SelectedValue.ToString
        Dim Username As String = TryCast(community_dgv.Rows(e.RowIndex).FindControl("usernameDGV_tb"), TextBox).Text
        Dim Resolved As String = TryCast(community_dgv.Rows(e.RowIndex).FindControl("resolved_chk"), CheckBox).Checked
        'Dim Timestamp As String = TryCast(community_dgv.Rows(e.RowIndex).FindControl("timestampDGV_lbl"), Label).Text

        'Check if user is the same username as the edited row
        If Username <> Session("username") And Session("username") <> "sweeneya" Then
            error_lbl.Text = "Cannot edit someone else's note."
            Exit Sub
        End If

        'Update note
        Try
            Using con As New SqlConnection(connection_string)
                Using cmd As New SqlCommand("UPDATE community SET type=@type, communityNote=@communityNote, pageName=@pageName, urgency=@urgency, resolved=@resolved WHERE ID=@Id")
                    cmd.Parameters.AddWithValue("@ID", ID)
                    cmd.Parameters.AddWithValue("@type", Type)
                    cmd.Parameters.AddWithValue("@communityNote", CommunityNote)
                    cmd.Parameters.AddWithValue("@pageName", PageName)
                    cmd.Parameters.AddWithValue("@urgency", Urgency)
                    cmd.Parameters.AddWithValue("@resolved", Resolved)
                    'cmd.Parameters.AddWithValue("@username", Username)
                    'cmd.Parameters.AddWithValue("@timestamp", Timestamp)
                    cmd.Connection = con
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
            community_dgv.EditIndex = -1       'reset the grid after editing
            LoadData()

        Catch ex As Exception
            error_lbl.Text = "Error in rowUpdating. Cannot update row."
            Exit Sub
        End Try

    End Sub

    Private Sub community_dgv_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles community_dgv.RowDeleting
        Dim row As GridViewRow = community_dgv.Rows(0)                           'Code is used to enable the editing prodecure
        Dim ID As Integer = Convert.ToInt32(community_dgv.DataKeys(e.RowIndex).Values(0)) 'Gets id number

        Dim Username As String = TryCast(community_dgv.Rows(e.RowIndex).FindControl("usernameDGV_tb"), TextBox).Text

        'Check if user is the same username as the edited row
        If Username <> Session("username") And Session("username") <> "sweeneya" Then
            error_lbl.Text = "Cannot delete someone else's note."
            Exit Sub
        End If

        'Delete note
        Try
            Using con As New SqlConnection(connection_string)
                Using cmd As New SqlCommand("DELETE FROM community WHERE id=@ID")
                    cmd.Parameters.AddWithValue("@ID", ID)
                    cmd.Connection = con
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
            community_dgv.EditIndex = -1       'reset the grid after editing

            LoadData()

        Catch ex As Exception
            error_lbl.Text = "Error in rowDeleting. Cannot delete row."
            Exit Sub
        End Try

    End Sub

    Private Sub community_dgv_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles community_dgv.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then

            'Type Dropdown
            Dim ddlType As DropDownList = CType(e.Row.FindControl("typeDGV_ddl"), DropDownList)
            ddlType.DataSource = GetData("SELECT DISTINCT type FROM community")
            ddlType.DataTextField = "type"
            'ddlSchool.DataValueField = "Businessid"
            ddlType.DataBind()
            Dim lblType As String = CType(e.Row.FindControl("typeDGV_lbl"), Label).Text

            ddlType.Items.FindByValue(lblType).Selected = True
            'Dim businessID As String = ddlSchool.SelectedValue

            'Urgency Dropdown
            Dim ddlUrgency As DropDownList = CType(e.Row.FindControl("urgencyLevelDGV_ddl"), DropDownList)
            ddlUrgency.DataSource = GetData("SELECT DISTINCT urgency FROM community")
            ddlUrgency.DataTextField = "urgency"
            ddlUrgency.DataBind()
            Dim lblUrgency As String = CType(e.Row.FindControl("urgencyLevelDGV_lbl"), Label).Text

            ddlUrgency.Items.FindByValue(lblUrgency).Selected = True
            'Dim businessID As String = ddlBusiness.SelectedValue
        End If
    End Sub

    Private Sub community_dgv_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles community_dgv.RowEditing
        Dim UserJob As String = SQLCommandsData.GetUserJob(Session("username"))

        community_dgv.EditIndex = e.NewEditIndex

        'Check if tech tech is logged in
        If UserJob <> "Technology Technician" Then
            'community_dgv.Rows(e.GetType("resolved_chk"), CheckBox).
        End If


        LoadData()
    End Sub

    Private Sub community_dgv_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles community_dgv.RowCancelingEdit
        community_dgv.EditIndex = -1
        LoadData()
    End Sub

    Private Sub community_dgv_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles community_dgv.PageIndexChanging
        community_dgv.PageIndex = e.NewPageIndex
        LoadData()
    End Sub

    Protected Sub createNew_btn_Click(sender As Object, e As EventArgs) Handles createNew_btn.Click
		If createNew_div.Visible = False Then
			createNew_div.Visible = True
			viewPosts_div.Visible = False
		End If
	End Sub

	Protected Sub viewPosts_btn_Click(sender As Object, e As EventArgs) Handles viewPosts_btn.Click
		If viewPosts_div.Visible = False Then
			viewPosts_div.Visible = True
			createNew_div.Visible = False
		End If
	End Sub

    Protected Sub submit_btn_Click(sender As Object, e As EventArgs) Handles submit_btn.Click
        Submit()
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