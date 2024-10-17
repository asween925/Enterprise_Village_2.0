<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Voting_System.aspx.vb" Inherits="Enterprise_Village_2._0.Voting_System" MaintainScrollPositionOnPostback="false" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>Voting System</title>

    <link href="~/css/Styles.StudentPages.css" rel="stylesheet" type="text/css">
    <%--look in this css file for body and h3 tags--%>
    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png" />

</head>

<body class="Voting_System_Body">
    <form autocomplete="off"  id="Voting_System" runat="server">
        <div id="Site_Wrap_Fullscreen">

            <h3 style="text-decoration: none; font-style: italic;">Enterprise Village Voting System</h3>
            
            <%--Start Up Screen--%>
            <div id="Voting_System_Main_Page">
                <asp:Label ID="error_lbl" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                <h4>Account Number:</h4>
                <asp:TextBox ID="acctNum_tb" runat="server" CssClass="textbox Voting_System_Textbox" TextMode="Number"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="enterAcct_btn" runat="server" CssClass="button3" Text="Enter Account Number" />
            </div>

            <%--Question Screen--%>
            <div id="Voting_System_Questions_Page">

                <div class="Voting_System_Questions_Name">
                    <p><a style="font-weight: bold;">Employee Name: <asp:Label ID="employeeName_lbl" runat="server" Font-Bold="false"></asp:Label></a>&ensp;<a style="font-weight: bold;">Account Number: <asp:Label ID="acctNum_lbl" runat="server" Font-Bold="false"></asp:Label></a></p>
                    <br />
                </div>
                <asp:Label ID="questionsError_lbl" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                <h4 class="Voting_System_Questions_H4">#1. 1)	How would you rate your day at Enterprise Village? (out of 4 stars, 4 being the best)</h4>
                <div class="Voting_System_Radio_Buttons">
                    <asp:RadioButton ID="q1a1_rdo" runat="server" GroupName="Q1" Text="4 stars" /><br />
                    <asp:RadioButton ID="q1a2_rdo" runat="server" GroupName="Q1" Text="3 stars" /><br />
                    <asp:RadioButton ID="q1a3_rdo" runat="server" GroupName="Q1" Text="2 stars" /><br />
                    <asp:RadioButton ID="q1a4_rdo" runat="server" GroupName="Q1" Text="1 star" />
                </div>

                <h4 class="Voting_System_Questions_H4">#2. What have you liked most about being at Enterprise Village today?</h4>
                <div class="Voting_System_Radio_Buttons">
                    <asp:RadioButton ID="q2a1_rdo" runat="server" GroupName="Q2" Text="My job" /> <br />
                    <asp:RadioButton ID="q2a2_rdo" runat="server" GroupName="Q2" Text="Lunch" /> <br />
                    <asp:RadioButton ID="q2a3_rdo" runat="server" GroupName="Q2" Text="Spending the money I earned" /><br />
                    <asp:RadioButton ID="q2a4_rdo" runat="server" GroupName="Q2" Text="Interacting with other citizens in their businesses" />
                </div>

                <h4 class="Voting_System_Questions_H4">#3. Do you know more about earning and spending money?</h4>
                <div class="Voting_System_Radio_Buttons">
                    <asp:RadioButton ID="q3a1_rdo" runat="server" GroupName="Q3" Text="Yes" /> <br />
                    <asp:RadioButton ID="q3a2_rdo" runat="server" GroupName="Q3" Text="No" /> <br />
                    <%--<asp:RadioButton ID="q3a3_rdo" runat="server" GroupName="Q3" Text="I don't know" /><br />--%>
                    <%--<asp:RadioButton ID="q3a4_rdo" runat="server" GroupName="Q3" Text="All of the above" /> --%>
                </div>

                <h4 class="Voting_System_Questions_H4">#4. Do you have a better understanding of what it means to have a job?</h4>
                <div class="Voting_System_Radio_Buttons">
                    <asp:RadioButton ID="q4a1_rdo" runat="server" GroupName="Q4" Text="Yes" /> <br />
                    <asp:RadioButton ID="q4a2_rdo" runat="server" GroupName="Q4" Text="No" /> <br />
                    <%--<asp:RadioButton ID="q4a3_rdo" runat="server" GroupName="Q4" Text="Hanging with my friends" /> <br />--%>
                    <%--<asp:RadioButton ID="q4a4_rdo" runat="server" GroupName="Q4" Text="Maybe so" />--%>
                </div>

                <h4 class="Voting_System_Questions_H4">#5. I will think more about managing money in the future:</h4>
                <div class="Voting_System_Radio_Buttons">
                    <asp:RadioButton ID="q5a1_rdo" runat="server" GroupName="Q5" Text="Often" /> <br />
                    <asp:RadioButton ID="q5a2_rdo" runat="server" GroupName="Q5" Text="Sometimes" /><br />
                    <asp:RadioButton ID="q5a3_rdo" runat="server" GroupName="Q5" Text="Never" /> <br />
                    <%--<asp:RadioButton ID="q5a4_rdo" runat="server" GroupName="Q5" Text="Mayor" /> --%>
                </div>

                <h4 class="Voting_System_Questions_H4">#6. Are you interested in learning more about the businesses and careers that you interacted with today at Enterprise Village?</h4>
                <div class="Voting_System_Radio_Buttons">
                    <asp:RadioButton ID="q6a1_rdo" runat="server" GroupName="Q6" Text="Yes" /> <br />
                    <asp:RadioButton ID="q6a2_rdo" runat="server" GroupName="Q6" Text="No" /> <br />
                    <%--<asp:RadioButton ID="q6a3_rdo" runat="server" GroupName="Q6" Text="Transfer Timed Savings" /> <br />--%>
                    <%--<asp:RadioButton ID="q6a4_rdo" runat="server" GroupName="Q6" Text="Time To Save" />--%>
                </div>

                <%--<h4 class="Voting_System_Questions_H4">#6. Would you like to come back to Enterprise Village?</h4>
                <div class="Voting_System_Radio_Buttons">
                    <asp:RadioButton ID="q6a1_rdo" runat="server" GroupName="Q6" Text="Yes" /> <br />
                    <asp:RadioButton ID="q6a2_rdo" runat="server" GroupName="Q6" Text="No" /> <br />
                    <asp:RadioButton ID="q6a3_rdo" runat="server" GroupName="Q6" Text="Maybe" />
                </div>--%>

                <br />
                <div style="text-align: center;">
                    <asp:Button ID="submit_btn" runat="server" Text="Cast Your Vote" CssClass="Voting_System_Vote_Button" />&ensp;<asp:Button ID="cancel_btn" runat="server" Text="Cancel Vote" CssClass="Voting_System_Cancel_Button" />
                </div>
                
            </div>

            <asp:HiddenField ID="visitdate_hf" runat="server" />
        </div>

        <script src="../../Scripts.js"></script>

    </form>
</body>
</html>
