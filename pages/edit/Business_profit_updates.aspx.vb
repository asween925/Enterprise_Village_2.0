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
    Dim Visits As New Class_VisitData
    Dim Businesses As New Class_BusinessData
    Dim SH As New Class_SchoolHeader
    Dim VisitID As Integer = Visits.GetVisitID

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Checks if the user is logged in and if not it redirects to the login page
        If Session("LoggedIn") <> "1" Then
            Response.Redirect("../../default.aspx")
        End If

        If Not (IsPostBack) Then

            If VisitID <> 0 Then
                visitdate_hf.Value = VisitID
            Else
                error_lbl.Text = "Error: No visit date created."
                Exit Sub
            End If

            'Populating school header
            headerSchoolName_lbl.Text = SH.GetSchoolHeader()

            'Load data
            LoadData()

        End If
    End Sub

    Sub LoadData()

        'Fill out profit tables
        'Try
        Businesses.GetBusinessProfitsTable(VisitID, businessProfit_dgv)
            'Catch
            '    error_lbl.Text = "Error in LoadData(). Could not load profit table."
            '    Exit Sub
            'End Try

            'Highlight row being edited
            For Each row As GridViewRow In businessProfit_dgv.Rows
            If row.RowIndex = businessProfit_dgv.EditIndex Then
                row.BackColor = ColorTranslator.FromHtml("#ebe534")
                'row.BorderColor = ColorTranslator.FromHtml("#ffffff")
                row.BorderWidth = 2
            End If
        Next
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
            Using cmd As New SqlCommand("UPDATE businessVisitInfo SET profit=@profits, deposit4=@deposit4 WHERE businessID=@Id AND visitID='" & visitID & "'")
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