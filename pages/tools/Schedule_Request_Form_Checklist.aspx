<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Schedule_Request_Form_Checklist.aspx.vb" Inherits="Enterprise_Village_2._0.Schedule_Request_Form_Checklist" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>EV 2.0 - Schedule Request Form Checklist</title>

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
        <div id="nav-placeholder" class="no-print">
        </div>

        <script>
            $(function () {
                $("#nav-placeholder").load("../../nav.html");
            });
        </script>

        <%--Content--%>
        <div class="content">
            <h2 class="h2">Schedule Request Form Checklist</h2>
            <h3 class="no-print">This page is used to mark which schools have returned their schedule request form.
            </h3>
            <asp:Button ID="clear_btn" runat="server" CssClass="button3 no-print" Text="Clear All Checkboxes" />&ensp;<asp:Button ID="print_btn" runat="server" CssClass="button3 no-print" Text="Print" />&ensp;<asp:Label ID="error_lbl" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="Red"></asp:Label>
            <br class="no-print" />
            <br class="no-print" />

            <div id="confirmClear_div" runat="server" visible="false">
                <p style="font-weight: bold;">Are you sure you want to clear the checkboxes? This will remove all checkmarks from this list and you will have to check them off again after clearing.</p>
                <asp:Button ID="confirmClear_btn" runat="server" Text="Yes, I Want To Clear All Checkboxes" CssClass="button3" />&ensp;<asp:Button ID="cancelClear_btn" runat="server" Text="No, I Don't Want to Clear All Checkboxes" CssClass="button3" />
                <br class="no-print" />
                <br class="no-print" />
            </div>

            <%--Gridview--%>
            <div>
                <asp:GridView ID="schools_dgv" runat="server" AutoGenerateEditButton="true" AutoGenerateColumns="False" AllowPaging="true" DataKeyNames="ID" CellPadding="3" PageSize="500" Height="50" Font-Size="Medium" Visible="true" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="true" Visible="false" />
                        <asp:BoundField DataField="schoolName" HeaderText="School Name" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="teacherName" HeaderText="Contact Teacher Name" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="futureRequestsEmail" HeaderText="Contact Teacher Email" ReadOnly="true" Visible="true" />
                        <asp:TemplateField HeaderText="SRF Returned">
                            <ItemTemplate>
                                <asp:CheckBox ID="spfReturned_chk" runat="server" Checked='<%#Bind("spfReturned") %>' />
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
