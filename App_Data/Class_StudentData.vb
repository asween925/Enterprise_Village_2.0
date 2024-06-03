﻿Imports System.Data.SqlClient

Public Class Class_StudentData
    Dim VisitID As New Class_VisitData
    Dim Visit As Integer = VisitID.GetVisitID
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
    Dim studentCount As String
    Dim errorStr As String

    'Gets the number of students in EV 2.0 from a passed through visit date (this is the correct number of students, not the student count number that the staff enters when the visit is created)
    Function GetStudentCount(visitDate As String)
        Dim studentCountSQL As String = "SELECT COUNT(lastName) as studentCount FROM (SELECT s.id, s.employeeNumber, s.firstName, s.lastName, j.jobTitle, b.businessName, sc.schoolName
                                FROM studentInfo s
                                INNER JOIN jobs j ON j.id=s.job
                                INNER JOIN businessInfo b ON b.id=s.business
                                INNER JOIN visitInfo v ON v.id=s.visit
                                INNER JOIN schoolInfo sc ON s.school = sc.id
                                WHERE v.visitDate='" & visitDate & "' AND NOT businessName='Training Business' AND NOT firstName='NULL' AND NOT lastName='NULL' AND NOT firstName = ' ' AND NOT lastName=' ' ) t"

        con.ConnectionString = connection_string
        con.Open()
        cmd.CommandText = studentCountSQL
        cmd.Connection = con
        dr = cmd.ExecuteReader

        While dr.Read()
            studentCount = dr("studentCount").ToString
        End While

        cmd.Dispose()
        con.Close()

        Return studentCount
    End Function


    'Gets the number of students of ONE school in EV 2.0 from a passed through visit date and school name (this is the correct number of students, not the student count number that the staff enters when the visit is created)
    Function GetStudentCountOfSchool(VisitDate As String, SchoolName As String)
        Dim studentCountSQL As String = "SELECT COUNT(lastName) as studentCount FROM (SELECT s.id, s.employeeNumber, s.firstName, s.lastName, j.jobTitle, b.businessName, sc.schoolName
                                FROM studentInfo s
                                INNER JOIN jobs j ON j.id=s.job
                                INNER JOIN businessInfo b ON b.id=s.business
                                INNER JOIN visitInfo v ON v.id=s.visit
                                INNER JOIN schoolInfo sc ON s.school = sc.id
                                WHERE v.visitDate='" & VisitDate & "' AND sc.schoolName = '" & SchoolName & "' AND NOT businessName='Training Business' AND NOT firstName='NULL' AND NOT lastName='NULL' AND NOT firstName = ' ' AND NOT lastName=' ' ) t"

        con.ConnectionString = connection_string
        con.Open()
        cmd.CommandText = studentCountSQL
        cmd.Connection = con
        dr = cmd.ExecuteReader

        While dr.Read()
            studentCount = dr("studentCount").ToString
        End While

        cmd.Dispose()
        con.Close()

        Return studentCount
    End Function


    '
    Function GetStudentCountOfBusiness(VisitDate As String, BusinessName As String)
        Dim studentCountSQL As String = "SELECT COUNT(lastName) as studentCount FROM (SELECT s.id, s.employeeNumber, s.firstName, s.lastName, j.jobTitle, b.businessName, sc.schoolName
                                FROM studentInfo s
                                INNER JOIN jobs j ON j.id=s.job
                                INNER JOIN businessInfo b ON b.id=s.business
                                INNER JOIN visitInfo v ON v.id=s.visit
                                INNER JOIN schoolInfo sc ON s.school = sc.id
                                WHERE v.visitDate='" & VisitDate & "' AND b.businessName = '" & BusinessName & "' AND NOT businessName='Training Business' AND NOT firstName='NULL' AND NOT lastName='NULL' AND NOT firstName = ' ' AND NOT lastName=' ' ) t"

        con.ConnectionString = connection_string
        con.Open()
        cmd.CommandText = studentCountSQL
        cmd.Connection = con
        dr = cmd.ExecuteReader

        While dr.Read()
            studentCount = dr("studentCount").ToString
        End While

        cmd.Dispose()
        con.Close()

        Return studentCount
    End Function


    'Gets the manually entered student count (from step 1, the teachers only section) from the school visit checklist
    Function GetSVCStudentCount(VisitDate As String, SchoolName As String)
        Dim studentCountSQL As String = "SELECT schoolStudentCount FROM schoolVisitChecklist WHERE visitDate='" & VisitDate & "' AND schoolName = '" & SchoolName & "'"

        con.ConnectionString = connection_string
        con.Open()
        cmd.CommandText = studentCountSQL
        cmd.Connection = con
        dr = cmd.ExecuteReader

        While dr.Read()
            studentCount = dr("schoolStudentCount").ToString
        End While

        cmd.Dispose()
        con.Close()

        Return studentCount
    End Function


    'Populates a DDL with the account number and name of a student in a passed through visit ID
    Function LoadStudentNameWithNumDDL(studentName_ddl As DropDownList, visitID As String)

        'Populates a DDL with student names and their account numbers at the beginning of the name
        con.ConnectionString = connection_string
        con.Open()
        cmd.CommandText = "SELECT CONCAT(employeeNumber, '.     ', firstName, ' ', lastName) as 'Account # and Name' FROM studentInfo WHERE visit='" & visitID & "'  AND NOT lastName IS NULL"
        cmd.Connection = con
        dr = cmd.ExecuteReader

        While dr.Read()
            studentName_ddl.Items.Add(dr(0).ToString)
        End While
        studentName_ddl.Items.Insert(0, "")

        cmd.Dispose()
        con.Close()

        Return studentName_ddl.Items
    End Function


    'Loads a table with total transactions and balance but only for students with a negative balance
    Function LoadTransactionsWithNegativeBalanceTable(VisitID As String)
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
              ,SUM(ISNULL(s.netdeposit1,0) + ISNULL(s.netdeposit2,0) + ISNULL(s.netdeposit3,0) + ISNULL(s.netdeposit4,0) - ISNULL(s.savings,0)) totalDeposits
       INTO #netdeposits
       FROM dbo.studentInfo s
       WHERE s.visit = '" & VisitID & "'
       GROUP BY s.employeeNumber, s.firstName, s.lastName

       -- Total Purchases and with JOIN to #netdeposits temp table
       SELECT 
               t.employeeNumber, CONCAT (MAX(firstname), ' ',MAX(lastName)) as studentname
              ,MAX(s.totalDeposits) TotalDeposits
              ,SUM(ISNULL(saleamount,0)) as TotalPurchases
              ,MAX(s.totalDeposits) - sum(ISNULL(saleamount,0)) as Balance
       FROM transactions t
       INNER JOIN #netdeposits s ON t.employeeNumber = s.employeeNumber
       WHERE t.visitdate = '" & VisitID & "'
       GROUP BY t.employeeNumber
       HAVING MAX(s.totalDeposits) - sum(ISNULL(saleamount,0)) < 0
       ORDER BY Balance"


        Dim da As New SqlDataAdapter
        da.SelectCommand = cmd
        Dim dt As New DataTable
        da.Fill(dt)

        cmd.Dispose()
        con.Close()

        Return dt
    End Function


    'Gets students info of various columns
    Function StudentLookup(VID As String, AccNum As String) As (AccountNumber As String, StudentID As String, FirstName As String, LastName As String, VisitID As String, SchoolName As String, VisitDate As String, BusinessName As String, JobTitle As String, Salary As String)
        Dim A As String = ""
        Dim S As String = ""
        Dim F As String = ""
        Dim L As String = ""
        Dim V As String = ""
        Dim Sc As String = ""
        Dim Vi As String = ""
        Dim B As String = ""
        Dim J As String = ""
        Dim Sa As String = ""
        Dim SQLStatement = "SELECT s.employeeNumber, s.id as studentID, s.firstName, s.lastName, v.id as visitID, sc.schoolName as schoolName, v.VisitDate,
                    b.businessName, j.jobTitle, sa.tierSalary
                    FROM studentInfo s
                    INNER JOIN visitInfo v
	                    ON v.id = s.visit
                    FULL JOIN schoolinfo sc
	                    ON sc.ID = s.school
                    FULL JOIN teacherinfo t
	                    ON t.Id = s.teacher
                    INNER JOIN businessInfo b
	                    ON b.ID = s.business
                    INNER JOIN jobs j
	                    ON j.ID = s.job
                    INNER JOIN salary sa
	                    ON sa.payTier = j.jobSalary
                    WHERE s.employeeNumber ='" & AccNum & "' AND v.id = '" & VID & "'"

        cmd.Connection = con
        con.ConnectionString = connection_string
        con.Open()
        cmd.CommandText = SQLStatement
        dr = cmd.ExecuteReader

        While dr.Read()
            A = dr("employeeNumber").ToString
            S = dr("studentID").ToString
            F = dr("firstName").ToString
            L = dr("lastName").ToString
            V = dr("visitID").ToString
            Sc = dr("schoolName").ToString
            Vi = dr("visitDate").ToString
            B = dr("businessName").ToString
            J = dr("jobTitle").ToString
            Sa = dr("tierSalary").ToString
        End While

        dr.Close()
        cmd.Dispose()
        con.Close()

        Return (A, S, F, L, V, Sc, Vi, B, J, Sa)
    End Function


    'Loads a gridview with deposits and cash back (for magic computer)
    Function LoadDepositsTable(VisitID As String, AccountNumber As String)
        con.ConnectionString = connection_string
        con.Open()
        cmd = New SqlCommand
        cmd.Connection = con
        cmd.CommandText = "SELECT id, cbw1, cbw2, cbw3, cbw4, initialDeposit1, initialDeposit2, initialDeposit3, initialDeposit4 
                              FROM studentInfo 
                              WHERE visit='" & VisitID & "' AND employeeNumber ='" & AccountNumber & "'"

        Dim da As New SqlDataAdapter
        da.SelectCommand = cmd
        Dim dt As New DataTable
        da.Fill(dt)

        cmd.Dispose()
        con.Close()

        Return dt
    End Function


    'Check savings
    Function CheckSavings(VisitID As String)
        Dim studentCountSQL As String = "SELECT savings FROM studentInfo WHERE visit='" & VisitID & "'"
        Dim Savings As Boolean = False

        con.ConnectionString = connection_string
        con.Open()
        cmd.CommandText = studentCountSQL
        cmd.Connection = con
        dr = cmd.ExecuteReader

        While dr.Read()
            If dr("savings").ToString() = Nothing Or dr("savings").ToString() = "0.00" Then
                Savings = False
            Else
                Savings = True
            End If
        End While

        cmd.Dispose()
        con.Close()

        Return Savings
    End Function


    'Update savings
    Sub TransferToSavings(VisitID As String, SavingsAmount As String)
        con.ConnectionString = connection_string
        con.Open()
        cmd.CommandText = "UPDATE studentInfo SET savings='" & SavingsAmount & "' WHERE visit='" & VisitID & "'"
        cmd.Connection = con
        cmd.ExecuteNonQuery()

        cmd.Dispose()
        con.Close()
    End Sub


    'Get student name from student ID
    Function GetStudentNameFromID(StudentID As Integer)
        Dim StudentName As String = ""

        con.ConnectionString = connection_string
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "SELECT CONCAT(firstName, ' ', lastName) as studentName FROM studentInfo WHERE id='" + StudentID.ToString() + "'"
        dr = cmd.ExecuteReader

        While dr.Read()
            StudentName = dr("studentName").ToString()
        End While

        cmd.Dispose()
        con.Close()

        Return StudentName
    End Function
End Class
