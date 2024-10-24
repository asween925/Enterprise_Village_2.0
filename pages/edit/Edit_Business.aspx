﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Edit_Business.aspx.vb" MaintainScrollPositionOnPostback="true" Inherits="Enterprise_Village_2._0.Edit_Business" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>EV 2.0 - Edit Business</title>

    <link href="~/css/Styles.updated.css" rel="stylesheet" media="screen" type="text/css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png" />

    <script src="https://code.jquery.com/jquery-1.10.2.js"></script>
</head>

<body>
    <form autocomplete="off" id="EMS_Form" runat="server">

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
            <h2 class="h2">Edit Business</h2>
            <h3>This page allows you to edit various things about the businesses for Enterprise Village.
            </h3>
            <asp:Button ID="changeView_btn" runat="server" Text="Assign Positions" CssClass="button3" />&ensp;<asp:Label ID="error_lbl" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="Red"></asp:Label>
            <br />

            <%--Business Gridview--%>
            <div id="businessTable_div" runat="server" visible="true" class="gridviewDiv">
                <asp:GridView ID="business_dgv" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="true" AutoGenerateDeleteButton="false" DataKeyNames="ID" CellPadding="3" PageSize="7" AllowPaging="True" ShowHeaderWhenEmpty="True" Font-Size="Medium" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" Visible="true">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" Visible="true" ReadOnly="true" />
                        <asp:TemplateField HeaderText="Business Name">
                            <ItemTemplate>
                                <asp:TextBox ID="businessNameDGV_tb" runat="server" ReadOnly="false" Text='<%#Bind("businessName") %>' CssClass="textbox"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Logo" HeaderStyle-Width="200px">
                            <ItemTemplate>
                                <asp:Image ID="businessLogoDGV_img" runat="server" ImageUrl='<%# Eval("logoPath") %>'
                                    Height="80px" Width="100px" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Image ID="img_user" runat="server" ImageUrl='<%# Eval("logoPath") %>'
                                    Height="80px" Width="100px" /><br />
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Address">
                            <ItemTemplate>
                                <asp:TextBox ID="addressDGV_tb" runat="server" Width="250px" ReadOnly="false" Text='<%#Bind("address") %>' CssClass="textbox"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Starting Balance">
                            <ItemTemplate>
                                <asp:TextBox ID="startingBalanceDGV_tb" runat="server" Text='<%#Bind("startingBalance") %>' TextMode="Number" Visible="true" ReadOnly="false" CssClass="textbox"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Job #1">
                            <ItemTemplate>
                                <asp:Label ID="position1DGV_lbl" runat="server" Text='<%#Bind("jobTitle1") %>' Visible="false" ReadOnly="true"></asp:Label>
                                <asp:DropDownList CssClass="ddl" ID="position1DGV_ddl" runat="server" AutoPostBack="true" readonly="false">
                                    <asp:ListItem>Test</asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Job #2">
                            <ItemTemplate>
                                <asp:Label ID="position2DGV_lbl" runat="server" Text='<%#Bind("jobTitle2") %>' Visible="false" ReadOnly="true"></asp:Label>
                                <asp:DropDownList CssClass="ddl" ID="position2DGV_ddl" runat="server" AutoPostBack="true" readonly="false"></asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Job #3">
                            <ItemTemplate>
                                <asp:Label ID="position3DGV_lbl" runat="server" Text='<%#Bind("jobTitle3") %>' Visible="false" ReadOnly="true"></asp:Label>
                                <asp:DropDownList CssClass="ddl" ID="position3DGV_ddl" runat="server" AutoPostBack="true" readonly="false"></asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Job #4">
                            <ItemTemplate>
                                <asp:Label ID="position4DGV_lbl" runat="server" Text='<%#Bind("jobTitle4") %>' Visible="false" ReadOnly="true"></asp:Label>
                                <asp:DropDownList CssClass="ddl" ID="position4DGV_ddl" runat="server" AutoPostBack="true" readonly="false"></asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Job #5">
                            <ItemTemplate>
                                <asp:Label ID="position5DGV_lbl" runat="server" Text='<%#Bind("jobTitle5") %>' Visible="false" ReadOnly="true"></asp:Label>
                                <asp:DropDownList CssClass="ddl" ID="position5DGV_ddl" runat="server" AutoPostBack="true" readonly="false"></asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Job #6">
                            <ItemTemplate>
                                <asp:Label ID="position6DGV_lbl" runat="server" Text='<%#Bind("jobTitle6") %>' Visible="false" ReadOnly="true"></asp:Label>
                                <asp:DropDownList CssClass="ddl" ID="position6DGV_ddl" runat="server" AutoPostBack="true" readonly="false"></asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Job #7">
                            <ItemTemplate>
                                <asp:Label ID="position7DGV_lbl" runat="server" Text='<%#Bind("jobTitle7") %>' Visible="false" ReadOnly="true"></asp:Label>
                                <asp:DropDownList CssClass="ddl" ID="position7DGV_ddl" runat="server" AutoPostBack="true" readonly="false"></asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Job #8">
                            <ItemTemplate>
                                <asp:Label ID="position8DGV_lbl" runat="server" Text='<%#Bind("jobTitle8") %>' Visible="false" ReadOnly="true"></asp:Label>
                                <asp:DropDownList CssClass="ddl" ID="position8DGV_ddl" runat="server" AutoPostBack="true" readonly="false"></asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Job #9">
                            <ItemTemplate>
                                <asp:Label ID="position9DGV_lbl" runat="server" Text='<%#Bind("jobTitle9") %>' Visible="false" ReadOnly="true"></asp:Label>
                                <asp:DropDownList CssClass="ddl" ID="position9DGV_ddl" runat="server" AutoPostBack="true" readonly="false"></asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Job #10">
                            <ItemTemplate>
                                <asp:Label ID="position10DGV_lbl" runat="server" Text='<%#Bind("jobTitle10") %>' Visible="false" ReadOnly="true"></asp:Label>
                                <asp:DropDownList CssClass="ddl" ID="position10DGV_ddl" runat="server" AutoPostBack="true" readonly="false"></asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>

            <%--Assign Jobs to Account Numbers--%>
            <div id="assignJobs_div" runat="server" visible="false">
                <p>Assign Job Titles to Account Numbers:</p>
                <asp:DropDownList ID="businessName_ddl" runat="server" CssClass="ddl" AutoPostBack="true"></asp:DropDownList>
                <br />
                <br />

                <%--Account Number Gridview--%>
                <div id="jobs_div" runat="server" visible="true">
                    <asp:GridView ID="jobs_dgv" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="true" AutoGenerateDeleteButton="false" DataKeyNames="ID" CellPadding="3" PageSize="25" AllowPaging="True" ShowHeaderWhenEmpty="True" Font-Size="Medium" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" Visible="true">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="true" Visible="false" />
                            <asp:BoundField DataField="accountNumber" HeaderText="Account Number" ReadOnly="true" Visible="true" />
                            <asp:TemplateField HeaderText="Job Title">
                                <ItemTemplate>
                                    <asp:Label ID="jobIDDGV_lbl" runat="server" Text='<%#Bind("jobID") %>' Visible="false" ReadOnly="true"></asp:Label>
                                    <asp:DropDownList CssClass="ddl" ID="jobTitleDGV_ddl" runat="server" readonly="false">
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

            <br />
            <br />
        </div>

        <asp:HiddenField ID="currentVisitID_hf" runat="server" />

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
