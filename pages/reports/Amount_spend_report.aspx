<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Amount_spend_report.aspx.vb" Inherits="Enterprise_Village_2._0.Amount_spend_report" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>EV 2.0 - Amount Spent Report</title>

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
            <h2 class="h2 no-print">Amount Spent Report</h2>
            <h3 class="no-print">This page will allow you to view which students have spent their funds.
            </h3>
            <p class="no-print">Visit Date:</p>
            <asp:TextBox ID="visitDate_tb" runat="server" TextMode="Date" AutoPostBack="true" CssClass="textbox no-print"></asp:TextBox>&ensp;<asp:Label ID="error_lbl" runat="server" Font-Size="X-Large" ForeColor="red" Font-Bold="true"></asp:Label>
            <br class="no-print"/>
            <br class="no-print"/>

            <%--Print button, school names, and table--%>
            <div id="content_div" runat="server" visible="false">
                <asp:Button ID="print_btn" runat="server" CssClass="button3 button3 no-print" Text="Print" />
                <br class="no-print"/>
                <p class="no-print">School Name(s):</p>
                <asp:Label ID="Schools_lbl" runat="server" Font-Size="XX-Large" Font-Underline="false"></asp:Label>
                <br />
                <br />

                <%--Gridview--%>
                <asp:GridView ID="businessProfit_dgv" runat="server" AutoGenerateColumns="False" CellPadding="5" CellSpacing="1" PageSize="20" Font-Size="Medium" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows">
                    <Columns>
                        <asp:BoundField DataField="employeeNumber" HeaderText="Account Number" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="studentname" HeaderText="Name" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="totaldeposits" HeaderText="Total Deposits" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="totalpurchases" HeaderText="Total Purchases" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="balance" HeaderText="Balance" ReadOnly="true" Visible="true" />
                    </Columns>
                </asp:GridView>
            </div>


            <asp:HiddenField ID="visitdate_hf" runat="server" />
            <asp:HiddenField ID="businessID_hf" runat="server" />
        </div>

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
