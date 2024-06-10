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
                <h4 class="Voting_System_Questions_H4">#1. How would you describe your day at Enterprise Village?.</h4>
                <div class="Voting_System_Radio_Buttons">
                    <asp:RadioButton ID="q1a1_rdo" runat="server" GroupName="Q1" Text="OK" /><br />
                    <asp:RadioButton ID="q1a2_rdo" runat="server" GroupName="Q1" Text="Great" /><br />
                    <asp:RadioButton ID="q1a3_rdo" runat="server" GroupName="Q1" Text="Fantastic" /><br />
                    <%--<asp:RadioButton ID="q1a4_rdo" runat="server" GroupName="Q1" Text="My Teacher" />--%>
                </div>

                <h4 class="Voting_System_Questions_H4">#2. Did you enjoy your job today?</h4>
                <div class="Voting_System_Radio_Buttons">
                    <asp:RadioButton ID="q2a1_rdo" runat="server" GroupName="Q2" Text="Yes" /> <br />
                    <asp:RadioButton ID="q2a2_rdo" runat="server" GroupName="Q2" Text="No" /> <br />
                    <asp:RadioButton ID="q2a3_rdo" runat="server" GroupName="Q2" Text="I don't know" /><br />
                    <%--<asp:RadioButton ID="q2a4_rdo" runat="server" GroupName="Q2" Text="Endorsed check and savings ticket" />--%>
                </div>

                <h4 class="Voting_System_Questions_H4">#3. Do you feel you know more about Free Enterprise after your visit today?</h4>
                <div class="Voting_System_Radio_Buttons">
                    <asp:RadioButton ID="q3a1_rdo" runat="server" GroupName="Q3" Text="Yes" /> <br />
                    <asp:RadioButton ID="q3a2_rdo" runat="server" GroupName="Q3" Text="No" /> <br />
                    <asp:RadioButton ID="q3a3_rdo" runat="server" GroupName="Q3" Text="I don't know" /><br />
                    <%--<asp:RadioButton ID="q3a4_rdo" runat="server" GroupName="Q3" Text="All of the above" /> --%>
                </div>

                <h4 class="Voting_System_Questions_H4">#4. What was your favorite part of the day? </h4>
                <div class="Voting_System_Radio_Buttons">
                    <asp:RadioButton ID="q4a1_rdo" runat="server" GroupName="Q4" Text="Spending money" /> <br />
                    <asp:RadioButton ID="q4a2_rdo" runat="server" GroupName="Q4" Text="Lunch" /> <br />
                    <asp:RadioButton ID="q4a3_rdo" runat="server" GroupName="Q4" Text="Hanging with my friends" /> <br />
                    <%--<asp:RadioButton ID="q4a4_rdo" runat="server" GroupName="Q4" Text="Maybe so" />--%>
                </div>

                <h4 class="Voting_System_Questions_H4">#5. I would describe my volunteer as:</h4>
                <div class="Voting_System_Radio_Buttons">
                    <asp:RadioButton ID="q5a1_rdo" runat="server" GroupName="Q5" Text="Okay" /> <br />
                    <asp:RadioButton ID="q5a2_rdo" runat="server" GroupName="Q5" Text="Great" /><br />
                    <asp:RadioButton ID="q5a3_rdo" runat="server" GroupName="Q5" Text="Fantastic" /> <br />
                    <%--<asp:RadioButton ID="q5a4_rdo" runat="server" GroupName="Q5" Text="Mayor" /> --%>
                </div>

                <h4 class="Voting_System_Questions_H4">#6. Would you like to come back to Enterprise Village?</h4>
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
