<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="City_Hall_Mayor_Checklist.aspx.vb" Inherits="Enterprise_Village_2._0.City_Hall_Mayor_Checklist" %>

<!doctype html>
<html>
<head runat ="server">
<meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">
          <title>Mayor's Population Count and Shopping Bag Delivery Sheet</title>


<link href="css/Styles.Checklist.css" rel="stylesheet" type="text/css">
</head>

<body>
    <form id="form1" runat="server">
    <div id="site_wrap">
    <div class="header1">
    
    <img class="EV" alt="Enterprise Village" src="Images/EV2.0_PCSB.png">
    
    </div>
        
    <div class="header2">
        <h2>Mayor's Population Count and Shopping Bag Delivery Sheet</h2> 
        </div>
        
      <div class="header3">
        <img class="business" alt="Business" src="Images/cityhall.jpg" >
        </div>
        
     <div class="main_pc">
         <br /><br /><br /><br />
        <table class="tall_table" border="1" >
            <tbody>
              <tr>
                <td class="table_header2">Business Name</td>
                <td class="table_header2"># of Employees</td>
                <td class="table_header2">Bags Delivered</td>
              </tr>
              <tr>
                <td class="row_text"><p>Astro Skate</p></td>
                <td class="text_field"><asp:TextBox ID="bus1_wmr_tb" runat="server" TextMode="Number"  CssClass="textbox"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus1_wmr_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Achieva Credit Union</p></td>
                <td class="text_field"><asp:TextBox ID="bus2_wmr_tb" runat="server" TextMode="Number"  CssClass="textbox"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus2_wmr_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>BayCare</p></td>
                <td class="text_field"><asp:TextBox ID="bus3_wmr_tb" runat="server" TextMode="Number"  CssClass="textbox"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus3_wmr_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>BBB</p></td>
                <td class="text_field"><asp:TextBox ID="bus4_wmr_tb" runat="server" TextMode="Number"  CssClass="textbox"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus4_wmr_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Koozie Group</p></td>
                <td class="text_field"><asp:TextBox ID="bus5_wmr_tb" runat="server" TextMode="Number"  CssClass="textbox"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus5_wmr_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Buccaneers</p></td>
                <td class="text_field"><asp:TextBox ID="bus18_wmr_tb" runat="server" TextMode="Number"  CssClass="textbox"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus18_wmr_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>City Hall</p></td>
                <td class="text_field"><asp:TextBox ID="bus6_wmr_tb" runat="server" TextMode="Number"  CssClass="textbox"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus6_wmr_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>CVS</p></td>
                <td class="text_field"><asp:TextBox ID="bus7_wmr_tb" runat="server" TextMode="Number"  CssClass="textbox"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus7_wmr_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Ditek</p></td>
                <td class="text_field"><asp:TextBox ID="bus9_wmr_tb" runat="server" TextMode="Number"  CssClass="textbox"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus9_wmr_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Duke Energy</p></td>
                <td class="text_field"><asp:TextBox ID="bus10_wmr_tb" runat="server" TextMode="Number"  CssClass="textbox"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus10_wmr_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>HSN</p></td>
                <td class="text_field"><asp:TextBox ID="bus11_wmr_tb" runat="server" TextMode="Number"  CssClass="textbox"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus11_wmr_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Kane's</p></td>
                <td class="text_field"><asp:TextBox ID="bus12_wmr_tb" runat="server" TextMode="Number"  CssClass="textbox"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus12_wmr_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>McDonald's</p></td>
                <td class="text_field"><asp:TextBox ID="bus13_wmr_tb" runat="server" TextMode="Number"  CssClass="textbox"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus13_wmr_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Mix 100.7</p></td>
                <td class="text_field"><asp:TextBox ID="bus14_wmr_tb" runat="server" TextMode="Number"  CssClass="textbox"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus14_wmr_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>KnowBe4</p></td>
                <td class="text_field"><asp:TextBox ID="bus17_wmr_tb" runat="server" TextMode="Number"  CssClass="textbox"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus17_wmr_cb" runat="server" /></td>
              </tr>
                <tr>
                <td class="row_text"><p>PCSW</p></td>
                <td class="text_field"><asp:TextBox ID="TextBox1" runat="server" TextMode="Number"  CssClass="textbox"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="CheckBox1" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Rays</p></td>
                <td class="text_field"><asp:TextBox ID="bus19_wmr_tb" runat="server" TextMode="Number"  CssClass="textbox"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus19_wmr_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>Tampa Bay Times</p></td>
                <td class="text_field"><asp:TextBox ID="bus20_wmr_tb" runat="server" TextMode="Number"  CssClass="textbox"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus20_wmr_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>TD SYNNEX</p></td>
                <td class="text_field"><asp:TextBox ID="bus21_wmr_tb" runat="server" TextMode="Number" CssClass="textbox"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus21_wmr_cb" runat="server" /></td>
              </tr>
              <tr>
                <td class="row_text"><p>United Way</p></td>
                <td class="text_field"><asp:TextBox ID="bus23_wmr_tb" runat="server" TextMode="Number" CssClass="textbox"></asp:TextBox></td>
                <td class="checkbox"><asp:CheckBox ID="bus23_wmr_cb" runat="server" /></td>
              </tr>
            </tbody>
          </table>
        </div>
        
    <div class="second">
      <ul>
      <li><h4>Enter the number of employees in each business and click the box when you have delivered the bags.</h4></li>
    </ul>
    </div>

    
    
    
    <div class="footer3"><button onclick="myFunction()" class="submit">Submit</button>
    
    </div>
    
        
</div> 
<script src="Scripts.js"></script>
    </form>
</body>
</html>
