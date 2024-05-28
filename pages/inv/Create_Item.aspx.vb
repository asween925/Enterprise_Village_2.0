Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class Create_Item
	Inherits System.Web.UI.Page
	Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
	Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
	Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
	Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
	Dim DBConnection As New DatabaseConection
	Dim dr As SqlDataReader
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
			Dim username As String = Session("username")

			If Visit <> 0 Then
				visitdate_hf.Value = Visit
			End If

			'Populating school header
			Dim header As New Class_SchoolHeader
			headerSchoolName_lbl.Text = header.GetSchoolHeader()

			'Populate business used DDL
			PopulateDDL()
		End If
	End Sub

	Sub Submit()
		Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
		Dim dr As SqlDataReader

		'Check for blanks or errors
		If itemName_tb.Text = Nothing Or itemName_tb.Text = "" Then
			error_lbl.Text = "Please enter an item name."
			ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ScrollPage", "window.scrollTo(0,0);", True)
			Exit Sub
		End If

		If onHand_tb.Text = Nothing Or onHand_tb.Text = "" Then
			error_lbl.Text = "Please enter an amount on hand."
			Exit Sub
		End If

		If usedDaily_tb.Text = Nothing Or usedDaily_tb.Text = "" Then
			usedDaily_tb.Text = 0
		End If

		'Check if item name is in DB
		Using con As New SqlConnection(connection_string)
			Using cmd As New SqlCommand("SELECT itemName FROM EV_Inventory WHERE itemName = '" & itemName_tb.Text & "'")
				cmd.Connection = con
				con.Open()
				dr = cmd.ExecuteReader
				While dr.Read()
					If dr.HasRows = True Then
						error_lbl.Text = "An item with that name is already in the inventory. Please view the 'Edit Item' page to make changes to the item."

						'Refresh page
						Dim meta As New HtmlMeta()
						meta.HttpEquiv = "Refresh"
						meta.Content = "5;url=create_item.aspx"
						Me.Page.Controls.Add(meta)
						Exit Sub
					End If
				End While
				con.Close()
				cmd.Dispose()

			End Using

			'Insert data into DB
			Using cmd As New SqlCommand("INSERT INTO EV_Inventory (
													 itemName
													,itemCategory
													,itemSubCat
													,currentLocation
													,businessUsed
													,onHand
													,source
													,merchCode
													,usedDaily
													,comments)
												VALUES ( 
													@itemName
													,@itemCategory
													,@itemSubCat
													,@currentLocation
													,@businessUsed
													,@onHand
													,@source
													,@merchCode
													,@usedDaily
													,@comments);")
				cmd.Parameters.Add("@itemName", SqlDbType.VarChar).Value = itemName_tb.Text
				cmd.Parameters.Add("@itemCategory", SqlDbType.VarChar).Value = itemCategory_ddl.SelectedValue
				cmd.Parameters.Add("@itemSubCat", SqlDbType.VarChar).Value = itemSubCat_ddl.SelectedValue
				cmd.Parameters.Add("@currentLocation", SqlDbType.VarChar).Value = currentLocation_ddl.SelectedValue
				cmd.Parameters.Add("@businessUsed", SqlDbType.VarChar).Value = businessUsed_ddl.SelectedValue
				cmd.Parameters.Add("@onHand", SqlDbType.Int).Value = onHand_tb.Text
				cmd.Parameters.Add("@source", SqlDbType.VarChar).Value = source_ddl.SelectedValue
				cmd.Parameters.Add("@merchCode", SqlDbType.VarChar).Value = merchCode_ddl.SelectedValue
				cmd.Parameters.Add("@usedDaily", SqlDbType.Int).Value = usedDaily_tb.Text
				cmd.Parameters.Add("@comments", SqlDbType.VarChar).Value = comments_tb.Text
				cmd.Connection = con
				con.Open()
				cmd.ExecuteNonQuery()
				con.Close()
			End Using
		End Using

		'error_lbl.Text = "Submission Sucessful"
		Page.ClientScript.RegisterStartupScript(Me.GetType(), "SubmitSucessText", "SubmitSucessText();", True)
		Page.ClientScript.RegisterStartupScript(Me.GetType(), "ScrollToTop", "ScrollToTop();", True)
	End Sub

	Sub EVBusinessLocation()
		If currentLocation_ddl.SelectedValue = "EV" Then
			businessUsed_ddl.Enabled = True
			businessUsed_ddl.Items.Remove("N/A")
		Else
			businessUsed_ddl.Items.Insert(0, "N/A")
			businessUsed_ddl.SelectedIndex = businessUsed_ddl.Items.IndexOf(businessUsed_ddl.Items.FindByValue("N/A"))
			businessUsed_ddl.Enabled = False

		End If
	End Sub

	Sub PopulateDDL()
		'Populate businesses (Current location in EV and Business Item Belongs to) DDL
		Dim businessUsedSQL As String = "SELECT b.businessName FROM businessinfo b ORDER BY b.businessName"
		Dim itemCategorySQL As String = "SELECT DISTINCT itemCategory FROM EV_Inventory ORDER BY itemCategory ASC"
		Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
		Dim con As New SqlConnection
		Dim cmd As New SqlCommand
		Dim dr As SqlDataReader

		'Clear out business DDL
		businessUsed_ddl.Items.Clear()
		itemCategory_ddl.Items.Clear()

		'Populate Business DDL
		Try
			con.ConnectionString = connection_string
			con.Open()
			cmd.CommandText = businessUsedSQL
			cmd.Connection = con
			dr = cmd.ExecuteReader

			While dr.Read()
				businessUsed_ddl.Items.Add(dr(0).ToString)
				'itemBusiness_ddl.Items.Add(dr(0).ToString)
			End While
			itemCategory_ddl.Items.Insert(0, "")
			businessUsed_ddl.Items.Insert(0, "N/A")
			cmd.Dispose()
			con.Close()

		Catch
			error_lbl.Text = "Error in PopulateDDL(). Cannot populate business names."
			Exit Sub
		Finally
			cmd.Dispose()
			con.Close()

		End Try

		'Clear out categories DDL
		itemCategory_ddl.Items.Clear()

		'Populate item category DDL
		Try
			con.ConnectionString = connection_string
			con.Open()
			cmd.CommandText = itemCategorySQL
			cmd.Connection = con
			dr = cmd.ExecuteReader

			While dr.Read()
				itemCategory_ddl.Items.Add(dr(0).ToString)
			End While
			'businessUsed_ddl.Items.Insert(0, "")
			cmd.Dispose()
			con.Close()

		Catch
			error_lbl.Text = "Error in PopulateDDL(). Cannot populate item category names."
			Exit Sub
		Finally
			cmd.Dispose()
			con.Close()

		End Try

		cmd.Dispose()
		con.Close()

		ItemCatFunction()
	End Sub

	Sub ItemCatFunction()
		Dim itemSubCatSQL As String = "SELECT DISTINCT itemSubCat FROM EV_Inventory WHERE itemCategory = '" & itemCategory_ddl.SelectedValue & "' ORDER BY itemSubCat ASC"
		Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
		Dim con As New SqlConnection
		Dim cmd As New SqlCommand
		Dim dr As SqlDataReader

		'Clear out categories DDL
		itemSubCat_ddl.Items.Clear()

		'Populate item  subcategory DDL
		Try
			con.ConnectionString = connection_string
			con.Open()
			cmd.CommandText = itemSubCatSQL
			cmd.Connection = con
			dr = cmd.ExecuteReader

			While dr.Read()
				itemSubCat_ddl.Items.Add(dr(0).ToString)
			End While
			'itemSubCat_ddl.Items.Insert(0, "")
			cmd.Dispose()
			con.Close()

		Catch
			error_lbl.Text = "Error in PopulateSubCatDDL(). Cannot populate sub category names."
			Exit Sub
		Finally
			cmd.Dispose()
			con.Close()

		End Try

		'Check if selected item category is Home, if so then keep itemSubCat DDL disabled and set to 'N/A'
		If itemCategory_ddl.SelectedValue = "Home" Then
			itemSubCat_ddl.Enabled = False
			Exit Sub
		Else
			itemSubCat_ddl.Enabled = True
		End If

		'Check if selected item category is Forms, if so then select N/A for merch code
		If itemCategory_ddl.SelectedValue = "Forms" Then
			merchCode_ddl.Items.Insert(0, "N/A")
			merchCode_ddl.SelectedIndex = merchCode_ddl.Items.IndexOf(merchCode_ddl.Items.FindByValue("N/A"))
			source_ddl.SelectedIndex = source_ddl.Items.IndexOf(source_ddl.Items.FindByValue("In House"))
			source_ddl.Enabled = False
			merchCode_ddl.Enabled = False
			Exit Sub
		Else
			merchCode_ddl.Items.Remove("N/A")
			source_ddl.Enabled = True
			merchCode_ddl.Enabled = True
			Exit Sub
		End If


		cmd.Dispose()
		con.Close()
	End Sub

	Protected Sub Submit_btn_Click(sender As Object, e As EventArgs) Handles Submit_btn.Click
		Submit()
	End Sub

	Protected Sub currentLocation_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles currentLocation_ddl.SelectedIndexChanged
		EVBusinessLocation()
	End Sub

	Protected Sub itemCategory_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles itemCategory_ddl.SelectedIndexChanged
		ItemCatFunction()
	End Sub
End Class