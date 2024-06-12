Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Web.Http.Tracing

Public Class Edit_Teacher
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim SchoolData As New Class_SchoolData
    Dim VisitID As New Class_VisitData
    Dim Teachers As New Class_TeacherData
    Dim Visit As Integer = VisitID.GetVisitID

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("LoggedIn") <> "1" Then
            Response.Redirect("../../default.aspx")
        End If

        If Not (IsPostBack) Then

            If Visit <> 0 Then
                visitdate_hf.Value = Visit
            End If

            'Populate school name ddl
            SchoolData.LoadSchoolsDDL(schoolName_ddl)

            'Populating school header
            Dim header As New Class_SchoolHeader
            headerSchoolName_lbl.Text = header.GetSchoolHeader()

            'Load data
            LoadData()

        End If
    End Sub

    Sub LoadData()
        Dim SearchTerm As String
        Dim SchoolName As String
        Dim SchoolID As String
        Dim SQLStatement As String = "SELECT DISTINCT t.id, t.isContact, t.studentCount, t.password, t.county, t.schoolID, t.futureRequestsEmail, t.firstName, t.lastName
                                        FROM teacherInfo t JOIN schoolInfo s ON s.id = t.schoolID"

        'Clear teacher table
        teachers_dgv.DataSource = Nothing
        teachers_dgv.DataBind()

        'Clear error label
        error_lbl.Text = ""



        'Check if school name is selected
        If schoolName_ddl.SelectedIndex <> 0 Then

            'Clear search textbox
            search_tb.Text = ""

            SchoolName = schoolName_ddl.SelectedValue
            'SchoolID = SchoolData.GetSchoolID(SchoolName)
            SQLStatement &= " WHERE s.schoolName='" & SchoolName & "'"
        End If

        'Check if search field is entered
        If search_tb.Text <> Nothing Then

            'Clear search textbox
            schoolName_ddl.SelectedIndex = schoolName_ddl.Items.IndexOf(schoolName_ddl.Items.FindByValue(0))

            SearchTerm = search_tb.Text
            SQLStatement &= " Where s.schoolName Like '%" & search_tb.Text & "%' 
                                Or t.firstName Like '%" & search_tb.Text & "%' 
                                Or t.lastName Like '%" & search_tb.Text & "%'
                                Or t.futureRequestsEmail Like '%" & search_tb.Text & "%'
                                ORDER BY t.firstName ASC"
        End If

        'Load data
        Try
            con.ConnectionString = connection_string
            con.Open()
            Review_sds.ConnectionString = connection_string
            Review_sds.SelectCommand = SQLStatement
            teachers_dgv.DataSource = Review_sds
            teachers_dgv.DataBind()

        Catch
            error_lbl.Text = "Error in LoadData(). Could not get info for teachers."
            cmd.Dispose()
            con.Close()
        End Try

        'Highlight row being edited
        For Each row As GridViewRow In teachers_dgv.Rows
            If row.RowIndex = teachers_dgv.EditIndex Then
                row.BackColor = ColorTranslator.FromHtml("#ebe534")
                'row.BorderColor = ColorTranslator.FromHtml("#ffffff")
                row.BorderWidth = 2
            End If
        Next

        cmd.Dispose()
        con.Close()

    End Sub
    Protected Sub schoolName_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles schoolName_ddl.SelectedIndexChanged
        If schoolName_ddl.SelectedIndex <> 0 Then
            LoadData()
        End If
    End Sub

    Private Sub teachers_dgv_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles teachers_dgv.RowUpdating
        Dim row As GridViewRow = teachers_dgv.Rows(0)                           'Code is used to enable the editing prodecure
        Dim ID As Integer = Convert.ToInt32(teachers_dgv.DataKeys(e.RowIndex).Values(0)) 'Gets id number
        Dim studentCount As String = TryCast(teachers_dgv.Rows(e.RowIndex).FindControl("studentCount_tb"), TextBox).Text
        Dim password As String = TryCast(teachers_dgv.Rows(e.RowIndex).FindControl("password_tb"), TextBox).Text
        Dim county As String = TryCast(teachers_dgv.Rows(e.RowIndex).FindControl("county_tb"), TextBox).Text
        Dim schoolID As String = TryCast(teachers_dgv.Rows(e.RowIndex).FindControl("schoolName_ddl"), DropDownList).SelectedValue.ToString   'Try cast is used to try to convert - gets item from ddl
        Dim firstName As String = TryCast(teachers_dgv.Rows(e.RowIndex).FindControl("firstName_tb"), TextBox).Text
        Dim lastName As String = TryCast(teachers_dgv.Rows(e.RowIndex).FindControl("lastName_tb"), TextBox).Text
        Dim futureRequestsEmail As String = TryCast(teachers_dgv.Rows(e.RowIndex).FindControl("futureRequestsEmail_tb"), TextBox).Text
        Dim isContact As Boolean = TryCast(teachers_dgv.Rows(e.RowIndex).FindControl("contact_chk"), CheckBox).Checked

        'Check if emails new value is blank or empty
        If futureRequestsEmail = Nothing Or futureRequestsEmail = " " Then
            error_lbl.Text = "Teacher Email cannot be blank. Please enter a valid email address."
            Exit Sub
        End If

        'Checks if email is an address
        If Not (futureRequestsEmail.Contains("@")) And Not (futureRequestsEmail.Contains(".")) Then
            'Not an email. Show message
            error_lbl.Text = "Not a valid email address."
            Exit Sub
        End If

        'Check if last name new value is blank or empty
        If lastName = Nothing Or lastName = " " Then
            error_lbl.Text = "Last Name cannot be blank."
            Exit Sub
        End If

        Try
            Using con As New SqlConnection(connection_string)
                Using cmd As New SqlCommand("UPDATE teacherInfo SET isContact=@isContact, studentCount=@studentCount, password=@password, county=@county, schoolID=@schoolID, firstName=@firstName, lastName=@lastName, futureRequestsEmail=@future WHERE ID=@Id")
                    cmd.Parameters.AddWithValue("@ID", ID)
                    cmd.Parameters.AddWithValue("@studentCount", studentCount)
                    cmd.Parameters.AddWithValue("@password", password)
                    cmd.Parameters.AddWithValue("@county", county)
                    cmd.Parameters.AddWithValue("@schoolID", schoolID)
                    cmd.Parameters.AddWithValue("@firstName", firstName)
                    cmd.Parameters.AddWithValue("@lastName", lastName)
                    cmd.Parameters.AddWithValue("@future", futureRequestsEmail)
                    cmd.Parameters.AddWithValue("@isContact", isContact)
                    cmd.Connection = con
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
            teachers_dgv.EditIndex = -1       'reset the grid after editing
            LoadData()
        Catch ex As Exception
            error_lbl.Text = "Error in rowUpdating. Cannot update row."
            Exit Sub
        End Try

    End Sub

    Private Sub teachers_dgv_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles teachers_dgv.RowDeleting
        Dim row As GridViewRow = teachers_dgv.Rows(0)                           'Code is used to enable the editing prodecure
        Dim ID As Integer = Convert.ToInt32(teachers_dgv.DataKeys(e.RowIndex).Values(0)) 'Gets id number

        Try
            Using con As New SqlConnection(connection_string)
                Using cmd As New SqlCommand("DELETE FROM teacherInfo WHERE id=@ID")
                    cmd.Parameters.AddWithValue("@ID", ID)
                    cmd.Connection = con
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
            teachers_dgv.EditIndex = -1       'reset the grid after editing
            LoadData()

            'Refresh page
            Response.Redirect(".\edit_teacher.aspx")
        Catch ex As Exception
            error_lbl.Text = "Error in rowDeleting. Cannot delete row."
            Exit Sub
        End Try
    End Sub
    Private Sub teachers_dgv_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles teachers_dgv.RowEditing
        teachers_dgv.EditIndex = e.NewEditIndex
        loadData()
    End Sub

    Private Sub teachers_dgv_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles teachers_dgv.RowCancelingEdit
        teachers_dgv.EditIndex = -1
        loadData()
    End Sub

    Private Sub teachers_dgv_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles teachers_dgv.PageIndexChanging
        teachers_dgv.PageIndex = e.NewPageIndex
        loadData()
    End Sub

    Private Sub teachers_dgv_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles teachers_dgv.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then

            'School Dropdown
            Dim ddlSchool As DropDownList = CType(e.Row.FindControl("schoolName_ddl"), DropDownList)
            ddlSchool.DataSource = GetData("SELECT id, schoolname FROM schoolInfo WHERE NOT id='505' AND NOT schoolName='A1 No School Scheduled' ORDER BY schoolName")
            ddlSchool.DataTextField = "schoolName"
            ddlSchool.DataValueField = "id"
            ddlSchool.DataBind()
            Dim lblSchool As String = CType(e.Row.FindControl("schoolName_lbl"), Label).Text

            ddlSchool.Items.FindByValue(lblSchool).Selected = True
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

    Private Function ConfirmDelete() As String
        Dim confirm As String
        Dim reponse As Boolean = MsgBox("Are you sure you want to delete this row? Type 'DELETE' in the box below and click OK to confirm.", vbYesNoCancel, "Delete Confirmation")

        If reponse = vbYes Then
            confirm = "DELETE"
        Else
            confirm = "NO"
        End If

        Return confirm
    End Function

    Protected Sub search_btn_Click(sender As Object, e As EventArgs) Handles search_btn.Click
        LoadData()
    End Sub

    Protected Sub refresh_btn_Click(sender As Object, e As EventArgs) Handles refresh_btn.Click
        Response.Redirect("edit_teacher.aspx")
    End Sub
End Class