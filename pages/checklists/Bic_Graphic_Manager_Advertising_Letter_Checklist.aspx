<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Bic_Graphic_Manager_Advertising_Letter_Checklist.aspx.vb" Inherits="Enterprise_Village_2._0.Bic_Graphic_Manager_Advertising_Letter_Checklist" %>

<!doctype html>
<html>
<head runat ="server">
<meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">
          <title>Koozie Group Manager's Advertising Letter Checklist</title>


<link href="~/css/Styles.Checklist.css" rel="stylesheet" type="text/css">
</head>

<body>
    <form autocomplete="off"  id="form1" runat="server">
    <div id="site_wrap">
    <div class="header1">
    
    <img class="EV" alt="Enterprise Village" src="../../../../Images/EV2.0_PCSB.png">
    
    </div>
        
    <div class="header2">
        <h2>Manager's Advertising Letter Checklist</h2> 
        </div>
        
      <div class="header3">
        <img class="business" alt="Business" src="../../Images/koozie.png" >
        </div>
        
     <div class="main_koozie">
         <br /><br /><br /><br />
        <table class="tall_table" border="1" >
            <tbody>
              <tr>
                <td class="table_header2">Business Name</td>
                <td class="table_header2">Advertising Letter Completed</td>
              </tr>
              <tr>
                <td class="row_text"><p>Astro Skate</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus1_wbd_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Achieva Credit Union</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus2_wbd_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>BayCare</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus3_wbd_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>BBB</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus4_wbd_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Koozie Group</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus5_wbd_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Tampa Bay Buccaneers</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus18_wbd_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>City Hall</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus6_wbd_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>CVS</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus7_wbd_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Ditek</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus9_wbd_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Duke Energy</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus10_wbd_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>PCS Newsroom</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus11_wbd_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Kane's</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus12_wbd_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>McDonald's</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus13_wbd_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Mix 100.7</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus14_wbd_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>KnowBe4</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus17_wbd_cb" runat="server" /></td>
              </tr>
                <tr>
                <td class="row_text"><p>PCSW</p></td>
                <td class="checkbox"><asp:CheckBox ID="CheckBox1" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Tampa Bay Rays</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus19_wbd_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Power Design</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus20_wbd_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>TD SYNNEX</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus21_wbd_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>United Way</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus23_wbd_cb" runat="server" /></td>
              </tr>
            </tbody>
          </table>
        </div>
        
    <div class="second">
      <ul>
      <li><h4>Complete the advertising letter for each business and then check it off in the box.</h4></li>
    </ul>
    </div>

    
    
    
    <div class="footer3"><button onclick="myFunction()" class="submit">Submit</button>
    
    </div>
    
        
</div> 
<script src="../../Scripts.js"></script>
    </form>
</body>
</html>
