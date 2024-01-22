Imports System.Data.SqlClient
Imports System.Threading
Imports System.IO

Public Class Newspaper_Hub
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim DBConnection As New DatabaseConection
    Dim dr As SqlDataReader
    Dim SchoolData As New Class_SchoolData
    Dim VisitID As New Class_VisitData
    Dim Visit As Integer = VisitID.GetVisitID

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not (IsPostBack) Then

            If Visit <> 0 Then
                visitID_hf.Value = Visit
            End If

        End If

    End Sub

    Sub LoadData()
        Dim VisitDate As String = visitDate_tb.Text
        Dim SchoolName As String = SchoolData.GetSchoolsString(VisitDate)
        Dim files As List(Of ListItem) = New List(Of ListItem)
        Dim subdir As List(Of ListItem) = New List(Of ListItem)
        Dim pathForFile As String
        Dim fileModified As List(Of ListItem) = New List(Of ListItem)
        Dim fileMod As String

        'Clear out table and labels
        error_lbl.Text = ""
        articles_dgv.DataSource = Nothing
        articles_dgv.DataBind()

        'Convert visit date to correct format
        VisitDate = Convert.ToDateTime(VisitDate).ToString("MM-dd-yyyy")

        'Assign server path for files
        pathForFile = Server.MapPath("~/uploads/Articles/" & VisitDate & "/")

        'Assign visit date and school name(s) label
        visitDate_lbl.Text = VisitDate
        schoolName_lbl.Text = SchoolName

        'Check if directory exists
        If My.Computer.FileSystem.DirectoryExists(pathForFile) Then

            'Load files into gridview
            Dim filePaths() As String = Directory.GetFiles(pathForFile, "*.docx", SearchOption.AllDirectories)

            For Each filePath As String In filePaths
                fileMod = Directory.GetLastWriteTime(filePath).ToString
                files.Add(New ListItem(Path.GetFileName(filePath) & " (" & fileMod & ")", filePath))
                'subdir.Add(New ListItem(Path.GetDirectoryName(filePath), filePath))
            Next

            articles_dgv.DataSource = files
            articles_dgv.DataBind()
        Else
            error_lbl.Text = "No articles found for this visit date."
            Exit Sub
        End If

    End Sub

    Protected Sub DownloadFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim filePath As String = CType(sender, LinkButton).CommandArgument

        'Downloads the file selected
        Response.ContentType = ContentType
        Response.AppendHeader("Content-Disposition", ("attachment; filename=" + Path.GetFileName(filePath)))
        Response.WriteFile(filePath)
        Response.End()
    End Sub

    Protected Sub ConfirmDelete(ByVal sender As Object, ByVal e As EventArgs)
        Dim articleName As String = CType(sender, LinkButton).CommandArgument
        Dim articleNameShortened As String = Path.GetFileNameWithoutExtension(articleName)

        'Put filePath into hidden field
        articleName_hf.Value = articleName

        'Put name of file in deletion header
        articleName_a.InnerText = articleNameShortened

        'Make confirm deletion div visible
        deletionConfirm_div.Visible = True
    End Sub

    Protected Sub DeleteFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim filePath As String = articleName_hf.Value

        'Check if user entered 'Delete' into textbox
        If confirmDelete_tb.Text = "Delete" Then
            File.Delete(filePath)
            Response.Redirect(Request.Url.AbsoluteUri)
            error_lbl.Text = "File deleted."
        Else
            error_lbl.Text = "Please enter 'Delete' or click 'Cancel'."
            Exit Sub
        End If

    End Sub

    Protected Sub cancel_btn_Click(sender As Object, e As EventArgs) Handles cancel_btn.Click
        deletionConfirm_div.Visible = False
    End Sub

    Protected Sub delete_btn_Click(sender As Object, e As EventArgs) Handles delete_btn.Click
        DeleteFile(sender, e)
    End Sub

    Protected Sub visitDate_tb_TextChanged(sender As Object, e As EventArgs) Handles visitDate_tb.TextChanged
        If visitDate_tb.Text <> Nothing Then
            articles_div.Visible = True
            LoadData()
        End If
    End Sub
End Class