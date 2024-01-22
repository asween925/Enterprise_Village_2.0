Imports System.Data.SqlClient
Imports System.Drawing
Public Class Business_profit_updates
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
    Dim DBConnection As New DatabaseConection
    Dim dr As SqlDataReader
    Dim logoRoot As String = "~/media/Logos/"
    Dim VisitID As New Class_VisitData
    Dim Visit As Integer = VisitID.GetVisitID
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

            If Visit <> 0 Then
                visitdate_hf.Value = Visit
            Else
                error_lbl.Text = "Error: No visit date created."
                Exit Sub
            End If

            'Populating school header
            Dim header As New Class_SchoolHeader
            headerSchoolName_lbl.Text = header.GetSchoolHeader()

            LoadData()

        End If
    End Sub

    Sub LoadData()
        Dim visitID As Integer = visitdate_hf.Value
        Dim con As New SqlConnection
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim cmd As New SqlCommand

        'Fill out profit tables
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "SELECT b.id, b.businessName, CASE WHEN profit IS NULL THEN '0.00' ELSE profit END AS profits, CASE WHEN deposit4 IS NULL THEN '0.00' ELSE deposit4 END AS deposit4,
                                CASE WHEN loanamount IS NULL THEN '0.00' ELSE loanamount END AS loan, CASE WHEN startingAmount IS NULL THEN '0.00' ELSE startingAmount END AS startingAmount 
                                FROM onlineBanking o 
                                INNER JOIN businessInfo b ON o.businessID = b.id
                                WHERE visitID = '" & visitID & "' ORDER BY businessName"

            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)
            businessProfit_dgv.DataSource = dt
            businessProfit_dgv.DataBind()
        Catch
            error_lbl.Text = "Operation failed"
            cmd.Dispose()
            con.Close()
        End Try

        'Highlight row being edited
        For Each row As GridViewRow In businessProfit_dgv.Rows
            If row.RowIndex = businessProfit_dgv.EditIndex Then
                row.BackColor = ColorTranslator.FromHtml("#ebe534")
                'row.BorderColor = ColorTranslator.FromHtml("#ffffff")
                row.BorderWidth = 2
            End If
        Next

        cmd.Dispose()
        con.Close()
    End Sub

    Private Sub Review_dgv_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles businessProfit_dgv.RowEditing
        businessProfit_dgv.EditIndex = e.NewEditIndex
        LoadData()
    End Sub

    Private Sub businessProfit_dgv_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles businessProfit_dgv.RowUpdating
        Dim row As GridViewRow = businessProfit_dgv.Rows(0)                           'Code is used to enable the editing prodecure
        Dim ID As Integer = Convert.ToInt32(businessProfit_dgv.DataKeys(e.RowIndex).Values(0)) 'Code is used to enable the editing procedure
        Dim visitID As Integer = visitdate_hf.Value
        Dim profits As Decimal = TryCast(businessProfit_dgv.Rows(e.RowIndex).FindControl("profits_tb"), TextBox).Text
        Dim deposit4 As Decimal = TryCast(businessProfit_dgv.Rows(e.RowIndex).FindControl("deposit4_tb"), TextBox).Text

        'Add deposit 4 to profits
        profits = profits + deposit4

        'Update profits
        Using con As New SqlConnection(connection_string)
            Using cmd As New SqlCommand("UPDATE onlineBanking SET profit=@profits, deposit4=@deposit4 WHERE businessID=@Id AND visitID='" & visitID & "'")
                cmd.Parameters.AddWithValue("@ID", ID)
                cmd.Parameters.AddWithValue("@profits", profits)
                cmd.Parameters.AddWithValue("@deposit4", deposit4)
                cmd.Connection = con
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using
        businessProfit_dgv.EditIndex = -1       'reset the grid after editing
        LoadData()
    End Sub

    Private Sub businessProfit_dgv_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles businessProfit_dgv.RowCancelingEdit
        businessProfit_dgv.EditIndex = -1
        LoadData()
    End Sub

End Class