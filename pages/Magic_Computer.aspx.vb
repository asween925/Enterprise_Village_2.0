Imports System.Data.SqlClient

Public Class Magic_Computer
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim DBConnection As New DatabaseConection
    Dim dr As SqlDataReader
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
    Dim StudentData As New Class_StudentData
    Dim TransactionData As New Class_TransactionData
    Dim VisitID As New Class_VisitData
    Dim Visit As Integer = VisitID.GetVisitID

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim savingsCheck As String = "SELECT savings FROM studentInfo WHERE visitID='" & visitdate_hf.Value & "'"
        Dim savings As String

        'Asks if the session is still active, if not, then it will redirect to the login screen
        If Session("LoggedIn") <> "1" Then
            Response.Redirect("../default.aspx")
        End If

        If Not (IsPostBack) Then

            'Focus on textbox
            accountNumber_tb.Focus()

            'Check if visit date has been created
            If Visit <> 0 Then
                visitdate_hf.Value = Visit
            Else
                error_lbl.Text = "No visit date created. Please create one for today on Create a Visit."
                accountNumber_tb.Enabled = False
                Enter_btn.Enabled = False
                directDeposit_btn.Enabled = False
                'deposit1Update_btn.Enabled = False
                'deposit2Update_btn.Enabled = False
                'deposit3Update_btn.Enabled = False
                'deposit4Update_btn.Enabled = False
            End If

            'Check if deposit 2 and 3 are enabled / disabled
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.CommandText = "SELECT deposit3Enable FROM visitInfo WHERE id = '" & visitdate_hf.Value & "'"
                cmd.Connection = con
                dr = cmd.ExecuteReader

                While dr.Read()
                    If dr("deposit3Enable").ToString = "True" Then
                        deposit3Enable_btn.Text = "Disable Deposit #3"
                        directDeposit_btn.Text = "Remove Direct Deposit (Deposit #2)"
                    Else
                        deposit3Enable_btn.Text = "Enable Deposit #3"
                        directDeposit_btn.Text = "Initiate Direct Deposit (Deposit #2)"
                    End If
                End While

                cmd.Dispose()
                con.Close()
            Catch
                error_lbl.Text = "Error Page Load() Cannot check if deposit 3 is enabled."
                Exit Sub
            End Try

            'Populating student name ddl
            Try
                StudentData.LoadStudentNameWithNumDDL(studentName_ddl, Visit)
            Catch
                error_lbl.Text = "Error in populating student DDL."
                Exit Sub
            End Try

            'Load hidden table for students with negative balance
            Try
                businessProfit_dgv.DataSource = StudentData.LoadTransactionsWithNegativeBalanceTable(Visit)
                businessProfit_dgv.DataBind()

                If businessProfit_dgv.Rows.Count <> 0 Then
                    error_lbl.Text = "One or more students have a negative balance! Go to 'Negative Balance Report' under 'Reports' to find the student, then correct it in the Magic Computer."
                End If

            Catch
                error_lbl.Text = "Error in loaddata(). Could not retrieve negative balance info."
                Exit Sub
            End Try

            'Populating school header
            Dim header As New Class_SchoolHeader
            headerSchoolName_lbl.Text = header.GetSchoolHeader()
        End If

    End Sub

    Sub Enter()
        If accountNumber_tb.Text.Length = 0 Then
            error_lbl.Text = "No account number entered."
            accountNumber_tb.Focus()
        ElseIf IsNumeric(accountNumber_tb.Text) Then
            If accountNumber_tb.Text > 235 Or accountNumber_tb.Text < 1 Then
                error_lbl.Text = "Please enter a number between 1 and 235"
                accountNumber_tb.Focus()
            Else
                error_lbl.Text = " "
                error_lbl.Text = ""
                empnum_hf.Value = accountNumber_tb.Text
                studentName_ddl.SelectedIndex = 0
                LoadData()
            End If
        Else
            error_lbl.Text = "Please enter a number."
            accountNumber_tb.Focus()
        End If
        'if statement here to check if the number entered was inputed in the database

    End Sub

    Sub DirectDeposit()
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim visitID As Integer = visitdate_hf.Value
        Dim timestamp As DateTime = DateTime.Now

        'Check button text
        If directDeposit_btn.Text = "Initiate Direct Deposit (Deposit #2)" Then

            'Transfer to savings
            Try

                'Salary tier 1 ($7.00)
                con.ConnectionString = connection_string
                con.Open()
                cmd.Connection = con
                cmd.CommandText = "UPDATE s SET s.initialDeposit2='7.00', s.netDeposit2='7.00', s.cbw2='0.00', s.tellerTimestamp2='" & DateTime.Now() & "' FROM studentInfo s INNER JOIN jobs j ON j.id = s.jobID WHERE j.jobSalary=1 AND s.visitID='" & visitID & "'"
                cmd.ExecuteNonQuery()
                con.Close()

                'Salary tier 2 ($6.50)
                con.ConnectionString = connection_string
                con.Open()
                cmd.Connection = con
                cmd.CommandText = "UPDATE s SET s.initialDeposit2='6.50', s.netDeposit2='6.50', s.cbw2='0.00', s.tellerTimestamp2='" & DateTime.Now() & "' FROM studentInfo s INNER JOIN jobs j ON j.id = s.jobID WHERE j.jobSalary=2 AND s.visitID='" & visitID & "'"
                cmd.ExecuteNonQuery()
                con.Close()

                'Salary tier 3 ($6.00)
                con.ConnectionString = connection_string
                con.Open()
                cmd.Connection = con
                cmd.CommandText = "UPDATE s SET s.initialDeposit2='6.00', s.netDeposit2='6.00', s.cbw2='0.00', s.tellerTimestamp2='" & DateTime.Now() & "' FROM studentInfo s INNER JOIN jobs j ON j.id = s.jobID WHERE j.jobSalary=3 AND s.visitID='" & visitID & "'"
                cmd.ExecuteNonQuery()
                con.Close()

                'Change button text
                directDeposit_btn.Text = "Remove Direct Deposit (Deposit #2)"

                'Refresh page
                Dim meta As New HtmlMeta()
                meta.HttpEquiv = "Refresh"
                meta.Content = "3;url=magic_computer.aspx"
                Me.Page.Controls.Add(meta)
                error_lbl.Text = "Direct deposit sucessful. Refreshing the page..."

            Catch
                error_lbl.Text = "Direct deposit failed. Please contact support."
                Exit Sub
            End Try

        ElseIf directDeposit_btn.Text = "Remove Direct Deposit (Deposit #2)" Then

            Try
                'Salary tier 3 ($6.00)
                con.ConnectionString = connection_string
                con.Open()
                cmd.Connection = con
                cmd.CommandText = "UPDATE studentInfo SET initialDeposit2='0.00', netDeposit2='0.00', cbw2='0.00' FROM studentInfo s WHERE visitID='" & visitID & "'"
                cmd.ExecuteNonQuery()
                con.Close()

                'Change button text
                directDeposit_btn.Text = "Initiate Direct Deposit (Deposit #2)"

                'Refresh page
                Dim meta As New HtmlMeta()
                meta.HttpEquiv = "Refresh"
                meta.Content = "3;url=magic_computer.aspx"
                Me.Page.Controls.Add(meta)
                error_lbl.Text = "Removal of direct deposit sucessful. Refreshing the page..."

            Catch
                error_lbl.Text = "Removing direct deposit failed. Please contact support."
                Exit Sub
            End Try

        End If

    End Sub

    Sub Deposit1()
        If Not IsNumeric(deposit1_tb.Text) Then
            error_lbl.Text = "Deposit amount entered is not a numerical value. Please clear out the number and enter it again."
            Exit Sub
        ElseIf Not IsNumeric(CBW1_tb.Text) Then
            error_lbl.Text = "Cash back amount entered is not a numerical value. Please clear out the number and enter it again."
            Exit Sub
        End If

        UpdateDeposit("initialDeposit1", deposit1_tb.Text, "cbw1", CBW1_tb.Text, "netDeposit1")
    End Sub

    Sub Deposit2()
        If Not IsNumeric(deposit2_tb.Text) Then
            error_lbl.Text = "Deposit amount entered is not a numerical value. Please clear out the number and enter it again."
            Exit Sub
        ElseIf Not IsNumeric(CBW2_tb.Text) Then
            error_lbl.Text = "Cash back amount entered is not a numerical value. Please clear out the number and enter it again."
            Exit Sub
        End If

        UpdateDeposit("initialDeposit2", deposit2_tb.Text, "cbw2", CBW2_tb.Text, "netDeposit2")
    End Sub

    Sub Deposit3()
        If Not IsNumeric(Deposit3_tb.Text) Then
            error_lbl.Text = "Deposit amount entered is not a numerical value. Please clear out the number and enter it again."
            Exit Sub
        ElseIf Not IsNumeric(CBW3_tb.Text) Then
            error_lbl.Text = "Cash back amount entered is not a numerical value. Please clear out the number and enter it again."
            Exit Sub
        End If

        UpdateDeposit("initialDeposit3", Deposit3_tb.Text, "cbw3", CBW3_tb.Text, "netDeposit3")
    End Sub

    Sub Deposit4()
        If Not IsNumeric(Deposit4_tb.Text) Then
            error_lbl.Text = "Deposit amount entered is not a numerical value. Please clear out the number and enter it again."
            Exit Sub
        ElseIf Not IsNumeric(CBW4_tb.Text) Then
            error_lbl.Text = "Cash back amount entered is not a numerical value. Please clear out the number and enter it again."
            Exit Sub
        End If

        UpdateDeposit("initialDeposit4", Deposit4_tb.Text, "cbw4", CBW4_tb.Text, "netDeposit4")
    End Sub

    Sub UpdateDeposit(ByVal depositNum As String, ByVal depositAmount As Decimal, ByVal cbwNum As String, ByVal cbwAmount As Decimal, ByVal netDepositNumber As String)
        Dim empID As Integer = empnum_hf.Value
        Dim visitID As Integer = visitdate_hf.Value
        Dim netDepositAmount As String
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand

        'Check if deposit amount entered is numeric
        If Not IsNumeric(depositAmount) Then
            error_lbl.Text = "Deposit amount entered is not a numerical value. Please clear out the number and enter it again."
            Exit Sub
        End If

        'Check if cash amount entered is numeric
        If Not IsNumeric(cbwAmount) Then
            error_lbl.Text = "Cash back amount entered is not a numerical value. Please clear out the number and enter it again."
            Exit Sub
        End If

        'Calculate netDeposit amount
        netDepositAmount = depositAmount - cbwAmount

        'If deposit amount is greater than 6 then fail
        If depositAmount > 7 Then
            error_lbl.Text = "Amount to be entered is not acceptable value."
            'Using below to prevent screen from reseting when error
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "Enter_account", "Enter_account();", True)
            Exit Sub
        End If

        'Added to try to control Cashback amounts
        If cbwAmount > 1 Then
            error_lbl.Text = "Cashback Amount not valid"
            Exit Sub
        ElseIf depositAmount > 7 Then
            error_lbl.Text = "Deposit Amount not valid." & " " & depositAmount
            Exit Sub
        End If

        'Used to change error text back if issue was corrected
        error_lbl.Text = ""

        'Update net deposit and cash back
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "UPDATE studentInfo SET " & depositNum & "=@deposit, " & cbwNum & "=@cbw, " & netDepositNumber & "=@netDeposit WHERE visitID ='" & visitID & "' AND accountNumber ='" & empID & "'"

            cmd.Parameters.Add("@netDeposit", SqlDbType.Decimal).Value = netDepositAmount
            cmd.Parameters.Add("@deposit", SqlDbType.Decimal).Value = depositAmount
            cmd.Parameters.Add("@cbw", SqlDbType.Decimal).Value = cbwAmount

            cmd.ExecuteNonQuery()
            con.Close()
        Catch
            error_lbl.Text = "Error in UpdateDeposit(). Error with updating deposit information."
            Exit Sub
        End Try
        LoadData()

    End Sub

    Sub UpdateSavings()
        Dim empID As Integer = empnum_hf.Value
        Dim visitID As Integer = visitdate_hf.Value
        Dim savings As String = savings_tb.Text
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand

        'Check if deposit amount entered is numeric
        If Not IsNumeric(savings) Then
            error_lbl.Text = "Savings amount entered is not a numerical value. Please clear out the number and enter it again."
            Exit Sub
        End If

        'Used to change error text back if issue was corrected
        error_lbl.Text = ""

        'Update net deposit and cash back
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "UPDATE studentInfo SET savings=@savings WHERE visitID ='" & visitID & "' AND accountNumber ='" & empID & "'"

            cmd.Parameters.Add("@savings", SqlDbType.Decimal).Value = savings

            cmd.ExecuteNonQuery()
            con.Close()
        Catch
            error_lbl.Text = "Error in UpdateSavings(). Error with updating savings information."
            Exit Sub
        End Try
        LoadData()
    End Sub

    Sub SplitEmpNumber()
        If studentName_ddl.SelectedIndex <> 0 Then
            error_lbl.Text = ""
            error_lbl.Text = ""
            accountNumber_tb.Text = ""
            Dim test() As String = studentName_ddl.SelectedValue.Split(".")
            empnum_hf.Value = test(0)
            LoadData()
        End If
    End Sub

    Sub Deposit3Enable()
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String = ""

        'Check if button is enabled or disabled
        If deposit3Enable_btn.Text = "Enable Deposit #3" Then
            sql = "UPDATE visitInfo
                                SET deposit3Enable = 1
                                WHERE id='" & visitdate_hf.Value & "'"

            'Update deposit3Enabled
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.Connection = con
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
                con.Close()

                deposit3Enable_btn.Text = "Disable Deposit #3"
                error_lbl.Text = "Deposit #3 is now Enabled."

            Catch
                error_lbl.Text = "deposit3Enable failed."
                Exit Sub
            End Try

        ElseIf deposit3Enable_btn.Text = "Disable Deposit #3" Then
            sql = "UPDATE visitInfo
                                SET deposit3Enable = 0
                                WHERE id='" & visitdate_hf.Value & "'"

            'Update deposit3Enabled
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.Connection = con
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
                con.Close()

                deposit3Enable_btn.Text = "Enable Deposit #3"
                error_lbl.Text = "Deposit #3 is now Disabled."

            Catch
                error_lbl.Text = "deposit3Enable failed."
                Exit Sub
            End Try

        End If
    End Sub

    Sub LoadData()
        Dim InitialDeposit1 As Double
        Dim InitialDeposit2 As Double
        Dim InitialDeposit3 As Double
        Dim InitialDeposit4 As Double
        Dim InitialDepositTotal As Double
        Dim NetDeposit1 As String
        Dim NetDeposit2 As Double
        Dim NetDeposit3 As Double
        Dim NetDeposit4 As Double
        Dim NetDepositTotal As Double
        Dim CBW1 As Double
        Dim CBW2 As Double
        Dim CBW3 As Double
        Dim CBW4 As Double
        Dim CBWTotal As Double
        Dim Savings As Double
        Dim TotalTransactions As Double
        Dim RemainingBalance As Double
        Dim StudentName As String
        Dim AccountNumber As String
        Dim BusinessID As String = Request.QueryString("b")
        Dim Timestamp As DateTime = DateTime.Now
        Dim TimestampSTR As String = Timestamp.ToString("yyyy-MM-dd HH:mm:ss")
        Dim EmpID As String = empnum_hf.Value
        Dim VisitID As String = visitdate_hf.Value
        Dim StudentInfo = StudentData.StudentLookup(Visit, EmpID)
        Dim DepositInfo = TransactionData.GetDepositInfo(Visit, EmpID)

        'Enable buttons
        accountNumber_tb.Enabled = True
        Enter_btn.Enabled = True
        directDeposit_btn.Enabled = True
        deposit1Update_btn.Enabled = True
        deposit2Update_btn.Enabled = True
        deposit3Update_btn.Enabled = True
        deposit4Update_btn.Enabled = True

        'Clear error label
        error_lbl.Text = ""

        'Dollar label visible
        dollar_lbl.Visible = True

        'Get student deposit, cash back, and savings info
        Try
            NetDeposit1 = DepositInfo.NetDeposit1
            NetDeposit2 = DepositInfo.NetDeposit2
            NetDeposit3 = DepositInfo.NetDeposit3
            NetDeposit4 = DepositInfo.NetDeposit4

            CBW1 = DepositInfo.CBW1
            CBW2 = DepositInfo.CBW2
            CBW3 = DepositInfo.CBW3
            CBW4 = DepositInfo.CBW4

            InitialDeposit1 = DepositInfo.InitialDeposit1
            InitialDeposit2 = DepositInfo.InitialDeposit2
            InitialDeposit3 = DepositInfo.InitialDeposit3
            InitialDeposit4 = DepositInfo.InitialDeposit4

            Savings = DepositInfo.Savings
        Catch
            error_lbl.Text = "Error in LoadData(). Cannot net deposit info from student."
            Exit Sub
        End Try

        'Get total transactions
        Try
            TotalTransactions = TransactionData.GetTotalTransactions(EmpID, VisitID)
        Catch
            error_lbl.Text = "Error in LoadData(). There was an error getting transaction information for account number."
            Exit Sub
        End Try

        'Get student name and employee number
        Try
            StudentName = StudentInfo.FirstName & " " & StudentInfo.LastName
            AccountNumber = StudentInfo.AccountNumber
        Catch
            error_lbl.Text = "Error in LoadData(). There was an error getting name information for account number, please inform a staff member."
            Exit Sub
        End Try

        'Fill transactions table
        Try
            Transactions_dgv.DataSource = TransactionData.LoadTransactionTimestampsTable(Visit, EmpID)
            Transactions_dgv.DataBind()
        Catch
            error_lbl.Text = "Error in LoadData(). Cannot load transaction table with timestamps."
            Exit Sub
        End Try

        'Get remaining balance for customer / total deposits, remaining balance, cash withdrawn
        Try
            InitialDepositTotal = InitialDeposit1 + InitialDeposit2 + InitialDeposit3 + InitialDeposit4
            NetDepositTotal = InitialDepositTotal - CBW1 - CBW2 - CBW3 - CBW4
            RemainingBalance = NetDepositTotal - TotalTransactions - Savings
            CBWTotal = CBW1 + CBW2 + CBW3 + CBW4
        Catch
            error_lbl.Text = "Error in loadData(). There was an error calculating account information, please inform IT."
            Exit Sub
        End Try

        'Assign labels and textboxes
        Savings_lbl.Text = Savings
        Total_deposit_lbl.Text = InitialDepositTotal.ToString("C")
        Total_purchases_lbl.Text = TotalTransactions.ToString("C")
        Balance_lbl.Text = RemainingBalance.ToString("C")
        Cwd_lbl.Text = CBWTotal.ToString("C")
        Employee_number_lbl.Text = AccountNumber
        Name_lbl.Text = StudentName

        deposit1_tb.Text = InitialDeposit1.ToString("F2")
        deposit2_tb.Text = InitialDeposit2.ToString("F2")
        Deposit3_tb.Text = InitialDeposit3.ToString("F2")
        Deposit4_tb.Text = InitialDeposit4.ToString("F2")
        savings_tb.Text = Savings.ToString("F2")
        Savings_lbl.Text = Savings.ToString("F2")
        CBW1_tb.Text = CBW1.ToString("F2")
        CBW2_tb.Text = CBW2.ToString("F2")
        CBW3_tb.Text = CBW3.ToString("F2")
        CBW4_tb.Text = CBW4.ToString("F2")

        'Success message
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "Enter_account", "Enter_account();", True)
    End Sub

    Private Sub Transations_dgv_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles Transactions_dgv.RowUpdating
        Dim row As GridViewRow = Transactions_dgv.Rows(e.RowIndex)                        'Code is used to enable the editing prodecure
        Dim ID As Integer = Convert.ToInt32(Transactions_dgv.DataKeys(e.RowIndex).Values(0)) 'Code is used to enable the editing procedure
        Dim transaction As String
        transaction = TryCast(Transactions_dgv.Rows(e.RowIndex).FindControl("debit_dgvtb"), TextBox).Text

        Dim empID As Integer = Employee_number_lbl.Text
        Dim visitID As Integer = visitdate_hf.Value


        Using con As New SqlConnection(connection_string)
            Using cmd As New SqlCommand("UPDATE Transactions SET saleAmount=@saleAmountUpdate WHERE visit ='" & visitID & "' AND employeeNumber ='" & empID & "' AND id = '" & ID & "'")

                cmd.Parameters.Add("@saleAmountUpdate", SqlDbType.Decimal).Value = transaction
                cmd.Connection = con
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using
        Transactions_dgv.EditIndex = -1
        LoadData()
    End Sub

    Private Sub Transactions_dgv_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles Transactions_dgv.RowEditing
        Transactions_dgv.EditIndex = e.NewEditIndex
        LoadData()
        'Javascript used because if not, the page resets to 1st screen
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "Enter_account", "Enter_account();", True)
    End Sub

    Private Sub Transactions_dgv_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles Transactions_dgv.RowCancelingEdit
        Transactions_dgv.EditIndex = -1
        LoadData()
    End Sub

    Private Sub Enter_btn_Click(sender As Object, e As EventArgs) Handles Enter_btn.Click
        Enter()
    End Sub

    Protected Sub directDeposit_btn_Click(sender As Object, e As EventArgs) Handles directDeposit_btn.Click
        DirectDeposit()
    End Sub

    Private Sub deposit1Update_btn_Click(sender As Object, e As EventArgs) Handles deposit1Update_btn.Click
        Deposit1()
    End Sub

    Private Sub deposit2Update_btn_Click(sender As Object, e As EventArgs) Handles deposit2Update_btn.Click
        Deposit2()
    End Sub

    Private Sub deposit3Update_btn_Click(sender As Object, e As EventArgs) Handles deposit3Update_btn.Click
        Deposit3()
    End Sub

    Private Sub deposit4Update_btn_Click(sender As Object, e As EventArgs) Handles deposit4Update_btn.Click
        Deposit4()
    End Sub

    Protected Sub studentName_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles studentName_ddl.SelectedIndexChanged
        SplitEmpNumber()
    End Sub

    Protected Sub deposit3Enable_btn_Click(sender As Object, e As EventArgs) Handles deposit3Enable_btn.Click
        Deposit3Enable()
    End Sub

    Protected Sub savingsUpdate_btn_Click(sender As Object, e As EventArgs) Handles savingsUpdate_btn.Click
        UpdateSavings()
    End Sub
End Class