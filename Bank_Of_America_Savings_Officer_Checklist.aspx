<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Bank_Of_America_Savings_Officer_Checklist.aspx.vb" Inherits="Enterprise_Village_2._0.Bank_Of_America_Savings_Officer_Checklist" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">
    <title>Achieva Credit Union CSR</title>


    <link href="css/Styles.Checklist.css" rel="stylesheet" type="text/css">
</head>

<body>
    <form id="form1" runat="server">
        <div id="site_wrap">
            <div class="header1">

                <img class="EV" alt="Enterprise Village" src="Images/EV2.0_PCSB.png">
            </div>

            <div class="header2">
                <h2>Savings Officer</h2>
            </div>

            <div class="header3">
                <img class="business" alt="Business" src="media\Logos\Achieva\achieva.png" width="390">
            </div>

            <div class="main_boa">
                <br /><br /><br /><br /><br />
                <table class="tall_table" border="1">
                    <tbody>
                        <tr>
                            <td class="table_header2">Business</td>
                            <td class="table_header2">Number of Employees</td>
                            <td class="table_header2">Collected Mortgage Payment</td>
                        </tr>
                        <tr>
                            <td class="row_text">Astro Skate</td>
                            <td class="text_field">
                                <asp:TextBox ID="bus1_numberofemployees_tb" runat="server" class="textbox_small" TextMode="Number"></asp:TextBox></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus1_collectmortgage__cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="row_text">Achieva Credit Union</td>
                            <td class="text_field">
                                <asp:TextBox ID="bus2_numberofemployees_tb" runat="server" class="textbox_small" TextMode="Number"></asp:TextBox></td>
                            <td class="closed"></td>
                        </tr>
                        <tr>
                            <td class="row_text">BayCare</td>
                            <td class="text_field">
                                <asp:TextBox ID="bus3_numberofemployees_tb" runat="server" class="textbox_small" TextMode="Number"></asp:TextBox></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus3_collectmortgage__cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="row_text">BBB</td>
                            <td class="text_field">
                                <asp:TextBox ID="bus4_numberofemployees_tb" runat="server" class="textbox_small" TextMode="Number"></asp:TextBox></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus4_collectmortgage__cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="row_text">Koozie Group</td>
                            <td class="text_field">
                                <asp:TextBox ID="bus5_numberofemployees_tb" runat="server" class="textbox_small" TextMode="Number"></asp:TextBox></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus5_collectmortgage__cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="row_text">Buccaneers</td>
                            <td class="text_field">
                                <asp:TextBox ID="bus18_numberofemployees_tb" runat="server" class="textbox_small" TextMode="Number"></asp:TextBox></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus18_collectmortgage__cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="row_text">City Hall</td>
                            <td class="text_field">
                                <asp:TextBox ID="bus6_numberofemployees_tb" runat="server" class="textbox_small" TextMode="Number"></asp:TextBox></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus6_collectmortgage__cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="row_text">CVS</td>
                            <td class="text_field">
                                <asp:TextBox ID="bus7_numberofemployees_tb" runat="server" class="textbox_small" TextMode="Number"></asp:TextBox></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus7_collectmortgage__cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="row_text">Ditek</td>
                            <td class="text_field">
                                <asp:TextBox ID="bus9_numberofemployees_tb" runat="server" class="textbox_small" TextMode="Number"></asp:TextBox></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus9_collectmortgage__cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="row_text">Duke Energy</td>
                            <td class="text_field">
                                <asp:TextBox ID="bus10_numberofemployees_tb" runat="server" class="textbox_small" TextMode="Number"></asp:TextBox></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus10_collectmortgage__cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="row_text">HSN</td>
                            <td class="text_field">
                                <asp:TextBox ID="bus11_numberofemployees_tb" runat="server" class="textbox_small" TextMode="Number"></asp:TextBox></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus11_collectmortgage__cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="row_text">Kane's</td>
                            <td class="text_field">
                                <asp:TextBox ID="bus12_numberofemployees_tb" runat="server" class="textbox_small" TextMode="Number"></asp:TextBox></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus12_collectmortgage__cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="row_text">McDonald's</td>
                            <td class="text_field">
                                <asp:TextBox ID="bus13_numberofemployees_tb" runat="server" class="textbox_small" TextMode="Number"></asp:TextBox></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus13_collectmortgage__cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="row_text">Mix 100.7</td>
                            <td class="text_field">
                                <asp:TextBox ID="bus14_numberofemployees_tb" runat="server" class="textbox_small" TextMode="Number"></asp:TextBox></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus14_collectmortgage__cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="row_text">Pinellas County Solid Waste</td>
                            <td class="text_field">
                                <asp:TextBox ID="TextBox1" runat="server" class="textbox_small" TextMode="Number"></asp:TextBox></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="CheckBox1" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="row_text">KnowBe4</td>
                            <td class="text_field">
                                <asp:TextBox ID="bus17_numberofemployees_tb" runat="server" class="textbox_small" TextMode="Number"></asp:TextBox></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus17_collectmortgage__cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="row_text">Rays</td>
                            <td class="text_field">
                                <asp:TextBox ID="bus19_numberofemployees_tb" runat="server" class="textbox_small" TextMode="Number"></asp:TextBox></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus19_collectmortgage__cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="row_text">Tampa Bay Times</td>
                            <td class="text_field">
                                <asp:TextBox ID="bus20_numberofemployees_tb" runat="server" class="textbox_small" TextMode="Number"></asp:TextBox></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus20_collectmortgage__cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="row_text">TD SYNNEX</td>
                            <td class="text_field">
                                <asp:TextBox ID="bus21_numberofemployees_tb" runat="server" class="textbox_small" TextMode="Number"></asp:TextBox></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus21_collectmortgage__cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="row_text">United Way</td>
                            <td class="text_field">
                                <asp:TextBox ID="bus23_numberofemployees_tb" runat="server" class="textbox_small" TextMode="Number"></asp:TextBox></td>
                            <td class="checkbox">
                                <asp:CheckBox ID="bus23_collectmortgage__cb" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="table_header2">Total Number of Employees</td>
                            <td class="text_field">
                                <asp:TextBox ID="total_numberofemployees_tb" runat="server" class="textbox_small" TextMode="Number"></asp:TextBox></td>
                            <td></td>
                        </tr>
                    </tbody>
                </table>
            </div>
            
            <div class="second">
                <ul>
                    <li>
                        <h4>Go to each business, locate the break schedule, count the number of employees and enter the number for each business.</h4>
                    </li>
                    <%--<li>
                        <h4>When you are finished, total the number of employees and multiply by $1.50.</h4>
                    </li>
                    <li>
                        <h4>Total number of employees x $1.50 =
                            <input type="number" class="textbox_small"></h4>
                    </li>--%>
                    <li>
                        <h4>After calculating total amount saved, collect mortgage payments check check off the businesses as you collect the checks.</h4>
                    </li>
                    <li>
                        <h4>When you are finished, please return your device to an EV Staff member.</h4>
                    </li>
                </ul>
            </div>

            <div class="footer3">
                <button onclick="myFunction()" class="submit">Submit</button>

            </div>


        </div>
        <script src="Scripts.js"></script>
    </form>
</body>
</html>
