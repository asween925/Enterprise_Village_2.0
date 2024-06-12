<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Open_Closed_Status.aspx.vb" Inherits="Enterprise_Village_2._0.Open_Closed_Status" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>EV 2.0 - Edit Open / Closed Status</title>

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

        <%-- Content--%>
        <div class="content">
            <h2 class="h2">Edit Open / Closed Status</h2>
            <h3>This page is used to open or close a business for the selected visit date.
                <br />
                <br />
                Select a visit date to show the table, then click on 'Edit' on the business you want to close, uncheck the box, and click 'Update'.
            </h3>
            <p>Visit Date</p>
            <asp:TextBox ID="date_tb" runat="server" AutoPostBack="true" TextMode="Date" CssClass="textbox"></asp:TextBox>&emsp;<asp:Label runat="server" ID="error_lbl" Font-Bold="true" Font-Size="X-Large" ForeColor="Red"></asp:Label>
            <br /><br />
            <asp:LinkButton ID="linkbutton" runat="server" PostBackUrl="/pages/forms/Teacher_Letter.aspx" Text="Teacher Letter" CssClass="button3 button3"></asp:LinkButton>
            <br />
            <br />
            <asp:GridView ID="OnlineBanking_dgv" runat="server" DataKeyNames="BusinessID" AutoGenerateColumns="False" AutoGenerateEditButton="True" CellPadding="5" CellSpacing="1" PageSize="20" Font-Size="Medium" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="School ID" ReadOnly="true" Visible="false" />
                    <asp:BoundField DataField="BusinessName" HeaderText="Business Name" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="BusinessID" HeaderText="Business ID" ReadOnly="true" Visible="false" />
                    <asp:TemplateField HeaderText="Open </br> Status">
                        <ItemTemplate>
                            <asp:Label ID="openstatus_lbl" runat="server" Text='<%#Bind("openstatus")%>' Visible="false"></asp:Label>
                            <asp:DropDownList CssClass="ddl" ID="openstatus_ddl" runat="server" Width="70px" AutoPostBack="true" ReadOnly="false">
                                <asp:ListItem>Closed</asp:ListItem>
                                <asp:ListItem>Open</asp:ListItem>
                            </asp:DropDownList>
                            <%--<asp:CheckBox ID="openStatus" runat="Server" Checked='<%#Bind("openstatus")%>' />--%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="School Assigned">
                        <ItemTemplate>
                            <asp:Label ID="schoolName_lbl" runat="server" Text='<%#Bind("schoolID") %>' Visible="false"></asp:Label>
                            <asp:DropDownList CssClass="ddl" ID="schoolName_ddl" runat="server" Width="200px" AutoPostBack="true" ReadOnly="false">
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Volunteer </br> Minimum Count">
                        <ItemTemplate>
                            <asp:TextBox ID="vMinCount_tb" runat="server" Width="100px" Text='<%#Bind("minVolCount") %>' CssClass="textbox"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Volunteer </br> Maximum Count">
                        <ItemTemplate>
                            <asp:TextBox ID="vMaxCount_tb" runat="server" Width="100px" Text='<%#Bind("maxVolCount") %>' CssClass="textbox"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>

        <asp:HiddenField ID="visitdate_hf" runat="server" />
        <asp:HiddenField ID="visitdateUpdate_hf" runat="server" />
        <asp:Label ID="vMin_lbl" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="vMax_lbl" runat="server" Visible="false"></asp:Label>

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
