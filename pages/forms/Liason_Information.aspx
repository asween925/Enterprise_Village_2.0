<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Liason_Information.aspx.vb" Inherits="Enterprise_Village_2._0.Liason_Information" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>EV 2.0 - Family & Community Liaison Information</title>

    <link href="~/css/Styles.updated.css" rel="stylesheet" media="screen" type="text/css">
    <link href="~/css/Styles.print.css" rel="stylesheet" media="print" type="text/css">
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

        <%--Content--%>
        <div class="content">
            <h2 class="h2 no-print">Family & Community Liaison Information</h2>
            <h3 class="no-print">This page is to print out a PDF of visit information for the volunteer liaison for the school.</h3>          
            <p class="no-print">Visit Date:</p>
            <asp:TextBox ID="visitDate_tb" runat="server" TextMode="Date" AutoPostBack="true" CssClass="textbox no-print"></asp:TextBox>&emsp;<asp:Label runat="server" ID="error_lbl" Font-Size="X-Large" ForeColor="Red" CssClass="no-print"></asp:Label>
            <p runat="server" id="school_p" visible="false" class="no-print">School Name:</p>
            <asp:DropDownList ID="schoolName_ddl" runat="server" Visible="false" AutoPostBack="true" CssClass="ddl no-print"></asp:DropDownList>
            <br class="no-print" /><br class="no-print" />
            <asp:Button ID="print_btn" runat="server" Text="Print" CssClass="button3 button3 no-print" Visible="false" />
            <div id="info_div" runat="server" visible="false">
                <h3 style="text-align: center;">Enterprise Village Family & Community Liaison Information</h3>
                <br />
                <p>School: <asp:Label ID="schoolName_lbl" runat="server" Font-Bold="true"></asp:Label>&emsp; Liaison: <asp:Label ID="liaison_lbl" runat="server" Font-Bold="true"></asp:Label></p>
                <p>From: <a style="font-weight: bold;">Kathryn Hilton, Community Liaison, Stavros Institute</a></p>
                <p>Your school is scheduled to visit Enterprise Village on: <asp:Label ID="visitDate_lbl" runat="server" Font-Bold="true"></asp:Label>.</p>
                <p>The number of volunteers needed that day is between <asp:Label ID="vMinCount_lbl" runat="server" Font-Bold="true"></asp:Label> and <asp:Label ID="vMaxCount_lbl" runat="server" Font-Bold="true"></asp:Label></p>
                <p style="font-weight: bold;">Please be aware that this number will be strictly adhered to.</p>
                <p>Training for all volunteers will be held the morning of your school's visit. On <asp:Label ID="visitDate2_lbl" runat="server" Font-Bold="true"></asp:Label>, training will begin promptly at <asp:Label ID="volunteerTime_lbl" runat="server" Font-Bold="true"></asp:Label>. <a style="font-weight: bold;">Please make sure volunteers know to arrive 15 minutes prior to the start of training. Dismissal will be at <asp:Label ID="volunteerDismisal_lbl" runat="server" Font-Bold="true"></asp:Label>.</a></p>
                <p style="font-weight: bold;">Volunteers do NOT need to be Level II approved. They need only be approved, active Level I volunteers. <a style="text-decoration: underline;">They will be required to present a valid photo ID on arrival at Enterprise Village.</a> </p>
                <p>Each fifth grade teacher has an Enterprise Village Parent Volunteer Letter to send home with students. This letter includes an Enterprise Village Response Form to be completed by the student's parent or guardian and returned to that student's teacher.</p>
                <p>Once the students have returned the forms, the teachers should forward all forms or a complete list to you for registration purposes.</p>
                <p>Once the volunteers have been approved, compile a detailed list, indicating that the volunteer has been registered and is eligible to volunteer. <a style="font-weight: bold;">(Please list the volunteers by the name under which they are entered in the volunteer system.)</a></p>
                <p><a style="font-weight: bold; text-decoration: underline;">IMPORTANT:</a> All lists should be sent to Kathryn Hilton (Stavros Institute) no later than <asp:Label ID="replyBy_lbl" runat="server" Font-Bold="true"></asp:Label>.</p>
                <p>Also, please let your staff and parents know that they can learn more about Enterprise Village by accessing our website, <a style="font-weight: bold;">www.stavrosinstitute.org.</a></p>
            </div>

            <%--EV Logo for Printing--%>        
            <asp:Image ID="EVLogo_img" runat="server" ImageUrl="~\media\EnterpriseVillage.png" ImageAlign="bottom" CssClass="EV_logo_print" Visible="false" />
        </div>

        <asp:HiddenField ID="visitdate_hf" runat="server" />
        <asp:HiddenField ID="businessID_hf" runat="server" />

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


