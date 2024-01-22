<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Low_Inventory_Report.aspx.vb" Inherits="Enterprise_Village_2._0.Low_Inventory_Report" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>Low Inventory Report</title>

    <link href="css/Styles.print.css" rel="stylesheet" media="print" type="text/css">
    <link href="css/Styles.updated.css" rel="stylesheet" media="screen" type="text/css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <link rel="shortcut icon" type="image/png" href="media/EV_favicon_2.png" />

    <script src="https://code.jquery.com/jquery-1.10.2.js"></script>
</head>

<body>
    <form id="EMS_Form" runat="server">

        <%--Header information--%>
        <header class="headerTop no-print"><a style="float: left; padding-top: 2px;">Enterprise Village 2.0</a><a style="float: right; padding-right: 30px; padding-top: 2px;"><asp:Label ID="headerSchoolName_lbl" Text="School Name Here" runat="server"></asp:Label></a></header>

        <%--Navigation bar--%>
        <div id="nav-placeholder">
        </div>

        <script>
            $(function () {
                $("#nav-placeholder").load("navInv.html");
            });
        </script>

        <div class="content">
            <h2 class="h2 no-print">Low Inventory Report</h2>
            <h3 class="no-print">Displays all items in the inventory that have an Amount On Hand value of 100 or less.
            </h3>
            <p>
                Sort By:
                <asp:DropDownList ID="sortBy_ddl" runat="server" CssClass="ddl">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Item Name</asp:ListItem>
                    <asp:ListItem>Item Category</asp:ListItem>
                    <asp:ListItem>Current Location</asp:ListItem>
                    <asp:ListItem>Current Location in EV</asp:ListItem>
                    <asp:ListItem>Amount On Hand</asp:ListItem>
                    <asp:ListItem>Source</asp:ListItem>
                    <asp:ListItem>Merch Code</asp:ListItem>
                    <asp:ListItem># Used Daily</asp:ListItem>
                </asp:DropDownList>
                &ensp;
                <asp:DropDownList ID="ascDesc_ddl" runat="server" CssClass="ddl">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Ascending</asp:ListItem>
                    <asp:ListItem>Descending</asp:ListItem>
                </asp:DropDownList>&ensp;<asp:Button ID="sortBy_btn" runat="server" CssClass="button3" Text="Sort" />
            </p>
            <asp:Label ID="error_lbl" runat="server" Font-Size="X-Large" ForeColor="Red"></asp:Label>
            <br /><br />

                <%--Items Table--%>
                 <div>
                        <asp:GridView ID="items_dgv" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="false" DataKeyNames="ID" CellPadding="5" Height="50" AllowPaging="True" ShowHeaderWhenEmpty="True" Font-Size="Medium" Visible="true" PageSize="50" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="true" Visible="true" />
                                <asp:BoundField DataField="itemName" HeaderText="Item Name" Visible="true" />
                                <asp:BoundField DataField="itemCategory" HeaderText="Item Category" Visible="true" />
                                <asp:BoundField DataField="itemSubCat" HeaderText="Item Sub-Category" Visible="true" />
                                <asp:BoundField DataField="currentLocation" HeaderText="Current Location" Visible="true" />
                                <asp:BoundField DataField="businessUsed" HeaderText="Current Location in EV" Visible="true" />
                                <asp:BoundField DataField="onHand" HeaderText="Total Amount On Hand" Visible="true" />
                                <asp:BoundField DataField="source" HeaderText="Source" Visible="true" />                                
                                <asp:BoundField DataField="merchCode" HeaderText="Merch Code" Visible="true" />
                                <asp:BoundField DataField="usedDaily" HeaderText="Amount Used Daily" Visible="true" />
                                <asp:BoundField DataField="comments" HeaderText="Comments" Visible="true" />
                            </Columns>
                        </asp:GridView>
                    </div>
                <br />
            </div>

        <asp:HiddenField ID="visitdate_hf" runat="server" />
        <asp:HiddenField ID="teachers_hf" runat="server" />
        <asp:HiddenField ID="itemID_hf" runat="server" />
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

        <asp:SqlDataSource ID="Review_sds" runat="server"></asp:SqlDataSource>
        <asp:SqlDataSource ID="print_sds" runat="server"></asp:SqlDataSource>
    </form>
</body>
</html>
