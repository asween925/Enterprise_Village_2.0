Imports System.Data.SqlClient
Public Class Amount_spend_report
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim DBConnection As New DatabaseConection
    Dim dr As SqlDataReader
    Dim TransactionData As New Class_TransactionData
    Dim SchoolData As New Class_SchoolData
    Dim VisitID As New Class_VisitData
    Dim Visit As Integer = VisitID.GetVisitID

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Asks if the session is still active, if not, then it will redirect to the login screen
        If Session("LoggedIn") <> "1" Then
            Response.Redirect(".\default.aspx")
        End If

        If Not (IsPostBack) Then

            'Check if a visit date has been created
            If Visit <> 0 Then
                visitdate_hf.Value = Visit
            End If

            'Populating school header
            Dim header As New Class_SchoolHeader
            headerSchoolName_lbl.Text = header.GetSchoolHeader()

        End If
    End Sub

    Sub LoadData()
        Dim VisitDate As String = visitDate_tb.Text
        Dim SelectedVisitID As String

        'Get selected visit ID
        Try
            SelectedVisitID = VisitID.GetVisitIDFromDate(VisitDate)
        Catch
            error_lbl.Text = "Error in loaddata(). Could not get selected visit ID."
            Exit Sub
        End Try

        'Get school name(s)
        Try
            Schools_lbl.Text = SchoolData.GetSchoolsString(VisitDate)
        Catch
            error_lbl.Text = "Error in loaddata(). Could not retrieve school name."
            Exit Sub

        End Try

        'get amount spent
        Try
            businessProfit_dgv.DataSource = TransactionData.LoadStudentTotalPurchasesTable(SelectedVisitID)
            businessProfit_dgv.DataBind()

            If businessProfit_dgv.Rows.Count = 0 Then
                error_lbl.Text = "No students have spent their money yet!"
            Else
                error_lbl.Text = ""
            End If

        Catch
            error_lbl.Text = "Error in loaddata(). Could not get student transaction information."
            Exit Sub
        End Try

    End Sub

    Protected Sub print_btn_Click(sender As Object, e As EventArgs) Handles print_btn.Click
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "PrintBadges", "PrintBadges();", True)
    End Sub

    Protected Sub visitDate_tb_TextChanged(sender As Object, e As EventArgs) Handles visitDate_tb.TextChanged
        If visitDate_tb.Text <> Nothing Then
            content_div.Visible = True
            LoadData()
        End If
    End Sub
End Class