<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Online_Banking.aspx.vb" Inherits="Enterprise_Village_2._0.Online_Banking" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!doctype html>
<html>
<head runat="server">

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">
    <title>Online Banking</title>

    <link href="~/css/Styles.Utility.css" rel="stylesheet" type="text/css">
    <link href="../../css/Styles.updated.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png" />
</head>

<body>
    <form autocomplete="off"  id="Online_Banking_Form" runat="server">
        <div id="site_wrap2">
            <div class="header1">
                <img class="EV" alt="Enterprise Village" src="../../Images/EV2.0_PCSB.png">
            </div>

            <div class="header2">
                <h2>Online Banking</h2>
            </div>

            <div class="header3">
                <asp:Image ID="BusLogo_img" runat="server" Class="Business_logo" />
            </div>

            <%--Content--%>
            <div class="main_base" runat="server" id="check_system">
                <br />
                <asp:HyperLink ID="F1URL" runat="server" Text="Payroll Checks" CssClass="ditek_print_button Bold"> </asp:HyperLink>
                <asp:HyperLink ID="F2URL" runat="server" Text="Operating Checks" CssClass="ditek_print_button Bold"></asp:HyperLink>
                <asp:HyperLink ID="F3URL" runat="server" Text="Sales History" CssClass="ditek_print_button Bold"></asp:HyperLink>
                <br />

                <%--Summary--%>
                <div class="Check_edits">
                    <h3>Financial Summary</h3>
                    <table style="background-color: rgba(255, 255, 255, 0.0);">
                        <tr>
                            <td style="float: left;">
                                <p style="font-weight: bold;">Total Deposits</p>
                            </td>
                            <td>&emsp;&emsp;&emsp;<asp:Label ID="total_deposits_lbl" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="float: left;">
                                <p style="font-weight: bold;">Loan Amount</p>
                            </td>
                            <td>&emsp;&emsp;&emsp;<asp:Label ID="loan_amount_display_lbl" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="float: left;">
                                <p style="font-weight: bold;">Profit</p>
                            </td>
                            <td>&emsp;&emsp;&emsp;<asp:Label ID="profit_lbl" runat="server"></asp:Label></td>
                        </tr>
                        <tr id="misc_row_tr" runat="server" visible="false">
                            <td style="float: left;">
                                <p runat="server" id="P1" style="font-weight: bold;">Miscellaneous Deposit</p>
                            </td>
                            <td>&emsp;&emsp;&emsp;<asp:Label ID="deposit4_lbl" runat="server"   ></asp:Label></td>
                        </tr>
                        <tr id="final_profit_row_tr" runat="server" visible="false">
                            <td style="float: left;">
                                <p runat="server" id="finalProfits_p" style="font-weight: bold;">Final Profit</p>
                            </td>
                            <td>&emsp;&emsp;&emsp;<asp:Label ID="finalProfit_lbl" runat="server"  ></asp:Label></td>
                        </tr>
                    </table>
                </div>

                <%--Updates--%>
                <div class="Check_edits">
                    <h3>Enter Check Amounts:</h3>
                    <table style="background-color: rgba(255, 255, 255, 0.0);">
                        <tr>
                            <td>
                                <p style="font-weight: bold;">Loan Amount</p>
                            </td>
                            <td>
                                &emsp;&emsp;&emsp;<asp:Label ID="Label100" runat="server" Text="$" ForeColor="Black"></asp:Label>
                                <asp:TextBox ID="Loan_Amount_tb" runat="server" Width="50px" CssClass="textbox" TextMode="Number" Style="text-align: center"></asp:TextBox>                            
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p style="font-weight: bold;">Deposit 1</p>
                            </td>
                            <td>
                                &emsp;&emsp;&emsp;<asp:Label ID="Label6" runat="server" Text="$" ForeColor="Black"></asp:Label>
                                <asp:TextBox ID="Deposit1_tb" runat="server" Width="50px" CssClass="textbox" TextMode="Number" Style="text-align: center" enabled="false" min="0" step="any"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="deposit2_tr" runat="server">
                            <td>
                                <p style="font-weight: bold;">Deposit 2</p>
                            </td>
                            <td>
                                &emsp;&emsp;&emsp;<asp:Label ID="Label7" runat="server" Text="$" ForeColor="Black"></asp:Label>
                                <asp:TextBox ID="Deposit2_tb" runat="server" Width="50px" CssClass="textbox" TextMode="Number" Style="text-align: center" enabled="false" min="0" step="any"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="deposit3_tr" runat="server">
                            <td>
                                <p style="font-weight: bold;">Deposit 3</p>
                            </td>
                            <td>
                                &emsp;&emsp;&emsp;<asp:Label ID="Label8" runat="server" Text="$" ForeColor="Black"></asp:Label>
                                <asp:TextBox ID="Deposit3_tb" runat="server" Width="50px" CssClass="textbox" TextMode="Number" Style="text-align: center" enabled="false" min="0" step="any"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:Button CssClass="button3_banking" ID="update_btn" runat="server" Text="Submit" />
                </div>
                <br />
                <asp:Label ID="error_lbl" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="Red"></asp:Label>
                <asp:HiddenField ID="visitdate_hf" runat="server" />
            </div>
        </div>
        <script src="../../Scripts.js"></script>
    </form>
</body>
</html>
