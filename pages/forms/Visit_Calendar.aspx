<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Visit_Calendar.aspx.vb" Inherits="Enterprise_Village_2._0.Visit_Calendar" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>EV 2.0 - Visit Calendar</title>

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
            <h2 class="h2">Visit Calendar</h2>
            <h3>This page is used to view all of the visits for a selected month in a calendar format.
                <br />
                <br />
                Select a month to view from the drop down menu to view the visits for the month. You can also click on a school to be directed to that school's student report page.
            </h3>
            <p>Select Month:</p>
            <asp:DropDownList ID="month_ddl" runat="server" CssClass="ddl no-print" AutoPostBack="true" >
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>January</asp:ListItem>
                <asp:ListItem>February</asp:ListItem>
                <asp:ListItem>March</asp:ListItem>
                <asp:ListItem>April</asp:ListItem>
                <asp:ListItem>May</asp:ListItem>
                <asp:ListItem>June</asp:ListItem>
                <asp:ListItem>July</asp:ListItem>
                <asp:ListItem>August</asp:ListItem>
                <asp:ListItem>September</asp:ListItem>
                <asp:ListItem>October</asp:ListItem>
                <asp:ListItem>November</asp:ListItem>
                <asp:ListItem>December</asp:ListItem>
            </asp:DropDownList>&ensp;<asp:Label ID="error_lbl" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="Red"></asp:Label>
            <br />

            <%--Weekly Calendar--%>
                <div class="Visit_Calendar_Calendar_Outer" id="calendarView_div" runat="server" visible="false">

                    <%--Week 1--%>
                    <div class="Visit_Calendar_Calendar_Inner">
                        <div class="Visit_Calendar_Calendar_Block VCC_Mon VCC_W1">
                            <a class="Visit_Calendar_Calendar_Day">Monday</a>
                            <asp:Label ID="monday1_lbl" runat="server" CssClass="Visit_Calendar_Calendar_Number" Text="0"></asp:Label>
                            <br />
                            <br />
                            <asp:Button ID="monday1School1_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="monday1School2_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="monday1School3_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="monday1School4_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="monday1School5_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                        </div>
                        <div class="Visit_Calendar_Calendar_Block VCC_Tue VCC_W1">
                            <a class="Visit_Calendar_Calendar_Day">Tuesday</a>
                            <asp:Label ID="tuesday1_lbl" runat="server" CssClass="Visit_Calendar_Calendar_Number" Text="0"></asp:Label>
                            <br />
                            <br />
                            <asp:Button ID="tuesday1School1_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="tuesday1School2_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="tuesday1School3_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="tuesday1School4_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="tuesday1School5_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                        </div>
                        <div class="Visit_Calendar_Calendar_Block VCC_Wed VCC_W1">
                            <a class="Visit_Calendar_Calendar_Day">Wednesday</a>
                            <asp:Label ID="wednesday1_lbl" runat="server" CssClass="Visit_Calendar_Calendar_Number" Text="0"></asp:Label>
                            <br />
                            <br />
                            <asp:Button ID="wednesday1School1_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="wednesday1School2_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="wednesday1School3_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="wednesday1School4_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="wednesday1School5_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                        </div>
                        <div class="Visit_Calendar_Calendar_Block VCC_Thu VCC_W1">
                            <a class="Visit_Calendar_Calendar_Day">Thursday</a>
                            <asp:Label ID="thursday1_lbl" runat="server" CssClass="Visit_Calendar_Calendar_Number" Text="0"></asp:Label>
                            <br />
                            <br />
                            <asp:Button ID="thursday1School1_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="thursday1School2_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="thursday1School3_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="thursday1School4_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="thursday1School5_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                        </div>
                        <div class="Visit_Calendar_Calendar_Block VCC_Fri VCC_W1">
                            <a class="Visit_Calendar_Calendar_Day">Friday</a>
                            <asp:Label ID="friday1_lbl" runat="server" CssClass="Visit_Calendar_Calendar_Number" Text="0"></asp:Label>
                            <br />
                            <br />
                            <asp:Button ID="friday1School1_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="friday1School2_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="friday1School3_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="friday1School4_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="friday1School5_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                        </div>
                    </div>

                    <%--Week 2--%> 
                    <div class="Visit_Calendar_Calendar_Inner">
                        <div class="Visit_Calendar_Calendar_Block VCC_Mon VCC_W2">
                            <a class="Visit_Calendar_Calendar_Day">Monday</a>
                            <asp:Label ID="monday2_lbl" runat="server" CssClass="Visit_Calendar_Calendar_Number" Text="0"></asp:Label>
                            <br />
                            <br />
                            <asp:Button ID="monday2School1_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="monday2School2_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="monday2School3_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="monday2School4_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="monday2School5_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                        </div>
                        <div class="Visit_Calendar_Calendar_Block  VCC_Tue VCC_W2">
                            <a class="Visit_Calendar_Calendar_Day">Tuesday</a>
                            <asp:Label ID="tuesday2_lbl" runat="server" CssClass="Visit_Calendar_Calendar_Number" Text="0"></asp:Label>
                            <br />
                            <br />
                            <asp:Button ID="tuesday2School1_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="tuesday2School2_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="tuesday2School3_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="tuesday2School4_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="tuesday2School5_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                        </div>
                        <div class="Visit_Calendar_Calendar_Block VCC_Wed VCC_W2">
                            <a class="Visit_Calendar_Calendar_Day">Wednesday</a>
                            <asp:Label ID="wednesday2_lbl" runat="server" CssClass="Visit_Calendar_Calendar_Number" Text="0"></asp:Label>
                            <br />
                            <br />
                            <asp:Button ID="wednesday2School1_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="wednesday2School2_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="wednesday2School3_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="wednesday2School4_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="wednesday2School5_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                        </div>
                        <div class="Visit_Calendar_Calendar_Block VCC_Thu VCC_W2">
                            <a class="Visit_Calendar_Calendar_Day">Thursday</a>
                            <asp:Label ID="thursday2_lbl" runat="server" CssClass="Visit_Calendar_Calendar_Number" Text="0"></asp:Label>
                            <br />
                            <br />
                            <asp:Button ID="thursday2School1_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="thursday2School2_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="thursday2School3_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="thursday2School4_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="thursday2School5_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                        </div>
                        <div class="Visit_Calendar_Calendar_Block VCC_Fri VCC_W2">
                            <a class="Visit_Calendar_Calendar_Day">Friday</a>
                            <asp:Label ID="friday2_lbl" runat="server" CssClass="Visit_Calendar_Calendar_Number" Text="0"></asp:Label>
                            <br />
                            <br />
                            <asp:Button ID="friday2School1_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="friday2School2_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="friday2School3_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="friday2School4_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="friday2School5_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                        </div>
                    </div>

                    <%--Week 3--%> 
                    <div class="Visit_Calendar_Calendar_Inner">
                        <div class="Visit_Calendar_Calendar_Block VCC_Mon VCC_W3">
                            <a class="Visit_Calendar_Calendar_Day">Monday</a>
                            <asp:Label ID="monday3_lbl" runat="server" CssClass="Visit_Calendar_Calendar_Number" Text="0"></asp:Label>
                            <br />
                            <br />
                            <asp:Button ID="monday3School1_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="monday3School2_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="monday3School3_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="monday3School4_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="monday3School5_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                        </div>
                        <div class="Visit_Calendar_Calendar_Block VCC_Tue VCC_W3">
                            <a class="Visit_Calendar_Calendar_Day">Tuesday</a>
                            <asp:Label ID="tuesday3_lbl" runat="server" CssClass="Visit_Calendar_Calendar_Number" Text="0"></asp:Label>
                            <br />
                            <br />
                            <asp:Button ID="tuesday3School1_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="tuesday3School2_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="tuesday3School3_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="tuesday3School4_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="tuesday3School5_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                        </div>
                        <div class="Visit_Calendar_Calendar_Block VCC_Wed VCC_W3">
                            <a class="Visit_Calendar_Calendar_Day">Wednesday</a>
                            <asp:Label ID="wednesday3_lbl" runat="server" CssClass="Visit_Calendar_Calendar_Number" Text="0"></asp:Label>
                            <br />
                            <br />
                            <asp:Button ID="wednesday3School1_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="wednesday3School2_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="wednesday3School3_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="wednesday3School4_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="wednesday3School5_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                        </div>
                        <div class="Visit_Calendar_Calendar_Block VCC_Thu VCC_W3">
                            <a class="Visit_Calendar_Calendar_Day">Thursday</a>
                            <asp:Label ID="thursday3_lbl" runat="server" CssClass="Visit_Calendar_Calendar_Number" Text="0"></asp:Label>
                            <br />
                            <br />
                            <asp:Button ID="thursday3School1_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="thursday3School2_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="thursday3School3_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="thursday3School4_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="thursday3School5_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                        </div>
                        <div class="Visit_Calendar_Calendar_Block VCC_Fri VCC_W3">
                            <a class="Visit_Calendar_Calendar_Day">Friday</a>
                            <asp:Label ID="friday3_lbl" runat="server" CssClass="Visit_Calendar_Calendar_Number" Text="0"></asp:Label>
                            <br />
                            <br />
                            <asp:Button ID="friday3School1_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="friday3School2_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="friday3School3_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="friday3School4_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="friday3School5_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                        </div>
                    </div>

                    <%--Week 4--%> 
                    <div class="Visit_Calendar_Calendar_Inner">
                        <div class="Visit_Calendar_Calendar_Block VCC_Mon VCC_W3">
                            <a class="Visit_Calendar_Calendar_Day">Monday</a>
                            <asp:Label ID="monday4_lbl" runat="server" CssClass="Visit_Calendar_Calendar_Number" Text="0"></asp:Label>
                            <br />
                            <br />
                            <asp:Button ID="monday4School1_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="monday4School2_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="monday4School3_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="monday4School4_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="monday4School5_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                        </div>
                        <div class="Visit_Calendar_Calendar_Block VCC_Tue VCC_W3">
                            <a class="Visit_Calendar_Calendar_Day">Tuesday</a>
                            <asp:Label ID="tuesday4_lbl" runat="server" CssClass="Visit_Calendar_Calendar_Number" Text="0"></asp:Label>
                            <br />
                            <br />
                            <asp:Button ID="tuesday4School1_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="tuesday4School2_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="tuesday4School3_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="tuesday4School4_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="tuesday4School5_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                        </div>
                        <div class="Visit_Calendar_Calendar_Block VCC_Wed VCC_W3">
                            <a class="Visit_Calendar_Calendar_Day">Wednesday</a>
                            <asp:Label ID="wednesday4_lbl" runat="server" CssClass="Visit_Calendar_Calendar_Number" Text="0"></asp:Label>
                            <br />
                            <br />
                            <asp:Button ID="wednesday4School1_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="wednesday4School2_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="wednesday4School3_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="wednesday4School4_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="wednesday4School5_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                        </div>
                        <div class="Visit_Calendar_Calendar_Block VCC_Thu VCC_W3">
                            <a class="Visit_Calendar_Calendar_Day">Thursday</a>
                            <asp:Label ID="thursday4_lbl" runat="server" CssClass="Visit_Calendar_Calendar_Number" Text="0"></asp:Label>
                            <br />
                            <br />
                            <asp:Button ID="thursday4School1_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="thursday4School2_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="thursday4School3_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="thursday4School4_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="thursday4School5_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                        </div>
                        <div class="Visit_Calendar_Calendar_Block VCC_Fri VCC_W3">
                            <a class="Visit_Calendar_Calendar_Day">Friday</a>
                            <asp:Label ID="friday4_lbl" runat="server" CssClass="Visit_Calendar_Calendar_Number" Text="0"></asp:Label>
                            <br />
                            <br />
                            <asp:Button ID="friday4School1_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="friday4School2_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="friday4School3_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="friday4School4_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="friday4School5_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                        </div>
                    </div>

                    <%--Week 5--%> 
                    <div class="Visit_Calendar_Calendar_Inner">
                        <div class="Visit_Calendar_Calendar_Block VCC_Mon VCC_W5">
                            <a class="Visit_Calendar_Calendar_Day">Monday</a>
                            <asp:Label ID="monday5_lbl" runat="server" CssClass="Visit_Calendar_Calendar_Number" Text="0"></asp:Label>
                            <br />
                            <br />
                            <asp:Button ID="monday5School1_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="monday5School2_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="monday5School3_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="monday5School4_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="monday5School5_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                        </div>
                        <div class="Visit_Calendar_Calendar_Block VCC_Tue VCC_W5">
                            <a class="Visit_Calendar_Calendar_Day">Tuesday</a>
                            <asp:Label ID="tuesday5_lbl" runat="server" CssClass="Visit_Calendar_Calendar_Number" Text="0"></asp:Label>
                            <br />
                            <br />
                            <asp:Button ID="tuesday5School1_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="tuesday5School2_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="tuesday5School3_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="tuesday5School4_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="tuesday5School5_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                        </div>
                        <div class="Visit_Calendar_Calendar_Block VCC_Wed VCC_W5">
                            <a class="Visit_Calendar_Calendar_Day">Wednesday</a>
                            <asp:Label ID="wednesday5_lbl" runat="server" CssClass="Visit_Calendar_Calendar_Number" Text="0"></asp:Label>
                            <br />
                            <br />
                            <asp:Button ID="wednesday5School1_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="wednesday5School2_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="wednesday5School3_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="wednesday5School4_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="wednesday5School5_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                        </div>
                        <div class="Visit_Calendar_Calendar_Block VCC_Thu VCC_W5">
                            <a class="Visit_Calendar_Calendar_Day">Thursday</a>
                            <asp:Label ID="thursday5_lbl" runat="server" CssClass="Visit_Calendar_Calendar_Number" Text="0"></asp:Label>
                            <br />
                            <br />
                            <asp:Button ID="thursday5School1_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="thursday5School2_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="thursday5School3_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="thursday5School4_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="thursday5School5_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                        </div>
                        <div class="Visit_Calendar_Calendar_Block VCC_Fri VCC_W5">
                            <a class="Visit_Calendar_Calendar_Day">Friday</a>
                            <asp:Label ID="friday5_lbl" runat="server" CssClass="Visit_Calendar_Calendar_Number" Text="0"></asp:Label>
                            <br />
                            <br />
                            <asp:Button ID="friday5School1_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="friday5School2_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="friday5School3_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="friday5School4_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                            <asp:Button ID="friday5School5_btn" runat="server" CssClass="Visit_Calendar_Calendar_Button" Text="School Name Here" Visible="false"></asp:Button>
                        </div>
                    </div>

                </div>
            <br /><br />
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
