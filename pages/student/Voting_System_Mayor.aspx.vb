Imports System.Data.SqlClient

Public Class Voting_System_Mayor
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
    Dim VisitData As New Class_VisitData
    Dim VisitID As Integer = VisitData.GetVisitID

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Check if visit date has been created
        If Not (IsPostBack) Then
            If VisitID <> 0 Then
                visitdate_hf.Value = VisitID
                LoadData()
            End If
        End If

    End Sub

    Sub LoadData()
        Dim Q1A1 As Integer
        Dim Q1A2 As Integer
        Dim Q1A3 As Integer
        Dim Q1A4 As Integer
        Dim Q2A1 As Integer
        Dim Q2A2 As Integer
        Dim Q2A3 As Integer
        Dim Q2A4 As Integer
        Dim Q3A1 As Integer
        Dim Q3A2 As Integer
        Dim Q3A3 As Integer
        Dim Q3A4 As Integer
        Dim Q4A1 As Integer
        Dim Q4A2 As Integer
        Dim Q4A3 As Integer
        Dim Q4A4 As Integer
        Dim Q5A1 As Integer
        Dim Q5A2 As Integer
        Dim Q5A3 As Integer
        Dim Q5A4 As Integer
        Dim Q6A1 As Integer
        Dim Q6A2 As Integer

        Dim Q1A1Per As Double
        Dim Q1A2Per As Double
        Dim Q1A3Per As Double
        Dim Q1A4Per As Double
        Dim Q2A1Per As Double
        Dim Q2A2Per As Double
        Dim Q2A3Per As Double
        Dim Q2A4Per As Double
        Dim Q3A1Per As Double
        Dim Q3A2Per As Double
        Dim Q3A3Per As Double
        Dim Q3A4Per As Double
        Dim Q4A1Per As Double
        Dim Q4A2Per As Double
        Dim Q4A3Per As Double
        Dim Q4A4Per As Double
        Dim Q5A1Per As Double
        Dim Q5A2Per As Double
        Dim Q5A3Per As Double
        Dim Q5A4Per As Double
        Dim Q6A1Per As Double
        Dim Q6A2Per As Double

        Dim TotalVotes As Integer
        Dim SQLStatement As String = "SELECT * FROM voting WHERE visitID = '" & VisitID & "'"

        'Get voting answers and assign to variables
        'Try
        con.ConnectionString = connection_string
            con.Open()
            cmd.CommandText = SQLStatement
            cmd.Connection = con
            dr = cmd.ExecuteReader

            While dr.Read()
                Q1A1 = dr("q1a1").ToString
                Q1A2 = dr("q1a2").ToString
                Q1A3 = dr("q1a3").ToString
            'Q1A4 = dr("q1a4").ToString
            Q2A1 = dr("q2a1").ToString
                Q2A2 = dr("q2a2").ToString
                Q2A3 = dr("q2a3").ToString
            'Q2A4 = dr("q2a4").ToString
            Q3A1 = dr("q3a1").ToString
                Q3A2 = dr("q3a2").ToString
                Q3A3 = dr("q3a3").ToString
            'Q3A4 = dr("q3a4").ToString
            Q4A1 = dr("q4a1").ToString
                Q4A2 = dr("q4a2").ToString
                Q4A3 = dr("q4a3").ToString
            'Q4A4 = dr("q4a4").ToString
            Q5A1 = dr("q5a1").ToString
                Q5A2 = dr("q5a2").ToString
                Q5A3 = dr("q5a3").ToString
            'Q5A4 = dr("q5a4").ToString
            Q6A1 = dr("q6a1").ToString
                Q6A2 = dr("q6a2").ToString
                'Q6A3 = dr("q6a3").ToString
                'Q6A4 = dr("q6a4").ToString
            End While

            cmd.Dispose()
            con.Close()
        'Catch
        '    error_lbl.Text = "Error with voting. Could not detect previous voters. Please see an Enterprise Village teacher for help!"
        '    Exit Sub
        'End Try

        'Get total votes per question
        'TotalVotes = Q1A1 + Q1A2 + Q1A3
        TotalVotes = Q3A1 + Q3A2 + Q3A3 + Q3A4

        Q1A1Per = Q1A1 / (Q1A1 + Q1A2 + Q1A3) * 100
        Q1A2Per = Q1A2 / (Q1A1 + Q1A2 + Q1A3) * 100
        Q1A3Per = Q1A3 / (Q1A1 + Q1A2 + Q1A3) * 100
        'Q1A4Per = Q1A4 / TotalVotes * 100
        Q2A1Per = Q2A1 / (Q2A1 + Q2A2 + Q2A3) * 100
        Q2A2Per = Q2A2 / (Q2A1 + Q2A2 + Q2A3) * 100
        Q2A3Per = Q2A3 / (Q2A1 + Q2A2 + Q2A3) * 100
        'Q2A4Per = Q2A4 / TotalVotes * 100
        Q3A1Per = Q3A1 / (Q3A1 + Q3A2 + Q3A3) * 100
        Q3A2Per = Q3A2 / (Q3A1 + Q3A2 + Q3A3) * 100
        Q3A3Per = Q3A3 / (Q3A1 + Q3A2 + Q3A3) * 100
        'Q3A4Per = Q3A4 / TotalVotes * 100
        Q4A1Per = Q4A1 / (Q4A1 + Q4A2 + Q4A3) * 100
        Q4A2Per = Q4A2 / (Q4A1 + Q4A2 + Q4A3) * 100
        Q4A3Per = Q4A3 / (Q4A1 + Q4A2 + Q4A3) * 100
        'Q4A4Per = Q4A4 / TotalVotes * 100
        Q5A1Per = Q5A1 / (Q5A1 + Q5A2 + Q5A3) * 100
        Q5A2Per = Q5A2 / (Q5A1 + Q5A2 + Q5A3) * 100
        Q5A3Per = Q5A3 / (Q5A1 + Q5A2 + Q5A3) * 100
        'Q5A4Per = Q5A4 / TotalVotes * 100

        Q6A1Per = Q6A1 / (Q6A1 + Q6A2) * 100
        Q6A2Per = Q6A2 / (Q6A1 + Q6A2) * 100

        q1a1_lbl.Text = Math.Ceiling(Q1A1Per) & "%"
        q1a2_lbl.Text = Math.Ceiling(Q1A2Per) & "%"
        q1a3_lbl.Text = Math.Ceiling(Q1A3Per) & "%"
        'q1a4_lbl.Text = Q1A4Per) & "%"
        q2a1_lbl.Text = Math.Ceiling(Q2A1Per) & "%"
        q2a2_lbl.Text = Math.Ceiling(Q2A2Per) & "%"
        q2a3_lbl.Text = Math.Ceiling(Q2A3Per) & "%"
        'q2a4_lbl.Text = Q2A4Per) & "%"
        q3a1_lbl.Text = Math.Ceiling(Q3A1Per) & "%"
        q3a2_lbl.Text = Math.Ceiling(Q3A2Per) & "%"
        q3a3_lbl.Text = Math.Ceiling(Q3A3Per) & "%"
        'q3a4_lbl.Text = Math.Ceiling(Q3A4Per) & "%"
        q4a1_lbl.Text = Math.Ceiling(Q4A1Per) & "%"
        q4a2_lbl.Text = Math.Ceiling(Q4A2Per) & "%"
        q4a3_lbl.Text = Math.Ceiling(Q4A3Per) & "%"
        'q4a4_lbl.Text = Math.Ceiling(Q4A4Per) & "%"
        q5a1_lbl.Text = Math.Ceiling(Q5A1Per) & "%"
        q5a2_lbl.Text = Math.Ceiling(Q5A2Per) & "%"
        q5a3_lbl.Text = Math.Ceiling(Q5A3Per) & "%"
        'q5a4_lbl.Text = Math.Ceiling(Q5A4Per) & "%"

        q6a1_lbl.Text = Math.Ceiling(Q6A1Per) & "%"
        q6a2_lbl.Text = Math.Ceiling(Q6A2Per) & "%"

    End Sub

    Protected Sub print_btn_Click(sender As Object, e As EventArgs) Handles print_btn.Click
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "Print", "Print();", True)
    End Sub
End Class