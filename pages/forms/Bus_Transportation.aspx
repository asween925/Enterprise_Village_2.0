<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Bus_Transportation.aspx.vb" Inherits="Enterprise_Village_2._0.Bus_Transportation" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>EV 2.0 - Bus Transportation</title>

    <link href="~/css/Styles.updated.css" rel="stylesheet" media="screen" type="text/css">
    <link href="~/css/Styles.Print.css" rel="stylesheet" media="print" type="text/css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png" />

    <script src="https://code.jquery.com/jquery-1.10.2.js"></script>

    <style>
        .estimations {
            font-size: 22px;
            font-weight: bold;
        }
    </style>
</head>

<body>
    <form autocomplete="off"  id="EMS_Form" runat="server">

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
        <div class="content">
            <h2 class="h2 no-print">Bus Transportation</h2>
            <h3 class="no-print">This is where you will print out the bus transportation information for EV. Select a visit date to view the mileage and time fields and the letter.
                <br class="no-print" /><br class="no-print" />
                If the calculations are not already saved for the visiting school, you can enter them manually by entering in the total mileage one way and the total time one way and click 'Calculate'. This will calculate the remaining values (including the total cost) and save it for future use.
            </h3>
            <p class="no-print">Visit Date:</p>
            <asp:TextBox ID="visitDate_tb" runat="server" TextMode="Date" CssClass="textbox no-print" AutoPostBack="true"></asp:TextBox>&ensp;<asp:Label ID="error_lbl" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="Red"></asp:Label>

            <%--Calculation Div--%>
            <div id="calculations_div" runat="server" visible="false">
                <p class="no-print">Enter Total Mileage One Way:</p>
                <asp:TextBox ID="totalMileageOneWay_tb" runat="server" TextMode="Number" CssClass="textbox no-print"></asp:TextBox>
                <p class="no-print">Enter Total Time One Way:</p>
                <asp:TextBox ID="totalTimeOneWay_tb" runat="server" TextMode="Number" CssClass="textbox no-print"></asp:TextBox>
                <br class="no-print" /><br class="no-print" />
                <asp:Button ID="calculate_btn" runat="server" CssClass="button3 no-print" Text="Calculate" /><asp:Button ID="print_btn" runat="server" CssClass="button3 no-print" Text="Print" />
                <br class="no-print"/>
            </div>
           
            <%--Letter--%>
            <div id="letter_div" runat="server" visible="false">
                <h3 style="text-align: center;">Bus Transportation Estimate</h3>
                <br />
                <asp:Label ID="currentDate_lbl" runat="server"></asp:Label>
                <br />
                <asp:Label ID="schoolName_lbl" runat="server"></asp:Label>
                <br />
                <asp:Label ID="address_lbl" runat="server"></asp:Label>
                <br />
                <asp:Label ID="address2_lbl" runat="server"></asp:Label>
                <br /><br />
                <p>Students attending Enterprise Village: <asp:Label ID="studentCount_lbl" runat="server"></asp:Label></p>
                <p>Enterprise Village Visit Date: <asp:Label ID="visitDate_lbl" runat="server" ></asp:Label></p>

                <div>
                    <p>Total mileage one way: <span style="float: right;"><asp:Label ID="totalMileageOneWay_lbl" runat="server" Font-Bold="true"></asp:Label> miles</span></p>
                    <p>Total mileage barn to barn: <span style="float: right;"><asp:Label ID="totalMileageBarn_lbl" runat="server" Font-Bold="true" ></asp:Label> miles</span></p>
                    <p>Total time one way: <span style="float: right;"><asp:Label ID="totalTimeOneWay_lbl" runat="server" Font-Bold="true" ></asp:Label> hours</span></p>
                    <p>Total time barn to barn: <span style="float: right;"><asp:Label ID="totalTimeBarn_lbl" runat="server" Font-Bold="true"></asp:Label> hours</span></p>
                    <br /><br />
                    <p class="estimations">Estimated total one bus: <span style="float: right;"><asp:Label ID="totalOneBus_lbl" runat="server" ></asp:Label></span></p>
                    <p class="estimations">Estimated total two buses: <span style="float: right;"><asp:Label ID="totalTwoBus_lbl" runat="server"></asp:Label></span></p>
                    <p class="estimations">Estimated total three buses: <span style="float: right;"><asp:Label ID="totalThreeBus_lbl" runat="server"></asp:Label></span></p>
                </div>
                <br /><br />
                <p>This is an estimate, invoice will reflect actual cost. Any tolls incurred during the trip will be paid by the school. Invoice will be mailed after visit date.</p>

                <%--EV Logo for Printing--%>        
                <asp:Image ID="EVLogo_img" runat="server" ImageUrl="../../media/EnterpriseVillage.png" ImageAlign="bottom" CssClass="EV_logo_print" Visible="false" />

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
