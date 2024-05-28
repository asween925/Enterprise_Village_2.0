Imports System.Data.SqlClient
Public Class Business_sales_report
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim DBConnection As New DatabaseConection
    Dim dr As SqlDataReader
    Dim logoRoot As String = "~/media/Logos/"
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
    Dim BusinessData As New Class_BusinessData
    Dim VisitData As New Class_VisitData
    Dim VisitID As Integer = VisitData.GetVisitID

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Checks if the user is logged in and if not it redirects to the login page
        If Session("LoggedIn") <> "1" Then
            Response.Redirect("../../default.aspx")
        End If

        If Not (IsPostBack) Then

            If VisitID <> 0 Then
                visitdate_hf.Value = VisitID
            End If

            'Get business names
            Try
                BusinessData.LoadBusinessNamesDDL(business_ddl)
            Catch
                error_lbl.Text = "Error in Page Load. Cannot load business names."
                Exit Sub
            End Try

            'Populating school header
            Dim header As New Class_SchoolHeader
            headerSchoolName_lbl.Text = header.GetSchoolHeader()
        End If

    End Sub

    Private Sub business_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles business_ddl.SelectedIndexChanged
        If business_ddl.SelectedIndex <> 0 Then
            totalSales_p.Visible = True
            total_sales_lbl.Visible = True
            LoadData()
        Else
            totalSales_p.Visible = False
            total_sales_lbl.Visible = False
        End If
    End Sub

    Sub LoadData()
        Dim Sales As Double
        Dim VisitDate As String = visitDate_tb.Text
        Dim VisitID As String
        Dim BusinessID As String
        Dim BusinessName As String = business_ddl.SelectedValue

        'Clear sales / error label
        total_sales_lbl.Text = ""
        error_lbl.Text = ""

        'Get visitID from visit date
        Try
            VisitID = VisitData.GetVisitIDFromDate(VisitDate)
        Catch
            error_lbl.Text = "Error in loaddata(). Could not find visit ID."
            Exit Sub
        End Try

        'Get business ID
        Try
            BusinessID = BusinessData.GetBusinessID(BusinessName)
        Catch
            error_lbl.Text = "Error in loaddata(). Could not find business ID."
            Exit Sub
        End Try

        'Gte business sales
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "SELECT CONCAT (s.firstname, ' ',s.lastName) as studentname, t.saleAmount, t.business, s.visit, t.visitdate, b.businessName, s.employeenumber
                , t.transactionTimeStamp, t.saleAmount2, t.saleAmount3, t.saleAmount4, t.transactionTimeStamp2, t.transactionTimeStamp3, t.transactionTimeStamp4
                FROM studentInfo s
                INNER JOIN transactions t
                ON t.employeeNumber = s.employeeNumber
                inner JOIN businessinfo b
                ON t.business = b.ID
                WHERE t.visitdate ='" & VisitID & "' AND businessName='" & BusinessName & "' AND s.visit='" & VisitID & "'"

            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)
            businessSales_dgv.DataSource = dt
            businessSales_dgv.DataBind()

            con.Close()
            cmd.Dispose()

        Catch   'Catch happens if the employee doesnt have any transations on record
            error_lbl.Text = "No transactions for selected business."
            Exit Sub
        End Try

        'get total sales
        Try
            con.Open()
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "SELECT SUM(saleamount + saleAmount2 + saleAmount3 + saleAmount4) as saleTotal FROM transactions WHERE visitdate ='" & VisitID & "' AND business='" & BusinessID & "'"
            dr = cmd.ExecuteReader

            While dr.Read
                If dr("saleTotal").ToString = Nothing Then
                    sales = 0.00
                Else
                    sales = dr("saleTotal").ToString
                End If
            End While

            total_sales_lbl.Text = sales.ToString("C")

            cmd.Dispose()
            con.Close()
        Catch
            error_lbl.Text = "Error in loaddata(). Could not find sale amount"
            Exit Sub
            cmd.Dispose()
            con.Close()
        End Try

        cmd.Dispose()
        con.Close()

    End Sub

    Protected Sub print_btn_Click(sender As Object, e As EventArgs) Handles print_btn.Click
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "PrintBadges", "PrintBadges();", True)
    End Sub

    Protected Sub visitDate_tb_TextChanged(sender As Object, e As EventArgs) Handles visitDate_tb.TextChanged
        If visitDate_tb.Text <> Nothing Then
            business_ddl.SelectedIndex = 0
            selectBusiness_p.Visible = True
            business_ddl.Visible = True
        End If
    End Sub
End Class