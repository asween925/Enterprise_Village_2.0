Imports System.IO
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Drawing

Public Class Closed_Business_Checks
	Inherits System.Web.UI.Page
	Dim sqlserver As String = System.Configuration.ConfigurationManager.AppSettings("EV_sfp").ToString
	Dim sqldatabase As String = System.Configuration.ConfigurationManager.AppSettings("EV_DB").ToString
	Dim sqluser As String = System.Configuration.ConfigurationManager.AppSettings("db_user").ToString
	Dim sqlpassword As String = System.Configuration.ConfigurationManager.AppSettings("db_password").ToString
	Dim con As New SqlConnection
	Dim cmd As New SqlCommand
	Dim dr As SqlDataReader
	Dim connection_string As String = "Server=" & sqlserver & ";database=" & sqldatabase & ";uid=" & sqluser & ";pwd=" & sqlpassword & ";Connection Timeout=20;"
	Dim BusinessData As New Class_BusinessData
	Dim VisitData As New Class_VisitData
	Dim VisitID As Integer = VisitData.GetVisitID

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Session("LoggedIn") <> "1" Then
			Response.Redirect(".\default.aspx")
		End If

		If Not (IsPostBack) Then
			'Assign current visit ID to hidden field
			If VisitID <> 0 Then
				currentVisitID_hf.Value = VisitID
			End If

			'Populating school header
			Dim header As New Class_SchoolHeader
			headerSchoolName_lbl.Text = header.GetSchoolHeader()

			'Populating Business DDL
			BusinessData.LoadBusinessNamesDDL(businessName_ddl)
		End If
	End Sub

	Sub LoadData()
		Dim BusinessName As String = businessName_ddl.SelectedValue
		Dim BusinessAddress As String = BusinessData.GetBusinessAddress(BusinessName)

		'Make check divs visible
		checksDiv_div.Visible = True

		'Check if business selected is city hall and reveal ditek checks button if so
		If BusinessName = "City Hall" Then
			cityHallDitek_btn.Visible = True
		End If

		'Assign business name, address, date to checks
		business_name1_lbl.Text = BusinessName
		business_name2_lbl.Text = BusinessName
		business_name3_lbl.Text = BusinessName
		business_name4_lbl.Text = BusinessName
		DD1BizName_lbl.Text = BusinessName
		DD2BizName_lbl.Text = BusinessName
		DD3BizName_lbl.Text = BusinessName
		DD4BizName_lbl.Text = BusinessName

		address1_lbl.Text = BusinessAddress
		address2_lbl.Text = BusinessAddress
		address3_lbl.Text = BusinessAddress
		address4_lbl.Text = BusinessAddress
		DD1Address_lbl.Text = BusinessAddress
		DD2Address_lbl.Text = BusinessAddress
		DD3Address_lbl.Text = BusinessAddress
		DD4Address_lbl.Text = BusinessAddress

		Label_date1_lbl.Text = DateTime.Now.ToString("MM/dd/yyyy")
		Label_date2_lbl.Text = DateTime.Now.ToString("MM/dd/yyyy")
		Label_date3_lbl.Text = DateTime.Now.ToString("MM/dd/yyyy")
		Label_date4_lbl.Text = DateTime.Now.ToString("MM/dd/yyyy")
		DD1Date_lbl.Text = DateTime.Now.ToString("MM/dd/yyyy")
		DD2Date_lbl.Text = DateTime.Now.ToString("MM/dd/yyyy")
		DD3Date_lbl.Text = DateTime.Now.ToString("MM/dd/yyyy")
		DD4Date_lbl.Text = DateTime.Now.ToString("MM/dd/yyyy")

		'Assign group 1 information
		Group1()

	End Sub

	Sub Group1()
		Dim BusinessName As String = businessName_ddl.SelectedValue
		Dim Operating1 As String
		Dim Operating2 As String
		Dim Operating3 As String
		Dim Operating4 As String
		Dim Name1() As String
		Dim Name2() As String
		Dim Name3() As String
		Dim Name4() As String
		Dim DollarAmount1 As String
		Dim DollarAmount2 As String
		Dim DollarAmount3 As String
		Dim DollarAmount4 As String
		Dim WrittenAmount1 As String
		Dim WrittenAmount2 As String
		Dim WrittenAmount3 As String
		Dim WrittenAmount4 As String
		Dim Memo1 As String
		Dim Memo2 As String
		Dim Memo3 As String
		Dim Memo4 As String
		Dim i As Integer

		'Check if loading payroll checks or operating checks
		If checkType_ddl.SelectedValue = "Payroll" Then

			'Assign pay to the order of, dollar amount, written amount, and memo for check 1
			checkName1_tb.Text = ""
			checkAmount1_lbl.Text = ""
			writtenAmount1_tb.Text = ""
			Memo1_tb.Text = "Payroll 1"

			'Check 2
			checkName2_tb.Text = ""
			checkAmount2_lbl.Text = ""
			writtenAmount2_tb.Text = ""
			Memo2_tb.Text = "Payroll 1"

			'Check 3
			checkName3_tb.Text = ""
			checkAmount3_lbl.Text = ""
			writtenAmount3_tb.Text = ""
			Memo3_tb.Text = "Payroll 1"

			'Check 4
			checkName4_tb.Text = ""
			checkAmount4_lbl.Text = ""
			writtenAmount4_tb.Text = ""
			Memo4_tb.Text = "Payroll 1"

			'Make direct deposit forms invisible, checks visible
			checksOverall_div.Visible = True
			ddSlips_div.Visible = False

		ElseIf checkType_ddl.SelectedValue = "Operating" Then

			'Make direct deposit forms invisible, checks visible
			checksOverall_div.Visible = True
			ddSlips_div.Visible = False

			'Get operating checks notes for first group of business selected
			Try
				con.ConnectionString = connection_string
				con.Open()
				cmd.CommandText = "SELECT operating1, operating2, operating3, operating4 FROM businessinfo WHERE businessName='" & BusinessName & "'"
				cmd.Connection = con
				dr = cmd.ExecuteReader

				While dr.Read()
					Operating1 = dr("operating1").ToString
					Operating2 = dr("operating2").ToString
					Operating3 = dr("operating3").ToString
					Operating4 = dr("operating4").ToString
				End While

				cmd.Dispose()
				con.Close()

			Catch
				error_lbl.Text = "Error in Group1(). Cannot get operating notes 1-4."
				Exit Sub
			End Try

			'Assign variables for operating business name, dollar amount, written amount, and memo for group 1
			Name1 = Operating1.Split("(")
			Name2 = Operating2.Split("(")
			Name3 = Operating3.Split("(")
			Name4 = Operating4.Split("(")

			'Get written amount
			If Name1(0) <> "Duke Energy" And Name1(0) <> Nothing Then
				i = Operating1.IndexOf("(")
				DollarAmount1 = Operating1.Substring(i + 1, Operating1.IndexOf("/", i + 1) - i - 1)

				WrittenAmount1 = WrittenAmount(DollarAmount1)
			End If

			If Name2(0) <> "Duke Energy" And Name2(0) <> Nothing Then
				i = Operating2.IndexOf("(")
				DollarAmount2 = Operating2.Substring(i + 1, Operating2.IndexOf("/", i + 1) - i - 1)

				WrittenAmount2 = WrittenAmount(DollarAmount2)
			End If

			If Name3(0) <> "Duke Energy" And Name3(0) <> Nothing Then
				i = Operating3.IndexOf("(")
				DollarAmount3 = Operating3.Substring(i + 1, Operating3.IndexOf("/", i + 1) - i - 1)

				WrittenAmount3 = WrittenAmount(DollarAmount3)
			End If

			If Name4(0) <> "Duke Energy" And Name4(0) <> Nothing Then
				i = Operating4.IndexOf("(")
				DollarAmount4 = Operating4.Substring(i + 1, Operating4.IndexOf("/", i + 1) - i - 1)

				WrittenAmount4 = WrittenAmount(DollarAmount4)
			End If

			'Get memos
			If Operating1 <> Nothing Then
				i = Operating1.IndexOf("/ ")
				Memo1 = Operating1.Substring(i + 1, Operating1.IndexOf(")", i + 1) - i - 1)
			End If

			If Operating2 <> Nothing Then
				i = Operating2.IndexOf("/ ")
				Memo2 = Operating2.Substring(i + 1, Operating2.IndexOf(")", i + 1) - i - 1)
			End If

			If Operating3 <> Nothing Then
				i = Operating3.IndexOf("/ ")
				Memo3 = Operating3.Substring(i + 1, Operating3.IndexOf(")", i + 1) - i - 1)
			End If

			If Operating4 <> Nothing Then
				i = Operating4.IndexOf("/ ")
				Memo4 = Operating4.Substring(i + 1, Operating4.IndexOf(")", i + 1) - i - 1)
			End If

			'Assign pay to the order of, dollar amount, written amount, and memo for check 1
			checkName1_tb.Text = Name1(0)
			checkAmount1_lbl.Text = DollarAmount1
			writtenAmount1_tb.Text = WrittenAmount1
			Memo1_tb.Text = Memo1

			'Check 2
			checkName2_tb.Text = Name2(0)
			checkAmount2_lbl.Text = DollarAmount2
			writtenAmount2_tb.Text = WrittenAmount2
			Memo2_tb.Text = Memo2

			'Check 3
			checkName3_tb.Text = Name3(0)
			checkAmount3_lbl.Text = DollarAmount3
			writtenAmount3_tb.Text = WrittenAmount3
			Memo3_tb.Text = Memo3

			'Check 4
			checkName4_tb.Text = Name4(0)
			checkAmount4_lbl.Text = DollarAmount4
			writtenAmount4_tb.Text = WrittenAmount4
			Memo4_tb.Text = Memo4

			'Check which checks are blank to put in the ditek check
			If BusinessName <> "City Hall" Then
				DitekCheck()
			End If
		End If

	End Sub

	Sub Group2()
		Dim BusinessName As String = businessName_ddl.SelectedValue
		Dim Operating5 As String
		Dim Operating6 As String
		Dim Operating7 As String
		Dim Operating8 As String
		Dim Name5() As String
		Dim Name6() As String
		Dim Name7() As String
		Dim Name8() As String
		Dim DollarAmount5 As String
		Dim DollarAmount6 As String
		Dim DollarAmount7 As String
		Dim DollarAmount8 As String
		Dim WrittenAmount5 As String
		Dim WrittenAmount6 As String
		Dim WrittenAmount7 As String
		Dim WrittenAmount8 As String
		Dim Memo5 As String
		Dim Memo6 As String
		Dim Memo7 As String
		Dim Memo8 As String
		Dim i As Integer

		'Check if check type is payroll or operating
		If checkType_ddl.SelectedValue = "Payroll" Then

			'Make direct deposit forms visible, checks invisible
			checksOverall_div.Visible = False
			ddSlips_div.Visible = True


		ElseIf checkType_ddl.SelectedValue = "Operating" Then

			'Make direct deposit forms invisible, checks visible
			checksOverall_div.Visible = True
			ddSlips_div.Visible = False

			'Get operating checks notes for first group of business selected
			Try
				con.ConnectionString = connection_string
				con.Open()
				cmd.CommandText = "SELECT operating5, operating6, operating7, operating8 FROM businessinfo WHERE businessName='" & BusinessName & "'"
				cmd.Connection = con
				dr = cmd.ExecuteReader

				While dr.Read()
					Operating5 = dr("operating5").ToString
					Operating6 = dr("operating6").ToString
					Operating7 = dr("operating7").ToString
					Operating8 = dr("operating8").ToString
				End While

				cmd.Dispose()
				con.Close()

			Catch
				error_lbl.Text = "Error in Group1(). Cannot get operating notes 5-8."
				Exit Sub
			End Try

			'Assign variables for operating business name, dollar amount, written amount, and memo for group 5
			Name5 = Operating5.Split("(")
			Name6 = Operating6.Split("(")
			Name7 = Operating7.Split("(")
			Name8 = Operating8.Split("(")

			'Get written amounts
			If Name5(0) <> "Duke Energy" And Name5(0) <> Nothing Then
				i = Operating5.IndexOf("(")
				DollarAmount5 = Operating5.Substring(i + 1, Operating5.IndexOf("/", i + 1) - i - 1)

				WrittenAmount5 = WrittenAmount(DollarAmount5)
			End If

			If Name6(0) <> "Duke Energy" And Name6(0) <> Nothing Then
				i = Operating6.IndexOf("(")
				DollarAmount6 = Operating6.Substring(i + 1, Operating6.IndexOf("/", i + 1) - i - 1)

				WrittenAmount6 = WrittenAmount(DollarAmount6)
			End If

			If Name7(0) <> "Duke Energy" And Name7(0) <> Nothing Then
				i = Operating7.IndexOf("(")
				DollarAmount7 = Operating7.Substring(i + 1, Operating7.IndexOf("/", i + 1) - i - 1)

				WrittenAmount7 = WrittenAmount(DollarAmount7)
			End If

			If Name8(0) <> "Duke Energy" And Name8(0) <> Nothing Then
				i = Operating8.IndexOf("(")
				DollarAmount8 = Operating8.Substring(i + 1, Operating8.IndexOf("/", i + 1) - i - 1)

				WrittenAmount8 = WrittenAmount(DollarAmount8)
			End If

			'Get memos
			If Operating5 <> Nothing Then
				i = Operating5.IndexOf("/ ")
				Memo5 = Operating5.Substring(i + 1, Operating5.IndexOf(")", i + 1) - i - 1)
			End If

			If Operating6 <> Nothing Then
				i = Operating6.IndexOf("/ ")
				Memo6 = Operating6.Substring(i + 1, Operating6.IndexOf(")", i + 1) - i - 1)
			End If

			If Operating7 <> Nothing Then
				i = Operating7.IndexOf("/ ")
				Memo7 = Operating7.Substring(i + 1, Operating7.IndexOf(")", i + 1) - i - 1)
			End If

			If Operating8 <> Nothing Then
				i = Operating8.IndexOf("/ ")
				Memo8 = Operating8.Substring(i + 1, Operating8.IndexOf(")", i + 1) - i - 1)
			End If

			'Assign pay to the order of, dollar amount, written amount, and memo for check 1
			checkName1_tb.Text = Name5(0)
			checkAmount1_lbl.Text = DollarAmount5
			writtenAmount1_tb.Text = WrittenAmount5
			Memo1_tb.Text = Memo5

			'Check 2
			checkName2_tb.Text = Name6(0)
			checkAmount2_lbl.Text = DollarAmount6
			writtenAmount2_tb.Text = WrittenAmount6
			Memo2_tb.Text = Memo6

			'Check 3
			checkName3_tb.Text = Name7(0)
			checkAmount3_lbl.Text = DollarAmount7
			writtenAmount3_tb.Text = WrittenAmount7
			Memo3_tb.Text = Memo7

			'Check 4
			checkName4_tb.Text = Name8(0)
			checkAmount4_lbl.Text = DollarAmount8
			writtenAmount4_tb.Text = WrittenAmount8
			Memo4_tb.Text = Memo8

			'Check which checks are blank to put in the ditek check
			If BusinessName <> "City Hall" Then
				DitekCheck()
			End If
		End If

	End Sub

	Sub Group3()
		Dim BusinessName As String = businessName_ddl.SelectedValue
		Dim Operating9 As String
		Dim Operating10 As String
		Dim Operating11 As String
		Dim Operating12 As String
		Dim Name9() As String
		Dim Name10() As String
		Dim Name11() As String
		Dim Name12() As String
		Dim DollarAmount9 As String
		Dim DollarAmount10 As String
		Dim DollarAmount11 As String
		Dim DollarAmount12 As String
		Dim WrittenAmount9 As String
		Dim WrittenAmount10 As String
		Dim WrittenAmount11 As String
		Dim WrittenAmount12 As String
		Dim Memo9 As String
		Dim Memo10 As String
		Dim Memo11 As String
		Dim Memo12 As String
		Dim i As Integer

		If checkType_ddl.SelectedValue = "Payroll" Then

			'Assign pay to the order of, dollar amount, written amount, and memo for check 1
			checkName1_tb.Text = ""
			checkAmount1_lbl.Text = ""
			writtenAmount1_tb.Text = ""
			Memo1_tb.Text = "Payroll 3"

			'Check 2
			checkName2_tb.Text = ""
			checkAmount2_lbl.Text = ""
			writtenAmount2_tb.Text = ""
			Memo2_tb.Text = "Payroll 3"

			'Check 3
			checkName3_tb.Text = ""
			checkAmount3_lbl.Text = ""
			writtenAmount3_tb.Text = ""
			Memo3_tb.Text = "Payroll 3"

			'Check 4
			checkName4_tb.Text = ""
			checkAmount4_lbl.Text = ""
			writtenAmount4_tb.Text = ""
			Memo4_tb.Text = "Payroll 3"

			'Make direct deposit forms invisible, checks visible
			checksOverall_div.Visible = True
			ddSlips_div.Visible = False

		ElseIf checkType_ddl.SelectedValue = "Operating" Then

			'Make direct deposit forms invisible, checks visible
			checksOverall_div.Visible = True
			ddSlips_div.Visible = False

			'Get operating checks notes for first group of business selected
			Try
				con.ConnectionString = connection_string
				con.Open()
				cmd.CommandText = "SELECT operating9, operating10, operating11, operating12 FROM businessinfo WHERE businessName='" & BusinessName & "'"
				cmd.Connection = con
				dr = cmd.ExecuteReader

				While dr.Read()
					Operating9 = dr("operating9").ToString
					Operating10 = dr("operating10").ToString
					Operating11 = dr("operating11").ToString
					Operating12 = dr("operating12").ToString
				End While

				cmd.Dispose()
				con.Close()

			Catch
				error_lbl.Text = "Error in Group3(). Cannot get operating notes 9-12."
				Exit Sub
			End Try

			'Assign variables for operating business name, dollar amount, written amount, and memo for group 3
			Name9 = Operating9.Split("(")
			Name10 = Operating10.Split("(")
			Name11 = Operating11.Split("(")
			Name12 = Operating12.Split("(")

			'Get written amounts
			If Name9(0) <> "Duke Energy " And Name9(0) <> Nothing Then
				i = Operating9.IndexOf("(")
				DollarAmount9 = Operating9.Substring(i + 1, Operating9.IndexOf("/", i + 1) - i - 1)

				WrittenAmount9 = WrittenAmount(DollarAmount9)
			End If

			If Name10(0) <> "Duke Energy " And Name10(0) <> Nothing Then
				i = Operating10.IndexOf("(")
				DollarAmount10 = Operating10.Substring(i + 1, Operating10.IndexOf("/", i + 1) - i - 1)

				WrittenAmount10 = WrittenAmount(DollarAmount10)
			End If

			If Name11(0) <> "Duke Energy " And Name11(0) <> Nothing Then
				i = Operating11.IndexOf("(")
				DollarAmount11 = Operating11.Substring(i + 1, Operating11.IndexOf("/", i + 1) - i - 1)

				WrittenAmount11 = WrittenAmount(DollarAmount11)
			End If

			If Name12(0) <> "Duke Energy " And Name12(0) <> Nothing Then
				i = Operating12.IndexOf("(")
				DollarAmount12 = Operating12.Substring(i + 1, Operating12.IndexOf("/", i + 1) - i - 1)

				WrittenAmount12 = WrittenAmount(DollarAmount12)
			End If

			'Get memos
			If Name9(0) <> Nothing Then
				i = Operating9.IndexOf("/ ")
				Memo9 = Operating9.Substring(i + 1, Operating9.IndexOf(")", i + 1) - i - 1)
			End If

			If Name10(0) <> Nothing Then
				i = Operating10.IndexOf("/ ")
				Memo10 = Operating10.Substring(i + 1, Operating10.IndexOf(")", i + 1) - i - 1)
			End If

			If Name11(0) <> Nothing Then
				i = Operating11.IndexOf("/ ")
				Memo11 = Operating11.Substring(i + 1, Operating11.IndexOf(")", i + 1) - i - 1)
			End If

			If Name12(0) <> Nothing Then
				i = Operating12.IndexOf("/ ")
				Memo12 = Operating12.Substring(i + 1, Operating12.IndexOf(")", i + 1) - i - 1)
			End If

			'Assign pay to the order of, dollar amount, written amount, and memo for check 1
			checkName1_tb.Text = Name9(0)
			checkAmount1_lbl.Text = DollarAmount9
			writtenAmount1_tb.Text = WrittenAmount9
			Memo1_tb.Text = Memo9

			'Check 2
			checkName2_tb.Text = Name10(0)
			checkAmount2_lbl.Text = DollarAmount10
			writtenAmount2_tb.Text = WrittenAmount10
			Memo2_tb.Text = Memo10

			'Check 3
			checkName3_tb.Text = Name11(0)
			checkAmount3_lbl.Text = DollarAmount11
			writtenAmount3_tb.Text = WrittenAmount11
			Memo3_tb.Text = Memo11

			'Check 4
			checkName4_tb.Text = Name12(0)
			checkAmount4_lbl.Text = DollarAmount12
			writtenAmount4_tb.Text = WrittenAmount12
			Memo4_tb.Text = Memo12

			'Check which checks are blank to put in the ditek check
			If BusinessName <> "City Hall" Then
				DitekCheck()
			End If

		End If

	End Sub

	Sub DitekCheck()

		'Check which check is blank
		If checkName1_tb.Text = Nothing Then
			checkName1_tb.Text = "Ditek"
			checkAmount1_lbl.Text = "$5.00"
			writtenAmount1_tb.Text = "FIVE AND 00/100"
			Memo1_tb.Text = "Supplies"
		ElseIf checkName2_tb.Text = Nothing Then
			checkName2_tb.Text = "Ditek"
			checkAmount2_lbl.Text = "$5.00"
			writtenAmount2_tb.Text = "FIVE AND 00/100"
			Memo2_tb.Text = "Supplies"
		ElseIf checkName3_tb.Text = Nothing Then
			checkName3_tb.Text = "Ditek"
			checkAmount3_lbl.Text = "$5.00"
			writtenAmount3_tb.Text = "FIVE AND 00/100"
			Memo3_tb.Text = "Supplies"
		ElseIf checkName4_tb.Text = Nothing Then
			checkName4_tb.Text = "Ditek"
			checkAmount4_lbl.Text = "$5.00"
			writtenAmount4_tb.Text = "FIVE AND 00/100"
			Memo4_tb.Text = "Supplies"
		End If

	End Sub

	Sub CityHallDitekChecks()

		'Check which check is blank
		checkName1_tb.Text = "Ditek"
			checkAmount1_lbl.Text = "$5.00"
			writtenAmount1_tb.Text = "FIVE AND 00/100"
			Memo1_tb.Text = "Supplies"

		checkName2_tb.Text = "Ditek"
			checkAmount2_lbl.Text = "$5.00"
			writtenAmount2_tb.Text = "FIVE AND 00/100"
			Memo2_tb.Text = "Supplies"

		checkName3_tb.Text = "Ditek"
			checkAmount3_lbl.Text = "$5.00"
			writtenAmount3_tb.Text = "FIVE AND 00/100"
			Memo3_tb.Text = "Supplies"

		checkName4_tb.Text = "Ditek"
			checkAmount4_lbl.Text = "$5.00"
			writtenAmount4_tb.Text = "FIVE AND 00/100"
			Memo4_tb.Text = "Supplies"

	End Sub

	Function WrittenAmount(DollarAmount As String)
		Dim ReturnWrittenAmount As String

		Select Case DollarAmount
			Case "$1.00 "
				ReturnWrittenAmount = "ONE AND 00/100"
			Case "$2.00 "
				ReturnWrittenAmount = "TWO AND 00/100"
			Case "$3.00 "
				ReturnWrittenAmount = "THREE AND 00/100"
			Case "$4.00 "
				ReturnWrittenAmount = "FOUR AND 00/100"
			Case "$5.00 "
				ReturnWrittenAmount = "FIVE AND 00/100"
			Case "$6.00 "
				ReturnWrittenAmount = "SIX AND 00/100"
			Case "$7.00 "
				ReturnWrittenAmount = "SEVEN AND 00/100"
			Case "$8.00 "
				ReturnWrittenAmount = "EIGHT AND 00/100"
			Case "$9.00 "
				ReturnWrittenAmount = "NINE AND 00/100"
			Case "$50.00 "
				ReturnWrittenAmount = "FIFTY AND 00/100"
		End Select

		Return ReturnWrittenAmount
	End Function

	Protected Sub businessName_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles businessName_ddl.SelectedIndexChanged
		If businessName_ddl.SelectedIndex <> 0 Then
			LoadData()
		End If
	End Sub

	Protected Sub print_btn_Click(sender As Object, e As EventArgs) Handles print_btn.Click
		Page.ClientScript.RegisterStartupScript(Me.GetType(), "Print", "Print();", True)
	End Sub

	Protected Sub group1_btn_Click(sender As Object, e As EventArgs) Handles group1_btn.Click
		Group1()
	End Sub

	Protected Sub group2_btn_Click(sender As Object, e As EventArgs) Handles group2_btn.Click
		Group2()
	End Sub

	Protected Sub group3_btn_Click(sender As Object, e As EventArgs) Handles group3_btn.Click
		Group3()
	End Sub

	Protected Sub cityHallDitek_btn_Click(sender As Object, e As EventArgs) Handles cityHallDitek_btn.Click
		CityHallDitekChecks()
	End Sub

	Protected Sub checkType_ddl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles checkType_ddl.SelectedIndexChanged
		LoadData()
	End Sub
End Class