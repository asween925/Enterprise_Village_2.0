<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Bank_Of_America_Manager_Checklist.aspx.vb" Inherits="Enterprise_Village_2._0.Bank_Of_America_Manager_Checklist" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">
    <title>Achieva Credit Union Branch Manager</title>


    <link href="~/css/Styles.Checklist.css" rel="stylesheet" type="text/css">
</head>

<body>
    <form autocomplete="off"  id="form1" runat="server">
        <div id="site_wrap">
            <div class="header1">

                <img class="EV" alt="Enterprise Village" src="../../../../Images/EV2.0_PCSB.png">
            </div>

            <div class="header2">
                <h2>Branch Manager</h2>
            </div>

            <div class="header3">
                <img class="business" alt="Business" src="../../media/Logos/Achieva/achieva.png">
            </div>

            <div class="main_boa">
                <h4></h4>
                <table border="1">
                    <tbody>
                        <tr>
                            <td class="table_header2">Business</td>
                            <td class="table_header2">Promissory Note Received</td>
                            <td class="table_header2">Loan Application Received</td>
                            <td class="table_header2">Approved Loan Application</td>
                        </tr>
                        <tr>
                            <td>
                                <p>Astro Skate</p>
                            </td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus1_pnr_cb" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus1_lar_cb" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus1_ala_cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>
                                <p>BBB</p>
                            </td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus4_pnr_cb" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus4_lar_cb" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus4_ala_cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>
                                <p>Koozie Group</p>
                            </td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus5_pnr_cb" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus5_lar_cb" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus5_ala_cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>
                                <p>CVS</p>
                            </td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus7_pnr_cb" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus7_lar_cb" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus7_ala_cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>
                                <p>Ditek</p>
                            </td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus9_pnr_cb" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus9_lar_cb" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus9_ala_cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>
                                <p>Duke Energy</p>
                            </td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus10_pnr_cb" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus10_lar_cb" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus10_ala_cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>
                                <p>HSN</p>
                            </td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus11_pnr_cb" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus11_lar_cb" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus11_ala_cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>
                                <p>Kane's</p>
                            </td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus12_pnr_cb" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus12_lar_cb" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus12_ala_cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>
                                <p>KnowBe4</p>
                            </td>
                            <td class="checkbox">
                                <asp:CheckBox ID="CheckBox1" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="CheckBox2" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="CheckBox3" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>
                                <p>McDonald's</p>
                            </td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus13_pnr_cb" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus13_lar_cb" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus13_ala_cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>
                                <p>Mix 100.7</p>
                            </td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus14_pnr_cb" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus14_lar_cb" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus14_ala_cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>
                                <p>Tampa Bay Buccaneers</p>
                            </td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus18_pnr_cb" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus18_lar_cb" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus18_ala_cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>
                                <p>Tampa Bay Rays</p>
                            </td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus19_pnr_cb" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus19_lar_cb" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus19_ala_cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>
                                <p>Tampa Bay Times</p>
                            </td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus20_pnr_cb" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus20_lar_cb" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus20_ala_cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>
                                <p>TD SYNNEX</p>
                            </td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus21_pnr_cb" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus21_lar_cb" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus21_ala_cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>
                                <p>United Way</p>
                            </td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus23_pnr_cb" runat="server" Enabled="false" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus23_lar_cb" runat="server" Enabled="false" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus23_ala_cb" runat="server" Enabled="false"/></td>
                        </tr>
                    </tbody>
                </table>

            </div>

            <div class="second">
                <ul>
                    <li>
                        <h4>Check off each business name as the Promissory Notes and Loan Applications are received.</h4>
                    </li>
                    <li>
                        <h4>Check off each business name after you have reviewed and approved the bank loan application.</h4>
                    </li>
                </ul>

            </div>




            <div class="footer3">
                <button onclick="myFunction()" class="submit">Submit</button>

            </div>


        </div>
        <script src="../../Scripts.js"></script>
    </form>
</body>
</html>
