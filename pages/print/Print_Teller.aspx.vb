Imports System.Data.SqlClient
Imports System.Windows.Forms
Public Class Print_Teller
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim DBConnection As New DatabaseConection
    Dim dr As SqlDataReader
    Dim logoRoot As String = "~/media/Logos/"
    Dim decTotal As Decimal
    Dim VisitID As New Class_VisitData
    Dim Visit As Integer = VisitID.GetVisitID

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (IsPostBack) Then


            If Visit <> 0 Then
                visitDate_hf.Value = Visit
            End If

        End If
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim empID As String = Request.QueryString("b")
        Dim checkAmountIndex As String = Request.QueryString("b2")
        Dim cashIndex As String = Request.QueryString("b3")
        Dim StudentData As New Class_StudentData
        Dim studentInfo = StudentData.StudentLookup(Visit, empID)
        con.ConnectionString = connection_string
        con.Open()
        Dim netDeposit1 As Double = 0.00
        Dim netDeposit2 As Double = 0.00
        Dim netDeposit3 As Double = 0.00
        Dim netDeposit4 As Double = 0.00
        Dim netDeposit As Double = 0.00
        Dim cbw1 As Double = 0.00
        Dim cbw2 As Double = 0.00
        Dim cbw3 As Double = 0.00
        Dim cbw4 As Double = 0.00
        Dim totalTransactions As Double = 0.00
        Dim remainingBalance As Double = 0.00
        Dim businessID As String = Request.QueryString("b")
        Dim timestamp As DateTime = DateTime.Now
        Dim timestampSTR As String = timestamp.ToString("yyyy-MM-dd HH:mm:ss")
        Dim savings As Double = 0.00
        cmd.Connection = con
        Dim sql As String = "SELECT 
            CASE WHEN netDeposit1 IS NULL THEN 0 ELSE 1 END as ND1, 
            CASE WHEN netDeposit2 IS NULL THEN 0 ELSE 1 END as ND2, 
            CASE WHEN netDeposit3 IS NULL THEN 0 ELSE 1 END as ND3, 
            CASE WHEN netDeposit4 IS NULL THEN 0 ELSE 1 END as ND4 
            FROM studentInfo WHERE visit='" & visitDate_hf.Value & "' AND employeeNumber ='" & empID & "'"

        Check_amount_ddl.SelectedIndex = checkAmountIndex
        cash_recieved_ddl.SelectedIndex = cashIndex



        Try
            cmd.CommandText = "SELECT netDeposit1, netDeposit2, netDeposit3, netDeposit4, cbw1, cbw2, cbw3, cbw4, savings FROM studentInfo WHERE visit='" & visitDate_hf.Value & "' AND employeeNumber ='" & empID & "'"
            dr = cmd.ExecuteReader
            While dr.Read()


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
                If dr("cbw1").ToString = Nothing Then
                    cbw1 = 0.00
                Else
                    cbw1 = dr("cbw1")
                End If
                If dr("cbw2").ToString = Nothing Then
                    cbw2 = 0.00
                Else
                    cbw2 = dr("cbw2")
                End If
                If dr("cbw3").ToString = Nothing Then
                    cbw3 = 0.00
                Else
                    cbw3 = dr("cbw3")
                End If


                If dr("savings").ToString = Nothing Then
                    savings = 0.00
                Else
                    savings = dr("savings")
                End If
            End While

            deposit1_lbl.Text = netDeposit1.ToString("C")
            deposit2_lbl.Text = netDeposit2.ToString("C")
            deposit3_lbl.Text = netDeposit3.ToString("C")
            deposit4_lbl.Text = netDeposit4.ToString("C")
            savings_lbl.Text = savings.ToString("C")
            dr.Close()
            netDeposit = netDeposit1 + netDeposit2 + netDeposit3 + netDeposit4
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "SELECT SUM(saleamount + saleAmount2 + saleAmount3 + saleAmount4) as Transactions FROM transactions WHERE visitDate ='" & visitDate_hf.Value & "' AND employeeNumber ='" & empID & "'"
            dr = cmd.ExecuteReader
            While dr.Read
                If dr("transactions").ToString = Nothing Then
                    totalTransactions = 0.00
                Else
                    totalTransactions = dr("Transactions")
                End If

            End While

        Catch
            cmd.Dispose()
            con.Close()

        End Try

        Try
            name_lbl.Text = studentInfo.FirstName & " " & studentInfo.LastName
            account_number_lbl.Text = studentInfo.AccountNumber
            'Business_name_lbl.Text = studentInfo.Tables(0).Rows(0)("businessName")

        Catch
            cmd.Dispose()
            con.Close()
        End Try

        cmd.Dispose()
        con.Close()

        'Get remaining balance for customer
        netDeposit = netDeposit1 + netDeposit2 + netDeposit3 + netDeposit4
        remainingBalance = netDeposit - totalTransactions - savings
        newBalance_lbl.Text = remainingBalance.ToString("C")
        checkAmount_lbl.Text = Check_amount_ddl.SelectedValue
        cash_lbl.Text = cash_recieved_ddl.SelectedValue
        Dim currentNet As Double = checkAmount_lbl.Text - cash_lbl.Text
        netDeposit_lbl.Text = currentNet.ToString("C")
        Dim previousBalance As Double = newBalance_lbl.Text - netDeposit_lbl.Text
        balance_lbl.Text = previousBalance.ToString("C")
        date_lbl.Text = DateTime.Now
    End Sub

End Class