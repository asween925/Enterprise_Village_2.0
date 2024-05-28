<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="directory.aspx.vb" Inherits="Enterprise_Village_2._0._Default" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>EV 2.0 - Business Directory</title>

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



        <asp:Label ID="error_lbl" runat="server"></asp:Label>
        <%--Content--%>
        <div class="content">
            <h2 class="h2">Business Directory</h2>
            <%--<asp:Button id="button1" runat="server" PostBackUrl="~/Account_Summary.aspx" CssClass="button button1" Text="ATM"/>--%>
            <div class="button_grid">
                <div class="button_item">
                    <!---Astro Skate--->
                    <asp:Image ID="Image1" runat="server" Class="Business_logo" ImageUrl="~/media/logos/AstroSkate/AstroSkate White Background.png" />
                    <br />
                    <asp:LinkButton ID="LinkButton11" runat="server" PostBackUrl="/pages/student/check_writing_system.aspx?b=10" CssClass="button3">Check Writing Startup</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton12" runat="server" PostBackUrl="/pages/student/sales_system.aspx?b=10" CssClass="button3">Sales Startup</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton4" runat="server" PostBackUrl="/pages/student/manager_system.aspx?b=10" CssClass="button3">Manager System</asp:LinkButton>
                </div>

                <div class="button_item">
                    <!---Achieva Credit Union (formerly Bank of America)--->
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/media/logos/Achieva/achieva.png" Class="Business_logo" />
                    <br />
                    <asp:LinkButton ID="LinkButton9" runat="server" PostBackUrl="/pages/student/check_writing_system.aspx?b=12" CssClass="button3">Check Writing Startup</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton10" runat="server" PostBackUrl="/pages/student/teller_system.aspx" CssClass="button3">Teller Startup</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton3" runat="server" PostBackUrl="~/pages/student/account_summary.aspx" CssClass="button3">ATM</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton36" runat="server" PostBackUrl="/pages/student/manager_system.aspx?b=12" CssClass="button3">Manager System</asp:LinkButton>
                </div>

                <%--<br />--%>

                <div class="button_item">
                    <%--Baycare--%>
                    <asp:Image ID="Image15" runat="server" ImageUrl="~/media/logos/BayCare/bayCare.jpg" Class="Business_logo" />
                    <br />
                    <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="/pages/student/check_writing_system.aspx?b=13" CssClass="button3">Check Writing Startup</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton490" runat="server" PostBackUrl="/pages/student/baycare_admin_assist.aspx" CssClass="button3">BayCare Administrative Assistant</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton37" runat="server" PostBackUrl="/pages/student/manager_system.aspx?b=13" CssClass="button3">Manager System</asp:LinkButton>
                </div>

                <div class="button_item">
                    <%--BBB--%>
                    <asp:Image ID="Image4" runat="server" ImageUrl="~/media/logos/bbb/bbb.png" Class="Business_logo" />
                    <br />
                    <asp:LinkButton ID="LinkButton15" runat="server" PostBackUrl="/pages/student/check_writing_system.aspx?b=9" CssClass="button3">Check Writing Startup</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton16" runat="server" PostBackUrl="/pages/student/sales_system.aspx?b=9" CssClass="button3">Sales Startup</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton5" runat="server" PostBackUrl="/pages/student/manager_system.aspx?b=9" CssClass="button3">Manager System</asp:LinkButton>
                </div>

                <%--<br />--%>

                <div class="button_item">
                    <%--Koozie Group--%>
                    <asp:Image ID="Image5" runat="server" ImageUrl="~/media/logos/Koozie/Koozie.png" Class="Business_logo" />
                    <br />
                    <asp:LinkButton ID="LinkButton17" runat="server" PostBackUrl="/pages/student/check_writing_system.aspx?b=6" CssClass="button3">Check Writing Startup</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton18" runat="server" PostBackUrl="/pages/student/sales_system.aspx?b=6" CssClass="button3">Sales Startup</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton6" runat="server" PostBackUrl="/pages/student/manager_system.aspx?b=6" CssClass="button3">Manager System</asp:LinkButton>
                </div>

                <div class="button_item">
                    <%--City Hall--%>
                    <asp:Image ID="Image6" runat="server" ImageUrl="~/media/logos/city_hall/cityhall.jpg" Class="Business_logo" />
                    <br />
                    <asp:LinkButton ID="LinkButton19" runat="server" PostBackUrl="/pages/student/check_writing_system.aspx?b=14" CssClass="button3">Check Writing Startup</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton38" runat="server" PostBackUrl="/pages/student/manager_system.aspx?b=14" CssClass="button3">Manager System</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton55" runat="server" PostBackUrl="/pages/student/voting_system.aspx" CssClass="button3">Voting System</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton56" runat="server" PostBackUrl="/pages/student/voting_system_mayor.aspx" CssClass="button3">Voting System Mayor</asp:LinkButton>
                </div>

                <%--<br />--%>

                <div class="button_item">
                    <%--CVS--%>
                    <asp:Image ID="Image7" runat="server" ImageUrl="~/media/logos/CVS/CVS.png" Class="Business_logo" />
                    <br />
                    <asp:LinkButton ID="LinkButton21" runat="server" PostBackUrl="/pages/student/check_writing_system.aspx?b=3" CssClass="button3">Check Writing Startup</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton22" runat="server" PostBackUrl="/pages/student/sales_system.aspx?b=3" CssClass="button3">Sales Startup</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton7" runat="server" PostBackUrl="/pages/student/manager_system.aspx?b=3" CssClass="button3">Manager System</asp:LinkButton>
                </div>

                <div class="button_item">
                    <%--Ditek--%>
                    <asp:Image ID="Image8" runat="server" ImageUrl="~/media/logos/Ditek/Ditek.jpg" Class="Business_logo" />
                    <br />
                    <asp:LinkButton ID="LinkButton23" runat="server" PostBackUrl="/pages/student/check_writing_system.aspx?b=11" CssClass="button3">Check Writing Startup</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton24" runat="server" PostBackUrl="/pages/student/sales_system.aspx?b=11" CssClass="button3">Sales Startup</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton8" runat="server" PostBackUrl="/pages/student/manager_system.aspx?b=11" CssClass="button3">Manager System</asp:LinkButton>
                </div>

                <%--<br />--%>

                <div class="button_item">
                    <%--Duke--%>
                    <asp:Image ID="Image9" runat="server" ImageUrl="~/media/logos/Duke/Duke.gif" Class="Business_logo" />
                    <br />
                    <asp:LinkButton ID="LinkButton25" runat="server" PostBackUrl="/pages/student/check_writing_system.aspx?b=16" CssClass="button3">Check Writing Startup</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton40" runat="server" PostBackUrl="/pages/student/manager_system.aspx?b=16" CssClass="button3">Manager System</asp:LinkButton>
                </div>

                <div class="button_item">
                    <%--HSN--%>
                    <asp:Image ID="Image10" runat="server" ImageUrl="~/media/logos/HSN/HSN.png" Class="Business_logo" />
                    <br />
                    <asp:LinkButton ID="LinkButton27" runat="server" PostBackUrl="/pages/student/check_writing_system.aspx?b=8" CssClass="button3">Check Writing Startup</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton28" runat="server" PostBackUrl="/pages/student/sales_system.aspx?b=8" CssClass="button3">Sales Startup</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton13" runat="server" PostBackUrl="/pages/student/manager_system.aspx?b=8" CssClass="button3">Manager System</asp:LinkButton>
                </div>

                <%--<br />--%>

                <div class="button_item">
                    <%--Kanes--%>
                    <asp:Image ID="Image11" runat="server" ImageUrl="~/media/logos/Kanes/Kanes.png" Class="Business_logo" />
                    <br />
                    <asp:LinkButton ID="LinkButton29" runat="server" PostBackUrl="/pages/student/check_writing_system.aspx?b=5" CssClass="button3">Check Writing Startup</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton30" runat="server" PostBackUrl="/pages/student/sales_system.aspx?b=5" CssClass="button3">Sales Startup</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton14" runat="server" PostBackUrl="/pages/student/manager_system.aspx?b=5" CssClass="button3">Manager System</asp:LinkButton>
                </div>

                <div class="button_item">
                    <%--McDonalds--%>
                    <asp:Image ID="Image12" runat="server" ImageUrl="~/media/logos/Mcdonalds/McDonalds.png" Class="Business_logo" />
                    <br />
                    <asp:LinkButton ID="LinkButton31" runat="server" PostBackUrl="/pages/student/check_writing_system.aspx?b=17" CssClass="button3">Check Writing Startup</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="/pages/student/sales_system_mcdonalds.aspx" CssClass="button3">Sales Startup</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton20" runat="server" PostBackUrl="/pages/student/manager_system.aspx?b=17" CssClass="button3">Manager System</asp:LinkButton>
                </div>

                <%--<br />--%>

                <div class="button_item">
                    <%--Mix--%>
                    <asp:Image ID="Image13" runat="server" ImageUrl="~/media/logos/Mix 1007/MIX100.7 Wide.png" Class="Business_logo" />
                    <br />
                    <asp:LinkButton ID="LinkButton33" runat="server" PostBackUrl="/pages/student/check_writing_system.aspx?b=18" CssClass="button3">Check Writing Startup</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton41" runat="server" PostBackUrl="/pages/student/manager_system.aspx?b=18" CssClass="button3">Manager System</asp:LinkButton>
                </div>

                <div class="button_item">
                    <%--Solid Waste--%>
                    <asp:Image ID="Image14" runat="server" ImageUrl="~/media/logos/solid_waste/solid_waste.png" Class="Business_logo" />
                    <br />
                    <asp:LinkButton ID="LinkButton35" runat="server" PostBackUrl="/pages/student/check_writing_system.aspx?b=19" CssClass="button3">Check Writing Startup</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton42" runat="server" PostBackUrl="/pages/student/manager_system.aspx?b=19" CssClass="button3">Manager System</asp:LinkButton>
                </div>

                <%--<br />--%>

                <div class="button_item">
                    <%--KnowBe4--%>
                    <asp:Image ID="Image16" runat="server" ImageUrl="~/media/logos/KnowBe4/KnowBe4 Full Logo Full Color (2).png" Class="Business_logo" />
                    <br />
                    <asp:LinkButton ID="LinkButton39" runat="server" PostBackUrl="/pages/student/check_writing_system.aspx?b=21" CssClass="button3">Check Writing Startup</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton47" runat="server" PostBackUrl="/pages/student/manager_system.aspx?b=21" CssClass="button3">Manager System</asp:LinkButton>
                </div>

                <div class="button_item">
                    <%--Bucs--%>
                    <asp:Image ID="Image18" runat="server" ImageUrl="~/media/logos/Bucs/Bucs.png" Class="Business_logo" />
                    <br />
                    <asp:LinkButton ID="LinkButton43" runat="server" PostBackUrl="/pages/student/check_writing_system.aspx?b=1" CssClass="button3">Check Writing Startup</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton44" runat="server" PostBackUrl="/pages/student/sales_system.aspx?b=1" CssClass="button3">Sales Startup</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton26" runat="server" PostBackUrl="/pages/student/manager_system.aspx?b=1" CssClass="button3">Manager System</asp:LinkButton>
                </div>

                <%--<br />--%>

                <div class="button_item">
                    <%--Rays--%>
                    <asp:Image ID="Image19" runat="server" ImageUrl="~/media/logos/Rays/Rays.png" Class="Business_logo" />
                    <br />
                    <asp:LinkButton ID="LinkButton45" runat="server" PostBackUrl="/pages/student/check_writing_system.aspx?b=2" CssClass="button3">Check Writing Startup</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton46" runat="server" PostBackUrl="/pages/student/sales_system.aspx?b=2" CssClass="button3">Sales Startup</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton32" runat="server" PostBackUrl="/pages/student/manager_system.aspx?b=2" CssClass="button3">Manager System</asp:LinkButton>
                </div>

                <div class="button_item">
                    <%--Times--%>
                    <asp:Image ID="Image21" runat="server" ImageUrl="~/media/logos/Times/times_logo.jpg" Class="Business_logo" />
                    <br />
                    <asp:LinkButton ID="LinkButton49" runat="server" PostBackUrl="/pages/student/check_writing_system.aspx?b=22" CssClass="button3">Check Writing Startup</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton50" runat="server" PostBackUrl="/pages/student/sales_system.aspx?b=22" CssClass="button3">Sales Startup</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton48" runat="server" PostBackUrl="/pages/student/manager_system.aspx?b=22" CssClass="button3">Manager System</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton57" runat="server" PostBackUrl="/pages/student/newspaper_hub.aspx" CssClass="button3">Newspaper Hub</asp:LinkButton>
                </div>

                <%--<br />--%>

                <div class="button_item">
                    <%--TD SYNNEX--%>
                    <asp:Image ID="Image22" runat="server" ImageUrl="~/media/logos/TD synnex/td_synnex.png" Class="Business_logo" />
                    <br />
                    <asp:LinkButton ID="LinkButton51" runat="server" PostBackUrl="/pages/student/check_writing_system.aspx?b=7" CssClass="button3">Check Writing Startup</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton52" runat="server" PostBackUrl="/pages/student/sales_system.aspx?b=7" CssClass="button3">Sales Startup</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton97" runat="server" PostBackUrl="~/pages/student/badge_creator.aspx" CssClass="button3">Badge Creator</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton34" runat="server" PostBackUrl="/pages/student/manager_system.aspx?b=7" CssClass="button3">Manager System</asp:LinkButton>
                </div>

                <div class="button_item">
                    <%--united Way--%>
                    <asp:Image ID="Image23" runat="server" ImageUrl="~/media/logos/United Way/UnitedWaySuncoast_Logo-LRG.png" Class="Business_logo" />
                    <br />
                    <asp:LinkButton ID="LinkButton53" runat="server" PostBackUrl="/pages/student/check_writing_system.aspx?b=24" CssClass="button3">Check Writing Startup</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton54" runat="server" PostBackUrl="/pages/student/manager_system.aspx?b=24" CssClass="button3">Manager System</asp:LinkButton>
                </div>
            </div>
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
