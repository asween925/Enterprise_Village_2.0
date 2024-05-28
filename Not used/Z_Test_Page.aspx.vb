Imports System.IO
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class Z_Test_Page
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
    Dim VisitID As New Class_VisitData
    Dim Visit As Integer = VisitID.GetVisitID

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadData()
    End Sub

    Sub LoadData()
        Dim con As New SqlConnection
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim cmd As New SqlCommand
        'Dim Sr As New StreamReader("\\A6351L045-4457.pinellas.local\C:\EV\media\Badge Photos\myPhoto.png")
        Dim clientName As String = System.Net.Dns.GetHostEntry(Request.ServerVariables.Item("REMOTE_HOST")).HostName
        Dim filePath As String = "C:\EV\media\Badge Photos\"
        Dim dr As SqlDataReader

        'If System.IO.Directory.GetFiles(filePath, "myPhoto.png", IO.SearchOption.AllDirectories).Length > 0 Then
        '    error_lbl.Text = "File exists"
        '    Exit Sub
        'Else
        '    error_lbl.Text = filePath
        '    Exit Sub
        'End If

        ''Load timestamp data
        'Try
        '    con.ConnectionString = connection_string
        '    con.Open()
        '    cmd.Connection = con
        '    cmd.CommandText = "SELECT id, itemName, itemCategory, itemSubCat, currentLocation, source, onHand, businessUsed, comments, merchCode, usedDaily
        '                        FROM EV_Inventory
        '                        ORDER BY id ASC"

        '    Dim da As New SqlDataAdapter
        '    da.SelectCommand = cmd
        '    Dim dt As New DataTable
        '    da.Fill(dt)
        '    items_dgv.DataSource = dt
        '    items_dgv.DataBind()

        '    cmd.Dispose()
        '    con.Close()

        'Catch
        '    error_lbl.Text = "Error in LoadData(). Cannot get load data."
        '    Exit Sub
        'End Try

        'Populating header school and school name label


        Dim SchoolData As New Class_SchoolData
        error_lbl.Text = SchoolData.GetSchoolsString("5/18/23")
    End Sub

    Protected Sub upload_btn_Click(sender As Object, e As EventArgs) Handles upload_btn.Click
        Dim folderPath As String = Server.MapPath("~/uploads/Articles/")

        'Check whether Directory (Folder) exists.
        If Not Directory.Exists(folderPath) Then
            'If Directory (Folder) does not exists. Create it.
            Directory.CreateDirectory(folderPath)
        End If

        'Save the File to the Directory (Folder).
        fileUpload_fu.SaveAs(folderPath & Path.GetFileName(fileUpload_fu.FileName))

        'Display the success message.
        error_lbl.Text = Path.GetFileName(fileUpload_fu.FileName) + " has been uploaded."

    End Sub
End Class