Imports System.Data.SqlClient
Public Class Business_profit_report
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim DBConnection As New DatabaseConection
    Dim dr As SqlDataReader
    Dim Visits As New Class_VisitData
    Dim Schools As New Class_SchoolData
    Dim Businesses As New Class_BusinessData
    Dim SH As New Class_SchoolHeader
    Dim VisitID As Integer = Visits.GetVisitID

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Checks if the user is logged in and if not it redirects to the login page
        If Session("LoggedIn") <> "1" Then
            Response.Redirect("../../default.aspx")
        End If

        If Not (IsPostBack) Then

            'Populating school header
            headerSchoolName_lbl.Text = SH.GetSchoolHeader()

        End If
    End Sub

    Sub LoadData()
        Dim VisitDate As String = visitDate_tb.Text
        Dim VIDOfDate As String = Visits.GetVisitIDFromDate(VisitDate)

        'Reveal print button
        print_btn.Visible = True

        'Get school name(s)
        Try
            Schools_lbl.Text = Schools.GetSchoolsString(VisitDate)
        Catch
            error_lbl.Text = "Error in loaddata(). Could not retrieve school name(s)."
            Exit Sub
        End Try

        'Get profit table
        Try
            Businesses.GetBusinessProfitsTable(VIDOfDate, businessProfit_dgv)
        Catch
            error_lbl.Text = "Error in loaddata(). Could not retrieve profits."
        End Try

    End Sub

    Protected Sub print_btn_Click(sender As Object, e As EventArgs) Handles print_btn.Click
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "PrintBadges", "PrintBadges();", True)
    End Sub

    Protected Sub visitDate_tb_TextChanged(sender As Object, e As EventArgs) Handles visitDate_tb.TextChanged
        If visitDate_tb.Text <> Nothing Then
            LoadData()
        End If
    End Sub
End Class