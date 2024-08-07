﻿Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class Inventory_Home
	Inherits System.Web.UI.Page
	Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
	Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
	Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
	Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
	Dim DBConnection As New DatabaseConection
    Dim dr As SqlDataReader
    Dim StudentData As New Class_StudentData
    Dim VisitData As New Class_VisitData
    Dim VisitID As Integer = VisitData.GetVisitID
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("LoggedIn") <> "1" Then
            Response.Redirect("../../default.aspx")
        End If

        If Not (IsPostBack) Then

            If VisitID <> 0 Then
                visitdate_hf.Value = VisitID
            End If

            'Populating school header
            Dim header As New Class_SchoolHeader
            headerSchoolName_lbl.Text = header.GetSchoolHeader()

            'Assign visit date to label
            visitDate_lbl.Text = FormatDateTime(Now, DateFormat.ShortDate)

            'Assign student count to label
            count_lbl.Text = StudentData.GetStudentCount(visitDate_lbl.Text)

        End If
    End Sub


End Class