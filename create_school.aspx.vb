Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class Create_School
	Inherits System.Web.UI.Page
	Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
	Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
	Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
	Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
	Dim DBConnection As New DatabaseConection
	Dim dr As SqlDataReader
	Dim VisitID As New Class_VisitData
	Dim Visit As Integer = VisitID.GetVisitID
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Session("LoggedIn") <> "1" Then
			Response.Redirect(".\default.aspx")
		End If

		If Not (IsPostBack) Then
			Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
			Dim con As New SqlConnection
			Dim cmd As New SqlCommand
			Dim dr As SqlDataReader
			Dim schoolDDL As String = "SELECT "

			If Visit <> 0 Then
				visitdate_hf.Value = Visit
			End If

			'Populating school header
			Dim header As New Class_SchoolHeader
			headerSchoolName_lbl.Text = header.GetSchoolHeader()

		End If
	End Sub

	Sub Submit()
		Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
		Dim dr As SqlDataReader

		If schoolName_tb.Text = Nothing Or phoneNum_tb.Text = Nothing Then
			error_lbl.Text = "Please enter a name for the school and a phone number."
			Exit Sub
		End If

		If principalFirst_tb.Text = Nothing Then
			principalFirst_tb.Text = "N/A"
		End If

		If principalLast_tb.Text = Nothing Then
			principalLast_tb.Text = "N/A"
		End If

		If faxNum_tb.Text = Nothing Then
			faxNum_tb.Text = "N/A"
		End If

		If schoolNum_tb.Text = Nothing Then
			schoolNum_tb.Text = "0000"
		End If

		If schoolHours_tb.Text = Nothing Then
			schoolHours_tb.Text = "N/A"
		End If

		If futureRequestsEmail_tb.Text = Nothing Then
			futureRequestsEmail_tb.Text = "N/A"
		End If

		If futureRequestsNotes_tb.Text = Nothing Then
			futureRequestsNotes_tb.Text = "N/A"
		End If

		If county_tb.Text = Nothing Then
			county_tb.Text = "N/A"
		End If

		If liaison_tb.Text = Nothing Then
			liaison_tb.Text = "N/A"
		End If


		Using con As New SqlConnection(connection_string)
			Using cmd As New SqlCommand("SELECT schoolName FROM schoolInfo WHERE schoolName = '" & schoolName_tb.Text & "'")
				cmd.Connection = con
				con.Open()
				dr = cmd.ExecuteReader
				While dr.Read()
					If dr.HasRows = True Then
						error_lbl.Text = "A school with that name is already in the database. Please view the 'Edit School' page to make changes to the school."

						'Refresh page
						Dim meta As New HtmlMeta()
						meta.HttpEquiv = "Refresh"
						meta.Content = "5;url=create_school.aspx"
						Me.Page.Controls.Add(meta)
						Exit Sub
					End If
				End While
				con.Close()
				cmd.Dispose()

			End Using
			Using cmd As New SqlCommand("INSERT INTO schoolInfo (
													 schoolName
													,principalFirst
													,principalLast
													,phone
													,fax
													,schoolNum
													,schoolHours
													,schoolType
													,futureRequestsEmail
													,futureRequests
													,county
													,liaisonName)
												VALUES ( 
													@schoolName
													,@principalFirst
													,@principalLast
													,@phone
													,@fax
													,@schoolNum
													,@schoolHours
													,@schoolType
													,@futureRequestsEmail
													,@futureRequests
													,@county
													,@liaisonName);")
				cmd.Parameters.Add("@schoolName", SqlDbType.VarChar).Value = schoolName_tb.Text
				cmd.Parameters.Add("@principalFirst", SqlDbType.VarChar).Value = principalFirst_tb.Text
				cmd.Parameters.Add("@principalLast", SqlDbType.VarChar).Value = principalLast_tb.Text
				cmd.Parameters.Add("@phone", SqlDbType.VarChar).Value = phoneNum_tb.Text
				cmd.Parameters.Add("@fax", SqlDbType.VarChar).Value = faxNum_tb.Text
				cmd.Parameters.Add("@schoolNum", SqlDbType.Int).Value = schoolNum_tb.Text
				cmd.Parameters.Add("@schoolHours", SqlDbType.VarChar).Value = schoolHours_tb.Text
				cmd.Parameters.Add("@schoolType", SqlDbType.VarChar).Value = schoolType_ddl.SelectedValue
				cmd.Parameters.Add("@futureRequestsEmail", SqlDbType.VarChar).Value = futureRequestsEmail_tb.Text
				cmd.Parameters.Add("@futureRequests", SqlDbType.Text).Value = futureRequestsNotes_tb.Text
				cmd.Parameters.Add("@county", SqlDbType.Text).Value = county_tb.Text
				cmd.Parameters.Add("@liaisonName", SqlDbType.Text).Value = liaison_tb.Text
				cmd.Connection = con
				con.Open()
				cmd.ExecuteNonQuery()
				con.Close()
			End Using
		End Using

		'error_lbl.Text = "Submission Sucessful"
		Page.ClientScript.RegisterStartupScript(Me.GetType(), "SubmitSucessText", "SubmitSucessText();", True)
	End Sub

	Protected Sub Submit_btn_Click(sender As Object, e As EventArgs) Handles Submit_btn.Click
		Submit()
	End Sub

End Class