<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Unified_Giving_Director's_Checklist.aspx.vb" Inherits="Enterprise_Village_2._0.Unified_Giving_Director_s_Checklist" %>

<!doctype html>
<html>
<head runat ="server">
<meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">
          <title>Unified Way Resource Dev Checklist</title>


<link href="css/Styles.Checklist.css" rel="stylesheet" type="text/css">
</head>

<body>
    <form id="form1" runat="server">
    <div id="site_wrap">
    <div class="header1">
    
    <img class="EV" alt="Enterprise Village" src="Images/EV2.0_PCSB.png">
    
    </div>
        
    <div class="header2">
        <h2 style="font-size: 22px;">United Way Resource Development Director Checklist</h2> 
        </div>
        
      <div class="header3">
        <img class="business" alt="Business" src="media/Logos/United Way/UnitedWaySuncoast_Logo-LRG.png" >
        </div>
        
     <div class="main_unified">
        <br /><br /><br />
        <table class="tall_table" border="1" >
            <tbody>
              <tr>
                <td class="table_header2">Business</td>
                <td class="table_header2">Container Delivered</td>
                <td class="table_header2">Pledge Sheet Collected</td>
                <td class="table_header2">Check Collected</td>
                <td class="table_header2">Container Collected</td>
              </tr>
              <tr>
                <td class="row_text"><p>Astro Skate</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus1_container_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus1_pledge_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus1_cert_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus1_containercollect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Achieva Credit Union</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus2_container_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus2_pledge_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus2_cert_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus2_containercollect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>BayCare</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus3_container_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus3_pledge_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus3_cert_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus3_containercollect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>BBB</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus4_container_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus4_pledge_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus4_cert_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus4_containercollect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Koozie Group</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus5_container_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus5_pledge_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus5_cert_cb" runat="server" /></td>\
                <td class="checkbox"><asp:CheckBox ID="bus5_containercollect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Buccaneers</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus18_container_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus18_pledge_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus18_cert_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus18_containercollect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>City Hall</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus6_container_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus6_pledge_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus6_cert_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus6_containercollect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>CVS</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus7_container_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus7_pledge_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus7_cert_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus7_containercollect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Ditek</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus9_container_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus9_pledge_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus9_cert_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus9_containercollect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Duke Energy</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus10_container_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus10_pledge_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus10_cert_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus10_containercollect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>HSN</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus_container_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus_pledge_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus_cert_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus_containercollect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Kane's</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus12_container_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus12_pledge_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus12_cert_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus12_containercollect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>McDonald's</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus13_container_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus13_pledge_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus13_cert_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus13_containercollect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Mix 100.7</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus14_container_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus14_pledge_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus14_cert_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus14_containercollect_cb" runat="server" /></td>
              </tr>
                <tr>
                <td class="row_text"><p>Pinellas County Solid Waste</p></td>
                <td class="checkbox"><asp:CheckBox ID="CheckBox1" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="CheckBox2" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="CheckBox3" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="CheckBox4" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>KnowBe4</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus17_container_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus17_pledge_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus17_cert_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus17_containercollect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Rays</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus19_container_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus19_pledge_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus19_cert_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus19_containercollect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Tampa Bay Times</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus20_container_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus20_pledge_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus20_cert_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus20_containercollect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>TD SYNNEX</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus21_container_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus21_pledge_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus21_cert_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus21_containercollect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>United Way</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus23_container_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus23_pledge_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus23_cert_cb" runat="server" Enabled="false" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus23_containercollect_cb" runat="server" /></td>
              </tr>
            </tbody>
          </table>
        </div>
        
    <div class="second">
      <ul>
      <h4><li>Check off as you go to each business for each activity in order.</li></h4>
    </ul>
    </div>
    

    
    
    
    <div class="footer3"><button onclick="myFunction()" class="submit">Submit</button>
    
    </div>
    
        
</div> 
<script src="Scripts.js"></script>
    </form>
</body>
</html>

