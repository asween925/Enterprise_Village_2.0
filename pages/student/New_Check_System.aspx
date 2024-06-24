<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="New_Check_System.aspx.vb" Inherits="Enterprise_Village_2._0.New_Check_System" MaintainScrollPositionOnPostback="false" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <%--<meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">--%>

    <title>Enterprise Village - Payroll Checks</title>

    <link href="~/css/Styles.StudentPages.css" rel="stylesheet" type="text/css">
    <%--look in this css file for body and h3 tags--%>
    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png" />
</head>

<body>
    <form autocomplete="off" id="Template_Student_Full" runat="server">
        <div id="Site_Wrap_Fullscreen">

            <%--Content--%>
            <div class="CS_BG_Default">

                <%--Header--%>
                <div id="divHeader" runat="server" class="CS_Header">
                    <div id="nav-placeholder"></div>
                    <a class="CS_Header_Title" ><asp:Label ID="businessNameHeader_lbl" runat="server"></asp:Label> Payroll Check System</a>
                    <a><asp:Image ID="imgStartLogo" runat="server" ImageUrl="~/Media/FP_Logo.png" CssClass="CS_Header_Logo" /></a>               
                </div>
                
                <%--Check--%>
                <div class="CS_Main_Check">
                    <asp:Label ID="businessName_lbl" runat="server" Text="Business Name" CssClass="CS_Main_Check_BizName"></asp:Label>&ensp;<asp:Label ID="currentDate_lbl" runat="server" Text="1/01/2021" CssClass="CS_Main_Check_Date" Font-Underline="True"></asp:Label>
                    <br />
                    <asp:Label ID="address_lbl" runat="server" Text="Business Address" CssClass="CS_Main_Check_Address"></asp:Label>
                    <br />
                    <p id="nameLine_p" runat="server" cssclass="CS_Main_Check_NameLine">
                        Pay to the order of: &ensp;
                        <asp:DropDownList ID="students_ddl" runat="server" CssClass="ddl CS_Main_Check_Students" AutoPostBack="true"></asp:DropDownList>
                        <asp:DropDownList ID="Position_ddl" runat="server" CssClass="ddl CS_Main_Check_Dollars" AutoPostBack="True">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>$7.00</asp:ListItem>
                            <asp:ListItem>$6.50</asp:ListItem>
                            <asp:ListItem>$6.00</asp:ListItem>
                        </asp:DropDownList>
                    </p>
                    <br />
                    <asp:TextBox ID="writtenAmount_tb" runat="server" CssClass="textbox CS_Main_Check_Written" ReadOnly="True"></asp:TextBox>
                    <asp:Label ID="Label8" runat="server" Text="DOLLARS" CssClass="Dollars_text"></asp:Label>
                    <br />
                    <p>Memo 
                        <asp:DropDownList ID="memo_ddl" runat="server" CssClass="ddl CS_Main_Check_Memo">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Payroll 1</asp:ListItem>
                            <asp:ListItem>Payroll 2</asp:ListItem>
                            <asp:ListItem>Payroll 3</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="Label9" runat="server" Text="__________________________________________________" CssClass="Sign_line" Font-Underline="True"></asp:Label>
                    </p>                                   
                    <br>
                    <div class="CS_Main_Check_Bottom">
                        <a style="float: left;">00010001</a>&ensp;<a style="text-align: center;">0163719363452</a>&ensp;<a style="float: right;">12345678</a>
                    </div>
                </div>
            </div>

            <asp:HiddenField ID="visitdate_hf" runat="server" />
        </div>

        <script src="../../Scripts.js"></script>

    </form>
</body>
</html>
