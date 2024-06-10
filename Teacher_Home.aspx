<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Teacher_Home.aspx.vb" Inherits="Enterprise_Village_2._0.Teacher_Home" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>Enterprise Village - Teacher Home</title>

    <link href="~/css/Styles.updated.css" rel="stylesheet" media="screen" type="text/css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png" />
    <script src="https://code.jquery.com/jquery-1.10.2.js"></script>

    <style>
        .errorTeacherHome {
            margin-top: 500px;
            margin-bottom: 500px;
        }
    </style>
</head>

<body>
    <form autocomplete="off"  id="EMS_Form" runat="server">

        <%--Header information--%>
        <div id="header-e1">
            Enterprise Village 2.0
        </div>
        <div id="header-e3">
            <asp:Label ID="headerSchoolName_lbl" Text="Welcome Teachers!" runat="server"></asp:Label>
        </div>
        <div id="header-e2">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </div>
        <%--<header class="headerTop"><a style="float: left; padding-top: 2px;">Enterprise Village 2.0</a><a style="float: right; padding-right: 30px; padding-top: 2px;"><asp:Label ID="headerSchoolName_lbl" Text="School Name Here" runat="server"></asp:Label></a></header>--%>


        <%--Content--%>
        <div class="content_home">
            <h2 class="h2" style="text-align: center;">Welcome
                <asp:Label ID="teacherName_lbl" runat="server"></asp:Label>
               to Enterprise Village!</h2>
            <br />
            <asp:Label ID="schoolName_lbl" runat="server" Font-Size="X-Large" ForeColor="Black" Font-Bold="true" Text="Test School 2"></asp:Label>
            <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="'s Scheduled Visit Date: " Font-Size="X-Large" ForeColor="Black"></asp:Label>
            <asp:Label ID="visitDate_lbl" runat="server" Font-Size="X-Large" Font-Italic="true" ForeColor="Black"></asp:Label>
            <br />
            <asp:Label ID="error_lbl" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="Red"></asp:Label>
            <br />
            <div class="button_grid__inv">
                <div class="button_item2">
                    <asp:Button ID="isi_btn" runat="server" Text="Enter Students"  CssClass="button_inv_home"></asp:Button><br />
                </div>
                <div class="button_item2">
                    <h3>Upload Newspaper Articles:</h3>
                    <p style="font-style: italic">Note: The articles uploaded must be a Word document.</p>
                    <asp:FileUpload ID="fileUpload_fu" runat="server"  />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="upload_btn" runat="server" Text="Upload" CssClass="button3"/>
                </div>
                <br />
                <asp:Button ID="logOut_btn" runat="server" Text="Log Out" CssClass="button3" />
                <br />
                <p class="no-print">Click <a href="mailto:sweeneya@pcsb.org?subject=Teacher Home Page Question">here</a> to ask us a question, or email us at stavrosinstitute@pcsb.org!</p>
            </div>

           <div class="teacher_home_stavros_logo_block">
                <%--Stavros Logo for Printing--%>
                <asp:Image ID="EVLogo_img" runat="server" ImageUrl="~\media\Stavros_logo.png" ImageAlign="Middle" CssClass="teacher_home_stavros_logo" Visible="true" />            
           </div>               
        </div>

        <asp:HiddenField ID="currentVisitID_hf" runat="server" />
        <asp:HiddenField ID="teacherVisitID_hf" runat="server" />
        <asp:HiddenField ID="visitDate_hf" runat="server" />

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
