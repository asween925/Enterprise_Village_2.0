﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Edit_Item.aspx.vb" Inherits="Enterprise_Village_2._0.Edit_Item" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>Edit Item</title>

    <link href="~/css/Styles.print.css" rel="stylesheet" media="print" type="text/css">
    <link href="~/css/Styles.updated.css" rel="stylesheet" media="screen" type="text/css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png" />

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

        <%--Content--%>
        <div class="content">
            <h2 class="h2 no-print">Edit Item</h2>
            <h3 class="no-print">This page allows you to edit the items in the EV inventory.
                <br />
                You can search for an item name by using the search bar or sort items using the two drop down menus next to "Sort By". You can also filter through the items by the Current Location in EV.
            </h3>
            <p>
                Item Name Search:
                <asp:TextBox ID="search_tb" runat="server" CssClass="textbox"></asp:TextBox>&ensp;<asp:Button ID="search_btn" runat="server" CssClass="button3" Text="Search" />&ensp;<asp:Label ID="error_lbl" runat="server" ForeColor="Red" Font-Size="X-Large"></asp:Label>
            </p>
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
                </asp:DropDownList>&ensp;<asp:Button ID="sortBy_btn" runat="server" CssClass="button3" Text="Sort" />&ensp;|&ensp;
                Filter By:
                <asp:DropDownList ID="filterBy_ddl" runat="server" CssClass="ddl">
                </asp:DropDownList>
                <asp:Button ID="filterBy_btn" runat="server" CssClass="button3" Text="Filter" />&ensp;|&ensp;<asp:Button ID="reload_btn" runat="server" CssClass="button3" Text="Refresh" />
            </p>
            <br />

            <%--Data Table--%>
            <div style="overflow-x: scroll; width: 85%; overflow-y: scroll; height: 65%;">
                <asp:GridView ID="items_dgv" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="True" AutoGenerateDeleteButton="true" DataKeyNames="ID" CellPadding="5" Height="50" AllowPaging="True" ShowHeaderWhenEmpty="True" Font-Size="Medium" Visible="true" PageSize="10" AllowSorting="true" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />
                        <asp:TemplateField HeaderText="Item Name">
                            <ItemTemplate>
                                <asp:TextBox ID="itemName_tb" runat="server" Width="200px" ReadOnly="false" Text='<%#Bind("itemName") %>' CssClass="textbox">
                                </asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Item Category">
                            <ItemTemplate>
                                <asp:Label ID="itemCategory_lbl" runat="server" Text='<%#Bind("itemCategory") %>' Visible="false"></asp:Label>
                                <asp:DropDownList CssClass="ddl" ID="itemCategory_ddl" runat="server" Width="100px" AutoPostBack="true" readonly="false" OnSelectedIndexChanged="itemCategory_ddl_SelectedIndexChanged"></asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Item Sub-Category">
                            <ItemTemplate>
                                <asp:Label ID="itemSubCat_lbl" runat="server" Text='<%#Bind("itemSubCat") %>' Visible="false"></asp:Label>
                                <asp:DropDownList CssClass="ddl" ID="itemSubCat_ddl" runat="server" Width="100px" AutoPostBack="true" readonly="false"></asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Current Location">
                            <ItemTemplate>
                                <asp:Label ID="currentLocation_lbl" runat="server" Text='<%#Bind("currentLocation") %>' Visible="false"></asp:Label>
                                <asp:DropDownList CssClass="ddl" ID="currentLocation_ddl" runat="server" Width="100px" AutoPostBack="true" readonly="false" OnSelectedIndexChanged="currentLocation_ddl_SelectedIndexChanged">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Current Location in EV">
                            <ItemTemplate>
                                <asp:Label ID="businessUsed_lbl" runat="server" Text='<%#Bind("businessUsed") %>' Visible="false"></asp:Label>
                                <asp:DropDownList CssClass="ddl" ID="businessUsed_ddl" runat="server" Width="150px" AutoPostBack="true" readonly="false"></asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Amount On Hand">
                            <ItemTemplate>
                                <asp:TextBox ID="onHand_tb" runat="server" Width="60px" Text='<%#Bind("onHand") %>' TextMode="Number" Enabled="true" CssClass="textbox"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Source">
                            <ItemTemplate>
                                <asp:Label ID="source_lbl" runat="server" Text='<%#Bind("source") %>' Visible="false"></asp:Label>
                                <asp:DropDownList CssClass="ddl" ID="source_ddl" runat="server" Width="100px" AutoPostBack="true" readonly="false">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Merch Code">
                            <ItemTemplate>
                                <asp:Label ID="merchCode_lbl" runat="server" Text='<%#Bind("merchCode") %>' Visible="false"></asp:Label>
                                <asp:DropDownList CssClass="ddl" ID="merchCode_ddl" runat="server" Width="50px" AutoPostBack="true" readonly="false">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="# Used Daily">
                            <ItemTemplate>
                                <asp:TextBox ID="usedDaily_tb" runat="server" Width="60px" Text='<%#Bind("usedDaily") %>' TextMode="Number" Enabled="true" CssClass="textbox"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Comments">
                            <ItemTemplate>
                                <asp:TextBox ID="comments_tb" runat="server" Width="200px" ReadOnly="false" Text='<%#Bind("comments") %>' CssClass="textbox">
                                </asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
            </div>
        </div>

        <asp:HiddenField ID="visitdate_hf" runat="server" />
        <asp:HiddenField ID="teachers_hf" runat="server" />
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

        <%--Delete confirmation--%>
        <script>
            jQuery("a").filter(function () {
                return this.innerHTML.indexOf("Delete") == 0;
            }).click(function () {
                return confirm("Are you sure you want to delete this item?");
            });
        </script>

        <asp:SqlDataSource ID="Review_sds" runat="server"></asp:SqlDataSource>
        <asp:SqlDataSource ID="print_sds" runat="server"></asp:SqlDataSource>
    </form>
</body>
</html>
