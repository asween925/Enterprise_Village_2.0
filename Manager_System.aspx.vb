Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class Manager_System
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim BusinessData As New Class_BusinessData
    Dim VisitData As New Class_VisitData
    Dim VisitID As Integer = VisitData.GetVisitID
    Dim logoRoot As String = "~/media/Logos/"
    Dim BusinessID As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (IsPostBack) Then
            BusinessID = Request.QueryString("b")

            If BusinessID = Nothing Then
                BusinessID = 0
            End If

            ChangeBusiness()

            UpdateLogoAndTitle()

            'Load businesses into ddl
            BusinessData.LoadBusinessNamesDDL(ditekBusinessDDL_ddl)
            BusinessData.LoadBusinessNamesDDL(dukeBusiness_ddl)

            'Remove Duke, UPS, Dali, PCW, and PCSW from DDL
            dukeBusiness_ddl.Items.Remove("Duke Energy")
            dukeBusiness_ddl.Items.Remove("UPS")
            dukeBusiness_ddl.Items.Remove("Salvador Dali Art Center")
            dukeBusiness_ddl.Items.Remove("Pinellas County Water")
            dukeBusiness_ddl.Items.Remove("Pinellas County Solid Waste")
        End If
    End Sub

    Sub Ditek()
        Dim BusinessName As String = ditekBusinessDDL_ddl.SelectedValue
        Dim DitekBusinessID As String

        'Get business ID of ditek
        DitekBusinessID = BusinessData.GetBusinessID(BusinessName)

        'Invisible pricing key
        ditekPricingKey_div.Visible = False

        'Display divs for business ID
        Select Case DitekBusinessID
            Case 1
                ditekPricingKey_div.Visible = True
            Case 2
                ditekPricingKey_div.Visible = True
            Case 3
                ditekPricingKey_div.Visible = True
            Case 5
                ditekPricingKey_div.Visible = True
            Case 6
                ditekPricingKey_div.Visible = True
            Case 7
                ditekPricingKey_div.Visible = True
            Case 8
                ditekPricingKey_div.Visible = True
            Case 9
                ditekPricingKey_div.Visible = True
            Case 10
                ditekPricingKey_div.Visible = True
            Case 17
                ditekPricingKey_div.Visible = True
        End Select

        'Load timestamp data
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "SELECT i.id, i.itemName, i.usedDaily, i.businessUsed, i.merchCode
                                FROM EV_Inventory i
                                INNER JOIN businessInfo b
                                ON businessUsed = b.businessName
                                WHERE b.businessName = '" & BusinessName & "'"

            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)
            items_dgv.DataSource = dt
            items_dgv.DataBind()

            cmd.Dispose()
            con.Close()

        Catch
            ditekError_lbl.Text = "Error in LoadData(). Cannot get load data from items."
            Exit Sub
        End Try

        cmd.Dispose()
        con.Close()
    End Sub

    Sub Duke()
        Dim AcctNum As String
        Dim EnergyUsed As String
        Dim Yesterday As String
        Dim Today As String
        Dim Kilo As String
        Dim Fuel As String
        Dim TotalElectric As String
        Dim TotalFinal As String

        'Clear error label
        dukeError_lbl.Text = ""

        'Check if a business is selected from the DDL
        If dukeBusiness_ddl.SelectedIndex = 0 Then
            dukeError_lbl.Text = "Please select a business from the drop down menu at the top of the screen before calculating."
            Exit Sub
        End If

        'Check if fields are filled out
        If dukeAcctNum_tb.Text = Nothing Or dukeAcctNum_tb.Text = "" Then
            dukeError_lbl.Text = "Please enter an account number before calculating."
            Exit Sub
        Else
            AcctNum = dukeAcctNum_tb.Text
            dukeAcctNum_lbl.Text = AcctNum
        End If

        If meterNum_tb.Text = Nothing Or meterNum_tb.Text = "" Then
            dukeError_lbl.Text = "Please enter the meter number before calculating."
            Exit Sub
        End If

        If yesterday_tb.Text = Nothing Or yesterday_tb.Text = "" Then
            dukeError_lbl.Text = "Please enter reading amount for yesterday before calculating."
            Exit Sub
        Else
            Yesterday = yesterday_tb.Text
        End If

        If today_tb.Text = Nothing Or today_tb.Text = "" Then
            dukeError_lbl.Text = "Please enter reading amount for today before calculating."
            Exit Sub
        Else
            Today = today_tb.Text
        End If

        'Calculate energy used and assign to textbox
        EnergyUsed = Today - Yesterday
        dukeEnergy_tb.Text = EnergyUsed

        'Calculate business services
        Kilo = EnergyUsed * 0.04
        Fuel = EnergyUsed * 0.02

        TotalElectric = 3 + Kilo + Fuel

        TotalFinal = 1 + 1 + TotalElectric

        'Assign Variables to labels
        dukeKiloCalc_lbl.Text = FormatCurrency(Kilo)
        dukeFuelCalc_lbl.Text = FormatCurrency(Fuel)
        dukeTotalElectric_lbl.Text = FormatCurrency(TotalElectric)
        dukeTotalDue_lbl.Text = FormatCurrency(TotalFinal)
        dukeTotal_lbl.Text = FormatCurrency(TotalFinal)

        dukeKiloHrs_lbl.Text = FormatCurrency(Kilo)
        dukeFuel_lbl.Text = FormatCurrency(Fuel)


    End Sub

    Sub UpdateLogoAndTitle()
        Dim Logos = BusinessData.GetBusinessLogos(BusinessID)
        Dim ImagePath As String = Logos.ImagePath
        Dim BColor As String = Logos.BColor

        'Update image and title based on business ID
        Try
            BusLogo_img.ImageUrl = ImagePath
            headerText_h2.InnerText = Logos.BusinessName & " Manager System"
            Me.Title = Logos.BusinessName & " Manager System"
        Catch
            ditekError_lbl.Text = "Error in UpdateLogoAndTitle(). Could not find image path and/or bColor."
            salesError_lbl.Text = "Error in UpdateLogoAndTitle(). Could not find image path and/or bColor."
            nonSalesError_lbl.Text = "Error in UpdateLogoAndTitle(). Could not find image path and/or bColor."
            dukeError_lbl.Text = "Error in UpdateLogoAndTitle(). Could not find image path and/or bColor."
            Exit Sub
        End Try

    End Sub

    Sub ChangeBusiness()

        'Display divs for business ID
        Select Case BusinessID
            Case 1
                sales_div.Visible = True
                manager_system_div.Attributes("class") = "main_bucs"
            Case 2
                sales_div.Visible = True
                manager_system_div.Attributes("class") = "main_rays"
            Case 3
                sales_div.Visible = True
                manager_system_div.Attributes("class") = "main_cvs"
            Case 5
                sales_div.Visible = True
                manager_system_div.Attributes("class") = "main_kanes"
            Case 6
                sales_div.Visible = True
                manager_system_div.Attributes("class") = "main_bic"
            Case 7
                sales_div.Visible = True
                manager_system_div.Attributes("class") = "main_td"
            Case 8
                sales_div.Visible = True
                manager_system_div.Attributes("class") = "main_hsn"
            Case 9
                sales_div.Visible = True
                manager_system_div.Attributes("class") = "main_bbb"
            Case 10
                sales_div.Visible = True
                manager_system_div.Attributes("class") = "main_astro"
            Case 11
                ditek_div.Visible = True
                manager_system_div.Attributes("class") = "main_ditek"
                Ditek()
            Case 12
                nonsales_div.Visible = True
                manager_system_div.Attributes("class") = "main_boa"
            Case 13
                nonsales_div.Visible = True
                manager_system_div.Attributes("class") = "main_baycare"
            Case 14
                nonsales_div.Visible = True
                manager_system_div.Attributes("class") = "main_city"
            Case 16
                duke_div.Visible = True
                manager_system_div.Attributes("class") = "main_duke"
            Case 17
                sales_div.Visible = True
                manager_system_div.Attributes("class") = "main_mcd"
            Case 18
                nonsales_div.Visible = True
                manager_system_div.Attributes("class") = "main_mix"
            Case 19
                nonsales_div.Visible = True
                manager_system_div.Attributes("class") = "main_pcsw"
            Case 21
                nonsales_div.Visible = True
                manager_system_div.Attributes("class") = "main_knowbe4"
            Case 22
                nonsales_div.Visible = True
                manager_system_div.Attributes("class") = "main_times"
            Case 24
                nonsales_div.Visible = True
                manager_system_div.Attributes("class") = "main_united"
        End Select

    End Sub

    Sub DukeSave()
        Dim AcctNum As String = dukeAcctNum_tb.Text
        Dim MeterNum As String = meterNum_tb.Text
        Dim Yesterday As String = yesterday_tb.Text
        Dim Today As String = today_tb.Text
        Dim EnergyUsed As String = dukeEnergy_tb.Text
        Dim VisitDate As String = DateTime.Now.ToShortDateString()
        Dim BusinessName As String = dukeBusiness_ddl.SelectedValue
        Dim SQLStatement As String

        'Check if business is selected
        If dukeBusiness_ddl.SelectedIndex = 0 Then
            dukeError_lbl.Text = "Please select a business before saving the data."
            Exit Sub
        End If

        'Check dukeManager table in DB for the current visit date / visit ID
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "SELECT visitID, businessName
                                FROM dukeManager
                                WHERE visitID = '" & VisitID & "' AND businessName = '" & BusinessName & "'"
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                SQLStatement = "UPDATE dukeManager SET accountNum = '" & AcctNum & "', meterNum = '" & MeterNum & "', yesterday = '" & Yesterday & "', today = '" & Today & "', energyUsed = '" & EnergyUsed & "' WHERE visitID = '" & VisitID & "' AND businessName = '" & BusinessName & "'"
            Else
                SQLStatement = "INSERT INTO dukeManager (visitID, visitDate, businessName, accountNum, meterNum, yesterday, today, energyUsed) VALUES ('" & VisitID & "', '" & VisitDate & "', '" & BusinessName & "', '" & AcctNum & "', '" & MeterNum & "', '" & Yesterday & "', '" & Today & "', '" & EnergyUsed & "')"
            End If

            cmd.Dispose()
            con.Close()

        Catch
            dukeError_lbl.Text = "Error in DukeSave(). Cannot save data."
            Exit Sub
        End Try

        cmd.Dispose()
        con.Close()

        'Save all data from textboxes into the DB
        con.Open()
        cmd.Connection = con
        cmd.CommandText = SQLStatement
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        con.Close()

        'Confirm message
        dukeError_lbl.Text = "Data saved!"

    End Sub

    Sub DukeBusinessChange()
        'Change business header name
        dukeBottomBusiness_lbl.Text = dukeBusiness_ddl.SelectedValue

        'Clear out fields
        dukeAcctNum_tb.Text = ""
        meterNum_tb.Text = ""
        yesterday_tb.Text = ""
        today_tb.Text = ""
        dukeEnergy_tb.Text = ""
        dukeKiloCalc_lbl.Text = ""
        dukeKiloHrs_lbl.Text = ""
        dukeFuelCalc_lbl.Text = ""
        dukeTotalElectric_lbl.Text = ""
        dukeTotalDue_lbl.Text = ""
        dukeFuel_lbl.Text = ""
        dukeTotal_lbl.Text = ""

        'Load data from duke manager by business name and visit ID
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "SELECT accountNum, meterNum, yesterday, today, energyUsed
                                FROM dukeManager
                                WHERE visitID = '" & VisitID & "' AND businessName = '" & dukeBusiness_ddl.SelectedValue & "'"
            dr = cmd.ExecuteReader

            While dr.Read()
                dukeAcctNum_tb.Text = dr("accountNum").ToString
                meterNum_tb.Text = dr("meterNum").ToString
                yesterday_tb.Text = dr("yesterday").ToString
                today_tb.Text = dr("today").ToString
                dukeEnergy_tb.Text = dr("energyUsed").ToString
            End While

            cmd.Dispose()
            con.Close()
        Catch
            dukeError_lbl.Text = "Error in DukeSave(). Cannot save data."
            Exit Sub
        End Try

        cmd.Dispose()
        con.Close()
    End Sub

    Protected Sub ditekBusinessDDL_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ditekBusinessDDL_ddl.SelectedIndexChanged
        Ditek()
    End Sub

    Protected Sub dukeBusiness_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dukeBusiness_ddl.SelectedIndexChanged
        DukeBusinessChange()
    End Sub

    Protected Sub ditekPrint_btn_Click(sender As Object, e As EventArgs) Handles ditekPrint_btn.Click
        If ditekBusinessDDL_ddl.SelectedIndex <> 0 Then
            ditekError_lbl.Text = "Deliver to: " & ditekBusinessDDL_ddl.SelectedValue
        End If
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "Print", "Print();", True)
    End Sub

    Protected Sub dukeCalc_btn_Click(sender As Object, e As EventArgs) Handles dukeCalc_btn.Click
        Duke()
    End Sub

    Protected Sub dukePrint_btn_Click(sender As Object, e As EventArgs) Handles dukePrint_btn.Click
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "Print", "Print();", True)
    End Sub

    Protected Sub dukeSave_btn_Click(sender As Object, e As EventArgs) Handles dukeSave_btn.Click
        DukeSave()
    End Sub

End Class