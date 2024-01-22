<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Verizon_Manager's_Checklist.aspx.vb" Inherits="Enterprise_Village_2._0.Verizon_Manager_s_Checklist" %>

<!doctype html>
<html>
<head runat ="server">
<meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">
          <title>Verizon Manager's Checklist</title>


<link href="css/Styles.Checklist.css" rel="stylesheet" type="text/css">
</head>

<body>
    <form id="form1" runat="server">
    <div id="site_wrap">
    <div class="header1">
    
    <img class="EV" alt="Enterprise Village" src="Images/EV2.0_PCSB.png">
    
    </div>
        
    <div class="header2">
        <h2>Manager</h2> 
        </div>
        
      <div class="header3">
        <img class="business" alt="Business" src="media/logos/Verizon/verizon1.png" >
        </div>
        
     <div class="main_verizon">
         <h4>Verizon Manager's Checklist</h4>
        <table class="tall_table" border="1" >
            <tbody>
              <tr>
                <td class="table_header2">Business</td>
                <td class="table_header2">Phone extension</td>
                <td class="table_header2">Bill Amount</td>
                <td class="table_header2">Printed Bill</td>
                <td class="table_header2">Delivered Bill</td>
              </tr>
              <tr>
                <td class="row_text"><p>Astro Skate</p></td>
                <td class="checkbox"><p>1253</p></td>
                <td class="checkbox"><p>$9.00</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus1_bus23print_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus1_bus23deliver_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Bank of America</p></td>
                <td class="checkbox"><p>1260</p></td>
                <td class="checkbox"><p>$9.00</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus2_bus23print_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus2_bus23deliver_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>BayCare</p></td>
                <td class="checkbox"><p>1247</p></td>
                <td class="checkbox"><p>$9.00</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus3_bus23print_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus3_bus23deliver_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>BBB</p></td>
                <td class="checkbox"><p>1238</p></td>
                <td class="checkbox"><p>$9.00</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus4_bus23print_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus4_bus23deliver_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Koozie Group</p></td>
                <td class="checkbox"><p>1254</p></td>
                <td class="checkbox"><p>$9.00</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus5_bus23print_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus5_bus23deliver_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Buccaneers</p></td>
                <td class="checkbox"><p>1251</p></td>
                <td class="checkbox"><p>$9.00</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus18_bus23print_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus18_bus23deliver_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>City Hall</p></td>
                <td class="checkbox"><p>1246</p></td>
                <td class="checkbox"><p>$9.00</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus6_bus23print_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus6_bus23deliver_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>CVS</p></td>
                <td class="checkbox"><p>1239</p></td>
                <td class="checkbox"><p>$9.00</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus7_bus23print_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus7_bus23deliver_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Ditek</p></td>
                <td class="checkbox"><p>1244</p></td>
                <td class="checkbox"><p>$9.00</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus9_bus23print_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus9_bus23deliver_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Duke Energy</p></td>
                <td class="checkbox"><p>1241</p></td>
                <td class="checkbox"><p>$9.00</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus10_bus23print_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus10_bus23deliver_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>HSN</p></td>
                <td class="checkbox"><p>1243</p></td>
                <td class="checkbox"><p>$9.00</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus11_bus23print_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus11_bus23deliver_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Kane's</p></td>
                <td class="checkbox"><p>1252</p></td>
                <td class="checkbox"><p>$9.00</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus12_bus23print_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus12_bus23deliver_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>McDonald's</p></td>
                <td class="checkbox"><p>1249</p></td>
                <td class="checkbox"><p>$9.00</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus_bus23print_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus_bus23deliver_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Mix 100.7</p></td>
                <td class="checkbox"><p>1236</p></td>
                <td class="checkbox"><p>$9.00</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus14_bus23print_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus14_bus23deliver_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Professional Offices</p></td>
                <td class="checkbox"><p>1240</p></td>
                <td class="checkbox"><p>$9.00</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus17_bus23print_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus17_bus23deliver_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Rays</p></td>
                <td class="checkbox"><p>1237</p></td>
                <td class="checkbox"><p>$9.00</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus19_bus23print_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus19_bus23deliver_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Tampa Bay Times</p></td>
                <td class="checkbox"><p>1242</p></td>
                <td class="checkbox"><p>$9.00</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus20_bus23print_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus20_bus23deliver_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Tech Data</p></td>
                <td class="checkbox"><p>1234</p></td>
                <td class="checkbox"><p>$9.00</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus21_bus23print_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus21_bus23deliver_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Verizon</p></td>
                <td class="checkbox"><p>1248</p></td>
                <td class="checkbox"><p>N/a</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus23_bus23print_cb" runat="server" /></td>
                <td class="checkbox"><asp:CheckBox ID="bus23_bus23deliver_cb" runat="server" /></td>
              </tr>
            </tbody>
          </table>
        </div>
        
    <div class="second">
      <ul>
      <li><h4>You will use the information on the checklist and the Bill Payment Program on your computer to complete the Verizon bills.</li></h4>
      <li><h4>After you have entered the information, print the bill and check off that business.</li></h4>
      <li><h4>When all bills have been printed, use this checklist to deliver the bill to each business.</li></h4>
      <li><h4>Check off the business after you deliver the bill.</li></h4>
      <li><h4>After all taks are completed, please return your device to an EV staff member. </li></h4>
    </ul>
    </div>
    

    
    
    
    <div class="footer3"><button onclick="myFunction()" class="submit">Submit</button>
    
    </div>
    
        
</div> 
<script src="Scripts.js"></script>
    </form>
</body>
</html>

