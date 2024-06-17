<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Input_Student_Information.aspx.vb" MaintainScrollPositionOnPostback="true" Inherits="Enterprise_Village_2._0.Input_Student_Information" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>Enterprise Village - Input Student Information</title>

    <link href="~/css/Styles.updated.css" rel="stylesheet" media="screen" type="text/css">
    <link href="~/css/Styles.print.css" rel="stylesheet" media="print" type="text/css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <link rel="shortcut icon" type="image/png" href="media/EV_favicon_2.png" />
</head>

<body onafterprint="javascript:ResetPage();">
    <form autocomplete="off"  id="Online_Banking_Form" runat="server">

        <%--Header information--%>
        <div class="no-print" id="header-e1">
            Enterprise Village 2.0
        </div>
        <div class="no-print" id="header-e3">
            <asp:Label ID="headerSchoolName_lbl" Text="Welcome Teachers!" runat="server"></asp:Label>
        </div>
        <div class="no-print" id="header-e2">
            &nbsp;
        </div>
        <%--<header class="headerTop"><a style="float: left; padding-top: 2px;">Enterprise Village 2.0</a><a style="float: right; padding-right: 30px; padding-top: 2px;"><asp:Label ID="headerSchoolName_lbl" Text="Welcome, teachers!" runat="server"></asp:Label></a></header>--%>

        <div class="content_ISI" id="Screen1">
            <h2 class="h2 no-print" style="text-align: center;">Enterprise Village Student Input</h2>
            <h3 class="no-print">Welcome to Enterprise Village!
                <br />
                <br />
                To get started, select a business from the drop down menu below and input your student's first and last name into the position assigned by them.
                <br />
                <br />
                Click 'Edit' on the left side of each row to make changes and when you are done for that student, click 'Update'. When you are finished, click the blue 'Submit' button below to confirm your student's names into our system.
                <br />
                <br />
                Please consult the staffing model to place your students in the correct business.
            </h3>

            <p>Visit Information for Enterprise Village:</p>
            <asp:Label ID="Schools_lbl" runat="server" Font-Size="XX-Large" Font-Underline="false" ></asp:Label>
            <asp:Label ID="Schools2_lbl" runat="server" Font-Size="XX-Large" Font-Underline="false" ></asp:Label>
            <asp:Label ID="Schools3_lbl" runat="server" Font-Size="XX-Large" Font-Underline="false" ></asp:Label>
            <asp:Label ID="Schools4_lbl" runat="server" Font-Size="XX-Large" Font-Underline="false" ></asp:Label>
            <asp:Label ID="Schools5_lbl" runat="server" Font-Size="XX-Large" Font-Underline="false" ></asp:Label>
            <asp:Label ID="visitDate_lbl" runat="server" Font-Size="XX-Large" Font-Underline="false" ></asp:Label>
            <br />
            <p class="no-print" >Select Business</p>
            <asp:DropDownList ID="business_ddl" CssClass="ddl no-print" runat="server" Width="200px" AutoPostBack="true"></asp:DropDownList>
            <br />
            <br />
            <div class="gridview">
                <asp:GridView ID="Review_dgv" CssClass="no-print" runat="server" Height="77%" AutoGenerateColumns="False" AutoGenerateEditButton="True" CellPadding="5" CellSpacing="1" PageSize="20" DataKeyNames="ID" AllowPaging="True" ShowHeaderWhenEmpty="True" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                        <asp:TemplateField HeaderText="Business Name">
                            <ItemTemplate>
                                <asp:Label ID="business_lbl" runat="server" Text='<%#Bind("BusinessID") %>' Visible="false" />
                                <asp:DropDownList CssClass="ddl" ID="business_ddl" runat="server" Width="200px" OnSelectedIndexChanged="BusinessSelectedIndexChanged" AutoPostBack="false" Enabled="false">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Account Number">
                            <ItemTemplate>
                                <asp:TextBox ID="empNum_tb" runat="server" Width="100px" Text='<%#Bind("accountNumber") %>' ReadOnly="true" Enabled="false" CssClass="textbox"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Student First Name">
                            <ItemTemplate>
                                <asp:TextBox ID="Employee_first_name_tb" runat="server" Width="100px" Text='<%#Bind("firstname") %>' CssClass="textbox"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Student Last Name">
                            <ItemTemplate>
                                <asp:TextBox ID="lastName_tb" runat="server" Width="100px" Text='<%#Bind("lastname") %>' CssClass="textbox"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Position">
                            <ItemTemplate>
                                <asp:Label ID="job_lbl" runat="server" Text='<%#Bind("jobid") %>' Visible="false" />
                                <asp:DropDownList CssClass="ddl" ID="job_ddl" runat="server" Width="200px" Enabled="false">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="School Name" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="schoolID_lbl" runat="server" Text='<%#Bind("schoolID") %>' Visible="false" />
                                <asp:DropDownList CssClass="ddl" ID="schoolName_ddl" runat="server" Width="200px" ReadOnly="true" Visible="false">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:GridView ID="employees_dgv" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" CellPadding="5" CellSpacing="1" PageSize="20" Font-Size="Medium" Visible="false">
                    <AlternatingRowStyle BackColor="#99CCFF" />
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />                       
                        <asp:BoundField DataField="businessName" HeaderText="Business Name" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="accountNumber" HeaderText="Account Number" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="firstName" HeaderText="First Name" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="lastName" HeaderText="Last Name" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="jobTitle" HeaderText="Position" ReadOnly="true" Visible="true" />                        
                        <asp:BoundField DataField="schoolName" HeaderText="School Name" ReadOnly="true" Visible="false" />
                    </Columns>
                </asp:GridView>
                <br />
                <asp:Button ID="submit_btn" runat="server" CssClass="button3 no-print" Text="Submit" /><asp:Button ID="print_btn" runat="server" CssClass="button3 no-print" Text="Print"/><asp:Button ID="teacherHome_btn" runat="server" CssClass="button3 no-print" Text="Back to Home" /><asp:Button ID="logout_btn" runat="server" CssClass="button3 no-print" Text="Log Out"/>
                <br />
                <asp:Label ID="error_lbl" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                <br />
                <p class="no-print">Click <a id="email1_a" runat="server" onserverclick="Email1_a_Click">here</a> to ask us a question, or email us at stavrosinstitute@pcsb.org!</p>
            </div>
            <br />
        </div>

        <%--Confirmation Screen--%>
        <div class="content_ISI2 no-print" id="Screen2" style="text-align: center;">
            <h2 class="h2" style="text-align: center;">Enterprise Village Student Input</h2>
            <h3 style="text-align: center;">Are you sure you want to confirm these students into Enterprise Village database?<br /><br />
                When you click confirm, <a style="font-weight: bold;">your default email application (Ex. Outlook) will open with an email filled out confirming your visit and your students will be in our database ready for that day.</a><br /><br />
                If your email application does not open after clicking confirm, please email tomlinl@pcsb.org to confirm your visit and students entered.
            </h3>
            <asp:Button ID="confirm_btn" runat="server" CssClass="button3" Text="Confirm & Print" /><asp:Button ID="back_btn" runat="server" Text="Go Back" CssClass="button3" />
            <br />
            <br />
            <asp:Label ID="error_lbl2" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="X-Large"></asp:Label>
            <br />
            <p>Click <a id="email2_a" runat="server" onserverclick="Email2_a_Click">here</a> to ask us a question, or email us at stavrosinstitute@pcsb.org!</p>
        </div>

        <asp:HiddenField ID="replyBy" runat="server" />
        <asp:HiddenField ID="visitID_hf" runat="server" />
        <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
        <script src="../../Scripts.js"></script>
        <script>
            /* Loop through all dropdown buttons to toggle between hiding and showing its dropdown content - This allows the user to have multiple dropdowns without any conflict */
            $(".sub-menu ul").hide();
            $(".sub-menu a").click(function () {
                $(this).parent(".sub-menu").children("ul").slideToggle("100");
                $(this).find(".right").toggleClass("fa-caret-up fa-caret-down");
            });
        </script>
        <script type="text/javascript">
            const email = message.emailId;
            const subject = message.subject;
            const emailBody = "Hi " + message.from;
            document.location =
                "mailto:" + email + "?subject=" + subject + "&body=" + emailBody;
        </script>

        <asp:SqlDataSource ID="Review_sds" runat="server"></asp:SqlDataSource>
    </form>
</body>
</html>
