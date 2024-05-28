<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ATM.aspx.vb" Inherits="Enterprise_Village_2._0.ATM" %>

<!doctype html>
<html>
<head runat ="server">

<meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">
          <title>ATM</title>


<link href="~/css/Styles.profit.css" rel="stylesheet" type="text/css">
    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png"/>
</head>

<body>
    <form id="Profit_display_Form" runat="server">
    <div id="site_wrap">

        
     <div class="main_bbb">

         <asp:Label ID="Label2" runat="server" Text="ATM" Font-Size="200px"></asp:Label>
         <br />
            <asp:Label ID="Label1" runat="server" Text="Swipe your debit card"></asp:Label>
         <br />
            <asp:TextBox ID="employee_number" runat="server" Height="150px" Width="165px" Font-Size="90px" autofocus=""></asp:TextBox>

             </div>
            


        

    

    
    

    
        
</div> 
<script src="../../Scripts.js"></script>
        </form>
</body>
</html>
