Imports System.Data.SqlClient

Public Class Badge_Creator_Print
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim DBConnection As New DatabaseConection
    Dim dr As SqlDataReader
    Dim BadgesData As New Class_BadgesData
    Dim VisitID As New Class_VisitData
    Dim Visit As Integer = VisitID.GetVisitID
    Dim path As String = "X:\inetpub\wwwroot\EV\media\Badge Photos\"
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Check if visit ID is not 0
        If Visit = 0 Then
            error_lbl.Text = "No visit date, please go to 'Database Creator' on the 'Tools / Reports' page and create a new school visit date."
            Exit Sub
        End If

        'Load badges into the drop down list
        LoadBadgesIntoDDL()

    End Sub

    Sub LoadPrintBadges()
        Dim studentName() As String = badges_ddl.SelectedValue.Split(".")
        Dim SQLWhere As String = " AND (employeeNumber = '" & studentName(0) & "')"


        If employeeNumber_lbl1.Text = Nothing Then

            'Clear out gridview
            printBadges_dgv.DataSource = Nothing
            printBadges_dgv.DataBind()

            'Load gridview with badge of account num
            Try
                printBadges_dgv.DataSource = BadgesData.LoadExistingBadgesTable(Visit, SQLWhere)
                printBadges_dgv.DataBind()
            Catch
                error_lbl.Text = "Error in LoadPrintBadges(). Cannot load badges. Please find an Enterprise Village teacher!"
                Exit Sub
            End Try

            'Assign labels 
            If badges_ddl.SelectedValue <> Nothing Then
                'Populate badge with data from the existingBadges table
                Dim row As GridViewRow = printBadges_dgv.Rows(0)
                'Dim path As String = "~/media/"
                studentName_lbl1.Text = row.Cells(2).Text
                businessName_lbl1.Text = row.Cells(3).Text
                position_lbl1.Text = row.Cells(4).Text
                date_lbl1.Text = FormatDateTime(row.Cells(6).Text, DateFormat.ShortDate)
                'photo_img1.ImageUrl = path & row.Cells(7).Text
                photo_img1.ImageUrl = row.Cells(7).Text
                photo_img1.Visible = True
                employeeNumber_lbl1.Text = row.Cells(1).Text

                'Clear badges from DDL
                badges_ddl.Items.Clear()
                LoadBadgesIntoDDL()

                Exit Sub
            End If

        ElseIf employeeNumber_lbl2.Text = Nothing Then

            'Clear out gridview
            printBadges_dgv.DataSource = Nothing
            printBadges_dgv.DataBind()

            'Load gridview with badge of account num
            Try
                printBadges_dgv.DataSource = BadgesData.LoadExistingBadgesTable(Visit, SQLWhere)
                printBadges_dgv.DataBind()
            Catch
                error_lbl.Text = "Error in LoadPrintBadges(). Cannot load badges. Please find an Enterprise Village teacher!"
                Exit Sub
            End Try

            'Assign labels 
            If badges_ddl.SelectedValue <> Nothing Then
                'Populate badge with data from the existingBadges table
                Dim row As GridViewRow = printBadges_dgv.Rows(0)
                Dim path As String = "~/media/"
                studentName_lbl2.Text = row.Cells(2).Text
                businessName_lbl2.Text = row.Cells(3).Text
                position_lbl2.Text = row.Cells(4).Text
                date_lbl2.Text = FormatDateTime(row.Cells(6).Text, DateFormat.ShortDate)
                'photo_img2.ImageUrl = path & row.Cells(7).Text
                photo_img2.ImageUrl = row.Cells(7).Text
                photo_img2.Visible = True
                employeeNumber_lbl2.Text = row.Cells(1).Text

                'Clear badges from DDL
                badges_ddl.Items.Clear()
                LoadBadgesIntoDDL()

                Exit Sub
            End If

        ElseIf employeeNumber_lbl3.Text = Nothing Then

            'Clear out gridview
            printBadges_dgv.DataSource = Nothing
            printBadges_dgv.DataBind()

            'Load gridview with badge of account num
            Try
                printBadges_dgv.DataSource = BadgesData.LoadExistingBadgesTable(Visit, SQLWhere)
                printBadges_dgv.DataBind()
            Catch
                error_lbl.Text = "Error in LoadPrintBadges(). Cannot load badges. Please find an Enterprise Village teacher!"
                Exit Sub
            End Try

            'Assign labels 
            If badges_ddl.SelectedValue <> Nothing Then
                'Populate badge with data from the existingBadges table
                Dim row As GridViewRow = printBadges_dgv.Rows(0)
                Dim path As String = "~/media/"
                studentName_lbl3.Text = row.Cells(2).Text
                businessName_lbl3.Text = row.Cells(3).Text
                position_lbl3.Text = row.Cells(4).Text
                date_lbl3.Text = FormatDateTime(row.Cells(6).Text, DateFormat.ShortDate)
                'photo_img3.ImageUrl = path & row.Cells(7).Text
                photo_img3.ImageUrl = row.Cells(7).Text
                photo_img3.Visible = True
                employeeNumber_lbl3.Text = row.Cells(1).Text

                'Clear badges from DDL
                badges_ddl.Items.Clear()
                LoadBadgesIntoDDL()

                Exit Sub
            End If

        ElseIf employeeNumber_lbl4.Text = Nothing Then

            'Clear out gridview
            printBadges_dgv.DataSource = Nothing
            printBadges_dgv.DataBind()

            'Load gridview with badge of account num
            Try
                printBadges_dgv.DataSource = BadgesData.LoadExistingBadgesTable(Visit, SQLWhere)
                printBadges_dgv.DataBind()
            Catch
                error_lbl.Text = "Error in LoadPrintBadges(). Cannot load badges. Please find an Enterprise Village teacher!"
                Exit Sub
            End Try

            'Assign labels 
            If badges_ddl.SelectedValue <> Nothing Then
                'Populate badge with data from the existingBadges table
                Dim row As GridViewRow = printBadges_dgv.Rows(0)
                Dim path As String = "~/media/"
                studentName_lbl4.Text = row.Cells(2).Text
                businessName_lbl4.Text = row.Cells(3).Text
                position_lbl4.Text = row.Cells(4).Text
                date_lbl4.Text = FormatDateTime(row.Cells(6).Text, DateFormat.ShortDate)
                'photo_img4.ImageUrl = path & row.Cells(7).Text
                photo_img4.ImageUrl = row.Cells(7).Text
                photo_img4.Visible = True
                employeeNumber_lbl4.Text = row.Cells(1).Text

                'Clear badges from DDL
                badges_ddl.Items.Clear()
                LoadBadgesIntoDDL()

                Exit Sub
            End If

        End If
    End Sub

    Sub LoadBadgesIntoDDL()

        'Load badges into DDL
        Try
            BadgesData.LoadExistingBadgesNamesDDL(Visit, badges_ddl)
        Catch
            error_lbl.Text = "Error in LoadBadgesIntoDDL(). Cannot find employeeName or employeeNumber. Contact IT support."
            Exit Sub
        End Try

        'If printed badges are loaded, clear out loaded names from DDL
        If studentName_lbl1.Text <> Nothing Then
            badges_ddl.Items.Remove(employeeNumber_lbl1.Text & ".   " & studentName_lbl1.Text)
        End If

        If studentName_lbl2.Text <> Nothing Then
            badges_ddl.Items.Remove(employeeNumber_lbl2.Text & ".   " & studentName_lbl2.Text)
        End If

        If studentName_lbl3.Text <> Nothing Then
            badges_ddl.Items.Remove(employeeNumber_lbl3.Text & ".   " & studentName_lbl3.Text)
        End If

        If studentName_lbl4.Text <> Nothing Then
            badges_ddl.Items.Remove(employeeNumber_lbl4.Text & ".   " & studentName_lbl4.Text)
            error_lbl.Text = "You have 4 badges ready to be printed. Please find a teacher so you can print the badges."
            badges_ddl.Enabled = False
        End If

    End Sub

    Protected Sub badges_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles badges_ddl.SelectedIndexChanged
        If badges_ddl.SelectedIndex <> 0 Then
            LoadPrintBadges()
        Else
            Exit Sub
        End If
    End Sub

    Protected Sub refresh_btn_Click(sender As Object, e As EventArgs) Handles refresh_btn.Click
        Response.Redirect(".\badge_creator_print.aspx")
    End Sub

    Protected Sub print_btn_Click(sender As Object, e As EventArgs) Handles print_btn.Click

        'Check if password matches, if so print, if not show error
        If password_tb.Text = "gsi123" Then
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "PrintPage", "PrintPage();", True)
            error_lbl.Text = "Click 'Clear' to clear out the loaded badges."
        Else
            error_lbl.Text = "Password is incorrect. Please ask an Enterprise Village staff member for assistance."
            Exit Sub
        End If

    End Sub
End Class