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
	Dim VisitID As New Class_VisitData
	Dim Visit As Integer = VisitID.GetVisitID

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("LoggedIn") <> "1" Then
            Response.Redirect("../default.aspx")
        End If

        If Not (IsPostBack) Then
            Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
            Dim con As New SqlConnection
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            If Visit <> 0 Then
                visitdate_hf.Value = Visit
            End If


            'Populating school header
            Dim header As New Class_SchoolHeader
            headerSchoolName_lbl.Text = header.GetSchoolHeader()
        End If

    End Sub

End Class