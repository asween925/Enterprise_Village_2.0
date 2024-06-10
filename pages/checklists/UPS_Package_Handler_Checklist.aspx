<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="UPS_Package_Handler_Checklist.aspx.vb" Inherits="Enterprise_Village_2._0.UPS_Package_Handler_Checklist" %>

<!doctype html>
<html>
<head runat ="server">
<meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">
          <title>UPS Package Handler Checklist</title>


<link href="~/css/Styles.Checklist.css" rel="stylesheet" type="text/css">
</head>

<body>
    <form autocomplete="off"  id="form1" runat="server">
    <div id="site_wrap">
    <div class="header1">
    
    <img class="EV" alt="Enterprise Village" src="../../Images/EV2.0_PCSB.png">
    
    </div>
        
    <div class="header2">
        <h2>UPS Package Handler Checklist</h2> 
        </div>
        
      <div class="header3">
        <img class="business" alt="Business" src="../../Images/UPSLogo.jpg" >
        </div>
        
     <div class="main_ups">
        <br /><br /><br /><br /><br />
        <table class="tall_table" border="1" >
            <tbody>
              <tr>
                <td class="table_header2">Business</td>
                <td class="table_header2"># of thermostats</td>
                <td class="table_header2">Install thermostats</td>
                <td class="table_header2">Collect red or green bins</td>
                <td class="table_header2">Deliver Thank you cards</td>
                <td class="table_header2">Uninstall thermostats</td>
              </tr>
              <tr>
                <td class="row_text"><p>Astro Skate</p></td>
                <td class="checkbox"><p>1</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus1_installtherm_cb" runat="server" /></td>
                <td class="closed"></td>
                <td class="checkbox"><asp:CheckBox ID="bus1_thankyou_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus1_uninstalltherm_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Achieva Credit Union</p></td>
                <td class="checkbox"><p>2</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus2_installtherm_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus2_collectbin_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus2_thankyou_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus2_uninstalltherm_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>BayCare</p></td>
                <td class="checkbox"><p>1</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus3_installtherm_cb" runat="server" /></td>
                <td class="closed"></td>
                <td class="checkbox"><asp:CheckBox ID="bus3_thankyou_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus3_uninstalltherm_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>BBB</p></td>
                <td class="checkbox"><p>1</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus4_installtherm_cb" runat="server" /></td>
                <td class="closed"></td>
                <td class="checkbox"><asp:CheckBox ID="bus4_thankyou_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus4_uninstalltherm_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Koozie Group</p></td>
                <td class="checkbox"><p>2</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus5_installtherm_cb" runat="server" /></td>
                <td class="closed"></td>
                <td class="checkbox"><asp:CheckBox ID="bus5_thankyou_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus5_uninstalltherm_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Buccaneers</p></td>
                <td class="checkbox"><p>1</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus18_installtherm_cb" runat="server" /></td>
                <td class="closed"></td>
                <td class="checkbox"><asp:CheckBox ID="bus18_thankyou_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus18_uninstalltherm_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>City Hall</p></td>
                <td class="checkbox"><p>3</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus6_installtherm_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus6_collectbin_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus6_thankyou_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus6_uninstalltherm_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>CVS</p></td>
                <td class="checkbox"><p>1</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus7_installtherm_cb" runat="server" /></td>
                <td class="closed"></td>
                <td class="checkbox"><asp:CheckBox ID="bus7_thankyou_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus7_uninstalltherm_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Ditek</p></td>
                <td class="checkbox"><p>1</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus9_installtherm_cb" runat="server" /></td>
                <td class="closed"></td>
                <td class="checkbox"><asp:CheckBox ID="bus9_thankyou_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus9_uninstalltherm_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Duke Energy</p></td>
                <td class="checkbox"><p>1</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus10_installtherm_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus10_collectbin_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus10_thankyou_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus10_uninstalltherm_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>HSN</p></td>
                <td class="checkbox"><p>1</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus11_installtherm_cb" runat="server" /></td>
                <td class="closed"></td>
                <td class="checkbox"><asp:CheckBox ID="bus11_thankyou_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus11_uninstalltherm_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Kane's</p></td>
                <td class="checkbox"><p>1</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus12_installtherm_cb" runat="server" /></td>
                <td class="closed"></td>
                <td class="checkbox"><asp:CheckBox ID="bus12_thankyou_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus12_uninstalltherm_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>McDonald's</p></td>
                <td class="checkbox"><p>2</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus13_installtherm_cb" runat="server" /></td>
                <td class="closed"></td>
                <td class="checkbox"><asp:CheckBox ID="bus13_thankyou_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus13_uninstalltherm_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Mix 100.7</p></td>
                <td class="checkbox"><p>1</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus14_installtherm_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus14_collectbin_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus14_thankyou_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus14_uninstalltherm_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>KnowBe4</p></td>
                <td class="checkbox"><p>1</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus17_installtherm_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus17_collectbin_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus17_thankyou_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus17_uninstalltherm_cb" runat="server" /></td>
              </tr>
                <tr>
                <td class="row_text"><p>PC Solid Waste</p></td>
                <td class="checkbox"><p>1</p></td>
                <td class="checkbox"><asp:CheckBox ID="CheckBox2" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="CheckBox3" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="CheckBox4" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="CheckBox5" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Rays</p></td>
                <td class="checkbox"><p>1</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus19_installtherm_cb" runat="server" /></td>
                <td class="closed"></td>
                <td class="checkbox"><asp:CheckBox ID="bus19_thankyou_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus19_uninstalltherm_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Tampa Bay Times</p></td>
                <td class="checkbox"><p>1</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus20_installtherm_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus20_collectbin_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus20_thankyou_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus20_uninstalltherm_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>TD SYNNEX</p></td>
                <td class="checkbox"><p>1</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus21_installtherm_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus21_collectbin_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus21_thankyou_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus21_uninstalltherm_cb" runat="server" /></td>
              </tr>
              <td class="row_text"><p>UPS</p></td>
              <td class="closed"></td>
              <td class="closed"></td>
              <td class="checkbox"><asp:CheckBox ID="bus22_collectbin_cb" runat="server" /></td>
              <td class="closed"></td>
              <td class="closed"></td>
            </tr>
              <tr>
                <td class="row_text"><p>United Way</p></td>
                <td class="checkbox"><p>1</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus23_installtherm_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="CheckBox1" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus23_thankyou_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus23_uninstalltherm_cb" runat="server" /></td>
              </tr>
            </tbody>
          </table>
          <p></p>
        </div>
        
    <div class="second">
      <ul>
        <li><h4>Check off each business as you complete each activity in order from left to right.</h4></li>
        <h4>*Grayed out areas do not require any action.</h4>
      </ul>

    </div>
    

    
    <div class="footer3"><button onclick="myFunction()" class="submit">Submit</button>
    
    </div>
    
        
</div> 
<script src="../../Scripts.js"></script>
    </form>
</body>
</html>

