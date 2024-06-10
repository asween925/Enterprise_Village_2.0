<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="teacher_input.aspx.vb" Inherits="Enterprise_Village_2._0.teacher_input" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>EV 2.0 - Create a Teacher</title>

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

        

        <%--Content--%>
        <div class="content">
            <h2 class="h2">Create a Teacher</h2>
            <h3>This page will allow you to add a new teacher to the database.
                <br /><br />
                Enter the teacher's first name, last name, school, school email, school county, and the approximate student count. Click 'Submit' when you are finished.
            </h3>
            <p>First Name:</p>
            <asp:TextBox ID="firstName_tb" runat="server" CssClass="textbox"></asp:TextBox>
            <p>Last Name (Required): </p>
            <asp:TextBox ID="lastName_tb" runat="server" CssClass="textbox"></asp:TextBox>
            <p>School Name (Required):</p>
            <asp:DropDownList CssClass="ddl" runat="server" ID="school_ddl"></asp:DropDownList>
            <p>Teacher Email (Required):</p>
            <asp:TextBox ID="email_tb" runat="server" CssClass="textbox"></asp:TextBox>
            <p>County:</p>
            <asp:TextBox ID="county_tb" runat="server" CssClass="textbox"></asp:TextBox>
            <p>Student Count:</p>
            <asp:TextBox ID="count_tb" runat="server" CssClass="textbox"></asp:TextBox>
            <p>Contact Teacher? (Checked is Yes)</p>
            <asp:CheckBox ID="contact_chk" runat="server"/>
            <%--<p>Teacher Password (Only Needed For non-PCSB Teachers):</p>
            <asp:TextBox ID="password_tb" runat="server"></asp:TextBox>--%>
            <br />
            <br />
            <asp:Button ID="Submit_btn" runat="server" Text="Submit" CssClass="button3" />
            <br />
            <br />
            <asp:Label ID="error_lbl" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="Red"></asp:Label>
            <asp:Label ID="error2_lbl" runat="server"></asp:Label>
        </div>

        <asp:HiddenField ID="visitdate_hf" runat="server" />
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
