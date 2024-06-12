Imports System.Data.SqlClient
Public Class teacher_input
	Inherits System.Web.UI.Page
	Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
	Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
	Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
	Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
	Dim DBConnection As New DatabaseConection
	Dim dr As SqlDataReader
	Dim VisitID As New Class_VisitData
	Dim Schools As New Class_SchoolData
	Dim Visit As Integer = VisitID.GetVisitID
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Session("LoggedIn") <> "1" Then
			Response.Redirect("../../default.aspx")
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

			Dim sql As String = "SELECT schoolname FROM schoolInfo WHERE NOT schoolName = 'A1 No School Scheduled' AND NOT id='505' ORDER BY schoolName"

			'School DDL
			Try
				con.ConnectionString = connection_string
				con.Open()
				cmd.CommandText = sql
				cmd.Connection = con
				dr = cmd.ExecuteReader

				While dr.Read()
					school_ddl.Items.Add(dr(0).ToString)
				End While

				school_ddl.Items.Insert(0, "")
				cmd.Dispose()
				con.Close()
			Catch
				MsgBox("Select a valid business name")
			Finally
				cmd.Dispose()
				con.Close()
			End Try
		End If
	End Sub

	Protected Sub Submit_btn_Click(sender As Object, e As EventArgs) Handles Submit_btn.Click
		Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
		Dim dr As SqlDataReader
		Dim email As String = email_tb.Text
		Dim SchoolID As String = Schools.GetSchoolID(school_ddl.SelectedValue)
		'Dim checkSQL As String = "SELECT lastname, schoolName, futureRequestsEmail FROM teacherInfo WHERE  lastName = '" & lastName_tb.Text & "' AND schoolName = '" & school_ddl.SelectedValue & "' AND futureRequestsEmail = '" & email_tb.Text & "'"

		'Checks what spots are empty and replaces select ones
		If firstName_tb.Text = Nothing And lastName_tb.Text = Nothing And school_ddl.SelectedIndex = 0 And email_tb.Text = Nothing And county_tb.Text = Nothing And count_tb.Text = Nothing Then
			error_lbl.Text = "Please select a school name and enter a last name and an email before submiting."
			Exit Sub
		ElseIf firstName_tb.Text = Nothing Then
			firstName_tb.Text = " "
		ElseIf lastName_tb.Text = Nothing Then
			error_lbl.Text = "Please enter a last name for the teacher."
			Exit Sub
		ElseIf school_ddl.SelectedIndex = 0 Then
			error_lbl.Text = "Please select a school name from the drop down menu."
			Exit Sub
		ElseIf email_tb.Text = Nothing Then
			error_lbl.Text = "Please enter a valid email."
			Exit Sub
		ElseIf county_tb.Text = Nothing Then
			county_tb.Text = " "
		ElseIf count_tb.Text = Nothing Then
			count_tb.Text = 0
		ElseIf contact_chk.Checked = False Then
			contact_chk.Checked = False
		End If

		'Checks if email_tb is an address
		If Not (email.Contains("@")) And Not (email.Contains(".")) Then
			'Not an email. Show message
			error_lbl.Text = "Not a valid email address."
			Exit Sub
		End If

		If school_ddl.SelectedIndex = 0 Then
			error_lbl.Text = "Please select a school name from the drop down menu."
			Exit Sub
		End If

		Using con As New SqlConnection(connection_string)
			'Checks if there is already a name, email, and school name with the entered information in the DB
			Using cmd As New SqlCommand("SELECT lastname, schoolID, futureRequestsEmail FROM teacherInfo WHERE lastName = '" & lastName_tb.Text & "' AND schoolID = '" & SchoolID & "' AND futureRequestsEmail = '" & email_tb.Text & "'")
				cmd.Connection = con
				con.Open()
				dr = cmd.ExecuteReader
				While dr.Read()
					If dr.HasRows = True Then
						error_lbl.Text = "A teacher with that last name, school name, and email address is already in the database. Please view the 'Edit Teacher' page to make changes to the teacher."

						'Refresh page
						Dim meta As New HtmlMeta()
						meta.HttpEquiv = "Refresh"
						meta.Content = "5;url=teacher_input.aspx"
						Me.Page.Controls.Add(meta)
						Exit Sub
					End If
				End While
				con.Close()
				cmd.Dispose()
			End Using

			'Checks if there is already a name, email, and school name with the entered information in the DB
			Using cmd As New SqlCommand("SELECT futureRequestsEmail FROM teacherInfo WHERE futureRequestsEmail = '" & email_tb.Text & "'")
				cmd.Connection = con
				con.Open()
				dr = cmd.ExecuteReader
				While dr.Read()
					If dr.HasRows = True Then
						error_lbl.Text = "A teacher with that email address is already in the database. Please view the 'Edit Teacher' page to make changes to the teacher."

						'Refresh page
						Dim meta As New HtmlMeta()
						meta.HttpEquiv = "Refresh"
						meta.Content = "5;url=teacher_input.aspx"
						Me.Page.Controls.Add(meta)
						Exit Sub
					End If
				End While
				con.Close()
				cmd.Dispose()
			End Using

			Using cmd As New SqlCommand("INSERT INTO teacherInfo (
													 firstName
													,lastName
													,isContact
													,schoolID
													,futureRequestsEmail
													,county
													,studentCount)
												VALUES ( 
													 @firstName
													,@lastName
													,@isContact
													,@schoolID
													,@futureRequestsEmail
													,@county
													,@studentCount);")

				cmd.Parameters.Add("@firstName", SqlDbType.VarChar).Value = firstName_tb.Text
				cmd.Parameters.Add("@lastName", SqlDbType.VarChar).Value = lastName_tb.Text
				cmd.Parameters.Add("@schoolID", SqlDbType.VarChar).Value = SchoolID
				cmd.Parameters.Add("@futureRequestsEmail", SqlDbType.VarChar).Value = email_tb.Text
				cmd.Parameters.Add("@county", SqlDbType.VarChar).Value = county_tb.Text
				cmd.Parameters.Add("@studentCount", SqlDbType.VarChar).Value = count_tb.Text
				cmd.Parameters.Add("@isContact", SqlDbType.Bit).Value = contact_chk.Checked
				'cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password_tb.Text
				cmd.Connection = con
				con.Open()
				cmd.ExecuteNonQuery()
				con.Close()
				'cmd.CommandText = "SELECT lastname, schoolName, futureRequestsEmail FROM teacherInfo WHERE  lastName = '" & lastName_tb.Text & "' AND schoolName = '" & school_ddl.SelectedValue & "' AND futureRequestsEmail = '" & email_tb.Text & "'"
				'cmd.Connection = con
				'dr = cmd.ExecuteReader

				'While dr.Read()
				'	If dr.HasRows = True Then
				'		error_lbl.Text = "A teacher with last name, school name, and email address is already in the database. Please view the 'Edit Teacher' page to make changes to the teacher."

				'		'Refresh page
				'		Dim meta As New HtmlMeta()
				'		meta.HttpEquiv = "Refresh"
				'		meta.Content = "3;url=teacher_input.aspx"
				'		Me.Page.Controls.Add(meta)
				'		Exit Sub
				'	End If
				'End While

				'cmd.ExecuteNonQuery()
				'con.Close()
				Page.ClientScript.RegisterStartupScript(Me.GetType(), "SubmitSucessText", "SubmitSucessText();", True)

			End Using
		End Using
	End Sub
End Class