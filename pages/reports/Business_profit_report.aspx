<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Business_profit_report.aspx.vb" Inherits="Enterprise_Village_2._0.Business_profit_report" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>EV 2.0 - Profit Report</title>

    <link href="~/css/Styles.Print.css" rel="stylesheet" media="print" type="text/css">
    <link href="~/css/Styles.updated.css" rel="stylesheet" media="screen" type="text/css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png" />
    <script src="https://code.jquery.com/jquery-1.10.2.js"></script>
</head>

<body>
    <form autocomplete="off"  id="EMS_Form" runat="server">

        <%--Header information--%>
        <header class="headerTop no-print"><a style="float: left; padding-top: 2px;">Enterprise Village 2.0</a><a style="float: right; padding-right: 30px; padding-top: 2px;"><asp:Label ID="headerSchoolName_lbl" Text="School Name Here" runat="server"></asp:Label></a></header>

    <%--Navigation bar--%>
        <div id="nav-placeholder">

        </div>

        <script>
            $(function () {
                $("#nav-placeholder").load("../../nav.html");
            });
        </script>

        

        <%--Content--%>
        <div class="content">
            <h2 class="h2">Profit Report</h2>
            <h3 class="no-print">Enter a date below to view the current profits, loan amounts, and staring amount for each business on that date.
            </h3>
            <p>Visit Date:</p>
            <asp:TextBox ID="visitDate_tb" runat="server" TextMode="Date" AutoPostBack="true" CssClass="textbox"></asp:TextBox>&emsp;<asp:Label runat="server" ID="error_lbl" Font-Size="X-Large" ForeColor="Red"></asp:Label>
            <br /><br />
            <asp:Button ID="print_btn" runat="server" Visible="false" CssClass="button3 button3 no-print" Text="Print" />
            <br />
            <asp:Label ID="Schools_lbl" runat="server" Font-Size="XX-Large" Font-Underline="false" ></asp:Label>
            <br /><br />
            <asp:GridView ID="businessProfit_dgv" runat="server" AutoGenerateColumns="False" CellPadding="5" CellSpacing="1" PageSize="20" Font-Size="Medium" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="ID" Visible="false" ReadOnly="true" />
                    <asp:BoundField DataField="businessName" HeaderText="Business" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="profits" HeaderText="Profits" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="loan" HeaderText="Loan Amount" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="startingBalance" HeaderText="Starting Amount" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="deposit4" HeaderText="Misc Deposit" ReadOnly="true" Visible="true" />
                </Columns>
            </asp:GridView>
            <br />
        </div>

        <asp:HiddenField ID="visitdate_hf" runat="server" />
        <asp:HiddenField ID="businessID_hf" runat="server" />

        <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
        <script src="../../Scripts.js"></script>
        <script>
            /* Loop through all dropdown buttons to toggle between hiding and showing its dropdown content - This allows the user to have multiple dropdowns without any conflict */
            $(".sub-menu ul").hide();
            $(".sub-menu a").click(function () {
                $(this).parent(".sub-menu").children("ul").slideToggle("100");
                $(this).find(".right").toggleClass("fa-caret-up fa-caret-down");
            });
        </script>

        <asp:SqlDataSource ID="Review_sds" runat="server"></asp:SqlDataSource>
    </form>
</body>
</html>
