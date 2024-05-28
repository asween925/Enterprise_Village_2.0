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
    Dim Visit As Integer = VisitID.GetVisitID

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("LoggedIn") <> "1" Then
            Response.Redirect("../../default.aspx")
        End If

        If Not (IsPostBack) Then
            Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
            Dim con As New SqlConnection
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim sql As String = "SELECT FORMAT(visitDate,'MM/dd/yyyy') as visitDate FROM visitinfo ORDER BY visitDate DESC"
            Dim sql2 As String = "SELECT schoolname FROM schoolInfo  WHERE NOT id='505' AND NOT schoolName='A1 No School Scheduled' ORDER BY schoolName"

            If Visit <> 0 Then
                visitdate_hf.Value = Visit
            End If

            'Populate schools DDL
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.CommandText = sql2
                cmd.Connection = con
                dr = cmd.ExecuteReader

                While dr.Read()
                    schools_ddl.Items.Add(dr(0).ToString)
                End While

                schools_ddl.Items.Insert(0, "")

                cmd.Dispose()
                con.Close()
            Catch
                error_lbl.Text = "Error in Page_Load(). Could not populate schools_ddl."
                Exit Sub
            Finally
                cmd.Dispose()
                con.Close()
            End Try

            'Populating school header
            Dim header As New Class_SchoolHeader
            headerSchoolName_lbl.Text = header.GetSchoolHeader()

            loadData()
        End If
    End Sub

    Sub loadData()
        'Dim visitDate As Date = visitDate_ddl.SelectedValue
        Dim con As New SqlConnection
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        con.ConnectionString = connection_string
        con.Open()
        Dim cmd As New SqlCommand

        teachers_dgv.DataSource = Nothing
        teachers_dgv.DataBind()

        Try
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "SELECT DISTINCT id, isContact, studentCount, password, county, schoolName, futureRequestsEmail, firstName, lastName FROM teacherInfo"


            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)
            teachers_dgv.DataSource = dt
            teachers_dgv.DataBind()

        Catch
            error_lbl.Text = "Error in loaddata(). Could not fill out teacher information."
            cmd.Dispose()
            con.Close()
        End Try

        cmd.Dispose()
        con.Close()

    End Sub

    Sub loadData2()
        'Dim visitDate As Date = visitDate_ddl.SelectedValue
        Dim con As New SqlConnection
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        con.ConnectionString = connection_string
        con.Open()
        Dim cmd As New SqlCommand

        teachers_dgv.DataSource = Nothing
        teachers_dgv.DataBind()

        Try
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "SELECT DISTINCT id, isContact, studentCount, password, county, schoolName, futureRequestsEmail, firstName, lastName FROM teacherInfo WHERE schoolName = '" & schools_ddl.SelectedValue & "'"


            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)
            teachers_dgv.DataSource = dt
            teachers_dgv.DataBind()

        Catch
            error_lbl.Text = "Error in loaddata(). Could not fill out teacher information."
            cmd.Dispose()
            con.Close()
        End Try

        cmd.Dispose()
        con.Close()

    End Sub

    Sub loadData3()
        'Dim visitDate As Date = visitDate_ddl.SelectedValue
        Dim con As New SqlConnection
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        con.ConnectionString = connection_string
        con.Open()
        Dim cmd As New SqlCommand

        teachers_dgv.DataSource = Nothing
        teachers_dgv.DataBind()

        Try
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "SELECT DISTINCT id, isContact, studentCount, password, county, schoolName, futureRequestsEmail, firstName, lastName FROM teacherInfo 
                                WHERE schoolName Like '%" & search_tb.Text & "%'
                                 Or county Like '%" & search_tb.Text & "%'
                                 Or futureRequestsEmail Like '%" & search_tb.Text & "%'
                                 Or firstName Like '%" & search_tb.Text & "%'
                                 Or lastName Like '%" & search_tb.Text & "%'
                                 ORDER BY lastName"


            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)
            teachers_dgv.DataSource = dt
            teachers_dgv.DataBind()

        Catch
            error_lbl.Text = "Error in loaddata(). Could not fill out teacher information."
            cmd.Dispose()
            con.Close()
        End Try

        cmd.Dispose()
        con.Close()

    End Sub

    Private Sub teachers_dgv_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles teachers_dgv.PageIndexChanging
        teachers_dgv.PageIndex = e.NewPageIndex
        If search_tb.Text <> Nothing Then
            loadData3()
        ElseIf schools_ddl.SelectedIndex <> 0 Then
            loadData2()
        Else
            loadData()
        End If
    End Sub

    Protected Sub schools_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles schools_ddl.SelectedIndexChanged
        If schools_ddl.SelectedIndex <> 0 Then
            loadData2()
            search_tb.Text = ""
        End If

    End Sub

    Protected Sub search_btn_Click(sender As Object, e As EventArgs) Handles search_btn.Click
        If search_tb.Text <> Nothing Then
            loadData3()
            schools_ddl.SelectedIndex = 0
        Else
            error_lbl.Text = "Please enter a search keyword and press 'Search'."
        End If
    End Sub

    Protected Sub refresh_btn_Click(sender As Object, e As EventArgs) Handles refresh_btn.Click
        Response.Redirect("teacher_report.aspx")
    End Sub
End Class