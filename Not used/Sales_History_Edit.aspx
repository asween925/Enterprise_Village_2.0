<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Sales_History_Edit.aspx.vb" Inherits="Enterprise_Village_2._0.Sales_History_Edit" %>

<!doctype html>
<html>
<head runat ="server">

<meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">
          <title>Sales History</title>


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
        <h2>Sales History Edit</h2> 
        </div>
        
      <div class="header3">
        <img class="business" alt="Business" src="" >
        </div>
        
     <div class="main_ups">



         <div class="Account_area">
            <div class="Employee_summary">
    




               
                <asp:GridView ID="Review_dgv" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="True" CellPadding="5" CellSpacing="1" PageSize="20" DataKeyNames="ID">
                    <AlternatingRowStyle BackColor="Aqua" />
                    <HeaderStyle BackColor="#99FF66" />
                    <SelectedRowStyle BackColor="#CC0066" />
                    <Columns>
                        <asp:TemplateField HeaderText="Business Name">
                            <ItemTemplate><asp:TextBox ID="Business_name_tb" runat="server" Width="100px" text='<%#Bind("Business_name") %>'></asp:TextBox></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Time Of Sale">
                            <ItemTemplate><asp:TextBox ID="Time_of_sale_tb" runat="server" Width="100px" text='<%#Bind("Time_of_sale") %>'></asp:TextBox></ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Account Number">
                            <ItemTemplate><asp:TextBox ID="Account_number_tb" runat="server" Width="100px" text='<%#Bind("Account_Number") %>'></asp:TextBox></ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Customer Name">
                            <ItemTemplate><asp:TextBox ID="Customer_name_tb" runat="server" Width="100px" text='<%#Bind("Customer_name") %>'></asp:TextBox></ItemTemplate>
                        </asp:TemplateField>
                         
                        <asp:TemplateField HeaderText="Total Sales">
                            <ItemTemplate><asp:TextBox ID="Total_Sales_tb" runat="server" Width="100px" text='<%#Bind("Total_sales") %>'></asp:TextBox></ItemTemplate>
                        </asp:TemplateField>


                    </Columns>




                </asp:GridView>
    




               
             </div>
            



             </div>


        
          
        </div>
        
    <div class="second">
      <ul>
      <li><h4>Table to repeat all applicable fields</h4></li>
      <li><h4>Text boxes to display fields and be editable</h4></li>
      <li><h4>Only allow characters for text boxes</h4></li>
      <li><h4>Sample instruction here</h4></li>
    </ul>
    
    </div>
    

    
    
    <div class="footer3"><button onclick="myFunction()" class="submit">Submit</button>
    
    </div>
    
        
</div> 
<script src="../../Scripts.js"></script>
        </form>
</body>
</html>

