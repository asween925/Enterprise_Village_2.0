Imports System.Data.SqlClient
Public Class Negative_balance_report
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim DBConnection As New DatabaseConection
    Dim dr As SqlDataReader

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("LoggedIn") <> "1" Then
            Response.Redirect("../../default.aspx")
        End If

        If Not (IsPostBack) Then
            Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
            Dim con As New SqlConnection
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            Dim VisitID As New Class_VisitData
            Dim Visit As Integer = VisitID.GetVisitID
            If Visit <> 0 Then
                visitdate_hf.Value = Visit
                LoadData()
            Else
                error_lbl.Text = "No visit date, please go to 'Database Creator' on the 'Tools / Reports' page and create a new school visit date."
            End If

            'Populating school header
            Dim header As New Class_SchoolHeader
            headerSchoolName_lbl.Text = header.GetSchoolHeader()

        End If
    End Sub

    Sub LoadData()
        Dim visitID As Integer = visitdate_hf.Value
        Dim con As New SqlConnection
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        con.ConnectionString = connection_string
        con.Open()
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader


        Try

            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "IF (OBJECT_ID('tempdb..#netdeposits') IS NOT NULL) DROP TABLE #netdeposits
       -- Total Deposits
       SELECT 
              s.accountNumber
              ,s.firstName
              ,s.lastName
              ,SUM(ISNULL(s.netdeposit1,0) + ISNULL(s.netdeposit2,0) + ISNULL(s.netdeposit3,0) + ISNULL(s.netdeposit4,0) - ISNULL(s.savings,0)) totalDeposits
       INTO #netdeposits
       FROM dbo.studentInfo s
       WHERE s.visitID = '" & visitID & "'
       GROUP BY s.accountNumber, s.firstName, s.lastName

       -- Total Purchases and with JOIN to #netdeposits temp table
       SELECT 
               t.accountNumber, CONCAT (MAX(firstname), ' ',MAX(lastName)) as studentname
              ,MAX(s.totalDeposits) TotalDeposits
              ,SUM(ISNULL(saleamount,0)) as TotalPurchases
              ,MAX(s.totalDeposits) - sum(ISNULL(saleamount,0)) as Balance
       FROM transactions t
       INNER JOIN #netdeposits s ON t.accountNumber = s.accountNumber
       WHERE t.visitID = '" & visitID & "'
       GROUP BY t.accountNumber
       HAVING MAX(s.totalDeposits) - sum(ISNULL(saleamount,0)) < 0
       ORDER BY Balance"


            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)
            businessProfit_dgv.DataSource = dt
            businessProfit_dgv.DataBind()

            If businessProfit_dgv.Rows.Count = 0 Then
                error_lbl.Text = "No students have a negative balance!"
            Else
                error_lbl.Text = ""
            End If

        Catch
            error_lbl.Text = "Error in loaddata(). Could not retrieve negative balance info."
            cmd.Dispose()
            con.Close()
        End Try

        cmd.Dispose()
        con.Close()

    End Sub

End Class