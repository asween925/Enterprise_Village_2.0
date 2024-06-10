<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Print_Badges.aspx.vb" Inherits="Enterprise_Village_2._0.Print_Badges" %>

<!DOCTYPE html>
<html>
<head runat ="server">
<meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title class="no-print">Badge Creator</title>

    <link href="~/css/Styles.print.css" rel="stylesheet" media="print" type="text/css">
    <link href="~/css/Styles.profit.css" rel="stylesheet" media="screen" type="text/css">
    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png" />

    <script src="script-jquery-3.6.0.slim.js"></script>
    <script src="jquery.webcam.js"></script>
    <script src="../../Scripts.js"></script>

    <style>
        #container {
            margin: 0px auto;
            width: 50px;
            height: 37px;
            border: 10px #333 solid;
            float: right;
        }

        #videoElement {
            margin: 10px auto;
            width: 110px;
            height: 125px;
            background-color: white;
            float: right;
        }

        .d-none {
        }
    </style>
    <script>
        function redirect() {
            window.location.href = "https://ev.pcsb.org/pages/student/Badge_creator.aspx";
        }
    </script>
</head>

<body onafterprint="redirect();" onload="window.print();">
     <form autocomplete="off"  id="Profit_display_Form" runat="server">
        <div id="site_wrap">
            <div class="main_mix">
                <asp:Label ID="Label19" runat="server" Text="Badge Creator" Font-Size="90px" CssClass="no-print"></asp:Label>
                <br />
                 <%--badge--%>
                    <div class="badge badge_print">                 
                        <img class="badge_logo" alt="Tech Data" src="Images/TD_SYNNEX.png">
                        <asp:Image ID="photo_img1" CssClass="photo print_photo" runat="server" />    
                        <br /><br /><br /><br /><br /><br /><br /><br /><br />
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
                        <asp:Label ID="date_lbl1" runat="server"></asp:Label>
                    </div>
                
                <%--badge2--%>
                    <div class="badge badge_print2">                 
                        <img class="badge_logo" alt="Tech Data" src="Images/TD_SYNNEX.png">
                        <asp:Image ID="photo_img2" CssClass="photo print_photo" runat="server"/>    
                        <br /><br /><br /><br /><br /><br /><br /><br /><br />
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
                        <asp:Label ID="date_lbl2" runat="server"></asp:Label>
                    </div>
                
                <%--badge3--%>
                    <div class="badge badge_print3">                 
                        <img class="badge_logo" alt="Tech Data" src="Images/TD_SYNNEX.png">
                        <asp:Image ID="photo_img3" CssClass="photo print_photo" runat="server" />    
                        <br /><br /><br /><br /><br /><br /><br /><br /><br />
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
                        <asp:Label ID="date_lbl3" runat="server"></asp:Label>
                    </div>
                
                <%--badge4--%>
                    <div class="badge badge_print4">                 
                        <img class="badge_logo" alt="Tech Data" src="Images/TD_SYNNEX.png">
                        <asp:Image ID="photo_img4" CssClass="photo print_photo" runat="server" />    
                        <br /><br /><br /><br /><br /><br /><br /><br /><br />
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
                        <asp:Label ID="date_lbl4" runat="server"></asp:Label>
                    </div>
                </div>
            <asp:HiddenField ID="visitdate_hf" runat="server" />
            </div>
    </form>

</body>
</html>
