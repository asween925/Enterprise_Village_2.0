Imports System.IO
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class Staff_List
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

			LoadJobsDDL()

			LoadData()
		End If
	End Sub

	Sub LoadData()
		Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
		Dim con As New SqlConnection
		Dim cmd As New SqlCommand

		'Clear error
		error_lbl.Text = ""

		'Check if table is visible
		If create_div.Visible = False Then
			create_div.Visible = False
			staff_dgv.Visible = True
			viewCreate_btn.Text = "Add New Staff Member"
		End If

		'Load staff info into table
		Try
			con.ConnectionString = connection_string
			con.Open()
			cmd.Connection = con
			cmd.CommandText = "SELECT firstName, lastName, address, city, zip, email, SUBSTRING(cellNumber, 1, 3) + '-' + 
								  SUBSTRING(cellNumber, 4, 3) + '-' + 
								  SUBSTRING(cellNumber, 7, 4) as cellNumber, job, dob, username FROM adminInfo WHERE location='Stavros' ORDER BY lastName"

			Dim da As New SqlDataAdapter
			da.SelectCommand = cmd
			Dim dt As New DataTable
			da.Fill(dt)

			staff_dgv.DataSource = dt
			staff_dgv.DataBind()

			cmd.Dispose()
			con.Close()

		Catch
			error_lbl.Text = "Error in loaddata(). Cannot load staff data."
			Exit Sub

		End Try
	End Sub

	Sub Submit()
		Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
		Dim dr As SqlDataReader
		Dim FirstName As String = firstName_tb.Text
		Dim LastName As String = lastName_tb.Text
		Dim Address As String = address_tb.Text
		Dim City As String = city_tb.Text
		Dim ZIP As String = zip_tb.Text
		Dim Email As String = email_tb.Text
		Dim Cell As String = cell_tb.Text
		Dim Username As String = Email.Replace("@pcsb.org", "")
		Dim Job As String = job_ddl.SelectedValue
		Dim DOB As String = dob_tb.Text

		'Check if email is PCSB
		If Not Email.Contains("@pcsb.org") Then
			error_lbl.Text = "Please enter a valid PCSB email address."
			Exit Sub
		End If

		'Check if required fields are filled
		If FirstName = Nothing Then
			error_lbl.Text = "Please enter a first name for the staff member."
			Exit Sub
		ElseIf LastName = Nothing Then
			error_lbl.Text = "Please enter a last name for the staff member."
			Exit Sub
		ElseIf Email = Nothing Then
			error_lbl.Text = "Please enter a valid email address for the staff member."
			Exit Sub
		ElseIf Job = Nothing Then
			error_lbl.Text = "Please select a job title for the staff member."
			Exit Sub
		End If

		'Check if ZIP is blank
		If ZIP = Nothing Then
			ZIP = "33771"
		End If

		'Check if phone number contains '-'
		If Cell.Contains("-") Then
			Cell.Replace("-", "")
		End If

		Using con As New SqlConnection(connection_string)
			'Check if email is in DB
			Using cmd As New SqlCommand("SELECT email FROM adminInfo WHERE email = '" & Email & "'")
				cmd.Connection = con
				con.Open()
				dr = cmd.ExecuteReader

				While dr.Read()
					If dr.HasRows = True Then
						error_lbl.Text = "A user with that email address is already in EV 2.0."
						Exit Sub
					End If
				End While

				con.Close()
				cmd.Dispose()

			End Using

			'Insert data into DB
			Using cmd As New SqlCommand("INSERT INTO adminInfo (
													 firstName
													,lastName
													,email
													,location
													,invoiceControl
													,username
													,job
													,address
													,city
													,zip
													,cellNumber
													,dob)
												VALUES ( 
													@firstName
													,@lastName
													,@email
													,@location
													,@invoiceControl
													,@username
													,@job
													,@address
													,@city
													,@zip
													,@cellNumber
													,@dob);")
				cmd.Parameters.Add("@firstName", SqlDbType.VarChar).Value = FirstName
				cmd.Parameters.Add("@lastName", SqlDbType.VarChar).Value = LastName
				cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = Email
				cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = "Stavros"
				cmd.Parameters.Add("@invoiceControl", SqlDbType.Bit).Value = False
				cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = Username
				cmd.Parameters.Add("@job", SqlDbType.VarChar).Value = Job
				cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = Address
				cmd.Parameters.Add("@city", SqlDbType.VarChar).Value = City
				cmd.Parameters.Add("@zip", SqlDbType.Int).Value = ZIP
				cmd.Parameters.Add("@cellNumber", SqlDbType.Char).Value = Cell
				cmd.Parameters.Add("@dob", SqlDbType.Char).Value = DOB
				cmd.Connection = con
				con.Open()
				cmd.ExecuteNonQuery()
				con.Close()
			End Using
		End Using

		LoadData()
	End Sub

	Sub LoadJobsDDL()
		Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
		Dim con As New SqlConnection
		Dim cmd As New SqlCommand
		Dim dr As SqlDataReader
		Dim SQLStatement As String = "SELECT DISTINCT job FROM adminInfo WHERE job IS NOT NULL AND NOT job='gsi123' ORDER BY job ASC"

		'Clear out business DDL
		job_ddl.Items.Clear()

		'Populate DDL
		con.ConnectionString = connection_string
		con.Open()
		cmd.CommandText = SQLStatement
		cmd.Connection = con
		dr = cmd.ExecuteReader

		While dr.Read()
			job_ddl.Items.Add(dr("job").ToString)
		End While

		job_ddl.Items.Insert(0, "")

		cmd.Dispose()
		con.Close()
	End Sub

	Protected Sub print_btn_Click(sender As Object, e As EventArgs) Handles print_btn.Click
		Page.ClientScript.RegisterStartupScript(Me.GetType(), "Print", "Print();", True)
	End Sub

	Protected Sub viewCreate_btn_Click(sender As Object, e As EventArgs) Handles viewCreate_btn.Click
		If create_div.Visible = False Then
			create_div.Visible = True
			staff_dgv.Visible = False
			viewCreate_btn.Text = "Show Table"
		Else
			create_div.Visible = False
			staff_dgv.Visible = True
			viewCreate_btn.Text = "Add New Staff Member"
		End If
	End Sub

	Protected Sub submit_btn_Click(sender As Object, e As EventArgs) Handles submit_btn.Click
		Submit()
	End Sub
End Class