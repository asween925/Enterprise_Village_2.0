Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class Employee_Report
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim StudentData As New Class_StudentData
    Dim BusinessData As New Class_BusinessData
    Dim SchoolData As New Class_SchoolData
    Dim VisitData As New Class_VisitData
    Dim VisitID As Integer = VisitData.GetVisitID
    Dim URL As String = HttpContext.Current.Request.Url.AbsoluteUri
    Dim HomePageVisitID As String
    Dim HomePageSchoolID As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("LoggedIn") <> "1" Then
            Response.Redirect("../../default.aspx")
        End If

        If Not (IsPostBack) Then

            If VisitID <> 0 Then
                visitdate_hf.Value = VisitID
            End If

            'Populating school header
            Dim header As New Class_SchoolHeader
            headerSchoolName_lbl.Text = header.GetSchoolHeader()

            'Check if coming from home page and assign visitDate hidden value and load school
            If URL.Contains("b=") Then
                HomePageVisitID = Request.QueryString("b")
                HomePageSchoolID = Request.QueryString("c")
                visitdateUpdate_hf.Value = VisitData.GetVisitDateFromID(HomePageVisitID)
                PopulateDDLs()
            End If

        End If
    End Sub

    Sub PopulateDDLs()
        Dim VisitDate As String
        Dim SchoolName As String

        'Clear DDLs
        schoolName_ddl.Items.Clear()
        business_ddl.Items.Clear()

        'Make DDL divs visible
        schoolDDLDIV.Visible = True

        'Check if coming from home page to assign visit date
        If URL.Contains("b=") Then
            VisitDate = visitdateUpdate_hf.Value
        Else
            VisitDate = visitDate_tb.Text
        End If

        'Populate School DDL
        Try
            SchoolData.LoadVisitDateSchoolsDDL(VisitDate, schoolName_ddl)
            schoolName_ddl.Items.RemoveAt(0)
            schoolName_ddl.Items.Insert(0, "Show All")
        Catch
            error_lbl.Text = "Error in LoadData(). Cannot load schools DDL."
            Exit Sub
        End Try

        'Populate business DDL
        Try
            BusinessData.LoadBusinessNamesDDL(business_ddl)
            business_ddl.Items.RemoveAt(0)
            business_ddl.Items.Insert(0, "Show All")
        Catch
            error_lbl.Text = "Error in LoadData(). Cannot load business DDL."
            Exit Sub
        End Try

        If URL.Contains("c=") Then
            SchoolName = SchoolData.GetSchoolNameFromID(HomePageSchoolID)
            schoolName_ddl.SelectedIndex = schoolName_ddl.Items.IndexOf(schoolName_ddl.Items.FindByValue(SchoolName))
            LoadData()
        Else
            LoadData()
        End If

    End Sub

    Sub LoadData()
        Dim VisitDate As String
        Dim StudentCount As String
        Dim ClosedBusinessess As String
        Dim WhereStart As String
        Dim WhereSchool As String = " AND sc.schoolName = '" & schoolName_ddl.SelectedValue & "'"
        Dim WhereBusiness As String = " AND b.businessName = '" & business_ddl.SelectedValue & "'"
        Dim WhereFinish As String = " AND NOT businessName='Training Business' AND NOT firstName='NULL' AND NOT lastName='NULL' AND NOT firstName = ' ' AND NOT lastName=' ' "
        Dim SQLStatement As String = "SELECT s.id, s.employeeNumber, s.firstName, s.lastName, j.jobTitle, b.businessName, sc.schoolName
                                        FROM studentInfo s
                                        INNER JOIN jobs j ON j.id=s.job
                                        INNER JOIN businessInfo b ON b.id=s.business
                                        INNER JOIN visitInfo v ON v.id=s.visit
                                        INNER JOIN schoolInfo sc ON s.school = sc.id"

        'Clear out table
        employees_dgv.DataSource = Nothing
        employees_dgv.DataBind()

        'Check if coming from home page to assign visit date
        If URL.Contains("b=") Then
            VisitDate = visitdateUpdate_hf.Value
            WhereStart = " WHERE v.visitDate='" & VisitDate & "'"
        Else
            VisitDate = visitDate_tb.Text
            WhereStart = " WHERE v.visitDate='" & VisitDate & "'"
        End If

        'Get closed businesses
        Try
            ClosedBusinessess = BusinessData.GetClosedBusinesses(VisitDate)
        Catch
            error_lbl.Text = "Error in loaddata(). Could not get closed businesses."
            Exit Sub
        Finally
            cmd.Dispose()
            con.Close()
        End Try

        'Get student count
        Try
            StudentCount = StudentData.GetStudentCount(VisitDate)
        Catch
            error_lbl.Text = "Error in LoadData(). Cannot get student count."
            Exit Sub
        End Try

        'Assign where clause if needed
        If schoolName_ddl.SelectedIndex = 0 And business_ddl.SelectedIndex = 0 Then
            SQLStatement &= WhereStart & WhereFinish

        ElseIf schoolName_ddl.SelectedIndex <> 0 And business_ddl.SelectedIndex = 0 Then
            SQLStatement &= WhereStart & WhereSchool & WhereFinish

            'Get student count of selected school
            Try
                StudentCount = StudentData.GetStudentCountOfSchool(VisitDate, schoolName_ddl.SelectedValue)
            Catch
                error_lbl.Text = "Error in LoadData(). Cannot get student count of school."
                Exit Sub
            End Try

        ElseIf schoolName_ddl.SelectedIndex = 0 And business_ddl.SelectedIndex <> 0 Then
            SQLStatement &= WhereStart & WhereBusiness & WhereFinish

            'Get student count of selected business
            Try
                StudentCount = StudentData.GetStudentCountOfBusiness(VisitDate, business_ddl.SelectedValue)
            Catch
                error_lbl.Text = "Error in LoadData(). Cannot get student count of school."
                Exit Sub
            End Try
        End If

        'Load employees table 
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = SQLStatement

            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)

            employees_dgv.DataSource = dt
            employees_dgv.DataBind()

            cmd.Dispose()
            con.Close()

        Catch
            error_lbl.Text = "Error in LoadData(). Cannot load table."
            cmd.Dispose()
            con.Close()
        End Try

        'Assign labels
        studentCount_lbl.Text = "Student Count: " & StudentCount
        closedBiz_lbl.Text = ClosedBusinessess
        schoolName_lbl.Text = SchoolData.GetSchoolsString(VisitDate) & " for " & Convert.ToDateTime(VisitDate).ToString("MM/dd/yyyy")


    End Sub

    Protected Sub show_btn_Click(sender As Object, e As EventArgs) Handles show_btn.Click
        If show_btn.Text = "Show Empty Names" Then
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "ISI_confirm", "ISI_confirm();", True)
            show_btn.Text = "Hide Empty Names"
        ElseIf show_btn.Text = "Hide Empty Names" Then
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "ISI_confirm", "ISI_confirm();", False)
            show_btn.Text = "Show Empty Names"
        End If

    End Sub

    Protected Sub visitDate_tb_TextChanged(sender As Object, e As EventArgs) Handles visitDate_tb.TextChanged
        PopulateDDLs()
    End Sub

    Protected Sub schoolName_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles schoolName_ddl.SelectedIndexChanged
        If schoolName_ddl.SelectedIndex <> 0 Then
            business_ddl.SelectedIndex = business_ddl.Items.IndexOf(business_ddl.Items.FindByValue("Show All"))
            LoadData()
        Else
            LoadData()
        End If
    End Sub

    Protected Sub business_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles business_ddl.SelectedIndexChanged
        If business_ddl.SelectedIndex <> 0 Then
            schoolName_ddl.SelectedIndex = schoolName_ddl.Items.IndexOf(schoolName_ddl.Items.FindByValue("Show All"))
            LoadData()
        Else
            LoadData()
        End If
    End Sub

    Protected Sub print_btn_Click(sender As Object, e As EventArgs) Handles print_btn.Click
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "Print", "Print();", True)
    End Sub

End Class