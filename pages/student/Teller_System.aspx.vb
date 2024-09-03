Imports System.Data.SqlClient
Imports System.Diagnostics.Contracts
Imports System.Drawing
Imports System.Reflection
Imports System.Windows.Forms
Public Class Teller_System
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim DBConnection As New DatabaseConection
    Dim dr As SqlDataReader
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
    Dim TransactionData As New Class_TransactionData
    Dim StudentData As New Class_StudentData
    Dim VisitID As New Class_VisitData
    Dim Visit As Integer = VisitID.GetVisitID

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Sub EnterAccount()
        Dim AccountNumber As Integer

        'Check if textbox is empty or not
        If acctNum_tb.Text <> Nothing Then

            AccountNumber = acctNum_tb.Text

            'Check if account number is a valid account
            If AccountNumber < 1 Or AccountNumber > 240 Then

                'Invalid account number
                error_lbl.Text = "Please enter a valid account number between 1 and 240."
                Exit Sub

            Else

                'Make enter account div invisible and make next slide visible
                acctEnter_div.Visible = False
                screen2.Visible = True

                'Load account data
                LoadData(AccountNumber)
            End If

        Else
            error_lbl.Text = "Please enter an account to continue."
            Exit Sub
        End If

    End Sub

    Sub LoadData(AcctNum As Integer)
        Dim StudentName As String
        Dim Balance As Double
        Dim Deposit1 As Double
        Dim Deposit2 As Double
        Dim Deposit3 As Double
        Dim Savings As Double
        Dim Deposit3Enable As String
        Dim Student = StudentData.StudentLookup(Visit, AcctNum)
        Dim DepositInfo = TransactionData.GetDepositInfo(Visit, AcctNum)

        'Clear error label
        error_lbl.Text = ""

        'Get account number data and assign it to variables
        StudentName = Student.FirstName & " " & Student.LastName
        Deposit1 = DepositInfo.InitialDeposit1
        Deposit2 = DepositInfo.InitialDeposit2
        Deposit3 = DepositInfo.InitialDeposit3
        Balance = StudentData.GetStudentBalance(Visit, AcctNum)
        Savings = DepositInfo.Savings

        'Assign variables to labels
        acctNum_lbl.Text = AcctNum
        studentName_lbl.Text = StudentName
        Deposit1_lbl.Text = Deposit1.ToString("C2")
        Deposit2_lbl.Text = Deposit2.ToString("C2")
        Deposit3_lbl.Text = Deposit3.ToString("C2")
        Balance_lbl.Text = Balance.ToString("C2")
        Savings_lbl.Text = Savings.ToString("C2")

        'Check if deposit 2 or 3 is enabled
        'Check if account number is a test account (211-219)
        If (AcctNum < 211) Or (AcctNum > 219) Then

            'Check if deposit 2 or deposit 3 is enabled
            Try
                cmd.Connection = con
                con.ConnectionString = connection_string
                con.Open()
                cmd.CommandText = "SELECT deposit3Enable FROM visitInfo WHERE id='" & Visit & "'"
                dr = cmd.ExecuteReader

                While dr.Read()

                    Deposit3Enable = dr("deposit3Enable").ToString

                    'Check if deposit 1 has been entered
                    If deposit1_lbl.Text <> "$0.00" Then

                        'Check if deposit 2 has been entered
                        If deposit2_lbl.Text <> "$0.00" Then

                            'Check if deposit 3 has been enabled by the staff via magic computer
                            If Deposit3Enable = "False" Then

                                'Disable deposit buttons
                                seven_rdo.Disabled = True
                                sixfive_rdo.Disabled = True
                                six_rdo.Disabled = True

                                'Check if savings account has been created
                                If savings_lbl.Text <> "$0.00" Then

                                    'Enable savings and submit buttons
                                    savings50_rdo.Disabled = True
                                    savings100_rdo.Disabled = True
                                    savings150_rdo.Disabled = True
                                    submit_btn.Enabled = False

                                    error_lbl.Text = "It is not time to deposit the 3rd check. Please wait until the 3rd deposit is active."

                                    'Savings is $0
                                Else

                                    'Enable savings and submit buttons
                                    savings50_rdo.Disabled = False
                                    savings100_rdo.Disabled = False
                                    savings150_rdo.Disabled = False
                                    submit_btn.Enabled = True

                                    error_lbl.Text = "Please open a savings account or cancel the deposit."

                                End If

                                'Deposit 3 is active
                            Else

                                'Enable deposit, submit and cashback buttons
                                seven_rdo.Disabled = False
                                sixfive_rdo.Disabled = False
                                six_rdo.Disabled = False
                                cash100_rdo.Disabled = False
                                cash75_rdo.Disabled = False
                                cash50_rdo.Disabled = False
                                cash25_rdo.Disabled = False
                                cash00_rdo.Disabled = False
                                submit_btn.Enabled = True

                                'Make savings div invisible
                                savings_div.Visible = False
                                deposit_div.Visible = True

                                Exit Try
                            End If

                            'Make savings div visible
                            savings_div.Visible = True
                            deposit_div.Visible = False
                            cashback_div.Visible = False

                        Else

                            'Disable deposit, submit and cashback buttons
                            seven_rdo.Disabled = True
                            sixfive_rdo.Disabled = True
                            six_rdo.Disabled = True
                            cash100_rdo.Disabled = True
                            cash75_rdo.Disabled = True
                            cash50_rdo.Disabled = True
                            cash25_rdo.Disabled = True
                            cash00_rdo.Disabled = True
                            submit_btn.Enabled = False

                            error_lbl.Text = "You do not need to deposit the 2nd check. Please wait until the direct deposit has been entered."
                            Exit Sub

                        End If

                    Else

                        'Make deposit div visible
                        deposit_div.Visible = True
                        savings_div.Visible = False

                    End If

                End While

                con.Close()
                cmd.Dispose()

            Catch
                error_lbl.Text = "Error in EnterDeposit(). Could not check for deposit 2 or 3 enabled."
                Exit Sub
            End Try

        End If

    End Sub

    Sub Submit()
        Dim AcctNum As Integer = acctNum_lbl.Text
        Dim DepositAmount As Double = 0.00
        Dim NetDeposit As Double = 0.00
        Dim Cashback As String
        Dim Savings As Double = 0.00
        Dim Timestamp As String = DateTime.Now()
        Dim SQLStatementUpdate As String
        Dim Deposit3Status As String = GetDeposit3Status()
        Dim SQLStatementND As String = "SELECT 
            CASE WHEN netDeposit1 IS NULL OR netDeposit1 = 0.00 THEN 0 ELSE 1 END as ND1, 
            CASE WHEN netDeposit2 IS NULL OR netDeposit2 = 0.00 THEN 0 ELSE 1 END as ND2, 
            CASE WHEN netDeposit3 IS NULL OR netDeposit3 = 0.00 THEN 0 ELSE 1 END as ND3, 
            CASE WHEN netDeposit4 IS NULL OR netDeposit4 = 0.00 THEN 0 ELSE 1 END as ND4,
			CASE WHEN savings IS NULL OR savings = 0.00 THEN 0 ELSE 1 END as savings 
            FROM studentInfo WHERE visitID='" & Visit & "' AND accountNumber ='" & AcctNum & "'"

        'Check if dollar amount is selected
        If deposit_div.Visible = True Then
            If seven_rdo.Checked = True Then
                DepositAmount = 7.0
            ElseIf sixfive_rdo.Checked = True Then
                DepositAmount = 6.5
            ElseIf six_rdo.Checked = True Then
                DepositAmount = 6.0
            Else
                error_lbl.Text = "Please select a dollar amount to deposit."
                Exit Sub
            End If

            'Check if cashback is selected
            If cash100_rdo.Checked = True Then
                Cashback = "1.00"
            ElseIf cash75_rdo.Checked = True Then
                Cashback = "0.75"
            ElseIf cash50_rdo.Checked = True Then
                Cashback = "0.5"
            ElseIf cash25_rdo.Checked = True Then
                Cashback = "0.25"
            ElseIf cash00_rdo.Checked = True Then
                Cashback = "0"
            End If
        Else
            'Check if savings is selected
            If savings150_rdo.Checked = True Then
                Savings = 1.5
            ElseIf savings100_rdo.Checked = True Then
                Savings = 1.0
            ElseIf savings50_rdo.Checked = True Then
                Savings = 0.5
            End If
        End If

        'Calculate the net deposit
        NetDeposit = DepositAmount - Cashback

        'Check which deposit (1, 2, or 3) is active
        Try
            cmd.Connection = con
            con.ConnectionString = connection_string
            con.Open()
            cmd.CommandText = SQLStatementND

            dr = cmd.ExecuteReader

            If dr.HasRows Then
                While dr.Read()
                    If dr("ND1").ToString = "0" Then
                        SQLStatementUpdate = "UPDATE studentInfo SET netDeposit1 = @nDeposit, CBW1 = @CBW, initialDeposit1 = @initial, tellerTimestamp1 = @tellerTimestamp WHERE visitID='" & Visit & "' AND accountNumber ='" & AcctNum & "'"
                        'ElseIf dr("ND2").ToString = "0" Then
                        '    SQLStatementUpdate = "UPDATE studentInfo SET savings = @savings, netDeposit2 = @nDeposit, CBW2 = @CBW, initialDeposit2 = @initial, tellerTimestamp2 = @tellerTimestamp WHERE visitID='" & Visit & "' AND accountNumber ='" & AcctNum & "'"
                    ElseIf dr("ND2").ToString = "1" And dr("savings").ToString = "0" Then
                        SQLStatementUpdate = "UPDATE studentInfo SET savings = @savings, savingsTimestamp = @savingsTimestamp WHERE visitID='" & Visit & "' AND accountNumber ='" & AcctNum & "'"
                    ElseIf dr("ND3").ToString = "0" Then
                        SQLStatementUpdate = "UPDATE studentInfo SET netDeposit3 = @nDeposit, CBW3 = @CBW, initialDeposit3 = @initial, tellerTimestamp3 = @tellerTimestamp WHERE visitID='" & Visit & "' AND accountNumber ='" & AcctNum & "'"
                    Else
                        cmd.Dispose()
                        con.Close()

                        error_lbl.Text = "You have reached the maximum number of deposits for the day (3). Please see a staff member for more assistance."
                        Exit Sub
                    End If
                End While
            End If

            cmd.Dispose()
            con.Close()
        Catch
            error_lbl.Text = "Error in Submit(). Cannot check for deposits."
            Exit Sub
        End Try

        'Update student info
        If deposit_div.Visible = True Then
            Try
                cmd.Connection = con
                con.ConnectionString = connection_string
                con.Open()
                cmd.CommandText = SQLStatementUpdate
                cmd.Parameters.AddWithValue("@initial", DepositAmount)
                cmd.Parameters.AddWithValue("@nDeposit", NetDeposit)
                cmd.Parameters.AddWithValue("@CBW", Cashback)
                cmd.Parameters.AddWithValue("@tellerTimestamp", Timestamp)
                cmd.ExecuteNonQuery()
                cmd.Dispose()

            Catch
                error_lbl.Text = "Error in Submit(). Cannot deposit amount."
                Exit Sub
            End Try
        ElseIf savings_div.Visible = True Then
            Try
                cmd.Connection = con
                con.ConnectionString = connection_string
                con.Open()
                cmd.CommandText = SQLStatementUpdate
                cmd.Parameters.AddWithValue("@savings", Savings)
                cmd.Parameters.AddWithValue("@savingsTimestamp", Timestamp)
                cmd.ExecuteNonQuery()
                cmd.Dispose()

            Catch
                error_lbl.Text = "Error in Submit(). Cannot deposit savings amount."
                Exit Sub
            End Try
        End If


        'Show success message
        error_lbl.Text = "Deposit successful!"

        'Refresh page after 4 seconds
        Dim meta As New HtmlMeta()
        meta.HttpEquiv = "Refresh"
        meta.Content = "4;url=teller_system.aspx"
        Me.Page.Controls.Add(meta)

    End Sub

    Sub Back()

        'Hide screen 2, reveal enter account window
        error_lbl.Text = ""
        screen2.Visible = False
        acctEnter_div.Visible = True

    End Sub

    Function GetDeposit3Status()
        Dim Deposit3Enable As String

        Try
            cmd.Connection = con
            con.ConnectionString = connection_string
            con.Open()
            cmd.CommandText = "SELECT deposit3Enable FROM visitInfo WHERE id='" & Visit & "'"
            dr = cmd.ExecuteReader

            While dr.Read()
                Deposit3Enable = dr("deposit3Enable").ToString
            End While

            cmd.Dispose()
            con.Close()

        Catch
            Deposit3Enable = "Error"
        End Try

        Return Deposit3Enable
    End Function



    Protected Sub acctEnter_btn_Click(sender As Object, e As EventArgs) Handles acctEnter_btn.Click
        EnterAccount()
    End Sub

    Protected Sub submit_btn_Click(sender As Object, e As EventArgs) Handles submit_btn.Click
        Submit()
    End Sub

    Protected Sub back_btn_Click(sender As Object, e As EventArgs) Handles back_btn.Click
        Back()
    End Sub

End Class