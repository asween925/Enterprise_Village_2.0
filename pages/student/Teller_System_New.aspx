<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Teller_System_New.aspx.vb" Inherits="Enterprise_Village_2._0.Teller_System_New" %>

<!doctype html>
<html>
<head runat="server">

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>Enterprise Village - Teller System</title>

    <link href="~/css/Styles.StudentPages.css" rel="stylesheet" type="text/css">
    <link href="~/css/Styles.print.css" rel="stylesheet" media="print" type="text/css">
    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png" />
</head>

<body>
    <form autocomplete="off" id="Online_Banking_Form" runat="server">
        <div id="Site_Wrap_Fullscreen">

            <%--Content--%>
            <div id="contentTS_div" runat="server" class="TS_Background">

                <%--Header--%>
                <div id="divHeader" runat="server" class="TS_Header">
                    <img src="../../media/Logos/12/ACUweblogo-wht.png" class="TS_Header_Logo" />
                </div>

                <%--Error--%>
                <asp:Label ID="error_lbl" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="X-Large"></asp:Label>

                <%--Account Enter--%>
                <div id="acctEnter_div" runat="server" visible="false" class="TS_Window TS_AcctEnter">
                    <p class="TS_P">Enter Account Number:</p>
                    <asp:TextBox ID="acctNum_tb" runat="server" CssClass="textbox TS_TB" TextMode="Number"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="acctEnter_btn" runat="server" CssClass="button3" Text="Enter" />
                </div>

                <%--When Account Is Entered--%>
                <div id="screen2" runat="server" visible="true">

                    <%--Account Information--%>
                    <div id="acctInfo_div" runat="server" class="TS_Window TS_Info">
                        <div class="TS_Info_Row">

                            <%--Name, Number, Balance--%>
                            <div class="TS_Info_Column" style="border-right: 1px solid black;">
                                <table class="TS_Info_Table">
                                    <tr class="TS_Info_Table_R">
                                        <th class="TS_Info_Table_D">Name:</th>
                                        <th class="TS_Info_Table_D">Account Number:</th>
                                        <th class="TS_Info_Table_D">Balance:</th>
                                    </tr>
                                    <tr class="TS_Info_Table_R">
                                        <td class="TS_Info_Table_D">
                                            <asp:Label ID="studentName_lbl" runat="server" Text="Student Name" CssClass="TS_Info_Name"></asp:Label></td>
                                        <td class="TS_Info_Table_D">
                                            <asp:Label ID="acctNum_lbl" runat="server" Text="113" CssClass="TS_Info_Num"></asp:Label></td>
                                        <td class="TS_Info_Table_D">
                                            <asp:Label ID="balance_lbl" runat="server" Text="$10" CssClass="TS_Info_Balance"></asp:Label></td>
                                    </tr>
                                </table>
                            </div>

                            <%--Deposit History--%>
                            <div class="TS_Info_Column">
                                <table class="TS_Info_Table">
                                    <tr class="TS_Info_Table_R">
                                        <th class="TS_Info_Table_D">Deposit #1:</th>
                                        <th class="TS_Info_Table_D">Deposit #2:</th>
                                        <th class="TS_Info_Table_D">Deposit #3:</th>
                                    </tr>
                                    <tr class="TS_Info_Table_R">
                                        <td class="TS_Info_Table_D">
                                            <asp:Label ID="deposit1_lbl" runat="server" Text="$2.00"></asp:Label></td>
                                        <td class="TS_Info_Table_D">
                                            <asp:Label ID="deposit2_lbl" runat="server" Text="$2.00"></asp:Label></td>
                                        <td class="TS_Info_Table_D">
                                            <asp:Label ID="deposit3_lbl" runat="server" Text="$2.00"></asp:Label></td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>

                    <%--Enter Deposit--%>
                    <div id="enterDeposit_div" runat="server" class="TS_Amount">

                        <%--Buttons--%>
                        <div style="margin-left: auto; margin-right: auto; width: 80%;">

                            <%--$7.00--%>
                            <label style="float: left;">
                                <input type="radio" name="test" value="small" class="TS_Radio" checked>
                                <img src="../../images/tellermoney3.png" class="TS_Radio_Img" alt="$7.00">
                            </label>

                            <%--$6.50--%>
                            <label style="margin-left: 20%; margin-right: 20%;">
                                <input type="radio" name="test" value="small" class="TS_Radio" checked>
                                <img src="../../images/tellermoney2.png" class="TS_Radio_Img" alt="$6.50">
                            </label>

                            <%--$6.00--%>
                            <label style="float: right;">
                                <input type="radio" name="test" value="small" class="TS_Radio" checked>
                                <img src="../../images/tellermoney1.png" class="TS_Radio_Img" alt="$6.00">
                            </label>


                        </div>

                    </div>

                </div>

            </div>

            <%--Bottom EV Logo--%>
            <div class="EV_Logo_Wrapper">
                <img id="EVLogo_img" runat="server" src="~/media\EnterpriseVillage.png" visible="true" />
            </div>

        </div>

        <script src="../../Scripts.js"></script>
    </form>
</body>
</html>
