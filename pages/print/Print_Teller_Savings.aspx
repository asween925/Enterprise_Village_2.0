<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Print_Teller_Savings.aspx.vb" Inherits="Enterprise_Village_2._0.Print_Teller_Savings" %>

<!doctype html>
<html>
<head runat="server">

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>Print Teller</title>

    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png" /> 
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
                /*tellerURL = "https://a6351sfp:1337/teller_system.aspx"*/
                tellerURL = "https://ev.pcsb.org/pages/student/teller_system.aspx"
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
            window.location.replace("https://ev.pcsb.org/pages/student/teller_system.aspx")
        }

        function GoBack() {
            window.history.back();
            //window.close();
            /*window.location.replace("https://a6351sfp:1337/teller_system.aspx");*/
            //window.open("https://ev.pcsb.org/teller_system.aspx");
        }
    </script>
    <style>
        img {
          display: block;
          margin-left: auto;
          margin-right: auto;
        }
    </style>
</head>

<body onload="PrintFromURL();">
    <form autocomplete="off"  id="Online_Banking_Form" runat="server">
        <div style="font-size: x-large;">

            <%--<asp:Image ID="Image1" runat="server" Height="100px" ImageUrl="~/media/Logos/BOA/Bank_of_America.png" Width="123px" />--%>
            <p style="text-align: center; font-weight: bold; text-decoration: underline;">Achieva Credit Union</p>

            <p>Name: <asp:Label ID="name_lbl" runat="server"></asp:Label></p>
            <p>Account #<asp:Label ID="account_number_lbl" runat="server"></asp:Label></p>
            <p>Savings: <asp:Label ID="savings_lbl" runat="server"></asp:Label></p>   

            <asp:DropDownList ID="savings_ddl" runat="server" Visible="false" Font-Size="X-Large">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>$0.50</asp:ListItem>
                <asp:ListItem>$1.00</asp:ListItem>
                <asp:ListItem>$1.50</asp:ListItem>
            </asp:DropDownList>               
            
            <asp:Label ID="date_lbl" runat="server"></asp:Label>

            <asp:HiddenField ID="empnum_hf" runat="server" />
            <asp:HiddenField ID="visitDate_hf" runat="server" />
        </div>

        <script src="../../Scripts.js"></script>
        
    </form>
</body>
</html>
