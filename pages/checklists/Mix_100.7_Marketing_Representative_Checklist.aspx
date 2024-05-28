<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Mix_100.7_Marketing_Representative_Checklist.aspx.vb" Inherits="Enterprise_Village_2._0.Mix_100_7_Marketing_Representative_Checklist" %>

<!doctype html>
<html>
<head runat ="server">
<meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">
          <title>Mix 100.7</title>


<link href="~/css/Styles.Checklist.css" rel="stylesheet" type="text/css">
</head>

<body>
    <form id="form1" runat="server">
    <div id="site_wrap">
    <div class="header1">
    
    <img class="EV" alt="Enterprise Village" src="../../Images/EV2.0_PCSB.png">
    
    </div>
        
    <div class="header2">
        <h2>Marketing Representative</h2> 
        </div>
        
      <div class="header3">
        <img class="business" alt="Business" src="../../Images/200px-NewMix1007.png">
        </div>
        
     <div class="main_mix">
         <br /><br /><br />
        <table border="1" >
            <tbody>
              <tr>
                <td class="table_header">Business</td>
                <td class="table_header">Collect Ads</td>
                <td class="table_header">Collect Checks</td>
              </tr>
              <tr>
                <td>Astro Skate</td>
                <td class="checkbox"><asp:CheckBox ID="bus1_collectads_cb" runat="server"  /></td>
                <td class="checkbox"><asp:CheckBox ID="bus1_collectadcheck_cb" runat="server"  /></td>
              </tr>
              <tr>
                <td>Achieva Credit Union</td>
                <td class="checkbox"><asp:CheckBox ID="bus2_collectads_cb" runat="server"  /></td>
                <td class="checkbox"><asp:CheckBox ID="bus2_collectadcheck_cb" runat="server"  /></td>
              </tr>
              <tr>
                <td>BayCare</td>
                <td class="checkbox"><asp:CheckBox ID="bus3_collectads_cb" runat="server"  /></td>
                <td class="checkbox"><asp:CheckBox ID="bus3_collectadcheck_cb" runat="server"  /></td>
              </tr>
              <tr>
                <td>BBB</td>
                <td class="checkbox"><asp:CheckBox ID="bus4_collectads_cb" runat="server"  /></td>
                <td class="checkbox"><asp:CheckBox ID="bus4_collectadcheck_cb" runat="server"  /></td>
              </tr>
              <tr>
                <td>Koozie Group</td>
                <td class="checkbox"><asp:CheckBox ID="bus5_collectads_cb" runat="server"  /></td>
                <td class="checkbox"><asp:CheckBox ID="bus5_collectadcheck_cb" runat="server"  /></td>
              </tr>
              <tr>
                <td>Buccaneers</td>
                <td class="checkbox"><asp:CheckBox ID="bus18_collectads_cb" runat="server"  /></td>
                <td class="checkbox"><asp:CheckBox ID="bus18_collectadcheck_cb" runat="server"  /></td>
              </tr>
              <tr>
                <td>City Hall</td>
                <td class="checkbox"><asp:CheckBox ID="bus6_collectads_cb" runat="server"  /></td>
                <td class="checkbox"><asp:CheckBox ID="bus6_collectadcheck_cb" runat="server"  /></td>
              </tr>
              <tr>
                <td>CVS</td>
                <td class="checkbox"><asp:CheckBox ID="bus7_collectads_cb" runat="server"  /></td>
                <td class="checkbox"><asp:CheckBox ID="bus7_collectadcheck_cb" runat="server"  /></td>
              </tr>
              <tr>
                <td>Ditek</td>
                <td class="checkbox"><asp:CheckBox ID="bus9_collectads_cb" runat="server"  /></td>
                <td class="checkbox"><asp:CheckBox ID="bus9_collectadcheck_cb" runat="server"  /></td>
              </tr>
              <tr>
                <td>Duke Energy</td>
                <td class="checkbox"><asp:CheckBox ID="bus10_collectads_cb" runat="server"  /></td>
                <td class="checkbox"><asp:CheckBox ID="bus10_collectadcheck_cb" runat="server"  /></td>
              </tr>
              <tr>
                <td>HSN</td>
                <td class="checkbox"><asp:CheckBox ID="bus11_collectads_cb" runat="server"  /></td>
                <td class="checkbox"><asp:CheckBox ID="bus11_collectadcheck_cb" runat="server"  /></td>
              </tr>
              <tr>
                <td>Kane's</td>
                <td class="checkbox"><asp:CheckBox ID="bus12_collectads_cb" runat="server"  /></td>
                <td class="checkbox"><asp:CheckBox ID="bus12_collectadcheck_cb" runat="server"  /></td>
              </tr>
              <tr>
                <td>McDonald's</td>
                <td class="checkbox"><asp:CheckBox ID="bus13_collectads_cb" runat="server"  /></td>
                <td class="checkbox"><asp:CheckBox ID="bus13_collectadcheck_cb" runat="server"  /></td>
              </tr>
              <tr>
                <td>Mix 100.7</td>
                <td class="checkbox"><asp:CheckBox ID="bus14_collectads_cb" runat="server"  /></td>
                <td class="closed"></td>
              </tr>
              <tr>
                <td>KnowBe4</td>
                <td class="checkbox"><asp:CheckBox ID="bus17_collectads_cb" runat="server"  /></td>
                <td class="checkbox"><asp:CheckBox ID="bus17_collectadcheck_cb" runat="server"  /></td>
              </tr>
              <tr>
                <td>Rays</td>
                <td class="checkbox"><asp:CheckBox ID="bus19_collectads_cb" runat="server"  /></td>
                <td class="checkbox"><asp:CheckBox ID="bus19_collectadcheck_cb" runat="server"  /></td>
              </tr>
              <tr>
                <td>Tampa Bay Times</td>
                <td class="checkbox"><asp:CheckBox ID="bus20_collectads_cb" runat="server"  /></td>
                <td class="checkbox"><asp:CheckBox ID="bus20_collectadcheck_cb" runat="server"  /></td>
              </tr>
              <tr>
                <td>TD SYNNEX</td>
                <td class="checkbox"><asp:CheckBox ID="bus21_collectads_cb" runat="server"  /></td>
                <td class="checkbox"><asp:CheckBox ID="bus21_collectadcheck_cb" runat="server"  /></td>
              </tr>
              <tr>
                <td>PC Solid Waste</td>
                <td class="checkbox"><asp:CheckBox ID="bus22_collectads_cb" runat="server"  /></td>
                <td class="checkbox"><asp:CheckBox ID="bus22_collectadcheck_cb" runat="server"  /></td>
              </tr>
              <tr>
                <td>United Way</td>
                <td class="checkbox"><asp:CheckBox ID="bus23_collectads_cb" runat="server"  /></td>
                <td class="checkbox"><asp:CheckBox ID="bus23_collectadcheck_cb" runat="server"  /></td>
              </tr>
            </tbody>
          </table>
        </div>
        
    <div class="second">
      <ul>
        <li><h4>Collect 5 at a time.</h4></li>
        <li><h4>Give them to the DJ.</h4></li>
        <li><h4>Continue collecting 5 at a time.</h4></li>
        <li><h4>Check them off the list.</h4></li>
        <li><h4>Collect all $4.00 checks</h4></li>
        <li><h4>Check them off the list.</h4></li>
        <li><h4>Give them to your manager.</h4></li>
      </ul>
    
    </div>
    

    
    
    
    <div class="footer3"><button onclick="myFunction()" class="submit">Submit</button>
    
    </div>
    
        
</div> 
<script src="../../Scripts.js"></script>
    </form>
</body>
</html>