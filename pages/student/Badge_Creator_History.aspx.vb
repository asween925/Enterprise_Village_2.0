Imports System.Data.SqlClient
Imports System.IO
Imports System.Data
Imports System.Configuration
Imports System.Drawing

Public Class Badge_Creator_History
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim DBConnection As New DatabaseConection
    Dim dr As SqlDataReader
    Dim Badges As New Class_BadgesData
    Dim Visit As New Class_VisitData
    Dim Students As New Class_StudentData
    Dim VisitID As Integer = Visit.GetVisitID
    Dim path As String = "X:\inetpub\wwwroot\EV\media\Badge Photos\"
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Check if visit ID is not 0
        If VisitID = 0 Then
            error_lbl.Text = "No visit date, please go to 'Database Creator' on the 'Tools / Reports' page and create a new school visit date."
            Exit Sub
        End If

        If Not (IsPostBack) Then

            'Load student names into DDL
            LoadStudentNamesDDL()

            'Load badges into the table
            LoadBadgesIntoGridview()

        End If

    End Sub

    Sub LoadBadgesIntoGridview()
        Dim SQLWhereSearch As String = ""
        Dim SQLOrderBy As String = " ORDER BY b.id DESC"

        'Clear out gridview
        existingBadges_dgv.DataSource = Nothing
        existingBadges_dgv.DataBind()

        'Check if searching from DDL
        If studentSearch_ddl.SelectedIndex <> 0 Then
            Dim StudentAccountNum() As String = studentSearch_ddl.SelectedValue.Split(".")
            SQLWhereSearch = " AND (s.accountNumber = '" & StudentAccountNum(0) & "')"
        End If

        'Load badges into table
        Try
            existingBadges_dgv.DataSource = Badges.LoadExistingBadgesTable(VisitID, SQLWhereSearch, SQLOrderBy)
            existingBadges_dgv.DataBind()
        Catch
            error_lbl.Text = "Error. Cannot load badges into table. Please find an Enterprise Village teacher for help!"
            Exit Sub
        End Try

    End Sub

    Sub LoadStudentNamesDDL()

        'Clear out StudentNamesDDL
        studentSearch_ddl.Items.Clear()

        'Load student names into the search DDL
        Try
            Badges.LoadExistingBadgesNamesDDL(VisitID, studentSearch_ddl)
        Catch ex As Exception
            error_lbl.Text = "Error in LoadStudentNamesDDL(). Cannot find employeeName. Find an Enterprise Village teacher."
            Exit Sub
        End Try

    End Sub

    Sub Reset()
        Response.Redirect("badge_creator_history.aspx")
    End Sub

    Sub Delete()
        Dim ID As Integer = deletingID_hf.Value
        Dim filePath As String = Server.MapPath("~/media/Badge Photos/")

        'Check if 'Delete' is entered into the textbox
        If deleteConfirm_tb.Text = "Delete" Then
            Try
                Using con As New SqlConnection(connection_string)
                    Using cmd As New SqlCommand("DELETE FROM badges WHERE id=@ID")
                        cmd.Parameters.AddWithValue("@ID", ID)
                        cmd.Connection = con
                        con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End Using
                End Using

                'Delete photo from badges photo folder
                My.Computer.FileSystem.DeleteFile(filePath & "badge-" + deletingName_hf.Value + ".png")

                existingBadges_dgv.EditIndex = -1       'reset the grid after editing
                LoadBadgesIntoGridview()

                'Refresh page
                Response.Redirect(".\badge_creator_history.aspx")

            Catch ex As Exception
                error_lbl.Text = "Error in rowDeleting. Cannot delete row."
                Exit Sub
            End Try
        Else
            error_lbl.Text = "Please enter 'Delete' in the field to delete the selected badge."
            Exit Sub
        End If

    End Sub

    Private Sub existingBadges_dgv_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles existingBadges_dgv.RowDeleting
        Dim ID As Integer = Convert.ToInt32(existingBadges_dgv.DataKeys(e.RowIndex).Values(0)) 'Gets id number
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        'Make delete div visible
        delete_div.Visible = True

        'Store selected ID into hidden field
        deletingID_hf.Value = ID

        'Get name of student that's being deleted
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "SELECT studentID FROM badges WHERE id='" & ID & "'"
            dr = cmd.ExecuteReader

            While dr.Read()
                deletingName_hf.Value = dr("studentID").ToString
            End While

            cmd.Dispose()
            con.Close()

        Catch ex As Exception
            error_lbl.Text = "Could not find student name being deleted."
            Exit Sub
        End Try

        cmd.Dispose()
        con.Close()

        'Assign student name to label
        deletingName_lbl.Text = Students.GetStudentNameFromID(deletingName_hf.Value).ToString()

        'Highlight row being edited
        For Each row As GridViewRow In existingBadges_dgv.Rows
            If row.RowIndex = existingBadges_dgv.EditIndex Then
                row.BackColor = ColorTranslator.FromHtml("#ebe534")
                'row.BorderColor = ColorTranslator.FromHtml("#ffffff")
                row.BorderWidth = 2
            End If
        Next

    End Sub

    Private Sub existingBadges_dgv_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles existingBadges_dgv.PageIndexChanging
        existingBadges_dgv.PageIndex = e.NewPageIndex
        LoadBadgesIntoGridview()
    End Sub

    Protected Sub reset_btn_Click(sender As Object, e As EventArgs) Handles reset_btn.Click
        Reset()
    End Sub

    Protected Sub deleteConfirm_btn_Click(sender As Object, e As EventArgs) Handles deleteConfirm_btn.Click
        Delete()
    End Sub

    Protected Sub cancel_btn_Click(sender As Object, e As EventArgs) Handles cancel_btn.Click
        Response.Redirect("badge_creator_history.aspx")
    End Sub

    Protected Sub search_btn_Click(sender As Object, e As EventArgs) Handles search_btn.Click

        'If student search DDL is not 0, then load badges from search DDL
        If studentSearch_ddl.SelectedIndex <> 0 Then
            LoadBadgesIntoGridview()
        End If

    End Sub
End Class