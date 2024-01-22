Imports System.IO
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Drawing

Public Class Kit_Inventory
	Inherits System.Web.UI.Page
	Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
	Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
	Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
	Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
	Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
	Dim VisitID As New Class_VisitData
	Dim Visit As Integer = VisitID.GetVisitID

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
		Dim con As New SqlConnection
		Dim cmd As New SqlCommand

		If Session("LoggedIn") <> "1" Then
			Response.Redirect(".\default.aspx")
		End If

		If Not (IsPostBack) Then

			'Assign current visit ID to hidden field
			If Visit <> 0 Then
				currentVisitID_hf.Value = Visit
			End If

			'Populating school header
			Dim header As New Class_SchoolHeader
			headerSchoolName_lbl.Text = header.GetSchoolHeader()

			'Populate schools DDL
			Dim load As New Class_SchoolData
			load.LoadSchoolsDDL(schoolName_ddl)
		End If
	End Sub

	Sub LoadTable()
		Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
		Dim con As New SqlConnection
		Dim cmd As New SqlCommand
		Dim columnSort As String = "id"
		Dim orderSort As String = "ASC"
		Dim searchTerm As String = search_tb.Text
		Dim searchBy As String = "id"
		Dim sql As String = "SELECT id, kitNumber, schoolName, category, FORMAT(dateIn, 'MM/dd/yyyy') as dateIn, FORMAT(dateOut, 'MM/dd/yyyy') as dateOut, gsiStaff, notes
							  FROM kitInventory"
		Dim load As New Class_SQLCommands

		'Clear out data table
		kits_dgv.DataSource = Nothing
		kits_dgv.DataBind()

		'Clear out error label
		error_lbl.Text = ""

		'Get sorting column information
		Select Case sortingColumn_ddl.SelectedIndex
			Case 0
				columnSort = "id"
			Case 1
				columnSort = "kitNumber"
			Case 2
				columnSort = "schoolName"
			Case 3
				columnSort = "category"
			Case 4
				columnSort = "dateIn"
			Case 5
				columnSort = "dateOut"
			Case 6
				columnSort = "gsiStaff"
		End Select

		'Get sorting order from DDL
		Select Case sortingOrder_ddl.SelectedIndex
			Case 0
				orderSort = "ASC"
			Case 1
				orderSort = "DESC"
		End Select

		'Get searching column information
		Select Case searchBy_ddl.SelectedIndex
			Case 0
				searchBy = "id"
			Case 1
				searchBy = "kitNumber"
			Case 2
				searchBy = "schoolName"
			Case 3
				searchBy = "category"
			Case 4
				searchBy = "dateIn"
			Case 5
				searchBy = "dateOut"
			Case 6
				searchBy = "gsiStaff"
		End Select

		'Load table
		Try
			kits_dgv.DataSource = load.LoadKitInventory(searchTerm, searchBy, columnSort, orderSort)
			kits_dgv.DataBind()
		Catch
			error_lbl.Text = "Error in LoadTable(). Could not load kit inventory."
			Exit Sub
		End Try

		'Highlight row being edited
		For Each row As GridViewRow In kits_dgv.Rows
			If row.RowIndex = kits_dgv.EditIndex Then
				row.BackColor = ColorTranslator.FromHtml("#ebe534")
				'row.BorderColor = ColorTranslator.FromHtml("#ffffff")
				row.BorderWidth = 2
			End If
		Next

	End Sub

	Sub DataEntrySubmit()
		Dim kitNumber As String = kitNumber_tb.Text
		Dim schoolName As String = schoolName_ddl.SelectedValue
		Dim category As String = category_ddl.SelectedValue
		Dim dateOut As String = dateOut_tb.Text
		Dim notes As String = notes_tb.Text
		Dim confirm As String
		Dim insert As New Class_SQLCommands

		'Submit data and assign return string to error label to confirm if it passed or failed
		confirm = insert.InsertIntoKitInventory(kitNumber, schoolName, category, dateOut, notes)

		If confirm = "Submission successful!" Then
			Page.ClientScript.RegisterStartupScript(Me.GetType(), "SubmitSucessText", "SubmitSucessText();", True)
		Else
			error_lbl.Text = confirm
		End If
	End Sub

	Private Sub kits_dgv_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles kits_dgv.RowUpdating
		Dim row As GridViewRow = kits_dgv.Rows(0)                           'Code is used to enable the editing prodecure
		Dim ID As Integer = Convert.ToInt32(kits_dgv.DataKeys(e.RowIndex).Values(0)) 'Gets id number

		Dim kitNumber As String = TryCast(kits_dgv.Rows(e.RowIndex).FindControl("kitNumberDGV_tb"), TextBox).Text
		Dim schoolName As String = TryCast(kits_dgv.Rows(e.RowIndex).FindControl("schoolNameDGV_ddl"), DropDownList).SelectedValue.ToString
		Dim category As String = TryCast(kits_dgv.Rows(e.RowIndex).FindControl("categoryDGV_ddl"), DropDownList).SelectedValue.ToString
		Dim dateIn As String = TryCast(kits_dgv.Rows(e.RowIndex).FindControl("dateInDGV_tb"), TextBox).Text
		Dim dateOut As String = TryCast(kits_dgv.Rows(e.RowIndex).FindControl("dateOutDGV_tb"), TextBox).Text
		Dim gsiStaff As String = TryCast(kits_dgv.Rows(e.RowIndex).FindControl("gsiStaffDGV_ddl"), DropDownList).SelectedValue.ToString
		Dim notes As String = TryCast(kits_dgv.Rows(e.RowIndex).FindControl("notesDGV_tb"), TextBox).Text

		'Check for dateIn not blank or nothing (this is to prevent a default date being entered in when updating the row)
		If dateIn <> Nothing Or dateIn <> "" Then

			'Updating rows with entered data (UPDATES DATE IN)
			Try
				Using con As New SqlConnection(connection_string)
					Using cmd As New SqlCommand("UPDATE kitInventory SET kitNumber=@kitNumber, schoolName=@schoolName, category=@category, dateIn=@dateIn, dateOut=@dateOut, gsiStaff=@gsiStaff, notes=@notes WHERE ID=@Id")
						cmd.Parameters.AddWithValue("@ID", ID)
						cmd.Parameters.AddWithValue("@kitNumber", kitNumber)
						cmd.Parameters.AddWithValue("@schoolName", schoolName)
						cmd.Parameters.AddWithValue("@category", category)
						cmd.Parameters.AddWithValue("@dateIn", dateIn)
						cmd.Parameters.AddWithValue("@dateOut", dateOut)
						cmd.Parameters.AddWithValue("@gsiStaff", gsiStaff)
						cmd.Parameters.AddWithValue("@notes", notes)
						cmd.Connection = con
						con.Open()
						cmd.ExecuteNonQuery()
						con.Close()
					End Using
				End Using

				kits_dgv.EditIndex = -1 'reset the grid after editing
				LoadTable()
			Catch
				error_lbl.Text = "Error in updating row."
				Exit Sub
			End Try
		Else

			'Updating rows with entered data (DOES NOT UPDATE DATE IN)
			Try
				Using con As New SqlConnection(connection_string)
					Using cmd As New SqlCommand("UPDATE kitInventory SET kitNumber=@kitNumber, schoolName=@schoolName, category=@category, dateOut=@dateOut, gsiStaff=@gsiStaff, notes=@notes WHERE ID=@Id")
						cmd.Parameters.AddWithValue("@ID", ID)
						cmd.Parameters.AddWithValue("@kitNumber", kitNumber)
						cmd.Parameters.AddWithValue("@schoolName", schoolName)
						cmd.Parameters.AddWithValue("@category", category)
						cmd.Parameters.AddWithValue("@dateOut", dateOut)
						cmd.Parameters.AddWithValue("@gsiStaff", gsiStaff)
						cmd.Parameters.AddWithValue("@notes", notes)
						cmd.Connection = con
						con.Open()
						cmd.ExecuteNonQuery()
						con.Close()
					End Using
				End Using

				kits_dgv.EditIndex = -1 'reset the grid after editing
				LoadTable()
			Catch
				error_lbl.Text = "Error in updating row."
				Exit Sub
			End Try
		End If

	End Sub

	Private Sub kits_dgv_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles kits_dgv.RowDeleting
		Dim row As GridViewRow = kits_dgv.Rows(0)                           'Code is used to enable the editing prodecure
		Dim ID As Integer = Convert.ToInt32(kits_dgv.DataKeys(e.RowIndex).Values(0)) 'Gets id number

		Try
			Using con As New SqlConnection(connection_string)
				Using cmd As New SqlCommand("DELETE FROM kitInventory WHERE id=@ID")
					cmd.Parameters.AddWithValue("@ID", ID)
					cmd.Connection = con
					con.Open()
					cmd.ExecuteNonQuery()
					con.Close()
				End Using
			End Using
			kits_dgv.EditIndex = -1       'reset the grid after editing
			LoadTable()

			'Refresh page
			'Response.Redirect(".\kit_inventory.aspx")
		Catch ex As Exception
			error_lbl.Text = "Error in rowDeleting. Cannot delete row."
			Exit Sub
		End Try


	End Sub

	Private Sub kits_dgv_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles kits_dgv.RowEditing
		kits_dgv.EditIndex = e.NewEditIndex
		LoadTable()
	End Sub

	Private Sub kits_dgv_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles kits_dgv.RowCancelingEdit
		kits_dgv.EditIndex = -1
		LoadTable()
	End Sub

	Private Sub kits_dgv_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles kits_dgv.RowDataBound
		If (e.Row.RowType = DataControlRowType.DataRow) Then

			'School Name Dropdown
			Dim ddlSchool As DropDownList = CType(e.Row.FindControl("schoolNameDGV_ddl"), DropDownList)
			ddlSchool.DataSource = GetData("SELECT schoolname FROM schoolInfo WHERE NOT (schoolName = 'A1 No School Scheduled') AND NOT id='505' ORDER BY schoolName ASC")
			ddlSchool.DataTextField = "schoolName"
			'ddlSchool.DataValueField = "Businessid"
			ddlSchool.DataBind()
			Dim lblSchool As String = CType(e.Row.FindControl("schoolNameDGV_lbl"), Label).Text

			ddlSchool.Items.FindByValue(lblSchool).Selected = True
			'Dim businessID As String = ddlSchool.SelectedValue

			'Category Dropdown
			Dim ddlCategory As DropDownList = CType(e.Row.FindControl("categoryDGV_ddl"), DropDownList)
			Dim lblCategory As String = CType(e.Row.FindControl("categoryDGV_lbl"), Label).Text

			ddlCategory.Items.FindByValue(lblCategory).Selected = True
			'Dim businessID As String = ddlSchool.SelectedValue

			'GSI Staff Dropdown
			Dim ddlStaff As DropDownList = CType(e.Row.FindControl("gsiStaffDGV_ddl"), DropDownList)
			Dim lblStaff As String = CType(e.Row.FindControl("gsiStaffDGV_lbl"), Label).Text

			ddlStaff.Items.FindByValue(lblStaff).Selected = True
			'Dim businessID As String = ddlSchool.SelectedValue

		End If
	End Sub

	Private Sub kits_dgv_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles kits_dgv.PageIndexChanging
		kits_dgv.PageIndex = e.NewPageIndex
		LoadTable()
	End Sub

	Protected Sub dataEntry_btn_Click(sender As Object, e As EventArgs) Handles dataEntry_btn.Click

		'Make data entry div visible
		If dataEntry_div.Visible = False Then
			dataEntry_div.Visible = True
			kitTable_div.Visible = False
		Else
			dataEntry_div.Visible = False
			kitTable_div.Visible = False
		End If

	End Sub

	Protected Sub dataEntrySubmit_btn_Click(sender As Object, e As EventArgs) Handles dataEntrySubmit_btn.Click
		DataEntrySubmit()
	End Sub

	Protected Sub kitTable_btn_Click(sender As Object, e As EventArgs) Handles kitTable_btn.Click

		'Make kit inventory list div visible
		If kitTable_div.Visible = False Then
			kitTable_div.Visible = True
			dataEntry_div.Visible = False

			LoadTable()
		Else
			kitTable_div.Visible = False
			dataEntry_div.Visible = False
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

	Public Function IsDate(input As String) As Boolean
		Dim result As DateTime
		Return DateTime.TryParse(input, result)
	End Function

	Protected Sub sort_btn_Click(sender As Object, e As EventArgs) Handles sort_btn.Click
		LoadTable()
	End Sub

	Protected Sub search_btn_Click(sender As Object, e As EventArgs) Handles search_btn.Click

		'Check if textbox is filled
		If search_tb.Text <> "" Or search_tb.Text <> Nothing Then
			LoadTable()
		Else
			error_lbl.Text = "Please enter a search term in the search bar."
			Exit Sub
		End If

	End Sub

	Protected Sub refresh_btn_Click(sender As Object, e As EventArgs) Handles refresh_btn.Click

		'Reset DDLs and textboxes to default values, then load the table again
		search_tb.Text = ""
		searchBy_ddl.SelectedIndex = searchBy_ddl.Items.IndexOf(searchBy_ddl.Items.FindByValue("ID"))
		sortingColumn_ddl.SelectedIndex = sortingColumn_ddl.Items.IndexOf(sortingColumn_ddl.Items.FindByValue("ID"))
		sortingOrder_ddl.SelectedIndex = sortingOrder_ddl.Items.IndexOf(sortingOrder_ddl.Items.FindByValue("Ascending"))

		LoadTable()
	End Sub

End Class