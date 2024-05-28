<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Verizon_Telecommunication_Engineer_Checklist.aspx.vb" Inherits="Enterprise_Village_2._0.Verizon_Telecommunication_Engineer_Checklist" %>

<!doctype html>
<html>
<head runat ="server">
<meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">
          <title>Verizon Telecommunication Engineer Checklist</title>


<link href="~/css/Styles.Checklist.css" rel="stylesheet" type="text/css">
</head>

<body>
    <form id="form1" runat="server">
    <div id="site_wrap">
    <div class="header1">
    
    <img class="EV" alt="Enterprise Village" src="../../Images/EV2.0_PCSB.png">
    
    </div>
        
    <div class="header2">
        <h2>Telecommunication Engineer</h2> 
        </div>
        
      <div class="header3">
        <img class="business" alt="Business" src="../../media/logos/Verizon/verizon1.png" >
        </div>
        
     <div class="main_verizon">
        <br /><br /><br /><br />
        <table class="tall_table" border="1" >
            <tbody>
              <tr>
                <td class="table_header2">Business</td>
                <td class="table_header2">Telephone extension card delivered and TV turned on</td>
                <td class="table_header2">Collected Payment</td>
                <td class="table_header2">Telephone extention card collected and TV turned off</td>
              </tr>
              <tr>
                <td class="row_text"><p>Astro Skate</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus1_tvon_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus1_bus23collect_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus1_tvoff_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Achieva Credit Union</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus2_tvon_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus2_bus23collect_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus2_tvoff_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>BayCare</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus_tvon_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus_bus23collect_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus_tvoff_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>BBB</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus4_tvon_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus4_bus23collect_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus4_tvoff_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Koozie Group</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus5_tvon_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus5_bus23collect_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus5_tvoff_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Buccaneers</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus18_tvon_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus18_bus23collect_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus18_tvoff_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>City Hall</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus6_tvon_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus6_bus23collect_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus6_tvoff_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>CVS</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus7_tvon_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus7_bus23collect_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus7_tvoff_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Ditek</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus9_tvon_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus9_bus23collect_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus9_tvoff_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Duke Energy</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus10_tvon_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus10_bus23collect_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus10_tvoff_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>HSN</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus11_tvon_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus11_bus23collect_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus11_tvoff_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Kane's</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus12_tvon_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus12_bus23collect_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus12_tvoff_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>McDonald's</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus13_tvon_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus13_bus23collect_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus13_tvoff_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Mix 100.7</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus14_tvon_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus14_bus23collect_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus14_tvoff_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Professional Offices</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus17_tvon_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus17_bus23collect_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus17_tvoff_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Rays</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus19_tvon_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus19_bus23collect_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus19_tvoff_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Tampa Bay Times</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus20_tvon_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus20_bus23collect_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus20_tvoff_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Tech Data</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus21_tvon_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus21_bus23collect_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus21_tvoff_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Verizon</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus23_tvon_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus23_bus23collect_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus23_tvoff_cb" runat="server" /></td>
              </tr>
            </tbody>
          </table>
        </div>
        
    <div class="second">
      <ul>
      <li><h4>After National Anthem, go into each business listed and deliver telephone ext. card. Hang card on hook labeled "Verizon". Then turn TV on in each business.</h4></li>
      <li><h4>Next, go to each business and collect payment.</h4></li>
      <li><h4>15 minutes before end of day - Go back and collect telephone extension cards and turn TV's off.</h4></li>
      <li><h4>Check each business off the list as you go.</h4></li>
    </ul>
    </div>
    

    
    
    
    <div class="footer3"><button onclick="myFunction()" class="submit">Submit</button>
    
    </div>
    
        
</div> 
<script src="../../Scripts.js"></script>
    </form>
</body>
</html>

