<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Voting_System.aspx.vb" Inherits="Enterprise_Village_2._0.Voting_System" MaintainScrollPositionOnPostback="false" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>Voting System</title>

    <link href="css/Styles.StudentPages.css" rel="stylesheet" type="text/css">
    <%--look in this css file for body and h3 tags--%>
    <link rel="shortcut icon" type="image/png" href="media/EV_favicon_2.png" />

</head>

<body class="Voting_System_Body">
    <form id="Voting_System" runat="server">
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
                <h4 class="Voting_System_Questions_H4">#1. Identify the person responsible for generating payroll checks.</h4>
                <div class="Voting_System_Radio_Buttons">
                    <asp:RadioButton ID="q1a1_rdo" runat="server" GroupName="Q1" Text="Manager" /><br />
                    <asp:RadioButton ID="q1a2_rdo" runat="server" GroupName="Q1" Text="Financial Officer" /><br />
                    <%--<asp:RadioButton ID="q1a3_rdo" runat="server" GroupName="Q1" Text="The Mayor" /><br />
                    <asp:RadioButton ID="q1a4_rdo" runat="server" GroupName="Q1" Text="My Teacher" />--%>
                </div>

                <h4 class="Voting_System_Questions_H4">#2. Name the two items citizens hand to the teller when they visit Achieva.</h4>
                <div class="Voting_System_Radio_Buttons">
                    <%--<asp:RadioButton ID="q2a1_rdo" runat="server" GroupName="Q2" Text="Dollars and coins" /> <br />--%>
                    <asp:RadioButton ID="q2a2_rdo" runat="server" GroupName="Q2" Text="Debit card and check register" /> <br />
                    <asp:RadioButton ID="q2a3_rdo" runat="server" GroupName="Q2" Text="Deposit ticket and endorsed check" /><br />
                    <%--<asp:RadioButton ID="q2a4_rdo" runat="server" GroupName="Q2" Text="Endorsed check and savings ticket" />--%>
                </div>

                <h4 class="Voting_System_Questions_H4">#3. How does the Enterprise Village experience symbolize citizenship?</h4>
                <div class="Voting_System_Radio_Buttons">
                    <asp:RadioButton ID="q3a1_rdo" runat="server" GroupName="Q3" Text="Citizens follow the rules" /> <br />
                    <asp:RadioButton ID="q3a2_rdo" runat="server" GroupName="Q3" Text="Citizens show responsibility" /> <br />
                    <asp:RadioButton ID="q3a3_rdo" runat="server" GroupName="Q3" Text="Citizens are respectful" /> <br />
                    <asp:RadioButton ID="q3a4_rdo" runat="server" GroupName="Q3" Text="All of the above" /> 
                </div>

                <h4 class="Voting_System_Questions_H4">#4. Would you like to come back to Enterprise Village? </h4>
                <div class="Voting_System_Radio_Buttons">
                    <%--<asp:RadioButton ID="q4a1_rdo" runat="server" GroupName="Q4" Text="Most definitely!" /> <br />--%>
                    <asp:RadioButton ID="q4a2_rdo" runat="server" GroupName="Q4" Text="Yes" /> <br />
                    <asp:RadioButton ID="q4a3_rdo" runat="server" GroupName="Q4" Text="No" /> <br />
                    <%--<asp:RadioButton ID="q4a4_rdo" runat="server" GroupName="Q4" Text="Maybe so" />--%>
                </div>

                <h4 class="Voting_System_Questions_H4">#5. If you were to return to Enterprise Village in the future, what job would you like to experience?</h4>
                <div class="Voting_System_Radio_Buttons">
                    <asp:RadioButton ID="q5a1_rdo" runat="server" GroupName="Q5" Text="The same as today - I loved it!" /> <br />
                    <asp:RadioButton ID="q5a2_rdo" runat="server" GroupName="Q5" Text="Any position! I just want to come back!" /><br />
                    <%--<asp:RadioButton ID="q5a3_rdo" runat="server" GroupName="Q5" Text="Financial Officer" /> <br />
                    <asp:RadioButton ID="q5a4_rdo" runat="server" GroupName="Q5" Text="Mayor" /> --%>
                </div>

                <%--<h4 class="Voting_System_Questions_H4">#6. What does TTS mean?</h4>
                <div class="Voting_System_Radio_Buttons">
                    <asp:RadioButton ID="q6a1_rdo" runat="server" GroupName="Q6" Text="Taco Tuesday for Supper" /> <br />
                    <asp:RadioButton ID="q6a2_rdo" runat="server" GroupName="Q6" Text="Transfer to Savings" /> <br />
                    <asp:RadioButton ID="q6a3_rdo" runat="server" GroupName="Q6" Text="Transfer Timed Savings" /> <br />
                    <asp:RadioButton ID="q6a4_rdo" runat="server" GroupName="Q6" Text="Time To Save" />
                </div>--%>

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

        <script src="Scripts.js"></script>

    </form>
</body>
</html>
