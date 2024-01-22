Imports System.Data.SqlClient
Imports System.Windows.Forms
Public Class Print_Sales
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
        Dim StudentData As New Class_StudentData
        Dim StudentInfo = StudentData.StudentLookup(Visit, empID)
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
        Dim item1 As Double = 0.00
        Dim item2 As Double = 0.00
        Dim item3 As Double = 0.00
        Dim item4 As Double = 0.00
        Dim saleAmount As Double = 0.00
        Dim saleAmount2 As Double = 0.00
        Dim saleAmount3 As Double = 0.00
        Dim saleAmount4 As Double = 0.00
        Dim totalTransactions As Double = 0.00
        Dim remainingBalance As Double = 0.00
        Dim businessID As String = Request.QueryString("c")
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

        'Get transaction information
        Try
            'Get net deposit and savings
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

                If dr("savings").ToString = Nothing Then
                    savings = 0.00
                Else
                    savings = dr("savings")
                End If

            End While

            'Get transaction total
            dr.Close()
            netDeposit = netDeposit1 + netDeposit2 + netDeposit3 + netDeposit4
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "SELECT CASE WHEN SUM(saleamount + saleAmount2 + saleAmount3 + saleAmount4) IS NULL THEN '0.00' ELSE SUM(saleamount + saleAmount2 + saleAmount3 + saleAmount4) END as Transactions FROM transactions WHERE visitdate ='" & visitDate_hf.Value & "' AND employeeNumber ='" & empID & "'"
            dr = cmd.ExecuteReader
            While dr.Read
                totalTransactions = dr("Transactions")
            End While

            'Get the latest sales transaction from that customer
            dr.Close()
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "SELECT TOP 1 item1, item2, item3, item4 FROM transactions WHERE visitdate ='" & visitDate_hf.Value & "' AND employeeNumber ='" & empID & "' AND business=17 ORDER BY item1 DESC"
            dr = cmd.ExecuteReader
            While dr.Read

                If dr("item1").ToString = Nothing Then
                    item1 = 0.00
                Else
                    item1 = dr("item1")
                End If

                If dr("item2").ToString = Nothing Then
                    item2 = 0.00
                Else
                    item2 = dr("item2")
                End If

                If dr("item3").ToString = Nothing Then
                    item3 = 0.00
                Else
                    item3 = dr("item3")
                End If

                If dr("item4").ToString = Nothing Then
                    item4 = 0.00
                Else
                    item4 = dr("item4")
                End If
            End While

        Catch
            cmd.Dispose()
            con.Close()
            dr.Close()
        End Try

        'Get first and last name and account number
        Try
            name_lbl.Text = StudentInfo.FirstName & " " & StudentInfo.LastName
            account_number_lbl.Text = StudentInfo.AccountNumber
            'Business_name_lbl.Text = studentInfo.Tables(0).Rows(0)("businessName")

        Catch
            cmd.Dispose()
            con.Close()
        End Try

        cmd.Dispose()
        con.Close()
        dr.Close()
        Dim itemTotal As Double = 0.00
        itemTotal = item1 + item2 + item3 + item4
        Dim saleAmountTotal As Double = 0.00
        saleAmountTotal = saleAmount + saleAmount2 + saleAmount3 + saleAmount4
        Dim newBalance As Double

        'Get remaining balance for customer
        netDeposit = netDeposit1 + netDeposit2 + netDeposit3 + netDeposit4
        remainingBalance = netDeposit - totalTransactions - savings + itemTotal
        balance_lbl.Text = remainingBalance.ToString("C")
        newBalance = remainingBalance - itemTotal
        newBalance_lbl.Text = newBalance.ToString("C")
        item1_lbl.Text = item1.ToString("C")
        item2_lbl.Text = item2.ToString("C")
        item3_lbl.Text = item3.ToString("C")
        item4_lbl.Text = item4.ToString("C")
        saleTotal_lbl.Text = itemTotal.ToString("C")
        date_lbl.Text = DateTime.Now

        SqlConnection.ClearAllPools()
    End Sub

End Class