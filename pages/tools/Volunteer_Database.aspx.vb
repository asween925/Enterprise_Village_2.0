Imports System.IO
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Web.UI.WebControls.Expressions

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
	Dim SH As New Class_SchoolHeader
	Dim VisitID As Integer = VisitData.GetVisitID

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		'If logged out, redirect to log in
		If Session("LoggedIn") <> "1" Then
			Response.Redirect("../../default.aspx")
		End If

		If Not (IsPostBack) Then

			'Populating school header
			headerSchoolName_lbl.Text = SH.GetSchoolHeader()

			'Populate school data
			SchoolData.LoadSchoolsDDL(schoolName_ddl)

			'Populate regular volunteer DDLs
			PopulateVolDDL()

			'Load data
			LoadData()
		End If
	End Sub

	Sub LoadData()
		Dim VIDOfDate As Integer
		Dim SchoolID As Integer
		Dim SQLStatement As String = "SELECT vo.id, firstName, lastName, businessID, schoolID, FORMAT(v.visitDate, 'yyyy-MM-dd') as visitDate, pr, svHours, notes, regular FROM volunteers vo JOIN visitInfo v ON v.id = vo.visitID"

		'Clear error
		error_lbl.Text = ""

		'Check if visit date has been entered
		If visitDate_tb.Text <> Nothing Or visitDate_tb.Text <> "" Then
			VIDOfDate = VisitData.GetVisitIDFromDate(visitDate_tb.Text)
			SQLStatement = SQLStatement & " WHERE vo.visitID = '" & VIDOfDate & "'"
			'error_lbl.Text = SQLStatement
			'Exit Sub

			'Load total SV hours
			TotalSVHours(visitDate_tb.Text)

			'Load volunteer check in information
			LoadVolCheckIn(visitDate_tb.Text)

			'Load schools scheduled to come on this 

			'Check if a specific school of scheduled visit date have been selected
			If visitDateSchools_ddl.SelectedIndex <> 0 Then
				SchoolID = SchoolData.GetSchoolID(visitDateSchools_ddl.SelectedValue)
				SQLStatement = SQLStatement & " AND vo.schoolID = '" & SchoolID & "'"


				'Load total SV hours
				TotalSVHours(visitDate_tb.Text, visitDateSchools_ddl.SelectedValue)
			Else
				SQLStatement = SQLStatement

				'Load total SV hours
				TotalSVHours(visitDate_tb.Text)
			End If

		Else
			SQLStatement = SQLStatement
		End If

		'Check if school name has been selected
		If schoolName_ddl.SelectedValue <> Nothing Or schoolName_ddl.SelectedValue <> "" Then
			SchoolID = SchoolData.GetSchoolID(schoolName_ddl.SelectedValue)
			SQLStatement = SQLStatement & " WHERE vo.schoolID = '" & SchoolID & "'"

			'Load total SV hours
			TotalSVHours(Nothing, schoolName_ddl.SelectedValue)

			'Check if specific visit date of selected school has been selected
			If schoolVisitDate_ddl.SelectedIndex <> 0 Then
				VIDOfDate = VisitData.GetVisitIDFromDate(schoolVisitDate_ddl.SelectedValue)
				SQLStatement = SQLStatement & " AND vo.visitID = '" & VIDOfDate & "'"

				'Load total SV hours
				TotalSVHours(schoolVisitDate_ddl.SelectedValue, schoolName_ddl.SelectedValue)
			Else
				SQLStatement = SQLStatement

				'Load total SV hours
				TotalSVHours(Nothing, schoolName_ddl.SelectedValue)
			End If

		Else
			SQLStatement = SQLStatement
		End If

		'Check if search bar is filled
		If search_tb.Text <> Nothing Or search_tb.Text <> "" Then
			SQLStatement = SQLStatement & " WHERE vo.firstName LIKE '%" & search_tb.Text & "%' OR vo.lastName LIKE '%" & search_tb.Text & "%'"
		Else
			SQLStatement = SQLStatement
		End If

		'Check if sorted DDL is selected
		If sortBy_ddl.SelectedIndex <> 0 Or ascDesc_ddl.SelectedIndex <> 0 Then

			'Add order by to SQLStatement
			SQLStatement = SQLStatement & " ORDER BY "

			'Check sorting DDLs
			If sortBy_ddl.SelectedValue = "Recently Added" Then
				SQLStatement = SQLStatement & "vo.id "
			ElseIf sortBy_ddl.SelectedValue = "First Name" Then
				SQLStatement = SQLStatement & "vo.firstName "
			ElseIf sortBy_ddl.SelectedValue = "Last Name" Then
				SQLStatement = SQLStatement & "vo.lastName "
			ElseIf sortBy_ddl.SelectedValue = "Business Name" Then
				SQLStatement = SQLStatement & "vo.businessID "
			ElseIf sortBy_ddl.SelectedValue = "School Name" Then
				SQLStatement = SQLStatement & "vo.schoolName "
			ElseIf sortBy_ddl.SelectedValue = "Visit Date" Then
				SQLStatement = SQLStatement & "vo.visitDate "
			ElseIf sortBy_ddl.SelectedValue = "PR" Then
				SQLStatement = SQLStatement & "vo.pr "
			ElseIf sortBy_ddl.SelectedValue = "SV Hours" Then
				SQLStatement = SQLStatement & "vo.svHours "
			ElseIf sortBy_ddl.SelectedValue = "Regular Volunteer" Then
				SQLStatement = SQLStatement & "vo.regular "
			End If

			If ascDesc_ddl.SelectedValue = "Ascending" Then
				SQLStatement = SQLStatement & "ASC"
			ElseIf ascDesc_ddl.SelectedValue = "Descending" Then
				SQLStatement = SQLStatement & "DESC"
			End If

		End If

		'error_lbl.Text = SQLStatement
		'Exit Sub

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
		Dim SchoolName As String
		Dim SchoolID As Integer
		Dim VisitDate As String
		Dim VIDOfDate As Integer
		Dim PR As String
		Dim SVHours As String = "6"
		Dim Regular As Boolean = False
		Dim Notes As String

		'Check for empty fields    Or businessName_ddl.SelectedIndex = 0 Or regularVol_ddl.SelectedIndex = 0 
		If firstName_tb.Text = Nothing Or lastName_tb.Text = Nothing Then
			error_lbl.Text = "Please enter a first name, last name, business, visit date, school name and regular volunteer status before submitting."
			Exit Sub
		End If

		'Check if loading from visit date or school name
		If visitDate_div.Visible = True Then
			If visitDate_tb.Text = Nothing Then
				error_lbl.Text = "Please enter a first name, last name, business, visit date, school name and regular volunteer status before submitting."
				Exit Sub
			Else
				VisitDate = visitDate_tb.Text
				VIDOfDate = VisitData.GetVisitIDFromDate(VisitDate)

				If visitDateSchools_ddl.SelectedIndex = 0 Then
					SchoolID = 0
				Else
					SchoolName = visitDateSchools_ddl.SelectedValue
					SchoolID = SchoolData.GetSchoolID(SchoolName)
				End If


			End If
		ElseIf schoolName_div.Visible = True Then
			If schoolName_ddl.SelectedIndex = 0 Or schoolVisitDate_ddl.SelectedIndex = 0 Then
				error_lbl.Text = "Please enter a first name, last name, business, visit date, school name and regular volunteer status before submitting."
				Exit Sub
			Else
				VisitDate = schoolVisitDate_ddl.SelectedValue
				SchoolName = schoolName_ddl.SelectedValue
				SchoolID = SchoolData.GetSchoolID(SchoolName)

			End If
		End If

		'Assign regular variable
		'If regularVol_ddl.SelectedValue = "No" Then
		'	Regular = False
		'Else
		'	Regular = True
		'End If

		'If SV Hours is blank
		'If svHours_tb.Text = Nothing Or svHours_tb.Text = "" Then
		'	SVHours = "0"
		'Else
		'	SVHours = svHours_tb.Text
		'End If

		'Assign fields to variables
		FirstName = firstName_tb.Text
		LastName = lastName_tb.Text
		'BusinessName = businessName_ddl.SelectedValue
		PR = pr_ddl.SelectedValue
		Notes = notes_tb.Text

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
			cmd.CommandText = "INSERT INTO volunteers (visitID, schoolID, businessID, firstName, lastName, pr, svHours, notes, regular)
                                VALUES ('" & VIDOfDate & "', '" & SchoolID & "', '0', '" & FirstName & "', '" & LastName & "', '" & PR & "', '" & SVHours & "', '" & Notes & "', '" & Regular & "')"

			cmd.ExecuteNonQuery()
			cmd.Dispose()
			con.Close()
		Catch
			error_lbl.Text = "Error in SubmitVolunteer(). Could not add the volunteer."
			Exit Sub
		End Try

		'Clear out text boxes and set cursor to first name
		firstName_tb.Text = ""
		lastName_tb.Text = ""
		firstName_tb.Focus()

		'Load table
		LoadData()

	End Sub

	Sub SubmitCheckIn()
		Dim SQLStatement As String
		Dim VisitDate As String = visitDate_tb.Text
		Dim VIDOfDate As Integer = VisitData.GetVisitIDFromDate(VisitDate)
		Dim AchVol, AchReg, AstVol, AstReg, BayVol, BayReg, BBBVol, BBBReg, BicVol, BicReg, CitVol, CitReg, MixVol, MixReg, UPSVol, UPSReg, CVSVol, CVSReg, DitVol,
		DitReg, DukeVol, DukeReg, HSNVol, HSNReg, KanesVol, KanesReg, McDVol, McDReg, UWVol, UWReg, DaliVol, DaliReg, PCSWVol, PCSWReg, KnowVol,
		KnowReg, BucsVol, BucsReg, RaysVol, RaysReg, TimesVol, TimesReg, TDVol, TDReg, PCUVol, PCUReg As String

		'Check for bodies and assign variables

		'Check for achieva bodies
		If ach_tb.Text = "" Then
			AchVol = "0"
		Else
			AchVol = ach_tb.Text
		End If

		If regVolAch_ddl.SelectedIndex <> 0 Then
			AchReg = regVolAch_ddl.SelectedValue
		Else
			AchReg = "None"
		End If

		'Check for astro bodies
		If astro_tb.Text = "" Then
			AstVol = "0"
		Else
			AstVol = astro_tb.Text
		End If

		If regVolAstro_ddl.SelectedIndex <> 0 Then
			AstReg = regVolAstro_ddl.SelectedValue
		Else
			AstReg = "None"
		End If

		'Check for Baycare bodies
		If baycare_tb.Text = "" Then
			BayVol = "0"
		Else
			BayVol = baycare_tb.Text
		End If

		If regVolBaycare_ddl.SelectedIndex <> 0 Then
			BayReg = regVolBaycare_ddl.SelectedValue
		Else
			BayReg = "None"
		End If

		'Check bbb bodies
		If bbb_tb.Text = "" Then
			BBBVol = "0"
		Else
			BBBVol = bbb_tb.Text
		End If

		If regVolBBB_ddl.SelectedIndex <> 0 Then
			BBBReg = regVolBBB_ddl.SelectedValue
		Else
			BBBReg = "None"
		End If

		'Check koozie bodies
		If bic_tb.Text = "" Then
			BicVol = "0"
		Else
			BicVol = bic_tb.Text
		End If

		If regVolBic_ddl.SelectedIndex <> 0 Then
			BicReg = regVolBic_ddl.SelectedValue
		Else
			BicReg = "None"
		End If

		'Check for city hall bodies
		If city_tb.Text = "" Then
			CitVol = "0"
		Else
			CitVol = city_tb.Text
		End If

		If regVolCity_ddl.SelectedIndex <> 0 Then
			CitReg = regVolCity_ddl.SelectedValue
		Else
			CitReg = "None"
		End If

		'Check for mix bodies
		If mix_tb.Text = "" Then
			MixVol = "0"
		Else
			MixVol = mix_tb.Text
		End If

		If regVolMix_ddl.SelectedIndex <> 0 Then
			MixReg = regVolMix_ddl.SelectedValue
		Else
			MixReg = "None"
		End If

		'Check for ups bodies
		If ups_tb.Text = "" Then
			UPSVol = "0"
		Else
			UPSVol = ups_tb.Text
		End If

		If regVolUPS_ddl.SelectedIndex <> 0 Then
			UPSReg = regVolUPS_ddl.SelectedValue
		Else
			UPSReg = "None"
		End If

		'Check cvs bodies
		If cvs_tb.Text = "" Then
			CVSVol = "0"
		Else
			CVSVol = cvs_tb.Text
		End If

		If regVolCVS_ddl.SelectedIndex <> 0 Then
			CVSReg = regVolCVS_ddl.SelectedValue
		Else
			CVSReg = "None"
		End If

		'Check ditek bodies
		If ditek_tb.Text = "" Then
			DitVol = "0"
		Else
			DitVol = ditek_tb.Text
		End If

		If regVolDitek_ddl.SelectedIndex <> 0 Then
			DitReg = regVolDitek_ddl.SelectedValue
		Else
			DitReg = "None"
		End If

		'Check duke energy bodies
		If duke_tb.Text = "" Then
			DukeVol = "0"
		Else
			DukeVol = duke_tb.Text
		End If

		If regVolDuke_ddl.SelectedIndex <> 0 Then
			DukeReg = regVolDuke_ddl.SelectedValue
		Else
			DukeReg = "None"
		End If

		'Check hsn bodies
		If hsn_tb.Text = "" Then
			HSNVol = "0"
		Else
			HSNVol = hsn_tb.Text
		End If

		If regVolHSN_ddl.SelectedIndex <> 0 Then
			HSNReg = regVolHSN_ddl.SelectedValue
		Else
			HSNReg = "None"
		End If

		'Check kanes bodies
		If kanes_tb.Text = "" Then
			KanesVol = "0"
		Else
			KanesVol = kanes_tb.Text
		End If

		If regVolKanes_ddl.SelectedIndex <> 0 Then
			KanesReg = regVolKanes_ddl.SelectedValue
		Else
			KanesReg = "None"
		End If

		'Check mcdonalds bodies
		If mcdonalds_tb.Text = "" Then
			McDVol = "0"
		Else
			McDVol = mcdonalds_tb.Text
		End If

		If regVolMcdonalds_ddl.SelectedIndex <> 0 Then
			McDReg = regVolMcdonalds_ddl.SelectedValue
		Else
			McDReg = "None"
		End If

		'Check united way bodies
		If united_tb.Text = "" Then
			UWVol = "0"
		Else
			UWVol = united_tb.Text
		End If

		If regVolUnited_ddl.SelectedIndex <> 0 Then
			UWReg = regVolUnited_ddl.SelectedValue
		Else
			UWReg = "None"
		End If

		'Check dali bodies
		If dali_tb.Text = "" Then
			DaliVol = "0"
		Else
			DaliVol = dali_tb.Text
		End If

		If regVolDali_ddl.SelectedIndex <> 0 Then
			DaliReg = regVolDali_ddl.SelectedValue
		Else
			DaliReg = "None"
		End If

		'Check pcsw bodies
		If pcsw_tb.Text = "" Then
			PCSWVol = "0"
		Else
			PCSWVol = pcsw_tb.Text
		End If

		If regVolPCSW_ddl.SelectedIndex <> 0 Then
			PCSWReg = regVolPCSW_ddl.SelectedValue
		Else
			PCSWReg = "None"
		End If

		'Check knowbe4 bodies
		If know_tb.Text = "" Then
			KnowVol = "0"
		Else
			KnowVol = know_tb.Text
		End If

		If regVolKnow_ddl.SelectedIndex <> 0 Then
			KnowReg = regVolKnow_ddl.SelectedValue
		Else
			KnowReg = "None"
		End If

		'Check bucs bodies
		If bucs_tb.Text = "" Then
			BucsVol = "0"
		Else
			BucsVol = bucs_tb.Text
		End If

		If regVolBucs_ddl.SelectedIndex <> 0 Then
			BucsReg = regVolBucs_ddl.SelectedValue
		Else
			BucsReg = "None"
		End If

		'Check rays bodies
		If rays_tb.Text = "" Then
			RaysVol = "0"
		Else
			RaysVol = rays_tb.Text
		End If

		If regVolRays_ddl.SelectedIndex <> 0 Then
			RaysReg = regVolRays_ddl.SelectedValue
		Else
			RaysReg = "None"
		End If

		'Check times bodies
		If times_tb.Text = "" Then
			TimesVol = "0"
		Else
			TimesVol = times_tb.Text
		End If

		If regVolTimes_ddl.SelectedIndex <> 0 Then
			TimesReg = regVolTimes_ddl.SelectedValue
		Else
			TimesReg = "None"
		End If

		'Check td synnex bodies
		If td_tb.Text = "" Then
			TDVol = "0"
		Else
			TDVol = td_tb.Text
		End If

		If regVolTD_ddl.SelectedIndex <> 0 Then
			TDReg = regVolTD_ddl.SelectedValue
		Else
			TDReg = "None"
		End If

		'Check pcu bodies
		If pcu_tb.Text = "" Then
			PCUVol = "0"
		Else
			PCUVol = pcu_tb.Text
		End If

		If regVolPCU_ddl.SelectedIndex <> 0 Then
			PCUReg = regVolPCU_ddl.SelectedValue
		Else
			PCUReg = "None"
		End If

		'Check if visit date exists, if not, insert new entry
		Try
			con.ConnectionString = connection_string
			con.Open()
			cmd.CommandText = "SELECT visitID FROM volunteersCheckIn WHERE visitID='" & VIDOfDate & "'"
			cmd.Connection = con
			dr = cmd.ExecuteReader

			If dr.HasRows() Then
				SQLStatement = "UPDATE volunteersCheckIn 
								SET achVol='" & AchVol & "', achReg='" & AchReg & "', astroVol='" & AstVol & "', astroReg='" & AstReg & "', baycareVol='" & BayVol & "'
								, baycareReg='" & BayReg & "', bbbVol='" & BBBVol & "', bbbReg='" & BBBReg & "', bicVol='" & BicVol & "', bicReg='" & BicReg & "'
								, cityVol='" & CitVol & "', cityReg='" & CitReg & "', cvsVol='" & CVSVol & "', cvsReg='" & CVSReg & "', ditekVol='" & DitVol & "'
								, ditekReg='" & DitReg & "', dukeVol='" & DukeVol & "', dukeReg='" & DukeReg & "', kanesVol='" & KanesVol & "', kanesReg='" & KanesReg & "'
								, knowVol='" & KnowVol & "', knowReg='" & KnowReg & "', daliVol='" & DaliVol & "', daliReg='" & DaliReg & "', mcdVol='" & McDVol & "'
								, mcdReg='" & McDReg & "', mixVol='" & MixVol & "', mixReg='" & MixReg & "', pcuVol='" & PCUVol & "', pcuReg='" & PCUReg & "'
								, pcswVol='" & PCSWVol & "', pcswReg='" & PCSWReg & "', tbbucsVol='" & BucsVol & "', tbbucsReg='" & BucsReg & "', tbraysVol='" & RaysVol & "'
								, tbraysReg='" & RaysReg & "', tbtimesVol='" & TimesVol & "', tbtimesReg='" & TimesReg & "', tdVol='" & TDVol & "', tdReg='" & TDReg & "'
								, upsVol='" & UPSVol & "', upsReg='" & UPSReg & "', unitedVol='" & UWVol & "', unitedReg='" & UWReg & "', hsnVol='" & HSNVol & "', hsnReg='" & HSNReg & "'  
								WHERE visitID='" & VIDOfDate & "'"
			Else
				SQLStatement = "INSERT INTO volunteersCheckIn 
								(visitID, achVol, achReg, astroVol, astroReg, baycareVol, baycareReg, bbbVol, bbbReg, bicVol, bicReg, cityVol, cityReg,
								cvsVol, cvsReg, ditekVol, ditekReg, dukeVol, dukeReg, kanesVol, kanesReg, knowVol, knowReg, daliVol, daliReg, mcdVol, 
								mcdReg, mixVol, mixReg, pcuVol, pcuReg, pcswVol, pcswReg, tbbucsVol, tbbucsReg, tbraysVol, tbraysReg, tbtimesVol, 
								tbtimesReg, tdVol, tdReg, upsVol, upsReg, unitedVol, unitedReg, hsnVol, hsnReg)
                                VALUES ('" & VIDOfDate & "', '" & AchVol & "', '" & AchReg & "', '" & AstVol & "', '" & AstReg & "', '" & BayVol & "', '" & BayReg & "', '" & BBBVol & "', '" & BBBReg & "'
								, '" & BicVol & "', '" & BicReg & "', '" & CitVol & "', '" & CitReg & "', '" & CVSVol & "', '" & CVSReg & "', '" & DitVol & "', '" & DitReg & "', '" & DukeVol & "'
								, '" & DukeReg & "', '" & KanesVol & "', '" & KanesReg & "', '" & KnowVol & "', '" & KnowReg & "', '" & DaliVol & "', '" & DaliReg & "', '" & McDVol & "', '" & McDReg & "'
								, '" & MixVol & "', '" & MixReg & "', '" & PCUVol & "', '" & PCUReg & "', '" & PCSWVol & "', '" & PCSWReg & "', '" & BucsVol & "', '" & BucsReg & "', '" & RaysVol & "'
								, '" & RaysReg & "', '" & TimesVol & "', '" & TimesReg & "', '" & TDVol & "', '" & TDReg & "', '" & UPSVol & "', '" & UPSReg & "', '" & UWVol & "', '" & UWReg & "', '" & HSNVol & "', '" & HSNReg & "')"
			End If

			cmd.Dispose()
			con.Close()

		Catch
			error_lbl.Text = "Error in SubmitCheckIn(). Could not detect selected visit date in database."
			Exit Sub
		End Try

		cmd.Dispose()
		con.Close()

		'Submit data into SQL server
		Try
			con.ConnectionString = connection_string
			con.Open()
			cmd.Connection = con
			cmd.CommandText = SQLStatement

			cmd.ExecuteNonQuery()

			error_lbl.Text = "Successfully updated volunteer check in for " & VisitDate

			cmd.Dispose()
			con.Close()
		Catch
			error_lbl.Text = "Error in SubmitCheckIn(). Could not complete the check in process."
			Exit Sub
		End Try

		cmd.Dispose()
		con.Close()

	End Sub

	Sub Textboxes()
		Dim count As Integer = 1
		Dim VIDOfDate As Integer = VisitData.GetVisitIDFromDate(visitDate_tb.Text)

		'Clear text boxes
		bucs_tb.Text = ""
		rays_tb.Text = ""
		cvs_tb.Text = ""
		kanes_tb.Text = ""
		bic_tb.Text = ""
		td_tb.Text = ""
		hsn_tb.Text = ""
		bbb_tb.Text = ""
		astro_tb.Text = ""
		ditek_tb.Text = ""
		ach_tb.Text = ""
		baycare_tb.Text = ""
		city_tb.Text = ""
		dali_tb.Text = ""
		duke_tb.Text = ""
		mcdonalds_tb.Text = ""
		mix_tb.Text = ""
		pcsw_tb.Text = ""
		pcu_tb.Text = ""
		know_tb.Text = ""
		times_tb.Text = ""
		ups_tb.Text = ""
		united_tb.Text = ""

		'Reset DDLs
		regVolAch_ddl.SelectedIndex = 0
		regVolAstro_ddl.SelectedIndex = 0
		regVolBaycare_ddl.SelectedIndex = 0
		regVolBBB_ddl.SelectedIndex = 0
		regVolBic_ddl.SelectedIndex = 0
		regVolBucs_ddl.SelectedIndex = 0
		regVolCity_ddl.SelectedIndex = 0
		regVolCVS_ddl.SelectedIndex = 0
		regVolDali_ddl.SelectedIndex = 0
		regVolDitek_ddl.SelectedIndex = 0
		regVolDuke_ddl.SelectedIndex = 0
		regVolHSN_ddl.SelectedIndex = 0
		regVolKanes_ddl.SelectedIndex = 0
		regVolKnow_ddl.SelectedIndex = 0
		regVolMcdonalds_ddl.SelectedIndex = 0
		regVolMix_ddl.SelectedIndex = 0
		regVolPCSW_ddl.SelectedIndex = 0
		regVolPCU_ddl.SelectedIndex = 0
		regVolRays_ddl.SelectedIndex = 0
		regVolTD_ddl.SelectedIndex = 0
		regVolTimes_ddl.SelectedIndex = 0
		regVolUnited_ddl.SelectedIndex = 0
		regVolUPS_ddl.SelectedIndex = 0

		'Get opened and closed businesses for selected visit date and enable checkboxes for opened businesses
		While count < 25
			If count = 4 Then
				count = count + 1
			Else
				Try
					con.ConnectionString = connection_string
					con.Open()
					cmd.CommandText = "SELECT o.businessID, o.openstatus, s.schoolName
								FROM businessVisitInfo o
								INNER JOIN schoolInfo s
								ON s.id = o.schoolID
								WHERE o.visitID='" & VIDOfDate & "' AND o.businessID='" & count & "' 
								AND o.openstatus=1
								ORDER BY o.businessID"
					cmd.Connection = con
					dr = cmd.ExecuteReader

					While dr.Read()

						'Check for rows
						If dr.HasRows = True Then

							'If business ID equals the count number then check the boxes
							If dr("businessID") = count Then
								businessCount_ddl.SelectedValue = count

								Select Case businessCount_ddl.SelectedValue
									Case "1"
										bucs_tb.Enabled = True
										regVolBucs_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = visitDateSchools_ddl.Items(1).Value Then
											bucs_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(2).Value Then
											bucs_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(3).Value Then
											bucs_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(4).Value Then
											bucs_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(5).Value Then
											bucs_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "2"
										rays_tb.Enabled = True
										regVolRays_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = visitDateSchools_ddl.Items(1).Value Then
											rays_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(2).Value Then
											rays_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(3).Value Then
											rays_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(4).Value Then
											rays_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(5).Value Then
											rays_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "3"
										cvs_tb.Enabled = True
										regVolCVS_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = visitDateSchools_ddl.Items(1).Value Then
											cvs_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(2).Value Then
											cvs_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(3).Value Then
											cvs_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(4).Value Then
											cvs_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(5).Value Then
											cvs_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "5"
										kanes_tb.Enabled = True
										regVolKanes_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = visitDateSchools_ddl.Items(1).Value Then
											kanes_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(2).Value Then
											kanes_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(3).Value Then
											kanes_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(4).Value Then
											kanes_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(5).Value Then
											kanes_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "6"
										bic_tb.Enabled = True
										regVolBic_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = visitDateSchools_ddl.Items(1).Value Then
											bic_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(2).Value Then
											bic_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(3).Value Then
											bic_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(4).Value Then
											bic_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(5).Value Then
											bic_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "7"
										td_tb.Enabled = True
										regVolTD_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = visitDateSchools_ddl.Items(1).Value Then
											td_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(2).Value Then
											td_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(3).Value Then
											td_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(4).Value Then
											td_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(5).Value Then
											td_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "8"
										hsn_tb.Enabled = True
										regVolHSN_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = visitDateSchools_ddl.Items(1).Value Then
											hsn_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(2).Value Then
											hsn_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(3).Value Then
											hsn_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(4).Value Then
											hsn_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(5).Value Then
											hsn_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "9"
										bbb_tb.Enabled = True
										regVolBBB_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = visitDateSchools_ddl.Items(1).Value Then
											bbb_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(2).Value Then
											bbb_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(3).Value Then
											bbb_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(4).Value Then
											bbb_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(5).Value Then
											bbb_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "10"
										astro_tb.Enabled = True
										regVolAstro_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = visitDateSchools_ddl.Items(1).Value Then
											astro_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(2).Value Then
											astro_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(3).Value Then
											astro_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(4).Value Then
											astro_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(5).Value Then
											astro_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "11"
										ditek_tb.Enabled = True
										regVolDitek_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = visitDateSchools_ddl.Items(1).Value Then
											ditek_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(2).Value Then
											ditek_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(3).Value Then
											ditek_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(4).Value Then
											ditek_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(5).Value Then
											ditek_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "12"
										ach_tb.Enabled = True
										regVolAch_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = visitDateSchools_ddl.Items(1).Value Then
											ach_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(2).Value Then
											ach_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(3).Value Then
											ach_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(4).Value Then
											ach_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(5).Value Then
											ach_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "13"
										baycare_tb.Enabled = True
										regVolBaycare_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = visitDateSchools_ddl.Items(1).Value Then
											baycare_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(2).Value Then
											baycare_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(3).Value Then
											baycare_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(4).Value Then
											baycare_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(5).Value Then
											baycare_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "14"
										city_tb.Enabled = True
										regVolCity_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = visitDateSchools_ddl.Items(1).Value Then
											city_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(2).Value Then
											city_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(3).Value Then
											city_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(4).Value Then
											city_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(5).Value Then
											city_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "15"
										dali_tb.Enabled = True
										regVolDali_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = visitDateSchools_ddl.Items(1).Value Then
											dali_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(2).Value Then
											dali_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(3).Value Then
											dali_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(4).Value Then
											dali_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(5).Value Then
											dali_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "16"
										duke_tb.Enabled = True
										regVolDuke_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = visitDateSchools_ddl.Items(1).Value Then
											duke_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(2).Value Then
											duke_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(3).Value Then
											duke_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(4).Value Then
											duke_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(5).Value Then
											duke_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "17"
										mcdonalds_tb.Enabled = True
										regVolMcdonalds_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = visitDateSchools_ddl.Items(1).Value Then
											mcdonalds_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(2).Value Then
											mcdonalds_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(3).Value Then
											mcdonalds_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(4).Value Then
											mcdonalds_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(5).Value Then
											mcdonalds_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "18"
										mix_tb.Enabled = True
										regVolMix_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = visitDateSchools_ddl.Items(1).Value Then
											mix_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(2).Value Then
											mix_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(3).Value Then
											mix_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(4).Value Then
											mix_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(5).Value Then
											mix_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "19"
										pcsw_tb.Enabled = True
										regVolPCSW_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = visitDateSchools_ddl.Items(1).Value Then
											pcsw_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(2).Value Then
											pcsw_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(3).Value Then
											pcsw_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(4).Value Then
											pcsw_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(5).Value Then
											pcsw_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "20"
										pcu_tb.Enabled = True
										regVolPCU_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = visitDateSchools_ddl.Items(1).Value Then
											pcu_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(2).Value Then
											pcu_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(3).Value Then
											pcu_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(4).Value Then
											pcu_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(5).Value Then
											pcu_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "21"
										know_tb.Enabled = True
										regVolKnow_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = visitDateSchools_ddl.Items(1).Value Then
											know_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(2).Value Then
											know_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(3).Value Then
											know_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(4).Value Then
											know_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(5).Value Then
											know_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "22"
										times_tb.Enabled = True
										regVolTimes_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = visitDateSchools_ddl.Items(1).Value Then
											times_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(2).Value Then
											times_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(3).Value Then
											times_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(4).Value Then
											times_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(5).Value Then
											times_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "23"
										ups_tb.Enabled = True
										regVolUPS_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = visitDateSchools_ddl.Items(1).Value Then
											ups_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(2).Value Then
											ups_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(3).Value Then
											ups_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(4).Value Then
											ups_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(5).Value Then
											ups_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "24"
										united_tb.Enabled = True
										regVolUnited_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = visitDateSchools_ddl.Items(1).Value Then
											united_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(2).Value Then
											united_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(3).Value Then
											united_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(4).Value Then
											united_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = visitDateSchools_ddl.Items(5).Value Then
											united_a.Attributes.CssStyle.Add("color", "orange")
										End If

								End Select
							End If
						Else

							Exit While
						End If

					End While

					cmd.Dispose()
					con.Close()

				Catch
					error_lbl.Text = "Error in Textboxes(). Could not get business open information. "
					cmd.Dispose()
					con.Close()
					Exit Sub
				End Try

				cmd.Dispose()
				con.Close()

				'Increase count number
				count = count + 1
			End If
		End While

		LoadData()

	End Sub

	Sub TotalSVHours(Optional VisitDate As String = Nothing, Optional SchoolName As String = Nothing)
		Dim SQLStatement As String = "SELECT SUM(svHours) as svHours FROM volunteers WHERE "
		Dim VIDOfDate As Integer = VisitData.GetVisitIDFromDate(VisitDate)
		Dim SchoolID As Integer = SchoolData.GetSchoolID(SchoolName)

		'Check if load by visit date or load by school name is active
		If visitDate_tb.Text <> Nothing Then
			SQLStatement += "visitID= '" & VIDOfDate & "' "

			If visitDateSchools_ddl.SelectedIndex <> 0 Then
				SQLStatement += " AND schoolID= '" & SchoolID & "' "
			End If
		End If

		If schoolName_ddl.SelectedIndex <> 0 Then
			SQLStatement += "schoolID = '" & SchoolID & "' "

			If schoolVisitDate_ddl.SelectedIndex <> 0 Then
				SQLStatement += " AND visitID = '" & VIDOfDate & "' "
			End If
		End If

		'Get total hours and apply it to label
		Try
			con.Close()
			con.ConnectionString = connection_string
			con.Open()
			cmd.CommandText = SQLStatement
			cmd.Connection = con
			dr = cmd.ExecuteReader

			While dr.Read()
				totalSVHours_lbl.Text = dr("svHours").ToString
			End While

		Catch ex As Exception
			error_lbl.Text = "Error in TotalSVHours(). Could not get total sv hours."
			Exit Sub
		End Try

		cmd.Dispose()
		con.Close()

	End Sub

	Sub PopulateVolDDL()
		LoadRegVolDDL(regVolAch_ddl)
		LoadRegVolDDL(regVolAstro_ddl)
		LoadRegVolDDL(regVolBaycare_ddl)
		LoadRegVolDDL(regVolBBB_ddl)
		LoadRegVolDDL(regVolBic_ddl)
		LoadRegVolDDL(regVolBucs_ddl)
		LoadRegVolDDL(regVolCity_ddl)
		LoadRegVolDDL(regVolCVS_ddl)
		LoadRegVolDDL(regVolDali_ddl)
		LoadRegVolDDL(regVolDitek_ddl)
		LoadRegVolDDL(regVolDuke_ddl)
		LoadRegVolDDL(regVolHSN_ddl)
		LoadRegVolDDL(regVolKanes_ddl)
		LoadRegVolDDL(regVolKnow_ddl)
		LoadRegVolDDL(regVolMcdonalds_ddl)
		LoadRegVolDDL(regVolMix_ddl)
		LoadRegVolDDL(regVolPCSW_ddl)
		LoadRegVolDDL(regVolPCU_ddl)
		LoadRegVolDDL(regVolRays_ddl)
		LoadRegVolDDL(regVolTD_ddl)
		LoadRegVolDDL(regVolTimes_ddl)
		LoadRegVolDDL(regVolUnited_ddl)
		LoadRegVolDDL(regVolUPS_ddl)
	End Sub

	Function LoadRegVolDDL(DDL As DropDownList)

		'Get all first names of regular volunteers from volunteers table and load them into the check in DDLs
		Try
			con.ConnectionString = connection_string
			con.Open()
			cmd.CommandText = "SELECT firstName FROM volunteers WHERE regular=1 ORDER BY firstName ASC"
			cmd.Connection = con
			dr = cmd.ExecuteReader()

			While dr.Read()
				DDL.Items.Add(dr(0).ToString)
			End While
			DDL.Items.Insert(0, "None")

			cmd.Dispose()
			con.Close()

			Return DDL.Items

		Catch ex As Exception
			error_lbl.Text = "Error in LoadRegVolDDL(). Could not load regular volunteer DDLs."
			Exit Function
		End Try

		Return DDL.Items

	End Function

	Sub LoadVolCheckIn(VisitDate As String)
		Dim VIDOfDate As Integer = VisitData.GetVisitIDFromDate(VisitDate)
		Dim CheckInSQL As String = "SELECT * FROM volunteersCheckIn WHERE visitID = '" & VIDOfDate & "'"

		'Clear text boxes
		bucs_tb.Text = ""
		rays_tb.Text = ""
		cvs_tb.Text = ""
		kanes_tb.Text = ""
		bic_tb.Text = ""
		td_tb.Text = ""
		hsn_tb.Text = ""
		bbb_tb.Text = ""
		astro_tb.Text = ""
		ditek_tb.Text = ""
		ach_tb.Text = ""
		baycare_tb.Text = ""
		city_tb.Text = ""
		dali_tb.Text = ""
		duke_tb.Text = ""
		mcdonalds_tb.Text = ""
		mix_tb.Text = ""
		pcsw_tb.Text = ""
		pcu_tb.Text = ""
		know_tb.Text = ""
		times_tb.Text = ""
		ups_tb.Text = ""
		united_tb.Text = ""

		'Reset DDLs
		regVolAch_ddl.SelectedIndex = 0
		regVolAstro_ddl.SelectedIndex = 0
		regVolBaycare_ddl.SelectedIndex = 0
		regVolBBB_ddl.SelectedIndex = 0
		regVolBic_ddl.SelectedIndex = 0
		regVolBucs_ddl.SelectedIndex = 0
		regVolCity_ddl.SelectedIndex = 0
		regVolCVS_ddl.SelectedIndex = 0
		regVolDali_ddl.SelectedIndex = 0
		regVolDitek_ddl.SelectedIndex = 0
		regVolDuke_ddl.SelectedIndex = 0
		regVolHSN_ddl.SelectedIndex = 0
		regVolKanes_ddl.SelectedIndex = 0
		regVolKnow_ddl.SelectedIndex = 0
		regVolMcdonalds_ddl.SelectedIndex = 0
		regVolMix_ddl.SelectedIndex = 0
		regVolPCSW_ddl.SelectedIndex = 0
		regVolPCU_ddl.SelectedIndex = 0
		regVolRays_ddl.SelectedIndex = 0
		regVolTD_ddl.SelectedIndex = 0
		regVolTimes_ddl.SelectedIndex = 0
		regVolUnited_ddl.SelectedIndex = 0
		regVolUPS_ddl.SelectedIndex = 0

		'Load data from volunteers Check in table and assign it to the textboxes and DDLs
		Try
			con.ConnectionString = connection_string
			con.Open()
			cmd.CommandText = CheckInSQL
			cmd.Connection = con
			dr = cmd.ExecuteReader

			If dr.HasRows Then
				While dr.Read()
					ach_tb.Text = dr("achVol").ToString
					regVolAch_ddl.SelectedValue = dr("achReg").ToString
					astro_tb.Text = dr("astroVol").ToString
					regVolAstro_ddl.SelectedValue = dr("astroReg").ToString
					baycare_tb.Text = dr("baycareVol").ToString
					regVolBaycare_ddl.SelectedValue = dr("baycareReg").ToString
					bbb_tb.Text = dr("bbbVol").ToString
					regVolBBB_ddl.SelectedValue = dr("bbbReg").ToString
					bic_tb.Text = dr("bicVol").ToString
					regVolBic_ddl.SelectedValue = dr("bicReg").ToString
					city_tb.Text = dr("cityVol").ToString
					regVolCity_ddl.SelectedValue = dr("cityReg").ToString
					cvs_tb.Text = dr("cvsVol").ToString
					regVolCVS_ddl.SelectedValue = dr("cvsReg").ToString
					ditek_tb.Text = dr("ditekVol").ToString
					regVolDitek_ddl.SelectedValue = dr("ditekReg").ToString
					duke_tb.Text = dr("dukeVol").ToString
					regVolDuke_ddl.SelectedValue = dr("dukeReg").ToString
					kanes_tb.Text = dr("kanesVol").ToString
					regVolKanes_ddl.SelectedValue = dr("kanesReg").ToString
					know_tb.Text = dr("knowVol").ToString
					regVolKnow_ddl.SelectedValue = dr("knowReg").ToString
					dali_tb.Text = dr("daliVol").ToString
					regVolDali_ddl.SelectedValue = dr("daliReg").ToString
					mcdonalds_tb.Text = dr("mcdVol").ToString
					regVolMcdonalds_ddl.SelectedValue = dr("mcdReg").ToString
					mix_tb.Text = dr("mixVol").ToString
					regVolMix_ddl.SelectedValue = dr("mixReg").ToString
					pcu_tb.Text = dr("pcuVol").ToString
					regVolPCU_ddl.SelectedValue = dr("pcuReg").ToString
					pcsw_tb.Text = dr("pcswVol").ToString
					regVolPCSW_ddl.SelectedValue = dr("pcswReg").ToString
					bucs_tb.Text = dr("tbbucsVol").ToString
					regVolBucs_ddl.SelectedValue = dr("tbbucsReg").ToString
					rays_tb.Text = dr("tbraysVol").ToString
					regVolRays_ddl.SelectedValue = dr("tbraysReg").ToString
					times_tb.Text = dr("tbtimesVol").ToString
					regVolTimes_ddl.SelectedValue = dr("tbtimesReg").ToString
					td_tb.Text = dr("tdVol").ToString
					regVolTD_ddl.SelectedValue = dr("tdReg").ToString
					ups_tb.Text = dr("upsVol").ToString
					regVolUPS_ddl.SelectedValue = dr("upsReg").ToString
					united_tb.Text = dr("unitedVol").ToString
					regVolUnited_ddl.SelectedValue = dr("unitedReg").ToString
					hsn_tb.Text = dr("hsnVol").ToString
					regVolHSN_ddl.SelectedValue = dr("hsnReg").ToString
				End While

				'Change submit button to update
				submitCheckIn_btn.Text = "Update"

			Else
				'Change submit button to update
				submitCheckIn_btn.Text = "Submit"
			End If

			cmd.Dispose()
			con.Close()

		Catch
			error_lbl.Text = "Error in LoadData(). Could not load volunteer check in information."
			Exit Sub
		End Try

		cmd.Dispose()
		con.Close()

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



	Private Sub volunteers_dgv_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles volunteers_dgv.RowUpdating
		Dim row As GridViewRow = volunteers_dgv.Rows(0)                           'Code is used to enable the editing prodecure
		Dim ID As Integer = Convert.ToInt32(volunteers_dgv.DataKeys(e.RowIndex).Values(0)) 'Gets id number
		Dim firstName As String = TryCast(volunteers_dgv.Rows(e.RowIndex).FindControl("firstNameDGV_tb"), TextBox).Text 'Try cast is used to try to convert - gets item from ddl
		Dim lastName As String = TryCast(volunteers_dgv.Rows(e.RowIndex).FindControl("lastNameDGV_tb"), TextBox).Text
		Dim businessID As String = TryCast(volunteers_dgv.Rows(e.RowIndex).FindControl("businessNameDGV_ddl"), DropDownList).SelectedValue.ToString
		Dim schoolID As String = TryCast(volunteers_dgv.Rows(e.RowIndex).FindControl("schoolNameDGV_ddl"), DropDownList).SelectedValue.ToString
		Dim visitDate As String = TryCast(volunteers_dgv.Rows(e.RowIndex).FindControl("visitDateDGV_tb"), TextBox).Text
		Dim pr As String = TryCast(volunteers_dgv.Rows(e.RowIndex).FindControl("prDGV_ddl"), DropDownList).SelectedValue.ToString
		Dim svHours As String = TryCast(volunteers_dgv.Rows(e.RowIndex).FindControl("svHoursDGV_tb"), TextBox).Text
		Dim notes As String = TryCast(volunteers_dgv.Rows(e.RowIndex).FindControl("notesDGV_tb"), TextBox).Text
		Dim regular As String = TryCast(volunteers_dgv.Rows(e.RowIndex).FindControl("regularDGV_chk"), CheckBox).Checked
		Dim VIDOfDate As String

		'Get visit ID of date
		Try
			VIDOfDate = VisitData.GetVisitIDFromDate(visitDate)
		Catch ex As Exception
			error_lbl.Text = "Error in Updating(). Could not get visit ID of date entered."
			Exit Sub
		End Try

		'Check if visit date entered is an existing visit date
		If VIDOfDate = Nothing Or VIDOfDate = "0" Then
			error_lbl.Text = "No visit scheduled for entered visit date. Please create a visit for that date or enter a different date that has already been created."
			Exit Sub
		End If

		'Update volunteers table
		Try
			Using con As New SqlConnection(connection_string)
				Using cmd As New SqlCommand("UPDATE volunteers SET firstName=@firstName, lastName=@lastName, businessID=@businessID, schoolID=@schoolID, visitID=@visitID, pr=@pr, svHours=@svHours, notes=@notes, regular=@regular WHERE ID=@Id")
					cmd.Parameters.AddWithValue("@ID", ID)
					cmd.Parameters.AddWithValue("@firstName", firstName)
					cmd.Parameters.AddWithValue("@lastName", lastName)
					cmd.Parameters.AddWithValue("@businessID", businessID)
					cmd.Parameters.AddWithValue("@schoolID", schoolID)
					cmd.Parameters.AddWithValue("@visitID", VIDOfDate)
					cmd.Parameters.AddWithValue("@pr", pr)
					cmd.Parameters.AddWithValue("@svHours", svHours)
					cmd.Parameters.AddWithValue("@notes", notes)
					cmd.Parameters.AddWithValue("@regular", regular)
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
			Dim lblSchool As String = CType(e.Row.FindControl("schoolNameDGV_lbl"), Label).Text

			If visitDate_tb.Text <> "" Then
				ddlSchool.DataSource = GetData("SELECT s.id, s.schoolName as 'schoolName' FROM schoolInfo s JOIN visitInfo v ON v.school = s.id OR v.school2 = s.id OR v.school3 = s.id OR v.school4 = s.id OR v.school5 = s.id WHERE v.visitDate='" & visitDate_tb.Text & "' AND NOT s.id=505 ORDER BY schoolName")
			Else
				ddlSchool.DataSource = GetData("SELECT id, schoolName FROM schoolInfo WHERE NOT (schoolName = 'A1 No School Scheduled') AND NOT id='505' ORDER BY schoolName ASC")
			End If

			ddlSchool.DataTextField = "schoolName"
			ddlSchool.DataValueField = "id"
			ddlSchool.DataBind()
			ddlSchool.Items.Insert(0, " ")

			'Select index 0 if school ID is 0, otherwise, select the school name associated with the ID
			If lblSchool = "0" Then
				ddlSchool.Items.Item(0).Selected = True
			Else
				ddlSchool.Items.FindByValue(lblSchool).Selected = True
			End If

			'Assign different colors for visit dates
			If visitDateSchools_ddl.Visible = True Then
				Select Case visitDateSchools_ddl.Items.Count
					Case 2
						If lblSchool = SchoolData.GetSchoolID(visitDateSchools_ddl.Items(1).Value) Then
							e.Row.BackColor = ColorTranslator.FromHtml("#afd8ff")
						End If
					Case 3
						If lblSchool = SchoolData.GetSchoolID(visitDateSchools_ddl.Items(1).Value) Then
							e.Row.BackColor = ColorTranslator.FromHtml("#afd8ff")
						ElseIf lblSchool = SchoolData.GetSchoolID(visitDateSchools_ddl.Items(2).Value) Then
							e.Row.BackColor = ColorTranslator.FromHtml("#ffafaf")
						End If
					Case 4
						If lblSchool = SchoolData.GetSchoolID(visitDateSchools_ddl.Items(1).Value) Then
							e.Row.BackColor = ColorTranslator.FromHtml("#afd8ff")
						ElseIf lblSchool = SchoolData.GetSchoolID(visitDateSchools_ddl.Items(2).Value) Then
							e.Row.BackColor = ColorTranslator.FromHtml("#ffafaf")
						ElseIf lblSchool = SchoolData.GetSchoolID(visitDateSchools_ddl.Items(3).Value) Then
							e.Row.BackColor = ColorTranslator.FromHtml("#bfffaf")
						End If
					Case 5
						If lblSchool = SchoolData.GetSchoolID(visitDateSchools_ddl.Items(1).Value) Then
							e.Row.BackColor = ColorTranslator.FromHtml("#afd8ff")
						ElseIf lblSchool = SchoolData.GetSchoolID(visitDateSchools_ddl.Items(2).Value) Then
							e.Row.BackColor = ColorTranslator.FromHtml("#ffafaf")
						ElseIf lblSchool = SchoolData.GetSchoolID(visitDateSchools_ddl.Items(3).Value) Then
							e.Row.BackColor = ColorTranslator.FromHtml("#bfffaf")
						ElseIf lblSchool = SchoolData.GetSchoolID(visitDateSchools_ddl.Items(4).Value) Then
							e.Row.BackColor = ColorTranslator.FromHtml("#afc3ff")
						End If
					Case 6
						If lblSchool = SchoolData.GetSchoolID(visitDateSchools_ddl.Items(1).Value) Then
							e.Row.BackColor = ColorTranslator.FromHtml("#afd8ff")
						ElseIf lblSchool = SchoolData.GetSchoolID(visitDateSchools_ddl.Items(2).Value) Then
							e.Row.BackColor = ColorTranslator.FromHtml("#ffafaf")
						ElseIf lblSchool = SchoolData.GetSchoolID(visitDateSchools_ddl.Items(3).Value) Then
							e.Row.BackColor = ColorTranslator.FromHtml("#bfffaf")
						ElseIf lblSchool = SchoolData.GetSchoolID(visitDateSchools_ddl.Items(4).Value) Then
							e.Row.BackColor = ColorTranslator.FromHtml("#afc3ff")
						ElseIf lblSchool = SchoolData.GetSchoolID(visitDateSchools_ddl.Items(5).Value) Then
							e.Row.BackColor = ColorTranslator.FromHtml("#ffd8af")
						End If
				End Select
			End If

			'Business Dropdown
			Dim ddlBusiness As DropDownList = CType(e.Row.FindControl("businessNameDGV_ddl"), DropDownList)
			ddlBusiness.DataSource = GetData("SELECT id, businessName FROM businessInfo ORDER BY BusinessName")
			ddlBusiness.DataTextField = "BusinessName"
			ddlBusiness.DataValueField = "id"
			ddlBusiness.DataBind()
			Dim lblBusiness As String = CType(e.Row.FindControl("businessNameDGV_lbl"), Label).Text

			ddlBusiness.Items.Insert(0, " ")

			If lblBusiness <> "0" Then
				ddlBusiness.Items.FindByValue(lblBusiness).Selected = True
			Else
				ddlBusiness.Items.Item(0).Selected = True
			End If


			'PR Dropdown
			Dim ddlPR As DropDownList = CType(e.Row.FindControl("prDGV_ddl"), DropDownList)
			Dim lblPR As String = CType(e.Row.FindControl("prDGV_lbl"), Label).Text

			ddlPR.Items.FindByValue(lblPR).Selected = True
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

	Protected Sub refresh_btn_Click(sender As Object, e As EventArgs) Handles refresh_btn.Click
		Response.Redirect("volunteer_database.aspx")
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
			checkIn_btn.Visible = False

			'Make school name section visible
			schoolName_div.Visible = True

			'Clear visit date text box and ddl from visit date section
			visitDate_tb.Text = ""
			visitDateSchools_ddl.Items.Clear()
		End If
	End Sub

	Protected Sub checkIn_btn_Click(sender As Object, e As EventArgs) Handles checkIn_btn.Click
		If checkIn_div.Visible = False Then
			checkIn_div.Visible = True
			Textboxes()
		Else
			checkIn_div.Visible = False
		End If
	End Sub

	Protected Sub submitCheckIn_btn_Click(sender As Object, e As EventArgs) Handles submitCheckIn_btn.Click
		SubmitCheckIn()
	End Sub

	Protected Sub businessAssignments_btn_Click(sender As Object, e As EventArgs) Handles businessAssignments_btn.Click
		Dim URL As String = "/pages/edit/Open_Closed_Status.aspx"
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

	Protected Sub addVol_btn_Click(sender As Object, e As EventArgs) Handles addVol_btn.Click
		'Reveal add volunteer section if not revealed
		If addVol_div.Visible = False Then
			addVol_btn.Text = "Hide New Volunteer"
			addVol_div.Visible = True
		Else
			addVol_div.Visible = False
			addVol_btn.Text = "Add New Volunteer"
		End If
	End Sub



	Protected Sub visitDate_tb_TextChanged(sender As Object, e As EventArgs) Handles visitDate_tb.TextChanged
		If visitDate_tb.Text <> Nothing Then
			visitDateSchools_ddl.Visible = True
			visitDateSchools_a.Visible = True
			buttons_div.Visible = True

			'Load schools associated with selected visit date
			SchoolData.LoadVisitDateSchoolsDDL(visitDate_tb.Text, visitDateSchools_ddl)

			'Add an option to show all the volunteers for a visit date
			visitDateSchools_ddl.Items.RemoveAt(0)
			visitDateSchools_ddl.Items.Insert(0, "Show All Schools")

			'Load data
			LoadData()
		End If
	End Sub

	Protected Sub schoolName_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles schoolName_ddl.SelectedIndexChanged
		If schoolName_ddl.SelectedIndex <> 0 Then
			schoolVisitDate_ddl.Visible = True
			schoolVisitDate_a.Visible = True
			buttons_div.Visible = True

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
		LoadData()
	End Sub

	Protected Sub visitDateSchools_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles visitDateSchools_ddl.SelectedIndexChanged
		LoadData()
	End Sub


End Class