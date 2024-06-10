<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Sales_System.aspx.vb" Inherits="Enterprise_Village_2._0.Sales_System" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!doctype html>
<html>
<head runat="server">

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">
    <title>Sales System</title>

    <link href="~/css/Styles.print.css" rel="stylesheet" media="print" type="text/css">
    <link href="css/Styles.SalesSystem.css" rel="stylesheet" media="screen" type="text/css">

    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png" />
</head>

<body>
    <form autocomplete="off"  id="Online_Banking_Form" runat="server" defaultbutton="Enter_account_btn">
        <div id="site_wrap">

            <%--Header--%>
            <div class="header1 no-print">
                <img class="EV no-print" alt="Enterprise Village" src="../../Images/EV2.0_PCSB.png">
            </div>

            <div class="header2 no-print">
                <h2>Sales System</h2>
            </div>

            <div class="header3">
                <asp:Image ID="BusLogo_img" runat="server" CssClass="Business_logo Business_logo_reciept" />
            </div>

            <%--Content--%>
            <div class="main_base" runat="server" id="sales_system_div" style="overflow: auto;">
                <br class="no-print" /> 

                <%--Help Window--%>
                <div id="help_div" runat="server" visible="false" class="no-print">
                    <div id="help_header">Welcome to the Sales System!
                        <asp:Button ID="close_btn" runat="server" CssClass="close_button" Text="X"/>
                    </div>
                    <ol class="help_list">
                            <li class="help_list_item">Hold card to the reader or type in a customer account number.</li>
                            <li class="help_list_item">Type in the price of the item the customer is buying in the 'Item 1' box.</li>
                            <li class="help_list_item">If buying more than one item, type in the price of the next item in the 'Item 2' box. Repeat this step if buying 3 or 4 items at once.</li>
                            <li class="help_list_item">Click 'Enter Sale' if finished. Click 'Cancel Sale' if you like to start over.</li>
                            <li class="help_list_item">The receipt print screen will display TWICE. Click the blue 'Print' button, then click it again once the window appears again.</li>
                            <li class="help_list_item">Give one of the receipts to the customer. Place the other receipt in the box.</li>
                        </ol>
                </div>     
                
                <%--Debit card--%>
                <div id="Debit_card_swipe">
                    <asp:Button ID="Button1" runat="server" Text="Debit Card Sale" Height="215px" Width="315px" class="Debit_card no-print" OnClientClick="CardSwipe();return false;" />
                </div>
                <div class="enter_account">
                    <asp:label ID="label6" Font-Bold="true" runat="server" CssClass="sales_label1 no-print">Hold card to the reader or type account number</asp:label>
                    <br />
                    <asp:TextBox ID="Debit_card_account" runat="server" TextMode="Number" Width="70px" CssClass="Textbox_text1 no-print"></asp:TextBox>
                    <br />
                    <asp:Button ID="Enter_account_btn" runat="server" textmode="number" Text="Enter Account" class="button3 no-print" ForeColor="white" />
                </div>

                <%--Name and Account Number And Balance--%>
                <div class="Check_edits">
                    <div>
                        <asp:Label  ID="Label2" runat="server" Text="Name: " Font-Bold="true"></asp:Label><asp:Label ID="customer_name_lbl" runat="server" Text=" "></asp:Label>
                        <asp:Label CssClass="no-print" ID="Business_name" runat="server" Text=""></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Account Number:"></asp:Label>
                        <asp:Label CssClass="Print_bold" ID="employee_number_lbl" runat="server" Text=" " ></asp:Label>
                    </div>
                     <div id="balance_div" runat="server" visible="true">
                        <asp:Label ID="Label3_lbl" runat="server" Font-Bold="true" Text="Current Balance:"></asp:Label>
                        <asp:Label CssClass="Print_bold" ID="balance_lbl" runat="server" Text=" "  ></asp:Label>
                    </div>
                    <div id="newBalance_div" runat="server" visible="false">
                        <asp:Label ID="Label4" runat="server" Font-Bold="true" Text="New Balance:"></asp:Label>
                        <asp:Label CssClass="Print_bold" ID="newBalance_lbl" runat="server" Text=" "  ></asp:Label>
                    </div> 
                </div>
                
                <asp:HiddenField ID="visitdate_hf" runat="server" />

                
                <%--Purchases Section--%>
                <h4 class='no-print'>Purchases</h4>
                <table class="Sales_Table">
                    <tr>
                        <td>
                            <p class="Sales_text">Item 1</p>
                        </td>
                        <td>
                            <a style="font-size: calc(13px + .5vw);">$</a><asp:TextBox ID="item1_tb" placeholder="_.__" runat="server" step="any" min="0" TextMode="Number" onkeyup="delayfunction3()" CssClass="Textbox_text Sales_System_Item_TB_Print"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <p id="item2_txt" class="Sales_text">Item 2</p>
                        </td>
                        <td>
                             <a style="font-size: calc(13px + .5vw);">$</a><asp:TextBox ID="item2_tb" placeholder="_.__" class="Print" runat="server" step="any" min="0" TextMode="Number" onkeyup="delayfunction3()" onKeyDown="if(this.value.length==5 && event.keyCode!=8) return false;" CssClass="Textbox_text Sales_System_Item_TB_Print"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <p id="item3_txt" class="Sales_text ">Item 3</p>
                        </td>
                        <td>
                             <a style="font-size: calc(13px + .5vw);">$</a><asp:TextBox ID="item3_tb" placeholder="_.__" class="Print" runat="server" step="any" min="0" TextMode="Number" onkeyup="delayfunction3()" onKeyDown="if(this.value.length==5 && event.keyCode!=8) return false;" CssClass="Textbox_text Sales_System_Item_TB_Print"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <p id="item4_txt" class="Sales_text ">Item 4</p>
                        </td>
                        <td>
                             <a style="font-size: calc(13px + .5vw);">$</a><asp:TextBox ID="item4_tb" placeholder="_.__" runat="server" step="any" min="0" TextMode="Number" onkeyup="delayfunction3()" onKeyDown="if(this.value.length==5 && event.keyCode!=8) return false;" CssClass="Textbox_text Sales_System_Item_TB_Print"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <p class="Print_bold Sales_text">Total</p>
                        </td>
                        <td>
                            <asp:TextBox ID="total_tb" runat="server" TextMode="Number" step="any" min="0"  CssClass="Textbox_text no-print total_tb2 " AutoPostBack="True"></asp:TextBox>
                             <a style="font-size: calc(13px + .5vw);">$</a><asp:TextBox ID="total_tb2" runat="server" TextMode="Number" step="any" min="0"  CssClass="Textbox_text Sales_System_Item_TB_Print" AutoPostBack="True"></asp:TextBox>
                        </td>
                    </tr>
                </table>
               
                <asp:Label ID="Label_date_time" runat="server" Text="Label"></asp:Label>
                <br />
                <asp:Button ID="Enter_sale_btn" runat="server" Text="Enter Sale" class="print_button no-print" ForeColor="white" />          <%--OnClientClick="javascript:window.print(); onafterprint:window.print();"--%>
                <%--<input type='button' value='Print' style="width:100px; height:50px" onclick='PrintFromURL()' />--%>
                <asp:Label ID="balancePrint_lbl" runat="server"></asp:Label>
                <asp:Button ID="Cancel_sale_btn" runat="server" Text="Cancel Sale" class="delete_button no-print" ForeColor="white" />
                <br />
                <asp:HyperLink ID="F2URL" runat="server" CssClass="ditek_print_button no-print" Text="Sales History"> </asp:HyperLink>&ensp;<asp:Button ID="help_btn" runat="server" Text="Help"  class="button3 no-print" />
                <br />
                <asp:Label ID="error_lbl" runat="server" Font-Bold="True" Font-Size="x-large" CssClass="no-print" ForeColor="Red"></asp:Label>                          
            </div>
        </div>      
        
        <script src="../../Scripts.js"></script>
        <script type="text/javascript">
            /*if (location.protocol = 'https:') {*/
                /*location.replace('https:' + window.location.href.substring(window.location.protocol.length))*/
            /*}*/
            url = window.location.search.substring(1)
            codepos = url.indexOf("passprnt_code");
            statpos = url.indexOf("passprnt_message")
            window.onload = function GetStat() {
                if (statpos > 0) {
                    status = url.slice(statpos + 17)
                    code = url.slice(codepos + 14, codepos + 15)
                    document.getElementById("stattxt").innerHTML = "Last Result:<br>" + status + "<br>Return Code: " + code
                }
            }

            function PrintFromURL() {
                URL = window.location.href
                passprnt_uri = "starpassprnt://v1/print/nopreview?";

                passprnt_uri += "&back=" + encodeURIComponent(window.location.href.split('?')[0]);
                passprnt_uri += "&popup=" + "ensable"
                passprnt_uri += "&url=" + encodeURIComponent(URL);
                location.href = passprnt_uri
            }

        </script>
       <%-- <script type="text/javascript">
            // Make the DIV element draggable:
            dragElement(document.getElementById("help_div2"));

            function dragElement(elmnt) {
                var pos1 = 0, pos2 = 0, pos3 = 0, pos4 = 0;
                if (document.getElementById(elmnt.id + "header2")) {
                    // if present, the header is where you move the DIV from:
                    document.getElementById(elmnt.id + "header2").onmousedown = dragMouseDown;
                } else {
                    // otherwise, move the DIV from anywhere inside the DIV:
                    elmnt.onmousedown = dragMouseDown;
                }

                function dragMouseDown(e) {
                    e = e || window.event;
                    e.preventDefault();
                    // get the mouse cursor position at startup:
                    pos3 = e.clientX;
                    pos4 = e.clientY;
                    document.onmouseup = closeDragElement;
                    // call a function whenever the cursor moves:
                    document.onmousemove = elementDrag;
                }

                function elementDrag(e) {
                    e = e || window.event;
                    e.preventDefault();
                    // calculate the new cursor position:
                    pos1 = pos3 - e.clientX;
                    pos2 = pos4 - e.clientY;
                    pos3 = e.clientX;
                    pos4 = e.clientY;
                    // set the element's new position:
                    elmnt.style.top = (elmnt.offsetTop - pos2) + "px";
                    elmnt.style.left = (elmnt.offsetLeft - pos1) + "px";
                }

                function closeDragElement() {
                    // stop moving when mouse button is released:
                    document.onmouseup = null;
                    document.onmousemove = null;
                }
            }
        </script>--%>
        <asp:Label ID="sql_lbl" runat="server" Visible="false"></asp:Label>
    </form>
</body>
</html>
