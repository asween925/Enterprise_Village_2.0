Imports System.Data.SqlClient
Imports AForge.Video.DirectShow

Public Class Badge_Creator
    Inherits System.Web.UI.Page
    Dim camera As VideoCaptureDevice
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim DBConnection As New DatabaseConection
    Dim dr As SqlDataReader
    Dim dr2 As SqlDataReader
    Dim path As String = "X:\inetpub\wwwroot\EV\media\Badge Photos\"
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
    Dim newPhotoPath As String
    Dim StudentData As New Class_StudentData
    Dim BadgesData As New Class_BadgesData
    Dim VisitID As New Class_VisitData
    Dim Visit As Integer = VisitID.GetVisitID

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Checks visit date
        If Not (IsPostBack) Then

            If Visit <> 0 Then
                visitdate_hf.Value = Visit
            Else
                error_lbl.Text = "No visit date, please go to 'Database Creator' on the 'Tools / Reports' page and create a new school visit date."
                employeeNumber_tb.Enabled = False
                Enter_btn.Enabled = False
                capture_btn.Enabled = False
                upload_btn.Enabled = False
                Exit Sub
            End If

            'Loads saved badges in gridview
            LoadData()

        End If
    End Sub

    Sub LoadData()

        'Clear out existing badges gridview
        existingBadges_dgv.DataSource = Nothing
        existingBadges_dgv.DataBind()
        tablerowIndex_hf.Value = 0

        'load existing table
        existingBadges_dgv.DataSource = BadgesData.LoadExistingBadgesTable(Visit, "", " ORDER BY id DESC")
        existingBadges_dgv.DataBind()

        'Check if there are no badges, if no then display error
        If existingBadges_dgv.Rows.Count = 0 Then
            tablemaxRow_hf.Value = existingBadges_dgv.Rows.Count
            badge_total.Text = tablemaxRow_hf.Value
            error_lbl.Text = "No badges created."
            Exit Sub
        Else
            tablemaxRow_hf.Value = existingBadges_dgv.Rows.Count
            badge_total.Text = tablemaxRow_hf.Value
            capture_btn.Enabled = False
            upload_btn.Enabled = False
        End If

    End Sub

    Sub EnterAccountNumber()
        Dim empID As Integer = employeeNumber_tb.Text
        Dim StudentLookup = StudentData.StudentLookup(Visit, empID)
        Dim FirstName = StudentLookup.FirstName
        Dim LastName = StudentLookup.LastName
        Dim BusinessName = StudentLookup.BusinessName
        Dim JobTitle = StudentLookup.JobTitle
        Dim AccountNumber = StudentLookup.AccountNumber

        'Clear out badge
        studentName_lbl.Text = Nothing
        businessName_lbl.Text = Nothing
        position_lbl.Text = Nothing
        date_lbl.Text = Nothing
        photo_img.ImageUrl = Nothing

        'Clear error lbl
        error_lbl.Text = Nothing

        'Check if textbox is empty
        If employeeNumber_tb.Text = Nothing Or employeeNumber_tb.Text = "" Then
            error_lbl.Text = "No account number entered. Please type in an account number and click 'Enter'."
            Exit Sub
        End If

        'Check if account number is valid
        If employeeNumber_tb.Text < 1 Or employeeNumber_tb.Text > 240 Then
            error_lbl.Text = "Please enter a number between 1 and 240."
            Exit Sub
        End If

        'Check if entered number is already saved
        Try
            If BadgesData.CheckIfBadgeExists(Visit, empID) = True Then
                error_lbl.Text = "A badge with that number associated to it already exists. Please delete the badge from the 'Badge History' to create it again."
                Exit Sub
            End If
        Catch
            error_lbl.Text = "Error in checking employeeNumber. Please inform a staff member!"
            Exit Sub
        End Try

        'Check if number has a name assigned to it
        Try
            If FirstName = Nothing Or LastName = Nothing Then
                error_lbl.Text = "There is no name associated with that account number. Please enter a different number."
                Exit Sub
            End If
        Catch
            error_lbl.Text = "Error in checking employeeName. Please inform a staff member!"
            Exit Sub
        End Try

        'Display student info on badge
        Try
            studentName_lbl.Text = FirstName & " " & LastName
            businessName_lbl.Text = BusinessName
            position_lbl.Text = JobTitle
            date_lbl.Text = FormatDateTime(Now, DateFormat.ShortDate)
            employeeNumber_lbl.Text = AccountNumber
        Catch
            error_lbl.Text = "Error in getting information from account number. Please find a Enterprise Village teacher!"
            Exit Sub
        End Try

        'Enable Buttons
        If employeeNumber_tb.Text <> Nothing Then
            capture_btn.Enabled = True
            upload_btn.Enabled = True
        Else
            capture_btn.Enabled = False
            upload_btn.Enabled = False
        End If

        'Change btn name
        Enter_btn.Text = "New Badge"

        'Disable Textbox
        employeeNumber_tb.Enabled = False
    End Sub

    Sub LoadRecentBadge()
        'Populate badge with data from the existingBadges table
        Dim row As GridViewRow = existingBadges_dgv.Rows(0)
        'Dim path As String = "~/media/"
        studentName_lbl.Text = row.Cells(2).Text
        businessName_lbl.Text = row.Cells(3).Text
        position_lbl.Text = row.Cells(4).Text
        date_lbl.Text = FormatDateTime(row.Cells(6).Text, DateFormat.ShortDate)
        photo_img.ImageUrl = row.Cells(7).Text
        'photo_img.ImageUrl = path & row.Cells(7).Text
        photo_img.Visible = True
        employeeNumber_lbl.Text = row.Cells(1).Text

        error_lbl.Text = "Photo successfully uploaded!"
    End Sub

    Sub UploadBadge()
        Dim filePath As String = Server.MapPath("~/media/Badge Photos/")
        Dim badgeDate As String = DateTime.Now.ToString().Replace("/", "-").Replace(" ", "- ").Replace(":", "")
        Dim count As Integer = 1
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim visitID As Integer = visitdate_hf.Value
        Dim businessID As String = Request.QueryString("b")
        Dim studentName As String = studentName_lbl.Text

        'Message for uploading photos
        error_lbl.Text = "Please wait for the badge to finish creating . . ."

        'Wait 3 seconds for download to finish
        Threading.Thread.Sleep(3000)

        'Check if studentName contains an apostraphe
        If studentName.Contains("'") Then
            studentName = studentName.ToString().Replace("'", "")
        End If

        'First checks if myPhoto.png exists, this is the base photo. Should not be deleted.
        If My.Computer.FileSystem.FileExists(filePath & "myPhoto.png") Then
            While count <> 0
                'Checks to see if the photo with the proper count number exists. This is always a base of 1, and then increases every time it confirms that the file exists
                'When the photo is downloaded from the 'Take Picture' button, it will download as myPhoto (1) or (2), etc. depending on how many photos they take
                If My.Computer.FileSystem.FileExists(filePath & "myPhoto (" & count & ").png") Then
                    count = count + 1
                Else
                    'If the count number does not match with the file number, it will subtract 1 from the count number and rename the latest picture with their ID, name, and date.                   
                    count = count - 1
                    If My.Computer.FileSystem.FileExists(filePath & "myPhoto (" & count & ").png") Then
                        My.Computer.FileSystem.RenameFile(filePath & "myPhoto (" & count & ").png", "badge-" + employeeNumber_tb.Text + "-" + studentName + "-" + badgeDate + ".png")
                    Else
                        error_lbl.Text = "There is no photo saved. Please inform a staff member."
                        Exit Sub
                    End If

                    'This while loop will count down and delete the remaining photos with the number (1), (2), ... until they are gone.
                    While count <> 0
                        count = count - 1
                        If count = 0 Then
                            Exit While
                        Else
                            My.Computer.FileSystem.DeleteFile(filePath & "myPhoto (" & count & ").png")
                        End If
                    End While
                End If
            End While
        Else
            error_lbl.Text = "myPhoto.png doesn't exist. Please inform a staff member."
            Exit Sub
        End If

        newPhotoPath = "Badge Photos/badge-" + employeeNumber_tb.Text + "-" + studentName + "-" + badgeDate + ".png"

        'Insert data into DB
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "INSERT INTO badges (employeeNumber, employeeName, businessName, position, businessID, date, photoPath, visitID ) VALUES ('" & employeeNumber_tb.Text & "', '" & studentName & "', '" & businessName_lbl.Text & "', '" & position_lbl.Text & "', '" & businessID & "', '" & date_lbl.Text & "', '" & newPhotoPath & "', '" & visitID & "')"
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            con.Close()
        Catch
            error_lbl.Text = "Error: could not upload photo. Student name could have an unusuable character (', ., etc.)."
            Exit Sub
        End Try

        LoadData()
        LoadRecentBadge()

    End Sub

    Sub NewBadge()
        'Makes cursor go to textbox
        employeeNumber_tb.Focus()

        'Enable employee number textbox
        employeeNumber_tb.Enabled = True

        'Clear error label
        error_lbl.Text = ""

        'Clear Badges
        studentName_lbl.Text = ""
        businessName_lbl.Text = ""
        position_lbl.Text = ""
        date_lbl.Text = ""
        photo_img.Visible = False
        employeeNumber_lbl.Text = ""
    End Sub

    Private Sub Enter_btn_Click(sender As Object, e As EventArgs) Handles Enter_btn.Click
        If Enter_btn.Text = "New Badge" Then
            Response.Redirect("badge_creator.aspx")
        ElseIf Enter_btn.Text = "Enter" Then
            EnterAccountNumber()
        End If
    End Sub

    Protected Sub upload_btn_Click(sender As Object, e As EventArgs) Handles upload_btn.Click
        error_lbl.Text = "Please wait... Photo being uploaded..."
        UploadBadge()
    End Sub

End Class