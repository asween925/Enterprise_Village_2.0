Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Drawing

Public Class Employee_Management_System_Review
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
    Dim Visits As New Class_VisitData
    Dim Businesses As New Class_BusinessData
    Dim Schools As New Class_SchoolData
    Dim Students As New Class_StudentData
    Dim SH As New Class_SchoolHeader
    Dim VisitID As Integer = Visits.GetVisitID

    Private Sub Employee_Management_System_Review_Load(sender As Object, e As EventArgs) Handles Me.Load

        'Redirects to log in page if not logged in
        If Session("LoggedIn") <> "1" Then
            Response.Redirect("../../default.aspx")
        End If

        If Not (IsPostBack) Then

            'Populating school header
            headerSchoolName_lbl.Text = SH.GetSchoolHeader()

        End If
    End Sub

    Sub LoadData()
        Dim visitDate As String = date_tb.Text
        Dim VIDOfDate As Integer = Visits.GetVisitIDFromDate(date_tb.Text)
        Dim businessID As Integer = Businesses.GetBusinessID(business_ddl.SelectedItem.ToString())
        Dim da As New SqlDataAdapter
        Dim dt As New DataTable
        Dim SQLStatement As String = "Select s.id, s.firstName, s.lastName, s.accountNumber, b.id as BusinessID,j.id as JobID, s.schoolID as 'schoolID'
                                    from studentInfo s
                                    inner join businessInfo b 
	                                    on b.id=s.businessID
                                    left join jobs j
	                                    on j.id=s.jobID
                                    inner join visitInfo v
	                                    on v.id=s.visitID
                                    where v.id='" & VIDOfDate & "' and b.ID='" & businessID & "'"

        'Clear error
        error_lbl.Text = ""

        'Load table
        'Try
        '    Students.LoadEMSTable(VIDOfDate, Review_dgv, businessID)
        'Catch
        '    error_lbl.Text = "Error in loaddata(). Cannot load data."
        '    Exit Sub
        'End Try

        'Load table
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd.CommandText = SQLStatement
            cmd.Connection = con
            da.SelectCommand = cmd
            da.Fill(dt)

            Review_dgv.DataSource = dt
            Review_dgv.DataBind()
        Catch
            error_lbl.Text = "Error in loaddata(). Cannot load data."
            Exit Sub
        End Try

        'Get closed businesses
        Try
            closedBiz_lbl.Text = Businesses.GetClosedBusinesses(VIDOfDate)
        Catch
            error_lbl.Text = "Error in loaddata(). Could not get closed businesses."
            Exit Sub
        End Try

        'Populate change schools DDL
        Schools.LoadVisitDateSchoolsDDL(visitDate, changeSchool_ddl)

        'Highlight row being edited
        For Each row As GridViewRow In Review_dgv.Rows
            If row.RowIndex = Review_dgv.EditIndex Then
                row.BackColor = ColorTranslator.FromHtml("#ebe534")
                'row.BorderColor = ColorTranslator.FromHtml("#ffffff")
                row.BorderWidth = 2
            End If
        Next

    End Sub

    Sub LoadBusinessDDL()
        Dim visitDate As Date = date_tb.Text
        Dim VIDOfDate As Integer = Visits.GetVisitIDFromDate(visitDate)

        'Make business div visible
        selectBiz_div.Visible = True
        gridview_div.Visible = False

        'Clear out business DDL
        business_ddl.Items.Clear()

        'Load business names into ddl (if they are open for selected visit date)
        Try
            Businesses.LoadBusinessNamesDDL(business_ddl, True, False, VIDOfDate, 0)
        Catch
            error_lbl.Text = "Error in date_ddl. Cannot obtain business names."
            Exit Sub
        End Try

    End Sub

    Sub ChangeSchool()
        Dim businessName As String = business_ddl.SelectedValue
        Dim visitDate As String = date_tb.Text
        Dim schoolName As String = changeSchool_ddl.SelectedValue
        Dim schoolID As String = Schools.GetSchoolID(schoolName)
        Dim businessID As String = Businesses.GetBusinessID(businessName)
        Dim selectedVisitID As String = Visits.GetVisitIDFromDate(visitDate)

        Using con As New SqlConnection(connection_string)
            Using cmd As New SqlCommand("UPDATE studentInfo SET schoolID='" & schoolID & "' WHERE businessID='" & businessID & "' AND visitID='" & selectedVisitID & "'")
                cmd.Connection = con
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using

        LoadData()

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

    Function GetEmptNum(ByVal Business As String, ByVal position As String) As Integer
        Dim empID As Integer = 0

        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim sql As String = "SELECT accountNumber From studentInfo_template WHERE businessID='" & Business & "' and jobID='" & position & "'"
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
            error_lbl.Text = "Error in GetEmptNum."
        Finally
            cmd.Dispose()
            con.Close()
        End Try

        Return empID
    End Function

    Protected Sub OnRowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Dim index As Integer = Convert.ToInt32(e.RowIndex)
        Dim dt As DataTable = TryCast(ViewState("dt"), DataTable)
        dt.Rows(index).Delete()
        ViewState("dt") = dt
        Review_dgv.DataSource = TryCast(ViewState("dt"), DataTable)
        Review_dgv.DataBind()
    End Sub

    Protected Sub OnSelectedIndexChanged(sender As Object, e As EventArgs)
        For Each row As GridViewRow In Review_dgv.Rows
            If row.RowIndex = Review_dgv.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
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
        Dim empNum As Integer = GetEmptNum(businessName, employeePosition)

        'Check if employeePosiution is blank
        If employeePosition = "" Then
            Using con As New SqlConnection(connection_string)
                Using cmd As New SqlCommand("UPDATE studentInfo SET businessID=@business, accountNumber=@employeeID, firstName=@employeeFirst, lastName =@employeeLast, schoolID =@school, jobID=NULL WHERE ID=@Id")
                    cmd.Parameters.AddWithValue("@ID", ID)
                    cmd.Parameters.AddWithValue("@business", businessName)
                    cmd.Parameters.AddWithValue("@employeeID", employeeNumber)
                    cmd.Parameters.AddWithValue("@employeeFirst", employeeFirst)
                    cmd.Parameters.AddWithValue("@employeeLast", employeeLast)
                    'cmd.Parameters.AddWithValue("@employeePosition", employeePosition)
                    cmd.Parameters.AddWithValue("@school", school)
                    cmd.Connection = con
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
        Else
            Using con As New SqlConnection(connection_string)
                Using cmd As New SqlCommand("UPDATE studentInfo SET businessID=@business, accountNumber=@employeeID, firstName=@employeeFirst, lastName =@employeeLast, schoolID =@school, jobID=@employeePosition WHERE ID=@Id")
                    cmd.Parameters.AddWithValue("@ID", ID)
                    cmd.Parameters.AddWithValue("@business", businessName)
                    cmd.Parameters.AddWithValue("@employeeID", employeeNumber)
                    cmd.Parameters.AddWithValue("@employeeFirst", employeeFirst)
                    cmd.Parameters.AddWithValue("@employeeLast", employeeLast)
                    cmd.Parameters.AddWithValue("@employeePosition", employeePosition)
                    cmd.Parameters.AddWithValue("@school", school)
                    cmd.Connection = con
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
        End If


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
        LoadData()
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

            ddlSchool1.DataSource = GetData("SELECT s.id as 'id', s.schoolName as 'schoolName'
											  FROM schoolInfo s 
											  JOIN visitInfo v ON v.school = s.id OR v.school2 = s.id OR v.school3 = s.id OR v.school4 = s.id OR v.school5 = s.id
											  WHERE v.visitDate='" & date_tb.Text & "' AND NOT s.id=505 
											  ORDER BY schoolName ")
            ddlSchool1.DataTextField = "schoolName"
            ddlSchool1.DataValueField = "id"
            ddlSchool1.DataBind()
            Dim lblSchool1 As String = CType(e.Row.FindControl("schoolID_lbl"), Label).Text

            If lblSchool1 = Nothing Then
                ddlSchool1.Items.FindByValue("A1 No School Scheduled").Selected = True
            Else
                ddlSchool1.Items.FindByValue(lblSchool1).Selected = True
            End If

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
            ddlJobs.Items.Insert(0, "")
            Dim lblJobs As String = CType(e.Row.FindControl("job_lbl"), Label).Text

            If lblJobs <> Nothing Then
                ddlJobs.Items.FindByValue(lblJobs).Selected = True
            End If

        End If
    End Sub



    Protected Sub changeSchool_btn_Click(sender As Object, e As EventArgs) Handles changeSchool_btn.Click
        If changeSchool_ddl.SelectedIndex <> 0 Then
            ChangeSchool()
        Else
            error_lbl.Text = "Please select a school to assign to business."
            Exit Sub
        End If
    End Sub

    Protected Sub date_tb_TextChanged(sender As Object, e As EventArgs) Handles date_tb.TextChanged
        If date_tb.Text <> Nothing Then
            LoadBusinessDDL()
        End If
    End Sub



    Private Sub business_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles business_ddl.SelectedIndexChanged
        If business_ddl.SelectedIndex <> 0 Then
            gridview_div.Visible = True
            LoadData()
        Else
            gridview_div.Visible = False
        End If
    End Sub

End Class