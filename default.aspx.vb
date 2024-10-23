Imports System.Data.SqlClient
Imports System.DirectoryServices
Public Class login
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim DBConnection As New DatabaseConection
    Dim dr As SqlDataReader
    Dim logoRoot As String = "~/media/Logos/"
    Dim strProfit As String
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
    Dim schoolName As String
    Dim schoolID As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None
    End Sub

    Sub Login()
        Dim email As String = email_tb.Text
        Dim password As String = password_tb.Text
        Dim emailCheck As New Regex("[@]")
        Dim emailMatch As Match = emailCheck.Match(email)
        Dim clientName As String
        Dim mainCompCheck As Integer
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        'Clear error label
        error_lbl.Text = ""

        'Get name of client-side computer, will crash if signing in on ipad
        '
        '           COMMENTING THIS OUT BECAUSE IT WAS FOR SOME REASON GIVING AN ERROR SCREEN WHEN AN OUTSIDE TEACHER WAS TRYING TO LOG IN (9/20/2023)
        '
        'clientName = System.Net.Dns.GetHostEntry(Request.ServerVariables.Item("REMOTE_HOST")).HostName

        'If clientName = "A6351D306-5839.pinellas.local" Or clientName = "A6351D306-5849.pinellas.local" Then
        '    mainCompCheck = 1
        'Else
        '    mainCompCheck = 0
        'End If

        ''Checks if email_tb is main and password matches
        'If email_tb.Text = "main" Then
        '    con.ConnectionString = connection_string
        '    con.Open()
        '    cmd.Connection = con

        '    Try
        '        cmd.CommandText = "SELECT job FROM adminInfo WHERE username='" & email & "'"
        '        cmd.Connection = con
        '        dr = cmd.ExecuteReader

        '        While dr.Read()
        '            If password_tb.Text = dr("job").ToString And mainCompCheck = 1 Then
        '                Session.Add("LoggedIn", "1")
        '                Session.Add("isAdmin", "True")
        '                Response.Redirect(".\home_page.aspx")
        '                error_lbl.Text = "Logged in"
        '            Else
        '                error_lbl.Text = "Error code 24. Invalid credentials or invalid computer name ('main' username and password must only be used on the two main computers in EV)."
        '                Exit Sub
        '            End If
        '        End While

        '        cmd.Dispose()
        '        con.Close()
        '    Catch
        '        error_lbl.Text = "Error code 24. Cannot get password credentials."
        '        Exit Sub
        '    End Try
        'End If

        'Checks if email_tb is an address
        If Not (email.Contains("@")) And Not (email.Contains(".")) Then
            'Not an email. Show message
            error_lbl.Text = "Not a valid email address."
            Exit Sub
        End If

        cmd.Dispose()
        con.Close()

        Dim domainCheck As New Regex("[\\]")
        Dim domainMatch As Match = domainCheck.Match(email)

        If email.Contains("@pcsb.org") Then
            'PCS user. Check AD
            Dim userName() As String = email.Split("@")
            'Dim schoolName As String
            'Dim schoolID As String

            con.ConnectionString = connection_string
            con.Open()
            cmd.Connection = con

            'Guest email
            'If email = "evguest@pcsb.org" And password = "*GoBl1N645*" Then
            '    Response.Redirect(".\input_student_information.aspx")
            'End If

            Try
                'Checking PCSB credentials
                If ValidateActiveDirectoryLogin("pinellas.local", userName(0), password) = True Then
                    'Valid user. Set Session variables and take to menu

                    Session.Add("LoggedIn", "1")
                    Session.Add("username", userName(0))

                    cmd.CommandText = "SELECT * FROM adminInfo WHERE email='" & email & "'"
                    dr = cmd.ExecuteReader

                    'Checks if email and password entered is GSI staff
                    If dr.HasRows = True Then
                        Session.Add("isAdmin", "True")

                        'Check if GSI staff member is bus driver or not; sends them to the inventory page
                        While dr.Read()
                            If dr("job").ToString = "Bus Driver" Then
                                Response.Redirect("/pages/inventory/Inventory_Home.aspx")
                            Else
                                Response.Redirect("/pages/home_page.aspx")
                            End If
                        End While

                        'If email and password entered is NOT GSI then it will check if the email entered is in the teacherInfo DB
                    Else
                        cmd.Dispose()
                        con.Close()

                        'Check if entered email is in the database, by checking if there is a school name associated with email
                        Try
                            con.ConnectionString = connection_string
                            con.Open()
                            cmd.CommandText = "SELECT DISTINCT t.schoolName FROM teacherInfo t LEFT JOIN schoolInfo s ON s.id = t.schoolID WHERE t.futureRequestsEmail = '" & email & "'"
                            cmd.Connection = con
                            dr = cmd.ExecuteReader

                            While dr.Read()
                                schoolName_lbl.Text = dr("schoolName").ToString

                                If dr.HasRows = False Or schoolName_lbl.Text = "" Then
                                    error_lbl.Text = "We do not have a school associated with your email. Please use the link above to email us about this issue."
                                    Exit Sub
                                End If
                            End While

                            cmd.Dispose()
                            con.Close()

                        Catch
                            error_lbl.Text = "Error code 1. Please use the link above to email us about this issue."
                            'error2_lbl.Text = schoolID_hf.Value & "/" & schoolName_lbl.Text
                            Exit Sub
                        End Try

                        'Get School ID
                        Try
                            con.ConnectionString = connection_string
                            con.Open()
                            cmd.CommandText = "SELECT DISTINCT id FROM schoolInfo WHERE schoolName = '" & schoolName_lbl.Text & "' AND NOT id=505"
                            cmd.Connection = con
                            dr = cmd.ExecuteReader

                            While dr.Read()
                                schoolID_hf.Value = dr("id").ToString

                                If schoolID_hf.Value = "" Or schoolID_hf.Value = Nothing Then
                                    error_lbl.Text = "Error code 22. Please use the link above to email us about this issue."
                                    cmd.Dispose()
                                    con.Close()
                                    Exit Sub
                                End If
                            End While

                            cmd.Dispose()
                            con.Close()

                        Catch
                            error_lbl.Text = "Error code 2. Please use the link above to email us about this issue."
                            'error2_lbl.Text = schoolID_hf.Value & "/" & schoolName_lbl.Text
                            cmd.Dispose()
                            con.Close()
                            Exit Sub
                        End Try

                        'Check if school has a visit created for current school year
                        Try
                            'Get current year, then get next year
                            Dim currentYear As String = Date.Now.Year.ToString()
                            Dim nextYear As String = currentYear + 1

                            con.ConnectionString = connection_string
                            con.Open()

                            'CHANGE THIS CODE HERE AFTER EACH SCHOOL YEAR:     CHANGE THE YEAR BETWEEN AT THE END OF THIS LINE TO 8-10-(Current Year) AND 6-10(Next Year)
                            cmd.CommandText = "SELECT id FROM (SELECT id, visitDate FROM visitInfo WHERE school = '" & schoolID_hf.Value & "' 
                                                    OR school2 = '" & schoolID_hf.Value & "' OR school3 = '" & schoolID_hf.Value & "' 
                                                    OR school4 = '" & schoolID_hf.Value & "' OR school5 = '" & schoolID_hf.Value & "')   
                                                    as x WHERE visitDate BETWEEN '07-01-" & currentYear & "' AND '07-01-" & nextYear & "'" '<----CHANGE HERE  
                            cmd.Connection = con
                            dr = cmd.ExecuteReader

                            If dr.HasRows = True Then
                                Dim URLEnd As String = schoolID_hf.Value
                                'Dim URLEndTeacher As String

                                Session.Add("isAdmin", "False")
                                'Response.Redirect(".\input_student_information.aspx?b=" & URLEnd)
                                Response.Redirect(".\teacher_home.aspx?b=" & URLEnd)
                            Else
                                'this error could happen if the email entered is associated with two or more schools. Check the teacherInfo table and search for the email entered.
                                error_lbl.Text = "We do not have a record of an upcoming visit for you. Please use the link above to email us about this issue."
                                Exit Sub
                            End If

                            cmd.Dispose()
                            con.Close()

                        Catch
                            error_lbl.Text = "Error code 3. Please use the link above to email us about this issue."
                            'error2_lbl.Text = schoolID_hf.Value & "/" & schoolName_lbl.Text
                            Exit Sub
                        End Try
                    End If
                Else
                    'Warn about invalid credentials. 
                    error_lbl.Text = "Invalid PCSB credentials. Email or password is incorrect."
                    Exit Sub
                End If
            Catch
                error_lbl.Text = "Error code 5. Please use the link above to email us about this issue."

                cmd.Dispose()
                con.Close()
            End Try

            'non-PCSB user. Check DB.
        Else
            'Checks if password is valid
            Try
                Session.Add("LoggedIn", "1")
                con.ConnectionString = connection_string
                con.Open()
                cmd.CommandText = "SELECT DISTINCT password FROM teacherInfo WHERE futureRequestsEmail = '" & email & "'"
                cmd.Connection = con
                dr = cmd.ExecuteReader

                While dr.Read()
                    If dr.HasRows = True Then
                        If password_tb.Text = Nothing Or password_tb.Text = "" Then
                            error_lbl.Text = "Please enter your password."
                            Exit Sub
                        ElseIf password_tb.Text = dr("password").ToString Then
                            error_lbl.Text = dr("password").ToString
                            Exit While
                        Else
                            error_lbl.Text = "Invalid password. Please use the password provided in your email."
                            Exit Sub
                        End If
                    Else
                        error_lbl.Text = "We do not have a school associated with your email. Please use the link above to email us about this issue."
                        Exit Sub
                    End If
                End While

                cmd.Dispose()
                con.Close()

                'gets schoolName and ID from teacherInfo using email
                Try
                    con.ConnectionString = connection_string
                    con.Open()
                    cmd.CommandText = "SELECT DISTINCT t.id, s.schoolName FROM teacherInfo t JOIN schoolInfo s ON s.id = t.schoolID WHERE t.futureRequestsEmail = '" & email & "'"
                    cmd.Connection = con
                    dr = cmd.ExecuteReader

                    While dr.Read()
                        schoolName_lbl.Text = dr("schoolName").ToString
                        teacherID_hf.Value = dr("id").ToString

                        If schoolName_lbl.Text = "" Then
                            error_lbl.Text = "We do not have a school associated with your email. Please use the link above to email us about this issue."
                            Exit Sub
                        End If

                        If dr.HasRows <> True Then
                            error_lbl.Text = "We do not have a school associated with your email. Please use the link above to email us about this issue."
                            Exit Sub
                        End If

                    End While

                    cmd.Dispose()
                    con.Close()

                Catch
                    error_lbl.Text = "Error code 6. Please use the link above to email us about this issue."
                    'error2_lbl.Text = schoolID_hf.Value & "/" & schoolName_lbl.Text
                    Exit Sub
                End Try

                'Gte school ID
                Try
                    con.ConnectionString = connection_string
                    con.Open()
                    cmd.CommandText = "SELECT DISTINCT id FROM schoolInfo WHERE schoolName = '" & schoolName_lbl.Text & "' AND NOT id='505'"
                    cmd.Connection = con
                    dr = cmd.ExecuteReader

                    While dr.Read()
                        schoolID_hf.Value = dr("id").ToString

                        If schoolID_hf.Value = "" Or schoolID_hf.Value = Nothing Then
                            error_lbl.Text = "Error code 22. Please use the link above to email us about this issue."
                            cmd.Dispose()
                            con.Close()
                            Exit Sub
                        End If
                    End While

                    cmd.Dispose()
                    con.Close()

                Catch
                    error_lbl.Text = "Error code 7. Please use the link above to email us about this issue."
                    'error2_lbl.Text = schoolID_hf.Value & "/" & schoolName_lbl.Text
                    Exit Sub
                End Try

                'Get visit ID from visitInfo and check if there is a visit in the system
                Try
                    'Get current year, then get next year
                    Dim currentYear As String = Date.Now.Year.ToString()
                    Dim nextYear As String = currentYear + 1

                    con.ConnectionString = connection_string
                    con.Open()

                    'CHANGE THE YEAR BETWEEN AT THE END OF THIS LINE TO 8-10-(Current Year) AND 6-10(Next Year)
                    cmd.CommandText = "SELECT id FROM (SELECT id, visitDate FROM visitInfo WHERE school = '" & schoolID_hf.Value & "' 
                                                    OR school2 = '" & schoolID_hf.Value & "' OR school3 = '" & schoolID_hf.Value & "' 
                                                    OR school4 = '" & schoolID_hf.Value & "' OR school5 = '" & schoolID_hf.Value & "')   
                                                    as x WHERE visitDate BETWEEN '07-01-" & currentYear & "' AND '07-01-" & nextYear & "'" '<----CHANGE HERE  
                    cmd.Connection = con
                    dr = cmd.ExecuteReader

                    If dr.HasRows = True Then
                        Dim schoolIDURL As String = schoolID_hf.Value
                        Dim teacherIDURL As String = teacherID_hf.Value

                        Session.Add("isAdmin", "False")

                        'Redirect to teacher home page
                        Response.Redirect(".\teacher_home.aspx?b=" & schoolIDURL & "&c=" & teacherIDURL)
                    Else
                        error_lbl.Text = "We do not have a record of a visit with your school (non-PCSB) in our system. Please use the link above to email us about this issue."
                        Exit Sub
                    End If

                    cmd.Dispose()
                    con.Close()

                Catch
                    error_lbl.Text = "Error code 8. Please use the link above to email us about this issue."
                    'error2_lbl.Text = schoolID_hf.Value & "/" & schoolName_lbl.Text
                    Exit Sub
                End Try

            Catch
                error_lbl.Text = "Error code 9. Please use the link above to email us about this issue."
                Exit Sub
            End Try
        End If

    End Sub

    Private Function ValidateActiveDirectoryLogin(ByVal Domain As String, ByVal Username As String, ByVal Password As String) As Boolean
        Dim Success As Boolean = False
        Dim Entry As New System.DirectoryServices.DirectoryEntry("LDAP://" & Domain, Username, Password)
        Dim Searcher As New System.DirectoryServices.DirectorySearcher(Entry)
        Searcher.SearchScope = DirectoryServices.SearchScope.OneLevel
        Try
            Dim Results As System.DirectoryServices.SearchResult = Searcher.FindOne
            Success = Not (Results Is Nothing)
        Catch
            Success = False
            error2_lbl.Text = "Error code 10. Please use the link above to email use about this issue."
        End Try
        Return (Success)
    End Function

    Private Sub login_btn_Click(sender As Object, e As EventArgs) Handles login_btn.Click
        Login()
    End Sub


End Class