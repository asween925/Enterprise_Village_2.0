Imports System.Data.SqlClient
Public Class Help_Page
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim DBConnection As New DatabaseConection
    Dim dr As SqlDataReader
    Dim VisitID As New Class_VisitData
    Dim Visit As Integer = VisitID.GetVisitID
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("LoggedIn") <> "1" Then
            Response.Redirect(".\default.aspx")
        End If

        If Not (IsPostBack) Then

            If Visit <> 0 Then
                visitdate_hf.Value = Visit
            End If

            'Populating school header
            Dim header As New Class_SchoolHeader
            headerSchoolName_lbl.Text = header.GetSchoolHeader()

        End If
    End Sub

    Sub HideAllDivs()
        magicComp_div.Visible = False
        createVisit_div.Visible = False
        createSchool_div.Visible = False
        createTeacher_div.Visible = False
        editVisit_div.Visible = False
        editOpen_div.Visible = False
        editSchool_div.Visible = False
        editTeacher_div.Visible = False
        isi_div.Visible = False
        ems_div.Visible = False
        editProfits_div.Visible = False
        editSales_div.Visible = False
        townHall_div.Visible = False
        svc_div.Visible = False
        schoolNotes_div.Visible = False
        kit_div.Visible = False
        srf_div.Visible = False
        bizSales_div.Visible = False
        studentSpendingReport_div.Visible = False
        amountSpent_div.Visible = False
        negativeBalance_div.Visible = False
        profitReport_div.Visible = False
        dupNums_div.Visible = False
        studentReport_div.Visible = False
        schoolReport_div.Visible = False
        visitReport_div.Visible = False
        teacherReport_div.Visible = False
        teacherReport_div.Visible = False
        liason_div.Visible = False
        teacherLetter_div.Visible = False
        dailyForms_div.Visible = False
        lunchForms_div.Visible = False
        bizDir_div.Visible = False
        chkDir_div.Visible = False
        payChecks_div.Visible = False
        operChecks_div.Visible = False
        onBank_div.Visible = False
        sales_div.Visible = False
        teller_div.Visible = False
        atm_div.Visible = False
        badgeCre_div.Visible = False
        badgeHis_div.Visible = False
        badgePri_div.Visible = False
        teacherHome_div.Visible = False
        invHome_div.Visible = False
        invCreate_div.Visible = False
        invEdit_div.Visible = False
        invAdd_div.Visible = False
        invLow_div.Visible = False
        invView_div.Visible = False
        dupStu_div.Visible = False
        moveArt_div.Visible = False
        parentLetter_div.Visible = False
        staffList_div.Visible = False
        breakSch_div.Visible = False
        baycare_div.Visible = False
        voting_div.Visible = False
        changelog_div.Visible = False
        volunteerDB_div.Visible = False
        requested_div.Visible = False
        busTrans_div.Visible = False
        schoolSch_div.Visible = False
        manager_div.Visible = False
        closedBizChecks_div.Visible = False
    End Sub

    Protected Sub magicComp_btn_Click(sender As Object, e As EventArgs) Handles magicComp_btn.Click
        HideAllDivs()
        magicComp_div.Visible = True
    End Sub

    Protected Sub createVisit_Click(sender As Object, e As EventArgs) Handles createVisit_btn.Click
        HideAllDivs()
        createVisit_div.Visible = True
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        HideAllDivs()
        createSchool_div.Visible = True

    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        HideAllDivs()
        createTeacher_div.Visible = True

    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        HideAllDivs()
        editVisit_div.Visible = True

    End Sub

    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        HideAllDivs()
        editOpen_div.Visible = True

    End Sub

    Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        HideAllDivs()
        editSchool_div.Visible = True

    End Sub

    Protected Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        HideAllDivs()
        editTeacher_div.Visible = True

    End Sub

    Protected Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        HideAllDivs()
        isi_div.Visible = True

    End Sub

    Protected Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        HideAllDivs()
        ems_div.Visible = True

    End Sub

    Protected Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        HideAllDivs()
        editProfits_div.Visible = True

    End Sub

    Protected Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        HideAllDivs()
        editSales_div.Visible = True

    End Sub

    Protected Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        HideAllDivs()
        townHall_div.Visible = True

    End Sub

    Protected Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        HideAllDivs()
        svc_div.Visible = True

    End Sub

    Protected Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        HideAllDivs()
        schoolNotes_div.Visible = True

    End Sub

    Protected Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        HideAllDivs()
        kit_div.Visible = True

    End Sub

    Protected Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        HideAllDivs()
        srf_div.Visible = True

    End Sub

    Protected Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        HideAllDivs()
        bizSales_div.Visible = True

    End Sub

    Protected Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        HideAllDivs()
        studentSpendingReport_div.Visible = True

    End Sub

    Protected Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        HideAllDivs()
        amountSpent_div.Visible = True

    End Sub

    Protected Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        HideAllDivs()
        negativeBalance_div.Visible = True

    End Sub

    Protected Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        HideAllDivs()
        profitReport_div.Visible = True

    End Sub

    Protected Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        HideAllDivs()
        dupNums_div.Visible = True

    End Sub

    Protected Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        HideAllDivs()
        studentReport_div.Visible = True

    End Sub

    Protected Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        HideAllDivs()
        schoolReport_div.Visible = True

    End Sub

    Protected Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        HideAllDivs()
        visitReport_div.Visible = True

    End Sub

    Protected Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        HideAllDivs()
        teacherReport_div.Visible = True

    End Sub

    Protected Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        HideAllDivs()
        liason_div.Visible = True
    End Sub

    Protected Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        HideAllDivs()
        teacherLetter_div.Visible = True

    End Sub

    Protected Sub Button28_Click(sender As Object, e As EventArgs) Handles Button28.Click
        HideAllDivs()
        dailyForms_div.Visible = True

    End Sub

    Protected Sub Button29_Click(sender As Object, e As EventArgs) Handles Button29.Click
        HideAllDivs()
        lunchForms_div.Visible = True

    End Sub

    Protected Sub bizDir_btn_Click(sender As Object, e As EventArgs) Handles bizDir_btn.Click
        HideAllDivs()
        bizDir_div.Visible = True
    End Sub

    Protected Sub chkDir_btn_Click(sender As Object, e As EventArgs) Handles chkDir_btn.Click
        HideAllDivs()
        chkDir_div.Visible = True
    End Sub

    Protected Sub Button30_Click(sender As Object, e As EventArgs) Handles Button30.Click
        HideAllDivs()
        payChecks_div.Visible = True

    End Sub

    Protected Sub Button31_Click(sender As Object, e As EventArgs) Handles Button31.Click
        HideAllDivs()
        operChecks_div.Visible = True
    End Sub

    Protected Sub Button32_Click(sender As Object, e As EventArgs) Handles Button32.Click
        HideAllDivs()
        onBank_div.Visible = True
    End Sub

    Protected Sub Button33_Click(sender As Object, e As EventArgs) Handles Button33.Click
        HideAllDivs()
        sales_div.Visible = True

    End Sub

    Protected Sub Button34_Click(sender As Object, e As EventArgs) Handles Button34.Click
        HideAllDivs()
        teller_div.Visible = True

    End Sub

    Protected Sub Button35_Click(sender As Object, e As EventArgs) Handles Button35.Click
        HideAllDivs()
        atm_div.Visible = True

    End Sub

    Protected Sub Button36_Click(sender As Object, e As EventArgs) Handles Button36.Click
        HideAllDivs()
        badgeCre_div.Visible = True

    End Sub

    Protected Sub Button37_Click(sender As Object, e As EventArgs) Handles Button37.Click
        HideAllDivs()
        badgeHis_div.Visible = True

    End Sub

    Protected Sub Button38_Click(sender As Object, e As EventArgs) Handles Button38.Click
        HideAllDivs()
        badgePri_div.Visible = True
    End Sub

    Protected Sub Button39_Click(sender As Object, e As EventArgs) Handles Button39.Click
        HideAllDivs()
        teacherHome_div.Visible = True
    End Sub

    Protected Sub Button40_Click(sender As Object, e As EventArgs) Handles Button40.Click
        HideAllDivs()
        invHome_div.Visible = True

    End Sub

    Protected Sub Button41_Click(sender As Object, e As EventArgs) Handles Button41.Click
        HideAllDivs()
        invCreate_div.Visible = True

    End Sub

    Protected Sub Button42_Click(sender As Object, e As EventArgs) Handles Button42.Click
        HideAllDivs()
        invEdit_div.Visible = True

    End Sub

    Protected Sub Button43_Click(sender As Object, e As EventArgs) Handles Button43.Click
        HideAllDivs()
        invAdd_div.Visible = True

    End Sub

    Protected Sub Button44_Click(sender As Object, e As EventArgs) Handles Button44.Click
        HideAllDivs()
        invLow_div.Visible = True
    End Sub

    Protected Sub Button45_Click(sender As Object, e As EventArgs) Handles Button45.Click
        HideAllDivs()
        invView_div.Visible = True
    End Sub

    Protected Sub Button46_Click(sender As Object, e As EventArgs) Handles Button46.Click
        HideAllDivs()
        dupStu_div.Visible = True
    End Sub

    Protected Sub Button47_Click(sender As Object, e As EventArgs) Handles Button47.Click
        HideAllDivs()
        moveArt_div.Visible = True
    End Sub

    Protected Sub Button48_Click(sender As Object, e As EventArgs) Handles Button48.Click
        HideAllDivs()
        parentLetter_div.Visible = True
    End Sub

    Protected Sub Button49_Click(sender As Object, e As EventArgs) Handles Button49.Click
        HideAllDivs()
        staffList_div.Visible = True
    End Sub

    Protected Sub Button50_Click(sender As Object, e As EventArgs) Handles Button50.Click
        HideAllDivs()
        breakSch_div.Visible = True
    End Sub

    Protected Sub Button51_Click(sender As Object, e As EventArgs) Handles Button51.Click
        HideAllDivs()
        baycare_div.Visible = True
    End Sub

    Protected Sub Button52_Click(sender As Object, e As EventArgs) Handles Button52.Click
        HideAllDivs()
        voting_div.Visible = True
    End Sub

    Protected Sub Button53_Click(sender As Object, e As EventArgs) Handles Button53.Click
        HideAllDivs()
        changelog_div.Visible = True
    End Sub

    Protected Sub Button54_Click(sender As Object, e As EventArgs) Handles Button54.Click
        HideAllDivs()
        volunteerDB_div.Visible = True
    End Sub

    Protected Sub Button55_Click(sender As Object, e As EventArgs) Handles Button55.Click
        HideAllDivs()
        requested_div.Visible = True
    End Sub

    Protected Sub Button56_Click(sender As Object, e As EventArgs) Handles Button56.Click
        HideAllDivs()
        busTrans_div.Visible = True
    End Sub

    Protected Sub Button57_Click(sender As Object, e As EventArgs) Handles Button57.Click
        HideAllDivs()
        schoolSch_div.Visible = True
    End Sub

    Protected Sub Button58_Click(sender As Object, e As EventArgs) Handles Button58.Click
        HideAllDivs()
        manager_div.Visible = True
    End Sub

    Protected Sub Button59_Click(sender As Object, e As EventArgs) Handles Button59.Click
        HideAllDivs()
        closedBizChecks_div.Visible = True
    End Sub

End Class