Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls

Public Class EV_Daily_Forms
	Inherits System.Web.UI.Page
	Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
	Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
	Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
	Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
	Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
	Dim DBConnection As New DatabaseConection
	Dim dr As SqlDataReader
	Dim VisitID As New Class_VisitData
	Dim Visit As Integer = VisitID.GetVisitID

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		If Session("LoggedIn") <> "1" Then
			Response.Redirect(".\default.aspx")
		End If

		If Not (IsPostBack) Then
			If Visit <> 0 Then
				visitdate_hf.Value = Visit
			End If

			'Populating school header
			Dim header As New Class_SchoolHeader
			headerSchoolName_lbl.Text = header.GetSchoolHeader()
		End If

	End Sub

	Sub LoadSchools()
		Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
		Dim con As New SqlConnection
		Dim cmd As New SqlCommand
		Dim dr As SqlDataReader
		Dim sql As String = "SELECT s.schoolName as 'schoolName'
											  FROM schoolInfo s 
											  JOIN visitInfo v ON v.school = s.id OR v.school2 = s.id OR v.school3 = s.id OR v.school4 = s.id OR v.school5 = s.id
											  WHERE v.visitDate='" & visitDate_tb.Text & "' AND NOT s.id=505 
											  ORDER BY schoolName"

		'Clear out DDL
		schoolName_ddl.Items.Clear()

		'Load schools into DDL
		Try
			con.ConnectionString = connection_string
			con.Open()
			cmd.CommandText = sql
			cmd.Connection = con
			dr = cmd.ExecuteReader

			While dr.Read()
				schoolName_ddl.Items.Add(dr(0).ToString)
			End While

			schoolName_ddl.Items.Insert(0, "")

			cmd.Dispose()
			con.Close()
		Catch
			error_lbl.Text = "Error in LoadSchools(). Could not get school names."
			Exit Sub
		Finally
			cmd.Dispose()
			con.Close()
		End Try

		'Make schools DDL visible
		schoolName_ddl.Visible = True
		schoolName_p.Visible = True

	End Sub

	Sub LoadData()
		Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
		Dim con As New SqlConnection
		Dim cmd As New SqlCommand
		Dim dr As SqlDataReader
		Dim visitDate As Date = visitDate_tb.Text
		Dim schoolName As String = schoolName_ddl.SelectedValue
		Dim sql As String = "SELECT schoolType FROM schoolInfo WHERE schoolName = '" & schoolName & "'"
		Dim sql2 As String = "SELECT workbooks FROM schoolVisitChecklist WHERE visitDate = '" & visitDate & "' AND schoolName = '" & schoolName & "'"
		Dim studentCountSQL As String = "SELECT COUNT(lastName) as studentCount FROM (SELECT s.id, s.employeeNumber, s.firstName, s.lastName, j.jobTitle, b.businessName, sc.schoolName
                                FROM studentInfo s
                                INNER JOIN jobs j ON j.id=s.job
                                INNER JOIN businessInfo b ON b.id=s.business
                                INNER JOIN visitInfo v ON v.id=s.visit
                                INNER JOIN schoolInfo sc ON s.school = sc.id
                                WHERE v.visitDate='" & visitDate & "' AND sc.schoolName = '" & schoolName & "' AND NOT businessName='Training Business' AND NOT firstName='NULL' AND NOT lastName='NULL' AND NOT firstName = ' ' AND NOT lastName=' ' ) t"

		'Load visit date and school name into labels
		visitDate_lbl.Text = visitDate
		schoolName_lbl.Text = schoolName
		schoolName2_lbl.Text = schoolName

		'Make fields and buttons visible
		info_div.Visible = True
		printPCSB_btn.Visible = True

		'Check if school is Pinellas county or not
		Try
			con.ConnectionString = connection_string
			con.Open()
			cmd.CommandText = sql
			cmd.Connection = con
			dr = cmd.ExecuteReader

			'Make Pinellas schools divs visible
			While dr.Read()
				If dr("schoolType").ToString = "Public" Or dr("schoolType").ToString = "PC Charter" Then
					lunchPCSB_div.Visible = True
					workbooksOOC_div.Visible = False
					questionsOOC_div.Visible = False
					PCSBForms_lbl.Text = "Pinellas County Schools Form"
				Else
					lunchPCSB_div.Visible = False
					workbooksOOC_div.Visible = True
					questionsOOC_div.Visible = True
					PCSBForms_lbl.Text = "Private/Out of County Schools Form"
				End If
			End While

			cmd.Dispose()
			con.Close()

		Catch
			error_lbl.Text = "Error in LoadData(). Could not check if school county."
			Exit Sub
		End Try

		cmd.Dispose()
		con.Close()

		'Load workbooks data from schoolVisitChecklist table in DB
		Try
			con.ConnectionString = connection_string
			con.Open()
			cmd.CommandText = sql2
			cmd.Connection = con
			dr = cmd.ExecuteReader

			While dr.Read()
				If dr.HasRows = False Then
					'If workbooks have not been added, then replace with student count for school
					Exit Try
				Else
					workbooks_lbl.Text = dr("workbooks").ToString
					cmd.Dispose()
					con.Close()
					Exit Sub
				End If
			End While

		Catch
			error_lbl.Text = "Error in LoadData(). Could not load workbooks data."
			Exit Sub
		End Try

		cmd.Dispose()
		con.Close()

		'Load student count data to replace workbooks number
		Try
			con.ConnectionString = connection_string
			con.Open()
			cmd.CommandText = studentCountSQL
			cmd.Connection = con
			dr = cmd.ExecuteReader

			While dr.Read()
				workbooks_lbl.Text = dr("studentCount").ToString

				If workbooksOOC_div.Visible = True Then
					error_lbl.Text = "Workbooks number is student count of school selected. If you need to add or remove workbooks, finish the school visit checklist for this school."
				Else
					error_lbl.Text = ""
				End If

			End While

			cmd.Dispose()
			con.Close()

		Catch
			error_lbl.Text = "Error in LoadData(). Could not load workbooks data."
			Exit Sub
		End Try

		cmd.Dispose()
		con.Close()



	End Sub

	Protected Sub visitDate_tb_TextChanged(sender As Object, e As EventArgs) Handles visitDate_tb.TextChanged
		LoadSchools()
	End Sub

	Protected Sub schoolName_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles schoolName_ddl.SelectedIndexChanged
		LoadData()
	End Sub

	Protected Sub printPCSB_btn_Click(sender As Object, e As EventArgs) Handles printPCSB_btn.Click

		'Make logos visible
		EVLogo_img.Visible = True
		StavrosLogo_img.Visible = True

		Page.ClientScript.RegisterStartupScript(Me.GetType(), "Print", "PrintBadges();", True)
	End Sub
End Class