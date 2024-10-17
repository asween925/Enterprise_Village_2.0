<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Tampa_Bay_Times_Marketing_Representative_Checklist.aspx.vb" Inherits="Enterprise_Village_2._0.Tampa_Bay_Times_Marketing_Representative_Checklist" %>

<!doctype html>
<html>
<head runat ="server">
<meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">
          <title>PCS TV Reporter / Editor Checklist</title>


<link href="~/css/Styles.Checklist.css" rel="stylesheet" type="text/css">
</head>

<body>
    <form autocomplete="off"  id="form1" runat="server">
    <div id="site_wrap">
    <div class="header1">
    
    <img class="EV" alt="Enterprise Village" src="../../Images/EV2.0_PCSB.png">
    
    </div>
        
    <div class="header2">
        <h2>Reporter / Editor</h2> 
        </div>
        
      <div class="header3">
        <img class="business" alt="Business" src="../../Images/PCSB_icon_round.png" />
        </div>
        
     <div class="main_tbt">
         <br /><br /><br /><br />
        <table class="tall_table" border="1" >
            <tbody>
              <tr>
                <td class="table_header3">Business</td>
                <td class="table_header3">Collected Ad</td>
              </tr>
              <tr>
                <td class="row_text">Astro Skate</td>
                <td class="checkbox"><asp:CheckBox ID="bus1_bus20collectad_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text">Achieva Credit Union</td>
                <td class="checkbox"><asp:CheckBox ID="bus2_bus20collectad_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text">BayCare</td>
                <td class="checkbox"><asp:CheckBox ID="bus3_bus20collectad_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text">BBB</td>
                <td class="checkbox"><asp:CheckBox ID="bus4_bus20collectad_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text">Koozie Group</td>
                <td class="checkbox"><asp:CheckBox ID="bus5_bus20collectad_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text">Buccaneers</td>
                <td class="checkbox"><asp:CheckBox ID="bus18_bus20collectad_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text">City Hall (including UPS & Dali Art)</td>
                <td class="checkbox"><asp:CheckBox ID="bus6_bus20collectad_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text">CVS</td>
                <td class="checkbox"><asp:CheckBox ID="bus7_bus20collectad_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text">Ditek</td>
                <td class="checkbox"><asp:CheckBox ID="bus9_bus20collectad_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text">Duke Energy</td>
                <td class="checkbox"><asp:CheckBox ID="bus10_bus20collectad_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text">PCS TV</td>
                <td class="checkbox"><asp:CheckBox ID="bus11_bus20collectad_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text">Kane's</td>
                <td class="checkbox"><asp:CheckBox ID="bus12_bus20collectad_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text">McDonald's</td>
                <td class="checkbox"><asp:CheckBox ID="bus13_bus20collectad_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text">Mix 100.7</td>
                <td class="checkbox"><asp:CheckBox ID="bus14_bus20collectad_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text">KnowBe4</td>
                <td class="checkbox"><asp:CheckBox ID="bus17_bus20collectad_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text">Rays</td>
                <td class="checkbox"><asp:CheckBox ID="bus19_bus20collectad_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text">Power Design</td>
                <td class="checkbox"><asp:CheckBox ID="bus20_bus20collectad_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text2">Pinellas County Solid Waste</td>
                <td class="checkbox"><asp:CheckBox ID="bus22_adpaper_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text">TD SYNNEX</td>
                <td class="checkbox"><asp:CheckBox ID="bus21_bus20collectad_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text">United Way</td>
                <td class="checkbox"><asp:CheckBox ID="bus23_bus20collectad_cb" runat="server" /></td>
              </tr>
            </tbody>
          </table>
        </div>
        
    <div class="second">
        <ul>
        <li><h4>Place them in the tray on your desk.</h4></li>
        <li><h4>Check them off as you collect them.</h4></li>
        <%--<li><h4>After lunch, return to each business and collect the $4.00 check from each manager or financial officer.</h4></li>
        <li><h4>Give the checks to your Managing Editor.</h4></li>--%>
        </ul>
    </div>
    

    
    
    
    <div class="footer3"><button onclick="myFunction()" class="submit">Submit</button>
    
    </div>
    
        
</div> 
<script src="../../Scripts.js"></script>
    </form>
</body>
</html>
