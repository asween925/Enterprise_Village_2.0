<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Sales_History.aspx.vb" Inherits="Enterprise_Village_2._0.Sales_History" %>

<!doctype html>
<html>
<head runat="server">

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">
    <title>Sales History</title>


    <link href="css/Styles.Print.css" rel="stylesheet" media="print" type="text/css">
    <link href="css/Styles.SalesSystem.css" rel="stylesheet" media="screen" type="text/css">
    <link rel="shortcut icon" type="image/png" href="media/EV_favicon_2.png" />
</head>

<body>
    <form id="EMS_Form" runat="server">
        <div id="site_wrap">
            <div class="header1">

                <img class="EV" alt="Enterprise Village" src="Images/EV2.0_PCSB.png">
            </div>

            <div class="header2">
                <h2>Sales History</h2>
            </div>

            <div class="header3">
                <asp:Image ID="BusLogo_img" runat="server" Class="Business_logo" />
            </div>

            <div class="main_boa">
                <br />
                <br />
                <asp:HyperLink ID="F1URL" runat="server" CssClass="ditek_print_button" Text="Sales System"></asp:HyperLink>
                <br />
                <br />
                <asp:Label runat="server" ID="error_lbl" Font-Bold="true" ForeColor="Red" Font-Size="X-Large"></asp:Label>
                <br />
                <asp:Label runat="server" ID="totalSales_lbl" Font-Bold="true" Font-Size="X-Large" ForeColor="White"></asp:Label>
                <br /><br /><br />
                <asp:GridView ID="Transactions_dgv" runat="server" AutoGenerateColumns="False" CellPadding="5" CellSpacing="1" PageSize="20" Font-Size="Medium" Width="30px">
                    <AlternatingRowStyle BackColor="#99CCFF" />
                    <Columns>
                        <asp:BoundField DataField="employeeNumber" HeaderText="Account <br /> Number" ReadOnly="true" Visible="true" HtmlEncode="false"/>
                        <asp:BoundField DataField="business" HeaderText="Business" ReadOnly="true" Visible="false" />
                        <asp:BoundField DataField="transactiontimestamp" HeaderText="Timestamp" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="saleAmount" HeaderText="Sale <br /> Amount" ReadOnly="true" Visible="true" HtmlEncode="false"/>
                        <asp:BoundField DataField="transactiontimestamp2" HeaderText="Timestamp 2" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="saleAmount2" HeaderText="Sale <br /> Amount 2" ReadOnly="true" Visible="true" HtmlEncode="false" />
                        <asp:BoundField DataField="transactiontimestamp3" HeaderText="Timestamp 3" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="saleAmount3" HeaderText="Sale <br /> Amount 3" ReadOnly="true" Visible="true" HtmlEncode="false"/>
                        <asp:BoundField DataField="transactiontimestamp4" HeaderText="Timestamp 4" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="saleAmount4" HeaderText="Sale <br /> Amount 4" ReadOnly="true" Visible="true" HtmlEncode="false" />
                        <asp:BoundField DataField="visit" HeaderText="Visit" ReadOnly="true" Visible="false" />
                    </Columns>
                </asp:GridView>
                <br />
                <asp:HiddenField ID="visitdate_hf" runat="server" />
            </div>
        </div>

        <script src="Scripts.js"></script>
        <asp:SqlDataSource ID="Review_sds" runat="server"></asp:SqlDataSource>
    </form>
</body>
</html>
