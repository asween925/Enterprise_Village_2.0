<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Badge_Creator.aspx.vb" Inherits="Enterprise_Village_2._0.Badge_Creator" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!doctype html>

<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title class="no-print">Badge Creator</title>

    <link href="~/css/Styles.Print.css" rel="stylesheet" media="print" type="text/css">
    <link href="~/css/Styles.profit.css" rel="stylesheet" type="text/css">
    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png" />

    <script src="../../script-jquery-3.6.0.slim.js"></script>
    <script src="../../jquery.webcam.js"></script>
    <script src="../../Scripts.js"></script>

    <style>
        #container {
            margin: 0px auto;
            width: 50px;
            height: 37px;
            border: 10px #333 solid;
            float: right;
        }

        #videoElement {
            margin: 10px auto;
            width: 110px;
            height: 125px;
            background-color: white;
            float: right;
        }

        .d-none {
        }
    </style>
</head>

<body>
    <form autocomplete="off"  id="Profit_display_Form" runat="server">
        <div id="site_wrap">
            <div class="main_mix">
                <asp:Label ID="Label19" runat="server" Text="Badge Creator" Font-Size="70px" CssClass="no-print"></asp:Label>
                <br />
                <asp:LinkButton ID="LinkButton9" runat="server" PostBackUrl="/pages/student/badge_creator_print.aspx" Font-Size="Medium" CssClass="button button1">Print Badges</asp:LinkButton>
                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="/pages/student/badge_creator_history.aspx" Font-Size="Medium" CssClass="button button1">Badge History</asp:LinkButton>
                <br /><br />
                <div>

                    <%--Instructions--%>
                    <div class="instructions no-print">
                        <h3>Welcome to the Badge Creator!</h3>
                        <ol>
                            <li>Enter the student number in the box at the top of the screen.</li>
                            <li>Take a picture of the student. Make sure they smile!</li>
                            <li>When they are happy with their picture, click the 'Upload Picture' button.</li>
                            <li>Click on 'Print Badges' to print your saved badges.</li>
                            <li>Click on 'Badge History' to see all saved badges.</li>
                            <p style="font-size: 18px; color: yellow;">Total Badges: <asp:Label runat="server" ID="badge_total" Text="0"></asp:Label></p>
                        </ol>
                    </div>

                <%--Camera--%>
                <div class="camera_controls">
                    <video id="capturevideo" width="275" height="275" class="camera d-none no-print"></video><%--camera--%>
                    <asp:Button runat="server" ID="capture_btn" Text="Take Picture" class="button button1 no-print" OnClientClick="javascript:capture(); return false;" /> 
                    <canvas id="capturecanvas" runat="server" width="275" height="275" class="badge_photo d-none"></canvas> <%--badge photo--%> <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
                    <asp:Button runat="server" ID="upload_btn" Text="Upload Picture" class="button button1 no-print"/>
                    
                </div>
                    
                    <%--Account Number--%>
                    <h4 class="no-print" style="font-size: 16px; text-decoration: underline;">Enter Account Number:</h4>
                    <asp:TextBox runat="server" ID="employeeNumber_tb" Width="70px" Height="50px" Font-Size="25px" TextMode="Number" CssClass="no-print"></asp:TextBox>
                    <br /><br />
                    <asp:Button ID="Enter_btn" runat="server" Text="Enter" class="print_button no-print" />
                    <br /><br />
                    <asp:Label ID="error_lbl" runat="server" Font-Bold="True" Font-Size="14px" ForeColor="Yellow" ></asp:Label>
                    <br />

                    <%--badge--%>
                    <div class="badge">                 
                        <img class="badge_logo" alt="Tech Data" src="../../Images/TD_SYNNEX.png">
                        <asp:Image ID="photo_img" CssClass="photo" runat="server"/>    
                        <br /><br /><br /><br /><br /><br /><br />
                        <asp:Label runat="server" Text="Name: "></asp:Label>
                        <asp:Label ID="studentName_lbl" runat="server"></asp:Label>
                        <br />
                        <asp:Label runat="server" Text="Business: "></asp:Label>
                        <asp:Label ID="businessName_lbl" runat="server"></asp:Label>
                        <br />
                        <asp:Label runat="server" Text="Position: "></asp:Label>
                        <asp:Label ID="position_lbl" runat="server"></asp:Label>
                        <br />
                        <asp:Label runat="server" Text="Date: "></asp:Label>
                        <asp:Label ID="date_lbl" runat="server"></asp:Label>&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;<asp:Label ID="employeeNumber_lbl" runat="server"></asp:Label>
                    </div>
                    <br />
                    <asp:Label ID="uploadWarning_lbl" runat="server" Text="Uploading a photo takes 3 seconds, please DO NOT click upload again after clicking once." Font-Bold="True" Font-Size="16px" ForeColor="Yellow"></asp:Label>
                </div>
                <asp:HiddenField ID="visitID_hf" runat="server" />
                <asp:HiddenField ID="tablemaxRow_hf" runat="server" Value="0" />
                <asp:HiddenField ID="tablerowIndex_hf" runat="server" Value="0" />
            </div>

            <asp:GridView ID="existingBadges_dgv" runat="server" PageSize="100" Visible="false" ShowHeaderWhenEmpty="True" CssClass="no-print"></asp:GridView>

        </div>
    </form>
    <script>

        var videoCapture;
        $(document).ready(function () {
            videoCapture = document.getElementById('capturevideo');
        });

        if (navigator.mediaDevices && navigator.mediaDevices.getUserMedia) {
            // access video stream from webcam
            navigator.mediaDevices.getUserMedia({ video: true }).then(function (stream) {
                // on success, stream it in video tag 
                window.localStream = stream;
                videoCapture.srcObject = stream;
                videoCapture.play();
                activateCamera();
            }).catch(e => {
                // on failure/error, alert message. 
                
            });
        }
        function capture() {          
            document.getElementById('capturecanvas').getContext('2d').drawImage(videoCapture, 0, 0, 230, 230);
            var image = document.getElementById("capturecanvas").toDataURL('image/png').replace('image/png', 'image/octet-stream');
            var anchor = document.createElement('a');
            anchor.setAttribute('download', 'myPhoto.png');
            anchor.setAttribute('href', image);
            anchor.click();
        }
       
        function save() {
                    
            var btn = document.getElementById('<%= upload_btn.ClientID %>');
            document.getElementById(btn).disabled = false;
            anchor.setAttribute('download', 'myPhoto.png');
            anchor.setAttribute('href', image);
            anchor.click();
          
        }

        function myTimer() {
            var timeleft = 3;
            var downloadTimer = setInterval(function () {
                if (timeleft <= 0) {
                    clearInterval(downloadTimer);
                    document.getElementById("upload_btn").innerHTML = "Upload Picture";
                } else {
                    document.getElementById("upload_btn").innerHTML = "(" + timeleft + ") Upload Picture";
                }
                timeleft -= 1;
            }, 1000);

            /*document.getElementById("upload_btn").innerHTML = */
        }

    </script>

    <script src="../../Scripts.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
</body>
</html>
