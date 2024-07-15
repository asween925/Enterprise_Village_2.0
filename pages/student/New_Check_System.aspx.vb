Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Security.Policy
Imports System.Web.UI.WebControls.Expressions

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
    Dim Businesses As New Class_BusinessData
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
                    contentCS_div.Attributes("class") = "CS_BG_bucs"
                Case 2 'Rays
                    contentCS_div.Attributes("class") = "CS_BG_rays"
                Case 3 'CVS
                    contentCS_div.Attributes("class") = "CS_BG_cvs"
                Case 5 'Kanes
                    contentCS_div.Attributes("class") = "CS_BG_kanes"
                Case 6 'Bic
                    contentCS_div.Attributes("class") = "CS_BG_bic"
                Case 7 'TD SYNNEX
                    contentCS_div.Attributes("class") = "CS_BG_td"
                Case 8 'HSN
                    contentCS_div.Attributes("class") = "CS_BG_hsn"
                Case 9 'BBB
                    contentCS_div.Attributes("class") = "CS_BG_bbb"
                Case 10 'Astro
                    contentCS_div.Attributes("class") = "CS_BG_astro"
                Case 11 'Ditek
                    contentCS_div.Attributes("class") = "CS_BG_ditek"
                    StepID = 1
                Case 12 'Achieva
                    contentCS_div.Attributes("class") = "CS_BG_boa"
                    F2URL.Visible = False
                Case 13 ' BayCare
                    contentCS_div.Attributes("class") = "CS_BG_baycare"
                    F2URL.Visible = False
                Case 14 'City Hall
                    contentCS_div.Attributes("class") = "CS_BG_city"
                    F2URL.Visible = False
                Case 16 'Duke
                    contentCS_div.Attributes("class") = "CS_BG_duke"
                Case 17 'McDonalds
                    contentCS_div.Attributes("class") = "CS_BG_mcd"
                    error_lbl.ForeColor = Color.White
                Case 18 'Mix
                    contentCS_div.Attributes("class") = "CS_BG_mix"
                Case 19 'PCSW
                    contentCS_div.Attributes("class") = "CS_BG_pcsw"
                Case 21 'KnowBE4
                    contentCS_div.Attributes("class") = "CS_BG_knowbe4"
                Case 22 'Times
                    contentCS_div.Attributes("class") = "CS_BG_times"
                Case 24 'United Way
                    contentCS_div.Attributes("class") = "CS_BG_united"
            End Select

            'Load students into DDL
            Students.LoadStudentWithIDValueDDL(students1_ddl, BusinessID, VisitID)
            Students.LoadStudentWithIDValueDDL(students2_ddl, BusinessID, VisitID)
            Students.LoadStudentWithIDValueDDL(students3_ddl, BusinessID, VisitID)
            Students.LoadStudentWithIDValueDDL(students4_ddl, BusinessID, VisitID)

            'Get business name, logo, and address Assign to labels
            Try
                Dim Biz = Businesses.GetBusinessLogos(BusinessID)
                businessName1_lbl.Text = Biz.BusinessName.ToString()
                businessName2_lbl.Text = Biz.BusinessName.ToString()
                businessName3_lbl.Text = Biz.BusinessName.ToString()
                businessName4_lbl.Text = Biz.BusinessName.ToString()

                imgStartLogo.ImageUrl = Biz.ImagePath

                address1_lbl.Text = Businesses.GetBusinessAddress(Biz.BusinessName.ToString())
                address2_lbl.Text = Businesses.GetBusinessAddress(Biz.BusinessName.ToString())
                address3_lbl.Text = Businesses.GetBusinessAddress(Biz.BusinessName.ToString())
                address4_lbl.Text = Businesses.GetBusinessAddress(Biz.BusinessName.ToString())

            Catch ex As Exception
                error_lbl.Text = "Error in PageLoad. Could not get business name, logo, or address."
                Exit Sub
            End Try

            'Assign date to label
            currentDate1_lbl.Text = DateTime.Now.ToString("MM/dd/yyyy")
            currentDate2_lbl.Text = DateTime.Now.ToString("MM/dd/yyyy")
            currentDate3_lbl.Text = DateTime.Now.ToString("MM/dd/yyyy")
            currentDate4_lbl.Text = DateTime.Now.ToString("MM/dd/yyyy")

            'Update title of web tab
            Me.Title = businessName1_lbl.Text & " Payroll Checks"

            'Load gridview with existing checks
            LoadData()

        End If

    End Sub

    Sub LoadData()
        'Check for payroll group number

        'Check how many checks were saved

        'Reveal all checks that were saved (1-4)

        'Load in check data
    End Sub

    Sub WrittenAmount(CheckNumber As Integer, DollarAmount As String)
        Select Case CheckNumber
            Case 1
                If DollarAmount = "$7.00" Then
                    writtenAmount1_tb.Text = "Seven and 00/100"
                ElseIf DollarAmount = "$6.50" Then
                    writtenAmount1_tb.Text = "Six and 50/100"
                Else
                    writtenAmount1_tb.Text = "Six and 00/100"
                End If
            Case 2
                If DollarAmount = "$7.00" Then
                    writtenAmount2_tb.Text = "Seven and 00/100"
                ElseIf DollarAmount = "$6.50" Then
                    writtenAmount2_tb.Text = "Six and 50/100"
                Else
                    writtenAmount2_tb.Text = "Six and 00/100"
                End If
            Case 3
                If DollarAmount = "$7.00" Then
                    writtenAmount3_tb.Text = "Seven and 00/100"
                ElseIf DollarAmount = "$6.50" Then
                    writtenAmount3_tb.Text = "Six and 50/100"
                Else
                    writtenAmount3_tb.Text = "Six and 00/100"
                End If
            Case 4
                If DollarAmount = "$7.00" Then
                    writtenAmount4_tb.Text = "Seven and 00/100"
                ElseIf DollarAmount = "$6.50" Then
                    writtenAmount4_tb.Text = "Six and 50/100"
                Else
                    writtenAmount4_tb.Text = "Six and 00/100"
                End If
        End Select
    End Sub

    Sub SaveCheck()
        'Dim StudentID As Integer = students_ddl.SelectedValue.ToString
        'Dim CheckAmount As String = Position_ddl.SelectedValue.ToString.Remove(0, 1)
        'Dim Timestamp As DateTime = DateTime.Now
        'Dim TimestampSTR As String = Timestamp.ToString("yyyy-MM-dd HH:mm:ss")
        'Dim WrittenAmount As String = Written_amount_tb.Text
        'Dim Memo As String = memo_ddl.SelectedItem.ToString

        ''Get student count
        'studentCount = students_ddl.Items.Count - 1

        ''Clear error label
        'error_lbl.Text = ""

        'If save_check_btn.Text = "Add Check" Then
        '    students_ddl.SelectedIndex = 0
        '    Position_ddl.SelectedIndex = 0
        '    Written_amount_tb.Text = Nothing
        '    Print_checks_btn.Text = "Review"
        '    Delete_Current_btn.Enabled = False
        '    Next_btn.Enabled = False
        '    Previous_btn.Enabled = False
        '    students_ddl.Enabled = True
        '    Position_ddl.Enabled = True

        '    'Change text save check button
        '    save_check_btn.Text = "Save Check"

        'ElseIf save_check_btn.Text = "Save Check" Then

        '    'Check for errors
        '    If students_ddl.SelectedIndex = 0 And Position_ddl.SelectedIndex = 0 And memo_ddl.SelectedIndex = 0 Then
        '        error_lbl.Text = "Operation failed. No student name, memo, or payment inputed."
        '        Exit Sub
        '    ElseIf students_ddl.SelectedIndex <> 0 And Position_ddl.SelectedIndex = 0 And memo_ddl.SelectedIndex = 0 Then
        '        error_lbl.Text = "Operation failed. No memo or payment inputed."
        '        Exit Sub
        '    ElseIf students_ddl.SelectedIndex <> 0 And Position_ddl.SelectedIndex <> 0 And memo_ddl.SelectedIndex = 0 Then
        '        error_lbl.Text = "Operation failed. No memo inputed."
        '        Exit Sub
        '    ElseIf students_ddl.SelectedIndex = 0 And Position_ddl.SelectedIndex <> 0 And memo_ddl.SelectedIndex = 0 Then
        '        error_lbl.Text = "Operation failed. No student name or memo inputed."
        '        Exit Sub
        '    ElseIf students_ddl.SelectedIndex = 0 And Position_ddl.SelectedIndex <> 0 And memo_ddl.SelectedIndex <> 0 Then
        '        error_lbl.Text = "Operation failed. No student memo or payment inputed."
        '        Exit Sub
        '    ElseIf students_ddl.SelectedIndex <> 0 And Position_ddl.SelectedIndex = 0 And memo_ddl.SelectedIndex <> 0 Then
        '        error_lbl.Text = "Operation failed. No payment inputed."
        '        Exit Sub
        '    ElseIf students_ddl.SelectedIndex = 0 And Position_ddl.SelectedIndex = 0 And memo_ddl.SelectedIndex <> 0 Then
        '        error_lbl.Text = "Operation failed. No student name or payment inputed."
        '        Exit Sub
        '    ElseIf students_ddl.SelectedIndex = 0 Or Position_ddl.SelectedIndex = 0 Or memo_ddl.SelectedIndex = 0 Then
        '        error_lbl.Text = "Operation failed. Please enter all information in the check before saving."
        '        Exit Sub
        '    End If

        '    'If existing checks is not 0, enable the print button
        '    If existingChecks_dgv.Rows.Count <> 0 Then
        '        Print_checks_btn.Enabled = True
        '    Else
        '        Print_checks_btn.Enabled = False
        '    End If

        '    'Check if selected has already been saved
        '    Try
        '        Checks.CheckForCheck(VisitID, BusinessID, Memo, StudentID)
        '    Catch
        '        error_lbl.Text = "Error in SaveCheck(). Cannot check if check has been saved before."
        '        Exit Sub
        '    End Try

        '    'Insert new check into database
        '    Try
        '        Checks.InsertNewCheck(BusinessID, StudentID, CheckAmount, WrittenAmount, VisitID, TimestampSTR, Memo)
        '    Catch ex As Exception
        '        error_lbl.Text = "Error in SaveCheck(). Cannot insert check into database."
        '    End Try

        '    'Load payroll group
        '    Check_selector_ddl.SelectedIndex = memo_ddl.SelectedIndex

        '    'Load data
        '    LoadData()
        '    'CheckGroups()

        '    'Get updated check number
        '    Check_que_lbl.Text = existingChecks_dgv.Rows.Count

        '    'Check if new check saved reached the max number of students in the business
        '    If existingChecks_dgv.Rows.Count = studentCount Then
        '        error_lbl.Text = "You have a check saved for each person in your business. Please click 'Review' to see your saved checks and print them out."
        '        Exit Sub
        '    End If

        '    'Reset check data
        '    students_ddl.SelectedIndex = 0
        '    Position_ddl.SelectedIndex = 0
        '    Written_amount_tb.Text = Nothing
        'Check if main check is selected

        'Check if name and position are not blank

        'Save check data to database

        'Load data
    End Sub


    Protected Sub F1URL_Click(sender As Object, e As EventArgs) Handles F1URL.Click
        Response.Redirect("operating_checks.aspx?b=" & BusinessID)
    End Sub

    Protected Sub F2URL_Click(sender As Object, e As EventArgs) Handles F2URL.Click
        Response.Redirect("online_banking.aspx?b=" & BusinessID)
    End Sub

    Protected Sub save_btn_Click(sender As Object, e As EventArgs) Handles save_btn.Click
        SaveCheck()
    End Sub


    Protected Sub Position1_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Position1_ddl.SelectedIndexChanged
        If Position1_ddl.SelectedIndex <> 0 Then
            WrittenAmount(1, Position1_ddl.SelectedValue)
        End If
    End Sub

    Protected Sub Position2_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Position2_ddl.SelectedIndexChanged
        If Position2_ddl.SelectedIndex <> 0 Then
            WrittenAmount(2, Position2_ddl.SelectedValue)
        End If
    End Sub

    Protected Sub Position3_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Position3_ddl.SelectedIndexChanged
        If Position3_ddl.SelectedIndex <> 0 Then
            WrittenAmount(3, Position3_ddl.SelectedValue)
        End If
    End Sub

    Protected Sub Position4_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Position4_ddl.SelectedIndexChanged
        If Position4_ddl.SelectedIndex <> 0 Then
            WrittenAmount(4, Position4_ddl.SelectedValue)
        End If
    End Sub
End Class