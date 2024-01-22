<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Closed_Business_Checks.aspx.vb" Inherits="Enterprise_Village_2._0.Closed_Business_Checks" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>EV 2.0 - Closed Business Checks</title>

    <link href="css/Styles.updated.css" rel="stylesheet" media="screen" type="text/css">
    <link href="css/Styles.print.css" rel="stylesheet" media="print" type="text/css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <link rel="shortcut icon" type="image/png" href="media/EV_favicon_2.png" />

    <script src="https://code.jquery.com/jquery-1.10.2.js"></script>
</head>

<body>
    <form id="EMS_Form" runat="server">

        <%--Header information--%>
        <header class="headerTop no-print"><a style="float: left; padding-top: 2px;">Enterprise Village 2.0</a><a style="float: right; padding-right: 30px; padding-top: 2px;"><asp:Label ID="headerSchoolName_lbl" Text="School Name Here" runat="server"></asp:Label></a></header>

        <%--Navigation bar--%>
        <div id="nav-placeholder">
        </div>

        <script>
            $(function () {
                $("#nav-placeholder").load("nav.html");
            });
        </script>

        <%--Content--%>
        <div class="content">
            <h2 class="h2 no-print">Closed Business Checks</h2>
            <h3 class="no-print">This page allows you to print out the operating checks of businesses that are closed for the day.
            </h3>
            <p class="no-print">Business Name:</p>
            <asp:DropDownList ID="businessName_ddl" runat="server" CssClass="ddl no-print" AutoPostBack="true"></asp:DropDownList>&ensp;<asp:Label ID="error_lbl" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="Red"></asp:Label>

            <%-----Check Div-----%>
            <div id="checksDiv_div" runat="server" visible="false">
                <p class="no-print">Check Type:</p>
                <asp:DropDownList ID="checkType_ddl" runat="server" CssClass="ddl no-print" AutoPostBack="true">
                    <asp:ListItem>Payroll</asp:ListItem>
                    <asp:ListItem>Operating</asp:ListItem>
                </asp:DropDownList>
                <br class="no-print" />
                <br class="no-print" />
                <asp:Button ID="group1_btn" runat="server" Text="Show Group 1" CssClass="button3 no-print" style="margin-right: 5px;" /><asp:Button ID="group2_btn" runat="server" Text="Show Group 2" CssClass="button3 no-print" /><asp:Button ID="group3_btn" runat="server" Text="Show Group 3" CssClass="button3 no-print" /><asp:Button ID="cityHallDitek_btn" runat="server" Text="Show Ditek Checks" CssClass="button3 no-print" Visible="false" /><a class="no-print">|</a><asp:Button ID="print_btn" runat="server" Text="Print" CssClass="button3 no-print" />
                <br class="no-print" /><br class="no-print" />                  

                <%--Checks--%>
                <div id="checksOverall_div" runat="server" visible="true">

                    <%--Check 1--%>
                    <div class="Closed_Checks Closed_Checks_Print1" runat="server" visible="true" id="check1_div">
                        <asp:Label ID="Checknumber1_lbl" runat="server" Text="37877" CssClass="Closed_Checks_Check_Number"></asp:Label>
                        <asp:Label ID="business_name1_lbl" runat="server" Text="Business Name" CssClass="Closed_Checks_Check_Business_Name"></asp:Label>
                        <br />
                        <asp:Label ID="address1_lbl" runat="server" Text="Business Address" CssClass="Closed_Checks_Business_Address"></asp:Label>
                        <asp:Label ID="Label_date1_lbl" runat="server" Text="1/01/2021" CssClass="Closed_Checks_Check_Date" Font-Underline="True"></asp:Label>
                        <asp:Label ID="Label5" runat="server" Text="DATE" CssClass="Closed_Checks_Check_Date_Text"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="Label6" runat="server" Text="Pay to the order of:" CssClass="Closed_Checks_Pay_To_The"></asp:Label>
                        <asp:TextBox ID="checkName1_tb" runat="server" Text="" CssClass="Closed_Checks_Student_Name textbox Closed_Checks_Student_Name" ReadOnly="false"></asp:TextBox>
                        <asp:TextBox ID="checkAmount1_lbl" runat="server" Text="" Width="55px" Style="text-align: center" CssClass="Closed_Checks_Amount_Of_Check textbox" ReadOnly="false"></asp:TextBox>
                        <br />
                        <br />

                        <asp:TextBox ID="writtenAmount1_tb" runat="server" Text="" CssClass="Closed_Checks_Written_Amount textbox Closed_Checks_Written_Amount" ReadOnly="false"></asp:TextBox>
                        <asp:Label ID="Label17" runat="server" Text="DOLLARS" CssClass="Closed_Checks_Dollars_Text"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="label100" runat="server" Text="Memo" CssClass="Closed_Checks_Memo"></asp:Label>
                        <asp:TextBox ID="Memo1_tb" runat="server" Text="" CssClass="Closed_Checks_Memo_Text textbox Closed_Checks_Memo_Text" ReadOnly="false"></asp:TextBox>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~\media\Leslie%20signature.png" CssClass="Closed_Checks_Signature_Image Closed_Checks_Signature_Image_Print" ></asp:Image>
                        <asp:Label ID="Label19" runat="server" Text="__________________________________________________________" CssClass="Closed_Checks_Sign_Line" Font-Underline="True"></asp:Label>

                        <br />
                        <p class="Closed_Checks_Bottom_Check">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;001001 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     011900357 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     12345678 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        </p>
                    </div>
                    <br />
                    <br class="no-print" />

                    <%--check 2--%>
                    <div class="Closed_Checks Closed_Checks_Print2" runat="server" visible="true" id="check2_div">
                        <asp:Label ID="Checknumber2_lbl" runat="server" Text="37877" CssClass="Closed_Checks_Check_Number"></asp:Label>
                        <asp:Label ID="business_name2_lbl" runat="server" Text="Business Name" CssClass="Closed_Checks_Check_Business_Name"></asp:Label>
                        <br />
                        <asp:Label ID="address2_lbl" runat="server" Text="Business Address" CssClass="Closed_Checks_Business_Address"></asp:Label>
                        <asp:Label ID="Label_date2_lbl" runat="server" Text="1/01/2021" CssClass="Closed_Checks_Check_Date" Font-Underline="True"></asp:Label>
                        <asp:Label ID="Label7" runat="server" Text="DATE" CssClass="Closed_Checks_Check_Date_Text"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="Label8" runat="server" Text="Pay to the order of:" CssClass="Closed_Checks_Pay_To_The"></asp:Label>
                        <asp:TextBox ID="checkName2_tb" runat="server" Text="" CssClass="Closed_Checks_Student_Name textbox Closed_Checks_Student_Name" ReadOnly="false"></asp:TextBox>
                        <asp:TextBox ID="checkAmount2_lbl" runat="server" Text="" Width="55px" Style="text-align: center" CssClass="Closed_Checks_Amount_Of_Check textbox" ReadOnly="false"></asp:TextBox>
                        <br />
                        <br />

                        <asp:TextBox ID="writtenAmount2_tb" runat="server" Text="" CssClass="Closed_Checks_Written_Amount textbox Closed_Checks_Written_Amount" ReadOnly="false"></asp:TextBox>
                        <asp:Label ID="Label9" runat="server" Text="DOLLARS" CssClass="Closed_Checks_Dollars_Text"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="label10" runat="server" Text="Memo" CssClass="Closed_Checks_Memo"></asp:Label>
                        <asp:TextBox ID="Memo2_tb" runat="server" Text="" CssClass="Closed_Checks_Memo_Text textbox Closed_Checks_Memo_Text" ReadOnly="false"></asp:TextBox>
                        <asp:Image ID="signature_img" runat="server" ImageUrl="~\media\Leslie%20signature.png" CssClass="Closed_Checks_Signature_Image Closed_Checks_Signature_Image_Print" ></asp:Image>
                        <asp:Label ID="Label11" runat="server" Text="__________________________________________________________" CssClass="Closed_Checks_Sign_Line" Font-Underline="True"></asp:Label>

                        <br />
                        <p class="Closed_Checks_Bottom_Check">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;001001 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     011900357 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     12345678 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        </p>
                    </div>
                    <br />
                    <br class="no-print" />

                    <%--Check 3--%>
                    <div class="Closed_Checks Closed_Checks_Print3" runat="server" visible="true" id="check3_div">
                        <asp:Label ID="Checknumber3_lbl" runat="server" Text="37877" CssClass="Closed_Checks_Check_Number"></asp:Label>
                        <asp:Label ID="business_name3_lbl" runat="server" Text="Business Name" CssClass="Closed_Checks_Check_Business_Name"></asp:Label>
                        <br />
                        <asp:Label ID="address3_lbl" runat="server" Text="Business Address" CssClass="Closed_Checks_Business_Address"></asp:Label>
                        <asp:Label ID="Label_date3_lbl" runat="server" Text="1/01/2021" CssClass="Closed_Checks_Check_Date" Font-Underline="True"></asp:Label>
                        <asp:Label ID="Label16" runat="server" Text="DATE" CssClass="Closed_Checks_Check_Date_Text"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="Label18" runat="server" Text="Pay to the order of:" CssClass="Closed_Checks_Pay_To_The"></asp:Label>
                        <asp:TextBox ID="checkName3_tb" runat="server" Text="" CssClass="Closed_Checks_Student_Name textbox Closed_Checks_Student_Name" ReadOnly="false"></asp:TextBox>
                        <asp:TextBox ID="checkAmount3_lbl" runat="server" Text="" Width="55px" Style="text-align: center" CssClass="Closed_Checks_Amount_Of_Check textbox" ReadOnly="false"></asp:TextBox>
                        <br />
                        <br />

                        <asp:TextBox ID="writtenAmount3_tb" runat="server" Text="" CssClass="Closed_Checks_Written_Amount textbox Closed_Checks_Written_Amount" ReadOnly="false"></asp:TextBox>
                        <asp:Label ID="Label20" runat="server" Text="DOLLARS" CssClass="Closed_Checks_Dollars_Text"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="label21" runat="server" Text="Memo" CssClass="Closed_Checks_Memo"></asp:Label>
                        <asp:TextBox ID="Memo3_tb" runat="server" Text="" CssClass="Closed_Checks_Memo_Text textbox Closed_Checks_Memo_Text" ReadOnly="false"></asp:TextBox>
                        <asp:Image ID="Image2" runat="server" ImageUrl="~\media\Leslie%20signature.png" CssClass="Closed_Checks_Signature_Image Closed_Checks_Signature_Image_Print" ></asp:Image>
                        <asp:Label ID="Label22" runat="server" Text="__________________________________________________________" CssClass="Closed_Checks_Sign_Line" Font-Underline="True"></asp:Label>

                        <br />
                        <p class="Closed_Checks_Bottom_Check">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;001001 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     011900357 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     12345678 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        </p>
                    </div>
                    <br />
                    <br class="no-print" />

                    <%--Check 4--%>
                    <div class="Closed_Checks Closed_Checks_Print4" runat="server" visible="true" id="check4_div">
                        <asp:Label ID="Checknumber4_lbl" runat="server" Text="37877" CssClass="Closed_Checks_Check_Number"></asp:Label>
                        <asp:Label ID="business_name4_lbl" runat="server" Text="Business Name" CssClass="Closed_Checks_Check_Business_Name"></asp:Label>
                        <br />
                        <asp:Label ID="address4_lbl" runat="server" Text="Business Address" CssClass="Closed_Checks_Business_Address"></asp:Label>
                        <asp:Label ID="Label_date4_lbl" runat="server" Text="1/01/2021" CssClass="Closed_Checks_Check_Date" Font-Underline="True"></asp:Label>
                        <asp:Label ID="Label27" runat="server" Text="DATE" CssClass="Closed_Checks_Check_Date_Text"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="Label28" runat="server" Text="Pay to the order of:" CssClass="Closed_Checks_Pay_To_The"></asp:Label>
                        <asp:TextBox ID="checkName4_tb" runat="server" Text="" CssClass="Closed_Checks_Student_Name textbox Closed_Checks_Student_Name" ReadOnly="false"></asp:TextBox>
                        <asp:TextBox ID="checkAmount4_lbl" runat="server" Text="" Width="55px" Style="text-align: center" CssClass="Closed_Checks_Amount_Of_Check textbox" ReadOnly="false"></asp:TextBox>
                        <br />
                        <br />

                        <asp:TextBox ID="writtenAmount4_tb" runat="server" Text="" CssClass="Closed_Checks_Written_Amount textbox Closed_Checks_Written_Amount" ReadOnly="false"></asp:TextBox>
                        <asp:Label ID="Label29" runat="server" Text="DOLLARS" CssClass="Closed_Checks_Dollars_Text"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="label30" runat="server" Text="Memo" CssClass="Closed_Checks_Memo"></asp:Label>
                        <asp:TextBox ID="Memo4_tb" runat="server" Text="" CssClass="Closed_Checks_Memo_Text textbox Closed_Checks_Memo_Text" ReadOnly="false"></asp:TextBox>
                        <asp:Image ID="Image3" runat="server" ImageUrl="~\media\Leslie%20signature.png" CssClass="Closed_Checks_Signature_Image Closed_Checks_Signature_Image_Print" ></asp:Image>
                        <asp:Label ID="Label31" runat="server" Text="__________________________________________________________" CssClass="Closed_Checks_Sign_Line" Font-Underline="True"></asp:Label>

    <%--                    <br class="no-print" />--%>
                        <p class="Closed_Checks_Bottom_Check">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;001001 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     011900357 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     12345678 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        </p>
                    </div>
                </div>
                
                <%--Direct Deposit--%>
                <div id="ddSlips_div" runat="server" visible="false">

                    <%--Slip 1--%>
                    <div class="Closed_Checks Closed_Checks_Print1" runat="server" visible="true" id="Div1">
                            <asp:Label ID="Label1" runat="server" Text="853452" CssClass="Closed_Checks_Check_Number"></asp:Label>
                            <asp:Label ID="DD1BizName_lbl" runat="server" Text="Business Name" CssClass="Closed_Checks_Check_Business_Name"></asp:Label>
                            <br />
                            <asp:Label ID="DD1Address_lbl" runat="server" Text="Business Address" CssClass="Closed_Checks_Business_Address"></asp:Label>
                            <asp:Label ID="DD1Date_lbl" runat="server" Text="1/01/2021" CssClass="Closed_Checks_Check_Date" Font-Underline="True"></asp:Label>
                            <asp:Label ID="Label12" runat="server" Text="DATE" CssClass="Closed_Checks_Check_Date_Text"></asp:Label>
                            <br />
                            <br />                       
                            <asp:Label ID="Label13" runat="server" Text="A DIRECT DEPOSIT FOR:" CssClass="Closed_Checks_Pay_To_The"></asp:Label>
                            <asp:TextBox ID="TextBox1" runat="server" Text="" Width="400px" CssClass="Closed_Checks_Student_Name textbox" ReadOnly="false"></asp:TextBox>
                            <br />
                            <asp:TextBox ID="TextBox2" runat="server" Text="" Width="580px" CssClass="Closed_Checks_Written_Amount textbox Closed_Checks_Written_Amount" ReadOnly="false"></asp:TextBox>
                            <br />
                            <asp:Label ID="label14" runat="server" Text="WAS DEPOSITED AT Achieva Credit Union" CssClass="Closed_Checks_Memo"></asp:Label>
                            <asp:TextBox ID="TextBox3" runat="server" Text="" Width="300px" CssClass="Closed_Checks_Memo_Text textbox Closed_Checks_Memo_Text" ReadOnly="True" Visible="false"></asp:TextBox>
                            <asp:Label ID="Label15" runat="server" Text="THIS IS NOT A CHECK" CssClass="Sign_line_DD"></asp:Label>
                            <br />
                            <asp:Label ID="Label23" runat="server" Text="NON-NEGOTIABLE" Font-Size="26px" CssClass="Closed_Checks_Sign_Line"></asp:Label>
                            <br />
                        </div>
                    <br />
                    <br class="no-print" />

                    <%--Slip 2--%>
                    <div class="Closed_Checks Closed_Checks_Print2" runat="server" visible="true" id="Div2">
                            <asp:Label ID="Label24" runat="server" Text="853452" CssClass="Closed_Checks_Check_Number"></asp:Label>
                            <asp:Label ID="DD2BizName_lbl" runat="server" Text="Business Name" CssClass="Closed_Checks_Check_Business_Name"></asp:Label>
                            <br />
                            <asp:Label ID="DD2Address_lbl" runat="server" Text="Business Address" CssClass="Closed_Checks_Business_Address"></asp:Label>
                            <asp:Label ID="DD2Date_lbl" runat="server" Text="1/01/2021" CssClass="Closed_Checks_Check_Date" Font-Underline="True"></asp:Label>
                            <asp:Label ID="Label33" runat="server" Text="DATE" CssClass="Closed_Checks_Check_Date_Text"></asp:Label>
                            <br />
                            <br />
                            <asp:Label ID="Label34" runat="server" Text="A DIRECT DEPOSIT FOR:" CssClass="Closed_Checks_Pay_To_The"></asp:Label>
                            <asp:TextBox ID="TextBox4" runat="server" Text="" Width="440px" CssClass="Closed_Checks_Student_Name textbox Closed_Checks_Student_Name" ReadOnly="false"></asp:TextBox>
                            <br />
                            <asp:TextBox ID="TextBox5" runat="server" Text="" Width="580px" CssClass="Closed_Checks_Written_Amount textbox Closed_Checks_Written_Amount" ReadOnly="false"></asp:TextBox>
                            <br />
                            <asp:Label ID="label35" runat="server" Text="WAS DEPOSITED AT Achieva Credit Union" CssClass="Closed_Checks_Memo"></asp:Label>
                            <asp:TextBox ID="TextBox6" runat="server" Text="" Width="300px" CssClass="Closed_Checks_Memo_Text textbox Closed_Checks_Memo_Text" ReadOnly="True" Visible="false"></asp:TextBox>
                            <asp:Label ID="Label36" runat="server" Text="THIS IS NOT A CHECK" CssClass="Sign_line_DD"></asp:Label>
                            <br />
                            <asp:Label ID="Label37" runat="server" Text="NON-NEGOTIABLE" Font-Size="26px" CssClass="Closed_Checks_Sign_Line"></asp:Label>
                            <br />
                        </div>
                    <br />
                    <br class="no-print" />

                    <%--Slip 3--%>
                    <div class="Closed_Checks Closed_Checks_Print3" runat="server" visible="true" id="Div3">
                            <asp:Label ID="Label38" runat="server" Text="853452" CssClass="Closed_Checks_Check_Number"></asp:Label>
                            <asp:Label ID="DD3BizName_lbl" runat="server" Text="Business Name" CssClass="Closed_Checks_Check_Business_Name"></asp:Label>
                            <br />
                            <asp:Label ID="DD3Address_lbl" runat="server" Text="Business Address" CssClass="Closed_Checks_Business_Address"></asp:Label>
                            <asp:Label ID="DD3Date_lbl" runat="server" Text="1/01/2021" CssClass="Closed_Checks_Check_Date" Font-Underline="True"></asp:Label>
                            <asp:Label ID="Label42" runat="server" Text="DATE" CssClass="Closed_Checks_Check_Date_Text"></asp:Label>
                            <br />
                            <br />
                            <asp:Label ID="Label43" runat="server" Text="A DIRECT DEPOSIT FOR:" CssClass="Closed_Checks_Pay_To_The"></asp:Label>
                            <asp:TextBox ID="TextBox7" runat="server" Text="" Width="440px" CssClass="Closed_Checks_Student_Name textbox Closed_Checks_Student_Name" ReadOnly="false"></asp:TextBox>
                            <br />
                            <asp:TextBox ID="TextBox8" runat="server" Text="" Width="580px" CssClass="Closed_Checks_Written_Amount textbox Closed_Checks_Written_Amount" ReadOnly="false"></asp:TextBox>
                            <br />
                            <asp:Label ID="label44" runat="server" Text="WAS DEPOSITED AT Achieva Credit Union" CssClass="Closed_Checks_Memo"></asp:Label>
                            <asp:TextBox ID="TextBox9" runat="server" Text="" Width="300px" CssClass="Closed_Checks_Memo_Text textbox Closed_Checks_Memo_Text" ReadOnly="True" Visible="false"></asp:TextBox>
                            <asp:Label ID="Label45" runat="server" Text="THIS IS NOT A CHECK" CssClass="Sign_line_DD"></asp:Label>
                            <br />
                            <asp:Label ID="Label46" runat="server" Text="NON-NEGOTIABLE" Font-Size="26px" CssClass="Closed_Checks_Sign_Line"></asp:Label>
                            <br />
                        </div>
                    <br />
                    <br class="no-print" />

                    <%--Slip 4--%>
                    <div class="Closed_Checks Closed_Checks_Print4" runat="server" visible="true" id="Div4">
                            <asp:Label ID="Label47" runat="server" Text="853452" CssClass="Closed_Checks_Check_Number"></asp:Label>
                            <asp:Label ID="DD4BizName_lbl" runat="server" Text="Business Name" CssClass="Closed_Checks_Check_Business_Name"></asp:Label>
                            <br />
                            <asp:Label ID="DD4Address_lbl" runat="server" Text="Business Address" CssClass="Closed_Checks_Business_Address"></asp:Label>
                            <asp:Label ID="DD4Date_lbl" runat="server" Text="1/01/2021" CssClass="Closed_Checks_Check_Date" Font-Underline="True"></asp:Label>
                            <asp:Label ID="Label51" runat="server" Text="DATE" CssClass="Closed_Checks_Check_Date_Text"></asp:Label>
                            <br />
                            <br />
                            <asp:Label ID="Label52" runat="server" Text="A DIRECT DEPOSIT FOR:" CssClass="Closed_Checks_Pay_To_The"></asp:Label>
                            <asp:TextBox ID="TextBox10" runat="server" Text="" Width="440px" CssClass="Closed_Checks_Student_Name textbox Closed_Checks_Student_Name" ReadOnly="false"></asp:TextBox>
                            <br />
                            <asp:TextBox ID="TextBox11" runat="server" Text="" Width="580px" CssClass="Closed_Checks_Written_Amount textbox Closed_Checks_Written_Amount" ReadOnly="false"></asp:TextBox>
                            <br />
                            <asp:Label ID="Label53" runat="server" Text="WAS DEPOSITED AT Achieva Credit Union" CssClass="Closed_Checks_Memo"></asp:Label>
                            <asp:TextBox ID="TextBox12" runat="server" Text="" Width="300px" CssClass="Closed_Checks_Memo_Text textbox Closed_Checks_Memo_Text" ReadOnly="True" Visible="false"></asp:TextBox>
                            <asp:Label ID="Label54" runat="server" Text="THIS IS NOT A CHECK" CssClass="Sign_line_DD"></asp:Label>
                            <br />
                            <asp:Label ID="Label55" runat="server" Text="NON-NEGOTIABLE" Font-Size="26px" CssClass="Closed_Checks_Sign_Line"></asp:Label>
                            <br />
                        </div>
                </div>

                
            </div>


            <%--<div id="schoolNotes_div" runat="server" visible="false">
                <asp:GridView ID="notes_dgv" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="true" AutoGenerateDeleteButton="true" DataKeyNames="ID" CellPadding="5" Height="50" AllowPaging="True" ShowHeaderWhenEmpty="True" Font-Size="Medium" Visible="true">
                    <AlternatingRowStyle BackColor="#99CCFF" />
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />
                        <asp:TemplateField HeaderText="School Name">
                            <ItemTemplate>
                                <asp:Label ID="schoolNameDGV_lbl" runat="server" Text='<%#Bind("schoolName") %>' Visible="false"></asp:Label>
                                <asp:DropDownList CssClass="ddl" ID="schoolNameDGV_ddl" runat="server" AutoPostBack="true" readonly="false"></asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Note">
                            <ItemTemplate>
                               <asp:TextBox ID="noteDGV_tb" runat="server" Width="250px" ReadOnly="false" Text='<%#Bind("note") %>' CssClass="textbox"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edited By">
                            <ItemTemplate>
                                <asp:Label ID="noteUserDGV_lbl" runat="server" Text='<%#Bind("noteUser") %>' Visible="true" ReadOnly="true"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Timestamp">
                            <ItemTemplate>
                                <asp:Label ID="noteTimestampDGV_lbl" runat="server" Text='<%#Bind("noteTimestamp") %>' Visible="true" ReadOnly="true"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>--%>
        </div>

        <asp:HiddenField ID="currentVisitID_hf" runat="server" />

        <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
        <script src="Scripts.js"></script>
        <script>
            /* Loop through all dropdown buttons to toggle between hiding and showing its dropdown content - This allows the user to have multiple dropdowns without any conflict */
            $(".sub-menu ul").hide();
            $(".sub-menu a").click(function () {
                $(this).parent(".sub-menu").children("ul").slideToggle("100");
                $(this).find(".right").toggleClass("fa-caret-up fa-caret-down");
            });
        </script>

        <asp:SqlDataSource ID="Review_sds" runat="server"></asp:SqlDataSource>
    </form>
</body>
</html>
