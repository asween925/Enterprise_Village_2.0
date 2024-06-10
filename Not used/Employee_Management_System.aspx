<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Employee_Management_System.aspx.vb" Inherits="Enterprise_Village_2._0.Employee_Management_System" %>

<!doctype html>
<html>
<head runat ="server">

<meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">
          <title>Employee Test</title>


<link href="css/Styles.OnlineBanking.css" rel="stylesheet" type="text/css">
</head>

<body>
    <form autocomplete="off"  id="Online_Banking_Form" runat="server">
    <div id="site_wrap">
    <div class="header1">
    
    <img class="EV" alt="Enterprise Village" src="../../Images/EV2.0_PCSB.png">
    
    </div>
        
    <div class="header2">
        <h2>Employee Management System</h2> 
        </div>
        
      <div class="header3">
        <img class="business" alt="Business" src="" >
        </div>
        
     <div class="main_ups">
         <div class="Business_name">
         <p>Select Business</p>
         <asp:DropDownList CssClass="ddl" ID="Business_Select_List" runat="server" Width="200px"></asp:DropDownList>
             </div>


         <div class="Account_area">
            <div class="Account_summary">
                            <p>Employee Account Number</p>
             <br />
             <asp:Label ID="Business_name" runat="server" Text="###"></asp:Label>
             <br /><br />
             <p>First Name</p>
             <asp:TextBox ID="Student_first_name" runat="server" TextMode="SingleLine" Width="150px" ></asp:TextBox>
             <br /><br />
             <p>Last Name</p>
             <asp:TextBox ID="Student_last_name" runat="server" TextMode="SingleLine" Width="150px" ></asp:TextBox>
             <br /><br />
             <p>Employee Position</p>
             <asp:DropDownList CssClass="ddl" ID="DropDownList4" runat="server" Width="200px"></asp:DropDownList>
             <br /><br />
             <asp:Button ID="Previous_employee" runat="server" Text="Go to Previous Employee" height="50px" BackColor="White" Width="200px" />
             <asp:Button ID="Add_next_employee" runat="server" Text="Add Next Employee" height="50px" BackColor="White" Width="200px" />
             <br /><br /><br />
             <asp:Button ID="Submit_employees" runat="server" Text="When you finish inputting names, have your volunteer come over and click this button." 
             height="70px" BackColor="White" Font-Bold="true"/>
             <br /><br />
             <p>Volunteers:When checking the student's work, please make sure that capitalization and spelling are correct.</p>
             </div>
            



             </div>


        
          
        </div>
        
    <div class="second">
      <ul>
      <li><h4>Max-length on textbox not working</h4></li>
      <li><h4>Employee Position dropdown box to fit the business.</h4></li>
      <li><h4>Only allow characters for text boxes</h4></li>
      <li><h4>Css to control text size of button</h4></li>
    </ul>
    
    </div>
    

    
    
    <div class="footer3"><button onclick="myFunction()" class="submit">Submit</button>
    
    </div>
    
        
</div> 
<script src="../../Scripts.js"></script>
        </form>
</body>
</html>

