Imports System.Data.SqlClient

Public Class Class_CheckData
    Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
    Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
    Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
    Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
    Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader

    Function LoadExistingPayrollChecksTable(Table As GridView, BusinessID As Integer, VisitID As Integer, PayPeriod As String)
        Dim SQLStatement As String = "SELECT c.id, c.studentID, c.checkAmount, c.writtenAmount, c.memo, c.timeWritten, c.operBizName, c.operGroup, b.businessName, b.address
            FROM checksinfo c
            FULL JOIN businessinfo b
            ON b.id = c.businessID
            FULL JOIN studentInfo s
            ON s.id = c.studentID
            WHERE c.memo='" & PayPeriod & "' AND c.businessID='" & BusinessID & "' AND c.visitID='" & VisitID & "' ORDER BY ID"

        con.ConnectionString = connection_string
        con.Open()
        cmd.Connection = con
        cmd.CommandText = SQLStatement

        Dim da As New SqlDataAdapter
        da.SelectCommand = cmd
        Dim dt As New DataTable
        da.Fill(dt)

        Table.DataSource = dt
        Table.DataBind()

        da.Dispose()
        cmd.Dispose()
        con.Close()

        Return Table
    End Function

    Function LoadExistingOperatingChecksTable(Table As GridView, BusinessID As Integer, VisitID As Integer, OperGroup As String)
        Dim SQLStatement As String = "SELECT c.id, c.studentID, c.checkAmount, c.writtenAmount, c.memo, c.timeWritten, c.operBizName, c.operGroup, b.businessName, b.address
            FROM checksinfo c
            FULL JOIN businessinfo b
            ON b.id = c.businessID
            FULL JOIN studentInfo s
            ON s.id = c.studentID
            WHERE c.operGroup='" & OperGroup & "' AND c.businessID='" & BusinessID & "' AND c.visitID='" & VisitID & "' ORDER BY ID"

        con.ConnectionString = connection_string
        con.Open()
        cmd.Connection = con
        cmd.CommandText = SQLStatement

        Dim da As New SqlDataAdapter
        da.SelectCommand = cmd
        Dim dt As New DataTable
        da.Fill(dt)

        Table.DataSource = dt
        Table.DataBind()

        da.Dispose()
        cmd.Dispose()
        con.Close()

        Return Table
    End Function

    Sub DeleteCheck(CheckID As Integer)
        Using con As New SqlConnection(connection_string)
            Using cmd As New SqlCommand("DELETE FROM checksinfo WHERE id='" & CheckID & "'")
                cmd.Connection = con
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using
    End Sub

    Function CheckForCheck(VisitID As Integer, BusinessID As Integer, Memo As String, StudentID As Integer)
        Dim CheckSaved As String = ""

        con.ConnectionString = connection_string
        con.Open()
        cmd = New SqlCommand
        cmd.Connection = con
        cmd.CommandText = "SELECT studentID FROM checksInfo WHERE visitID ='" & VisitID & "' AND businessID='" & BusinessID & "' AND memo='" & Memo & "' AND studentID='" & StudentID & "'"
        dr = cmd.ExecuteReader

        If dr.HasRows = True Then
            CheckSaved = "A check with that name has already been saved."
        End If

        cmd.Dispose()
        con.Close()

        Return CheckSaved
    End Function

    Sub InsertNewCheck(BusinessID As Integer, StudentID As Integer, CheckAmount As String, WrittenAmount As String, VisitID As Integer, TimeStampSTR As String, Memo As String)
        con.ConnectionString = connection_string
        con.Open()
        cmd = New SqlCommand
        cmd.Connection = con
        cmd.CommandText = "INSERT INTO checksinfo (businessID, studentID, checkAmount, writtenAmount, memo, visitID, timeWritten ) 
                            VALUES ('" & BusinessID & "', '" & StudentID & "', '" & CheckAmount & "', '" & WrittenAmount & "', '" & Memo & "', '" & VisitID & "', '" & TimeStampSTR & "')"
        cmd.ExecuteNonQuery()
        dr.Close()
        cmd.Dispose()
        con.Close()
    End Sub

    Sub InsertNewOperatingCheck(BusinessID As Integer, CheckAmount As String, WrittenAmount As String, VisitID As Integer, TimeStampSTR As String, Memo As String, OperBizName As String, OperGroup As String)
        con.ConnectionString = connection_string
        con.Open()
        cmd = New SqlCommand
        cmd.Connection = con
        cmd.CommandText = "INSERT INTO checksinfo (businessID, checkAmount, writtenAmount, memo, visitID, timeWritten, operBizName, operGroup ) 
                            VALUES ('" & BusinessID & "', '" & CheckAmount & "', '" & WrittenAmount & "', '" & Memo & "', '" & VisitID & "', '" & TimeStampSTR & "', '" & OperBizName & "', '" & OperGroup & "')"
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        con.Close()
    End Sub

    Function GetOperatingText(BusinessID As Integer) As (O1 As String, O2 As String, O3 As String, O4 As String, O5 As String, O6 As String, O7 As String, O8 As String, O9 As String, O10 As String, O11 As String, O12 As String, O13 As String, PChecks As String)
        Dim SQLStatement As String = "SELECT operating1, operating2, operating3, operating4, operating5, operating6, operating7, operating8, operating9, operating10, operating11, operating12, operating13, printChecks FROM businessinfo WHERE ID='" & BusinessID & "'"
        Dim O1 As String
        Dim O2 As String
        Dim O3 As String
        Dim O4 As String
        Dim O5 As String
        Dim O6 As String
        Dim O7 As String
        Dim O8 As String
        Dim O9 As String
        Dim O10 As String
        Dim O11 As String
        Dim O12 As String
        Dim O13 As String
        Dim P As String

        con.ConnectionString = connection_string
        con.Open()
        cmd.CommandText = SQLStatement
        cmd.Connection = con
        dr = cmd.ExecuteReader

        While dr.Read()
            O1 = dr("operating1").ToString()
            O2 = dr("operating2").ToString()
            O3 = dr("operating3").ToString()
            O4 = dr("operating4").ToString()
            O5 = dr("operating5").ToString()
            O6 = dr("operating6").ToString()
            O7 = dr("operating7").ToString()
            O8 = dr("operating8").ToString()
            O9 = dr("operating9").ToString()
            O10 = dr("operating10").ToString()
            O11 = dr("operating11").ToString()
            O12 = dr("operating12").ToString()
            O13 = dr("operating13").ToString()
            P = dr("printChecks").ToString()
        End While

        cmd.Dispose()
        con.Close()

        Return (O1, O2, O3, O4, O5, O6, O7, O8, O9, O10, O11, O12, O13, P)
    End Function

    Function GetCheckIDs(CheckIDs As List(Of String), BusinessID As Integer, VisitID As Integer, OperGroup As String)
        con.ConnectionString = connection_string
        con.Open()
        cmd.CommandText = "SELECT ID FROM checksInfo WHERE businessID ='" & BusinessID & "' AND visitID='" & VisitID & "' and operGroup='" & OperGroup & "'"
        cmd.Connection = con
        dr = cmd.ExecuteReader

        While dr.Read()
            CheckIDs.Add(dr("ID"))
        End While

        cmd.Dispose()
        con.Close()

        Return CheckIDs
    End Function

End Class