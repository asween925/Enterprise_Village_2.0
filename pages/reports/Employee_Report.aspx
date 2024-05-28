<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Employee_Report.aspx.vb" Inherits="Enterprise_Village_2._0.Employee_Report" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>EV 2.0 - Student Report</title>

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
                $("#nav-placeholder").load("../../nav.html");
            });
        </script>

        <div class="content">
            <h2 class="h2">Student Report</h2>
            <h3 class="no-print">This page will allow you to view all students in EV for the day. Use the school name drop down menu to only see students from the selected school. Select the blank space in the drop down menu to see all students. You can also print out a copy of this page.
            </h3>
            <p class="no-print">Enter Visit Date:</p>
            <asp:TextBox ID="visitDate_tb" runat="server" AutoPostBack="true" CssClass="textbox no-print" TextMode="Date"></asp:TextBox>&ensp;<asp:Label ID="error_lbl" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="Red"></asp:Label>

            <div runat="server" id="schoolDDLDIV" visible="false">
                <p class="no-print">Select School Name:</p>
                <asp:DropDownList CssClass="ddl no-print" ID="schoolName_ddl" runat="server" AutoPostBack="true"></asp:DropDownList>
                <p class="no-print">Or:</p>
                <p class="no-print">Select Business:</p>
                <asp:DropDownList ID="business_ddl" runat="server" AutoPostBack="true" CssClass="ddl no-print"></asp:DropDownList>
                <br class="no-print" />
                <br class="no-print" />
                <asp:Button ID="print_btn" runat="server" CssClass="button3 no-print" Text="Print" /><asp:Button ID="show_btn" runat="server" CssClass="button3 no-print" Text="Show Empty Names" />
                <br class="no-print" />
                <asp:Label ID="schoolName_lbl" runat="server" Font-Size="X-Large" Font-Underline="True"></asp:Label>
                <p>Businesses Closed:
                    <asp:Label ID="closedBiz_lbl" runat="server"></asp:Label></p>
                <asp:Label ID="studentCount_lbl" runat="server" Font-Size="X-Large" Font-Underline="true" ForeColor="Red" Font-Bold="true"></asp:Label>
                <br />
                <br />
            </div>

            <asp:GridView ID="employees_dgv" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" CellPadding="5" CellSpacing="1" PageSize="20" Font-Size="Medium" Visible="true" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />
                    <asp:BoundField DataField="employeeNumber" HeaderText="Account Number" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="businessName" HeaderText="Business" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="jobTitle" HeaderText="Job Title" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="firstName" HeaderText="First Name" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="lastName" HeaderText="Last Name" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="schoolName" HeaderText="School Name" ReadOnly="true" Visible="true" />
                </Columns>
            </asp:GridView>

            <br />
        </div>


        <asp:HiddenField ID="visitdate_hf" runat="server" />
        <asp:HiddenField ID="visitdateUpdate_hf" runat="server" />

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
