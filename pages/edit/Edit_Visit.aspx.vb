Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Net.Mail
Public Class Edit_Visit
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
    Dim DBConnection As New DatabaseConection
    Dim dr As SqlDataReader
    Dim Schools As New Class_SchoolData
    Dim Visits As New Class_VisitData
    Dim Students As New Class_StudentData
    Dim SH As New Class_SchoolHeader
    Dim VisitID As Integer = Visits.GetVisitID

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Checks if the user is logged in and if not it redirects to the login page
        If Session("LoggedIn") <> "1" Then
            Response.Redirect("../../default.aspx")
        End If

        If Not (IsPostBack) Then

            'Populating school header
            headerSchoolName_lbl.Text = SH.GetSchoolHeader()

        End If
    End Sub

    Sub LoadData()
        Dim VisitDate As String = date_tb.Text
        Dim con As New SqlConnection
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim cmd As New SqlCommand
        Dim sql As String = "SELECT v.id, s.id as 'schoolid1', s2.id as 'schoolid2', s3.id as 'schoolid3', s4.id as 'schoolid4', s5.id as 'schoolid5', s.schoolName as 'schoolname1', s2.schoolName as 'schoolname2', s3.schoolName as 'schoolname3', s4.schoolName as 'schoolname4', s5.schoolName as 'schoolname5', v.vTrainingTime, v.vMinCount, v.vMaxCount, FORMAT(v.replyBy, 'yyyy-MM-dd') as replyBy, FORMAT(v.visitDate, 'yyyy-MM-dd') as visitDate, v.studentCount, v.visitTime
                                  FROM visitInfo v 
                                  LEFT JOIN schoolInfo s ON s.ID = v.school
								  LEFT JOIN schoolInfo s2 ON s2.ID = v.school2
								  LEFT JOIN schoolInfo s3 ON s3.ID = v.school3
								  LEFT JOIN schoolInfo s4 ON s4.ID = v.school4
								  LEFT JOIN schoolInfo s5 ON s5.ID = v.school5
                                  WHERE v.visitDate = '" & date_tb.Text & "'"

        'Clear out visit table
        visit_dgv.DataSource = Nothing
        visit_dgv.DataBind()

        'Clear error label
        error_lbl.Text = ""

        'Load edit visit table
        Try
            visit_dgv.DataSource = Visits.LoadEditVisitTable(VisitDate)
            visit_dgv.DataBind()

        Catch
            error_lbl.Text = "Error in LoadData(). Could not fill table."
            Exit Sub
        End Try

        'Highlight row being edited
        For Each row As GridViewRow In visit_dgv.Rows
            If row.RowIndex = visit_dgv.EditIndex Then
                row.BackColor = ColorTranslator.FromHtml("#ebe534")
                'row.BorderColor = ColorTranslator.FromHtml("#ffffff")
                row.BorderWidth = 2
            End If
        Next

    End Sub

    Protected Sub date_tb_TextChanged(sender As Object, e As EventArgs) Handles date_tb.TextChanged
        If date_tb.Text <> Nothing Then
            gridview_div.Visible = True
            LoadData()
        End If
    End Sub

    Private Sub visit_dgv_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles visit_dgv.RowUpdating
        Dim row As GridViewRow = visit_dgv.Rows(0) 'Code is used to enable the editing prodecure
        Dim ID As Integer = Convert.ToInt32(visit_dgv.DataKeys(e.RowIndex).Values(0)) 'Gets id number
        Dim visitDate As String = TryCast(visit_dgv.Rows(e.RowIndex).FindControl("visitDate_tb"), TextBox).Text
        Dim visitTime As String = TryCast(visit_dgv.Rows(e.RowIndex).FindControl("visitTime_tb"), TextBox).Text
        Dim school1 As String = TryCast(visit_dgv.Rows(e.RowIndex).FindControl("school1_ddl"), DropDownList).SelectedValue.ToString  'Try cast is used to try to convert - gets item from ddl
        Dim school2 As String = TryCast(visit_dgv.Rows(e.RowIndex).FindControl("school2_ddl"), DropDownList).SelectedValue.ToString
        Dim school3 As String = TryCast(visit_dgv.Rows(e.RowIndex).FindControl("school3_ddl"), DropDownList).SelectedValue.ToString
        Dim school4 As String = TryCast(visit_dgv.Rows(e.RowIndex).FindControl("school4_ddl"), DropDownList).SelectedValue.ToString
        Dim school5 As String = TryCast(visit_dgv.Rows(e.RowIndex).FindControl("school5_ddl"), DropDownList).SelectedValue.ToString
        Dim vTrainingTime As String = TryCast(visit_dgv.Rows(e.RowIndex).FindControl("vTrainingTime_tb"), TextBox).Text
        Dim vMinCount As String = TryCast(visit_dgv.Rows(e.RowIndex).FindControl("vMinCount_tb"), TextBox).Text
        Dim vMaxCount As String = TryCast(visit_dgv.Rows(e.RowIndex).FindControl("vMaxCount_tb"), TextBox).Text
        Dim replyBy As String = TryCast(visit_dgv.Rows(e.RowIndex).FindControl("replyBy_tb"), TextBox).Text
        Dim studentCount As String = TryCast(visit_dgv.Rows(e.RowIndex).FindControl("studentCount_tb"), TextBox).Text
        Dim CurrentVisitDate As String = FormatDateTime(Schools.LoadSchoolInfoFromSchool(Schools.GetSchoolNameFromID(school1), "currentVisitDate"), DateFormat.ShortDate)
        Dim School1Name As String = Schools.GetSchoolNameFromID(school1)
        Dim School2Name As String = Schools.GetSchoolNameFromID(school2)
        Dim School3Name As String = Schools.GetSchoolNameFromID(school3)
        Dim School4Name As String = Schools.GetSchoolNameFromID(school4)
        Dim School5Name As String = Schools.GetSchoolNameFromID(school5)

        'If updating the visit date, check to make sure that there is already not a visit date scheduled for that day
        If visitDate <> date_tb.Text And Visits.GetVisitIDFromDate(visitDate) <> Nothing Then
            error_lbl.Text = "Cannot move visit to that date as there is already a visit created for that date." & visitDate & " " & date_tb.Text
            Exit Sub
        End If

        'Update visitInfo table
        Try
            Using con As New SqlConnection(connection_string)
                Using cmd As New SqlCommand("UPDATE visitInfo SET school=@school, vTrainingTime=@vTrainingTime, vMinCount=@vMinCount, vMaxCount=@vMaxCount, replyBy=@replyBy, visitDate=@visitDate, studentCount=@studentCount, school2=@school2, school3=@school3, school4=@school4, visitTime=@visitTime, school5=@school5 WHERE ID=@ID")
                    cmd.Parameters.AddWithValue("@ID", ID)
                    cmd.Parameters.AddWithValue("@school", school1)
                    cmd.Parameters.AddWithValue("@vTrainingTime", vTrainingTime)
                    cmd.Parameters.AddWithValue("@vMinCount", vMinCount)
                    cmd.Parameters.AddWithValue("@vMaxCount", vMaxCount)
                    cmd.Parameters.AddWithValue("@replyBy", replyBy)
                    cmd.Parameters.AddWithValue("@visitDate", visitDate)
                    cmd.Parameters.AddWithValue("@studentCount", studentCount)
                    cmd.Parameters.AddWithValue("@school2", school2)
                    cmd.Parameters.AddWithValue("@school3", school3)
                    cmd.Parameters.AddWithValue("@school4", school4)
                    cmd.Parameters.AddWithValue("@visitTime", visitTime)
                    cmd.Parameters.AddWithValue("@school5", school5)

                    cmd.Connection = con
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            error_lbl.Text = "Error in updating visitInfo."
            Exit Sub
        End Try

        'Update business visit info with the new school ids (if any)
        Try
            Visits.UpdateBusinessVisitInfo(school1, school2, school3, school4, school5, ID)
        Catch ex As Exception
            error_lbl.Text = "Error in Updating(). Cannot update business visit info."
            Exit Sub
        End Try

        'Update studentInfo with new school ID
        Try
            Students.UpdateSchoolID(ID, school1)
        Catch ex As Exception
            error_lbl.Text = "Error in Updating(). Cannot update studentInfo."
            Exit Sub
        End Try

        'Move update currentVisitDate in school info if visitdate has change
        If CurrentVisitDate <> visitDate Then
            Try
                Visits.MoveVisitDate(School1Name, School2Name, School3Name, School4Name, School5Name, visitDate)
            Catch ex As Exception
                error_lbl.Text = "Error in Updating(). Cannot move visit date."
                Exit Sub
            End Try
        End If

        'Message to let staff know if visit date has changed, move articles if needed
        error_lbl.Text = "If you have changed the visit date, please go to Upload / Move Articles to move the newspaper articles to the updated visit date."

        'Reset gridview and loaddata
        visit_dgv.EditIndex = -1
        LoadData()
    End Sub

    Private Sub visit_dgv_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles visit_dgv.RowEditing
        visit_dgv.EditIndex = e.NewEditIndex
        LoadData()
    End Sub

    Private Sub visit_dgv_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles visit_dgv.RowCancelingEdit
        visit_dgv.EditIndex = -1
        LoadData()
    End Sub

    Private Sub visit_dgv_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles visit_dgv.PageIndexChanging
        visit_dgv.PageIndex = e.NewPageIndex
        LoadData()
    End Sub

    Private Sub visit_dgv_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles visit_dgv.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then

            'School Dropdown
            Dim ddlSchool1 As DropDownList = CType(e.Row.FindControl("school1_ddl"), DropDownList)

            ddlSchool1.DataSource = GetData("SELECT id, schoolName FROM schoolInfo ORDER BY schoolName")
            ddlSchool1.DataTextField = "schoolName"
            ddlSchool1.DataValueField = "id"
            ddlSchool1.DataBind()
            Dim lblSchool1 As String = CType(e.Row.FindControl("schoolName1_lbl"), Label).Text
            If lblSchool1 = Nothing Then
                ddlSchool1.Items.FindByValue("A1 No School Scheduled").Selected = True
            Else
                ddlSchool1.Items.FindByValue(lblSchool1).Selected = True
            End If

            'ddlSchool1.Items.Insert(0, "")
            Dim school1ID As String = ddlSchool1.SelectedValue

            'School Dropdown
            Dim ddlSchool2 As DropDownList = CType(e.Row.FindControl("school2_ddl"), DropDownList)

            ddlSchool2.DataSource = GetData("SELECT id, schoolName FROM schoolInfo ORDER BY schoolName")
            ddlSchool2.DataTextField = "schoolName"
            ddlSchool2.DataValueField = "id"
            ddlSchool2.DataBind()
            Dim lblSchool2 As String = CType(e.Row.FindControl("schoolName2_lbl"), Label).Text
            If lblSchool2 = Nothing Then
                ddlSchool2.Items.FindByValue("A1 No School Scheduled").Selected = True
            Else
                ddlSchool2.Items.FindByValue(lblSchool2).Selected = True
            End If
            'ddlSchool2.Items.Insert(0, "")
            Dim school2ID As String = ddlSchool2.SelectedValue

            'School Dropdown
            Dim ddSchool3 As DropDownList = CType(e.Row.FindControl("school3_ddl"), DropDownList)

            ddSchool3.DataSource = GetData("SELECT id, schoolName FROM schoolInfo ORDER BY schoolName")
            ddSchool3.DataTextField = "schoolName"
            ddSchool3.DataValueField = "id"
            ddSchool3.DataBind()
            Dim lblSchool3 As String = CType(e.Row.FindControl("schoolName3_lbl"), Label).Text
            If lblSchool3 = Nothing Then
                ddSchool3.Items.FindByValue("A1 No School Scheduled").Selected = True
            Else
                ddSchool3.Items.FindByValue(lblSchool3).Selected = True
            End If
            'ddSchool3.Items.Insert(0, "")
            Dim school3ID As String = ddSchool3.SelectedValue

            'School Dropdown
            Dim ddSchool4 As DropDownList = CType(e.Row.FindControl("school4_ddl"), DropDownList)

            ddSchool4.DataSource = GetData("SELECT id, schoolName FROM schoolInfo ORDER BY schoolName")
            ddSchool4.DataTextField = "schoolName"
            ddSchool4.DataValueField = "id"
            ddSchool4.DataBind()
            Dim lblSchool4 As String = CType(e.Row.FindControl("schoolName4_lbl"), Label).Text
            If lblSchool4 = Nothing Then
                ddSchool4.Items.FindByValue("A1 No School Scheduled").Selected = True
            Else
                ddSchool4.Items.FindByValue(lblSchool4).Selected = True
            End If
            'ddSchool4.Items.Insert(0, "")
            Dim school4ID As String = ddSchool4.SelectedValue

            'School Dropdown
            Dim ddSchool5 As DropDownList = CType(e.Row.FindControl("school5_ddl"), DropDownList)

            ddSchool5.DataSource = GetData("SELECT id, schoolName FROM schoolInfo ORDER BY schoolName")
            ddSchool5.DataTextField = "schoolName"
            ddSchool5.DataValueField = "id"
            ddSchool5.DataBind()
            Dim lblSchool5 As String = CType(e.Row.FindControl("schoolName5_lbl"), Label).Text
            If lblSchool5 = Nothing Then
                ddSchool5.Items.FindByValue("A1 No School Scheduled").Selected = True
            Else
                ddSchool5.Items.FindByValue(lblSchool5).Selected = True
            End If
            'ddSchool5.Items.Insert(0, "")
            Dim school5ID As String = ddSchool5.SelectedValue

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