<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Negative_balance_report.aspx.vb" Inherits="Enterprise_Village_2._0.Negative_balance_report" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>EV 2.0 - Negative Balance Report</title>

    <link href="css/Styles.updated.css" rel="stylesheet" media="screen" type="text/css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <link rel="shortcut icon" type="image/png" href="media/EV_favicon_2.png" />
<script src="https://code.jquery.com/jquery-1.10.2.js"></script>
</head>

<body>
    <form id="EMS_Form" runat="server">

        <%--Header information--%>
        <header class="headerTop"><a style="float: left; padding-top: 2px;">Enterprise Village 2.0</a><a style="float: right; padding-right: 30px; padding-top: 2px;"><asp:Label ID="headerSchoolName_lbl" Text="School Name Here" runat="server"></asp:Label></a></header>


       <%--Navigation bar--%>
        <div id="nav-placeholder">

        </div>

        <script>
            $(function () {
                $("#nav-placeholder").load("nav.html");
            });
        </script>

        

        <%--Content--%>
        <div class="content">
            <h2 class="h2">Negative Balance Report</h2>
            <h3>This page displays any students who have a negative balance.
            </h3>
            <br />
            <br />
            <asp:Label runat="server" ID="error_lbl" Text="No negative balances!" Font-Size="X-Large" ForeColor="Red"></asp:Label>
            <br />
            <asp:GridView ID="businessProfit_dgv" runat="server" AutoGenerateColumns="False" CellPadding="5" CellSpacing="1" PageSize="20" Font-Size="Medium" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows">
                <Columns>
                    <asp:BoundField DataField="employeeNumber" HeaderText="Account Number" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="studentname" HeaderText="Name" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="totaldeposits" HeaderText="Total Deposits" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="totalpurchases" HeaderText="Total Purchases" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="balance" HeaderText="Balance" ReadOnly="true" Visible="true" />
                </Columns>
            </asp:GridView>
            <br />
        </div>

        <asp:HiddenField ID="visitdate_hf" runat="server" />
        <asp:HiddenField ID="businessID_hf" runat="server" />

        <asp:SqlDataSource ID="Review_sds" runat="server"></asp:SqlDataSource>

        <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
        <script src="Scripts.js"></script>
        <script>
            /* Loop through all dropdown buttons to toggle between hiding and showing its dropdown content - This allows the user to have multiple dropdowns without any conflict */
            $(".sub-menu ul").hide();
            $(".sub-menu a").click(function () {
                $(this).parent(".sub-menu").children("ul").slideToggle("100");
                $(this).find(".right").toggleClass("fa-caret-up fa-caret-down");
            });
        </script>

    </form>
</body>
</html>
