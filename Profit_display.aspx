<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Profit_display.aspx.vb" Inherits="Enterprise_Village_2._0.Profit_display" %>

<!doctype html>
<html>
<head runat="server">

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">
    <title>Profit Powerpoint</title>


    <link href="css/Styles.profit.css" rel="stylesheet" type="text/css">
    <link rel="shortcut icon" type="image/png" href="media/EV_favicon_2.png" />
</head>

<body onload="delayfunction4()" class="main_boa">
    <form id="Profit_display_Form" runat="server">
        
        <div>
            <asp:GridView ID="profit_dgv" runat="server" AutoGenerateColumns="False" CellPadding="5" CellSpacing="1" PageSize="100" Font-Size="Medium" Visible="false">
                <AlternatingRowStyle BackColor="#99CCFF" />
                <Columns>
                    <asp:BoundField DataField="businessname" HeaderText="business name" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="profit" HeaderText="profit" ReadOnly="true" Visible="true" />
                </Columns>
            </asp:GridView>
        </div>
        <asp:Label ID="error_lbl" runat="server" Font-Size="XX-Large" ForeColor="white"></asp:Label>
        <div>
            <div style="text-align: center; margin: auto;">
                
                <div id="Message" style="position: fixed; top: 40%; left: 50%; transform: translate(-50%, -50%);">
                    <asp:Label ID="Label3" runat="server" Text="Town Hall Business Reports" CssClass="Heading1" Font-Underline="true"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="Congratulations to all the sucessful businesses!" CssClass="Heading2"></asp:Label>
                </div>

                <div id="Bus1" style="position: fixed; top: 40%; left: 50%; transform: translate(-50%, -50%);">

                    <asp:Label ID="bus1_name_lbl" runat="server" Text="Thank you for visiting Enterprise Village!" CssClass="Heading1"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="bus1_profit_lbl" runat="server" Text="Have a great day!" CssClass="Heading2"></asp:Label><asp:Label ID="Label18" runat="server" CssClass="Heading2"></asp:Label>

                </div>
                <div id="Bus2" style="position: fixed; top: 40%; left: 50%; transform: translate(-50%, -50%);">

                    <asp:Label ID="bus2_name_lbl" runat="server" Text="Thank you for visiting Enterprise Village!" CssClass="Heading1"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="bus2_profit_lbl" runat="server" Text="Have a great day!" CssClass="Heading2"></asp:Label><asp:Label ID="Label15" runat="server"  CssClass="Heading2"></asp:Label>

                </div>
                <div id="Bus3" style="position: fixed; top: 40%; left: 50%; transform: translate(-50%, -50%);">

                    <asp:Label ID="bus3_name_lbl" runat="server" Text="Thank you for visiting Enterprise Village!" CssClass="Heading1"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="bus3_profit_lbl" runat="server" Text="Have a great day!" CssClass="Heading2"></asp:Label><asp:Label ID="Label14" runat="server"  CssClass="Heading2"></asp:Label>

                </div>
                <div id="Bus4" style="position: fixed; top: 40%; left: 50%; transform: translate(-50%, -50%);">

                    <asp:Label ID="bus4_name_lbl" runat="server" Text="Thank you for visiting Enterprise Village!" CssClass="Heading1"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="bus4_profit_lbl" runat="server" Text="Have a great day!" CssClass="Heading2"></asp:Label><asp:Label ID="Label13" runat="server"  CssClass="Heading2"></asp:Label>

                </div>
                <div id="Bus5" style="position: fixed; top: 40%; left: 50%; transform: translate(-50%, -50%);">

                    <asp:Label ID="bus5_name_lbl" runat="server" Text="Thank you for visiting Enterprise Village!" CssClass="Heading1"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="bus5_profit_lbl" runat="server" Text="Have a great day!" CssClass="Heading2"></asp:Label><asp:Label ID="Label12" runat="server"  CssClass="Heading2"></asp:Label>

                </div>
                <div id="Bus6" style="position: fixed; top: 40%; left: 50%; transform: translate(-50%, -50%);">

                    <asp:Label ID="bus6_name_lbl" runat="server" Text="Thank you for visiting Enterprise Village!" CssClass="Heading1"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="bus6_profit_lbl" runat="server" Text="Have a great day!" CssClass="Heading2"></asp:Label><asp:Label ID="Label11" runat="server"  CssClass="Heading2"></asp:Label>

                </div>
                <div id="Bus7" style="position: fixed; top: 40%; left: 50%; transform: translate(-50%, -50%);">

                    <asp:Label ID="bus7_name_lbl" runat="server" Text="Thank you for visiting Enterprise Village!" CssClass="Heading1"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="bus7_profit_lbl" runat="server" Text="Have a great day!" CssClass="Heading2"></asp:Label><asp:Label ID="Label10" runat="server"  CssClass="Heading2"></asp:Label>

                </div>
                <div id="Bus8" style="position: fixed; top: 40%; left: 50%; transform: translate(-50%, -50%);">

                    <asp:Label ID="bus8_name_lbl" runat="server" Text="Thank you for visiting Enterprise Village!" CssClass="Heading1"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="bus8_profit_lbl" runat="server" Text="Have a great day!" CssClass="Heading2"></asp:Label><asp:Label ID="Label9" runat="server"  CssClass="Heading2"></asp:Label>

                </div>
                <div id="Bus9" style="position: fixed; top: 40%; left: 50%; transform: translate(-50%, -50%);">

                    <asp:Label ID="bus9_name_lbl" runat="server" Text="Thank you for visiting Enterprise Village!" CssClass="Heading1"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="bus9_profit_lbl" runat="server" Text="Have a great day!" CssClass="Heading2"></asp:Label><asp:Label ID="Label8" runat="server"  CssClass="Heading2"></asp:Label>

                </div>
                <div id="Bus10" style="position: fixed; top: 40%; left: 50%; transform: translate(-50%, -50%);">

                    <asp:Label ID="bus10_name_lbl" runat="server" Text="Thank you for visiting Enterprise Village!" CssClass="Heading1"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="bus10_profit_lbl" runat="server" Text="Have a great day!" CssClass="Heading2"></asp:Label><asp:Label ID="Label7" runat="server"  CssClass="Heading2"></asp:Label>

                </div>
                <div id="Bus11" style="position: fixed; top: 40%; left: 50%; transform: translate(-50%, -50%);">

                    <asp:Label ID="bus11_name_lbl" runat="server" Text="Thank you for visiting Enterprise Village!" CssClass="Heading1"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="bus11_profit_lbl" runat="server" Text="Have a great day!" CssClass="Heading2"></asp:Label><asp:Label ID="Label6" runat="server"  CssClass="Heading2"></asp:Label>

                </div>
                <div id="Bus12" style="position: fixed; top: 40%; left: 50%; transform: translate(-50%, -50%);">

                    <asp:Label ID="bus12_name_lbl" runat="server" Text="Thank you for visiting Enterprise Village!" CssClass="Heading1"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="bus12_profit_lbl" runat="server" Text="Have a great day!" CssClass="Heading2"></asp:Label><asp:Label ID="Label5" runat="server"  CssClass="Heading2"></asp:Label>

                </div>
                <div id="Bus13" style="position: fixed; top: 40%; left: 50%; transform: translate(-50%, -50%);">

                    <asp:Label ID="bus13_name_lbl" runat="server" Text="Thank you for visiting Enterprise Village!" CssClass="Heading1"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="bus13_profit_lbl" runat="server" Text="Have a great day!" CssClass="Heading2"></asp:Label><asp:Label ID="Label2" runat="server"  CssClass="Heading2"></asp:Label>

                </div>
                <div id="Bus14" style="position: fixed; top: 40%; left: 50%; transform: translate(-50%, -50%);">

                    <asp:Label ID="bus14_name_lbl" runat="server" Text="Thank you for visiting Enterprise Village!" CssClass="Heading1"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="bus14_profit_lbl" runat="server" Text="Have a great day!" CssClass="Heading2"></asp:Label><asp:Label ID="Label1" runat="server"  CssClass="Heading2"></asp:Label>

                </div>

                <div id="Bus15" style="position: fixed; top: 40%; left: 50%; transform: translate(-50%, -50%);">

                    <asp:Label ID="bus15_name_lbl" runat="server" Text="Thank you for visiting Enterprise Village!" CssClass="Heading1"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="bus15_profit_lbl" runat="server" Text="Have a great day!" CssClass="Heading2"></asp:Label><asp:Label ID="Label19" runat="server"  CssClass="Heading2"></asp:Label>

                </div>

                <div id="Bus16" style="position: fixed; top: 40%; left: 50%; transform: translate(-50%, -50%);">

                    <asp:Label ID="bus16_name_lbl" runat="server" Text="Thank you for visiting Enterprise Village!" CssClass="Heading1"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="bus16_profit_lbl" runat="server" Text="Have a great day!" CssClass="Heading2"></asp:Label><asp:Label ID="Label22" runat="server"  CssClass="Heading2"></asp:Label>

                </div>

                <div id="Bus17" style="position: fixed; top: 40%; left: 50%; transform: translate(-50%, -50%);">

                    <asp:Label ID="bus17_name_lbl" runat="server" Text="Thank you for visiting Enterprise Village!" CssClass="Heading1"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="bus17_profit_lbl" runat="server" Text="Have a great day!" CssClass="Heading2"></asp:Label><asp:Label ID="Label21" runat="server"  CssClass="Heading2" Visible="false"></asp:Label>

                </div>
            </div>

            <%--<asp:GridView ID="profit_dgv" runat="server" PageSize="100" Visible="true" ShowHeaderWhenEmpty="True"></asp:GridView>--%>

            <asp:HiddenField ID="visitdate_hf" runat="server"/>
            <asp:HiddenField ID="tablemaxRow_hf" runat="server" Value="0" />
        </div>
        <script src="Scripts.js"></script>
    </form>
</body>
</html>
