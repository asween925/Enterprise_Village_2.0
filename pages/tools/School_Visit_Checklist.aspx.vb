Imports System.Data.SqlClient
Imports System.Globalization
Imports VB = Microsoft.VisualBasic
Public Class School_Visit_Checklist
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim DBConnection As New DatabaseConection
    Dim schoolID As String
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim Teachers As New Class_TeacherData
    Dim Students As New Class_StudentData
    Dim Schools As New Class_SchoolData
    Dim Visits As New Class_VisitData
    Dim SH As New Class_SchoolHeader
    Dim Commands As New Class_SQLCommands
    Dim VisitID As Integer = Visits.GetVisitID

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If logged out, redirects to log in page
        If Session("LoggedIn") <> "1" Then
            Response.Redirect("../../default.aspx")
        End If

        If Not (IsPostBack) Then

            'Assign current visit ID to hidden value
            If VisitID <> 0 Then
                currentVisitDate_hf.Value = VisitID
            End If

            'Populating school header
            headerSchoolName_lbl.Text = SH.GetSchoolHeader()

        End If
    End Sub

    Sub LoadData()
        Dim username As String = Session("username")
        Dim UserJob As String
        Dim visitDate As Date = visitDate_tb.Text
        Dim VIDofDate As Integer = Visits.GetVisitIDFromDate(visitDate)
        Dim schoolName As String = schoolName_ddl.SelectedValue
        Dim SchoolID As Integer = Schools.GetSchoolID(schoolName)
        Dim SVC = Schools.GetSVCData(VIDofDate, SchoolID)

        'Step 1 variables

        Dim LastEditedBy1 As String
        Dim schoolType As String
        Dim ContactTeacher As String
        Dim schoolStudentCount As String
        Dim AdminEmail As String
        Dim studentCountFormReceived As String

        'Step 2 variables

        Dim LastEditedBy2 As String
        Dim invoiceIssued As String
        Dim directorsSignature As String

        'Step 3 Variables

        Dim LastEditedBy3 As String
        Dim contractRecieved As String
        Dim invoiceNum As String
        Dim deliveryMethod As String = delivery_ddl.SelectedValue
        Dim notes As String

        'Step 4 variables

        Dim LastEditedBy4 As String
        Dim numOfKits As String = numOfKits_ddl.SelectedValue
        Dim kit1 As String
        Dim kit2 As String
        Dim kit3 As String
        Dim kit4 As String
        Dim kit5 As String
        Dim kit6 As String
        Dim kit7 As String
        Dim kit8 As String
        Dim kit9 As String
        Dim kit10 As String
        Dim workbooks As String

        'Step 5 variables

        Dim LastEditedBy5 As String
        Dim deliveryAccepted As String
        Dim position As String
        Dim dateAccepted As String

        'Make all divs visible

        step1_div.Visible = True
        step2_div.Visible = True
        step3_div.Visible = True
        step4_div.Visible = True
        step5_div.Visible = True

        'Clear out data

        schoolType_ddl.SelectedIndex = 0
        schoolName_lbl.Text = ""
        visitDate_lbl.Text = ""
        adminEmail_lbl.Text = ""
        studentCountTotal_lbl.Text = ""
        schoolStudentCount_tb.Text = ""
        contactTeacher_lbl.Text = ""
        studentCountFormReceived_tb.Text = ""
        invoice_chk.Checked = False
        director_chk.Checked = False
        contractRecieved_tb.Text = ""
        invoiceNum_tb.Text = ""
        delivery_ddl.SelectedIndex = 0
        notes_tb.Text = ""
        numOfKits_ddl.SelectedIndex = 0
        kit1_tb.Text = ""
        kit2_tb.Text = ""
        kit3_tb.Text = ""
        kit4_tb.Text = ""
        kit5_tb.Text = ""
        kit6_tb.Text = ""
        kit7_tb.Text = ""
        kit8_tb.Text = ""
        kit9_tb.Text = ""
        kit10_tb.Text = ""
        workbooks_tb.Text = ""
        deliveryAccepted_tb.Text = ""
        dateAccepted_tb.Text = ""
        lastEdited1_lbl.Text = ""
        lastEdited2_lbl.Text = ""
        lastEdited3_lbl.Text = ""
        lastEdited4_lbl.Text = ""
        lastEdited5_lbl.Text = ""
        error_lbl.Text = ""

        'Get school ID
        Try
            schoolID = Schools.GetSchoolID(schoolName)
        Catch
            error_lbl.Text = "Error in loaddata(). Cannot retrieve school ID."
            Exit Sub
        End Try

        'Get admin email (futureRequestsEmail)
        Try
            AdminEmail = Schools.LoadSchoolInfoFromSchool(schoolName, "futureRequestsEmail")
        Catch
            error_lbl.Text = "Error in loaddata(). Could not get admin email."
            Exit Sub
        End Try

        'Get contact teacher
        Try
            ContactTeacher = Teachers.GetContactTeacher(SchoolID)
            If ContactTeacher = Nothing Or ContactTeacher = "" Then
                ContactTeacher = "N/A"
            End If
        Catch
            error_lbl.Text = "Error in loaddata(). Could not retrieve contact teacher name."
            Exit Sub
        End Try

        'Get current user job
        Try
            UserJob = Commands.GetUserJob(username)
        Catch
            error_lbl.Text = "Error in loaddata(). Cannot check who is logged in."
            Exit Sub
        End Try

        'Assign variables 
        Try
            'Step 1
            LastEditedBy1 = SVC.LasteditedStep1
            schoolType = SVC.SchoolType
            schoolStudentCount = SVC.SchoolStudentCount
            studentCountFormReceived = SVC.StudentCountFormReceived

            'Step 2
            LastEditedBy2 = SVC.LastEditedStep2
            invoiceIssued = SVC.InvoiceIssued
            directorsSignature = SVC.DirectorSignature

            'Step 3
            LastEditedBy3 = SVC.LastEditedStep3
            contractRecieved = SVC.ContractReceivedDate
            invoiceNum = SVC.InvoiceNum
            deliveryMethod = SVC.DeliveryMethod
            notes = SVC.Notes

            'Step 4
            LastEditedBy4 = SVC.LastEditedStep4
            numOfKits = SVC.NumOfKits
            kit1 = SVC.Kit1
            kit2 = SVC.Kit2
            kit3 = SVC.Kit3
            kit4 = SVC.Kit4
            kit5 = SVC.Kit5
            kit6 = SVC.Kit6
            kit7 = SVC.Kit7
            kit8 = SVC.Kit8
            kit9 = SVC.Kit9
            kit10 = SVC.Kit10
            workbooks = SVC.Workbooks

            'Step 5
            LastEditedBy5 = SVC.LastEditedStep5
            deliveryAccepted = SVC.DeliveryAccepted
            position = SVC.Position
            dateAccepted = SVC.DateAccepted

        Catch
            error_lbl.Text = "Error in LoadData(). Cannot get SVC data to variables."
            Exit Sub
        End Try

        'Assign labels, textboxes, DDL values, etc


        '-----------STEP 1------------

        lastEdited1_lbl.Text = LastEditedBy1
        schoolName_lbl.Text = schoolName
        visitDate_lbl.Text = visitDate
        contactTeacher_lbl.Text = ContactTeacher
        adminEmail_lbl.Text = AdminEmail

        If schoolType = Nothing Then
            schoolType_ddl.SelectedIndex = 0
            schoolType_ddl.Items(0).Enabled = True      'If nothing has been entered yet for the school type, it means the teacher has not started the SVC for the selected school, meaning they have to manually select what the school type is before submitting.
        Else
            schoolType_ddl.SelectedValue = schoolType
            schoolType_ddl.Items(0).Enabled = False     'Disables selecting the first option (which is blank) on the school type DDL. This is so the teacher cannot select a blank value when updating the section
        End If

        If schoolStudentCount = Nothing Then
            schoolStudentCount_tb.Text = studentCountTotal_lbl.Text
        Else
            schoolStudentCount_tb.Text = schoolStudentCount
        End If

        If studentCountFormReceived = Nothing Then
            studentCountFormReceived_tb = Nothing
        Else
            studentCountFormReceived_tb.Text = DateTime.Parse(studentCountFormReceived).ToString("yyyy-MM-dd")
        End If

        '-----------STEP 2------------

        lastEdited2_lbl.Text = LastEditedBy2

        If invoiceIssued = Nothing Then
            invoice_chk.Checked = False
        Else
            invoice_chk.Checked = invoiceIssued
        End If

        If directorsSignature = Nothing Then
            director_chk.Checked = False
        Else
            director_chk.Checked = directorsSignature
        End If

        '-----------STEP 3------------

        lastEdited3_lbl.Text = LastEditedBy3 & " " & DateTime.Parse(contractRecieved).ToString("yyyy-MM-dd")
        invoiceNum_tb.Text = invoiceNum
        notes_tb.Text = notes

        If contractRecieved = Nothing Then
            contractRecieved_tb.Text = ""
        Else
            contractRecieved_tb.Text = DateTime.Parse(contractRecieved).ToString("yyyy-MM-dd")
        End If

        If deliveryMethod = Nothing Then
            delivery_ddl.SelectedIndex = 0
        Else
            delivery_ddl.SelectedValue = deliveryMethod
        End If

        '-----------STEP 4------------

        lastEdited4_lbl.Text = LastEditedBy4
        kit1_tb.Text = kit1
        kit2_tb.Text = kit2
        kit3_tb.Text = kit3
        kit4_tb.Text = kit4
        kit5_tb.Text = kit5
        kit6_tb.Text = kit6
        kit7_tb.Text = kit7
        kit8_tb.Text = kit8
        kit9_tb.Text = kit9
        kit10_tb.Text = kit10

        If numOfKits = Nothing Then
            numOfKits_ddl.SelectedIndex = 0
        Else
            numOfKits_ddl.SelectedValue = numOfKits
            KitTextboxes() 'Makes kit textboxes visible based on number of kits needed from the ddl
            numOfKits_ddl.SelectedIndex = numOfKits_ddl.Items.IndexOf(numOfKits_ddl.Items.FindByValue(numOfKits))
        End If

        If workbooks = Nothing Then
            workbooks_lbl.Text = schoolStudentCount_tb.Text 'Assigns the same number of students in the visit info, which is initially entered by a teacher during visit creation (this is not the actual student count that is calculated based on entered students)
        Else
            workbooks_lbl.Text = workbooks
        End If

        '-----------STEP 5------------

        lastEdited5_lbl.Text = LastEditedBy5
        deliveryAccepted_tb.Text = deliveryAccepted
        position_tb.Text = position

        If dateAccepted = Nothing Then
            dateAccepted_tb.Text = ""
        Else
            dateAccepted_tb.Text = DateTime.Parse(dateAccepted).ToString("yyyy-MM-dd")
        End If


        'Check who is logged in and disable/enable fields based on job of the user logged in

        'Check if user logged in is teacher: STEP 1
        If UserJob = "Teacher" Then

            'Disabled / Hidden for Teachers
            contractRecieved_tb.Enabled = False
            invoiceNum_tb.Enabled = False
            delivery_ddl.Enabled = False
            notes_tb.Enabled = False
            numOfKits_ddl.Enabled = False
            deliveryAccepted_tb.Enabled = False
            dateAccepted_tb.Enabled = False
            step2Submit_btn.Visible = False
            step3Submit_btn.Visible = False
            step4Submit_btn.Visible = False
            step5Submit_btn.Visible = False
            invoice_chk.Enabled = False
            director_chk.Enabled = False
            printTicket_btn.Visible = False

            'Enabled / Visible for Teachers
            schoolType_ddl.Enabled = True
            step1Submit_btn.Visible = True

            'Check if bookkeeper is logged in: STEP 2
        ElseIf UserJob = "Bookkeeper" Then

            'Disabled / Hidden for Bookkeeper
            schoolType_ddl.Enabled = False
            contractRecieved_tb.Enabled = False
            invoiceNum_tb.Enabled = False
            delivery_ddl.Enabled = False
            notes_tb.Enabled = False
            numOfKits_ddl.Enabled = False
            deliveryAccepted_tb.Enabled = False
            dateAccepted_tb.Enabled = False
            step1Submit_btn.Visible = False
            step3Submit_btn.Visible = False
            step4Submit_btn.Visible = False
            step5Submit_btn.Visible = False
            printTicket_btn.Visible = False

            'Enabled / Visible for Bookkeeper
            'Check if teacher selected school type and submitted
            If schoolType_ddl.SelectedIndex <> 0 Then
                step2Submit_btn.Visible = True
                invoice_chk.Enabled = True
                director_chk.Enabled = True
            End If


            'Check if user logged in is front office: STEP 3 + 5
        ElseIf UserJob = "Front Office" Or UserJob = "Bookkeeper" Then

            'Disabled / hidden for Front Office
            schoolType_ddl.Enabled = False
            numOfKits_ddl.Enabled = False
            step1Submit_btn.Visible = False
            step2Submit_btn.Visible = False
            step4Submit_btn.Visible = False
            invoice_chk.Enabled = False
            director_chk.Enabled = False
            printTicket_btn.Visible = True

            'Enabled / Visable for Front Office
            'Check if bookkeeper info is filled out
            If invoice_chk.Checked = True And director_chk.Checked = True Then
                step3Submit_btn.Visible = True
                contractRecieved_tb.Enabled = True
                invoiceNum_tb.Enabled = True
                delivery_ddl.Enabled = True
                notes_tb.Enabled = True
            Else
                step3Submit_btn.Visible = False
                contractRecieved_tb.Enabled = False
                invoiceNum_tb.Enabled = False
                delivery_ddl.Enabled = False
                notes_tb.Enabled = False
            End If

            'Check if TA info is filled out
            If numOfKits_ddl.SelectedIndex <> 0 Then
                deliveryAccepted_tb.Enabled = True
                dateAccepted_tb.Enabled = True
                step5Submit_btn.Visible = True
                step3Submit_btn.Visible = True
                contractRecieved_tb.Enabled = True
                invoiceNum_tb.Enabled = True
                delivery_ddl.Enabled = True
                notes_tb.Enabled = True
            Else
                deliveryAccepted_tb.Enabled = False
                dateAccepted_tb.Enabled = False
            End If

            'Check if user logged in is TA: STEP 4
        ElseIf UserJob = "TA" Then

            'Disabled / Hidden for TAs
            schoolType_ddl.Enabled = False
            contractRecieved_tb.Enabled = False
            invoiceNum_tb.Enabled = False
            delivery_ddl.Enabled = False
            notes_tb.Enabled = False
            deliveryAccepted_tb.Enabled = False
            dateAccepted_tb.Enabled = False
            step1Submit_btn.Visible = False
            step2Submit_btn.Visible = False
            step3Submit_btn.Visible = False
            step5Submit_btn.Visible = False
            invoice_chk.Enabled = False
            director_chk.Enabled = False

            'Enabled / Visible for TAs
            step4Submit_btn.Visible = True
            numOfKits_ddl.Enabled = True
            printTicket_btn.Visible = True

            'If steps 1, 2, or 3 is NOT completed
            If schoolType_ddl.SelectedIndex = 0 Or invoice_chk.Checked = False Or director_chk.Checked = False Or contractRecieved_tb.Text = Nothing Or invoiceNum_tb.Text = Nothing Or delivery_ddl.SelectedIndex = 0 Then
                step4Submit_btn.Visible = False
                numOfKits_ddl.Enabled = False
                printTicket_btn.Visible = False
            End If

            'Check if user logged in is Tech Tech
        ElseIf UserJob = "Technology Technician" Then

            'All sections are enabled for TT
            contractRecieved_tb.Enabled = True
            invoiceNum_tb.Enabled = True
            delivery_ddl.Enabled = True
            notes_tb.Enabled = True
            numOfKits_ddl.Enabled = True
            deliveryAccepted_tb.Enabled = True
            dateAccepted_tb.Enabled = True
            step2Submit_btn.Visible = True
            step3Submit_btn.Visible = True
            step4Submit_btn.Visible = True
            step5Submit_btn.Visible = True
            invoice_chk.Enabled = True
            director_chk.Enabled = True
            schoolType_ddl.Enabled = True
            step1Submit_btn.Visible = True
            printTicket_btn.Visible = True
        End If

        'Change button text from submit to update if data is loaded

        If schoolType_ddl.SelectedIndex = 0 Then
            step1Submit_btn.Text = "Submit"
            I0.Visible = False
        Else
            step1Submit_btn.Text = "Update"
            I0.Visible = True
        End If

        If invoice_chk.Checked = False And director_chk.Checked = False Then
            step2Submit_btn.Text = "Submit"
            I1.Visible = False
        Else
            step2Submit_btn.Text = "Update"
            I1.Visible = True
        End If

        If contractRecieved_tb.Text = "" And invoiceNum_tb.Text = "" And delivery_ddl.SelectedIndex = 0 Then
            step3Submit_btn.Text = "Submit"
            I2.Visible = False
        Else
            step3Submit_btn.Text = "Update"
            I2.Visible = True
        End If

        If numOfKits_ddl.SelectedIndex = 0 Then
            step4Submit_btn.Text = "Submit"
            I3.Visible = False
        Else
            step4Submit_btn.Text = "Update"
            I3.Visible = True
        End If

        If deliveryAccepted_tb.Text = "" And position_tb.Text = "" And dateAccepted_tb.Text = "" Then
            step5Submit_btn.Text = "Submit"
            I4.Visible = False
        Else
            step5Submit_btn.Text = "Update"
            I4.Visible = True
        End If

    End Sub

    Sub KitTextboxes()
        'Make kit textboxes invisible
        kit1_tb.Visible = False
        kit2_tb.Visible = False
        kit3_tb.Visible = False
        kit4_tb.Visible = False
        kit5_tb.Visible = False
        kit6_tb.Visible = False
        kit7_tb.Visible = False
        kit8_tb.Visible = False
        kit9_tb.Visible = False
        kit10_tb.Visible = False

        'Make textboxes visible
        Select Case numOfKits_ddl.SelectedValue
            Case 0
                kit1_tb.Visible = False
                kit2_tb.Visible = False
                kit3_tb.Visible = False
                kit4_tb.Visible = False
                kit5_tb.Visible = False
                kit6_tb.Visible = False
                kit7_tb.Visible = False
                kit8_tb.Visible = False
                kit9_tb.Visible = False
                kit10_tb.Visible = False
            Case 1
                kit1_tb.Visible = True
            Case 2
                kit1_tb.Visible = True
                kit2_tb.Visible = True
            Case 3
                kit1_tb.Visible = True
                kit2_tb.Visible = True
                kit3_tb.Visible = True
            Case 4
                kit1_tb.Visible = True
                kit2_tb.Visible = True
                kit3_tb.Visible = True
                kit4_tb.Visible = True
            Case 5
                kit1_tb.Visible = True
                kit2_tb.Visible = True
                kit3_tb.Visible = True
                kit4_tb.Visible = True
                kit5_tb.Visible = True
            Case 6
                kit1_tb.Visible = True
                kit2_tb.Visible = True
                kit3_tb.Visible = True
                kit4_tb.Visible = True
                kit5_tb.Visible = True
                kit6_tb.Visible = True
            Case 7
                kit1_tb.Visible = True
                kit2_tb.Visible = True
                kit3_tb.Visible = True
                kit4_tb.Visible = True
                kit5_tb.Visible = True
                kit6_tb.Visible = True
                kit7_tb.Visible = True
            Case 8
                kit1_tb.Visible = True
                kit2_tb.Visible = True
                kit3_tb.Visible = True
                kit4_tb.Visible = True
                kit5_tb.Visible = True
                kit6_tb.Visible = True
                kit7_tb.Visible = True
                kit8_tb.Visible = True
            Case 9
                kit1_tb.Visible = True
                kit2_tb.Visible = True
                kit3_tb.Visible = True
                kit4_tb.Visible = True
                kit5_tb.Visible = True
                kit6_tb.Visible = True
                kit7_tb.Visible = True
                kit8_tb.Visible = True
                kit9_tb.Visible = True
            Case 10
                kit1_tb.Visible = True
                kit2_tb.Visible = True
                kit3_tb.Visible = True
                kit4_tb.Visible = True
                kit5_tb.Visible = True
                kit6_tb.Visible = True
                kit7_tb.Visible = True
                kit8_tb.Visible = True
                kit9_tb.Visible = True
                kit10_tb.Visible = True
        End Select
    End Sub

    Sub VisitDateTextboxLoad()
        Dim VisitDate As String = visitDate_tb.Text

        If visitDate_tb.Text <> Nothing Then

            'Make step divs not visible
            step1_div.Visible = False
            step2_div.Visible = False
            step3_div.Visible = False
            step4_div.Visible = False
            step5_div.Visible = False

            'Make school DDL visible
            schoolDDL_div.Visible = True

            'Populate school name DDL
            Try
                Schools.LoadVisitingSchoolsDDL(VisitDate, schoolName_ddl)
            Catch
                error_lbl.Text = "Error in VisitDateTextboxLoad(). Could not populate schoolName DDL."
                Exit Sub
            End Try
        Else
            schoolDDL_div.Visible = False
        End If
    End Sub

    Sub Step1()
        Dim visitDate As String = visitDate_lbl.Text
        Dim visitID As Integer = Visits.GetVisitIDFromDate(visitDate)
        Dim schoolName As String = schoolName_ddl.SelectedValue
        Dim schoolID As String = Schools.GetSchoolID(schoolName)
        Dim schoolType As String
        Dim studentCountFormReceived As String
        Dim schoolStudentCount As String
        Dim studentCountTotal As String
        Dim step1SQL As String
        Dim username As String = Session("username")
        Dim LastEditedBy As String

        'Check if school type ddl is not blank, then start the insertion process
        If schoolType_ddl.SelectedIndex <> 0 Then

            'Assign variables
            schoolType = schoolType_ddl.SelectedValue
            studentCountFormReceived = studentCountFormReceived_tb.Text
            schoolStudentCount = schoolStudentCount_tb.Text
            studentCountTotal = studentCountTotal_lbl.Text

            'Assign last edited by string
            LastEditedBy = username & " on " & DateTime.Now.ToString("yyyy-MM-dd hh:mm")

            'Check if data was loaded in or not
            If schoolType_ddl.Items(0).Enabled = False Then
                step1SQL = "UPDATE schoolVisitChecklist SET schoolType='" & schoolType & "', studentCountFormReceived='" & studentCountFormReceived & "', schoolStudentCount='" & schoolStudentCount & "', workbooks='" & studentCountTotal & "', lastEditedStep1='" & LastEditedBy & "' WHERE visitID='" & visitID & "' AND schoolID='" & schoolID & "'"
            Else
                step1SQL = "INSERT INTO schoolVisitChecklist (schoolID, schoolType, schoolStudentCount, visitID, workbooks, lastEditedStep1) 
                                    VALUES ('" & schoolID & "', '" & schoolType & "', '" & schoolStudentCount & "', '" & visitID & "', '" & studentCountTotal & "', '" & LastEditedBy & "')"
            End If

            'Inserting into DB with school type selected
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.Connection = con
                cmd.CommandText = step1SQL
                cmd.ExecuteNonQuery()
                con.Close()

            Catch
                error_lbl.Text = "Step 1. Cannot insert or update data into DB."
                Exit Sub
            End Try

            'Open email and refresh
            error_lbl.Text = "Submission Successful! Opening email..."
            ScriptManager.RegisterStartupScript(Me.Page, Me.Page.[GetType](), "OpenEmail", "javascript:window.location.href='mailto:rushm@pcsb.org ?subject=School Visit Checklist: School Type Submitted&body=I have completed the submission of the school type of " & schoolName_lbl.Text & " for " & visitDate_lbl.Text & ". Time completed: " & DateTime.Now & " ';", True)


        Else
            error_lbl.Text = "Please select a school type from the drop down menu."
            Exit Sub
        End If
    End Sub

    Sub Step2()
        Dim visitDate As String = visitDate_tb.Text
        Dim visitID As Integer = Visits.GetVisitIDFromDate(visitDate)
        Dim SchoolID As Integer = Schools.GetSchoolID(schoolName_ddl.SelectedValue)
        Dim con As New SqlConnection
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim cmd As New SqlCommand
        Dim invoiceIssued As Boolean
        Dim directorSignature As Boolean
        Dim username As String = Session("username")
        Dim LastEditedBy As String

        'Check if invoice checkbox and director checkbox are selected
        If invoice_chk.Checked = True And director_chk.Checked = True Then
            invoiceIssued = 1
            directorSignature = 1

            'Assign last edited by string
            LastEditedBy = username & " on " & DateTime.Now.ToString("yyyy-MM-dd hh:mm")

            'Updating DB with school type selected
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.Connection = con
                cmd.CommandText = "UPDATE schoolVisitChecklist SET invoiceIssued=@invoiceIssued, directorSignature=@directorSignature, lastEditedStep2=@lastEditedStep2 WHERE visitID='" & visitID & "' AND schoolID='" & schoolID & "'"
                cmd.Parameters.Add("@invoiceIssued", SqlDbType.Bit).Value = invoiceIssued
                cmd.Parameters.Add("@directorSignature", SqlDbType.Bit).Value = directorSignature
                cmd.Parameters.Add("@lastEditedStep2", SqlDbType.VarChar).Value = LastEditedBy
                cmd.ExecuteNonQuery()
                con.Close()

            Catch
                step2Msg_lbl.Text = "Error in Step 2. Cannot update DB."
                Exit Sub
            End Try

            'Open email
            step2Msg_lbl.Text = ""
            error_lbl.Text = "Submission Successful! Opening email..."
            ScriptManager.RegisterStartupScript(Me.Page, Me.Page.[GetType](), "OpenEmail", "javascript:window.location.href='mailto:rebelom@pcsb.org ?subject=School Visit Checklist: Invoice Number and Signature Received&cc=fritzs@pcsb.org&body=I have gotten the invoice number and directors signature for " & schoolName_lbl.Text & " visiting on " & visitDate_lbl.Text & ". Time completed: " & DateTime.Now & " ';", True)

            'Refresh page
            Dim meta As New HtmlMeta()
            meta.HttpEquiv = "Refresh"
            meta.Content = "5;url=school_visit_checklist.aspx"
            Me.Page.Controls.Add(meta)

        Else
            step2Msg_lbl.Text = "Please check both boxes before submitting."
            Exit Sub
        End If
    End Sub

    Sub Step3()
        Dim visitDate As String = visitDate_tb.Text
        Dim visitID As Integer = Visits.GetVisitIDFromDate(visitDate)
        Dim SchoolID As Integer = Schools.GetSchoolID(schoolName_ddl.SelectedValue)
        Dim con As New SqlConnection
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim cmd As New SqlCommand
        Dim contractReceivedDate As String
        Dim invoiceNum As String
        Dim deliveryMethod As String = delivery_ddl.SelectedValue
        Dim notes As String
        Dim username As String = Session("username")
        Dim LastEditedBy As String

        If contractRecieved_tb.Text <> Nothing And invoiceNum_tb.Text <> Nothing And delivery_ddl.SelectedIndex <> 0 Then
            contractReceivedDate = contractRecieved_tb.Text
            invoiceNum = invoiceNum_tb.Text
            deliveryMethod = delivery_ddl.SelectedValue
            notes = notes_tb.Text

            'Assign last edited by string
            LastEditedBy = username & " on " & DateTime.Now.ToString("yyyy-MM-dd hh:mm")

            'Updating DB with school type selected
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.Connection = con
                cmd.CommandText = "UPDATE schoolVisitChecklist SET contractReceivedDate=@contractReceivedDate, invoiceNum=@invoiceNum, deliveryMethod=@deliveryMethod, notes=@notes, lastEditedStep3=@lastEditedStep3 WHERE visitID='" & visitID & "' AND schoolID='" & SchoolID & "'"

                cmd.Parameters.Add("@contractReceivedDate", SqlDbType.VarChar).Value = contractReceivedDate
                cmd.Parameters.Add("@invoiceNum", SqlDbType.Int).Value = invoiceNum
                cmd.Parameters.Add("@deliveryMethod", SqlDbType.VarChar).Value = deliveryMethod
                cmd.Parameters.Add("@notes", SqlDbType.VarChar).Value = notes
                cmd.Parameters.Add("@lastEditedStep3", SqlDbType.VarChar).Value = LastEditedBy
                cmd.ExecuteNonQuery()
                con.Close()

            Catch
                step3Msg_lbl.Text = "Error in Step 3. Cannot update DB."
                Exit Sub
            End Try

            'Open email
            step3Msg_lbl.Text = ""
            error_lbl.Text = "Submission Successful! Opening email..."
            ScriptManager.RegisterStartupScript(Me.Page, Me.Page.[GetType](), "OpenEmail", "javascript:window.location.href='mailto:duntonj@pcsb.org;mazurekb@pcsb.org ?subject=School Visit Checklist: Invoice Received&body=I have completed the submission of the invoice, delivery method, and date of contract received of " & schoolName_lbl.Text & " for " & visitDate_lbl.Text & ". Time completed: " & DateTime.Now & " ';", True)

            'Refresh page
            Dim meta As New HtmlMeta()
            meta.HttpEquiv = "Refresh"
            meta.Content = "5;url=school_visit_checklist.aspx"
            Me.Page.Controls.Add(meta)

        Else
            step3Msg_lbl.Text = "Please enter a contract received date, invoice number, and delivery method before submitting."
            Exit Sub
        End If
    End Sub

    Sub Step4()
        Dim visitDate As String = visitDate_tb.Text
        Dim visitID As Integer = Visits.GetVisitIDFromDate(visitDate)
        Dim schoolName As String = schoolName_ddl.SelectedValue
        Dim SchoolID As Integer = Schools.GetSchoolID(schoolName)
        Dim con As New SqlConnection
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim cmd As New SqlCommand
        Dim numOfKits As String
        Dim workbooks As String = workbooks_tb.Text
        Dim kitNumbersSQL As String
        Dim username As String = Session("username")
        Dim LastEditedBy As String

        If numOfKits_ddl.SelectedIndex <> 0 Then
            numOfKits = numOfKits_ddl.SelectedValue

            'Assign last edited by string
            LastEditedBy = username & " on " & DateTime.Now.ToString("yyyy-MM-dd hh:mm")

            'Check if the visible kit fields are empty
            If kit1_tb.Visible = True And kit1_tb.Text = Nothing Then
                step4Msg_lbl.Text = "Please enter the kit numbers for all visible fields."
                Exit Sub
            ElseIf kit2_tb.Visible = True And kit2_tb.Text = Nothing Then
                step4Msg_lbl.Text = "Please enter the kit numbers for all visible fields."
                Exit Sub
            ElseIf kit3_tb.Visible = True And kit3_tb.Text = Nothing Then
                step4Msg_lbl.Text = "Please enter the kit numbers for all visible fields."
                Exit Sub
            ElseIf kit4_tb.Visible = True And kit4_tb.Text = Nothing Then
                step4Msg_lbl.Text = "Please enter the kit numbers for all visible fields."
                Exit Sub
            ElseIf kit5_tb.Visible = True And kit5_tb.Text = Nothing Then
                step4Msg_lbl.Text = "Please enter the kit numbers for all visible fields."
                Exit Sub
            ElseIf kit6_tb.Visible = True And kit6_tb.Text = Nothing Then
                step4Msg_lbl.Text = "Please enter the kit numbers for all visible fields."
                Exit Sub
            ElseIf kit7_tb.Visible = True And kit7_tb.Text = Nothing Then
                step4Msg_lbl.Text = "Please enter the kit numbers for all visible fields."
                Exit Sub
            ElseIf kit8_tb.Visible = True And kit8_tb.Text = Nothing Then
                step4Msg_lbl.Text = "Please enter the kit numbers for all visible fields."
                Exit Sub
            ElseIf kit9_tb.Visible = True And kit9_tb.Text = Nothing Then
                step4Msg_lbl.Text = "Please enter the kit numbers for all visible fields."
                Exit Sub
            ElseIf kit10_tb.Visible = True And kit10_tb.Text = Nothing Then
                step4Msg_lbl.Text = "Please enter the kit numbers for all visible fields."
                Exit Sub
            End If

            'Check if workbooks have been added or removed
            If workbooks = Nothing Or workbooks = "" Then
                workbooks = schoolStudentCount_tb.Text
            End If

            'Updating number of kits to schoolVisitChecklist with school type selected
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.Connection = con
                cmd.CommandText = "UPDATE schoolVisitChecklist SET numberOfKits=@numberOfKits, lastEditedStep4=@lastEditedStep4 WHERE visitID='" & visitID & "' and schoolID='" & SchoolID & "'"

                cmd.Parameters.Add("@numberOfKits", SqlDbType.Int).Value = numOfKits
                cmd.Parameters.Add("@lastEditedStep4", SqlDbType.VarChar).Value = LastEditedBy
                cmd.ExecuteNonQuery()
                con.Close()

            Catch
                step4Msg_lbl.Text = "Error in Step4(). Cannot update number of kits."
                Exit Sub
            End Try

            'Updating schoolInfo with workbooks
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.Connection = con
                cmd.CommandText = "UPDATE schoolVisitChecklist SET workbooks=@workbooks, lastEditedStep4=@lastEditedStep4 WHERE visitID='" & visitID & "' AND schoolID='" & SchoolID & "'"

                cmd.Parameters.Add("@workbooks", SqlDbType.Int).Value = workbooks
                cmd.ExecuteNonQuery()
                con.Close()

            Catch
                step4Msg_lbl.Text = "Error in Step4(). Cannot update workbooks into DB."
                Exit Sub
            End Try

            'Get how many kits to enter into the DB
            Select Case numOfKits
                Case 0
                    kitNumbersSQL = "UPDATE schoolVisitChecklist SET kit1='" & kit1_tb.Text & "' WHERE visitID='" & visitID & "' AND schoolID='" & SchoolID & "'"
                Case 1
                    kitNumbersSQL = "UPDATE schoolVisitChecklist SET kit1='" & kit1_tb.Text & "' WHERE visitID='" & visitID & "' AND schoolID='" & SchoolID & "'"
                Case 2
                    kitNumbersSQL = "UPDATE schoolVisitChecklist SET kit1='" & kit1_tb.Text & "', kit2='" & kit2_tb.Text & "' WHERE visitID='" & visitID & "' AND schoolID='" & SchoolID & "'"
                Case 3
                    kitNumbersSQL = "UPDATE schoolVisitChecklist SET kit1='" & kit1_tb.Text & "', kit2='" & kit2_tb.Text & "', kit3='" & kit3_tb.Text & "' WHERE visitID='" & visitID & "' AND schoolID='" & SchoolID & "'"
                Case 4
                    kitNumbersSQL = "UPDATE schoolVisitChecklist SET kit1='" & kit1_tb.Text & "', kit2='" & kit2_tb.Text & "', kit3='" & kit3_tb.Text & "', kit4='" & kit4_tb.Text & "' WHERE visitID='" & visitID & "' AND schoolID='" & SchoolID & "'"
                Case 5
                    kitNumbersSQL = "UPDATE schoolVisitChecklist SET kit1='" & kit1_tb.Text & "', kit2='" & kit2_tb.Text & "', kit3='" & kit3_tb.Text & "', kit4='" & kit4_tb.Text & "', kit5='" & kit5_tb.Text & "' WHERE visitID='" & visitID & "' AND schoolID='" & SchoolID & "'"
                Case 6
                    kitNumbersSQL = "UPDATE schoolVisitChecklist SET kit1='" & kit1_tb.Text & "', kit2='" & kit2_tb.Text & "', kit3='" & kit3_tb.Text & "', kit4='" & kit4_tb.Text & "', kit5='" & kit5_tb.Text & "', kit6='" & kit6_tb.Text & "' WHERE visitID='" & visitID & "' AND schoolID='" & SchoolID & "'"
                Case 7
                    kitNumbersSQL = "UPDATE schoolVisitChecklist SET kit1='" & kit1_tb.Text & "', kit2='" & kit2_tb.Text & "', kit3='" & kit3_tb.Text & "', kit4='" & kit4_tb.Text & "', kit5='" & kit5_tb.Text & "', kit6='" & kit6_tb.Text & "', kit7='" & kit7_tb.Text & "' WHERE visitID='" & visitID & "' AND schoolID='" & SchoolID & "'"
                Case 8
                    kitNumbersSQL = "UPDATE schoolVisitChecklist SET kit1='" & kit1_tb.Text & "', kit2='" & kit2_tb.Text & "', kit3='" & kit3_tb.Text & "', kit4='" & kit4_tb.Text & "', kit5='" & kit5_tb.Text & "', kit6='" & kit6_tb.Text & "', kit7='" & kit7_tb.Text & "', kit8='" & kit8_tb.Text & "' WHERE visitID='" & visitID & "' AND schoolID='" & SchoolID & "'"
                Case 9
                    kitNumbersSQL = "UPDATE schoolVisitChecklist SET kit1='" & kit1_tb.Text & "', kit2='" & kit2_tb.Text & "', kit3='" & kit3_tb.Text & "', kit4='" & kit4_tb.Text & "', kit5='" & kit5_tb.Text & "', kit6='" & kit6_tb.Text & "', kit7='" & kit7_tb.Text & "', kit8='" & kit8_tb.Text & "', kit9='" & kit9_tb.Text & "' WHERE visitID='" & visitID & "' AND schoolID='" & SchoolID & "'"
                Case 10
                    kitNumbersSQL = "UPDATE schoolVisitChecklist SET kit1='" & kit1_tb.Text & "', kit2='" & kit2_tb.Text & "', kit3='" & kit3_tb.Text & "', kit4='" & kit4_tb.Text & "', kit5='" & kit5_tb.Text & "', kit6='" & kit6_tb.Text & "', kit7='" & kit7_tb.Text & "', kit8='" & kit8_tb.Text & "', kit9='" & kit9_tb.Text & "', kit10='" & kit10_tb.Text & "' WHERE visitID='" & visitID & "' AND schoolID='" & SchoolID & "'"
            End Select

            'Update kit numbers into kits table in DB
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.Connection = con
                cmd.CommandText = kitNumbersSQL
                cmd.ExecuteNonQuery()
                con.Close()
            Catch
                step4Msg_lbl.Text = "Error in Step 4. Cannot update kit numbers into DB."
                Exit Sub
            End Try

            'Open Email
            step3Msg_lbl.Text = ""
            error_lbl.Text = "Submission Successful! Opening email ..."
            ScriptManager.RegisterStartupScript(Me.Page, Me.Page.[GetType](), "OpenEmail", "javascript:window.location.href='mailto:fritzs@pcsb.org ?subject=School Visit Checklist: Kit Numbers Submitted&cc=rebelom@pcsb.org&body=I have completed the submission of the amount of kits being sent out and the number each kit for " & schoolName_lbl.Text & " on " & visitDate_lbl.Text & ". Time completed: " & DateTime.Now & " ';", True)

            'Refresh page
            Dim meta As New HtmlMeta()
            meta.HttpEquiv = "Refresh"
            meta.Content = "5;url=school_visit_checklist.aspx"
            Me.Page.Controls.Add(meta)
        Else
            step4Msg_lbl.Text = "Please select a kit amount and enter in the kit numbers."
            Exit Sub
        End If
    End Sub

    Sub Step5()
        Dim visitDate As String = visitDate_tb.Text
        Dim visitID As Integer = Visits.GetVisitIDFromDate(visitDate)
        Dim schoolID As Integer = Schools.GetSchoolID(schoolName_ddl.SelectedValue)
        Dim con As New SqlConnection
        Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
        Dim cmd As New SqlCommand
        Dim deliveryAccepted As String
        Dim dateAccepted As Date
        Dim position As String
        Dim username As String = Session("username")
        Dim LastEditedBy As String

        If deliveryAccepted_tb.Text <> Nothing And position_tb.Text <> Nothing And dateAccepted_tb.Text <> Nothing Then
            deliveryAccepted = deliveryAccepted_tb.Text
            dateAccepted = dateAccepted_tb.Text
            position = position_tb.Text

            'Assign last edited by string
            LastEditedBy = username & " on " & DateTime.Now.ToString("yyyy-MM-dd hh:mm")

            'Updating DB with school type selected
            Try
                con.ConnectionString = connection_string
                con.Open()
                cmd.Connection = con
                cmd.CommandText = "UPDATE schoolVisitChecklist SET deliveryAccepted=@deliveryAccepted, position=@position, dateAccepted=@dateAccepted, lastEditedStep5=@lastEditedStep5 WHERE visitID='" & visitID & "' AND schoolID='" & schoolID & "'"

                cmd.Parameters.Add("@deliveryAccepted", SqlDbType.VarChar).Value = deliveryAccepted
                cmd.Parameters.Add("@position", SqlDbType.VarChar).Value = position
                cmd.Parameters.Add("@dateAccepted", SqlDbType.Date).Value = dateAccepted
                cmd.Parameters.Add("@lastEditedStep5", SqlDbType.VarChar).Value = LastEditedBy

                cmd.ExecuteNonQuery()
                con.Close()


            Catch
                step5Msg_lbl.Text = "Error in Step 5. Cannot update DB."
                Exit Sub
            End Try

            'Open email
            step5Msg_lbl.Text = ""
            error_lbl.Text = "Submission Successful! Opening email ..."
            ScriptManager.RegisterStartupScript(Me.Page, Me.Page.[GetType](), "OpenEmail", "javascript:window.location.href='mailto:rushm@pcsb.org ?subject=School Visit Checklist: Delivery Date and Date Accepted Submitted&body=I have completed the submission of the delivery accepted by date and the date accepted for " & schoolName_lbl.Text & " on " & visitDate_lbl.Text & ". Time completed: " & DateTime.Now & " ';", True)

            'Refresh page
            Dim meta As New HtmlMeta()
            meta.HttpEquiv = "Refresh"
            meta.Content = "5;url=school_visit_checklist.aspx"
            Me.Page.Controls.Add(meta)
        Else
            step5Msg_lbl.Text = "      Please enter a date who the delivery was accepted by, a position, and a date accepted."
            Exit Sub
        End If
    End Sub

    Sub PrintTicket()
        'Make lines invisible
        step2_div.Visible = False
        adminEmail_p.Visible = False
        adminEmail_lbl.Visible = False
        schoolType_p.Visible = False
        schoolType_ddl.Visible = False
        contractReceived_p.Visible = False
        contractRecieved_tb.Visible = False
        invoiceNum_p.Visible = False
        invoiceNum_tb.Visible = False
        step3Msg_lbl.Visible = False
        notes_p.Visible = False
        notes_tb.Visible = False
        updateWorkbooks_p.Visible = False
        workbooks_tb.Visible = False
        deliveryAccepted_tb.Visible = False
        position_tb.Visible = False
        dateAccepted_tb.Visible = False

        'Make Lines visible
        deliveryAcceptedLine_lbl.Visible = True
        positionLine_lbl.Visible = True
        dateAcceptedLine_lbl.Visible = True

        'Make logos visible
        EVLogo_img.Visible = True
        StavrosLogo_img.Visible = True

        'Retitle header
        h2_h2.InnerText = "Delivery Ticket"

        Page.ClientScript.RegisterStartupScript(Me.GetType(), "print", "PrintBadges();", True)
    End Sub



    Protected Sub schoolName_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles schoolName_ddl.SelectedIndexChanged
        If schoolName_ddl.SelectedIndex <> 0 Then
            LoadData()
        Else
            error_lbl.Text = ""
            step1_div.Visible = False
            step2_div.Visible = False
            step3_div.Visible = False
            step4_div.Visible = False
            step5_div.Visible = False
        End If

    End Sub

    Protected Sub numOfKits_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles numOfKits_ddl.SelectedIndexChanged
        KitTextboxes()
    End Sub



    Protected Sub visitDate_tb_TextChanged(sender As Object, e As EventArgs) Handles visitDate_tb.TextChanged
        VisitDateTextboxLoad()
    End Sub



    Protected Sub step1Submit_btn_Click(sender As Object, e As EventArgs) Handles step1Submit_btn.Click
        Step1()
    End Sub

    Protected Sub step2Submit_btn_Click(sender As Object, e As EventArgs) Handles step2Submit_btn.Click
        Step2()
    End Sub

    Protected Sub step3Submit_btn_Click(sender As Object, e As EventArgs) Handles step3Submit_btn.Click
        Step3()
    End Sub

    Protected Sub step4Submit_btn_Click(sender As Object, e As EventArgs) Handles step4Submit_btn.Click
        Step4()
    End Sub

    Protected Sub step5Submit_btn_Click(sender As Object, e As EventArgs) Handles step5Submit_btn.Click
        Step5()
    End Sub

    Protected Sub print_btn_Click(sender As Object, e As EventArgs) Handles print_btn.Click

        'Make lines invisible
        updateWorkbooks_p.Visible = False
        workbooks_tb.Visible = False

        'Make logos visible
        EVLogo_img.Visible = True
        StavrosLogo_img.Visible = True

        Page.ClientScript.RegisterStartupScript(Me.GetType(), "print", "PrintBadges();", True)
    End Sub

    Protected Sub printTicket_btn_Click(sender As Object, e As EventArgs) Handles printTicket_btn.Click
        PrintTicket()
    End Sub

    Protected Sub printTicket2_btn_Click(sender As Object, e As EventArgs) Handles printTicket2_btn.Click
        PrintTicket()
    End Sub

    Protected Sub refresh_btn_Click(sender As Object, e As EventArgs) Handles refresh_btn.Click
        Response.Redirect("school_visit_checklist.aspx")
    End Sub

    Protected Sub refresh2_btn_Click(sender As Object, e As EventArgs) Handles refresh2_btn.Click
        Response.Redirect("school_visit_checklist.aspx")
    End Sub

End Class