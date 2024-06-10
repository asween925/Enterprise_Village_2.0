<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Teller_Startup.aspx.vb" Inherits="Enterprise_Village_2._0.Teller_Startup" %>

<!doctype html>
<html>
<head runat ="server">

<meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">
          <title>Teller System</title>


<link href="css/Styles.Teller.css" rel="stylesheet" type="text/css">
    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png"/>
</head>

<body>
    <form autocomplete="off"  id="Online_Banking_Form" runat="server">
    <div id="site_wrap">
    <div class="header1">
    
    <img class="EV" alt="Enterprise Village" src="../../Images/EV2.0_PCSB.png">
    
    </div>
        
    <div class="header2">
        <h2>Teller System</h2> 
        </div>
        
      <div class="header3">
        <img class="business" alt="Business" src="Images/Bank_of_America2.jpg" >
        </div>
        
     <div class="main_boa">


         <div class="Account_area">
            <div class="Account_summary">
                <asp:HiddenField ID="visitdate_hf" runat="server" />
            <h3 class="Bold">Deposit Check</h3>
             <p>Customer Account #</p>
             <asp:TextBox ID="Label11" runat="server" TextMode="Number" CssClass="Teller_textbox"></asp:TextBox>
            <br /><br />
            <asp:Button ID="Enter_account_btn" runat="server" Text="Enter" BackColor="Blue" Height="70px" CssClass="Teller_button" ForeColor="white" />
            
          </div>
            <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
                      <div class="Account_updates">
                         <h4>Confidentiality</h4>
                          <span>By using this system, you are agreeing to a confidentiality agreement. This agreement means that the user can not disclose any personal
                              or nonpublic information. While you may disclose generic account information, you can not disclosure sensitive information like social
                              security numbers without authorization from the bank. This agreement is designed to protect the bank and its valued customers. Thank you very much
                              for practicing safe confidentiality practices.
                          </span><br /><br />


             </div>



             </div>


        
          
        </div>
        
    <div class="second">
        <asp:Label ID="Label1" runat="server" Text="Account Navigation" CssClass="Account_info Bold" ></asp:Label><br /><br />
        <asp:Button ID="Button1" runat="server" Text="Checking" BackColor="#0000CC" Height="70px" CssClass="Teller_navigation Bold" ForeColor="white" />
        <asp:Button ID="Button2" runat="server" Text="Savings" BackColor="blue" Height="70px" CssClass="Teller_navigation" ForeColor="white" />
        <asp:Button ID="Button4" runat="server" Text="Credit Card" BackColor="blue" Height="70px" CssClass="Teller_navigation" ForeColor="white" />
        <asp:Button ID="Button5" runat="server" Text="Loan" BackColor="blue" Height="70px" CssClass="Teller_navigation" ForeColor="white" />
        <asp:Button ID="Button6" runat="server" Text="Money Market" BackColor="blue" Height="70px" CssClass="Teller_navigation" ForeColor="white" />
        <asp:Button ID="Button7" runat="server" Text="Certificate of Deposit" BackColor="blue" Height="70px" CssClass="Teller_navigation" ForeColor="white" />
    </div>
    

    
    
    <div class="footer3"><button onclick="myFunction()" class="submit">TBD</button>
    
    </div>
    
        
</div> 
<script src="../../Scripts.js"></script>
        </form>
</body>
</html>
