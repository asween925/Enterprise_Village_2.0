Imports System.Data.SqlClient
Public Class Online_Banking
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim DBConnection As New DatabaseConection
    Dim dr As SqlDataReader
    Dim logoRoot As String = "~/media/Logos/"
    Dim strProfit As String
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
    Dim cmd As New SqlCommand
    Dim con As New SqlConnection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim businessID As String = Request.QueryString("b")
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim cmd As New SqlCommand
        Dim con As New SqlConnection
        Dim dr As SqlDataReader

        If businessID = Nothing Then
            businessID = 0
        End If

        'McDonald's
        If businessID = 17 Then
            F3URL.Visible = True
            F3URL.NavigateUrl = "Sales_History.aspx?B=17"
            deposit2_tr.Visible = False
            deposit3_tr.Visible = False
        Else
            F3URL.Visible = False
        End If

        F1URL.NavigateUrl = "Check_writing_system.aspx?B=" & businessID
        F2URL.NavigateUrl = "Operating_check_writing_system.aspx?B=" & businessID


        If Not (IsPostBack) Then
            Dim VisitID As New Class_VisitData
            Dim Visit As Integer = VisitID.GetVisitID
            If Visit <> 0 Then
                visitdate_hf.Value = Visit
            End If

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

                    Me.Title = dr(2).ToString & " Online Banking"
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

            LoadData()
        End If

    End Sub

    Sub LoadData()
        Dim visitID As Integer = visitdate_hf.Value
        Dim businessID As String = Request.QueryString("b")
        Dim con As New SqlConnection
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        con.ConnectionString = connection_string
        con.Open()
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim startingAmount As Double = 0.00
        Dim loanAmount As Double = 0.00
        Dim Deposit1 As Double = 00.00
        Dim Deposit2 As Double = 00.00
        Dim Deposit3 As Double = 00.00
        Dim Deposit4 As Double = 00.00
        Dim Deposits As Double = 00.00
        Dim Profit As Double = 0.00
        Dim finalProfit As Double = 0.00

        Try
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "SELECT visitID, visitDate, businessID, profit, openstatus, startingAmount, loanAmount, deposit1, deposit2, deposit3, deposit4
                FROM onlineBanking WHERE visitID ='" & visitID & "' AND businessID='" & businessID & "'"
            dr = cmd.ExecuteReader
            While dr.Read
                If dr("deposit1").ToString = Nothing Then
                    Deposit1 = 0.00
                    Deposit1_tb.Text = ""
                Else
                    Deposit1 = dr("Deposit1")
                    Deposit1_tb.Text = Deposit1.ToString("C2")
                End If
                If dr("deposit2").ToString = Nothing Then
                    Deposit2 = 0.00
                    Deposit2_tb.Text = ""
                Else
                    Deposit2 = dr("Deposit2")
                    Deposit2_tb.Text = Deposit2.ToString("C2")
                End If
                If dr("deposit3").ToString = Nothing Then
                    Deposit3 = 00.00
                    Deposit3_tb.Text = ""
                Else
                    Deposit3 = dr("Deposit3")
                    Deposit3_tb.Text = Deposit3.ToString("C2")
                End If

                If dr("loanAmount").ToString = Nothing Then
                    loanAmount = 00.00
                    Loan_Amount_tb.Text = ""
                Else
                    loanAmount = dr("loanAmount")
                    Loan_Amount_tb.Text = loanAmount.ToString("C2")
                End If
                If dr("startingAmount").ToString = Nothing Then
                    startingAmount = 0.00
                Else
                    startingAmount = dr("startingAmount")
                End If

                If dr("deposit4").ToString = Nothing Then
                    Deposit4 = 0.00
                Else
                    Deposit4 = dr("deposit4")
                    misc_row_tr.Visible = True
                    final_profit_row_tr.Visible = True
                    deposit4_lbl.Text = Deposit4.ToString("C2")
                End If

                If dr("profit").ToString = Nothing Then
                    finalProfit = 0.00
                Else
                    finalProfit = dr("profit")
                    finalProfit_lbl.Visible = True
                    finalProfits_p.Visible = True
                    finalProfit_lbl.Text = finalProfit.ToString("C2")
                    finalProfit_lbl.Font.Bold = True
                    finalProfit_lbl.ForeColor = System.Drawing.Color.LightGreen
                    profit_lbl.Font.Bold = False
                    profit_lbl.ForeColor = System.Drawing.Color.Black
                    profit_lbl.Text = finalProfit - Deposit4
                End If
            End While

            dr.Close()

            'Display for loan amount and profits
            Deposits = Deposit1 + Deposit2 + Deposit3 + Deposit4 + startingAmount
            loan_amount_display_lbl.Text = loanAmount.ToString("C2")
            'Loan_Amount_tb.Text = loanAmount.ToString("F2")
            total_deposits_lbl.Text = Deposits.ToString("C2")
            Profit = Deposits - loanAmount
            profit_lbl.Text = Profit.ToString("C2")
            'Deposit1_tb.Text = Deposit1.ToString("F5")
            'Deposit2_tb.Text = Deposit2.ToString("F5")
            'Deposit3_tb.Text = Deposit3.ToString("F5")

            Try
                If Loan_Amount_tb.Text = Nothing Then
                    Loan_Amount_tb.Enabled = True
                    Update_loan_amount.Enabled = True
                    Deposit1_tb.Enabled = False
                    Update_deposit1.Enabled = False
                    Deposit2_tb.Enabled = False
                    Update_deposit2.Enabled = False
                    Deposit3_tb.Enabled = False
                    Update_deposit3.Enabled = False
                    Exit Try
                End If

                If Deposit1_tb.Text = Nothing Then
                    Loan_Amount_tb.Enabled = True
                    Update_loan_amount.Enabled = True
                    Deposit1_tb.Enabled = True
                    Update_deposit1.Enabled = True
                    Deposit2_tb.Enabled = False
                    Update_deposit2.Enabled = False
                    Deposit3_tb.Enabled = False
                    Update_deposit3.Enabled = False
                    Exit Try
                End If

                If Deposit2_tb.Text = Nothing Then
                    Loan_Amount_tb.Enabled = True
                    Update_loan_amount.Enabled = True
                    Deposit1_tb.Enabled = True
                    Update_deposit1.Enabled = True
                    Deposit2_tb.Enabled = True
                    Update_deposit2.Enabled = True
                    Deposit3_tb.Enabled = False
                    Update_deposit3.Enabled = False
                    Exit Try
                End If

                If Deposit3_tb.Text = Nothing Then
                    Loan_Amount_tb.Enabled = True
                    Update_loan_amount.Enabled = True
                    Deposit1_tb.Enabled = True
                    Update_deposit1.Enabled = True
                    Deposit2_tb.Enabled = True
                    Update_deposit2.Enabled = True
                    Deposit3_tb.Enabled = True
                    Update_deposit3.Enabled = True
                    Exit Try
                End If
            Catch
                Exit Try
            End Try

            strProfit = profit_lbl.Text
            If strProfit <= 0 Then
                profit_lbl.Font.Bold = True
                profit_lbl.ForeColor = System.Drawing.Color.Red

            End If

            If strProfit >= 1 Then
                profit_lbl.Font.Bold = True
                profit_lbl.ForeColor = System.Drawing.Color.LightGreen

            End If

            Me.profit_lbl.Text = strProfit

            If misc_row_tr.Visible = True And final_profit_row_tr.Visible = True Then
                profit_lbl.Font.Bold = False
                profit_lbl.ForeColor = System.Drawing.Color.Black
                Profit = finalProfit - Deposit4
                profit_lbl.Text = Profit.ToString("C2")
                Update_deposit1.Enabled = False
                Update_deposit2.Enabled = False
                Update_deposit3.Enabled = False
                Update_loan_amount.Enabled = False
                error_lbl.Text = "A staff member has entered your final profit."
            End If

        Catch
            con.Close()
        End Try

        con.Close()

    End Sub


    Private Sub Update_loan_amount_Click(sender As Object, e As EventArgs) Handles Update_loan_amount.Click
        UpdateEntries("loanAmount", Loan_Amount_tb.Text, "profit", profit_lbl.Text)
        LoadData()
    End Sub

    Private Sub Update_deposit1_Click(sender As Object, e As EventArgs) Handles Update_deposit1.Click
        UpdateEntries("deposit1", Deposit1_tb.Text, "profit", profit_lbl.Text)
        LoadData()
    End Sub

    Private Sub Update_deposit2_Click(sender As Object, e As EventArgs) Handles Update_deposit2.Click
        UpdateEntries("deposit2", Deposit2_tb.Text, "profit", profit_lbl.Text)
        LoadData()
    End Sub

    Private Sub Update_deposit3_Click(sender As Object, e As EventArgs) Handles Update_deposit3.Click
        UpdateEntries("deposit3", Deposit3_tb.Text, "profit", profit_lbl.Text)
        LoadData()
    End Sub


    Sub UpdateEntries(ByVal depositNum As String, ByVal depositAmount As String, ByVal profitnum As String, ByVal profitAmount As String)

        Dim businessID As String = Request.QueryString("b")
        Dim visitID As Integer = visitdate_hf.Value
        Dim amount() As String = depositAmount.Split(".")
        Dim dr As SqlDataReader
        Dim startingAmount As Double = 0.00
        Dim loanAmount As Double = 00.00
        Dim Deposit1 As Double = 00.00
        Dim Deposit2 As Double = 00.00
        Dim Deposit3 As Double = 00.00
        Dim Deposit4 As Double = 00.00
        Dim Deposits As Double = 00.00
        Dim Profit As Double = 0.00
        Dim finalProfit As Double = 0.00

        error_lbl.Text = ""


        'If Val(amount(0)) > 300 Then
        '    error_lbl.Text = "Amount entered is not acceptable value"
        '    'Using below to prevent screen from reseting when error
        '    Page.ClientScript.RegisterStartupScript(Me.GetType(), "Enter_account", "Enter_account();", True)
        '    Exit Sub
        'ElseIf Val(amount(0)) = 300 And Val(amount(1)) > 0 Then
        '    error_lbl.Text = "Deposit Amount not valid."
        '    'Using below to prevent screen from reseting when error
        '    Page.ClientScript.RegisterStartupScript(Me.GetType(), "Enter_account", "Enter_account();", True)
        '    Exit Sub
        'End If

        Try

            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "SELECT visitID, visitDate, businessID, profit, openstatus, startingAmount, loanAmount, deposit1, deposit2, deposit3, deposit4
                FROM onlineBanking WHERE visitID ='" & visitID & "' AND businessID='" & businessID & "'"
            dr = cmd.ExecuteReader
            While dr.Read
                If dr("deposit1").ToString = Nothing Then
                    Deposit1 = 0.00
                    Deposit1_tb.Text = ""
                Else
                    Deposit1 = dr("Deposit1")
                    Deposit1_tb.Text = Deposit1.ToString("C2")
                End If

                If dr("deposit2").ToString = Nothing Then
                    Deposit2 = 0.00
                    Deposit2_tb.Text = ""
                Else
                    Deposit2 = dr("Deposit2")
                    Deposit2_tb.Text = Deposit2.ToString("C2")
                End If

                If dr("deposit3").ToString = Nothing Then
                    Deposit3 = 00.00
                    Deposit3_tb.Text = ""
                Else
                    Deposit3 = dr("Deposit3")
                    Deposit3_tb.Text = Deposit3.ToString("C2")
                End If

                If dr("loanAmount").ToString = Nothing Then
                    loanAmount = 00.00
                    Loan_Amount_tb.Text = ""
                Else
                    loanAmount = dr("loanAmount")
                    Loan_Amount_tb.Text = loanAmount.ToString("C2")
                End If
                If dr("startingAmount").ToString = Nothing Then
                    startingAmount = 0.00
                Else
                    startingAmount = dr("startingAmount")
                End If

                If dr("deposit4").ToString = Nothing Then
                    Deposit4 = 0.00
                Else
                    Deposit4 = dr("deposit4")
                    deposit4_lbl.Visible = True
                    misc_row_tr.Visible = True
                    final_profit_row_tr.Visible = True
                    deposit4_lbl.Text = Deposit4.ToString("C2")
                End If

                If dr("profit").ToString = Nothing Then
                    finalProfit = 0.00
                Else
                    finalProfit = dr("profit")
                    finalProfit_lbl.Visible = True
                    finalProfits_p.Visible = True
                    finalProfit_lbl.Text = finalProfit.ToString("C2")
                    finalProfit_lbl.Font.Bold = True
                    finalProfit_lbl.ForeColor = System.Drawing.Color.LightGreen
                    profit_lbl.Font.Bold = False
                    profit_lbl.ForeColor = System.Drawing.Color.Black
                    profit_lbl.Text = finalProfit - Deposit4
                End If
            End While

            dr.Close()

            error_lbl.Text = " "

        Catch

        End Try

        If IsNumeric(Loan_Amount_tb.Text) Then
            If Loan_Amount_tb.Text > 300 Or Loan_Amount_tb.Text < 1 Then
                error_lbl.Text = "Please enter a number between 1 and 300."
                Exit Sub
            Else
                loanAmount = Loan_Amount_tb.Text
            End If
        ElseIf Loan_Amount_tb.Text = Nothing Then
            loanAmount = 00.00
            Loan_Amount_tb.Text = ""
        Else
            error_lbl.Text = "Please enter a number between 1 and 300."
            Exit Sub
        End If

        If IsNumeric(Deposit1_tb.Text) Then
            If Deposit1_tb.Text > 200 Or Deposit1_tb.Text < 1 Then
                error_lbl.Text = "Please enter a number between 1 and 200."
                Exit Sub
            Else
                Deposit1 = Deposit1_tb.Text
            End If
        ElseIf Deposit1_tb.Text = Nothing Then
            Deposit1 = 00.00
            Loan_Amount_tb.Text = ""
        Else
            error_lbl.Text = "Please enter a number between 1 and 300."
            Exit Sub
        End If

        If IsNumeric(Deposit2_tb.Text) Then
            If Deposit2_tb.Text > 300 Or Deposit2_tb.Text < 1 Then
                error_lbl.Text = "Please enter a number between 1 and 300."
                Exit Sub
            Else
                Deposit2 = Deposit2_tb.Text
            End If
        ElseIf Deposit2_tb.Text = Nothing Then
            Deposit2 = 00.00
            Loan_Amount_tb.Text = ""
        Else
            error_lbl.Text = "Please enter a number between 1 and 300."
            Exit Sub
        End If

        If IsNumeric(Deposit3_tb.Text) Then
            If Deposit3_tb.Text > 300 Or Deposit3_tb.Text < 1 Then
                error_lbl.Text = "Please enter a number between 1 and 300."
                Exit Sub
            Else
                Deposit3 = Deposit3_tb.Text
            End If
        ElseIf Deposit3_tb.Text = Nothing Then
            Deposit3 = 00.00
            Deposit3_tb.Text = ""
        Else
            error_lbl.Text = "Please enter a number between 1 and 300."
            Exit Sub
        End If

        'If Deposit3_tb.Text = Nothing Then
        '    Deposit3 = 00.00
        '    Deposit3_tb.Text = ""
        'Else
        '    Deposit3 = Deposit3_tb.Text
        'End If

        'Deposit1 = Deposit1_tb.Text
        'Deposit2 = Deposit2_tb.Text
        'Deposit3 = Deposit3_tb.Text
        Deposits = Deposit1 + Deposit2 + Deposit3 + startingAmount
        'loanAmount = Loan_Amount_tb.Text

        'Profit calculations
        profitAmount = startingAmount - loanAmount



        Try
            Dim con As New SqlConnection
            con.ConnectionString = connection_string
            con.Open()
            Dim cmd As New SqlCommand

            cmd.Connection = con
            cmd.CommandText = "UPDATE onlineBanking SET " & depositNum & "=@deposit, " & profitnum & "=@profit WHERE visitID ='" & visitID & "' AND businessID='" & businessID & "'"
            'cmd.CommandText = "UPDATE onlineBanking SET profit = startingAmount - loanAmount WHERE visitID ='" & visitID & "' AND businessID='" & businessID & "'"

            cmd.Parameters.Add("@startingAmount", SqlDbType.Decimal).Value = startingAmount
            cmd.Parameters.Add("@loanAmount", SqlDbType.Decimal).Value = loanAmount
            cmd.Parameters.Add("@deposit", SqlDbType.Decimal).Value = depositAmount
            cmd.Parameters.Add("@profit", SqlDbType.Decimal).Value = profitAmount


            cmd.ExecuteNonQuery()
            con.Close()
        Catch
            error_lbl.Text = "Error with update query. Try again."
            Exit Sub
        End Try

        Try
            Dim con As New SqlConnection
            con.ConnectionString = connection_string
            con.Open()
            Dim cmd As New SqlCommand

            cmd.Connection = con
            cmd.CommandText = "UPDATE onlineBanking SET profit = startingAmount - loanAmount WHERE visitID ='" & visitID & "' AND businessID='" & businessID & "'"

            'cmd.Parameters.Add("@startingAmount", SqlDbType.Decimal).Value = startingAmount
            'cmd.Parameters.Add("@loanAmount", SqlDbType.Decimal).Value = loanAmount
            'cmd.Parameters.Add("@deposit", SqlDbType.Decimal).Value = depositAmount
            'cmd.Parameters.Add("@profit", SqlDbType.Decimal).Value = profitAmount


            cmd.ExecuteNonQuery()
            con.Close()
        Catch
            error_lbl.Text = "Error with update query 2 (profit=startingAmount-loanAmount). Try again."
            Exit Sub
        End Try

        Try
            Dim con As New SqlConnection
            con.ConnectionString = connection_string
            con.Open()
            Dim cmd As New SqlCommand

            cmd.Connection = con
            cmd.CommandText = "UPDATE onlineBanking SET profit = startingAmount - loanAmount + '" & Deposits & "' WHERE visitID ='" & visitID & "' AND businessID='" & businessID & "'"

            'cmd.Parameters.Add("@startingAmount", SqlDbType.Decimal).Value = startingAmount
            'cmd.Parameters.Add("@loanAmount", SqlDbType.Decimal).Value = loanAmount
            'cmd.Parameters.Add("@deposit", SqlDbType.Decimal).Value = depositAmount
            'cmd.Parameters.Add("@profit", SqlDbType.Decimal).Value = profitAmount


            cmd.ExecuteNonQuery()
            con.Close()
        Catch
            error_lbl.Text = "Error with update query 3 (profit=startingAmount-loanAmount+Deposits. Try again."
            Exit Sub
        End Try

    End Sub


End Class