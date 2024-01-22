<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Upload_Move_Articles.aspx.vb" Inherits="Enterprise_Village_2._0.Upload_Move_Articles" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>EV 2.0 - Upload / Move Articles</title>

    <link href="css/Styles.updated.css" rel="stylesheet" media="screen" type="text/css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <link rel="shortcut icon" type="image/png" href="media/EV_favicon_2.png" />

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
                $("#nav-placeholder").load("nav.html");
            });
        </script>

        <%--Content--%>
        <div class="content">
            <h2 class="h2">Upload / Move Articles</h2>
            <h3>If you have updated a visit date for a school, this page is designed to move the newspaper articles that the teacher has submitted to the updated visit date.
                <br />
                <br />
                Enter the previous visit date in the textbox below and select the school that has been moved. Then enter the updated visit date and click 'Submit'.
            </h3>
            <asp:Button ID="uploadView_btn" runat="server" CssClass="button3 no-print" Text="Upload Articles" /><asp:Button ID="moveView_btn" runat="server" CssClass="button3 no-print" Text="Move Articles" /><asp:Label ID="error_lbl" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="Red"></asp:Label>
         
            <%--Upload Articles--%>
            <div id="upload_div" runat="server" visible="false">
                <p>Visit Date:</p>
                <asp:TextBox ID="uploadVisitDate_tb" runat="server" AutoPostBack="true" TextMode="Date" CssClass="textbox"></asp:TextBox>

                <p id="uploadSchoolName_p" runat="server" visible="false">School Name:</p>
                <asp:DropDownList ID="uploadSchoolName_ddl" runat="server" AutoPostBack="true" CssClass="ddl" Visible="false"></asp:DropDownList>

                <p id="fileUpload_p" runat="server" visible="false">Select Word Document to Upload:</p>
                <asp:FileUpload ID="fileUpload_fu" runat="server" Visible="false" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="upload_btn" runat="server" Text="Upload" CssClass="button3" Visible="false"/>
            </div>

            <%--Move Articles--%>
            <div id="move_div" runat="server" visible="false">
                <p>Previous Visit Date:</p>
                <asp:TextBox ID="oldVisitDate_tb" runat="server" TextMode="Date" AutoPostBack="true" CssClass="textbox"></asp:TextBox>

                <div id="school_p" runat="server" visible="false">
                    <p>School Name:</p>
                    <asp:DropDownList ID="schoolName_ddl" runat="server" CssClass="ddl" AutoPostBack="true"></asp:DropDownList>
                    <br />
                </div>

                <div id="newDate_p" runat="server" visible="false">
                    <p>New Visit Date:</p>
                    <asp:TextBox ID="newVisitDate_tb" runat="server" TextMode="Date" AutoPostBack="true" CssClass="textbox"></asp:TextBox>
                    <br />
                    <br />
                    <br />
                    <asp:Button ID="submit_btn" runat="server" CssClass="button3" Text="Submit" />
                </div>
            </div>

        </div>

        <asp:HiddenField ID="currentVisitID_hf" runat="server" />

        <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
        <script src="Scripts.js"></script>
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
