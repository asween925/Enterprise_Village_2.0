Imports System.Data.SqlClient

Public Class Account_Summary
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim DBConnection As New DatabaseConection
    Dim dr As SqlDataReader
    Dim StudentData As New Class_StudentData
    Dim VisitID As New Class_VisitData
    Dim TransactionData As New Class_TransactionData
    Dim Visit As Integer = VisitID.GetVisitID

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Makes cursor go to text box on page load
        employee_number.Focus()

        'Check if visit date has been created
        If Not (IsPostBack) Then
            If Visit <> 0 Then
                visitdate_hf.Value = Visit
            Else
                error2_lbl.Text = "No visit date, please go to 'Database Creator' on the 'Tools / Reports' page and create a new school visit date."
                employee_number.Enabled = False
                Enter_btn.Enabled = False
            End If
        End If

    End Sub

    Sub ViewAccountSummary()
        Dim netDeposit As Double
        Dim totalTransactions As Double
        Dim remainingBalance As Double
        Dim savings As Double = 0.00
        Dim netDeposit1 As Double = 0.00
        Dim netDeposit2 As Double = 0.00
        Dim netDeposit3 As Double = 0.00
        Dim netDeposit4 As Double = 0.00
        Dim empID As Integer = employee_number.Text
        Dim visitID As Integer = visitdate_hf.Value
        Dim Studentinfo = StudentData.StudentLookup(Visit, empID)

        'Check if an account number was entered
        If employee_number.Text = Nothing Or employee_number.Text = "" Then
            error2_lbl.Text = "No account number entered, tap in the textbox and swipe your debit card."
            Exit Sub
        End If

        'Check if employee number entered is within range
        If employee_number.Text < 1 Or employee_number.Text > 235 Then
            error2_lbl.Text = "Please enter a number between 1 and 235."
            Exit Sub
        End If

        'Clear error label
        error_lbl.Text = Nothing

        'Clear out transaction table
        Transactions_dgv.DataSource = Nothing
        Transactions_dgv.DataBind()

        'Get total transactions of student
        totalTransactions = TransactionData.GetTotalTransactions(empID, visitID)
        Total_purchases_lbl.Text = totalTransactions.ToString("C")

        'Display transaction info
        Try
            Transactions_dgv.DataSource = TransactionData.LoadTransactionTable(empID, Visit)
            Transactions_dgv.DataBind()
        Catch
            error2_lbl.Text = "There was an error getting account information, please inform a staff member."
            Exit Sub
        End Try

        'Assign student name and number to labels
        Name_lbl.Text = Studentinfo.FirstName & " " & Studentinfo.LastName
        Employee_number_lbl.Text = Studentinfo.AccountNumber

        'Get net deposit info
        Try
            Dim NetDeposits = TransactionData.GetDepositInfo(Visit, empID)

            netDeposit1 = NetDeposits.NetDeposit1
            netDeposit2 = NetDeposits.NetDeposit2
            netDeposit3 = NetDeposits.NetDeposit3
            netDeposit4 = NetDeposits.NetDeposit4

            savings = NetDeposits.Savings

            Deposit1_lbl.Text = netDeposit1.ToString("C")
            Deposit2_lbl.Text = netDeposit2.ToString("C")
            Deposit3_lbl.Text = netDeposit3.ToString("C")
            Deposit4_lbl.Text = netDeposit4.ToString("C")
            Savings_lbl.Text = savings.ToString("C")

        Catch
            error2_lbl.Text = "There was an error getting deposit information for account number, please inform a staff member."
            Exit Sub
        End Try

        'Get remaining balance for customer
        Try
            netDeposit = netDeposit1 + netDeposit2 + netDeposit3 + netDeposit4
            Total_deposit_lbl.Text = netDeposit.ToString("C")
            remainingBalance = netDeposit - totalTransactions - savings
            Balance_lbl.Text = remainingBalance.ToString("C")
        Catch
            error2_lbl.Text = "There was an error calculating account information, please inform a staff member."
            Exit Sub
        End Try

        'Switching to screen 2
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "Enter_account", "Enter_account();", True)
    End Sub

    Sub DisplayKeyboard()
        If number1_btn.Visible = False Then
            osk_btn.Text = "Close Keyboard"

            number1_btn.Visible = True
            number2_btn.Visible = True
            number3_btn.Visible = True
            number4_btn.Visible = True
            number5_btn.Visible = True
            number6_btn.Visible = True
            number7_btn.Visible = True
            number8_btn.Visible = True
            number9_btn.Visible = True
            number0_btn.Visible = True
            numberClear_btn.Visible = True
        Else
            osk_btn.Text = "Open Keyboard"

            number1_btn.Visible = False
            number2_btn.Visible = False
            number3_btn.Visible = False
            number4_btn.Visible = False
            number5_btn.Visible = False
            number6_btn.Visible = False
            number7_btn.Visible = False
            number8_btn.Visible = False
            number9_btn.Visible = False
            number0_btn.Visible = False
            numberClear_btn.Visible = False
        End If
    End Sub

    Private Sub Enter_btn_Click(sender As Object, e As EventArgs) Handles Enter_btn.Click
        ViewAccountSummary()
    End Sub

    Private Sub exit_btn_Click(sender As Object, e As EventArgs) Handles exit_btn.Click
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "ResetPage", "ResetPage();", True)
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "Exit_account", "Exit_account();", True)
        employee_number.Text = ""
        employee_number.Focus()
    End Sub

    Private Sub osk_btn_Click(sender As Object, e As EventArgs) Handles osk_btn.Click
        DisplayKeyboard()
    End Sub

    Protected Sub numberClear_btn_Click(sender As Object, e As EventArgs) Handles numberClear_btn.Click
        employee_number.Text = ""
    End Sub
End Class