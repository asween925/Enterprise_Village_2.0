<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Mayor_Population_Count.aspx.vb" Inherits="Enterprise_Village_2._0.Mayor_Population_Count" %>

<!doctype html>
<html>
<head runat ="server">
<meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">
          <title>Mayor Checklist</title>


<link href="~/css/Styles.Checklist.css" rel="stylesheet" type="text/css">
</head>

<body>
    <form id="form1" runat="server">
    <div id="site_wrap">
    <div class="header1">
    
    <img class="EV" alt="Enterprise Village" src="../../Images/EV2.0_PCSB.png">
    
    </div>
        
    <div class="header2">
        <h2>Mayor</h2> 
        </div>
        
      <div class="header3">
        <img class="business" alt="Business" src="Images/cityhall.jpg" >
        </div>
        
     <div class="main_city">
         <h4>Mayor Population Count<br> and Shopping Bag Delivery Sheet</h4>
        <table border="1" >
            <tbody>
              <tr>
                <td class="table_header2">Business</td>
                <td class="table_header2">Number of Employees</td>
                <td class="table_header2">Bags Delivered</td>
              </tr>
              <tr>
                <td><p>Astro Skate</p></td>
                <td class="text_field"><asp:TextBox ID="bus1_employees_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus1_bag_cb" runat="server" /></td>
              </tr>
              <tr>
                <td><p>Achieva Credit Union</p></td>
                <td class="text_field"><asp:TextBox ID="bus2_employees_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus2_bag_cb" runat="server" /></td>
              </tr>
              <tr>
                <td><p>BayCare</p></td>
                <td class="text_field"><asp:TextBox ID="bus3_employees_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus3_bag_cb" runat="server" /></td>
              </tr>
              <tr>
                <td><p>BBB</p></td>
                <td class="text_field"><asp:TextBox ID="bus4_employees_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus4_bag_cb" runat="server" /></td>
              </tr>
              <tr>
                <td><p>Koozie Group</p></td>
                <td class="text_field"><asp:TextBox ID="bus5_employees_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus5_bag_cb" runat="server" /></td>
              </tr>
              <tr>
                <td><p>Buccaneers</p></td>
                <td class="text_field"><asp:TextBox ID="bus18_employees_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus18_bag_cb" runat="server" /></td>
              </tr>
              <tr>
                <td><p>City Hall</p></td>
                <td class="text_field"><asp:TextBox ID="bus6_employees_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus6_bag_cb" runat="server" /></td>
              </tr>
              <tr>
                <td><p>CVS</p></td>
                <td class="text_field"><asp:TextBox ID="bus7_employees_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus7_bag_cb" runat="server" /></td>
              </tr>
              <tr>
                <td><p>Ditek</p></td>
                <td class="text_field"><asp:TextBox ID="bus9_employees_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus9_bag_cb" runat="server" /></td>
              </tr>
              <tr>
                <td><p>Duke Energy</p></td>
                <td class="text_field"><asp:TextBox ID="bus10_employees_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus10_bag_cb" runat="server" /></td>
              </tr>
              <tr>
                <td><p>HSN</p></td>
                <td class="text_field"><asp:TextBox ID="bus11_employees_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus11_bag_cb" runat="server" /></td>
              </tr>
              <tr>
                <td><p>Kane's</p></td>
                <td class="text_field"><asp:TextBox ID="bus12_employees_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus12_bag_cb" runat="server" /></td>
              </tr>
              <tr>
                <td><p>McDonald's</p></td>
                <td class="text_field"><asp:TextBox ID="bus13_employees_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus13_bag_cb" runat="server" /></td>
              </tr>
              <tr>
                <td><p>Mix 100.7</p></td>
                <td class="text_field"><asp:TextBox ID="bus14_employees_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus14_bag_cb" runat="server" /></td>
              </tr>
              <tr>
                <td><p>Professional Offices</p></td>
                <td class="text_field"><asp:TextBox ID="bus17_employees_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus17_bag_cb" runat="server" /></td>
              </tr>
              <tr>
                <td><p>Rays</p></td>
                <td class="text_field"><asp:TextBox ID="bus19_employees_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus19_bag_cb" runat="server" /></td>
              </tr>
              <tr>
                <td><p>Tampa Bay Times</p></td>
                <td class="text_field"><asp:TextBox ID="bus20_employees_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus20_bag_cb" runat="server" /></td>
              </tr>
              <tr>
                <td><p>Tech Data</p></td>
                <td class="text_field"><asp:TextBox ID="bus21_employees_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus21_bag_cb" runat="server" /></td>
              </tr>
              <tr>
                <td><p>Verizon</p></td>
                <td class="text_field"><asp:TextBox ID="bus23_employees_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus23_bag_cb" runat="server" /></td>
              </tr>
            </tbody>
          </table>
        </div>
        
    <div class="second">
      <ul>
      <li><h4>Take Ipad to each business and locate the break schedule on the wall. Count the number of employees and enter the total in the left column.</h4></li>
      <li><h4>Deliver that many bags to each business and check off each box as you go.</h4></li>
      <li><h4>Return Ipad to EV staff member when done.</h4></li>
    </ul>
    </div>
    

    
    
    
    <div class="footer3"><button onclick="myFunction()" class="submit">Submit</button>
    
    </div>
    
        
</div> 
<script src="../../Scripts.js"></script>
    </form>
</body>
</html>
