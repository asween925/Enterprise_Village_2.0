Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class Add_Remove_Amount
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
    Dim SQLCommands As New Class_SQLCommands
    Dim VisitID As New Class_VisitData
    Dim Visit As Integer = VisitID.GetVisitID

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("LoggedIn") <> "1" Then
            Response.Redirect("../../default.aspx")
        End If

        If Not IsPostBack Then
            Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
            Dim con As New SqlConnection
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim sql2 As String = "SELECT itemName FROM EV_Inventory ORDER BY itemName"
            Dim username As String = Session("username")
            Dim job As String

            If Visit <> 0 Then
                visitdate_hf.Value = Visit
            End If

            'Populate items DDL
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.CommandText = sql2
                cmd.Connection = con
                dr = cmd.ExecuteReader

                While dr.Read()
                    items_ddl.Items.Add(dr(0).ToString)
                End While

                items_ddl.Items.Insert(0, "")

                cmd.Dispose()
                con.Close()
            Catch
                error_lbl.Text = "Error in Page_Load(). Could not populate items_ddl."
                Exit Sub
            Finally
                cmd.Dispose()
                con.Close()
            End Try

            'Populating school header
            Dim header As New Class_SchoolHeader
            headerSchoolName_lbl.Text = header.GetSchoolHeader()

        End If
    End Sub

    Sub LoadData()
        Dim con As New SqlConnection
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim SQLStatementItem As String = "SELECT id, itemName, itemCategory, itemSubCat, currentLocation, source, onHand, businessUsed, comments, merchCode, usedDaily
                                        FROM EV_Inventory"
        Dim SQLStatementTimestamp As String = "SELECT id, itemID, itemName, dateReceived, amount, lastEdited, lastEditedBy, notes
                                                FROM EV_InventoryTimesheet1"
        Dim SQLWhereItem As String = ""
        Dim SQLWhereTimestamp As String = ""

        'Clear error label
        error_lbl.Text = ""

        'Check if loading from search bar or DDL
        If search_tb.Text <> Nothing Then
            SQLWhereItem = " WHERE itemName LIKE '%" & search_tb.Text & "%'"
            SQLStatementItem &= SQLWhereItem

            SQLWhereTimestamp = " WHERE itemName LIKE '%" & search_tb.Text & "%' ORDER BY id DESC"
            SQLStatementTimestamp &= SQLWhereTimestamp
        ElseIf items_ddl.SelectedIndex <> 0 Then
            SQLWhereItem = " WHERE itemName = '" & items_ddl.SelectedValue & "'"
            SQLStatementItem &= SQLWhereItem

            SQLWhereTimestamp = " WHERE itemName = '" & items_ddl.SelectedValue & "' ORDER BY id DESC"
            SQLStatementTimestamp &= SQLWhereTimestamp
        End If

        'Load item data
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd.CommandText = SQLStatementItem
            cmd.Connection = con
            dr = cmd.ExecuteReader

            While dr.Read()
                itemName_lbl.Text = dr("itemName").ToString
                itemCategory_lbl.Text = dr("itemCategory").ToString
                itemSubCat_lbl.Text = dr("itemSubCat").ToString
                currentLocation_lbl.Text = dr("currentLocation").ToString
                source_lbl.Text = dr("source").ToString
                onHand_lbl.Text = dr("onHand").ToString
                businessUsed_lbl.Text = dr("businessUsed").ToString
                comments_tb.Text = dr("comments").ToString
                merchCode_lbl.Text = dr("merchCode").ToString
                usedDaily_lbl.Text = dr("usedDaily").ToString
                itemID_hf.Value = dr("id").ToString
            End While

            cmd.Dispose()
            con.Close()

        Catch
            error_lbl.Text = "Error in LoadDataFromDDL(). Cannot get data from item."
            Exit Sub
        End Try

        'Load timestamp data
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd.Connection = con
            cmd.CommandText = SQLStatementTimestamp

            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)
            items_dgv.DataSource = dt
            items_dgv.DataBind()

            cmd.Dispose()
            con.Close()

        Catch
            error_lbl.Text = "Error in LoadDataFromDDL(). Cannot get load data from item for timestamp."
            Exit Sub
        End Try

        'Check if loading from UpdateOnHandAmount()
        If date_tb.Text <> Nothing Or date_tb.Text <> "" Or amount_tb.Text <> Nothing Or amount_tb.Text <> "" Then
            previousOnHand_lbl.Text = onHand_lbl.Text - amount_tb.Text
            date_tb.Text = ""
            amount_tb.Text = ""
            comments_tb.Text = ""
        End If

        cmd.Dispose()
        con.Close()

    End Sub

    Sub UpdateOnHandAmount()
        Dim con As New SqlConnection
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim cmd As New SqlCommand
        Dim itemID As String = itemID_hf.Value
        Dim username As String = Session("username")

        'Check if item is selected
        If items_ddl.SelectedIndex = 0 Then
            error_lbl.Text = "Please select an item."
            Exit Sub
        End If

        'Check if date or amount is empty
        If date_tb.Text = Nothing Or date_tb.Text = "" Or amount_tb.Text = Nothing Or amount_tb.Text = "" Then
            error_lbl.Text = "Please enter a valid date and valid amount."
            Exit Sub
        End If

        'Check if notes contains an invalid character
        If notes_tb.Text.Contains("'") Then
            error_lbl.Text = "Please remove the apostraphe from the notes textbox."
            Exit Sub
        End If

        'Update onHand field with number from amount_tb into the inventory table
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "UPDATE EV_Inventory SET onHand = onHand + '" & amount_tb.Text & "' WHERE id = '" & itemID & "'"
            cmd.ExecuteNonQuery()
            con.Close()

            'Insert values into timesheet
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "INSERT INTO EV_InventoryTimesheet1 (itemID, itemName, dateReceived, amount, lastEdited, lastEditedBy, notes)
                                VALUES ('" & itemID & "', '" & itemName_lbl.Text & "', '" & date_tb.Text & "', '" & amount_tb.Text & "', '" & DateTime.Now & "', '" & username & "', '" & notes_tb.Text & "')"

            cmd.ExecuteNonQuery()
            con.Close()

            LoadData()

        Catch
            error_lbl.Text = "Error in UpdateOnHandAmount(). Could not update on hand data."
            Exit Sub
        End Try

        cmd.Dispose()
        con.Close()
    End Sub

    Private Sub Transations_dgv_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles items_dgv.RowUpdating
        Dim row As GridViewRow = items_dgv.Rows(e.RowIndex)                        'Code is used to enable the editing prodecure
        Dim ID As Integer = Convert.ToInt32(items_dgv.DataKeys(e.RowIndex).Values(0)) 'Code is used to enable the editing procedure
        Dim dateReceived = TryCast(items_dgv.Rows(e.RowIndex).FindControl("dateReceiveddgv_tb"), TextBox).Text
        Dim amount = TryCast(items_dgv.Rows(e.RowIndex).FindControl("amountdgv_tb"), TextBox).Text
        Dim notes = TryCast(items_dgv.Rows(e.RowIndex).FindControl("notesdgv_tb"), TextBox).Text
        Dim username As String = Session("username")

        Using con As New SqlConnection(connection_string)
            Using cmd As New SqlCommand("UPDATE EV_InventoryTimesheet1 SET dateReceived=@dateReceived, notes=@notes, lastEdited='" & DateTime.Now & "', lastEditedBy='" & username & "' WHERE id = '" & ID & "'")
                cmd.Parameters.Add("@dateReceived", SqlDbType.Date).Value = dateReceived
                cmd.Parameters.Add("@notes", SqlDbType.VarChar).Value = notes
                cmd.Connection = con
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using

        items_dgv.EditIndex = -1
        LoadData()
    End Sub

    Private Sub items_dgv_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles items_dgv.RowEditing
        items_dgv.EditIndex = e.NewEditIndex
        LoadData()
    End Sub

    Private Sub items_dgv_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles items_dgv.RowCancelingEdit
        items_dgv.EditIndex = -1
        LoadData()
    End Sub

    Protected Sub items_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles items_ddl.SelectedIndexChanged
        If items_ddl.SelectedIndex <> 0 Then
            search_tb.Text = ""
            LoadData()
        End If

    End Sub

    Protected Sub enter_btn_Click(sender As Object, e As EventArgs) Handles enter_btn.Click
        UpdateOnHandAmount()
    End Sub

    Protected Sub search_btn_Click(sender As Object, e As EventArgs) Handles search_btn.Click
        items_ddl.SelectedIndex = items_ddl.Items.IndexOf(items_ddl.Items.FindByValue(""))
        LoadData()
    End Sub
End Class