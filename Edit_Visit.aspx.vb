Imports System.Data.SqlClient
Imports System.Drawing
Public Class Edit_Visit
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim DBConnection As New DatabaseConection
    Dim dr As SqlDataReader
    Dim SchoolData As New Class_SchoolData
    Dim VisitID As New Class_VisitData
    Dim Visit As Integer = VisitID.GetVisitID
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Checks if the user is logged in and if not it redirects to the login page
        If Session("LoggedIn") <> "1" Then
            Response.Redirect(".\default.aspx")
        End If

        If Not (IsPostBack) Then
            Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
            Dim con As New SqlConnection
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim sql As String = "SELECT FORMAT(visitDate,'MM/dd/yyyy') as visitDate FROM visitinfo ORDER BY visitDate DESC"

            If Visit <> 0 Then
                visitdate_hf.Value = Visit
            End If

            'Populating school header
            Dim header As New Class_SchoolHeader
            headerSchoolName_lbl.Text = header.GetSchoolHeader()

        End If
    End Sub

    Sub loadData()
        Dim con As New SqlConnection
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim cmd As New SqlCommand
        Dim sql As String = "SELECT v.id, s.id as 'schoolid1', s2.id as 'schoolid2', s3.id as 'schoolid3', s4.id as 'schoolid4', s5.id as 'schoolid5', s.schoolName as 'schoolname1', s2.schoolName as 'schoolname2', s3.schoolName as 'schoolname3', s4.schoolName as 'schoolname4', s5.schoolName as 'schoolname5', v.vTrainingTime, v.vMinCount, v.vMaxCount, v.replyBy, v.visitDate, v.studentCount, v.visitTime
                                  FROM visitInfo v 
                                  LEFT JOIN schoolInfo s ON s.ID = v.school
								  LEFT JOIN schoolInfo s2 ON s2.ID = v.school2
								  LEFT JOIN schoolInfo s3 ON s3.ID = v.school3
								  LEFT JOIN schoolInfo s4 ON s4.ID = v.school4
								  LEFT JOIN schoolInfo s5 ON s5.ID = v.school5
                                  WHERE v.visitDate = '" & date_tb.Text & "'"

        'Clear out visit table
        visit_dgv.DataSource = Nothing
        visit_dgv.DataBind()

        'Clear error label
        error_lbl.Text = ""

        'Fill visit table
        Try
            con.ConnectionString = connection_string
            con.Open()
            Review_sds.ConnectionString = connection_string
            Review_sds.SelectCommand = sql
            visit_dgv.DataSource = Review_sds
            visit_dgv.DataBind()

        Catch
            error_lbl.Text = "Error in LoadData(). Could not fill table."
            cmd.Dispose()
            con.Close()
        End Try

        'Highlight row being edited
        For Each row As GridViewRow In visit_dgv.Rows
            If row.RowIndex = visit_dgv.EditIndex Then
                row.BackColor = ColorTranslator.FromHtml("#ebe534")
                'row.BorderColor = ColorTranslator.FromHtml("#ffffff")
                row.BorderWidth = 2
            End If
        Next

        cmd.Dispose()
        con.Close()

    End Sub

    Protected Sub date_tb_TextChanged(sender As Object, e As EventArgs) Handles date_tb.TextChanged
        If date_tb.Text <> Nothing Then
            gridview_div.Visible = True
            loadData()
        End If
    End Sub
    Private Sub visit_dgv_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles visit_dgv.RowUpdating
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim cond As New SqlConnection
        Dim cmdd As New SqlCommand
        Dim dr As SqlDataReader
        Dim row As GridViewRow = visit_dgv.Rows(0) 'Code is used to enable the editing prodecure
        Dim ID As Integer = Convert.ToInt32(visit_dgv.DataKeys(e.RowIndex).Values(0)) 'Gets id number
        Dim visitDate As String = TryCast(visit_dgv.Rows(e.RowIndex).FindControl("visitDate_tb"), TextBox).Text
        Dim visitTime As String = TryCast(visit_dgv.Rows(e.RowIndex).FindControl("visitTime_tb"), TextBox).Text
        Dim school1 As String = TryCast(visit_dgv.Rows(e.RowIndex).FindControl("school1_ddl"), DropDownList).SelectedValue.ToString  'Try cast is used to try to convert - gets item from ddl
        Dim school2 As String = TryCast(visit_dgv.Rows(e.RowIndex).FindControl("school2_ddl"), DropDownList).SelectedValue.ToString
        Dim school3 As String = TryCast(visit_dgv.Rows(e.RowIndex).FindControl("school3_ddl"), DropDownList).SelectedValue.ToString
        Dim school4 As String = TryCast(visit_dgv.Rows(e.RowIndex).FindControl("school4_ddl"), DropDownList).SelectedValue.ToString
        Dim school5 As String = TryCast(visit_dgv.Rows(e.RowIndex).FindControl("school5_ddl"), DropDownList).SelectedValue.ToString
        Dim vTrainingTime As String = TryCast(visit_dgv.Rows(e.RowIndex).FindControl("vTrainingTime_tb"), TextBox).Text
        Dim vMinCount As String = TryCast(visit_dgv.Rows(e.RowIndex).FindControl("vMinCount_tb"), TextBox).Text
        Dim vMaxCount As String = TryCast(visit_dgv.Rows(e.RowIndex).FindControl("vMaxCount_tb"), TextBox).Text
        Dim replyBy As String = TryCast(visit_dgv.Rows(e.RowIndex).FindControl("replyBy_tb"), TextBox).Text
        Dim studentCount As String = TryCast(visit_dgv.Rows(e.RowIndex).FindControl("studentCount_tb"), TextBox).Text
        Dim CurrentVisitDate As String

        Try
            Using con As New SqlConnection(connection_string)
                Using cmd As New SqlCommand("UPDATE visitInfo SET school=@school, vTrainingTime=@vTrainingTime, vMinCount=@vMinCount, vMaxCount=@vMaxCount, replyBy=@replyBy, visitDate=@visitDate, studentCount=@studentCount, school2=@school2, school3=@school3, school4=@school4, visitTime=@visitTime, school5=@school5 WHERE ID=@ID")
                    cmd.Parameters.AddWithValue("@ID", ID)
                    cmd.Parameters.AddWithValue("@school", school1)
                    cmd.Parameters.AddWithValue("@vTrainingTime", vTrainingTime)
                    cmd.Parameters.AddWithValue("@vMinCount", vMinCount)
                    cmd.Parameters.AddWithValue("@vMaxCount", vMaxCount)
                    cmd.Parameters.AddWithValue("@replyBy", replyBy)
                    cmd.Parameters.AddWithValue("@visitDate", visitDate)
                    cmd.Parameters.AddWithValue("@studentCount", studentCount)
                    cmd.Parameters.AddWithValue("@school2", school2)
                    cmd.Parameters.AddWithValue("@school3", school3)
                    cmd.Parameters.AddWithValue("@school4", school4)
                    cmd.Parameters.AddWithValue("@visitTime", visitTime)
                    cmd.Parameters.AddWithValue("@school5", school5)

                    cmd.Connection = con
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
            visit_dgv.EditIndex = -1       'reset the grid after editing
            loadData()
        Catch ex As Exception
            error_lbl.Text = "Error in updating visitInfo."
            Exit Sub
        End Try

        'Update onlineBanking visitDate
        Try
            Using con As New SqlConnection(connection_string)
                Using cmd As New SqlCommand("UPDATE onlineBanking SET visitDate=@visitDate WHERE visitID=@ID")
                    cmd.Parameters.AddWithValue("@ID", ID)
                    cmd.Parameters.AddWithValue("@visitDate", visitDate)
                    cmd.Connection = con
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
            visit_dgv.EditIndex = -1       'reset the grid after editing
            loadData()
        Catch ex As Exception
            error_lbl.Text = "Error in updating onlineBanking."
            Exit Sub
        End Try

        'Update onlineBanking school 1
        Try
            cond.ConnectionString = connection_string
            cond.Open()
            cmdd.CommandText = "SELECT school
                                  FROM onlineBanking
                                  WHERE school = '" & school1 & "' AND visitDate = '11-16-2022'"
            cmdd.Connection = cond
            dr = cmdd.ExecuteReader

            If Not dr.HasRows() Then
                Using con As New SqlConnection(connection_string)
                    Using cmd As New SqlCommand("UPDATE onlineBanking SET school=@school WHERE visitID=@ID AND NOT (school = '" & school2 & "' OR school = '" & school3 & "' OR school = '" & school4 & "' OR school = '" & school5 & "')")
                        cmd.Parameters.AddWithValue("@ID", ID)
                        cmd.Parameters.AddWithValue("@school", school1)
                        cmd.Connection = con
                        con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End Using
                End Using
                visit_dgv.EditIndex = -1       'reset the grid after editing
                loadData()
            End If
            'error_lbl.Text = "Does have rows"
            cmdd.Dispose()
            cond.Close()

        Catch
            error_lbl.Text = "Error in updating onlineBanking school1"
            Exit Sub
        End Try

        'Update onlineBanking school 2
        Try
            cond.ConnectionString = connection_string
            cond.Open()
            cmdd.CommandText = "SELECT school
                                  FROM onlineBanking
                                  WHERE school = '" & school2 & "' AND visitDate = '11-16-2022'"
            cmdd.Connection = cond
            dr = cmdd.ExecuteReader

            If Not dr.HasRows() Then
                Using con As New SqlConnection(connection_string)
                    Using cmd As New SqlCommand("UPDATE onlineBanking SET school=@school WHERE visitID=@ID AND NOT (school = '" & school1 & "' OR school = '" & school3 & "' OR school = '" & school4 & "' OR school = '" & school5 & "')")
                        cmd.Parameters.AddWithValue("@ID", ID)
                        cmd.Parameters.AddWithValue("@school", school2)
                        cmd.Connection = con
                        con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End Using
                End Using
                visit_dgv.EditIndex = -1       'reset the grid after editing
                loadData()
            End If
            'error_lbl.Text = "Does have rows"
            cmdd.Dispose()
            cond.Close()

        Catch
            error_lbl.Text = "Error in updating onlineBanking school2"
            Exit Sub
        End Try

        'Update onlineBanking school 3
        Try
            cond.ConnectionString = connection_string
            cond.Open()
            cmdd.CommandText = "SELECT school
                                  FROM onlineBanking
                                  WHERE school = '" & school3 & "' AND visitDate = '11-16-2022'"
            cmdd.Connection = cond
            dr = cmdd.ExecuteReader

            If Not dr.HasRows() Then
                Using con As New SqlConnection(connection_string)
                    Using cmd As New SqlCommand("UPDATE onlineBanking SET school=@school WHERE visitID=@ID AND NOT (school = '" & school1 & "' OR school = '" & school2 & "' OR school = '" & school4 & "' OR school = '" & school5 & "')")
                        cmd.Parameters.AddWithValue("@ID", ID)
                        cmd.Parameters.AddWithValue("@school", school3)
                        cmd.Connection = con
                        con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End Using
                End Using
                visit_dgv.EditIndex = -1       'reset the grid after editing
                loadData()
            End If
            'error_lbl.Text = school3
            cmdd.Dispose()
            cond.Close()

        Catch
            error_lbl.Text = "Error in updating onlineBanking school3"
            Exit Sub
        End Try

        'Update onlineBanking school 4
        Try
            cond.ConnectionString = connection_string
            cond.Open()
            cmdd.CommandText = "SELECT school
                                  FROM onlineBanking
                                  WHERE school = '" & school4 & "' AND visitDate = '11-16-2022'"
            cmdd.Connection = cond
            dr = cmdd.ExecuteReader

            If Not dr.HasRows() Then
                Using con As New SqlConnection(connection_string)
                    Using cmd As New SqlCommand("UPDATE onlineBanking SET school=@school WHERE visitID=@ID AND NOT (school = '" & school1 & "' OR school = '" & school2 & "' OR school = '" & school3 & "' OR school = '" & school5 & "')")
                        cmd.Parameters.AddWithValue("@ID", ID)
                        cmd.Parameters.AddWithValue("@school", school4)
                        cmd.Connection = con
                        con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End Using
                End Using
                visit_dgv.EditIndex = -1       'reset the grid after editing
                loadData()
            End If
            'error_lbl.Text = "Does have rows"
            cmdd.Dispose()
            cond.Close()

        Catch
            error_lbl.Text = "Error in updating onlineBanking school4"
            Exit Sub
        End Try

        'Update onlineBanking school 5
        Try
            cond.ConnectionString = connection_string
            cond.Open()
            cmdd.CommandText = "SELECT school
                                  FROM onlineBanking
                                  WHERE school = '" & school5 & "' AND visitDate = '11-16-2022'"
            cmdd.Connection = cond
            dr = cmdd.ExecuteReader

            If Not dr.HasRows() Then
                Using con As New SqlConnection(connection_string)
                    Using cmd As New SqlCommand("UPDATE onlineBanking SET school=@school WHERE visitID=@ID AND NOT (school = '" & school1 & "' OR school = '" & school2 & "' OR school = '" & school3 & "' OR school = '" & school4 & "')")
                        cmd.Parameters.AddWithValue("@ID", ID)
                        cmd.Parameters.AddWithValue("@school", school5)
                        cmd.Connection = con
                        con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End Using
                End Using
                visit_dgv.EditIndex = -1       'reset the grid after editing
                loadData()
            End If
            'error_lbl.Text = "Does have rows"
            cmdd.Dispose()
            cond.Close()

        Catch
            error_lbl.Text = "Error in updating onlineBanking school5"
            Exit Sub
        End Try

        'Update studentInfo
        Try
            Using con As New SqlConnection(connection_string)
                Using cmd As New SqlCommand("UPDATE studentInfo SET visit=@ID, school=@school WHERE visit=@ID")
                    cmd.Parameters.AddWithValue("@ID", ID)
                    cmd.Parameters.AddWithValue("@school", school1)
                    cmd.Connection = con
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
            visit_dgv.EditIndex = -1       'reset the grid after editing
            loadData()
        Catch ex As Exception
            error_lbl.Text = "Error in updating studentInfo."
        End Try

        'Check if current visit date in school info is the same as the date being updated here
        CurrentVisitDate = FormatDateTime(SchoolData.LoadSchoolInfoFromSchool(SchoolData.GetSchoolNameFromID(school1), "currentVisitDate"), DateFormat.ShortDate)

        If CurrentVisitDate <> visitDate Then

            'Update schoolInfo
            Try
                'Using con As New SqlConnection(connection_string)
                '    Using cmd As New SqlCommand("UPDATE schoolInfo SET currentVisitDate=@currentVisitDate WHERE id=@school AND id=@school2 AND id=@school3 AND id=@schoo4 AND id=@school5")
                '        cmd.Parameters.AddWithValue("@ID", ID)
                '        cmd.Parameters.AddWithValue("@school", school1)
                '        cmd.Parameters.AddWithValue("@school2", school2)
                '        cmd.Parameters.AddWithValue("@school3", school3)
                '        cmd.Parameters.AddWithValue("@school4", school4)
                '        cmd.Parameters.AddWithValue("@school5", school5)
                '        cmd.Connection = con
                '        con.Open()
                '        cmd.ExecuteNonQuery()
                '        con.Close()
                '    End Using
                'End Using
                SchoolData.UpdatePreviousVisitDate(school1)
                SchoolData.UpdateCurrentVisitDate(school1, visitDate)

                visit_dgv.EditIndex = -1       'reset the grid after editing
                loadData()
            Catch ex As Exception
                error_lbl.Text = "Error in updating studentInfo."
                Exit Sub
            End Try

        End If

        'Check if current visit date in school info is the same as the date being updated here
        CurrentVisitDate = FormatDateTime(SchoolData.LoadSchoolInfoFromSchool(SchoolData.GetSchoolNameFromID(school2), "currentVisitDate"), DateFormat.ShortDate)

        If CurrentVisitDate <> visitDate Then

            'Update schoolInfo
            Try
                SchoolData.UpdatePreviousVisitDate(school2)
                SchoolData.UpdateCurrentVisitDate(school2, visitDate)

                visit_dgv.EditIndex = -1       'reset the grid after editing
                loadData()
            Catch ex As Exception
                error_lbl.Text = "Error in updating studentInfo."
                Exit Sub
            End Try

        End If

        'Check if current visit date in school info is the same as the date being updated here
        CurrentVisitDate = FormatDateTime(SchoolData.LoadSchoolInfoFromSchool(SchoolData.GetSchoolNameFromID(school3), "currentVisitDate"), DateFormat.ShortDate)

        If CurrentVisitDate <> visitDate Then

            'Update schoolInfo
            Try
                SchoolData.UpdatePreviousVisitDate(school3)
                SchoolData.UpdateCurrentVisitDate(school3, visitDate)

                visit_dgv.EditIndex = -1       'reset the grid after editing
                loadData()
            Catch ex As Exception
                error_lbl.Text = "Error in updating studentInfo."
                Exit Sub
            End Try

        End If

        'Check if current visit date in school info is the same as the date being updated here
        CurrentVisitDate = FormatDateTime(SchoolData.LoadSchoolInfoFromSchool(SchoolData.GetSchoolNameFromID(school4), "currentVisitDate"), DateFormat.ShortDate)

        If CurrentVisitDate <> visitDate Then

            'Update schoolInfo
            Try
                SchoolData.UpdatePreviousVisitDate(school4)
                SchoolData.UpdateCurrentVisitDate(school4, visitDate)

                visit_dgv.EditIndex = -1       'reset the grid after editing
                loadData()
            Catch ex As Exception
                error_lbl.Text = "Error in updating studentInfo."
                Exit Sub
            End Try

        End If

        'Check if current visit date in school info is the same as the date being updated here
        CurrentVisitDate = FormatDateTime(SchoolData.LoadSchoolInfoFromSchool(SchoolData.GetSchoolNameFromID(school5), "currentVisitDate"), DateFormat.ShortDate)

        If CurrentVisitDate <> visitDate Then

            'Update schoolInfo
            Try
                SchoolData.UpdatePreviousVisitDate(school5)
                SchoolData.UpdateCurrentVisitDate(school5, visitDate)

                visit_dgv.EditIndex = -1       'reset the grid after editing
                loadData()
            Catch ex As Exception
                error_lbl.Text = "Error in updating studentInfo."
                Exit Sub
            End Try

        End If


        'Message to let staff know if visit date has changed, move articles if needed
        error_lbl.Text = "If you have changed the visit date, please go to Upload / Move Articles to move the newspaper articles to the updated visit date."

    End Sub

    Private Sub visit_dgv_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles visit_dgv.RowEditing
        visit_dgv.EditIndex = e.NewEditIndex
        loadData()
    End Sub

    Private Sub visit_dgv_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles visit_dgv.RowCancelingEdit
        visit_dgv.EditIndex = -1
        loadData()
    End Sub

    Private Sub visit_dgv_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles visit_dgv.PageIndexChanging
        visit_dgv.PageIndex = e.NewPageIndex
        loadData()
    End Sub

    Private Sub visit_dgv_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles visit_dgv.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then

            'School Dropdown
            Dim ddlSchool1 As DropDownList = CType(e.Row.FindControl("school1_ddl"), DropDownList)

            ddlSchool1.DataSource = GetData("SELECT id, schoolName FROM schoolInfo ORDER BY schoolName")
            ddlSchool1.DataTextField = "schoolName"
            ddlSchool1.DataValueField = "id"
            ddlSchool1.DataBind()
            Dim lblSchool1 As String = CType(e.Row.FindControl("schoolName1_lbl"), Label).Text
            If lblSchool1 = Nothing Then
                ddlSchool1.Items.FindByValue("A1 No School Scheduled").Selected = True
            Else
                ddlSchool1.Items.FindByValue(lblSchool1).Selected = True
            End If

            'ddlSchool1.Items.Insert(0, "")
            Dim school1ID As String = ddlSchool1.SelectedValue

            'School Dropdown
            Dim ddlSchool2 As DropDownList = CType(e.Row.FindControl("school2_ddl"), DropDownList)

            ddlSchool2.DataSource = GetData("SELECT id, schoolName FROM schoolInfo ORDER BY schoolName")
            ddlSchool2.DataTextField = "schoolName"
            ddlSchool2.DataValueField = "id"
            ddlSchool2.DataBind()
            Dim lblSchool2 As String = CType(e.Row.FindControl("schoolName2_lbl"), Label).Text
            If lblSchool2 = Nothing Then
                ddlSchool2.Items.FindByValue("A1 No School Scheduled").Selected = True
            Else
                ddlSchool2.Items.FindByValue(lblSchool2).Selected = True
            End If
            'ddlSchool2.Items.Insert(0, "")
            Dim school2ID As String = ddlSchool2.SelectedValue

            'School Dropdown
            Dim ddSchool3 As DropDownList = CType(e.Row.FindControl("school3_ddl"), DropDownList)

            ddSchool3.DataSource = GetData("SELECT id, schoolName FROM schoolInfo ORDER BY schoolName")
            ddSchool3.DataTextField = "schoolName"
            ddSchool3.DataValueField = "id"
            ddSchool3.DataBind()
            Dim lblSchool3 As String = CType(e.Row.FindControl("schoolName3_lbl"), Label).Text
            If lblSchool3 = Nothing Then
                ddSchool3.Items.FindByValue("A1 No School Scheduled").Selected = True
            Else
                ddSchool3.Items.FindByValue(lblSchool3).Selected = True
            End If
            'ddSchool3.Items.Insert(0, "")
            Dim school3ID As String = ddSchool3.SelectedValue

            'School Dropdown
            Dim ddSchool4 As DropDownList = CType(e.Row.FindControl("school4_ddl"), DropDownList)

            ddSchool4.DataSource = GetData("SELECT id, schoolName FROM schoolInfo ORDER BY schoolName")
            ddSchool4.DataTextField = "schoolName"
            ddSchool4.DataValueField = "id"
            ddSchool4.DataBind()
            Dim lblSchool4 As String = CType(e.Row.FindControl("schoolName4_lbl"), Label).Text
            If lblSchool4 = Nothing Then
                ddSchool4.Items.FindByValue("A1 No School Scheduled").Selected = True
            Else
                ddSchool4.Items.FindByValue(lblSchool4).Selected = True
            End If
            'ddSchool4.Items.Insert(0, "")
            Dim school4ID As String = ddSchool4.SelectedValue

            'School Dropdown
            Dim ddSchool5 As DropDownList = CType(e.Row.FindControl("school5_ddl"), DropDownList)

            ddSchool5.DataSource = GetData("SELECT id, schoolName FROM schoolInfo ORDER BY schoolName")
            ddSchool5.DataTextField = "schoolName"
            ddSchool5.DataValueField = "id"
            ddSchool5.DataBind()
            Dim lblSchool5 As String = CType(e.Row.FindControl("schoolName5_lbl"), Label).Text
            If lblSchool5 = Nothing Then
                ddSchool5.Items.FindByValue("A1 No School Scheduled").Selected = True
            Else
                ddSchool5.Items.FindByValue(lblSchool5).Selected = True
            End If
            'ddSchool5.Items.Insert(0, "")
            Dim school5ID As String = ddSchool5.SelectedValue

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

End Class