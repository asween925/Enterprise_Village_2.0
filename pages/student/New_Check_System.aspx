<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="New_Check_System.aspx.vb" Inherits="Enterprise_Village_2._0.New_Check_System" MaintainScrollPositionOnPostback="false" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <%--<meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">--%>

    <title>Enterprise Village - Payroll Checks</title>

    <link href="~/css/Styles.StudentPages.css" rel="stylesheet" type="text/css">
    <link rel="stylesheet" href="../../css/flickity.min.css" media="screen">

    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png" />
</head>

<body>
    <form autocomplete="off" id="Template_Student_Full" runat="server">
        <div id="Site_Wrap_Fullscreen">

            <%--Content--%>
            <div id="contentCS_div" runat="server" class="CS_BG_Default">

                <%--Header--%>
                <div id="divHeader" runat="server" class="CS_Header">
                    <div id="nav-placeholder"></div>
                    <a class="CS_Header_Title">
                        <asp:Label ID="businessNameHeader_lbl" runat="server"></asp:Label>
                        Payroll Check System</a>
                    <a>
                        <asp:Image ID="imgStartLogo" runat="server" ImageUrl="~/Media/FP_Logo.png" CssClass="CS_Header_Logo" /></a>
                </div>

                <%--Link Buttons--%>
                <div id="groupButtons_div" runat="server" style="text-align: center; margin-top: 10px;">
                    <asp:Button ID="F1URL" runat="server" CssClass="group_button" Text="Operating Checks"> </asp:Button>
                    <asp:Button ID="F2URL" runat="server" CssClass="group_button" Text="Online Banking"> </asp:Button>
                </div>

                <%--Group Selector--%>
                <div id="groupSelect_div" runat="server" class="CS_Group_Div">
                    <p style="font-weight: bold;">Select Payroll Group:</p>
                    <asp:DropDownList ID="groupSelect_ddl" runat="server" CssClass="CS_Group_DDL" AutoPostBack="true">
                        <asp:ListItem>Payroll 1</asp:ListItem>
                        <asp:ListItem>Payroll 2</asp:ListItem>
                        <asp:ListItem>Payroll 3</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <br />
                <asp:Label ID="error_lbl" runat="server" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                <br />

                <!-- Check Carousel -->
                <div class="gallery js-flickity">

                    <%--Check 1--%>
                    <div id="check1_div" class="gallery-cell" visible="true ">
                        <div class="CS_Main_Check">
                            <asp:Label ID="businessName1_lbl" runat="server" Text="Business Name" CssClass="CS_Main_Check_BizName"></asp:Label>&ensp;<asp:Label ID="currentDate1_lbl" runat="server" Text="1/01/2021" CssClass="CS_Main_Check_Date" Font-Underline="True"></asp:Label>
                            <br />
                            <asp:Label ID="address1_lbl" runat="server" Text="Business Address" CssClass="CS_Main_Check_Address"></asp:Label>
                            <br />
                            <p id="nameLine1_p" runat="server" cssclass="CS_Main_Check_NameLine">
                                Pay to the order of: &ensp;
                                <asp:DropDownList ID="students1_ddl" runat="server" CssClass="ddl CS_Main_Check_Students" AutoPostBack="true"></asp:DropDownList>
                                <asp:DropDownList ID="Position1_ddl" runat="server" CssClass="ddl CS_Main_Check_Dollars" AutoPostBack="True">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>$7.00</asp:ListItem>
                                    <asp:ListItem>$6.50</asp:ListItem>
                                    <asp:ListItem>$6.00</asp:ListItem>
                                </asp:DropDownList>
                            </p>
                            <asp:TextBox ID="writtenAmount1_tb" runat="server" CssClass="textbox CS_Main_Check_Written" ReadOnly="True"></asp:TextBox>
                            <asp:Label ID="Label8" runat="server" Text="DOLLARS" CssClass="Dollars_text"></asp:Label>
                            <br />
                            <p>
                                Memo: 
                                <asp:DropDownList ID="memo1_ddl" runat="server" CssClass="ddl CS_Main_Check_Memo" enabled="false">
                                    <asp:ListItem>Payroll 1</asp:ListItem>
                                    <asp:ListItem>Payroll 2</asp:ListItem>
                                    <asp:ListItem>Payroll 3</asp:ListItem>
                                </asp:DropDownList>&ensp;
                                <asp:Label ID="Label9" runat="server" Text="____________________________________________" CssClass="CS_Main_Check_SignLine" Font-Underline="True"></asp:Label>
                            </p>
                            <br />
                            <div class="CS_Main_Check_Bottom">
                                <a style="float: left;">00010001</a>&ensp;<a style="text-align: center;">0163719363452</a>&ensp;<a style="float: right;">12345678</a>
                            </div>
                        </div>
                    </div>

                    <%--Check 2--%>
                    <div id="check2_div" runat="server" class="gallery-cell" visible="true">
                        <div class="CS_Main_Check">
                            <asp:Label ID="businessName2_lbl" runat="server" Text="Business Name" CssClass="CS_Main_Check_BizName"></asp:Label>&ensp;<asp:Label ID="currentDate2_lbl" runat="server" Text="1/01/2021" CssClass="CS_Main_Check_Date" Font-Underline="True"></asp:Label>
                            <br />
                            <asp:Label ID="address2_lbl" runat="server" Text="Business Address" CssClass="CS_Main_Check_Address"></asp:Label>
                            <br />
                            <p id="nameLine2_p" runat="server" cssclass="CS_Main_Check_NameLine">
                                Pay to the order of: &ensp;
                              <asp:DropDownList ID="students2_ddl" runat="server" CssClass="ddl CS_Main_Check_Students" AutoPostBack="true"></asp:DropDownList>
                                <asp:DropDownList ID="Position2_ddl" runat="server" CssClass="ddl CS_Main_Check_Dollars" AutoPostBack="True">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>$7.00</asp:ListItem>
                                    <asp:ListItem>$6.50</asp:ListItem>
                                    <asp:ListItem>$6.00</asp:ListItem>
                                </asp:DropDownList>
                            </p>
                            <asp:TextBox ID="writtenAmount2_tb" runat="server" CssClass="textbox CS_Main_Check_Written" ReadOnly="True"></asp:TextBox>
                            <asp:Label ID="Label4" runat="server" Text="DOLLARS" CssClass="Dollars_text"></asp:Label>
                            <br />
                            <p>
                                Memo 
                              <asp:DropDownList ID="memo2_ddl" runat="server" CssClass="ddl CS_Main_Check_Memo" enabled="false">
                                  <asp:ListItem>Payroll 1</asp:ListItem>
                                  <asp:ListItem>Payroll 2</asp:ListItem>
                                  <asp:ListItem>Payroll 3</asp:ListItem>
                              </asp:DropDownList>
                                <br />
                                <asp:Label ID="Label5" runat="server" Text="______________________________________________________________" CssClass="CS_Main_Check_SignLine" Font-Underline="True"></asp:Label>
                            </p>
                            <br />
                            <div class="CS_Main_Check_Bottom">
                                <a style="float: left;">00010001</a>&ensp;<a style="text-align: center;">0163719363452</a>&ensp;<a style="float: right;">12345678</a>
                            </div>
                        </div>
                    </div>

                    <%--Check 3--%>
                    <div id="check3_div" runat="server" class="gallery-cell" visible="true">
                        <div class="CS_Main_Check">
                            <asp:Label ID="businessName3_lbl" runat="server" Text="Business Name" CssClass="CS_Main_Check_BizName"></asp:Label>&ensp;<asp:Label ID="currentDate3_lbl" runat="server" Text="1/01/2021" CssClass="CS_Main_Check_Date" Font-Underline="True"></asp:Label>
                            <br />
                            <asp:Label ID="address3_lbl" runat="server" Text="Business Address" CssClass="CS_Main_Check_Address"></asp:Label>
                            <br />
                            <p id="nameLine3_p" runat="server" cssclass="CS_Main_Check_NameLine">
                                Pay to the order of: &ensp;
                            <asp:DropDownList ID="students3_ddl" runat="server" CssClass="ddl CS_Main_Check_Students" AutoPostBack="true"></asp:DropDownList>
                                <asp:DropDownList ID="Position3_ddl" runat="server" CssClass="ddl CS_Main_Check_Dollars" AutoPostBack="True">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>$7.00</asp:ListItem>
                                    <asp:ListItem>$6.50</asp:ListItem>
                                    <asp:ListItem>$6.00</asp:ListItem>
                                </asp:DropDownList>
                            </p>
                            <asp:TextBox ID="writtenAmount3_tb" runat="server" CssClass="textbox CS_Main_Check_Written" ReadOnly="True"></asp:TextBox>
                            <asp:Label ID="Label11" runat="server" Text="DOLLARS" CssClass="Dollars_text"></asp:Label>
                            <br />
                            <p>
                                Memo 
                            <asp:DropDownList ID="memo3_ddl" runat="server" CssClass="ddl CS_Main_Check_Memo" enabled="false">
                                <asp:ListItem>Payroll 1</asp:ListItem>
                                <asp:ListItem>Payroll 2</asp:ListItem>
                                <asp:ListItem>Payroll 3</asp:ListItem>
                            </asp:DropDownList>
                                <br />
                                <asp:Label ID="Label12" runat="server" Text="______________________________________________________________" CssClass="CS_Main_Check_SignLine" Font-Underline="True"></asp:Label>
                            </p>
                            <br />
                            <div class="CS_Main_Check_Bottom">
                                <a style="float: left;">00010001</a>&ensp;<a style="text-align: center;">0163719363452</a>&ensp;<a style="float: right;">12345678</a>
                            </div>
                        </div>
                    </div>
                    
                    <%--Check 4--%>
                    <div id="check4_div" runat="server" class="gallery-cell" visible="true">
                        <div class="CS_Main_Check">
                            <asp:Label ID="businessName4_lbl" runat="server" Text="Business Name" CssClass="CS_Main_Check_BizName"></asp:Label>&ensp;<asp:Label ID="currentDate4_lbl" runat="server" Text="1/01/2021" CssClass="CS_Main_Check_Date" Font-Underline="True"></asp:Label>
                            <br />
                            <asp:Label ID="address4_lbl" runat="server" Text="Business Address" CssClass="CS_Main_Check_Address"></asp:Label>
                            <br />
                            <p id="nameLine4_p" runat="server" cssclass="CS_Main_Check_NameLine">
                                Pay to the order of: &ensp;
                                <asp:DropDownList ID="students4_ddl" runat="server" CssClass="ddl CS_Main_Check_Students" AutoPostBack="true"></asp:DropDownList>
                                <asp:DropDownList ID="Position4_ddl" runat="server" CssClass="ddl CS_Main_Check_Dollars" AutoPostBack="True">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>$7.00</asp:ListItem>
                                    <asp:ListItem>$6.50</asp:ListItem>
                                    <asp:ListItem>$6.00</asp:ListItem>
                                </asp:DropDownList>
                            </p>
                            <asp:TextBox ID="writtenAmount4_tb" runat="server" CssClass="textbox CS_Main_Check_Written" ReadOnly="True"></asp:TextBox>
                            <asp:Label ID="Label16" runat="server" Text="DOLLARS" CssClass="Dollars_text"></asp:Label>
                            <br />
                            <p>
                                Memo 
                                <asp:DropDownList ID="memo4_ddl" runat="server" CssClass="ddl CS_Main_Check_Memo" enabled="false">
                                    <asp:ListItem>Payroll 1</asp:ListItem>
                                    <asp:ListItem>Payroll 2</asp:ListItem>
                                    <asp:ListItem>Payroll 3</asp:ListItem>
                                </asp:DropDownList>
                                <br />
                                <asp:Label ID="Label17" runat="server" Text="______________________________________________________________" CssClass="CS_Main_Check_SignLine" Font-Underline="True"></asp:Label>
                            </p>
                            <br />
                            <div class="CS_Main_Check_Bottom">
                                <a style="float: left;">00010001</a>&ensp;<a style="text-align: center;">0163719363452</a>&ensp;<a style="float: right;">12345678</a>
                            </div>
                        </div>
                    </div>
                   
                </div>

                <%--Buttons--%>
                <div id="buttons_div" runat="server" class="CS_Buttons_Div">
                    <asp:Button ID="save_btn" runat="server" CssClass="save_check" Text="Save Check" />&ensp;<asp:Button ID="delete_btn" runat="server" CssClass="delete_button" Text="Delete Check" />
                    <br />
                    <asp:Button ID="print_btn" runat="server" CssClass="print_button2" Text="Print" />
                </div>
                <br />

                <%--EV Logo for Printing--%>    
                <div class="EV_Logo_Wrapper">
                    <img ID="EVLogo_img" runat="server" src="~\media\EnterpriseVillage.png" Visible="true"/> 
                </div>
                
            </div>

            <%--Popup--%>
            <div id="popup" runat="server" visible="true">
                <p class="Sim_Research_Popup_Header">
                    <asp:Label ID="lblPopupText" runat="server" Text="Welcome to Enterprise Village!"></asp:Label></p>
                <p>As the financial officer, you are responsible for creating and handing out checks to your fellow employees. First off, click the button below to print out the check for Ditek!</p>
                <asp:Button ID="btnEnter" runat="server" Text="Enter" CssClass="button"  /><asp:Button ID="btnCancel" runat="server" CssClass="buttonReset" Text="Cancel"></asp:Button>
            </div> 

            <asp:HiddenField ID="visitdate_hf" runat="server" />
        </div>

        <script src="../../Scripts.js"></script>
        <script src="../../jscript/flickity.pkgd.min.js">
            $('.main-gallery').flickity({
                // options
                cellAlign: 'left',
                contain: true
            });
        </script>
        <script>
            function togglePopup() {
                //Blur the div with the blur id
                var blur = document.getElementById('contentCS_div');
                blur.classList.toggle('active');

                //Toggle the Sim Research Popup
                var popup = document.getElementById('popup');
                popup.classList.toggle('active');
            }
        </script>

    </form>
</body>
</html>
