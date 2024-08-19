Imports System.Data.SqlClient
Imports System.Windows.Forms
Public Class Teller_System
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim DBConnection As New DatabaseConection
    Dim dr As SqlDataReader
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
    Dim TransactionData As New Class_TransactionData
    Dim StudentData As New Class_StudentData
    Dim VisitID As New Class_VisitData
    Dim Visit As Integer = VisitID.GetVisitID

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim currentURL As String = HttpContext.Current.Request.Url.AbsoluteUri

        If currentURL = "https://ev.pcsb.org/pages/student/teller_system.aspx?passprnt_code=0&passprnt_message=SUCCESS" Then
            'Page.ClientScript.RegisterStartupScript(Me.GetType(), "Close", "window.open()", True)
            Me.ClientScript.RegisterClientScriptBlock(Me.[GetType](), "Close", "window.close()", True)
        End If

    End Sub

    Sub EnterAccount()
        If employee_number_tb.Text = Nothing Then
            error_lbl.Text = "Please enter an account number."
            Exit Sub
        End If

        If employee_number_tb.Text > 235 Or employee_number_tb.Text < 1 Then
            error_lbl.Text = "No valid account number entered."
            Exit Sub
        Else
            LoadData()
        End If
    End Sub

    Sub EnterDeposit()
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim empID As Integer = employee_number_tb.Text
        Dim visitID As Integer = visitdate_hf.Value
        Dim timestamp As DateTime = DateTime.Now
        Dim sql As String = "SELECT 
            CASE WHEN netDeposit1 IS NULL OR netDeposit1 = 0.00 THEN 0 ELSE 1 END as ND1, 
            CASE WHEN netDeposit2 IS NULL OR netDeposit2 = 0.00 THEN 0 ELSE 1 END as ND2, 
            CASE WHEN netDeposit3 IS NULL OR netDeposit3 = 0.00 THEN 0 ELSE 1 END as ND3, 
            CASE WHEN netDeposit4 IS NULL OR netDeposit4 = 0.00 THEN 0 ELSE 1 END as ND4 
            FROM studentInfo WHERE visitID='" & visitID & "' AND accountNumber ='" & empID & "'"
        Dim checkAmount As String = Check_amount_ddl.SelectedValue.ToString
        Dim cashRecieved As String = cash_recieved_ddl.SelectedValue.ToString
        Dim URLEnd As String = employee_number_tb.Text
        Dim checkAmountIndex As String = Check_amount_ddl.SelectedIndex
        Dim cashIndex As String = cash_recieved_ddl.SelectedIndex
        Dim dr As SqlDataReader
        Dim NDNum As String = Nothing
        Dim deposit3Enable As String

        'Check if Check amount is blank
        If Check_amount_ddl.SelectedIndex = 0 Then
            error_lbl.Text = "Please select a dollar amount."
            Exit Sub
        End If

        'Only for non-testing accounts
        If (empID >= 211) And (empID <= 219) Then

        ElseIf (empID < 211) Or (empID > 219) Then

            'Check if deposit 2 or deposit 3 is enabled
            Try
                cmd = New SqlCommand
                cmd.Connection = con
                con.ConnectionString = connection_string
                con.Open()
                cmd.CommandText = "SELECT deposit3Enable FROM visitInfo WHERE id='" & visitdate_hf.Value & "'"
                dr = cmd.ExecuteReader

                While dr.Read()
                    deposit3Enable = dr("deposit3Enable").ToString
                    'error_lbl.Text = deposit2Enable & " " & deposit3Enable
                    If Deposit1_lbl.Text <> 0.00 Then
                        If Deposit2_lbl.Text <> 0.00 Then
                            If deposit3Enable = "False" Then
                                error_lbl.Text = "It is not time to deposit the third check. Please wait until the Enterprise Village staff enabled the 3rd deposits."
                                Exit Sub
                            Else
                                Exit Try
                            End If
                        End If

                        error_lbl.Text = "You do not need to deposit the 2nd check. Please wait until the direct deposit has been entered."
                        Exit Sub
                    End If
                End While

                con.Close()
                cmd.Dispose()

            Catch ex As Exception
                error_lbl.Text = "Error in EnterDeposit(). Could not check for deposit 2 or 3 enabled."
                Exit Sub
            End Try

        End If

        con.Close()
        cmd.Dispose()

        'Remove dollar sign from check amount and cash received
        checkAmount = checkAmount.Remove(0, 1)
        cashRecieved = cashRecieved.Remove(0, 1)

        'Clear error label
        error_lbl.Text = ""

        'Check if net deposit is totalling correctly
        If Net_tb2.Text <> Nothing And Net_tb2.Text <> "" Then
            Dim val As Double
            If Double.TryParse(Net_tb2.Text, val) = vbFalse Then
                'Error message - valid value
                error_lbl.Text = "Please enter a valid value."
                Exit Sub
            End If
        End If

        cmd = New SqlCommand
        cmd.Connection = con
        con.ConnectionString = connection_string
        con.Open()
        cmd.CommandText = sql

        dr = cmd.ExecuteReader

        If dr.HasRows Then
            While dr.Read()
                If dr("ND1").ToString = "0" Then
                    sql = "UPDATE studentInfo SET netDeposit1 = @nDeposit, CBW1 = @CBW, initialDeposit1 = @initial, tellerTimestamp1 = @tellerTimestamp WHERE visitID='" & visitID & "' AND accountNumber ='" & empID & "'"
                    NDNum = "netDeposit1"
                ElseIf dr("ND2").ToString = "0" Then
                    sql = "UPDATE studentInfo SET netDeposit2 = @nDeposit, CBW2 = @CBW, initialDeposit2 = @initial, tellerTimestamp2 = @tellerTimestamp WHERE visitID='" & visitID & "' AND accountNumber ='" & empID & "'"
                    NDNum = "netDeposit2"
                ElseIf dr("ND3").ToString = "0" Then
                    sql = "UPDATE studentInfo SET netDeposit3 = @nDeposit, CBW3 = @CBW, initialDeposit3 = @initial, tellerTimestamp3 = @tellerTimestamp WHERE visitID='" & visitID & "' AND accountNumber ='" & empID & "'"
                    NDNum = "netDeposit3"
                    'Below V   Commenting this out because the staff only wants 3 deposits for the teller system, not 4. Edited on 5/27/2022
                    'ElseIf dr("ND4").ToString = "0" Then
                    '    sql = "UPDATE studentInfo SET netDeposit4 = @nDeposit, CBW4 = @CBW, initialDeposit4 = @initial WHERE visit='" & visitID & "' AND employeeNumber ='" & empID & "'"
                    '    NDNum = "netDeposit4"
                Else
                    'Error message
                    error_lbl.Text = "You have reached the maximum number of deposits for the day (3). Please see a staff member for more assistance."
                    cmd.Dispose()
                    con.Close()
                    Exit Sub
                End If
            End While
        End If

        dr.Close()
        cmd.Dispose()

        cmd = New SqlCommand
        cmd.Connection = con
        cmd.CommandText = sql
        cmd.Parameters.AddWithValue("@initial", checkAmount)
        cmd.Parameters.AddWithValue("@nDeposit", Net_tb2.Text)
        cmd.Parameters.AddWithValue("@CBW", cashRecieved)
        cmd.Parameters.AddWithValue("@tellerTimestamp", timestamp)
        cmd.ExecuteNonQuery()
        cmd.Dispose()

        cmd = New SqlCommand
        cmd.Connection = con
        cmd.CommandText = "SELECT " & NDNum & " FROM studentInfo WHERE visitID='" & visitID & "' AND accountNumber ='" & empID & "'"
        dr = cmd.ExecuteReader

        While dr.Read()
            If dr(NDNum).ToString <> Net_tb2.Text Then
                'Did not save correctly
                error_lbl.Text = "Did not save correctly."
                Exit Sub
            Else
                'Saved
            End If
        End While

        dr.Close()
        cmd.Dispose()
        con.Close()

        'Show success message
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "DepositSucessText", "DepositSucessText();", True)

        'Refresh page after 4 seconds
        Dim meta As New HtmlMeta()
        meta.HttpEquiv = "Refresh"
        meta.Content = "4;url=teller_system.aspx"
        Me.Page.Controls.Add(meta)

        'Response.Redirect("./teller_system.aspx")

        'USE THIS PAGE TO GO TO THE PRINT RECEIPT PAGE
        'Response.Redirect("/pages/print/Print_Teller.aspx?b=" & URLEnd & "&b2=" & checkAmountIndex & "&b3=" & cashIndex)
    End Sub

    Sub OpenSavingsAccount()
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim visitID As Integer = visitdate_hf.Value
        Dim savings As String = savings_ddl.SelectedValue
        Dim empID As Integer = employee_number_tb.Text
        Dim savingsAmountIndex As String = savings_ddl.SelectedIndex

        'Check if DDL is blank
        If savings_ddl.SelectedIndex = 0 Then
            error_savings_lbl.Text = "Please select an amount to enter into the savings account."
            Exit Sub
        End If

        'Remove $ from savings amount
        savings = savings.Replace("$", "")

        'Check if savings has already been entered
        If Savings_lbl.Text = "0.00" Then

            'Update savings
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd = New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "UPDATE studentInfo SET savings = '" & savings & "', savingsTimestamp = '" & DateTime.Now() & "' WHERE visitID='" & visitID & "' AND accountNumber ='" & empID & "'"
                cmd.ExecuteNonQuery()
                cmd.Dispose()

                'Show success message
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "DepositSucessText", "DepositSucessText();", True)

                'Refresh page after 4 seconds
                Dim meta As New HtmlMeta()
                meta.HttpEquiv = "Refresh"
                meta.Content = "4;url=teller_system.aspx"
                Me.Page.Controls.Add(meta)

                'Go to savings receipt page
                'Response.Redirect("/pages/print/Print_Teller_Savings.aspx?b=" & empID & "&b2=" & savingsAmountIndex)

                cmd.Dispose()
                con.Close()

            Catch ex As Exception
                error_savings_lbl.Text = "Error. Could not open savings account. Please contact a teacher."
                Exit Sub
            End Try

            cmd.Dispose()
            con.Close()

        Else
            error_lbl.Text = "This student has already created their savings account."
            Exit Sub
        End If

    End Sub

    Sub LoadData()
        Dim studentInfo = StudentData.StudentLookup(Visit, employee_number_tb.Text)
        Dim DepositInfo = TransactionData.GetDepositInfo(Visit, employee_number_tb.Text)
        Dim netDeposit1 As Double
        Dim netDeposit2 As Double
        Dim netDeposit3 As Double
        Dim netDeposit4 As Double
        Dim netDeposit As Double
        Dim initialDeposit1 As Double
        Dim initialDeposit2 As Double
        Dim initialDeposit3 As Double
        Dim initialDeposit4 As Double
        Dim initialDeposit As Double
        Dim cbw1 As Double
        Dim cbw2 As Double
        Dim cbw3 As Double
        Dim cbw4 As Double
        Dim totalTransactions As Double
        Dim remainingBalance As Double = 0.00
        Dim businessID As String = Request.QueryString("b")
        Dim timestamp As DateTime = DateTime.Now
        Dim timestampSTR As String = timestamp.ToString("yyyy-MM-dd HH:mm:ss")
        Dim savings As Double = 0.00
        Dim empID As Integer = employee_number_tb.Text
        Dim visitID As Integer = visitdate_hf.Value
        Dim lbl As Double
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim deposit3Enable As String
        Dim deposit2Enable As String


        'Clear error label
        error_lbl.Text = ""

        'Dont know what this is
        If Check_amount_ddl.SelectedIndex = 0 Then
            Check_amount_ddl.SelectedIndex = 1
            cash_recieved_ddl.SelectedIndex = 0
            lbl = Check_amount_ddl.SelectedValue - cash_recieved_ddl.SelectedValue
            Net_tb2.Text = lbl.ToString("F2")
        End If

        'Resetting check amount index to 0
        Check_amount_ddl.SelectedIndex = 0

        'Enable enter deposit button
        Enter_deposit_btn.Enabled = True

        'Get student deposit, cash back, and savings info
        Try
            netDeposit1 = DepositInfo.NetDeposit1
            netDeposit2 = DepositInfo.NetDeposit2
            netDeposit3 = DepositInfo.NetDeposit3
            netDeposit4 = DepositInfo.NetDeposit4

            cbw1 = DepositInfo.CBW1
            cbw2 = DepositInfo.CBW2
            cbw3 = DepositInfo.CBW3
            cbw4 = DepositInfo.CBW4

            initialDeposit1 = DepositInfo.InitialDeposit1
            initialDeposit2 = DepositInfo.InitialDeposit2
            initialDeposit3 = DepositInfo.InitialDeposit3
            initialDeposit4 = DepositInfo.InitialDeposit4

            savings = DepositInfo.Savings
        Catch
            error_lbl.Text = "Error in LoadData(). Cannot net deposit info from student."
            Exit Sub
        End Try

        'Get total transactions
        Try
            totalTransactions = TransactionData.GetTotalTransactions(empID, Visit)
        Catch
            error_lbl.Text = "Error in LoadData(). There was an error getting transaction information for account number."
            Exit Sub
        End Try

        'Assign labels
        Try
            Deposit1_lbl.Text = netDeposit1.ToString("F2")
            Deposit2_lbl.Text = netDeposit2.ToString("F2")
            Deposit3_lbl.Text = netDeposit3.ToString("F2")
            Deposit4_lbl.Text = netDeposit4.ToString("F2")
            Savings_lbl.Text = savings.ToString("F2")

            netDeposit = netDeposit1 + netDeposit2 + netDeposit3 + netDeposit4
        Catch
            error_lbl.Text = "Error in LoadData(). Cannot assign deposit info to labels."
            Exit Sub
        End Try

        'Check if deposit 2 or deposit 3 is enabled
        Try
            cmd = New SqlCommand
            cmd.Connection = con
            con.ConnectionString = connection_string
            con.Open()
            cmd.CommandText = "SELECT deposit2Enable, deposit3Enable FROM visitInfo WHERE id='" & visitdate_hf.Value & "'"
            dr = cmd.ExecuteReader

            While dr.Read()
                deposit2Enable = dr("deposit2Enable").ToString
                deposit3Enable = dr("deposit3Enable").ToString
            End While

            con.Close()
            cmd.Dispose()

        Catch
            error_lbl.Text = "Error in LoadData(). Could not check if deposit 3 has been enabled. Please find a teacher."
            Exit Sub
        End Try

        'Check if direct deposit has been initiated
        If deposit2Enable = "False" Then
            savings_div.Visible = False
            deposit_div.Visible = True
        Else
            savings_div.Visible = True
            deposit_div.Visible = False
        End If

        If deposit2Enable = "true" And Savings_lbl.Text <> "0.00" Then

        End If

        'Check if direct deposit has been initiated
        If deposit3Enable = "True" Then
            savings_div.Visible = False
            deposit_div.Visible = True
        End If

        'Add student name and account number to side bar
        Try
            Name_lbl.Text = studentInfo.FirstName & " " & studentInfo.LastName
            Employee_number_lbl.Text = studentInfo.AccountNumber
        Catch
            error_lbl.Text = "Error in LoadData(). Cannot assign name or account number to labels."
            Exit Sub
        End Try

        'Get remaining balance for student
        netDeposit = netDeposit1 + netDeposit2 + netDeposit3 + netDeposit4
        remainingBalance = netDeposit - totalTransactions - savings
        Balance_lbl.Text = remainingBalance.ToString("C")
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "Enter", "Enter();", True)

    End Sub

    Private Sub Enter_account_btn_Click(sender As Object, e As EventArgs) Handles Enter_account_btn.Click
        EnterAccount()
    End Sub

    Private Sub Teller_System_Init(sender As Object, e As EventArgs) Handles Me.Init
        employee_number_tb.Focus()

        If Not (IsPostBack) Then


            If Visit <> 0 Then
                visitdate_hf.Value = Visit
            Else
                error_lbl.Text = "No visit date, please go to 'Database Creator' on the 'Tools / Reports' page and create a new school visit date."
                Enter_account_btn.Enabled = False
            End If

        End If
    End Sub

    Private Sub Enter_deposit_btn_Click(sender As Object, e As EventArgs) Handles Enter_deposit_btn.Click
        EnterDeposit()
    End Sub

    Protected Sub Check_amount_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Check_amount_ddl.SelectedIndexChanged
        Dim lbl As Double
        If Check_amount_ddl.SelectedIndex <> 0 Then
            lbl = Check_amount_ddl.SelectedValue - cash_recieved_ddl.SelectedValue
            Net_tb2.Text = lbl.ToString("F2")
        End If

    End Sub

    Protected Sub cash_recieved_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cash_recieved_ddl.SelectedIndexChanged
        Dim lbl As Double

        If Check_amount_ddl.SelectedIndex <> 0 Then
            lbl = Check_amount_ddl.SelectedValue - cash_recieved_ddl.SelectedValue
            Net_tb2.Text = lbl.ToString("F2")
        End If

    End Sub

    Protected Sub clear_btn_Click(sender As Object, e As EventArgs) Handles clear_btn.Click
        Response.Redirect("./teller_system.aspx")
    End Sub

    Protected Sub savings_btn_Click(sender As Object, e As EventArgs) Handles savings_btn.Click
        OpenSavingsAccount()
    End Sub
End Class