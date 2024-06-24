Imports System.Data.SqlClient

Public Class Class_BusinessData
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

	Function GetBusinessID(businessName As String)
		Dim returnBusinessID As String = ""

		'Get school info from school name
		con.ConnectionString = connection_string
		con.Open()
		cmd.CommandText = "SELECT ID FROM businessInfo WHERE businessName = '" & businessName & "'"
		cmd.Connection = con
		dr = cmd.ExecuteReader

		While dr.Read()
			returnBusinessID = dr("ID").ToString()
			cmd.Dispose()
			con.Close()
			Return returnBusinessID
		End While

		cmd.Dispose()
		con.Close()

		Return returnBusinessID
	End Function

	Function LoadBusinessNamesDDL(businessNameDDL As DropDownList, Optional Open As Boolean = False, Optional VisitID As Integer = 0)
		Dim SQLStatement As String = "SELECT b.businessName FROM businessInfo b"
		Dim SQLOpenClause As String = " JOIN businessVisitInfo o ON b.id = o.businessID WHERE o.openstatus=1 AND o.visitID='" & VisitID & "' AND NOT b.id=28 AND NOT b.id=29 ORDER BY b.businessName"

		'Clear out teacher and school DDLs
		businessNameDDL.Items.Clear()

		'If Open is true, add a where clause to only load business names if they are open on the passed through visit ID
		If Open = True Then
			SQLStatement = SQLStatement & SQLOpenClause
		Else
			SQLStatement = SQLStatement & " WHERE NOT b.id=28 AND NOT b.id=29 ORDER BY b.businessName"
		End If

		'Populate school DDL from entered visit date
		con.ConnectionString = connection_string
		con.Open()
		cmd.CommandText = SQLStatement
		cmd.Connection = con
		dr = cmd.ExecuteReader

		While dr.Read()
			businessNameDDL.Items.Add(dr(0).ToString)
		End While
		businessNameDDL.Items.Insert(0, "")

		cmd.Dispose()
		con.Close()

		Return businessNameDDL.Items
	End Function

	'Update image and title based on business ID
	Function GetBusinessLogos(BusinessID As String) As (ImagePath As String, BColor As String, BusinessName As String)
		Dim I As String = ""
		Dim C As String = ""
		Dim B As String = ""
		Dim logoRoot As String = "~/media/Logos/"

		con.ConnectionString = connection_string
		con.Open()
		cmd.CommandText = "SELECT logoPath, businessColor, businessName FROM businessinfo WHERE ID='" & BusinessID & "'"
		cmd.Connection = con
		dr = cmd.ExecuteReader

		While dr.Read()
			I = logoRoot & dr(0).ToString
			C = dr(1).ToString
			B = dr(2).ToString
		End While

		cmd.Dispose()
		con.Close()

		Return (I, C, B)

	End Function

	'Get business address
	Function GetBusinessAddress(BusinessName As String)
		Dim returnAddress As String = ""

		'Get school info from school name
		con.ConnectionString = connection_string
		con.Open()
		cmd.CommandText = "SELECT address FROM businessInfo WHERE businessName = '" & BusinessName & "'"
		cmd.Connection = con
		dr = cmd.ExecuteReader

		While dr.Read()
			returnAddress = dr("address").ToString()
			cmd.Dispose()
			con.Close()
			Return returnAddress
		End While

		cmd.Dispose()
		con.Close()

		Return returnAddress
	End Function

	'Get job ID from job title
	Function GetJobID(JobTitle As String)
		Dim ReturnID As String

		'Get job ID from job title
		con.ConnectionString = connection_string
		con.Open()
		cmd.CommandText = "SELECT id FROM jobs WHERE jobTitle='" & JobTitle & "'"
		cmd.Connection = con
		dr = cmd.ExecuteReader

		While dr.Read()
			ReturnID = dr("id").ToString
		End While

		cmd.Dispose()
		con.Close()

		Return ReturnID

	End Function

	'Gets a string of the closed businesses in EV
	Function GetClosedBusinesses(VisitID As Integer)
		Dim ClosedBusinesses As String

		con.ConnectionString = connection_string
		con.Open()
		cmd.CommandText = "Declare @val varchar(MAX)
                               SELECT @val = COALESCE(@val + ', ' + b.businessName, b.businessName)
	                                FROM businessInfo b
                                INNER JOIN businessVisitInfo o
                                ON b.id = o.businessID
                                WHERE o.openstatus=0 AND o.visitID='" & VisitID & "'
                                ORDER BY b.businessName
	                                SELECT @val as names"
		cmd.Connection = con
		dr = cmd.ExecuteReader

		While dr.Read()
			ClosedBusinesses = dr("names").ToString
		End While

		cmd.Dispose()
		con.Close()

		Return ClosedBusinesses
	End Function

	'Returns a table filled with profit and deposit information from a passed through visit id
	Function GetBusinessProfitsTable(VisitID As Integer, Table As GridView)
		Dim da As New SqlDataAdapter
		Dim dt As New DataTable
		Dim SQLStatement As String = "SELECT b.id, b.businessName, 
								CASE WHEN profit IS NULL THEN '0.00' ELSE profit END AS profits, 
								CASE WHEN loanamount IS NULL THEN '0.00' ELSE loanamount END AS loan, 
								CASE WHEN deposit4 IS NULL THEN '0.00' ELSE deposit4 END AS deposit4,
								b.startingBalance
                                  FROM businessVisitInfo o
                                  INNER JOIN businessInfo b
                                  ON o.businessID = b.id
                                  WHERE o.visitID = '" & VisitID & "'
                                  ORDER BY b.businessName"

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

	'Returns deposit, profits, and loan amount information from businessVisitInfo
	Function GetBusinessFinancials(VisitID As Integer, BusinessID As Integer) As (Deposit1 As String, Deposit2 As String, Deposit3 As String, Deposit4 As String, Profit As String, LoanAmount As String, StartingBalance As String)
		Dim SQLStatement As String = "SELECT o.loanAmount, o.deposit1, o.deposit2, o.deposit3, o.deposit4, o.profit, b.startingBalance FROM businessVisitInfo o JOIN businessInfo b ON b.id = o.businessID WHERE o.visitID='" & VisitID & "' AND o.businessID='" & BusinessID & "'"
		Dim D1 As String
		Dim D2 As String
		Dim D3 As String
		Dim D4 As String
		Dim L As String
		Dim P As String
		Dim S As String

		con.ConnectionString = connection_string
		con.Open()
		cmd.CommandText = SQLStatement
		cmd.Connection = con
		dr = cmd.ExecuteReader()

		While dr.Read()
			D1 = dr("deposit1").ToString()
			D2 = dr("deposit2").ToString()
			D3 = dr("deposit3").ToString()
			D4 = dr("deposit4").ToString()
			L = dr("loanAmount").ToString()
			P = dr("profit").ToString()
			S = dr("startingBalance").ToString()
		End While

		cmd.Dispose()
		con.Close()

		Return (D1, D2, D3, D4, P, L, S)
	End Function

	'Update online banking entries
	Sub UpdateOnlineBanking(VisitID As Integer, BusinessID As Integer, Deposit1 As String, Deposit2 As String, Deposit3 As String, Deposit4 As String, LoanAmount As String, Profit As String)
		Dim SQLStatement As String = "UPDATE businessVisitInfo SET loanAmount='" & LoanAmount & "', deposit1='" & Deposit1 & "', deposit2='" & Deposit2 & "', deposit3='" & Deposit3 & "', deposit4='" & Deposit4 & "', profit='" & Profit & "' WHERE visitID ='" & VisitID & "' AND businessID='" & BusinessID & "'"

		con.ConnectionString = connection_string
		con.Open()
		cmd.CommandText = SQLStatement
		cmd.Connection = con
		cmd.ExecuteNonQuery()
		con.Close()
	End Sub

	'Load open closed status table
	Function LoadOpenClosedStatus(VisitID As Integer, Table As GridView)
		Dim da As New SqlDataAdapter
		Dim dt As New DataTable
		Dim SQLStatement As String = " SELECT DISTINCT o.businessID, o.openstatus, o.schoolID, b.businessName, o.minVolCount, o.maxVolCount
								  FROM businessVisitInfo o
								  INNER JOIN businessInfo b
								  ON o.businessID = b.ID
								  INNER JOIN schoolInfo s ON s.id = o.schoolID
								  WHERE o.visitID='" & VisitID & "'
								  ORDER BY b.businessname"

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

	'Load edit business gridview
	Function LoadEditBusinessTable(Table As GridView)
		Dim da As New SqlDataAdapter
		Dim dt As New DataTable
		Dim SQLStatement As String = "SELECT b.id, b.businessName, b.address, b.startingBalance, CONCAT('../../media/Logos/', b.id, '/', b.logoPath) as logoPath, j.jobTitle as jobTitle1, j2.jobTitle as jobTitle2, j3.jobTitle as jobTitle3, j4.jobTitle as jobTitle4
                                      , j5.jobTitle as jobTitle5, j6.jobTitle as jobTitle6, j7.jobTitle as jobTitle7, j8.jobTitle as jobTitle8, j9.jobTitle as jobTitle9, j10.jobTitle as jobTitle10
                                      FROM businessInfo b
                                      LEFT JOIN jobs j ON j.id = b.position1
                                      LEFT JOIN jobs j2 ON j2.id = b.position2
                                      LEFT JOIN jobs j3 ON j3.id = b.position3
                                      LEFT JOIN jobs j4 ON j4.id = b.position4
                                      LEFT JOIN jobs j5 ON j5.id = b.position5
                                      LEFT JOIN jobs j6 ON j6.id = b.position6
                                      LEFT JOIN jobs j7 ON j7.id = b.position7
                                      LEFT JOIN jobs j8 ON j8.id = b.position8
                                      LEFT JOIN jobs j9 ON j9.id = b.position9
                                      LEFT JOIN jobs j10 ON j10.id = b.position10
                                      ORDER BY b.businessName"

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

End Class
