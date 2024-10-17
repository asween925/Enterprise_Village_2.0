Imports System.Data.SqlClient

Public Class Voting_System
    Inherits System.Web.UI.Page
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim DBConnection As New DatabaseConection
    Dim dr As SqlDataReader
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
    Dim StudentData As New Class_StudentData
    Dim VisitData As New Class_VisitData
    Dim VisitID As Integer = VisitData.GetVisitID
    Dim AccountNumber As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Check if visit date has been created
        If Not (IsPostBack) Then
            If VisitID <> 0 Then
                visitdate_hf.Value = VisitID
            End If
        End If

    End Sub

    Sub ShowQuestions()
        Dim StudentName As String

        'Check if textbox is empty
        If acctNum_tb.Text = Nothing Or acctNum_tb.Text = "" Then
            error_lbl.Text = "No account number entered. Please type in an account number and click 'Enter'."
            Exit Sub
        End If

        'Check if account number is valid
        If acctNum_tb.Text < 1 Or acctNum_tb.Text > 240 Then
            error_lbl.Text = "Please enter a number between 1 and 240."
            Exit Sub
        End If

        'Check if number has a name assigned to it
        Dim Student = StudentData.StudentLookup(VisitID, acctNum_tb.Text)
        Dim FirstName = Student.FirstName
        Dim LastName = Student.LastName

        Try
            If FirstName = Nothing Or LastName = Nothing Then
                error_lbl.Text = "There is no name associated with that account number. Please enter a different number."
                Exit Sub
            End If
        Catch
            error_lbl.Text = "Error in checking employeeName. Please inform a staff member!"
            Exit Sub
        End Try

        'Check if entered number is already saved ??


        'Assign account number
        AccountNumber = acctNum_tb.Text

        'Get employee name from account number
        StudentName = FirstName & " " & LastName

        'Assign labels
        employeeName_lbl.Text = StudentName
        acctNum_lbl.Text = AccountNumber

        'Reveal questions screen
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "Voting_System", "Voting_System();", True)

    End Sub

    Sub SubmitVoting()
        Dim SQLInsert As String
        Dim SQLUpdate As String
        Dim SQLStatement As String

        'Script to make sure the voting page stays on screen instead of resetting to the main input screen
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "Voting_System", "Voting_System();", True)

        'Check if all questions are answered
        'If q1a1_rdo.Checked = False And q1a2_rdo.Checked = False And q1a3_rdo.Checked = False And q1a4_rdo.Checked = False Then
        If q1a1_rdo.Checked = False And q1a2_rdo.Checked = False And q1a3_rdo.Checked = False And q1a4_rdo.Checked = False Then
            questionsError_lbl.Text = "Please answer question #1 before casting your vote."
            Exit Sub
        End If

        'If q2a1_rdo.Checked = False And q2a2_rdo.Checked = False And q2a3_rdo.Checked = False And q2a4_rdo.Checked = False Then
        If q2a1_rdo.Checked = False And q2a2_rdo.Checked = False And q2a3_rdo.Checked = False And q2a4_rdo.Checked = False Then
            questionsError_lbl.Text = "Please answer question #2 before casting your vote."
            Exit Sub
        End If

        If q3a1_rdo.Checked = False And q3a2_rdo.Checked = False Then
            questionsError_lbl.Text = "Please answer question #3 before casting your vote."
            Exit Sub
        End If

        'If q4a1_rdo.Checked = False And q4a2_rdo.Checked = False And q4a3_rdo.Checked = False And q4a4_rdo.Checked = False Then
        If q4a1_rdo.Checked = False And q4a2_rdo.Checked = False Then
            questionsError_lbl.Text = "Please answer question #4 before casting your vote."
            Exit Sub
        End If

        'If q5a1_rdo.Checked = False And q5a2_rdo.Checked = False And q5a3_rdo.Checked = False And q5a4_rdo.Checked = False Then
        If q5a1_rdo.Checked = False And q5a2_rdo.Checked = False And q5a3_rdo.Checked = False Then
            questionsError_lbl.Text = "Please answer question #5 before casting your vote."
            Exit Sub
        End If

        If q6a1_rdo.Checked = False And q6a2_rdo.Checked = False Then
            questionsError_lbl.Text = "Please answer question #6 before casting your vote."
            Exit Sub
        End If

        'Assign strings
        'SQLInsert = "INSERT INTO voting (visitID, visitDate, q1a1, q1a2, q1a3, q1a4, q2a1, q2a2, q2a3, q2a4, q3a1, q3a2, q3a3, q3a4, q4a1, q4a2, q4a3, q4a4, q5a1, q5a2, q5a3, q5a4) VALUES ('" & VisitID & "', '" & Date.Today.ToShortDateString & "', '" & CountVotes.Q1A1 & "', '" & CountVotes.Q1A2 & "', '" & CountVotes.Q1A3 & "', '" & CountVotes.Q1A4 & "', '" & CountVotes.Q2A1 & "', '" & CountVotes.Q2A2 & "', '" & CountVotes.Q2A3 & "', '" & CountVotes.Q2A4 & "', '" & CountVotes.Q3A1 & "', '" & CountVotes.Q3A2 & "', '" & CountVotes.Q3A3 & "', '" & CountVotes.Q3A4 & "', '" & CountVotes.Q4A1 & "', '" & CountVotes.Q4A2 & "', '" & CountVotes.Q4A3 & "', '" & CountVotes.Q4A4 & "', '" & CountVotes.Q5A1 & "', '" & CountVotes.Q5A2 & "', '" & CountVotes.Q5A3 & "', '" & CountVotes.Q5A4 & "')"
        SQLInsert = "INSERT INTO voting (visitID, visitDate, q1a1, q1a2, q1a3, q1a4, q2a1, q2a2, q2a3, q2a4, q3a1, q3a2, q4a1, q4a2, q5a1, q5a2, q5a3, q6a1, q6a2) VALUES ('" & VisitID & "', '" & Date.Today.ToShortDateString & "', '" & CountVotes.Q1A1 & "', '" & CountVotes.Q1A2 & "', '" & CountVotes.Q1A3 & "', '" & CountVotes.Q1A4 & "','" & CountVotes.Q2A1 & "', '" & CountVotes.Q2A2 & "', '" & CountVotes.Q2A3 & "', '" & CountVotes.Q2A4 & "', '" & CountVotes.Q3A1 & "', '" & CountVotes.Q3A2 & "', '" & CountVotes.Q4A1 & "','" & CountVotes.Q4A2 & "', '" & CountVotes.Q5A1 & "', '" & CountVotes.Q5A2 & "', '" & CountVotes.Q5A3 & "', '" & CountVotes.Q6A1 & "', '" & CountVotes.Q6A2 & "')"
        'SQLUpdate = "UPDATE voting SET q1a1=q1a1+'" & CountVotes.Q1A1 & "', q1a2=q1a2+'" & CountVotes.Q1A2 & "', q1a3=q1a3+'" & CountVotes.Q1A3 & "', q1a4=q1a4+'" & CountVotes.Q1A4 & "', q2a1=q2a1+'" & CountVotes.Q2A1 & "', q2a2=q2a2+'" & CountVotes.Q2A2 & "', q2a3=q2a3+'" & CountVotes.Q2A3 & "', q2a4=q2a4+'" & CountVotes.Q2A4 & "', q3a1=q3a1+'" & CountVotes.Q3A1 & "', q3a2=q3a2+'" & CountVotes.Q3A2 & "', q3a3=q3a3+'" & CountVotes.Q3A3 & "', q3a4=q3a4+'" & CountVotes.Q3A4 & "', q4a1=q4a1+'" & CountVotes.Q4A1 & "', q4a2=q4a2+'" & CountVotes.Q4A2 & "', q4a3=q4a3+'" & CountVotes.Q4A3 & "', q4a4=q4a4+'" & CountVotes.Q4A4 & "', q5a1=q5a1+'" & CountVotes.Q5A1 & "', q5a2=q5a2+'" & CountVotes.Q5A2 & "', q5a3=q5a3+'" & CountVotes.Q5A3 & "', q5a4=q5a4+'" & CountVotes.Q5A4 & "' WHERE visitID = '" & VisitID & "'"
        SQLUpdate = "UPDATE voting SET q1a1=q1a1+'" & CountVotes.Q1A1 & "', q1a2=q1a2+'" & CountVotes.Q1A2 & "', q1a3=q1a3+'" & CountVotes.Q1A3 & "', q1a4=q1a4+'" & CountVotes.Q1A4 & "', q2a1=q2a1+'" & CountVotes.Q2A1 & "',q2a2=q2a2+'" & CountVotes.Q2A2 & "', q2a3=q2a3+'" & CountVotes.Q2A3 & "', q2a4=q2a4+'" & CountVotes.Q2A4 & "', q3a1=q3a1+'" & CountVotes.Q3A1 & "', q3a2=q3a2+'" & CountVotes.Q3A2 & "', q4a1=q4a1+'" & CountVotes.Q4A1 & "', q4a2=q4a2+'" & CountVotes.Q4A2 & "', q5a1=q5a1+'" & CountVotes.Q5A1 & "', q5a2=q5a2+'" & CountVotes.Q5A2 & "', q5a3=q5a3+'" & CountVotes.Q5A3 & "', q6a1=q6a1+'" & CountVotes.Q6A1 & "', q6a2=q6a2+'" & CountVotes.Q6A2 & "' WHERE visitID = '" & VisitID & "'"

        'If not yet created, submit answers into DB
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd.CommandText = "SELECT id FROM voting WHERE visitID = '" & VisitID & "'"
            cmd.Connection = con
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                SQLStatement = SQLUpdate
            Else
                SQLStatement = SQLInsert
            End If

            cmd.Dispose()
            con.Close()
        Catch
            questionsError_lbl.Text = "Error with voting. Could not detect previous voters. Please see an Enterprise Village teacher for help!"
            Exit Sub
        End Try

        'Update or insert votes into DB
        Try
            con.ConnectionString = connection_string
            con.Open()
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandText = SQLStatement
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            con.Close()
        Catch
            questionsError_lbl.Text = "Error with voting. Could not cast vote. Please see an Enterprise Village teacher for help!"
            Exit Sub
        End Try

        'Refresh page and show success message
        Dim meta As New HtmlMeta()
        meta.HttpEquiv = "Refresh"
        meta.Content = "3;url=voting_system.aspx"
        Me.Page.Controls.Add(meta)
        questionsError_lbl.Text = "Vote cast!"

    End Sub

    Function CountVotes() As (Q1A1 As Integer, Q1A2 As Integer, Q1A3 As Integer, Q1A4 As Integer, Q2A1 As Integer, Q2A2 As Integer, Q2A3 As Integer, Q2A4 As Integer, Q3A1 As Integer, Q3A2 As Integer, Q3A3 As Integer, Q3A4 As Integer, Q4A1 As Integer, Q4A2 As Integer, Q4A3 As Integer, Q4A4 As Integer, Q5A1 As Integer, Q5A2 As Integer, Q5A3 As Integer, Q5A4 As Integer, Q6A1 As Integer, Q6A2 As Integer)
        Dim Q1A1 As Integer = 0
        Dim Q1A2 As Integer = 0
        Dim Q1A3 As Integer = 0
        Dim Q1A4 As Integer = 0
        Dim Q2A1 As Integer = 0
        Dim Q2A2 As Integer = 0
        Dim Q2A3 As Integer = 0
        Dim Q2A4 As Integer = 0
        Dim Q3A1 As Integer = 0
        Dim Q3A2 As Integer = 0
        Dim Q3A3 As Integer = 0
        Dim Q3A4 As Integer = 0
        Dim Q4A1 As Integer = 0
        Dim Q4A2 As Integer = 0
        Dim Q4A3 As Integer = 0
        Dim Q4A4 As Integer = 0
        Dim Q5A1 As Integer = 0
        Dim Q5A2 As Integer = 0
        Dim Q5A3 As Integer = 0
        Dim Q5A4 As Integer = 0
        Dim Q6A1 As Integer = 0
        Dim Q6A2 As Integer = 0
        'Dim Q6A3 As Integer = 0

        'Assign varibles
        If q1a1_rdo.Checked = True Then
            Q1A1 = 1
        End If

        If q1a2_rdo.Checked = True Then
            Q1A2 = 1
        End If

        If q1a3_rdo.Checked = True Then
            Q1A3 = 1
        End If

        If q1a4_rdo.Checked = True Then
            Q1A4 = 1
        End If

        If q2a1_rdo.Checked = True Then
            Q2A1 = 1
        End If

        If q2a2_rdo.Checked = True Then
            Q2A2 = 1
        End If

        If q2a3_rdo.Checked = True Then
            Q2A3 = 1
        End If

        If q2a4_rdo.Checked = True Then
            Q2A4 = 1
        End If

        If q3a1_rdo.Checked = True Then
            Q3A1 = 1
        End If

        If q3a2_rdo.Checked = True Then
            Q3A2 = 1
        End If

        'If q3a3_rdo.Checked = True Then
        '    Q3A3 = 1
        'End If

        'If q3a4_rdo.Checked = True Then
        '    Q3A4 = 1
        'End If

        If q4a1_rdo.Checked = True Then
            Q4A1 = 1
        End If

        If q4a2_rdo.Checked = True Then
            Q4A2 = 1
        End If

        'If q4a3_rdo.Checked = True Then
        '    Q4A3 = 1
        'End If

        'If q4a4_rdo.Checked = True Then
        '    Q4A4 = 1
        'End If

        If q5a1_rdo.Checked = True Then
            Q5A1 = 1
        End If

        If q5a2_rdo.Checked = True Then
            Q5A2 = 1
        End If

        If q5a3_rdo.Checked = True Then
            Q5A3 = 1
        End If

        'If q5a4_rdo.Checked = True Then
        '    Q5A4 = 1
        'End If

        If q6a1_rdo.Checked = True Then
            Q6A1 = 1
        End If

        If q6a2_rdo.Checked = True Then
            Q6A2 = 1
        End If

        Return (Q1A1, Q1A2, Q1A3, Q1A4, Q2A1, Q2A2, Q2A3, Q2A4, Q3A1, Q3A2, Q3A3, Q3A4, Q4A1, Q4A2, Q4A3, Q4A4, Q5A1, Q5A2, Q5A3, Q5A4, Q6A1, Q6A2)


    End Function

    Protected Sub enterAcct_btn_Click(sender As Object, e As EventArgs) Handles enterAcct_btn.Click
        ShowQuestions()
    End Sub

    Protected Sub submit_btn_Click(sender As Object, e As EventArgs) Handles submit_btn.Click
        SubmitVoting()
    End Sub

    Protected Sub cancel_btn_Click(sender As Object, e As EventArgs) Handles cancel_btn.Click
        Response.Redirect("~/voting_system.aspx")
    End Sub
End Class