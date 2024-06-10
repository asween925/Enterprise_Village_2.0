<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Parent_Letter.aspx.vb" Inherits="Enterprise_Village_2._0.Parent_Letter" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>EV 2.0 - Parent Letter</title>

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
        <div id="nav-placeholder" class="no-print">
        </div>

        <script>
            $(function () {
                $("#nav-placeholder").load("../../nav.html");
            });
        </script>

        <%--Content--%>
        <div class="content">
            <h2 class="h2 no-print">Parent Letter</h2>
            <h3 class="no-print">This page is used to save a PDF of the parent letter. Select a visit date and click 'Save as PDF' to open the print window. When the print window appears, select Save as PDF under printers.</h3>
            <p class="no-print">Visit Date:</p>
            <asp:TextBox ID="visitDate_tb" runat="server" TextMode="Date" CssClass="textbox no-print" AutoPostBack="true"></asp:TextBox><a class="no-print">&ensp;</a><asp:Label ID="error_lbl" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="Red"></asp:Label>
            <p class="no-print" id="schoolName_p" runat="server" visible="false">School Name (Used to Get Volunteer Range):</p>
            <asp:DropDownList ID="schoolName_ddl" runat="server" CssClass="ddl no-print" AutoPostBack="true" Visible="false"></asp:DropDownList>
            <br class="no-print" /><br class="no-print" />
            <asp:Button ID="print_btn" runat="server" Text="Save as PDF" CssClass="button3 no-print" />
            <br class="no-print" />

            <%--Letter--%>
            <div id="letter_div" runat="server" visible="false">
                <p>Dear Parents,</p>
                <p>On <asp:Label ID="visitDateLetter_lbl" runat="server"></asp:Label> our class will be going to Enterprise Village. This trip is part of the Free Enterprise-Consumer-Economic Education program in the Pinellas County Schools. Enterprise Village is part of the Gus A. Stavros Institute and is located at 12100 Starkey Road, one mile south of Ulmerton Road in Largo. The phone number is 727-588-3746.</p>
                <p>On that day, each student will become an Enterprise village citizen and assume a job in one of the Village businesses. Students will experience economics first hand by applying for and getting a job, producing and selling products, earning paychecks, shopping in the stores with Enterprise Village money and managing a checking account.</p>
                <p>We need <asp:Label ID="volRange_lbl" runat="server"></asp:Label> volunteers to assist us at Enterprise Village. The role of the volunteer will be to provide guidance and assistance to the students as they operate their businesses during the day. You must be an approved volunteer to participate. If you are uncertain of your status, contact your child's school.</p>
                <p>To prepare for that day, a training will be held at the Gus A. Stavros Institute the morning of your school's visit to acquiant you with your responsibilites. This training is mandatory and will begin promptly at <asp:Label ID="trainingTime_lbl" runat="server"></asp:Label>. Please arrive 15 minutes prior to the start of training! Even if you have volunteered at Enterprise Village in the past, it is suggested that you attend training again. A McDonald's lunch can be purchased for $3.00. A photo ID is required.</p>
                <p>We look forward to your participation in this exciting education experience. Please complete the slip below and return to school by _________________________</p>
                <br />
                <p>_______________________________</p>
                <p>Teacher</p>
                <br />
                <p>Tear on the dotted line and return only the bottom portion to school.</p>
                <p>KEEP THIS PORTION FOR FUTURE REFERENCE.</p>
            </div>

            <%--Return Slip--%>
            <div id="returnSlip_div" runat="server" visible="false" class="Parent_Letter_Slip">
                <h4 style="text-align: center;">ENTERPRISE VILLAGE RESPONSE FORM</h4>
                <p>Name:______________________________________________</p>
                <p>Child's Name:______________________________________________</p>
                <p>Teacher / School:______________________________________________</p>
                <br />
                <br />
                <p>______ I will volunteer at Enterprise Village on <asp:Label ID="visitDateSlip1_lbl" runat="server"></asp:Label> and will attend the mandatory training on <asp:Label ID="visitDateSlip2_lbl" runat="server"></asp:Label> @ <asp:Label ID="trainingTimeSlip_lbl" runat="server"></asp:Label>. PLEASE ARRIVE 15 MINUTES PRIOR TO THE START OF THE TRAINING, AS THE SESSION MUST BEGIN ON TIME.</p>
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
