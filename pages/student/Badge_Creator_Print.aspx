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
    <form id="Profit_display_Form" runat="server">
        <div id="site_wrap">
            <div class="main_mix">
                <asp:Label ID="Label19" runat="server" Text="Badge Printing" Font-Size="70px" CssClass="no-print"></asp:Label>
                <br />
                <asp:LinkButton ID="LinkButton9" runat="server" PostBackUrl="/pages/student/badge_creator_history.aspx" Font-Size="Medium" CssClass="button button1 no-print">Badge History</asp:LinkButton>
                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="/pages/student/badge_creator.aspx" Font-Size="Medium" CssClass="button button1 no-print">Badge Creator</asp:LinkButton>
                <br /><br />
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
                    <img class="badge_logo" alt="Tech Data" src="../../Images/TD_SYNNEX.png">
                    <asp:Image ID="photo_img1" CssClass="photo2 print_photo" runat="server" />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br class="disable" />
                    <br class="disable" />
                    <br class="disable" />
                    <br class="disable" />
                    <br class="disable" />
                    <asp:Label runat="server" Text="Name: "></asp:Label>
                    <asp:Label ID="studentName_lbl1" runat="server"></asp:Label>
                    <br />
                    <asp:Label runat="server" Text="Business: "></asp:Label>
                    <asp:Label ID="businessName_lbl1" runat="server"></asp:Label>
                    <br />
                    <asp:Label runat="server" Text="Position: "></asp:Label>
                    <asp:Label ID="position_lbl1" runat="server"></asp:Label>
                    <br />
                    <asp:Label runat="server" Text="Date: "></asp:Label>
                    <asp:Label ID="date_lbl1" runat="server"></asp:Label>&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;<asp:Label ID="employeeNumber_lbl1" runat="server"></asp:Label>
                </div>

                <%--badge2--%>
                <div class="badge_history badge_print2">
                    <img class="badge_logo" alt="Tech Data" src="../../Images/TD_SYNNEX.png">
                    <asp:Image ID="photo_img2" CssClass="photo2 print_photo" runat="server" />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br class="disable" />
                    <br class="disable" />
                    <br class="disable" />
                    <br class="disable" />
                    <br class="disable" />
                    <asp:Label runat="server" Text="Name: "></asp:Label>
                    <asp:Label ID="studentName_lbl2" runat="server"></asp:Label>
                    <br />
                    <asp:Label runat="server" Text="Business: "></asp:Label>
                    <asp:Label ID="businessName_lbl2" runat="server"></asp:Label>
                    <br />
                    <asp:Label runat="server" Text="Position: "></asp:Label>
                    <asp:Label ID="position_lbl2" runat="server"></asp:Label>
                    <br />
                    <asp:Label runat="server" Text="Date: "></asp:Label>
                    <asp:Label ID="date_lbl2" runat="server"></asp:Label>&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;<asp:Label ID="employeeNumber_lbl2" runat="server"></asp:Label>
                </div>
                <br class="no-print" />

                <%--badge3--%>
                <div class="badge_history badge_print3">
                    <img class="badge_logo" alt="Tech Data" src="../../Images/TD_SYNNEX.png">
                    <asp:Image ID="photo_img3" CssClass="photo2 print_photo" runat="server" />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br class="disable" />
                    <br class="disable" />
                    <br class="disable" />
                    <br class="disable" />
                    <br class="disable" />
                    <asp:Label runat="server" Text="Name: "></asp:Label>
                    <asp:Label ID="studentName_lbl3" runat="server"></asp:Label>
                    <br />
                    <asp:Label runat="server" Text="Business: "></asp:Label>
                    <asp:Label ID="businessName_lbl3" runat="server"></asp:Label>
                    <br />
                    <asp:Label runat="server" Text="Position: "></asp:Label>
                    <asp:Label ID="position_lbl3" runat="server"></asp:Label>
                    <br />
                    <asp:Label runat="server" Text="Date: "></asp:Label>
                    <asp:Label ID="date_lbl3" runat="server"></asp:Label>&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;<asp:Label ID="employeeNumber_lbl3" runat="server"></asp:Label>
                </div>

                <%--badge4--%>
                <div class="badge_history badge_print4">
                    <img class="badge_logo" alt="Tech Data" src="../../Images/TD_SYNNEX.png">
                    <asp:Image ID="photo_img4" CssClass="photo2 print_photo" runat="server" />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br class="disable" />
                    <br class="disable" />
                    <br class="disable" />
                    <br class="disable" />
                    <br class="disable" />
                    <asp:Label runat="server" Text="Name: "></asp:Label>
                    <asp:Label ID="studentName_lbl4" runat="server"></asp:Label>
                    <br />
                    <asp:Label runat="server" Text="Business: "></asp:Label>
                    <asp:Label ID="businessName_lbl4" runat="server"></asp:Label>
                    <br />
                    <asp:Label runat="server" Text="Position: "></asp:Label>
                    <asp:Label ID="position_lbl4" runat="server"></asp:Label>
                    <br />
                    <asp:Label runat="server" Text="Date: "></asp:Label>
                    <asp:Label ID="date_lbl4" runat="server"></asp:Label>&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;<asp:Label ID="employeeNumber_lbl4" runat="server"></asp:Label>
                </div>

                <asp:GridView ID="printBadges_dgv" runat="server" PageSize="100" Visible="false" ShowHeaderWhenEmpty="True" CssClass="no-print"></asp:GridView>
                <asp:HiddenField ID="visitdate_hf" runat="server" />

            </div>
        </div>
    </form>
</body>
</html>
