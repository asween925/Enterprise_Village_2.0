Imports System.Data.SqlClient
Imports System.Drawing
Public Class Ditek_Check
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim businessID1 As String = Request.QueryString("b")
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        Label_date1.Text = DateTime.Now.ToString("MM/dd/yyyy")

        'get business name from url
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd.CommandText = "SELECT businessName, address FROM businessInfo WHERE id='" & businessID1 & "'"
            cmd.Connection = con
            dr = cmd.ExecuteReader

            While dr.Read()
                Label2.Text = dr("businessName").ToString
                Label3.Text = dr("address").ToString
                Label7.Text = dr("businessName").ToString
                Label11.Text = dr("address").ToString
                Label25.Text = dr("businessName").ToString
                Label26.Text = dr("address").ToString
                Label37.Text = dr("businessName").ToString
                Label38.Text = dr("address").ToString
            End While

            cmd.Dispose()
            con.Close()

        Catch
            cmd.Dispose()
            con.Close()
        Finally
            cmd.Dispose()
            con.Close()

        End Try

        If businessID1 = 14 Then
            check2.Visible = True
            check3.Visible = True
            check4.Visible = True
            Label18.Text = "City Hall Supplies"
        Else
            check2.Visible = False
            check3.Visible = False
            check4.Visible = False
        End If
    End Sub

End Class