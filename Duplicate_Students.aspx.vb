Imports System.IO
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class Duplicate_Students
	Inherits System.Web.UI.Page
	Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
	Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
	Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
	Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
	Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
	Dim con As New SqlConnection
	Dim cmd As New SqlCommand
	Dim dr As SqlDataReader
	Dim VisitData As New Class_VisitData
	Dim StudentData As New Class_StudentData
	Dim CurrentVisitID As Integer = VisitData.GetVisitID

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		If Session("LoggedIn") <> "1" Then
			Response.Redirect(".\default.aspx")
		End If

		If Not (IsPostBack) Then

			'Assign current visit ID to hidden field
			If CurrentVisitID <> 0 Then
				currentVisitID_hf.Value = CurrentVisitID
			End If

			'Populating school header
			Dim header As New Class_SchoolHeader
			headerSchoolName_lbl.Text = header.GetSchoolHeader()
		End If

	End Sub

	Sub LoadData()
		Dim VisitDate As String = visitDate_tb.Text
		Dim VisitID As String = VisitData.GetVisitIDFromDate(VisitDate)
		Dim SQLStatement As String = "SELECT a.id, a.employeeNumber, a.firstName, a.lastName
										FROM studentInfo a
										JOIN (SELECT firstName, lastName 
										FROM studentInfo 
										WHERE visit='" & VisitID & "' AND NOT firstName IS NULL AND NOT firstName='' AND NOT lastName IS NULL AND NOT lastName=''  
										GROUP BY firstName, lastName HAVING COUNT(*) > 1) b
										ON a.firstName = b.firstName
										AND a.lastName = b.lastName
										WHERE visit='" & VisitID & "'
										ORDER BY a.id"

		'Clear out table
		students_dgv.DataSource = Nothing
		students_dgv.DataBind()

		'Clear error label
		error_lbl.Text = ""

		'Populate table
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

			students_dgv.DataSource = dt
			students_dgv.DataBind()

			cmd.Dispose()
			con.Close()
		Catch
			error_lbl.Text = "Error in LoadData. Cannot load duplicate students from visit date."
			Exit Sub
		End Try

	End Sub

	Protected Sub visitDate_tb_TextChanged(sender As Object, e As EventArgs) Handles visitDate_tb.TextChanged
		LoadData()
	End Sub
End Class