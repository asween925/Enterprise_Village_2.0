Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class Visit_Report
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
    Dim SchoolData As New Class_SchoolData
    Dim VisitData As New Class_VisitData
    Dim Visit As Integer = VisitData.GetVisitID

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("LoggedIn") <> "1" Then
            Response.Redirect(".\default.aspx")
        End If

        If Not (IsPostBack) Then

            If Visit <> 0 Then
                visitdate_hf.Value = Visit
            End If

            'populate school DDL
            Try
                SchoolData.LoadSchoolsDDL(schoolNameSearch_ddl)
            Catch
                error_lbl.Text = "Error in page load. Cannot load schools in DDL."
                Exit Sub
            End Try

            'Populating school header
            Dim header As New Class_SchoolHeader
            headerSchoolName_lbl.Text = header.GetSchoolHeader()

            LoadData()

        End If
    End Sub

    Sub LoadData()
        Dim SQLWhereVisitDate As String = Nothing
        Dim SQLWhereSchoolName As String = Nothing
        Dim SQLWhereMonth As String = Nothing
        Dim SQLWhereNot As String = Nothing
        Dim CurrentYear As String = Date.Today.Year
        Dim SelectedMonth As String

        If visitDate_tb.Text <> Nothing Then
            SQLWhereVisitDate = " WHERE v.visitDate='" & visitDate_tb.Text & "' AND NOT v.school=1 ORDER BY v.visitDate DESC"
        End If

        If schoolNameSearch_ddl.SelectedIndex <> 0 Then
            SQLWhereSchoolName = " WHERE s.schoolName='" & schoolNameSearch_ddl.SelectedValue & "' OR s2.schoolName='" & schoolNameSearch_ddl.SelectedValue & "' OR s3.schoolName='" & schoolNameSearch_ddl.SelectedValue & "' OR s4.schoolName='" & schoolNameSearch_ddl.SelectedValue & "' OR s5.schoolName='" & schoolNameSearch_ddl.SelectedValue & "' AND NOT v.school=1 ORDER BY v.visitDate DESC"
        End If

        If month_ddl.SelectedIndex <> 0 Then

            Select Case month_ddl.SelectedValue
                Case "January"
                    SelectedMonth = 1
                Case "February"
                    SelectedMonth = 2
                Case "March"
                    SelectedMonth = 3
                Case "April"
                    SelectedMonth = 4
                Case "May"
                    SelectedMonth = 5
                Case "June"
                    SelectedMonth = 6
                Case "July"
                    SelectedMonth = 7
                Case "August"
                    SelectedMonth = 8
                Case "September"
                    SelectedMonth = 9
                Case "October"
                    SelectedMonth = 10
                Case "November"
                    SelectedMonth = 11
                Case "December"
                    SelectedMonth = 12
            End Select

            SQLWhereMonth = " WHERE DATEPART(MONTH, v.visitDate) = '" & SelectedMonth & "' AND DATEPART(YEAR, v.visitDate) = '" & CurrentYear & "' ORDER BY v.visitDate"

            visit_dgv.PageSize = 31
        End If

        If schoolNameSearch_ddl.SelectedIndex = 0 And visitDate_tb.Text = Nothing And month_ddl.SelectedIndex = 0 Then
            SQLWhereNot = " WHERE NOT v.school=1 ORDER BY v.visitDate DESC"
        End If

        'Get visit info
        Try
            visit_dgv.DataSource = Nothing
            visit_dgv.DataBind()

            visit_dgv.DataSource = VisitData.LoadVisitInfoTable(SQLWhereVisitDate, SQLWhereSchoolName, SQLWhereMonth, SQLWhereNot)
            visit_dgv.DataBind()
        Catch
            error_lbl.Text = "Error in LoadData. Cannot load data."
            Exit Sub
        End Try

    End Sub

    Private Sub visit_dgv_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles visit_dgv.PageIndexChanging
        visit_dgv.PageIndex = e.NewPageIndex
        LoadData()
    End Sub

    Protected Sub refresh_btn_Click(sender As Object, e As EventArgs) Handles refresh_btn.Click
        Response.Redirect("visit_report.aspx")
    End Sub

    Protected Sub visitDate_tb_TextChanged(sender As Object, e As EventArgs) Handles visitDate_tb.TextChanged
        If visitDate_tb.Text <> Nothing Then
            schoolNameSearch_ddl.SelectedIndex = schoolNameSearch_ddl.Items.IndexOf(schoolNameSearch_ddl.Items.FindByValue(0))
            month_ddl.SelectedIndex = month_ddl.Items.IndexOf(month_ddl.Items.FindByValue(0))
            LoadData()
        End If
    End Sub

    Protected Sub schoolNameSearch_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles schoolNameSearch_ddl.SelectedIndexChanged
        If schoolNameSearch_ddl.SelectedIndex <> 0 Then
            visitDate_tb.Text = Nothing
            month_ddl.SelectedIndex = month_ddl.Items.IndexOf(month_ddl.Items.FindByValue(0))
            LoadData()
        End If
    End Sub

    Protected Sub month_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles month_ddl.SelectedIndexChanged
        If month_ddl.SelectedIndex <> 0 Then
            visitDate_tb.Text = Nothing
            schoolNameSearch_ddl.SelectedIndex = schoolNameSearch_ddl.Items.IndexOf(schoolNameSearch_ddl.Items.FindByValue(0))
            LoadData()
        End If
    End Sub

    Protected Sub print_btn_Click(sender As Object, e As EventArgs) Handles print_btn.Click
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "Print", "Print();", True)
    End Sub
End Class