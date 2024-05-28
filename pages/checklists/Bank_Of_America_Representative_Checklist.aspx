<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Bank_Of_America_Representative_Checklist.aspx.vb" Inherits="Enterprise_Village_2._0.Bank_Of_America_Representative_Checklist" %>

<!doctype html>
<html>
<head runat="server">

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">
    <title>Achieva Credit Union CSR</title>


    <link href="~/~/css/Styles.Checklist.css" rel="stylesheet" type="text/css">
</head>

<body>
    <form id="form1" runat="server">
        <div id="site_wrap">
            <div class="header1">

                <img class="EV" alt="Enterprise Village" src="../../../../Images/EV2.0_PCSB.png">
            </div>

            <div class="header2">
                <h2 style="font-size: 22px;">Customer Service Representative</h2>
            </div>

            <div class="header3">
                <img class="business" alt="Business" src="../../media/Logos/Achieva/achieva.png" width="390">
            </div>

            <div class="main_boa">
                <h4></h4>
                <table border="1">
                    <tbody>
                        <tr>
                            <td class="table_header">Business</td>
                            <td class="table_header">Delivered Bank Bag</td>
                            <td class="table_header">Collected Payment</td>
                        </tr>
                        <tr>
                            <td>Astro Skate</td>
                            <td class="checkbox">
                                <asp:CheckBox ID="CheckBox2" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus1_collectbus2__cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>BayCare</td>
                             <td class="checkbox">
                                <asp:CheckBox ID="CheckBox18" runat="server" Enabled="false" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus3_collectbus2__cb" runat="server" Enabled="false" /></td>
                        </tr>
                        <tr>
                            <td>BBB</td>
                            <td class="checkbox">
                                <asp:CheckBox ID="CheckBox3" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus4_collectbus2__cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>Koozie Group</td>
                            <td class="checkbox">
                                <asp:CheckBox ID="CheckBox4" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus5_collectbus2__cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>Buccaneers</td>
                            <td class="checkbox">
                                <asp:CheckBox ID="CheckBox5" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus18_collectbus2__cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>City Hall</td>
                             <td class="checkbox">
                                <asp:CheckBox ID="CheckBox19" runat="server" Enabled="false" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus6_collectbus2__cb" runat="server" Enabled="false" /></td>
                        </tr>
                        <tr>
                            <td>CVS</td>
                            <td class="checkbox">
                                <asp:CheckBox ID="CheckBox6" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus7_collectbus2__cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>Ditek</td>
                            <td class="checkbox">
                                <asp:CheckBox ID="CheckBox7" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus9_collectbus2__cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>Duke Energy</td>
                            <td class="checkbox">
                                <asp:CheckBox ID="CheckBox8" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus10_collectbus2__cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>HSN</td>
                            <td class="checkbox">
                                <asp:CheckBox ID="CheckBox9" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus11_collectbus2__cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>Kane's</td>
                            <td class="checkbox">
                                <asp:CheckBox ID="CheckBox10" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus12_collectbus2__cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>McDonald's</td>
                            <td class="checkbox">
                                <asp:CheckBox ID="CheckBox11" runat="server" Enabled="false" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus13_collectbus2__cb" runat="server" enabled="false"/></td>
                        </tr>
                        <tr>
                            <td>Mix 100.7</td>
                            <td class="checkbox">
                                <asp:CheckBox ID="CheckBox12" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus14_collectbus2__cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>Pinellas County Solid Waste</td>
                            <td class="checkbox">
                                <asp:CheckBox ID="CheckBox13" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="CheckBox1" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>KnowBe4</td>
                            <td class="checkbox">
                                <asp:CheckBox ID="CheckBox14" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus17_collectbus2__cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>Rays</td>
                            <td class="checkbox">
                                <asp:CheckBox ID="CheckBox15" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus19_collectbus2__cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>Tampa Bay Times</td>
                            <td class="checkbox">
                                <asp:CheckBox ID="CheckBox16" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus20_collectbus2__cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>TD SYNNEX</td>
                            <td class="checkbox">
                                <asp:CheckBox ID="CheckBox17" runat="server" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus21_collectbus2__cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>United Way</td>
                             <td class="checkbox">
                                <asp:CheckBox ID="CheckBox20" runat="server" Enabled="false" /></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus23_collectbus2__cb" runat="server" Enabled="false" /></td>
                        </tr>
                    </tbody>
                </table>
            </div>

            <div class="second">
                <h4>Go to each business.</h4>
                <ul>
                    <li>
                        <h4>Deliver a bank bag to each business.</h4>
                    </li>
                    <li>
                        <h4>Later return to each business and collect the mortgage payment.</h4>
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
