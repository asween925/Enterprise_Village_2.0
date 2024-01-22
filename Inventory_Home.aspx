<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Inventory_Home.aspx.vb" Inherits="Enterprise_Village_2._0.Inventory_Home" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>Home Page - Inventory</title>

    <link href="css/Styles.updated.css" rel="stylesheet" media="screen" type="text/css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <link rel="shortcut icon" type="image/png" href="media/EV_favicon_2.png" />

</head>

<body>
    <form id="EMS_Form" runat="server">

        <%--Header information--%>
        <div id="header-e1">
            Enterprise Village 2.0
        </div>
        <div id="header-e3">
            <asp:Label ID="headerSchoolName_lbl" Text="School Name Here" runat="server"></asp:Label><asp:Label ID="headerSchoolName2_lbl" runat="server"></asp:Label><asp:Label ID="headerSchoolName3_lbl" runat="server"></asp:Label>
        </div>
        <div id="header-e2">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </div>
       
        <%--Content--%>
        <div class="content_home">
            <h2 class="h2" style="text-align: center;">Home Page - Inventory</h2>
            <br />
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Today's Date: " Font-Size="X-Large" ForeColor="Black"></asp:Label>
                <asp:Label ID="visitDate_lbl" runat="server" Font-Size="X-Large" Font-Italic="true" ForeColor="Black"></asp:Label>
                &emsp;    
                
                <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="Student Count: " Font-Size="X-Large" ForeColor="Black"></asp:Label>
                <asp:Label ID="count_lbl" runat="server" Font-Size="X-Large" Font-Italic="true" ForeColor="Black"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Today's School(s): " Font-Size="X-Large" ForeColor="Black"></asp:Label>
                <asp:Label ID="schoolName_lbl" runat="server" Text="No School Visit Created For Today!" Font-Italic="true" Font-Size="X-Large" ForeColor="Black"></asp:Label><asp:Label ID="schoolName2_lbl" runat="server" Font-Size="X-Large" Font-Italic="true" ForeColor="Black"></asp:Label><asp:Label ID="schoolName3_lbl" runat="server" Font-Italic="true" Font-Size="X-Large" ForeColor="Black"></asp:Label>
                <br />
                <br />
            <asp:Label ID="error_lbl" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="Red"></asp:Label>
            <div class="button_grid__inv">
                    <div class="button_item2">
                        <asp:LinkButton ID="create_btn" runat="server" PostBackUrl="/create_item.aspx" CssClass="button_inv_home">Create an Item</asp:LinkButton><br />
                        
                    </div>
                <div class="button_item2">
                    <br />
                        <asp:LinkButton ID="LinkButton3" runat="server" PostBackUrl="/edit_item.aspx" CssClass="button_inv_home">Edit Item</asp:LinkButton><br />
                </div>
                <div class="button_item2">
                    <br />
                        <asp:LinkButton ID="LinkButton4" runat="server" PostBackUrl="/add_remove_amount.aspx" CssClass="button_inv_home">Add / Remove On Hand Amount</asp:LinkButton><br />
                </div>
                <div class="button_item2">
                    <br />
                        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="/low_inventory_report.aspx" CssClass="button_inv_home">Low Inventory Report</asp:LinkButton><br />
                </div>
                <div class="button_item2">
                    <br />
                        <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="/view_all_items.aspx" CssClass="button_inv_home">View All Items</asp:LinkButton><br />
                </div>
                <div class="button_item2">
                    <br />
                        <asp:LinkButton ID="LinkButton5" runat="server" PostBackUrl="/manager_system.aspx?b=11" CssClass="button_inv_home">Ditek Manager System</asp:LinkButton><br />
                </div>
                <div class="button_item2">
                    <br />
                        <asp:LinkButton ID="homePage_btn" runat="server" PostBackUrl="/home_page.aspx" CssClass="button_inv_home" Visible="true">EV 2.0 Home Page</asp:LinkButton><br />
                </div>
            </div>
        </div>

        <asp:HiddenField ID="visitdate_hf" runat="server" />
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
    </form>
</body>
</html>
