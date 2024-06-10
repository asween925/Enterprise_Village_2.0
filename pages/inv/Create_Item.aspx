<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Create_Item.aspx.vb" Inherits="Enterprise_Village_2._0.Create_Item" MaintainScrollPositionOnPostback="true" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>Create an Item</title>

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
                $("#nav-placeholder").load("navInv.html");
            });
        </script>

        <%--Content--%>
        <div class="content">
            <h2 class="h2">Create an Item</h2>
            <h3>This page will allow you to add a new item to the EV Inventory.
                <br />
                <br />
                Enter all of the information below. Fields that are labeled (Required) must be filled out before submission. Click 'Submit' when you are finished.
            </h3>
            <asp:Label CssClass="no-print" ID="error_lbl" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="Red"></asp:Label>
            <p>Item Name (Required):</p>
            <asp:TextBox ID="itemName_tb" runat="server" CssClass="textbox"></asp:TextBox>
            <p>Item Category:</p>
            <asp:DropDownList CssClass="ddl" ID="itemCategory_ddl" runat="server" AutoPostBack="true">
            </asp:DropDownList>
            <p>Item Sub-Category:</p>
            <asp:DropDownList CssClass="ddl" ID="itemSubCat_ddl" runat="server" Enabled="false">
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList>
            <%--<p>Business Tied to Item:</p>
            <asp:DropDownList CssClass="ddl" ID="itemBusiness_ddl" runat="server" Enabled="True">
                <asp:ListItem>Receiving</asp:ListItem>
            </asp:DropDownList>--%>
            <p>Current Location:</p>
            <asp:DropDownList CssClass="ddl" ID="currentLocation_ddl" runat="server" AutoPostBack="true">
                <asp:ListItem>Receiving</asp:ListItem>
                <asp:ListItem>EV</asp:ListItem>
            </asp:DropDownList>
            <p>Current Location in EV:</p>
            <asp:DropDownList CssClass="ddl" ID="businessUsed_ddl" runat="server" Enabled="false" AutoPostBack="true">
            </asp:DropDownList>
            <p>Amount On Hand (Required):</p>
            <asp:TextBox ID="onHand_tb" runat="server" TextMode="Number" CssClass="textbox"></asp:TextBox>
            <p>Amount Used Daily:</p>
            <asp:TextBox ID="usedDaily_tb" runat="server" TextMode="Number" CssClass="textbox"></asp:TextBox>
            <p>Source:</p>
            <asp:DropDownList CssClass="ddl" ID="source_ddl" runat="server">
                <asp:ListItem>Vendor</asp:ListItem>
                <asp:ListItem>Donation</asp:ListItem>
                <asp:ListItem>In House</asp:ListItem>
            </asp:DropDownList>
            <p>Merch Code:</p>
            <asp:DropDownList CssClass="ddl" ID="merchCode_ddl" runat="server">
                <asp:ListItem>$</asp:ListItem>
                <asp:ListItem>$$</asp:ListItem>
                <asp:ListItem>$$$</asp:ListItem>
            </asp:DropDownList>
            <p>Comments:</p>
            <asp:TextBox ID="comments_tb" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Submit_btn" runat="server" Text="Submit" CssClass="button3" OnClientClick="ScrollToTop()" />
            <br />
            <br />
            <asp:Label ID="error2_lbl" runat="server"></asp:Label>
            <br />
            <br />
            <br />
            <br />
        </div>

        <asp:HiddenField ID="visitdate_hf" runat="server" />
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
        <script>
            function ScrollToTop() {
                window.scrollTo(0, 0);
            }
            //On UpdatePanel Refresh
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            if (prm != null) {
                prm.add_endRequest(function (sender, e) {
                    if (sender._postBackSettings.panelsToUpdate != null) {
                        ScrollToTop();
                    }
                });
            };
        </script>

        <asp:SqlDataSource ID="Review_sds" runat="server"></asp:SqlDataSource>
    </form>
</body>
</html>
