Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Drawing

Public Class Check_Writing_System
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
    Dim DBConnection As New DatabaseConection
    Dim dr As SqlDataReader
    Dim dr2 As SqlDataReader
    Dim logoRoot As String = "~/media/Logos/"
    Public CheckStart As Integer = 1
    Public CheckEnd As Integer = 0
    Dim studentCount As String
    Dim Visits As New Class_VisitData
    Dim Students As New Class_StudentData
    Dim Businesses As New Class_BusinessData
    Dim Checks As New Class_CheckData
    Dim VisitID As Integer = Visits.GetVisitID
    Dim BusinessID As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Check for visit ID, if 0, disable all buttons and other functions
        If VisitID <> 0 Then
            visitdate_hf.Value = VisitID
        Else
            Label2.Text = "No visit date! Please go to 'Create a Visit' on the Home page to make a visit date."
            Check_que_lbl.Text = ""
            F3URL.Enabled = False
            students_ddl.Enabled = False
            Position_ddl.Enabled = False
            memo_ddl.Enabled = False
            save_check_btn.Enabled = False
            Check_selector_ddl.Enabled = False
            Print_checks_btn.Enabled = False
            Previous_btn.Enabled = False
            Next_btn.Enabled = False
            Delete_Current_btn.Enabled = False
            F1URL.Enabled = False
            F2URL.Enabled = False
            Exit Sub
        End If

        'Assign business ID
        BusinessID = Request.QueryString("b")

        'Check if business ID is not 0
        If BusinessID = 0 Or BusinessID = Nothing Then
            error_lbl.Text = "No business ID found. Please load in the check writing system from the Business Directory to get started."
            Exit Sub
        End If

        'Check if loading from postback
        If Not (IsPostBack) Then

            'Update backgrounds for businesses
            Select Case BusinessID
                Case 1 'Bucs
                    check_system.Attributes("class") = "main_bucs"
                Case 2 'Rays
                    check_system.Attributes("class") = "main_rays"
                Case 3 'CVS
                    check_system.Attributes("class") = "main_cvs"
                Case 5 'Kanes
                    check_system.Attributes("class") = "main_kanes"
                Case 6 'Bic
                    check_system.Attributes("class") = "main_bic"
                Case 7 'TD SYNNEX
                    check_system.Attributes("class") = "main_td"
                Case 8 'HSN
                    check_system.Attributes("class") = "main_hsn"
                Case 9 'BBB
                    check_system.Attributes("class") = "main_bbb"
                Case 10 'Astro
                    check_system.Attributes("class") = "main_astro"
                Case 11 'Ditek
                    check_system.Attributes("class") = "main_ditek"
                    ditekCheckLists_div.Visible = False
                    step2header_h5.InnerText = "1"
                    F3URL.Visible = False
                Case 12 'Achieva
                    check_system.Attributes("class") = "main_boa"
                    F2URL.Visible = False
                Case 13 ' BayCare
                    check_system.Attributes("class") = "main_baycare"
                    F2URL.Visible = False
                Case 14 'City Hall
                    check_system.Attributes("class") = "main_city"
                    F2URL.Visible = False
                    ditekdir.Visible = True
                    ditekdir1.Visible = True
                    ditekdir2.Visible = True
                Case 16 'Duke
                    check_system.Attributes("class") = "main_duke"
                Case 17 'McDonalds
                    check_system.Attributes("class") = "main_mcd"
                    error_lbl.ForeColor = Color.White
                Case 18 'Mix
                    check_system.Attributes("class") = "main_mix"
                Case 19 'PCSW
                    check_system.Attributes("class") = "main_pcsw"
                Case 21 'KnowBE4
                    check_system.Attributes("class") = "main_knowbe4"
                Case 22 'Times
                    check_system.Attributes("class") = "main_times"
                Case 24 'United Way
                    check_system.Attributes("class") = "main_united"
            End Select

            'Load students into DDL
            Students.LoadStudentWithIDValueDDL(students_ddl, BusinessID, VisitID)

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
            F3URL.NavigateUrl = "Ditek_Check.aspx?B=" & BusinessID

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
        Dim PayPeriod As String = Check_selector_ddl.SelectedValue
        Dim row As GridViewRow

        'Clear out gridview
        existingChecks_dgv.DataSource = Nothing
        existingChecks_dgv.DataBind()

        'Reset table index
        tablerowIndex_hf.Value = 0

        'Name buttons
        Print_checks_btn.Text = "Review"
        save_check_btn.Text = "Save Check"

        'Get number of students in the DDL
        studentCount = students_ddl.Items.Count - 1

        'Load existing checks table
        Try
            Checks.LoadExistingPayrollChecksTable(existingChecks_dgv, BusinessID, VisitID, PayPeriod)
        Catch ex As Exception
            error_lbl.Text = "Error in LoadData. Cannot load existing checks table."
            Exit Sub
        End Try

        'If there are no checks in the table, disable the print checks button
        If existingChecks_dgv.Rows.Count <> 0 Then
            Print_checks_btn.Enabled = True
        Else
            Print_checks_btn.Enabled = False
        End If

        'If there are no checks saved or the check selector is blank, disable buttons and other functions
        If existingChecks_dgv.Rows.Count = 0 Or Check_selector_ddl.SelectedIndex = 0 Then
            Next_btn.Enabled = False
            Previous_btn.Enabled = False
            Delete_Current_btn.Enabled = False
            students_ddl.SelectedIndex = 0
            Position_ddl.SelectedIndex = 0
            Written_amount_tb.Text = Nothing
            error_lbl.Text = "No checks saved. Please fill out the check above and click 'Save Check' to continue."
            Exit Sub
        End If

        'Checking if the number of checks saved in the gridview matches the amount of students in the DDL, enables print button
        If existingChecks_dgv.Rows.Count = studentCount Then
            error_lbl.Text = "You have a check saved for each person in your business. Please make sure your saved checks are correct and click 'Print' to print them out."
            Print_checks_btn.Enabled = True
            students_ddl.Enabled = False
            Position_ddl.Enabled = False
            save_check_btn.Enabled = False
            memo_ddl.Enabled = False
            Next_btn.Enabled = False
            Previous_btn.Enabled = False
            Delete_Current_btn.Enabled = False
            memo_ddl.SelectedIndex = Check_selector_ddl.SelectedIndex
        End If

        'Checking if there is a check saved from a student whose business was changed after the check was made.
        Try
            row = existingChecks_dgv.Rows(0)
            students_ddl.SelectedValue = row.Cells(1).Text
        Catch
            error_lbl.Text = "Error in LoadData(). Check is saved with a student's name that is not assigned to business. Please contact tech support."
            Exit Sub
        End Try

        'Assign labels on the check
        Position_ddl.SelectedValue = "$" & row.Cells(2).Text
        Written_amount_tb.Text = row.Cells(3).Text
        memo_ddl.SelectedValue = row.Cells(4).Text

        'Update total number of checks saved
        Check_que_lbl.Text = existingChecks_dgv.Rows.Count

    End Sub

    Sub NextCheck()
        Dim maxRows As Integer = existingChecks_dgv.Rows.Count
        Dim rowIndex As Integer = Val(tablerowIndex_hf.Value)

        maxRows = maxRows - 1
        tablerowIndex_hf.Value = tablerowIndex_hf.Value + 1

        If tablerowIndex_hf.Value = maxRows Then
            Next_btn.Enabled = False
            Previous_btn.Enabled = True
            LoadChecks(tablerowIndex_hf.Value)
            Exit Sub
        Else

            Next_btn.Enabled = True
            Previous_btn.Enabled = True
            LoadChecks(tablerowIndex_hf.Value)
        End If
        'If Val(tablerowIndex_hf.Value) + 1 > Val(tablemaxRow_hf.Value) Then
        '    Next_btn.Enabled = False
        '    Previous_btn.Enabled = True
        '    Exit Sub
        'Else
        '    Dim rowIndex As Integer = Val(tablerowIndex_hf.Value)
        '    tablerowIndex_hf.Value = rowIndex + 1
        '    Next_btn.Enabled = True
        '    Previous_btn.Enabled = True
        '    LoadChecks(rowIndex + 1)
        'End If
    End Sub

    Sub PreviousCheck()
        Dim maxRows As Integer = existingChecks_dgv.Rows.Count
        Dim rowIndex As Integer = Val(tablerowIndex_hf.Value)

        maxRows = maxRows - 1
        tablerowIndex_hf.Value = tablerowIndex_hf.Value - 1

        If tablerowIndex_hf.Value = 0 Then
            Previous_btn.Enabled = False
            Next_btn.Enabled = True
            LoadChecks(tablerowIndex_hf.Value)
            Exit Sub
        Else

            Previous_btn.Enabled = True
            Next_btn.Enabled = True
            LoadChecks(tablerowIndex_hf.Value)
        End If
    End Sub

    Sub DeleteCheck()
        Dim row As GridViewRow = existingChecks_dgv.Rows(Val(tablerowIndex_hf.Value))
        Dim CheckID As Integer = row.Cells(0).Text

        'Check if students ddl, position ddl, or memo ddl is selected
        If students_ddl.SelectedIndex = 0 Or Position_ddl.SelectedIndex = 0 Or memo_ddl.SelectedIndex = 0 Then
            error_lbl.Text = "Cannot delete. Please click 'Review' to see your saved checks before deleting them."
            Exit Sub
        End If

        'Delete check from checksInfo table in DB
        Try
            Checks.DeleteCheck(CheckID)
        Catch ex As Exception
            error_lbl.Text = "Error in Delete(). Cannot delete check."
        End Try

        'Load data
        LoadData()
        'CheckGroups()
        Check_que_lbl.Text = existingChecks_dgv.Rows.Count

        'Reload the Review Checks button
        ReviewChecks()

        'If there are no checks, enable the students and position ddls
        If existingChecks_dgv.Rows.Count = 0 Then
            students_ddl.Enabled = True
            Position_ddl.Enabled = True
        End If
    End Sub

    Sub SaveCheck()
        Dim StudentID As Integer = students_ddl.SelectedValue.ToString
        Dim CheckAmount As String = Position_ddl.SelectedValue.ToString.Remove(0, 1)
        Dim Timestamp As DateTime = DateTime.Now
        Dim TimestampSTR As String = Timestamp.ToString("yyyy-MM-dd HH:mm:ss")
        Dim WrittenAmount As String = Written_amount_tb.Text
        Dim Memo As String = memo_ddl.SelectedItem.ToString

        'Get student count
        studentCount = students_ddl.Items.Count - 1

        'Clear error label
        error_lbl.Text = ""

        If save_check_btn.Text = "Add Check" Then
            students_ddl.SelectedIndex = 0
            Position_ddl.SelectedIndex = 0
            Written_amount_tb.Text = Nothing
            Print_checks_btn.Text = "Review"
            Delete_Current_btn.Enabled = False
            Next_btn.Enabled = False
            Previous_btn.Enabled = False
            students_ddl.Enabled = True
            Position_ddl.Enabled = True

            'Change text save check button
            save_check_btn.Text = "Save Check"

        ElseIf save_check_btn.Text = "Save Check" Then

            'Check for errors
            If students_ddl.SelectedIndex = 0 And Position_ddl.SelectedIndex = 0 And memo_ddl.SelectedIndex = 0 Then
                error_lbl.Text = "Operation failed. No student name, memo, or payment inputed."
                Exit Sub
            ElseIf students_ddl.SelectedIndex <> 0 And Position_ddl.SelectedIndex = 0 And memo_ddl.SelectedIndex = 0 Then
                error_lbl.Text = "Operation failed. No memo or payment inputed."
                Exit Sub
            ElseIf students_ddl.SelectedIndex <> 0 And Position_ddl.SelectedIndex <> 0 And memo_ddl.SelectedIndex = 0 Then
                error_lbl.Text = "Operation failed. No memo inputed."
                Exit Sub
            ElseIf students_ddl.SelectedIndex = 0 And Position_ddl.SelectedIndex <> 0 And memo_ddl.SelectedIndex = 0 Then
                error_lbl.Text = "Operation failed. No student name or memo inputed."
                Exit Sub
            ElseIf students_ddl.SelectedIndex = 0 And Position_ddl.SelectedIndex <> 0 And memo_ddl.SelectedIndex <> 0 Then
                error_lbl.Text = "Operation failed. No student memo or payment inputed."
                Exit Sub
            ElseIf students_ddl.SelectedIndex <> 0 And Position_ddl.SelectedIndex = 0 And memo_ddl.SelectedIndex <> 0 Then
                error_lbl.Text = "Operation failed. No payment inputed."
                Exit Sub
            ElseIf students_ddl.SelectedIndex = 0 And Position_ddl.SelectedIndex = 0 And memo_ddl.SelectedIndex <> 0 Then
                error_lbl.Text = "Operation failed. No student name or payment inputed."
                Exit Sub
            ElseIf students_ddl.SelectedIndex = 0 Or Position_ddl.SelectedIndex = 0 Or memo_ddl.SelectedIndex = 0 Then
                error_lbl.Text = "Operation failed. Please enter all information in the check before saving."
                Exit Sub
            End If

            'If existing checks is not 0, enable the print button
            If existingChecks_dgv.Rows.Count <> 0 Then
                Print_checks_btn.Enabled = True
            Else
                Print_checks_btn.Enabled = False
            End If

            'Check if selected has already been saved
            Try
                Checks.CheckForCheck(VisitID, BusinessID, Memo, StudentID)
            Catch
                error_lbl.Text = "Error in SaveCheck(). Cannot check if check has been saved before."
                Exit Sub
            End Try

            'Insert new check into database
            Try
                Checks.InsertNewCheck(BusinessID, StudentID, CheckAmount, WrittenAmount, VisitID, TimestampSTR, Memo)
            Catch ex As Exception
                error_lbl.Text = "Error in SaveCheck(). Cannot insert check into database."
            End Try

            'Load payroll group
            Check_selector_ddl.SelectedIndex = memo_ddl.SelectedIndex

            'Load data
            LoadData()
            'CheckGroups()

            'Get updated check number
            Check_que_lbl.Text = existingChecks_dgv.Rows.Count

            'Check if new check saved reached the max number of students in the business
            If existingChecks_dgv.Rows.Count = studentCount Then
                error_lbl.Text = "You have a check saved for each person in your business. Please click 'Review' to see your saved checks and print them out."
                Exit Sub
            End If

            'Reset check data
            students_ddl.SelectedIndex = 0
            Position_ddl.SelectedIndex = 0
            Written_amount_tb.Text = Nothing
        End If
    End Sub

    Sub ReviewChecks()
        Dim URLEnd As String = Nothing

        'Get student count of business
        studentCount = students_ddl.Items.Count - 1

        'If reviewing checks, 
        If Print_checks_btn.Text = "Review" Then

            'Load data
            LoadData()
            'CheckGroups()

            'Get number of existing checks
            Check_que_lbl.Text = existingChecks_dgv.Rows.Count

            'If no checks are saved, enable save button
            If existingChecks_dgv.Rows.Count = 0 Then
                save_check_btn.Enabled = True
                Delete_Current_btn.Enabled = False
                Next_btn.Enabled = False
                Previous_btn.Enabled = False
                save_check_btn.Text = "Save Check"

                'If student count matches existing check amount, disable saving button
            ElseIf existingChecks_dgv.Rows.Count = studentCount Then
                error_lbl.Text = "You have a check saved for each person in your business. Please make sure your saved checks are correct and click 'Print' to print them out."
                students_ddl.Enabled = False
                Position_ddl.Enabled = False
                save_check_btn.Enabled = False
                memo_ddl.Enabled = False

                'If there is only 1 person in the buisness then disable the next and prev buttons
                If studentCount = 1 Then
                    Next_btn.Enabled = False
                    Previous_btn.Enabled = False
                Else
                    Next_btn.Enabled = True
                    Previous_btn.Enabled = False
                End If

                'Enable delete button
                Delete_Current_btn.Enabled = True

                'Memo ddl is now the same as the payroll group ddl
                memo_ddl.SelectedIndex = Check_selector_ddl.SelectedIndex

                'If number of checks saved is less than the max but more than 0
            Else

                'Enable buttons and other functions
                save_check_btn.Enabled = True
                Delete_Current_btn.Enabled = True
                Next_btn.Enabled = True
                save_check_btn.Text = "Add Check"

                'Clear error
                error_lbl.Text = ""

                'Check if check loaded is the first one in the gridview, enable next but disable previous
                If tablerowIndex_hf.Value = 0 Then
                    Previous_btn.Enabled = False
                    Next_btn.Enabled = True
                End If

                'Check if there is only 1 check saved in the gridview
                If tablemaxRow_hf.Value = 1 Then
                    Next_btn.Enabled = False
                    Previous_btn.Enabled = False
                End If
            End If

            'Change button text to print
            Print_checks_btn.Text = "Print"

            'If printing checks,
        ElseIf Print_checks_btn.Text = "Print" Then

            'Get the URL end for the print checks page based on payroll group
            Select Case Check_selector_ddl.SelectedIndex
                Case 1
                    URLEnd = "&c1=1"
                Case 2
                    URLEnd = "&c1=2"
                Case 3
                    URLEnd = "&c1=3"
            End Select

            'Change print button text to review
            Print_checks_btn.Text = "Review"

            '--------------------------------------------------------------------------------------------------
            'UNCOMMENT THE 3 LINES BELOW TO REDIRECT THE PAYROLL 3 GROUP TO DIRECT DEPOSIT SLIPS
            If Check_selector_ddl.SelectedIndex = 3 Then
                Response.Redirect("/pages/print/Print_Direct_Deposit.aspx?b=" & BusinessID & URLEnd)
            End If
            '--------------------------------------------------------------------------------------------------

            'Go to print checks page
            Response.Redirect("/pages/print/Print_Checks.aspx?b=" & BusinessID & URLEnd)

        End If
    End Sub

    'Checking the number of groups (may not be needed, 6/3/2024)
    Sub CheckGroups()
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        'checkgroup_ddl.Items.Clear()

        Dim CheckInitials As New List(Of String)
        Dim CheckIds As New List(Of String)

        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd.CommandText = "SELECT ID FROM checksInfo
                                        WHERE businessID ='" & Request.QueryString("b") & "' 
                                        AND visitID='" & visitID_hf.Value & "' and memo='" & Check_selector_ddl.SelectedValue.ToString & "'
                                        ORDER BY id ASC"
            cmd.Connection = con
            dr = cmd.ExecuteReader

            While dr.Read()
                CheckIds.Add(dr("ID"))
            End While

            cmd.Dispose()
            con.Close()

        Catch
            error_lbl.Text = "Error in CheckGroups(). Cannot get check IDs."
        Finally
            cmd.Dispose()
            con.Close()
        End Try

        cmd.Dispose()
        con.Close()

        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd.CommandText = "SELECT LEFT(s.firstName,1) + '. ' + s.lastName AS initials 
                                          FROM checksInfo c
                                          INNER JOIN studentInfo s
                                          ON c.studentID = s.id
                                        WHERE c.businessID ='" & Request.QueryString("b") & "' 
                                        AND s.visitID='" & visitID_hf.Value & "' and c.memo='" & Check_selector_ddl.SelectedValue.ToString & "' AND c.visitID='" & visitID_hf.Value & "'
                                        ORDER BY c.id ASC"
            cmd.Connection = con
            dr = cmd.ExecuteReader

            While dr.Read()
                CheckInitials.Add(dr("initials"))
            End While

            cmd.Dispose()
            con.Close()

        Catch
            error_lbl.Text = "Error in CheckGroups(). Cannot get check initials."
        Finally
            cmd.Dispose()
            con.Close()
        End Try

        'While dr.Read()
        '    CheckIds.Add(dr("ID"))
        'End While

        'While dr2.Read()
        '    CheckInitials.Add(dr2("initials"))
        'End While

        Dim chunks2 As List(Of List(Of String)) = SplitIntoChunks(CheckInitials, 4)
        Dim chunks As List(Of List(Of String)) = SplitIntoChunks(CheckIds, 4)
        Dim valueString As String = Nothing
        Dim textString As String = Nothing

        For n As Integer = 0 To chunks2.Count - 1
            valueString = Nothing
            textString = Nothing
            CheckEnd = 0

            For Each ID As String In chunks(n)
                'Build value string
                valueString += ID & ","
            Next

            For Each name As String In chunks2(n)
                'Build value string
                textString += " " & name & ","
            Next

            textString = textString.TrimEnd(CChar(","))
            valueString = valueString.TrimEnd(CChar(","))

            Dim group As New ListItem

            group.Text = textString
            'group.Text = String.Join(", ", CheckInitials.ToArray())
            group.Value = valueString
            'checkgroup_ddl.Items.Add(group)

            'error_lbl.Text = existingChecks_dgv.Rows.Count

        Next
        Dim blankGroup As New ListItem
        blankGroup.Text = ""
        blankGroup.Value = ""
        'checkgroup_ddl.Items.Insert(0, blankGroup)
        cmd.Dispose()
        con.Close()

    End Sub

    Sub LoadChecks(ByVal rowIndex As Integer)
        Try
            Dim row As GridViewRow = existingChecks_dgv.Rows(rowIndex)
            students_ddl.SelectedValue = row.Cells(1).Text
            Position_ddl.SelectedValue = "$" & row.Cells(2).Text
            Written_amount_tb.Text = row.Cells(3).Text
            memo_ddl.SelectedValue = row.Cells(4).Text
        Catch
        End Try
    End Sub

    Private Function SplitIntoChunks(keys As List(Of String), chunkSize As Integer) As List(Of List(Of String))
        Return keys.
        Select(Function(x, i) New With {Key .Index = i, Key .Value = x}).
        GroupBy(Function(x) (x.Index \ chunkSize)).
        Select(Function(x) x.Select(Function(v) v.Value).ToList()).
        ToList()
    End Function



    Protected Sub Position_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Position_ddl.SelectedIndexChanged
        Select Case Position_ddl.SelectedItem.ToString
            Case "$6.00"
                Written_amount_tb.Text = "Six and 00/100"
            Case "$6.50"
                Written_amount_tb.Text = "Six and 50/100"
            Case "$7.00"
                Written_amount_tb.Text = "Seven and 00/100"
        End Select
    End Sub

    Private Sub Check_selector_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Check_selector_ddl.SelectedIndexChanged

        If Check_selector_ddl.SelectedIndex <> 0 Then
            LoadData()
            'CheckGroups()
            tablemaxRow_hf.Value = existingChecks_dgv.Rows.Count
            Check_que_lbl.Text = tablemaxRow_hf.Value
            studentCount = students_ddl.Items.Count - 1

            If existingChecks_dgv.Rows.Count = studentCount Then
                error_lbl.Text = "You have a check saved for each person in your business." & vbCrLf & "Please click 'Review' to see your saved checks and print them out."
                students_ddl.Enabled = False
                Position_ddl.Enabled = False
                save_check_btn.Enabled = False
                memo_ddl.Enabled = False
                Next_btn.Enabled = False
                Previous_btn.Enabled = False
                Delete_Current_btn.Enabled = False
                'checkgroup_ddl.Enabled = False
                memo_ddl.SelectedIndex = Check_selector_ddl.SelectedIndex
                Exit Sub
            Else
                students_ddl.SelectedIndex = 0
                Position_ddl.SelectedIndex = 0
                Written_amount_tb.Text = ""
                Previous_btn.Enabled = False
                Next_btn.Enabled = False
                Delete_Current_btn.Enabled = False
                students_ddl.Enabled = True
                Position_ddl.Enabled = True
                save_check_btn.Enabled = True
                'New_check_btn.Enabled = True
                error_lbl.Text = ""
                memo_ddl.SelectedIndex = Check_selector_ddl.SelectedIndex
                Print_checks_btn.Text = "Review"

                If existingChecks_dgv.Rows.Count <> 0 Then
                    Print_checks_btn.Enabled = True
                Else
                    Print_checks_btn.Enabled = False
                End If

            End If
        End If

    End Sub

    Protected Sub students_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles students_ddl.SelectedIndexChanged
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim studentsValue As String

        studentsValue = students_ddl.SelectedValue.ToString

        'empNum_lbl.Text = studentsValue
    End Sub



    Protected Sub Next_btn_Click(sender As Object, e As EventArgs) Handles Next_btn.Click
        NextCheck()
    End Sub

    Protected Sub Previous_btn_Click(sender As Object, e As EventArgs) Handles Previous_btn.Click
        PreviousCheck()
    End Sub

    Protected Sub Delete_Current_btn_Click(sender As Object, e As EventArgs) Handles Delete_Current_btn.Click
        DeleteCheck()
    End Sub

    Protected Sub save_check_btn_Click(sender As Object, e As EventArgs) Handles save_check_btn.Click
        SaveCheck()
    End Sub

    Private Sub Print_checks_btn_Click(sender As Object, e As EventArgs) Handles Print_checks_btn.Click
        ReviewChecks()
    End Sub

    Protected Sub help_btn_Click(sender As Object, e As EventArgs) Handles help_btn.Click
        help_div.Visible = True
    End Sub

    Protected Sub close_btn_Click(sender As Object, e As EventArgs) Handles close_btn.Click
        help_div.Visible = False
    End Sub



End Class