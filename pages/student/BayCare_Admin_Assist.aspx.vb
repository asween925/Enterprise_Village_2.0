Imports System.Data.SqlClient

Public Class BayCare_Admin_Assist
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
    Dim BusinessData As New Class_BusinessData
    Dim StudentData As New Class_StudentData
    Dim VisitData As New Class_VisitData
    Dim TransactionData As New Class_TransactionData
    Dim VisitID As Integer = VisitData.GetVisitID
    Dim VisitDate As String = DateTime.Now.ToShortDateString()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Check if visit date has been created
        If Not (IsPostBack) Then
            If VisitID <> 0 Then
                visitdate_hf.Value = VisitID
            End If
        End If

        'Populate voucher businesses DDL
        BusinessData.LoadBusinessNamesDDL(voucherBusiness_ddl)

    End Sub

    Protected Sub vouchers_btn_Click(sender As Object, e As EventArgs) Handles vouchers_btn.Click
        'Switching to vouchers screen
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "BayCare_Admin_Switch_Vouchers", "BayCare_Admin_Switch_Vouchers();", True)
    End Sub

    Protected Sub voucherNext_btn_Click(sender As Object, e As EventArgs) Handles voucherNext_btn.Click

        'Clear textbox
        numVouchers_tb.Text = ""

        'Switching to vouchers screen
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "BayCare_Admin_Switch_Vouchers", "BayCare_Admin_Switch_Vouchers();", True)
    End Sub

    Protected Sub checkingIn_btn_Click(sender As Object, e As EventArgs) Handles checkingIn_btn.Click
        'Switching to check in screen
        BayCareAA_CheckIn_Page.Visible = True
        BayCareAA_Main_Page.Visible = False
        BusinessData.LoadBusinessNamesDDL(checkInBusiness_ddl)
    End Sub

    Protected Sub finalReport_btn_Click(sender As Object, e As EventArgs) Handles finalReport_btn.Click
        Try
            'Clear out table
            finalReport_dgv.DataSource = Nothing
            finalReport_dgv.DataBind()

            'Assign check ups to table
            con.ConnectionString = connection_string
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "SELECT id, checkupsPerformed, businessName FROM BayCareAdmin WHERE visitID = '" & VisitID & "' ORDER BY businessName ASC"

            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)

            finalReport_dgv.DataSource = dt
            finalReport_dgv.DataBind()
        Catch
            errorMain_lbl.Text = "Error in Final Report. Cannot get the total checkups performed for the day. Please find an Enterprise Village teacher."
            Exit Sub
        End Try

        'Switching to vouchers screen
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "BayCare_Admin_Switch_FinalReport", "BayCare_Admin_Switch_FinalReport();", True)
    End Sub

    Protected Sub checkIn_btn_Click(sender As Object, e As EventArgs) Handles checkIn_btn.Click
        Dim BusinessName As String = checkInBusiness_ddl.SelectedValue
        Dim SQLStatement As String

        'Check if business is already in the DB
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "SELECT visitDate, visitID, businessName FROM BayCareAdmin WHERE visitDate = '" & VisitDate & "' AND visitID = '" & VisitID & "' AND businessName = '" & BusinessName & "'"
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                SQLStatement = "UPDATE BayCareAdmin SET checkupsPerformed = checkupsPerformed + 1 WHERE visitID = '" & VisitID & "' AND businessName = '" & BusinessName & "'"
            Else
                SQLStatement = "INSERT INTO BayCareAdmin (visitID, checkupsPerformed, businessName) VALUES ('" & VisitID & "', '1', '" & BusinessName & "')"
            End If

            cmd.Dispose()
            con.Close()
        Catch
            errorMain_lbl.Text = "Error in CheckIn. Cannot find business check in date. Please find an Enterprise Village teacher."
            Exit Sub
        End Try

        cmd.Dispose()
        con.Close()

        'Add voucher number to DB
        con.Open()
        cmd.Connection = con
        cmd.CommandText = SQLStatement
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        con.Close()

        'Set DDL back to 0 index
        checkInBusiness_ddl.SelectedIndex = checkInBusiness_ddl.Items.IndexOf(checkInBusiness_ddl.Items.FindByValue(0))
    End Sub

    Protected Sub checkInReturn_btn_Click(sender As Object, e As EventArgs) Handles checkInReturn_btn.Click
        Response.Redirect(".\BayCare_Admin_Assist.aspx")
    End Sub
End Class