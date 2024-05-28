<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EV_Daily_Forms.aspx.vb" Inherits="Enterprise_Village_2._0.EV_Daily_Forms" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>EV 2.0 - EV Daily Forms</title>

    <link href="~/css/Styles.updated.css" rel="stylesheet" media="screen" type="text/css">
    <link href="~/css/Styles.print.css" rel="stylesheet" media="print" type="text/css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png" />
    <script src="https://code.jquery.com/jquery-1.10.2.js"></script>
</head>

<body onafterprint="javascript:ResetPage();">
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
            <asp:Image ID="StavrosLogo_img" runat="server" ImageUrl="~\media\Stavros_logo.png" Visible="false" CssClass="stavros_logo_print" />
            <h2 class="h2">Enterprise Village Daily Forms</h2>
            <h3 class="no-print">This page is for printing out the daily Enterprise Village forms, both the PCSB and the Out of County schools. Enter a visit date below to start.</h3>
            <p class="no-print">Visit Date:</p>
            <asp:TextBox ID="visitDate_tb" runat="server" TextMode="Date" AutoPostBack="true" CssClass="textbox no-print"></asp:TextBox>&emsp;<asp:Label runat="server" ID="error_lbl" Font-Size="X-Large" ForeColor="Red" CssClass="no-print"></asp:Label>            
            <p class="no-print" runat="server" id="schoolName_p" visible="false">School Name:</p>
            <asp:DropDownList ID="schoolName_ddl" runat="server" AutoPostBack="true" Visible="false" CssClass="ddl no-print"></asp:DropDownList>
            <br class="no-print" />
            <br class="no-print" />

            <asp:Button ID="printPCSB_btn" runat="server" Text="Print PCSB Schools" CssClass="button3 button3 no-print" Visible="false" />

            <div id="info_div" runat="server" visible="false">
                <h3 id="title_h3" runat="server"></h3>

                <p style="text-align:left;">Date:
                    <asp:Label ID="visitDate_lbl" runat="server"></asp:Label>
                    <span style="float: right;">
                       <asp:Label ID="PCSBForms_lbl" runat="server" Text=""></asp:Label>
                    </span>
                </p>
                <br />

                <p style="font-weight: bold; text-align:left;">Total number of <asp:Label ID="schoolName_lbl" runat="server" Font-Underline="true"></asp:Label> students attending:
                    <span style="float: right; font-weight: normal;">
                        _____________
                    </span>
                </p>

                <div id="lunchPCSB_div" runat="server" style="border: 2px solid black; padding: 5px;">
                    <h4 style="text-align:center;">Lunch Information</h4>
                    <p>Number of students NOT eating a McDonald's lunch (Will not be ordered for students): _________________</p>
                </div>

                <div id="workbooksOOC_div" runat="server">
                    <p style="text-align:left;">Number of workbooks received by <asp:Label ID="schoolName2_lbl" runat="server"></asp:Label>: 
                        <span style="float: right;">
                            <asp:Label ID="workbooks_lbl" runat="server" Font-Bold="true" Font-Underline="true"></asp:Label>
                        </span>
                    </p>
                    <p>Number of unused workbooks returned:
                        <span style="float: right;">
                            _____________
                        </span>
                    </p>
                </div>
                <br /><br />
                <div id="questions_div" runat="server">
                    <p style="text-align: right;">Please circle your answer:</p>

                    <p style="text-align:left;">Have you turned in a list of students attending today to our front office? 
                        <span style="float: right;">
                            Yes&emsp;&emsp;&emsp;No
                        </span>
                    </p>

                    <p style="text-align:left;">Kit returned? 
                        <span style="float: right;">
                            Yes&emsp;&emsp;&emsp;No
                        </span>
                    </p>
                    <div id="questionsOOC_div" runat="server">
                        <p style="text-align:left;">Did you return your Enterprise Village Kit(s)?
                            <span style="float: right;">
                                Yes&emsp;&emsp;&emsp;No
                            </span>
                        </p>
                        <p style="text-align:left;">Did we transport your students today?&ensp;
                            <span style="float: right;">
                                Yes&emsp;&emsp;&emsp;No
                            </span>
                        </p>
                    </div>

                </div>
                <br />
                <br />

                <p>Teacher Signature:___________________________________________________________________ Date:____________________</p>
            </div>

            <%--EV Logo for Printing--%>        
            <asp:Image ID="EVLogo_img" runat="server" ImageUrl="~\media\EnterpriseVillage.png" ImageAlign="bottom" CssClass="EV_logo_print" Visible="false" />

        </div>

        <asp:HiddenField ID="visitdate_hf" runat="server" />
        <asp:HiddenField ID="businessID_hf" runat="server" />
        <asp:HiddenField ID="teacherID_hf" runat="server" />
        <asp:HiddenField ID="schoolID_hf" runat="server" />
        <asp:HiddenField ID="schoolType_hf" runat="server" />

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


