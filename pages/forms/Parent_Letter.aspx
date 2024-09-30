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
                <p>Date: <asp:Label ID="visitDate_lbl" runat="server"></asp:Label></p>
                <p>Dear Parents,</p>
                <p>On <asp:Label ID="visitDateLetter_lbl" runat="server"></asp:Label> our class will be going to Enterprise Village. This trip is part of the free enterprise curriculum taught to Pinellas County fifth grade students. <a style="font-weight: bold;">Enterprise Village is part of the Gus A. Stavros Institute and Pinellas County Schools.</a></p>
                <p>On that day, each student will become an Enterprise village citizen and assume a job in one of the Village businesses, experience economics first hand by selling products and services, earning salaries, shopping in the stores with an Enterprise Village debit card and managing a checking account.</p>
                <p>We need <asp:Label ID="volRange_lbl" runat="server"></asp:Label> volunteers to assist us at Enterprise Village. <a style="font-weight: bold;">We need your help!</a></p>
                <p style="text-align: center; font-weight: bold; text-decoration: underline;">What is my role as a volunteer?</p>
                <p>You are assigned to work in a business with a small group of children. Your duties will include:</p>
                <ul>
                    <li>Assist students in performing their assigned job duties.</li>
                    <li>Assist students with completeing tasks on time.</li>
                    <li>Help students prepare their bank deposits.</li>
                    <li>Enjoy lunch with your child during their assigned lunch break.</li>
                </ul>
                <p><a style="font-weight: bold;">Important:</a> You must be an active, approved volunteer at your child's school to participate. You can contact your school's Community Liaison to confirm your eligibility (for PCSB, you must be a level 1 volunteer).</p>
                <p>We look forward to your participation in this exciting simulation experience! Please complete the form below and return by: <asp:Label ID="replyBy_lbl" runat="server"></asp:Label></p>

                <table style="margin-left: auto; margin-right: auto; text-align: center; width: 100%;">
                    <tr>
                        <th style="text-decoration: underline;">Volunteer Arrival Time</th>
                        <th style="text-decoration: underline;">Volunteer Dismissal Time</th>
                    </tr>
                    <tr>
                        <td><asp:TextBox ID="textbox1" runat="server" CssClass="textbox" textmode="Time"></asp:TextBox></td>
                        <td><asp:TextBox ID="textbox2" runat="server" CssClass="textbox" textmode="Time"></asp:TextBox></td>
                    </tr>
                </table>
                <p style="font-weight: bold;">Tear on the dotted line and return bottom portion to school. Keep top portion for future reference.</p>
            </div>

            <%--Return Slip--%>
            <div id="returnSlip_div" runat="server" visible="false" class="Parent_Letter_Slip">
                <h4 style="text-align: center;">ENTERPRISE VILLAGE RESPONSE FORM</h4>
                <p>Name:______________________________________________________________________________________________</p>
                <p>Child's Name:_____________________________________________________________________________________</p>
                <p>Teacher / School:_________________________________________________________________________________________________</p>
                <br />
                <br />
                <p>______ I will volunteer at Enterprise Village on <asp:Label ID="visitDateSlip1_lbl" runat="server" Font-Bold="true"></asp:Label> and will attend the mandatory training on at <asp:Label ID="trainingTimeSlip_lbl" runat="server" Font-Bold="true"></asp:Label>.</p>
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
