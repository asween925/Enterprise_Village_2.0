Imports System.IO
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Drawing

Public Class Volunteer_Database
	Inherits System.Web.UI.Page
	Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
	Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
	Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
	Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
	Dim con As New SqlConnection
	Dim cmd As New SqlCommand
	Dim dr As SqlDataReader
	Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
	Dim VisitData As New Class_VisitData
	Dim BusinessData As New Class_BusinessData
	Dim SchoolData As New Class_SchoolData
	Dim VisitID As Integer = VisitData.GetVisitID

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Session("LoggedIn") <> "1" Then
			Response.Redirect(".\default.aspx")
		End If

		If Not (IsPostBack) Then

			'Assign current visit ID to hidden field
			If VisitID <> 0 Then
				currentVisitID_hf.Value = VisitID
			End If

			'Populating school header
			Dim header As New Class_SchoolHeader
			headerSchoolName_lbl.Text = header.GetSchoolHeader()

			'Populate DDLs
			BusinessData.LoadBusinessNamesDDL(businessName_ddl)

			'Replace first list item in business DDL with DDL name
			businessName_ddl.Items.RemoveAt(0)
			businessName_ddl.Items.Insert(0, "Business Name")

			'Populate school data
			SchoolData.LoadSchoolsDDL(schoolName_ddl)

			'Load data
			LoadData()
		End If
	End Sub

	Sub LoadData()
		Dim SQLStatement As String = "SELECT id, firstName, lastName, businessName, schoolName, visitDate, pr, svHours, notes FROM volunteers"

		'Clear error
		error_lbl.Text = ""

		'Check if visit date has been entered
		If visitDate_tb.Text <> Nothing Or visitDate_tb.Text <> "" Then
			SQLStatement = SQLStatement & " WHERE visitDate = '" & visitDate_tb.Text & "'"

			'Load total SV hours
			TotalSVHours(visitDate_tb.Text)

			'Check if a specific school of scheduled visit date have been selected
			If visitDateSchools_ddl.SelectedIndex <> 0 Then
				SQLStatement = SQLStatement & " AND schoolName = '" & visitDateSchools_ddl.SelectedValue & "'"

				'Load total SV hours
				TotalSVHours(visitDate_tb.Text, visitDateSchools_ddl.SelectedValue)
			End If

		Else
			SQLStatement = SQLStatement
		End If

		'Check if school name has been selected
		If schoolName_ddl.SelectedValue <> Nothing Or schoolName_ddl.SelectedValue <> "" Then
			SQLStatement = SQLStatement & " WHERE schoolName = '" & schoolName_ddl.SelectedValue & "'"

			'Load total SV hours
			TotalSVHours(Nothing, schoolName_ddl.SelectedValue)

			'Check if specific visit date of selected school has been selected
			If schoolVisitDate_ddl.SelectedValue <> Nothing Or schoolVisitDate_ddl.SelectedValue <> "" Then
				SQLStatement = SQLStatement & " AND visitDate = '" & schoolVisitDate_ddl.SelectedValue & "'"

				'Load total SV hours
				TotalSVHours(schoolVisitDate_ddl.SelectedValue, schoolName_ddl.SelectedValue)
			End If

		Else
			SQLStatement = SQLStatement
		End If

		'Check if search bar is filled
		If search_tb.Text <> Nothing Or search_tb.Text <> "" Then
			SQLStatement = SQLStatement & " WHERE firstName LIKE '%" & search_tb.Text & "%' OR lastName LIKE '%" & search_tb.Text & "%'"
		Else
			SQLStatement = SQLStatement
		End If

		'Check if sorted DDL is selected
		If sortBy_ddl.SelectedIndex <> 0 Or ascDesc_ddl.SelectedIndex <> 0 Then

			'Add order by to SQLStatement
			SQLStatement = SQLStatement & " ORDER BY "

			'Check sorting DDLs
			If sortBy_ddl.SelectedValue = "Recently Added" Then
				SQLStatement = SQLStatement & "id "
			ElseIf sortBy_ddl.SelectedValue = "First Name" Then
				SQLStatement = SQLStatement & "firstName "
			ElseIf sortBy_ddl.SelectedValue = "Last Name" Then
				SQLStatement = SQLStatement & "lastName "
			ElseIf sortBy_ddl.SelectedValue = "Business Name" Then
				SQLStatement = SQLStatement & "businessName "
			ElseIf sortBy_ddl.SelectedValue = "School Name" Then
				SQLStatement = SQLStatement & "schoolName "
			ElseIf sortBy_ddl.SelectedValue = "Visit Date" Then
				SQLStatement = SQLStatement & "visitDate "
			ElseIf sortBy_ddl.SelectedValue = "PR" Then
				SQLStatement = SQLStatement & "pr "
			ElseIf sortBy_ddl.SelectedValue = "SV Hours" Then
				SQLStatement = SQLStatement & "svHours "
			End If

			If ascDesc_ddl.SelectedValue = "Ascending" Then
				SQLStatement = SQLStatement & "ASC"
			ElseIf ascDesc_ddl.SelectedValue = "Descending" Then
				SQLStatement = SQLStatement & "DESC"
			End If

		End If

		'Load data from volunteers table
		Try
			con.Close()
			con.ConnectionString = connection_string
			con.Open()
			cmd.CommandText = SQLStatement
			cmd.Connection = con

			Dim da As New SqlDataAdapter
			da.SelectCommand = cmd
			Dim dt As New DataTable
			da.Fill(dt)
			volunteers_dgv.DataSource = dt
			volunteers_dgv.DataBind()

			cmd.Dispose()
			con.Close()
		Catch
			error_lbl.Text = "Error in LoadData(). Could not load volunteer data into table."
			Exit Sub
		End Try

		'Highlight row being edited
		For Each row As GridViewRow In volunteers_dgv.Rows
			If row.RowIndex = volunteers_dgv.EditIndex Then
				row.BackColor = ColorTranslator.FromHtml("#ebe534")
				'row.BorderColor = ColorTranslator.FromHtml("#ffffff")
				row.BorderWidth = 2
			End If
		Next

	End Sub

	Sub SubmitVolunteer()
		Dim FirstName As String
		Dim LastName As String
		Dim BusinessName As String
		Dim SchoolName As String
		Dim VisitDate As String
		Dim PR As String
		Dim SVHours As String

		'Check for empty fields
		If firstName_tb.Text = Nothing Or lastName_tb.Text = Nothing Or businessName_ddl.SelectedIndex = 0 Or svHours_tb.Text = Nothing Then
			error_lbl.Text = "Please enter all fields in before submitting a new volunteer."
			Exit Sub
		End If

		'Check if loading from visit date or school name
		If visitDate_div.Visible = True Then
			If visitDate_tb.Text = Nothing Or visitDateSchools_ddl.SelectedIndex = 0 Then
				error_lbl.Text = "Please enter all fields in before submitting a new volunteer."
				Exit Sub
			Else
				VisitDate = visitDate_tb.Text
				SchoolName = visitDateSchools_ddl.SelectedValue
			End If
		ElseIf schoolName_div.Visible = True Then
			If schoolName_ddl.SelectedIndex = 0 Or schoolVisitDate_ddl.SelectedIndex = 0 Then
				error_lbl.Text = "Please enter all fields in before submitting a new volunteer."
				Exit Sub
			Else
				VisitDate = schoolVisitDate_ddl.SelectedValue
				SchoolName = schoolName_ddl.SelectedValue
			End If
		End If

		'Assign fields to variables
		FirstName = firstName_tb.Text
		LastName = lastName_tb.Text
		BusinessName = businessName_ddl.SelectedValue
		PR = pr_ddl.SelectedValue
		SVHours = svHours_tb.Text

		'Check if visit date has been created
		If VisitData.GetVisitIDFromDate(VisitDate) = 0 Then
			error_lbl.Text = "A visit has not been created for that date. Please go to the 'Create a Visit' page to create a new EV visit date."
			Exit Sub
		End If

		'Insert data into DB
		Try
			con.ConnectionString = connection_string
			con.Open()
			cmd.Connection = con
			cmd.CommandText = "INSERT INTO volunteers (firstName, lastName, businessName, schoolName, visitDate, pr, svHours)
                                VALUES ('" & FirstName & "', '" & LastName & "', '" & BusinessName & "', '" & SchoolName & "', '" & VisitDate & "', '" & PR & "', '" & SVHours & "')"

			cmd.ExecuteNonQuery()
			cmd.Dispose()
			con.Close()
		Catch
			error_lbl.Text = "Error in SubmitVolunteer(). Could not add the volunteer."
			Exit Sub
		End Try

		'Load table
		LoadData()

	End Sub

	Sub ChangeColor(SchoolDDL As DropDownList)
		Dim School1 As String
		Dim School2 As String
		Dim School3 As String
		Dim School4 As String
		Dim School5 As String

		'Get schools of selected visit date
		Select Case SchoolDDL.Items.Count
			Case 2
				School1 = SchoolDDL.Items(1).Value
				SchoolDDL.Items.FindByValue(School1).Attributes.Add("style", "color: Blue")
				SchoolDDL.Style.Add("style", "color: Blue")

			Case 3
				School1 = SchoolDDL.Items(1).Value
				School2 = SchoolDDL.Items(2).Value
				SchoolDDL.Items.FindByValue(School1).Attributes.Add("style", "color: Blue")
				SchoolDDL.Style.Add("style", "color: Blue")
			Case 4
				School1 = SchoolDDL.Items(1).Value
				School2 = SchoolDDL.Items(2).Value
				School3 = SchoolDDL.Items(3).Value
			Case 5
				School1 = SchoolDDL.Items(1).Value
				School2 = SchoolDDL.Items(2).Value
				School3 = SchoolDDL.Items(3).Value
				School4 = SchoolDDL.Items(4).Value
			Case 6
				School1 = SchoolDDL.Items(1).Value
				School2 = SchoolDDL.Items(2).Value
				School3 = SchoolDDL.Items(3).Value
				School4 = SchoolDDL.Items(4).Value
				School5 = SchoolDDL.Items(5).Value
		End Select

	End Sub

	Sub TotalSVHours(Optional VisitDate As String = Nothing, Optional SchoolName As String = Nothing)
		Dim SQLStatement As String = "SELECT SUM(svHours) as svHours FROM volunteers WHERE "

		'Check if load by visit date or load by school name is active
		If visitDate_tb.Text <> Nothing Then
			SQLStatement += "visitdate= '" & VisitDate & "' "

			If visitDateSchools_ddl.SelectedIndex <> 0 Then
				SQLStatement += " AND schoolName= '" & SchoolName & "' "
			End If
		End If

		If schoolName_ddl.SelectedIndex <> 0 Then
			SQLStatement += "schoolName = '" & SchoolName & "' "

			If schoolVisitDate_ddl.SelectedIndex <> 0 Then
				SQLStatement += " AND visitDate = '" & VisitDate & "' "
			End If
		End If

		'Get total hours and apply it to label
		'Try
		con.ConnectionString = connection_string
		con.Open()
		cmd.CommandText = SQLStatement
		cmd.Connection = con
		dr = cmd.ExecuteReader

		While dr.Read()
			totalSVHours_lbl.Text = dr("svHours").ToString
		End While

		'Catch ex As Exception
		'	error_lbl.Text = "Error in TotalSVHours(). Could not get total sv hours."
		'	Exit Sub
		'End Try

		cmd.Dispose()
		con.Close()

	End Sub

	Private Sub volunteers_dgv_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles volunteers_dgv.RowUpdating
		Dim row As GridViewRow = volunteers_dgv.Rows(0)                           'Code is used to enable the editing prodecure
		Dim ID As Integer = Convert.ToInt32(volunteers_dgv.DataKeys(e.RowIndex).Values(0)) 'Gets id number
		Dim firstName As String = TryCast(volunteers_dgv.Rows(e.RowIndex).FindControl("firstNameDGV_tb"), TextBox).Text 'Try cast is used to try to convert - gets item from ddl
		Dim lastName As String = TryCast(volunteers_dgv.Rows(e.RowIndex).FindControl("lastNameDGV_tb"), TextBox).Text
		Dim businessName As String = TryCast(volunteers_dgv.Rows(e.RowIndex).FindControl("businessNameDGV_ddl"), DropDownList).SelectedValue.ToString
		Dim schoolName As String = TryCast(volunteers_dgv.Rows(e.RowIndex).FindControl("schoolNameDGV_ddl"), DropDownList).SelectedValue.ToString
		Dim visitDate As String = TryCast(volunteers_dgv.Rows(e.RowIndex).FindControl("visitDateDGV_tb"), TextBox).Text
		Dim pr As String = TryCast(volunteers_dgv.Rows(e.RowIndex).FindControl("prDGV_ddl"), DropDownList).SelectedValue.ToString
		Dim svHours As String = TryCast(volunteers_dgv.Rows(e.RowIndex).FindControl("svHoursDGV_tb"), TextBox).Text
		Dim notes As String = TryCast(volunteers_dgv.Rows(e.RowIndex).FindControl("notesDGV_tb"), TextBox).Text

		Try
			Using con As New SqlConnection(connection_string)
				Using cmd As New SqlCommand("UPDATE volunteers SET firstName=@firstName, lastName=@lastName, businessName=@businessName, schoolName=@schoolName, visitDate=@visitDate, pr=@pr, svHours=@svHours, notes=@notes WHERE ID=@Id")
					cmd.Parameters.AddWithValue("@ID", ID)
					cmd.Parameters.AddWithValue("@firstName", firstName)
					cmd.Parameters.AddWithValue("@lastName", lastName)
					cmd.Parameters.AddWithValue("@businessName", businessName)
					cmd.Parameters.AddWithValue("@schoolName", schoolName)
					cmd.Parameters.AddWithValue("@visitDate", visitDate)
					cmd.Parameters.AddWithValue("@pr", pr)
					cmd.Parameters.AddWithValue("@svHours", svHours)
					cmd.Parameters.AddWithValue("@notes", notes)
					cmd.Connection = con
					con.Open()
					cmd.ExecuteNonQuery()
					con.Close()
				End Using
			End Using
			volunteers_dgv.EditIndex = -1 'reset the grid after editing
			LoadData()
		Catch ex As Exception
			error_lbl.Text = "Error with updating table."
			Exit Sub
		End Try

	End Sub

	Private Sub volunteers_dgv_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles volunteers_dgv.RowDataBound
		If (e.Row.RowType = DataControlRowType.DataRow) Then

			'School Dropdown
			Dim ddlSchool As DropDownList = CType(e.Row.FindControl("schoolNameDGV_ddl"), DropDownList)
			ddlSchool.DataSource = GetData("SELECT schoolName FROM schoolInfo WHERE NOT (schoolName = 'A1 No School Scheduled') AND NOT id='505' ORDER BY schoolName ASC")
			ddlSchool.DataTextField = "schoolName"
			ddlSchool.DataBind()
			Dim lblSchool As String = CType(e.Row.FindControl("schoolNameDGV_lbl"), Label).Text

			ddlSchool.Items.FindByValue(lblSchool).Selected = True


			'Business Dropdown
			Dim ddlBusiness As DropDownList = CType(e.Row.FindControl("businessNameDGV_ddl"), DropDownList)
			ddlBusiness.DataSource = GetData("SELECT businessName FROM businessInfo ORDER BY BusinessName")
			ddlBusiness.DataTextField = "BusinessName"
			ddlBusiness.DataBind()
			Dim lblBusiness As String = CType(e.Row.FindControl("businessNameDGV_lbl"), Label).Text

			ddlBusiness.Items.FindByValue(lblBusiness).Selected = True
		End If
	End Sub

	Private Sub volunteers_dgv_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles volunteers_dgv.RowEditing
		volunteers_dgv.EditIndex = e.NewEditIndex
		LoadData()
	End Sub

	Private Sub volunteers_dgv_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles volunteers_dgv.RowDeleting
		Dim row As GridViewRow = volunteers_dgv.Rows(0)                           'Code is used to enable the editing prodecure
		Dim ID As Integer = Convert.ToInt32(volunteers_dgv.DataKeys(e.RowIndex).Values(0)) 'Gets id number

		Try
			Using con As New SqlConnection(connection_string)
				Using cmd As New SqlCommand("DELETE FROM volunteers WHERE id=@ID")
					cmd.Parameters.AddWithValue("@ID", ID)
					cmd.Connection = con
					con.Open()
					cmd.ExecuteNonQuery()
					con.Close()
				End Using
			End Using
			volunteers_dgv.EditIndex = -1       'reset the grid after editing
			LoadData()

			'Refresh page
			Response.Redirect(".\volunteer_database.aspx")

		Catch ex As Exception
			error_lbl.Text = "Error in rowDeleting. Cannot delete row."
			Exit Sub
		End Try

	End Sub

	Private Sub volunteers_dgv_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles volunteers_dgv.RowCancelingEdit
		volunteers_dgv.EditIndex = -1
		LoadData()
	End Sub

	Private Sub volunteers_dgv_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles volunteers_dgv.PageIndexChanging
		volunteers_dgv.PageIndex = e.NewPageIndex
		LoadData()
	End Sub

	Protected Sub submit_btn_Click(sender As Object, e As EventArgs) Handles submit_btn.Click
		SubmitVolunteer()
	End Sub

	Protected Sub search_btn_Click(sender As Object, e As EventArgs) Handles search_btn.Click
		LoadData()
	End Sub

	Protected Sub sortBy_btn_Click(sender As Object, e As EventArgs) Handles sortBy_btn.Click
		LoadData()
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

	Protected Sub refresh_btn_Click(sender As Object, e As EventArgs) Handles refresh_btn.Click
		Response.Redirect("volunteer_database.aspx")
	End Sub

	Protected Sub visitDate_tb_TextChanged(sender As Object, e As EventArgs) Handles visitDate_tb.TextChanged
		If visitDate_tb.Text <> Nothing Then
			visitDateSchools_ddl.Visible = True
			visitDateSchools_a.Visible = True

			'Load schools associated with selected visit date
			SchoolData.LoadVisitDateSchoolsDDL(visitDate_tb.Text, visitDateSchools_ddl)

			'Load data
			LoadData()
		End If
	End Sub

	Protected Sub schoolName_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles schoolName_ddl.SelectedIndexChanged
		If schoolName_ddl.SelectedIndex <> 0 Then
			schoolVisitDate_ddl.Visible = True
			schoolVisitDate_a.Visible = True

			'Clear school visit date and visit date text box
			schoolVisitDate_ddl.Items.Clear()
			visitDate_tb.Text = ""

			'Get School id from school name in DDL
			Dim SchoolID As String = SchoolData.GetSchoolID(schoolName_ddl.SelectedValue)

			'Load all visit dates of a school in DDL
			VisitData.LoadVisitDatesFromSchool(SchoolID, schoolVisitDate_ddl)

			LoadData()
		End If
	End Sub

	Protected Sub schoolVisitDate_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles schoolVisitDate_ddl.SelectedIndexChanged
		If schoolVisitDate_ddl.SelectedIndex <> 0 Then
			LoadData()
		End If
	End Sub

	Protected Sub visitDateSchools_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles visitDateSchools_ddl.SelectedIndexChanged
		If visitDateSchools_ddl.SelectedIndex <> 0 Then
			LoadData()
		End If
	End Sub

	Protected Sub visitDate_btn_Click(sender As Object, e As EventArgs) Handles visitDate_btn.Click
		If visitDate_div.Visible = False Then

			'Hide school name section stuff
			schoolName_div.Visible = False
			schoolVisitDate_a.Visible = False
			schoolVisitDate_ddl.Visible = False

			'Make visit date section visible
			visitDate_div.Visible = True

			'Clear ddls for school name section
			schoolName_ddl.SelectedIndex = schoolName_ddl.Items.IndexOf(schoolName_ddl.Items.FindByValue(""))
			schoolVisitDate_ddl.Items.Clear()
		End If
	End Sub

	Protected Sub schoolName_btn_Click(sender As Object, e As EventArgs) Handles schoolName_btn.Click
		If schoolName_div.Visible = False Then

			'Hide visit date stuff
			visitDate_div.Visible = False
			visitDateSchools_a.Visible = False
			visitDateSchools_ddl.Visible = False

			'Make school name section visible
			schoolName_div.Visible = True

			'Clear visit date text box and ddl from visit date section
			visitDate_tb.Text = ""
			visitDateSchools_ddl.Items.Clear()
		End If
	End Sub

	Protected Sub businessAssignments_btn_Click(sender As Object, e As EventArgs) Handles businessAssignments_btn.Click
		Dim URL As String = "\Open_Closed_Status.aspx"
		Dim VisitID As String = ""

		'Check if visit date has been selected or entered
		If visitDate_tb.Text <> "" Or schoolVisitDate_ddl.SelectedValue <> "" Then

			'get visit id of selected visit date
			If visitDate_tb.Text <> "" Then
				VisitID = VisitData.GetVisitIDFromDate(visitDate_tb.Text)
			End If

			If schoolVisitDate_ddl.SelectedIndex <> 0 And schoolVisitDate_ddl.SelectedValue <> "" Then
				VisitID = VisitData.GetVisitIDFromDate(schoolVisitDate_ddl.SelectedValue)
			End If

			'Add visit ID to URL
			URL += "?b=" & VisitID

			Page.ClientScript.RegisterStartupScript(Me.GetType(), "OpenInNewWindow", "OpenLinkInNewTab('" & URL & "');", True)
		Else
			Page.ClientScript.RegisterStartupScript(Me.GetType(), "OpenInNewWindow", "OpenLinkInNewTab('" & URL & "');", True)
		End If
	End Sub
End Class