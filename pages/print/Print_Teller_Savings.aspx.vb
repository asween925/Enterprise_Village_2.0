Imports System.Data.SqlClient
Imports System.Windows.Forms
Public Class Print_Teller_Savings
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
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim empID As String = Request.QueryString("b")
        Dim savingsAmountIndex As String = Request.QueryString("b2")
        Dim StudentData As New Class_StudentData
        Dim StudentInfo = StudentData.StudentLookup(Visit, empID)

        'Get student info
        Try
            name_lbl.Text = StudentInfo.FirstName & " " & StudentInfo.LastName
            account_number_lbl.Text = StudentInfo.AccountNumber

        Catch
            cmd.Dispose()
            con.Close()
        End Try

        'Get savings amount
        savings_ddl.SelectedIndex = savingsAmountIndex
        savings_lbl.Text = savings_ddl.SelectedValue

        'Get current date and time
        date_lbl.Text = DateTime.Now

        cmd.Dispose()
        con.Close()

    End Sub

End Class