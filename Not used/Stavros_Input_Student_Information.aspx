<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Stavros_Input_Student_Information.aspx.vb" Inherits="Enterprise_Village_2._0.Stavros_Input_Student_Information" %>

<!doctype html>
<html>
<head runat ="server">

<meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">
          <title>Employee Management System</title>


<link href="css/Styles.OnlineBanking.css" rel="stylesheet" type="text/css">
    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png"/>
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

             <asp:Label ID="Schools_lbl" runat="server" Text="Sample School"></asp:Label>
             <br /><br />
             <asp:DropDownList CssClass="ddl" ID="date_ddl" runat="server" AutoPostBack="True"></asp:DropDownList>
             <br /><br />
             <p>Select Business</p>
         <asp:DropDownList CssClass="ddl" ID="business_ddl" runat="server" Width="200px"></asp:DropDownList>
             


             </div>




         <div class="Account_area">
            <div class="Employee_entry">
                             <p>Employee Account Number</p>
             <asp:Label ID="Account_number_lbl" runat="server" Text="###"></asp:Label>
                <br /><br />
                            
                          <p>Employee Position</p>
             <asp:Label ID="Employee_Position_lbl" runat="server" Text="###" Width="200"></asp:Label>
             <br /><br />
             <p>First Name</p>
             <asp:TextBox ID="Student_first_name_tb" runat="server" TextMode="SingleLine" Width="150px" ></asp:TextBox>
                <br /><br />
             <p>Last Name</p>
             <asp:TextBox ID="Student_last_name_tb" runat="server" TextMode="SingleLine" Width="150px" ></asp:TextBox>
             <br /><br />
             <asp:Button ID="Previous_employee" runat="server" Text="Go to Previous Employee" height="50px" BackColor="White" Width="200px" />
             <asp:Button ID="Add_next_employee" runat="server" Text="Add Next Employee" height="50px" BackColor="White" Width="200px" />
             <br /><br /><br />
             <asp:Button ID="Submit_employees" runat="server" Text="When you finish inputting names, click this button to review business assignment sheet" height="70px" width="95%" BackColor="White" Font-Bold="true"/>
             <br /><br />
             </div>
            



             </div>


        
          
        </div>
        
    <div class="second">
      
        <!--
        <ul>
      <li><h4>This page needs to allow null values to be editable</h4></li>
      <li><h4>Max-length on textbox not working</h4></li>
      <li><h4>Employee Position dropdown box to fit the business.</h4></li>
      <li><h4>Only allow characters for text boxes</h4></li>
      <li><h4>Css to control text size of button</h4></li>
    </ul>
        -->
    
    </div>
    

    
    
    <div class="footer3"><button onclick="myFunction()" class="submit">TBD</button>
    
    </div>
    
        
</div> 
<script src="../../Scripts.js"></script>
        </form>
</body>
</html>
