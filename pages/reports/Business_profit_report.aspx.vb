Imports System.Data.SqlClient
Public Class Business_profit_report
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim DBConnection As New DatabaseConection
    Dim dr As SqlDataReader
    Dim logoRoot As String = "~/media/Logos/"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Checks if the user is logged in and if not it redirects to the login page
        If Session("LoggedIn") <> "1" Then
            Response.Redirect("../../default.aspx")
        End If

        If Not (IsPostBack) Then
            Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
            Dim con As New SqlConnection
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim VisitID As New Class_VisitData
            Dim Visit As Integer = VisitID.GetVisitID

            If Visit <> 0 Then
                visitdate_hf.Value = Visit
            Else
                'error_lbl.Text = "No visit date, please go to 'Database Creator' on the 'Tools / Reports' page and create a new school visit date."
            End If

            'Populating school header
            Dim header As New Class_SchoolHeader
            headerSchoolName_lbl.Text = header.GetSchoolHeader()

        End If
    End Sub

    Sub LoadData()
        Dim visitID As String
        Dim con As New SqlConnection
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim schoolName As String

        'Get selected visit ID
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd.CommandText = "SELECT id FROM visitInfo WHERE visitDate='" & visitDate_tb.Text & "'"
            cmd.Connection = con
            dr = cmd.ExecuteReader

            While dr.Read()
                visitdate_hf.Value = dr("id").ToString
            End While

            visitID = visitdate_hf.Value

            cmd.Dispose()
            con.Close()

        Catch
            error_lbl.Text = "Error in loaddata(). Could not get selected visit ID."
            Exit Sub
        Finally
            cmd.Dispose()
            con.Close()

        End Try

        'Get school name(s)
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd.CommandText = "SELECT schools = STUFF((
	                                SELECT ', ' + s.schoolName
	                                FROM schoolInfo s 
	                                INNER JOIN visitInfo v on s.ID = v.School OR s.id = v.school2 or s.id = v.school3 or s.id = v.school4 or s.id = v.school5 
	                                WHERE v.id='" & visitID & "'
	                                FOR XML PATH('')), 1, 1, '')"
            cmd.Connection = con
            dr = cmd.ExecuteReader

            While dr.Read()
                schoolName = dr("schools").ToString

                schoolName = schoolName.TrimEnd(",", " ")

                Schools_lbl.Text = schoolName
            End While

            cmd.Dispose()
            con.Close()

        Catch
            error_lbl.Text = "Error in loaddata(). Could not retrieve school name."
            Exit Sub
        Finally
            cmd.Dispose()
            con.Close()

        End Try

        'Get profits
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "  SELECT b.businessName, CASE WHEN profit IS NULL THEN '0.00' ELSE profit END AS profits, CASE WHEN loanamount IS NULL THEN '0.00' ELSE loanamount END AS loan, CASE WHEN startingAmount IS NULL THEN '0.00' ELSE startingAmount END AS startingAmount, CASE WHEN deposit4 IS NULL THEN '0.00' ELSE deposit4 END AS deposit4
                                  FROM onlineBanking o
                                  INNER JOIN businessInfo b
                                  ON o.businessID = b.id
                                  WHERE visitID = '" & visitID & "'
                                  ORDER BY b.businessName"


            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)
            businessProfit_dgv.DataSource = dt
            businessProfit_dgv.DataBind()
        Catch
            error_lbl.Text = "Error in loaddata(). Could not retrieve profits."
            cmd.Dispose()
            con.Close()
        End Try

        cmd.Dispose()
        con.Close()

    End Sub

    Protected Sub print_btn_Click(sender As Object, e As EventArgs) Handles print_btn.Click
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "PrintBadges", "PrintBadges();", True)
    End Sub

    Protected Sub visitDate_tb_TextChanged(sender As Object, e As EventArgs) Handles visitDate_tb.TextChanged
        If visitDate_tb.Text <> Nothing Then
            LoadData()
        End If
    End Sub
End Class