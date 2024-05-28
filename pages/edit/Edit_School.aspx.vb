Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Drawing

Public Class Edit_School
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
    Dim SchoolData As New Class_SchoolData
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
            Dim sql2 As String = "SELECT schoolname FROM schoolInfo  WHERE NOT schoolName = 'A1 No School Scheduled' AND NOT id='505' ORDER BY schoolName"

            If Visit <> 0 Then
                visitdate_hf.Value = Visit
            End If

            Try
                SchoolData.LoadSchoolsDDL(schoolNameSearch_ddl)
            Catch
                error_lbl.Text = "Error in PageLoad. Cannot load school names in DDL."
                Exit Sub
            End Try

            'Populating school header
            Dim header As New Class_SchoolHeader
            headerSchoolName_lbl.Text = header.GetSchoolHeader()

            'Load data
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
        Dim sql As String = "SELECT id, schoolName, principalFirst, principalLast, phone, fax, schoolHours, schoolType, currentVisitDate, previousVisitDate, futureRequests, futureRequestsEmail, address, city, zip, county, liaisonName 
                                FROM schoolInfo
                                WHERE NOT (schoolName = 'A1 No School Scheduled') AND NOT id='505'
                                ORDER BY schoolName ASC"

        error_lbl.Text = ""
        school_dgv.DataSource = Nothing
        school_dgv.DataBind()

        'Try
        Review_sds.ConnectionString = connection_string
            Review_sds.SelectCommand = sql
            school_dgv.DataSource = Review_sds
            school_dgv.DataBind()

        'Catch
        '    error_lbl.Text = "Error in loaddata()"
        '    cmd.Dispose()
        '    con.Close()
        'End Try

        cmd.Dispose()
        con.Close()

        'Highlight row being edited
        For Each row As GridViewRow In school_dgv.Rows
            If row.RowIndex = school_dgv.EditIndex Then
                row.BackColor = ColorTranslator.FromHtml("#ebe534")
                'row.BorderColor = ColorTranslator.FromHtml("#ffffff")
                row.BorderWidth = 2
            End If
        Next

    End Sub

    Sub loadData2()
        Dim schoolSearch As String = schoolNameSearch_ddl.SelectedValue
        Dim con As New SqlConnection
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        con.ConnectionString = connection_string
        con.Open()
        Dim cmd As New SqlCommand
        Dim sql As String = "SELECT id, schoolName, principalFirst, principalLast, phone, fax, schoolHours, schoolType, currentVisitDate, previousVisitDate, futureRequests, futureRequestsEmail, address, city, zip, county, liaisonName 
                                FROM schoolInfo
                                WHERE schoolName = '" & schoolSearch & "'
                                ORDER BY schoolName ASC"

        error_lbl.Text = ""
        school_dgv.DataSource = Nothing
        school_dgv.DataBind()

        Try
            Review_sds.ConnectionString = connection_string
            Review_sds.SelectCommand = sql
            school_dgv.DataSource = Review_sds
            school_dgv.DataBind()

        Catch
            error_lbl.Text = "Error in loaddata2()"
            cmd.Dispose()
            con.Close()
        End Try

        'Highlight row being edited
        For Each row As GridViewRow In school_dgv.Rows
            If row.RowIndex = school_dgv.EditIndex Then
                row.BackColor = ColorTranslator.FromHtml("#ebe534")
                'row.BorderColor = ColorTranslator.FromHtml("#ffffff")
                row.BorderWidth = 2
            End If
        Next

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
        Dim sql As String = "SELECT id, schoolName, principalFirst, principalLast, phone, fax, schoolHours, schoolType, currentVisitDate, previousVisitDate, futureRequests, futureRequestsEmail, address, city, zip,  county, liaisonName
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
                                ORDER BY schoolName ASC"

        error_lbl.Text = ""
        school_dgv.DataSource = Nothing
        school_dgv.DataBind()

        Try
            Review_sds.ConnectionString = connection_string
            Review_sds.SelectCommand = sql
            school_dgv.DataSource = Review_sds
            school_dgv.DataBind()

        Catch
            error_lbl.Text = "Error in loaddata3()"
            cmd.Dispose()
            con.Close()
        End Try

        'Highlight row being edited
        For Each row As GridViewRow In school_dgv.Rows
            If row.RowIndex = school_dgv.EditIndex Then
                row.BackColor = ColorTranslator.FromHtml("#ebe534")
                'row.BorderColor = ColorTranslator.FromHtml("#ffffff")
                row.BorderWidth = 2
            End If
        Next

        cmd.Dispose()
        con.Close()

    End Sub

    Private Sub school_dgv_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles school_dgv.RowUpdating
        Dim row As GridViewRow = school_dgv.Rows(0)                           'Code is used to enable the editing prodecure
        Dim ID As Integer = Convert.ToInt32(school_dgv.DataKeys(e.RowIndex).Values(0)) 'Gets id number   'Try cast is used to try to convert - gets item from ddl
        Dim principalFirst As String = TryCast(school_dgv.Rows(e.RowIndex).FindControl("principalFirst_tb"), TextBox).Text
        Dim principalLast As String = TryCast(school_dgv.Rows(e.RowIndex).FindControl("principalLast_tb"), TextBox).Text
        Dim phone As String = TryCast(school_dgv.Rows(e.RowIndex).FindControl("phone_tb"), TextBox).Text
        Dim fax As String = TryCast(school_dgv.Rows(e.RowIndex).FindControl("fax_tb"), TextBox).Text
        Dim hours As String = TryCast(school_dgv.Rows(e.RowIndex).FindControl("hours_tb"), TextBox).Text
        Dim schoolType As String = TryCast(school_dgv.Rows(e.RowIndex).FindControl("schoolType_ddl"), DropDownList).SelectedValue.ToString
        Dim futureRequestsEmail As String = TryCast(school_dgv.Rows(e.RowIndex).FindControl("futureRequestsEmail_tb"), TextBox).Text
        Dim futureRequestsNotes As String = TryCast(school_dgv.Rows(e.RowIndex).FindControl("futureRequestsNotes_tb"), TextBox).Text
        Dim address As String = TryCast(school_dgv.Rows(e.RowIndex).FindControl("address_tb"), TextBox).Text
        Dim city As String = TryCast(school_dgv.Rows(e.RowIndex).FindControl("city_tb"), TextBox).Text
        Dim zip As String = TryCast(school_dgv.Rows(e.RowIndex).FindControl("zip_tb"), TextBox).Text
        Dim county As String = TryCast(school_dgv.Rows(e.RowIndex).FindControl("county_tb"), TextBox).Text
        Dim liaisonName As String = TryCast(school_dgv.Rows(e.RowIndex).FindControl("liaisonName_tb"), TextBox).Text

        'If TryCast(row.Cells(x).Controls(0), CheckBox).Checked = True Then                 Used for checkboxes, just need to assign a value after then

        'End If

        Try
            Using con As New SqlConnection(connection_string)
                Using cmd As New SqlCommand("UPDATE schoolInfo SET principalFirst=@principalFirst, principalLast=@principalLast, phone=@phone, fax=@fax, schoolHours=@schoolHours, schoolType=@schoolType, futureRequestsEmail=@future, futureRequests=@futureRequests, address=@address, city=@city, zip=@zip, county=@county, liaisonName=@liaisonName WHERE ID=@Id")
                    cmd.Parameters.AddWithValue("@ID", ID)
                    cmd.Parameters.AddWithValue("@principalFirst", principalFirst)
                    cmd.Parameters.AddWithValue("@principalLast", principalLast)
                    cmd.Parameters.AddWithValue("@phone", phone)
                    cmd.Parameters.AddWithValue("@fax", fax)
                    cmd.Parameters.AddWithValue("@schoolHours", hours)
                    cmd.Parameters.AddWithValue("@schoolType", schoolType)
                    cmd.Parameters.AddWithValue("@future", futureRequestsEmail)
                    cmd.Parameters.AddWithValue("@futureRequests", futureRequestsNotes)
                    cmd.Parameters.AddWithValue("@address", address)
                    cmd.Parameters.AddWithValue("@city", city)
                    cmd.Parameters.AddWithValue("@zip", zip)
                    cmd.Parameters.AddWithValue("@county", county)
                    cmd.Parameters.AddWithValue("@liaisonName", liaisonName)
                    cmd.Connection = con
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
            school_dgv.EditIndex = -1 'reset the grid after editing
            If schoolNameSearch_ddl.SelectedIndex <> 0 Then
                loadData2()
            ElseIf search_tb.Text <> Nothing Then
                loadData3()
            Else
                loadData()
            End If
        Catch ex As Exception
            error_lbl.Text = "Cannot update row."
            Exit Sub
        End Try

    End Sub

    'Private Sub school_dgv_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles school_dgv.RowDeleting
    '    Dim row As GridViewRow = school_dgv.Rows(0)                           'Code is used to enable the editing prodecure
    '    Dim ID As Integer = Convert.ToInt32(school_dgv.DataKeys(e.RowIndex).Values(0)) 'Gets id number

    '    Try
    '        Using con As New SqlConnection(connection_string)
    '            Using cmd As New SqlCommand("DELETE FROM schoolInfo WHERE id=@ID")
    '                cmd.Parameters.AddWithValue("@ID", ID)
    '                cmd.Connection = con
    '                con.Open()
    '                cmd.ExecuteNonQuery()
    '                con.Close()
    '            End Using
    '        End Using
    '        school_dgv.EditIndex = -1       'reset the grid after editing
    '        loadData()

    '        'Refresh page
    '        Response.Redirect(".\edit_school.aspx")
    '    Catch ex As Exception
    '        error_lbl.Text = "Error in rowDeleting. Cannot delete row."
    '        Exit Sub
    '    End Try

    'End Sub
    Private Sub school_dgv_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles school_dgv.RowEditing
        school_dgv.EditIndex = e.NewEditIndex

        If schoolNameSearch_ddl.SelectedIndex <> 0 Then
            loadData2()
        ElseIf search_tb.Text <> Nothing Then
            loadData3()
        Else
            loadData()
        End If

    End Sub

    Private Sub school_dgv_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles school_dgv.RowCancelingEdit
        school_dgv.EditIndex = -1

        If schoolNameSearch_ddl.SelectedIndex <> 0 Then
            loadData2()
        ElseIf search_tb.Text <> Nothing Then
            loadData3()
        Else
            loadData()
        End If

    End Sub

    Private Sub school_dgv_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles school_dgv.PageIndexChanging
        school_dgv.PageIndex = e.NewPageIndex

        If schoolNameSearch_ddl.SelectedIndex <> 0 Then
            loadData2()
        ElseIf search_tb.Text <> Nothing Then
            loadData3()
        Else
            loadData()
        End If

    End Sub

    Private Sub school_dgv_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles school_dgv.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then

            'School Dropdown
            'Dim ddlSchool As DropDownList = CType(e.Row.FindControl("schoolName_ddl"), DropDownList)
            'ddlSchool.DataSource = GetData("SELECT schoolname FROM schoolInfo WHERE NOT (schoolName = 'A1 No School Scheduled') AND NOT id='505' ORDER BY schoolName ASC")
            'ddlSchool.DataTextField = "schoolName"
            ''ddlSchool.DataValueField = "Businessid"
            'ddlSchool.DataBind()
            'Dim lblSchool As String = CType(e.Row.FindControl("schoolName_lbl"), Label).Text

            'ddlSchool.Items.FindByValue(lblSchool).Selected = True
            'Dim businessID As String = ddlSchool.SelectedValue

            'School Type Dropdown
            Dim ddlType As DropDownList = CType(e.Row.FindControl("schoolType_ddl"), DropDownList)
            ddlType.DataSource = GetData("SELECT DISTINCT schoolType FROM schoolInfo")
            ddlType.DataTextField = "schoolType"
            ddlType.DataBind()
            Dim lblType As String = CType(e.Row.FindControl("schoolType_lbl"), Label).Text

            ddlType.Items.FindByValue(lblType).Selected = True

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

    Protected Sub search_btn_Click(sender As Object, e As EventArgs) Handles search_btn.Click
        If search_tb.Text <> Nothing Then
            loadData3()
            schoolNameSearch_ddl.SelectedIndex = 0
        Else
            error_lbl.Text = "Please enter a search keyword and press 'Search'."
        End If
    End Sub

    Protected Sub refresh_btn_Click(sender As Object, e As EventArgs) Handles refresh_btn.Click
        Response.Redirect("edit_school.aspx")
    End Sub

    Protected Sub schoolNameSearch_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles schoolNameSearch_ddl.SelectedIndexChanged
        If schoolNameSearch_ddl.SelectedIndex <> 0 Then
            loadData2()
            search_tb.Text = ""
        End If

    End Sub
End Class