<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Print_Operating_Checks.aspx.vb" Inherits="Enterprise_Village_2._0.Print_Operating_Checks" %>

<!doctype html>
<html>
<head runat ="server">

<meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">
          <title>Check Writing System</title>


<link href="css/Styles.Print.css" rel="stylesheet" media="print" type="text/css">
<link href="css/Styles.Utility.css" rel="stylesheet" media="screen" type="text/css">
        <link rel="shortcut icon" type="image/jpg" href="media/EV_favicon_2.png"/>
</head>

<body onafterprint="history.back();" onload="window.print();">
    <form id="Online_Banking_Form" runat="server">
    <div id="site_wrap">
    <div class="header1 no-print" >
    
    <img class="EV no-print" alt="Enterprise Village" src="Images/EV2.0_PCSB.png">
    
    </div>
        
    <div class="header2 no-print">
        <h2>Print Checks</h2> 
        </div>
        
      <div class="header3 no-print">
        <asp:Image ID="BusLogo_img" runat="server" Class="Business_logo"/>
        </div>
        
     <div class="main_boa">

         <div class="Account_area">
             


         <div class="Check_print Check_print1">
             <asp:Label ID="Checknumber1_lbl" runat="server" Text="37877" CssClass="Check_number"></asp:Label>
             <asp:Label ID="business_name1_lbl" runat="server" Text="Business Name" CssClass="Check_business_name"></asp:Label>
             <br />
             <asp:Label ID="address1_lbl" runat="server" Text="Business Address" CssClass="Business_address"></asp:Label>
             <asp:Label ID="Label_date1_lbl" runat="server" Text="1/01/2021" CssClass="Check_date" Font-Underline="True"></asp:Label>
             <asp:Label ID="Label5" runat="server" Text="DATE" CssClass="Check_date_text" ></asp:Label>
             <br /><br /><br />
             <asp:Label ID="Label6" runat="server" Text="Pay to the order of:" CssClass="Pay_to_the"></asp:Label>
             <asp:TextBox ID="checkName1_tb" runat="server" Text="" Width="440px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
             <asp:TextBox ID="checkAmount1_lbl" runat="server" Text="" Width="55px" style="text-align: center" CssClass="Check_textbox1 Amount_of_check" ReadOnly="True"></asp:TextBox>
             <br /><br />

             <asp:TextBox ID="writtenAmount1_tb" runat="server" Text="" Width="630px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
             <asp:Label ID="Label17" runat="server" Text="DOLLARS" CssClass="Dollars_text" ></asp:Label>
             <br /><br />
             <asp:Label ID="label100" runat="server" Text="Memo" CssClass="Memo"></asp:Label>
             <asp:TextBox ID="Memo1_tb" runat="server" Text="" Width="300px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
             <asp:Label ID="Label19" runat="server" Text="__________________________________________________________" CssClass="Sign_line" Font-Underline="True"></asp:Label>
            
             <br />
             <p class="Bottom_check">
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;001001 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 011900357 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 12345678 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  </p> 
</div>
             

         <div class="Check_print Check_print2">
             <asp:Label ID="Checknumber2_lbl" runat="server" Text="37877" CssClass="Check_number"></asp:Label>
             <asp:Label ID="business_name2_lbl" runat="server" Text="Business Name" CssClass="Check_business_name"></asp:Label>
             <br />
             <asp:Label ID="address2_lbl" runat="server" Text="Business Address" CssClass="Business_address"></asp:Label>
             <asp:Label ID="Label_date2_lbl" runat="server" Text="1/01/2021" CssClass="Check_date" Font-Underline="True"></asp:Label>
             <asp:Label ID="Label7" runat="server" Text="DATE" CssClass="Check_date_text" ></asp:Label>
             <br /><br /><br />
             <asp:Label ID="Label8" runat="server" Text="Pay to the order of:" CssClass="Pay_to_the"></asp:Label>
             <asp:TextBox ID="checkName2_tb" runat="server" Text="" Width="440px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
             <asp:TextBox ID="checkAmount2_lbl" runat="server" Text="" Width="55px" style="text-align: center" CssClass="Check_textbox1 Amount_of_check" ReadOnly="True"></asp:TextBox>
             <br /><br />

             <asp:TextBox ID="writtenAmount2_tb" runat="server" Text="" Width="630px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
             <asp:Label ID="Label9" runat="server" Text="DOLLARS" CssClass="Dollars_text" ></asp:Label>
             <br /><br />
             <asp:Label ID="label10" runat="server" Text="Memo" CssClass="Memo"></asp:Label>
             <asp:TextBox ID="Memo2_tb" runat="server" Text="" Width="300px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
             <asp:Label ID="Label11" runat="server" Text="__________________________________________________________" CssClass="Sign_line" Font-Underline="True"></asp:Label>
            
             <br />
             <p class="Bottom_check">
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;001001 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 011900357 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 12345678 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  </p> 
</div>
         <div class="Check_print Check_print3">
                          <asp:Label ID="Checknumber3_lbl" runat="server" Text="37877" CssClass="Check_number"></asp:Label>
             <asp:Label ID="business_name3_lbl" runat="server" Text="Business Name" CssClass="Check_business_name"></asp:Label>
             <br />
             <asp:Label ID="address3_lbl" runat="server" Text="Business Address" CssClass="Business_address"></asp:Label>
             <asp:Label ID="Label_date3_lbl" runat="server" Text="1/01/2021" CssClass="Check_date" Font-Underline="True"></asp:Label>
             <asp:Label ID="Label16" runat="server" Text="DATE" CssClass="Check_date_text" ></asp:Label>
             <br /><br /><br />
             <asp:Label ID="Label18" runat="server" Text="Pay to the order of:" CssClass="Pay_to_the"></asp:Label>
             <asp:TextBox ID="checkName3_tb" runat="server" Text="" Width="440px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
             <asp:TextBox ID="checkAmount3_lbl" runat="server" Text="" Width="55px" style="text-align: center" CssClass="Check_textbox1 Amount_of_check" ReadOnly="True"></asp:TextBox>
             <br /><br />

             <asp:TextBox ID="writtenAmount3_tb" runat="server" Text="" Width="630px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
             <asp:Label ID="Label20" runat="server" Text="DOLLARS" CssClass="Dollars_text" ></asp:Label>
             <br /><br />
             <asp:Label ID="label21" runat="server" Text="Memo" CssClass="Memo"></asp:Label>
             <asp:TextBox ID="Memo3_tb" runat="server" Text="" Width="300px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
             <asp:Label ID="Label22" runat="server" Text="__________________________________________________________" CssClass="Sign_line" Font-Underline="True"></asp:Label>
            
             <br />
             <p class="Bottom_check">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;001001 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 011900357 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 12345678 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  </p> 
</div>
                      <div class="Check_print Check_print4">
                          <asp:Label ID="Checknumber4_lbl" runat="server" Text="37877" CssClass="Check_number"></asp:Label>
             <asp:Label ID="business_name4_lbl" runat="server" Text="Business Name" CssClass="Check_business_name"></asp:Label>
             <br />
             <asp:Label ID="address4_lbl" runat="server" Text="Business Address" CssClass="Business_address"></asp:Label>
             <asp:Label ID="Label_date4_lbl" runat="server" Text="1/01/2021" CssClass="Check_date" Font-Underline="True"></asp:Label>
             <asp:Label ID="Label27" runat="server" Text="DATE" CssClass="Check_date_text" ></asp:Label>
             <br /><br /><br />
             <asp:Label ID="Label28" runat="server" Text="Pay to the order of:" CssClass="Pay_to_the"></asp:Label>
             <asp:TextBox ID="checkName4_tb" runat="server" Text="" Width="440px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
             <asp:TextBox ID="checkAmount4_lbl" runat="server" Text="" Width="55px" style="text-align: center" CssClass="Check_textbox1 Amount_of_check" ReadOnly="True"></asp:TextBox>
             <br /><br />

             <asp:TextBox ID="writtenAmount4_tb" runat="server" Text="" Width="630px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
             <asp:Label ID="Label29" runat="server" Text="DOLLARS" CssClass="Dollars_text" ></asp:Label>
             <br /><br />
             <asp:Label ID="label30" runat="server" Text="Memo" CssClass="Memo"></asp:Label>
             <asp:TextBox ID="Memo4_tb" runat="server" Text="" Width="300px" CssClass="Student_name Check_textbox" ReadOnly="True"></asp:TextBox>
             <asp:Label ID="Label31" runat="server" Text="__________________________________________________________" CssClass="Sign_line" Font-Underline="True"></asp:Label>
            
             <br />
             <p class="Bottom_check">
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;001001 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 011900357 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 12345678 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  </p>  
</div>







             
         
         
         
         </div> 
        </div>
        
    <div class="second no-print">

    
    </div>
   
    <div class="footer1 no-print"><p>Business Cost</p>
    <img class="icon1" src="images/Icons/noun_Excitement_267.png" width="70" height="76" alt="computer"/>
    </div>  
    
    <div class="footer2 no-print"><p>Checks Report</p>
    <img class="icon1" src="images/Icons/noun_Computer_216.png" width="70" height="67" alt="computer"/><br>
    </div>

    
    
    <div class="footer3 no-print">
    <asp:HiddenField ID="visitdate_hf" runat="server" />
    </div>
    
        <i onload="javascript:PrintPayrollChecks();"</i>
    
        
</div> 
<script src="Scripts.js"></script>
        </form>
</body>
</html>