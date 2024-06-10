Imports System.Data.SqlClient
Imports System.Drawing
Public Class Operating_Check_Writing_System
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
    Dim DBConnection As New DatabaseConection
    Dim dr As SqlDataReader
    Dim logoRoot As String = "~/media/Logos/"
    Dim Visits As New Class_VisitData
    Dim Students As New Class_StudentData
    Dim Businesses As New Class_BusinessData
    Dim Checks As New Class_CheckData
    Dim VisitID As Integer = Visits.GetVisitID
    Dim BusinessID As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not (IsPostBack) Then

            'Check for current visit
            If VisitID <> 0 Then
                visitID_hf.Value = VisitID
            Else
                Label2.Text = "No visit date, please go to 'Database Creator' on the 'Tools / Reports' page and create a new school visit date."
                Check_que_lbl.Text = ""
                business_tb.Enabled = False
                checkAmount_tb.Enabled = False
                Memo_tb.Enabled = False
                'New_check_btn.Enabled = False
                save_check_btn.Enabled = False
                operating_selector_ddl.Enabled = False
                checkgroup_ddl.Enabled = False
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

            'Assign operating text to side bar
            Try
                Dim Operating = Checks.GetOperatingText(BusinessID)
                operating1_lbl.Text = Operating.O1
                operating2_lbl.Text = Operating.O2
                operating3_lbl.Text = Operating.O3
                operating4_lbl.Text = Operating.O4
                operating5_lbl.Text = Operating.O5
                operating6_lbl.Text = Operating.O6
                operating7_lbl.Text = Operating.O7
                operating8_lbl.Text = Operating.O8
                operating9_lbl.Text = Operating.O9
                operating10_lbl.Text = Operating.O10
                operating11_lbl.Text = Operating.O11
                operating12_lbl.Text = Operating.O12
                'operating13_lbl.Text = Operating.O13

                'Checking if step 9, 10, 11, or 12 is not blank
                If Operating.O9 = Nothing Then
                    row9.Visible = False
                    rowstop1.Visible = False
                Else
                    row9.Visible = True
                    operating9_lbl.Text = Operating.O9
                End If

                If Operating.O10 = Nothing Then
                    row10.Visible = False
                Else
                    row10.Visible = True
                    operating10_lbl.Text = Operating.O10
                End If

                If Operating.O11 = Nothing Then
                    row11.Visible = False
                Else
                    row11.Visible = True
                    operating11_lbl.Text = Operating.O11
                End If

                If Operating.O12 = Nothing Then
                    row12.Visible = False
                Else
                    row12.Visible = True
                    operating12_lbl.Text = Operating.O12
                End If

            Catch
                error_lbl.Text = "Error in PageLoad(). Could not assign operating text."
                Exit Sub
            End Try

            'Checking if the operating group selector ddl is blank
            If operating_selector_ddl.SelectedIndex = 0 Then
                error_lbl.Text = "Please select an Operating Group from the drop down list at the top before continuing."
                business_tb.Enabled = False
                checkAmount_tb.Enabled = False
                save_check_btn.Enabled = False
                'New_check_btn.Enabled = False
                Memo_tb.Enabled = False
                writtenAmount_tb.Enabled = False
                Print_checks_btn.Enabled = False
                Next_btn.Enabled = False
                Previous_btn.Enabled = False
                Delete_Current_btn.Enabled = False
            Else
                business_tb.Enabled = True
                checkAmount_tb.Enabled = True
                save_check_btn.Enabled = True
                'New_check_btn.Enabled = True
                Memo_tb.Enabled = True
                writtenAmount_tb.Enabled = True
                Print_checks_btn.Enabled = True
                Next_btn.Enabled = True
                Previous_btn.Enabled = True
                Delete_Current_btn.Enabled = True
            End If

            'Load background colors and apply unique settings for businesses
            Select Case BusinessID
                Case 1
                    check_system.Attributes("class") = "main_bucs"
                Case 2
                    check_system.Attributes("class") = "main_rays"
                Case 3
                    check_system.Attributes("class") = "main_cvs"
                Case 5
                    check_system.Attributes("class") = "main_kanes"
                Case 6
                    check_system.Attributes("class") = "main_bic"
                Case 7
                    check_system.Attributes("class") = "main_td"
                Case 8
                    check_system.Attributes("class") = "main_hsn"
                Case 9
                    check_system.Attributes("class") = "main_bbb"
                Case 10
                    check_system.Attributes("class") = "main_astro"
                Case 11
                    check_system.Attributes("class") = "main_ditek"
                Case 12
                    check_system.Attributes("class") = "main_boa"
                    F2URL.Visible = False
                Case 13
                    check_system.Attributes("class") = "main_baycare"
                    F2URL.Visible = False
                Case 14
                    check_system.Attributes("class") = "main_city"
                    F2URL.Visible = False
                Case 16
                    check_system.Attributes("class") = "main_duke"
                Case 17
                    check_system.Attributes("class") = "main_mcd"
                Case 18
                    check_system.Attributes("class") = "main_mix"
                Case 19
                    check_system.Attributes("class") = "main_pcsw"
                Case 21
                    check_system.Attributes("class") = "main_knowbe4"
                Case 22
                    check_system.Attributes("class") = "main_times"
                Case 24
                    check_system.Attributes("class") = "main_united"
            End Select

            'Assign links to buttons
            F1URL.NavigateUrl = "Check_writing_system.aspx?B=" & BusinessID
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

            'Get and assign groups for checks
            CheckGroups()

            'Get updated total count for checks
            Check_que_lbl.Text = existingChecks_dgv.Rows.Count

            'Clear out the check after saving
            business_tb.Text = Nothing
            checkAmount_tb.Text = Nothing
            writtenAmount_tb.Text = Nothing
            Memo_tb.Text = ""
        End If

    End Sub

    Sub LoadData()
        Dim OperGroup As String = Nothing
        BusinessID = Request.QueryString("b")

        'Clear out gridview
        existingChecks_dgv.DataSource = Nothing
        existingChecks_dgv.DataBind()

        'Reset index value
        tablerowIndex_hf.Value = 0

        'Name buttons to their default
        Print_checks_btn.Text = "Review"
        save_check_btn.Text = "Save Check"

        'Assign operating group number
        Select Case operating_selector_ddl.SelectedIndex
            Case 0
                Exit Sub
            Case 1
                OperGroup = "1"
            Case 2
                OperGroup = "2"
            Case 3
                OperGroup = "3"
        End Select

        'Load existing operating checks gridview
        Try
            Checks.LoadExistingOperatingChecksTable(existingChecks_dgv, BusinessID, VisitID, OperGroup)
        Catch ex As Exception
            error_lbl.Text = "Error in LoadData. Cannot load existing checks table."
            Exit Sub
        End Try

        'Checking if there is no checks saved
        If existingChecks_dgv.Rows.Count = 0 Then
            'May need to show message that there are no existing saved Checks.
            Next_btn.Enabled = False
            Previous_btn.Enabled = False
            Delete_Current_btn.Enabled = False
            Print_checks_btn.Enabled = False
            business_tb.Text = Nothing
            checkAmount_tb.Text = Nothing
            writtenAmount_tb.Text = Nothing
            Memo_tb.Text = Nothing
            Label2.Text = "Number of Checks for Selected Operating Group: "
            business_tb.Enabled = True
            checkAmount_tb.Enabled = True
            Memo_tb.Enabled = True
            F1URL.Visible = True
            F2URL.Visible = True
            Exit Sub

            'If checks saved equals 4 for the operating group
        ElseIf existingChecks_dgv.Rows.Count = 4 Then
            save_check_btn.Enabled = False
            error_lbl.Text = "You cannot save anymore checks to this operating group. Please click 'Review' to see your saved checks and print them out."
            Next_btn.Enabled = False
            Previous_btn.Enabled = False
            Delete_Current_btn.Enabled = False

            'If checks saved is not 0 or 4
        Else
            tablemaxRow_hf.Value = existingChecks_dgv.Rows.Count
            Check_que_lbl.Text = tablemaxRow_hf.Value
            Next_btn.Enabled = False
            Previous_btn.Enabled = False
            Print_checks_btn.Enabled = True
            Delete_Current_btn.Enabled = False
            Label2.Text = "Number of Checks for Selected Operating Group: "
            error_lbl.Text = ""
            business_tb.Enabled = True
            checkAmount_tb.Enabled = True
            Memo_tb.Enabled = True
            save_check_btn.Enabled = True
            F1URL.Visible = True
            F2URL.Visible = True
        End If

        'Assign data to textboxes in check
        Dim row As GridViewRow = existingChecks_dgv.Rows(0)
        business_tb.Text = row.Cells(6).Text
        checkAmount_tb.Text = "$" & row.Cells(2).Text
        writtenAmount_tb.Text = row.Cells(3).Text
        Memo_tb.Text = row.Cells(4).Text

        'Updated check que with total number checks saved
        Check_que_lbl.Text = existingChecks_dgv.Rows.Count

        'If only 1 check is saved, disable next and previous buttons
        If tablemaxRow_hf.Value = 1 Then
            Next_btn.Enabled = False
            Previous_btn.Enabled = False
        End If

    End Sub

    Sub CheckGroups()
        Dim BusinessID As Integer = Request.QueryString("b")
        Dim OperGroup As String = operating_selector_ddl.SelectedValue.ToString
        Dim CheckIds As New List(Of String)
        Dim chunks As List(Of List(Of String))
        Dim valueString As String = Nothing
        Dim textString As String = Nothing
        Dim group As New ListItem

        'Clear check groups
        checkgroup_ddl.Items.Clear()

        'Assign check IDs to list
        Try
            Checks.GetCheckIDs(CheckIds, BusinessID, VisitID, OperGroup)
        Catch
            error_lbl.Text = "Error in CheckGroups(). Cannot get Check IDs."
            Exit Sub
        End Try

        'Assign list of checkIDs to another list
        chunks = SplitIntoChunks(CheckIds, 4)

        'Assign check IDs from list into the checkgroup DDL, used to put the check IDs into the URL for printing
        For n As Integer = 0 To chunks.Count - 1

            For Each ID As String In chunks(n)
                'Build value string
                valueString += ID & ","
            Next

            'Remove the comma
            valueString = valueString.TrimEnd(CChar(","))

            group.Text = "Checks 1 - " & tablemaxRow_hf.Value
            group.Value = valueString
            checkgroup_ddl.Items.Add(group)

        Next

    End Sub

    Sub LoadChecks(ByVal rowIndex As Integer)
        Try
            Dim row As GridViewRow = existingChecks_dgv.Rows(rowIndex)
            business_tb.Text = row.Cells(6).Text
            checkAmount_tb.Text = "$" & row.Cells(2).Text
            writtenAmount_tb.Text = row.Cells(3).Text
            Memo_tb.Text = row.Cells(4).Text

        Catch
        End Try
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

    Sub ReviewChecks()
        Dim checkIDS() As String = checkgroup_ddl.SelectedValue.ToString.Split(",")
        Dim URLEnd As String = Nothing

        'If button is labeled 'Review'
        If Print_checks_btn.Text = "Review" Then

            'Reload data
            LoadData()

            'Reassign check groups
            CheckGroups()

            'Update existing count of total checks saved
            Check_que_lbl.Text = existingChecks_dgv.Rows.Count

            'If total checks equals 4, its time to print
            If existingChecks_dgv.Rows.Count = 4 Then
                save_check_btn.Enabled = False
                error_lbl.Text = "You cannot save anymore checks to this operating group. Please click 'Print' before moving on to the next group."
                Delete_Current_btn.Enabled = True
                Next_btn.Enabled = True

                'If total checks is neither 0 or 4
            ElseIf existingChecks_dgv.Rows.Count < 4 And existingChecks_dgv.Rows.Count >= 1 Then
                save_check_btn.Enabled = True
                Delete_Current_btn.Enabled = True
                Next_btn.Enabled = True
                save_check_btn.Text = "Add Check"
                error_lbl.Text = ""

                If tablerowIndex_hf.Value = 0 Then
                    Previous_btn.Enabled = False
                    Next_btn.Enabled = True
                End If

                If tablemaxRow_hf.Value = 1 Then
                    Next_btn.Enabled = False
                    Previous_btn.Enabled = False
                End If
            End If

            'Change button text to Print
            Print_checks_btn.Text = "Print"

            'If button is labeled print
        ElseIf Print_checks_btn.Text = "Print" Then

            'Get the check ID for redirection to print page
            Select Case checkIDS.Length
                Case 1
                    URLEnd = "&c1=" & checkIDS(0).ToString
                Case 2
                    URLEnd = "&c1=" & checkIDS(0).ToString & "&C2=" & checkIDS(1).ToString
                Case 3
                    URLEnd = "&c1=" & checkIDS(0).ToString & "&C2=" & checkIDS(1).ToString & "&c3=" & checkIDS(2).ToString
                Case 4
                    URLEnd = "&c1=" & checkIDS(0).ToString & "&C2=" & checkIDS(1).ToString & "&c3=" & checkIDS(2).ToString & "&C4=" & checkIDS(3).ToString
            End Select

            'Change text to Review
            Print_checks_btn.Text = "Review"

            'Go to print page
            Response.Redirect("/pages/print/Print_Operating_Checks.aspx?b=" & BusinessID & URLEnd)

        End If

    End Sub

    Sub DeleteCheck()
        Dim row As GridViewRow = existingChecks_dgv.Rows(Val(tablerowIndex_hf.Value))
        Dim CheckID As Integer = row.Cells(0).Text

        'Check if the check has everything in it
        If business_tb.Text = Nothing Or checkAmount_tb.Text = Nothing Or writtenAmount_tb.Text = Nothing Or Memo_tb.Text = Nothing Then
            error_lbl.Text = "Cannot delete. Please click 'Review' to see your saved checks before deleting them."
            Exit Sub
        End If

        'Delete check
        Try
            Checks.DeleteCheck(CheckID)
        Catch ex As Exception
            error_lbl.Text = "Error in DeleteCheck(). Could not delete check."
            Exit Sub
        End Try

        'Load data
        LoadData()

        'Get check groups
        CheckGroups()

        'Update existing check count
        Check_que_lbl.Text = existingChecks_dgv.Rows.Count

        'Load existing checks into main check
        ReviewChecks()
    End Sub

    Sub SaveCheck()
        Dim timestamp As DateTime = DateTime.Now
        Dim timestampSTR As String = timestamp.ToString("yyyy-MM-dd HH:mm:ss")
        Dim writtenamount As String = writtenAmount_tb.Text
        Dim memo As String = Memo_tb.Text
        Dim numericCheck As Boolean
        Dim businessName As String = business_tb.Text
        Dim checkGroup As String = operating_selector_ddl.SelectedValue.ToString
        Dim checkamount As String = checkAmount_tb.Text
        BusinessID = Request.QueryString("b")

        'Clear out check if the button is labeled Add Check
        If save_check_btn.Text = "Add Check" Then
            business_tb.Text = ""
            checkAmount_tb.Text = ""
            writtenAmount_tb.Text = Nothing
            Memo_tb.Text = Nothing
            error_lbl.Text = ""
            Print_checks_btn.Text = "Review"
            Delete_Current_btn.Enabled = False
            Next_btn.Enabled = False

            'Rename button to Save Check
            save_check_btn.Text = "Save Check"

        ElseIf save_check_btn.Text = "Save Check" Then

            'Checking for blanks in the check
            If business_tb.Text = Nothing And checkAmount_tb.Text = Nothing And Memo_tb.Text = Nothing And writtenAmount_tb.Text = Nothing Then
                error_lbl.Text = "Operation failed. No business name, memo, written amount, or payment inputed."
                Exit Sub
            ElseIf business_tb.Text = Nothing And checkAmount_tb.Text = Nothing And Memo_tb.Text = Nothing And writtenAmount_tb.Text = Nothing Then
                error_lbl.Text = "Operation failed. No memo, written amount, or payment inputed."
                Exit Sub
            ElseIf business_tb.Text = Nothing And checkAmount_tb.Text = Nothing And Memo_tb.Text = Nothing And writtenAmount_tb.Text = Nothing Then
                error_lbl.Text = "Operation failed. No memo, or written amount inputed."
                Exit Sub
            ElseIf business_tb.Text = Nothing And checkAmount_tb.Text = Nothing And Memo_tb.Text = Nothing And writtenAmount_tb.Text = Nothing Then
                error_lbl.Text = "Operation failed. No written amount inputed."
                Exit Sub
            ElseIf business_tb.Text = Nothing And checkAmount_tb.Text = Nothing And Memo_tb.Text = Nothing Then
                error_lbl.Text = "Operation failed. No memo or payment inputed."
                Exit Sub
            ElseIf business_tb.Text = Nothing And checkAmount_tb.Text = Nothing And Memo_tb.Text = Nothing Then
                error_lbl.Text = "Operation failed. No memo inputed."
                Exit Sub
            ElseIf business_tb.Text = Nothing And checkAmount_tb.Text = Nothing And Memo_tb.Text = Nothing Then
                error_lbl.Text = "Operation failed. No business name or memo inputed."
                Exit Sub
            ElseIf business_tb.Text = Nothing And checkAmount_tb.Text = Nothing And Memo_tb.Text = Nothing Then
                error_lbl.Text = "Operation failed. No business memo or payment inputed."
                Exit Sub
            ElseIf business_tb.Text = Nothing And checkAmount_tb.Text = Nothing And Memo_tb.Text = Nothing Then
                error_lbl.Text = "Operation failed. No payment inputed."
                Exit Sub
            ElseIf business_tb.Text = Nothing And checkAmount_tb.Text = Nothing And Memo_tb.Text = Nothing Then
                error_lbl.Text = "Operation failed. No business name or payment inputed."
                Exit Sub
            ElseIf business_tb.Text = Nothing Or checkAmount_tb.Text = Nothing Or Memo_tb.Text = Nothing Or writtenAmount_tb.Text = Nothing Then
                error_lbl.Text = "Operation failed. Please fill out all the information in the check."
                Exit Sub
            End If

            'If the operating group selector is blank, show error
            If operating_selector_ddl.SelectedIndex = 0 Then
                error_lbl.Text = "Please select the correct Operating Group from the drop down menu in the 'Set Selector' area."
                Exit Sub
            End If

            'Checking if the check amount is a valid number
            numericCheck = IsNumeric(checkAmount_tb.Text)

            'If check amount is nto a number, show error
            If numericCheck = False Then
                error_lbl.Text = "Operation failed. Please enter a number in the check amount box."
                Exit Sub
            End If

            'If the check amount has a dollar sign, remove the dollar sign
            If checkAmount_tb.Text.Contains("$") Then
                checkamount = checkamount.Remove(0, 1)
            End If

            'Insert new check into database
            Try
                Checks.InsertNewOperatingCheck(BusinessID, checkamount, writtenamount, VisitID, timestampSTR, Memo, businessName, checkGroup)
            Catch ex As Exception
                error_lbl.Text = "Error in SaveCheck(). Could not insert new check into database."
                Exit Sub
            End Try

            'Load data
            LoadData()

            'Get check groups
            CheckGroups()

            'Update number of existing checks
            Check_que_lbl.Text = existingChecks_dgv.Rows.Count

            'Clear out the check after saving
            business_tb.Text = Nothing
            checkAmount_tb.Text = Nothing
            writtenAmount_tb.Text = Nothing
            Memo_tb.Text = Nothing
        End If
    End Sub

    Private Function SplitIntoChunks(keys As List(Of String), chunkSize As Integer) As List(Of List(Of String))
        Return keys.
        Select(Function(x, i) New With {Key .Index = i, Key .Value = x}).
        GroupBy(Function(x) (x.Index \ chunkSize)).
        Select(Function(x) x.Select(Function(v) v.Value).ToList()).
        ToList()
    End Function



    Protected Sub Next_btn_Click(sender As Object, e As EventArgs) Handles Next_btn.Click
        NextCheck()
    End Sub

    Protected Sub Previous_btn_Click(sender As Object, e As EventArgs) Handles Previous_btn.Click
        PreviousCheck()
    End Sub

    Protected Sub Delete_Current_btn_Click(sender As Object, e As EventArgs) Handles Delete_Current_btn.Click
        DeleteCheck()
    End Sub

    Private Sub Print_checks_btn_Click(sender As Object, e As EventArgs) Handles Print_checks_btn.Click
        ReviewChecks()
    End Sub

    Protected Sub save_check_btn_Click(sender As Object, e As EventArgs) Handles save_check_btn.Click
        SaveCheck()
    End Sub

    Protected Sub help_btn_Click(sender As Object, e As EventArgs) Handles help_btn.Click
        help_div.Visible = True
    End Sub

    Protected Sub close_btn_Click(sender As Object, e As EventArgs) Handles close_btn.Click
        help_div.Visible = False
    End Sub



    Protected Sub operating_selector_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles operating_selector_ddl.SelectedIndexChanged

        If operating_selector_ddl.SelectedIndex = 0 Then
            error_lbl.Text = "Please select an Operating Group from the drop down list below before continuing. Click on the white box on the left, above the green 'Print' button."
            business_tb.Enabled = False
            checkAmount_tb.Enabled = False
            save_check_btn.Enabled = False
            ' New_check_btn.Enabled = False
            Memo_tb.Enabled = False
            writtenAmount_tb.Enabled = False
            Print_checks_btn.Enabled = False
        Else
            business_tb.Enabled = True
            checkAmount_tb.Enabled = True
            save_check_btn.Enabled = True
            '  New_check_btn.Enabled = True
            Memo_tb.Enabled = True
            writtenAmount_tb.Enabled = True
            Print_checks_btn.Enabled = True

            LoadData()
            CheckGroups()
            tablemaxRow_hf.Value = existingChecks_dgv.Rows.Count
            Check_que_lbl.Text = tablemaxRow_hf.Value

            If existingChecks_dgv.Rows.Count = 4 Then
                ReviewChecks()
                Exit Sub
            Else
                save_check_btn.Enabled = True
                error_lbl.Text = ""
                business_tb.Text = ""
                checkAmount_tb.Text = ""
                writtenAmount_tb.Text = ""
                Memo_tb.Text = ""
                Previous_btn.Enabled = False
                Next_btn.Enabled = False
                Delete_Current_btn.Enabled = False
            End If
        End If
    End Sub



    'Protected Sub checkgroup_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles checkgroup_ddl.SelectedIndexChanged
    '    LoadChecks(tablerowIndex_hf.Value)
    'End Sub
End Class