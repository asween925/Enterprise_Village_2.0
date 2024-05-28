Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class View_All_Items
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
    Dim VisitData As New Class_VisitData
    Dim VisitID As Integer = VisitData.GetVisitID

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("LoggedIn") <> "1" Then
            Response.Redirect("../../default.aspx")
        End If

        If Not IsPostBack Then

            'Assign current visit ID to hidden value
            If VisitID <> 0 Then
                visitdate_hf.Value = VisitID
            End If

            'Populating school header
            Dim header As New Class_SchoolHeader
            headerSchoolName_lbl.Text = header.GetSchoolHeader()

            'Load data
            LoadData()

        End If
    End Sub

    Sub LoadData()
        Dim con As New SqlConnection
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim cmd As New SqlCommand

        'Load timestamp data
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "SELECT id, itemName, itemCategory, itemSubCat, currentLocation, source, onHand, businessUsed, comments, merchCode, usedDaily
                                FROM EV_Inventory
                                ORDER BY id ASC"

            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)
            items_dgv.DataSource = dt
            items_dgv.DataBind()

            cmd.Dispose()
            con.Close()

        Catch
            error_lbl.Text = "Error in LoadData(). Cannot get load data."
            Exit Sub
        End Try

        cmd.Dispose()
        con.Close()
    End Sub

    Sub Sorting()
        Dim con As New SqlConnection
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim cmd As New SqlCommand
        Dim sqlBase As String = "SELECT DISTINCT id, itemName, itemCategory, itemSubCat, currentLocation, onHand, source, businessUsed, comments, merchCode, usedDaily
                                FROM EV_Inventory
                                ORDER BY "

        Dim sqlNew As String = ""
        Dim sqlNew2 As String = ""

        items_dgv.DataSource = Nothing
        items_dgv.DataBind()

        error_lbl.Text = ""

        'Check if sorted DDL is selected
        If sortBy_ddl.SelectedIndex = 0 Or ascDesc_ddl.SelectedIndex = 0 Then
            error_lbl.Text = "Please select a sorting category and ascending or descending to sort items."
            Exit Sub
        End If

        'Check sorting DDLs
        If sortBy_ddl.SelectedValue = "Recently Added" Then
            sqlNew = sqlBase & "id "
        ElseIf sortBy_ddl.SelectedValue = "Item Name" Then
            sqlNew = sqlBase & "itemName "
        ElseIf sortBy_ddl.SelectedValue = "Item Category" Then
            sqlNew = sqlBase & "itemCategory "
        ElseIf sortBy_ddl.SelectedValue = "Current Location" Then
            sqlNew = sqlBase & "currentLocation "
        ElseIf sortBy_ddl.SelectedValue = "Current Location in EV" Then
            sqlNew = sqlBase & "businessUsed "
        ElseIf sortBy_ddl.SelectedValue = "Amount On Hand" Then
            sqlNew = sqlBase & "onHand "
        ElseIf sortBy_ddl.SelectedValue = "Source" Then
            sqlNew = sqlBase & "source "
        ElseIf sortBy_ddl.SelectedValue = "Merch Code" Then
            sqlNew = sqlBase & "merchCode "
        ElseIf sortBy_ddl.SelectedValue = "# Used Daily" Then
            sqlNew = sqlBase & "usedDaily "
        End If

        If ascDesc_ddl.SelectedValue = "Ascending" Then
            sqlNew2 = sqlNew & "ASC"
        ElseIf ascDesc_ddl.SelectedValue = "Descending" Then
            sqlNew2 = sqlNew & "DESC"
        End If

        'Execute sqlNew2 query
        Try
            con.ConnectionString = connection_string
            con.Open()
            Review_sds.ConnectionString = connection_string
            Review_sds.SelectCommand = sqlNew2
            items_dgv.DataSource = Review_sds
            items_dgv.DataBind()

        Catch
            error_lbl.Text = "Error in Sorting(). Could not get info for items."
            cmd.Dispose()
            con.Close()
        End Try

        cmd.Dispose()
        con.Close()
    End Sub

    Sub ItemNameSearch()
        Dim con As New SqlConnection
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim cmd As New SqlCommand
        Dim sql As String = "SELECT DISTINCT id, itemName, itemCategory, itemSubCat, currentLocation, onHand, source, businessUsed, comments, merchCode, usedDaily
                                FROM EV_Inventory
                                WHERE itemName Like '%" & search_tb.Text & "%'"

        items_dgv.DataSource = Nothing
        items_dgv.DataBind()

        error_lbl.Text = ""

        Try
            con.ConnectionString = connection_string
            con.Open()
            Review_sds.ConnectionString = connection_string
            Review_sds.SelectCommand = sql
            items_dgv.DataSource = Review_sds
            items_dgv.DataBind()

        Catch
            error_lbl.Text = "Error in Search(). Could not get info for items."
            cmd.Dispose()
            con.Close()
        End Try

        cmd.Dispose()
        con.Close()
    End Sub

    Private Sub items_dgv_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles items_dgv.PageIndexChanging
        items_dgv.PageIndex = e.NewPageIndex
        If sortBy_ddl.SelectedIndex <> 0 And ascDesc_ddl.SelectedIndex <> 0 Then
            Sorting()
        Else
            LoadData()
        End If
    End Sub

    Protected Sub sortBy_btn_Click(sender As Object, e As EventArgs) Handles sortBy_btn.Click
        Sorting()
    End Sub

    Protected Sub search_btn_Click(sender As Object, e As EventArgs) Handles search_btn.Click
        ItemNameSearch()
    End Sub
End Class