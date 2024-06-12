Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls
Imports System.Drawing

Public Class Open_Closed_Status
	Inherits System.Web.UI.Page
	Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
	Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
	Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
	Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
	Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
	Dim DBConnection As New DatabaseConection
	Dim dr As SqlDataReader
	Dim URL As String = HttpContext.Current.Request.Url.AbsoluteUri
	Dim VolDBVisitID As String
	Dim Visits As New Class_VisitData
	Dim SH As New Class_SchoolHeader
	Dim Businesses As New Class_BusinessData
	Dim VisitID As Integer = Visits.GetVisitID

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		'If not logged in, returns to log in page
		If Session("LoggedIn") <> "1" Then
			Response.Redirect("../../default.aspx")
		End If

		If Not (IsPostBack) Then

			'Populating school header
			headerSchoolName_lbl.Text = SH.GetSchoolHeader()

			'Check if coming from home page and assign visitDate hidden value and load school
			If URL.Contains("b=") Then
				VolDBVisitID = Request.QueryString("b")
				date_tb.Text = Visits.GetVisitDateFromID(VolDBVisitID)
				LoadData()
			End If

		End If

	End Sub

	Sub LoadData()
		Dim vMin As String = vMin_lbl.Text
		Dim vMax As String = vMax_lbl.Text
		Dim VIDOfDate As Integer = Visits.GetVisitIDFromDate(date_tb.Text)

		'Clear out table
		OnlineBanking_dgv.DataSource = Nothing
		OnlineBanking_dgv.DataBind()

		'Try
		Businesses.LoadOpenClosedStatus(VIDOfDate, OnlineBanking_dgv)
			'Catch
			'	error_lbl.Text = "Error in LoadData() SQL query. Check query or visitInfo / businessVisitInfo in DB."
			'	Exit Sub
			'End Try

			'Highlight row being edited
			For Each row As GridViewRow In OnlineBanking_dgv.Rows
			If row.RowIndex = OnlineBanking_dgv.EditIndex Then
				row.BackColor = ColorTranslator.FromHtml("#ebe534")
				'row.BorderColor = ColorTranslator.FromHtml("#ffffff")
				row.BorderWidth = 2
			End If
		Next

		'Clear all the connections (back up just in case the server gets overloaded)
		SqlConnection.ClearAllPools()

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
					cmd.Dispose()
					con.Close()

				End Using
			End Using
		End Using
	End Function



	Private Sub OnlineBanking_dgv_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles OnlineBanking_dgv.RowUpdating
		Dim row As GridViewRow = OnlineBanking_dgv.Rows(e.RowIndex)                        'Code is used to enable the editing prodecure
		Dim ID As Integer = Convert.ToInt32(OnlineBanking_dgv.DataKeys(e.RowIndex).Values(0)) 'Code is used to enable the editing procedure

		Dim openstatus As String = TryCast(OnlineBanking_dgv.Rows(e.RowIndex).FindControl("openstatus_ddl"), DropDownList).SelectedValue.ToString
		Dim schoolID As String = TryCast(OnlineBanking_dgv.Rows(e.RowIndex).FindControl("schoolName_ddl"), DropDownList).SelectedValue.ToString
		Dim minVolCount As String = TryCast(OnlineBanking_dgv.Rows(e.RowIndex).FindControl("vMinCount_tb"), TextBox).Text
		Dim maxVolCount As String = TryCast(OnlineBanking_dgv.Rows(e.RowIndex).FindControl("vMaxCount_tb"), TextBox).Text

		Dim status As Boolean
		Dim VIDOfDate As Integer = Visits.GetVisitIDFromDate(date_tb.Text)

		'Set status to 1 or 0 based on the openstatus string (used to update the sql)
		If openstatus = "Open" Then
			status = 1
		ElseIf openstatus = "Closed" Then
			status = 0
		End If

		'Checking if there is anything in min or max vol count, if not, it's 0
		If minVolCount = Nothing Then
			minVolCount = 0
		End If

		If maxVolCount = Nothing Then
			maxVolCount = 0
		End If

		'Update businessVisitInfo with minimum and maximum volunteer counts
		Using con As New SqlConnection(connection_string)
			Using cmd As New SqlCommand("UPDATE businessVisitInfo SET openstatus=@openUpdate, schoolID=@schoolName, minvolcount=@minVolCount, maxVolCount=@maxVolCount WHERE visitID ='" & VIDOfDate & "' AND businessID=@ID")
				cmd.Parameters.Add("@openUpdate", SqlDbType.Bit).Value = status
				cmd.Parameters.AddWithValue("@ID", ID)
				cmd.Parameters.AddWithValue("@schoolName", schoolID)
				cmd.Parameters.AddWithValue("@minVolCount", minVolCount)
				cmd.Parameters.AddWithValue("@maxVolCount", maxVolCount)
				cmd.Connection = con
				con.Open()
				cmd.ExecuteNonQuery()
				con.Close()

			End Using
		End Using

		'Get vMin and vMax Count
		Try
			Dim con As New SqlConnection
			Dim cmd As New SqlCommand
			Dim dr As SqlDataReader
			con.ConnectionString = connection_string
			con.Open()
			cmd.CommandText = "SELECT SUM(minVolCount) as vMin, SUM(maxVolCount) as vMax FROM businessVisitInfo WHERE visitID='" & VIDOfDate & "'"
			cmd.Connection = con
			dr = cmd.ExecuteReader

			While dr.Read()
				vMin_lbl.Text = dr("vMin").ToString
				vMax_lbl.Text = dr("vMax").ToString
			End While

			cmd.Dispose()
			con.Close()

		Catch
			error_lbl.Text = "Error getting volunteer min and max count."
			Exit Sub
		End Try

		'Update visitInfo with total min and max volunteers
		Using con As New SqlConnection(connection_string)
			Using cmd As New SqlCommand("UPDATE visitInfo SET vMinCount='" & vMin_lbl.Text & "', vMaxCount='" & vMax_lbl.Text & "' WHERE visitDate ='" & date_tb.Text & "'")
				cmd.Connection = con
				con.Open()
				cmd.ExecuteNonQuery()
				con.Close()

			End Using
		End Using

		'Reset gridview and load data
		OnlineBanking_dgv.EditIndex = -1
		LoadData()
	End Sub

	Private Sub OnlineBanking_dgv_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles OnlineBanking_dgv.RowDataBound
		Dim VIDOfDate As Integer = Visits.GetVisitIDFromDate(date_tb.Text)

		If (e.Row.RowType = DataControlRowType.DataRow) Then

			'School Dropdown
			Dim ddlSchool1 As DropDownList = CType(e.Row.FindControl("schoolName_ddl"), DropDownList)
			Dim tbVMin As TextBox = CType(e.Row.FindControl("vMinCount_tb"), TextBox)
			Dim tbVMax As TextBox = CType(e.Row.FindControl("vMaxCount_tb"), TextBox)

			ddlSchool1.DataSource = GetData("SELECT s.id as 'id', s.schoolName as 'schoolName'
											  FROM schoolInfo s 
											  JOIN visitInfo v ON v.school = s.id OR v.school2 = s.id OR v.school3 = s.id OR v.school4 = s.id OR v.school5 = s.id
											  WHERE v.visitDate='" & date_tb.Text & "'
											  ORDER BY schoolName ")
			ddlSchool1.DataTextField = "schoolName"
			ddlSchool1.DataValueField = "id"
			ddlSchool1.DataBind()
			Dim lblSchool1 As String = CType(e.Row.FindControl("schoolName_lbl"), Label).Text
			If lblSchool1 = Nothing Then
				ddlSchool1.Items.FindByValue("A1 No School Scheduled").Selected = True
			Else
				ddlSchool1.Items.FindByValue(lblSchool1).Selected = True
			End If

			'ddlSchool1.Items.Insert(0, "")
			Dim school1ID As String = ddlSchool1.SelectedValue

			'Open Status Dropdown
			Dim ddlopenstatus As DropDownList = CType(e.Row.FindControl("openstatus_ddl"), DropDownList)

			ddlSchool1.DataSource = GetData("SELECT DISTINCT openstatus 
											  FROM businessVisitInfo 
											  WHERE visitID='" & VIDOfDate & "'")
			ddlopenstatus.DataTextField = "schoolName"
			ddlopenstatus.DataValueField = "id"
			ddlopenstatus.DataBind()
			Dim lblopenstatus As String = CType(e.Row.FindControl("openstatus_lbl"), Label).Text
			If lblopenstatus = True Then
				ddlopenstatus.Items.FindByValue("Open").Selected = True
				ddlSchool1.Visible = True
				tbVMin.Visible = True
				tbVMax.Visible = True
			Else
				ddlopenstatus.Items.FindByValue("Closed").Selected = True
				ddlSchool1.Visible = False
				tbVMin.Visible = False
				tbVMax.Visible = False
			End If

		End If
	End Sub

	Private Sub OnlineBanking_dgv_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles OnlineBanking_dgv.RowCancelingEdit
		OnlineBanking_dgv.EditIndex = -1
		LoadData()
	End Sub

	Private Sub OnlineBanking_dgv_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles OnlineBanking_dgv.RowEditing
		OnlineBanking_dgv.EditIndex = e.NewEditIndex
		LoadData()
	End Sub



	Protected Sub date_tb_TextChanged(sender As Object, e As EventArgs) Handles date_tb.TextChanged
		If date_tb.Text <> Nothing Then
			LoadData()
		End If
	End Sub

End Class