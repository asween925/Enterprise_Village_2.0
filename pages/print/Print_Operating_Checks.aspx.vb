Imports System.Data.SqlClient
Public Class Print_Operating_Checks
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim DBConnection As New DatabaseConection
    Dim dr As SqlDataReader
    Dim logoRoot As String = "~/media/Logos/"
    Dim strProfit As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim businessID As String = Request.QueryString("b")
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        If businessID = Nothing Then
            businessID = 0
        End If

        If Not (IsPostBack) Then
            Dim VisitID As New Class_VisitData
            Dim Visit As Integer = VisitID.GetVisitID
            If Visit <> 0 Then
                visitdate_hf.Value = Visit
            End If
        End If

        Dim businessSQL As String = "SELECT businessName, address, logoPath, businessColor, businessName FROM businessinfo WHERE ID='" & businessID & "'"
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd.CommandText = businessSQL
            cmd.Connection = con
            dr = cmd.ExecuteReader

            While dr.Read()
                business_name1_lbl.Text = dr("businessName")
                business_name2_lbl.Text = dr("businessName")
                business_name3_lbl.Text = dr("businessName")
                business_name4_lbl.Text = dr("businessName")
                address1_lbl.Text = dr("address")
                address2_lbl.Text = dr("address")
                address3_lbl.Text = dr("address")
                address4_lbl.Text = dr("address")

                Dim imagePath As String = logoRoot & dr(0).ToString
                Dim bColor As String = dr(1).ToString
                BusLogo_img.ImageUrl = imagePath

                Me.Title = dr(2).ToString

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

        Dim check1, check2, check3, check4 As Integer
        check1 = Request.QueryString("c1")
        check2 = Request.QueryString("c2")
        check3 = Request.QueryString("c3")
        check4 = Request.QueryString("c4")

        If check1 <> 0 And check1 <> Nothing Then
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.CommandText = "SELECT c.businessID, c.operBizName, c.checkAmount, c.writtenAmount, c.memo 
  FROM checksinfo c 
  WHERE c.ID='" & check1 & "' AND visitID='" & visitdate_hf.Value & "'"
                cmd.Connection = con
                dr = cmd.ExecuteReader

                While dr.Read()
                    checkName1_tb.Text = dr("operBizName")
                    checkAmount1_lbl.Text = dr("checkAmount")
                    writtenAmount1_tb.Text = dr("writtenAmount")
                    Memo1_tb.Text = dr("Memo")
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

        If check2 <> 0 And check2 <> Nothing Then
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.CommandText = "SELECT c.businessID, c.operBizName, c.checkAmount, c.writtenAmount, c.memo 
        FROM checksinfo c 
        WHERE c.ID='" & check2 & "' AND visitID='" & visitdate_hf.Value & "'"
                cmd.Connection = con
                dr = cmd.ExecuteReader

                While dr.Read()
                    checkName2_tb.Text = dr("operBizName")
                    checkAmount2_lbl.Text = dr("checkAmount")
                    writtenAmount2_tb.Text = dr("writtenAmount")
                    Memo2_tb.Text = dr("Memo")
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

        If check3 <> 0 And check3 <> Nothing Then
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.CommandText = "SELECT c.businessID, c.operBizName, c.checkAmount, c.writtenAmount, c.memo 
        FROM checksinfo c 
        WHERE c.ID='" & check3 & "' AND visitID='" & visitdate_hf.Value & "'"
                cmd.Connection = con
                dr = cmd.ExecuteReader

                While dr.Read()
                    checkName3_tb.Text = dr("operBizName")
                    checkAmount3_lbl.Text = dr("checkAmount")
                    writtenAmount3_tb.Text = dr("writtenAmount")
                    Memo3_tb.Text = dr("Memo")
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

        If check4 <> 0 And check4 <> Nothing Then
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.CommandText = "SELECT c.businessID, c.operBizName, c.checkAmount, c.writtenAmount, c.memo 
        FROM checksinfo c 
        WHERE c.ID='" & check4 & "' AND visitID='" & visitdate_hf.Value & "'"
                cmd.Connection = con
                dr = cmd.ExecuteReader

                While dr.Read()
                    checkName4_tb.Text = dr("operBizName")
                    checkAmount4_lbl.Text = dr("checkAmount")
                    writtenAmount4_tb.Text = dr("writtenAmount")
                    Memo4_tb.Text = dr("Memo")
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
        Label_date1_lbl.Text = DateTime.Now.ToString("MM/dd/yyyy")
        Label_date2_lbl.Text = DateTime.Now.ToString("MM/dd/yyyy")
        Label_date3_lbl.Text = DateTime.Now.ToString("MM/dd/yyyy")
        Label_date4_lbl.Text = DateTime.Now.ToString("MM/dd/yyyy")

    End Sub

End Class