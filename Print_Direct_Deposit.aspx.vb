Imports System.Data.SqlClient
Imports System.Collections

Public Class Print_Direct_Deposit
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim DBConnection As New DatabaseConection
    Dim dr As SqlDataReader
    Dim logoRoot As String = "~/media/Logos/"
    Dim strProfit As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim businessID As String = Request.QueryString("b")
        Dim rowCount As Integer
        Dim VisitID As New Class_VisitData
        Dim Visit As Integer = VisitID.GetVisitID
        Dim businessSQL As String = "SELECT businessName, address, logoPath, businessColor, businessName FROM businessinfo WHERE ID='" & businessID & "'"
        Dim payroll As String = Request.QueryString("c1")
        Dim check1, check2, check3, check4, check5, check6, check7, check8, check9, check10, check11, check12, check13, check14, check15, check16 As Integer

        'Check for business ID
        If businessID = Nothing Then
            businessID = 0
        End If

        'Get visit ID
        If Not (IsPostBack) Then
            If Visit <> 0 Then
                visitdate_hf.Value = Visit
            End If
        End If

        cmd.Dispose()
        con.Close()

        'Get Payroll Group Name
        If payroll = "1" Then
            payrollGroup_lbl.Text = "Payroll 1"
        ElseIf payroll = "2" Then
            payrollGroup_lbl.Text = "Payroll 2"
        ElseIf payroll = "3" Then
            payrollGroup_lbl.Text = "Payroll 3"
        End If

        'Get total amount of saved checks and make divs visible
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd.CommandText = "SELECT COUNT(*) as count
                               FROM checksInfo c
                               RIGHT JOIN studentInfo s ON s.employeenumber = c.payee
                               WHERE c.memo='" & payrollGroup_lbl.Text & "' AND c.check_type = '0' AND 
                               (c.visit_id='" & visitdate_hf.Value & "' AND s.visit='" & visitdate_hf.Value & "' AND c.business_ID='" & businessID & "')"
            cmd.Connection = con
            dr = cmd.ExecuteReader()
            'error_lbl.Text = payroll & " " & rowCount & " " & visitdate_hf.Value

            While dr.Read()
                rowCount = dr("count").ToString

                If rowCount = 5 Then
                    check4_div.Attributes.Add("style", "margin-bottom: 30px;")
                End If
            End While

            Select Case rowCount
                Case 1
                    check1_div.Visible = True
                Case 2
                    check1_div.Visible = True
                    check2_div.Visible = True
                Case 3
                    check1_div.Visible = True
                    check2_div.Visible = True
                    check3_div.Visible = True
                Case 4
                    check1_div.Visible = True
                    check2_div.Visible = True
                    check3_div.Visible = True
                    check4_div.Visible = True
                Case 5
                    check1_div.Visible = True
                    check2_div.Visible = True
                    check3_div.Visible = True
                    check4_div.Visible = True
                    check5_div.Visible = True
                Case 6
                    check1_div.Visible = True
                    check2_div.Visible = True
                    check3_div.Visible = True
                    check4_div.Visible = True
                    check5_div.Visible = True
                    check6_div.Visible = True
                Case 7
                    check1_div.Visible = True
                    check2_div.Visible = True
                    check3_div.Visible = True
                    check4_div.Visible = True
                    check5_div.Visible = True
                    check6_div.Visible = True
                    check7_div.Visible = True
                Case 8
                    check1_div.Visible = True
                    check2_div.Visible = True
                    check3_div.Visible = True
                    check4_div.Visible = True
                    check5_div.Visible = True
                    check6_div.Visible = True
                    check7_div.Visible = True
                    check8_div.Visible = True
                Case 9
                    check1_div.Visible = True
                    check2_div.Visible = True
                    check3_div.Visible = True
                    check4_div.Visible = True
                    check5_div.Visible = True
                    check6_div.Visible = True
                    check7_div.Visible = True
                    check8_div.Visible = True
                    check9_div.Visible = True
                Case 10
                    check1_div.Visible = True
                    check2_div.Visible = True
                    check3_div.Visible = True
                    check4_div.Visible = True
                    check5_div.Visible = True
                    check6_div.Visible = True
                    check7_div.Visible = True
                    check8_div.Visible = True
                    check9_div.Visible = True
                    check10_div.Visible = True
                Case 11
                    check1_div.Visible = True
                    check2_div.Visible = True
                    check3_div.Visible = True
                    check4_div.Visible = True
                    check5_div.Visible = True
                    check6_div.Visible = True
                    check7_div.Visible = True
                    check8_div.Visible = True
                    check9_div.Visible = True
                    check10_div.Visible = True
                    check11_div.Visible = True
                Case 12
                    check1_div.Visible = True
                    check2_div.Visible = True
                    check3_div.Visible = True
                    check4_div.Visible = True
                    check5_div.Visible = True
                    check6_div.Visible = True
                    check7_div.Visible = True
                    check8_div.Visible = True
                    check9_div.Visible = True
                    check10_div.Visible = True
                    check11_div.Visible = True
                    check12_div.Visible = True
                Case 13
                    check1_div.Visible = True
                    check2_div.Visible = True
                    check3_div.Visible = True
                    check4_div.Visible = True
                    check5_div.Visible = True
                    check6_div.Visible = True
                    check7_div.Visible = True
                    check8_div.Visible = True
                    check9_div.Visible = True
                    check10_div.Visible = True
                    check11_div.Visible = True
                    check12_div.Visible = True
                    check13_div.Visible = True
                Case 14
                    check1_div.Visible = True
                    check2_div.Visible = True
                    check3_div.Visible = True
                    check4_div.Visible = True
                    check5_div.Visible = True
                    check6_div.Visible = True
                    check7_div.Visible = True
                    check8_div.Visible = True
                    check9_div.Visible = True
                    check10_div.Visible = True
                    check11_div.Visible = True
                    check12_div.Visible = True
                    check13_div.Visible = True
                    check14_div.Visible = True
                Case 15
                    check1_div.Visible = True
                    check2_div.Visible = True
                    check3_div.Visible = True
                    check4_div.Visible = True
                    check5_div.Visible = True
                    check6_div.Visible = True
                    check7_div.Visible = True
                    check8_div.Visible = True
                    check9_div.Visible = True
                    check10_div.Visible = True
                    check11_div.Visible = True
                    check12_div.Visible = True
                    check13_div.Visible = True
                    check14_div.Visible = True
                    check15_div.Visible = True
                Case 16
                    check1_div.Visible = True
                    check2_div.Visible = True
                    check3_div.Visible = True
                    check4_div.Visible = True
                    check5_div.Visible = True
                    check6_div.Visible = True
                    check7_div.Visible = True
                    check8_div.Visible = True
                    check9_div.Visible = True
                    check10_div.Visible = True
                    check11_div.Visible = True
                    check12_div.Visible = True
                    check13_div.Visible = True
                    check14_div.Visible = True
                    check15_div.Visible = True
                    check16_div.Visible = True
            End Select

            cmd.Dispose()
            con.Close()

        Catch
            cmd.Dispose()
            con.Close()

            Exit Sub
        End Try

        'Get current date and assign to label
        Try
            Label_date1_lbl.Text = DateTime.Now.ToString("MM/dd/yyyy")
            Label_date2_lbl.Text = DateTime.Now.ToString("MM/dd/yyyy")
            Label_date3_lbl.Text = DateTime.Now.ToString("MM/dd/yyyy")
            Label_date4_lbl.Text = DateTime.Now.ToString("MM/dd/yyyy")
            label_date5_lbl.Text = DateTime.Now.ToString("MM/dd/yyyy")
            label_date6_lbl.Text = DateTime.Now.ToString("MM/dd/yyyy")
            label_date7_lbl.Text = DateTime.Now.ToString("MM/dd/yyyy")
            label_date8_lbl.Text = DateTime.Now.ToString("MM/dd/yyyy")
            label_date9_lbl.Text = DateTime.Now.ToString("MM/dd/yyyy")
            label_date10_lbl.Text = DateTime.Now.ToString("MM/dd/yyyy")
            label_date11_lbl.Text = DateTime.Now.ToString("MM/dd/yyyy")
            label_date12_lbl.Text = DateTime.Now.ToString("MM/dd/yyyy")
            label_date13_lbl.Text = DateTime.Now.ToString("MM/dd/yyyy")
            label_date14_lbl.Text = DateTime.Now.ToString("MM/dd/yyyy")
            label_date15_lbl.Text = DateTime.Now.ToString("MM/dd/yyyy")
            label_date16_lbl.Text = DateTime.Now.ToString("MM/dd/yyyy")
        Catch

        End Try

        'get business name and address
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd.CommandText = businessSQL
            cmd.Connection = con
            dr = cmd.ExecuteReader

            While dr.Read()
                business_name1_lbl.Text = dr("businessName").ToString
                business_name2_lbl.Text = dr("businessName")
                business_name3_lbl.Text = dr("businessName")
                business_name4_lbl.Text = dr("businessName")
                business_name5_lbl.Text = dr("businessName")
                business_name6_lbl.Text = dr("businessName")
                business_name7_lbl.Text = dr("businessName")
                business_name8_lbl.Text = dr("businessName")
                business_name9_lbl.Text = dr("businessName")
                business_name10_lbl.Text = dr("businessName")
                business_name11_lbl.Text = dr("businessName")
                business_name12_lbl.Text = dr("businessName")
                business_name13_lbl.Text = dr("businessName")
                business_name14_lbl.Text = dr("businessName")
                business_name15_lbl.Text = dr("businessName")
                business_name16_lbl.Text = dr("businessName")
                address1_lbl.Text = dr("address")
                address2_lbl.Text = dr("address")
                address3_lbl.Text = dr("address")
                address4_lbl.Text = dr("address")
                address5_lbl.Text = dr("address")
                address6_lbl.Text = dr("address")
                address7_lbl.Text = dr("address")
                address8_lbl.Text = dr("address")
                address9_lbl.Text = dr("address")
                address10_lbl.Text = dr("address")
                address11_lbl.Text = dr("address")
                address12_lbl.Text = dr("address")
                address13_lbl.Text = dr("address")
                address14_lbl.Text = dr("address")
                address15_lbl.Text = dr("address")
                address16_lbl.Text = dr("address")

                Dim imagePath As String = logoRoot & dr(0).ToString
                Dim bColor As String = dr(1).ToString
                BusLogo_img.ImageUrl = imagePath

                Me.Title = dr(2).ToString

            End While

            cmd.Dispose()
            con.Close()

        Catch
            error_lbl.Text = "Error"
            cmd.Dispose()
            con.Close()
            Exit Sub
        Finally
            cmd.Dispose()
            con.Close()
        End Try

        'get check IDs and store them into an array
        Try

            con.ConnectionString = connection_string
            con.Open()
            cmd.CommandText = "SELECT c.id, c.business_ID, c.check_type, CONCAT(s.Firstname,' ',s.lastname) as payee2, c.check_amount, c.written_amount, c.memo
                                            FROM checksInfo c
                                            RIGHT JOIN studentInfo s ON s.employeenumber = c.payee
                                            WHERE c.memo='" & payrollGroup_lbl.Text & "' AND c.check_type = '0' AND (c.visit_id='" & visitdate_hf.Value & "' AND s.visit='" & visitdate_hf.Value & "' AND c.business_ID=" & businessID & ")
                                            ORDER BY id ASC"
            cmd.Connection = con
            dr = cmd.ExecuteReader

            Dim checks As ArrayList = New ArrayList()

            While dr.Read()
                checks.Add(dr("id"))
            End While

            check1 = checks(0)
            check2 = checks(1)
            check3 = checks(2)
            check4 = checks(3)
            check5 = checks(4)
            check6 = checks(5)
            check7 = checks(6)
            check8 = checks(7)
            check9 = checks(8)
            check10 = checks(9)
            check11 = checks(10)
            check12 = checks(11)
            check13 = checks(12)
            check14 = checks(13)
            check15 = checks(14)
            check16 = checks(15)

            If checks(0) = Nothing Then
                error_lbl.Text = "Nothing in here but us chickens"
            Else
                error_lbl.Text = "Wtf"
            End If


            cmd.Dispose()
            con.Close()
        Catch
            'error_lbl.Text = "Error in checks array"
            cmd.Dispose()
            con.Close()
            'Exit Sub
        End Try

        cmd.Dispose()
        con.Close()

        'Check 1
        If check1 <> 0 And check1 <> Nothing Then
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.CommandText = "SELECT c.id, c.business_ID, c.check_type, CONCAT(s.Firstname,' ',s.lastname) as payee2, c.check_amount, c.written_amount, c.memo
                                            FROM checksInfo c
                                            RIGHT JOIN studentInfo s ON s.employeenumber = c.payee
                                            WHERE c.id = '" & check1 & "' AND c.check_type = '0' AND (c.visit_id='" & visitdate_hf.Value & "' AND s.visit='" & visitdate_hf.Value & "' AND c.business_ID=" & businessID & ")"
                cmd.Connection = con
                dr = cmd.ExecuteReader

                While dr.Read()
                    checkName1_tb.Text = dr("payee2")
                    'checkAmount1_lbl.Text = dr("check_amount")
                    writtenAmount1_tb.Text = dr("written_amount")
                    Memo1_tb.Text = dr("Memo")
                End While

                cmd.Dispose()
                con.Close()
            Catch
                error_lbl.Text = "error"
                Exit Sub
            Finally
                cmd.Dispose()
                con.Close()
            End Try

        End If

        'Check 2
        If check2 <> 0 And check2 <> Nothing Then
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.CommandText = "SELECT c.id, c.business_ID, c.check_type, CONCAT(s.Firstname,' ',s.lastname) as payee, c.check_amount, c.written_amount, c.memo
                                            FROM checksInfo c
                                            RIGHT JOIN studentInfo s ON s.employeenumber = c.payee
                                            WHERE c.id = '" & check2 & "' AND c.check_type = '0' AND (c.visit_id='" & visitdate_hf.Value & "' AND s.visit='" & visitdate_hf.Value & "' AND c.business_ID=" & businessID & ")"
                cmd.Connection = con
                dr = cmd.ExecuteReader

                While dr.Read()
                    checkName2_tb.Text = dr("payee")
                    'checkAmount2_lbl.Text = dr("check_amount")
                    writtenAmount2_tb.Text = dr("written_amount")
                    Memo2_tb.Text = dr("Memo")
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

        End If

        'Check 3
        If check3 <> 0 And check3 <> Nothing Then
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.CommandText = "SELECT c.id, c.business_ID, c.check_type, CONCAT(s.Firstname,' ',s.lastname) as payee, c.check_amount, c.written_amount, c.memo
                                            FROM checksInfo c
                                            RIGHT JOIN studentInfo s ON s.employeenumber = c.payee
                                            WHERE c.id = '" & check3 & "' AND c.check_type = '0' AND (c.visit_id='" & visitdate_hf.Value & "' AND s.visit='" & visitdate_hf.Value & "' AND c.business_ID=" & businessID & ")"
                cmd.Connection = con
                dr = cmd.ExecuteReader

                While dr.Read()
                    checkName3_tb.Text = dr("payee")
                    'checkAmount3_lbl.Text = dr("check_amount")
                    writtenAmount3_tb.Text = dr("written_amount")
                    Memo3_tb.Text = dr("Memo")
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

        End If

        'Check 4
        If check4 <> 0 And check4 <> Nothing Then
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.CommandText = "SELECT c.id, c.business_ID, c.check_type, CONCAT(s.Firstname,' ',s.lastname) as payee, c.check_amount, c.written_amount, c.memo
                                            FROM checksInfo c
                                            RIGHT JOIN studentInfo s ON s.employeenumber = c.payee
                                            WHERE c.id = '" & check4 & "' AND c.check_type = '0' AND (c.visit_id='" & visitdate_hf.Value & "' AND s.visit='" & visitdate_hf.Value & "' AND c.business_ID=" & businessID & ")"
                cmd.Connection = con
                dr = cmd.ExecuteReader

                While dr.Read()
                    checkName4_tb.Text = dr("payee")
                    'checkAmount4_lbl.Text = dr("check_amount")
                    writtenAmount4_tb.Text = dr("written_amount")
                    Memo4_tb.Text = dr("Memo")
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

        End If

        'check 5
        If check5 <> 0 And check5 <> Nothing Then
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.CommandText = "SELECT c.business_ID, c.check_type, CONCAT(s.Firstname,' ',s.lastname) as payee, c.check_amount, c.written_amount, c.memo 
        FROM checksinfo c 
        Inner join studentinfo s
        ON c.payee = s.employeenumber
        WHERE c.ID='" & check5 & "' AND c.check_type ='0' AND (c.visit_id='" & visitdate_hf.Value & "' AND s.visit='" & visitdate_hf.Value & "' AND c.business_ID=" & businessID & ")"
                cmd.Connection = con
                dr = cmd.ExecuteReader

                While dr.Read()
                    checkName5_tb.Text = dr("payee")
                    'checkAmount5_lbl.Text = dr("check_amount")
                    writtenAmount5_tb.Text = dr("written_amount")
                    Memo5_tb.Text = dr("Memo")
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

        End If

        'Check 6
        If check6 <> 0 And check6 <> Nothing Then
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.CommandText = "SELECT c.business_ID, c.check_type, CONCAT(s.Firstname,' ',s.lastname) as payee, c.check_amount, c.written_amount, c.memo 
        FROM checksinfo c 
        Inner join studentinfo s
        ON c.payee = s.employeenumber
        WHERE c.ID='" & check6 & "' AND c.check_type ='0' AND (c.visit_id='" & visitdate_hf.Value & "' AND s.visit='" & visitdate_hf.Value & "' AND c.business_ID=" & businessID & ")"
                cmd.Connection = con
                dr = cmd.ExecuteReader

                While dr.Read()
                    checkName6_tb.Text = dr("payee")
                    'checkAmount6_lbl.Text = dr("check_amount")
                    writtenAmount6_tb.Text = dr("written_amount")
                    Memo6_tb.Text = dr("Memo")
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

        End If

        'Check 7
        If check7 <> 0 And check7 <> Nothing Then
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.CommandText = "SELECT c.business_ID, c.check_type, CONCAT(s.Firstname,' ',s.lastname) as payee, c.check_amount, c.written_amount, c.memo 
        FROM checksinfo c 
        Inner join studentinfo s
        ON c.payee = s.employeenumber
        WHERE c.ID='" & check7 & "' AND c.check_type ='0' AND (c.visit_id='" & visitdate_hf.Value & "' AND s.visit='" & visitdate_hf.Value & "' AND c.business_ID=" & businessID & ")"
                cmd.Connection = con
                dr = cmd.ExecuteReader

                While dr.Read()
                    checkName7_tb.Text = dr("payee")
                    'checkAmount7_lbl.Text = dr("check_amount")
                    writtenAmount7_tb.Text = dr("written_amount")
                    Memo7_tb.Text = dr("Memo")
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

        End If

        'Check 8
        If check8 <> 0 And check8 <> Nothing Then
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.CommandText = "SELECT c.business_ID, c.check_type, CONCAT(s.Firstname,' ',s.lastname) as payee, c.check_amount, c.written_amount, c.memo 
        FROM checksinfo c 
        Inner join studentinfo s
        ON c.payee = s.employeenumber
        WHERE c.ID='" & check8 & "' AND c.check_type ='0' AND (c.visit_id='" & visitdate_hf.Value & "' AND s.visit='" & visitdate_hf.Value & "' AND c.business_ID=" & businessID & ")"
                cmd.Connection = con
                dr = cmd.ExecuteReader

                While dr.Read()
                    checkName8_tb.Text = dr("payee")
                    'checkAmount8_lbl.Text = dr("check_amount")
                    writtenAmount8_tb.Text = dr("written_amount")
                    Memo8_tb.Text = dr("Memo")
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

        End If

        'Check 9
        If check9 <> 0 And check9 <> Nothing Then
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.CommandText = "SELECT c.business_ID, c.check_type, CONCAT(s.Firstname,' ',s.lastname) as payee, c.check_amount, c.written_amount, c.memo 
        FROM checksinfo c 
        Inner join studentinfo s
        ON c.payee = s.employeenumber
        WHERE c.ID='" & check9 & "' AND c.check_type ='0' AND (c.visit_id='" & visitdate_hf.Value & "' AND s.visit='" & visitdate_hf.Value & "' AND c.business_ID=" & businessID & ")"
                cmd.Connection = con
                dr = cmd.ExecuteReader

                While dr.Read()
                    checkName9_tb.Text = dr("payee")
                    'checkAmount9_lbl.Text = dr("check_amount")
                    writtenAmount9_tb.Text = dr("written_amount")
                    Memo9_tb.Text = dr("Memo")
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

        End If

        'Check 10
        If check10 <> 0 And check10 <> Nothing Then
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.CommandText = "SELECT c.business_ID, c.check_type, CONCAT(s.Firstname,' ',s.lastname) as payee, c.check_amount, c.written_amount, c.memo 
        FROM checksinfo c 
        Inner join studentinfo s
        ON c.payee = s.employeenumber
        WHERE c.ID='" & check10 & "' AND c.check_type ='0' AND (c.visit_id='" & visitdate_hf.Value & "' AND s.visit='" & visitdate_hf.Value & "' AND c.business_ID=" & businessID & ")"
                cmd.Connection = con
                dr = cmd.ExecuteReader

                While dr.Read()
                    checkName10_tb.Text = dr("payee")
                    'checkAmount10_lbl.Text = dr("check_amount")
                    writtenAmount10_tb.Text = dr("written_amount")
                    Memo10_tb.Text = dr("Memo")
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

        End If

        'Check 11
        If check11 <> 0 And check11 <> Nothing Then
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.CommandText = "SELECT c.business_ID, c.check_type, CONCAT(s.Firstname,' ',s.lastname) as payee, c.check_amount, c.written_amount, c.memo 
        FROM checksinfo c 
        Inner join studentinfo s
        ON c.payee = s.employeenumber
        WHERE c.ID='" & check11 & "' AND c.check_type ='0' AND (c.visit_id='" & visitdate_hf.Value & "' AND s.visit='" & visitdate_hf.Value & "' AND c.business_ID=" & businessID & ")"
                cmd.Connection = con
                dr = cmd.ExecuteReader

                While dr.Read()
                    checkName11_tb.Text = dr("payee")
                    'checkAmount11_lbl.Text = dr("check_amount")
                    writtenAmount11_tb.Text = dr("written_amount")
                    Memo11_tb.Text = dr("Memo")
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

        End If

        'Check 12
        If check12 <> 0 And check12 <> Nothing Then
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.CommandText = "SELECT c.business_ID, c.check_type, CONCAT(s.Firstname,' ',s.lastname) as payee, c.check_amount, c.written_amount, c.memo 
        FROM checksinfo c 
        Inner join studentinfo s
        ON c.payee = s.employeenumber
        WHERE c.ID='" & check12 & "' AND c.check_type ='0' AND (c.visit_id='" & visitdate_hf.Value & "' AND s.visit='" & visitdate_hf.Value & "' AND c.business_ID=" & businessID & ")"
                cmd.Connection = con
                dr = cmd.ExecuteReader

                While dr.Read()
                    checkName12_tb.Text = dr("payee")
                    'checkAmount12_lbl.Text = dr("check_amount")
                    writtenAmount12_tb.Text = dr("written_amount")
                    Memo12_tb.Text = dr("Memo")
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

        End If

        'Check 13
        If check13 <> 0 And check13 <> Nothing Then
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.CommandText = "SELECT c.business_ID, c.check_type, CONCAT(s.Firstname,' ',s.lastname) as payee, c.check_amount, c.written_amount, c.memo 
        FROM checksinfo c 
        Inner join studentinfo s
        ON c.payee = s.employeenumber
        WHERE c.ID='" & check13 & "' AND c.check_type ='0' AND (c.visit_id='" & visitdate_hf.Value & "' AND s.visit='" & visitdate_hf.Value & "' AND c.business_ID=" & businessID & ")"
                cmd.Connection = con
                dr = cmd.ExecuteReader

                While dr.Read()
                    checkName13_tb.Text = dr("payee")
                    'checkAmount13_lbl.Text = dr("check_amount")
                    writtenAmount13_tb.Text = dr("written_amount")
                    Memo13_tb.Text = dr("Memo")
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

        End If

        'Check 14
        If check14 <> 0 And check14 <> Nothing Then
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.CommandText = "SELECT c.business_ID, c.check_type, CONCAT(s.Firstname,' ',s.lastname) as payee, c.check_amount, c.written_amount, c.memo 
        FROM checksinfo c 
        Inner join studentinfo s
        ON c.payee = s.employeenumber
        WHERE c.ID='" & check14 & "' AND c.check_type ='0' AND (c.visit_id='" & visitdate_hf.Value & "' AND s.visit='" & visitdate_hf.Value & "' AND c.business_ID=" & businessID & ")"
                cmd.Connection = con
                dr = cmd.ExecuteReader

                While dr.Read()
                    checkName14_tb.Text = dr("payee")
                    'checkAmount14_lbl.Text = dr("check_amount")
                    writtenAmount14_tb.Text = dr("written_amount")
                    Memo14_tb.Text = dr("Memo")
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

        End If

        'Check 15
        If check15 <> 0 And check15 <> Nothing Then
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.CommandText = "SELECT c.business_ID, c.check_type, CONCAT(s.Firstname,' ',s.lastname) as payee, c.check_amount, c.written_amount, c.memo 
        FROM checksinfo c 
        Inner join studentinfo s
        ON c.payee = s.employeenumber
        WHERE c.ID='" & check15 & "' AND c.check_type ='0' AND (c.visit_id='" & visitdate_hf.Value & "' AND s.visit='" & visitdate_hf.Value & "' AND c.business_ID=" & businessID & ")"
                cmd.Connection = con
                dr = cmd.ExecuteReader

                While dr.Read()
                    checkName15_tb.Text = dr("payee")
                    'checkAmount15_lbl.Text = dr("check_amount")
                    writtenAmount15_tb.Text = dr("written_amount")
                    Memo15_tb.Text = dr("Memo")
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

        End If

        'Check 16
        If check16 <> 0 And check16 <> Nothing Then
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.CommandText = "SELECT c.business_ID, c.check_type, CONCAT(s.Firstname,' ',s.lastname) as payee, c.check_amount, c.written_amount, c.memo 
        FROM checksinfo c 
        Inner join studentinfo s
        ON c.payee = s.employeenumber
        WHERE c.ID='" & check16 & "' AND c.check_type ='0' AND (c.visit_id='" & visitdate_hf.Value & "' AND s.visit='" & visitdate_hf.Value & "' AND c.business_ID=" & businessID & ")"
                cmd.Connection = con
                dr = cmd.ExecuteReader

                While dr.Read()
                    checkName16_tb.Text = dr("payee")
                    'checkAmount16_lbl.Text = dr("check_amount")
                    writtenAmount16_tb.Text = dr("written_amount")
                    Memo16_tb.Text = dr("Memo")
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

        End If

        'Clear connection pools
        SqlConnection.ClearAllPools()

    End Sub

    'Sub Payroll2Function()
    '    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
    '    Dim con As New SqlConnection
    '    Dim cmd As New SqlCommand
    '    Dim dr As SqlDataReader
    '    Dim businessID As String = Request.QueryString("b")
    '    Dim VisitID As New GetVisitID
    '    Dim Visit As Integer = VisitID.GetVisitID
    '    Dim payroll As String = Request.QueryString("c1")
    '    Dim check1, check2, check3, check4, check5, check6, check7, check8, check9, check10, check11, check12, check13, check14, check15, check16 As Integer

    '    'Check for business ID
    '    If businessID = Nothing Then
    '        businessID = 0
    '    End If

    '    'Get visit ID
    '    If Not (IsPostBack) Then
    '        If Visit <> 0 Then
    '            visitdate_hf.Value = Visit
    '        End If
    '    End If

    '    cmd.Dispose()
    '    con.Close()

    '    'get check IDs and store them into an array
    '    Try

    '        con.ConnectionString = connection_string
    '        con.Open()
    '        cmd.CommandText = "SELECT c.id, c.business_ID, c.check_type, CONCAT(s.Firstname,' ',s.lastname) as payee2, c.check_amount, c.written_amount, c.memo
    '                                        FROM checksInfo c
    '                                        RIGHT JOIN studentInfo s ON s.employeenumber = c.payee
    '                                        WHERE c.memo='" & payrollGroup_lbl.Text & "' AND c.check_type = '0' AND (c.visit_id='" & visitdate_hf.Value & "' AND s.visit='" & visitdate_hf.Value & "' AND c.business_ID=" & businessID & ")
    '                                        ORDER BY id ASC"
    '        cmd.Connection = con
    '        dr = cmd.ExecuteReader

    '        Dim checks As ArrayList = New ArrayList()

    '        While dr.Read()
    '            checks.Add(dr("id"))
    '        End While

    '        check1 = checks(0)
    '        check2 = checks(1)
    '        check3 = checks(2)
    '        check4 = checks(3)
    '        check5 = checks(4)
    '        check6 = checks(5)
    '        check7 = checks(6)
    '        check8 = checks(7)
    '        check9 = checks(8)
    '        check10 = checks(9)
    '        check11 = checks(10)
    '        check12 = checks(11)
    '        check13 = checks(12)
    '        check14 = checks(13)
    '        check15 = checks(14)
    '        check16 = checks(15)

    '        If checks(0) = Nothing Then
    '            error_lbl.Text = "Nothing in here but us chickens"
    '        Else
    '            error_lbl.Text = "Wtf"
    '        End If


    '        cmd.Dispose()
    '        con.Close()
    '    Catch
    '        'error_lbl.Text = "Error in checks array"
    '        cmd.Dispose()
    '        con.Close()
    '        'Exit Sub
    '    End Try

    '    'Change text of 'Pay to the order of' and 'Memo' and the sign line
    '    Try

    '        Label6.Text = "A DIRECT DEPOSIT FOR "
    '        label100.Text = "WAS DEPOSITED AT BANK OF AMERICA"
    '        Label19.Text = "THIS IS NOT A CHECK | NON-NEGOTIABLE"


    '        Label8.Text = "A DIRECT DEPOSIT FOR "
    '        label10.Text = "WAS DEPOSITED AT BANK OF AMERICA"
    '        Label11.Text = "THIS IS NOT A CHECK | NON-NEGOTIABLE"


    '        Label18.Text = "A DIRECT DEPOSIT FOR "
    '        label21.Text = "WAS DEPOSITED AT BANK OF AMERICA"
    '        Label22.Text = "THIS IS NOT A CHECK | NON-NEGOTIABLE"


    '        Label28.Text = "A DIRECT DEPOSIT FOR "
    '        label30.Text = "WAS DEPOSITED AT BANK OF AMERICA"
    '        Label31.Text = "THIS IS NOT A CHECK | NON-NEGOTIABLE"


    '        Label13.Text = "A DIRECT DEPOSIT FOR "
    '        label15.Text = "WAS DEPOSITED AT BANK OF AMERICA"
    '        Label23.Text = "THIS IS NOT A CHECK | NON-NEGOTIABLE"


    '        Label34.Text = "A DIRECT DEPOSIT FOR "
    '        label36.Text = "WAS DEPOSITED AT BANK OF AMERICA"
    '        Label37.Text = "THIS IS NOT A CHECK | NON-NEGOTIABLE"


    '        Label43.Text = "A DIRECT DEPOSIT FOR "
    '        label45.Text = "WAS DEPOSITED AT BANK OF AMERICA"
    '        Label46.Text = "THIS IS NOT A CHECK | NON-NEGOTIABLE"


    '        Label52.Text = "A DIRECT DEPOSIT FOR "
    '        label54.Text = "WAS DEPOSITED AT BANK OF AMERICA"
    '        Label55.Text = "THIS IS NOT A CHECK | NON-NEGOTIABLE"


    '        Label61.Text = "A DIRECT DEPOSIT FOR "
    '        label63.Text = "WAS DEPOSITED AT BANK OF AMERICA"
    '        Label64.Text = "THIS IS NOT A CHECK | NON-NEGOTIABLE"


    '        Label70.Text = "A DIRECT DEPOSIT FOR "
    '        label72.Text = "WAS DEPOSITED AT BANK OF AMERICA"
    '        Label73.Text = "THIS IS NOT A CHECK | NON-NEGOTIABLE"


    '        Label79.Text = "A DIRECT DEPOSIT FOR "
    '        label81.Text = "WAS DEPOSITED AT BANK OF AMERICA"
    '        Label82.Text = "THIS IS NOT A CHECK | NON-NEGOTIABLE"


    '        Label88.Text = "A DIRECT DEPOSIT FOR "
    '        label90.Text = "WAS DEPOSITED AT BANK OF AMERICA"
    '        Label91.Text = "THIS IS NOT A CHECK | NON-NEGOTIABLE"


    '        Label97.Text = "A DIRECT DEPOSIT FOR "
    '        label99.Text = "WAS DEPOSITED AT BANK OF AMERICA"
    '        Label101.Text = "THIS IS NOT A CHECK | NON-NEGOTIABLE"


    '        Label107.Text = "A DIRECT DEPOSIT FOR "
    '        label109.Text = "WAS DEPOSITED AT BANK OF AMERICA"
    '        Label110.Text = "THIS IS NOT A CHECK | NON-NEGOTIABLE"


    '        Label116.Text = "A DIRECT DEPOSIT FOR "
    '        label118.Text = "WAS DEPOSITED AT BANK OF AMERICA"
    '        Label119.Text = "THIS IS NOT A CHECK | NON-NEGOTIABLE"


    '        Label125.Text = "A DIRECT DEPOSIT FOR "
    '        label127.Text = "WAS DEPOSITED AT BANK OF AMERICA"
    '        Label128.Text = "THIS IS NOT A CHECK | NON-NEGOTIABLE"

    '    Catch

    '    End Try

    '    cmd.Dispose()
    '    con.Close()

    '    'Make memo_tb invisible
    '    Try
    '        Memo1_tb.Visible = False
    '        Memo2_tb.Visible = False
    '        Memo3_tb.Visible = False
    '        Memo4_tb.Visible = False
    '        Memo5_tb.Visible = False
    '        Memo6_tb.Visible = False
    '        Memo7_tb.Visible = False
    '        Memo8_tb.Visible = False
    '        Memo9_tb.Visible = False
    '        Memo10_tb.Visible = False
    '        Memo11_tb.Visible = False
    '        Memo12_tb.Visible = False
    '        Memo13_tb.Visible = False
    '        Memo14_tb.Visible = False
    '        Memo15_tb.Visible = False
    '        Memo16_tb.Visible = False
    '    Catch

    '    End Try

    '    'Check 1
    '    If check1 <> 0 And check1 <> Nothing Then
    '        Try
    '            con.ConnectionString = connection_string
    '            con.Open()
    '            cmd.CommandText = "SELECT c.id, c.business_ID, c.check_type, CONCAT(s.Firstname,' ',s.lastname) as payee2, c.check_amount, c.written_amount, c.memo
    '                                        FROM checksInfo c
    '                                        RIGHT JOIN studentInfo s ON s.employeenumber = c.payee
    '                                        WHERE c.id = '" & check1 & "' AND c.check_type = '0' AND (c.visit_id='" & visitdate_hf.Value & "' AND s.visit='" & visitdate_hf.Value & "' AND c.business_ID=" & businessID & ")"
    '            cmd.Connection = con
    '            dr = cmd.ExecuteReader

    '            While dr.Read()
    '                checkName1_tb.Text = dr("payee2")
    '                'checkAmount1_lbl.Text = dr("check_amount")
    '                writtenAmount1_tb.Text = dr("written_amount")
    '            End While

    '            cmd.Dispose()
    '            con.Close()
    '        Catch
    '            error_lbl.Text = "error"
    '            Exit Sub
    '        Finally
    '            cmd.Dispose()
    '            con.Close()
    '        End Try

    '    End If

    '    'Check 2
    '    If check2 <> 0 And check2 <> Nothing Then
    '        Try
    '            con.ConnectionString = connection_string
    '            con.Open()
    '            cmd.CommandText = "SELECT c.business_ID, c.check_type, CONCAT(s.Firstname,' ',s.lastname) as payee, c.check_amount, c.written_amount, c.memo 
    '    FROM checksinfo c 
    '    Inner join studentinfo s
    '    ON c.payee = s.employeenumber
    '    WHERE c.ID='" & check2 & "' AND c.check_type ='0' AND (c.visit_id='" & visitdate_hf.Value & "' AND s.visit='" & visitdate_hf.Value & "' AND c.business_ID=" & businessID & ")"
    '            cmd.Connection = con
    '            dr = cmd.ExecuteReader

    '            While dr.Read()
    '                checkName2_tb.Text = dr("payee")
    '                checkAmount2_lbl.Text = dr("check_amount")
    '                writtenAmount2_tb.Text = dr("written_amount")
    '                Memo2_tb.Text = dr("Memo")
    '            End While

    '            cmd.Dispose()
    '            con.Close()
    '        Catch
    '            cmd.Dispose()
    '            con.Close()
    '        Finally
    '            cmd.Dispose()
    '            con.Close()
    '        End Try

    '    End If

    '    'Check 3
    '    If check3 <> 0 And check3 <> Nothing Then
    '        Try
    '            con.ConnectionString = connection_string
    '            con.Open()
    '            cmd.CommandText = "SELECT c.business_ID, c.check_type, CONCAT(s.Firstname,' ',s.lastname) as payee, c.check_amount, c.written_amount, c.memo 
    '    FROM checksinfo c 
    '    Inner join studentinfo s
    '    ON c.payee = s.employeenumber
    '    WHERE c.ID='" & check3 & "' AND c.check_type ='0' AND (c.visit_id='" & visitdate_hf.Value & "' AND s.visit='" & visitdate_hf.Value & "' AND c.business_ID=" & businessID & ")"
    '            cmd.Connection = con
    '            dr = cmd.ExecuteReader

    '            While dr.Read()
    '                checkName3_tb.Text = dr("payee")
    '                checkAmount3_lbl.Text = dr("check_amount")
    '                writtenAmount3_tb.Text = dr("written_amount")
    '                Memo3_tb.Text = dr("Memo")
    '            End While

    '            cmd.Dispose()
    '            con.Close()
    '        Catch
    '            cmd.Dispose()
    '            con.Close()
    '        Finally
    '            cmd.Dispose()
    '            con.Close()
    '        End Try

    '    End If

    '    'Check 4
    '    If check4 <> 0 And check4 <> Nothing Then
    '        Try
    '            con.ConnectionString = connection_string
    '            con.Open()
    '            cmd.CommandText = "SELECT c.business_ID, c.check_type, CONCAT(s.Firstname,' ',s.lastname) as payee, c.check_amount, c.written_amount, c.memo 
    '    FROM checksinfo c 
    '    Inner join studentinfo s
    '    ON c.payee = s.employeenumber
    '    WHERE c.ID='" & check4 & "' AND c.check_type ='0' AND (c.visit_id='" & visitdate_hf.Value & "' AND s.visit='" & visitdate_hf.Value & "' AND c.business_ID=" & businessID & ")"
    '            cmd.Connection = con
    '            dr = cmd.ExecuteReader

    '            While dr.Read()
    '                checkName4_tb.Text = dr("payee")
    '                checkAmount4_lbl.Text = dr("check_amount")
    '                writtenAmount4_tb.Text = dr("written_amount")
    '                Memo4_tb.Text = dr("Memo")
    '            End While

    '            cmd.Dispose()
    '            con.Close()
    '        Catch
    '            cmd.Dispose()
    '            con.Close()
    '        Finally
    '            cmd.Dispose()
    '            con.Close()
    '        End Try

    '    End If

    '    'check 5
    '    If check5 <> 0 And check5 <> Nothing Then
    '        Try
    '            con.ConnectionString = connection_string
    '            con.Open()
    '            cmd.CommandText = "SELECT c.business_ID, c.check_type, CONCAT(s.Firstname,' ',s.lastname) as payee, c.check_amount, c.written_amount, c.memo 
    '    FROM checksinfo c 
    '    Inner join studentinfo s
    '    ON c.payee = s.employeenumber
    '    WHERE c.ID='" & check5 & "' AND c.check_type ='0' AND (c.visit_id='" & visitdate_hf.Value & "' AND s.visit='" & visitdate_hf.Value & "' AND c.business_ID=" & businessID & ")"
    '            cmd.Connection = con
    '            dr = cmd.ExecuteReader

    '            While dr.Read()
    '                checkName5_tb.Text = dr("payee")
    '                checkAmount5_lbl.Text = dr("check_amount")
    '                writtenAmount5_tb.Text = dr("written_amount")
    '                Memo5_tb.Text = dr("Memo")
    '            End While

    '            cmd.Dispose()
    '            con.Close()
    '        Catch
    '            cmd.Dispose()
    '            con.Close()
    '        Finally
    '            cmd.Dispose()
    '            con.Close()
    '        End Try

    '    End If

    '    'Check 6
    '    If check6 <> 0 And check6 <> Nothing Then
    '        Try
    '            con.ConnectionString = connection_string
    '            con.Open()
    '            cmd.CommandText = "SELECT c.business_ID, c.check_type, CONCAT(s.Firstname,' ',s.lastname) as payee, c.check_amount, c.written_amount, c.memo 
    '    FROM checksinfo c 
    '    Inner join studentinfo s
    '    ON c.payee = s.employeenumber
    '    WHERE c.ID='" & check6 & "' AND c.check_type ='0' AND (c.visit_id='" & visitdate_hf.Value & "' AND s.visit='" & visitdate_hf.Value & "' AND c.business_ID=" & businessID & ")"
    '            cmd.Connection = con
    '            dr = cmd.ExecuteReader

    '            While dr.Read()
    '                checkName6_tb.Text = dr("payee")
    '                checkAmount6_lbl.Text = dr("check_amount")
    '                writtenAmount6_tb.Text = dr("written_amount")
    '                Memo6_tb.Text = dr("Memo")
    '            End While

    '            cmd.Dispose()
    '            con.Close()
    '        Catch
    '            cmd.Dispose()
    '            con.Close()
    '        Finally
    '            cmd.Dispose()
    '            con.Close()
    '        End Try

    '    End If

    '    'Check 7
    '    If check7 <> 0 And check7 <> Nothing Then
    '        Try
    '            con.ConnectionString = connection_string
    '            con.Open()
    '            cmd.CommandText = "SELECT c.business_ID, c.check_type, CONCAT(s.Firstname,' ',s.lastname) as payee, c.check_amount, c.written_amount, c.memo 
    '    FROM checksinfo c 
    '    Inner join studentinfo s
    '    ON c.payee = s.employeenumber
    '    WHERE c.ID='" & check7 & "' AND c.check_type ='0' AND (c.visit_id='" & visitdate_hf.Value & "' AND s.visit='" & visitdate_hf.Value & "' AND c.business_ID=" & businessID & ")"
    '            cmd.Connection = con
    '            dr = cmd.ExecuteReader

    '            While dr.Read()
    '                checkName7_tb.Text = dr("payee")
    '                checkAmount7_lbl.Text = dr("check_amount")
    '                writtenAmount7_tb.Text = dr("written_amount")
    '                Memo7_tb.Text = dr("Memo")
    '            End While

    '            cmd.Dispose()
    '            con.Close()
    '        Catch
    '            cmd.Dispose()
    '            con.Close()
    '        Finally
    '            cmd.Dispose()
    '            con.Close()
    '        End Try

    '    End If

    '    'Check 8
    '    If check8 <> 0 And check8 <> Nothing Then
    '        Try
    '            con.ConnectionString = connection_string
    '            con.Open()
    '            cmd.CommandText = "SELECT c.business_ID, c.check_type, CONCAT(s.Firstname,' ',s.lastname) as payee, c.check_amount, c.written_amount, c.memo 
    '    FROM checksinfo c 
    '    Inner join studentinfo s
    '    ON c.payee = s.employeenumber
    '    WHERE c.ID='" & check8 & "' AND c.check_type ='0' AND (c.visit_id='" & visitdate_hf.Value & "' AND s.visit='" & visitdate_hf.Value & "' AND c.business_ID=" & businessID & ")"
    '            cmd.Connection = con
    '            dr = cmd.ExecuteReader

    '            While dr.Read()
    '                checkName8_tb.Text = dr("payee")
    '                checkAmount8_lbl.Text = dr("check_amount")
    '                writtenAmount8_tb.Text = dr("written_amount")
    '                Memo8_tb.Text = dr("Memo")
    '            End While

    '            cmd.Dispose()
    '            con.Close()
    '        Catch
    '            cmd.Dispose()
    '            con.Close()
    '        Finally
    '            cmd.Dispose()
    '            con.Close()
    '        End Try

    '    End If

    '    'Check 9
    '    If check9 <> 0 And check9 <> Nothing Then
    '        Try
    '            con.ConnectionString = connection_string
    '            con.Open()
    '            cmd.CommandText = "SELECT c.business_ID, c.check_type, CONCAT(s.Firstname,' ',s.lastname) as payee, c.check_amount, c.written_amount, c.memo 
    '    FROM checksinfo c 
    '    Inner join studentinfo s
    '    ON c.payee = s.employeenumber
    '    WHERE c.ID='" & check9 & "' AND c.check_type ='0' AND (c.visit_id='" & visitdate_hf.Value & "' AND s.visit='" & visitdate_hf.Value & "' AND c.business_ID=" & businessID & ")"
    '            cmd.Connection = con
    '            dr = cmd.ExecuteReader

    '            While dr.Read()
    '                checkName9_tb.Text = dr("payee")
    '                checkAmount9_lbl.Text = dr("check_amount")
    '                writtenAmount9_tb.Text = dr("written_amount")
    '                Memo9_tb.Text = dr("Memo")
    '            End While

    '            cmd.Dispose()
    '            con.Close()
    '        Catch
    '            cmd.Dispose()
    '            con.Close()
    '        Finally
    '            cmd.Dispose()
    '            con.Close()
    '        End Try

    '    End If

    '    'Check 10
    '    If check10 <> 0 And check10 <> Nothing Then
    '        Try
    '            con.ConnectionString = connection_string
    '            con.Open()
    '            cmd.CommandText = "SELECT c.business_ID, c.check_type, CONCAT(s.Firstname,' ',s.lastname) as payee, c.check_amount, c.written_amount, c.memo 
    '    FROM checksinfo c 
    '    Inner join studentinfo s
    '    ON c.payee = s.employeenumber
    '    WHERE c.ID='" & check10 & "' AND c.check_type ='0' AND (c.visit_id='" & visitdate_hf.Value & "' AND s.visit='" & visitdate_hf.Value & "' AND c.business_ID=" & businessID & ")"
    '            cmd.Connection = con
    '            dr = cmd.ExecuteReader

    '            While dr.Read()
    '                checkName10_tb.Text = dr("payee")
    '                checkAmount10_lbl.Text = dr("check_amount")
    '                writtenAmount10_tb.Text = dr("written_amount")
    '                Memo10_tb.Text = dr("Memo")
    '            End While

    '            cmd.Dispose()
    '            con.Close()
    '        Catch
    '            cmd.Dispose()
    '            con.Close()
    '        Finally
    '            cmd.Dispose()
    '            con.Close()
    '        End Try

    '    End If

    '    'Check 11
    '    If check11 <> 0 And check11 <> Nothing Then
    '        Try
    '            con.ConnectionString = connection_string
    '            con.Open()
    '            cmd.CommandText = "SELECT c.business_ID, c.check_type, CONCAT(s.Firstname,' ',s.lastname) as payee, c.check_amount, c.written_amount, c.memo 
    '    FROM checksinfo c 
    '    Inner join studentinfo s
    '    ON c.payee = s.employeenumber
    '    WHERE c.ID='" & check11 & "' AND c.check_type ='0' AND (c.visit_id='" & visitdate_hf.Value & "' AND s.visit='" & visitdate_hf.Value & "' AND c.business_ID=" & businessID & ")"
    '            cmd.Connection = con
    '            dr = cmd.ExecuteReader

    '            While dr.Read()
    '                checkName11_tb.Text = dr("payee")
    '                checkAmount11_lbl.Text = dr("check_amount")
    '                writtenAmount11_tb.Text = dr("written_amount")
    '                Memo11_tb.Text = dr("Memo")
    '            End While

    '            cmd.Dispose()
    '            con.Close()
    '        Catch
    '            cmd.Dispose()
    '            con.Close()
    '        Finally
    '            cmd.Dispose()
    '            con.Close()
    '        End Try

    '    End If

    '    'Check 12
    '    If check12 <> 0 And check12 <> Nothing Then
    '        Try
    '            con.ConnectionString = connection_string
    '            con.Open()
    '            cmd.CommandText = "SELECT c.business_ID, c.check_type, CONCAT(s.Firstname,' ',s.lastname) as payee, c.check_amount, c.written_amount, c.memo 
    '    FROM checksinfo c 
    '    Inner join studentinfo s
    '    ON c.payee = s.employeenumber
    '    WHERE c.ID='" & check12 & "' AND c.check_type ='0' AND (c.visit_id='" & visitdate_hf.Value & "' AND s.visit='" & visitdate_hf.Value & "' AND c.business_ID=" & businessID & ")"
    '            cmd.Connection = con
    '            dr = cmd.ExecuteReader

    '            While dr.Read()
    '                checkName12_tb.Text = dr("payee")
    '                checkAmount12_lbl.Text = dr("check_amount")
    '                writtenAmount12_tb.Text = dr("written_amount")
    '                Memo12_tb.Text = dr("Memo")
    '            End While

    '            cmd.Dispose()
    '            con.Close()
    '        Catch
    '            cmd.Dispose()
    '            con.Close()
    '        Finally
    '            cmd.Dispose()
    '            con.Close()
    '        End Try

    '    End If

    '    'Check 13
    '    If check13 <> 0 And check13 <> Nothing Then
    '        Try
    '            con.ConnectionString = connection_string
    '            con.Open()
    '            cmd.CommandText = "SELECT c.business_ID, c.check_type, CONCAT(s.Firstname,' ',s.lastname) as payee, c.check_amount, c.written_amount, c.memo 
    '    FROM checksinfo c 
    '    Inner join studentinfo s
    '    ON c.payee = s.employeenumber
    '    WHERE c.ID='" & check13 & "' AND c.check_type ='0' AND (c.visit_id='" & visitdate_hf.Value & "' AND s.visit='" & visitdate_hf.Value & "' AND c.business_ID=" & businessID & ")"
    '            cmd.Connection = con
    '            dr = cmd.ExecuteReader

    '            While dr.Read()
    '                checkName13_tb.Text = dr("payee")
    '                checkAmount13_lbl.Text = dr("check_amount")
    '                writtenAmount13_tb.Text = dr("written_amount")
    '                Memo13_tb.Text = dr("Memo")
    '            End While

    '            cmd.Dispose()
    '            con.Close()
    '        Catch
    '            cmd.Dispose()
    '            con.Close()
    '        Finally
    '            cmd.Dispose()
    '            con.Close()
    '        End Try

    '    End If

    '    'Check 14
    '    If check14 <> 0 And check14 <> Nothing Then
    '        Try
    '            con.ConnectionString = connection_string
    '            con.Open()
    '            cmd.CommandText = "SELECT c.business_ID, c.check_type, CONCAT(s.Firstname,' ',s.lastname) as payee, c.check_amount, c.written_amount, c.memo 
    '    FROM checksinfo c 
    '    Inner join studentinfo s
    '    ON c.payee = s.employeenumber
    '    WHERE c.ID='" & check14 & "' AND c.check_type ='0' AND (c.visit_id='" & visitdate_hf.Value & "' AND s.visit='" & visitdate_hf.Value & "' AND c.business_ID=" & businessID & ")"
    '            cmd.Connection = con
    '            dr = cmd.ExecuteReader

    '            While dr.Read()
    '                checkName14_tb.Text = dr("payee")
    '                checkAmount14_lbl.Text = dr("check_amount")
    '                writtenAmount14_tb.Text = dr("written_amount")
    '                Memo14_tb.Text = dr("Memo")
    '            End While

    '            cmd.Dispose()
    '            con.Close()
    '        Catch
    '            cmd.Dispose()
    '            con.Close()
    '        Finally
    '            cmd.Dispose()
    '            con.Close()
    '        End Try

    '    End If

    '    'Check 15
    '    If check15 <> 0 And check15 <> Nothing Then
    '        Try
    '            con.ConnectionString = connection_string
    '            con.Open()
    '            cmd.CommandText = "SELECT c.business_ID, c.check_type, CONCAT(s.Firstname,' ',s.lastname) as payee, c.check_amount, c.written_amount, c.memo 
    '    FROM checksinfo c 
    '    Inner join studentinfo s
    '    ON c.payee = s.employeenumber
    '    WHERE c.ID='" & check15 & "' AND c.check_type ='0' AND (c.visit_id='" & visitdate_hf.Value & "' AND s.visit='" & visitdate_hf.Value & "' AND c.business_ID=" & businessID & ")"
    '            cmd.Connection = con
    '            dr = cmd.ExecuteReader

    '            While dr.Read()
    '                checkName15_tb.Text = dr("payee")
    '                checkAmount15_lbl.Text = dr("check_amount")
    '                writtenAmount15_tb.Text = dr("written_amount")
    '                Memo15_tb.Text = dr("Memo")
    '            End While

    '            cmd.Dispose()
    '            con.Close()
    '        Catch
    '            cmd.Dispose()
    '            con.Close()
    '        Finally
    '            cmd.Dispose()
    '            con.Close()
    '        End Try

    '    End If

    '    'Check 16
    '    If check16 <> 0 And check16 <> Nothing Then
    '        Try
    '            con.ConnectionString = connection_string
    '            con.Open()
    '            cmd.CommandText = "SELECT c.business_ID, c.check_type, CONCAT(s.Firstname,' ',s.lastname) as payee, c.check_amount, c.written_amount, c.memo 
    '    FROM checksinfo c 
    '    Inner join studentinfo s
    '    ON c.payee = s.employeenumber
    '    WHERE c.ID='" & check16 & "' AND c.check_type ='0' AND (c.visit_id='" & visitdate_hf.Value & "' AND s.visit='" & visitdate_hf.Value & "' AND c.business_ID=" & businessID & ")"
    '            cmd.Connection = con
    '            dr = cmd.ExecuteReader

    '            While dr.Read()
    '                checkName16_tb.Text = dr("payee")
    '                checkAmount16_lbl.Text = dr("check_amount")
    '                writtenAmount16_tb.Text = dr("written_amount")
    '                Memo16_tb.Text = dr("Memo")
    '            End While

    '            cmd.Dispose()
    '            con.Close()
    '        Catch
    '            cmd.Dispose()
    '            con.Close()
    '        Finally
    '            cmd.Dispose()
    '            con.Close()
    '        End Try

    '    End If

    '    'Clear connection pools
    '    SqlConnection.ClearAllPools()

    'End Sub

End Class