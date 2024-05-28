<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Staff_List.aspx.vb" Inherits="Enterprise_Village_2._0.Staff_List" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>EV 2.0 - Staff List</title>

    <link href="~/css/Styles.updated.css" rel="stylesheet" media="screen" type="text/css">
    <link href="~/css/Styles.print.css" rel="stylesheet" media="print" type="text/css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png" />

    <script src="https://code.jquery.com/jquery-1.10.2.js"></script>
</head>

<body>
    <form id="EMS_Form" runat="server">

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
            <h2 class="h2">Stavros Staff List</h2>
            <h3 class="no-print">This page contains the list of all staff members at the Stavros Institute.
            </h3>
            <asp:Button ID="viewCreate_btn" runat="server" Text="Add New Staff Member" CssClass="button3 no-print" />&ensp;<asp:Button ID="print_btn" runat="server" CssClass="button3 no-print" Text="Print"/>&ensp;<asp:Label ID="error_lbl" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="Red"></asp:Label>
            
            <%--Create new staff div--%>
            <div id="create_div" runat="server" visible="false" class="no-print">
                <p>First Name:</p>
                <asp:TextBox ID="firstName_tb" runat="server" CssClass="textbox"></asp:TextBox>
                <p>Last Name:</p>
                <asp:TextBox ID="lastName_tb" runat="server" CssClass="textbox"></asp:TextBox>
                <p>Address:</p>
                <asp:TextBox ID="address_tb" runat="server" CssClass="textbox"></asp:TextBox>
                <p>City:</p>
                <asp:TextBox ID="city_tb" runat="server" CssClass="textbox"></asp:TextBox>
                <p>ZIP Code:</p>
                <asp:TextBox ID="zip_tb" runat="server" CssClass="textbox" TextMode="Number"></asp:TextBox>
                <p>PCSB Email:</p>
                <asp:TextBox ID="email_tb" runat="server" CssClass="textbox" TextMode="Email"></asp:TextBox>
                <p>Cell Number:</p>
                <asp:TextBox ID="cell_tb" runat="server" CssClass="textbox" TextMode="Phone"></asp:TextBox>
                <p>Job Title:</p>
                <asp:DropDownList ID="job_ddl" runat="server" CssClass="ddl"></asp:DropDownList>
                <p>Date of Birth:</p>
                <asp:Textbox ID="dob_tb" runat="server" Textmode="Date" CssClass="textbox"></asp:Textbox>
                <br /><br />
                <asp:Button ID="submit_btn" runat="server" Text="Submit" CssClass="button3" />
            </div>
            <br class="no-print"/><br class="no-print"/>
            <asp:GridView ID="staff_dgv" runat="server" AutoGenerateColumns="False" CellPadding="5" CellSpacing="1" PageSize="20" Font-Size="Small" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows">
                <Columns>
                    <asp:BoundField DataField="firstName" HeaderText="First Name" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="lastName" HeaderText="Last Name" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="address" HeaderText="Address" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="city" HeaderText="City" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="zip" HeaderText="ZIP Code" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="email" HeaderText="PCSB Email" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="cellNumber" HeaderText="Cell Number" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="job" HeaderText="Job Title" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="username" HeaderText="Username" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="dob" HeaderText="DOB" ReadOnly="true" Visible="true" />
                </Columns>
            </asp:GridView>
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
