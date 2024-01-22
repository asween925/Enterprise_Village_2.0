Imports System.Data.SqlClient
Public Class Operating_Check_Writing_System
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim DBConnection As New DatabaseConection
    Dim dr As SqlDataReader
    Dim logoRoot As String = "~/media/Logos/"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label_date.Text = DateTime.Now.ToString("MM/dd/yyyy")
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        If Not (IsPostBack) Then

            Dim businessID1 As String = Request.QueryString("b")
            businessID_hf.Value = businessID1
            Dim sql2 As String = "SELECT operating1, operating2, operating3, operating4, operating5, operating6, operating7, operating8, operating9, operating10, operating11, operating12, operating13 FROM businessinfo WHERE ID='" & businessID1 & "'"
            Dim sql As String = "SELECT Businessname FROM businessinfo WHERE NOT id='" & businessID1 & "' AND active='1' OR id='15' OR id='20' OR id='23' ORDER BY Businessname"

            If businessID_hf.Value = 12 Or businessID_hf.Value = 13 Or businessID_hf.Value = 14 Then
                F2URL.Visible = False
            End If

            Dim VisitID As New Class_VisitData
            Dim Visit As Integer = VisitID.GetVisitID
            If Visit <> 0 Then
                visitID_hf.Value = Visit
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

            'Try
            '    con.ConnectionString = connection_string
            '    con.Open()
            '    cmd.CommandText = sql
            '    cmd.Connection = con
            '    dr = cmd.ExecuteReader

            '    While dr.Read()
            '        business_tb.Items.Add(dr(0).ToString)
            '    End While

            '    business_tb.Items.Insert(0, "")
            '    cmd.Dispose()
            '    con.Close()

            '    'Check if the business is City Hall, so it can have the UPS business in the DDL
            '    If businessID1 = 14 Then
            '        business_tb.Items.Add("UPS")
            '        checkAmount_tb.Items.Add("$50.00")
            '    End If

            'Catch
            '    MsgBox("Select a valid business name")
            'Finally
            '    cmd.Dispose()
            '    con.Close()

            'End Try

        End If

        If Not (IsPostBack) Then
            Dim businessID1 As String = Request.QueryString("b")
            Dim sql2 As String = "SELECT businessName, address, operating1, operating2, operating3, operating4, operating5, operating6, operating7, operating8, operating9, operating10, operating11,
                                  operating12, operating13, printChecks FROM businessinfo WHERE ID='" & businessID1 & "'"

            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.CommandText = sql2
                cmd.Connection = con
                dr = cmd.ExecuteReader

                While dr.Read()
                    business_name_lbl.Text = dr("businessName")
                    address_lbl.Text = dr("address")
                    operating1_lbl.Text = dr("operating1")
                    operating2_lbl.Text = dr("operating2")
                    operating3_lbl.Text = dr("operating3")
                    operating4_lbl.Text = dr("operating4")
                    operating5_lbl.Text = dr("operating5")
                    operating6_lbl.Text = dr("operating6")
                    operating7_lbl.Text = dr("operating7")
                    operating8_lbl.Text = dr("operating8")

                    If dr("operating9").ToString = Nothing Then
                        row9.Visible = False
                        rowstop1.Visible = False
                    Else
                        row9.Visible = True
                        operating9_lbl.Text = dr("operating9").ToString
                    End If

                    If dr("operating10").ToString = Nothing Then
                        row10.Visible = False
                    Else
                        row10.Visible = True
                        operating10_lbl.Text = dr("operating10").ToString
                    End If

                    If dr("operating11").ToString = Nothing Then
                        row11.Visible = False
                    Else
                        row11.Visible = True
                        operating11_lbl.Text = dr("operating11").ToString
                    End If

                    If dr("operating12").ToString = Nothing Then
                        row12.Visible = False
                    Else
                        row12.Visible = True
                        operating12_lbl.Text = dr("operating12").ToString
                    End If

                    'printChecks_lbl.Text = dr("printChecks").ToString

                End While
                'business_tb.Items.Insert(0, "")
                cmd.Dispose()
                con.Close()

            Catch
                error_lbl.Text = "Error in page load"
                cmd.Dispose()
                con.Close()

            End Try

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

            cmd.Dispose()
            con.Close()

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

            'Clear out the check after saving
            business_tb.Text = Nothing
            checkAmount_tb.Text = Nothing
            writtenAmount_tb.Text = Nothing
            Memo_tb.Text = ""
        End If

        Dim businessID As String = Request.QueryString("b")
        If businessID = Nothing Then
            businessID = 0
        End If

        F1URL.NavigateUrl = "Check_writing_system.aspx?B=" & businessID
        F2URL.NavigateUrl = "Online_Banking.aspx?B=" & businessID

        Dim businessSQL As String = "SELECT logoPath, businessColor, businessName FROM businessinfo WHERE ID='" & businessID & "'"
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd.CommandText = businessSQL
            cmd.Connection = con
            dr = cmd.ExecuteReader

            While dr.Read()
                Dim imagePath As String = logoRoot & dr(0).ToString
                Dim bColor As String = dr(1).ToString
                BusLogo_img.ImageUrl = imagePath

                'this code below has been turned into a comment to test functioning prior to utilizing
                'Dim htmlColor As Drawing.Color = Drawing.ColorTranslator.FromHtml(bColor)
                'Me.ev_lbl.ForeColor = htmlColor
                'end here

                Me.Title = dr(2).ToString & " Operating Checks"

            End While

            cmd.Dispose()
            con.Close()

        Catch
            error_lbl.Text = "Error in Page_load(). Cannot get image path and bcolor"
            cmd.Dispose()
            con.Close()
            Exit Sub
        Finally
            cmd.Dispose()
            con.Close()
        End Try

        cmd.Dispose()
        con.Close()

    End Sub

    Sub LoadData()
        Dim operGroup As String = Nothing
        existingChecks_dgv.DataSource = Nothing
        existingChecks_dgv.DataBind()
        tablerowIndex_hf.Value = 0
        Print_checks_btn.Text = "Review"
        save_check_btn.Text = "Save Check"

        'May need to add code to reset the check values'

        Select Case operating_selector_ddl.SelectedIndex
            Case 0
                Exit Sub
            Case 1
                operGroup = "1"
            Case 2
                operGroup = "2"
            Case 3
                operGroup = "3"
        End Select

        Dim sql As String = "SELECT c.id, c.payee,c.check_amount,c.written_amount,c.memo,c.time_written,c.visit_ID,c.oper_bus_name,c.oper_group,b.businessName,b.address
            From checksinfo c
            FULL Join businessinfo b
            On b.id = c.business_ID      
            WHERE c.oper_group = @operGroup AND c.check_type ='0' AND c.business_ID = @businessID AND visit_ID=@visitID"

        'Testing if the sql query is passing through the correct values (it is)
        'text_tb.Text = sql & " : PayPeriod :" & payperiod & "  : BID:" & businessID_hf.Value.ToString & "  : VID:" & visitID_hf.Value.ToString


        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand

        con.ConnectionString = connection_string
        con.Open()

        cmd.Connection = con
        cmd.CommandText = sql
        cmd.Parameters.AddWithValue("@operGroup", operGroup)
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

        'Errors
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
        ElseIf existingChecks_dgv.Rows.Count = 4 Then
            save_check_btn.Enabled = False
            error_lbl.Text = "You cannot save anymore checks to this operating group. Please click 'Review' to see your saved checks and print them out."
            Next_btn.Enabled = False
            Previous_btn.Enabled = False
            Delete_Current_btn.Enabled = False
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
            'New_check_btn.Enabled = True
            save_check_btn.Enabled = True
            F1URL.Visible = True
            F2URL.Visible = True
        End If

        Dim row As GridViewRow = existingChecks_dgv.Rows(0)
        business_tb.Text = row.Cells(7).Text
        checkAmount_tb.Text = "$" & row.Cells(2).Text
        writtenAmount_tb.Text = row.Cells(3).Text
        Memo_tb.Text = row.Cells(4).Text

        tablemaxRow_hf.Value = existingChecks_dgv.Rows.Count
        Check_que_lbl.Text = tablemaxRow_hf.Value

        If tablemaxRow_hf.Value = 1 Then
            Next_btn.Enabled = False
            Previous_btn.Enabled = False
        End If

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

    End Sub
    Protected Sub Delete_Current_btn_Click(sender As Object, e As EventArgs) Handles Delete_Current_btn.Click
        Dim checkID As Integer
        Dim row As GridViewRow = existingChecks_dgv.Rows(Val(tablerowIndex_hf.Value))
        checkID = row.Cells(0).Text
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"

        If business_tb.Text = Nothing Or checkAmount_tb.Text = Nothing Or writtenAmount_tb.Text = Nothing Or Memo_tb.Text = Nothing Then
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

    End Sub
    Private Sub Print_checks_btn_Click(sender As Object, e As EventArgs) Handles Print_checks_btn.Click
        Dim checkIDS() As String = checkgroup_ddl.SelectedValue.ToString.Split(",")
        Dim URLEnd As String = Nothing
        Dim business As String = Request.QueryString("b")

        If Print_checks_btn.Text = "Review" Then
            LoadData()
            CheckGroups()
            tablemaxRow_hf.Value = existingChecks_dgv.Rows.Count
            Check_que_lbl.Text = tablemaxRow_hf.Value

            'error2_lbl.Text = tablerowIndex_hf.Value

            If existingChecks_dgv.Rows.Count = 4 Then
                save_check_btn.Enabled = False
                error_lbl.Text = "You cannot save anymore checks to this operating group. Please click 'Print' before moving on to the next group."
                Delete_Current_btn.Enabled = True
                Next_btn.Enabled = True
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

            Print_checks_btn.Text = "Print"

        ElseIf Print_checks_btn.Text = "Print" Then
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

            Print_checks_btn.Text = "Review"

            Response.Redirect("./Print_Operating_Checks.aspx?b=" & business & URLEnd)

        End If

        'If checkgroup_ddl.SelectedIndex = 0 Then
        '    error_lbl.Text = "Please select a group of checks before printing."
        '    Exit Sub
        'End If


        'Needs code to print, then reset the screen to checking_writing

    End Sub
    Sub LoadChecks(ByVal rowIndex As Integer)
        Try
            Dim row As GridViewRow = existingChecks_dgv.Rows(rowIndex)
            business_tb.Text = row.Cells(7).Text
            checkAmount_tb.Text = "$" & row.Cells(2).Text
            writtenAmount_tb.Text = row.Cells(3).Text
            Memo_tb.Text = row.Cells(4).Text

        Catch
        End Try
    End Sub
    Protected Sub save_check_btn_Click(sender As Object, e As EventArgs) Handles save_check_btn.Click

        If save_check_btn.Text = "Add Check" Then
            business_tb.Text = ""
            checkAmount_tb.Text = ""
            writtenAmount_tb.Text = Nothing
            Memo_tb.Text = Nothing
            error_lbl.Text = ""
            Print_checks_btn.Text = "Review"
            Delete_Current_btn.Enabled = False
            Next_btn.Enabled = False

            save_check_btn.Text = "Save Check"

        ElseIf save_check_btn.Text = "Save Check" Then
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

            Dim numericCheck As Boolean
            numericCheck = IsNumeric(checkAmount_tb.Text)

            If operating_selector_ddl.SelectedIndex = 0 Then
                error_lbl.Text = "Please select the correct Operating Group from the drop down menu in the 'Set Selector' area."
                Exit Sub
            End If

            If numericCheck = False Then
                error_lbl.Text = "Operation failed. Please enter a number in the check amount box."
                Exit Sub
            End If

            Dim checkType As String = 0
            Dim businessName As String = business_tb.Text
            Dim checkGroup As String = operating_selector_ddl.SelectedValue.ToString
            Dim checkamount As String = checkAmount_tb.Text

            If checkAmount_tb.Text.Contains("$") Then
                checkamount = checkamount.Remove(0, 1)
            End If

            'checkamount = checkamount.Remove(0, 1)
            Dim timestamp As DateTime = DateTime.Now
            Dim timestampSTR As String = timestamp.ToString("yyyy-MM-dd HH:mm:ss")
            Dim writtenamount As String = writtenAmount_tb.Text
            Dim memo As String = Memo_tb.Text
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
                cmd.CommandText = "SELECT oper_bus_name FROM checksInfo WHERE visit_ID ='" & visitID & "' AND business_ID='" & businessID_hf.Value & "' AND oper_bus_name='" & businessName & "'"
                dr = cmd.ExecuteReader

                If dr.HasRows = True Then
                    error_lbl.Text = "A check with that business name has already been saved."
                    Exit Sub
                End If

                cmd.Dispose()
                con.Close()
            Catch
                error_lbl.Text = "Error in save_check_btn_click. Business name check has failed."
                Exit Sub
            End Try

            con.Open()
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "INSERT INTO checksinfo (business_ID, check_type, check_amount, written_amount, memo, visit_ID, time_written, oper_bus_name, oper_group ) VALUES ('" & businessID_hf.Value & "', '" & checkType & "', '" & checkamount & "', '" & writtenamount & "', '" & memo & "', '" & visitID & "', '" & timestampSTR & "', '" & businessName & "', '" & checkGroup & "')"
            cmd.ExecuteNonQuery()
            dr.Close()
            cmd.Dispose()
            con.Close()

            LoadData()
            CheckGroups()
            tablemaxRow_hf.Value = existingChecks_dgv.Rows.Count
            Check_que_lbl.Text = tablemaxRow_hf.Value



            'Clear out the check after saving
            business_tb.Text = Nothing
            checkAmount_tb.Text = Nothing
            writtenAmount_tb.Text = Nothing
            Memo_tb.Text = Nothing
        End If

    End Sub

    Sub CheckGroups()
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim CheckIds As New List(Of String)
        checkgroup_ddl.Items.Clear()
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd.CommandText = "SELECT ID FROM checksInfo
                    WHERE business_id ='" & Request.QueryString("b") & "' AND visit_id='" & visitID_hf.Value & "' and oper_group='" & operating_selector_ddl.SelectedValue.ToString & "' and check_type='0'"
            cmd.Connection = con
            dr = cmd.ExecuteReader

            While dr.Read()
                CheckIds.Add(dr("ID"))
            End While

            cmd.Dispose()
            con.Close()

        Catch
            cmd.Dispose()
            con.Close()
        Finally
            cmd.Dispose()
            con.Close()
        End Try

        Dim chunks As List(Of List(Of String)) = SplitIntoChunks(CheckIds, 4)
        Dim valueString As String = Nothing
        Dim textString As String = Nothing

        For n As Integer = 0 To chunks.Count - 1
            valueString = Nothing
            textString = Nothing

            For Each ID As String In chunks(n)
                'Build value string
                valueString += ID & ","
            Next
            valueString = valueString.TrimEnd(CChar(","))

            Dim group As New ListItem
            'error2_lbl.Text = "Checks 1 - " & CType(existingChecks_dgv.DataSource, DataTable).Rows.Count
            'group.Text = "Checks " & chunks(n).Min & " - " & chunks(n).Max
            group.Text = "Checks 1 - " & tablemaxRow_hf.Value
            group.Value = valueString
            checkgroup_ddl.Items.Add(group)

        Next
        'Dim blankGroup As New ListItem
        'blankGroup.Text = ""
        'blankGroup.Value = ""
        'checkgroup_ddl.Items.Insert(0, blankGroup)

    End Sub
    Private Function SplitIntoChunks(keys As List(Of String), chunkSize As Integer) As List(Of List(Of String))
        Return keys.
        Select(Function(x, i) New With {Key .Index = i, Key .Value = x}).
        GroupBy(Function(x) (x.Index \ chunkSize)).
        Select(Function(x) x.Select(Function(v) v.Value).ToList()).
        ToList()
    End Function

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
                Print_checks_btn_Click(sender, e)
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

                'If tablerowIndex_hf.Value = 0 Then
                '    Previous_btn.Enabled = False
                'End If

                'If tablemaxRow_hf.Value = 1 Then
                '    Next_btn.Enabled = False
                '    Previous_btn.Enabled = False
                'End If
            End If
        End If
    End Sub

    Protected Sub help_btn_Click(sender As Object, e As EventArgs) Handles help_btn.Click
        help_div.Visible = True
    End Sub

    Protected Sub close_btn_Click(sender As Object, e As EventArgs) Handles close_btn.Click
        help_div.Visible = False
    End Sub

    'Protected Sub checkgroup_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles checkgroup_ddl.SelectedIndexChanged
    '    LoadChecks(tablerowIndex_hf.Value)
    'End Sub
End Class