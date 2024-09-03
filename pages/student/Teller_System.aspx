<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Teller_System.aspx.vb" Inherits="Enterprise_Village_2._0.Teller_System" %>

<!doctype html>
<html>
<head runat="server">

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>Teller System</title>

    <link href="~/css/Styles.Teller2.css" rel="stylesheet" type="text/css">
    <link href="~/css/Styles.print.css" rel="stylesheet" media="print" type="text/css">
    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png" />
</head>

<body>
    <form autocomplete="off" id="Online_Banking_Form" runat="server">
        <div id="site_wrap">

            <%--Header--%>
            <div class="header1 no-print">
                <img class="EV " alt="Enterprise Village" src="../../Images/EV2.0_PCSB.png">
            </div>

            <div class="header2 no-print">
                <h2>Teller System</h2>
            </div>

            <div class="header3 teller_logo_print">
                <img class="business" alt="Business" src="../../media/Logos/Achieva/achieva.png">
            </div>

                <%--First Page--%>
                <div class="main_boa">
                    <div class="Account_area">

                        <%--Input Account Number--%>
                        <div class="Account_summary no-print">
                            <asp:HiddenField ID="visitdate_hf" runat="server" />
                            <h3 class="Bold">Enter Account Number</h3>
                            <p>Account Number:</p>
                            <asp:TextBox ID="employee_number_tb" runat="server" TextMode="Number" CssClass="Teller_textbox"  ></asp:TextBox>
                            <br />
                            <asp:Label ID="error_lbl" runat="server" Font-Bold="True" Font-Size="Large" CssClass="no-print" ForeColor="Red"></asp:Label>
                            <br />
                            <asp:Button ID="Enter_account_btn" runat="server" Text="Enter" Enabled="true" CssClass="Teller_button1" /> &ensp; <asp:Button ID="clear_btn" runat="server" Text="Clear Out" CssClass="Teller_button1" />
                        </div>
                        <br /><br />

                        <%--Input Savings Amount (After Direct Deposit)--%>
                        <div class="Account_summary no-print" runat="server" id="savings_div" visible="false">
                            <h3 class="Bold">Enter Savings Amount</h3>
                            <p>Savings Amount:</p>
                            <asp:DropDownList ID="savings_ddl" runat="server" CssClass="ddl teller_deposit_print">
                                <asp:ListItem ></asp:ListItem>
                                <asp:ListItem >$0.50</asp:ListItem>
                                <asp:ListItem >$1.00</asp:ListItem>
                                <asp:ListItem >$1.50</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                            <asp:Label ID="error_savings_lbl" runat="server" Font-Bold="True" Font-Size="Large" CssClass="no-print" ForeColor="Red"></asp:Label>
                            <br />
                            <asp:Button ID="savings_btn" runat="server" Text="Open Savings Account" Font-Size="15px" Enabled="true" CssClass="Teller_button" />
                        </div>
                        <br /><br />     
                        
                        <%--Input Section--%>
                        <div id="deposit_div" runat="server" class="Account_summary teller_sidebar_print">
                            <h3 class="Bold no-print">Deposit Check</h3>
                            <p class="teller_deposit_print">Check Amount</p>

                            <asp:DropDownList CssClass="ddl teller_deposit_print" ID="Check_amount_ddl" runat="server" AutoPostBack="true">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>$6.00</asp:ListItem>
                                <asp:ListItem>$6.50</asp:ListItem>
                                <asp:ListItem>$7.00</asp:ListItem>
                            </asp:DropDownList>

                            <p class="Error" id="demo2"></p>                       
                            <br /> 

                            <p class="teller_deposit_print">Cash Being Withdrawn</p>

                            <p class="Error" id="demo"></p>

                             <asp:DropDownList CssClass="ddl teller_deposit_print" ID="cash_recieved_ddl" runat="server" AutoPostBack="true">
                                <asp:ListItem >$0.00</asp:ListItem>
                                <asp:ListItem >$0.25</asp:ListItem>
                                <asp:ListItem >$0.50</asp:ListItem>
                                <asp:ListItem >$0.75</asp:ListItem>
                                <asp:ListItem >$1.00</asp:ListItem>
                            </asp:DropDownList>
                            <br /><br />

                            <p class="teller_deposit_print">Net Deposit</p>

                            <asp:TextBox ID="Net_tb2" runat="server" TextMode="Number" CssClass="Teller_textbox teller_deposit_print" ReadOnly="true"></asp:TextBox>

                            <p id="demo3" class="Error no-print"></p>
                            <br />
                            <asp:Button ID="Enter_deposit_btn" Enabled="false" runat="server" Text="Enter Deposit" CssClass="Teller_button no-print" />

                        </div>
                    </div>
                </div>

                <%--Side bar--%>
                <div class="second teller_sidebar_print">
                    <div id="screen3">
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                        <asp:Label ID="Label1" runat="server" Text="Name:"  Font-Bold="true" font-Underline="true" CssClass="teller_sidebar_text teller_sidebar_text_print"></asp:Label><br />
                        <asp:Label ID="Name_lbl" runat="server" Text=" "  CssClass="teller_sidebar_text teller_sidebar_text_print"></asp:Label>
    <%--                    <br />
                        <br />
                        <asp:Label ID="Label14" runat="server" Text="Employer:"  Font-Bold="true" font-Underline="true" CssClass="teller_sidebar_text"></asp:Label><br />
                        <asp:Label ID="Business_name_lbl" runat="server" Text=" "  CssClass="teller_sidebar_text"></asp:Label>--%>
                        <br />
                        <br />
                        <asp:Label ID="Label2" runat="server" Text="Account Number:"  Font-Bold="true" font-Underline="true" CssClass="teller_sidebar_text teller_sidebar_text_print"></asp:Label><br />
                        <asp:Label ID="Employee_number_lbl" runat="server" Text=" "  CssClass="teller_sidebar_text teller_sidebar_text_print"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Label4" runat="server" Text="Current Balance:"  Font-Bold="true" font-Underline="true" CssClass="teller_sidebar_text teller_sidebar_text_print"></asp:Label><br />
                        <asp:Label ID="Balance_lbl" runat="server" Text=" " CssClass="teller_sidebar_text teller_sidebar_text_print" ></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Label18" runat="server" Text="Savings:"  Font-Bold="true" font-Underline="true" CssClass="teller_sidebar_text teller_sidebar_text_print"></asp:Label><br />
                        <asp:Label ID="Label3" runat="server" Text="$"  CssClass="teller_sidebar_text teller_sidebar_text_print"></asp:Label>
                        <asp:Label ID="Savings_lbl" runat="server" Text=" " CssClass="teller_sidebar_text teller_sidebar_text_print" ></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Label7" runat="server" Text="Deposit History"  Font-Bold="true" font-Underline="true" CssClass="teller_sidebar_text teller_sidebar_text_print"></asp:Label>
                        <br />
                        <asp:Label ID="Label11" runat="server" Text="$" CssClass="teller_sidebar_text teller_sidebar_text_print" ></asp:Label>
                        <asp:Label ID="Deposit1_lbl" runat="server" Text=" "  CssClass="teller_sidebar_text teller_sidebar_text_print"></asp:Label>
                        <br />
                        <asp:Label ID="Label12" runat="server" Text="$" CssClass="teller_sidebar_text teller_sidebar_text_print" ></asp:Label>
                        <asp:Label ID="Deposit2_lbl" runat="server" Text=" " CssClass="teller_sidebar_text teller_sidebar_text_print" ></asp:Label>
                        <br />
                        <asp:Label ID="Label13" runat="server" Text="$" CssClass="teller_sidebar_text teller_sidebar_text_print" ></asp:Label>
                        <asp:Label ID="Deposit3_lbl" runat="server" Text=" " CssClass="teller_sidebar_text teller_sidebar_text_print" ></asp:Label>
                        <br />
                        <asp:Label ID="Label17" runat="server" Text="$" CssClass="teller_sidebar_text teller_sidebar_text_print"></asp:Label>
                        <asp:Label ID="Deposit4_lbl" runat="server" Text=" " CssClass="teller_sidebar_text teller_sidebar_text_print" ></asp:Label>
                    </div>
                </div>
           
        </div>

        <script src="../../Scripts.js"></script>
         <script type="text/javascript">
            /*if (location.protocol = 'https:') {*/
                /*location.replace('https:' + window.location.href.substring(window.location.protocol.length))*/
            /*}*/
            url = window.location.search.substring(1)
            codepos = url.indexOf("passprnt_code");
            statpos = url.indexOf("passprnt_message")
            window.onload = function GetStat() {
                if (statpos > 0) {
                    status = url.slice(statpos + 17)
                    code = url.slice(codepos + 14, codepos + 15)
                    document.getElementById("stattxt").innerHTML = "Last Result:<br>" + status + "<br>Return Code: " + code
                }
            }

            function PrintFromURL() {
                URL = window.location.href
                passprnt_uri = "starpassprnt://v1/print/nopreview?";

                passprnt_uri += "&back=" + encodeURIComponent(window.location.href.split('?')[0]);
                passprnt_uri += "&popup=" + "ensable"
                passprnt_uri += "&url=" + encodeURIComponent(URL);
                location.href = passprnt_uri
            }

         </script>

    </form>
</body>
</html>
