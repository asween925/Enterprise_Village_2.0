﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="School_Notes.aspx.vb" Inherits="Enterprise_Village_2._0.School_Notes" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>EV 2.0 - School Notes</title>

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
                $("#nav-placeholder").load("../../nav.html");
            });
        </script>

        <%--Content--%>
        <div class="content">
            <h2 class="h2">School Notes</h2>
            <h3>This page is used to jot down notes for schools and visits when needed.
            </h3>
            <p>School Name:</p>
            <asp:DropDownList ID="schoolName_ddl" runat="server" AutoPostBack="true" CssClass="ddl"></asp:DropDownList>&ensp;<asp:Label ID="error_lbl" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="Red"></asp:Label>
            <br />
            <br />

            <%--School Info Section--%>
            <div id="schoolInfo_div" runat="server" visible="false" class="button_grid_home" style="border-top: 1px solid gray; border-bottom: 1px solid gray; padding-top: 5px; padding-bottom: 5px;">
                <div class="button_item2">
                    <p style="font-weight: bold;" >
                        School Name:
                    <asp:Label ID="schoolName_lbl" runat="server" Font-Bold="false"></asp:Label>
                        <br /><br />
                        Phone Number:
                    <asp:Label ID="schoolPhone_lbl" runat="server" Font-Bold="false"></asp:Label>
                        <br /><br />
                        Contact Teacher:
                    <asp:Label ID="contactTeacher_lbl" runat="server" Font-Bold="false"></asp:Label>
                    </p>
                </div>
                <div class="button_item2">
                    <p style="font-weight: bold;" >
                        School Type:
                    <asp:Label ID="schoolType_lbl" runat="server" Font-Bold="false"></asp:Label>
                        <br /><br />
                        School Number:
                    <asp:Label ID="schoolNumber_lbl" runat="server" Font-Bold="false"></asp:Label>
                        <br /><br />
                        School Address:
                    <asp:Label ID="schoolAddress_lbl" runat="server" Font-Bold="false"></asp:Label>
                    </p>
                </div>
            </div>

            <%--New Entry Section--%>
            <div id="newEntry_div" runat="server" visible="false">
                <p>Enter New Note:</p>
                <asp:TextBox ID="note_tb" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>&ensp;<asp:Button ID="submit_btn" runat="server" Text="Submit" CssClass="button3" />
                <br /><br />
            </div>

            <%--Notes Table--%>
            <div id="schoolNotes_div" runat="server" visible="false">
                <asp:GridView ID="notes_dgv" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="true" AutoGenerateDeleteButton="true" DataKeyNames="ID" CellPadding="5" Height="50" AllowPaging="True" ShowHeaderWhenEmpty="True" Font-Size="Medium" Visible="true" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />
                        <asp:TemplateField HeaderText="School Name">
                            <ItemTemplate>
                                <asp:Label ID="schoolNameDGV_lbl" runat="server" Text='<%#Bind("schoolName") %>' Visible="false"></asp:Label>
                                <asp:DropDownList CssClass="ddl" ID="schoolNameDGV_ddl" runat="server" AutoPostBack="true" readonly="false"></asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Note">
                            <ItemTemplate>
                               <asp:TextBox ID="noteDGV_tb" runat="server" Width="250px" ReadOnly="false" Text='<%#Bind("note") %>' CssClass="textbox"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edited By">
                            <ItemTemplate>
                                <asp:Label ID="noteUserDGV_lbl" runat="server" Text='<%#Bind("noteUser") %>' Visible="true" ReadOnly="true"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Timestamp">
                            <ItemTemplate>
                                <asp:Label ID="noteTimestampDGV_lbl" runat="server" Text='<%#Bind("noteTimestamp") %>' Visible="true" ReadOnly="true"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
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