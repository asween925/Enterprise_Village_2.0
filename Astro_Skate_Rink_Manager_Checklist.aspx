<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Astro_Skate_Rink_Manager_Checklist.aspx.vb" Inherits="Enterprise_Village_2._0.Astro_Skate_Rink_Manager_Checklist" %>

<!doctype html>
<html>
<head runat ="server">
<meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">
          <title>Rink Manager Checklist</title>


<link href="css/Styles.Checklist.css" rel="stylesheet" type="text/css">
</head>

<body>
    <form id="form1" runat="server">
    <div id="site_wrap">
    <div class="header1">
    
    <img class="EV" alt="Enterprise Village" src="Images/EV2.0_PCSB.png">
    
    </div>
        
    <div class="header2">
        <h2>Rink Manager</h2> 
        </div>
        
      <div class="header3">
        <img class="business" alt="Business" src="Images/AstroSkate.jpg">
        </div>
        
     <div class="main_astro">
         <h4></h4>
        <table border="1" >
            <tbody>
              <tr>
                <td class="table_header">Business</td>
                <td class="table_header">Collect $3 Check</td>
              </tr>
              <tr>
                <td>Achieva Credit Union</td>
                <td class="checkbox"><asp:CheckBox ID="bus2_collectbus1__cb" runat="server" /></td>
              </tr>
              <tr>
                <td>BayCare</td>
                <td class="checkbox"><asp:CheckBox ID="bus3_collectbus1__cb" runat="server" /></td>
              </tr>
              <tr>
                <td>BBB</td>
                <td class="checkbox"><asp:CheckBox ID="bus4_collectbus1__cb" runat="server" /></td>
              </tr>
              <tr>
                <td>Koozie Group</td>
                <td class="checkbox"><asp:CheckBox ID="bus5_collectbus1__cb" runat="server" /></td>
              </tr>
              <tr>
                <td>Tampa Bay Bucs</td>
                <td class="checkbox"><asp:CheckBox ID="bus18_collectbus1__cb" runat="server" /></td>
              </tr>
              <tr>
                <td>City Hall</td>
                <td class="checkbox"><asp:CheckBox ID="bus6_collectbus1__cb" runat="server" /></td>
              </tr>
              <tr>
                <td>CVS</td>
                <td class="checkbox"><asp:CheckBox ID="bus7_collectbus1__cb" runat="server" /></td>
              </tr>
              <tr>
                <td>Ditek</td>
                <td class="checkbox"><asp:CheckBox ID="bus9_collectbus1__cb" runat="server" /></td>
              </tr>
              <tr>
                <td>Duke Energy</td>
                <td class="checkbox"><asp:CheckBox ID="bus10_collectbus1__cb" runat="server" /></td>
              </tr>
              <tr>
                <td>HSN</td>
                <td class="checkbox"><asp:CheckBox ID="bus11_collectbus1__cb" runat="server" /></td>
              </tr>
              <tr>
                <td>Kane's</td>
                <td class="checkbox"><asp:CheckBox ID="bus12_collectbus1__cb" runat="server" /></td>
              </tr>
              <tr>
                <td>McDonald's</td>
                <td class="checkbox"><asp:CheckBox ID="bus13_collectbus1__cb" runat="server" /></td>
              </tr>
              <tr>
                <td>Mix 100.7</td>
                <td class="checkbox"><asp:CheckBox ID="bus14_collectbus1__cb" runat="server" /></td>
              </tr>
              <tr>
                <td>KnowBe4</td>
                <td class="checkbox"><asp:CheckBox ID="bus17_collectbus1__cb" runat="server" /></td>
              </tr>
               <tr>
                <td>PCSW</td>
                <td class="checkbox"><asp:CheckBox ID="bus24_collectbus1__cb" runat="server" /></td>
              </tr>
              <tr>
                <td>Rays</td>
                <td class="checkbox"><asp:CheckBox ID="bus19_collectbus1__cb" runat="server" /></td>
              </tr>
              <tr>
                <td>Tampa Bay Times</td>
                <td class="checkbox"><asp:CheckBox ID="bus20_collectbus1__cb" runat="server" /></td>
              </tr>
              <tr>
                <td>TD SYNNEX</td>
                <td class="checkbox"><asp:CheckBox ID="bus21_collectbus1__cb" runat="server" /></td>
              </tr>
              <tr>
                <td>United Way</td>
                <td class="checkbox"><asp:CheckBox ID="bus23_collectbus1__cb" runat="server" /></td>
              </tr>
            </tbody>
          </table>
        </div>

    <div class="second">
        <ul>
        <li><h4>Go to each business and collect the $3.00 checks.</h4></li>
        <li><h4>Check off each business as you collect the checks.</h4></li>
        <li><h4>When you are finished, please return your device to an EV Staff member.</h4></li>
      </ul>

    </div>
    

    

    
    
    
    <div class="footer3"><button onclick="myFunction()" class="submit">Submit</button>
    
    </div>
    
        
</div> 
<script src="Scripts.js"></script>
        </form>
</body>
</html>


