<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Duke_Electric_Bill_Checklist.aspx.vb" Inherits="Enterprise_Village_2._0.Duke_Electric_Bill_Checklist" %>

<!DOCTYPE html>

<html>
<head runat ="server">
<meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">
          <title>Duke Energy Electric Bill Checklist</title>



    <link href="~/css/Styles.Checklist.css" rel="stylesheet" type="text/css" />



</head>

<body>
    <form id="form1" runat="server">
    <div id="site_wrap">
    <div class="header1">
    
    <img class="EV" alt="Enterprise Village" src="../../Images/EV2.0_PCSB.png">
    
    </div>
        
    <div class="header2">
        <h2>Electric Bill</h2> 
        </div>
        
      <div class="header3">
        <img class="business" alt="Business" src="../../Images/duke.jpg" >
        </div>
        
     <div class="main_duke">
         <br /><br /><br />
        <table border="1" >
            <tbody>
              <tr>
                <td class="table_header2">Business</td>
                <td class="table_header2">Entered Meter Reading</td>
                <td class="table_header2">Total Due</td>
                <td class="table_header2">Print Electric Bill</td>
              </tr>
              <tr>
                <td><p>Astro Skate</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus1_mr_cb" runat="server" /></td>
                <td class="text_field"><asp:TextBox ID="bus1_totaldue_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus1_printbill_cb" runat="server"  /></td>
                
              </tr>
              <tr>
                <td><p>Achieva Credit Union</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus2_mr_cb" runat="server" /></td>
                <td class="text_field"><asp:TextBox ID="bus2_totaldue_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus2_printbill_cb" runat="server"  /></td>
              </tr>
              <tr>
                <td><p>BayCare</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus3_mr_cb" runat="server" /></td>
                <td class="text_field"><asp:TextBox ID="bus3_totaldue_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus3_printbill_cb" runat="server"  /></td>
              </tr>
              <tr>
                <td><p>BBB</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus4_mr_cb" runat="server" /></td>
                <td class="text_field"><asp:TextBox ID="bus4_totaldue_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus4_printbill_cb" runat="server"  /></td>
              </tr>
              <tr>
                <td><p>Koozie Group</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus5_mr_cb" runat="server" /></td>
                <td class="text_field"><asp:TextBox ID="bus5_totaldue_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus5_printbill_cb" runat="server"  /></td>
              </tr>
              <tr>
                <td><p>Buccaneers</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus18_mr_cb" runat="server" /></td>
                <td class="text_field"><asp:TextBox ID="bus18_totaldue_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus18_printbill_cb" runat="server"  /></td>
              </tr>
              <tr>
                <td><p>City Hall</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus6_mr_cb" runat="server" /></td>
                <td class="text_field"><asp:TextBox ID="bus6_totaldue_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus6_printbill_cb" runat="server"  /></td>
              </tr>
              <tr>
                <td><p>CVS</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus7_mr_cb" runat="server" /></td>
                <td class="text_field"><asp:TextBox ID="bus7_totaldue_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus7_printbill_cb" runat="server"  /></td>
              </tr>
              <tr>
                <td><p>Ditek</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus9_mr_cb" runat="server" /></td>
                <td class="text_field"><asp:TextBox ID="bus9_totaldue_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus9_printbill_cb" runat="server"  /></td>
              </tr>
              <tr>
                <td><p>HSN</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus11_mr_cb" runat="server" /></td>
                <td class="text_field"><asp:TextBox ID="bus11_totaldue_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus11_printbill_cb" runat="server"  /></td>
              </tr>
              <tr>
                <td><p>Kane's</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus12_mr_cb" runat="server" /></td>
                <td class="text_field"><asp:TextBox ID="bus12_totaldue_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus12_printbill_cb" runat="server"  /></td>
              </tr>
              <tr>
                <td><p>McDonald's</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus13_mr_cb" runat="server" /></td>
                <td class="text_field"><asp:TextBox ID="bus13_totaldue_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus13_printbill_cb" runat="server"  /></td>
              </tr>
              <tr>
                <td><p>Mix 100.7</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus14_mr_cb" runat="server" /></td>
                <td class="text_field"><asp:TextBox ID="bus14_totaldue_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus14_printbill_cb" runat="server"  /></td>
              </tr>
              <tr>
                <td><p>Professional Offices</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus17_mr_cb" runat="server" /></td>
                <td class="text_field"><asp:TextBox ID="bus17_totaldue_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus17_printbill_cb" runat="server"  /></td>
              </tr>
              <tr>
                <td><p>Rays</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus19_mr_cb" runat="server" /></td>
                <td class="text_field"><asp:TextBox ID="bus19_totaldue_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus19_printbill_cb" runat="server"  /></td>
              </tr>
              <tr>
                <td><p>Tampa Bay Times</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus20_mr_cb" runat="server" /></td>
                <td class="text_field"><asp:TextBox ID="bus20_totaldue_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus20_printbill_cb" runat="server"  /></td>
              </tr>
              <tr>
                <td><p>Tech Data</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus21_mr_cb" runat="server" /></td>
                <td class="text_field"><asp:TextBox ID="bus21_totaldue_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus21_printbill_cb" runat="server"  /></td>
              </tr>
              <tr>
                <td><p>Verizon</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus23_mr_cb" runat="server" /></td>
                <td class="text_field"><asp:TextBox ID="bus23_totaldue_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus23_printbill_cb" runat="server"  /></td>
                
              </tr>
            </tbody>
          </table>
        </div>
        
    <div class="second">
      <ul>
      <li><h4>Read and enter all meter readings, then click submit on form.</h4></li>
      <li><h4>Go to "Magic Computer" to pick up your list of Meter Readings.</h4></li>
      <li><h4>Give this list to your manager.</h4></li>
      <li><h4>After electric bills are completed by your Manager, deliver them to each business and check off as you deliver. </h4></li>
      <li><h4>After all bills have been delivered, go back to each business, collect the check and mark them off as you collect them. </h4></li>

    </ul>
    </div>
    

    
    
    <div class="footer3"><input type="submit" class="submit" value="Submit">
    
    </div>
    
        
</div> 
<script src="../../Scripts.js"></script>
    </form>
</body>
</html>
