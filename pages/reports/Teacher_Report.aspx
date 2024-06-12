<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Teacher_Report.aspx.vb" Inherits="Enterprise_Village_2._0.Teacher_Report" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>EV 2.0 - Teacher Report</title>

    <link href="~/css/Styles.print.css" rel="stylesheet" media="print" type="text/css">
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
                $("#nav-placeholder").load("../../nav.html");
            });
        </script>

        <div class="content">
            <h2 class="h2 no-print">Teacher Report</h2>
            <h3 class="no-print">This page displays all teachers in the database. Select the school the teacher belongs to from the drop down menu below.
            </h3>
            <p>School Name:</p>
            <asp:DropDownList CssClass="ddl" ID="schools_ddl" runat="server" AutoPostBack="true"></asp:DropDownList>
            <p>Keyword Search:</p>
            <asp:TextBox ID="search_tb" runat="server" CssClass="textbox"></asp:TextBox>
            &nbsp;&nbsp;
            <asp:Button ID="search_btn" runat="server" CssClass="button3" Text="Search" />
            <br />
            <br />
            <asp:Button ID="refresh_btn" runat="server" CssClass="button3" Text="Show All Teachers" />
            <br />
            <br />
            <asp:Label ID="error_lbl" runat="server" Font-Size="X-Large" ForeColor="Red"></asp:Label>
            <br />
            <%--Print Out Table--%>
            <div>
                <asp:GridView ID="teachers_dgv" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="false" DataKeyNames="ID" CellPadding="5" Height="50" AllowPaging="True" ShowHeaderWhenEmpty="True" Font-Size="Medium" Visible="true" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="schoolname" HeaderText="School Name" Visible="true" />
                        <asp:BoundField DataField="futureRequestsEmail" HeaderText="Email" Visible="true" />
                        <asp:BoundField DataField="firstName" HeaderText="First Name" Visible="true" />
                        <asp:BoundField DataField="lastName" HeaderText="Last Name" Visible="true" />
                        <asp:BoundField DataField="password" HeaderText="Password" Visible="true" />
                        <asp:BoundField DataField="county" HeaderText="County" Visible="true" />
                        <asp:BoundField DataField="studentCount" HeaderText="Student Count" Visible="true" />
                        <asp:BoundField DataField="isContact" HeaderText="Contact Teacher?" Visible="true" />
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

        <asp:SqlDataSource ID="Review_sds" runat="server"></asp:SqlDataSource>
        <asp:SqlDataSource ID="print_sds" runat="server"></asp:SqlDataSource>
    </form>
</body>
</html>
