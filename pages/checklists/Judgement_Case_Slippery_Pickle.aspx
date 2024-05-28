<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Judgement_Case_Slippery_Pickle.aspx.vb" Inherits="Enterprise_Village_2._0.Judgement_Case_Slippery_Pickle" %>

<!doctype html>
<html>
<head runat ="server">
<meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">
          <title>Judgement Statement</title>


<link href="~/css/Styles.Checklist.css" rel="stylesheet" type="text/css">
</head>

<body>
    <form id="form1" runat="server">
    <div id="site_wrap">
    <div class="header1">
    
    <img class="EV" alt="Enterprise Village" src="../../Images/EV2.0_PCSB.png">
    
    </div>
        
    <div class="header2">
        <h2>Attorney-at-law </h2> 
        </div>
        
      <div class="header3">
        <img class="business" alt="Business" src="../../Images/professionaloffice.jpg">
        </div>
        
     <div class="main_professional">
         <h4>JUDGEMENT STATEMENT <BR>
        THE CASE OF THE SLIPPERY PICKLE</h4>
        <P>Date:<input type="date"><br>Good afternoon citizens of Enterprise Village. Based on my investigation, I found that McDonald's <asp:CheckBox ID="pickle_will_cb" runat="server" />will <asp:CheckBox ID="pickle_wont_cb" runat="server" />will not be 
          responsible for paying the medical bills of Tony Perry for the following  </P>
          <textarea class="textarea2">
          </textarea><br>
         
         <div class="bottom_right" ><td class="text_field"><asp:TextBox ID="pickle_name_tb" runat="server"></asp:TextBox></td>
          <p>Attorney-at-law</p><br>
          <input type="button" value="Print this page" onClick="window.print()">
     </div>
        </div>
        
    <div class="second">
      <ul><h4><li>You have read all the information regarding Tony Perry's accident, his medical records, and other similar Florida court cases. 
        You must now decide and recommend what you think should happen regarding Tony Perry's accident. Should McDonald's be responsible for paying Tony's medical bills?
        Using the information from your investigation, fill in the blanks. You will be reading these results at the Town Meeting.
      </li></h4></ul>
    </div>
    

    
    
    
    <div class="footer3"><button onclick="myFunction()" class="submit">Submit</button>
    
    </div>
    
        
</div> 
<script src="../../Scripts.js"></script>
    </form>
</body>
</html>
