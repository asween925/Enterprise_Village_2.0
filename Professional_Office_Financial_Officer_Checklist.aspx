<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Professional_Office_Financial_Officer_Checklist.aspx.vb" Inherits="Enterprise_Village_2._0.Professional_Office_Financial_Officer_Checklist" %>

<!doctype html>
<html>
<head runat ="server">
<meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">
          <title>Payment Checklist</title>


<link href="css/Styles.Checklist.css" rel="stylesheet" type="text/css">
</head>

<body>
    <form id="form1" runat="server">
    <div id="site_wrap">
    <div class="header1">
    
    <img class="EV" alt="Enterprise Village" src="Images/EV2.0_PCSB.png">
    
    </div>
        
    <div class="header2">
        <h2>Financial Officer Payment Checklist</h2> 
        </div>
        
      <div class="header3">
        <img class="business" alt="Business" src="Images/professionaloffice.jpg" width="390">
        </div>
        
     <div class="main_professional">
         <br /><br />
        <table border="1" >
            <tbody>
              <tr>
                <td class="table_header">Business</td>
                <td class="table_header">Payment Collected</td>
              </tr>
              <tr>
                <td>Astro Skate</td>
                <td class="checkbox"><asp:CheckBox ID="bus1_procollect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td>BayCare</td>
                <td class="checkbox"><asp:CheckBox ID="bus3_procollect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td>Bank Of America</td>
                <td class="checkbox"><asp:CheckBox ID="bus2_procollect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td>BBB</td>
                <td class="checkbox"><asp:CheckBox ID="bus4_procollect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td>Koozie Group</td>
                <td class="checkbox"><asp:CheckBox ID="bus5_procollect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td>Buccaneers</td>
                <td class="checkbox"><asp:CheckBox ID="bus18_procollect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td>City Hall</td>
                <td class="checkbox"><asp:CheckBox ID="bus6_procollect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td>CVS</td>
                <td class="checkbox"><asp:CheckBox ID="bus7_procollect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td>Ditek</td>
                <td class="checkbox"><asp:CheckBox ID="bus9_procollect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td>Duke Energy</td>
                <td class="checkbox"><asp:CheckBox ID="bus10_procollect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td>HSN</td>
                <td class="checkbox"><asp:CheckBox ID="bus11_procollect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td>Kane's</td>
                <td class="checkbox"><asp:CheckBox ID="bus12_procollect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td>McDonald's</td>
                <td class="checkbox"><asp:CheckBox ID="bus13_procollect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td>Mix 100.7</td>
                <td class="checkbox"><asp:CheckBox ID="bus14_procollect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td>Rays</td>
                <td class="checkbox"><asp:CheckBox ID="bus19_procollect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td>Tampa Bay Times</td>
                <td class="checkbox"><asp:CheckBox ID="bus20_procollect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td>Tech Data</td>
                <td class="checkbox"><asp:CheckBox ID="bus21_procollect_cb" runat="server" /></td>
              </tr>
              <tr>
                <td>Verizon</td>
                <td class="checkbox"><asp:CheckBox ID="bus23_procollect_cb" runat="server" /></td>
              </tr>
            </tbody>
          </table>
        </div>
        
    <div class="second">
      <ul>
      <h4><li>Take your iPad and go to each business to collect a check for Professional Office.</li></h4>
      <h4><li>As you collect the checks, tap on the checkbox of the business you just visited.</li></h4>
      <h4><li>Place checks you collect in the container on the Financial Officer Station.</li></h4>
      <h4><li>After completing, return your iPad to an Enterprise Village Staff Member (Red Shirt).</li></h4>
    </ul>
    </div>
    

    
    
    
    <div class="footer3"><button onclick="myFunction()" class="submit">Submit</button>
    
    </div>
    
        
</div> 
<script src="Scripts.js"></script>
    </form>
</body>
</html>
