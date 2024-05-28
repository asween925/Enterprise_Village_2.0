Imports System.Data.SqlClient
Public Class Print_Badges
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim DBConnection As New DatabaseConection
    Dim dr As SqlDataReader
    Dim photoRoot As String = "~/media/"
    Dim strProfit As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        If Not (IsPostBack) Then
            Dim VisitID As New Class_VisitData
            Dim Visit As Integer = VisitID.GetVisitID
            If Visit <> 0 Then
                visitdate_hf.Value = Visit
            End If
        End If

        Dim badge1, badge2, badge3, badge4 As Integer
        badge1 = Request.QueryString("c1")
        badge2 = Request.QueryString("c2")
        badge3 = Request.QueryString("c3")
        badge4 = Request.QueryString("c4")

        If badge1 <> 0 And badge1 <> Nothing Then
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.CommandText = "SELECT id, employeeName, businessName, position, date, photoPath, visitID 
                                          FROM badges
                                          WHERE id='" & badge1 & "' AND visitID='" & visitdate_hf.Value & "'"
                cmd.Connection = con
                dr = cmd.ExecuteReader

                While dr.Read()
                    studentName_lbl1.Text = dr("employeeName")
                    businessName_lbl1.Text = dr("businessName")
                    position_lbl1.Text = dr("position")
                    date_lbl1.Text = dr("date")
                    photo_img1.ImageUrl = photoRoot & dr("photoPath")
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


        End If

        If badge2 <> 0 And badge2 <> Nothing Then
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.CommandText = "SELECT id, employeeName, businessName, position, date, photoPath, visitID 
                                          FROM badges
                                          WHERE id='" & badge2 & "' AND visitID='" & visitdate_hf.Value & "'"
                cmd.Connection = con
                dr = cmd.ExecuteReader

                While dr.Read()
                    studentName_lbl2.Text = dr("employeeName")
                    businessName_lbl2.Text = dr("businessName")
                    position_lbl2.Text = dr("position")
                    date_lbl2.Text = dr("date")
                    photo_img2.ImageUrl = photoRoot & dr("photoPath")
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



        End If

        If badge3 <> 0 And badge3 <> Nothing Then
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.CommandText = "SELECT id, employeeName, businessName, position, date, photoPath, visitID 
                                          FROM badges
                                          WHERE id='" & badge3 & "' AND visitID='" & visitdate_hf.Value & "'"
                cmd.Connection = con
                dr = cmd.ExecuteReader

                While dr.Read()
                    studentName_lbl3.Text = dr("employeeName")
                    businessName_lbl3.Text = dr("businessName")
                    position_lbl3.Text = dr("position")
                    date_lbl3.Text = dr("date")
                    photo_img3.ImageUrl = photoRoot & dr("photoPath")
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


        End If

        If badge4 <> 0 And badge4 <> Nothing Then
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.CommandText = "SELECT id, employeeName, businessName, position, date, photoPath, visitID 
                                          FROM badges
                                          WHERE id='" & badge4 & "' AND visitID='" & visitdate_hf.Value & "'"
                cmd.Connection = con
                dr = cmd.ExecuteReader

                While dr.Read()
                    studentName_lbl4.Text = dr("employeeName")
                    businessName_lbl4.Text = dr("businessName")
                    position_lbl4.Text = dr("position")
                    date_lbl4.Text = dr("date")
                    photo_img4.ImageUrl = photoRoot & dr("photoPath")
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


        End If

        SqlConnection.ClearAllPools()
    End Sub

End Class