Imports System.IO
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class Changelog
	Inherits System.Web.UI.Page
	Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
	Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
	Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
	Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
	Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
	Dim VisitID As New Class_VisitData
	Dim Visit As Integer = VisitID.GetVisitID

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
		Dim con As New SqlConnection
		Dim cmd As New SqlCommand

		If Session("LoggedIn") <> "1" Then
			Response.Redirect(".\default.aspx")
		End If

		If Not (IsPostBack) Then

			'Assign current visit ID to hidden field
			If Visit <> 0 Then
				currentVisitID_hf.Value = Visit
			End If

			'Populating school header
			Dim header As New Class_SchoolHeader
			headerSchoolName_lbl.Text = header.GetSchoolHeader()
		End If
	End Sub

	Sub RevealDiv(DivID As HtmlGenericControl)
		If DivID.Visible = False Then
			DivID.Visible = True
		ElseIf DivID.Visible = True Then
			DivID.Visible = False
		End If
	End Sub

	Protected Sub v2108_btn_Click(sender As Object, e As EventArgs) Handles v2108_btn.Click
		RevealDiv(v2108_div)
	End Sub

	Protected Sub v2109_btn_Click(sender As Object, e As EventArgs) Handles v2109_btn.Click
		RevealDiv(v2109_div)
	End Sub

	Protected Sub v2110_btn_Click(sender As Object, e As EventArgs) Handles v2110_btn.Click
		RevealDiv(v2110_div)
	End Sub

	Protected Sub v2111_btn_Click(sender As Object, e As EventArgs) Handles v2111_btn.Click
		RevealDiv(v2111_div)
	End Sub

	Protected Sub v2112_btn_Click(sender As Object, e As EventArgs) Handles v2112_btn.Click
		RevealDiv(v2112_div)
	End Sub

	Protected Sub v2113_Click(sender As Object, e As EventArgs) Handles v2113.Click
		RevealDiv(v2113_div)
	End Sub

	Protected Sub v2114_Click(sender As Object, e As EventArgs) Handles v2114.Click
		RevealDiv(v2114_div)
	End Sub

	Protected Sub v2115_btn_Click(sender As Object, e As EventArgs) Handles v2115_btn.Click
		RevealDiv(v2115_div)
	End Sub

	Protected Sub v22_btn_Click(sender As Object, e As EventArgs) Handles v22_btn.Click
		RevealDiv(v22_div)
	End Sub

	Protected Sub v2201_btn_Click(sender As Object, e As EventArgs) Handles v2201_btn.Click
		RevealDiv(v2201_div)
	End Sub

	Protected Sub v2202_btn_Click(sender As Object, e As EventArgs) Handles v2202_btn.Click
		RevealDiv(v2202_div)
	End Sub

	Protected Sub v2203_btn_Click(sender As Object, e As EventArgs) Handles v2203_btn.Click
		RevealDiv(v2203_div)
	End Sub

	Protected Sub v2204_btn_Click(sender As Object, e As EventArgs) Handles v2204_btn.Click
		RevealDiv(v2204_div)
	End Sub

	Protected Sub v2205_btn_Click(sender As Object, e As EventArgs) Handles v2205_btn.Click
		RevealDiv(v2205_div)
	End Sub

	Protected Sub v2206_btn_Click(sender As Object, e As EventArgs) Handles v2206_btn.Click
		RevealDiv(v2206_div)
	End Sub

	Protected Sub v2207_btn_Click(sender As Object, e As EventArgs) Handles v2207_btn.Click
		RevealDiv(v2207_div)
	End Sub

	Protected Sub v2208_btn_Click(sender As Object, e As EventArgs) Handles v2208_btn.Click
		RevealDiv(v2208_div)
	End Sub

	Protected Sub v2209_btn_Click(sender As Object, e As EventArgs) Handles v2209_btn.Click
		RevealDiv(v2209_div)
	End Sub

	Protected Sub v2210_btn_Click(sender As Object, e As EventArgs) Handles v2210_btn.Click
		RevealDiv(v2210_div)
	End Sub

	Protected Sub v2211_btn_Click(sender As Object, e As EventArgs) Handles v2211_btn.Click
		RevealDiv(v2211_div)
	End Sub

	Protected Sub v2212_btn_Click(sender As Object, e As EventArgs) Handles v2212_btn.Click
		RevealDiv(v2212_div)
	End Sub

	Protected Sub v2213_btn_Click(sender As Object, e As EventArgs) Handles v2213_btn.Click
		RevealDiv(v2213_div)
	End Sub

	Protected Sub v2214_btn_Click(sender As Object, e As EventArgs) Handles v2214_btn.Click
		RevealDiv(v2214_div)
	End Sub

	Protected Sub v2215_btn_Click(sender As Object, e As EventArgs) Handles v2215_btn.Click
		RevealDiv(v2215_div)
	End Sub

	Protected Sub v2216_btn_Click(sender As Object, e As EventArgs) Handles v2216_btn.Click
		RevealDiv(v2216_div)
	End Sub

	Protected Sub v2217_btn_Click(sender As Object, e As EventArgs) Handles v2217_btn.Click
		RevealDiv(v2217_div)
	End Sub

	Protected Sub v2218_btn_Click(sender As Object, e As EventArgs) Handles v2218_btn.Click
		RevealDiv(v2218_div)
	End Sub

	Protected Sub v2219_btn_Click(sender As Object, e As EventArgs) Handles v2219_btn.Click
		RevealDiv(v2219_div)
	End Sub

	Protected Sub v2220_btn_Click(sender As Object, e As EventArgs) Handles v2220_btn.Click
		RevealDiv(v2220_div)
	End Sub
End Class