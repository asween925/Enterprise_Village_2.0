<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Business_sales_report.aspx.vb" Inherits="Enterprise_Village_2._0.Business_sales_report" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>EV 2.0 - Business Sales Report</title>

    <link href="~/css/Styles.print.css" rel="stylesheet" media="print" type="text/css">
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
            <h2 class="h2">Business Sales Report</h2>
            <h3 class="no-print">This page will allow you to view sales from each business. Select the business from the drop down menu below.
            </h3>
            <p>Visit Date:</p>
            <asp:TextBox ID="visitDate_tb" runat="server" TextMode="Date" AutoPostBack="true" CssClass="textbox"></asp:TextBox>&ensp;<asp:Label runat="server" ID="error_lbl" Font-Bold="True" Font-Size="X-Large" ForeColor="Red"></asp:Label>
            <p class="no-print" id="selectBusiness_p" runat="server" visible="false">Select Business</p>
            <asp:DropDownList CssClass="ddl" ID="business_ddl" runat="server" AutoPostBack="True" visible="false"></asp:DropDownList> 
            <br /><br />
            <asp:Button ID="print_btn" runat="server" CssClass="button3 button3 no-print" Text="Print" />
            <br /><br />
            <asp:Label runat="server" Text="Total Sales: " Font-Bold="true" Font-Size="X-Large" ID="totalSales_p" Visible="false"></asp:Label>
            <asp:Label runat="server" ID="total_sales_lbl" Text="$0.00" Font-Bold="true" Font-Size="X-Large" Visible="false"></asp:Label>
            <br /><br />          
            
            <asp:GridView ID="businessSales_dgv" runat="server" AutoGenerateColumns="False" CellPadding="5" CellSpacing="1" PageSize="20" Font-Size="Medium" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows">
                <Columns>
                    <asp:BoundField DataField="employeeNumber" HeaderText="Account Number" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="studentName" HeaderText="Student Name" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="saleAmount" HeaderText="Sale Amount" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="transactionTimeStamp" HeaderText="Time Stamp" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="saleAmount2" HeaderText="Sale Amount 2" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="transactionTimeStamp2" HeaderText="Time Stamp 2" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="saleAmount3" HeaderText="Sale Amount 3" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="transactionTimeStamp3" HeaderText="Time Stamp 3" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="saleAmount4" HeaderText="Sale Amount 4" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="transactionTimeStamp4" HeaderText="Time Stamp 4" ReadOnly="true" Visible="true" />
                </Columns>
            </asp:GridView>
            <br />
        </div>

        <asp:HiddenField ID="visitdate_hf" runat="server" />
        <asp:HiddenField ID="businessID_hf" runat="server" />
        <asp:SqlDataSource ID="Review_sds" runat="server"></asp:SqlDataSource>

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

    </form>
</body>
</html>
