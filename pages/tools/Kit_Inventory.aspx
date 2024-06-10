<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Kit_Inventory.aspx.vb" Inherits="Enterprise_Village_2._0.Kit_Inventory" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>EV 2.0 - Kit Inventory</title>

    <link href="~/css/Styles.updated.css" rel="stylesheet" media="screen" type="text/css">
    <link href="~/css/Styles.print.css" rel="stylesheet" media="print" type="text/css">
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
            <h2 class="h2">Kit Inventory</h2>
            <h3>This page allows you to enter in kit inventory information and viewing the list of them all.
            </h3>
            <asp:Button ID="dataEntry_btn" runat="server" Text="Data Entry" CssClass="button3 no-print" />&ensp;<asp:Button ID="kitTable_btn" runat="server" Text="View Inventory List" CssClass="button3 no-print" />&ensp;<asp:Label ID="error_lbl" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="Red"></asp:Label>

            <%--Data Entry--%>
            <div id="dataEntry_div" runat="server" visible="false">
                <p>Kit Number:</p>
                <asp:TextBox ID="kitNumber_tb" runat="server" CssClass="textbox"></asp:TextBox>
                <p>School Name:</p>
                <asp:DropDownList ID="schoolName_ddl" runat="server" CssClass="ddl"></asp:DropDownList>
                <p>Category:</p>
                <asp:DropDownList ID="category_ddl" runat="server" CssClass="ddl">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>PCSB</asp:ListItem>
                    <asp:ListItem>Priv/OC</asp:ListItem>
                    <asp:ListItem>Charter</asp:ListItem>
                    <asp:ListItem>Old Kit (2014)</asp:ListItem>
                    <asp:ListItem>Staff Kit</asp:ListItem>
                    <asp:ListItem>District Kit</asp:ListItem>
                </asp:DropDownList>            
                <p>Date Out:</p>
                <asp:TextBox ID="dateOut_tb" runat="server" TextMode="Date" CssClass="textbox"></asp:TextBox>
                <p>Notes:</p>
                <asp:TextBox ID="notes_tb" runat="server" TextMode="MultiLine" CssClass="textbox"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="dataEntrySubmit_btn" runat="server" Text="Submit" CssClass="button3 no-print" />
            </div>

            <%--Inventory List--%>
            <div id="kitTable_div" runat="server" visible="false">

                <%--Sorting Section--%>
                <div id="sorting_div" runat="server">
                    <p>Search and Sorting:</p>
                    <asp:TextBox ID="search_tb" runat="server" CssClass="textbox"></asp:TextBox>
                    &ensp;<asp:DropDownList ID="searchBy_ddl" runat="server" CssClass="ddl">
                        <asp:ListItem>ID</asp:ListItem>
                        <asp:ListItem>Kit Number</asp:ListItem>
                        <asp:ListItem>School Name</asp:ListItem>
                        <asp:ListItem>Category</asp:ListItem>
                        <asp:ListItem>Date In</asp:ListItem>
                        <asp:ListItem>Date Out</asp:ListItem>
                        <asp:ListItem>GSI Staff</asp:ListItem>
                    </asp:DropDownList>
                    &ensp;<asp:Button ID="search_btn" runat="server" Text="Search" CssClass="button3" />
                    &ensp;|&ensp;
                    <asp:DropDownList ID="sortingColumn_ddl" runat="server" CssClass="ddl">
                        <asp:ListItem>ID</asp:ListItem>
                        <asp:ListItem>Kit Number</asp:ListItem>
                        <asp:ListItem>School Name</asp:ListItem>
                        <asp:ListItem>Category</asp:ListItem>
                        <asp:ListItem>Date In</asp:ListItem>
                        <asp:ListItem>Date Out</asp:ListItem>
                        <asp:ListItem>GSI Staff</asp:ListItem>
                    </asp:DropDownList>
                    &ensp;<asp:DropDownList ID="sortingOrder_ddl" runat="server" CssClass="ddl">
                        <asp:ListItem>Ascending</asp:ListItem>
                        <asp:ListItem>Descending</asp:ListItem>
                    </asp:DropDownList>
                    &ensp;<asp:Button ID="sort_btn" runat="server" CssClass="button3" Text="Sort" />
                    &ensp;|&ensp;
                    <asp:Button ID="refresh_btn" runat="server" CssClass="button3" Text="Refresh" />
                    <br />
                    <br />
                </div>

                <%--Table--%>
                <asp:GridView ID="kits_dgv" runat="server" AllowPaging="True" AutoGenerateColumns="False" AutoGenerateEditButton="true" AutoGenerateDeleteButton="true" CellPadding="5" CellSpacing="1" PageSize="15" Font-Size="Medium" DataKeyNames="ID" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="true" />
                        <asp:TemplateField HeaderText="Kit Number">
                            <ItemTemplate>
                                <asp:TextBox ID="kitNumberDGV_tb" runat="server" ReadOnly="false" Text='<%#Bind("kitNumber") %>' Width="55px" CssClass="textbox"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="School Name">
                            <ItemTemplate>
                                <asp:Label ID="schoolNameDGV_lbl" runat="server" Text='<%#Bind("schoolID") %>' Visible="false"></asp:Label>
                                <asp:DropDownList CssClass="ddl" ID="schoolNameDGV_ddl" runat="server" AutoPostBack="true" readonly="false"></asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Category">
                            <ItemTemplate>
                                <asp:Label ID="categoryDGV_lbl" runat="server" Text='<%#Bind("category") %>' Visible="false"></asp:Label>
                                <asp:DropDownList CssClass="ddl" ID="categoryDGV_ddl" runat="server" Width="100px" AutoPostBack="true" readonly="false">
                                    <asp:ListItem>PCSB</asp:ListItem>
                                    <asp:ListItem>Priv/OC</asp:ListItem>
                                    <asp:ListItem>Charter</asp:ListItem>
                                    <asp:ListItem>Old Kit (2014)</asp:ListItem>
                                    <asp:ListItem>Staff Kit</asp:ListItem>
                                    <asp:ListItem>District Kit</asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date In" Visible="true">
                            <ItemTemplate>
                                <asp:TextBox ID="dateInDGV_tb" runat="server" Width="80px" Text='<%#Bind("dateIn") %>' DataFormatString="{0: MM-dd-yyyy }" CssClass="textbox"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date Out" Visible="true">
                            <ItemTemplate>
                                <asp:TextBox ID="dateOutDGV_tb" runat="server" Width="80px" Text='<%#Bind("dateOut") %>' DataFormatString="{0: MM-dd-yyyy }" CssClass="textbox"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="GSI Staff">
                            <ItemTemplate>
                                <asp:Label ID="gsiStaffDGV_lbl" runat="server" Text='<%#Bind("gsiStaff") %>' Visible="false"></asp:Label>
                                <asp:DropDownList CssClass="ddl" ID="gsiStaffDGV_ddl" runat="server" Width="100px" AutoPostBack="true" readonly="false">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>S. Fritz</asp:ListItem>
                                    <asp:ListItem>B. Mazurek</asp:ListItem>
                                    <asp:ListItem>M. Rush</asp:ListItem>
                                    <asp:ListItem>P. Pittman</asp:ListItem>
                                    <asp:ListItem>D. Sweigart</asp:ListItem>
                                    <asp:ListItem>J. Dunton</asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Notes" Visible="true">
                            <ItemTemplate>
                                <asp:TextBox ID="notesDGV_tb" runat="server" Width="120px" Text='<%#Bind("notes") %>' CssClass="textbox"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </div>
        </div>

        <asp:HiddenField ID="currentVisitID_hf" runat="server" />
        <asp:HiddenField ID="currentSorting_hf" runat="server" />

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
