﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Print_Sales.aspx.vb" Inherits="Enterprise_Village_2._0.Print_Sales" %>

<!doctype html>
<html>
<head runat="server">

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">
    <title>Print Sales</title>
    <link rel="shortcut icon" type="image/png" href="media/EV_favicon_2.png" /> 
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
                tellerURL = "https://ev.pcsb.org/sales_system_mcdonalds.aspx"
                passprnt_uri = "starpassprnt://v1/print/nopreview?";

                passprnt_uri += "&back=" + encodeURIComponent(tellerURL);
                /*passprnt_uri += "&popup=" + "enable"*/
                passprnt_uri += "&url=" + encodeURIComponent(URL);
                location.href = passprnt_uri
                myVar = setTimeout(GoBackToTeller, 1000);
        }

        function PrintTeller() {
            myVar = setTimeout(GoBack, 1000);
        }

        function GoBackToTeller() {
            window.location.replace("https://ev.pcsb.org/sales_system_mcdonalds.aspx")
        }

        function GoBack() {
            window.history.back();
        }
    </script>
</head>

<body onload="PrintFromURL();">
    <form id="Online_Banking_Form" runat="server">
        <div style="font-size: x-large;">
            <p style="text-align:center; font-weight: bold; text-decoration: underline;">McDonald's</p>
            <p>Name: <asp:Label ID="name_lbl" runat="server"></asp:Label></p>
            <p>Account #<asp:Label ID="account_number_lbl" runat="server"></asp:Label></p>
            <p>Old Balance: <asp:Label ID="balance_lbl" runat="server"></asp:Label></p>
            <p>New Balance: <asp:Label ID="newBalance_lbl" runat="server"></asp:Label></p>
            <p>Items Purchased:</p>
            <asp:Label ID="item1_lbl" runat="server"></asp:Label>
            <br />
            <asp:Label ID="item2_lbl" runat="server"></asp:Label>
            <br />
            <asp:Label ID="item3_lbl" runat="server"></asp:Label>
            <br />
            <asp:Label ID="item4_lbl" runat="server"></asp:Label><br />
            <p>Total: <asp:Label ID="saleTotal_lbl" runat="server"></asp:Label></p>
            <%--<input type='button' value='Print' style="width:100px; height:50px" onclick='PrintFromURL()' />    --%>     
            <asp:Label ID="date_lbl" runat="server"></asp:Label>
            <asp:HiddenField ID="empnum_hf" runat="server" />
            <asp:HiddenField ID="visitDate_hf" runat="server" />
        </div>

        <script src="Scripts.js"></script>
        

    </form>
</body>
</html>
