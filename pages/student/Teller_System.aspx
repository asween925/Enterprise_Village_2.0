<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Teller_System.aspx.vb" Inherits="Enterprise_Village_2._0.Teller_System" %>

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
                <div class="TS_Error"><asp:Label ID="error_lbl" runat="server"></asp:Label></div>

                <%--Account Enter--%>
                <div id="acctEnter_div" runat="server" visible="true" class="TS_Window TS_AcctEnter">
                    <p class="TS_P">Teller System:</p>
                    <asp:TextBox ID="acctNum_tb" runat="server" CssClass="textbox TS_TB" TextMode="Number" placeholder="Enter Account Number"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="acctEnter_btn" runat="server" CssClass="TS_Button3" Text="Enter" />
                </div>

                <%--When Account Is Entered--%>
                <div id="screen2" runat="server" visible="false">

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
                                        <th class="TS_Info_Table_D">Deposit #1:</th>
                                        <th class="TS_Info_Table_D">Deposit #2:</th>
                                        <th class="TS_Info_Table_D">Deposit #3:</th>
                                        <th class="TS_Info_Table_D">Savings: </th>
                                    </tr>
                                    <tr class="TS_Info_Table_R">
                                        <td class="TS_Info_Table_D">
                                            <asp:Label ID="studentName_lbl" runat="server" Text="Student Name" CssClass="TS_Info_Name"></asp:Label></td>
                                        <td class="TS_Info_Table_D">
                                            <asp:Label ID="acctNum_lbl" runat="server" Text="113" CssClass="TS_Info_Num"></asp:Label></td>
                                        <td class="TS_Info_Table_D">
                                            <asp:Label ID="balance_lbl" runat="server" Text="$10" CssClass="TS_Info_Balance"></asp:Label></td>
                                        <td class="TS_Info_Table_D">
                                            <asp:Label ID="deposit1_lbl" runat="server" Text="$2.00"></asp:Label></td>
                                        <td class="TS_Info_Table_D">
                                            <asp:Label ID="deposit2_lbl" runat="server" Text="$2.00"></asp:Label></td>
                                        <td class="TS_Info_Table_D">
                                            <asp:Label ID="deposit3_lbl" runat="server" Text="$2.00"></asp:Label></td>
                                        <td class="TS_Info_Table_D">
                                            <asp:Label ID="savings_lbl" runat="server" Text="$0.00"></asp:Label></td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>

                    <%--Enter Deposit--%>
                    <div id="enterDeposit_div" runat="server" class="TS_Amount">

                        <%--Dollar Buttons (Visible ONLY during Deposit 1 & 3 periods)--%>
                        <div id="deposit_div" runat="server" style=" margin-top: 10px;">
                            <p class="TS_P" style="font-size: calc(7px + 0.8vw);">Deposit Amount:</p>
                            <table class="TS_Buttons">
                                <tr>
                                    <%--$7.00--%>
                                    <td>
                                        <label>
                                            <input id="seven_rdo" runat="server" type="radio" name="deposit" value="7.0" class="TS_Radio">
                                            <img src="../../images/tellermoney3.png" class="TS_Radio_Img" alt="$7.00">
                                        </label>
                                    </td>

                                    <%--$6.50--%>
                                    <td>
                                        <label>
                                            <input id="sixfive_rdo" runat="server" type="radio" name="deposit" value="6.50" class="TS_Radio">
                                            <img src="../../images/tellermoney2.png" class="TS_Radio_Img" alt="$6.50">
                                        </label>
                                    </td>

                                    <%--$6.00--%>
                                    <td>
                                        <label>
                                            <input id="six_rdo" runat="server" type="radio" name="deposit" value="6.0" class="TS_Radio">
                                            <img src="../../images/tellermoney1.png" class="TS_Radio_Img" alt="$6.00">
                                        </label>
                                    </td>
                                </tr>
                            </table>
                        </div>

                        <%--Savings Buttons (Visible ONLY during Deposit 2 period)--%>
                        <div id="savings_div" runat="server" style=" margin-top: 10px;" visible="false">
                            <p class="TS_P" style="font-size: calc(7px + 0.8vw);">Savings (Optional):</p>
                            <table class="TS_Buttons">
                                <tr>
                                    <%--$1.50--%>
                                    <td>
                                        <label>
                                            <input id="savings150_rdo" runat="server" type="radio" name="savings" value="1.50" class="TS_Radio">
                                            <img src="../../images/dollarsign3.png" class="TS_Radio_Img" alt="$1.50">
                                        </label>
                                    </td>

                                    <%--$1.00--%>
                                    <td>
                                        <label>
                                            <input id="savings100_rdo" runat="server" type="radio" name="savings" value="1.00" class="TS_Radio">
                                            <img src="../../images/dollarsign2.png" class="TS_Radio_Img" alt="$1.00">
                                        </label>
                                    </td>

                                    <%--$0.50--%>
                                    <td>
                                        <label>
                                            <input id="savings50_rdo" runat="server" type="radio" name="savings" value="0.50" class="TS_Radio">
                                            <img src="../../images/dollarsign.png" class="TS_Radio_Img" alt="$0.50">
                                        </label>
                                    </td>
                                </tr>
                            </table>
                        </div>

                        <%--Cash Back (Always visible)--%>
                        <div id="cashback_div" runat="server" style="">
                            <p class="TS_P" style="font-size: calc(7px + 0.8vw);">Cashback (Optional):</p>
                            <table class="TS_Buttons">
                                <tr>
                                    <%--$1.00--%>
                                    <td>
                                        <label>
                                            <input id="cash100_rdo" runat="server" type="radio" name="cash" value="1.00" class="TS_Radio">
                                            <img src="../../images/quarter4.png" class="TS_Radio_Img" alt="$1.00">
                                        </label>
                                    </td>

                                    <%--$0.75--%>
                                    <td>
                                        <label>
                                            <input id="cash75_rdo" runat="server" type="radio" name="cash" value="0.75" class="TS_Radio">
                                            <img src="../../images/quarter3.png" class="TS_Radio_Img" alt="$0.75">
                                        </label>
                                    </td>

                                    <%--$0.50--%>
                                    <td>
                                        <label>
                                            <input id="cash50_rdo" runat="server" type="radio" name="cash" value="0.50" class="TS_Radio">
                                            <img src="../../images/quarter2.png" class="TS_Radio_Img" alt="$0.50">
                                        </label>
                                    </td>

                                    <%--$0.25--%>
                                    <td>
                                        <label>
                                            <input id="cash25_rdo" runat="server" type="radio" name="cash" value="0.25" class="TS_Radio">
                                            <img src="../../images/quarter1.png" class="TS_Radio_Img" alt="$0.25">
                                        </label>
                                    </td>

                                    <%--None--%>
                                    <td>
                                        <label>
                                            <input id="cash00_rdo" runat="server" type="radio" name="cash" value="0.00" class="TS_Radio">
                                            <img src="../../images/quarterClear.png" class="TS_Radio_Img" alt="None">
                                        </label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <br />

                        <%--Submit Buttons--%>
                        <div class="TS_SubmitBtn">
                            <asp:Button ID="submit_btn" runat="server" Text="Submit" CssClass="submit_button TS_Button2" />&ensp;
                            <asp:Button ID="back_btn" runat="server" Text="Back" CssClass="submit_button TS_Button2" />
                        </div>
                        
                    </div>

                </div>

            </div>

        </div>

        <script src="../../Scripts.js"></script>
    </form>
</body>
</html>
