Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Drawing

Public Class Edit_Item
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim BusinessData As New Class_BusinessData
    Dim VisitData As New Class_VisitData
    Dim VisitID As Integer = VisitData.GetVisitID

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("LoggedIn") <> "1" Then
            Response.Redirect(".\default.aspx")
        End If

        If Not (IsPostBack) Then

            If VisitID <> 0 Then
                visitdate_hf.Value = VisitID
            End If

            'Populating school header
            Dim header As New Class_SchoolHeader
            headerSchoolName_lbl.Text = header.GetSchoolHeader()

            'Load filter by DDL with businesses
            BusinessData.LoadBusinessNamesDDL(filterBy_ddl)

            'Add the N/A option to the DDL
            filterBy_ddl.Items.Insert(1, "N/A")

            'Load data
            LoadData()

        End If
    End Sub

    Sub LoadData()
        Dim SearchTerm As String
        Dim SortingBy As String = " ORDER BY "
        Dim FilterBy As String
        Dim SQLStatement As String = "SELECT DISTINCT id, itemName, itemCategory, itemSubCat, currentLocation, onHand, source, businessUsed, comments, merchCode, usedDaily
                                        FROM EV_Inventory"

        'Clear out table
        items_dgv.DataSource = Nothing
        items_dgv.DataBind()

        'Clear error label
        error_lbl.Text = ""

        'Check if search textbox is not blank
        If search_tb.Text <> Nothing Or search_tb.Text <> "" Then
            SearchTerm = " itemName Like '%" & search_tb.Text & "%'"
            SQLStatement &= " WHERE " & SearchTerm
        End If

        'Check if filter DDL is not blank
        If filterBy_ddl.SelectedIndex <> 0 Then
            FilterBy = " businessUsed='" & filterBy_ddl.SelectedValue & "'"

            If search_tb.Text <> Nothing Or search_tb.Text <> "" Then
                SQLStatement &= " AND " & FilterBy
            Else
                SQLStatement &= " WHERE " & FilterBy
            End If

        End If

        'Check if SortingBy is not blank
        If sortBy_ddl.SelectedIndex <> 0 And ascDesc_ddl.SelectedIndex <> 0 Then

            'Check sorting DDLs
            If sortBy_ddl.SelectedValue = "Item Name" Then
                SortingBy &= "itemName "
            ElseIf sortBy_ddl.SelectedValue = "Item Category" Then
                SortingBy &= "itemCategory "
            ElseIf sortBy_ddl.SelectedValue = "Current Location" Then
                SortingBy &= "currentLocation "
            ElseIf sortBy_ddl.SelectedValue = "Current Location in EV" Then
                SortingBy &= "businessUsed "
            ElseIf sortBy_ddl.SelectedValue = "Amount On Hand" Then
                SortingBy &= "onHand "
            ElseIf sortBy_ddl.SelectedValue = "Source" Then
                SortingBy &= "source "
            ElseIf sortBy_ddl.SelectedValue = "Merch Code" Then
                SortingBy &= "merchCode "
            ElseIf sortBy_ddl.SelectedValue = "# Used Daily" Then
                SortingBy &= "usedDaily "
            End If

            If ascDesc_ddl.SelectedValue = "Ascending" Then
                SortingBy &= "ASC"
            ElseIf ascDesc_ddl.SelectedValue = "Descending" Then
                SortingBy &= "DESC"
            End If

            'Add sorting by statement to SQL statement
            SQLStatement &= SortingBy
        End If

        'Load Data
        Try
            con.ConnectionString = connection_string
            con.Open()
            Review_sds.ConnectionString = connection_string
            Review_sds.SelectCommand = SQLStatement
            items_dgv.DataSource = Review_sds
            items_dgv.DataBind()
        Catch
            error_lbl.Text = "Error in loaddata(). Could not get info for items."
            error_lbl.Text = SQLStatement
            Exit Sub
            cmd.Dispose()
            con.Close()
        End Try

        'Highlight row being edited
        For Each row As GridViewRow In items_dgv.Rows
            If row.RowIndex = items_dgv.EditIndex Then
                row.BackColor = ColorTranslator.FromHtml("#ebe534")
                'row.BorderColor = ColorTranslator.FromHtml("#ffffff")
                row.BorderWidth = 2
            End If
        Next

        cmd.Dispose()
        con.Close()

    End Sub

    Sub EnableDisableCurrentLocationInEVDDL()
        'Controls row being edited
        For Each row As GridViewRow In items_dgv.Rows
            If row.RowIndex = items_dgv.EditIndex Then
                Dim currentLocation As DropDownList = TryCast(row.FindControl("currentLocation_ddl"), DropDownList)
                Dim currentLocationInEV As DropDownList = TryCast(row.FindControl("businessUsed_ddl"), DropDownList)

                If currentLocation.SelectedValue = "EV" Then
                    currentLocationInEV.Enabled = True
                    currentLocationInEV.Items.Remove("N/A")
                End If

                If currentLocation.SelectedValue <> "EV" Then
                    currentLocationInEV.Items.Insert(0, "N/A")
                    currentLocationInEV.SelectedIndex = currentLocationInEV.Items.IndexOf(currentLocationInEV.Items.FindByValue(0))
                    currentLocationInEV.Enabled = False
                End If
            End If
        Next
    End Sub

    Sub ItemCatControl()
        'Controls row being edited
        For Each row As GridViewRow In items_dgv.Rows
            If row.RowIndex = items_dgv.EditIndex Then
                'Item Cat Dropdown
                Dim ddlItemCategory As DropDownList = TryCast(row.FindControl("itemCategory_ddl"), DropDownList)
                Dim lblItemCategory As String = TryCast(row.FindControl("itemCategory_lbl"), Label).Text

                'Item SubCat Dropdown
                Dim ddlItemSubCat As DropDownList = TryCast(row.FindControl("itemSubCat_ddl"), DropDownList)
                ddlItemSubCat.DataSource = GetData("SELECT DISTINCT itemSubCat FROM EV_Inventory WHERE itemCategory = '" & ddlItemCategory.SelectedValue & "'")
                ddlItemSubCat.DataTextField = "itemSubCat"
                'ddlSchool.DataValueField = "Businessid"
                ddlItemSubCat.DataBind()
                'Dim lblItemSubCat As String = TryCast(row.FindControl("itemSubCat_lbl"), Label).Text

                'ddlItemSubCat.Items.FindByValue(lblItemSubCat).Selected = True
                'Dim businessID As String = ddlSchool.SelectedValue

            End If
        Next
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

    Private Sub items_dgv_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles items_dgv.RowUpdating
        Dim row As GridViewRow = items_dgv.Rows(0)                           'Code is used to enable the editing prodecure
        Dim ID As Integer = Convert.ToInt32(items_dgv.DataKeys(e.RowIndex).Values(0)) 'Gets id number
        Dim itemName As String = TryCast(items_dgv.Rows(e.RowIndex).FindControl("itemName_tb"), TextBox).Text
        Dim itemCategory As String = TryCast(items_dgv.Rows(e.RowIndex).FindControl("itemCategory_ddl"), DropDownList).SelectedValue.ToString
        Dim itemSubCat As String = TryCast(items_dgv.Rows(e.RowIndex).FindControl("itemSubCat_ddl"), DropDownList).SelectedValue.ToString
        Dim currentLocation As String = TryCast(items_dgv.Rows(e.RowIndex).FindControl("currentLocation_ddl"), DropDownList).SelectedValue.ToString
        Dim businessUsed As String = TryCast(items_dgv.Rows(e.RowIndex).FindControl("businessUsed_ddl"), DropDownList).SelectedValue.ToString
        Dim onHand As String = TryCast(items_dgv.Rows(e.RowIndex).FindControl("onHand_tb"), TextBox).Text
        Dim source As String = TryCast(items_dgv.Rows(e.RowIndex).FindControl("source_ddl"), DropDownList).SelectedValue.ToString
        Dim merchCode As String = TryCast(items_dgv.Rows(e.RowIndex).FindControl("merchCode_ddl"), DropDownList).SelectedValue.ToString
        Dim usedDaily As String = TryCast(items_dgv.Rows(e.RowIndex).FindControl("usedDaily_tb"), TextBox).Text
        Dim comments As String = TryCast(items_dgv.Rows(e.RowIndex).FindControl("comments_tb"), TextBox).Text

        'Check if item name new value is blank or empty
        If itemName = Nothing Or itemName = " " Then
            error_lbl.Text = "Item name cannot be blank. Please enter an item name."
            Exit Sub
        End If

        'Check if last name new value is blank or empty
        If onHand = Nothing Or onHand = " " Then
            error_lbl.Text = "On hand cannot be blank."
            Exit Sub
        End If

        Try
            Using con As New SqlConnection(connection_string)
                Using cmd As New SqlCommand("UPDATE EV_Inventory SET itemName=@itemName, itemCategory=@itemCategory, itemSubCat=@itemSubCat, currentLocation=@currentLocation, businessUsed=@businessUsed, onHand=@onHand, source=@source, merchCode=@merchCode, usedDaily=@usedDaily, comments=@comments WHERE ID=@Id")
                    cmd.Parameters.AddWithValue("@ID", ID)
                    cmd.Parameters.AddWithValue("@itemName", itemName)
                    cmd.Parameters.AddWithValue("@itemCategory", itemCategory)
                    cmd.Parameters.AddWithValue("@itemSubCat", itemSubCat)
                    cmd.Parameters.AddWithValue("@currentLocation", currentLocation)
                    cmd.Parameters.AddWithValue("@businessUsed", businessUsed)
                    cmd.Parameters.AddWithValue("@onHand", onHand)
                    cmd.Parameters.AddWithValue("@source", source)
                    cmd.Parameters.AddWithValue("@merchCode", merchCode)
                    cmd.Parameters.AddWithValue("@usedDaily", usedDaily)
                    cmd.Parameters.AddWithValue("@comments", comments)
                    cmd.Connection = con
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
            items_dgv.EditIndex = -1       'reset the grid after editing
            LoadData()

        Catch ex As Exception
            error_lbl.Text = "Error in rowUpdating. Cannot update row."
            Exit Sub
        End Try

    End Sub

    Private Sub items_dgv_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles items_dgv.RowDeleting
        Dim row As GridViewRow = items_dgv.Rows(0)                           'Code is used to enable the editing prodecure
        Dim ID As Integer = Convert.ToInt32(items_dgv.DataKeys(e.RowIndex).Values(0)) 'Gets id number

        Try
            Using con As New SqlConnection(connection_string)
                Using cmd As New SqlCommand("DELETE FROM EV_Inventory WHERE id=@ID")
                    cmd.Parameters.AddWithValue("@ID", ID)
                    cmd.Connection = con
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
            items_dgv.EditIndex = -1       'reset the grid after editing
            LoadData()

            'Refresh page
            Response.Redirect(".\edit_item.aspx")
        Catch ex As Exception
            error_lbl.Text = "Error in rowDeleting. Cannot delete row."
            Exit Sub
        End Try


    End Sub

    Private Sub items_dgv_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles items_dgv.RowEditing
        items_dgv.EditIndex = e.NewEditIndex
        LoadData()
    End Sub

    Private Sub items_dgv_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles items_dgv.RowCancelingEdit
        items_dgv.EditIndex = -1
        LoadData()
    End Sub

    Private Sub items_dgv_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles items_dgv.PageIndexChanging
        items_dgv.PageIndex = e.NewPageIndex
        LoadData()
    End Sub

    Private Sub items_dgv_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles items_dgv.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then

            'Item Cat Dropdown
            Dim ddlItemCategory As DropDownList = CType(e.Row.FindControl("itemCategory_ddl"), DropDownList)
            ddlItemCategory.DataSource = GetData("SELECT DISTINCT itemCategory FROM EV_Inventory")
            ddlItemCategory.DataTextField = "itemCategory"
            'ddlSchool.DataValueField = "Businessid"
            ddlItemCategory.DataBind()
            Dim lblItemCategory As String = CType(e.Row.FindControl("itemCategory_lbl"), Label).Text

            ddlItemCategory.Items.FindByValue(lblItemCategory).Selected = True
            'Dim businessID As String = ddlSchool.SelectedValue

            'Item SubCat Dropdown
            Dim ddlItemSubCat As DropDownList = CType(e.Row.FindControl("itemSubCat_ddl"), DropDownList)
            ddlItemSubCat.DataSource = GetData("SELECT DISTINCT itemSubCat FROM EV_Inventory WHERE itemCategory = '" & lblItemCategory & "'")
            ddlItemSubCat.DataTextField = "itemSubCat"
            'ddlSchool.DataValueField = "Businessid"
            ddlItemSubCat.DataBind()
            Dim lblItemSubCat As String = CType(e.Row.FindControl("itemSubCat_lbl"), Label).Text

            ddlItemSubCat.Items.FindByValue(lblItemSubCat).Selected = True
            'Dim businessID As String = ddlSchool.SelectedValue

            'Current Location Dropdown
            Dim ddlCurrentLocation As DropDownList = CType(e.Row.FindControl("currentLocation_ddl"), DropDownList)
            ddlCurrentLocation.DataSource = GetData("SELECT DISTINCT currentLocation FROM EV_Inventory")
            ddlCurrentLocation.DataTextField = "currentLocation"
            'ddlSchool.DataValueField = "Businessid"
            ddlCurrentLocation.DataBind()
            Dim lblCurrentLocation As String = CType(e.Row.FindControl("currentLocation_lbl"), Label).Text

            ddlCurrentLocation.Items.FindByValue(lblCurrentLocation).Selected = True
            'Dim businessID As String = ddlSchool.SelectedValue

            'Business Used Dropdown
            Dim ddlBusinessUsed As DropDownList = CType(e.Row.FindControl("businessUsed_ddl"), DropDownList)
            ddlBusinessUsed.DataSource = GetData("SELECT DISTINCT businessName FROM businessInfo ORDER BY businessName")
            ddlBusinessUsed.DataTextField = "businessName"
            'ddlSchool.DataValueField = "Businessid"
            ddlBusinessUsed.DataBind()
            ddlBusinessUsed.Items.Insert(0, "N/A")
            Dim lblBusinessUsed As String = CType(e.Row.FindControl("businessUsed_lbl"), Label).Text

            ddlBusinessUsed.Items.FindByValue(lblBusinessUsed).Selected = True
            'Dim businessID As String = ddlSchool.SelectedValue

            'Source Dropdown
            Dim ddlSource As DropDownList = CType(e.Row.FindControl("source_ddl"), DropDownList)
            ddlSource.DataSource = GetData("SELECT DISTINCT source FROM EV_Inventory")
            ddlSource.DataTextField = "source"
            'ddlSchool.DataValueField = "Businessid"
            ddlSource.DataBind()
            Dim lblSource As String = CType(e.Row.FindControl("source_lbl"), Label).Text

            ddlSource.Items.FindByValue(lblSource).Selected = True
            'Dim businessID As String = ddlSchool.SelectedValue

            'Merch Code Dropdown
            Dim ddlMerchCode As DropDownList = CType(e.Row.FindControl("merchCode_ddl"), DropDownList)
            ddlMerchCode.DataSource = GetData("SELECT DISTINCT merchCode FROM EV_Inventory")
            ddlMerchCode.DataTextField = "merchCode"
            'ddlSchool.DataValueField = "Businessid"
            ddlMerchCode.DataBind()
            Dim lblMerchCode As String = CType(e.Row.FindControl("merchCode_lbl"), Label).Text

            ddlMerchCode.Items.FindByValue(lblMerchCode).Selected = True
            'Dim businessID As String = ddlSchool.SelectedValue
        End If
    End Sub

    Protected Sub currentLocation_ddl_SelectedIndexChanged(sender As Object, e As EventArgs)
        EnableDisableCurrentLocationInEVDDL()
    End Sub

    Protected Sub itemCategory_ddl_SelectedIndexChanged(sender As Object, e As EventArgs)
        ItemCatControl()
    End Sub

    Protected Sub search_btn_Click(sender As Object, e As EventArgs) Handles search_btn.Click
        If search_tb.Text = Nothing Or search_tb.Text = "" Then
            error_lbl.Text = "Please enter a search term."
            Exit Sub
        Else
            LoadData()
        End If
    End Sub

    Protected Sub sortBy_btn_Click(sender As Object, e As EventArgs) Handles sortBy_btn.Click
        'Check if sorted DDL is selected
        If sortBy_ddl.SelectedIndex = 0 Or ascDesc_ddl.SelectedIndex = 0 Then
            error_lbl.Text = "Please select a sorting category and ascending or descending to sort items."
            Exit Sub
        Else
            LoadData()
        End If
    End Sub

    Protected Sub reload_btn_Click(sender As Object, e As EventArgs) Handles reload_btn.Click
        'Refreshes page
        Response.Redirect(".\Edit_item.aspx")
    End Sub

    Protected Sub filterBy_btn_Click(sender As Object, e As EventArgs) Handles filterBy_btn.Click
        If filterBy_ddl.SelectedIndex = 0 Then
            error_lbl.Text = "Please select an option from the Filter By drop down menu before clicking the Filter button."
            Exit Sub
        Else
            LoadData()
        End If
    End Sub
End Class