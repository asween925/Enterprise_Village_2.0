Imports System.Data.SqlClient
Public Class Online_Banking
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
    Dim DBConnection As New DatabaseConection
    Dim Visits As New Class_VisitData
    Dim Businesses As New Class_BusinessData
    Dim VisitID As Integer = Visits.GetVisitID()
    Dim strProfit As String
    Dim logoRoot As String = "../../media/logos/"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim businessID As String = Request.QueryString("b")
        Dim BizLogos = Businesses.GetBusinessLogos(businessID)

        'If loading from McDonald's, make 3rd link button visible, disable despit 2 and 3 rows
        If businessID = 17 Then
            F3URL.Visible = True
            F3URL.NavigateUrl = "Sales_History.aspx?B=17"
            deposit2_tr.Visible = False
            deposit3_tr.Visible = False
        Else
            F3URL.Visible = False
        End If

        'Assign business ID to button links
        F1URL.NavigateUrl = "Check_writing_system.aspx?B=" & businessID
        F2URL.NavigateUrl = "Operating_check_writing_system.aspx?B=" & businessID


        If Not (IsPostBack) Then

            'Get business logo and add business name to title
            Try
                BusLogo_img.ImageUrl = logoRoot & BizLogos.ImagePath.ToString()
                Me.Title = BizLogos.BusinessName & " Online Banking"
            Catch
                error_lbl.Text = "Error in Page_load(). Cannot get image path and bcolor"
                Exit Sub
            End Try

            'Change background
            Select Case businessID
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

            'Load data
            LoadData()
        End If

    End Sub

    Sub LoadData()
        Dim BusinessID As String = Request.QueryString("b")
        Dim StartingBalance As Double = 0.00
        Dim LoanAmount As Double = 0.00
        Dim Deposit1 As Double = 00.00
        Dim Deposit2 As Double = 00.00
        Dim Deposit3 As Double = 00.00
        Dim Deposit4 As Double = 00.00
        Dim Deposits As Double = 00.00
        Dim Profit As Double = 0.00
        Dim Final As Double = 0.00

        'Get deposits, loan amounts, and profits from businessVisitInfo
        Try
            Dim Finances = Businesses.GetBusinessFinancials(VisitID, BusinessID)

            'Checking for null values and replacing them with a 0.00
            Deposit1 = Finances.Deposit1
            Deposit2 = Finances.Deposit2
            Deposit3 = Finances.Deposit3
            Deposit4 = Finances.Deposit4
            Profit = Finances.Profit
            LoanAmount = Finances.LoanAmount
            StartingBalance = Finances.StartingBalance

        Catch ex As Exception
            error_lbl.Text = "Error in LoadData(). Cannot get business financials. Please find a teacher!"
            Exit Sub
        End Try

        'Get total deposit amount
        Deposits = Deposit1 + Deposit2 + Deposit3 + Deposit4 + StartingBalance
        Profit = Deposits - LoanAmount

        'Add amounts to labels
        loan_amount_display_lbl.Text = LoanAmount.ToString("C2")
        total_deposits_lbl.Text = Deposits.ToString("C2")
        profit_lbl.Text = Profit.ToString("C2")

        'Change color of profit label based on if the profit is positive or negative
        If Profit <= 0 Then
            profit_lbl.Font.Bold = True
            profit_lbl.ForeColor = System.Drawing.Color.Red
        ElseIf Profit >= 1 Then
            profit_lbl.Font.Bold = True
            profit_lbl.ForeColor = System.Drawing.Color.LightGreen
        End If

        'Enable / disable fields based on deposits enetered

        If Loan_Amount_tb.Text = Nothing Then
            Loan_Amount_tb.Enabled = True
            update_btn.Enabled = True
            Exit Sub
        End If

        If Deposit1_tb.Text = "" Then
            Loan_Amount_tb.Enabled = True
            Deposit1_tb.Enabled = True
            Exit Sub
        End If

        If Deposit2_tb.Text = "" Then
            Loan_Amount_tb.Enabled = True
            update_btn.Enabled = True
            Deposit1_tb.Enabled = True
            Deposit2_tb.Enabled = True
            Exit Sub
        End If

        If Deposit3_tb.Text = "" Then
            Loan_Amount_tb.Enabled = True
            update_btn.Enabled = True
            Deposit1_tb.Enabled = True
            Deposit2_tb.Enabled = True
            Deposit3_tb.Enabled = True
            Exit Sub
        End If

    End Sub

    Sub UpdateEntries()
        Dim BusinessID As String = Request.QueryString("b")
        Dim Business = Businesses.GetBusinessFinancials(VisitID, businessID)
        Dim startingBalance As Double = Business.StartingBalance
        Dim loanAmount As Double = 00.00
        Dim Deposit1 As Double = 00.00
        Dim Deposit2 As Double = 00.00
        Dim Deposit3 As Double = 00.00
        Dim Deposit4 As Double = 00.00
        Dim Deposits As Double = 00.00
        Dim Profit As Double = 0.00
        Dim finalProfit As Double = 0.00

        'Clear error label
        error_lbl.Text = ""

        'Check for blank fields, if not blank or disabled, add the text values to variables
        If Loan_Amount_tb.Text = "" Then
            error_lbl.Text = "Please enter a loan amount before submiting."
            Exit Sub
        Else
            loanAmount = Loan_Amount_tb.Text
        End If

        If Deposit1_tb.Enabled = False Then
            Deposit1 = 0.00
        ElseIf Deposit1_tb.Enabled = True And Deposit1_tb.Text = "" Then
            error_lbl.Text = "Please enter an amount for deposit 1."
            Exit Sub
        Else
            Deposit1 = Deposit1_tb.Text
        End If

        If Deposit2_tb.Enabled = False Then
            Deposit2 = 0.00
        ElseIf Deposit2_tb.Enabled = True And Deposit2_tb.Text = "" Then
            error_lbl.Text = "Please enter an amount for deposit 2."
            Exit Sub
        Else
            Deposit2 = Deposit2_tb.Text
        End If

        If Deposit3_tb.Enabled = False Then
            Deposit3 = 0.00
        ElseIf Deposit3_tb.Enabled = True And Deposit3_tb.Text = "" Then
            error_lbl.Text = "Please enter an amount for deposit 3."
            Exit Sub
        Else
            Deposit3 = Deposit3_tb.Text
        End If

        'Calculate profit
        Profit = Deposit1 + Deposit2 + Deposit3 + startingBalance - loanAmount

        'Update entries and profit
        Try
            Businesses.UpdateOnlineBanking(VisitID, BusinessID, Deposit1, Deposit2, Deposit3, Deposit4, loanAmount, Profit)
        Catch ex As Exception
            error_lbl.Text = "Error in Submission(). Cannot update the financials. Please see a teacher for help."
            Exit Sub
        End Try



        ''Deposit1 = Deposit1_tb.Text
        ''Deposit2 = Deposit2_tb.Text
        ''Deposit3 = Deposit3_tb.Text
        'Deposits = Deposit1 + Deposit2 + Deposit3 + startingAmount
        ''loanAmount = Loan_Amount_tb.Text

        ''Profit calculations
        'profitAmount = startingAmount - loanAmount



        'Try
        '    Dim con As New SqlConnection
        '    con.ConnectionString = connection_string
        '    con.Open()
        '    Dim cmd As New SqlCommand

        '    cmd.Connection = con
        '    cmd.CommandText = "UPDATE businessVisitInfo SET " & depositNum & "=@deposit, " & profitnum & "=@profit WHERE visitID ='" & visitID & "' AND businessID='" & businessID & "'"
        '    'cmd.CommandText = "UPDATE businessVisitInfo SET profit = startingAmount - loanAmount WHERE visitID ='" & visitID & "' AND businessID='" & businessID & "'"
        '    cmd.Parameters.Add("@loanAmount", SqlDbType.Decimal).Value = loanAmount
        '    cmd.Parameters.Add("@deposit", SqlDbType.Decimal).Value = depositAmount
        '    cmd.Parameters.Add("@profit", SqlDbType.Decimal).Value = profitAmount


        '    cmd.ExecuteNonQuery()
        '    con.Close()
        'Catch
        '    error_lbl.Text = "Error with update query. Try again."
        '    Exit Sub
        'End Try

        'Try
        '    Dim con As New SqlConnection
        '    con.ConnectionString = connection_string
        '    con.Open()
        '    Dim cmd As New SqlCommand

        '    cmd.Connection = con
        '    cmd.CommandText = "UPDATE businessVisitInfo SET profit = profit - loanAmount WHERE visitID ='" & visitID & "' AND businessID='" & businessID & "'"

        '    'cmd.Parameters.Add("@startingAmount", SqlDbType.Decimal).Value = startingAmount
        '    'cmd.Parameters.Add("@loanAmount", SqlDbType.Decimal).Value = loanAmount
        '    'cmd.Parameters.Add("@deposit", SqlDbType.Decimal).Value = depositAmount
        '    'cmd.Parameters.Add("@profit", SqlDbType.Decimal).Value = profitAmount


        '    cmd.ExecuteNonQuery()
        '    con.Close()
        'Catch
        '    error_lbl.Text = "Error with update query 2 (profit=profit-loanAmount). Try again."
        '    Exit Sub
        'End Try

        'Try
        '    Dim con As New SqlConnection
        '    con.ConnectionString = connection_string
        '    con.Open()
        '    Dim cmd As New SqlCommand

        '    cmd.Connection = con
        '    cmd.CommandText = "UPDATE businessVisitInfo SET profit = profit - loanAmount + '" & Deposits & "' WHERE visitID ='" & visitID & "' AND businessID='" & businessID & "'"

        '    'cmd.Parameters.Add("@startingAmount", SqlDbType.Decimal).Value = startingAmount
        '    'cmd.Parameters.Add("@loanAmount", SqlDbType.Decimal).Value = loanAmount
        '    'cmd.Parameters.Add("@deposit", SqlDbType.Decimal).Value = depositAmount
        '    'cmd.Parameters.Add("@profit", SqlDbType.Decimal).Value = profitAmount


        '    cmd.ExecuteNonQuery()
        '    con.Close()
        'Catch
        '    error_lbl.Text = "Error with update query 3 (profit=profit-loanAmount+Deposits. Try again."
        '    Exit Sub
        'End Try

        'Load update data
        LoadData()

    End Sub



    Private Sub Update_loan_amount_Click(sender As Object, e As EventArgs) Handles update_btn.Click
        UpdateEntries()
    End Sub

End Class