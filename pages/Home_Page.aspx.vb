Imports System.Data.SqlClient
Imports System.Net.Http
Imports System.Net.Mail
Imports System.Windows.Forms.HtmlElement
Imports Newtonsoft.Json
Imports System.Text.Json

Public Class Home_Page
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim DBConnection As New DatabaseConection
    Dim dr As SqlDataReader
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
    Dim SchoolData As New Class_SchoolData
    Dim SQL As New Class_SQLCommands
    Dim StudentData As New Class_StudentData
    Dim VisitData As New Class_VisitData
    Dim VisitID As Integer = VisitData.GetVisitID
    Dim SchoolHeader As New Class_SchoolHeader
    Dim dayOfWeek = CInt(DateTime.Today.DayOfWeek)
    Dim MondayVisitDate = DateTime.Today.AddDays(-1 * dayOfWeek + 1)
    Dim TuesdayVisitDate = DateTime.Today.AddDays(2 - dayOfWeek)
    Dim WednesdayVisitDate = DateTime.Today.AddDays(3 - dayOfWeek)
    Dim ThursdayVisitDate = DateTime.Today.AddDays(4 - dayOfWeek)
    Dim FridayVisitDate = DateTime.Today.AddDays(5 - dayOfWeek)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Username As String = Session("username")
        Dim apiKey As String = "a4e3d706b2dbc3eaf740fa64ea113707"
        Dim location As String = "Largo, FL"
        Dim apiEndPoint As String = "api.openweathermap.org"

        'Checks if the user is logged in and if not it redirects to the login page
        If Session("LoggedIn") <> "1" Then
            Response.Redirect("../default.aspx")
        End If

        If Not (IsPostBack) Then

            'Assign visit ID to label and hf
            If VisitID <> 0 Then
                visitdate_hf.Value = VisitID
                visitID_lbl.Text = VisitID
            End If

            'Assign current date to label
            visitDate_lbl.Text = FormatDateTime(Now, DateFormat.ShortDate)

            'Populating school header and labels
            headerSchoolName_lbl.Text = SchoolHeader.GetSchoolHeader()
            schoolName_lbl.Text = SchoolHeader.GetSchoolHeader()

            'Assign student count to label
            count_lbl.Text = StudentData.GetStudentCount(visitDate_lbl.Text)

            'Check if bookkeeper / tech tech / director is logged in
            'If SQL.GetUserJob(Username) = "Bookkeeper" Or SQL.GetUserJob(Username) = "Technology Technician" Or SQL.GetUserJob(Username) = "Director" Then
            '    LinkButton33.Visible = True
            'Else
            '    LinkButton33.Visible = False
            'End If

            'Load calendar
            Calendar()

            'Load current weather
            'Using client As New HttpClient()
            '    Dim queryParams As String = $"?key={apiKey}&location={location}"
            '    Dim response As HttpResponseMessage = client.GetAsync($"{apiEndPoint}{queryParams}").Result

            '    If response.IsSuccessStatusCode Then
            '        Dim jsonResponse As String = response.Content.ReadAsStringAsync().Result
            '        Dim weatherData As WeatherResponse = JsonSerializer.Deserialize(Of WeatherResponse)(jsonResponse)
            '    End If
            'End Using
            'temperature_lbl.Text = $"Temperature: {weatherData.Days(0).Temp2m}"

        End If

    End Sub

    Sub Calendar()
        'Basically, what this is doing is getting the current day of the week (sun-sat) represented by a number (0-6) and doing some calculation to figure out how many days to add or subtract from the current date to get the dates of the rest of the week. Then it's just extracting the day number from the full date to apply to the labels. 
        Dim MondayNumber = DateTime.Today.AddDays(-1 * dayOfWeek + 1).Day
        Dim TuesdayNumber = DateTime.Today.AddDays(2 - dayOfWeek).Day
        Dim WednesdayNumber = DateTime.Today.AddDays(3 - dayOfWeek).Day
        Dim ThursdayNumber = DateTime.Today.AddDays(4 - dayOfWeek).Day
        Dim FridayNumber = DateTime.Today.AddDays(5 - dayOfWeek).Day
        Dim TodayNumber = DateTime.Today.Day

        'Assign labels to calendar numbers
        monday_lbl.Text = MondayNumber
        tuesday_lbl.Text = TuesdayNumber
        wednesday_lbl.Text = WednesdayNumber
        thursday_lbl.Text = ThursdayNumber
        friday_lbl.Text = FridayNumber

        'If current day matches the number, change the font color to red
        If TodayNumber = MondayNumber Then
            monday_lbl.ForeColor = System.Drawing.Color.Red
        ElseIf TodayNumber = TuesdayNumber Then
            tuesday_lbl.ForeColor = System.Drawing.Color.Red
        ElseIf TodayNumber = WednesdayNumber Then
            wednesday_lbl.ForeColor = System.Drawing.Color.Red
        ElseIf TodayNumber = ThursdayNumber Then
            thursday_lbl.ForeColor = System.Drawing.Color.Red
        ElseIf TodayNumber = FridayNumber Then
            friday_lbl.ForeColor = System.Drawing.Color.Red
        End If

        'Assign school names to buttons - Monday
        Try
            mondaySchool1_btn.Text = SchoolData.GetSchoolsIndividual(MondayVisitDate).School1.TrimEnd(" ")
            mondaySchool2_btn.Text = SchoolData.GetSchoolsIndividual(MondayVisitDate).School2.TrimEnd(" ")
            mondaySchool3_btn.Text = SchoolData.GetSchoolsIndividual(MondayVisitDate).School3.TrimEnd(" ")
            mondaySchool4_btn.Text = SchoolData.GetSchoolsIndividual(MondayVisitDate).School4.TrimEnd(" ")
            mondaySchool5_btn.Text = SchoolData.GetSchoolsIndividual(MondayVisitDate).School5.TrimEnd(" ")
        Catch
            error_lbl.Text = "Error in Calendar. Cannot get monday's school names."
            Exit Sub
        End Try

        'Assign school names to buttons - Tuesday
        Try
            tuesdaySchool1_btn.Text = SchoolData.GetSchoolsIndividual(TuesdayVisitDate).School1.TrimEnd(" ")
            tuesdaySchool2_btn.Text = SchoolData.GetSchoolsIndividual(TuesdayVisitDate).School2.TrimEnd(" ")
            tuesdaySchool3_btn.Text = SchoolData.GetSchoolsIndividual(TuesdayVisitDate).School3.TrimEnd(" ")
            tuesdaySchool4_btn.Text = SchoolData.GetSchoolsIndividual(TuesdayVisitDate).School4.TrimEnd(" ")
            tuesdaySchool5_btn.Text = SchoolData.GetSchoolsIndividual(TuesdayVisitDate).School5.TrimEnd(" ")
        Catch
            error_lbl.Text = "Error in Calendar. Cannot get tuesday's school names."
            Exit Sub
        End Try

        'Assign school names to buttons - Wednesday
        Try
            wednesdaySchool1_btn.Text = SchoolData.GetSchoolsIndividual(WednesdayVisitDate).School1.TrimEnd(" ")
            wednesdaySchool2_btn.Text = SchoolData.GetSchoolsIndividual(WednesdayVisitDate).School2.TrimEnd(" ")
            wednesdaySchool3_btn.Text = SchoolData.GetSchoolsIndividual(WednesdayVisitDate).School3.TrimEnd(" ")
            wednesdaySchool4_btn.Text = SchoolData.GetSchoolsIndividual(WednesdayVisitDate).School4.TrimEnd(" ")
            wednesdaySchool5_btn.Text = SchoolData.GetSchoolsIndividual(WednesdayVisitDate).School5.TrimEnd(" ")
        Catch
            error_lbl.Text = "Error in Calendar. Cannot get wednesday's school names."
            Exit Sub
        End Try

        'Assign school names to buttons - Thursday
        Try
            thursdaySchool1_btn.Text = SchoolData.GetSchoolsIndividual(ThursdayVisitDate).School1.TrimEnd(" ")
            thursdaySchool2_btn.Text = SchoolData.GetSchoolsIndividual(ThursdayVisitDate).School2.TrimEnd(" ")
            thursdaySchool3_btn.Text = SchoolData.GetSchoolsIndividual(ThursdayVisitDate).School3.TrimEnd(" ")
            thursdaySchool4_btn.Text = SchoolData.GetSchoolsIndividual(ThursdayVisitDate).School4.TrimEnd(" ")
            thursdaySchool5_btn.Text = SchoolData.GetSchoolsIndividual(ThursdayVisitDate).School5.TrimEnd(" ")
        Catch
            error_lbl.Text = "Error in Calendar. Cannot get thursday's school names."
            Exit Sub
        End Try

        'Assign school names to buttons - Friday
        Try
            fridaySchool1_btn.Text = SchoolData.GetSchoolsIndividual(FridayVisitDate).School1.TrimEnd(" ")
            fridaySchool2_btn.Text = SchoolData.GetSchoolsIndividual(FridayVisitDate).School2.TrimEnd(" ")
            fridaySchool3_btn.Text = SchoolData.GetSchoolsIndividual(FridayVisitDate).School3.TrimEnd(" ")
            fridaySchool4_btn.Text = SchoolData.GetSchoolsIndividual(FridayVisitDate).School4.TrimEnd(" ")
            fridaySchool5_btn.Text = SchoolData.GetSchoolsIndividual(FridayVisitDate).School5.TrimEnd(" ")
        Catch
            error_lbl.Text = "Error in Calendar. Cannot get friday's school names."
            Exit Sub
        End Try

        'Make buttons with school names visible
        Try
            If mondaySchool1_btn.Text <> Nothing Then
                mondaySchool1_btn.Visible = True
            End If

            If mondaySchool2_btn.Text <> Nothing Then
                mondaySchool2_btn.Visible = True
            End If

            If mondaySchool3_btn.Text <> Nothing Then
                mondaySchool3_btn.Visible = True
            End If

            If mondaySchool4_btn.Text <> Nothing Then
                mondaySchool4_btn.Visible = True
            End If

            If mondaySchool5_btn.Text <> Nothing Then
                mondaySchool5_btn.Visible = True
            End If

            If tuesdaySchool1_btn.Text <> Nothing Then
                tuesdaySchool1_btn.Visible = True
            End If

            If tuesdaySchool2_btn.Text <> Nothing Then
                tuesdaySchool2_btn.Visible = True
            End If

            If tuesdaySchool3_btn.Text <> Nothing Then
                tuesdaySchool3_btn.Visible = True
            End If

            If tuesdaySchool4_btn.Text <> Nothing Then
                tuesdaySchool4_btn.Visible = True
            End If

            If tuesdaySchool5_btn.Text <> Nothing Then
                tuesdaySchool5_btn.Visible = True
            End If

            If wednesdaySchool1_btn.Text <> Nothing Then
                wednesdaySchool1_btn.Visible = True
            End If

            If wednesdaySchool2_btn.Text <> Nothing Then
                wednesdaySchool2_btn.Visible = True
            End If

            If wednesdaySchool3_btn.Text <> Nothing Then
                wednesdaySchool3_btn.Visible = True
            End If

            If wednesdaySchool4_btn.Text <> Nothing Then
                wednesdaySchool4_btn.Visible = True
            End If

            If wednesdaySchool5_btn.Text <> Nothing Then
                wednesdaySchool5_btn.Visible = True
            End If

            If thursdaySchool1_btn.Text <> Nothing Then
                thursdaySchool1_btn.Visible = True
            End If

            If thursdaySchool2_btn.Text <> Nothing Then
                thursdaySchool2_btn.Visible = True
            End If

            If thursdaySchool3_btn.Text <> Nothing Then
                thursdaySchool3_btn.Visible = True
            End If

            If thursdaySchool4_btn.Text <> Nothing Then
                thursdaySchool4_btn.Visible = True
            End If

            If thursdaySchool5_btn.Text <> Nothing Then
                thursdaySchool5_btn.Visible = True
            End If

            If fridaySchool1_btn.Text <> Nothing Then
                fridaySchool1_btn.Visible = True
            End If

            If fridaySchool2_btn.Text <> Nothing Then
                fridaySchool2_btn.Visible = True
            End If

            If fridaySchool3_btn.Text <> Nothing Then
                fridaySchool3_btn.Visible = True
            End If

            If fridaySchool4_btn.Text <> Nothing Then
                fridaySchool4_btn.Visible = True
            End If

            If fridaySchool5_btn.Text <> Nothing Then
                fridaySchool5_btn.Visible = True
            End If

        Catch
            error_lbl.Text = "Error in Calendar. Cannot make buttons visible."
            Exit Sub
        End Try

    End Sub

    Sub DayButton(SchoolName As String, VisitDate As String)
        Dim SchoolID As String
        Dim VisitID As String

        'Get school id from school name
        SchoolID = SchoolData.GetSchoolID(SchoolName)

        'Get visitID of date
        VisitID = VisitData.GetVisitIDFromDate(VisitDate)

        'Link to student report
        Response.Redirect("~/pages/reports/employee_report.aspx?b=" & VisitID & "&c=" & SchoolID)
    End Sub

    Protected Sub LinkButton24_Click(sender As Object, e As EventArgs) Handles LinkButton24.Click
        HttpContext.Current.Session.Abandon()
        Response.Redirect("../../default.aspx")
    End Sub

    Protected Sub mondaySchool1_btn_Click(sender As Object, e As EventArgs) Handles mondaySchool1_btn.Click
        DayButton(mondaySchool1_btn.Text, MondayVisitDate)
    End Sub

    Protected Sub mondaySchool2_btn_Click(sender As Object, e As EventArgs) Handles mondaySchool2_btn.Click
        DayButton(mondaySchool2_btn.Text, MondayVisitDate)
    End Sub

    Protected Sub mondaySchool3_btn_Click(sender As Object, e As EventArgs) Handles mondaySchool3_btn.Click
        DayButton(mondaySchool3_btn.Text, MondayVisitDate)
    End Sub

    Protected Sub mondaySchool4_btn_Click(sender As Object, e As EventArgs) Handles mondaySchool4_btn.Click
        DayButton(mondaySchool4_btn.Text, MondayVisitDate)
    End Sub

    Protected Sub mondaySchool5_btn_Click(sender As Object, e As EventArgs) Handles mondaySchool5_btn.Click
        DayButton(mondaySchool5_btn.Text, MondayVisitDate)
    End Sub

    Protected Sub tuesdaySchool1_btn_Click(sender As Object, e As EventArgs) Handles tuesdaySchool1_btn.Click
        DayButton(tuesdaySchool1_btn.Text, TuesdayVisitDate)
    End Sub
    Protected Sub tuesdaySchool2_btn_Click(sender As Object, e As EventArgs) Handles tuesdaySchool2_btn.Click
        DayButton(tuesdaySchool2_btn.Text, TuesdayVisitDate)
    End Sub

    Protected Sub tuesdaySchool3_btn_Click(sender As Object, e As EventArgs) Handles tuesdaySchool3_btn.Click
        DayButton(tuesdaySchool3_btn.Text, TuesdayVisitDate)
    End Sub

    Protected Sub tuesdaySchool4_btn_Click(sender As Object, e As EventArgs) Handles tuesdaySchool4_btn.Click
        DayButton(tuesdaySchool4_btn.Text, TuesdayVisitDate)
    End Sub

    Protected Sub tuesdaySchool5_btn_Click(sender As Object, e As EventArgs) Handles tuesdaySchool5_btn.Click
        DayButton(tuesdaySchool5_btn.Text, TuesdayVisitDate)
    End Sub

    Protected Sub wednesdaySchool1_btn_Click(sender As Object, e As EventArgs) Handles wednesdaySchool1_btn.Click
        DayButton(wednesdaySchool1_btn.Text, WednesdayVisitDate)
    End Sub

    Protected Sub wednesdaySchool2_btn_Click(sender As Object, e As EventArgs) Handles wednesdaySchool2_btn.Click
        DayButton(wednesdaySchool2_btn.Text, WednesdayVisitDate)
    End Sub

    Protected Sub wednesdaySchool3_btn_Click(sender As Object, e As EventArgs) Handles wednesdaySchool3_btn.Click
        DayButton(wednesdaySchool3_btn.Text, WednesdayVisitDate)
    End Sub

    Protected Sub wednesdaySchool4_btn_Click(sender As Object, e As EventArgs) Handles wednesdaySchool4_btn.Click
        DayButton(wednesdaySchool4_btn.Text, WednesdayVisitDate)
    End Sub

    Protected Sub wednesdaySchool5_btn_Click(sender As Object, e As EventArgs) Handles wednesdaySchool5_btn.Click
        DayButton(wednesdaySchool5_btn.Text, WednesdayVisitDate)
    End Sub

    Protected Sub thursdaySchool1_btn_Click(sender As Object, e As EventArgs) Handles thursdaySchool1_btn.Click
        DayButton(thursdaySchool1_btn.Text, ThursdayVisitDate)
    End Sub

    Protected Sub thursdaySchool2_btn_Click(sender As Object, e As EventArgs) Handles thursdaySchool2_btn.Click
        DayButton(thursdaySchool2_btn.Text, ThursdayVisitDate)
    End Sub

    Protected Sub thursdaySchool3_btn_Click(sender As Object, e As EventArgs) Handles thursdaySchool3_btn.Click
        DayButton(thursdaySchool3_btn.Text, ThursdayVisitDate)
    End Sub

    Protected Sub thursdaySchool4_btn_Click(sender As Object, e As EventArgs) Handles thursdaySchool4_btn.Click
        DayButton(thursdaySchool4_btn.Text, ThursdayVisitDate)
    End Sub

    Protected Sub thursdaySchool5_btn_Click(sender As Object, e As EventArgs) Handles thursdaySchool5_btn.Click
        DayButton(thursdaySchool5_btn.Text, ThursdayVisitDate)
    End Sub

    Protected Sub fridaySchool1_btn_Click(sender As Object, e As EventArgs) Handles fridaySchool1_btn.Click
        DayButton(fridaySchool1_btn.Text, FridayVisitDate)
    End Sub

    Protected Sub fridaySchool2_btn_Click(sender As Object, e As EventArgs) Handles fridaySchool2_btn.Click
        DayButton(fridaySchool2_btn.Text, FridayVisitDate)
    End Sub

    Protected Sub fridaySchool3_btn_Click(sender As Object, e As EventArgs) Handles fridaySchool3_btn.Click
        DayButton(fridaySchool3_btn.Text, FridayVisitDate)
    End Sub

    Protected Sub fridaySchool4_btn_Click(sender As Object, e As EventArgs) Handles fridaySchool4_btn.Click
        DayButton(fridaySchool4_btn.Text, FridayVisitDate)
    End Sub

    Protected Sub fridaySchool5_btn_Click(sender As Object, e As EventArgs) Handles fridaySchool5_btn.Click
        DayButton(fridaySchool5_btn.Text, FridayVisitDate)
    End Sub
End Class