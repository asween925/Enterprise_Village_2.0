Imports System.Data.SqlClient

Public Class _Default
    Inherits System.Web.UI.Page
    Dim DBConnection As New DatabaseConection
    Dim dr As SqlDataReader
    Dim logoRoot As String = "~/media/Logos/"
    Dim URLRoot As String = "~/Sales_System.aspx?b="
    Dim URLRoot2 As String = "~/Online_Banking.aspx?b="
    Dim URLRoot3 As String = "~/Check_Writing_System.aspx?b="
    Dim URLRoot4 As String = "~/Operating_Check_Writing_System.aspx?b="
    Dim btotal As String = Nothing
    Dim bcount As Integer = 0
	Dim objectName As String = Nothing
	Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
	Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
	Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
	Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim Visits As New Class_VisitData
    Dim SH As New Class_SchoolHeader
    Dim VisitID As Integer = Visits.GetVisitID

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Redirect to log in page if logged out
        If Session("LoggedIn") <> "1" Then
            Response.Redirect("../default.aspx")
        End If

        If Not (IsPostBack) Then

            'Populating school header
            headerSchoolName_lbl.Text = SH.GetSchoolHeader()

            'Load business logos

        End If

    End Sub



End Class