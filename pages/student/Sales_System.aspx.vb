
Imports System.Data.SqlClient
Imports System.Drawing.Printing
Public Class Sales_System
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim DBConnection As New DatabaseConection
    Dim logoRoot As String = "~/media/Logos/"
    Dim decTotal As Decimal
    Dim Visits As New Class_VisitData
    Dim Businesses As New Class_BusinessData
    Dim VisitID As Integer = Visits.GetVisitID

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim BusinessID As Integer = Request.QueryString("b")
        Dim Biz = Businesses.GetBusinessLogos(BusinessID)

        'Put cursor on the account number textbox
        Debit_card_account.Focus()

        If Not (IsPostBack) Then

            'McDonald's Sales
            If businessID = 17 Then
                label6.Text = "Type account number"
            End If

            'Check if visit is active currently
            If VisitID <> 0 Then
                visitdate_hf.Value = VisitID
            Else
                error_lbl.Text = "No visit date, please go to 'Database Creator' on the 'Tools / Reports' page and create a new school visit date."
                Debit_card_account.Enabled = False
                Enter_account_btn.Enabled = False
                item1_tb.Enabled = False
                total_tb2.Enabled = False
                total_tb.Enabled = False
                Enter_sale_btn.Enabled = False
                Cancel_sale_btn.Enabled = False
                F2URL.Enabled = False
            End If

            'Assign labels, buttons, background
            F2URL.NavigateUrl = "sales_history.aspx?B=" & BusinessID
            sales_system_div.Attributes("class") = Businesses.GetBackgroundClass(BusinessID)
            BusLogo_img.ImageUrl = Biz.ImagePath
            Me.Title = Biz.BusinessName & " Sales System"
            Label_date_time.Text = DateAndTime.Now.ToString("G")

        End If
    End Sub

    Protected Sub Enter_account_btn_Click(sender As Object, e As EventArgs) Handles Enter_account_btn.Click
        Dim GetStudentInfo As New Class_StudentData
        Dim netDeposit As Double = 0.00
        Dim netDeposit1 As Double = 0.00
        Dim netDeposit2 As Double = 0.00
        Dim netDeposit3 As Double = 0.00
        Dim netDeposit4 As Double = 0.00
        Dim totalTransactions As Double = 0.00
        Dim remainingBalance As Double = 0.00
        Dim savings As Double = 0.00
        Dim visitID As Integer = visitdate_hf.Value
        Dim studentInfo = GetStudentInfo.StudentLookup(visitID, Debit_card_account.Text)
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        con.ConnectionString = connection_string
        con.Open()
        cmd.Connection = con

        If IsNumeric(Debit_card_account.Text) Then

            Dim totalSale As Decimal = Convert.ToDecimal(Debit_card_account.Text)

            Try
                customer_name_lbl.Text = studentInfo.FirstName & " " & studentInfo.LastName
                employee_number_lbl.Text = studentInfo.AccountNumber
                cmd.CommandText = "SELECT netDeposit1, netDeposit2, netDeposit3, netDeposit4 FROM studentInfo WHERE visitID='" & visitID & "' AND accountNumber ='" & employee_number_lbl.Text & "'"
                dr = cmd.ExecuteReader
                While dr.Read
                    If dr("netDeposit1").ToString = Nothing Then
                        netDeposit1 = 0.00
                    Else
                        netDeposit1 = dr("netDeposit1")
                    End If
                    If dr("NetDeposit2").ToString = Nothing Then
                        netDeposit2 = 0.00
                    Else
                        netDeposit2 = dr("netDeposit2")
                    End If
                    If dr("NetDeposit3").ToString = Nothing Then
                        netDeposit3 = 0.00
                    Else
                        netDeposit3 = dr("netDeposit3")
                    End If
                    If dr("NetDeposit4").ToString = Nothing Then
                        netDeposit4 = 0.00
                    Else
                        netDeposit4 = dr("netDeposit4")
                    End If
                End While

                dr.Close()
                netDeposit = netDeposit1 + netDeposit2 + netDeposit3 + netDeposit4
                cmd = New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "SELECT SUM(saleamount + saleAmount2 + saleAmount3 + saleAmount4) as Transactions FROM transactions WHERE visitID ='" & visitID & "' AND accountNumber ='" & employee_number_lbl.Text & "'"
                dr = cmd.ExecuteReader
                While dr.Read
                    If dr("transactions").ToString = Nothing Then
                        totalTransactions = 0.00
                    Else
                        totalTransactions = dr("Transactions")
                    End If

                End While
                dr.Close()
                cmd.CommandText = "SELECT (savings) as savings FROM studentInfo WHERE visitID='" & visitID & "' AND accountNumber ='" & employee_number_lbl.Text & "'"
                dr = cmd.ExecuteReader
                While dr.Read()
                    If dr("savings").ToString = Nothing Then
                        savings = 0.00
                    Else
                        savings = dr("savings")
                    End If
                End While
                dr.Close()

                'Used if they dont have any transactions

                'Get remaining balance for customer
                remainingBalance = netDeposit - totalTransactions - savings
                balance_lbl.Text = remainingBalance.ToString("C")
                item1_tb.Focus()

                'Page.ClientScript.RegisterStartupScript(Me.GetType(), "print", "invalid();", True)
            Catch
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "invalid", "invalid();", True)
                Exit Sub
            End Try

        Else
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "sale_error", "sale_error();", True)
            Exit Sub
        End If

        cmd.Dispose()
        con.Close()

    End Sub

    Private Sub Enter_sale_btn_Click(sender As Object, e As EventArgs) Handles Enter_sale_btn.Click
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim netDeposit As Double = 0.00
        Dim netDeposit1 As Double = 0.00
        Dim netDeposit2 As Double = 0.00
        Dim netDeposit3 As Double = 0.00
        Dim netDeposit4 As Double = 0.00
        Dim totalTransactions As Double = 0.00
        Dim remainingBalance As Double = 0.00
        Dim savings As Double = 0.00
        'Dim totalSale As Decimal = Convert.ToDecimal(total_tb.Text)
        Dim businessID As String = Request.QueryString("b")
        Dim timestamp As DateTime = DateTime.Now
        Dim timestampSTR As String = timestamp.ToString("yyyy-MM-dd HH:mm:ss")
        Dim visitID As Integer = visitdate_hf.Value
        Dim sqlStatement As String

        con.ConnectionString = connection_string
        con.Open()
        cmd.Connection = con

        If Debit_card_account.Text = Nothing Then
            error_lbl.Text = "Please enter or swipe an account number."
            Exit Sub
        End If

        If IsNumeric(total_tb.Text) Then

            If total_tb2.Text = "" Then
                error_lbl.Text = "Please enter a dollar amount in item to continue the sale."
                Exit Sub
            End If

            If item2_tb.Text = "" Then
                item2_tb.Text = 0.00
            End If

            If item3_tb.Text = "" Then
                item3_tb.Text = 0.00
            End If

            If item4_tb.Text = "" Then
                item4_tb.Text = 0.00
            End If

            If item1_tb.Text.Contains(".50") Or item1_tb.Text.Contains(".00") Then
                error_lbl.Text = "Check passed."
                'error_lbl.Text = ""
            Else
                error_lbl.Text = "Item 1 can only be in 50 cent increments. Please enter a number ending with .50 or .00"
                Exit Sub
            End If

            If item2_tb.Text.Contains(".50") Or item2_tb.Text.Contains(".00") Or item2_tb.Text = 0 Then
                error_lbl.Text = "Check passed."
                'error_lbl.Text = ""
            Else
                error_lbl.Text = "Item 2 can only be in 50 cent increments. Please enter a number ending with .50 or .00"
                Exit Sub
            End If

            If item3_tb.Text.Contains(".50") Or item3_tb.Text.Contains(".00") Or item3_tb.Text = 0 Then
                error_lbl.Text = "Check passed."
                'error_lbl.Text = ""
            Else
                error_lbl.Text = "Item 3 can only be in 50 cent increments. Please enter a number ending with .50 or .00"
                Exit Sub
            End If

            If item4_tb.Text.Contains(".50") Or item4_tb.Text.Contains(".00") Or item4_tb.Text = 0 Then
                error_lbl.Text = "Check passed."
                'error_lbl.Text = ""
            Else
                error_lbl.Text = "Item 4 can only be in 50 cent increments. Please enter a number ending with .50 or .00"
                Exit Sub
            End If

            If item1_tb.Text < 1.5 Or item1_tb.Text > 14.0 Then
                error_lbl.Text = "Please enter a number between $1.50 and $14.00 for item 1."
                item1_tb.Text = ""
                item2_tb.Text = ""
                item3_tb.Text = ""
                item4_tb.Text = ""
                total_tb2.Text = ""
                Exit Sub
            End If

            If item2_tb.Text = 0.00 Then
                item2_tb.Text = 0.00
            ElseIf item2_tb.Text < 1.5 Or item2_tb.Text > 14.0 Then
                error_lbl.Text = "Please enter a number between $1.50 and $14.00 for item 2."
                item1_tb.Text = ""
                item2_tb.Text = ""
                item3_tb.Text = ""
                item4_tb.Text = ""
                total_tb2.Text = ""
                Exit Sub
            End If

            If item3_tb.Text = 0.00 Then
                item3_tb.Text = 0.00
            ElseIf item3_tb.Text < 1.5 Or item3_tb.Text > 14.0 Then
                error_lbl.Text = "Please enter a number between $1.50 and $14.00 for item 3."
                item1_tb.Text = ""
                item2_tb.Text = ""
                item3_tb.Text = ""
                item4_tb.Text = ""
                total_tb2.Text = ""
                Exit Sub
            End If

            If item4_tb.Text = 0.00 Then
                item4_tb.Text = 0.00
            ElseIf item4_tb.Text < 1.5 Or item4_tb.Text > 14.0 Then
                error_lbl.Text = "Please enter a number between $1.50 and $14.00 for item 4."
                item1_tb.Text = ""
                item2_tb.Text = ""
                item3_tb.Text = ""
                item4_tb.Text = ""
                total_tb2.Text = ""
                Exit Sub
            End If



            Dim totalSale As Decimal = Convert.ToDecimal(total_tb.Text)
            Dim empID As Integer
            If IsNumeric(employee_number_lbl.Text) Then
                empID = employee_number_lbl.Text
            Else
                error_lbl.Text = "Please enter an account number and press 'Enter Account'."
                Exit Sub
            End If
            'Try

            'THIS SECTION ONLY WORKS IF THERE ARE VALUES FOR EACH DEPOSIT AND AT LEAST 1 TRANSACTION
            cmd.CommandText = "SELECT netDeposit1, netDeposit2, netDeposit3, netDeposit4 FROM studentInfo WHERE visitID='" & visitID & "' AND accountNumber ='" & empID & "'"
            dr = cmd.ExecuteReader
            While dr.Read
                If dr("netDeposit1").ToString = Nothing Then
                    netDeposit1 = 0.00
                Else
                    netDeposit1 = dr("netDeposit1")
                End If
                If dr("NetDeposit2").ToString = Nothing Then
                    netDeposit2 = 0.00
                Else
                    netDeposit2 = dr("netDeposit2")
                End If
                If dr("NetDeposit3").ToString = Nothing Then
                    netDeposit3 = 0.00
                Else
                    netDeposit3 = dr("netDeposit3")
                End If
                If dr("NetDeposit4").ToString = Nothing Then
                    netDeposit4 = 0.00
                Else
                    netDeposit4 = dr("netDeposit4")
                End If
            End While

            dr.Close()
            netDeposit = netDeposit1 + netDeposit2 + netDeposit3 + netDeposit4
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "SELECT SUM(saleamount + saleAmount2 + saleAmount3 + saleAmount4) as Transactions FROM transactions WHERE visitID ='" & visitID & "' AND accountNumber ='" & empID & "'"
            dr = cmd.ExecuteReader
            While dr.Read
                If dr("transactions").ToString = Nothing Then
                    totalTransactions = 0.00
                Else
                    totalTransactions = dr("Transactions")
                End If

            End While
            dr.Close()
            cmd.CommandText = "SELECT (savings) as savings FROM studentInfo WHERE visitID='" & visitID & "' AND accountNumber ='" & empID & "'"
            dr = cmd.ExecuteReader
            While dr.Read()
                If dr("savings").ToString = Nothing Then
                    savings = 0.00
                Else
                    savings = dr("savings")
                End If
            End While
            dr.Close()

            'Used if they dont have any transactions

            'Get remaining balance for customer
            remainingBalance = netDeposit - totalTransactions - savings
            balance_lbl.Text = remainingBalance.ToString("C")
            If totalSale > remainingBalance Then
                'not enough $ to purchase
                error_lbl.Text = "Sale declined. Not enough balance."
                Exit Sub

            Else
                'has enough

                'Sale Amount 1
                Dim endCount = 0
                While endCount = 0
                    endCount = 1

                    Try
                        cmd = New SqlCommand
                        cmd.Connection = con
                        cmd.CommandText = "SELECT saleAmount FROM transactions WHERE visitID='" & visitdate_hf.Value & "' AND accountNumber='" & employee_number_lbl.Text & "' AND businessID='" & businessID & "'"

                        dr = cmd.ExecuteReader
                        If dr.HasRows Then
                            Exit Try
                        Else
                            sql_lbl.Text = "INSERT INTO transactions (accountNumber, businessID, transactionTimestamp, saleAmount, visitID, item1, item2, item3, item4, saleAmount2, saleAmount3, saleAmount4) VALUES ('" & employee_number_lbl.Text & "', '" & businessID & "', '" & timestampSTR & "', '" & totalSale & "', '" & visitdate_hf.Value & "', '" & item1_tb.Text & "', '" & item2_tb.Text & "', '" & item3_tb.Text & "', '" & item4_tb.Text & "', 0.00, 0.00, 0.00)"
                        End If

                        dr.Close()
                        sqlStatement = sql_lbl.Text
                        'Exit while if has rows
                        'Code here to execute query
                        cmd = New SqlCommand
                        cmd.Connection = con
                        cmd.CommandText = sqlStatement
                        cmd.ExecuteNonQuery()
                        'Exit While, continue with rest of code outside of while loop
                        Exit While

                    Catch
                        error_lbl.Text = "Error in sale."
                        Exit Sub
                    End Try
                    dr.Close()

                    'Sale 2
                    Try
                        cmd = New SqlCommand
                        cmd.Connection = con
                        cmd.CommandText = "SELECT saleAmount2, transactionTimeStamp2 FROM transactions WHERE visitID='" & visitdate_hf.Value & "' AND accountNumber='" & employee_number_lbl.Text & "' AND businessID='" & businessID & "'"

                        dr = cmd.ExecuteReader
                        While dr.Read()
                            If dr("saleAmount2").ToString = "0.00" And dr("transactionTimeStamp2").ToString = Nothing Then
                                sql_lbl.Text = "UPDATE transactions SET saleAmount2='" & totalSale & "', transactionTimeStamp2='" & timestampSTR & "', item1='" & item1_tb.Text & "', item2='" & item2_tb.Text & "', item3='" & item3_tb.Text & "', item4='" & item4_tb.Text & "' WHERE visitID='" & visitdate_hf.Value & "' AND accountNumber='" & employee_number_lbl.Text & "' AND businessID='" & businessID & "'"
                                Exit While
                            Else
                                Exit Try
                            End If
                        End While

                        dr.Close()
                        sqlStatement = sql_lbl.Text
                        'Exit while if has rows
                        'Code here to execute query
                        cmd = New SqlCommand
                        cmd.Connection = con
                        cmd.CommandText = sqlStatement
                        cmd.ExecuteNonQuery()
                        'Exit While, continue with rest of code outside of while loop
                        Exit While
                    Catch
                        error_lbl.Text = "Error in sale2."
                        Exit Sub
                    End Try
                    dr.Close()

                    'Sale 3
                    Try
                        cmd = New SqlCommand
                        cmd.Connection = con
                        cmd.CommandText = "SELECT saleAmount3, transactionTimeStamp3 FROM transactions WHERE visitID='" & visitdate_hf.Value & "' AND accountNumber='" & employee_number_lbl.Text & "' AND businessID='" & businessID & "'"

                        dr = cmd.ExecuteReader
                        While dr.Read()
                            If dr("saleAmount3").ToString = "0.00" And dr("transactionTimeStamp3").ToString = Nothing Then
                                sql_lbl.Text = "UPDATE transactions SET saleAmount3='" & totalSale & "', transactionTimeStamp3='" & timestampSTR & "', item1='" & item1_tb.Text & "', item2='" & item2_tb.Text & "', item3='" & item3_tb.Text & "', item4='" & item4_tb.Text & "' WHERE visitDate='" & visitdate_hf.Value & "' AND accountNumber='" & employee_number_lbl.Text & "' AND businessID='" & businessID & "'"
                                Exit While
                            Else
                                Exit Try
                            End If
                        End While

                        dr.Close()
                        sqlStatement = sql_lbl.Text
                        'Exit while if has rows
                        'Code here to execute query
                        cmd = New SqlCommand
                        cmd.Connection = con
                        cmd.CommandText = sqlStatement
                        cmd.ExecuteNonQuery()
                        'Exit While, continue with rest of code outside of while loop
                        Exit While
                    Catch
                        error_lbl.Text = "Error in sale3."
                        Exit Sub
                    End Try
                    dr.Close()

                    'Sale 4
                    Try
                        cmd = New SqlCommand
                        cmd.Connection = con
                        cmd.CommandText = "SELECT saleAmount4, transactionTimeStamp4 FROM transactions WHERE visitID='" & visitdate_hf.Value & "' AND accountNumber='" & employee_number_lbl.Text & "' AND businessID='" & businessID & "'"

                        dr = cmd.ExecuteReader
                        While dr.Read()
                            If dr("saleAmount4").ToString = "0.00" And dr("transactionTimeStamp4").ToString = Nothing Then
                                sql_lbl.Text = "UPDATE transactions SET saleAmount4='" & totalSale & "', transactionTimeStamp4='" & timestampSTR & "', item1='" & item1_tb.Text & "', item2='" & item2_tb.Text & "', item3='" & item3_tb.Text & "', item4='" & item4_tb.Text & "' WHERE visitID='" & visitdate_hf.Value & "' AND accountNumber='" & employee_number_lbl.Text & "' AND businessID='" & businessID & "'"
                                Exit While
                            Else
                                Exit Try
                            End If
                        End While

                        dr.Close()
                        sqlStatement = sql_lbl.Text
                        'Exit while if has rows
                        'Code here to execute query
                        cmd = New SqlCommand
                        cmd.Connection = con
                        cmd.CommandText = sqlStatement
                        cmd.ExecuteNonQuery()
                        'Exit While, continue with rest of code outside of while loop
                        Exit While
                    Catch
                        error_lbl.Text = "Error in sale4."
                        Exit Sub
                    End Try
                    dr.Close()

                    'Sale 5 / End Transaction
                    Try
                        cmd = New SqlCommand
                        cmd.Connection = con
                        cmd.CommandText = "SELECT saleAmount4, transactionTimeStamp4 FROM transactions WHERE visitID='" & visitdate_hf.Value & "' AND accountNumber='" & employee_number_lbl.Text & "' AND businessID='" & businessID & "'"

                        dr = cmd.ExecuteReader
                        While dr.Read()
                            If dr("saleAmount4").ToString <> "0.00" And dr("transactionTimeStamp4").ToString <> Nothing Then
                                error_lbl.Text = "This account number has reached the maximum amount of purchases for this business. Please see a staff member for more assistance."
                                Exit Sub
                                Exit While
                            End If
                        End While

                        dr.Close()
                        sqlStatement = sql_lbl.Text
                        'Exit while if has rows
                        'Code here to execute query
                        cmd = New SqlCommand
                        cmd.Connection = con
                        cmd.CommandText = sqlStatement
                        cmd.ExecuteNonQuery()
                        'Exit While, continue with rest of code outside of while loop
                        Exit While
                    Catch
                        error_lbl.Text = "Error in sale5."
                        Exit Sub
                    End Try
                    dr.Close()

                    endCount = 1
                End While

                'sqlStatement = sql_lbl.Text

                'cmd = New SqlCommand
                'cmd.Connection = con
                'cmd.CommandText = sqlStatement
                'cmd.ExecuteNonQuery()
                dr.Close()

                cmd = New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "SELECT COUNT(*) FROM transactions WHERE visitID ='" & visitdate_hf.Value & "' AND accountNumber = '" & employee_number_lbl.Text & "' AND businessID = '" & businessID & "' AND transactionTimeStamp ='" & timestampSTR & "' AND saleAmount ='" & totalSale & "'"

                dr = cmd.ExecuteReader
                If dr.HasRows Then
                    If businessID = 17 Then
                        Dim URLEnd As String = employee_number_lbl.Text

                        Response.Redirect("/pages/print/Print_Sales.aspx?b=" & URLEnd)
                    Else
                        remainingBalance = remainingBalance - total_tb2.Text
                        newBalance_div.Visible = True
                        balance_div.Visible = True
                        Label3_lbl.Text = "Previous Balance: "
                        newBalance_lbl.Text = remainingBalance.ToString("C")
                        Page.ClientScript.RegisterStartupScript(Me.GetType(), "ShowSucessText", "ShowSucessText();", True)
                    End If

                Else
                    'Transaction didn't save
                    error_lbl.Text = "Transaction did not save. Please see a staff member."
                End If
            End If

            cmd.Dispose()
            con.Close()

        Else
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "sale_error", "sale_error();", True)
        End If

        cmd.Dispose()
        con.Close()

    End Sub

    Private Sub Cancel_sale_btn_Click(sender As Object, e As EventArgs) Handles Cancel_sale_btn.Click
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "ResetPage", "ResetPage();", True)

    End Sub

    Protected Sub help_btn_Click(sender As Object, e As EventArgs) Handles help_btn.Click
        help_div.Visible = True
    End Sub

    Protected Sub close_btn_Click(sender As Object, e As EventArgs) Handles close_btn.Click
        help_div.Visible = False
    End Sub
End Class