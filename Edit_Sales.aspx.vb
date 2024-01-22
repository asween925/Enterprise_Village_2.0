Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Drawing
Imports System
Public Class Edit_Sales
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
    Dim VisitID As New Class_VisitData
    Dim Visit As Integer = VisitID.GetVisitID

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
            End If

            'Populating school header
            Dim header As New Class_SchoolHeader
            headerSchoolName_lbl.Text = header.GetSchoolHeader()

        End If
    End Sub

    Sub loadData()
        Dim netDeposit As Double = 0.00
        Dim netDeposit1 As Double = 0.00
        Dim netDeposit2 As Double = 0.00
        Dim netDeposit3 As Double = 0.00
        Dim netDeposit4 As Double = 0.00
        Dim totalTransactions As Double = 0.00
        Dim remainingBalance As Double = 0.00
        Dim savings As Double = 0.00
        Dim con As New SqlConnection
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim sql As String = "SELECT t.id, b.businessName, t.saleAmount, t.saleAmount2, t.saleAmount3, t.saleAmount4 
                               FROM transactions t
                               INNER JOIN businessInfo b
                               ON b.id = t.business
                               WHERE visitDate='" & visitdate_hf.Value & "' AND employeeNumber='" & empID_hf.Value & "'"

        error_lbl.Text = ""

        con.ConnectionString = connection_string
        con.Open()

        sales_dgv.DataSource = Nothing
        sales_dgv.DataBind()

        'Populate sales table
        Try
            Review_sds.ConnectionString = connection_string
            Review_sds.SelectCommand = sql
            sales_dgv.DataSource = Review_sds
            sales_dgv.DataBind()

            If studentName_ddl.SelectedIndex <> 0 And sales_dgv.Rows.Count = 0 Then
                error_lbl.Text = "No purchases made for selected student."
            Else
                error_lbl.Text = ""
            End If
        Catch
            error_lbl.Text = "Error in loaddata(). Could not populate table."
            cmd.Dispose()
            con.Close()
            Exit Sub
        End Try

        cmd.Dispose()
        con.Close()

        'Get balance
        Try
            'Get netDeposit info
            con.ConnectionString = connection_string
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "SELECT netDeposit1, netDeposit2, netDeposit3, netDeposit4 FROM studentInfo WHERE visit='" & visitdate_hf.Value & "' AND employeeNumber ='" & empID_hf.Value & "'"
            dr = cmd.ExecuteReader
            While dr.Read
                If dr("netDeposit1").ToString = Nothing Then
                    netDeposit1 = 0.00
                Else
                    netDeposit1 = dr("netDeposit1")
                End If
                If dr("NetDeposit2").ToString = Nothing Then
                    netDeposit2 = 0.00
                Else
                    netDeposit2 = dr("netDeposit2")
                End If
                If dr("NetDeposit3").ToString = Nothing Then
                    netDeposit3 = 0.00
                Else
                    netDeposit3 = dr("netDeposit3")
                End If
                If dr("NetDeposit4").ToString = Nothing Then
                    netDeposit4 = 0.00
                Else
                    netDeposit4 = dr("netDeposit4")
                End If
            End While

            dr.Close()
            netDeposit = netDeposit1 + netDeposit2 + netDeposit3 + netDeposit4

            'Get total of all transactions for the day
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "SELECT SUM(saleamount + saleAmount2 + saleAmount3 + saleAmount4) as Transactions FROM transactions WHERE visitdate ='" & visitdate_hf.Value & "' AND employeeNumber ='" & empID_hf.Value & "'"
            dr = cmd.ExecuteReader
            While dr.Read
                If dr("transactions").ToString = Nothing Then
                    totalTransactions = 0.00
                Else
                    totalTransactions = dr("Transactions")
                End If

            End While
            dr.Close()

            'Get savings
            cmd.CommandText = "SELECT (savings) as savings FROM studentInfo WHERE visit='" & visitdate_hf.Value & "' AND employeeNumber ='" & empID_hf.Value & "'"
            dr = cmd.ExecuteReader
            While dr.Read()
                If dr("savings").ToString = Nothing Then
                    savings = 0.00
                Else
                    savings = dr("savings")
                End If
            End While
            dr.Close()

            'Get remaining balance for customer
            remainingBalance = netDeposit - totalTransactions - savings
            balance_lbl.Text = remainingBalance.ToString("C")

            cmd.Dispose()
            con.Close()
        Catch
            error_lbl.Text = "Error in loaddata(). Could not obtain balance information"
            Exit Sub
        End Try

        'Highlight row being edited
        For Each row As GridViewRow In sales_dgv.Rows
            If row.RowIndex = sales_dgv.EditIndex Then
                row.BackColor = ColorTranslator.FromHtml("#ebe534")
                'row.BorderColor = ColorTranslator.FromHtml("#ffffff")
                row.BorderWidth = 2
            End If
        Next

        cmd.Dispose()
        con.Close()

    End Sub

    Private Sub sales_dgv_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles sales_dgv.RowUpdating
        Dim row As GridViewRow = sales_dgv.Rows(0)                           'Code is used to enable the editing prodecure
        Dim ID As Integer = Convert.ToInt32(sales_dgv.DataKeys(e.RowIndex).Values(0)) 'Gets id number
        Dim saleAmount As String = TryCast(sales_dgv.Rows(e.RowIndex).FindControl("saleAmount_tb"), TextBox).Text 'Try cast is used to try to convert - gets item from ddl
        Dim saleAmount2 As String = TryCast(sales_dgv.Rows(e.RowIndex).FindControl("saleAmount2_tb"), TextBox).Text
        Dim saleAmount3 As String = TryCast(sales_dgv.Rows(e.RowIndex).FindControl("saleAmount3_tb"), TextBox).Text
        Dim saleAmount4 As String = TryCast(sales_dgv.Rows(e.RowIndex).FindControl("saleAmount4_tb"), TextBox).Text

        'Updating rows with entered data
        Try
            Using con As New SqlConnection(connection_string)
                Using cmd As New SqlCommand("UPDATE transactions SET saleAmount=@saleAmount, saleAmount2=@saleAmount2, saleAmount3=@saleAmount3, saleAmount4=@saleAmount4 WHERE ID=@Id")
                    cmd.Parameters.AddWithValue("@ID", ID)
                    cmd.Parameters.AddWithValue("@saleAmount", saleAmount)
                    cmd.Parameters.AddWithValue("@saleAmount2", saleAmount2)
                    cmd.Parameters.AddWithValue("@saleAmount3", saleAmount3)
                    cmd.Parameters.AddWithValue("@saleAmount4", saleAmount4)
                    cmd.Connection = con
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
            sales_dgv.EditIndex = -1 'reset the grid after editing
            loadData()
        Catch
            error_lbl.Text = "Error with updating. Please contact IT."
            Exit Sub
        End Try

    End Sub
    Private Sub sales_dgv_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles sales_dgv.RowEditing
        sales_dgv.EditIndex = e.NewEditIndex
        loadData()
    End Sub

    Private Sub sales_dgv_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles sales_dgv.RowCancelingEdit
        sales_dgv.EditIndex = -1
        loadData()
    End Sub

    Private Sub sales_dgv_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles sales_dgv.PageIndexChanging
        sales_dgv.PageIndex = e.NewPageIndex
        loadData()
    End Sub

    Protected Sub studentName_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles studentName_ddl.SelectedIndexChanged
        If studentName_ddl.SelectedIndex <> 0 Then
            sales_dgv.Visible = True
            studentBalance_p.Visible = True
            balance_lbl.Visible = True
            Dim test() As String = studentName_ddl.SelectedValue.Split(".")
            empID_hf.Value = test(0)
            loadData()
        Else
            sales_dgv.Visible = False
            empID_hf.Value = 0
        End If
    End Sub

    Protected Sub visitDate_tb_TextChanged(sender As Object, e As EventArgs) Handles visitDate_tb.TextChanged
        Dim con As New SqlConnection
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim visitID As Integer

        If visitDate_tb.Text <> Nothing Then
            selectStudent_p.Visible = True
            studentName_ddl.Visible = True

            'Get visitID from visit date
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd = New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "SELECT id FROM visitInfo WHERE visitDate='" & visitDate_tb.Text & "'"
                dr = cmd.ExecuteReader

                While dr.Read
                    visitID = dr("id")
                End While

                If visitID = 0 Then
                    error_lbl.Text = "No visit date created for selected date. Please create one in the Create a Visit page."
                    Exit Sub
                Else
                    visitdate_hf.Value = visitID
                End If


                cmd.Dispose()
                con.Close()
            Catch
                error_lbl.Text = "Error in visitDate_tb. Could not find visit ID."
                Exit Sub

                cmd.Dispose()
                con.Close()
            End Try

            cmd.Dispose()
            con.Close()

            'Populating student name ddl

            Dim studentName As String = "SELECT CONCAT(employeeNumber, '.     ', firstName, ' ', lastName) as 'Account # and Name' FROM studentInfo WHERE visit='" & visitdate_hf.Value & "'  AND NOT lastName IS NULL"
            studentName_ddl.Items.Clear()

            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.CommandText = studentName
                cmd.Connection = con
                dr = cmd.ExecuteReader

                While dr.Read()
                    studentName_ddl.Items.Add(dr(0).ToString)
                End While

                studentName_ddl.Items.Insert(0, "")

                cmd.Dispose()
                con.Close()

            Catch
                error_lbl.Text = "Error in visitDate_tb. Cannot populate studentName_DDL."
                Exit Sub
            Finally
                cmd.Dispose()
                con.Close()

            End Try

            loadData()
        Else
            selectStudent_p.Visible = False
            studentName_ddl.Visible = False
            studentBalance_p.Visible = False
            balance_lbl.Visible = False
        End If
    End Sub

End Class