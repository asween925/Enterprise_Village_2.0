<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Salvador_Dali_Museum_Art_Curator_Checklist.aspx.vb" Inherits="Enterprise_Village_2._0.Salvador_Dali_Museum_Art_Curator_Checklist" %>

<!doctype html>
<html>
<head runat ="server">
<meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">
          <title>Salvador Dali Museum Art Curator Checklist</title>


<link href="css/Styles.Checklist.css" rel="stylesheet" type="text/css">
</head>

<body>
    <form id="form1" runat="server">
    <div id="site_wrap">
    <div class="header1">
    
    <img class="EV" alt="Enterprise Village" src="Images/EV2.0_PCSB.png">
    
    </div>
        
    <div class="header2">
        <h2>Art Curator</h2> 
        </div>
        
      <div class="header3">
        <img class="business" alt="Business" src="Images/Dali Museum Red Logo .jpg" >
        </div>
        
     <div class="main_dali">
        <br /><br /><br />
        <table border="1" >
            <tbody>
              <tr>
                <td class="table_header">Business</td>
                <td class="table_header">$2 Collected</td>
              </tr>
              <tr>
                <td>Astro Skate</td>
                <td class="checkbox"><asp:CheckBox ID="bus1_bus8collect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td>Achieva Credit Union</td>
                <td class="checkbox"><asp:CheckBox ID="bus2_bus8collect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td>BayCare</td>
                <td class="checkbox"><asp:CheckBox ID="bus3_bus8collect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td>BBB</td>
                <td class="checkbox"><asp:CheckBox ID="bus4_bus8collect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td>Koozie Group</td>
                <td class="checkbox"><asp:CheckBox ID="bus5_bus8collect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td>Buccaneers</td>
                <td class="checkbox"><asp:CheckBox ID="bus18_bus8collect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td>City Hall</td>
                <td class="checkbox"><asp:CheckBox ID="bus6_bus8collect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td>CVS</td>
                <td class="checkbox"><asp:CheckBox ID="bus7_bus8collect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td>Ditek</td>
                <td class="checkbox"><asp:CheckBox ID="bus9_bus8collect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td>Duke Energy</td>
                <td class="checkbox"><asp:CheckBox ID="bus10_bus8collect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td>HSN</td>
                <td class="checkbox"><asp:CheckBox ID="bus11_bus8collect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td>Kane's</td>
                <td class="checkbox"><asp:CheckBox ID="bus12_bus8collect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td>McDonald's</td>
                <td class="checkbox"><asp:CheckBox ID="bus13_bus8collect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td>Mix 100.7</td>
                <td class="checkbox"><asp:CheckBox ID="bus14_bus8collect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td>Professional Offices</td>
                <td class="checkbox"><asp:CheckBox ID="bus17_bus8collect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td>Rays</td>
                <td class="checkbox"><asp:CheckBox ID="bus19_bus8collect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td>Tampa Bay Times</td>
                <td class="checkbox"><asp:CheckBox ID="bus20_bus8collect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td>Tech Data</td>
                <td class="checkbox"><asp:CheckBox ID="bus21_bus8collect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td>Verizon</td>
                <td class="checkbox"><asp:CheckBox ID="bus23_bus8collect_cb" runat="server" /></td>
              </tr>
            </tbody>
          </table>
        </div>
        
    <div class="second">
      <ul>
        <li><h4>Go to each business on the checklist and collect the $2.00 check.</h4></li>
        <li><h4>Check off each business as you collect the check</h4></li>
    </ul>
  </ul>
    </div>
    

    
    
    
    <div class="footer3"><button onclick="myFunction()" class="submit">Submit</button>
    
    </div>
    
        
</div> 
<script src="Scripts.js"></script>
    </form>
</body>
</html>
