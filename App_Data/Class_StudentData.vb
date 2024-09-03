Imports System.Data.SqlClient

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
    Dim TransactionData As New Class_TransactionData

    'Gets the number of students in EV 2.0 from a passed through visitID date (this is the correct number of students, not the student count number that the staff enters when the visitID is created)
    Function GetStudentCount(visitDate As String)
        Dim studentCountSQL As String = "SELECT COUNT(lastName) as studentCount FROM (SELECT s.id, s.accountNumber, s.firstName, s.lastName, j.jobTitle, b.businessName, sc.schoolName
                                FROM studentInfo s
                                INNER JOIN jobs j ON j.id=s.jobID
                                INNER JOIN businessInfo b ON b.id=s.businessID
                                INNER JOIN visitInfo v ON v.id=s.visitID
                                INNER JOIN schoolInfo sc ON s.schoolID = sc.id
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


    'Gets the number of students of ONE schoolID in EV 2.0 from a passed through visitID date and schoolID name (this is the correct number of students, not the student count number that the staff enters when the visitID is created)
    Function GetStudentCountOfSchool(VisitDate As String, SchoolName As String)
        Dim studentCountSQL As String = "SELECT COUNT(lastName) as studentCount FROM (SELECT s.id, s.accountNumber, s.firstName, s.lastName, j.jobTitle, b.businessName, sc.schoolName
                                FROM studentInfo s
                                INNER JOIN jobs j ON j.id=s.jobID
                                INNER JOIN businessInfo b ON b.id=s.businessID
                                INNER JOIN visitInfo v ON v.id=s.visitID
                                INNER JOIN schoolInfo sc ON s.schoolID = sc.id
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


    'gets the student count of businesses
    Function GetStudentCountOfBusiness(VisitDate As String, BusinessName As String)
        Dim studentCountSQL As String = "SELECT COUNT(lastName) as studentCount FROM (SELECT s.id, s.accountNumber, s.firstName, s.lastName, j.jobTitle, b.businessName, sc.schoolName
                                FROM studentInfo s
                                INNER JOIN jobs j ON j.id=s.jobID
                                INNER JOIN businessInfo b ON b.id=s.businessID
                                INNER JOIN visitInfo v ON v.id=s.visitID
                                INNER JOIN schoolInfo sc ON s.schoolID = sc.id
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


    'Gets the manually entered student count (from step 1, the teachers only section) from the schoolID visitID checklist
    Function GetSVCStudentCount(VisitID As String, SchoolID As String)
        Dim studentCountSQL As String = "SELECT schoolStudentCount FROM schoolVisitChecklist WHERE visitID='" & VisitID & "' AND schoolID = '" & SchoolID & "'"

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


    'Populates a DDL with the account number and name of a student in a passed through visitID ID
    Function LoadStudentNameWithNumDDL(studentName_ddl As DropDownList, visitID As String)

        'Populates a DDL with student names and their account numbers at the beginning of the name
        con.ConnectionString = connection_string
        con.Open()
        cmd.CommandText = "SELECT CONCAT(accountNumber, '.     ', firstName, ' ', lastName) as 'Account # and Name' FROM studentInfo WHERE visitID='" & visitID & "'  AND NOT lastName IS NULL"
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
              s.accountNumber
              ,s.firstName
              ,s.lastName
              ,SUM(ISNULL(s.netdeposit1,0) + ISNULL(s.netdeposit2,0) + ISNULL(s.netdeposit3,0) + ISNULL(s.netdeposit4,0) - ISNULL(s.savings,0)) totalDeposits
       INTO #netdeposits
       FROM dbo.studentInfo s
       WHERE s.visitID = '" & VisitID & "'
       GROUP BY s.accountNumber, s.firstName, s.lastName

       -- Total Purchases and with JOIN to #netdeposits temp table
       SELECT 
               t.accountNumber, CONCAT (MAX(firstname), ' ',MAX(lastName)) as studentname
              ,MAX(s.totalDeposits) TotalDeposits
              ,SUM(ISNULL(saleamount,0)) as TotalPurchases
              ,MAX(s.totalDeposits) - sum(ISNULL(saleamount,0)) as Balance
       FROM transactions t
       INNER JOIN #netdeposits s ON t.accountNumber = s.accountNumber
       WHERE t.visitID = '" & VisitID & "'
       GROUP BY t.accountNumber
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
        Dim SQLStatement = "SELECT s.accountNumber, s.id as studentID, s.firstName, s.lastName, v.id as visitID, sc.schoolName as schoolName, v.VisitDate,
                    b.businessName, j.jobTitle, sa.tierSalary
                    FROM studentInfo s
                    INNER JOIN visitInfo v
	                    ON v.id = s.visitID
                    FULL JOIN schoolinfo sc
	                    ON sc.ID = s.schoolID
                    FULL JOIN teacherinfo t
	                    ON t.Id = s.teacherID
                    INNER JOIN businessInfo b
	                    ON b.ID = s.businessID
                    INNER JOIN jobs j
	                    ON j.ID = s.jobID
                    INNER JOIN salary sa
	                    ON sa.payTier = j.jobSalary
                    WHERE s.accountNumber ='" & AccNum & "' AND v.id = '" & VID & "'"

        cmd.Connection = con
        con.ConnectionString = connection_string
        con.Open()
        cmd.CommandText = SQLStatement
        dr = cmd.ExecuteReader

        While dr.Read()
            A = dr("accountNumber").ToString
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
                              WHERE visitID='" & VisitID & "' AND accountNumber ='" & AccountNumber & "'"

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
        Dim studentCountSQL As String = "SELECT savings FROM studentInfo WHERE visitID='" & VisitID & "'"
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
        cmd.CommandText = "UPDATE studentInfo SET savings='" & SavingsAmount & "' WHERE visitID='" & VisitID & "'"
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


    'Loads student names in DDL with with account number and first and last name
    Function LoadStudentWithIDValueDDL(Students As DropDownList, BusinessID As Integer, VisitID As Integer)
        Dim SQL As String
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter

        'Check if businessID is city hall, if so, Adding UPS, Dali, PCU (water) to city hall FO students
        If BusinessID = 14 Then
            SQL = "SELECT CONCAT(firstname,' ',lastname) as StudentName, id FROM studentinfo WHERE businessID IN ('14', '15', '23', '20') AND visitID='" & VisitID & "' AND NOT firstName=' '"
        Else
            SQL = "SELECT CONCAT(firstname,' ',lastname) as StudentName, id FROM studentinfo WHERE businessID='" & BusinessID & "' AND visitID='" & VisitID & "' AND NOT firstName=' '"
        End If

        con.ConnectionString = connection_string
        con.Open()
        cmd.CommandText = SQL
        cmd.Connection = con

        da.SelectCommand = cmd
        da.Fill(ds)

        Students.DataSource = ds
        Students.DataTextField = "StudentName"
        Students.DataValueField = "id"
        Students.DataBind()
        Students.Items.Insert(0, "")

        cmd.Dispose()
        con.Close()

        Return Students
    End Function


    'Updates studentInfo with new schoolID (used in edit visitID)
    Sub UpdateSchoolID(VisitID As String, SchoolID As String)
        Using con As New SqlConnection(connection_string)
            Using cmd As New SqlCommand("UPDATE studentInfo SET visitID=@ID, schoolID=@schoolID WHERE visitID=@ID")
                cmd.Parameters.AddWithValue("@ID", VisitID)
                cmd.Parameters.AddWithValue("@schoolID", SchoolID)
                cmd.Connection = con
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using
    End Sub


    'Returns the studentinfo table with all students visiting for a selected visitID date
    Function LoadEMSTable(VisitID As Integer, Table As GridView, Optional BusinessID As Integer = 0)
        Dim da As New SqlDataAdapter
        Dim dt As New DataTable
        Dim SQLStatement As String = "Select s.id, s.firstName, s.lastName, s.accountNumber, b.id as BusinessID,j.id as JobID, s.schoolID as 'schoolID'
                                    from studentInfo s
                                    inner join businessInfo b 
	                                    on b.id=s.businessID
                                    inner join jobs j
	                                    on j.id=s.jobID
                                    inner join visitInfo v
	                                    on v.id=s.visitID
                                    where v.id='" & VisitID & "' and b.ID='" & BusinessID & "'"

        con.ConnectionString = connection_string
        con.Open()
        cmd.CommandText = SQLStatement
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(dt)

        Table.DataSource = dt
        Table.DataBind()

        Return Table
    End Function


    'Gets the student balance
    Function GetStudentBalance(VisitID As Integer, AcctNum As Integer)
        Dim Balance As Double
        Dim NetDeposit As Double
        Dim TotalTransactions As Double
        Dim Savings As Double = 0.00
        Dim NetDeposit1 As Double = 0.00
        Dim NetDeposit2 As Double = 0.00
        Dim NetDeposit3 As Double = 0.00
        Dim NetDeposit4 As Double = 0.00

        'Get total transactions of student
        TotalTransactions = TransactionData.GetTotalTransactions(AcctNum, VisitID)

        'Get net deposit info
        Dim NetDeposits = TransactionData.GetDepositInfo(VisitID, AcctNum)

        NetDeposit1 = NetDeposits.NetDeposit1
        NetDeposit2 = NetDeposits.NetDeposit2
        NetDeposit3 = NetDeposits.NetDeposit3
        NetDeposit4 = NetDeposits.NetDeposit4

        Savings = NetDeposits.Savings

        'Get remaining balance for customer
        NetDeposit = NetDeposit1 + NetDeposit2 + NetDeposit3 + NetDeposit4
        Balance = NetDeposit - TotalTransactions - Savings

        Return Balance
    End Function


End Class
