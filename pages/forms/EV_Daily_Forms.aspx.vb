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
	Dim Visits As New Class_VisitData
	Dim Schools As New Class_SchoolData
	Dim Students As New Class_StudentData
	Dim SH As New Class_SchoolHeader
	Dim VisitID As Integer = Visits.GetVisitID

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		If Session("LoggedIn") <> "1" Then
			Response.Redirect("../../default.aspx")
		End If

		If Not (IsPostBack) Then

			'Populating school header
			headerSchoolName_lbl.Text = SH.GetSchoolHeader()

		End If

	End Sub

	Sub LoadSchools()
		Dim VisitDate As String = visitDate_tb.Text

		'Clear out DDL
		schoolName_ddl.Items.Clear()

		'Load schools into DDL
		Try
			Schools.LoadVisitDateSchoolsDDL(VisitDate, schoolName_ddl)
		Catch
			error_lbl.Text = "Error in LoadSchools(). Could not get school names."
			Exit Sub
		End Try

		'Make schools DDL visible
		schoolName_ddl.Visible = True
		schoolName_p.Visible = True

	End Sub

	Sub LoadData()
		Dim VisitDate As Date = visitDate_tb.Text
		Dim SchoolName As String = schoolName_ddl.SelectedValue
		Dim SchoolID As Integer = Schools.GetSchoolID(SchoolName)
		Dim SchoolType As String
		Dim Workbooks As String
		Dim StudentCount As String
		Dim studentCountSQL As String = "SELECT COUNT(lastName) as studentCount FROM (SELECT s.id, s.accountNumber, s.firstName, s.lastName, j.jobTitle, b.businessName, sc.schoolName
                                FROM studentInfo s
                                INNER JOIN jobs j ON j.id=s.jobID
                                INNER JOIN businessInfo b ON b.id=s.businessID
                                INNER JOIN visitInfo v ON v.id=s.visitID
                                INNER JOIN schoolInfo sc ON s.schoolID = sc.id
                                WHERE v.visitDate='" & VisitDate & "' AND sc.schoolName = '" & SchoolName & "' AND NOT businessName='Training Business' AND NOT firstName='NULL' AND NOT lastName='NULL' AND NOT firstName = ' ' AND NOT lastName=' ' ) t"

		'Load visit date and school name into labels
		visitDate_lbl.Text = visitDate
		schoolName_lbl.Text = schoolName
		schoolName2_lbl.Text = schoolName

		'Make fields and buttons visible
		info_div.Visible = True
		printPCSB_btn.Visible = True

		'Check if school is Pinellas county or not
		Try
			SchoolType = Schools.LoadSchoolInfoFromSchool(schoolName, "schoolType")

			If SchoolType = "Public" Or SchoolType = "PC Charter" Then
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
		Catch
			error_lbl.Text = "Error in LoadData(). Could not check school county."
			Exit Sub
		End Try

		'Load workbooks data from schoolVisitChecklist table in DB
		Try
			Workbooks = Schools.GetWorkbooks(VisitID, SchoolID)
		Catch
			error_lbl.Text = "Error in LoadData(). Could not load workbooks data."
			Exit Sub
		End Try

		'Load student count data to replace workbooks number
		Try
			StudentCount = Students.GetStudentCountOfSchool(VisitDate, SchoolName)

			If Workbooks <> 0 Then
				workbooks_lbl.Text = Workbooks
			Else
				workbooks_lbl.Text = StudentCount
			End If

			If workbooksOOC_div.Visible = True Then
				error_lbl.Text = "Workbooks number is student count of school selected. If you need to add or remove workbooks, finish the school visit checklist for this school."
			Else
				error_lbl.Text = ""
			End If

		Catch
			error_lbl.Text = "Error in LoadData(). Could not load workbooks data."
			Exit Sub
		End Try

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