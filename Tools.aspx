<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Tools.aspx.vb" Inherits="Enterprise_Village_2._0.Tools" %>

<!doctype html>
<html>
<head runat ="server">

<meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">
          <title>Profit Report</title>


<link href="css/Styles.Print.css" rel="stylesheet" media="print" type="text/css">
<link href="css/Styles.employeeManagement.css" rel="stylesheet" media="screen" type="text/css">
    <link rel="shortcut icon" type="image/png" href="media/EV_favicon_2.png"/>
</head>

<body>
    <form id="EMS_Form" runat="server">
    <div id="site_wrap">
    <div class="header1">
    
    <img class="EV" alt="Enterprise Village" src="Images/EV2.0_PCSB.png">
    
    </div>
        
    <div class="header2">
        <h2>Profit Report</h2> 
        </div>
        
      <div class="header3">
        <asp:Image ID="BusLogo_img" runat="server" Class="Business_logo"/>
        </div>
        
     <div class="main_ups">



         <div class="Account_area">
            <div class="Employee_summary">
                <asp:LinkButton ID="LinkButton1"  runat="server" PostBackUrl="https://ev.pcsb.org/reports.aspx">Update School and Visit Info</asp:LinkButton><br /><br /><br />
                  <asp:LinkButton ID="LinkButton2"  runat="server" PostBackUrl="https://ev.pcsb.org/reports.aspx">Insert Database Entries</asp:LinkButton><br /><br /><br />


                <asp:Label runat="server" ID="error_lbl"></asp:Label>

               
               <asp:GridView ID="businessProfit_dgv" runat="server" AutoGenerateColumns="False" CellPadding="5" CellSpacing="1" PageSize="20" Font-Size="Medium">
                 <AlternatingRowStyle BackColor="#99CCFF" />
                 <Columns>
                     <asp:BoundField DataField="businessName" HeaderText="Business" ReadOnly="true" Visible="true" />
                     <asp:BoundField DataField="Profits" HeaderText="Profits" ReadOnly="true" Visible="true" />
                     <asp:BoundField DataField="loan" HeaderText="Loan Amount" ReadOnly="true" Visible="true" />


                     
                 </Columns>
             </asp:GridView>




               
                <br />
    




               
             </div>
            



             </div>


        
          
        </div>
        

    <asp:HiddenField ID="visitdate_hf" runat="server" />
        <asp:HiddenField ID="businessID_hf" runat="server" />

    
        
</div> 
<script src="Scripts.js"></script>
        <asp:SqlDataSource ID="Review_sds" runat="server"></asp:SqlDataSource>
        </form>
</body>
</html>

