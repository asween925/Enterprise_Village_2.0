<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Duke_Energy_Utility_Engineer_Energy_Conservation_Checklist.aspx.vb" Inherits="Enterprise_Village_2._0.Duke_Energy_Utility_Engineer_Energy_Conservation_Checklist" %>

<!doctype html>
<html>
<head runat ="server">
<meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">
          <title>Duke Energy Utility Engineer Energy Conservation Checklist</title>


<link href="~/css/Styles.Checklist.css" rel="stylesheet" type="text/css">
</head>

<body>
    <form id="form1" runat="server">
    <div id="site_wrap">
    <div class="header1">
    
    <img class="EV" alt="Enterprise Village" src="../../Images/EV2.0_PCSB.png">
    
    </div>
        
    <div class="header2">
        <h2 style="font-size: 14px;">Duke Energy Utility Engineer</h2> 
        </div>
        
      <div class="header3">
        <img class="business" alt="Business" src="../../Images/duke.jpg" >
        </div>
        
     <div class="main_duke">
        <br /><br /><br /><br />
        <table class="tall_table" border="1" style="font-size: 10px;" >
            <tbody>
              <tr>
                <td class="table_header2" style="font-size: 8px;">Business</td>
                <td class="table_header2" style="font-size: 8px;">Step A</td>
                <td class="table_header2" style="font-size: 8px;"># of thermostats</td>
                <td class="table_header2" style="font-size: 8px;">Step B: Thermostat reading(s)</td>
                <td class="table_header2" style="font-size: 8px;">Step C</td>
              </tr>
              <tr>
                <td class="row_text"><p>Astro Skate</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus1_install_cb" runat="server" /></td>
                <td class="checkbox"><p>1</p></td>
                <td class="text_field"><asp:TextBox ID="bus1_thermostat_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus1_remove_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Achieva Credit Union</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus2_install_cb" runat="server" /></td>
                <td class="checkbox"><p>2</p></td>
                <td class="text_field"><asp:TextBox ID="bus2_thermostat1_tb" runat="server" TextMode="Number" CssClass="textbox2"></asp:TextBox><asp:TextBox ID="bus2_thermostat2_tb" runat="server" TextMode="Number" CssClass="textbox2"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus2_remove_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>BayCare</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus3_install_cb" runat="server" /></td>
                <td class="checkbox"><p>1</p></td>
                <td class="text_field"><asp:TextBox ID="bus3_thermostat_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus3_remove_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>BBB</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus4_install_cb" runat="server" /></td>
                <td class="checkbox"><p>1</p></td>
                <td class="text_field"><asp:TextBox ID="bus4_thermostat_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus4_remove_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Koozie Group</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus5_install_cb" runat="server" /></td>
                <td class="checkbox"><p>2</p></td>
                <td class="text_field"><asp:TextBox ID="bus5_thermostat1_tb" runat="server" TextMode="Number" CssClass="textbox2"></asp:TextBox><asp:TextBox ID="bus5_thermostat2_tb" runat="server" TextMode="Number" CssClass="textbox2"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus5_remove_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Buccaneers</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus18_install_cb" runat="server" /></td>
                <td class="checkbox"><p>1</p></td>
                <td class="text_field"><asp:TextBox ID="bus18_thermostat_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus18_remove_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>City Hall</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus6_install_cb" runat="server" /></td>
                <td class="checkbox"><p>3</p></td>
                <td class="text_field"><asp:TextBox ID="bus6_thermostat1_tb" runat="server" TextMode="Number" CssClass="textbox3"></asp:TextBox><asp:TextBox ID="bus6_thermostat2_tb" runat="server" TextMode="Number" CssClass="textbox3"></asp:TextBox><br><asp:TextBox ID="bus6_thermostat3_tb" runat="server" TextMode="Number" CssClass="textbox3"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus6_remove_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>CVS</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus7_install_cb" runat="server" /></td>
                <td class="checkbox"><p>1</p></td>
                <td class="text_field"><asp:TextBox ID="bus7_thermostat_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus7_remove_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Ditek</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus9_install_cb" runat="server" /></td>
                <td class="checkbox"><p>1</p></td>
                <td class="text_field"><asp:TextBox ID="bus9_thermostat_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus9_remove_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Duke Energy</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus10_install_cb" runat="server" /></td>
                <td class="checkbox"><p>1</p></td>
                <td class="text_field"><asp:TextBox ID="bus10_thermostat_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus10_remove_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>HSN</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus11_install_cb" runat="server" /></td>
                <td class="checkbox"><p>1</p></td>
                <td class="text_field"><asp:TextBox ID="bus11_thermostat_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus11_remove_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Kane's</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus12_install_cb" runat="server" /></td>
                <td class="checkbox"><p>1</p></td>
                <td class="text_field"><asp:TextBox ID="bus12_thermostat_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus12_remove_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>McDonald's</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus13_install_cb" runat="server" /></td>
                <td class="checkbox"><p>2</p></td>
                <td class="text_field"><asp:TextBox ID="bus13_thermostat_tb" runat="server" TextMode="Number"></asp:TextBox><asp:TextBox ID="TextBox1" runat="server" TextMode="Number" CssClass="textbox3"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus13_remove_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Mix 100.7</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus14_install_cb" runat="server" /></td>
                <td class="checkbox"><p>1</p></td>
                <td class="text_field"><asp:TextBox ID="bus14_thermostat1_tb" runat="server" TextMode="Number" CssClass="textbox2"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus14_remove_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>KnowBe4</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus17_install_cb" runat="server" /></td>
                <td class="checkbox"><p>1</p></td>
                <td class="checkbox"><asp:TextBox ID="bus17_thermostat1_tb" runat="server" TextMode="Number" CssClass="textbox4"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus17_remove_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Rays</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus19_install_cb" runat="server" /></td>
                <td class="checkbox"><p>1</p></td>
                <td class="text_field"><asp:TextBox ID="bus19_thermostat_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus19_remove_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Tampa Bay Times</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus20_install_cb" runat="server" /></td>
                <td class="checkbox"><p>1</p></td>
                <td class="text_field"><asp:TextBox ID="bus20_thermostat_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus20_remove_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>TD SYNNEX</p></td>
                <td class="closed"></td>
                <td class="checkbox"><p>1</p></td>
                <td class="text_field"><asp:TextBox ID="bus21_thermostat_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="closed"></td>
              </tr>
              <tr class="row_text">
                <td><p>United Way</p></td>
                <td class="checkbox"><asp:CheckBox ID="bus23_install_cb" runat="server" /></td>
                <td class="checkbox"><p>1</p></td>
                <td class="text_field"><asp:TextBox ID="bus23_thermostat_tb" runat="server" TextMode="Number"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus23_remove_cb" runat="server" /></td>            
              </tr>
            </tbody>
          </table>
        </div>
        
    <div class="second">
      <h2>Step A:</h2>
      <ul>
      <li><h4>Complete after National Anthem</h4></li>
      <li><h4>Install clean filter, give the Energy Award to each Manager</h4></li>
    </ul>
    <h2>Step B:</h2>
      <ul>
      <li><h4>Go to each business and get today's reading. Type reading in for each business.</h4></li>
    </ul>
    <h2>Step C:</h2>
      <ul>
      <li><h4>Complete after 3rd business meeting</h4></li>
      <li><h4>Remove the clean filter</h4></li>
    </ul>
    </div>
    

    
    
    <div class="footer3"><button onclick="myFunction()" class="submit">Submit</button>
    
    </div>
    
        
</div> 
<script src="../../Scripts.js"></script>
    </form>
</body>
</html>

