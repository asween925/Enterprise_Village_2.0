
Imports System.Data.SqlClient
Imports System.Drawing.Printing
Public Class Sales_System_McDonalds
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim DBConnection As New DatabaseConection
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim logoRoot As String = "~/media/Logos/"
    Dim decTotal As Decimal
    Dim TransactionData As New Class_TransactionData
    Dim GetStudentInfo As New Class_StudentData
    Dim VisitData As New Class_VisitData
    Dim VisitID As Integer = VisitData.GetVisitID

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim businessID As String = Request.QueryString("b")
        Dim businessSQL As String = "SELECT logoPath, businessColor, businessName FROM businessinfo WHERE ID='" & businessID & "'"
        Dim currentURL As String = HttpContext.Current.Request.Url.AbsoluteUri

        'If the page is returning from a receipt print, it will close the page and open it again in order to have to tab open at once
        If currentURL = "https://ev.pcsb.org/pages/student/sales_system_mcdonalds.aspx?passprnt_code=0&passprnt_message=SUCCESS" Then
            'Page.ClientScript.RegisterStartupScript(Me.GetType(), "Close", "window.open()", True)
            Me.ClientScript.RegisterClientScriptBlock(Me.[GetType](), "Close", "window.close()", True)
            'Me.ClientScript.RegisterClientScriptBlock(Me.[GetType](), "Back", "window.history.back()", True)
        End If

        'Focus cursor on employee number textbox
        accountNumber_tb.Focus()

        If Not (IsPostBack) Then

            'If no visit created for today, show error
            If VisitID <> 0 Then
                visitdate_hf.Value = VisitID
            Else
                error_lbl.Text = "No visit date, please go to 'Database Creator' on the 'Tools / Reports' page and create a new school visit date."
                accountNumber_tb.Enabled = False
                enterAccount_btn.Enabled = False
                enterSale_btn.Enabled = False
                cancelSale_btn.Enabled = False
            End If

        End If

        'Clear all connections to reduce server load
        SqlConnection.ClearAllPools()
    End Sub

    Sub EnterAccount()
        Dim NetDepositTotal As Double = 0.00
        Dim NetDeposit1 As Double = 0.00
        Dim NetDeposit2 As Double = 0.00
        Dim NetDeposit3 As Double = 0.00
        Dim NetDeposit4 As Double = 0.00
        Dim TotalTransactions As Double = 0.00
        Dim RemainingBalance As Double = 0.00
        Dim Savings As Double = 0.00
        Dim AccountNumber As String = accountNumber_tb.Text
        Dim StudentInfo = GetStudentInfo.StudentLookup(VisitID, AccountNumber)
        Dim DepositInfo = TransactionData.GetDepositInfo(VisitID, AccountNumber)

        'Check if the number entered is assigned to a name
        If StudentInfo.FirstName = "" And StudentInfo.LastName = "" Then
            error_lbl.Text = "No name assigned for account number. Please try a different account number."
            Exit Sub
        End If

        Try
            'Assign net deposits to variables
            If DepositInfo.NetDeposit1 = Nothing Then
                NetDeposit1 = 0.00
            Else
                NetDeposit1 = DepositInfo.NetDeposit1
            End If
            If DepositInfo.NetDeposit2 = Nothing Then
                NetDeposit2 = 0.00
            Else
                NetDeposit2 = DepositInfo.NetDeposit2
            End If
            If DepositInfo.NetDeposit3 = Nothing Then
                NetDeposit3 = 0.00
            Else
                NetDeposit3 = DepositInfo.NetDeposit3
            End If
            If DepositInfo.NetDeposit4 = Nothing Then
                NetDeposit4 = 0.00
            Else
                NetDeposit4 = DepositInfo.NetDeposit4
            End If

            'Calculate net deposit total
            NetDepositTotal = NetDeposit1 + NetDeposit2 + NetDeposit3 + NetDeposit4

            'Get total transactions
            If TransactionData.GetTotalTransactions(AccountNumber, VisitID) = Nothing Then
                TotalTransactions = 0.00
            Else
                TotalTransactions = TransactionData.GetTotalTransactions(AccountNumber, VisitID)
            End If

            'Get savings
            If DepositInfo.Savings = Nothing Then
                Savings = 0.00
            Else
                Savings = DepositInfo.Savings
            End If

            'Get remaining balance for customer
            RemainingBalance = NetDepositTotal - TotalTransactions - Savings

            'Assign student name, account number, and current balance to labels
            customer_name_lbl.Text = StudentInfo.FirstName & " " & StudentInfo.LastName
            employee_number_lbl.Text = StudentInfo.AccountNumber
            balance_lbl.Text = RemainingBalance.ToString("C")

            'Move to second screen
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "McDonalds_Sales", "McDonalds_Sales();", True)

            'Page.ClientScript.RegisterStartupScript(Me.GetType(), "print", "invalid();", True)
        Catch
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "invalid", "invalid();", True)
            Exit Sub
        End Try

        'Clear all connections to reduce server load
        SqlConnection.ClearAllPools()
    End Sub

    Sub EnterSale()
        Dim NetDeposit As Double = 0.00
        Dim NetDeposit1 As Double = 0.00
        Dim NetDeposit2 As Double = 0.00
        Dim NetDeposit3 As Double = 0.00
        Dim NetDeposit4 As Double = 0.00
        Dim NetDepositTotal As Double = 0.00
        Dim SaleAmount As Double = 0.00
        Dim TotalTransactions As Double = 0.00
        Dim RemainingBalance As Double = 0.00
        Dim Savings As Double = 0.00
        Dim BusinessID As String = 17
        Dim Timestamp As DateTime = DateTime.Now
        Dim AccountNumber As Integer = employee_number_lbl.Text
        Dim SQLStatement As String
        Dim ReturnStatement As String
        Dim StudentInfo = GetStudentInfo.StudentLookup(VisitID, AccountNumber)
        Dim DepositInfo = TransactionData.GetDepositInfo(VisitID, AccountNumber)

        'Check if option has been selected
        If snack_rdo.Checked = False And drink_rdo.Checked = False And both_rdo.Checked = False Then
            error_lbl.Text = "Please select an option before entering a sale."
            Exit Sub
        End If

        'Assign amounts to saleAmount based on button checked
        If snack_rdo.Checked Then
            SaleAmount = 0.5
        ElseIf drink_rdo.Checked Then
            SaleAmount = 0.5
        ElseIf both_rdo.Checked Then
            SaleAmount = 1.0
        End If

        'Assign net deposits to variables
        If DepositInfo.NetDeposit1 = Nothing Then
            NetDeposit1 = 0.00
        Else
            NetDeposit1 = DepositInfo.NetDeposit1
        End If
        If DepositInfo.NetDeposit2 = Nothing Then
            NetDeposit2 = 0.00
        Else
            NetDeposit2 = DepositInfo.NetDeposit2
        End If
        If DepositInfo.NetDeposit3 = Nothing Then
            NetDeposit3 = 0.00
        Else
            NetDeposit3 = DepositInfo.NetDeposit3
        End If
        If DepositInfo.NetDeposit4 = Nothing Then
            NetDeposit4 = 0.00
        Else
            NetDeposit4 = DepositInfo.NetDeposit4
        End If

        'Calculate net deposit total
        NetDepositTotal = NetDeposit1 + NetDeposit2 + NetDeposit3 + NetDeposit4

        'Get total transactions
        If TransactionData.GetTotalTransactions(AccountNumber, VisitID) = Nothing Then
            TotalTransactions = 0.00
        Else
            TotalTransactions = TransactionData.GetTotalTransactions(AccountNumber, VisitID)
        End If

        'Get savings
        If DepositInfo.Savings = Nothing Then
            Savings = 0.00
        Else
            Savings = DepositInfo.Savings
        End If

        'Get remaining balance for customer
        RemainingBalance = NetDepositTotal - TotalTransactions - Savings

        'Check if sale amount is greater than current balance
        If SaleAmount > RemainingBalance Then
            error_lbl.Text = "Sale declined. Not enough balance."
            Exit Sub
        Else

            'This while loop is designed to check which sale is currently happening, 1, 2, 3, or 4. Example: if sale 3 has not happened but sale 1 has, it will exit the while loop after sale 2 has been made
            Dim endCount = 0
            While endCount = 0
                endCount = 1

                'Inserting a sale
                Try
                    'Sale amount is the same as item 1 because you cannot select more than 1 item at mcdonalds, items2-4 will always be 0.00
                    ReturnStatement = TransactionData.InsertSale(VisitID, AccountNumber, BusinessID, SaleAmount, SaleAmount)

                    'If the return statement is "has rows" then that means saleamount1 has already been entered, if it is "sale inserted" it means it was just inserted and it can exit the loop
                    If ReturnStatement = "Has Rows" Then
                        Exit Try
                    ElseIf ReturnStatement = "Sale inserted" Then
                        Exit While
                    End If
                Catch
                    error_lbl.Text = "Error in sale insertion. Please find a staff member."
                    Exit Sub
                End Try

                'Sale 2
                Try
                    ReturnStatement = TransactionData.Sale("2", VisitID, AccountNumber, BusinessID, SaleAmount, SaleAmount)

                    'If the return statement is "has rows" then that means saleamount1 has already been entered, if it is "sale inserted" it means it was just inserted and it can exit the loop
                    If ReturnStatement = "Has Rows" Then
                        Exit Try
                    ElseIf ReturnStatement = "Sale successful" Then
                        Exit While
                    End If
                Catch
                    error_lbl.Text = "Error in sale 2. Please find a staff member."
                    Exit Sub
                End Try

                'Sale 3
                Try
                    ReturnStatement = TransactionData.Sale("3", VisitID, AccountNumber, BusinessID, SaleAmount, SaleAmount)

                    'If the return statement is "has rows" then that means saleamount1 has already been entered, if it is "sale inserted" it means it was just inserted and it can exit the loop
                    If ReturnStatement = "Has Rows" Then
                        Exit Try
                    ElseIf ReturnStatement = "Sale successful" Then
                        Exit While
                    End If
                Catch
                    error_lbl.Text = "Error in sale 3. Please find a staff member."
                    Exit Sub
                End Try

                'Sale 4
                Try
                    ReturnStatement = TransactionData.Sale("4", VisitID, AccountNumber, BusinessID, SaleAmount, SaleAmount)

                    'If the Return statement Is "has rows" Then that means saleamount1 has already been entered, If it Is "sale inserted" it means it was just inserted And it can Exit the Loop
                    If ReturnStatement = "Has Rows" Then
                        error_lbl.Text = "This account number has reached the maximum amount of purchases for this business. Please see a staff member for more assistance."
                        Exit Sub
                    ElseIf ReturnStatement = "Sale successful" Then
                        Exit While
                    End If
                Catch
                    error_lbl.Text = "Error in sale 4. Please find a staff member."
                    Exit Sub
                End Try

                endCount = 1
            End While

        End If

        cmd.Dispose()
        con.Close()
        SqlConnection.ClearAllPools()

        'Show success message
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "DepositSucessText", "DepositSucessText();", True)

        'Refresh page after 4 seconds
        Dim meta As New HtmlMeta()
        meta.HttpEquiv = "Refresh"
        meta.Content = "4;url=sales_system_mcdonalds.aspx"
        Me.Page.Controls.Add(meta)
        error_lbl.Text = "Purchase successful!"

        'Move to print sales page to print receipt
        'Response.Redirect("/pages/print/Print_Sales.aspx?b=" & AccountNumber)
    End Sub

    Protected Sub enterAccount_btn_Click(sender As Object, e As EventArgs) Handles enterAccount_btn.Click
        EnterAccount()
    End Sub

    Private Sub enterSale_btn_Click(sender As Object, e As EventArgs) Handles enterSale_btn.Click
        EnterSale()
    End Sub

    Private Sub cancelSale_btn_Click(sender As Object, e As EventArgs) Handles cancelSale_btn.Click
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "ResetPage", "ResetPage();", True)
    End Sub

End Class