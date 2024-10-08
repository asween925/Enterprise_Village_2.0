﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Print_Checks.aspx.vb" Inherits="Enterprise_Village_2._0.Print_Checks" %>

<!doctype html>
<html>
<head runat="server">

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">
    
    <title>Check Writing System</title>

    <link href="~/css/Styles.print.css" rel="stylesheet" media="print" type="text/css">
    <link href="css/Styles.Utility.css" rel="stylesheet" media="screen" type="text/css">
    <link rel="shortcut icon" type="image/jpg" href="~/media/EV_favicon_2.png" />
</head>

<body onafterprint="history.back();" onload="window.print();">
    <form autocomplete="off"  id="Online_Banking_Form" runat="server">
        <div id="site_wrap">
            <div class="header1 no-print">

                <img class="EV no-print" alt="Enterprise Village" src="../../Images/EV2.0_PCSB.png">
            </div>

            <div class="header2 no-print">
                <h2>Print Checks</h2>
            </div>

            <div class="header3 no-print">
                <asp:Image ID="BusLogo_img" runat="server" Class="Business_logo" />
            </div>

            <div class="main_boa">
                <div class="Account_area">
                    <asp:Label ID="error_lbl" runat="server"></asp:Label>

                    <%--Check 1--%>
                    <div class="Check_print Check_print1" runat="server" visible="false" id="check1_div">
                        <asp:Label ID="Checknumber1_lbl" runat="server" Text="37877" CssClass="Check_number"></asp:Label>
                        <asp:Label ID="business_name1_lbl" runat="server" Text="Business Name" CssClass="Check_business_name"></asp:Label>
                        <br />
                        <asp:Label ID="address1_lbl" runat="server" Text="Business Address" CssClass="Business_address"></asp:Label>
                        <asp:Label ID="Label_date1_lbl" runat="server" Text="1/01/2021" CssClass="Check_date" Font-Underline="True"></asp:Label>
                        <asp:Label ID="Label5" runat="server" Text="DATE" CssClass="Check_date_text"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="Label6" runat="server" Text="Pay to the order of:" CssClass="Pay_to_the"></asp:Label>
                        <asp:TextBox ID="checkName1_tb" runat="server" Text="" Width="440px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:TextBox ID="checkAmount1_lbl" runat="server" Text="" Width="55px" Style="text-align: center" CssClass="Check_textbox1 Amount_of_check" ReadOnly="True"></asp:TextBox>
                        <br />
                        <br />

                        <asp:TextBox ID="writtenAmount1_tb" runat="server" Text="" Width="630px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:Label ID="Label17" runat="server" Text="DOLLARS" CssClass="Dollars_text"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="label100" runat="server" Text="Memo" CssClass="Memo"></asp:Label>
                        <asp:TextBox ID="Memo1_tb" runat="server" Text="" Width="300px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:Label ID="Label19" runat="server" Text="__________________________________________________________" CssClass="Sign_line" Font-Underline="True"></asp:Label>

                        <br />
                        <p class="Bottom_check">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;001001 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 011900357 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 12345678 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        </p>
                    </div>

                    <%--check 2--%>
                    <div class="Check_print Check_print2" runat="server" visible="false" id="check2_div">
                        <asp:Label ID="Checknumber2_lbl" runat="server" Text="37877" CssClass="Check_number"></asp:Label>
                        <asp:Label ID="business_name2_lbl" runat="server" Text="Business Name" CssClass="Check_business_name"></asp:Label>
                        <br />
                        <asp:Label ID="address2_lbl" runat="server" Text="Business Address" CssClass="Business_address"></asp:Label>
                        <asp:Label ID="Label_date2_lbl" runat="server" Text="1/01/2021" CssClass="Check_date" Font-Underline="True"></asp:Label>
                        <asp:Label ID="Label7" runat="server" Text="DATE" CssClass="Check_date_text"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="Label8" runat="server" Text="Pay to the order of:" CssClass="Pay_to_the"></asp:Label>
                        <asp:TextBox ID="checkName2_tb" runat="server" Text="" Width="440px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:TextBox ID="checkAmount2_lbl" runat="server" Text="" Width="55px" Style="text-align: center" CssClass="Check_textbox1 Amount_of_check" ReadOnly="True"></asp:TextBox>
                        <br />
                        <br />

                        <asp:TextBox ID="writtenAmount2_tb" runat="server" Text="" Width="630px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:Label ID="Label9" runat="server" Text="DOLLARS" CssClass="Dollars_text"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="label10" runat="server" Text="Memo" CssClass="Memo"></asp:Label>
                        <asp:TextBox ID="Memo2_tb" runat="server" Text="" Width="300px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:Label ID="Label11" runat="server" Text="__________________________________________________________" CssClass="Sign_line" Font-Underline="True"></asp:Label>

                        <br />
                        <p class="Bottom_check">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;001001 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 011900357 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 12345678 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        </p>
                    </div>

                    <%--Check 3--%>
                    <div class="Check_print Check_print3" runat="server" visible="false" id="check3_div">
                        <asp:Label ID="Checknumber3_lbl" runat="server" Text="37877" CssClass="Check_number"></asp:Label>
                        <asp:Label ID="business_name3_lbl" runat="server" Text="Business Name" CssClass="Check_business_name"></asp:Label>
                        <br />
                        <asp:Label ID="address3_lbl" runat="server" Text="Business Address" CssClass="Business_address"></asp:Label>
                        <asp:Label ID="Label_date3_lbl" runat="server" Text="1/01/2021" CssClass="Check_date" Font-Underline="True"></asp:Label>
                        <asp:Label ID="Label16" runat="server" Text="DATE" CssClass="Check_date_text"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="Label18" runat="server" Text="Pay to the order of:" CssClass="Pay_to_the"></asp:Label>
                        <asp:TextBox ID="checkName3_tb" runat="server" Text="" Width="440px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:TextBox ID="checkAmount3_lbl" runat="server" Text="" Width="55px" Style="text-align: center" CssClass="Check_textbox1 Amount_of_check" ReadOnly="True"></asp:TextBox>
                        <br />
                        <br />

                        <asp:TextBox ID="writtenAmount3_tb" runat="server" Text="" Width="630px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:Label ID="Label20" runat="server" Text="DOLLARS" CssClass="Dollars_text"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="label21" runat="server" Text="Memo" CssClass="Memo"></asp:Label>
                        <asp:TextBox ID="Memo3_tb" runat="server" Text="" Width="300px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:Label ID="Label22" runat="server" Text="__________________________________________________________" CssClass="Sign_line" Font-Underline="True"></asp:Label>

                        <br />
                        <p class="Bottom_check">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;001001 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 011900357 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 12345678 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        </p>
                    </div>

                    <%--Check 4--%>
                    <div class="Check_print Check_print4" runat="server" visible="false" id="check4_div">
                        <asp:Label ID="Checknumber4_lbl" runat="server" Text="37877" CssClass="Check_number"></asp:Label>
                        <asp:Label ID="business_name4_lbl" runat="server" Text="Business Name" CssClass="Check_business_name"></asp:Label>
                        <br />
                        <asp:Label ID="address4_lbl" runat="server" Text="Business Address" CssClass="Business_address"></asp:Label>
                        <asp:Label ID="Label_date4_lbl" runat="server" Text="1/01/2021" CssClass="Check_date" Font-Underline="True"></asp:Label>
                        <asp:Label ID="Label27" runat="server" Text="DATE" CssClass="Check_date_text"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="Label28" runat="server" Text="Pay to the order of:" CssClass="Pay_to_the"></asp:Label>
                        <asp:TextBox ID="checkName4_tb" runat="server" Text="" Width="440px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:TextBox ID="checkAmount4_lbl" runat="server" Text="" Width="55px" Style="text-align: center" CssClass="Check_textbox1 Amount_of_check" ReadOnly="True"></asp:TextBox>
                        <br />
                        <br />

                        <asp:TextBox ID="writtenAmount4_tb" runat="server" Text="" Width="630px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:Label ID="Label29" runat="server" Text="DOLLARS" CssClass="Dollars_text"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="label30" runat="server" Text="Memo" CssClass="Memo"></asp:Label>
                        <asp:TextBox ID="Memo4_tb" runat="server" Text="" Width="300px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:Label ID="Label31" runat="server" Text="__________________________________________________________" CssClass="Sign_line" Font-Underline="True"></asp:Label>

                        <br />
                        <p class="Bottom_check">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;001001 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 011900357 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 12345678 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        </p>
                    </div>

                    <%--Check 5--%>
                    <div class="Check_print Check_print1" runat="server"  visible="false" id="check5_div">
                        <asp:Label ID="Checknumber5_lbl" runat="server" Text="37877" CssClass="Check_number"></asp:Label>
                        <asp:Label ID="business_name5_lbl" runat="server" Text="Business Name" CssClass="Check_business_name"></asp:Label>
                        <br />
                        <asp:Label ID="address5_lbl" runat="server" Text="Business Address" CssClass="Business_address"></asp:Label>
                        <asp:Label ID="label_date5_lbl" runat="server" Text="1/01/2021" CssClass="Check_date" Font-Underline="True"></asp:Label>
                        <asp:Label ID="Label12" runat="server" Text="DATE" CssClass="Check_date_text"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="Label13" runat="server" Text="Pay to the order of:" CssClass="Pay_to_the"></asp:Label>
                        <asp:TextBox ID="checkName5_tb" runat="server" Text="" Width="440px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:TextBox ID="checkAmount5_lbl" runat="server" Text="" Width="55px" Style="text-align: center" CssClass="Check_textbox1 Amount_of_check" ReadOnly="True"></asp:TextBox>
                        <br />
                        <br />

                        <asp:TextBox ID="writtenAmount5_tb" runat="server" Text="" Width="630px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:Label ID="Label14" runat="server" Text="DOLLARS" CssClass="Dollars_text"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="label15" runat="server" Text="Memo" CssClass="Memo"></asp:Label>
                        <asp:TextBox ID="Memo5_tb" runat="server" Text="" Width="300px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:Label ID="Label23" runat="server" Text="__________________________________________________________" CssClass="Sign_line" Font-Underline="True"></asp:Label>

                        <br />
                        <p class="Bottom_check">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;001001 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 011900357 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 12345678 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        </p>
                    </div>

                    <%--Check 6--%>
                    <div class="Check_print Check_print2" runat="server" visible="false" id="check6_div">
                        <asp:Label ID="Checknumber6_lbl" runat="server" Text="37877" CssClass="Check_number"></asp:Label>
                        <asp:Label ID="business_name6_lbl" runat="server" Text="Business Name" CssClass="Check_business_name"></asp:Label>
                        <br />
                        <asp:Label ID="address6_lbl" runat="server" Text="Business Address" CssClass="Business_address"></asp:Label>
                        <asp:Label ID="label_date6_lbl" runat="server" Text="1/01/2021" CssClass="Check_date" Font-Underline="True"></asp:Label>
                        <asp:Label ID="Label33" runat="server" Text="DATE" CssClass="Check_date_text"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="Label34" runat="server" Text="Pay to the order of:" CssClass="Pay_to_the"></asp:Label>
                        <asp:TextBox ID="checkName6_tb" runat="server" Text="" Width="440px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:TextBox ID="checkAmount6_lbl" runat="server" Text="" Width="55px" Style="text-align: center" CssClass="Check_textbox1 Amount_of_check" ReadOnly="True"></asp:TextBox>
                        <br />
                        <br />

                        <asp:TextBox ID="writtenAmount6_tb" runat="server" Text="" Width="630px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:Label ID="Label35" runat="server" Text="DOLLARS" CssClass="Dollars_text"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="label36" runat="server" Text="Memo" CssClass="Memo"></asp:Label>
                        <asp:TextBox ID="Memo6_tb" runat="server" Text="" Width="300px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:Label ID="Label37" runat="server" Text="__________________________________________________________" CssClass="Sign_line" Font-Underline="True"></asp:Label>

                        <br />
                        <p class="Bottom_check">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;001001 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 011900357 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 12345678 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        </p>
                    </div>

                    <%--Check 7--%>
                    <div class="Check_print Check_print3" runat="server" visible="false" id="check7_div">
                        <asp:Label ID="Checknumber7_lbl" runat="server" Text="37877" CssClass="Check_number"></asp:Label>
                        <asp:Label ID="business_name7_lbl" runat="server" Text="Business Name" CssClass="Check_business_name"></asp:Label>
                        <br />
                        <asp:Label ID="address7_lbl" runat="server" Text="Business Address" CssClass="Business_address"></asp:Label>
                        <asp:Label ID="label_date7_lbl" runat="server" Text="1/01/2021" CssClass="Check_date" Font-Underline="True"></asp:Label>
                        <asp:Label ID="Label42" runat="server" Text="DATE" CssClass="Check_date_text"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="Label43" runat="server" Text="Pay to the order of:" CssClass="Pay_to_the"></asp:Label>
                        <asp:TextBox ID="checkName7_tb" runat="server" Text="" Width="440px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:TextBox ID="checkAmount7_lbl" runat="server" Text="" Width="55px" Style="text-align: center" CssClass="Check_textbox1 Amount_of_check" ReadOnly="True"></asp:TextBox>
                        <br />
                        <br />

                        <asp:TextBox ID="writtenAmount7_tb" runat="server" Text="" Width="630px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:Label ID="Label44" runat="server" Text="DOLLARS" CssClass="Dollars_text"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="label45" runat="server" Text="Memo" CssClass="Memo"></asp:Label>
                        <asp:TextBox ID="Memo7_tb" runat="server" Text="" Width="300px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:Label ID="Label46" runat="server" Text="__________________________________________________________" CssClass="Sign_line" Font-Underline="True"></asp:Label>

                        <br />
                        <p class="Bottom_check">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;001001 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 011900357 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 12345678 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        </p>
                    </div>

                    <%--Check 8--%>
                    <div class="Check_print Check_print4" runat="server" visible="false" id="check8_div">
                        <asp:Label ID="Checknumber8_lbl" runat="server" Text="37877" CssClass="Check_number"></asp:Label>
                        <asp:Label ID="business_name8_lbl" runat="server" Text="Business Name" CssClass="Check_business_name"></asp:Label>
                        <br />
                        <asp:Label ID="address8_lbl" runat="server" Text="Business Address" CssClass="Business_address"></asp:Label>
                        <asp:Label ID="label_date8_lbl" runat="server" Text="1/01/2021" CssClass="Check_date" Font-Underline="True"></asp:Label>
                        <asp:Label ID="Label51" runat="server" Text="DATE" CssClass="Check_date_text"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="Label52" runat="server" Text="Pay to the order of:" CssClass="Pay_to_the"></asp:Label>
                        <asp:TextBox ID="checkName8_tb" runat="server" Text="" Width="440px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:TextBox ID="checkAmount8_lbl" runat="server" Text="" Width="55px" Style="text-align: center" CssClass="Check_textbox1 Amount_of_check" ReadOnly="True"></asp:TextBox>
                        <br />
                        <br />

                        <asp:TextBox ID="writtenAmount8_tb" runat="server" Text="" Width="630px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:Label ID="Label53" runat="server" Text="DOLLARS" CssClass="Dollars_text"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="label54" runat="server" Text="Memo" CssClass="Memo"></asp:Label>
                        <asp:TextBox ID="Memo8_tb" runat="server" Text="" Width="300px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:Label ID="Label55" runat="server" Text="__________________________________________________________" CssClass="Sign_line" Font-Underline="True"></asp:Label>

                        <br />
                        <p class="Bottom_check">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;001001 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 011900357 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 12345678 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        </p>
                    </div>

                    <%--Check 9--%>
                    <div class="Check_print Check_print1" runat="server" visible="false" id="check9_div">
                        <asp:Label ID="Checknumber9_lbl" runat="server" Text="37877" CssClass="Check_number"></asp:Label>
                        <asp:Label ID="business_name9_lbl" runat="server" Text="Business Name" CssClass="Check_business_name"></asp:Label>
                        <br />
                        <asp:Label ID="address9_lbl" runat="server" Text="Business Address" CssClass="Business_address"></asp:Label>
                        <asp:Label ID="label_date9_lbl" runat="server" Text="1/01/2021" CssClass="Check_date" Font-Underline="True"></asp:Label>
                        <asp:Label ID="Label60" runat="server" Text="DATE" CssClass="Check_date_text"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="Label61" runat="server" Text="Pay to the order of:" CssClass="Pay_to_the"></asp:Label>
                        <asp:TextBox ID="checkName9_tb" runat="server" Text="" Width="440px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:TextBox ID="checkAmount9_lbl" runat="server" Text="" Width="55px" Style="text-align: center" CssClass="Check_textbox1 Amount_of_check" ReadOnly="True"></asp:TextBox>
                        <br />
                        <br />

                        <asp:TextBox ID="writtenAmount9_tb" runat="server" Text="" Width="630px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:Label ID="Label62" runat="server" Text="DOLLARS" CssClass="Dollars_text"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="label63" runat="server" Text="Memo" CssClass="Memo"></asp:Label>
                        <asp:TextBox ID="Memo9_tb" runat="server" Text="" Width="300px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:Label ID="Label64" runat="server" Text="__________________________________________________________" CssClass="Sign_line" Font-Underline="True"></asp:Label>

                        <br />
                        <p class="Bottom_check">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;001001 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 011900357 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 12345678 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        </p>
                    </div>

                    <%--Check 10--%>
                    <div class="Check_print Check_print2" runat="server" visible="false" id="check10_div">
                        <asp:Label ID="Checknumber10_lbl" runat="server" Text="37877" CssClass="Check_number"></asp:Label>
                        <asp:Label ID="business_name10_lbl" runat="server" Text="Business Name" CssClass="Check_business_name"></asp:Label>
                        <br />
                        <asp:Label ID="address10_lbl" runat="server" Text="Business Address" CssClass="Business_address"></asp:Label>
                        <asp:Label ID="label_date10_lbl" runat="server" Text="1/01/2021" CssClass="Check_date" Font-Underline="True"></asp:Label>
                        <asp:Label ID="Label69" runat="server" Text="DATE" CssClass="Check_date_text"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="Label70" runat="server" Text="Pay to the order of:" CssClass="Pay_to_the"></asp:Label>
                        <asp:TextBox ID="checkName10_tb" runat="server" Text="" Width="440px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:TextBox ID="checkAmount10_lbl" runat="server" Text="" Width="55px" Style="text-align: center" CssClass="Check_textbox1 Amount_of_check" ReadOnly="True"></asp:TextBox>
                        <br />
                        <br />

                        <asp:TextBox ID="writtenAmount10_tb" runat="server" Text="" Width="630px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:Label ID="Label71" runat="server" Text="DOLLARS" CssClass="Dollars_text"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="label72" runat="server" Text="Memo" CssClass="Memo"></asp:Label>
                        <asp:TextBox ID="Memo10_tb" runat="server" Text="" Width="300px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:Label ID="Label73" runat="server" Text="__________________________________________________________" CssClass="Sign_line" Font-Underline="True"></asp:Label>

                        <br />
                        <p class="Bottom_check">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;001001 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 011900357 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 12345678 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        </p>
                    </div>

                    <%--Check 11--%>
                    <div class="Check_print Check_print3" runat="server" visible="false" id="check11_div">
                        <asp:Label ID="Checknumber11_lbl" runat="server" Text="37877" CssClass="Check_number"></asp:Label>
                        <asp:Label ID="business_name11_lbl" runat="server" Text="Business Name" CssClass="Check_business_name"></asp:Label>
                        <br />
                        <asp:Label ID="address11_lbl" runat="server" Text="Business Address" CssClass="Business_address"></asp:Label>
                        <asp:Label ID="label_date11_lbl" runat="server" Text="1/01/2021" CssClass="Check_date" Font-Underline="True"></asp:Label>
                        <asp:Label ID="Label78" runat="server" Text="DATE" CssClass="Check_date_text"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="Label79" runat="server" Text="Pay to the order of:" CssClass="Pay_to_the"></asp:Label>
                        <asp:TextBox ID="checkName11_tb" runat="server" Text="" Width="440px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:TextBox ID="checkAmount11_lbl" runat="server" Text="" Width="55px" Style="text-align: center" CssClass="Check_textbox1 Amount_of_check" ReadOnly="True"></asp:TextBox>
                        <br />
                        <br />

                        <asp:TextBox ID="writtenAmount11_tb" runat="server" Text="" Width="630px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:Label ID="Label80" runat="server" Text="DOLLARS" CssClass="Dollars_text"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="label81" runat="server" Text="Memo" CssClass="Memo"></asp:Label>
                        <asp:TextBox ID="Memo11_tb" runat="server" Text="" Width="300px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:Label ID="Label82" runat="server" Text="__________________________________________________________" CssClass="Sign_line" Font-Underline="True"></asp:Label>

                        <br />
                        <p class="Bottom_check">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;001001 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 011900357 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 12345678 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        </p>
                    </div>

                    <%--Check 12--%>
                    <div class="Check_print Check_print4" runat="server" visible="false" id="check12_div">
                        <asp:Label ID="Checknumber12_lbl" runat="server" Text="37877" CssClass="Check_number"></asp:Label>
                        <asp:Label ID="business_name12_lbl" runat="server" Text="Business Name" CssClass="Check_business_name"></asp:Label>
                        <br />
                        <asp:Label ID="address12_lbl" runat="server" Text="Business Address" CssClass="Business_address"></asp:Label>
                        <asp:Label ID="label_date12_lbl" runat="server" Text="1/01/2021" CssClass="Check_date" Font-Underline="True"></asp:Label>
                        <asp:Label ID="Label87" runat="server" Text="DATE" CssClass="Check_date_text"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="Label88" runat="server" Text="Pay to the order of:" CssClass="Pay_to_the"></asp:Label>
                        <asp:TextBox ID="checkName12_tb" runat="server" Text="" Width="440px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:TextBox ID="checkAmount12_lbl" runat="server" Text="" Width="55px" Style="text-align: center" CssClass="Check_textbox1 Amount_of_check" ReadOnly="True"></asp:TextBox>
                        <br />
                        <br />

                        <asp:TextBox ID="writtenAmount12_tb" runat="server" Text="" Width="630px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:Label ID="Label89" runat="server" Text="DOLLARS" CssClass="Dollars_text"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="label90" runat="server" Text="Memo" CssClass="Memo"></asp:Label>
                        <asp:TextBox ID="Memo12_tb" runat="server" Text="" Width="300px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:Label ID="Label91" runat="server" Text="__________________________________________________________" CssClass="Sign_line" Font-Underline="True"></asp:Label>

                        <br />
                        <p class="Bottom_check">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;001001 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 011900357 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 12345678 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        </p>
                    </div>

                    <%--Check 13--%>
                    <div class="Check_print Check_print1" runat="server" visible="false" id="check13_div">
                        <asp:Label ID="Checknumber13_lbl" runat="server" Text="37877" CssClass="Check_number"></asp:Label>
                        <asp:Label ID="business_name13_lbl" runat="server" Text="Business Name" CssClass="Check_business_name"></asp:Label>
                        <br />
                        <asp:Label ID="address13_lbl" runat="server" Text="Business Address" CssClass="Business_address"></asp:Label>
                        <asp:Label ID="label_date13_lbl" runat="server" Text="1/01/2021" CssClass="Check_date" Font-Underline="True"></asp:Label>
                        <asp:Label ID="Label96" runat="server" Text="DATE" CssClass="Check_date_text"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="Label97" runat="server" Text="Pay to the order of:" CssClass="Pay_to_the"></asp:Label>
                        <asp:TextBox ID="checkName13_tb" runat="server" Text="" Width="440px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:TextBox ID="checkAmount13_lbl" runat="server" Text="" Width="55px" Style="text-align: center" CssClass="Check_textbox1 Amount_of_check" ReadOnly="True"></asp:TextBox>
                        <br />
                        <br />

                        <asp:TextBox ID="writtenAmount13_tb" runat="server" Text="" Width="630px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:Label ID="Label98" runat="server" Text="DOLLARS" CssClass="Dollars_text"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="label99" runat="server" Text="Memo" CssClass="Memo"></asp:Label>
                        <asp:TextBox ID="Memo13_tb" runat="server" Text="" Width="300px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:Label ID="Label101" runat="server" Text="__________________________________________________________" CssClass="Sign_line" Font-Underline="True"></asp:Label>

                        <br />
                        <p class="Bottom_check">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;001001 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 011900357 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 12345678 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        </p>
                    </div>

                    <%--Check 14--%>
                    <div class="Check_print Check_print2" runat="server" visible="false" id="check14_div">
                        <asp:Label ID="Checknumber14_lbl" runat="server" Text="37877" CssClass="Check_number"></asp:Label>
                        <asp:Label ID="business_name14_lbl" runat="server" Text="Business Name" CssClass="Check_business_name"></asp:Label>
                        <br />
                        <asp:Label ID="address14_lbl" runat="server" Text="Business Address" CssClass="Business_address"></asp:Label>
                        <asp:Label ID="label_date14_lbl" runat="server" Text="1/01/2021" CssClass="Check_date" Font-Underline="True"></asp:Label>
                        <asp:Label ID="Label106" runat="server" Text="DATE" CssClass="Check_date_text"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="Label107" runat="server" Text="Pay to the order of:" CssClass="Pay_to_the"></asp:Label>
                        <asp:TextBox ID="checkName14_tb" runat="server" Text="" Width="440px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:TextBox ID="checkAmount14_lbl" runat="server" Text="" Width="55px" Style="text-align: center" CssClass="Check_textbox1 Amount_of_check" ReadOnly="True"></asp:TextBox>
                        <br />
                        <br />

                        <asp:TextBox ID="writtenAmount14_tb" runat="server" Text="" Width="630px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:Label ID="Label108" runat="server" Text="DOLLARS" CssClass="Dollars_text"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="label109" runat="server" Text="Memo" CssClass="Memo"></asp:Label>
                        <asp:TextBox ID="Memo14_tb" runat="server" Text="" Width="300px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:Label ID="Label110" runat="server" Text="__________________________________________________________" CssClass="Sign_line" Font-Underline="True"></asp:Label>

                        <br />
                        <p class="Bottom_check">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;001001 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 011900357 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 12345678 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        </p>
                    </div>

                    <%--Check 15--%>
                    <div class="Check_print Check_print3" runat="server" visible="false" id="check15_div">
                        <asp:Label ID="Checknumber15_lbl" runat="server" Text="37877" CssClass="Check_number"></asp:Label>
                        <asp:Label ID="business_name15_lbl" runat="server" Text="Business Name" CssClass="Check_business_name"></asp:Label>
                        <br />
                        <asp:Label ID="address15_lbl" runat="server" Text="Business Address" CssClass="Business_address"></asp:Label>
                        <asp:Label ID="label_date15_lbl" runat="server" Text="1/01/2021" CssClass="Check_date" Font-Underline="True"></asp:Label>
                        <asp:Label ID="Label115" runat="server" Text="DATE" CssClass="Check_date_text"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="Label116" runat="server" Text="Pay to the order of:" CssClass="Pay_to_the"></asp:Label>
                        <asp:TextBox ID="checkName15_tb" runat="server" Text="" Width="440px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:TextBox ID="checkAmount15_lbl" runat="server" Text="" Width="55px" Style="text-align: center" CssClass="Check_textbox1 Amount_of_check" ReadOnly="True"></asp:TextBox>
                        <br />
                        <br />

                        <asp:TextBox ID="writtenAmount15_tb" runat="server" Text="" Width="630px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:Label ID="Label117" runat="server" Text="DOLLARS" CssClass="Dollars_text"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="label118" runat="server" Text="Memo" CssClass="Memo"></asp:Label>
                        <asp:TextBox ID="Memo15_tb" runat="server" Text="" Width="300px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:Label ID="Label119" runat="server" Text="__________________________________________________________" CssClass="Sign_line" Font-Underline="True"></asp:Label>

                        <br />
                        <p class="Bottom_check">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;001001 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 011900357 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 12345678 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        </p>
                    </div>

                    <%--Check 16--%>
                    <div class="Check_print Check_print4" runat="server" visible="false" id="check16_div">
                        <asp:Label ID="Checknumber16_lbl" runat="server" Text="37877" CssClass="Check_number"></asp:Label>
                        <asp:Label ID="business_name16_lbl" runat="server" Text="Business Name" CssClass="Check_business_name"></asp:Label>
                        <br />
                        <asp:Label ID="address16_lbl" runat="server" Text="Business Address" CssClass="Business_address"></asp:Label>
                        <asp:Label ID="label_date16_lbl" runat="server" Text="1/01/2021" CssClass="Check_date" Font-Underline="True"></asp:Label>
                        <asp:Label ID="Label124" runat="server" Text="DATE" CssClass="Check_date_text"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="Label125" runat="server" Text="Pay to the order of:" CssClass="Pay_to_the"></asp:Label>
                        <asp:TextBox ID="checkName16_tb" runat="server" Text="" Width="440px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:TextBox ID="checkAmount16_lbl" runat="server" Text="" Width="55px" Style="text-align: center" CssClass="Check_textbox1 Amount_of_check" ReadOnly="True"></asp:TextBox>
                        <br />
                        <br />

                        <asp:TextBox ID="writtenAmount16_tb" runat="server" Text="" Width="630px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:Label ID="Label126" runat="server" Text="DOLLARS" CssClass="Dollars_text"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="label127" runat="server" Text="Memo" CssClass="Memo"></asp:Label>
                        <asp:TextBox ID="Memo16_tb" runat="server" Text="" Width="300px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
                        <asp:Label ID="Label128" runat="server" Text="__________________________________________________________" CssClass="Sign_line" Font-Underline="True"></asp:Label>

                        <br />
                        <p class="Bottom_check">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;001001 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 011900357 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 12345678 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        </p>
                    </div>
                </div>
            </div>

            <div class="second no-print">
            </div>

            <div class="footer1 no-print">
                <p>Business Cost</p>
                <img class="icon1" src="images/Icons/noun_Excitement_267.png" width="70" height="76" alt="computer" />
            </div>

            <div class="footer2 no-print">
                <p>Checks Report</p>
                <img class="icon1" src="images/Icons/noun_Computer_216.png" width="70" height="67" alt="computer" /><br>
            </div>



            <div class="footer3 no-print">
                <asp:HiddenField ID="visitdate_hf" runat="server" />
                
            </div>

            <i onload="javascript:PrintPayrollChecks();"></i>


        </div>
        <script src="../../Scripts.js"></script>
        <asp:DropDownList CssClass="ddl" ID="checkID_ddl" runat="server" Visible="false"></asp:DropDownList>
                <asp:Label ID="payrollGroup_lbl" runat="server" Visible="false"></asp:Label>
    </form>
</body>
</html>
