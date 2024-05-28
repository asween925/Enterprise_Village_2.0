<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Judgement_Case_Missing_Teddy_Bear.aspx.vb" Inherits="Enterprise_Village_2._0.Judgement_Case_Missing_Teddy_Bear" %>

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
        THE CASE OF THE MISSING TEDDY BEAR</h4>
        <P>Date:<input type="date"><br>Good afternoon citizens of Enterprise Village. Based on my investigation, I found that <td class="text_field"><asp:TextBox ID="investigation_tb" runat="server"></asp:TextBox></td> went into CVS and stole a big, black and white teddy bear. </P>
        <p>According to the Enterprise Village statute 812.015 the defendent is guilty of:</p>
        <textarea class="textarea2">
          </textarea><br>
          <p>The maximum punishment allowed for this crime is:</p>
          <textarea class="textarea2">
            </textarea><br>
         
         <div class="bottom_right" ><td class="text_field"><asp:TextBox ID="teddy_name_tb" runat="server"></asp:TextBox></td>
          <p>Attorney-at-law</p><br>
          <input type="button" value="Print this page" onClick="window.print()">
     </div>
        </div>
        
    <div class="second">
      <h4><ul>
        <li>You have completed your investigation and are ready to recommend what you think should happen to the person who stole the teddy bear. Using the information from 
        the statute and your investigation, fill in the blanks. You will be reading these results at the Town Meeting.</li></ul></h4>
     
    </div>
    

    
    
    
    <div class="footer3"><button onclick="myFunction()" class="submit">Submit</button>
    
    </div>
    
        
</div> 
<script src="../../Scripts.js"></script>
    </form>
</body>
</html>
