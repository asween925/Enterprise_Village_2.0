Imports System.Data.SqlClient
Public Class Student_Spending_Report
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim DBConnection As New DatabaseConection
    Dim dr As SqlDataReader

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Asks if the session is still active, if not, then it will redirect to the login screen
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
                'Else
                '    error_lbl.Text = "No visit date, please go to 'Database Creator' on the 'Tools / Reports' page and create a new school visit date."
            End If

            'Populating school header
            Dim header As New Class_SchoolHeader
            headerSchoolName_lbl.Text = header.GetSchoolHeader()

        End If
    End Sub

    Sub LoadData()
        'Dim visitID As Integer = visitdate_hf.Value
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        con.ConnectionString = connection_string
        Dim accountNumber As String = empnum_hf.Value
        Dim initialDeposit1 As Double = 0.00
        Dim initialDeposit2 As Double = 0.00
        Dim initialDeposit3 As Double = 0.00
        Dim initialDeposit4 As Double = 0.00
        Dim cbw1 As Double = 0.00
        Dim cbw2 As Double = 0.00
        Dim cbw3 As Double = 0.00
        Dim cbw4 As Double = 0.00
        Dim cbwtotal As Double = 0.00
        Dim sales1 As Double = 0.00
        Dim sales2 As Double = 0.00
        Dim sales3 As Double = 0.00
        Dim sales4 As Double = 0.00
        Dim salestotal As Double = 0.00
        Dim savings As Double = 0.00
        Dim rowCount As Integer = 0
        Dim visitDate As Integer
        Dim schoolID As Integer

        'Get Visit ID for selected visit date
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd.CommandText = "SELECT id FROM visitInfo WHERE visitDate='" & visitDate_tb.Text & "'"
            cmd.Connection = con
            dr = cmd.ExecuteReader

            While dr.Read()
                visitDate = dr("id").ToString
            End While

            cmd.Dispose()
            con.Close()

        Catch
            error_lbl.Text = "Error in loaddata(). Cannot find visit ID for selected visit date."
            Exit Sub
        End Try

        'Get school ID from school DDL
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd.CommandText = "SELECT id FROM schoolInfo WHERE schoolName='" & schools_ddl.SelectedValue & "'"
            cmd.Connection = con
            dr = cmd.ExecuteReader

            While dr.Read()
                schoolID = dr("id").ToString
            End While

            cmd.Dispose()
            con.Close()

        Catch
            error_lbl.Text = "Error in loaddata(). Cannot find visit ID for selected visit date."
            Exit Sub
        End Try

        'Load astro skate transacation data
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = " SELECT t.employeeNumber, CONCAT(s.firstName, ' ', s.lastName) as studentName, SUM(ISNULL(saleAmount,0) + ISNULL(saleAmount2,0)
                                    + ISNULL(saleAmount3,0) + ISNULL(saleAmount4,0)) as saleTotal 
                                  FROM transactions t
                                  INNER JOIN studentInfo s
                                  ON t.employeeNumber = s.employeeNumber
                                  WHERE t.visitDate='" & visitDate & "' AND s.visit='" & visitDate & "' AND t.business=10 AND s.school='" & schoolID & "'
                                  GROUP BY t.employeeNumber, s.firstName, s.lastName"

            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)
            astro_dgv.DataSource = dt
            astro_dgv.DataBind()

            If astro_dgv.Rows.Count <> 0 Then
                astro_div.Visible = True
            Else
                astro_div.Visible = False
            End If

            error_lbl.Text = ""

            cmd.Dispose()
            con.Close()

        Catch
            error_lbl.Text = "Error in loaddata(). Cannot load data for astro skate."
            Exit Sub

        End Try

        'Load bbb transacation data
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = " SELECT t.employeeNumber, CONCAT(s.firstName, ' ', s.lastName) as studentName, SUM(ISNULL(saleAmount,0) + ISNULL(saleAmount2,0)
                                    + ISNULL(saleAmount3,0) + ISNULL(saleAmount4,0)) as saleTotal 
                                  FROM transactions t
                                  INNER JOIN studentInfo s
                                  ON t.employeeNumber = s.employeeNumber
                                  WHERE t.visitDate='" & visitDate & "' AND s.visit='" & visitDate & "' AND t.business=9 AND s.school='" & schoolID & "'
                                  GROUP BY t.employeeNumber, s.firstName, s.lastName"

            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)
            bbb_dgv.DataSource = dt
            bbb_dgv.DataBind()

            If bbb_dgv.Rows.Count <> 0 Then
                bbb_div.Visible = True
            Else
                bbb_div.Visible = False
            End If

            error_lbl.Text = ""

            cmd.Dispose()
            con.Close()

        Catch
            error_lbl.Text = "Error in loaddata(). Cannot load data for bbb."
            Exit Sub

        End Try

        'Load bic transacation data
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = " SELECT t.employeeNumber, CONCAT(s.firstName, ' ', s.lastName) as studentName, SUM(ISNULL(saleAmount,0) + ISNULL(saleAmount2,0)
                                    + ISNULL(saleAmount3,0) + ISNULL(saleAmount4,0)) as saleTotal 
                                  FROM transactions t
                                  INNER JOIN studentInfo s
                                  ON t.employeeNumber = s.employeeNumber
                                  WHERE t.visitDate='" & visitDate & "' AND s.visit='" & visitDate & "' AND t.business=6 AND s.school='" & schoolID & "'
                                  GROUP BY t.employeeNumber, s.firstName, s.lastName"

            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)
            bic_dgv.DataSource = dt
            bic_dgv.DataBind()

            If bic_dgv.Rows.Count <> 0 Then
                bic_div.Visible = True
            Else
                bic_div.Visible = False
            End If

            error_lbl.Text = ""

            cmd.Dispose()
            con.Close()

        Catch
            error_lbl.Text = "Error in loaddata(). Cannot load data for bic."
            Exit Sub

        End Try

        'Load cvs transacation data
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = " SELECT t.employeeNumber, CONCAT(s.firstName, ' ', s.lastName) as studentName, SUM(ISNULL(saleAmount,0) + ISNULL(saleAmount2,0)
                                    + ISNULL(saleAmount3,0) + ISNULL(saleAmount4,0)) as saleTotal 
                                  FROM transactions t
                                  INNER JOIN studentInfo s
                                  ON t.employeeNumber = s.employeeNumber
                                  WHERE t.visitDate='" & visitDate & "' AND s.visit='" & visitDate & "' AND t.business=3 AND s.school='" & schoolID & "'
                                  GROUP BY t.employeeNumber, s.firstName, s.lastName"

            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)
            cvs_dgv.DataSource = dt
            cvs_dgv.DataBind()

            If cvs_dgv.Rows.Count <> 0 Then
                cvs_div.Visible = True
            Else
                cvs_div.Visible = False
            End If

            error_lbl.Text = ""

            cmd.Dispose()
            con.Close()

        Catch
            error_lbl.Text = "Error in loaddata(). Cannot load data for cvs."
            Exit Sub

        End Try

        'Load ditek transacation data
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = " SELECT t.employeeNumber, CONCAT(s.firstName, ' ', s.lastName) as studentName, SUM(ISNULL(saleAmount,0) + ISNULL(saleAmount2,0)
                                    + ISNULL(saleAmount3,0) + ISNULL(saleAmount4,0)) as saleTotal 
                                  FROM transactions t
                                  INNER JOIN studentInfo s
                                  ON t.employeeNumber = s.employeeNumber
                                  WHERE t.visitDate='" & visitDate & "' AND s.visit='" & visitDate & "' AND t.business=11 AND s.school='" & schoolID & "'
                                  GROUP BY t.employeeNumber, s.firstName, s.lastName"

            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)
            ditek_dgv.DataSource = dt
            ditek_dgv.DataBind()

            If ditek_dgv.Rows.Count <> 0 Then
                ditek_div.Visible = True
            Else
                ditek_div.Visible = False
            End If

            error_lbl.Text = ""

            cmd.Dispose()
            con.Close()

        Catch
            error_lbl.Text = "Error in loaddata(). Cannot load data for ditek."
            Exit Sub

        End Try

        'Load hsn transacation data
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = " SELECT t.employeeNumber, CONCAT(s.firstName, ' ', s.lastName) as studentName, SUM(ISNULL(saleAmount,0) + ISNULL(saleAmount2,0)
                                    + ISNULL(saleAmount3,0) + ISNULL(saleAmount4,0)) as saleTotal 
                                  FROM transactions t
                                  INNER JOIN studentInfo s
                                  ON t.employeeNumber = s.employeeNumber
                                  WHERE t.visitDate='" & visitDate & "' AND s.visit='" & visitDate & "' AND t.business=8 AND s.school='" & schoolID & "'
                                  GROUP BY t.employeeNumber, s.firstName, s.lastName"

            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)
            hsn_dgv.DataSource = dt
            hsn_dgv.DataBind()

            If hsn_dgv.Rows.Count <> 0 Then
                hsn_div.Visible = True
            Else
                hsn_div.Visible = False
            End If

            error_lbl.Text = ""

            cmd.Dispose()
            con.Close()

        Catch
            error_lbl.Text = "Error in loaddata(). Cannot load data for hsn."
            Exit Sub

        End Try

        'Load kanes transacation data
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = " SELECT t.employeeNumber, CONCAT(s.firstName, ' ', s.lastName) as studentName, SUM(ISNULL(saleAmount,0) + ISNULL(saleAmount2,0)
                                    + ISNULL(saleAmount3,0) + ISNULL(saleAmount4,0)) as saleTotal 
                                  FROM transactions t
                                  INNER JOIN studentInfo s
                                  ON t.employeeNumber = s.employeeNumber
                                  WHERE t.visitDate='" & visitDate & "' AND s.visit='" & visitDate & "' AND t.business=5 AND s.school='" & schoolID & "'
                                  GROUP BY t.employeeNumber, s.firstName, s.lastName"

            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)
            kanes_dgv.DataSource = dt
            kanes_dgv.DataBind()

            If kanes_dgv.Rows.Count <> 0 Then
                kanes_div.Visible = True
            Else
                kanes_div.Visible = False
            End If

            error_lbl.Text = ""

            cmd.Dispose()
            con.Close()

        Catch
            error_lbl.Text = "Error in loaddata(). Cannot load data for kanes."
            Exit Sub

        End Try

        'Load mcdonalds transacation data
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = " SELECT t.employeeNumber, CONCAT(s.firstName, ' ', s.lastName) as studentName, SUM(ISNULL(saleAmount,0) + ISNULL(saleAmount2,0)
                                    + ISNULL(saleAmount3,0) + ISNULL(saleAmount4,0)) as saleTotal 
                                  FROM transactions t
                                  INNER JOIN studentInfo s
                                  ON t.employeeNumber = s.employeeNumber
                                  WHERE t.visitDate='" & visitDate & "' AND s.visit='" & visitDate & "' AND t.business=17 AND s.school='" & schoolID & "'
                                  GROUP BY t.employeeNumber, s.firstName, s.lastName"

            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)
            mcdonalds_dgv.DataSource = dt
            mcdonalds_dgv.DataBind()

            If mcdonalds_dgv.Rows.Count <> 0 Then
                mcdonalds_div.Visible = True
            Else
                mcdonalds_div.Visible = False
            End If

            error_lbl.Text = ""

            cmd.Dispose()
            con.Close()

        Catch
            error_lbl.Text = "Error in loaddata(). Cannot load data for mcdonalds."
            Exit Sub

        End Try

        'Load bucs transacation data
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = " SELECT t.employeeNumber, CONCAT(s.firstName, ' ', s.lastName) as studentName, SUM(ISNULL(saleAmount,0) + ISNULL(saleAmount2,0)
                                    + ISNULL(saleAmount3,0) + ISNULL(saleAmount4,0)) as saleTotal 
                                  FROM transactions t
                                  INNER JOIN studentInfo s
                                  ON t.employeeNumber = s.employeeNumber
                                  WHERE t.visitDate='" & visitDate & "' AND s.visit='" & visitDate & "' AND t.business=1 AND s.school='" & schoolID & "'
                                  GROUP BY t.employeeNumber, s.firstName, s.lastName"

            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)
            bucs_dgv.DataSource = dt
            bucs_dgv.DataBind()

            If bucs_dgv.Rows.Count <> 0 Then
                bucs_div.Visible = True
            Else
                bucs_div.Visible = False
            End If

            error_lbl.Text = ""

            cmd.Dispose()
            con.Close()

        Catch
            error_lbl.Text = "Error in loaddata(). Cannot load data for bucs."
            Exit Sub

        End Try

        'Load rays transacation data
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = " SELECT t.employeeNumber, CONCAT(s.firstName, ' ', s.lastName) as studentName, SUM(ISNULL(saleAmount,0) + ISNULL(saleAmount2,0)
                                    + ISNULL(saleAmount3,0) + ISNULL(saleAmount4,0)) as saleTotal 
                                  FROM transactions t
                                  INNER JOIN studentInfo s
                                  ON t.employeeNumber = s.employeeNumber
                                  WHERE t.visitDate='" & visitDate & "' AND s.visit='" & visitDate & "' AND t.business=2 AND s.school='" & schoolID & "'
                                  GROUP BY t.employeeNumber, s.firstName, s.lastName"

            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)
            rays_dgv.DataSource = dt
            rays_dgv.DataBind()

            If rays_dgv.Rows.Count <> 0 Then
                rays_div.Visible = True
            Else
                rays_div.Visible = False
            End If

            error_lbl.Text = ""

            cmd.Dispose()
            con.Close()

        Catch
            error_lbl.Text = "Error in loaddata(). Cannot load data for rays."
            Exit Sub
        End Try

        'Load times transacation data
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = " SELECT t.employeeNumber, CONCAT(s.firstName, ' ', s.lastName) as studentName, SUM(ISNULL(saleAmount,0) + ISNULL(saleAmount2,0)
                                    + ISNULL(saleAmount3,0) + ISNULL(saleAmount4,0)) as saleTotal 
                                  FROM transactions t
                                  INNER JOIN studentInfo s
                                  ON t.employeeNumber = s.employeeNumber
                                  WHERE t.visitDate='" & visitDate & "' AND s.visit='" & visitDate & "' AND t.business=22 AND s.school='" & schoolID & "'
                                  GROUP BY t.employeeNumber, s.firstName, s.lastName"

            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)
            times_dgv.DataSource = dt
            times_dgv.DataBind()

            If times_dgv.Rows.Count <> 0 Then
                times_div.Visible = True
            Else
                times_div.Visible = False
            End If

            error_lbl.Text = ""

            cmd.Dispose()
            con.Close()

        Catch
            error_lbl.Text = "Error in loaddata(). Cannot load data for times."
            Exit Sub

        End Try

        'Load techdata transacation data
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = " SELECT t.employeeNumber, CONCAT(s.firstName, ' ', s.lastName) as studentName, SUM(ISNULL(saleAmount,0) + ISNULL(saleAmount2,0)
                                    + ISNULL(saleAmount3,0) + ISNULL(saleAmount4,0)) as saleTotal 
                                  FROM transactions t
                                  INNER JOIN studentInfo s
                                  ON t.employeeNumber = s.employeeNumber
                                  WHERE t.visitDate='" & visitDate & "' AND s.visit='" & visitDate & "' AND t.business=7 AND s.school='" & schoolID & "'
                                  GROUP BY t.employeeNumber, s.firstName, s.lastName"

            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)
            techdata_dgv.DataSource = dt
            techdata_dgv.DataBind()

            If techdata_dgv.Rows.Count <> 0 Then
                techdata_div.Visible = True
            Else
                techdata_div.Visible = False
            End If

            error_lbl.Text = ""

            cmd.Dispose()
            con.Close()

        Catch
            error_lbl.Text = "Error in loaddata(). Cannot load data for techdata."
            Exit Sub

        End Try

        'Load students fincancial data
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "IF (OBJECT_ID('tempdb..#netdeposits') IS NOT NULL) DROP TABLE #netdeposits
       -- Total Deposits
       SELECT 
              s.employeeNumber
              ,s.firstName
              ,s.lastName
			  ,s.cbw1, s.cbw2, s.cbw3, s.cbw4
			  ,s.initialDeposit1, s.initialDeposit2, s.initialDeposit3, s.initialDeposit4, s.savings, s.school
			  ,SUM(ISNULL(s.cbw1,0) + ISNULL(s.cbw2,0) + ISNULL(s.cbw3,0) + ISNULL(s.cbw4,0)) as cbwTotal
              ,SUM(ISNULL(s.initialDeposit1,0) + ISNULL(s.initialDeposit2,0) + ISNULL(s.initialDeposit3,0) + ISNULL(s.initialDeposit4,0)) 
			  - SUM(ISNULL(s.cbw1,0) + ISNULL(s.cbw2,0) + ISNULL(s.cbw3,0) + ISNULL(s.cbw4,0)) - ISNULL(s.savings,0) totalDeposits
       INTO #netdeposits
       FROM dbo.studentInfo s
       WHERE s.visit = '" & visitDate & "' AND s.school='" & schoolID & "'
       GROUP BY s.employeeNumber, s.firstName, s.lastName, s.cbw1, s.cbw2, s.cbw3, s.cbw4, s.savings
	   , s.initialDeposit1, s.initialDeposit2, s.initialDeposit3, s.initialDeposit4, s.school
	   

       -- Total Purchases and with JOIN to #netdeposits temp table
       SELECT 
               t.employeeNumber, CONCAT (MAX(firstname), ' ',MAX(lastName)) as studentname
			   ,ISNULL(s.initialDeposit1,0) as initialDeposit1, ISNULL(s.initialDeposit2,0) as initialDeposit2, ISNULL(s.initialDeposit3,0) as initialDeposit3
			   , ISNULL(s.initialDeposit4,0) as initialDeposit4
			   ,s.cbwTotal, ISNULL(s.savings,0) as savings
              ,MAX(s.totalDeposits) TotalDeposits
              ,SUM(ISNULL(saleamount,0) + ISNULL(saleamount2,0)+ ISNULL(saleamount3,0)+ ISNULL(saleamount4,0)) as TotalPurchases
              ,MAX(s.totalDeposits) - sum(ISNULL(saleamount,0)+ ISNULL(saleamount2,0)+ ISNULL(saleamount3,0)+ ISNULL(saleamount4,0)) as Balance
       FROM transactions t
       INNER JOIN #netdeposits s ON t.employeeNumber = s.employeeNumber
       WHERE t.visitdate = '" & visitDate & "' AND s.school='" & schoolID & "'
       GROUP BY t.employeeNumber, s.initialDeposit1,s.initialDeposit1, s.initialDeposit2, s.initialDeposit3, s.initialDeposit4
	   ,s.cbwTotal, s.savings, s.school
       ORDER BY employeeNumber"

            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)
            students_dgv.DataSource = dt
            students_dgv.DataBind()

            If students_dgv.Rows.Count <> 0 Then
                students_dgv.Visible = True
            Else
                students_dgv.Visible = False
            End If

            error_lbl.Text = ""

            cmd.Dispose()
            con.Close()

        Catch
            error_lbl.Visible = True
            error_lbl.Text = "Error in loaddata(). Cannot fill out student financial information."

        End Try


        cmd.Dispose()
        con.Close()

    End Sub

    Protected Sub visitDate_tb_TextChanged(sender As Object, e As EventArgs) Handles visitDate_tb.TextChanged
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        con.ConnectionString = connection_string

        schools_ddl.Items.Clear()

        If visitDate_tb.Text <> Nothing Then
            schools_ddl.Visible = True
            selectschool_p.Visible = True

            'School ddl populate
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.CommandText = "SELECT s.schoolName as 'schoolName'
											  FROM schoolInfo s 
											  JOIN visitInfo v ON v.school = s.id OR v.school2 = s.id OR v.school3 = s.id OR v.school4 = s.id OR v.school5 = s.id
											  WHERE v.visitDate='" & visitDate_tb.Text & "' AND NOT s.id=505 
											  ORDER BY schoolName "
                cmd.Connection = con
                dr = cmd.ExecuteReader

                While dr.Read()
                    schools_ddl.Items.Add(dr(0).ToString)
                End While
                schools_ddl.Items.Insert(0, "")

                cmd.Dispose()
                con.Close()
            Catch
                error_lbl.Text = "Error in visitdate_tb(). Could not populate schools_ddl."
                Exit Sub
            Finally
                cmd.Dispose()
                con.Close()
            End Try
        Else
            schools_ddl.Visible = False
            selectschool_p.Visible = False
        End If
    End Sub

    Protected Sub schools_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles schools_ddl.SelectedIndexChanged
        If schools_ddl.SelectedIndex <> 0 Then
            schoolName_lbl.Text = schools_ddl.SelectedValue & " on " & visitDate_tb.Text
            LoadData()
        Else
            schoolName_lbl.Text = ""
            students_dgv.Visible = False
            astro_div.Visible = False
            bbb_div.Visible = False
            bic_div.Visible = False
            cvs_div.Visible = False
            ditek_div.Visible = False
            hsn_div.Visible = False
            kanes_div.Visible = False
            mcdonalds_div.Visible = False
            bucs_div.Visible = False
            rays_div.Visible = False
            times_div.Visible = False
            techdata_div.Visible = False
        End If
    End Sub

    Protected Sub print_btn_Click(sender As Object, e As EventArgs) Handles print_btn.Click
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "printBadges", "PrintBadges();", True)
    End Sub

    'Old code may not need anymore 
    '
    '"SELECT s.employeeNumber, CONCAT(s.firstName, ' ', s.lastName) as studentName
    '                        , s.initialDeposit1, s.initialDeposit2, s.initialDeposit3, s.initialDeposit4
    '                        , SUM(ISNULL(s.initialDeposit1,0) + ISNULL(s.initialDeposit2,0) + ISNULL(s.initialDeposit3,0) + ISNULL(s.initialDeposit4,0)) as depositTotal
    '                        , s.savings, b.businessName
    '                        , SUM(t.saleAmount + t.saleAmount2 + t.saleAmount3 + t.saleAmount4) as saleTotal
    '                        , SUM(ISNULL(s.cbw1,0) + ISNULL(s.cbw2,0) + ISNULL(s.cbw3,0) + ISNULL(s.cbw4,0)) as cbwtotal
    '                        , SUM(ISNULL(s.initialDeposit1,0) + ISNULL(s.initialDeposit2,0) + ISNULL(s.initialDeposit3,0) + ISNULL(s.initialDeposit4,0))
    '                        - (SUM(t.saleAmount + t.saleAmount2 + t.saleAmount3 + t.saleAmount4))
    '                        - (SUM(ISNULL(s.cbw1,0) + ISNULL(s.cbw2,0) + ISNULL(s.cbw3,0) + ISNULL(s.cbw4,0)))
    '                        - s.savings as balance
    '                        FROM studentInfo s
    '                        INNER JOIN transactions t
    '                        ON t.employeeNumber = s.employeeNumber
    '                        INNER JOIN businessInfo b
    '                        ON b.id = t.business
    '                        WHERE s.visit='" & visitDate & "' AND t.visitDate='" & visitDate & "'
    '                        GROUP BY s.employeeNumber, s.firstName, s.lastName
    '                        , s.initialDeposit1, s.initialDeposit2, s.initialDeposit3, s.initialDeposit4, s.savings,
    '                        b.businessName, t.saleAmount, t.saleAmount2, t.saleAmount3, t.saleAmount4, s.cbw1, s.cbw2, s.cbw3, s.cbw4"
End Class