Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO

Public Class Teacher_Home
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim DBConnection As New DatabaseConection
    Dim dr As SqlDataReader
    Dim SchoolData As New Class_SchoolData
    Dim TeacherData As New Class_TeacherData
    Dim VisitID As New Class_VisitData
    Dim Visit As Integer = VisitID.GetVisitID
    Dim schoolID As String
    Dim teacherID As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("LoggedIn") <> "1" Then
            Response.Redirect("../../default.aspx")
        End If

        'currentVisitID_hf.Value = Visit
        schoolID = Request.QueryString("b")
        teacherID = Request.QueryString("c")

        If Not (IsPostBack) Then
            Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
            Dim con As New SqlConnection
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim username As String = Session("username")
            Dim teacherNameSQL As String = "SELECT firstName FROM teacherInfo WHERE id='" & teacherID & "'"
            Dim visitIDSQL As String = "SELECT id, visitDate FROM visitInfo WHERE school = '" & schoolID & "' OR school2 = '" & schoolID & "' OR school3 = '" & schoolID & "' OR school4 = '" & schoolID & "' OR school5 = '" & schoolID & "' AND visitDate BETWEEN '08-10-2022' AND '07-01-2023'"
            Dim schoolNameSQL As String = "SELECT schoolName FROM schoolInfo WHERE id = '" & schoolID & "'"

            'Get school visit date
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.CommandText = visitIDSQL
                cmd.Connection = con
                dr = cmd.ExecuteReader

                While dr.Read()
                    teacherVisitID_hf.Value = dr("id").ToString
                    visitDate_lbl.Text = Convert.ToDateTime(dr("visitDate")).ToString("MM/dd/yyyy")
                    visitDate_hf.Value = Convert.ToDateTime(dr("visitDate")).ToString("MM-dd-yyyy")
                End While

                cmd.Dispose()
                con.Close()

            Catch ex As Exception
                visitDate_lbl.Text = "Not found."
            End Try

            cmd.Dispose()
            con.Close()

            'Get School Name
            Try
                schoolName_lbl.Text = SchoolData.GetSchoolNameFromID(schoolID)
            Catch
                schoolName_lbl.Text = "Your School"
            End Try


            'Get teacher name
            Try
                teacherName_lbl.Text = TeacherData.GetContactTeacher(schoolName_lbl.Text)
            Catch
                teacherName_lbl.Text = ""
            End Try


        End If
    End Sub

    Sub UploadFile()
        Dim VisitDate As Date = visitDate_hf.Value
        Dim SchoolName As String = schoolName_lbl.Text
        Dim CurrentDate As Date = DateTime.Now.ToShortDateString
        Dim DayDiff As String = DateDiff(DateInterval.Day, CurrentDate, VisitDate)
        Dim visitFolderPath As String = Server.MapPath("~\uploads\Articles\" & visitDate_hf.Value & "\")
        Dim schoolFolderPath As String = Server.MapPath("~\uploads\Articles\" & visitDate_hf.Value & "\" & SchoolName & "\")
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

        'Check if current date is more than 3 days before visit date
        If DayDiff <= 1 Then
            error_lbl.Text = "You cannot upload anymore articles because your visit date is 3 days or less away. Please contact an Enterprise Village teacher or staff member for any questions."
            Exit Sub
        End If

        'Start uploading
        Try
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
                fileUpload_fu.SaveAs(schoolFolderPath & Path.GetFileName(FileName))

                'Display the success message.
                error_lbl.Text = "Articles have been uploaded. Thank you!"

            Else
                error_lbl.Text = "File not uploaded. File must be a Word document."
                Exit Sub
            End If
        Catch
            error_lbl.Text = "Error in uploading. Please try again or click the link under the 'Log Out' button to ask for help."
            Exit Sub
        End Try


    End Sub

    Protected Sub upload_btn_Click(sender As Object, e As EventArgs) Handles upload_btn.Click
        UploadFile()
    End Sub

    Protected Sub isi_btn_Click(sender As Object, e As EventArgs) Handles isi_btn.Click
        Dim schoolIDURL As String = schoolID
        Dim teacherIDURL As String = teacherID

        'Redirect to ISI page
        Response.Redirect(".\input_student_information.aspx?b=" & schoolIDURL & "&c=" & teacherIDURL)
    End Sub

    Protected Sub logOut_btn_Click(sender As Object, e As EventArgs) Handles logOut_btn.Click
        HttpContext.Current.Session.Abandon()
        Response.Redirect("../../default.aspx")
    End Sub
End Class