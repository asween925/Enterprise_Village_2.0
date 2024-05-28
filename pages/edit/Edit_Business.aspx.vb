Imports System.IO
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Drawing

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

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Session("LoggedIn") <> "1" Then
			Response.Redirect("../../default.aspx")
		End If

		If Not (IsPostBack) Then
			'Assign current visit ID to hidden field
			If VisitID <> 0 Then
				currentVisitID_hf.Value = VisitID
			End If

			'Populating school header
			Dim header As New Class_SchoolHeader
            headerSchoolName_lbl.Text = header.GetSchoolHeader()

            'Load data
            LoadData()
        End If
	End Sub

	Sub LoadData()
        Dim SQLStatement As String = "SELECT b.id, b.businessName, b.address, b.startingBalance, j.jobTitle as jobTitle1, j2.jobTitle as jobTitle2, j3.jobTitle as jobTitle3, j4.jobTitle as jobTitle4
                                      , j5.jobTitle as jobTitle5, j6.jobTitle as jobTitle6, j7.jobTitle as jobTitle7, j8.jobTitle as jobTitle8, j9.jobTitle as jobTitle9, j10.jobTitle as jobTitle10
                                      FROM businessInfo b
                                      LEFT JOIN jobs j ON j.id = b.position1
                                      LEFT JOIN jobs j2 ON j2.id = b.position2
                                      LEFT JOIN jobs j3 ON j3.id = b.position3
                                      LEFT JOIN jobs j4 ON j4.id = b.position4
                                      LEFT JOIN jobs j5 ON j5.id = b.position5
                                      LEFT JOIN jobs j6 ON j6.id = b.position6
                                      LEFT JOIN jobs j7 ON j7.id = b.position7
                                      LEFT JOIN jobs j8 ON j8.id = b.position8
                                      LEFT JOIN jobs j9 ON j9.id = b.position9
                                      LEFT JOIN jobs j10 ON j10.id = b.position10
                                      ORDER BY b.businessName"

        'Clear out visit table
        business_dgv.DataSource = Nothing
		business_dgv.DataBind()

		'Clear error label
		error_lbl.Text = ""

        'Fill visit table
        Try
            con.ConnectionString = connection_string
            con.Open()
            Review_sds.ConnectionString = connection_string
            Review_sds.SelectCommand = SQLStatement
            business_dgv.DataSource = Review_sds
            business_dgv.DataBind()

        Catch
            error_lbl.Text = "Error in LoadData(). Could not fill table."
            cmd.Dispose()
            con.Close()
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

    Private Sub business_dgv_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles business_dgv.RowUpdating
        Dim SQLStatement As String = "UPDATE businessInfo SET address=@address, startingBalance=@startingBalance"
        Dim row As GridViewRow = business_dgv.Rows(0)                           'Code is used to enable the editing prodecure
        Dim ID As Integer = Convert.ToInt32(business_dgv.DataKeys(e.RowIndex).Values(0)) 'Gets id number

        'Dim BusinessName As String = TryCast(business_dgv.Rows(e.RowIndex).FindControl("businessNameDGV_ddl"), DropDownList).SelectedValue.ToString
        Dim Address As String = TryCast(business_dgv.Rows(e.RowIndex).FindControl("addressDGV_tb"), TextBox).Text
        Dim StartingBalance As String = TryCast(business_dgv.Rows(e.RowIndex).FindControl("startingBalanceDGV_tb"), TextBox).Text
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

        'Update DB
        Try
            Using con As New SqlConnection(connection_string)
                Using cmd As New SqlCommand(SQLStatement)
                    cmd.Parameters.AddWithValue("@ID", ID)
                    'cmd.Parameters.AddWithValue("@businessName", BusinessName)
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

            ''School name DGV Dropdown
            'Dim ddlBusinessName As DropDownList = CType(e.Row.FindControl("businessNameDGV_ddl"), DropDownList)
            'ddlBusinessName.DataSource = GetData("SELECT DISTINCT businessName FROM businessInfo ORDER BY businessName")
            'ddlBusinessName.DataTextField = "businessName"
            ''ddlSchool.DataValueField = "Businessid"
            'ddlBusinessName.DataBind()
            'Dim lblBusinessName As String = CType(e.Row.FindControl("businessNameDGV_lbl"), Label).Text

            'ddlBusinessName.Items.FindByValue(lblBusinessName).Selected = True
            ''Dim businessID As String = ddlSchool.SelectedValue

            'School name DGV Dropdown
            Dim ddlPosition1 As DropDownList = CType(e.Row.FindControl("position1DGV_ddl"), DropDownList)
            ddlPosition1.DataSource = GetData("SELECT DISTINCT jobTitle FROM jobs UNION SELECT '' ORDER BY jobTitle")
            ddlPosition1.DataTextField = "jobTitle"

            'ddlSchool.DataValueField = "Businessid"
            ddlPosition1.DataBind()
            Dim lblPosition1 As String = CType(e.Row.FindControl("position1DGV_lbl"), Label).Text

            ddlPosition1.Items.FindByValue(lblPosition1).Selected = True
            'Dim businessID As String = ddlSchool.SelectedValue

            'School name DGV Dropdown
            Dim ddlPosition2 As DropDownList = CType(e.Row.FindControl("position2DGV_ddl"), DropDownList)
            ddlPosition2.DataSource = GetData("SELECT DISTINCT jobTitle FROM jobs UNION SELECT '' ORDER BY jobTitle")
            ddlPosition2.DataTextField = "jobTitle"
            'ddlSchool.DataValueField = "Businessid"
            ddlPosition2.DataBind()
            Dim lblPosition2 As String = CType(e.Row.FindControl("position2DGV_lbl"), Label).Text

            ddlPosition2.Items.FindByValue(lblPosition2).Selected = True
            'Dim businessID As String = ddlSchool.SelectedValue

            'School name DGV Dropdown
            Dim ddlPosition3 As DropDownList = CType(e.Row.FindControl("position3DGV_ddl"), DropDownList)
            ddlPosition3.DataSource = GetData("SELECT DISTINCT jobTitle FROM jobs UNION SELECT '' ORDER BY jobTitle")
            ddlPosition3.DataTextField = "jobTitle"
            'ddlSchool.DataValueField = "Businessid"
            ddlPosition3.DataBind()
            Dim lblPosition3 As String = CType(e.Row.FindControl("position3DGV_lbl"), Label).Text

            If lblPosition3 <> Nothing Then
                ddlPosition3.Items.FindByValue(lblPosition3).Selected = True
            End If

            'School name DGV Dropdown
            Dim ddlPosition4 As DropDownList = CType(e.Row.FindControl("position4DGV_ddl"), DropDownList)
            ddlPosition4.DataSource = GetData("SELECT DISTINCT jobTitle FROM jobs UNION SELECT '' ORDER BY jobTitle")
            ddlPosition4.DataTextField = "jobTitle"
            'ddlSchool.DataValueField = "Businessid"
            ddlPosition4.DataBind()
            Dim lblPosition4 As String = CType(e.Row.FindControl("position4DGV_lbl"), Label).Text

            If lblPosition4 <> Nothing Then
                ddlPosition4.Items.FindByValue(lblPosition4).Selected = True
            End If

            'School name DGV Dropdown
            Dim ddlPosition5 As DropDownList = CType(e.Row.FindControl("position5DGV_ddl"), DropDownList)
            ddlPosition5.DataSource = GetData("SELECT DISTINCT jobTitle FROM jobs UNION SELECT '' ORDER BY jobTitle")
            ddlPosition5.DataTextField = "jobTitle"
            'ddlSchool.DataValueField = "Businessid"
            ddlPosition5.DataBind()
            Dim lblPosition5 As String = CType(e.Row.FindControl("position5DGV_lbl"), Label).Text

            If lblPosition5 <> Nothing Then
                ddlPosition5.Items.FindByValue(lblPosition5).Selected = True
            End If

            'School name DGV Dropdown
            Dim ddlPosition6 As DropDownList = CType(e.Row.FindControl("position6DGV_ddl"), DropDownList)
            ddlPosition6.DataSource = GetData("SELECT DISTINCT jobTitle FROM jobs UNION SELECT '' ORDER BY jobTitle")
            ddlPosition6.DataTextField = "jobTitle"
            'ddlSchool.DataValueField = "Businessid"
            ddlPosition6.DataBind()
            Dim lblPosition6 As String = CType(e.Row.FindControl("position6DGV_lbl"), Label).Text

            If lblPosition6 <> Nothing Then
                ddlPosition6.Items.FindByValue(lblPosition6).Selected = True
            End If

            'School name DGV Dropdown
            Dim ddlPosition7 As DropDownList = CType(e.Row.FindControl("position7DGV_ddl"), DropDownList)
            ddlPosition7.DataSource = GetData("SELECT DISTINCT jobTitle FROM jobs UNION SELECT '' ORDER BY jobTitle")
            ddlPosition7.DataTextField = "jobTitle"
            'ddlSchool.DataValueField = "Businessid"
            ddlPosition7.DataBind()
            Dim lblPosition7 As String = CType(e.Row.FindControl("position7DGV_lbl"), Label).Text

            If lblPosition7 <> Nothing Then
                ddlPosition7.Items.FindByValue(lblPosition7).Selected = True
            End If

            'School name DGV Dropdown
            Dim ddlPosition8 As DropDownList = CType(e.Row.FindControl("position8DGV_ddl"), DropDownList)
            ddlPosition8.DataSource = GetData("SELECT DISTINCT jobTitle FROM jobs UNION SELECT '' ORDER BY jobTitle")
            ddlPosition8.DataTextField = "jobTitle"
            'ddlSchool.DataValueField = "Businessid"
            ddlPosition8.DataBind()
            Dim lblPosition8 As String = CType(e.Row.FindControl("position8DGV_lbl"), Label).Text

            If lblPosition8 <> Nothing Then
                ddlPosition8.Items.FindByValue(lblPosition8).Selected = True
            End If

            'School name DGV Dropdown
            Dim ddlPosition9 As DropDownList = CType(e.Row.FindControl("position9DGV_ddl"), DropDownList)
            ddlPosition9.DataSource = GetData("SELECT DISTINCT jobTitle FROM jobs UNION SELECT '' ORDER BY jobTitle")
            ddlPosition9.DataTextField = "jobTitle"
            'ddlSchool.DataValueField = "Businessid"
            ddlPosition9.DataBind()
            Dim lblPosition9 As String = CType(e.Row.FindControl("position9DGV_lbl"), Label).Text

            If lblPosition9 <> Nothing Then
                ddlPosition9.Items.FindByValue(lblPosition9).Selected = True
            End If

            'School name DGV Dropdown
            Dim ddlPosition10 As DropDownList = CType(e.Row.FindControl("position10DGV_ddl"), DropDownList)
            ddlPosition10.DataSource = GetData("SELECT DISTINCT jobTitle FROM jobs UNION SELECT '' ORDER BY jobTitle")
            ddlPosition10.DataTextField = "jobTitle"
            'ddlSchool.DataValueField = "Businessid"
            ddlPosition10.DataBind()
            Dim lblPosition10 As String = CType(e.Row.FindControl("position10DGV_lbl"), Label).Text

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

End Class