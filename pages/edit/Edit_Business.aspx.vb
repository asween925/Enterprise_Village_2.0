﻿Imports System.IO
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Net.Mime.MediaTypeNames
Imports System.Net
Public Class Edit_Business
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
    Dim BusinessData As New Class_BusinessData
    Dim VisitData As New Class_VisitData
    Dim VisitID As Integer = VisitData.GetVisitID
    Dim SH As New Class_SchoolHeader

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("LoggedIn") <> "1" Then
            Response.Redirect("../../default.aspx")
        End If

        If Not (IsPostBack) Then

            'Populating school header
            headerSchoolName_lbl.Text = SH.GetSchoolHeader()

            'Load business names into ddl
            BusinessData.LoadBusinessNamesDDL(businessName_ddl)

            'Load data
            LoadData()
        End If

    End Sub

    Sub LoadData()

        'Clear out visit table
        business_dgv.DataSource = Nothing
        business_dgv.DataBind()

        'Clear error label
        error_lbl.Text = ""

        'Fill visit table
        Try
            BusinessData.LoadEditBusinessTable(business_dgv)
        Catch
            error_lbl.Text = "Error in LoadData(). Could not fill table."
            Exit Sub
        End Try

        'Highlight row being edited
        For Each row As GridViewRow In business_dgv.Rows
            If row.RowIndex = business_dgv.EditIndex Then
                row.BackColor = ColorTranslator.FromHtml("#ebe534")
                'row.BorderColor = ColorTranslator.FromHtml("#ffffff")
                row.BorderWidth = 2
            End If
        Next

    End Sub

    Sub LoadAssignJobsToAcctNums(BusinessName As String)
        Dim da As New SqlDataAdapter
        Dim dt As New DataTable
        Dim BusinessID As String
        Dim SQLStatement As String = "SELECT id, accountNumber, jobID FROM studentInfo_template "

        'Clear out visit table
        jobs_dgv.DataSource = Nothing
        jobs_dgv.DataBind()

        'Check for business name
        If BusinessName <> Nothing Then

            'Get business ID
            BusinessID = BusinessData.GetBusinessID(BusinessName)

            'Assign it to SQL statement
            SQLStatement = SQLStatement & "WHERE businessID='" & BusinessID & "'"
        Else
            error_lbl.Text = "Error in LoadAssign(). Could not find business name."
            Exit Sub
        End If

        'Fill visit table
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd.CommandText = SQLStatement
            cmd.Connection = con
            da.SelectCommand = cmd
            da.Fill(dt)

            jobs_dgv.DataSource = dt
            jobs_dgv.DataBind()
        Catch
            error_lbl.Text = "Error in LoadAssign(). Could not fill table."
            Exit Sub
        End Try

        'Highlight row being edited
        For Each row As GridViewRow In jobs_dgv.Rows
            If row.RowIndex = jobs_dgv.EditIndex Then
                row.BackColor = ColorTranslator.FromHtml("#ebe534")
                'row.BorderColor = ColorTranslator.FromHtml("#ffffff")
                row.BorderWidth = 2
            End If
        Next
    End Sub

    Private Sub jobs_dgv_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles jobs_dgv.RowUpdating
        Dim row As GridViewRow = jobs_dgv.Rows(0)                           'Code is used to enable the editing prodecure
        Dim ID As Integer = Convert.ToInt32(jobs_dgv.DataKeys(e.RowIndex).Values(0)) 'Gets id number
        Dim JobID As String = TryCast(jobs_dgv.Rows(e.RowIndex).FindControl("jobTitleDGV_ddl"), DropDownList).SelectedValue.ToString

        'Check if job DDL is blank
        If JobID = "" Then
            Try
                'Update student info template
                Using con As New SqlConnection(connection_string)
                    Using cmd As New SqlCommand("UPDATE studentInfo_template SET jobID=NULL WHERE ID=@Id")
                        cmd.Parameters.AddWithValue("@ID", ID)
                        'cmd.Parameters.AddWithValue("@jobID", JobID)
                        cmd.Connection = con
                        con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End Using
                End Using

                jobs_dgv.EditIndex = -1       'reset the grid after editing
                LoadAssignJobsToAcctNums(businessName_ddl.SelectedValue)

            Catch ex As Exception
                error_lbl.Text = "Error in updating for assignments. Cannot update row for null value."
                Exit Sub
            End Try
        Else
            Try
                'Update student info template
                Using con As New SqlConnection(connection_string)
                    Using cmd As New SqlCommand("UPDATE studentInfo_template SET jobID=@jobID WHERE ID=@Id")
                        cmd.Parameters.AddWithValue("@ID", ID)
                        cmd.Parameters.AddWithValue("@jobID", JobID)
                        cmd.Connection = con
                        con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End Using
                End Using

                jobs_dgv.EditIndex = -1       'reset the grid after editing
                LoadAssignJobsToAcctNums(businessName_ddl.SelectedValue)

            Catch ex As Exception
                error_lbl.Text = "Error in updating for assignments. Cannot update row."
                Exit Sub
            End Try
        End If

        'Update DB

    End Sub

    Private Sub jobs_dgv_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles jobs_dgv.RowEditing
        jobs_dgv.EditIndex = e.NewEditIndex
        LoadAssignJobsToAcctNums(businessName_ddl.SelectedValue)
    End Sub

    Private Sub jobs_dgv_RowCanceling(sender As Object, e As GridViewCancelEditEventArgs) Handles jobs_dgv.RowCancelingEdit
        jobs_dgv.EditIndex = -1
        LoadAssignJobsToAcctNums(businessName_ddl.SelectedValue)
    End Sub

    Private Sub jobs_dgv_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles jobs_dgv.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Dim ddlPosition As DropDownList = CType(e.Row.FindControl("jobTitleDGV_ddl"), DropDownList)
            Dim lblPosition As String = CType(e.Row.FindControl("jobIDDGV_lbl"), Label).Text
            Dim businessID As String = BusinessData.GetBusinessID(businessName_ddl.SelectedValue)

            ddlPosition.DataSource = GetData("SELECT j.ID AS JobID,j.JobTitle
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
            ddlPosition.DataTextField = "jobTitle"
            ddlPosition.DataValueField = "Jobid"
            ddlPosition.DataBind()
            ddlPosition.Items.Insert(0, "")

            If lblPosition <> Nothing Then
                ddlPosition.Items.FindByValue(lblPosition).Selected = True
            End If

        End If
    End Sub

    Private Sub business_dgv_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles business_dgv.RowUpdating
        Dim SQLStatement As String = "UPDATE businessInfo SET businessName=@businessName, logoPath=@logoPath, address=@address, startingBalance=@startingBalance"
        Dim row As GridViewRow = business_dgv.Rows(0)                           'Code is used to enable the editing prodecure
        Dim ID As Integer = Convert.ToInt32(business_dgv.DataKeys(e.RowIndex).Values(0)) 'Gets id number
        Dim BusinessName As String = TryCast(business_dgv.Rows(e.RowIndex).FindControl("businessNameDGV_tb"), TextBox).Text
        Dim Address As String = TryCast(business_dgv.Rows(e.RowIndex).FindControl("addressDGV_tb"), TextBox).Text
        Dim StartingBalance As String = TryCast(business_dgv.Rows(e.RowIndex).FindControl("startingBalanceDGV_tb"), TextBox).Text
        Dim FileUpload1 As FileUpload = CType(business_dgv.Rows(e.RowIndex).FindControl("FileUpload1"), FileUpload)
        Dim LogoPath As String = "../../media/Logos/" & ID & "/"
        Dim JobTitle1 As String = TryCast(business_dgv.Rows(e.RowIndex).FindControl("position1DGV_ddl"), DropDownList).SelectedValue.ToString
        Dim JobTitle2 As String = TryCast(business_dgv.Rows(e.RowIndex).FindControl("position2DGV_ddl"), DropDownList).SelectedValue.ToString
        Dim JobTitle3 As String = TryCast(business_dgv.Rows(e.RowIndex).FindControl("position3DGV_ddl"), DropDownList).SelectedValue.ToString
        Dim JobTitle4 As String = TryCast(business_dgv.Rows(e.RowIndex).FindControl("position4DGV_ddl"), DropDownList).SelectedValue.ToString
        Dim JobTitle5 As String = TryCast(business_dgv.Rows(e.RowIndex).FindControl("position5DGV_ddl"), DropDownList).SelectedValue.ToString
        Dim JobTitle6 As String = TryCast(business_dgv.Rows(e.RowIndex).FindControl("position6DGV_ddl"), DropDownList).SelectedValue.ToString
        Dim JobTitle7 As String = TryCast(business_dgv.Rows(e.RowIndex).FindControl("position7DGV_ddl"), DropDownList).SelectedValue.ToString
        Dim JobTitle8 As String = TryCast(business_dgv.Rows(e.RowIndex).FindControl("position8DGV_ddl"), DropDownList).SelectedValue.ToString
        Dim JobTitle9 As String = TryCast(business_dgv.Rows(e.RowIndex).FindControl("position9DGV_ddl"), DropDownList).SelectedValue.ToString
        Dim JobTitle10 As String = TryCast(business_dgv.Rows(e.RowIndex).FindControl("position10DGV_ddl"), DropDownList).SelectedValue.ToString
        Dim JobID1 As String
        Dim JobID2 As String
        Dim JobID3 As String
        Dim JobID4 As String
        Dim JobID5 As String
        Dim JobID6 As String
        Dim JobID7 As String
        Dim JobID8 As String
        Dim JobID9 As String
        Dim JobID10 As String
        Dim UpdatedLogo As String
        Dim Logos = BusinessData.GetBusinessLogos(ID)

        'Get Job title IDs / check if job title if blank
        Try
            If JobTitle1 <> "" Or JobTitle1 <> Nothing Then
                JobID1 = BusinessData.GetJobID(JobTitle1)
                SQLStatement &= ", position1='" & JobID1 & "'"
            Else
                Exit Try
            End If

            If JobTitle2 <> "" Or JobTitle2 <> Nothing Then
                JobID2 = BusinessData.GetJobID(JobTitle2)
                SQLStatement &= ", position2='" & JobID2 & "'"
            Else
                Exit Try
            End If

            If JobTitle3 <> "" Or JobTitle3 <> Nothing Then
                JobID3 = BusinessData.GetJobID(JobTitle3)
                SQLStatement &= ", position3='" & JobID3 & "'"
            Else
                Exit Try
            End If

            If JobTitle4 <> "" Or JobTitle4 <> Nothing Then
                JobID4 = BusinessData.GetJobID(JobTitle4)
                SQLStatement &= ", position4='" & JobID4 & "'"
            Else
                Exit Try
            End If

            If JobTitle5 <> "" Or JobTitle5 <> Nothing Then
                JobID5 = BusinessData.GetJobID(JobTitle5)
                SQLStatement &= ", position5='" & JobID5 & "'"
            Else
                Exit Try
            End If

            If JobTitle6 <> "" Or JobTitle6 <> Nothing Then
                JobID6 = BusinessData.GetJobID(JobTitle6)
                SQLStatement &= ", position6='" & JobID6 & "'"
            Else
                Exit Try
            End If

            If JobTitle7 <> "" Or JobTitle7 <> Nothing Then
                JobID7 = BusinessData.GetJobID(JobTitle7)
                SQLStatement &= ", position7='" & JobID7 & "'"
            Else
                Exit Try
            End If

            If JobTitle8 <> "" Or JobTitle8 <> Nothing Then
                JobID8 = BusinessData.GetJobID(JobTitle8)
                SQLStatement &= ", position8='" & JobID8 & "'"
            Else
                Exit Try
            End If

            If JobTitle9 <> "" Or JobTitle9 <> Nothing Then
                JobID9 = BusinessData.GetJobID(JobTitle9)
                SQLStatement &= ", position9='" & JobID9 & "'"
            Else
                Exit Try
            End If

            If JobTitle10 <> "" Or JobTitle10 <> Nothing Then
                JobID10 = BusinessData.GetJobID(JobTitle10)
                SQLStatement &= ", position10='" & JobID10 & "'"
            Else
                Exit Try
            End If
        Catch
            error_lbl.Text = "Error in rowUpdating. Cannot check job IDs."
            Exit Sub
        End Try

        'Add WHERE clause
        SQLStatement &= " WHERE id=@ID"

        'Check if file upload has a file
        If FileUpload1.HasFile Then
            LogoPath += FileUpload1.FileName
            FileUpload1.SaveAs(MapPath(LogoPath))
            UpdatedLogo = FileUpload1.FileName
        Else
            'Get the original file name from business info
            UpdatedLogo = GetOriginalLogoFile(ID)
        End If

        'error_lbl.Text = UpdatedLogo
        'Exit Sub

        'Update DB
        Try
            Using con As New SqlConnection(connection_string)
                Using cmd As New SqlCommand(SQLStatement)
                    cmd.Parameters.AddWithValue("@ID", ID)
                    cmd.Parameters.AddWithValue("@businessName", BusinessName)
                    cmd.Parameters.AddWithValue("@logoPath", UpdatedLogo)
                    cmd.Parameters.AddWithValue("@address", Address)
                    cmd.Parameters.AddWithValue("@startingBalance", StartingBalance)
                    cmd.Connection = con
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
            business_dgv.EditIndex = -1       'reset the grid after editing
            LoadData()

        Catch ex As Exception
            error_lbl.Text = "Error in rowUpdating. Cannot update row."
            Exit Sub
        End Try

    End Sub

    Private Sub business_dgv_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles business_dgv.RowEditing
        business_dgv.EditIndex = e.NewEditIndex
        LoadData()
    End Sub

    Private Sub business_dgv_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles business_dgv.RowCancelingEdit
        business_dgv.EditIndex = -1
        LoadData()
    End Sub

    Private Sub business_dgv_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles business_dgv.PageIndexChanging
        business_dgv.PageIndex = e.NewPageIndex
        LoadData()
    End Sub

    Private Sub business_dgv_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles business_dgv.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Dim ddlPosition1 As DropDownList = CType(e.Row.FindControl("position1DGV_ddl"), DropDownList)
            Dim ddlPosition2 As DropDownList = CType(e.Row.FindControl("position2DGV_ddl"), DropDownList)
            Dim ddlPosition3 As DropDownList = CType(e.Row.FindControl("position3DGV_ddl"), DropDownList)
            Dim ddlPosition4 As DropDownList = CType(e.Row.FindControl("position4DGV_ddl"), DropDownList)
            Dim ddlPosition5 As DropDownList = CType(e.Row.FindControl("position5DGV_ddl"), DropDownList)
            Dim ddlPosition6 As DropDownList = CType(e.Row.FindControl("position6DGV_ddl"), DropDownList)
            Dim ddlPosition7 As DropDownList = CType(e.Row.FindControl("position7DGV_ddl"), DropDownList)
            Dim ddlPosition8 As DropDownList = CType(e.Row.FindControl("position8DGV_ddl"), DropDownList)
            Dim ddlPosition9 As DropDownList = CType(e.Row.FindControl("position9DGV_ddl"), DropDownList)
            Dim ddlPosition10 As DropDownList = CType(e.Row.FindControl("position10DGV_ddl"), DropDownList)
            Dim lblPosition1 As String = CType(e.Row.FindControl("position1DGV_lbl"), Label).Text
            Dim lblPosition2 As String = CType(e.Row.FindControl("position2DGV_lbl"), Label).Text
            Dim lblPosition3 As String = CType(e.Row.FindControl("position3DGV_lbl"), Label).Text
            Dim lblPosition4 As String = CType(e.Row.FindControl("position4DGV_lbl"), Label).Text
            Dim lblPosition5 As String = CType(e.Row.FindControl("position5DGV_lbl"), Label).Text
            Dim lblPosition6 As String = CType(e.Row.FindControl("position6DGV_lbl"), Label).Text
            Dim lblPosition7 As String = CType(e.Row.FindControl("position7DGV_lbl"), Label).Text
            Dim lblPosition8 As String = CType(e.Row.FindControl("position8DGV_lbl"), Label).Text
            Dim lblPosition9 As String = CType(e.Row.FindControl("position9DGV_lbl"), Label).Text
            Dim lblPosition10 As String = CType(e.Row.FindControl("position10DGV_lbl"), Label).Text

            ddlPosition1.DataSource = GetData("SELECT DISTINCT jobTitle FROM jobs UNION SELECT '' ORDER BY jobTitle")
            ddlPosition1.DataTextField = "jobTitle"
            ddlPosition1.DataBind()
            ddlPosition1.Items.FindByValue(lblPosition1).Selected = True

            ddlPosition2.DataSource = GetData("SELECT DISTINCT jobTitle FROM jobs UNION SELECT '' ORDER BY jobTitle")
            ddlPosition2.DataTextField = "jobTitle"
            ddlPosition2.DataBind()
            ddlPosition2.Items.FindByValue(lblPosition2).Selected = True

            ddlPosition3.DataSource = GetData("SELECT DISTINCT jobTitle FROM jobs UNION SELECT '' ORDER BY jobTitle")
            ddlPosition3.DataTextField = "jobTitle"
            ddlPosition3.DataBind()

            If lblPosition3 <> Nothing Then
                ddlPosition3.Items.FindByValue(lblPosition3).Selected = True
            End If

            ddlPosition4.DataSource = GetData("SELECT DISTINCT jobTitle FROM jobs UNION SELECT '' ORDER BY jobTitle")
            ddlPosition4.DataTextField = "jobTitle"
            ddlPosition4.DataBind()

            If lblPosition4 <> Nothing Then
                ddlPosition4.Items.FindByValue(lblPosition4).Selected = True
            End If

            ddlPosition5.DataSource = GetData("SELECT DISTINCT jobTitle FROM jobs UNION SELECT '' ORDER BY jobTitle")
            ddlPosition5.DataTextField = "jobTitle"
            ddlPosition5.DataBind()

            If lblPosition5 <> Nothing Then
                ddlPosition5.Items.FindByValue(lblPosition5).Selected = True
            End If

            ddlPosition6.DataSource = GetData("SELECT DISTINCT jobTitle FROM jobs UNION SELECT '' ORDER BY jobTitle")
            ddlPosition6.DataTextField = "jobTitle"
            ddlPosition6.DataBind()

            If lblPosition6 <> Nothing Then
                ddlPosition6.Items.FindByValue(lblPosition6).Selected = True
            End If

            ddlPosition7.DataSource = GetData("SELECT DISTINCT jobTitle FROM jobs UNION SELECT '' ORDER BY jobTitle")
            ddlPosition7.DataTextField = "jobTitle"
            ddlPosition7.DataBind()

            If lblPosition7 <> Nothing Then
                ddlPosition7.Items.FindByValue(lblPosition7).Selected = True
            End If

            ddlPosition8.DataSource = GetData("SELECT DISTINCT jobTitle FROM jobs UNION SELECT '' ORDER BY jobTitle")
            ddlPosition8.DataTextField = "jobTitle"
            ddlPosition8.DataBind()

            If lblPosition8 <> Nothing Then
                ddlPosition8.Items.FindByValue(lblPosition8).Selected = True
            End If

            ddlPosition9.DataSource = GetData("SELECT DISTINCT jobTitle FROM jobs UNION SELECT '' ORDER BY jobTitle")
            ddlPosition9.DataTextField = "jobTitle"
            ddlPosition9.DataBind()

            If lblPosition9 <> Nothing Then
                ddlPosition9.Items.FindByValue(lblPosition9).Selected = True
            End If

            ddlPosition10.DataSource = GetData("SELECT DISTINCT jobTitle FROM jobs UNION SELECT '' ORDER BY jobTitle")
            ddlPosition10.DataTextField = "jobTitle"
            ddlPosition10.DataBind()

            If lblPosition10 <> Nothing Then
                ddlPosition10.Items.FindByValue(lblPosition10).Selected = True
            End If

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

    Private Function GetOriginalLogoFile(BusinessID As Integer)
        Dim LogoFileName As String

        con.ConnectionString = connection_string
        con.Open()
        cmd.CommandText = "SELECT logoPath FROM businessinfo WHERE ID='" & BusinessID & "'"
        cmd.Connection = con
        dr = cmd.ExecuteReader

        While dr.Read()
            LogoFileName = dr(0).ToString
        End While

        cmd.Dispose()
        con.Close()

        Return LogoFileName
    End Function

    Protected Sub businessName_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles businessName_ddl.SelectedIndexChanged
        If businessName_ddl.SelectedIndex <> 0 Then

            'Make jobs div visible
            jobs_dgv.Visible = True

            'Load gridview
            LoadAssignJobsToAcctNums(businessName_ddl.SelectedValue)
        Else

            'Make jobs div invisible
            jobs_dgv.Visible = False
        End If
    End Sub

    Protected Sub changeView_btn_Click(sender As Object, e As EventArgs) Handles changeView_btn.Click
        If businessTable_div.Visible = True Then

            'Change text of button
            changeView_btn.Text = "Edit a Business"

            'Change view to assign positions
            assignJobs_div.Visible = True
            businessTable_div.Visible = False

        Else

            'Change text of button
            changeView_btn.Text = "Assign Positions"

            'Change view to assign positions
            assignJobs_div.Visible = False
            businessTable_div.Visible = True

        End If
    End Sub
End Class