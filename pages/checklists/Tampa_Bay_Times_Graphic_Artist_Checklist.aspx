<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Tampa_Bay_Times_Graphic_Artist_Checklist.aspx.vb" Inherits="Enterprise_Village_2._0.Tampa_Bay_Times_Graphic_Artist_Checklist" %>

<!doctype html>
<html>
<head runat ="server">
<meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">
          <title>Tampa Bay Times Graphic Artist Checklist</title>


<link href="~/css/Styles.Checklist.css" rel="stylesheet" type="text/css">
</head>

<body>
    <form autocomplete="off"  id="form1" runat="server">
    <div id="site_wrap">
    <div class="header1">
    
    <img class="EV" alt="Enterprise Village" src="../../Images/EV2.0_PCSB.png">
    
    </div>
        
    <div class="header2">
        <h2>Graphic Artist</h2> 
        </div>
        
      <div class="header3">
        <img class="business" alt="Business" src="../../Images/times_logo_horizontal_black.jpg" >
        </div>
        
     <div class="main_tbt">
         <br /><br /><br />
        <table border="1" >
            <tbody>
              <tr>
                <td class="table_header">Business</td>
                <td class="table_header">Ad Placed in Paper?</td>
              </tr>
              <tr>
                <td class="row_text2">Astro Skate</td>
                <td class="checkbox"><asp:CheckBox ID="bus1_adpaper_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text2">Achieva Credit Union</td>
                <td class="checkbox"><asp:CheckBox ID="bus2_adpaper_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text2">BayCare</td>
                <td class="checkbox"><asp:CheckBox ID="bus3_adpaper_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text2">BBB</td>
                <td class="checkbox"><asp:CheckBox ID="bus4_adpaper_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text2">Koozie Group</td>
                <td class="checkbox"><asp:CheckBox ID="bus5_adpaper_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text2">Buccaneers</td>
                <td class="checkbox"><asp:CheckBox ID="bus18_adpaper_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text2">City Hall (Mayor, Attorney,<br /> PC Utilities, Dali Art, & UPS)</td>
                <td class="checkbox"><asp:CheckBox ID="bus6_adpaper_cb" runat="server" /></td>
              </tr>
              <%--<tr>
                <td class="row_text2">City Hall (Dali)</td>
                <td class="checkbox"><asp:CheckBox ID="bus8_adpaper_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text2">City Hall (PC Utilities, Water Department)</td>
                <td class="checkbox"><asp:CheckBox ID="bus16_adpaper_cb" runat="server" /></td>
              </tr>--%>
              <tr>
                <td class="row_text2">CVS</td>
                <td class="checkbox"><asp:CheckBox ID="bus7_adpaper_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text2">Ditek</td>
                <td class="checkbox"><asp:CheckBox ID="bus9_adpaper_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text2">Duke Energy</td>
                <td class="checkbox"><asp:CheckBox ID="bus10_adpaper_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text2">HSN</td>
                <td class="checkbox"><asp:CheckBox ID="bus11_adpaper_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text2">Kane's</td>
                <td class="checkbox"><asp:CheckBox ID="bus12_adpaper_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text2">McDonald's</td>
                <td class="checkbox"><asp:CheckBox ID="bus13_adpaper_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text2">Mix 100.7</td>
                <td class="checkbox"><asp:CheckBox ID="bus14_adpaper_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text2">KnowBe4</td>
                <td class="checkbox"><asp:CheckBox ID="bus17_adpaper_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text2">Rays</td>
                <td class="checkbox"><asp:CheckBox ID="bus19_adpaper_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text2">Tampa Bay Times</td>
                <td class="checkbox"><asp:CheckBox ID="bus20_adpaper_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text2">Pinellas County Solid Waste</td>
                <td class="checkbox"><asp:CheckBox ID="bus22_adpaper_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text2">TD SYNNEX</td>
                <td class="checkbox"><asp:CheckBox ID="bus21_adpaper_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text2">United Way</td>
                <td class="checkbox"><asp:CheckBox ID="bus23_adpaper_cb" runat="server" /></td>
              </tr>
            </tbody>
          </table>
        </div>
        
    <div class="second">
        <ul>
        <li><h4>Check off each business as you place their ad in the newspaper layout.</h4></li>
        <li><h4>Make sure you only have ONE ad from each business listed.</h4></li>
        </ul>
    </div>
    

    
    
    
    <div class="footer3"><button onclick="myFunction()" class="submit">Submit</button>
    
    </div>
    
        
</div> 
<script src="../../Scripts.js"></script>
    </form>
</body>
</html>
