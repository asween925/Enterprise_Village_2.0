<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Create_School.aspx.vb" Inherits="Enterprise_Village_2._0.Create_School" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>EV 2.0 - Create a School</title>

    <link href="~/css/Styles.updated.css" rel="stylesheet" media="screen" type="text/css">
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
            <h2 class="h2">Create a School</h2>
            <h3>This page will allow you to add a new school to the database.
                <br /><br />
                Enter all of the information below. The required section must all be filled out before finishing. Click 'Submit' when you are finished.
            </h3>
            <asp:Label CssClass="no-print" ID="error_lbl" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="Red"></asp:Label>
            <p>School Name: (Required)</p>
            <asp:TextBox ID="schoolName_tb" runat="server" CssClass="textbox"></asp:Textbox>
            <p>Phone Number: (Required)</p>
            <asp:TextBox ID="phoneNum_tb" runat="server" TextMode="Phone" CssClass="textbox"></asp:TextBox>
            <p>Administrator First Name: </p>
            <asp:TextBox ID="principalFirst_tb" runat="server" CssClass="textbox"></asp:Textbox>
            <p>Administrator Last Name:</p>
            <asp:TextBox ID="principalLast_tb" runat="server" CssClass="textbox"></asp:Textbox>            
            <p hidden="hidden">Fax Number:</p>
            <asp:TextBox ID="faxNum_tb" runat="server" Visible="false"></asp:TextBox>
            <p>School Number:</p>
            <asp:TextBox ID="schoolNum_tb" runat="server" TextMode="Number" CssClass="textbox"></asp:TextBox>
            <p>School Hours:</p>
            <asp:TextBox ID="schoolHours_tb" runat="server" CssClass="textbox"></asp:Textbox>
            <p>School Type:</p>
            <asp:DropDownList CssClass="ddl" ID="schoolType_ddl" runat="server">
                <asp:ListItem>Public</asp:ListItem>
                <asp:ListItem>Private</asp:ListItem>
                <asp:ListItem>Charter</asp:ListItem>
                <asp:ListItem>OC</asp:ListItem>
                <asp:ListItem>Religious</asp:ListItem>
            </asp:DropDownList>
            <p>Administrator Email:</p>
            <asp:TextBox ID="futureRequestsEmail_tb" runat="server" TextMode="Email" CssClass="textbox"></asp:TextBox>
            <p>Notes:</p>
            <asp:TextBox ID="futureRequestsNotes_tb" runat="server" CssClass="textbox"></asp:Textbox>
            <p>County:</p>
            <asp:TextBox ID="county_tb" runat="server" CssClass="textbox"></asp:Textbox>
            <p>Liaison:</p>
            <asp:TextBox ID="liaison_tb" runat="server" CssClass="textbox"></asp:Textbox>
            <br /><br />         
            <asp:Button ID="Submit_btn" runat="server" Text="Submit" CssClass="button3" />
            <br /><br />           
            
            <asp:Label ID="error2_lbl" runat="server"></asp:Label>
            <br /><br /><br /><br />
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
