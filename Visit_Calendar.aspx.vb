Imports System.IO
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Globalization

Public Class Visit_Calendar
	Inherits System.Web.UI.Page
	Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
	Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
	Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
	Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
	Dim con As New SqlConnection
	Dim cmd As New SqlCommand
	Dim dr As SqlDataReader
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
    Dim SchoolData As New Class_SchoolData
    Dim VisitData As New Class_VisitData
    Dim VisitID As Integer = VisitData.GetVisitID
    Dim dayOfWeek = CInt(DateTime.Today.DayOfWeek)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("LoggedIn") <> "1" Then
            Response.Redirect(".\default.aspx")
        End If

        If Not (IsPostBack) Then
            'Assign current visit ID to hidden field
            If VisitID <> 0 Then
                currentVisitID_hf.Value = VisitID
            End If

            'Populating school header
            Dim header As New Class_SchoolHeader
            headerSchoolName_lbl.Text = header.GetSchoolHeader()

        End If
    End Sub

    Sub FirstWeek(MonthPassed As String)

        'Converts the month name in a string to a number
        Dim MonthNumber As String = DateTime.ParseExact(MonthPassed, "MMMM", CultureInfo.CurrentCulture).Month

        'Gets the 1st of the month, each week after the start, and the end date
        Dim StartDate = New DateTime(Now.Year, MonthNumber, 1)

        'Gets what day (sun-sat, in a number between 0-6) the beginning of the month is on
        Dim StartDayOfTheWeek = CInt(StartDate.DayOfWeek)

        'Gets the full date of each day of the week (ie 11/13/2023)
        Dim MondayVisitDate = StartDate.AddDays(-1 * StartDayOfTheWeek + 1)  'Basically, what this is doing is getting the current day of the week (sun-sat) represented by a number (0-6) and doing ome calculation to figure out how many days to add or subtract from the current date to get the dates of the rest of the week. Then it's just extracting the day number from the full date to apply to the labels.
        Dim TuesdayVisitDate = StartDate.AddDays(2 - StartDayOfTheWeek)
        Dim WednesdayVisitDate = StartDate.AddDays(3 - StartDayOfTheWeek)
        Dim ThursdayVisitDate = StartDate.AddDays(4 - StartDayOfTheWeek)
        Dim FridayVisitDate = StartDate.AddDays(5 - StartDayOfTheWeek)

        'Gets the day number of the days of the week (ie 1-31)
        Dim MondayNumber = MondayVisitDate.Day
        Dim TuesdayNumber = TuesdayVisitDate.Day
        Dim WednesdayNumber = WednesdayVisitDate.Day
        Dim ThursdayNumber = ThursdayVisitDate.Day
        Dim FridayNumber = FridayVisitDate.Day

        'Get today's day number
        Dim TodayNumber = DateTime.Today.Day
        Dim TodayMonth = MonthName(DateTime.Today.Month)

        'For testing
        'error_lbl.Text = "StartDate: " & StartDate & " StartDayOfWeek: " & StartDayOfTheWeek & " MondayVisitDate: " & MondayVisitDate

        'Make buttons invisible
        InvisibleButtons()

        'Assign labels to calendar numbers
        monday1_lbl.Text = MondayNumber
        tuesday1_lbl.Text = TuesdayNumber
        wednesday1_lbl.Text = WednesdayNumber
        thursday1_lbl.Text = ThursdayNumber
        friday1_lbl.Text = FridayNumber

        'If current month and day matches the selected month and current day number, change the font color to red
        If TodayMonth = MonthPassed Then
            If TodayNumber = MondayNumber Then
                monday1_lbl.ForeColor = System.Drawing.Color.Red
            ElseIf TodayNumber = TuesdayNumber Then
                tuesday1_lbl.ForeColor = System.Drawing.Color.Red
            ElseIf TodayNumber = WednesdayNumber Then
                wednesday1_lbl.ForeColor = System.Drawing.Color.Red
            ElseIf TodayNumber = ThursdayNumber Then
                thursday1_lbl.ForeColor = System.Drawing.Color.Red
            ElseIf TodayNumber = FridayNumber Then
                friday1_lbl.ForeColor = System.Drawing.Color.Red
            End If
        End If

        'Assign school names to buttons - Monday
        Try
            monday1School1_btn.Text = SchoolData.GetSchoolsIndividual(MondayVisitDate).School1.TrimEnd(" ")
            monday1School2_btn.Text = SchoolData.GetSchoolsIndividual(MondayVisitDate).School2.TrimEnd(" ")
            monday1School3_btn.Text = SchoolData.GetSchoolsIndividual(MondayVisitDate).School3.TrimEnd(" ")
            monday1School4_btn.Text = SchoolData.GetSchoolsIndividual(MondayVisitDate).School4.TrimEnd(" ")
            monday1School5_btn.Text = SchoolData.GetSchoolsIndividual(MondayVisitDate).School5.TrimEnd(" ")
        Catch
            error_lbl.Text = "Error in Calendar. Cannot get monday's school names."
            Exit Sub
        End Try

        'Assign school names to buttons - Tuesday
        Try
            tuesday1School1_btn.Text = SchoolData.GetSchoolsIndividual(TuesdayVisitDate).School1.TrimEnd(" ")
            tuesday1School2_btn.Text = SchoolData.GetSchoolsIndividual(TuesdayVisitDate).School2.TrimEnd(" ")
            tuesday1School3_btn.Text = SchoolData.GetSchoolsIndividual(TuesdayVisitDate).School3.TrimEnd(" ")
            tuesday1School4_btn.Text = SchoolData.GetSchoolsIndividual(TuesdayVisitDate).School4.TrimEnd(" ")
            tuesday1School5_btn.Text = SchoolData.GetSchoolsIndividual(TuesdayVisitDate).School5.TrimEnd(" ")
        Catch
            error_lbl.Text = "Error in Calendar. Cannot get tuesday's school names."
            Exit Sub
        End Try

        'Assign school names to buttons - Wednesday
        Try
            wednesday1School1_btn.Text = SchoolData.GetSchoolsIndividual(WednesdayVisitDate).School1.TrimEnd(" ")
            wednesday1School2_btn.Text = SchoolData.GetSchoolsIndividual(WednesdayVisitDate).School2.TrimEnd(" ")
            wednesday1School3_btn.Text = SchoolData.GetSchoolsIndividual(WednesdayVisitDate).School3.TrimEnd(" ")
            wednesday1School4_btn.Text = SchoolData.GetSchoolsIndividual(WednesdayVisitDate).School4.TrimEnd(" ")
            wednesday1School5_btn.Text = SchoolData.GetSchoolsIndividual(WednesdayVisitDate).School5.TrimEnd(" ")
        Catch
            error_lbl.Text = "Error in Calendar. Cannot get wednesday's school names."
            Exit Sub
        End Try

        'Assign school names to buttons - Thursday
        Try
            thursday1School1_btn.Text = SchoolData.GetSchoolsIndividual(ThursdayVisitDate).School1.TrimEnd(" ")
            thursday1School2_btn.Text = SchoolData.GetSchoolsIndividual(ThursdayVisitDate).School2.TrimEnd(" ")
            thursday1School3_btn.Text = SchoolData.GetSchoolsIndividual(ThursdayVisitDate).School3.TrimEnd(" ")
            thursday1School4_btn.Text = SchoolData.GetSchoolsIndividual(ThursdayVisitDate).School4.TrimEnd(" ")
            thursday1School5_btn.Text = SchoolData.GetSchoolsIndividual(ThursdayVisitDate).School5.TrimEnd(" ")
        Catch
            error_lbl.Text = "Error in Calendar. Cannot get thursday's school names."
            Exit Sub
        End Try

        'Assign school names to buttons - Friday
        Try
            friday1School1_btn.Text = SchoolData.GetSchoolsIndividual(FridayVisitDate).School1.TrimEnd(" ")
            friday1School2_btn.Text = SchoolData.GetSchoolsIndividual(FridayVisitDate).School2.TrimEnd(" ")
            friday1School3_btn.Text = SchoolData.GetSchoolsIndividual(FridayVisitDate).School3.TrimEnd(" ")
            friday1School4_btn.Text = SchoolData.GetSchoolsIndividual(FridayVisitDate).School4.TrimEnd(" ")
            friday1School5_btn.Text = SchoolData.GetSchoolsIndividual(FridayVisitDate).School5.TrimEnd(" ")
        Catch
            error_lbl.Text = "Error in Calendar. Cannot get friday's school names."
            Exit Sub
        End Try

        'Make buttons with school names visible
        Try
            If monday1School1_btn.Text <> Nothing Then
                monday1School1_btn.Visible = True
            End If

            If monday1School2_btn.Text <> Nothing Then
                monday1School2_btn.Visible = True
            End If

            If monday1School3_btn.Text <> Nothing Then
                monday1School3_btn.Visible = True
            End If

            If monday1School4_btn.Text <> Nothing Then
                monday1School4_btn.Visible = True
            End If

            If monday1School5_btn.Text <> Nothing Then
                monday1School5_btn.Visible = True
            End If

            If tuesday1School1_btn.Text <> Nothing Then
                tuesday1School1_btn.Visible = True
            End If

            If tuesday1School2_btn.Text <> Nothing Then
                tuesday1School2_btn.Visible = True
            End If

            If tuesday1School3_btn.Text <> Nothing Then
                tuesday1School3_btn.Visible = True
            End If

            If tuesday1School4_btn.Text <> Nothing Then
                tuesday1School4_btn.Visible = True
            End If

            If tuesday1School5_btn.Text <> Nothing Then
                tuesday1School5_btn.Visible = True
            End If

            If wednesday1School1_btn.Text <> Nothing Then
                wednesday1School1_btn.Visible = True
            End If

            If wednesday1School2_btn.Text <> Nothing Then
                wednesday1School2_btn.Visible = True
            End If

            If wednesday1School3_btn.Text <> Nothing Then
                wednesday1School3_btn.Visible = True
            End If

            If wednesday1School4_btn.Text <> Nothing Then
                wednesday1School4_btn.Visible = True
            End If

            If wednesday1School5_btn.Text <> Nothing Then
                wednesday1School5_btn.Visible = True
            End If

            If thursday1School1_btn.Text <> Nothing Then
                thursday1School1_btn.Visible = True
            End If

            If thursday1School2_btn.Text <> Nothing Then
                thursday1School2_btn.Visible = True
            End If

            If thursday1School3_btn.Text <> Nothing Then
                thursday1School3_btn.Visible = True
            End If

            If thursday1School4_btn.Text <> Nothing Then
                thursday1School4_btn.Visible = True
            End If

            If thursday1School5_btn.Text <> Nothing Then
                thursday1School5_btn.Visible = True
            End If

            If friday1School1_btn.Text <> Nothing Then
                friday1School1_btn.Visible = True
            End If

            If friday1School2_btn.Text <> Nothing Then
                friday1School2_btn.Visible = True
            End If

            If friday1School3_btn.Text <> Nothing Then
                friday1School3_btn.Visible = True
            End If

            If friday1School4_btn.Text <> Nothing Then
                friday1School4_btn.Visible = True
            End If

            If friday1School5_btn.Text <> Nothing Then
                friday1School5_btn.Visible = True
            End If

        Catch
            error_lbl.Text = "Error in Calendar. Cannot make buttons visible."
            Exit Sub
        End Try

        'Loads data for week 2
        SecondWeek(MonthPassed)

    End Sub

    Sub SecondWeek(MonthPassed As String)

        'Converts the month name in a string to a number
        Dim MonthNumber As String = DateTime.ParseExact(MonthPassed, "MMMM", CultureInfo.CurrentCulture).Month

        'Gets the 1st of the month, each week after the start, and the end date
        Dim StartDate = New DateTime(Now.Year, MonthNumber, 1)
        Dim Week2StartDate = StartDate.AddDays(7)
        Dim EndDate = StartDate.AddMonths(1).AddDays(-1)

        'Gets what day (sun-sat, in a number between 0-6) the beginning of the month is on
        Dim Week2StartDayOfTheWeek = CInt(Week2StartDate.DayOfWeek)

        'Gets the full date of each day of the week (ie 11/13/2023)
        Dim MondayVisitDate = Week2StartDate.AddDays(-1 * Week2StartDayOfTheWeek + 1)  'Basically, what this is doing is getting the current day of the week (sun-sat) represented by a number (0-6) and doing ome calculation to figure out how many days to add or subtract from the current date to get the dates of the rest of the week. Then it's just extracting the day number from the full date to apply to the labels.
        Dim TuesdayVisitDate = Week2StartDate.AddDays(2 - Week2StartDayOfTheWeek)
        Dim WednesdayVisitDate = Week2StartDate.AddDays(3 - Week2StartDayOfTheWeek)
        Dim ThursdayVisitDate = Week2StartDate.AddDays(4 - Week2StartDayOfTheWeek)
        Dim FridayVisitDate = Week2StartDate.AddDays(5 - Week2StartDayOfTheWeek)

        'Gets the day number of the days of the week (ie 1-31)
        Dim MondayNumber = MondayVisitDate.Day
        Dim TuesdayNumber = TuesdayVisitDate.Day
        Dim WednesdayNumber = WednesdayVisitDate.Day
        Dim ThursdayNumber = ThursdayVisitDate.Day
        Dim FridayNumber = FridayVisitDate.Day

        'Get today's day number
        Dim TodayNumber = DateTime.Today.Day
        Dim TodayMonth = MonthName(DateTime.Today.Month)

        'For testing
        'error_lbl.Text = "Week2StartDate: " & Week2StartDate & " StartDayOfWeek: " & Week2StartDayOfTheWeek & " MondayVisitDate: " & MondayVisitDate

        'Assign labels to calendar numbers
        monday2_lbl.Text = MondayNumber
        tuesday2_lbl.Text = TuesdayNumber
        wednesday2_lbl.Text = WednesdayNumber
        thursday2_lbl.Text = ThursdayNumber
        friday2_lbl.Text = FridayNumber

        'If current month and day matches the selected month and current day number, change the font color to red
        If TodayMonth = MonthPassed Then
            If TodayNumber = MondayNumber Then
                monday2_lbl.ForeColor = System.Drawing.Color.Red
            ElseIf TodayNumber = TuesdayNumber Then
                tuesday2_lbl.ForeColor = System.Drawing.Color.Red
            ElseIf TodayNumber = WednesdayNumber Then
                wednesday2_lbl.ForeColor = System.Drawing.Color.Red
            ElseIf TodayNumber = ThursdayNumber Then
                thursday2_lbl.ForeColor = System.Drawing.Color.Red
            ElseIf TodayNumber = FridayNumber Then
                friday2_lbl.ForeColor = System.Drawing.Color.Red
            End If
        End If

        'Assign school names to buttons - Monday
        Try
            monday2School1_btn.Text = SchoolData.GetSchoolsIndividual(MondayVisitDate).School1.TrimEnd(" ")
            monday2School2_btn.Text = SchoolData.GetSchoolsIndividual(MondayVisitDate).School2.TrimEnd(" ")
            monday2School3_btn.Text = SchoolData.GetSchoolsIndividual(MondayVisitDate).School3.TrimEnd(" ")
            monday2School4_btn.Text = SchoolData.GetSchoolsIndividual(MondayVisitDate).School4.TrimEnd(" ")
            monday2School5_btn.Text = SchoolData.GetSchoolsIndividual(MondayVisitDate).School5.TrimEnd(" ")
        Catch
            error_lbl.Text = "Error in Calendar. Cannot get monday's school names."
            Exit Sub
        End Try

        'Assign school names to buttons - Tuesday
        Try
            tuesday2School1_btn.Text = SchoolData.GetSchoolsIndividual(TuesdayVisitDate).School1.TrimEnd(" ")
            tuesday2School2_btn.Text = SchoolData.GetSchoolsIndividual(TuesdayVisitDate).School2.TrimEnd(" ")
            tuesday2School3_btn.Text = SchoolData.GetSchoolsIndividual(TuesdayVisitDate).School3.TrimEnd(" ")
            tuesday2School4_btn.Text = SchoolData.GetSchoolsIndividual(TuesdayVisitDate).School4.TrimEnd(" ")
            tuesday2School5_btn.Text = SchoolData.GetSchoolsIndividual(TuesdayVisitDate).School5.TrimEnd(" ")
        Catch
            error_lbl.Text = "Error in Calendar. Cannot get tuesday's school names."
            Exit Sub
        End Try

        'Assign school names to buttons - Wednesday
        Try
            wednesday2School1_btn.Text = SchoolData.GetSchoolsIndividual(WednesdayVisitDate).School1.TrimEnd(" ")
            wednesday2School2_btn.Text = SchoolData.GetSchoolsIndividual(WednesdayVisitDate).School2.TrimEnd(" ")
            wednesday2School3_btn.Text = SchoolData.GetSchoolsIndividual(WednesdayVisitDate).School3.TrimEnd(" ")
            wednesday2School4_btn.Text = SchoolData.GetSchoolsIndividual(WednesdayVisitDate).School4.TrimEnd(" ")
            wednesday2School5_btn.Text = SchoolData.GetSchoolsIndividual(WednesdayVisitDate).School5.TrimEnd(" ")
        Catch
            error_lbl.Text = "Error in Calendar. Cannot get wednesday's school names."
            Exit Sub
        End Try

        'Assign school names to buttons - Thursday
        Try
            thursday2School1_btn.Text = SchoolData.GetSchoolsIndividual(ThursdayVisitDate).School1.TrimEnd(" ")
            thursday2School2_btn.Text = SchoolData.GetSchoolsIndividual(ThursdayVisitDate).School2.TrimEnd(" ")
            thursday2School3_btn.Text = SchoolData.GetSchoolsIndividual(ThursdayVisitDate).School3.TrimEnd(" ")
            thursday2School4_btn.Text = SchoolData.GetSchoolsIndividual(ThursdayVisitDate).School4.TrimEnd(" ")
            thursday2School5_btn.Text = SchoolData.GetSchoolsIndividual(ThursdayVisitDate).School5.TrimEnd(" ")
        Catch
            error_lbl.Text = "Error in Calendar. Cannot get thursday's school names."
            Exit Sub
        End Try

        'Assign school names to buttons - Friday
        Try
            friday2School1_btn.Text = SchoolData.GetSchoolsIndividual(FridayVisitDate).School1.TrimEnd(" ")
            friday2School2_btn.Text = SchoolData.GetSchoolsIndividual(FridayVisitDate).School2.TrimEnd(" ")
            friday2School3_btn.Text = SchoolData.GetSchoolsIndividual(FridayVisitDate).School3.TrimEnd(" ")
            friday2School4_btn.Text = SchoolData.GetSchoolsIndividual(FridayVisitDate).School4.TrimEnd(" ")
            friday2School5_btn.Text = SchoolData.GetSchoolsIndividual(FridayVisitDate).School5.TrimEnd(" ")
        Catch
            error_lbl.Text = "Error in Calendar. Cannot get friday's school names."
            Exit Sub
        End Try

        'Make buttons with school names visible
        Try
            If monday2School1_btn.Text <> Nothing Then
                monday2School1_btn.Visible = True
            End If

            If monday2School2_btn.Text <> Nothing Then
                monday2School2_btn.Visible = True
            End If

            If monday2School3_btn.Text <> Nothing Then
                monday2School3_btn.Visible = True
            End If

            If monday2School4_btn.Text <> Nothing Then
                monday2School4_btn.Visible = True
            End If

            If monday2School5_btn.Text <> Nothing Then
                monday2School5_btn.Visible = True
            End If

            If tuesday2School1_btn.Text <> Nothing Then
                tuesday2School1_btn.Visible = True
            End If

            If tuesday2School2_btn.Text <> Nothing Then
                tuesday2School2_btn.Visible = True
            End If

            If tuesday2School3_btn.Text <> Nothing Then
                tuesday2School3_btn.Visible = True
            End If

            If tuesday2School4_btn.Text <> Nothing Then
                tuesday2School4_btn.Visible = True
            End If

            If tuesday2School5_btn.Text <> Nothing Then
                tuesday2School5_btn.Visible = True
            End If

            If wednesday2School1_btn.Text <> Nothing Then
                wednesday2School1_btn.Visible = True
            End If

            If wednesday2School2_btn.Text <> Nothing Then
                wednesday2School2_btn.Visible = True
            End If

            If wednesday2School3_btn.Text <> Nothing Then
                wednesday2School3_btn.Visible = True
            End If

            If wednesday2School4_btn.Text <> Nothing Then
                wednesday2School4_btn.Visible = True
            End If

            If wednesday2School5_btn.Text <> Nothing Then
                wednesday2School5_btn.Visible = True
            End If

            If thursday2School1_btn.Text <> Nothing Then
                thursday2School1_btn.Visible = True
            End If

            If thursday2School2_btn.Text <> Nothing Then
                thursday2School2_btn.Visible = True
            End If

            If thursday2School3_btn.Text <> Nothing Then
                thursday2School3_btn.Visible = True
            End If

            If thursday2School4_btn.Text <> Nothing Then
                thursday2School4_btn.Visible = True
            End If

            If thursday2School5_btn.Text <> Nothing Then
                thursday2School5_btn.Visible = True
            End If

            If friday2School1_btn.Text <> Nothing Then
                friday2School1_btn.Visible = True
            End If

            If friday2School2_btn.Text <> Nothing Then
                friday2School2_btn.Visible = True
            End If

            If friday2School3_btn.Text <> Nothing Then
                friday2School3_btn.Visible = True
            End If

            If friday2School4_btn.Text <> Nothing Then
                friday2School4_btn.Visible = True
            End If

            If friday2School5_btn.Text <> Nothing Then
                friday2School5_btn.Visible = True
            End If

        Catch
            error_lbl.Text = "Error in Calendar. Cannot make buttons visible."
            Exit Sub
        End Try

        'Loads data for week 3
        ThirdWeek(MonthPassed)

    End Sub

    Sub ThirdWeek(MonthPassed As String)

        'Converts the month name in a string to a number
        Dim MonthNumber As String = DateTime.ParseExact(MonthPassed, "MMMM", CultureInfo.CurrentCulture).Month

        'Gets the 1st of the month, each week after the start, and the end date
        Dim StartDate = New DateTime(Now.Year, MonthNumber, 1)
        Dim Week2StartDate = StartDate.AddDays(7)
        Dim Week3StartDate = Week2StartDate.AddDays(7)

        'Gets what day (sun-sat, in a number between 0-6) the beginning of the month is on
        Dim Week3StartDayOfTheWeek = CInt(Week3StartDate.DayOfWeek)

        'Gets the full date of each day of the week (ie 11/13/2023)
        Dim MondayVisitDate = Week3StartDate.AddDays(-1 * Week3StartDayOfTheWeek + 1)  'Basically, what this is doing is getting the current day of the week (sun-sat) represented by a number (0-6) and doing ome calculation to figure out how many days to add or subtract from the current date to get the dates of the rest of the week. Then it's just extracting the day number from the full date to apply to the labels.
        Dim TuesdayVisitDate = Week3StartDate.AddDays(2 - Week3StartDayOfTheWeek)
        Dim WednesdayVisitDate = Week3StartDate.AddDays(3 - Week3StartDayOfTheWeek)
        Dim ThursdayVisitDate = Week3StartDate.AddDays(4 - Week3StartDayOfTheWeek)
        Dim FridayVisitDate = Week3StartDate.AddDays(5 - Week3StartDayOfTheWeek)

        'Gets the day number of the days of the week (ie 1-31)
        Dim MondayNumber = MondayVisitDate.Day
        Dim TuesdayNumber = TuesdayVisitDate.Day
        Dim WednesdayNumber = WednesdayVisitDate.Day
        Dim ThursdayNumber = ThursdayVisitDate.Day
        Dim FridayNumber = FridayVisitDate.Day

        'Get today's day number
        Dim TodayNumber = DateTime.Today.Day
        Dim TodayMonth = MonthName(DateTime.Today.Month)

        'For testing
        'error_lbl.Text = "Week3StartDate: " & Week3StartDate & " StartDayOfWeek: " & Week3StartDayOfTheWeek & " MondayVisitDate: " & MondayVisitDate

        'Assign labels to calendar numbers
        monday3_lbl.Text = MondayNumber
        tuesday3_lbl.Text = TuesdayNumber
        wednesday3_lbl.Text = WednesdayNumber
        thursday3_lbl.Text = ThursdayNumber
        friday3_lbl.Text = FridayNumber

        'If current month and day matches the selected month and current day number, change the font color to red
        If TodayMonth = MonthPassed Then
            If TodayNumber = MondayNumber Then
                monday3_lbl.ForeColor = System.Drawing.Color.Red
            ElseIf TodayNumber = TuesdayNumber Then
                tuesday3_lbl.ForeColor = System.Drawing.Color.Red
            ElseIf TodayNumber = WednesdayNumber Then
                wednesday3_lbl.ForeColor = System.Drawing.Color.Red
            ElseIf TodayNumber = ThursdayNumber Then
                thursday3_lbl.ForeColor = System.Drawing.Color.Red
            ElseIf TodayNumber = FridayNumber Then
                friday3_lbl.ForeColor = System.Drawing.Color.Red
            End If
        End If

        'Assign school names to buttons - Monday
        Try
            monday3School1_btn.Text = SchoolData.GetSchoolsIndividual(MondayVisitDate).School1.TrimEnd(" ")
            monday3School2_btn.Text = SchoolData.GetSchoolsIndividual(MondayVisitDate).School2.TrimEnd(" ")
            monday3School3_btn.Text = SchoolData.GetSchoolsIndividual(MondayVisitDate).School3.TrimEnd(" ")
            monday3School4_btn.Text = SchoolData.GetSchoolsIndividual(MondayVisitDate).School4.TrimEnd(" ")
            monday3School5_btn.Text = SchoolData.GetSchoolsIndividual(MondayVisitDate).School5.TrimEnd(" ")
        Catch
            error_lbl.Text = "Error in Calendar. Cannot get monday's school names."
            Exit Sub
        End Try

        'Assign school names to buttons - Tuesday
        Try
            tuesday3School1_btn.Text = SchoolData.GetSchoolsIndividual(TuesdayVisitDate).School1.TrimEnd(" ")
            tuesday3School2_btn.Text = SchoolData.GetSchoolsIndividual(TuesdayVisitDate).School2.TrimEnd(" ")
            tuesday3School3_btn.Text = SchoolData.GetSchoolsIndividual(TuesdayVisitDate).School3.TrimEnd(" ")
            tuesday3School4_btn.Text = SchoolData.GetSchoolsIndividual(TuesdayVisitDate).School4.TrimEnd(" ")
            tuesday3School5_btn.Text = SchoolData.GetSchoolsIndividual(TuesdayVisitDate).School5.TrimEnd(" ")
        Catch
            error_lbl.Text = "Error in Calendar. Cannot get tuesday's school names."
            Exit Sub
        End Try

        'Assign school names to buttons - Wednesday
        Try
            wednesday3School1_btn.Text = SchoolData.GetSchoolsIndividual(WednesdayVisitDate).School1.TrimEnd(" ")
            wednesday3School2_btn.Text = SchoolData.GetSchoolsIndividual(WednesdayVisitDate).School2.TrimEnd(" ")
            wednesday3School3_btn.Text = SchoolData.GetSchoolsIndividual(WednesdayVisitDate).School3.TrimEnd(" ")
            wednesday3School4_btn.Text = SchoolData.GetSchoolsIndividual(WednesdayVisitDate).School4.TrimEnd(" ")
            wednesday3School5_btn.Text = SchoolData.GetSchoolsIndividual(WednesdayVisitDate).School5.TrimEnd(" ")
        Catch
            error_lbl.Text = "Error in Calendar. Cannot get wednesday's school names."
            Exit Sub
        End Try

        'Assign school names to buttons - Thursday
        Try
            thursday3School1_btn.Text = SchoolData.GetSchoolsIndividual(ThursdayVisitDate).School1.TrimEnd(" ")
            thursday3School2_btn.Text = SchoolData.GetSchoolsIndividual(ThursdayVisitDate).School2.TrimEnd(" ")
            thursday3School3_btn.Text = SchoolData.GetSchoolsIndividual(ThursdayVisitDate).School3.TrimEnd(" ")
            thursday3School4_btn.Text = SchoolData.GetSchoolsIndividual(ThursdayVisitDate).School4.TrimEnd(" ")
            thursday3School5_btn.Text = SchoolData.GetSchoolsIndividual(ThursdayVisitDate).School5.TrimEnd(" ")
        Catch
            error_lbl.Text = "Error in Calendar. Cannot get thursday's school names."
            Exit Sub
        End Try

        'Assign school names to buttons - Friday
        Try
            friday3School1_btn.Text = SchoolData.GetSchoolsIndividual(FridayVisitDate).School1.TrimEnd(" ")
            friday3School2_btn.Text = SchoolData.GetSchoolsIndividual(FridayVisitDate).School2.TrimEnd(" ")
            friday3School3_btn.Text = SchoolData.GetSchoolsIndividual(FridayVisitDate).School3.TrimEnd(" ")
            friday3School4_btn.Text = SchoolData.GetSchoolsIndividual(FridayVisitDate).School4.TrimEnd(" ")
            friday3School5_btn.Text = SchoolData.GetSchoolsIndividual(FridayVisitDate).School5.TrimEnd(" ")
        Catch
            error_lbl.Text = "Error in Calendar. Cannot get friday's school names."
            Exit Sub
        End Try

        'Make buttons with school names visible
        Try
            If monday3School1_btn.Text <> Nothing Then
                monday3School1_btn.Visible = True
            End If

            If monday3School2_btn.Text <> Nothing Then
                monday3School2_btn.Visible = True
            End If

            If monday3School3_btn.Text <> Nothing Then
                monday3School3_btn.Visible = True
            End If

            If monday3School4_btn.Text <> Nothing Then
                monday3School4_btn.Visible = True
            End If

            If monday3School5_btn.Text <> Nothing Then
                monday3School5_btn.Visible = True
            End If

            If tuesday3School1_btn.Text <> Nothing Then
                tuesday3School1_btn.Visible = True
            End If

            If tuesday3School2_btn.Text <> Nothing Then
                tuesday3School2_btn.Visible = True
            End If

            If tuesday3School3_btn.Text <> Nothing Then
                tuesday3School3_btn.Visible = True
            End If

            If tuesday3School4_btn.Text <> Nothing Then
                tuesday3School4_btn.Visible = True
            End If

            If tuesday3School5_btn.Text <> Nothing Then
                tuesday3School5_btn.Visible = True
            End If

            If wednesday3School1_btn.Text <> Nothing Then
                wednesday3School1_btn.Visible = True
            End If

            If wednesday3School2_btn.Text <> Nothing Then
                wednesday3School2_btn.Visible = True
            End If

            If wednesday3School3_btn.Text <> Nothing Then
                wednesday3School3_btn.Visible = True
            End If

            If wednesday3School4_btn.Text <> Nothing Then
                wednesday3School4_btn.Visible = True
            End If

            If wednesday3School5_btn.Text <> Nothing Then
                wednesday3School5_btn.Visible = True
            End If

            If thursday3School1_btn.Text <> Nothing Then
                thursday3School1_btn.Visible = True
            End If

            If thursday3School2_btn.Text <> Nothing Then
                thursday3School2_btn.Visible = True
            End If

            If thursday3School3_btn.Text <> Nothing Then
                thursday3School3_btn.Visible = True
            End If

            If thursday3School4_btn.Text <> Nothing Then
                thursday3School4_btn.Visible = True
            End If

            If thursday3School5_btn.Text <> Nothing Then
                thursday3School5_btn.Visible = True
            End If

            If friday3School1_btn.Text <> Nothing Then
                friday3School1_btn.Visible = True
            End If

            If friday3School2_btn.Text <> Nothing Then
                friday3School2_btn.Visible = True
            End If

            If friday3School3_btn.Text <> Nothing Then
                friday3School3_btn.Visible = True
            End If

            If friday3School4_btn.Text <> Nothing Then
                friday3School4_btn.Visible = True
            End If

            If friday3School5_btn.Text <> Nothing Then
                friday3School5_btn.Visible = True
            End If

        Catch
            error_lbl.Text = "Error in Calendar. Cannot make buttons visible."
            Exit Sub
        End Try

        'Loads data for week 4
        FourthWeek(MonthPassed)

    End Sub

    Sub FourthWeek(MonthPassed As String)

        'Converts the month name in a string to a number
        Dim MonthNumber As String = DateTime.ParseExact(MonthPassed, "MMMM", CultureInfo.CurrentCulture).Month

        'Gets the 1st of the month, each week after the start, and the end date
        Dim StartDate = New DateTime(Now.Year, MonthNumber, 1)
        Dim Week2StartDate = StartDate.AddDays(7)
        Dim Week3StartDate = Week2StartDate.AddDays(7)
        Dim Week4StartDate = Week3StartDate.AddDays(7)

        'Gets what day (sun-sat, in a number between 0-6) the beginning of the month is on
        Dim Week4StartDayOfTheWeek = CInt(Week4StartDate.DayOfWeek)

        'Gets the full date of each day of the week (ie 11/13/2023)
        Dim MondayVisitDate = Week4StartDate.AddDays(-1 * Week4StartDayOfTheWeek + 1)  'Basically, what this is doing is getting the current day of the week (sun-sat) represented by a number (0-6) and doing ome calculation to figure out how many days to add or subtract from the current date to get the dates of the rest of the week. Then it's just extracting the day number from the full date to apply to the labels.
        Dim TuesdayVisitDate = Week4StartDate.AddDays(2 - Week4StartDayOfTheWeek)
        Dim WednesdayVisitDate = Week4StartDate.AddDays(3 - Week4StartDayOfTheWeek)
        Dim ThursdayVisitDate = Week4StartDate.AddDays(4 - Week4StartDayOfTheWeek)
        Dim FridayVisitDate = Week4StartDate.AddDays(5 - Week4StartDayOfTheWeek)

        'Gets the day number of the days of the week (ie 1-31)
        Dim MondayNumber = MondayVisitDate.Day
        Dim TuesdayNumber = TuesdayVisitDate.Day
        Dim WednesdayNumber = WednesdayVisitDate.Day
        Dim ThursdayNumber = ThursdayVisitDate.Day
        Dim FridayNumber = FridayVisitDate.Day

        'Get today's day number
        Dim TodayNumber = DateTime.Today.Day
        Dim TodayMonth = MonthName(DateTime.Today.Month)

        'For testing
        'error_lbl.Text = "Week4StartDate: " & Week4StartDate & " StartDayOfWeek: " & Week4StartDayOfTheWeek & " MondayVisitDate: " & MondayVisitDate

        'Assign labels to calendar numbers
        monday4_lbl.Text = MondayNumber
        tuesday4_lbl.Text = TuesdayNumber
        wednesday4_lbl.Text = WednesdayNumber
        thursday4_lbl.Text = ThursdayNumber
        friday4_lbl.Text = FridayNumber

        'If current month and day matches the selected month and current day number, change the font color to red
        If TodayMonth = MonthPassed Then
            If TodayNumber = MondayNumber Then
                monday4_lbl.ForeColor = System.Drawing.Color.Red
            ElseIf TodayNumber = TuesdayNumber Then
                tuesday4_lbl.ForeColor = System.Drawing.Color.Red
            ElseIf TodayNumber = WednesdayNumber Then
                wednesday4_lbl.ForeColor = System.Drawing.Color.Red
            ElseIf TodayNumber = ThursdayNumber Then
                thursday4_lbl.ForeColor = System.Drawing.Color.Red
            ElseIf TodayNumber = FridayNumber Then
                friday4_lbl.ForeColor = System.Drawing.Color.Red
            End If
        End If

        'Assign school names to buttons - Monday
        Try
            monday4School1_btn.Text = SchoolData.GetSchoolsIndividual(MondayVisitDate).School1.TrimEnd(" ")
            monday4School2_btn.Text = SchoolData.GetSchoolsIndividual(MondayVisitDate).School2.TrimEnd(" ")
            monday4School3_btn.Text = SchoolData.GetSchoolsIndividual(MondayVisitDate).School3.TrimEnd(" ")
            monday4School4_btn.Text = SchoolData.GetSchoolsIndividual(MondayVisitDate).School4.TrimEnd(" ")
            monday4School5_btn.Text = SchoolData.GetSchoolsIndividual(MondayVisitDate).School5.TrimEnd(" ")
        Catch
            error_lbl.Text = "Error in Calendar. Cannot get monday's school names."
            Exit Sub
        End Try

        'Assign school names to buttons - Tuesday
        Try
            tuesday4School1_btn.Text = SchoolData.GetSchoolsIndividual(TuesdayVisitDate).School1.TrimEnd(" ")
            tuesday4School2_btn.Text = SchoolData.GetSchoolsIndividual(TuesdayVisitDate).School2.TrimEnd(" ")
            tuesday4School3_btn.Text = SchoolData.GetSchoolsIndividual(TuesdayVisitDate).School3.TrimEnd(" ")
            tuesday4School4_btn.Text = SchoolData.GetSchoolsIndividual(TuesdayVisitDate).School4.TrimEnd(" ")
            tuesday4School5_btn.Text = SchoolData.GetSchoolsIndividual(TuesdayVisitDate).School5.TrimEnd(" ")
        Catch
            error_lbl.Text = "Error in Calendar. Cannot get tuesday's school names."
            Exit Sub
        End Try

        'Assign school names to buttons - Wednesday
        Try
            wednesday4School1_btn.Text = SchoolData.GetSchoolsIndividual(WednesdayVisitDate).School1.TrimEnd(" ")
            wednesday4School2_btn.Text = SchoolData.GetSchoolsIndividual(WednesdayVisitDate).School2.TrimEnd(" ")
            wednesday4School3_btn.Text = SchoolData.GetSchoolsIndividual(WednesdayVisitDate).School3.TrimEnd(" ")
            wednesday4School4_btn.Text = SchoolData.GetSchoolsIndividual(WednesdayVisitDate).School4.TrimEnd(" ")
            wednesday4School5_btn.Text = SchoolData.GetSchoolsIndividual(WednesdayVisitDate).School5.TrimEnd(" ")
        Catch
            error_lbl.Text = "Error in Calendar. Cannot get wednesday's school names."
            Exit Sub
        End Try

        'Assign school names to buttons - Thursday
        Try
            thursday4School1_btn.Text = SchoolData.GetSchoolsIndividual(ThursdayVisitDate).School1.TrimEnd(" ")
            thursday4School2_btn.Text = SchoolData.GetSchoolsIndividual(ThursdayVisitDate).School2.TrimEnd(" ")
            thursday4School3_btn.Text = SchoolData.GetSchoolsIndividual(ThursdayVisitDate).School3.TrimEnd(" ")
            thursday4School4_btn.Text = SchoolData.GetSchoolsIndividual(ThursdayVisitDate).School4.TrimEnd(" ")
            thursday4School5_btn.Text = SchoolData.GetSchoolsIndividual(ThursdayVisitDate).School5.TrimEnd(" ")
        Catch
            error_lbl.Text = "Error in Calendar. Cannot get thursday's school names."
            Exit Sub
        End Try

        'Assign school names to buttons - Friday
        Try
            friday4School1_btn.Text = SchoolData.GetSchoolsIndividual(FridayVisitDate).School1.TrimEnd(" ")
            friday4School2_btn.Text = SchoolData.GetSchoolsIndividual(FridayVisitDate).School2.TrimEnd(" ")
            friday4School3_btn.Text = SchoolData.GetSchoolsIndividual(FridayVisitDate).School3.TrimEnd(" ")
            friday4School4_btn.Text = SchoolData.GetSchoolsIndividual(FridayVisitDate).School4.TrimEnd(" ")
            friday4School5_btn.Text = SchoolData.GetSchoolsIndividual(FridayVisitDate).School5.TrimEnd(" ")
        Catch
            error_lbl.Text = "Error in Calendar. Cannot get friday's school names."
            Exit Sub
        End Try

        'Make buttons with school names visible
        Try
            If monday4School1_btn.Text <> Nothing Then
                monday4School1_btn.Visible = True
            End If

            If monday4School2_btn.Text <> Nothing Then
                monday4School2_btn.Visible = True
            End If

            If monday4School3_btn.Text <> Nothing Then
                monday4School3_btn.Visible = True
            End If

            If monday4School4_btn.Text <> Nothing Then
                monday4School4_btn.Visible = True
            End If

            If monday4School5_btn.Text <> Nothing Then
                monday4School5_btn.Visible = True
            End If

            If tuesday4School1_btn.Text <> Nothing Then
                tuesday4School1_btn.Visible = True
            End If

            If tuesday4School2_btn.Text <> Nothing Then
                tuesday4School2_btn.Visible = True
            End If

            If tuesday4School3_btn.Text <> Nothing Then
                tuesday4School3_btn.Visible = True
            End If

            If tuesday4School4_btn.Text <> Nothing Then
                tuesday4School4_btn.Visible = True
            End If

            If tuesday4School5_btn.Text <> Nothing Then
                tuesday4School5_btn.Visible = True
            End If

            If wednesday4School1_btn.Text <> Nothing Then
                wednesday4School1_btn.Visible = True
            End If

            If wednesday4School2_btn.Text <> Nothing Then
                wednesday4School2_btn.Visible = True
            End If

            If wednesday4School3_btn.Text <> Nothing Then
                wednesday4School3_btn.Visible = True
            End If

            If wednesday4School4_btn.Text <> Nothing Then
                wednesday4School4_btn.Visible = True
            End If

            If wednesday4School5_btn.Text <> Nothing Then
                wednesday4School5_btn.Visible = True
            End If

            If thursday4School1_btn.Text <> Nothing Then
                thursday4School1_btn.Visible = True
            End If

            If thursday4School2_btn.Text <> Nothing Then
                thursday4School2_btn.Visible = True
            End If

            If thursday4School3_btn.Text <> Nothing Then
                thursday4School3_btn.Visible = True
            End If

            If thursday4School4_btn.Text <> Nothing Then
                thursday4School4_btn.Visible = True
            End If

            If thursday4School5_btn.Text <> Nothing Then
                thursday4School5_btn.Visible = True
            End If

            If friday4School1_btn.Text <> Nothing Then
                friday4School1_btn.Visible = True
            End If

            If friday4School2_btn.Text <> Nothing Then
                friday4School2_btn.Visible = True
            End If

            If friday4School3_btn.Text <> Nothing Then
                friday4School3_btn.Visible = True
            End If

            If friday4School4_btn.Text <> Nothing Then
                friday4School4_btn.Visible = True
            End If

            If friday4School5_btn.Text <> Nothing Then
                friday4School5_btn.Visible = True
            End If

        Catch
            error_lbl.Text = "Error in Calendar. Cannot make buttons visible."
            Exit Sub
        End Try

        'Loads data for week 4
        FifthWeek(MonthPassed)

    End Sub

    Sub FifthWeek(MonthPassed As String)

        'Converts the month name in a string to a number
        Dim MonthNumber As String = DateTime.ParseExact(MonthPassed, "MMMM", CultureInfo.CurrentCulture).Month

        'Gets the 1st of the month, each week after the start, and the end date
        Dim StartDate = New DateTime(Now.Year, MonthNumber, 1)
        Dim Week2StartDate = StartDate.AddDays(7)
        Dim Week3StartDate = Week2StartDate.AddDays(7)
        Dim Week4StartDate = Week3StartDate.AddDays(7)
        Dim Week5StartDate = Week4StartDate.AddDays(7)

        'Gets what day (sun-sat, in a number between 0-6) the beginning of the month is on
        Dim Week5StartDayOfTheWeek = CInt(Week5StartDate.DayOfWeek)

        'Gets the full date of each day of the week (ie 11/13/2023)
        Dim MondayVisitDate = Week5StartDate.AddDays(-1 * Week5StartDayOfTheWeek + 1)  'Basically, what this is doing is getting the current day of the week (sun-sat) represented by a number (0-6) and doing ome calculation to figure out how many days to add or subtract from the current date to get the dates of the rest of the week. Then it's just extracting the day number from the full date to apply to the labels.
        Dim TuesdayVisitDate = Week5StartDate.AddDays(2 - Week5StartDayOfTheWeek)
        Dim WednesdayVisitDate = Week5StartDate.AddDays(3 - Week5StartDayOfTheWeek)
        Dim ThursdayVisitDate = Week5StartDate.AddDays(4 - Week5StartDayOfTheWeek)
        Dim FridayVisitDate = Week5StartDate.AddDays(5 - Week5StartDayOfTheWeek)

        'Gets the day number of the days of the week (ie 1-31)
        Dim MondayNumber = MondayVisitDate.Day
        Dim TuesdayNumber = TuesdayVisitDate.Day
        Dim WednesdayNumber = WednesdayVisitDate.Day
        Dim ThursdayNumber = ThursdayVisitDate.Day
        Dim FridayNumber = FridayVisitDate.Day

        'Get today's day number
        Dim TodayNumber = DateTime.Today.Day
        Dim TodayMonth = MonthName(DateTime.Today.Month)

        'For testing
        'error_lbl.Text = "Week5StartDate: " & Week5StartDate & " StartDayOfWeek: " & Week5StartDayOfTheWeek & " MondayVisitDate: " & MondayVisitDate

        'Assign labels to calendar numbers
        monday5_lbl.Text = MondayNumber
        tuesday5_lbl.Text = TuesdayNumber
        wednesday5_lbl.Text = WednesdayNumber
        thursday5_lbl.Text = ThursdayNumber
        friday5_lbl.Text = FridayNumber

        'If current month and day matches the selected month and current day number, change the font color to red
        If TodayMonth = MonthPassed Then
            If TodayNumber = MondayNumber Then
                monday5_lbl.ForeColor = System.Drawing.Color.Red
            ElseIf TodayNumber = TuesdayNumber Then
                tuesday5_lbl.ForeColor = System.Drawing.Color.Red
            ElseIf TodayNumber = WednesdayNumber Then
                wednesday5_lbl.ForeColor = System.Drawing.Color.Red
            ElseIf TodayNumber = ThursdayNumber Then
                thursday5_lbl.ForeColor = System.Drawing.Color.Red
            ElseIf TodayNumber = FridayNumber Then
                friday5_lbl.ForeColor = System.Drawing.Color.Red
            End If
        End If

        'Assign school names to buttons - Monday
        Try
            monday5School1_btn.Text = SchoolData.GetSchoolsIndividual(MondayVisitDate).School1.TrimEnd(" ")
            monday5School2_btn.Text = SchoolData.GetSchoolsIndividual(MondayVisitDate).School2.TrimEnd(" ")
            monday5School3_btn.Text = SchoolData.GetSchoolsIndividual(MondayVisitDate).School3.TrimEnd(" ")
            monday5School4_btn.Text = SchoolData.GetSchoolsIndividual(MondayVisitDate).School4.TrimEnd(" ")
            monday5School5_btn.Text = SchoolData.GetSchoolsIndividual(MondayVisitDate).School5.TrimEnd(" ")
        Catch
            error_lbl.Text = "Error in Calendar. Cannot get monday's school names."
            Exit Sub
        End Try

        'Assign school names to buttons - Tuesday
        Try
            tuesday5School1_btn.Text = SchoolData.GetSchoolsIndividual(TuesdayVisitDate).School1.TrimEnd(" ")
            tuesday5School2_btn.Text = SchoolData.GetSchoolsIndividual(TuesdayVisitDate).School2.TrimEnd(" ")
            tuesday5School3_btn.Text = SchoolData.GetSchoolsIndividual(TuesdayVisitDate).School3.TrimEnd(" ")
            tuesday5School4_btn.Text = SchoolData.GetSchoolsIndividual(TuesdayVisitDate).School4.TrimEnd(" ")
            tuesday5School5_btn.Text = SchoolData.GetSchoolsIndividual(TuesdayVisitDate).School5.TrimEnd(" ")
        Catch
            error_lbl.Text = "Error in Calendar. Cannot get tuesday's school names."
            Exit Sub
        End Try

        'Assign school names to buttons - Wednesday
        Try
            wednesday5School1_btn.Text = SchoolData.GetSchoolsIndividual(WednesdayVisitDate).School1.TrimEnd(" ")
            wednesday5School2_btn.Text = SchoolData.GetSchoolsIndividual(WednesdayVisitDate).School2.TrimEnd(" ")
            wednesday5School3_btn.Text = SchoolData.GetSchoolsIndividual(WednesdayVisitDate).School3.TrimEnd(" ")
            wednesday5School4_btn.Text = SchoolData.GetSchoolsIndividual(WednesdayVisitDate).School4.TrimEnd(" ")
            wednesday5School5_btn.Text = SchoolData.GetSchoolsIndividual(WednesdayVisitDate).School5.TrimEnd(" ")
        Catch
            error_lbl.Text = "Error in Calendar. Cannot get wednesday's school names."
            Exit Sub
        End Try

        'Assign school names to buttons - Thursday
        Try
            thursday5School1_btn.Text = SchoolData.GetSchoolsIndividual(ThursdayVisitDate).School1.TrimEnd(" ")
            thursday5School2_btn.Text = SchoolData.GetSchoolsIndividual(ThursdayVisitDate).School2.TrimEnd(" ")
            thursday5School3_btn.Text = SchoolData.GetSchoolsIndividual(ThursdayVisitDate).School3.TrimEnd(" ")
            thursday5School4_btn.Text = SchoolData.GetSchoolsIndividual(ThursdayVisitDate).School4.TrimEnd(" ")
            thursday5School5_btn.Text = SchoolData.GetSchoolsIndividual(ThursdayVisitDate).School5.TrimEnd(" ")
        Catch
            error_lbl.Text = "Error in Calendar. Cannot get thursday's school names."
            Exit Sub
        End Try

        'Assign school names to buttons - Friday
        Try
            friday5School1_btn.Text = SchoolData.GetSchoolsIndividual(FridayVisitDate).School1.TrimEnd(" ")
            friday5School2_btn.Text = SchoolData.GetSchoolsIndividual(FridayVisitDate).School2.TrimEnd(" ")
            friday5School3_btn.Text = SchoolData.GetSchoolsIndividual(FridayVisitDate).School3.TrimEnd(" ")
            friday5School4_btn.Text = SchoolData.GetSchoolsIndividual(FridayVisitDate).School4.TrimEnd(" ")
            friday5School5_btn.Text = SchoolData.GetSchoolsIndividual(FridayVisitDate).School5.TrimEnd(" ")
        Catch
            error_lbl.Text = "Error in Calendar. Cannot get friday's school names."
            Exit Sub
        End Try

        'Make buttons with school names visible
        Try
            If monday5School1_btn.Text <> Nothing Then
                monday5School1_btn.Visible = True
            End If

            If monday5School2_btn.Text <> Nothing Then
                monday5School2_btn.Visible = True
            End If

            If monday5School3_btn.Text <> Nothing Then
                monday5School3_btn.Visible = True
            End If

            If monday5School4_btn.Text <> Nothing Then
                monday5School4_btn.Visible = True
            End If

            If monday5School5_btn.Text <> Nothing Then
                monday5School5_btn.Visible = True
            End If

            If tuesday5School1_btn.Text <> Nothing Then
                tuesday5School1_btn.Visible = True
            End If

            If tuesday5School2_btn.Text <> Nothing Then
                tuesday5School2_btn.Visible = True
            End If

            If tuesday5School3_btn.Text <> Nothing Then
                tuesday5School3_btn.Visible = True
            End If

            If tuesday5School4_btn.Text <> Nothing Then
                tuesday5School4_btn.Visible = True
            End If

            If tuesday5School5_btn.Text <> Nothing Then
                tuesday5School5_btn.Visible = True
            End If

            If wednesday5School1_btn.Text <> Nothing Then
                wednesday5School1_btn.Visible = True
            End If

            If wednesday5School2_btn.Text <> Nothing Then
                wednesday5School2_btn.Visible = True
            End If

            If wednesday5School3_btn.Text <> Nothing Then
                wednesday5School3_btn.Visible = True
            End If

            If wednesday5School4_btn.Text <> Nothing Then
                wednesday5School4_btn.Visible = True
            End If

            If wednesday5School5_btn.Text <> Nothing Then
                wednesday5School5_btn.Visible = True
            End If

            If thursday5School1_btn.Text <> Nothing Then
                thursday5School1_btn.Visible = True
            End If

            If thursday5School2_btn.Text <> Nothing Then
                thursday5School2_btn.Visible = True
            End If

            If thursday5School3_btn.Text <> Nothing Then
                thursday5School3_btn.Visible = True
            End If

            If thursday5School4_btn.Text <> Nothing Then
                thursday5School4_btn.Visible = True
            End If

            If thursday5School5_btn.Text <> Nothing Then
                thursday5School5_btn.Visible = True
            End If

            If friday5School1_btn.Text <> Nothing Then
                friday5School1_btn.Visible = True
            End If

            If friday5School2_btn.Text <> Nothing Then
                friday5School2_btn.Visible = True
            End If

            If friday5School3_btn.Text <> Nothing Then
                friday5School3_btn.Visible = True
            End If

            If friday5School4_btn.Text <> Nothing Then
                friday5School4_btn.Visible = True
            End If

            If friday5School5_btn.Text <> Nothing Then
                friday5School5_btn.Visible = True
            End If

        Catch
            error_lbl.Text = "Error in Calendar. Cannot make buttons visible."
            Exit Sub
        End Try

    End Sub

    Sub InvisibleButtons()

        'Make all buttons invisible
        monday1School1_btn.Visible = False
        monday1School2_btn.Visible = False
        monday1School3_btn.Visible = False
        monday1School4_btn.Visible = False
        monday1School5_btn.Visible = False
        monday2School1_btn.Visible = False
        monday2School2_btn.Visible = False
        monday2School3_btn.Visible = False
        monday2School4_btn.Visible = False
        monday2School5_btn.Visible = False
        monday3School1_btn.Visible = False
        monday3School2_btn.Visible = False
        monday3School3_btn.Visible = False
        monday3School4_btn.Visible = False
        monday3School5_btn.Visible = False
        monday4School1_btn.Visible = False
        monday4School2_btn.Visible = False
        monday4School3_btn.Visible = False
        monday4School4_btn.Visible = False
        monday4School5_btn.Visible = False
        monday5School1_btn.Visible = False
        monday5School2_btn.Visible = False
        monday5School3_btn.Visible = False
        monday5School4_btn.Visible = False
        monday5School5_btn.Visible = False

        tuesday1School1_btn.Visible = False
        tuesday1School2_btn.Visible = False
        tuesday1School3_btn.Visible = False
        tuesday1School4_btn.Visible = False
        tuesday1School5_btn.Visible = False
        tuesday2School1_btn.Visible = False
        tuesday2School2_btn.Visible = False
        tuesday2School3_btn.Visible = False
        tuesday2School4_btn.Visible = False
        tuesday2School5_btn.Visible = False
        tuesday3School1_btn.Visible = False
        tuesday3School2_btn.Visible = False
        tuesday3School3_btn.Visible = False
        tuesday3School4_btn.Visible = False
        tuesday3School5_btn.Visible = False
        tuesday4School1_btn.Visible = False
        tuesday4School2_btn.Visible = False
        tuesday4School3_btn.Visible = False
        tuesday4School4_btn.Visible = False
        tuesday4School5_btn.Visible = False
        tuesday5School1_btn.Visible = False
        tuesday5School2_btn.Visible = False
        tuesday5School3_btn.Visible = False
        tuesday5School4_btn.Visible = False
        tuesday5School5_btn.Visible = False

        wednesday1School1_btn.Visible = False
        wednesday1School2_btn.Visible = False
        wednesday1School3_btn.Visible = False
        wednesday1School4_btn.Visible = False
        wednesday1School5_btn.Visible = False
        wednesday2School1_btn.Visible = False
        wednesday2School2_btn.Visible = False
        wednesday2School3_btn.Visible = False
        wednesday2School4_btn.Visible = False
        wednesday2School5_btn.Visible = False
        wednesday3School1_btn.Visible = False
        wednesday3School2_btn.Visible = False
        wednesday3School3_btn.Visible = False
        wednesday3School4_btn.Visible = False
        wednesday3School5_btn.Visible = False
        wednesday4School1_btn.Visible = False
        wednesday4School2_btn.Visible = False
        wednesday4School3_btn.Visible = False
        wednesday4School4_btn.Visible = False
        wednesday4School5_btn.Visible = False
        wednesday5School1_btn.Visible = False
        wednesday5School2_btn.Visible = False
        wednesday5School3_btn.Visible = False
        wednesday5School4_btn.Visible = False
        wednesday5School5_btn.Visible = False

        thursday1School1_btn.Visible = False
        thursday1School2_btn.Visible = False
        thursday1School3_btn.Visible = False
        thursday1School4_btn.Visible = False
        thursday1School5_btn.Visible = False
        thursday2School1_btn.Visible = False
        thursday2School2_btn.Visible = False
        thursday2School3_btn.Visible = False
        thursday2School4_btn.Visible = False
        thursday2School5_btn.Visible = False
        thursday3School1_btn.Visible = False
        thursday3School2_btn.Visible = False
        thursday3School3_btn.Visible = False
        thursday3School4_btn.Visible = False
        thursday3School5_btn.Visible = False
        thursday4School1_btn.Visible = False
        thursday4School2_btn.Visible = False
        thursday4School3_btn.Visible = False
        thursday4School4_btn.Visible = False
        thursday4School5_btn.Visible = False
        thursday5School1_btn.Visible = False
        thursday5School2_btn.Visible = False
        thursday5School3_btn.Visible = False
        thursday5School4_btn.Visible = False
        thursday5School5_btn.Visible = False

        friday1School1_btn.Visible = False
        friday1School2_btn.Visible = False
        friday1School3_btn.Visible = False
        friday1School4_btn.Visible = False
        friday1School5_btn.Visible = False
        friday2School1_btn.Visible = False
        friday2School2_btn.Visible = False
        friday2School3_btn.Visible = False
        friday2School4_btn.Visible = False
        friday2School5_btn.Visible = False
        friday3School1_btn.Visible = False
        friday3School2_btn.Visible = False
        friday3School3_btn.Visible = False
        friday3School4_btn.Visible = False
        friday3School5_btn.Visible = False
        friday4School1_btn.Visible = False
        friday4School2_btn.Visible = False
        friday4School3_btn.Visible = False
        friday4School4_btn.Visible = False
        friday4School5_btn.Visible = False
        friday5School1_btn.Visible = False
        friday5School2_btn.Visible = False
        friday5School3_btn.Visible = False
        friday5School4_btn.Visible = False
        friday5School5_btn.Visible = False
    End Sub

    Sub DayButton(SchoolName As String, VisitDate As String)
        Dim SchoolID As String
        Dim VisitID As String

        'Get school id from school name
        SchoolID = SchoolData.GetSchoolID(SchoolName)

        'Get visitID of date
        VisitID = VisitData.GetVisitIDFromDate(VisitDate)

        'Link to student report
        Response.Redirect("employee_report.aspx?b=" & VisitID & "&c=" & SchoolID)
    End Sub

    Protected Sub month_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles month_ddl.SelectedIndexChanged
        If month_ddl.SelectedIndex <> 0 Then
            calendarView_div.Visible = True
            FirstWeek(month_ddl.SelectedValue)
        End If
    End Sub

    'Protected Sub monday1School1_btn_Click(sender As Object, e As EventArgs) Handles monday1School1_btn.Click
    '    DayButton(monday1School1_btn.Text, MondayVisitDate)
    'End Sub

    'Protected Sub monday1School2_btn_Click(sender As Object, e As EventArgs) Handles monday1School2_btn.Click
    '    DayButton(monday1School2_btn.Text, MondayVisitDate)
    'End Sub

    'Protected Sub monday1School3_btn_Click(sender As Object, e As EventArgs) Handles monday1School3_btn.Click
    '    DayButton(monday1School3_btn.Text, MondayVisitDate)
    'End Sub

    'Protected Sub monday1School4_btn_Click(sender As Object, e As EventArgs) Handles monday1School4_btn.Click
    '    DayButton(monday1School4_btn.Text, MondayVisitDate)
    'End Sub

    'Protected Sub monday1School5_btn_Click(sender As Object, e As EventArgs) Handles monday1School5_btn.Click
    '    DayButton(monday1School5_btn.Text, MondayVisitDate)
    'End Sub

    'Protected Sub tuesday1School1_btn_Click(sender As Object, e As EventArgs) Handles tuesday1School1_btn.Click
    '    DayButton(tuesday1School1_btn.Text, TuesdayVisitDate)
    'End Sub
    'Protected Sub tuesday1School2_btn_Click(sender As Object, e As EventArgs) Handles tuesday1School2_btn.Click
    '    DayButton(tuesday1School2_btn.Text, TuesdayVisitDate)
    'End Sub

    'Protected Sub tuesday1School3_btn_Click(sender As Object, e As EventArgs) Handles tuesday1School3_btn.Click
    '    DayButton(tuesday1School3_btn.Text, TuesdayVisitDate)
    'End Sub

    'Protected Sub tuesday1School4_btn_Click(sender As Object, e As EventArgs) Handles tuesday1School4_btn.Click
    '    DayButton(tuesday1School4_btn.Text, TuesdayVisitDate)
    'End Sub

    'Protected Sub tuesday1School5_btn_Click(sender As Object, e As EventArgs) Handles tuesday1School5_btn.Click
    '    DayButton(tuesday1School5_btn.Text, TuesdayVisitDate)
    'End Sub

    'Protected Sub wednesday1School1_btn_Click(sender As Object, e As EventArgs) Handles wednesday1School1_btn.Click
    '    DayButton(wednesday1School1_btn.Text, WednesdayVisitDate)
    'End Sub

    'Protected Sub wednesday1School2_btn_Click(sender As Object, e As EventArgs) Handles wednesday1School2_btn.Click
    '    DayButton(wednesday1School2_btn.Text, WednesdayVisitDate)
    'End Sub

    'Protected Sub wednesday1School3_btn_Click(sender As Object, e As EventArgs) Handles wednesday1School3_btn.Click
    '    DayButton(wednesday1School3_btn.Text, WednesdayVisitDate)
    'End Sub

    'Protected Sub wednesday1School4_btn_Click(sender As Object, e As EventArgs) Handles wednesday1School4_btn.Click
    '    DayButton(wednesday1School4_btn.Text, WednesdayVisitDate)
    'End Sub

    'Protected Sub wednesday1School5_btn_Click(sender As Object, e As EventArgs) Handles wednesday1School5_btn.Click
    '    DayButton(wednesday1School5_btn.Text, WednesdayVisitDate)
    'End Sub

    'Protected Sub thursday1School1_btn_Click(sender As Object, e As EventArgs) Handles thursday1School1_btn.Click
    '    DayButton(thursday1School1_btn.Text, ThursdayVisitDate)
    'End Sub

    'Protected Sub thursday1School2_btn_Click(sender As Object, e As EventArgs) Handles thursday1School2_btn.Click
    '    DayButton(thursday1School2_btn.Text, ThursdayVisitDate)
    'End Sub

    'Protected Sub thursday1School3_btn_Click(sender As Object, e As EventArgs) Handles thursday1School3_btn.Click
    '    DayButton(thursday1School3_btn.Text, ThursdayVisitDate)
    'End Sub

    'Protected Sub thursday1School4_btn_Click(sender As Object, e As EventArgs) Handles thursday1School4_btn.Click
    '    DayButton(thursday1School4_btn.Text, ThursdayVisitDate)
    'End Sub

    'Protected Sub thursday1School5_btn_Click(sender As Object, e As EventArgs) Handles thursday1School5_btn.Click
    '    DayButton(thursday1School5_btn.Text, ThursdayVisitDate)
    'End Sub

    'Protected Sub friday1School1_btn_Click(sender As Object, e As EventArgs) Handles friday1School1_btn.Click
    '    DayButton(friday1School1_btn.Text, FridayVisitDate)
    'End Sub

    'Protected Sub friday1School2_btn_Click(sender As Object, e As EventArgs) Handles friday1School2_btn.Click
    '    DayButton(friday1School2_btn.Text, FridayVisitDate)
    'End Sub

    'Protected Sub friday1School3_btn_Click(sender As Object, e As EventArgs) Handles friday1School3_btn.Click
    '    DayButton(friday1School3_btn.Text, FridayVisitDate)
    'End Sub

    'Protected Sub friday1School4_btn_Click(sender As Object, e As EventArgs) Handles friday1School4_btn.Click
    '    DayButton(friday1School4_btn.Text, FridayVisitDate)
    'End Sub

    'Protected Sub friday1School5_btn_Click(sender As Object, e As EventArgs) Handles friday1School5_btn.Click
    '    DayButton(friday1School5_btn.Text, FridayVisitDate)
    'End Sub
End Class