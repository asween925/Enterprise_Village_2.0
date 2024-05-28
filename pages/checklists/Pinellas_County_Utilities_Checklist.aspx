<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Pinellas_County_Utilities_Checklist.aspx.vb" Inherits="Enterprise_Village_2._0.Pinellas_County_Utilities_Checklist" %>

<!doctype html>
<html>
<head runat ="server">
<meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">
          <title>Pinellas County Solid Waste Checklist</title>


<link href="~/css/Styles.Checklist.css" rel="stylesheet" type="text/css">
</head>

<body>
    <form id="form1" runat="server">
    <div id="site_wrap">
    <div class="header1">
    
    <img class="EV" alt="Enterprise Village" src="../../Images/EV2.0_PCSB.png">
    
    </div>
        
    <div class="header2">
        <h2>Manager's Checklist</h2> 
        </div>
        
      <div class="header3">
        <img class="business" alt="Business" src="../../Images/Utilities_color-rgb.png" >
        </div>
        
     <div class="main_pc">
         <br /><br /><br /><br />
        <table class="tall_table" border="1" >
            <tbody>
              <tr>
                <td class="table_header2">Business</td>
                <td class="table_header2">Collected Paper AM</td>
                <td class="table_header2">Free Gift Delivered</td>
                <td class="table_header2">Collected Paper PM</td>
              </tr>
              <tr>
                <td class="row_text"><p>Astro Skate</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus1_wmr_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus1_wbc_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus1_wbd_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Achieva Credit Union</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus2_wmr_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus2_wbc_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus2_wbd_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>BayCare</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus3_wmr_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus3_wbc_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus3_wbd_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>BBB</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus4_wmr_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus4_wbc_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus4_wbd_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Koozie Group</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus5_wmr_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus5_wbc_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus5_wbd_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Buccaneers</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus18_wmr_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus18_wbc_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus18_wbd_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>City Hall</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus6_wmr_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus6_wbc_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus6_wbd_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>CVS</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus7_wmr_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus7_wbc_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus7_wbd_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Ditek</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus9_wmr_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus9_wbc_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus9_wbd_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Duke Energy</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus10_wmr_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus10_wbc_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus10_wbd_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>HSN</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus11_wmr_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus11_wbc_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus11_wbd_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Kane's</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus12_wmr_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus12_wbc_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus12_wbd_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>McDonald's</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus13_wmr_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus13_wbc_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus13_wbd_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Mix 100.7</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus14_wmr_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus14_wbc_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus14_wbd_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>KnowBe4</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus17_wmr_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus17_wbc_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus17_wbd_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Rays</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus19_wmr_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus19_wbc_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus19_wbd_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Tampa Bay Times</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus20_wmr_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus20_wbc_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus20_wbd_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>TD SYNNEX</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus21_wmr_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus21_wbc_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus21_wbd_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>United Way</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus23_wmr_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus23_wbc_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus23_wbd_cb" runat="server" /></td>
              </tr>
            </tbody>
          </table>
        </div>
        
    <div class="second">
      <ul>
      <li><h4>Collect the AM recycling papers. Locate the Blue Paper Trash Can in each business and empty it into your large Blue Bin.</h4></li>
      <li><h4>Go to each business and deliver a "free gift" to each manager to thank him/her for participating in the recycling program.</h4></li>
      <li><h4>Collect the PM recycling paper.</h4></li>
    </ul>
    </div>

    
    
    
    <div class="footer3"><button onclick="myFunction()" class="submit">Submit</button>
    
    </div>
    
        
</div> 
<script src="../../Scripts.js"></script>
    </form>
</body>
</html>
