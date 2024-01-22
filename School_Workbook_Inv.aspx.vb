Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Drawing

Public Class School_Workbook_Inv
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
    Dim VisitID As New Class_VisitData
    Dim Visit As Integer = VisitID.GetVisitID
    'Dim schoolHeader1 As New SchoolHeader

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("LoggedIn") <> "1" Then
            Response.Redirect(".\default.aspx")
        End If

        If Not (IsPostBack) Then
            Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
            Dim con As New SqlConnection
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim sql As String = "SELECT FORMAT(visitDate,'MM/dd/yyyy') as visitDate FROM visitinfo ORDER BY visitDate DESC"
            Dim sql2 As String = "SELECT schoolname FROM schoolInfo  WHERE NOT schoolName = 'A1 No School Scheduled' AND NOT id='505' ORDER BY schoolName"

            If Visit <> 0 Then
                visitdate_hf.Value = Visit
            End If

            'Populate DDL with schools
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.CommandText = sql2
                cmd.Connection = con
                dr = cmd.ExecuteReader

                While dr.Read()
                    schoolNameSearch_ddl.Items.Add(dr(0).ToString)
                End While

                schoolNameSearch_ddl.Items.Insert(0, "")

                cmd.Dispose()
                con.Close()
            Catch
                MsgBox("Select a valid business name")
            Finally
                cmd.Dispose()
                con.Close()
            End Try

            'Populating school header
            Dim header As New Class_SchoolHeader
            headerSchoolName_lbl.Text = header.GetSchoolHeader()

        End If
    End Sub

    Sub AddRequest()
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"

        'Check if fields are populated
        If dateRequest_tb.Text = Nothing Or dateRequest_tb.Text = "" Then
            error_lbl.Text = "Please enter a request date and number requested."
            Exit Sub
        End If

        If numRequest_tb.Text = Nothing Or numRequest_tb.Text = "" Then
            error_lbl.Text = "Please enter a request date and number requested."
            Exit Sub
        End If

        'Insert data from request fields into DB
        Using con As New SqlConnection(connection_string)
            Using cmd As New SqlCommand("INSERT INTO workbooksInventory (
													 schoolName
													,dateRequested
													,workbooksRequested)													
												VALUES ( 
													@schoolName
													,@dateRequested
													,@workbooksRequested);")
                cmd.Parameters.Add("@schoolName", SqlDbType.VarChar).Value = schoolNameSearch_ddl.SelectedValue
                cmd.Parameters.Add("@dateRequested", SqlDbType.VarChar).Value = dateRequest_tb.Text
                cmd.Parameters.Add("@workbooksRequested", SqlDbType.VarChar).Value = numRequest_tb.Text
                cmd.Connection = con
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using

        'Enable delivery button and fields

        'Clear fields
        dateRequest_tb.Text = ""
        numRequest_tb.Text = ""

        LoadData()

    End Sub

    Sub LoadData()
        Dim con As New SqlConnection
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim schoolSQL As String = "SELECT schoolName, phone, schoolType, county FROM schoolInfo WHERE schoolName = '" & schoolNameSearch_ddl.SelectedValue & "'"
        Dim teacherSQL As String = "SELECT TRIM(firstName) + ' ' + TRIM(lastName) as teacherName FROM teacherInfo WHERE isContact=1 AND schoolName = '" & schoolNameSearch_ddl.SelectedValue & "'"
        Dim visitSQL As String = "SELECT FORMAT(v.visitDate, 'MM/dd/yy') as visitDate, v.studentCount FROM visitInfo v LEFT JOIN schoolInfo s ON s.ID = v.school LEFT JOIN schoolInfo s2 ON s2.ID = v.school2 LEFT JOIN schoolInfo s3 ON s3.ID = v.school3 LEFT JOIN schoolInfo s4 ON s4.ID = v.school4 LEFT JOIN schoolInfo s5 ON s5.ID = v.school5 WHERE s.schoolName='" & schoolNameSearch_ddl.SelectedValue & "' OR s2.schoolName='" & schoolNameSearch_ddl.SelectedValue & "' OR s3.schoolName='" & schoolNameSearch_ddl.SelectedValue & "'  OR s4.schoolName='" & schoolNameSearch_ddl.SelectedValue & "' OR s5.schoolName='" & schoolNameSearch_ddl.SelectedValue & "' AND NOT v.school=1 ORDER BY v.visitDate ASC"
        Dim workbooksSQL As String = "SELECT id, schoolName, dateRequested, dateDelivered, workbooksRequested, workbooksDelivered FROM workbooksInventory WHERE schoolName = '" & schoolNameSearch_ddl.SelectedValue & "' AND dateDelivered IS NULL AND workbooksDelivered IS NULL"

        'Clear out error
        error_lbl.Text = ""

        'Clear out workbooks table
        workbooks_dgv.DataSource = Nothing
        workbooks_dgv.DataBind()

        'Make div visible
        school_div.Visible = True

        'Execute SQL statement and load data (display and table) - School Info
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd.CommandText = schoolSQL
            cmd.Connection = con
            dr = cmd.ExecuteReader

            While dr.Read()
                schoolName_lbl.Text = dr("schoolName").ToString()
                phone_lbl.Text = dr("phone").ToString()
                schoolType_lbl.Text = dr("schoolType").ToString()
                county_lbl.Text = dr("county").ToString()
            End While

            cmd.Dispose()
            con.Close()
        Catch
            error_lbl.Text = "Error in loaddata(). Error in school SQL statement."
            cmd.Dispose()
            con.Close()
            Exit Sub
        End Try

        'Execute SQL statement and load data (display and table) - Visit Info
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd.CommandText = visitSQL
            cmd.Connection = con
            dr = cmd.ExecuteReader

            While dr.Read()
                visitDate_lbl.Text = dr("visitDate").ToString()
                studentCount_lbl.Text = dr("studentCount").ToString
            End While

            cmd.Dispose()
            con.Close()
        Catch
            error_lbl.Text = "Error in loaddata(). Error in visit SQL statement."
            cmd.Dispose()
            con.Close()
            Exit Sub
        End Try

        'Execute SQL statement and load data (display and table) - Teacher Info
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd.CommandText = teacherSQL
            cmd.Connection = con
            dr = cmd.ExecuteReader

            While dr.Read()
                contactTeacher_lbl.Text = dr("teacherName").ToString
            End While

            cmd.Dispose()
            con.Close()
        Catch
            error_lbl.Text = "Error in loaddata(). Error in teacher SQL statement."
            cmd.Dispose()
            con.Close()
            Exit Sub
        End Try

        cmd.Dispose()
        con.Close()

        'Load data into table
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "SELECT id, schoolName, dateRequested, workbooksRequested, dateDelivered, workbooksDelivered
                                FROM workbooksInventory
                                WHERE schoolName = '" & schoolNameSearch_ddl.SelectedValue & "'
                                ORDER BY dateRequested DESC"

            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)
            workbooks_dgv.DataSource = dt
            workbooks_dgv.DataBind()

            cmd.Dispose()
            con.Close()

        Catch
            error_lbl.Text = "Error in LoadData(). Cannot get load data for workbooks table."
            Exit Sub
        End Try

        'Check if request fields are in table, if not, disable delivery button and fields
        'Try
        '    con.ConnectionString = connection_string
        '    con.Open()
        '    cmd.CommandText = workbooksSQL
        '    cmd.Connection = con
        '    dr = cmd.ExecuteReader

        '    If dr("dateDelivered").ToString <> Nothing And dr("workbooksDelivered").ToString <> Nothing Then
        '        addDelivery_btn.Enabled = True
        '        dateDelivery_tb.Enabled = True
        '        numDelivery_tb.Enabled = True
        '    Else
        '        addDelivery_btn.Enabled = False
        '        dateDelivery_tb.Enabled = False
        '        numDelivery_tb.Enabled = False
        '    End If
        'Catch
        '    error_lbl.Text = "Error in loaddata(). Error with workbooks SQL line."
        '    Exit Sub
        'End Try

        'Highlight row being edited
        For Each row As GridViewRow In workbooks_dgv.Rows
            If row.RowIndex = workbooks_dgv.EditIndex Then
                row.BackColor = ColorTranslator.FromHtml("#ebe534")
                'row.BorderColor = ColorTranslator.FromHtml("#ffffff")
                row.BorderWidth = 2
            End If
        Next

    End Sub

    Public Function IsDate(input As String) As Boolean
        Dim result As DateTime
        Return DateTime.TryParse(input, result)
    End Function

    Private Sub workbooks_dgv_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles workbooks_dgv.RowUpdating
        Dim row As GridViewRow = workbooks_dgv.Rows(0)  'Code is used to enable the editing prodecure
        Dim ID As Integer = Convert.ToInt32(workbooks_dgv.DataKeys(e.RowIndex).Values(0)) 'Gets id number
        Dim dateRequested As String = TryCast(workbooks_dgv.Rows(e.RowIndex).FindControl("dgvDateReq_tb"), TextBox).Text
        Dim workbooksRequested As String = TryCast(workbooks_dgv.Rows(e.RowIndex).FindControl("workbooksRequested_tb"), TextBox).Text
        Dim dateDelivered As String = TryCast(workbooks_dgv.Rows(e.RowIndex).FindControl("dgvDateDel_tb"), TextBox).Text
        Dim workbooksDelivered As String = TryCast(workbooks_dgv.Rows(e.RowIndex).FindControl("workbooksDelivered_tb"), TextBox).Text

        'Check if date entered is valid
        If IsDate(dateRequested) = False Or IsDate(dateDelivered) = False Then
            error_lbl.Text = "Please enter a valid date. (MM/DD/YYYY, MM-DD-YYYY, M-D-YY, or M/D/YY"
            Exit Sub
        End If

        Try
            Using con As New SqlConnection(connection_string)
                Using cmd As New SqlCommand("UPDATE workbooksInventory SET dateRequested=@dateRequested, workbooksRequested=@workbooksRequested, dateDelivered=@dateDelivered, workbooksDelivered=@workbooksDelivered WHERE id=@ID")
                    cmd.Parameters.AddWithValue("@ID", ID)
                    cmd.Parameters.AddWithValue("@dateRequested", dateRequested)
                    cmd.Parameters.AddWithValue("@workbooksRequested", workbooksRequested)
                    cmd.Parameters.AddWithValue("@dateDelivered", dateDelivered)
                    cmd.Parameters.AddWithValue("@workbooksDelivered", workbooksDelivered)
                    cmd.Connection = con
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
            workbooks_dgv.EditIndex = -1 'reset grid after editing

            LoadData()

        Catch
            error_lbl.Text = "Error with updating table."
            Exit Sub
        End Try

    End Sub

    Private Sub school_dgv_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles workbooks_dgv.PageIndexChanging
        workbooks_dgv.PageIndex = e.NewPageIndex
        LoadData()
    End Sub

    Private Sub school_dgv_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles workbooks_dgv.RowCancelingEdit
        workbooks_dgv.EditIndex = -1
        LoadData()
    End Sub

    Private Sub workbooks_dgv_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles workbooks_dgv.RowEditing
        workbooks_dgv.EditIndex = e.NewEditIndex
        LoadData()
    End Sub

    Protected Sub schoolNameSearch_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles schoolNameSearch_ddl.SelectedIndexChanged
        If schoolNameSearch_ddl.SelectedIndex <> 0 Then
            LoadData()
        End If
    End Sub

    Protected Sub addRequest_btn_Click(sender As Object, e As EventArgs) Handles addRequest_btn.Click
        AddRequest()
    End Sub

End Class