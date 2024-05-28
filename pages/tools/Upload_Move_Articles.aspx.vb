Imports System.IO
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class Upload_Move_Articles
	Inherits System.Web.UI.Page
	Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
	Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
	Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
	Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
	Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
	Dim SchoolData As New Class_SchoolData
	Dim VisitID As New Class_VisitData
	Dim Visit As Integer = VisitID.GetVisitID
	Dim oldVisitDateFormat As String

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
		Dim con As New SqlConnection
		Dim cmd As New SqlCommand

		If Session("LoggedIn") <> "1" Then
			Response.Redirect("../../default.aspx")
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

	Sub LoadSchools()
		Dim schoolNameDDL As DropDownList = schoolName_ddl
		Dim oldVisitDate As String = oldVisitDate_tb.Text

		'Made school name DDL and header visible
		school_p.Visible = True

		'Load schools into DDL
		Dim load As New Class_SchoolData
		load.LoadVisitDateSchoolsDDL(oldVisitDate, schoolNameDDL)

	End Sub

	Sub CheckForFolder()
		Dim schoolName As String = schoolName_ddl.SelectedValue
		Dim oldDateFilePath As String

		'Change format of string
		oldVisitDateFormat = Convert.ToDateTime(oldVisitDate_tb.Text).ToString("MM-dd-yyyy")
		oldDateFilePath = Server.MapPath("~/uploads/Articles/" & oldVisitDateFormat & "/")

		'Check if a folder has been created for the visit date and school name in the uploads\Articles\ directory
		If My.Computer.FileSystem.DirectoryExists(oldDateFilePath) Then

			'Visit date directory exists (means at least one school has uploaded their articles, now check for school name dir.
			If My.Computer.FileSystem.DirectoryExists(oldDateFilePath & schoolName & "/") Then

				'Teacher has uploaded articles for their visit date
				'Made school name DDL and header visible
				newDate_p.Visible = True
			Else
				error_lbl.Text = "Teacher has not yet uploaded their newspaper articles. You may now close this page."
				Exit Sub
			End If

		Else
			error_lbl.Text = "Teacher has not yet uploaded their newspaper articles. You may now close this page."
			Exit Sub
		End If

	End Sub

	Sub CheckForVisitDate()
		Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
		Dim con As New SqlConnection
		Dim cmd As New SqlCommand
		Dim dr As SqlDataReader
		Dim newVisitDate As String = newVisitDate_tb.Text
		Dim sql As String = "SELECT visitDate FROM visitInfo WHERE visitDate='" & newVisitDate & "'"

		'Check if new visit date exists
		Try
			con.ConnectionString = connection_string
			con.Open()
			cmd.CommandText = sql
			cmd.Connection = con
			dr = cmd.ExecuteReader

			If dr.HasRows() Then
				error_lbl.Text = "New visit date exists. Click 'Submit' to begin transfering articles."
				Exit Sub
			Else
				error_lbl.Text = "No updated visit date exists. Please create one by going to 'Create a Visit' under 'Tools'."
				Exit Sub
			End If

		Catch ex As Exception
			error_lbl.Text = "Error in CheckForVisitDate(). Error in SQL statement."
			Exit Sub
		End Try

		cmd.Dispose()
		con.Close()

	End Sub

	Sub Submit()
		Dim schoolName As String = schoolName_ddl.SelectedValue
		Dim oldVisitDateFormat As String = Convert.ToDateTime(oldVisitDate_tb.Text).ToString("MM-dd-yyyy")
		Dim newVisitDateFormat As String = Convert.ToDateTime(newVisitDate_tb.Text).ToString("MM-dd-yyyy")
		Dim oldDirectoryPath As String = Server.MapPath("~/uploads/Articles/" & oldVisitDateFormat & "/" & schoolName & "/")
		Dim newDirectoryPath As String = Server.MapPath("~/uploads/Articles/" & newVisitDateFormat & "/")

		'Move folder to new visit date folder, create one if necessary
		If My.Computer.FileSystem.DirectoryExists(newDirectoryPath) Then

			'Move old directory
			My.Computer.FileSystem.MoveDirectory(oldDirectoryPath, newDirectoryPath & schoolName & "/")
		Else
			'Create directory
			My.Computer.FileSystem.CreateDirectory(newDirectoryPath)

			'Move old directory
			My.Computer.FileSystem.MoveDirectory(oldDirectoryPath, newDirectoryPath & schoolName & "/")
		End If

		'Confirm it moved to the new location
		If My.Computer.FileSystem.DirectoryExists(newDirectoryPath & "/" & schoolName & "/") Then
			error_lbl.Text = "Articles now moved into the '" & newVisitDateFormat & "' folder in the EV 2.0 server."
			Exit Sub
		Else
			error_lbl.Text = "Error in Submit(). Cannot find new directory path."
			Exit Sub
		End If

	End Sub

	Sub UploadFile()
		Dim VisitDate As String = Convert.ToDateTime(uploadVisitDate_tb.Text).ToString("MM-dd-yyyy")
		Dim SchoolName As String = uploadSchoolName_ddl.SelectedValue
		Dim visitFolderPath As String = Server.MapPath("~\uploads\Articles\" & VisitDate & "\")
		Dim schoolFolderPath As String = Server.MapPath("~\uploads\Articles\" & VisitDate & "\" & SchoolName & "\")
		Dim fi As FileInfo = New FileInfo(fileUpload_fu.FileName)
		Dim ext As String = fi.Extension
		Dim FileName As String = fileUpload_fu.FileName
		Dim FileName2() As String = FileName.Split(ext)
		Dim Count As Integer = 2

		'Check whether Directory (Folder) exists.
		If Not Directory.Exists(visitFolderPath) Then

			'If Directory (Folder) does not exists. Create it.
			Directory.CreateDirectory(visitFolderPath)
		End If

		'Check if school folder exists
		If Not Directory.Exists(schoolFolderPath) Then

			'If Directory (Folder) does not exists. Create it.
			Directory.CreateDirectory(schoolFolderPath)
		End If

		'Try
		'Check if extension is a word doc
		If ext = ".docx" Then

				'Check if file name in the directory is the same name 
				While Count <> 0
					If File.Exists(schoolFolderPath & FileName) Then
						FileName = FileName2(0) & "(" & Count & ")" & ext
						Count += 1
					Else
						Exit While
					End If
				End While

				'Save the File to the Directory (Folder).
				Try
					fileUpload_fu.SaveAs(schoolFolderPath & Path.GetFileName(FileName))
				Catch
					error_lbl.Text = "Error with uploading file. Check school name in database."
				End Try


				'Display the success message.
				error_lbl.Text = "Articles have been uploaded. Thank you!"

			Else
				error_lbl.Text = "File not uploaded. File must be a Word document."
				Exit Sub
			End If
		'Catch
		'	error_lbl.Text = "Error in uploading. Please try again or click the link under the 'Log Out' button to ask for help."
		'	Exit Sub
		'End Try


	End Sub

	Protected Sub oldVisitDate_tb_TextChanged(sender As Object, e As EventArgs) Handles oldVisitDate_tb.TextChanged
		If oldVisitDate_tb.Text <> Nothing Then
			LoadSchools()
		End If
	End Sub

	Protected Sub newVisitDate_tb_TextChanged(sender As Object, e As EventArgs) Handles newVisitDate_tb.TextChanged
		CheckForVisitDate()
	End Sub

	Protected Sub submit_btn_Click(sender As Object, e As EventArgs) Handles submit_btn.Click
		Submit()
	End Sub

	Protected Sub schoolName_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles schoolName_ddl.SelectedIndexChanged
		CheckForFolder()
	End Sub

	Protected Sub uploadView_btn_Click(sender As Object, e As EventArgs) Handles uploadView_btn.Click
		If upload_div.Visible = False Then
			upload_div.Visible = True
			move_div.Visible = False

			'Clear error label
			error_lbl.Text = ""
		End If
	End Sub

	Protected Sub moveView_btn_Click(sender As Object, e As EventArgs) Handles moveView_btn.Click
		If move_div.Visible = False Then
			move_div.Visible = True
			upload_div.Visible = False

			'Clear error label
			error_lbl.Text = ""
		End If
	End Sub

	Protected Sub upload_btn_Click(sender As Object, e As EventArgs) Handles upload_btn.Click
		UploadFile()
	End Sub

	Protected Sub uploadVisitDate_tb_TextChanged(sender As Object, e As EventArgs) Handles uploadVisitDate_tb.TextChanged
		If uploadVisitDate_tb.Text <> Nothing Then
			uploadSchoolName_p.Visible = True
			uploadSchoolName_ddl.Visible = True

			'Load school DDL for visit date
			SchoolData.LoadVisitDateSchoolsDDL(uploadVisitDate_tb.Text, uploadSchoolName_ddl)
		End If
	End Sub

	Protected Sub uploadSchoolName_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles uploadSchoolName_ddl.SelectedIndexChanged
		If uploadSchoolName_ddl.SelectedIndex <> 0 Then
			fileUpload_p.Visible = True
			fileUpload_fu.Visible = True
			upload_btn.Visible = True
		End If
	End Sub
End Class