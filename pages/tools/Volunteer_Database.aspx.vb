Imports System.IO
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Web.UI.WebControls.Expressions
Imports System.Runtime.CompilerServices
Imports System.Diagnostics.Contracts

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
	Private ScheduleVolTable As DataTable

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		'If logged out, redirect to log in
		If Session("LoggedIn") <> "1" Then
			Response.Redirect("../../default.aspx")
		End If

		If Not (IsPostBack) Then

			'Set session for scheduled vol gridviews
			ScheduleVolTable = New DataTable
			ScheduleVolTable.Columns.Add("Volunteer ID")
			ScheduleVolTable.Columns.Add("Volunteer Name")
			Session("dt") = ScheduleVolTable

			'Populating school header
			headerSchoolName_lbl.Text = SH.GetSchoolHeader()

			'Populate school name ddl in Add New Volunteer
			SchoolData.LoadSchoolsDDL(schoolNameAdd_ddl)
			SchoolData.LoadSchoolsDDL(schoolNameSchedule_ddl)

			'Populate volunteer names in ddl in Schedule Volunteers
			LoadVolunteerNameDDL(volNameSchedule_ddl)

			'Populate regular volunteer DDLs
			PopulateVolDDL()

			'Load data
			LoadData()
		Else
			ScheduleVolTable = CType(Session("dt"), DataTable)
		End If
	End Sub

	'Loads the volunteer gridview based on what button was clicked at the top of the page / what section is currently visible 
	Sub LoadData()
		Dim VIDOfDate As Integer
		Dim SchoolID As Integer
		Dim VisitDateFromID As Date
		Dim SQLStatement As String = "SELECT vo.id, vo.firstName, vo.lastName, vo.businessID, FORMAT(v.visitDate, 'yyyy-MM-dd') as visitDate, vo.schoolID, vo.pr, vo.svHours, vo.notes, vo.regular
										  FROM volunteers vo
										  JOIN volunteersSchedule vs ON vo.id = vs.volunteerID
										  JOIN visitInfo v ON v.id = vs.visitID"

		'Clear error and reset all fields
		error_lbl.Text = ""
		totalSVHours_lbl.Text = "-"
		viewVol_div.Visible = False
		schoolNameCheckin_ddl.Visible = False

		'Check which section is visible
		'Add Volunteer
		If addVol_div.Visible = True Then
			viewVol_div.Visible = True

			'Schedule Volunteer
		ElseIf scheduleVol_div.Visible = True Then

			'Check if visit date has been entered
			If volNameSchedule_ddl.SelectedIndex = 0 Then
				SQLStatement = SQLStatement
			End If

			'Check In Volunteer
		ElseIf checkIn_div.Visible = True Then

			'Check if current date is a visit date
			If visitDateCheckin_tb.Text <> "" Then

				'Assign SQL statement
				VIDOfDate = VisitData.GetVisitIDFromDate(visitDateCheckin_tb.Text)
				SQLStatement = SQLStatement & " WHERE vs.visitID = '" & VIDOfDate & "'"

				'Load total SV hours
				totalSVHours_lbl.Text = TotalSVHours(visitDateCheckin_tb.Text)

				'Enable checkboxes
				Checkboxes(VIDOfDate)

				'Load volunteer check in information
				LoadVolCheckIn(visitDateCheckin_tb.Text)

				'Make volunteers div visible
				viewVol_div.Visible = True

				'Make school name ddl visible
				schoolNameCheckin_ddl.Visible = True
				schoolNameCheckin_a.Visible = True

			ElseIf VisitID <> 0 Then

				'Load visit date into text box
				VisitDateFromID = VisitData.GetVisitDateFromID(VisitID)
				visitDateCheckin_tb.Text = VisitDateFromID.ToString("yyyy-MM-dd")

				'Assign SQL statement
				SQLStatement = SQLStatement & " WHERE vs.visitID = '" & VisitID & "'"

				'Load visiting schools
				SchoolData.LoadVisitDateSchoolsDDL(VisitDateFromID, schoolNameCheckin_ddl)
				schoolNameCheckin_ddl.Items.RemoveAt(0)
				schoolNameCheckin_ddl.Items.Insert(0, "Show All Schools")

				'Load total SV hours
				totalSVHours_lbl.Text = TotalSVHours(visitDateCheckin_tb.Text)

				'Enable checkboxes
				Checkboxes(VisitID)

				'Load volunteer check in information
				LoadVolCheckIn(visitDateCheckin_tb.Text)

				'Make volunteers div visible
				viewVol_div.Visible = True

				'Make school name ddl visible
				schoolNameCheckin_ddl.Visible = True
				schoolNameCheckin_a.Visible = True

				'Assign colors to school DDL text
				Select Case schoolNameCheckin_ddl.Items.Count
					Case 1
					'The first item in the DDL is the Show All Schools item, does not need to change color
					Case 2
						schoolNameCheckin_ddl.Items(1).Attributes.CssStyle.Add("background-color", "#afd8ff")
					Case 3
						schoolNameCheckin_ddl.Items(1).Attributes.CssStyle.Add("background-color", "#afd8ff")
						schoolNameCheckin_ddl.Items(2).Attributes.CssStyle.Add("background-color", "#ffafaf")

					Case 4
						schoolNameCheckin_ddl.Items(1).Attributes.CssStyle.Add("background-color", "#afd8ff")
						schoolNameCheckin_ddl.Items(2).Attributes.CssStyle.Add("background-color", "#ffafaf")
						schoolNameCheckin_ddl.Items(3).Attributes.CssStyle.Add("background-color", "#bfffaf")
					Case 5
						schoolNameCheckin_ddl.Items(1).Attributes.CssStyle.Add("background-color", "#afd8ff")
						schoolNameCheckin_ddl.Items(2).Attributes.CssStyle.Add("background-color", "#ffafaf")
						schoolNameCheckin_ddl.Items(3).Attributes.CssStyle.Add("background-color", "#bfffaf")
						schoolNameCheckin_ddl.Items(4).Attributes.CssStyle.Add("background-color", "#afc3ff")
					Case 6
						schoolNameCheckin_ddl.Items(1).Attributes.CssStyle.Add("background-color", "#afd8ff")
						schoolNameCheckin_ddl.Items(2).Attributes.CssStyle.Add("background-color", "#ffafaf")
						schoolNameCheckin_ddl.Items(3).Attributes.CssStyle.Add("background-color", "#bfffaf")
						schoolNameCheckin_ddl.Items(4).Attributes.CssStyle.Add("background-color", "#afc3ff")
						schoolNameCheckin_ddl.Items(5).Attributes.CssStyle.Add("background-color", "#ffd8af")
				End Select

			Else

				'Make volunteers div visible
				viewVol_div.Visible = True

				error_lbl.Text = "No visit date scheduled for today."

			End If

		Else
			viewVol_div.Visible = True
		End If

		'Check if search bar is filled
		If search_tb.Text <> Nothing Or search_tb.Text <> "" Then
			SQLStatement = SQLStatement & " WHERE vo.firstName LIKE '%" & search_tb.Text & "%' OR vo.lastName LIKE '%" & search_tb.Text & "%'"
		Else
			SQLStatement = SQLStatement
		End If

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
			SQLStatement = SQLStatement & "v.visitDate "
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

	'Loads the seperate viewVolCtrl gridview used for view volunteers from a specific visit date or viewing volunteer's muiltiple visits
	Sub LoadViewVolCtrlGridview()
		Dim VIDOfDate As Integer
		Dim VisitDate As String
		Dim TotalHours As String
		Dim VolNameWithID() As String
		Dim VolName As String
		Dim VolIDWithParentheses() As String
		Dim VolID As String
		Dim SQLStatement As String = "SELECT vs.id, vs.volunteerID, vo.firstName, vo.lastName, FORMAT(v.visitDate, 'MM/dd/yyyy') as visitDate, s.schoolName, vo.pr, vo.svHours, vo.notes, vo.regular
										FROM volunteers vo
										JOIN volunteersSchedule vs ON vo.id = vs.volunteerID
										JOIN visitInfo v ON v.id = vs.visitID
										JOIN schoolInfo s ON s.id = vo.schoolID"

		'Clear error and reset all fields
		error_lbl.Text = ""
		totalSVHours_lbl.Text = "-"
		viewVol_div.Visible = False
		viewVolControls_div.Visible = False
		schoolNameCheckin_ddl.Visible = False

		'Check if school name or visit date is loaded
		If visitDateViewVolCtrl_tb.Text <> Nothing Then

			'Assign visit date
			VisitDate = visitDateViewVolCtrl_tb.Text

			'Get VID of date
			VIDOfDate = VisitData.GetVisitIDFromDate(VisitDate)

			'Update SQL statement
			SQLStatement = SQLStatement & " WHERE vs.visitID='" & VIDOfDate & "'"

			'Assign total hours
			TotalHours = TotalSVHours(VisitDate)

		ElseIf volNameViewVolCtrl_ddl.SelectedIndex <> 0 Then
			VolNameWithID = volNameViewVolCtrl_ddl.SelectedValue.Split("(")
			VolName = VolNameWithID(0)
			VolIDWithParentheses = VolNameWithID(1).Split(")")
			VolID = VolIDWithParentheses(0)

			'Update SQL statement
			SQLStatement = SQLStatement & " WHERE vs.volunteerID='" & VolID & "'"

		End If

		'Load view control gridview
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
			viewVolCtrl_dgv.DataSource = dt
			viewVolCtrl_dgv.DataBind()

			cmd.Dispose()
			con.Close()
		Catch
			error_lbl.Text = "Error in LoadViewVolCtrl(). Could not load volunteer data into table."
			Exit Sub
		End Try

		'assign total SV hours to label
		totalSVHoursCtrl_lbl.Text = TotalHours

		'Make view vol ctrl div visible
		viewVolCtrlDGV_div.Visible = True
		viewVolControls_div.Visible = True

	End Sub

	'Gets an updated list of regular volunteers and assigns them by first name to a passed through ddl
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

	'Load data from volunteers Check in table and checks off the checkboxes based on amount of volunteers assigned to that business. Also loads the selected regular volunteer into the DDL for the business
	Sub LoadVolCheckIn(VisitDate As String)
		Dim VIDOfDate As Integer = VisitData.GetVisitIDFromDate(VisitDate)
		Dim CheckInSQL As String = "SELECT * FROM volunteersCheckIn WHERE visitID = '" & VIDOfDate & "'"
		Dim AchVol, AchReg, AstVol, AstReg, BayVol, BayReg, BBBVol, BBBReg, BicVol, BicReg, CitVol, CitReg, MixVol, MixReg, UPSVol, UPSReg, CVSVol, CVSReg, DitVol,
		DitReg, DukeVol, DukeReg, HSNVol, HSNReg, KanesVol, KanesReg, McDVol, McDReg, UWVol, UWReg, DaliVol, DaliReg, PCSWVol, PCSWReg, KnowVol,
		KnowReg, BucsVol, BucsReg, RaysVol, RaysReg, TimesVol, TimesReg, TDVol, TDReg, PCUVol, PCUReg As String

		'Clear checkboxes
		For Each cBox As Control In checkIn_div.Controls
			If TypeOf cBox Is CheckBox Then
				CType(cBox, CheckBox).Checked = False
			End If
		Next

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
		regVolPCSN_ddl.SelectedIndex = 0
		regVolKanes_ddl.SelectedIndex = 0
		regVolKnow_ddl.SelectedIndex = 0
		regVolMcdonalds_ddl.SelectedIndex = 0
		regVolMix_ddl.SelectedIndex = 0
		regVolPCSW_ddl.SelectedIndex = 0
		regVolPCU_ddl.SelectedIndex = 0
		regVolRays_ddl.SelectedIndex = 0
		regVolTD_ddl.SelectedIndex = 0
		regVolPower_ddl.SelectedIndex = 0
		regVolUnited_ddl.SelectedIndex = 0
		regVolUPS_ddl.SelectedIndex = 0

		'Load data from volunteers Check in table and assign it to the variables and DDLs
		Try
			con.ConnectionString = connection_string
			con.Open()
			cmd.CommandText = CheckInSQL
			cmd.Connection = con
			dr = cmd.ExecuteReader

			If dr.HasRows Then
				While dr.Read()
					AchVol = dr("achVol").ToString
					regVolAch_ddl.SelectedValue = dr("achReg").ToString
					AstVol = dr("astroVol").ToString
					regVolAstro_ddl.SelectedValue = dr("astroReg").ToString
					BayVol = dr("baycareVol").ToString
					regVolBaycare_ddl.SelectedValue = dr("baycareReg").ToString
					BBBVol = dr("bbbVol").ToString
					regVolBBB_ddl.SelectedValue = dr("bbbReg").ToString
					BicVol = dr("bicVol").ToString
					regVolBic_ddl.SelectedValue = dr("bicReg").ToString
					CitVol = dr("cityVol").ToString
					regVolCity_ddl.SelectedValue = dr("cityReg").ToString
					CVSVol = dr("cvsVol").ToString
					regVolCVS_ddl.SelectedValue = dr("cvsReg").ToString
					DitVol = dr("ditekVol").ToString
					regVolDitek_ddl.SelectedValue = dr("ditekReg").ToString
					DukeVol = dr("dukeVol").ToString
					regVolDuke_ddl.SelectedValue = dr("dukeReg").ToString
					KanesVol = dr("kanesVol").ToString
					regVolKanes_ddl.SelectedValue = dr("kanesReg").ToString
					KnowVol = dr("knowVol").ToString
					regVolKnow_ddl.SelectedValue = dr("knowReg").ToString
					DaliVol = dr("daliVol").ToString
					regVolDali_ddl.SelectedValue = dr("daliReg").ToString
					McDVol = dr("mcdVol").ToString
					regVolMcdonalds_ddl.SelectedValue = dr("mcdReg").ToString
					MixVol = dr("mixVol").ToString
					regVolMix_ddl.SelectedValue = dr("mixReg").ToString
					PCUVol = dr("pcuVol").ToString
					regVolPCU_ddl.SelectedValue = dr("pcuReg").ToString
					PCSWVol = dr("pcswVol").ToString
					regVolPCSW_ddl.SelectedValue = dr("pcswReg").ToString
					BucsVol = dr("tbbucsVol").ToString
					regVolBucs_ddl.SelectedValue = dr("tbbucsReg").ToString
					RaysVol = dr("tbraysVol").ToString
					regVolRays_ddl.SelectedValue = dr("tbraysReg").ToString
					TimesVol = dr("tbtimesVol").ToString
					regVolPower_ddl.SelectedValue = dr("tbtimesReg").ToString
					TDVol = dr("tdVol").ToString
					regVolTD_ddl.SelectedValue = dr("tdReg").ToString
					UPSVol = dr("upsVol").ToString
					regVolUPS_ddl.SelectedValue = dr("upsReg").ToString
					UWVol = dr("unitedVol").ToString
					regVolUnited_ddl.SelectedValue = dr("unitedReg").ToString
					HSNVol = dr("hsnVol").ToString
					regVolPCSN_ddl.SelectedValue = dr("hsnReg").ToString
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

		'Assign values to checkboxes
		Select Case AchVol
			Case "1"
				ach1_chk.Checked = True
			Case "2"
				ach1_chk.Checked = True
				ach2_chk.Checked = True
			Case "3"
				ach1_chk.Checked = True
				ach2_chk.Checked = True
				ach3_chk.Checked = True
			Case "4"
				ach1_chk.Checked = True
				ach2_chk.Checked = True
				ach3_chk.Checked = True
				ach4_chk.Checked = True
		End Select

		Select Case AstVol
			Case "1"
				astro1_chk.Checked = True
			Case "2"
				astro1_chk.Checked = True
				astro2_chk.Checked = True
		End Select

		Select Case BayVol
			Case "1"
				baycare1_chk.Checked = True
			Case "2"
				baycare1_chk.Checked = True
				baycare2_chk.Checked = True
		End Select

		Select Case BBBVol
			Case "1"
				bbb1_chk.Checked = True
			Case "2"
				bbb1_chk.Checked = True
				bbb2_chk.Checked = True
		End Select

		Select Case BicVol
			Case "1"
				bic1_chk.Checked = True
			Case "2"
				bic1_chk.Checked = True
				bic2_chk.Checked = True
			Case "3"
				bic1_chk.Checked = True
				bic2_chk.Checked = True
				bic3_chk.Checked = True
		End Select

		Select Case CitVol
			Case "1"
				city1_chk.Checked = True
			Case "2"
				city1_chk.Checked = True
				city2_chk.Checked = True
			Case "3"
				city1_chk.Checked = True
				city2_chk.Checked = True
				city3_chk.Checked = True
		End Select

		Select Case MixVol
			Case "1"
				mix1_chk.Checked = True
			Case "2"
				mix1_chk.Checked = True
				mix2_chk.Checked = True
		End Select

		Select Case UPSVol
			Case "1"
				ups_chk.Checked = True
		End Select

		Select Case CVSVol
			Case "1"
				cvs1_chk.Checked = True
			Case "2"
				cvs1_chk.Checked = True
				cvs2_chk.Checked = True
			Case "3"
				cvs1_chk.Checked = True
				cvs2_chk.Checked = True
				cvs3_chk.Checked = True
		End Select

		Select Case DitVol
			Case "1"
				ditek1_chk.Checked = True
			Case "2"
				ditek1_chk.Checked = True
				ditek2_chk.Checked = True
		End Select

		Select Case DukeVol
			Case "1"
				duke1_chk.Checked = True
			Case "2"
				duke1_chk.Checked = True
				duke2_chk.Checked = True
		End Select

		Select Case HSNVol
			Case "1"
				pcsn1_chk.Checked = True
			Case "2"
				pcsn1_chk.Checked = True
				pcsn2_chk.Checked = True
		End Select

		Select Case KanesVol
			Case "1"
				kanes1_chk.Checked = True
			Case "2"
				kanes1_chk.Checked = True
				kanes2_chk.Checked = True
		End Select

		Select Case McDVol
			Case "1"
				mcd1_chk.Checked = True
			Case "2"
				mcd1_chk.Checked = True
				mcd2_chk.Checked = True
			Case "3"
				mcd1_chk.Checked = True
				mcd2_chk.Checked = True
				mcd3_chk.Checked = True
		End Select

		Select Case UWVol
			Case "1"
				uw1_chk.Checked = True
			Case "2"
				uw1_chk.Checked = True
				uw2_chk.Checked = True
			Case "3"
				uw1_chk.Checked = True
				uw2_chk.Checked = True
				uw3_chk.Checked = True
		End Select

		Select Case DaliVol
			Case "1"
				dali_chk.Checked = True
		End Select

		Select Case PCSWVol
			Case "1"
				pcsw1_chk.Checked = True
			Case "2"
				pcsw1_chk.Checked = True
				pcsw2_chk.Checked = True
		End Select

		Select Case KnowVol
			Case "1"
				know1_chk.Checked = True
			Case "2"
				know1_chk.Checked = True
				know2_chk.Checked = True
		End Select

		Select Case BucsVol
			Case "1"
				bucs1_chk.Checked = True
			Case "2"
				bucs1_chk.Checked = True
				bucs2_chk.Checked = True
		End Select

		Select Case RaysVol
			Case "1"
				rays1_chk.Checked = True
			Case "2"
				rays1_chk.Checked = True
				rays2_chk.Checked = True
			Case "3"
				rays1_chk.Checked = True
				rays2_chk.Checked = True
				rays3_chk.Checked = True
		End Select

		Select Case TimesVol
			Case "1"
				power1_chk.Checked = True
			Case "2"
				power1_chk.Checked = True
				power2_chk.Checked = True
			Case "3"
				power1_chk.Checked = True
				power2_chk.Checked = True
				power3_chk.Checked = True
		End Select

		Select Case TDVol
			Case "1"
				td1_chk.Checked = True
			Case "2"
				td1_chk.Checked = True
				td2_chk.Checked = True
			Case "3"
				td1_chk.Checked = True
				td2_chk.Checked = True
				td3_chk.Checked = True
		End Select

		Select Case PCUVol
			Case "1"
				pcu1_chk.Checked = True
			Case "2"
				pcu1_chk.Checked = True
				pcu2_chk.Checked = True
		End Select

	End Sub

	'Loads a ddl with all volunteer names, first and last, with their ID in parentheses and returns it
	Function LoadVolunteerNameDDL(VolNamesDDL As DropDownList, Optional SchoolID As String = Nothing)
		Dim SQLStatement As String = "SELECT CONCAT(lastName, ', ', firstName, ' (', id, ')') as volName FROM volunteers"

		'Clear volunteer names ddl
		volNameSchedule_ddl.Items.Clear()

		'Check if schoolID is not null
		If SchoolID <> Nothing Then
			SQLStatement = SQLStatement + " WHERE schoolID='" & SchoolID & "'"
		End If

		'Add ORDER BY clause
		SQLStatement = SQLStatement + " ORDER BY lastName ASC"

		'Populates a DDL with student names and their account numbers at the beginning of the name
		con.ConnectionString = connection_string
		con.Open()
		cmd.CommandText = SQLStatement
		cmd.Connection = con
		dr = cmd.ExecuteReader

		While dr.Read()
			VolNamesDDL.Items.Add(dr(0).ToString)
		End While
		VolNamesDDL.Items.Insert(0, "")

		cmd.Dispose()
		con.Close()

		Return VolNamesDDL.Items
	End Function

	'Adds a new volunteer into the volunteers table in the database
	Sub SubmitAddNewVolunteer()
		Dim FirstName As String
		Dim LastName As String
		Dim SchoolName As String
		Dim SchoolID As Integer
		Dim PR As String
		Dim SVHours As String = "6"
		Dim Regular As Boolean = False
		Dim Notes As String

		'Check for empty fields    Or businessName_ddl.SelectedIndex = 0 Or regularVol_ddl.SelectedIndex = 0 
		If firstName_tb.Text = Nothing Or lastName_tb.Text = Nothing Then
			error_lbl.Text = "Please enter a first name, last name, business, visit date, school name and regular volunteer status before submitting."
			Exit Sub
		End If

		'Assign fields to variables
		SchoolName = schoolNameAdd_ddl.SelectedValue
		SchoolID = SchoolData.GetSchoolID(SchoolName)
		FirstName = firstName_tb.Text
		LastName = lastName_tb.Text
		PR = pr_ddl.SelectedValue
		Notes = notes_tb.Text

		'Check if volunteer first and last name are already apart of the selected school
		Try
			con.ConnectionString = connection_string
			con.Open()
			cmd.Connection = con
			cmd.CommandText = "SELECT firstName, lastName, schoolID FROM volunteers WHERE firstName LIKE '%" & FirstName & "%' AND lastName LIKE '%" & LastName & "%' AND schoolID='" & SchoolID & "'"
			dr = cmd.ExecuteReader()

			If dr.HasRows() Then
				error_lbl.Text = "A volunteer by that name has already been added to the database. To schedule them, click on the Schedule Volunteers button and find their name in the drop down list."
				Exit Sub
			End If

			cmd.Dispose()
			con.Close()
		Catch

		End Try

		'Insert data into DB
		Try
			con.ConnectionString = connection_string
			con.Open()
			cmd.Connection = con
			cmd.CommandText = "INSERT INTO volunteers (schoolID, businessID, firstName, lastName, pr, svHours, notes, regular)
                                VALUES ('" & SchoolID & "', '0','" & FirstName & "', '" & LastName & "', '" & PR & "', '" & SVHours & "', '" & Notes & "', '" & Regular & "')"

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

		'Show success message
		error_lbl.Text = "Volunteer successfully added."

	End Sub

	'Adds all volunteer IDs from the schedule volunteers table, to the volunteersSchedule table, found in the database. Used for loading in the volunteers in the check in section
	Sub SubmitScheduleVolunteers()
		Dim VisitDate As String
		Dim VisitID As String
		Dim CountOfVolunteers As Integer
		Dim VolunteerID As Integer
		Dim SQLInsertQuery As String = "INSERT INTO volunteersSchedule (volunteerID, visitID) VALUES"
		Dim SQLRemoveBusiness As String = "UPDATE volunteers SET businessID=0 WHERE "

		'Check if the visit date is not blank
		If visitDateSchedule_tb.Text <> "" Then
			VisitDate = visitDateSchedule_tb.Text
		Else
			error_lbl.Text = "Please enter a visit date before submitting."
			Exit Sub
		End If

		'Get visit ID (if found)
		VisitID = VisitData.GetVisitIDFromDate(VisitDate)

		If VisitID = "0" Or VisitID = "" Then
			error_lbl.Text = "Visit date entered has not been created. Please check with an EV teacher to confirm that the visit date you have entered has been created."
			Exit Sub
		End If

		'Get the total number of volunteers in the table
		CountOfVolunteers = scheduledVol_dgv.Rows.Count

		'Start a for loop to add volunteer IDs and visit IDs to the insert query
		For i = 0 To CountOfVolunteers - 1

			'Assign volunteer ID
			VolunteerID = scheduledVol_dgv.Rows(i).Cells(0).Text

			'Check if volunteer ID is already assigned to visitID
			If CheckVolunteerSchedule(VolunteerID, VisitID) = True Then
				Continue For
			End If

			'If adding data for the first row, do not add a comma to the beginning of the query
			If i = 0 Or Not SQLInsertQuery.Contains("VALUES (") Then
				SQLInsertQuery = SQLInsertQuery & " (" & VolunteerID & ", " & VisitID & ")"
			Else
				SQLInsertQuery = SQLInsertQuery & ", (" & VolunteerID & ", " & VisitID & ")"
			End If

			'Remove business ID from exsiting volunteers (if they are being added into the insert 
			If i = 0 Or Not SQLRemoveBusiness.Contains("WHERE id") Then
				SQLRemoveBusiness = SQLRemoveBusiness & " id=" & VolunteerID & " "
			Else
				SQLRemoveBusiness = SQLRemoveBusiness & "AND id=" & VolunteerID & ""
			End If
		Next

		'Insert into volunteerSchedule table in the database
		Try
			con.ConnectionString = connection_string
			con.Open()
			cmd.Connection = con
			cmd.CommandText = SQLInsertQuery
			cmd.ExecuteNonQuery()
			cmd.Dispose()
			con.Close()
		Catch
			error_lbl.Text = "Error in submission for Schedule Volunteers. Cannot insert volunteers into database."
			Exit Sub
		End Try

		'Update volunteers database to remove old business from table
		Try
			con.ConnectionString = connection_string
			con.Open()
			cmd.Connection = con
			cmd.CommandText = SQLRemoveBusiness
			cmd.ExecuteNonQuery()
			cmd.Dispose()
			con.Close()
		Catch
			error_lbl.Text = "Error in submission for Schedule Volunteers. Cannot remove old assigned business into database."
			Exit Sub
		End Try

		'Show success message and refresh
		error_lbl.Text = "Volunteers scheduled for " & VisitDate
		Dim meta As New HtmlMeta()
		meta.HttpEquiv = "Refresh"
		meta.Content = "3;url=volunteer_database.aspx"
		Me.Page.Controls.Add(meta)

	End Sub

	'Assigns the regular volunteer that was selected from the DDL on the check in section, found next to the checkboxes
	Sub SubmitCheckIn(VIDOfDate As Integer)
		Dim SQLStatement As String
		'Dim VisitDate As String = visitDateCheckin_tb.Text
		'Dim VIDOfDate As Integer = VisitData.GetVisitIDFromDate(VisitDate)
		Dim BusinessCount As Integer = 1
		Dim AchVol, AchReg, AstVol, AstReg, BayVol, BayReg, BBBVol, BBBReg, BicVol, BicReg, CitVol, CitReg, MixVol, MixReg, UPSVol, UPSReg, CVSVol, CVSReg, DitVol,
		DitReg, DukeVol, DukeReg, HSNVol, HSNReg, KanesVol, KanesReg, McDVol, McDReg, UWVol, UWReg, DaliVol, DaliReg, PCSWVol, PCSWReg, KnowVol,
		KnowReg, BucsVol, BucsReg, RaysVol, RaysReg, TimesVol, TimesReg, TDVol, TDReg, PCUVol, PCUReg As String

		'Check for bodies and assign variables

		'Check for achieva bodies
		If regVolAch_ddl.SelectedIndex <> 0 Then
			AchReg = regVolAch_ddl.SelectedValue
		Else
			AchReg = "None"
		End If


		'Check for astro bodies
		If regVolAstro_ddl.SelectedIndex <> 0 Then
			AstReg = regVolAstro_ddl.SelectedValue
		Else
			AstReg = "None"
		End If


		'Check for Baycare bodies
		If regVolBaycare_ddl.SelectedIndex <> 0 Then
			BayReg = regVolBaycare_ddl.SelectedValue
		Else
			BayReg = "None"
		End If


		'Check bbb bodies
		If regVolBBB_ddl.SelectedIndex <> 0 Then
			BBBReg = regVolBBB_ddl.SelectedValue
		Else
			BBBReg = "None"
		End If


		'Check koozie bodies
		If regVolBic_ddl.SelectedIndex <> 0 Then
			BicReg = regVolBic_ddl.SelectedValue
		Else
			BicReg = "None"
		End If


		'Check for city hall bodies
		If regVolCity_ddl.SelectedIndex <> 0 Then
			CitReg = regVolCity_ddl.SelectedValue
		Else
			CitReg = "None"
		End If


		'Check for mix bodies
		If regVolMix_ddl.SelectedIndex <> 0 Then
			MixReg = regVolMix_ddl.SelectedValue
		Else
			MixReg = "None"
		End If


		'Check for ups bodies
		If regVolUPS_ddl.SelectedIndex <> 0 Then
			UPSReg = regVolUPS_ddl.SelectedValue
		Else
			UPSReg = "None"
		End If


		'Check cvs bodies
		If regVolCVS_ddl.SelectedIndex <> 0 Then
			CVSReg = regVolCVS_ddl.SelectedValue
		Else
			CVSReg = "None"
		End If


		'Check ditek bodies
		If regVolDitek_ddl.SelectedIndex <> 0 Then
			DitReg = regVolDitek_ddl.SelectedValue
		Else
			DitReg = "None"
		End If


		'Check duke energy bodies
		If regVolDuke_ddl.SelectedIndex <> 0 Then
			DukeReg = regVolDuke_ddl.SelectedValue
		Else
			DukeReg = "None"
		End If


		'Check hsn / pcs newsroom bodies
		If regVolPCSN_ddl.SelectedIndex <> 0 Then
			HSNReg = regVolPCSN_ddl.SelectedValue
		Else
			HSNReg = "None"
		End If


		'Check kanes bodies
		If regVolKanes_ddl.SelectedIndex <> 0 Then
			KanesReg = regVolKanes_ddl.SelectedValue
		Else
			KanesReg = "None"
		End If


		'Check mcdonalds bodies
		If regVolMcdonalds_ddl.SelectedIndex <> 0 Then
			McDReg = regVolMcdonalds_ddl.SelectedValue
		Else
			McDReg = "None"
		End If


		'Check united way bodies
		If regVolUnited_ddl.SelectedIndex <> 0 Then
			UWReg = regVolUnited_ddl.SelectedValue
		Else
			UWReg = "None"
		End If


		'Check dali bodies
		If regVolDali_ddl.SelectedIndex <> 0 Then
			DaliReg = regVolDali_ddl.SelectedValue
		Else
			DaliReg = "None"
		End If


		'Check pcsw bodies
		If regVolPCSW_ddl.SelectedIndex <> 0 Then
			PCSWReg = regVolPCSW_ddl.SelectedValue
		Else
			PCSWReg = "None"
		End If


		'Check knowbe4 bodies
		If regVolKnow_ddl.SelectedIndex <> 0 Then
			KnowReg = regVolKnow_ddl.SelectedValue
		Else
			KnowReg = "None"
		End If


		'Check bucs bodies
		If regVolBucs_ddl.SelectedIndex <> 0 Then
			BucsReg = regVolBucs_ddl.SelectedValue
		Else
			BucsReg = "None"
		End If


		'Check rays bodies
		If regVolRays_ddl.SelectedIndex <> 0 Then
			RaysReg = regVolRays_ddl.SelectedValue
		Else
			RaysReg = "None"
		End If

		'Check times /power design bodies
		If regVolPower_ddl.SelectedIndex <> 0 Then
			TimesReg = regVolPower_ddl.SelectedValue
		Else
			TimesReg = "None"
		End If

		'Check td synnex bodies
		If regVolTD_ddl.SelectedIndex <> 0 Then
			TDReg = regVolTD_ddl.SelectedValue
		Else
			TDReg = "None"
		End If

		'Check pcu bodies
		If regVolPCU_ddl.SelectedIndex <> 0 Then
			PCUReg = regVolPCU_ddl.SelectedValue
		Else
			PCUReg = "None"
		End If

		'Calculuate amount of volunteers in each business
		While BusinessCount < 25

			'Check if business ID is not 4 (no business for ID 4)
			If BusinessCount = 4 Then
				BusinessCount += 1
			End If

			'Get the count 
			Try
				con.ConnectionString = connection_string
				con.Open()
				cmd.CommandText = "SELECT COUNT(*) as occur FROM volunteers v
									  WHERE v.visitID='" & VIDOfDate & "' AND v.businessID='" & BusinessCount & "'
									  GROUP BY v.businessID"
				cmd.Connection = con
				dr = cmd.ExecuteReader

				While dr.Read()

					'Checking if there are volunteers in that business
					If dr.HasRows() Then

						'Assign count to variable based on business
						Select Case BusinessCount
							Case 1
								BucsVol = dr("occur").ToString()
							Case 2
								RaysVol = dr("occur").ToString()
							Case 3
								CVSVol = dr("occur").ToString()
							Case 5
								KanesVol = dr("occur").ToString()
							Case 6
								BicVol = dr("occur").ToString()
							Case 7
								TDVol = dr("occur").ToString()
							Case 8
								HSNVol = dr("occur").ToString()
							Case 9
								BBBVol = dr("occur").ToString()
							Case 10
								AstVol = dr("occur").ToString()
							Case 11
								DitVol = dr("occur").ToString()
							Case 12
								AchVol = dr("occur").ToString()
							Case 13
								BayVol = dr("occur").ToString()
							Case 14
								CitVol = dr("occur").ToString()
							Case 15
								DaliVol = dr("occur").ToString()
							Case 16
								DukeVol = dr("occur").ToString()
							Case 17
								McDVol = dr("occur").ToString()
							Case 18
								MixVol = dr("occur").ToString()
							Case 19
								PCSWVol = dr("occur").ToString()
							Case 20
								PCUVol = dr("occur").ToString()
							Case 21
								KnowVol = dr("occur").ToString()
							Case 22
								TimesVol = dr("occur").ToString()
							Case 23
								UPSVol = dr("occur").ToString()
							Case 24
								UWVol = dr("occur").ToString()
						End Select

					End If

				End While

				cmd.Dispose()
				con.Close()

			Catch ex As Exception
				error_lbl.Text = "Error in SubmitCheckIn(). Could not assign volunteer count."
				Exit Sub
			End Try

			'add 1 to count
			BusinessCount += 1

		End While

		cmd.Dispose()
		con.Close()

		'Check if visit date exists, if not, insert new entry, otherwise update existing entry
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

			error_lbl.Text = "Successfully updated volunteer check in."

			cmd.Dispose()
			con.Close()
		Catch
			error_lbl.Text = "Error in SubmitCheckIn(). Could not complete the check in process."
			Exit Sub
		End Try

		'Refresh page
		Dim meta As New HtmlMeta()
		meta.HttpEquiv = "Refresh"
		meta.Content = "3;url=volunteer_database.aspx"
		Me.Page.Controls.Add(meta)

	End Sub

	'Loads a volunteer from a vol name DDL into a gridview found in the schedule volunteers section
	Sub AddVolIntoTable()
		Dim VolNameWithID() As String = volNameSchedule_ddl.SelectedValue.Split("(")
		Dim VolName As String = VolNameWithID(0)
		Dim VolIDWithParentheses() As String = VolNameWithID(1).Split(")")
		Dim VolID As String = VolIDWithParentheses(0)
		Dim ScheduledVolRow As DataRow = ScheduleVolTable.NewRow

		ScheduledVolRow("Volunteer ID") = VolID
		ScheduledVolRow("Volunteer Name") = VolName

		ScheduleVolTable.Rows.Add(ScheduledVolRow)
		scheduledVol_dgv.DataSource = ScheduleVolTable
		scheduledVol_dgv.DataBind()

		Session("dt") = ScheduleVolTable

	End Sub

	'Enables the regular vol ddls and assigns the colors for the checkboxes based on what business is open for the entered visit date in the check in section
	Sub Checkboxes(VIDOfDate As Integer)
		Dim count As Integer = 1
		'Dim VIDOfDate As Integer = VisitData.GetVisitIDFromDate(visitDateCheckin_tb.Text)

		'Clear checkboxes
		For Each cBox As Control In checkIn_div.Controls
			If TypeOf cBox Is CheckBox Then
				CType(cBox, CheckBox).Checked = False
			End If
		Next

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
		regVolPCSN_ddl.SelectedIndex = 0
		regVolKanes_ddl.SelectedIndex = 0
		regVolKnow_ddl.SelectedIndex = 0
		regVolMcdonalds_ddl.SelectedIndex = 0
		regVolMix_ddl.SelectedIndex = 0
		regVolPCSW_ddl.SelectedIndex = 0
		regVolPCU_ddl.SelectedIndex = 0
		regVolRays_ddl.SelectedIndex = 0
		regVolTD_ddl.SelectedIndex = 0
		regVolPower_ddl.SelectedIndex = 0
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
										regVolBucs_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = schoolNameCheckin_ddl.Items(1).Value Then
											bucs_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(2).Value Then
											bucs_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(3).Value Then
											bucs_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(4).Value Then
											bucs_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(5).Value Then
											bucs_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "2"
										regVolRays_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = schoolNameCheckin_ddl.Items(1).Value Then
											rays_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(2).Value Then
											rays_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(3).Value Then
											rays_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(4).Value Then
											rays_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(5).Value Then
											rays_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "3"
										regVolCVS_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = schoolNameCheckin_ddl.Items(1).Value Then
											cvs_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(2).Value Then
											cvs_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(3).Value Then
											cvs_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(4).Value Then
											cvs_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(5).Value Then
											cvs_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "5"
										regVolKanes_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = schoolNameCheckin_ddl.Items(1).Value Then
											kanes_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(2).Value Then
											kanes_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(3).Value Then
											kanes_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(4).Value Then
											kanes_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(5).Value Then
											kanes_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "6"
										regVolBic_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = schoolNameCheckin_ddl.Items(1).Value Then
											bic_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(2).Value Then
											bic_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(3).Value Then
											bic_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(4).Value Then
											bic_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(5).Value Then
											bic_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "7"
										regVolTD_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = schoolNameCheckin_ddl.Items(1).Value Then
											td_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(2).Value Then
											td_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(3).Value Then
											td_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(4).Value Then
											td_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(5).Value Then
											td_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "8"
										regVolPCSN_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = schoolNameCheckin_ddl.Items(1).Value Then
											pcsn_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(2).Value Then
											pcsn_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(3).Value Then
											pcsn_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(4).Value Then
											pcsn_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(5).Value Then
											pcsn_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "9"
										regVolBBB_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = schoolNameCheckin_ddl.Items(1).Value Then
											bbb_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(2).Value Then
											bbb_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(3).Value Then
											bbb_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(4).Value Then
											bbb_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(5).Value Then
											bbb_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "10"
										regVolAstro_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = schoolNameCheckin_ddl.Items(1).Value Then
											astro_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(2).Value Then
											astro_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(3).Value Then
											astro_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(4).Value Then
											astro_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(5).Value Then
											astro_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "11"
										regVolDitek_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = schoolNameCheckin_ddl.Items(1).Value Then
											ditek_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(2).Value Then
											ditek_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(3).Value Then
											ditek_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(4).Value Then
											ditek_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(5).Value Then
											ditek_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "12"
										regVolAch_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = schoolNameCheckin_ddl.Items(1).Value Then
											ach_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(2).Value Then
											ach_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(3).Value Then
											ach_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(4).Value Then
											ach_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(5).Value Then
											ach_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "13"
										regVolBaycare_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = schoolNameCheckin_ddl.Items(1).Value Then
											baycare_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(2).Value Then
											baycare_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(3).Value Then
											baycare_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(4).Value Then
											baycare_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(5).Value Then
											baycare_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "14"
										regVolCity_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = schoolNameCheckin_ddl.Items(1).Value Then
											city_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(2).Value Then
											city_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(3).Value Then
											city_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(4).Value Then
											city_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(5).Value Then
											city_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "15"
										regVolDali_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = schoolNameCheckin_ddl.Items(1).Value Then
											dali_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(2).Value Then
											dali_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(3).Value Then
											dali_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(4).Value Then
											dali_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(5).Value Then
											dali_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "16"
										regVolDuke_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = schoolNameCheckin_ddl.Items(1).Value Then
											duke_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(2).Value Then
											duke_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(3).Value Then
											duke_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(4).Value Then
											duke_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(5).Value Then
											duke_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "17"
										regVolMcdonalds_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = schoolNameCheckin_ddl.Items(1).Value Then
											mcdonalds_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(2).Value Then
											mcdonalds_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(3).Value Then
											mcdonalds_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(4).Value Then
											mcdonalds_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(5).Value Then
											mcdonalds_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "18"
										regVolMix_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = schoolNameCheckin_ddl.Items(1).Value Then
											mix_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(2).Value Then
											mix_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(3).Value Then
											mix_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(4).Value Then
											mix_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(5).Value Then
											mix_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "19"
										regVolPCSW_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = schoolNameCheckin_ddl.Items(1).Value Then
											pcsw_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(2).Value Then
											pcsw_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(3).Value Then
											pcsw_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(4).Value Then
											pcsw_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(5).Value Then
											pcsw_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "20"
										regVolPCU_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = schoolNameCheckin_ddl.Items(1).Value Then
											pcu_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(2).Value Then
											pcu_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(3).Value Then
											pcu_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(4).Value Then
											pcu_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(5).Value Then
											pcu_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "21"
										regVolKnow_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = schoolNameCheckin_ddl.Items(1).Value Then
											know_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(2).Value Then
											know_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(3).Value Then
											know_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(4).Value Then
											know_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(5).Value Then
											know_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "22"
										regVolPower_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = schoolNameCheckin_ddl.Items(1).Value Then
											power_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(2).Value Then
											power_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(3).Value Then
											power_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(4).Value Then
											power_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(5).Value Then
											power_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "23"
										regVolUPS_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = schoolNameCheckin_ddl.Items(1).Value Then
											ups_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(2).Value Then
											ups_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(3).Value Then
											ups_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(4).Value Then
											ups_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(5).Value Then
											ups_a.Attributes.CssStyle.Add("color", "orange")
										End If

									Case "24"
										regVolUnited_ddl.Enabled = True

										'Set color of text based on school assigned
										If dr("schoolName") = schoolNameCheckin_ddl.Items(1).Value Then
											united_a.Attributes.CssStyle.Add("color", "blue")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(2).Value Then
											united_a.Attributes.CssStyle.Add("color", "red")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(3).Value Then
											united_a.Attributes.CssStyle.Add("color", "green")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(4).Value Then
											united_a.Attributes.CssStyle.Add("color", "magenta")
										ElseIf dr("schoolName").ToString = schoolNameCheckin_ddl.Items(5).Value Then
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
					error_lbl.Text = "Error in Checkboxes(). Could not get business open information."
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

		'LoadData()

	End Sub

	'Gets the total amount of SV hours of a visit, school, or volunteer (currently volunteer isn't working - 8/29/2024)
	Function TotalSVHours(Optional VisitDate As String = Nothing, Optional SchoolName As String = Nothing, Optional VolID As String = Nothing)
		Dim SQLStatement As String = "SELECT SUM(svHours) as svHours FROM volunteers WHERE "
		Dim VIDOfDate As Integer = VisitData.GetVisitIDFromDate(VisitDate)
		Dim SchoolID As Integer = SchoolData.GetSchoolID(SchoolName)
		Dim Total As String

		'Check if load by visit date or load by school name is active
		If VisitDate <> Nothing Then
			SQLStatement += "visitID= '" & VIDOfDate & "' "

			If SchoolName <> Nothing Then
				SQLStatement += " AND schoolID= '" & SchoolID & "' "
			ElseIf VolID <> Nothing Then
				SQLStatement += " AND id= '" & VolID & "' "
			End If
		ElseIf SchoolName <> Nothing Then
			SQLStatement += "schoolID = '" & SchoolID & "' "

			If VisitDate <> Nothing Then
				SQLStatement += " AND visitID = '" & VIDOfDate & "' "
			ElseIf VolID <> Nothing Then
				SQLStatement += " AND id='" & VolID & "'"
			End If
		ElseIf VolID <> Nothing Then
			SQLStatement += "id = '" & VolID & "' "

			If VisitID <> Nothing Then
				SQLStatement += " AND visitID = '" & VIDOfDate & "' "
			ElseIf SchoolID <> Nothing Then
				SQLStatement += " AND schoolID = '" & SchoolID & "' "
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
				Total = dr("svHours").ToString
			End While

		Catch ex As Exception
			error_lbl.Text = "Error in TotalSVHours(). Could not get total sv hours."
			Exit Function
		End Try

		cmd.Dispose()
		con.Close()

		Return Total
	End Function

	'Uses the LoadRegVolDDL function to populate all regular volunteer DDLs found in the check in section
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
		LoadRegVolDDL(regVolPCSN_ddl)
		LoadRegVolDDL(regVolKanes_ddl)
		LoadRegVolDDL(regVolKnow_ddl)
		LoadRegVolDDL(regVolMcdonalds_ddl)
		LoadRegVolDDL(regVolMix_ddl)
		LoadRegVolDDL(regVolPCSW_ddl)
		LoadRegVolDDL(regVolPCU_ddl)
		LoadRegVolDDL(regVolRays_ddl)
		LoadRegVolDDL(regVolTD_ddl)
		LoadRegVolDDL(regVolPower_ddl)
		LoadRegVolDDL(regVolUnited_ddl)
		LoadRegVolDDL(regVolUPS_ddl)
	End Sub

	'Returns a true or false value for if a passed through volunteer ID is already in the volunteersSchedule table in the database assigned to the passed through visit ID
	Function CheckVolunteerSchedule(VolunteerID As Integer, VisitID As Integer)
		Dim Check As Boolean = False

		Try
			con.ConnectionString = connection_string
			con.Open()
			cmd.CommandText = "SELECT id FROM volunteersSchedule WHERE volunteerID='" & VolunteerID & "' AND visitID='" & VisitID & "'"
			cmd.Connection = con
			dr = cmd.ExecuteReader()

			If dr.HasRows() = True Then
				Check = True
			Else
				Check = False
			End If

			cmd.Dispose()
			con.Close()

		Catch
			error_lbl.Text = "Error in LoadRegVolDDL(). Could not load regular volunteer DDLs."
			Exit Function
		End Try

		Return Check
	End Function

	'Gets data (tbh idk what this does but its in everything)
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



	'All of the volunteers gridview modules
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

		'Update checkboxes if check in is visible
		If checkIn_div.Visible = True Then

			'Update checkboxes
			SubmitCheckIn(VIDOfDate)

		End If

	End Sub

	Private Sub volunteers_dgv_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles volunteers_dgv.RowDataBound
		If (e.Row.RowType = DataControlRowType.DataRow) Then

			'School Dropdown
			Dim ddlSchool As DropDownList = CType(e.Row.FindControl("schoolNameDGV_ddl"), DropDownList)
			Dim lblSchool As String = CType(e.Row.FindControl("schoolNameDGV_lbl"), Label).Text
			Dim VisitDate As String

			If visitDateCheckin_tb.Text <> "" Then
				VisitDate = visitDateCheckin_tb.Text
			Else
				VisitDate = ""
			End If

			ddlSchool.DataSource = GetData("SELECT id, schoolName FROM schoolInfo WHERE NOT (schoolName = 'A1 No School Scheduled') AND NOT id='505' ORDER BY schoolName ASC")

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
			'If schoolNameSchedule_ddl.Visible = True And schoolNameCheckin_ddl.Visible = False Then
			'	Select Case schoolNameSchedule_ddl.Items.Count
			'		Case 2
			'			If lblSchool = SchoolData.GetSchoolID(schoolNameSchedule_ddl.Items(1).Value) Then
			'				e.Row.BackColor = ColorTranslator.FromHtml("#afd8ff")
			'			End If

			'			ddlSchool.Items(1).Attributes.CssStyle.Add("background-color", "#afd8ff")
			'		Case 3
			'			If lblSchool = SchoolData.GetSchoolID(schoolNameSchedule_ddl.Items(1).Value) Then
			'				e.Row.BackColor = ColorTranslator.FromHtml("#afd8ff")
			'			ElseIf lblSchool = SchoolData.GetSchoolID(schoolNameSchedule_ddl.Items(2).Value) Then
			'				e.Row.BackColor = ColorTranslator.FromHtml("#ffafaf")
			'			End If

			'			ddlSchool.Items(1).Attributes.CssStyle.Add("background-color", "#afd8ff")
			'			ddlSchool.Items(2).Attributes.CssStyle.Add("background-color", "#ffafaf")
			'		Case 4
			'			If lblSchool = SchoolData.GetSchoolID(schoolNameSchedule_ddl.Items(1).Value) Then
			'				e.Row.BackColor = ColorTranslator.FromHtml("#afd8ff")
			'			ElseIf lblSchool = SchoolData.GetSchoolID(schoolNameSchedule_ddl.Items(2).Value) Then
			'				e.Row.BackColor = ColorTranslator.FromHtml("#ffafaf")
			'			ElseIf lblSchool = SchoolData.GetSchoolID(schoolNameSchedule_ddl.Items(3).Value) Then
			'				e.Row.BackColor = ColorTranslator.FromHtml("#bfffaf")
			'			End If

			'			ddlSchool.Items(1).Attributes.CssStyle.Add("background-color", "#afd8ff")
			'			ddlSchool.Items(2).Attributes.CssStyle.Add("background-color", "#ffafaf")
			'			ddlSchool.Items(3).Attributes.CssStyle.Add("background-color", "#bfffaf")
			'		Case 5
			'			If lblSchool = SchoolData.GetSchoolID(schoolNameSchedule_ddl.Items(1).Value) Then
			'				e.Row.BackColor = ColorTranslator.FromHtml("#afd8ff")
			'			ElseIf lblSchool = SchoolData.GetSchoolID(schoolNameSchedule_ddl.Items(2).Value) Then
			'				e.Row.BackColor = ColorTranslator.FromHtml("#ffafaf")
			'			ElseIf lblSchool = SchoolData.GetSchoolID(schoolNameSchedule_ddl.Items(3).Value) Then
			'				e.Row.BackColor = ColorTranslator.FromHtml("#bfffaf")
			'			ElseIf lblSchool = SchoolData.GetSchoolID(schoolNameSchedule_ddl.Items(4).Value) Then
			'				e.Row.BackColor = ColorTranslator.FromHtml("#afc3ff")
			'			End If

			'			ddlSchool.Items(1).Attributes.CssStyle.Add("background-color", "#afd8ff")
			'			ddlSchool.Items(2).Attributes.CssStyle.Add("background-color", "#ffafaf")
			'			ddlSchool.Items(3).Attributes.CssStyle.Add("background-color", "#bfffaf")
			'			ddlSchool.Items(4).Attributes.CssStyle.Add("background-color", "#afc3ff")
			'		Case 6
			'			If lblSchool = SchoolData.GetSchoolID(schoolNameSchedule_ddl.Items(1).Value) Then
			'				e.Row.BackColor = ColorTranslator.FromHtml("#afd8ff")
			'			ElseIf lblSchool = SchoolData.GetSchoolID(schoolNameSchedule_ddl.Items(2).Value) Then
			'				e.Row.BackColor = ColorTranslator.FromHtml("#ffafaf")
			'			ElseIf lblSchool = SchoolData.GetSchoolID(schoolNameSchedule_ddl.Items(3).Value) Then
			'				e.Row.BackColor = ColorTranslator.FromHtml("#bfffaf")
			'			ElseIf lblSchool = SchoolData.GetSchoolID(schoolNameSchedule_ddl.Items(4).Value) Then
			'				e.Row.BackColor = ColorTranslator.FromHtml("#afc3ff")
			'			ElseIf lblSchool = SchoolData.GetSchoolID(schoolNameSchedule_ddl.Items(5).Value) Then
			'				e.Row.BackColor = ColorTranslator.FromHtml("#ffd8af")
			'			End If

			'			ddlSchool.Items(1).Attributes.CssStyle.Add("background-color", "#afd8ff")
			'			ddlSchool.Items(2).Attributes.CssStyle.Add("background-color", "#ffafaf")
			'			ddlSchool.Items(3).Attributes.CssStyle.Add("background-color", "#bfffaf")
			'			ddlSchool.Items(4).Attributes.CssStyle.Add("background-color", "#afc3ff")
			'			ddlSchool.Items(5).Attributes.CssStyle.Add("background-color", "#ffd8af")
			'	End Select
			If schoolNameCheckin_ddl.Visible = True Then ' And schoolNameSchedule_ddl.Visible = False
				Select Case schoolNameCheckin_ddl.Items.Count
					Case 2
						If lblSchool = SchoolData.GetSchoolID(schoolNameCheckin_ddl.Items(1).Value) Then
							e.Row.BackColor = ColorTranslator.FromHtml("#afd8ff")
						End If

						ddlSchool.Items(1).Attributes.CssStyle.Add("background-color", "#afd8ff")
					Case 3
						If lblSchool = SchoolData.GetSchoolID(schoolNameCheckin_ddl.Items(1).Value) Then
							e.Row.BackColor = ColorTranslator.FromHtml("#afd8ff")
						ElseIf lblSchool = SchoolData.GetSchoolID(schoolNameCheckin_ddl.Items(2).Value) Then
							e.Row.BackColor = ColorTranslator.FromHtml("#ffafaf")
						End If

						ddlSchool.Items(1).Attributes.CssStyle.Add("background-color", "#afd8ff")
						ddlSchool.Items(2).Attributes.CssStyle.Add("background-color", "#ffafaf")
					Case 4
						If lblSchool = SchoolData.GetSchoolID(schoolNameCheckin_ddl.Items(1).Value) Then
							e.Row.BackColor = ColorTranslator.FromHtml("#afd8ff")
						ElseIf lblSchool = SchoolData.GetSchoolID(schoolNameCheckin_ddl.Items(2).Value) Then
							e.Row.BackColor = ColorTranslator.FromHtml("#ffafaf")
						ElseIf lblSchool = SchoolData.GetSchoolID(schoolNameCheckin_ddl.Items(3).Value) Then
							e.Row.BackColor = ColorTranslator.FromHtml("#bfffaf")
						End If

						ddlSchool.Items(1).Attributes.CssStyle.Add("background-color", "#afd8ff")
						ddlSchool.Items(2).Attributes.CssStyle.Add("background-color", "#ffafaf")
						ddlSchool.Items(3).Attributes.CssStyle.Add("background-color", "#bfffaf")
					Case 5
						If lblSchool = SchoolData.GetSchoolID(schoolNameCheckin_ddl.Items(1).Value) Then
							e.Row.BackColor = ColorTranslator.FromHtml("#afd8ff")
						ElseIf lblSchool = SchoolData.GetSchoolID(schoolNameCheckin_ddl.Items(2).Value) Then
							e.Row.BackColor = ColorTranslator.FromHtml("#ffafaf")
						ElseIf lblSchool = SchoolData.GetSchoolID(schoolNameCheckin_ddl.Items(3).Value) Then
							e.Row.BackColor = ColorTranslator.FromHtml("#bfffaf")
						ElseIf lblSchool = SchoolData.GetSchoolID(schoolNameCheckin_ddl.Items(4).Value) Then
							e.Row.BackColor = ColorTranslator.FromHtml("#afc3ff")
						End If

						ddlSchool.Items(1).Attributes.CssStyle.Add("background-color", "#afd8ff")
						ddlSchool.Items(2).Attributes.CssStyle.Add("background-color", "#ffafaf")
						ddlSchool.Items(3).Attributes.CssStyle.Add("background-color", "#bfffaf")
						ddlSchool.Items(4).Attributes.CssStyle.Add("background-color", "#afc3ff")
					Case 6
						If lblSchool = SchoolData.GetSchoolID(schoolNameCheckin_ddl.Items(1).Value) Then
							e.Row.BackColor = ColorTranslator.FromHtml("#afd8ff")
						ElseIf lblSchool = SchoolData.GetSchoolID(schoolNameCheckin_ddl.Items(2).Value) Then
							e.Row.BackColor = ColorTranslator.FromHtml("#ffafaf")
						ElseIf lblSchool = SchoolData.GetSchoolID(schoolNameCheckin_ddl.Items(3).Value) Then
							e.Row.BackColor = ColorTranslator.FromHtml("#bfffaf")
						ElseIf lblSchool = SchoolData.GetSchoolID(schoolNameCheckin_ddl.Items(4).Value) Then
							e.Row.BackColor = ColorTranslator.FromHtml("#afc3ff")
						ElseIf lblSchool = SchoolData.GetSchoolID(schoolNameCheckin_ddl.Items(5).Value) Then
							e.Row.BackColor = ColorTranslator.FromHtml("#ffd8af")
						End If

						ddlSchool.Items(1).Attributes.CssStyle.Add("background-color", "#afd8ff")
						ddlSchool.Items(2).Attributes.CssStyle.Add("background-color", "#ffafaf")
						ddlSchool.Items(3).Attributes.CssStyle.Add("background-color", "#bfffaf")
						ddlSchool.Items(4).Attributes.CssStyle.Add("background-color", "#afc3ff")
						ddlSchool.Items(5).Attributes.CssStyle.Add("background-color", "#ffd8af")
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



	'All button controls (most go to another sub or function)
	Protected Sub submit_btn_Click(sender As Object, e As EventArgs) Handles submit_btn.Click
		SubmitAddNewVolunteer()
	End Sub

	Protected Sub submitSchedule_btn_Click(sender As Object, e As EventArgs) Handles submitSchedule_btn.Click
		SubmitScheduleVolunteers()
	End Sub

	Protected Sub submitCheckIn_btn_Click(sender As Object, e As EventArgs) Handles submitCheckIn_btn.Click
		If visitDateCheckin_tb.Text <> Nothing Then
			Dim VIDOfDate As Integer = VisitData.GetVisitIDFromDate(visitDateCheckin_tb.Text)
			SubmitCheckIn(VIDOfDate)
		End If
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

	Protected Sub businessAssignments_btn_Click(sender As Object, e As EventArgs) Handles businessAssignments_btn.Click
		Dim URL As String = "/pages/edit/Open_Closed_Status.aspx"
		Dim VisitID As String = ""
		Dim VisitDate As String = ""

		If visitDateCheckin_tb.Text <> "" Then
			VisitDate = visitDateCheckin_tb.Text
		Else
			VisitDate = ""
		End If

		'Check if visit date has been selected or entered
		If VisitDate <> "" Then

			'get visit id of selected visit date
			If VisitDate <> "" Then
				VisitID = VisitData.GetVisitIDFromDate(VisitDate)
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
			addVol_div.Visible = True
			scheduleVol_div.Visible = False
			checkIn_div.Visible = False
			viewVolControls_div.Visible = False

			'Clear error label and visit date
			error_lbl.Text = ""
			visitDateCheckin_tb.Text = ""
			'volNameSchedule_ddl.SelectedIndex = 0

			LoadData()

		End If

	End Sub

	Protected Sub scheduleVol_btn_Click(sender As Object, e As EventArgs) Handles scheduleVol_btn.Click

		'Reveal add volunteer section if not revealed
		If scheduleVol_div.Visible = False Then
			addVol_div.Visible = False
			scheduleVol_div.Visible = True
			checkIn_div.Visible = False
			viewVolControls_div.Visible = False

			'Clear error label and visit date
			error_lbl.Text = ""
			visitDateCheckin_tb.Text = ""

			LoadData()
		End If

	End Sub

	Protected Sub checkIn_btn_Click(sender As Object, e As EventArgs) Handles checkIn_btn.Click

		'Reveal check in section
		If checkIn_div.Visible = False Then
			checkIn_div.Visible = True
			addVol_div.Visible = False
			scheduleVol_div.Visible = False
			viewVolControls_div.Visible = False

			'Clear error label and visit date
			error_lbl.Text = ""
			visitDateCheckin_tb.Text = ""
			volNameSchedule_ddl.SelectedIndex = 0

			LoadData()
		End If

	End Sub

	Protected Sub viewVol_btn_Click(sender As Object, e As EventArgs) Handles viewVol_btn.Click
		addVol_div.Visible = False
		scheduleVol_div.Visible = False
		checkIn_div.Visible = False
		viewVol_div.Visible = False
		viewVolControls_div.Visible = True

		LoadVolunteerNameDDL(volNameViewVolCtrl_ddl)
	End Sub



	'All textbox functions
	Protected Sub visitDateCheckin_tb_TextChanged(sender As Object, e As EventArgs) Handles visitDateCheckin_tb.TextChanged
		If visitDateCheckin_tb.Text <> Nothing Then
			schoolNameCheckin_ddl.Visible = True
			schoolNameCheckin_a.Visible = True

			'Load schools associated with selected visit date
			SchoolData.LoadVisitDateSchoolsDDL(visitDateCheckin_tb.Text, schoolNameCheckin_ddl)

			'Add an option to show all the volunteers for a visit date
			schoolNameCheckin_ddl.Items.RemoveAt(0)
			schoolNameCheckin_ddl.Items.Insert(0, "Show All Schools")

			'Assign colors to school DDL text
			Select Case schoolNameCheckin_ddl.Items.Count
				Case 1
					'The first item in the DDL is the Show All Schools item, does not need to change color
				Case 2
					schoolNameCheckin_ddl.Items(1).Attributes.CssStyle.Add("background-color", "#afd8ff")
				Case 3
					schoolNameCheckin_ddl.Items(1).Attributes.CssStyle.Add("background-color", "#afd8ff")
					schoolNameCheckin_ddl.Items(2).Attributes.CssStyle.Add("background-color", "#ffafaf")

				Case 4
					schoolNameCheckin_ddl.Items(1).Attributes.CssStyle.Add("background-color", "#afd8ff")
					schoolNameCheckin_ddl.Items(2).Attributes.CssStyle.Add("background-color", "#ffafaf")
					schoolNameCheckin_ddl.Items(3).Attributes.CssStyle.Add("background-color", "#bfffaf")
				Case 5
					schoolNameCheckin_ddl.Items(1).Attributes.CssStyle.Add("background-color", "#afd8ff")
					schoolNameCheckin_ddl.Items(2).Attributes.CssStyle.Add("background-color", "#ffafaf")
					schoolNameCheckin_ddl.Items(3).Attributes.CssStyle.Add("background-color", "#bfffaf")
					schoolNameCheckin_ddl.Items(4).Attributes.CssStyle.Add("background-color", "#afc3ff")
				Case 6
					schoolNameCheckin_ddl.Items(1).Attributes.CssStyle.Add("background-color", "#afd8ff")
					schoolNameCheckin_ddl.Items(2).Attributes.CssStyle.Add("background-color", "#ffafaf")
					schoolNameCheckin_ddl.Items(3).Attributes.CssStyle.Add("background-color", "#bfffaf")
					schoolNameCheckin_ddl.Items(4).Attributes.CssStyle.Add("background-color", "#afc3ff")
					schoolNameCheckin_ddl.Items(5).Attributes.CssStyle.Add("background-color", "#ffd8af")
			End Select

			LoadData()
		End If
	End Sub

	Protected Sub visitDateViewVolCtrl_tb_TextChanged(sender As Object, e As EventArgs) Handles visitDateViewVolCtrl_tb.TextChanged
		If visitDateViewVolCtrl_tb.Text <> Nothing Then

			'Make vol name ddl selected at 0
			volNameViewVolCtrl_ddl.SelectedIndex = 0

			'Load gridview
			LoadViewVolCtrlGridview()
		End If
	End Sub



	'All ddl functions
	Protected Sub schoolNameSchedule_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles schoolNameSchedule_ddl.SelectedIndexChanged
		If schoolNameSchedule_ddl.SelectedIndex <> 0 Then

			'Get school id and load volunteer names from school
			Dim SID As String = SchoolData.GetSchoolID(schoolNameSchedule_ddl.SelectedValue)
			LoadVolunteerNameDDL(volNameSchedule_ddl, SID)
		Else
			LoadVolunteerNameDDL(volNameSchedule_ddl)
		End If
	End Sub

	Protected Sub schoolNameCheckin_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles schoolNameCheckin_ddl.SelectedIndexChanged
		LoadData()
	End Sub

	Protected Sub volNameSchedule_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles volNameSchedule_ddl.SelectedIndexChanged
		If volNameSchedule_ddl.SelectedIndex <> 0 Then
			AddVolIntoTable()

			'Reveal table div
			scheduledVol_div.Visible = True
		End If

	End Sub

	Protected Sub volNameViewVolCtrl_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles volNameViewVolCtrl_ddl.SelectedIndexChanged
		If volNameViewVolCtrl_ddl.SelectedIndex <> 0 Then

			'Make visit date clear
			visitDateViewVolCtrl_tb.Text = ""

			'Load gridview
			LoadViewVolCtrlGridview()
		End If
	End Sub
End Class