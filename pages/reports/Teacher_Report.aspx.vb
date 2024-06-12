Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class Teacher_Report
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
    Dim VisitID As New Class_VisitData
    Dim Schools As New Class_SchoolData
    Dim Teachers As New Class_TeacherData
    Dim SH As New Class_SchoolHeader
    Dim Visit As Integer = VisitID.GetVisitID

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If not logged in, redirect to log in page
        If Session("LoggedIn") <> "1" Then
            Response.Redirect("../../default.aspx")
        End If

        If Not (IsPostBack) Then

            'Populate schools DDL
            Schools.LoadSchoolsDDL(schools_ddl)

            'Populating school header
            headerSchoolName_lbl.Text = SH.GetSchoolHeader()

            'Load table data
            loadData()
        End If
    End Sub

    Sub loadData()

        'Clear out table
        teachers_dgv.DataSource = Nothing
        teachers_dgv.DataBind()

        'Load table
        Try
            If schools_ddl.SelectedIndex <> 0 Then
                Teachers.LoadTeacherInfoTable(teachers_dgv, schools_ddl.SelectedValue)
            ElseIf search_tb.Text <> "" Then
                Teachers.LoadTeacherInfoTable(teachers_dgv, "", search_tb.Text)
            Else
                Teachers.LoadTeacherInfoTable(teachers_dgv)
            End If

        Catch
            error_lbl.Text = "Error in loaddata(). Could not fill out teacher information."
            Exit Sub
        End Try

    End Sub



    Private Sub teachers_dgv_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles teachers_dgv.PageIndexChanging
        teachers_dgv.PageIndex = e.NewPageIndex

        If search_tb.Text <> Nothing Then
            loadData()
        End If
    End Sub

    Protected Sub schools_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles schools_ddl.SelectedIndexChanged
        If schools_ddl.SelectedIndex <> 0 Then
            loadData()
        End If

    End Sub

    Protected Sub search_btn_Click(sender As Object, e As EventArgs) Handles search_btn.Click
        If search_tb.Text <> Nothing Then
            loadData()
            schools_ddl.SelectedIndex = 0
        Else
            error_lbl.Text = "Please enter a search keyword and press 'Search'."
        End If
    End Sub

    Protected Sub refresh_btn_Click(sender As Object, e As EventArgs) Handles refresh_btn.Click
        Response.Redirect("teacher_report.aspx")
    End Sub
End Class