<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Ditek_Check.aspx.vb" Inherits="Enterprise_Village_2._0.Ditek_Check" %>

<!doctype html>
<html>
<head runat="server">

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">
    <title>Print Ditek Check</title>

    <link href="~/css/Styles.print.css" rel="stylesheet" media="print" type="text/css">
    <link href="css/Styles.Utility.css" rel="stylesheet" media="screen" type="text/css">
</head>

<body onload="window.print();" onafterprint="history.back();">
    <form autocomplete="off"  id="Online_Banking_Form" runat="server">
        <div id="site_wrap">
            <div class="header1 no-print">

                <img class="EV no-print" alt="Enterprise Village" src="../../Images/EV2.0_PCSB.png">
            </div>

            <div class="header2 no-print">
                <h2>Check Writing System</h2>
            </div>

            <div class="header3 no-print">
                <img class="business" alt="Business" src="media\Logos\Achieva\achieva.png">
            </div>

            <div class="main_boa">

                <div class="Account_area">

                    <%--Check 1--%>
                    <div class="Check_print Check_print1">
                        <asp:Label ID="Label1" runat="server" Text="37877" CssClass="Check_number"></asp:Label>
                        <asp:Label ID="Label2" runat="server" Text="Ditek" CssClass="Check_business_name"></asp:Label>
                        <br />
                        <asp:Label ID="Label3" runat="server" Text="123 Enterprise Ave" CssClass="Business_address"></asp:Label>
                        <asp:Label ID="Label_date1" runat="server" Text="1/01/2021" CssClass="Check_date" Font-Underline="True"></asp:Label>
                        <asp:Label ID="Label5" runat="server" Text="DATE" CssClass="Check_date_text"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="Label6" runat="server" Text="Pay to the order of:" CssClass="Pay_to_the"></asp:Label>
                        <asp:Label ID="Label8" runat="server" Text="Ditek____________________________________________________________" CssClass="Student_name Check_textbox" Font-Underline="false"></asp:Label>

                        <asp:TextBox ID="TextBox1" runat="server" Text="$5.00" Width="55px" CssClass="Check_textbox Amount_of_check"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="Label9" runat="server" Text="Five Dollars and 00/100__________________________________________________________________" CssClass="Check_amount_written Check_textbox" Font-Underline="false"></asp:Label>
                        <asp:Label ID="Label17" runat="server" Text="DOLLARS" CssClass="Dollars_text"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Memo" runat="server" Text="Memo" CssClass="Memo"></asp:Label>
                        <asp:Label ID="Label18" runat="server" Text="Supplies______________________________________" CssClass="Check_textbox Memo_text" Font-Underline="false"></asp:Label>
                        <asp:Label ID="Label19" runat="server" Text="__________________________________________________________" CssClass="Sign_line" Font-Underline="True"></asp:Label>
                        <br />
                        <p class="Bottom_check">
                                        001001 &nbsp;&nbsp;&nbsp;
                             011900357 &nbsp;&nbsp;&nbsp;
                             12345678 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        </p>
                    </div>

                    <%--Check 2--%>
                     <div id="check2" class="Check_print Check_print2" runat="server" visible="false">
                        <asp:Label ID="Label4" runat="server" Text="37877" CssClass="Check_number"></asp:Label>
                        <asp:Label ID="Label7" runat="server" Text="Ditek" CssClass="Check_business_name"></asp:Label>
                        <br />
                        <asp:Label ID="Label11" runat="server" Text="123 Enterprise Ave" CssClass="Business_address"></asp:Label>
                        <asp:Label ID="Label12" runat="server" Text="1/01/2021" CssClass="Check_date" Font-Underline="True"></asp:Label>
                        <asp:Label ID="Label13" runat="server" Text="DATE" CssClass="Check_date_text"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="Label14" runat="server" Text="Pay to the order of:" CssClass="Pay_to_the"></asp:Label>
                        <asp:Label ID="Label15" runat="server" Text="Ditek____________________________________________________________" CssClass="Student_name Check_textbox" Font-Underline="false"></asp:Label>

                        <asp:TextBox ID="TextBox2" runat="server" Text="$5.00" Width="55px" CssClass="Check_textbox Amount_of_check"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="Label16" runat="server" Text="Five Dollars and 00/100__________________________________________________________________" CssClass="Check_amount_written Check_textbox" Font-Underline="false"></asp:Label>
                        <asp:Label ID="Label20" runat="server" Text="DOLLARS" CssClass="Dollars_text"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Label21" runat="server" Text="Memo" CssClass="Memo"></asp:Label>
                        <asp:Label ID="Label22" runat="server" Text="PCU Supplies______________________________________" CssClass="Check_textbox Memo_text" Font-Underline="false"></asp:Label>
                        <asp:Label ID="Label23" runat="server" Text="______________________________________________________" CssClass="Sign_line" Font-Underline="True"></asp:Label>
                        <br />
                        <p class="Bottom_check">
                                        001001 &nbsp;&nbsp;&nbsp;
                             011900357 &nbsp;&nbsp;&nbsp;
                             12345678 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        </p>
                    </div>

                    <%--Check 3--%>
                     <div id="check3" class="Check_print Check_print3" runat="server" visible="false">
                        <asp:Label ID="Label24" runat="server" Text="37877" CssClass="Check_number"></asp:Label>
                        <asp:Label ID="Label25" runat="server" Text="Ditek" CssClass="Check_business_name"></asp:Label>
                        <br />
                        <asp:Label ID="Label26" runat="server" Text="123 Enterprise Ave" CssClass="Business_address"></asp:Label>
                        <asp:Label ID="Label27" runat="server" Text="1/01/2021" CssClass="Check_date" Font-Underline="True"></asp:Label>
                        <asp:Label ID="Label28" runat="server" Text="DATE" CssClass="Check_date_text"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="Label29" runat="server" Text="Pay to the order of:" CssClass="Pay_to_the"></asp:Label>
                        <asp:Label ID="Label30" runat="server" Text="Ditek____________________________________________________________" CssClass="Student_name Check_textbox" Font-Underline="false"></asp:Label>

                        <asp:TextBox ID="TextBox3" runat="server" Text="$5.00" Width="55px" CssClass="Check_textbox Amount_of_check"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="Label31" runat="server" Text="Five Dollars and 00/100__________________________________________________________________" CssClass="Check_amount_written Check_textbox" Font-Underline="false"></asp:Label>
                        <asp:Label ID="Label32" runat="server" Text="DOLLARS" CssClass="Dollars_text"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Label33" runat="server" Text="Memo" CssClass="Memo"></asp:Label>
                        <asp:Label ID="Label34" runat="server" Text="UPS Supplies______________________________________" CssClass="Check_textbox Memo_text" Font-Underline="false"></asp:Label>
                        <asp:Label ID="Label35" runat="server" Text="______________________________________________________" CssClass="Sign_line" Font-Underline="True"></asp:Label>
                        <br />
                        <p class="Bottom_check">
                                        001001 &nbsp;&nbsp;&nbsp;
                             011900357 &nbsp;&nbsp;&nbsp;
                             12345678 
                        </p>
                    </div>

                    <%--Check 4--%>
                     <div id="check4" class="Check_print Check_print4" runat="server" visible="false">
                        <asp:Label ID="Label36" runat="server" Text="37877" CssClass="Check_number"></asp:Label>
                        <asp:Label ID="Label37" runat="server" Text="Ditek" CssClass="Check_business_name"></asp:Label>
                        <br />
                        <asp:Label ID="Label38" runat="server" Text="123 Enterprise Ave" CssClass="Business_address"></asp:Label>
                        <asp:Label ID="Label39" runat="server" Text="1/01/2021" CssClass="Check_date" Font-Underline="True"></asp:Label>
                        <asp:Label ID="Label40" runat="server" Text="DATE" CssClass="Check_date_text"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="Label41" runat="server" Text="Pay to the order of:" CssClass="Pay_to_the"></asp:Label>
                        <asp:Label ID="Label42" runat="server" Text="Ditek____________________________________________________________" CssClass="Student_name Check_textbox" Font-Underline="false"></asp:Label>

                        <asp:TextBox ID="TextBox4" runat="server" Text="$5.00" Width="55px" CssClass="Check_textbox Amount_of_check"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="Label43" runat="server" Text="Five Dollars and 00/100__________________________________________________________________" CssClass="Check_amount_written Check_textbox" Font-Underline="false"></asp:Label>
                        <asp:Label ID="Label44" runat="server" Text="DOLLARS" CssClass="Dollars_text"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Label45" runat="server" Text="Memo" CssClass="Memo"></asp:Label>
                        <asp:Label ID="Label46" runat="server" Text="Art Supplies______________________________________" CssClass="Check_textbox Memo_text" Font-Underline="false"></asp:Label>
                        <asp:Label ID="Label47" runat="server" Text="______________________________________________________" CssClass="Sign_line" Font-Underline="True"></asp:Label>
                        
                        <p class="Bottom_check">
                                        001001 &nbsp;&nbsp;&nbsp;
                             011900357 &nbsp;&nbsp;&nbsp;
                             12345678 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        </p>
                    </div>

                </div>

            </div>

            <div class="second no-print">
            </div>

            <div class="footer1 no-print">
                <p>Business Operation Checks</p>
                <img class="icon1" src="images/Icons/noun_Excitement_267.png" width="70" height="76" alt="computer" />
            </div>

            <div class="footer2 no-print">
                <p>Online Banking</p>
                <img class="icon1" src="images/Icons/noun_Computer_216.png" width="70" height="67" alt="computer" /><br>
            </div>



            <div class="footer3 no-print">
            </div>


        </div>
        <script src="../../Scripts.js"></script>
    </form>
</body>
</html>
