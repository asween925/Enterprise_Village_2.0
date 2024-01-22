Imports System.Data.SqlClient
Public Class Tools
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim DBConnection As New DatabaseConection
    Dim dr As SqlDataReader
    Dim logoRoot As String = "~/media/Logos/"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (IsPostBack) Then
            Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
            Dim con As New SqlConnection
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            Dim VisitID As New Class_VisitData
            Dim Visit As Integer = VisitID.GetVisitID
            If Visit <> 0 Then
                visitdate_hf.Value = Visit
            End If
            LoadData()
        End If



    End Sub

    Sub LoadData()
        Dim visitID As Integer = visitdate_hf.Value
        Dim con As New SqlConnection
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        con.ConnectionString = connection_string
        con.Open()
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader


        'Try

        cmd = New SqlCommand
        cmd.Connection = con
        cmd.CommandText = "  SELECT b.businessName, CASE WHEN profit IS NULL THEN '0.00' ELSE profit END AS profits, CASE WHEN loanamount IS NULL THEN '0.00' ELSE loanamount END AS loan
  FROM onlineBanking o
  INNER JOIN businessInfo b
  ON o.businessID = b.id
  WHERE visitID = '" & visitID & "'
  ORDER BY profits
"


        Dim da As New SqlDataAdapter
        da.SelectCommand = cmd
        Dim dt As New DataTable
        da.Fill(dt)
        businessProfit_dgv.DataSource = dt
        businessProfit_dgv.DataBind()
        cmd.Dispose()
        con.Close()



    End Sub

End Class