<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BayCare_Admin_Assist.aspx.vb" Inherits="Enterprise_Village_2._0.BayCare_Admin_Assist" MaintainScrollPositionOnPostback="false" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>EV 2.0 - BayCare Administrative Assistant</title>

    <link href="~/~/css/Styles.StudentPages.css" rel="stylesheet" type="text/css"> <%--look in this css file for body and h3 tags--%>
    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png" />
</head>

<body>
    <form id="BayCare_Admin_Assist_Form" runat="server">
        <div id="Site_Wrap_Fullscreen">

            <%--Main Page--%>
            <div id="BayCareAA_Main_Page" runat="server">
                <div class="BayCareAA">
                    <h3>BayCare Administrative Assistant - Main</h3>
                    <asp:Button ID="vouchers_btn" runat="server" CssClass="BayCareAA_Main_Button" Text="Issuing Vouchers At Start Of Day" visible="false" />&ensp;<asp:Button ID="checkingIn_btn" runat="server" CssClass="BayCareAA_Main_Button" Text="Checking In Customers" />
                    <br /><br />
                    <asp:Button ID="finalReport_btn" runat="server" CssClass="BayCareAA_Main_Button" Text="Final Report" />
                    <br /><br />
                    <asp:Label ID="errorMain_lbl" runat="server" Font-Bold="True" Font-Size="XX-Large" ForeColor="Red"></asp:Label>
                </div>
            </div>

            <%--Vouchers--%>
            <div id="BayCareAA_Vouchers_Page">
                <div class="BayCareAA">
                    <h3>BayCare Administrative Assistant - Vouchers</h3>
                    <h4>Number of Vouchers Given to Manager:</h4>&ensp;<asp:TextBox ID="numVouchers_tb" runat="server" CssClass="textbox" TextMode="Number" Width="70px" Height="50px" Font-Size="X-Large"></asp:TextBox>
                    <br /><br />
                    <h4>Business Manager is from:</h4>&ensp;<asp:DropDownList ID="voucherBusiness_ddl" runat="server" CssClass="ddl" Height="50px" Font-Size="X-Large"></asp:DropDownList>
                    <br /><br /><br /><br />
                    <asp:Button ID="voucherNext_btn" runat="server" CssClass="BayCareAA_Next_Button" Text="Next Business Manager" />&ensp;<asp:Button ID="voucherReturn_btn" runat="server" CssClass="BayCareAA_Return_Button" Text="Return to Main" />
                </div>
            </div>
            
            <%--Check In--%>
            <div id="BayCareAA_CheckIn_Page" runat="server" visible="false">
                <div class="BayCareAA">
                    <h3>BayCare Administrative Assistant - Check In</h3>
                    <asp:Button ID="checkIn_btn" runat="server" CssClass="BayCareAA_Next_Button" Text="Check In" />
                    <br /><br />
                    <asp:DropDownList ID="checkInBusiness_ddl" runat="server" CssClass="ddl" Height="50px" Font-Size="X-Large" AutoPostBack="false"></asp:DropDownList>
                    <br /><br />
                    <asp:Button ID="checkInReturn_btn" runat="server" CssClass="BayCareAA_Return_Button" Text="Return to Main" />
                </div>
            </div>
            
            <%--Final Report--%>
            <div id="BayCareAA_Final_Report_Page">
                <div class="BayCareAA">
                    <h3>BayCare Administrative Assistant - Final Report</h3>
                    <asp:Button ID="finalReturn_btn" runat="server" CssClass="BayCareAA_Return_Button" Text="Return to Main" />
                    <br /><br /><br />
                        <asp:GridView ID="finalReport_dgv" runat="server" CellPadding="5" CellSpacing="1" PageSize="20" Font-Size="Medium" DataKeyNames="ID" AutoGenerateColumns="false" BorderColor="Black" HorizontalAlign="Center">
                            <Columns>
                                <asp:BoundField DataField="businessName" HeaderText="Business Name" ReadOnly="true" />
                                <asp:BoundField DataField="checkupsPerformed" HeaderText="Checkups Performed" ReadOnly="true" />
                            </Columns>
                        </asp:GridView>
                    
                </div>
            </div>  
            <asp:HiddenField ID="visitdate_hf" runat="server" />   
        </div>
           
        <script src="../../Scripts.js"></script>

    </form>
</body>
</html>
