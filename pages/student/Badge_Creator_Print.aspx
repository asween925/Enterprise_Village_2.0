<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Badge_Creator_Print.aspx.vb" Inherits="Enterprise_Village_2._0.Badge_Creator_Print" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title class="no-print">Badge Printing</title>

    <link href="~/css/Styles.Print.css" rel="stylesheet" media="print" type="text/css">
    <link href="~/css/Styles.profit.css" rel="stylesheet" media="screen" type="text/css">
    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png" />

    <script src="../../Scripts.js"></script>
</head>

<body>
    <form autocomplete="off" id="Profit_display_Form" runat="server">
        <div id="site_wrap" style="overflow: auto;">
            <div class="main_mix" style="overflow: auto;">
                <asp:Label ID="Label19" runat="server" Text="Badge Printing" Font-Size="70px" CssClass="no-print"></asp:Label>
                <br />
                <asp:LinkButton ID="LinkButton9" runat="server" PostBackUrl="/pages/student/badge_creator_history.aspx" Font-Size="Medium" CssClass="button button1 no-print">Badge History</asp:LinkButton>
                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="/pages/student/badge_creator.aspx" Font-Size="Medium" CssClass="button button1 no-print">Badge Creator</asp:LinkButton>
                <br />
                <br />
                <%--Printed Badges--%>
                <h4 class="no-print" style="font-size: 16px; text-decoration: underline;">Select a Badge to Print</h4>
                <asp:DropDownList ID="badges_ddl" runat="server" AutoPostBack="true" CssClass="ddl no-print"></asp:DropDownList>
                <br />
                <br />
                <asp:TextBox ID="password_tb" runat="server" TextMode="Password" CssClass="textbox no-print" Width="90px" Height="30px" Font-Size="14px"></asp:TextBox>&ensp;<asp:Button ID="print_btn" runat="server" Text="Print" CssClass="print_button no-print" />&ensp;<asp:Button ID="refresh_btn" runat="server" Text="Clear" CssClass="button4 no-print" />
                <br />
                <asp:Label ID="error_lbl" runat="server" Font-Size="X-Large" ForeColor="Yellow" CssClass="no-print"></asp:Label>
                <br />

                <%--badge--%>
                <div class="badge_history badge_print">
                    <img class="badge_logo_stav" alt="Stavros logo" src="../../Images/Stavros-Logo.jpg">
                    <br />
                    <asp:Image ID="photo_img1" CssClass="badge_photo" runat="server"/>    
                    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
                    <asp:Label ID="studentName1_lbl" runat="server" Text="Student Name" CssClass="badge_student_name"></asp:Label>
                    <br />
                    <asp:Label ID="businessName1_lbl" runat="server" Text="Business Name" CssClass="badge_biz_name"></asp:Label>
                    <br />
                    <asp:Label ID="position1_lbl" runat="server" Text="Job Title" CssClass="badge_job_title"></asp:Label>
                    <br />
                    <asp:Label ID="date1_lbl" runat="server" Text="10/10/1900" CssClass="badge_date"></asp:Label>&emsp;<asp:Label ID="employeeNumber1_lbl" runat="server" Text="#000" CssClass="badge_emp"></asp:Label>
                    <img class="badge_logo" alt="TD SYNNEX logo" src="../../Images/TD_SYNNEX.png">&ensp;<img class="badge_logo_PCS" alt="PCS Logo" src="../../Images/PCSB_icon_round.png">
                </div>

                <%--badge2--%>
                <div class="badge_history badge_print2">
                    <img class="badge_logo_stav" alt="Stavros logo" src="../../Images/Stavros-Logo.jpg">
                    <br />
                    <asp:Image ID="photo_img2" CssClass="badge_photo" runat="server"/>    
                    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
                    <asp:Label ID="studentName2_lbl" runat="server" Text="Student Name" CssClass="badge_student_name"></asp:Label>
                    <br />
                    <asp:Label ID="businessName2_lbl" runat="server" Text="Business Name" CssClass="badge_biz_name"></asp:Label>
                    <br />
                    <asp:Label ID="position2_lbl" runat="server" Text="Job Title" CssClass="badge_job_title"></asp:Label>
                    <br />
                    <asp:Label ID="date2_lbl" runat="server" Text="10/10/1900" CssClass="badge_date"></asp:Label>&emsp;<asp:Label ID="employeeNumber2_lbl" runat="server" Text="#000" CssClass="badge_emp"></asp:Label>
                    <img class="badge_logo" alt="TD SYNNEX logo" src="../../Images/TD_SYNNEX.png">&ensp;<img class="badge_logo_PCS" alt="PCS Logo" src="../../Images/PCSB_icon_round.png">
                </div>
                <br class="no-print" />

                <%--badge3--%>
                <div class="badge_history badge_print3">
                    <img class="badge_logo_stav" alt="Stavros logo" src="../../Images/Stavros-Logo.jpg">
                    <br />
                    <asp:Image ID="photo_img3" CssClass="badge_photo" runat="server"/>    
                    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
                    <asp:Label ID="studentName3_lbl" runat="server" Text="Student Name" CssClass="badge_student_name"></asp:Label>
                    <br />
                    <asp:Label ID="businessName3_lbl" runat="server" Text="Business Name" CssClass="badge_biz_name"></asp:Label>
                    <br />
                    <asp:Label ID="position3_lbl" runat="server" Text="Job Title" CssClass="badge_job_title"></asp:Label>
                    <br />
                    <asp:Label ID="date3_lbl" runat="server" Text="10/10/1900" CssClass="badge_date"></asp:Label>&emsp;<asp:Label ID="employeeNumber3_lbl" runat="server" Text="#000" CssClass="badge_emp"></asp:Label>
                    <img class="badge_logo" alt="TD SYNNEX logo" src="../../Images/TD_SYNNEX.png">&ensp;<img class="badge_logo_PCS" alt="PCS Logo" src="../../Images/PCSB_icon_round.png">
                </div>

                <%--badge4--%>
                <div class="badge_history badge_print4">
                    <img class="badge_logo_stav" alt="Stavros logo" src="../../Images/Stavros-Logo.jpg">
                    <br />
                    <asp:Image ID="photo_img4" CssClass="badge_photo" runat="server"/>    
                    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
                    <asp:Label ID="studentName4_lbl" runat="server" Text="Student Name" CssClass="badge_student_name"></asp:Label>
                    <br />
                    <asp:Label ID="businessName4_lbl" runat="server" Text="Business Name" CssClass="badge_biz_name"></asp:Label>
                    <br />
                    <asp:Label ID="position4_lbl" runat="server" Text="Job Title" CssClass="badge_job_title"></asp:Label>
                    <br />
                    <asp:Label ID="date4_lbl" runat="server" Text="10/10/1900" CssClass="badge_date"></asp:Label>&emsp;<asp:Label ID="employeeNumber4_lbl" runat="server" Text="#000" CssClass="badge_emp"></asp:Label>
                    <img class="badge_logo" alt="TD SYNNEX logo" src="../../Images/TD_SYNNEX.png">&ensp;<img class="badge_logo_PCS" alt="PCS Logo" src="../../Images/PCSB_icon_round.png">
                </div>

                <asp:GridView ID="printBadges_dgv" runat="server" PageSize="100" Visible="true" ShowHeaderWhenEmpty="True" CssClass="no-print"></asp:GridView>
                <asp:HiddenField ID="visitdate_hf" runat="server" />

            </div>
        </div>
    </form>
</body>
</html>
