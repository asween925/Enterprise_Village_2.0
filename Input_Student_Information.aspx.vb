Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Net.Mail
Imports System.Net
Imports System.Diagnostics
Imports System.Drawing
Public Class Input_Student_Information
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim VisitID As Integer
    Dim SchoolID As Integer
    Dim TeacherID As Integer
    Dim Visits As New Class_VisitData
    Dim Schools As New Class_SchoolData
    Dim Businesses As New Class_BusinessData
    Dim Students As New Class_StudentData

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim SchoolName As String
        Dim VisitDate As String
        Dim replyByDate As Date
        Dim currentDate As Date = DateTime.Now()
        Dim result As Integer = DateTime.Compare(currentDate, replyByDate)

        'Asks If the session Is still active, If Not, then it will redirect to the login screen
        If Session("LoggedIn") <> "1" Then
            Response.Redirect("default.aspx")
        End If

        'Get schoolID from URL from login page
        SchoolID = Request.QueryString("b")

        'Assign school ID to the blank school name if there is no ID
        If SchoolID = Nothing Then
            SchoolID = 505
            Exit Sub
        End If

        If Not (IsPostBack) Then

            'Get visit ID using schoolID from URL
            Try
                VisitID = Visits.GetVisitIDFromSchoolID(SchoolID)
            Catch
                error_lbl.Text = "Error in visitIDSQL query. Please use the link below to email us about this issue."
                Exit Sub
            End Try

            'Get School Name        
            Try
                SchoolName = Schools.GetSchoolNameFromID(SchoolID) & " for "
            Catch
                error_lbl.Text = "Error in schoolNameSQL query. Please use the link below to email us about this issue."
                Exit Sub
            End Try

            'Get Visit Date
            Try
                VisitDate = Visits.GetVisitDateFromID(VisitID)
            Catch
                error_lbl.Text = "Error in visitDateSQL query. Please use the link below to email us about this issue."
                Exit Sub
            End Try

            'Populate the business name DDL
            'Dim businessDDLSQL As String = "SELECT DISTINCT b.Businessname FROM businessinfo b 
            'INNER JOIN businessVisitInfo o
            'ON o.businessID = b.id
            'WHERE o.openstatus='1' AND o.visitID = '" & visitID_hf.Value & "' AND o.schoolID = '" & SchoolID & "'
            'ORDER BY b.Businessname"
            Try
                Businesses.LoadBusinessNamesDDL(business_ddl, True, True, VisitID, SchoolID)
                'con.ConnectionString = connection_string
                'con.Open()
                'cmd.CommandText = businessDDLSQL
                'cmd.Connection = con
                'dr = cmd.ExecuteReader

                'While dr.Read()
                '    business_ddl.Items.Add(dr(0).ToString)
                'End While
                'business_ddl.Items.Insert(0, "")

                'cmd.Dispose()
                'con.Close()

            Catch
                error_lbl.Text = "Error in businessDDLSQL query. Please use the link below to email us about this issue."
                Exit Sub
            End Try

            'Check if reply by date is before the current date logged in.
            Try
                replyByDate = Visits.LoadVisitInfoFromDate(VisitDate, "replyBy")

                If currentDate >= replyByDate Then
                    'If result > 0 Then
                    business_ddl.Enabled = False
                    submit_btn.Enabled = False
                    error_lbl.Text = "You are no longer able to make changes to your Enterprise Village student list because your selected visit date is only/less than 2 weeks away." & Environment.NewLine & "Please email stavrosinstitute@pcsb.org for more information on this."
                    Exit Sub
                End If

            Catch
                error_lbl.Text = "Error with replyBy query. Please use the link below to email us about this issue."
                Exit Sub

            End Try

            'Fill out print table
            Try
                con.ConnectionString = connection_string
                Review_sds.ConnectionString = connection_string
                Review_sds.SelectCommand = "Select s.id, s.firstName, s.lastName, s.accountNumber, b.businessName, sc.schoolName, j.jobTitle
                                from studentInfo s
                                inner join businessInfo b 
	                                on b.id=s.businessID
                                inner join jobs j
	                                on j.id=s.jobID
                                inner join visitInfo v
	                                on v.id=s.visitID
								inner join schoolInfo sc
									on s.schoolID = sc.id
                                        where v.id ='" & VisitID & "' and sc.id='" & SchoolID & "' and not b.businessName='Training Business' and not s.firstName IS NULL and not s.lastName IS NULL"
                employees_dgv.DataSource = Review_sds
                employees_dgv.DataBind()
                con.Dispose()
                con.Close()
                cmd.Dispose()
            Catch
                error_lbl.Text = "Error with employees_dgv. Please use the link below to email us about this issue."
                Exit Sub
            End Try

            'Enable business ddl
            business_ddl.Enabled = True

            'Assign labels
            visitDate_lbl.Text = DateTime.Parse(VisitDate).ToLongDateString
            Schools_lbl.Text = SchoolName

        End If
    End Sub

    Sub loadData()
        Dim BusinessName As String = business_ddl.SelectedValue
        Dim BusinessID As Integer = Businesses.GetBusinessID(BusinessName)

        'Clear error label
        error_lbl.Text = ""

        VisitID = Visits.GetVisitIDFromSchoolID(SchoolID)

        'Load EMS table
        Students.LoadEMSTable(VisitID, Review_dgv, BusinessID)

        'con.ConnectionString = connection_string
        'Review_sds.ConnectionString = connection_string
        'Review_sds.SelectCommand = sql
        'Review_dgv.DataSource = Review_sds
        'Review_dgv.DataBind()
        'con.Dispose()
        'con.Close()
        'cmd.Dispose()

        'Highlight row being edited
        For Each row As GridViewRow In Review_dgv.Rows
            If row.RowIndex = Review_dgv.EditIndex Then
                row.BackColor = ColorTranslator.FromHtml("#ebe534")
                'row.BorderColor = ColorTranslator.FromHtml("#ffffff")
                row.BorderWidth = 2
            End If
        Next

    End Sub

    Private Sub Review_dgv_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles Review_dgv.RowUpdating
        Dim row As GridViewRow = Review_dgv.Rows(0)                           'Code is used to enable the editing prodecure
        Dim ID As Integer = Convert.ToInt32(Review_dgv.DataKeys(e.RowIndex).Values(0)) 'Code is used to enable the editing procedure

        Dim businessName As String = TryCast(Review_dgv.Rows(e.RowIndex).FindControl("business_ddl"), DropDownList).SelectedValue.ToString   'Try cast is used to try to convert - gets item from ddl
        Dim employeeNumber As String = TryCast(Review_dgv.Rows(e.RowIndex).FindControl("empNum_tb"), TextBox).Text
        Dim employeeFirst As String = TryCast(Review_dgv.Rows(e.RowIndex).FindControl("Employee_first_name_tb"), TextBox).Text
        Dim employeeLast As String = TryCast(Review_dgv.Rows(e.RowIndex).FindControl("lastName_tb"), TextBox).Text
        Dim employeePosition As String = TryCast(Review_dgv.Rows(e.RowIndex).FindControl("job_ddl"), DropDownList).SelectedValue.ToString
        Dim school As String = TryCast(Review_dgv.Rows(e.RowIndex).FindControl("schoolName_ddl"), DropDownList).SelectedValue.ToString

        Dim captialFirst As String = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(employeeFirst)
        Dim captialLast As String = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(employeeLast)

        'Check if first and last name is not empty
        If employeeFirst = Nothing And employeeLast <> Nothing Then
            error_lbl.Text = "Please enter a first name AND last name for your student."
            Exit Sub
        ElseIf employeeFirst <> Nothing And employeeLast = Nothing Then
            error_lbl.Text = "Please enter a first name AND last name for your student."
            Exit Sub
        End If

        Dim empNum As Integer = GetEmptNum(businessName, employeePosition)

        Using con As New SqlConnection(connection_string)
            Using cmd As New SqlCommand("UPDATE studentInfo SET businessID=@businessID, accountNumber=@employeeID, firstName=@employeeFirst, lastName =@employeeLast, schoolID=@schoolID, jobID=@employeePosition WHERE ID=@Id")
                cmd.Parameters.AddWithValue("@ID", ID)
                cmd.Parameters.AddWithValue("@businessID", businessName)
                cmd.Parameters.AddWithValue("@employeeID", employeeNumber)
                cmd.Parameters.AddWithValue("@employeeFirst", captialFirst)
                cmd.Parameters.AddWithValue("@employeeLast", captialLast)
                cmd.Parameters.AddWithValue("@employeePosition", employeePosition)
                cmd.Parameters.AddWithValue("@schoolID", school)
                cmd.Connection = con
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using
        Review_dgv.EditIndex = -1       'reset the grid after editing
        loadData()
    End Sub

    Private Sub Review_dgv_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles Review_dgv.RowCancelingEdit
        Review_dgv.EditIndex = -1
        loadData()
    End Sub

    Private Sub Review_dgv_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles Review_dgv.PageIndexChanging
        Review_dgv.PageIndex = e.NewPageIndex
        loadData()
    End Sub

    Private Sub Review_dgv_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles Review_dgv.RowEditing
        Review_dgv.EditIndex = e.NewEditIndex
        loadData()
    End Sub

    Private Sub Review_dgv_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles Review_dgv.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then

            'Business Dropdown
            Dim ddlBusiness As DropDownList = CType(e.Row.FindControl("business_ddl"), DropDownList)
            ddlBusiness.DataSource = GetData("SELECT DISTINCT ID AS businessID, BusinessName FROM businessInfo WHERE active='1' ORDER BY BusinessName")
            ddlBusiness.DataTextField = "BusinessName"
            ddlBusiness.DataValueField = "Businessid"
            ddlBusiness.DataBind()
            Dim lblBusiness As String = CType(e.Row.FindControl("business_lbl"), Label).Text

            ddlBusiness.Items.FindByValue(lblBusiness).Selected = True
            Dim businessID As String = ddlBusiness.SelectedValue

            'School Dropdown
            Dim ddlSchool1 As DropDownList = CType(e.Row.FindControl("schoolName_ddl"), DropDownList)
            Dim schoolID As String = Request.QueryString("b")

            ddlSchool1.DataSource = GetData("SELECT s.id as 'id', s.schoolName as 'schoolName'
											  FROM schoolInfo s 
											  JOIN visitInfo v ON v.school = s.id OR v.school2 = s.id OR v.school3 = s.id OR v.school4 = s.id OR v.school5 = s.id
											  WHERE v.id='" & VisitID & "' AND s.id=" & schoolID & " AND NOT s.id=505 
											  ORDER BY schoolName ")
            ddlSchool1.DataTextField = "schoolName"
            ddlSchool1.DataValueField = "id"
            ddlSchool1.DataBind()
            Dim lblSchool1 As String = CType(e.Row.FindControl("schoolID_lbl"), Label).Text
            'If lblSchool1 = Nothing Then
            '    ddlSchool1.Items.FindByValue("A1 No School Scheduled").Selected = True
            'Else
            '    ddlSchool1.Items.FindByValue(lblSchool1).Selected = True
            'End If

            'ddlSchool1.Items.Insert(0, "")
            Dim school1ID As String = ddlSchool1.SelectedValue

            'Job Dropdown
            Dim ddlJobs As DropDownList = CType(e.Row.FindControl("job_ddl"), DropDownList)
            ddlJobs.DataSource = GetData("SELECT j.ID AS JobID,j.JobTitle
                                            FROM Jobs j
                                            JOIN businessinfo b
	                                            ON j.id = b.position1
	                                            OR j.id = b.position2
	                                            OR j.id = b.position3
	                                            OR j.id = b.position4
	                                            OR j.id = b.position5
	                                            OR j.id = b.position6
	                                            OR j.id = b.position7
	                                            OR j.id = b.position8
	                                            OR j.id = b.position9
	                                            OR j.id = b.position10
                                                OR j.id = b.position11
                                            WHERE b.Id='" & businessID & "'
                                            ORDER BY JobTitle")
            ddlJobs.DataTextField = "JobTitle"
            ddlJobs.DataValueField = "Jobid"
            ddlJobs.DataBind()
            Dim lblJobs As String = CType(e.Row.FindControl("job_lbl"), Label).Text
            Try
                ddlJobs.Items.FindByValue(lblJobs).Selected = True
            Catch

            End Try

        End If
    End Sub

    Private Function GetData(query As String) As DataSet
        Dim cmd As New SqlCommand(query)
        Using con As New SqlConnection(connection_string)
            Using sda As New SqlDataAdapter()
                cmd.Connection = con
                sda.SelectCommand = cmd
                Using ds As New DataSet()
                    sda.Fill(ds)
                    Return ds
                End Using
            End Using
        End Using
    End Function

    Protected Sub BusinessSelectedIndexChanged(sender As Object, e As EventArgs)

        Dim ddlBusiness As DropDownList = CType(sender, DropDownList)

        Dim row As GridViewRow = ddlBusiness.NamingContainer

        If row.RowState = DataControlRowState.Edit Then
            Dim ddlJobs As DropDownList = CType(row.FindControl("job_ddl"), DropDownList)

            Dim businessID As String = ddlBusiness.SelectedValue.ToString

            ddlJobs.DataSource = GetData("SELECT j.ID AS JobID,j.JobTitle
                                            FROM Jobs j
                                            JOIN businessinfo b
	                                            ON j.id = b.position1
	                                            OR j.id = b.position2
	                                            OR j.id = b.position3
	                                            OR j.id = b.position4
	                                            OR j.id = b.position5
	                                            OR j.id = b.position6
	                                            OR j.id = b.position7
	                                            OR j.id = b.position8
	                                            OR j.id = b.position9
	                                            OR j.id = b.position10
                                            WHERE b.Id='" & businessID & "'")
            ddlJobs.DataTextField = "JobTitle"
            ddlJobs.DataValueField = "Jobid"
            ddlJobs.DataBind()

            Try
                Dim lblJobs As String = CType(row.FindControl("job_lbl"), Label).Text

                If ddlJobs.Items.Contains(ddlJobs.Items.FindByText(lblJobs)) Then
                    ddlJobs.Items.FindByValue(lblJobs).Selected = True
                Else
                    ddlJobs.Items.FindByValue(ddlJobs.Items(0).Value).Selected = True
                End If
            Catch
                ddlJobs.Items.Clear()
            End Try
        End If
    End Sub

    'Private Sub date_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles date_ddl.SelectedIndexChanged
    '    If date_ddl.SelectedIndex <> 0 Then
    '        loadData()
    '    End If
    'End Sub

    Function GetEmptNum(ByVal Business As String, ByVal position As String) As Integer
        Dim empID As Integer = 0

        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim sql As String = "SELECT employeeNumber From studentInfo_template WHERE business='" & Business & "' and job='" & position & "'"
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd.CommandText = sql
            cmd.Connection = con
            dr = cmd.ExecuteReader

            While dr.Read()
                empID = CType(dr(0).ToString, Integer)
            End While

            cmd.Dispose()
            con.Close()
        Catch

        Finally
            cmd.Dispose()
            con.Close()
        End Try

        Return empID
    End Function



    Private Sub business_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles business_ddl.SelectedIndexChanged
        If business_ddl.SelectedIndex <> 0 Then
            loadData()
        End If
    End Sub

    Protected Sub submit_btn_Click(sender As Object, e As EventArgs) Handles submit_btn.Click
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "ISI_confirm", "ISI_confirm();", True)
    End Sub

    Protected Sub confirm_btn_Click(sender As Object, e As EventArgs) Handles confirm_btn.Click
        Using con As New SqlConnection(connection_string)
            Using cmd As New SqlCommand("UPDATE visitInfo SET teacherCompleted=1, lastEdited='" & DateTime.Now & "' WHERE ID='" & VisitID & "'")
                cmd.Connection = con
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using

        ScriptManager.RegisterStartupScript(Me.Page, Me.Page.[GetType](), "OpenEmail", "javascript:window.location.href='mailto:tomlinl@pcsb.org ?subject=EV Student Input Confirmation: " & Schools_lbl.Text & " " & visitDate_lbl.Text & "&body=I am confirming that my students are in the database for " & visitDate_lbl.Text & ". Time completed: " & DateTime.Now & " ';", True)

        'employees_dgv.Visible = True
        Dim schoolID As String = Request.QueryString("b")
        Response.Redirect("/pages/print/Print_ISI.aspx?b=" & schoolID)

    End Sub

    Protected Sub back_btn_Click(sender As Object, e As EventArgs) Handles back_btn.Click
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "Exit_account", "Exit_account();", True)
    End Sub

    Protected Sub print_btn_Click(sender As Object, e As EventArgs) Handles print_btn.Click
        'employees_dgv.Visible = True
        Dim schoolID As String = Request.QueryString("b")
        Response.Redirect("/pages/print/Print_ISI.aspx?b=" & schoolID)
    End Sub

    Protected Sub logout_btn_Click(sender As Object, e As EventArgs) Handles logout_btn.Click
        HttpContext.Current.Session.Abandon()
        Response.Redirect("default.aspx")
    End Sub

    Protected Sub teacherHome_btn_Click(sender As Object, e As EventArgs) Handles teacherHome_btn.Click
        Dim schoolID As String = Request.QueryString("b")
        Dim teacherID As String = Request.QueryString("c")
        Response.Redirect(".\teacher_home.aspx?b=" & schoolID & "&c=" & teacherID)
    End Sub

    Protected Sub Email1_a_Click(sender As Object, e As EventArgs) Handles email1_a.ServerClick
        ScriptManager.RegisterStartupScript(Me.Page, Me.Page.[GetType](), "OpenEmail", "javascript:window.location.href='mailto:sweeneya@pcsb.org?subject=ISI - " & visitDate_lbl.Text & " | " & schoolID & " ';", True)
    End Sub

    Protected Sub Email2_a_Click(sender As Object, e As EventArgs) Handles email2_a.ServerClick
        ScriptManager.RegisterStartupScript(Me.Page, Me.Page.[GetType](), "OpenEmail", "javascript:window.location.href='mailto:sweeneya@pcsb.org?subject=ISI - " & visitDate_lbl.Text & " | " & schoolID & " ';", True)
    End Sub

End Class