<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Break_Schedules.aspx.vb" Inherits="Enterprise_Village_2._0.Break_Schedules" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>EV 2.0 - Break Schedules</title>

    <link href="~/css/Styles.updated.css" rel="stylesheet" media="screen" type="text/css">
    <link href="~/css/Styles.print.css" rel="stylesheet" media="print" type="text/css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png" />

    <script src="https://code.jquery.com/jquery-1.10.2.js"></script>
</head>

<body>
    <form id="EMS_Form" runat="server">

        <%--Header information--%>
        <header class="headerTop no-print"><a style="float: left; padding-top: 2px;">Enterprise Village 2.0</a><a style="float: right; padding-right: 30px; padding-top: 2px;"><asp:Label ID="headerSchoolName_lbl" Text="School Name Here" runat="server"></asp:Label></a></header>

        <%--Navigation bar--%>
        <div id="nav-placeholder" class="no-print">
        </div>

        <script>
            $(function () {
                $("#nav-placeholder").load("../../nav.html");
            });
        </script>

        <%--Content--%>
        <div class="content" >
            <h2 class="h2 no-print">Break Schedules</h2>
            <h3 class="no-print">You can print out the business break schedules for the current day here.
            </h3>
            <p class="no-print">Business Name:</p>
            <asp:DropDownList ID="businessName_ddl" runat="server" CssClass="ddl no-print" AutoPostBack="true"></asp:DropDownList>&ensp;<asp:Label ID="error_lbl" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="Red" CssClass="no-print"></asp:Label>
            
            <%--School Schedule DDL--%>
            <div id="schoolSch_div" runat="server" visible="false">
                <p class="no-print">School Schedule Time:</p>
                <asp:DropDownList ID="schoolScheduleTime_ddl" runat="server" AutoPostBack="true" CssClass="ddl no-print">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>7:25</asp:ListItem>
                    <asp:ListItem>7:45</asp:ListItem>
                    <asp:ListItem>7:55</asp:ListItem>
                    <asp:ListItem>8:00</asp:ListItem>
                    <asp:ListItem>8:15</asp:ListItem>
                    <asp:ListItem>8:25</asp:ListItem>
                    <asp:ListItem>8:30</asp:ListItem>
                    <asp:ListItem>8:45</asp:ListItem>
                    <asp:ListItem>8:50</asp:ListItem>
                    <asp:ListItem>8:55</asp:ListItem>
                    <asp:ListItem>9:10</asp:ListItem>
                    <asp:ListItem>9:30</asp:ListItem>
                    <asp:ListItem>9:40</asp:ListItem>
                </asp:DropDownList>
                <br class="no-print" /><br class="no-print" />
            </div>

           <%-- Break Schedule Form--%>
            <div id="breakSchedule_div" runat="server" visible="false" class="break_schedules_printing_moving_up">
                <asp:Button ID="print_btn" runat="server" CssClass="button3 no-print" Text="Print on Legal Paper" />
                <br class="no-print" /><br class="no-print" />
                <p style="font-weight: bold; text-align: center; text-decoration: underline;"><asp:Label ID="businessName_lbl" runat="server" Font-Size="Large"></asp:Label></p>
                <p style="font-weight: bold; text-align: center; font-size: 14px;">Break Schedule</p>
                <p style="font-weight: bold; text-align: center;"><asp:Label ID="schoolSchedule_lbl" runat="server" Font-Size="Large"></asp:Label></p>

                <%--Group A--%>
                <div class="button_grid_home" style="border-top: 3px solid black; ">
                    <div class="button_item2" style="margin-top: -10px;">
                        <h2 style="font-size: 26px;">A</h2>
                        <p class="Break1" style="font-style:italic;">Break #1 (10 Minutes)</p>
                        <p class="Break1" style="font-style:italic; font-weight: bold;"><asp:Label ID="break1ATime_lbl" runat="server"></asp:Label></p>
                        <p class="Break2" style="font-style:italic;">Break #2 (20 Minutes)</p>
                        <p class="Break2" style="font-style:italic; font-weight: bold;"><asp:Label ID="break2ATime_lbl" runat="server"></asp:Label></p>
                        <p class="Break3" style="font-style:italic;">Break #3 (25 Minutes)</p>
                        <p class="Break3" style="font-style:italic; font-weight: bold;"><asp:Label ID="break3ATime_lbl" runat="server"></asp:Label></p>
                    </div>

                    <div class="button_item2" style="margin-top: -10px;">
                        <h2 style="font-size: 26px;">Jobs</h2>
                        <p id="job1A_p" runat="server" visible="false" style="padding: 5px;"><asp:Label ID="job1A_lbl" runat="server" Text="Sale Associate #1"></asp:Label>&emsp;<a>______________________________________________</a></p>
                        <p id="job2A_p" runat="server" visible="false" style="padding: 5px;"><asp:Label ID="job2A_lbl" runat="server" Text="Sale Associate #1"></asp:Label>&emsp;<a>______________________________________________</a></p>
                        <p id="job3A_p" runat="server" visible="false" style="padding: 5px;"><asp:Label ID="job3A_lbl" runat="server" Text="Sale Associate #1"></asp:Label>&emsp;<a>______________________________________________</a></p>
                        <p id="job4A_p" runat="server" visible="false" style="padding: 5px;"><asp:Label ID="job4A_lbl" runat="server" Text="Sale Associate #1"></asp:Label>&emsp;<a>______________________________________________</a></p>
                        <p id="job5A_p" runat="server" visible="false" style="padding: 5px;"><asp:Label ID="job5A_lbl" runat="server" Text="Sale Associate #1"></asp:Label>&emsp;<a>______________________________________________</a></p>
                    </div>
                </div>                

                <%--Group B--%>
                <div class="button_grid_home" style="border-top: 3px solid black; margin-top: -10px;">
                    <div class="button_item2" style="margin-top: -10px;">
                        <h2 style="font-size: 26px;">B</h2>
                        <p class="Break1" style="font-style:italic;">Break #1 (10 Minutes)</p>
                        <p class="Break1" style="font-style:italic; font-weight: bold;"><asp:Label ID="break1BTime_lbl" runat="server"></asp:Label></p>
                        <p class="Break2" style="font-style:italic;">Break #2 (20 Minutes)</p>
                        <p class="Break2" style="font-style:italic; font-weight: bold;"><asp:Label ID="break2BTime_lbl" runat="server"></asp:Label></p>
                        <p class="Break3" style="font-style:italic;">Break #3 (25 Minutes)</p>
                        <p class="Break3" style="font-style:italic; font-weight: bold;"><asp:Label ID="break3BTime_lbl" runat="server"></asp:Label></p>
                    </div>

                    <div class="button_item2" style="margin-top: -10px;">
                        <h2 style="font-size: 26px;">Jobs</h2>
                        <p id="job1B_p" runat="server" visible="false" style="padding: 5px;"><asp:Label ID="job1B_lbl" runat="server" Text="Sale Associate #1"></asp:Label>&emsp;<a>______________________________________________</a></p>
                        <p id="job2B_p" runat="server" visible="false" style="padding: 5px;"><asp:Label ID="job2B_lbl" runat="server" Text="Sale Associate #1"></asp:Label>&emsp;<a>______________________________________________</a></p>
                        <p id="job3B_p" runat="server" visible="false" style="padding: 5px;"><asp:Label ID="job3B_lbl" runat="server" Text="Sale Associate #1"></asp:Label>&emsp;<a>______________________________________________</a></p>
                        <p id="job4B_p" runat="server" visible="false" style="padding: 5px;"><asp:Label ID="job4B_lbl" runat="server" Text="Sale Associate #1"></asp:Label>&emsp;<a>______________________________________________</a></p>
                    </div>
                </div>

                <%--Group C--%>
                <div class="button_grid_home" style="border-top: 3px solid black; margin-top: -10px;">
                    <div class="button_item2" style="margin-top: -10px;">
                        <h2 style="font-size: 26px;">C</h2>
                        <p class="Break1" style="font-style:italic;">Break #1 (10 Minutes)</p>
                        <p class="Break1" style="font-style:italic; font-weight: bold;"><asp:Label ID="break1CTime_lbl" runat="server"></asp:Label></p>
                        <p class="Break2" style="font-style:italic;">Break #2 (20 Minutes)</p>
                        <p class="Break2" style="font-style:italic; font-weight: bold;"><asp:Label ID="break2CTime_lbl" runat="server"></asp:Label></p>
                        <p class="Break3" style="font-style:italic;">Break #3 (25 Minutes)</p>
                        <p class="Break3" style="font-style:italic; font-weight: bold;"><asp:Label ID="break3CTime_lbl" runat="server"></asp:Label></p>
                    </div>

                    <div class="button_item2" style="margin-top: -10px;">
                        <h2 style="font-size: 26px;">Jobs</h2>
                        <p id="job1C_p" runat="server" visible="false" style="padding: 5px;"><asp:Label ID="job1C_lbl" runat="server" Text="Sale Associate #1"></asp:Label>&emsp;<a>______________________________________________</a></p>
                        <p id="job2C_p" runat="server" visible="false" style="padding: 5px;"><asp:Label ID="job2C_lbl" runat="server" Text="Sale Associate #1"></asp:Label>&emsp;<a>______________________________________________</a></p>
                        <p id="job3C_p" runat="server" visible="false" style="padding: 5px;"><asp:Label ID="job3C_lbl" runat="server" Text="Sale Associate #1"></asp:Label>&emsp;<a>______________________________________________</a></p>
                    </div>
                </div>

                <%--Schedule Times--%>
                <div class="button_grid_home" style="border-top: 3px solid black; margin-top: -10px;">
                    <div class="button_item2" style="margin-top: -10px;">
                        <p style="font-style:italic; color: purple;">Business Meeting #1 (10 Minutes)</p>
                        <p style="font-style:italic; color: orange;">Setup Time</p>
                        <p class="Break1" style="font-style:italic;">Business Meeting #2 (10 Minutes)</p>
                        <p class="Break2" style="font-style:italic;">Business Meeting #3 (10 Minutes)</p>
                        <p class="Break3" style="font-style:italic;">Clean-up Time (5 Minutes)</p>
                        <p style="font-style:italic; color: black;">Town Meeting (10 Minutes)</p>
                    </div>
                    
                    <div class="button_item2" style="margin-top: -10px;">
                        <p style="color: purple;" >9:55 - 10:05</p>
                        <p style="color: orange;">10:05 - Until National Anthem</p>
                        <p class="Break1">11:00 - 11:10</p>
                        <p class="Break2">12:10 - 12:20</p>
                        <p class="Break3">1:35 - 1:40</p>
                        <p style="color: black;">1:40</p>
                    </div>
                </div>
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
