Imports System.Data.SqlClient
Public Class Print_ISI
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
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        'Get schoolID from URL from login page
        Dim schoolID As String = Request.QueryString("b")

        If schoolID = Nothing Then
            schoolID = 505
            Exit Sub
        End If

        If Not (IsPostBack) Then
            Dim VisitID As New Class_VisitData
            Dim Visit As Integer = VisitID.GetVisitID
            If Visit <> 0 Then
                visitdate_hf.Value = Visit
            End If

            Dim visitIDSQL As String = "SELECT id FROM visitInfo WHERE school = '" & schoolID & "' OR school2 = '" & schoolID & "' OR school3 = '" & schoolID & "' OR school4 = '" & schoolID & "' OR school5 = '" & schoolID & "' AND visitDate BETWEEN '08-10-2022' AND '07-01-2023'"

            'Get visit ID using schoolID from URL
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.CommandText = visitIDSQL
                cmd.Connection = con
                dr = cmd.ExecuteReader

                While dr.Read()
                    visitID_hf.Value = dr("id").ToString
                    'error_lbl.Text = visitID_hf.Value
                End While

                cmd.Dispose()
                con.Close()

            Catch
                Exit Sub

            End Try

            'Get School Name
            Dim schoolNameSQL As String = "SELECT s.SchoolName FROM Schoolinfo s INNER JOIN visitInfo v on s.ID = v.School OR s.id = v.school2 or s.id = v.school3 or s.id = v.school4 or s.id = v.school5 WHERE v.id='" & visitID_hf.Value & "' AND s.id='" & schoolID & "'"
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.CommandText = schoolNameSQL
                cmd.Connection = con
                dr = cmd.ExecuteReader

                While dr.Read()
                    Schools_lbl.Text = dr("schoolName").ToString & " for "
                End While

                cmd.Dispose()
                con.Close()

            Catch
                'error_lbl.Text = "Error in schoolNameSQL query. Please use the link below to email us about this issue."
                Exit Sub
            End Try

            'Get Visit Date
            Dim visitDateSQL As String = "SELECT FORMAT(visitDate,'MM/dd/yyyy') as visitDate FROM visitInfo WHERE id='" & visitID_hf.Value & "'"
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.CommandText = visitDateSQL
                cmd.Connection = con
                dr = cmd.ExecuteReader

                While dr.Read()
                    visitDate_lbl.Text = dr("visitDate").ToString
                End While

                cmd.Dispose()
                con.Close()

            Catch
                Exit Sub
            End Try

            'Fill out print table
            Try
                Dim visitDate As String = visitDate_lbl.Text
                con.ConnectionString = connection_string
                Dim sql As String = "Select s.id, s.firstName, s.lastName, s.employeenumber, b.businessName, sc.schoolName, j.jobTitle
                                from studentInfo s
                                inner join businessInfo b 
	                                on b.id=s.businessID
                                inner join jobs j
	                                on j.id=s.jobID
                                inner join visitInfo v
	                                on v.id=s.visitID
								inner join schoolInfo sc
									on s.schoolID = sc.id
                                        where v.visitDate ='" & visitDate & "' and sc.id='" & schoolID & "' and not b.businessName='Training Business' and not s.firstName IS NULL and not s.lastName IS NULL"

                Review_sds.ConnectionString = connection_string
                Review_sds.SelectCommand = sql
                employees_dgv.DataSource = Review_sds
                employees_dgv.DataBind()
                con.Dispose()
                con.Close()
                cmd.Dispose()
            Catch
                Exit Sub
            End Try
        End If


        SqlConnection.ClearAllPools()

    End Sub

End Class