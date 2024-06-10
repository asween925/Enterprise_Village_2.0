<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Business_profit_updates.aspx.vb" Inherits="Enterprise_Village_2._0.Business_profit_updates" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>EV 2.0 - Edit Profits</title>

    <link href="~/css/Styles.updated.css" rel="stylesheet" media="screen" type="text/css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png" />

<script src="https://code.jquery.com/jquery-1.10.2.js"></script>

</head>

<body>
    <form autocomplete="off"  id="EMS_Form" runat="server">

        <%--Header information--%>
        <header class="headerTop"><a style="float: left; padding-top: 2px;">Enterprise Village 2.0</a><a style="float: right; padding-right: 30px; padding-top: 2px;"><asp:Label ID="headerSchoolName_lbl" Text="School Name Here" runat="server"></asp:Label></a></header>

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
            <h2 class="h2">Edit Profits</h2>
            <h3>This page will allow you to edit the profits and the miscellaneous deposits for each business.
                <br />
                <br />
                Click 'Edit' on the row of the business you which to edit. Change the profit and click 'Update'. 
                The Misc. Deposit will add to the total profits and display on the Online Banking page for that business. If you want to edit the profit directly, make sure that Misc. Deposit is 0 so it doesn't add to the profit.
            </h3>
            <asp:Label ID="error_lbl" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="X-Large"></asp:Label>
            <br />
            <asp:GridView ID="businessProfit_dgv" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="True" DataKeyNames="ID" CellPadding="5" CellSpacing="1" PageSize="20" Font-Size="Medium" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />
                    <asp:BoundField DataField="businessName" HeaderText="Business" ReadOnly="true" Visible="true" />
                    <asp:TemplateField HeaderText="Profits">
                        <ItemTemplate>
                            <asp:TextBox ID="profits_tb" runat="server" Width="50px" Text='<%#Bind("profits") %>' CssClass="textbox"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Misc.<br/> Deposit">
                        <ItemTemplate>
                            <asp:TextBox ID="deposit4_tb" runat="server" Width="50px" Text='<%#Bind("deposit4") %>' CssClass="textbox"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="loan" HeaderText="Loan Amount" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="startingBalance" HeaderText="Starting Amount" ReadOnly="true" Visible="true" />
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

