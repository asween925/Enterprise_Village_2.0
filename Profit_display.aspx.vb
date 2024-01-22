Imports System.Data.SqlClient

Public Class Profit_display
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim DBConnection As New DatabaseConection
    Dim dr As SqlDataReader

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim businessID As String = Request.QueryString("b")
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        If businessID = Nothing Then
            businessID = 0
        End If

        Dim businessSQL As String = "SELECT logoPath, businessColor, businessName FROM businessinfo WHERE ID='" & businessID & "'"
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd.CommandText = businessSQL
            cmd.Connection = con
            dr = cmd.ExecuteReader

            While dr.Read()
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


        If Not (IsPostBack) Then
            Dim VisitID As New Class_VisitData
            Dim Visit As Integer = VisitID.GetVisitID
            If Visit <> 0 Then
                visitdate_hf.Value = Visit
            Else
                error_lbl.Text = "Error: No Visit Date Created."
                Exit Sub
            End If

            LoadData()
        End If
    End Sub

    Sub LoadData()
        Dim visitID As Integer = visitdate_hf.Value
        Dim businessID As String = Request.QueryString("b")
        Dim con As New SqlConnection
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        con.ConnectionString = connection_string
        con.Open()
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim da As New SqlDataAdapter
        Dim dt As New DataTable

        cmd = New SqlCommand
        cmd.Connection = con
        cmd.CommandText = "  SELECT o.visitID, o.openStatus, o.profit, b.businessName 
  FROM onlineBanking o inner join businessinfo b ON b.ID = o.businessID 
  WHERE visitID ='" & visitID & "'AND openstatus='1' AND NOT b.id='20' AND NOT b.id='14' AND NOT b.id='13' AND NOT b.id='12' AND NOT b.id='24' AND NOT b.id='15' ORDER BY businessName"

        da.SelectCommand = cmd
        da.Fill(dt)
        profit_dgv.DataSource = dt
        profit_dgv.DataBind()

        da.Dispose()

        'Add a check to see if open status is 0: in the while loop, add an if to see if the first business (loopCount 0) is open (openstatus=1) or closed (openstatus=0).
        'If it is open, then it continues with the code before the if statement with the negative.
        'If it is closed, then it adds 1 to the loop count and then ignore all of the if statment and starts the while loop again

        'Error msg to check for negative balance and also check if profit is a null, if so, then convert the value to 0
        Dim loopCount As Integer = 0
        Dim loopCount2 As Integer = 0
        Dim rowCount As Integer
        tablemaxRow_hf.Value = profit_dgv.Rows.Count
        rowCount = tablemaxRow_hf.Value

        Try
            While loopCount < rowCount
                If profit_dgv.Rows(loopCount).Cells(1).Text.Contains("-") Then
                    error_lbl.Text = "Business contains a negative balance. Please visit the 'Edit Profits' page to see what business profit is negative and change it to continue with the PowerPoint."
                    Exit Sub
                ElseIf profit_dgv.Rows(loopCount).Cells(1).Text Is Nothing Then 'This doesn't work, does not convert the NULL value from SQL into a 0
                    profit_dgv.Rows(loopCount).Cells(1).Text = "0"
                    loopCount = loopCount + 1
                Else
                    loopCount = loopCount + 1
                End If

                bus1_name_lbl.Text = profit_dgv.Rows(0).Cells(0).Text
                bus1_profit_lbl.Text = "$" & profit_dgv.Rows(0).Cells(1).Text
                Label18.Text = " Profit"

                bus2_name_lbl.Text = profit_dgv.Rows(1).Cells(0).Text
                bus2_profit_lbl.Text = "$" & profit_dgv.Rows(1).Cells(1).Text
                Label15.Text = " Profit"

                bus3_name_lbl.Text = profit_dgv.Rows(2).Cells(0).Text
                bus3_profit_lbl.Text = "$" & profit_dgv.Rows(2).Cells(1).Text
                Label14.Text = " Profit"

                bus4_name_lbl.Text = profit_dgv.Rows(3).Cells(0).Text
                bus4_profit_lbl.Text = "$" & profit_dgv.Rows(3).Cells(1).Text
                Label13.Text = " Profit"

                bus5_name_lbl.Text = profit_dgv.Rows(4).Cells(0).Text
                bus5_profit_lbl.Text = "$" & profit_dgv.Rows(4).Cells(1).Text
                Label12.Text = " Profit"

                bus6_name_lbl.Text = profit_dgv.Rows(5).Cells(0).Text
                bus6_profit_lbl.Text = "$" & profit_dgv.Rows(5).Cells(1).Text
                Label11.Text = " Profit"

                bus7_name_lbl.Text = profit_dgv.Rows(6).Cells(0).Text
                bus7_profit_lbl.Text = "$" & profit_dgv.Rows(6).Cells(1).Text
                Label10.Text = " Profit"

                bus8_name_lbl.Text = profit_dgv.Rows(7).Cells(0).Text
                bus8_profit_lbl.Text = "$" & profit_dgv.Rows(7).Cells(1).Text
                Label9.Text = " Profit"

                bus9_name_lbl.Text = profit_dgv.Rows(8).Cells(0).Text
                bus9_profit_lbl.Text = "$" & profit_dgv.Rows(8).Cells(1).Text
                Label8.Text = " Profit"

                bus10_name_lbl.Text = profit_dgv.Rows(9).Cells(0).Text
                bus10_profit_lbl.Text = "$" & profit_dgv.Rows(9).Cells(1).Text
                Label7.Text = " Profit"

                bus11_name_lbl.Text = profit_dgv.Rows(10).Cells(0).Text
                bus11_profit_lbl.Text = "$" & profit_dgv.Rows(10).Cells(1).Text
                Label6.Text = " Profit"

                bus12_name_lbl.Text = profit_dgv.Rows(11).Cells(0).Text
                bus12_profit_lbl.Text = "$" & profit_dgv.Rows(11).Cells(1).Text
                Label5.Text = " Profit"

                bus13_name_lbl.Text = profit_dgv.Rows(12).Cells(0).Text
                bus13_profit_lbl.Text = "$" & profit_dgv.Rows(12).Cells(1).Text
                Label2.Text = " Profit"

                bus14_name_lbl.Text = profit_dgv.Rows(13).Cells(0).Text
                bus14_profit_lbl.Text = "$" & profit_dgv.Rows(13).Cells(1).Text
                Label1.Text = " Profit"

                bus15_name_lbl.Text = profit_dgv.Rows(14).Cells(0).Text
                bus15_profit_lbl.Text = "$" & profit_dgv.Rows(14).Cells(1).Text
                Label19.Text = " Profit"

                bus16_name_lbl.Text = profit_dgv.Rows(15).Cells(0).Text
                bus16_profit_lbl.Text = "$" & profit_dgv.Rows(15).Cells(1).Text
                Label22.Text = " Profit"

                bus17_name_lbl.Text = "Congratulations!"
                bus17_profit_lbl.Text = "Thank you for visiting Enterprise Village!"
            End While
        Catch
            While loopCount2 < rowCount
                If profit_dgv.Rows(loopCount2).Cells(1).Text.Contains("-") Then
                    error_lbl.Text = "Business contains a negative balance. Please visit the 'Profit Reports' page to see what business profit is negative and change it to continue with the PowerPoint."
                    Exit Sub
                ElseIf profit_dgv.Rows(loopCount2).Cells(1).Text Is Nothing Then 'This doesn't work, does not convert the NULL value from SQL into a 0
                    profit_dgv.Rows(loopCount2).Cells(1).Text = "0"
                    loopCount2 = loopCount2 + 1
                Else
                    loopCount2 = loopCount2 + 1
                End If
            End While
        End Try

        cmd.Dispose()
        con.Close()

    End Sub

End Class