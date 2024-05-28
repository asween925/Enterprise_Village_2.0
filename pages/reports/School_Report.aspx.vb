Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class School_Report
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
            Dim sql As String = "SELECT schoolname FROM schoolInfo WHERE NOT schoolName = 'A1 No School Scheduled' AND NOT id='505' ORDER BY schoolName"

            If Visit <> 0 Then
                visitdate_hf.Value = Visit
            End If

            'Populate date DDL
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.CommandText = sql
                cmd.Connection = con
                dr = cmd.ExecuteReader

                While dr.Read()
                    schoolNameSearch_ddl.Items.Add(dr(0).ToString)
                End While
                schoolNameSearch_ddl.Items.Insert(0, "")
                cmd.Dispose()
                con.Close()
            Catch
                error_lbl.Text = "Error in school name DDL SQL statement."
                Exit Sub
            Finally
                cmd.Dispose()
                con.Close()
            End Try

            loadData()

            'Populating school header
            Dim header As New Class_SchoolHeader
            headerSchoolName_lbl.Text = header.GetSchoolHeader()

        End If
    End Sub

    Sub loadData()

        Dim con As New SqlConnection
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        con.ConnectionString = connection_string
        con.Open()
        Dim cmd As New SqlCommand

        Try

            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "SELECT id, schoolName, principalFirst, principalLast, phone, fax, schoolHours, schoolType, currentVisitDate, previousVisitDate, futureRequests, futureRequestsEmail, address, city, zip, county, liaisonName 
                                FROM schoolInfo
                                WHERE NOT (schoolName = 'A1 No School Scheduled') AND NOT (schoolName = ' ')
                                ORDER BY schoolName ASC"


            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)
            schools_dgv.DataSource = dt
            schools_dgv.DataBind()

        Catch
            error_lbl.Text = "Operation failed."
            cmd.Dispose()
            con.Close()
        End Try

        cmd.Dispose()
        con.Close()

    End Sub

    Sub loadData2()
        Dim con As New SqlConnection
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        con.ConnectionString = connection_string
        con.Open()
        Dim cmd As New SqlCommand

        Try

            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "SELECT id, schoolName, principalFirst, principalLast, phone, fax, schoolHours, schoolType, currentVisitDate, previousVisitDate, futureRequests, futureRequestsEmail, address, city, zip, county, liaisonName
                                FROM schoolInfo
                                WHERE schoolName = '" & schoolNameSearch_ddl.SelectedValue & "' AND NOT (schoolName = 'A1 No School Scheduled') AND NOT (schoolName = ' ')
                                ORDER BY schoolName ASC"


            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)
            schools_dgv.DataSource = dt
            schools_dgv.DataBind()

        Catch
            error_lbl.Text = "Error in loaddata2."
            cmd.Dispose()
            con.Close()
        End Try

        cmd.Dispose()
        con.Close()

    End Sub

    Sub loadData3()
        'Dim schoolSearch As String = schoolNameSearch_ddl.SelectedValue
        Dim con As New SqlConnection
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        con.ConnectionString = connection_string
        con.Open()
        Dim cmd As New SqlCommand
        Dim sql As String = "SELECT id, schoolName, principalFirst, principalLast, phone, fax, schoolHours, schoolType, currentVisitDate, previousVisitDate, futureRequests, futureRequestsEmail, address, city, zip, county, liaisonName
        From schoolInfo
                                Where schoolName Like '%" & search_tb.Text & "%' 
                                Or principalFirst Like '%" & search_tb.Text & "%' 
                                Or principalLast Like '%" & search_tb.Text & "%'
                                Or phone Like '%" & search_tb.Text & "%'
                                Or schoolHours Like '%" & search_tb.Text & "%'
                                Or schoolType Like '%" & search_tb.Text & "%'
                                Or futureRequestsEmail Like '%" & search_tb.Text & "%'
                                Or futureRequests Like '%" & search_tb.Text & "%'
                                Or county Like '%" & search_tb.Text & "%'
                                Or liaisonName Like '%" & search_tb.Text & "%'
                                ORDER BY schoolName ASC"

        error_lbl.Text = ""
        schools_dgv.DataSource = Nothing
        schools_dgv.DataBind()

        Try
            Review_sds.ConnectionString = connection_string
            Review_sds.SelectCommand = sql
            schools_dgv.DataSource = Review_sds
            schools_dgv.DataBind()

        Catch
            error_lbl.Text = "Error in loaddata3()"
            cmd.Dispose()
            con.Close()
        End Try

        cmd.Dispose()
        con.Close()

    End Sub

    Private Sub schools_dgv_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles schools_dgv.PageIndexChanging
        schools_dgv.PageIndex = e.NewPageIndex
        If search_tb.Text <> Nothing Then
            loadData3()
        ElseIf schoolNameSearch_ddl.SelectedIndex <> 0 Then
            loadData2()
        Else
            loadData()
        End If

    End Sub

    Protected Sub schoolNameSearch_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles schoolNameSearch_ddl.SelectedIndexChanged
        If schoolNameSearch_ddl.SelectedIndex <> 0 Then
            loadData2()
            search_tb.Text = ""
        End If
    End Sub

    Protected Sub search_btn_Click(sender As Object, e As EventArgs) Handles search_btn.Click
        If search_tb.Text <> Nothing Then
            loadData3()
            schoolNameSearch_ddl.SelectedIndex = 0
        Else
            error_lbl.Text = "Please enter a search keyword and press 'Search'."
        End If
    End Sub

    Protected Sub refresh_btn_Click(sender As Object, e As EventArgs) Handles refresh_btn.Click
        Response.Redirect("school_report.aspx")
    End Sub

End Class