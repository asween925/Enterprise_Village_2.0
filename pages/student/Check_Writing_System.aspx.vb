Imports System.Data.SqlClient
Imports System.Drawing

Public Class Check_Writing_System
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim DBConnection As New DatabaseConection
    Dim dr As SqlDataReader
    Dim dr2 As SqlDataReader
    Dim logoRoot As String = "~/media/Logos/"
    Public CheckStart As Integer = 1
    Public CheckEnd As Integer = 0
    Dim studentCount As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label_date.Text = DateTime.Now.ToString("MM/dd/yyyy")
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        ' checkgroup_ddl.Items.Clear()
        If Not (IsPostBack) Then
            Dim businessID1 As String = Request.QueryString("b")
            businessID_hf.Value = businessID1

            If businessID_hf.Value = 14 Then
                ditekdir.Visible = True
                ditekdir1.Visible = True
                ditekdir2.Visible = True
            End If

            If businessID_hf.Value = 11 Then
                ditekCheckLists_div.Visible = False
                step2header_h5.InnerText = "1"
            End If

            If businessID_hf.Value = 12 Or businessID_hf.Value = 13 Or businessID_hf.Value = 14 Then
                F2URL.Visible = False
            End If

            If businessID_hf.Value = 17 Then
                error_lbl.ForeColor = Color.White
            End If

            'Check if business is Ditek and if so, make Ditek Check button invisible
            If businessID_hf.Value = 11 Then
                    F3URL.Visible = False
                Else
                    F3URL.Visible = True
                End If

                Dim VisitID As New Class_VisitData
                Dim Visit As Integer = VisitID.GetVisitID
                If Visit <> 0 Then
                    visitdate_hf.Value = Visit
                Else
                    Label2.Text = "No visit date! Please go to 'Create a Visit' on the Home page to make a visit date."
                    Check_que_lbl.Text = ""
                    F3URL.Enabled = False
                    students_ddl.Enabled = False
                    Position_ddl.Enabled = False
                    memo_ddl.Enabled = False
                    'New_check_btn.Enabled = False
                    save_check_btn.Enabled = False
                    Check_selector_ddl.Enabled = False
                    'checkgroup_ddl.Enabled = False
                    Print_checks_btn.Enabled = False
                    Previous_btn.Enabled = False
                    Next_btn.Enabled = False
                    Delete_Current_btn.Enabled = False
                    F1URL.Enabled = False
                    F2URL.Enabled = False
                    Exit Sub
                End If

                Dim sql As String

                'Adding UPS, Dali, PCU (water) to city hall FO students
                If businessID_hf.Value = 14 Then
                    sql = "SELECT CONCAT(firstname,' ',lastname) as StudentName,employeeNumber FROM studentinfo WHERE business IN ('14', '15', '23', '20') AND visit='" & Visit & "' AND NOT firstName=' '"
                Else
                    sql = "SELECT CONCAT(firstname,' ',lastname) as StudentName,employeeNumber FROM studentinfo WHERE business='" & businessID1 & "' AND visit='" & Visit & "' AND NOT firstName=' '"
                End If

                Try
                    con.ConnectionString = connection_string
                    con.Open()
                    cmd.CommandText = sql
                    cmd.Connection = con
                    'dr = cmd.ExecuteReader

                    Dim ds As New DataSet
                    Dim da As New SqlDataAdapter
                    da.SelectCommand = cmd
                    da.Fill(ds)
                    students_ddl.DataSource = ds
                    students_ddl.DataTextField = "StudentName"
                    students_ddl.DataValueField = "employeeNumber"
                    students_ddl.DataBind()

                    'Not needed with above change
                    'While dr.Read()
                    '    students_ddl.Items.Add(dr(0).ToString)
                    'End While
                    students_ddl.Items.Insert(0, "")
                    studentCount = students_ddl.Items.Count
                    cmd.Dispose()
                    'dr.Close()

                    cmd = New SqlCommand
                    cmd.Connection = con
                    cmd.CommandText = "SELECT ID FROM visitInfo WHERE visitDate ='" & Label_date.Text & "'"
                    dr = cmd.ExecuteReader
                    While dr.Read()
                        visitID_hf.Value = dr("ID").ToString
                    End While
                    cmd.Dispose()

                    con.Close()
                Catch
                    'Update to error message to label
                Finally
                    cmd.Dispose()
                    con.Close()

                End Try

                If Check_selector_ddl.SelectedIndex = 0 Then
                    'May need to show message that there are no existing saved Checks.
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

                'If Check_selector_ddl.SelectedIndex = 0 Then
                '    error_lbl.Text = "Please select a payroll group from the drop down list below before continuing."
                '    students_ddl.Enabled = False
                '    Position_ddl.Enabled = False
                '    save_check_btn.Enabled = False
                '    New_check_btn.Enabled = False
                '    memo_ddl.Enabled = False
                '    Print_checks_btn.Enabled = False
                '    Next_btn.Enabled = False
                '    Previous_btn.Enabled = False
                '    Delete_Current_btn.Enabled = False
                'Else
                '    students_ddl.Enabled = True
                '    Position_ddl.Enabled = True
                '    save_check_btn.Enabled = True
                '    New_check_btn.Enabled = True
                '    memo_ddl.Enabled = True
                '    Print_checks_btn.Enabled = True
                '    Next_btn.Enabled = True
                '    Previous_btn.Enabled = True
                '    Delete_Current_btn.Enabled = True
                'End If

                Select Case businessID1
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
                    Case 13
                        check_system.Attributes("class") = "main_baycare"
                    Case 14
                        check_system.Attributes("class") = "main_city"
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

                LoadData()
                CheckGroups()
                tablemaxRow_hf.Value = existingChecks_dgv.Rows.Count
                Check_que_lbl.Text = tablemaxRow_hf.Value

                'Clear out checks
                students_ddl.SelectedIndex = 0
                Position_ddl.SelectedIndex = 0
                Written_amount_tb.Text = Nothing
                memo_ddl.SelectedIndex = 0

                cmd.Dispose()
                con.Close()

            End If

            Dim businessID As String = Request.QueryString("b")
        If businessID = Nothing Then
            businessID = 0
        End If

        F1URL.NavigateUrl = "Operating_Check_writing_system.aspx?B=" & businessID
        F2URL.NavigateUrl = "Online_Banking.aspx?B=" & businessID
        F3URL.NavigateUrl = "Ditek_Check.aspx?B=" & businessID

        Dim businessSQL As String = "SELECT logoPath, businessColor, businessName, address FROM businessinfo WHERE ID='" & businessID & "'"

        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd.CommandText = businessSQL
            cmd.Connection = con
            dr = cmd.ExecuteReader

            While dr.Read()
                business_name_lbl.Text = dr("businessName")
                address_lbl.Text = dr("address")
                Dim imagePath As String = logoRoot & dr(0).ToString
                Dim bColor As String = dr(1).ToString
                BusLogo_img.ImageUrl = imagePath

                'this code below has been turned into a comment to test functioning prior to utilizing
                'Dim htmlColor As Drawing.Color = Drawing.ColorTranslator.FromHtml(bColor)
                'Me.ev_lbl.ForeColor = htmlColor
                'end here

                Me.Title = dr(2).ToString & " Payroll Checks"
            End While

            cmd.Dispose()
            con.Close()

        Catch
            error_lbl.Text = "Error in PageLoad. Could not find image path and/or bColor."
            Exit Sub
        Finally
            cmd.Dispose()
            con.Close()

        End Try

    End Sub

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

    Private Sub Check_selector_rbl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Check_selector_ddl.SelectedIndexChanged

        If Check_selector_ddl.SelectedIndex <> 0 Then
            LoadData()
            CheckGroups()
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

        'Below is the code for the updated direct deposit feature for the school year of 23-24 / will be uncommented in August

        'If Check_selector_ddl.SelectedIndex = 1 Or Check_selector_ddl.SelectedIndex = 3 Then
        '    LoadData()
        '    CheckGroups()
        '    tablemaxRow_hf.Value = existingChecks_dgv.Rows.Count
        '    Check_que_lbl.Text = tablemaxRow_hf.Value
        '    studentCount = students_ddl.Items.Count - 1

        '    If existingChecks_dgv.Rows.Count = studentCount Then
        '        error_lbl.Text = "You have a check saved for each person in your business." & vbCrLf & "Please click 'Review' to see your saved checks and print them out."
        '        students_ddl.Enabled = False
        '        Position_ddl.Enabled = False
        '        save_check_btn.Enabled = False
        '        memo_ddl.Enabled = False
        '        Next_btn.Enabled = False
        '        Previous_btn.Enabled = False
        '        Delete_Current_btn.Enabled = False
        '        'checkgroup_ddl.Enabled = False
        '        memo_ddl.SelectedIndex = Check_selector_ddl.SelectedIndex
        '        Exit Sub
        '    Else
        '        students_ddl.SelectedIndex = 0
        '        Position_ddl.SelectedIndex = 0
        '        Written_amount_tb.Text = ""
        '        Previous_btn.Enabled = False
        '        Next_btn.Enabled = False
        '        Delete_Current_btn.Enabled = False
        '        students_ddl.Enabled = True
        '        Position_ddl.Enabled = True
        '        save_check_btn.Enabled = True
        '        'New_check_btn.Enabled = True
        '        error_lbl.Text = ""
        '        memo_ddl.SelectedIndex = Check_selector_ddl.SelectedIndex
        '        Print_checks_btn.Text = "Review"

        '        If existingChecks_dgv.Rows.Count <> 0 Then
        '            Print_checks_btn.Enabled = True
        '        Else
        '            Print_checks_btn.Enabled = False
        '        End If

        '    End If
        'ElseIf Check_selector_ddl.SelectedIndex = 2 Then
        '    error_lbl.Text = "Payroll 2 checks will be directly deposited into your accounts. Please select Payroll 1 or Payroll 3 instead."
        '    students_ddl.Enabled = False
        '    Position_ddl.Enabled = False
        '    save_check_btn.Enabled = False
        '    memo_ddl.Enabled = False
        '    Next_btn.Enabled = False
        '    Previous_btn.Enabled = False
        '    Delete_Current_btn.Enabled = False
        '    'checkgroup_ddl.Enabled = False
        '    memo_ddl.SelectedIndex = Check_selector_ddl.SelectedIndex
        '    Exit Sub
        'End If

    End Sub

    Protected Sub Next_btn_Click(sender As Object, e As EventArgs) Handles Next_btn.Click
        Dim maxRows As Integer = tablemaxRow_hf.Value
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

    Protected Sub Previous_btn_Click(sender As Object, e As EventArgs) Handles Previous_btn.Click
        Dim maxRows As Integer = tablemaxRow_hf.Value
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
        'If Val(tablerowIndex_hf.Value) - 1 < 0 Then
        '    Previous_btn.Enabled = False
        '    Next_btn.Enabled = True
        '    Exit Sub
        'Else
        '    Dim rowIndex As Integer = Val(tablerowIndex_hf.Value)
        '    tablerowIndex_hf.Value = rowIndex - 1
        '    Previous_btn.Enabled = True
        '    Next_btn.Enabled = True
        '    LoadChecks(rowIndex - 1)
        'End If

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

    Protected Sub Delete_Current_btn_Click(sender As Object, e As EventArgs) Handles Delete_Current_btn.Click
        Dim checkID As Integer
        Dim row As GridViewRow = existingChecks_dgv.Rows(Val(tablerowIndex_hf.Value))
        checkID = row.Cells(0).Text
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"

        If students_ddl.SelectedIndex = 0 Or Position_ddl.SelectedIndex = 0 Or memo_ddl.SelectedIndex = 0 Then
            error_lbl.Text = "Cannot delete. Please click 'Review' to see your saved checks before deleting them."
            Exit Sub
        End If

        Using con As New SqlConnection(connection_string)
            Using cmd As New SqlCommand("DELETE FROM checksinfo WHERE id='" & checkID & "'")

                cmd.Connection = con
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using

        LoadData()
        CheckGroups()
        tablemaxRow_hf.Value = existingChecks_dgv.Rows.Count
        Check_que_lbl.Text = tablemaxRow_hf.Value
        Print_checks_btn_Click(sender, e)

        If existingChecks_dgv.Rows.Count = 0 Then
            students_ddl.Enabled = True
            Position_ddl.Enabled = True
        End If

    End Sub

    'Protected Sub New_check_btn_Click(sender As Object, e As EventArgs) Handles New_check_btn.Click
    '    students_ddl.SelectedIndex = 0
    '    Position_ddl.SelectedIndex = 0
    '    Written_amount_tb.Text = Nothing
    '    memo_ddl.SelectedIndex = 0
    '    Check_selector_ddl.SelectedIndex = 0
    'End Sub

    Protected Sub save_check_btn_Click(sender As Object, e As EventArgs) Handles save_check_btn.Click

        studentCount = students_ddl.Items.Count - 1

        If save_check_btn.Text = "Add Check" Then
            students_ddl.SelectedIndex = 0
            Position_ddl.SelectedIndex = 0
            Written_amount_tb.Text = Nothing
            error_lbl.Text = ""
            Print_checks_btn.Text = "Review"
            Delete_Current_btn.Enabled = False
            Next_btn.Enabled = False
            Previous_btn.Enabled = False
            students_ddl.Enabled = True
            Position_ddl.Enabled = True

            save_check_btn.Text = "Save Check"

        ElseIf save_check_btn.Text = "Save Check" Then
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

            error_lbl.Text = ""

            If existingChecks_dgv.Rows.Count <> 0 Then
                Print_checks_btn.Enabled = True
            Else
                Print_checks_btn.Enabled = False
            End If

            Dim checkType As String = 0
            Dim studentID As String = students_ddl.SelectedValue.ToString
            Dim checkamount As String = Position_ddl.SelectedValue.ToString
            checkamount = checkamount.Remove(0, 1)
            Dim timestamp As DateTime = DateTime.Now
            Dim timestampSTR As String = timestamp.ToString("yyyy-MM-dd HH:mm:ss")
            Dim writtenamount As String = Written_amount_tb.Text
            Dim memo As String = memo_ddl.SelectedItem.ToString
            Dim visitID As String = visitID_hf.Value
            Dim cmd As New SqlCommand
            Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
            Dim con As New SqlConnection

            con.ConnectionString = connection_string

            'Check if selected has already been saved
            Try
                con.Open()
                cmd = New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "SELECT payee FROM checksInfo WHERE visit_ID ='" & visitID & "' AND business_ID='" & businessID_hf.Value & "' AND memo='" & memo & "' AND payee='" & studentID & "'"
                dr = cmd.ExecuteReader

                If dr.HasRows = True Then
                    error_lbl.Text = "A check with that name has already been saved."
                    Exit Sub
                End If

                cmd.Dispose()
                con.Close()
            Catch
                error_lbl.Text = "Error in save_check_btn_click. Name check has failed."
                Exit Sub
            End Try

            con.Open()
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "INSERT INTO checksinfo (business_ID, check_type, payee, check_amount, written_amount, memo, visit_ID, time_written ) VALUES ('" & businessID_hf.Value & "', '" & checkType & "', '" & studentID & "', '" & checkamount & "', '" & writtenamount & "', '" & memo & "', '" & visitID & "', '" & timestampSTR & "')"
            cmd.ExecuteNonQuery()
            dr.Close()
            cmd.Dispose()
            con.Close()

            Check_selector_ddl.SelectedIndex = memo_ddl.SelectedIndex
            LoadData()
            CheckGroups()
            tablemaxRow_hf.Value = existingChecks_dgv.Rows.Count
            Check_que_lbl.Text = tablemaxRow_hf.Value

            If existingChecks_dgv.Rows.Count = studentCount Then
                error_lbl.Text = "You have a check saved for each person in your business. Please click 'Review' to see your saved checks and print them out."
                Exit Sub
            End If

            students_ddl.SelectedIndex = 0
            Position_ddl.SelectedIndex = 0
            Written_amount_tb.Text = Nothing
        End If
    End Sub

    Sub LoadData()
        Dim payperiod As String = Nothing
        existingChecks_dgv.DataSource = Nothing
        existingChecks_dgv.DataBind()
        tablerowIndex_hf.Value = 0
        Print_checks_btn.Text = "Review"
        save_check_btn.Text = "Save Check"
        studentCount = students_ddl.Items.Count - 1

        'Disable arrow and delete buttons if no checks in the DB


        'May need to add code to reset the check values'

        Select Case Check_selector_ddl.SelectedIndex
            Case 0
                Exit Sub
            Case 1
                payperiod = "Payroll 1"
            Case 2
                payperiod = "Payroll 2"
            Case 3
                payperiod = "Payroll 3"
        End Select

        Dim sql As String = "SELECT c.id,c.payee,c.check_amount,c.written_amount,c.memo,c.time_written,b.businessName,b.address
            FROM checksinfo c
            FULL JOIN businessinfo b
            ON b.id = c.business_ID
            FULL JOIN studentInfo s
            ON s.employeeNumber = c.payee
            WHERE c.memo = @payperiod AND c.check_type ='0' AND c.business_ID = @businessID AND visit_ID=@visitID AND s.visit=@visitID
            ORDER BY ID"

        'Testing if the sql query is passing through the correct values (it is)
        'text_tb.Text = sql & " : PayPeriod :" & payperiod & "  : BID:" & businessID_hf.Value.ToString & "  : VID:" & visitID_hf.Value.ToString

        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand

        con.ConnectionString = connection_string
        con.Open()

        cmd.Connection = con
        cmd.CommandText = sql
        cmd.Parameters.AddWithValue("@payperiod", payperiod)
        cmd.Parameters.AddWithValue("@businessID", businessID_hf.Value.ToString)
        cmd.Parameters.AddWithValue("@visitID", visitID_hf.Value.ToString)

        Dim da As New SqlDataAdapter
        da.SelectCommand = cmd
        Dim dt As New DataTable
        da.Fill(dt)

        existingChecks_dgv.DataSource = dt
        existingChecks_dgv.DataBind()

        da.Dispose()
        cmd.Dispose()
        con.Close()

        If existingChecks_dgv.Rows.Count <> 0 Then
            Print_checks_btn.Enabled = True
        Else
            Print_checks_btn.Enabled = False
        End If

        If existingChecks_dgv.Rows.Count = 0 Or Check_selector_ddl.SelectedIndex = 0 Then
            'May need to show message that there are no existing saved Checks.
            Next_btn.Enabled = False
            Previous_btn.Enabled = False
            Delete_Current_btn.Enabled = False
            students_ddl.SelectedIndex = 0
            Position_ddl.SelectedIndex = 0
            Written_amount_tb.Text = Nothing
            error_lbl.Text = "No checks saved. Please fill out the check above and click 'Save Check' to continue."
            Exit Sub
            'ElseIf existingChecks_dgv.Rows.Count = 4 Then
            '    Label2.Text = "You have 4 checks saved! Please print them out before continuing."
            '    ditekButton1.Visible = False
            '    students_ddl.Enabled = False
            '    Position_ddl.Enabled = False
            '    memo_ddl.Enabled = False
            '    New_check_btn.Enabled = False
            '    save_check_btn.Enabled = False
            '    F1URL.Visible = False
            '    F2URL.Visible = False
            '    Next_btn.Enabled = True
            '    Previous_btn.Enabled = True
            '    Delete_Current_btn.Enabled = True
            'Else
            '    tablemaxRow_hf.Value = existingChecks_dgv.Rows.Count
            '    Check_que_lbl.Text = tablemaxRow_hf.Value
            '    Next_btn.Enabled = True
            '    Previous_btn.Enabled = True
            '    Delete_Current_btn.Enabled = True
            '    Label2.Text = "Number of Checks for Selected Pay Period: "
            '    ditekButton1.Visible = True
            '    students_ddl.Enabled = True
            '    Position_ddl.Enabled = True
            '    memo_ddl.Enabled = True
            '    New_check_btn.Enabled = True
            '    save_check_btn.Enabled = True
            '    F1URL.Visible = True
            '    F2URL.Visible = True
            '    Next_btn.Enabled = True
            '    Previous_btn.Enabled = True
            '    Delete_Current_btn.Enabled = True
        End If

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
            'checkgroup_ddl.Enabled = False
            memo_ddl.SelectedIndex = Check_selector_ddl.SelectedIndex
        End If

        Dim row As GridViewRow = existingChecks_dgv.Rows(0)
        Try
            students_ddl.SelectedValue = row.Cells(1).Text
        Catch
            error_lbl.Text = "Error in LoadData(). Check is saved with a student's name that is not assigned to business. Please contact tech support."
            Exit Sub
        End Try

        Position_ddl.SelectedValue = "$" & row.Cells(2).Text
        Written_amount_tb.Text = row.Cells(3).Text
        memo_ddl.SelectedValue = row.Cells(4).Text

        tablemaxRow_hf.Value = existingChecks_dgv.Rows.Count
        Check_que_lbl.Text = tablemaxRow_hf.Value

    End Sub

    'Checking the number of groups
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
                                        WHERE business_id ='" & Request.QueryString("b") & "' 
                                        AND visit_id='" & visitID_hf.Value & "' and memo='" & Check_selector_ddl.SelectedValue.ToString & "' and check_type='0'
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
                                          ON c.payee = s.employeeNumber
                                        WHERE c.business_id ='" & Request.QueryString("b") & "' 
                                        AND s.visit='" & visitID_hf.Value & "' and c.memo='" & Check_selector_ddl.SelectedValue.ToString & "' and c.check_type='0' AND c.visit_ID='" & visitID_hf.Value & "'
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

    Private Sub Print_checks_btn_Click(sender As Object, e As EventArgs) Handles Print_checks_btn.Click
        ' Dim checkIDS() As String = checkgroup_ddl.SelectedValue.ToString.Split(",")
        Dim URLEnd As String = Nothing
        Dim business As String = Request.QueryString("b")
        studentCount = students_ddl.Items.Count - 1

        If Print_checks_btn.Text = "Review" Then
            LoadData()
            CheckGroups()
            tablemaxRow_hf.Value = existingChecks_dgv.Rows.Count
            Check_que_lbl.Text = tablemaxRow_hf.Value

            'error2_lbl.Text = tablerowIndex_hf.Value

            If existingChecks_dgv.Rows.Count = 0 Then
                save_check_btn.Enabled = True
                Delete_Current_btn.Enabled = False
                Next_btn.Enabled = False
                Previous_btn.Enabled = False
                'checkgroup_ddl.Enabled = False
                save_check_btn.Text = "Save Check"
            ElseIf existingChecks_dgv.Rows.Count = studentCount Then
                error_lbl.Text = "You have a check saved for each person in your business. Please make sure your saved checks are correct and click 'Print' to print them out."
                students_ddl.Enabled = False
                Position_ddl.Enabled = False
                save_check_btn.Enabled = False
                memo_ddl.Enabled = False
                If studentCount = 1 Then
                    Next_btn.Enabled = False
                    Previous_btn.Enabled = False
                Else
                    Next_btn.Enabled = True
                    Previous_btn.Enabled = False
                End If

                Delete_Current_btn.Enabled = True
                'checkgroup_ddl.Enabled = True
                memo_ddl.SelectedIndex = Check_selector_ddl.SelectedIndex
            Else
                save_check_btn.Enabled = True
                Delete_Current_btn.Enabled = True
                Next_btn.Enabled = True
                'checkgroup_ddl.Enabled = True
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

            Print_checks_btn.Text = "Print"

        ElseIf Print_checks_btn.Text = "Print" Then

            'If checkgroup_ddl.SelectedIndex = 0 Then
            '    error_lbl.Text = "Please select a check group to print from the drop down menu above the 'Print' button."
            '    Exit Sub
            'End If

            Select Case Check_selector_ddl.SelectedIndex
                Case 1
                    URLEnd = "&c1=1"
                Case 2
                    URLEnd = "&c1=2"
                Case 3
                    URLEnd = "&c1=3"
            End Select

            'Select Case checkIDS.Length
            '    Case 1
            '        URLEnd = "&c1=" & checkIDS(0).ToString
            '    Case 2
            '        URLEnd = "&c1=" & checkIDS(0).ToString & "&C2=" & checkIDS(1).ToString
            '    Case 3
            '        URLEnd = "&c1=" & checkIDS(0).ToString & "&C2=" & checkIDS(1).ToString & "&c3=" & checkIDS(2).ToString
            '    Case 4
            '        URLEnd = "&c1=" & checkIDS(0).ToString & "&C2=" & checkIDS(1).ToString & "&c3=" & checkIDS(2).ToString & "&C4=" & checkIDS(3).ToString
            'End Select

            'checkgroup_ddl.Attributes.Add("select", "select option:checked")
            'checkgroup_ddl.Items.RemoveAt(checkgroup_ddl.SelectedIndex)

            Print_checks_btn.Text = "Review"
            '--------------------------------------------------------------------------------------------------
            'UNCOMMENT THE 3 LINES BELOW TO REDIRECT THE PAYROLL 2 GROUP TO DIRECT DEPOSIT SLIPS
            If Check_selector_ddl.SelectedIndex = 2 Then
                Response.Redirect("/pages/print/Print_Direct_Deposit.aspx?b=" & business & URLEnd)
            End If
            '--------------------------------------------------------------------------------------------------

            Response.Redirect("/pages/print/Print_Checks.aspx?b=" & business & URLEnd)

        End If

    End Sub

    Private Function SplitIntoChunks(keys As List(Of String), chunkSize As Integer) As List(Of List(Of String))
        Return keys.
        Select(Function(x, i) New With {Key .Index = i, Key .Value = x}).
        GroupBy(Function(x) (x.Index \ chunkSize)).
        Select(Function(x) x.Select(Function(v) v.Value).ToList()).
        ToList()
    End Function

    Protected Sub help_btn_Click(sender As Object, e As EventArgs) Handles help_btn.Click
        help_div.Visible = True
    End Sub

    Protected Sub close_btn_Click(sender As Object, e As EventArgs) Handles close_btn.Click
        help_div.Visible = False
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

End Class