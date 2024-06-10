<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Print_ISI.aspx.vb" Inherits="Enterprise_Village_2._0.Print_ISI" %>

<!doctype html>
<html>
<head runat="server">

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">
    <title>Check Writing System</title>


    <link href="~/css/Styles.print.css" rel="stylesheet" media="print" type="text/css">
    <link href="~/css/Styles.updated.css" rel="stylesheet" media="screen" type="text/css">
    <link rel="shortcut icon" type="image/jpg" href="~/media/EV_favicon_2.png" />
</head>

<body onafterprint="history.back();" onload="window.print();">
    <form autocomplete="off"  id="Online_Banking_Form" runat="server">
        <div id="site_wrap">
            <%--Header information--%>
            <div class="no-print" id="header-e1">
                Enterprise Village 2.0
            </div>
            <div class="no-print" id="header-e3">
                <asp:Label ID="headerSchoolName_lbl" Text="Welcome Teachers!" runat="server"></asp:Label>
            </div>
            <div class="no-print" id="header-e2">
                &nbsp;
            </div>

            <%--Student Table--%>
            <div class="content_ISI">
                <p>Visit Information for Enterprise Village:</p>
                <asp:Label ID="Schools_lbl" runat="server" Font-Size="XX-Large" Font-Underline="false"></asp:Label>
                <asp:Label ID="Schools2_lbl" runat="server" Font-Size="XX-Large" Font-Underline="false"></asp:Label>
                <asp:Label ID="Schools3_lbl" runat="server" Font-Size="XX-Large" Font-Underline="false"></asp:Label>
                <asp:Label ID="Schools4_lbl" runat="server" Font-Size="XX-Large" Font-Underline="false"></asp:Label>
                <asp:Label ID="Schools5_lbl" runat="server" Font-Size="XX-Large" Font-Underline="false"></asp:Label>
                <asp:Label ID="visitDate_lbl" runat="server" Font-Size="XX-Large" Font-Underline="false"></asp:Label>
                <br />
                <asp:GridView ID="employees_dgv" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" CellPadding="5" CellSpacing="1" PageSize="20" Font-Size="Medium" Visible="true">
                    <AlternatingRowStyle BackColor="#99CCFF" />
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />
                        <asp:BoundField DataField="businessName" HeaderText="Business Name" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="employeeNumber" HeaderText="Account Number" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="firstName" HeaderText="First Name" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="lastName" HeaderText="Last Name" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="jobTitle" HeaderText="Position" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="schoolName" HeaderText="School Name" ReadOnly="true" Visible="false" />
                    </Columns>
                </asp:GridView>
            </div>

            <asp:HiddenField ID="visitID_hf" runat="server" />
            <div class="second no-print">
            </div>

            <div class="footer1 no-print">
                <p>Business Cost</p>
                <img class="icon1" src="images/Icons/noun_Excitement_267.png" width="70" height="76" alt="computer" />
            </div>

            <div class="footer2 no-print">
                <p>Checks Report</p>
                <img class="icon1" src="images/Icons/noun_Computer_216.png" width="70" height="67" alt="computer" /><br>
            </div>



            <div class="footer3 no-print">
                <asp:HiddenField ID="visitdate_hf" runat="server" />
            </div>

            <i onload="javascript:PrintPayrollChecks();"></i>


        </div>
        <asp:SqlDataSource ID="Review_sds" runat="server"></asp:SqlDataSource>
        <script src="../../Scripts.js"></script>
    </form>
</body>
</html>
