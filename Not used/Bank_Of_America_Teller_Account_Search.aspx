<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Bank_Of_America_Teller_Account_Search.aspx.vb" Inherits="Enterprise_Village_2._0.Bank_Of_America_Teller_Account_Search" %>

<!doctype html>
<html>
<head runat ="server">

<meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">
          <title>Teller System</title>


<link href="css/Styles.OnlineBanking.css" rel="stylesheet" type="text/css">
</head>

<body>
    <form id="Online_Banking_Form" runat="server">
    <div id="site_wrap">
    <div class="header1">
    
    <img class="EV" alt="Enterprise Village" src="Images/EV2.0_PCSB.png">
    
    </div>
        
    <div class="header2">
        <h2>Teller System</h2> 
        </div>
        
      <div class="header3">
        <img class="business" alt="Business" src="Images/Bank_of_America2.jpg" >
        </div>
        
     <div class="main_boa">
         <div class="Business_name">
         <asp:Label ID="Student_name" runat="server" Text="Student Name"></asp:Label>
         <asp:Label ID="Account_Number" runat="server" Text="###"></asp:Label>
         </div>

         <div class="Account_area">
            <div class="Account_summary">
            <h4>Account Summary</h4>
                            <p>Total Sales</p>
             <asp:TextBox ID="Total_deposits" runat="server"></asp:TextBox>
             <p>Total Deposits</p>
             <asp:TextBox ID="Total_purchases" runat="server"></asp:TextBox>
             <p>Balance</p>
             <asp:TextBox ID="Balance" runat="server"></asp:TextBox>

             </div>
            
         <div class="Account_updates">
                         <h4>Deposits</h4>
                          <p>Net Deposit 1</p>
             <asp:TextBox ID="Student_deposit_1" runat="server" TextMode="Number" MaxLength="6" Width="75px" ></asp:TextBox>
             <asp:Button ID="Update_student_deposit_1" runat="server" Text="Submit" />
             <p>Net Deposit 2</p>
             <asp:TextBox ID="Student_deposit_2" runat="server" TextMode="Number" MaxLength="6" Width="75px" ></asp:TextBox>
             <asp:Button ID="Update_student_deposit_2" runat="server" Text="Submit" />
             <p>Net Deposit 3</p>
             <asp:TextBox ID="Student_deposit_3" runat="server" TextMode="Number" MaxLength="6" Width="75px" ></asp:TextBox>
             <asp:Button ID="Update_student_deposit_3" runat="server" Text="Submit" />
             <p>Net Deposit 4</p>
             <asp:TextBox ID="Student_deposit_4" runat="server" TextMode="Number" MaxLength="6" Width="75px" ></asp:TextBox>
             <asp:Button ID="Update_student_deposit_4" runat="server" Text="Submit" />
             <br /><br />
             <p>Auto Savings $1.50</p>

             </div>


             </div>


        
          
        </div>
        
    <div class="second">
      <ul>
      <li><h4>Max-length on textbox not working</h4></li>

      <li><h4>Goals:Prevent field from being emptied after 1st submission.</h4></li>
      <li><h4>Sample instruction here</h4></li>
    </ul>
    
    </div>
    

    
    
    <div class="footer3"><button onclick="myFunction()" class="submit">Finish Transaction</button>
    
    </div>
    
        
</div> 
<script src="Scripts.js"></script>
        </form>
</body>
</html>
