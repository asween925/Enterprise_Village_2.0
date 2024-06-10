<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Voting_System_Mayor.aspx.vb" Inherits="Enterprise_Village_2._0.Voting_System_Mayor" MaintainScrollPositionOnPostback="false" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %> 

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>Voting System</title>

    <link href="~/css/Styles.StudentPages.css" rel="stylesheet" type="text/css"> <%--look in this css file for body and h3 tags--%>
    <link href="~/css/Styles.print.css" rel="stylesheet" media="print" type="text/css">
    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png" />
</head>

<body class="Voting_System_Body">
    <form autocomplete="off"  id="Voting_System_Mayor" runat="server">
        <div id="Site_Wrap_Fullscreen">

            <h3 style="text-decoration: none; font-style: italic;" class="Voting_System_H3_Print">Enterprise Village Voting System</h3>
            <asp:Label ID="error_lbl" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="X-Large"></asp:Label>
            <asp:Button ID="print_btn" runat="server" CssClass="print_button no-print" Text="Print" />

            <%--Content--%>
            <div>            
                <h4 class="Voting_System_Questions_H4">#1. How would you describe your day at Enterprise Village?</h4>

                    <p>OK - <asp:Label ID="q1a1_lbl" runat="server"></asp:Label></p>
                    <p>Great - <asp:Label ID="q1a2_lbl" runat="server"></asp:Label></p>
                    <p>Fantastic - <asp:Label ID="q1a3_lbl" runat="server"></asp:Label></p>
                    <%--<p>My Teacher - <asp:Label ID="q1a4_lbl" runat="server"></asp:Label></p>--%>

                <h4 class="Voting_System_Questions_H4">#2. Did you enjoy your job today?</h4>

                    <p>Yes - <asp:Label ID="q2a1_lbl" runat="server"></asp:Label></p>
                    <p>No - <asp:Label ID="q2a2_lbl" runat="server"></asp:Label></p>
                    <p>I don't know - <asp:Label ID="q2a3_lbl" runat="server"></asp:Label></p>
                    <%--<p>Endorsed check and savings ticket - <asp:Label ID="q2a4_lbl" runat="server"></asp:Label></p>--%>

                <h4 class="Voting_System_Questions_H4">#3. Do you feel you know more about Free Enterprise after your visit today?</h4>

                    <p>Yes - <asp:Label ID="q3a1_lbl" runat="server"></asp:Label></p>
                    <p>No - <asp:Label ID="q3a2_lbl" runat="server"></asp:Label></p>
                    <p>I don't know - <asp:Label ID="q3a3_lbl" runat="server"></asp:Label></p>
                    <%--<p>All of the above - <asp:Label ID="q3a4_lbl" runat="server"></asp:Label></p>--%>

                <h4 class="Voting_System_Questions_H4">#4. What was your favorite part or the day? </h4>

                    <p>Spending money - <asp:Label ID="q4a1_lbl" runat="server"></asp:Label></p>
                    <p>Lunch - <asp:Label ID="q4a2_lbl" runat="server"></asp:Label></p>
                    <p>Hanging with my friends - <asp:Label ID="q4a3_lbl" runat="server"></asp:Label></p>
                    <%--<p>Maybe so - <asp:Label ID="q4a4_lbl" runat="server"></asp:Label></p>--%>

                <h4 class="Voting_System_Questions_H4">#5. I would describe my volunteer as:</h4>

                    <p>Okay - <asp:Label ID="q5a1_lbl" runat="server"></asp:Label></p>
                    <p>Great - <asp:Label ID="q5a2_lbl" runat="server"></asp:Label></p>
                    <p>Fantastic - <asp:Label ID="q5a3_lbl" runat="server"></asp:Label></p>
                    <%--<p>Mayor - <asp:Label ID="q5a4_lbl" runat="server"></asp:Label></p> --%> 
                
                <h4 class="Voting_System_Questions_H4">#6. Would you like to come back to Enterprise Village?</h4>
                    <p>Yes - <asp:Label ID="q6a1_lbl" runat="server"></asp:Label></p>
                    <p>No - <asp:Label ID="q6a2_lbl" runat="server"></asp:Label></p>
                    <%--<p>Maybe - <asp:Label ID="q6a3_lbl" runat="server"></asp:Label></p>--%>
            </div>
            <br />
            <asp:HiddenField ID="visitdate_hf" runat="server" />   
        </div>
           
        <script src="../../Scripts.js"></script>
        <script src="https://cdn.canvasjs.com/canvasjs.min.js"> </script>
        <script type="text/javascript">
            window.onload = function () {

            var chart = new CanvasJS.Chart("chartContainer", {
	            theme: "light1", // "light2", "dark1", "dark2"
	            animationEnabled: false, // change to true		
	            title:{
		            text: "Basic Column Chart"
	            },
	            data: [
	            {
		            // Change type to "bar", "area", "spline", "pie",etc.
		            type: "column",
		            dataPoints: [
			            { label: "apple",  y: 10  },
			            { label: "orange", y: 15  },
			            { label: "banana", y: 25  },
			            { label: "mango",  y: 30  },
			            { label: "grape",  y: 28  }
		            ]
	            }
	            ]
            });
            chart.render();

            }
        </script>

    </form>
</body>
</html>
