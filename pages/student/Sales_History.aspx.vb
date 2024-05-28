Imports System.Data.SqlClient
Public Class Sales_History
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim DBConnection As New DatabaseConection
    Dim dr As SqlDataReader
    Dim logoRoot As String = "~/media/Logos/"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not (IsPostBack) Then
            Dim businessID As String = Request.QueryString("b")
            Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
            Dim con As New SqlConnection
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            If businessID = 17 Then
                F1URL.Text = "Online Banking"
                F1URL.NavigateUrl = "Online_Banking.aspx?B=17"
            Else
                F1URL.NavigateUrl = "sales_system.aspx?B=" & businessID
            End If

            Dim businessSQL As String = "SELECT logoPath, businessColor, businessName FROM businessinfo WHERE ID='" & businessID & "'"
            'Label_date_time.Text = DateAndTime.Now.ToString("G")
            If businessID = Nothing Then
                businessID = 0
            End If

            'Calls class to pull visitDate
            Dim VisitID As New Class_VisitData
            Dim Visit As Integer = VisitID.GetVisitID
            If Visit <> 0 Then
                visitdate_hf.Value = Visit
            End If

            'Get logo, business name and color
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
                    Me.Title = dr(2).ToString

                End While

                cmd.Dispose()
                con.Close()

            Catch
                error_lbl.Text = "Error in PageLoad. Could not find image path and/or bColor."
                Exit Sub
            Finally
                cmd.Dispose()
                con.Close()

            End Try

            cmd.Dispose()
            con.Close()


        End If

        Loaddata()

    End Sub


    Sub Loaddata()

        Dim visitID As Integer = visitdate_hf.Value
        Dim businessID As String = Request.QueryString("b")
        Dim con As New SqlConnection
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        con.ConnectionString = connection_string
        con.Open()
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        'Get transaction information for business
        Try

            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "  SELECT employeenumber, business, transactionTimeStamp, transactionTimeStamp2, transactionTimeStamp3, transactionTimeStamp4, CONCAT('$',saleamount) AS saleamount, CONCAT('$',saleAmount2) AS saleamount2, CONCAT('$',saleAmount3) AS saleamount3, CONCAT('$',saleAmount4) AS saleamount4, visitdate FROM transactions 
            WHERE visitdate ='" & visitID & "' AND business='" & businessID & "' ORDER BY transactionTimeStamp"

            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)
            Transactions_dgv.DataSource = dt
            Transactions_dgv.DataBind()
            da.Dispose()
            cmd.Dispose()
            con.Close()

        Catch   'Catch happens if the employee doesnt have any transations on record
            error_lbl.Text = "There was an error getting account information, please inform a staff member."
            cmd.Dispose()
            con.Close()
        End Try

        'Get sales total
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd.CommandText = " SELECT SUM(saleamount + saleAmount2 + saleAmount3 + saleAmount4) as saleTotal 
                                 FROM transactions 
                                 WHERE visitdate ='" & visitdate_hf.Value & "' AND business='" & businessID & "'"
            cmd.Connection = con
            dr = cmd.ExecuteReader

            While dr.Read()
                totalSales_lbl.Text = "Total Sales: " & dr("saleTotal").ToString
            End While

            cmd.Dispose()
            con.Close()
        Catch
            error_lbl.Text = "Error in loaddata(). Cannot retrieve total sales."
            Exit Sub
        End Try

        cmd.Dispose()
        con.Close()
    End Sub

End Class