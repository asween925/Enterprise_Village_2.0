<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Sales_System_McDonalds.aspx.vb" Inherits="Enterprise_Village_2._0.Sales_System_McDonalds" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!doctype html>
<html>
<head runat="server">

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">
    <title>McDonald's Sales System</title>

    <link href="~/css/Styles.print.css" rel="stylesheet" media="print" type="text/css">
    <link href="css/Styles.McDonaldsSales.css" rel="stylesheet" media="screen" type="text/css">

    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png" />
</head>

<body>
    <form autocomplete="off"  id="Online_Banking_Form" runat="server">
        <div>

            <%--Content--%>
            <div class="main_mcd">
                <br class="no-print" />

                <%--Screen 1--%>
                <div class="enter_account" id="Screen1">

                    <%--Enter Account--%>
                    <image alt="McDonald's Logo" src="media\Logos\Mcdonalds\mcdonalds-png-logo-simple-m-1.png"></image>
                    <br />
                    <asp:Label ID="label6" Font-Bold="true" runat="server" class="no-print">Enter an Account Number</asp:Label>
                    <br />
                    <br />
                    <asp:TextBox ID="accountNumber_tb" runat="server" TextMode="Number" Width="50px" Height="40px" CssClass="textbox no-print"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="enterAccount_btn" runat="server" textmode="number" Text="Enter Account" class="button3 no-print" ForeColor="white" />
                    <br /><br />
                    <asp:Label ID="error_lbl" runat="server" Font-Bold="True" Font-Size="x-large" CssClass="no-print" ForeColor="Yellow"></asp:Label>
                </div>

                <%--Screen 2--%>
                <div id="Screen2">
                    
                    <%--Account Information--%>
                    <div class="account_info">
                        <h3>Account Information</h3>
                        <div>
                            <asp:Label ID="Label2" runat="server" Text="Name: " Font-Bold="true"></asp:Label><asp:Label ID="customer_name_lbl" runat="server" Text=" "></asp:Label>
                            <asp:Label CssClass="no-print" ID="Business_name" runat="server" Text=""></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Account Number:"></asp:Label>
                            <asp:Label CssClass="Print_bold" ID="employee_number_lbl" runat="server" Text=" "></asp:Label>
                        </div>
                        <div id="balance_div" runat="server" visible="true">
                            <asp:Label ID="Label3" runat="server" Font-Bold="true" Text="Current Balance:"></asp:Label>
                            <asp:Label CssClass="Print_bold" ID="balance_lbl" runat="server" Text=" "></asp:Label>
                        </div>
                        <div id="newBalance_div" runat="server" visible="false">
                            <asp:Label ID="Label4" runat="server" Font-Bold="true" Text="New Balance:"></asp:Label>
                            <asp:Label CssClass="Print_bold" ID="newBalance_lbl" runat="server" Text=" "></asp:Label>
                        </div>

                    </div>
                    <br />
                    <br />

                    <%--Buttons--%>
                    <div class="snack_box">
                        <label class="container">
                            <image alt="Snack Only" src="images\snackonly.png" width="260px;" height="260px;"></image>
                            <input type="radio" name="radio" id="snack_rdo" runat="server">
                            <span class="checkmark"></span>
                        </label>
                    </div>
                    <div class="drink_box">
                        <label class="container">
                            <image alt="Drink Only" src="images\drinkonly.png" width="260px;" height="260px;"></image>
                            <input type="radio" name="radio" id="drink_rdo" runat="server">
                            <span class="checkmark"></span>
                        </label>
                    </div>
                    <div class="snackanddrink_box">
                        <label class="container">
                            <image alt="Snack and Drink" src="images\snack&drink.png" width="250px;" height="250px;"></image>
                            <input type="radio" name="radio" id="both_rdo" runat="server">
                            <span class="checkmark"></span>
                        </label>
                    </div>

                    <%--Controls--%>
                    <div>
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <asp:Button ID="enterSale_btn" runat="server" Text="Enter Sale" CssClass="print_button no-print" ForeColor="white" />
                        <asp:Label ID="balancePrint_lbl" runat="server"></asp:Label>
                        <asp:Button ID="cancelSale_btn" runat="server" Text="Cancel Sale" CssClass="delete_button no-print" ForeColor="white" />
                        <br />
                        <asp:Button ID="help_btn" runat="server" Text="Help" CssClass="button3 no-print" />
                        <br />
                    </div>

                    <asp:Label ID="sql_lbl" runat="server" Visible="false"></asp:Label><asp:HiddenField ID="visitdate_hf" runat="server" />
                </div>
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
    </form>
</body>
</html>
