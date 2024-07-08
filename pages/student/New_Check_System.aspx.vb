Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Security.Policy

Public Class New_Check_System
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim DBConnection As New DatabaseConection
    Dim dr As SqlDataReader
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
    Dim Visits As New Class_VisitData
    Dim Students As New Class_StudentData
    Dim VisitID As Integer = Visits.GetVisitID
    Dim BusinessID As Integer
    Dim StepID As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Check if visit date has been created
        If Not (IsPostBack) Then
            If VisitID <> 0 Then
                visitdate_hf.Value = VisitID
            End If

            'Assign business ID
            BusinessID = Request.QueryString("b")

            'Check which step the FO is on
            If StepID = Nothing Then

                'Open beginning pop up window
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "Popup", "togglePopup();", True)

            ElseIf StepID = 1 Then

                'Open pop up, switch div

            End If

            'Update backgrounds for businesses
            Select Case BusinessID
                Case 1 'Bucs
                    contentCS_div.Attributes("class") = "main_bucs"
                Case 2 'Rays
                    contentCS_div.Attributes("class") = "main_rays"
                Case 3 'CVS
                    contentCS_div.Attributes("class") = "main_cvs"
                Case 5 'Kanes
                    contentCS_div.Attributes("class") = "main_kanes"
                Case 6 'Bic
                    contentCS_div.Attributes("class") = "main_bic"
                Case 7 'TD SYNNEX
                    contentCS_div.Attributes("class") = "main_td"
                Case 8 'HSN
                    contentCS_div.Attributes("class") = "main_hsn"
                Case 9 'BBB
                    contentCS_div.Attributes("class") = "main_bbb"
                Case 10 'Astro
                    contentCS_div.Attributes("class") = "main_astro"
                Case 11 'Ditek
                    contentCS_div.Attributes("class") = "main_ditek"
                    StepID = 1
                Case 12 'Achieva
                    contentCS_div.Attributes("class") = "main_boa"
                    F2URL.Visible = False
                Case 13 ' BayCare
                    contentCS_div.Attributes("class") = "main_baycare"
                    F2URL.Visible = False
                Case 14 'City Hall
                    contentCS_div.Attributes("class") = "main_city"
                    F2URL.Visible = False
                Case 16 'Duke
                    contentCS_div.Attributes("class") = "main_duke"
                Case 17 'McDonalds
                    contentCS_div.Attributes("class") = "main_mcd"
                    error_lbl.ForeColor = Color.White
                Case 18 'Mix
                    contentCS_div.Attributes("class") = "main_mix"
                Case 19 'PCSW
                    contentCS_div.Attributes("class") = "main_pcsw"
                Case 21 'KnowBE4
                    contentCS_div.Attributes("class") = "main_knowbe4"
                Case 22 'Times
                    contentCS_div.Attributes("class") = "main_times"
                Case 24 'United Way
                    contentCS_div.Attributes("class") = "main_united"
            End Select

            'Load students into DDL
            Students.LoadStudentWithIDValueDDL(students1_ddl, BusinessID, VisitID)
            Students.LoadStudentWithIDValueDDL(students2_ddl, BusinessID, VisitID)
            Students.LoadStudentWithIDValueDDL(students3_ddl, BusinessID, VisitID)
            Students.LoadStudentWithIDValueDDL(students4_ddl, BusinessID, VisitID)


            'Check if payroll group 1, 2, 3, or nothing is selected
            If Check_selector_ddl.SelectedIndex = 0 Then
                Next_btn.Enabled = False
                Previous_btn.Enabled = False
                Delete_Current_btn.Enabled = False
                students_ddl.Enabled = False
                Position_ddl.Enabled = False
                Written_amount_tb.Text = Nothing
                Written_amount_tb.Enabled = False
                memo_ddl.Enabled = False
                Print_checks_btn.Enabled = False
                error_lbl.Text = "Please select a Payroll Group from" & vbCrLf & " the drop down list at the top before continuing."
            Else
                Print_checks_btn.Enabled = True
                students_ddl.Enabled = True
                Position_ddl.Enabled = True
                save_check_btn.Enabled = True
                'New_check_btn.Enabled = True
                memo_ddl.Enabled = False
                Next_btn.Enabled = False
                Previous_btn.Enabled = False
                Delete_Current_btn.Enabled = False
                error_lbl.Text = ""
            End If

            'Assign buttons to redirect to the business 
            F1URL.NavigateUrl = "Operating_Check_writing_system.aspx?B=" & BusinessID
            F2URL.NavigateUrl = "Online_Banking.aspx?B=" & BusinessID

            'Get business name, logo, and address Assign to labels
            Try
                Dim Biz = Businesses.GetBusinessLogos(BusinessID)
                business_name_lbl.Text = Biz.BusinessName.ToString()
                BusLogo_img.ImageUrl = Biz.ImagePath

                address_lbl.Text = Businesses.GetBusinessAddress(business_name_lbl.Text)

            Catch ex As Exception
                error_lbl.Text = "Error in PageLoad. Could not get business name, logo, or address."
                Exit Sub
            End Try

            'Assign date to label
            Label_date.Text = DateTime.Now.ToString("MM/dd/yyyy")

            'Update title of web tab
            Me.Title = business_name_lbl.Text & " Payroll Checks"

            'Load gridview with existing checks
            LoadData()

            'Checks the number of groups
            'CheckGroups()

            'get existing checks number and assign it to the check que label
            Check_que_lbl.Text = existingChecks_dgv.Rows.Count

            'Clear out check
            students_ddl.SelectedIndex = 0
            Position_ddl.SelectedIndex = 0
            Written_amount_tb.Text = Nothing
            memo_ddl.SelectedIndex = 0

        End If

    End Sub

    Sub LoadData()

    End Sub
End Class