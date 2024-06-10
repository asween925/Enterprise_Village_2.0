<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Teacher_Letter.aspx.vb" Inherits="Enterprise_Village_2._0.Teacher_Letter" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>EV 2.0 - Teacher Letter</title>

    <link href="~/css/Styles.updated.css" rel="stylesheet" media="screen" type="text/css">
    <link href="~/css/Styles.print.css" rel="stylesheet" media="print" type="text/css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png" />
    <script src="https://code.jquery.com/jquery-1.10.2.js"></script>
</head>

<body>
    <form autocomplete="off"  id="EMS_Form" runat="server">

        <%--Header information--%>
        <header class="headerTop no-print"><a style="float: left; padding-top: 2px;">Enterprise Village 2.0</a><a style="float: right; padding-right: 30px; padding-top: 2px;"><asp:Label ID="headerSchoolName_lbl" Text="School Name Here" runat="server"></asp:Label></a></header>

       <%--Navigation bar--%>
        <div id="nav-placeholder" class="no-print">

        </div>

        <script>
            $(function () {
                $("#nav-placeholder").load("../../nav.html");
            });
        </script>      

        <%--Content--%>
        <div class="content">
            <h2 class="h2 no-print">Teacher Letter</h2>
            <h3 class="no-print">This page is the teacher letter that gets sent out to the teachers coming to Enterprise Village. Please select a date, school, and teacher and save the letter as a PDF. When the print window appears, select Save as PDF under printers.</h3>
            <p class="no-print">Visit Date:</p>
            <asp:TextBox ID="visitDate_tb" runat="server" TextMode="Date" AutoPostBack="true" CssClass="textbox no-print"></asp:TextBox>&emsp;<asp:Label runat="server" ID="error_lbl" Font-Size="X-Large" ForeColor="Red" CssClass="no-print"></asp:Label>
            <p runat="server" id="school_p" visible="false" class="no-print">School Name:</p>
            <asp:DropDownList ID="schoolName_ddl" runat="server" Visible="false" AutoPostBack="true" CssClass="ddl no-print"></asp:DropDownList>
            <p runat="server" id="teacher_p" visible="false" class="no-print">Teacher Name:</p>
            <asp:DropDownList ID="teacherName_ddl" runat="server" Visible="false" AutoPostBack="true" CssClass="ddl no-print"></asp:DropDownList>
            <br class="no-print" />
            <br class="no-print" />

            <asp:Button ID="print_btn" runat="server" Text="Save as PDF" CssClass="button3 button3 no-print" Visible="false" />

            <div id="info_div" runat="server" visible="false">
                <h3 style="text-align: center;">IMPORTANT INFORMATION! PLEASE READ!</h3>
                <br class="no-print"/>
                <p>
                    School:
                    <asp:Label ID="schoolName_lbl" runat="server" Font-Bold="true"></asp:Label>&emsp; EV Visit:
                    <asp:Label ID="visitDate_lbl" runat="server" Font-Bold="true"></asp:Label>&emsp; Arr. Time:
                    <asp:Label ID="studentArrivalTime_lbl" runat="server" Font-Bold="true"></asp:Label>&emsp; Dis. Time:
                    <asp:Label ID="studentDismissalTime_lbl" runat="server" Font-Bold="true"></asp:Label>
                </p>
                <p>
                    Sharing Schools:
                    <asp:Label ID="sharingSchool_lbl" runat="server" Font-Bold="true" Visible="false" ></asp:Label>
                    <asp:Label ID="schoolName2_lbl" runat="server" Font-Bold="true" Visible="false"></asp:Label>
                    <asp:Label ID="schoolName3_lbl" runat="server" Font-Bold="true" Visible="false"></asp:Label>
                    <asp:Label ID="schoolName4_lbl" runat="server" Font-Bold="true" Visible="false"></asp:Label>
                    <asp:Label ID="schoolName5_lbl" runat="server" Font-Bold="true" Visible="false"></asp:Label>
                    <asp:Label ID="sharingSchoolString_lbl" runat="server" Font-Bold="true"></asp:Label>
                </p>
                <p>
                    Teacher:
                    <asp:Label ID="teacherName_lbl" runat="server" Font-Bold="true"></asp:Label><a class="no-print">&ensp;</a>
                    Number of students: <asp:Label ID="studentCount_lbl" runat="server" Font-Bold="true"></asp:Label>
                    <%--<asp:Label ID="sharingSchool_lbl" runat="server" Font-Bold="true"></asp:Label>--%>
                </p>
                <p style="font-weight: bold;">1. Your assigned businesses will be marked with a "✓". Never close a business without contacting tomlinl@pcsb.org OR campognif@pcsb.org.</p>
                
                <div>
                    <table class="tg">                      
                        <tbody>
                            <tr>
                                <td class="tg-hfk9"><asp:CheckBox ID="ach_chk" runat="server" Text="Achieva Credit Union" Enabled="false"/></td>                              
                                <td class="tg-hfk9"><asp:CheckBox ID="cvs_chk" runat="server" Text="CVS" Enabled="false"/></td>
                                <td class="tg-hfk9"><asp:CheckBox ID="pcsw_chk" runat="server" Text="PC Solid Waste" Enabled="false"/></td>
                            </tr>
                            <tr>
                                <td class="tg-hfk9"><asp:CheckBox ID="astro_chk" runat="server" Text="Astro Skate" Enabled="false" /></td>
                                <td class="tg-hfk9"><asp:CheckBox ID="ditek_chk" runat="server" Text="Ditek" Enabled="false"/></td>
                                <td class="tg-hfk9"><asp:CheckBox ID="know_chk" runat="server" Text="KnowBe4" Enabled="false"/></td>
                            </tr>
                            <tr>
                                <td class="tg-hfk9"><asp:CheckBox ID="baycare_chk" runat="server" Text="BayCare" Enabled="false"/></td>
                                <td class="tg-hfk9"><asp:CheckBox ID="duke_chk" runat="server" Text="Duke Energy" Enabled="false"/></td>
                                <td class="tg-hfk9"><asp:CheckBox ID="bucs_chk" runat="server" Text="Tampa Bay Bucs" Enabled="false"/></td>
                            </tr>
                            <tr>
                                <td class="tg-hfk9"><asp:CheckBox ID="bbb_chk" runat="server" Text="BBB" Enabled="false"/></td>
                                <td class="tg-hfk9"><asp:CheckBox ID="hsn_chk" runat="server" Text="HSN" Enabled="false"/></td>
                                <td class="tg-hfk9"><asp:CheckBox ID="rays_chk" runat="server" Text="Tampa Bay Rays" Enabled="false"/></td>
                            </tr>
                            <tr>
                                <td class="tg-hfk9"><asp:CheckBox ID="bic_chk" runat="server" Text="Koozie Group" Enabled="false"/></td>
                                <td class="tg-hfk9"><asp:CheckBox ID="kanes_chk" runat="server" Text="Kane's" Enabled="false"/></td>
                                <td class="tg-hfk9"><asp:CheckBox ID="times_chk" runat="server" Text="Tampa Bay Times" Enabled="false"/></td>
                            </tr>
                            <tr>
                                <td class="tg-hfk9"><asp:CheckBox ID="city_chk" runat="server" Text="City Hall" Enabled="false"/></td>
                                <td class="tg-hfk9"><asp:CheckBox ID="mcdonalds_chk" runat="server" Text="McDonald's" Enabled="false"/></td>
                                <td class="tg-hfk9"><asp:CheckBox ID="td_chk" runat="server" Text="TD SYNNEX" Enabled="false"/></td>
                            </tr>
                            <tr>
                                <td class="tg-hfk9"><asp:CheckBox ID="mix_chk" runat="server" Text="Mix 100.7" Enabled="false"/></td>
                                <td class="tg-hfk9"><asp:CheckBox ID="united_chk" runat="server" Text="United Way" Enabled="false"/></td>
                                <td class="tg-hfk9"><asp:CheckBox ID="pcu_chk" runat="server" Text="PC Water" Enabled="false"/></td>
                            </tr>
                             <tr>
                                <td class="tg-hfk9"><asp:CheckBox ID="ups_chk" runat="server" Text="UPS" Enabled="false"/></td>
                                <td class="tg-hfk9"><asp:CheckBox ID="dali_chk" runat="server" Text="Dali Art Center" Enabled="false"/></td>
                                <td class="tg-hfk9"></td>
                            </tr>
                        </tbody>
                    </table>
                </div>

                <%--PCSB Teacher Letter--%>
                <div runat="server" id="inCountyLetter_div" visible="false">
                    <p><a style="font-weight: bold;">2. CHECKBOOKS AND DEBIT CARDS:</a> Check registers will be sent along with your cirriculum. Checkbooks should have the student's name and account number written on the front, along with their <a style="font-weight: bold;">first Deposit Ticket filled out and the Net Deposit recorded in their registers.</a> Debit cards and name tags will be issued at EV.</p>
                    <p><a style="font-weight: bold;">3. REMINDERS:</a> Each manager should have an envelope that contains their completed Business Workbook & checkbooks. Teaching Kits must be returned in tact on the day of your visit. <a style="font-weight: bold;">Directions for submitting student articles/stories are in the Teaching Kit.</a></p>
                    <p>
                        <a style="font-weight: bold;">4. VOLUNTEER TRAINING WILL BE HELD THE MORNING OF YOUR VISIT!</a> We ask that volunteers arrive 15 minutes before:
                        <asp:Label ID="vTrainingTime_lbl" runat="server" Font-Bold="true"></asp:Label>. PCSB volunteers must meet Level 1 requirements.
                    </p>
                    <p>
                        <a style="font-weight: bold;">5. VOLUNTEERS NEEDED:
                        <asp:Label ID="vMin_lbl" runat="server" Font-Bold="true"></asp:Label>
                            -
                        <asp:Label ID="vMax_lbl" runat="server" Font-Bold="true"></asp:Label>&emsp; REPLY TO EV BEFORE:
                        <asp:Label ID="replyBy_lbl" runat="server" Font-Bold="true"></asp:Label></a><br />
                        *Business Assignment Sheets and Volunteer List should be returned by the reply date above.<br />
                        *Email EV Questions to Leslie at tomlinl@pcsb.org
                    </p>
                    <p>
                        <a style="font-weight: bold;">6. STUDENT BUSINESS ASSIGNMENTS AND ACCOUNT NUMBERS:</a>
                        Please go to <a style="font-weight: bold;">https://ev.pcsb.org</a> and log in with your standard <a style="font-weight: bold;">PCSB username and password</a> to assign your students to businesses and receive their individual account numbers. <a style="font-weight: bold;">Non-PCSB teachers</a> will log in with the assigned password emailed to them. This needs to be completed BEFORE YOUR SCHEDULED REPLY BY DATE (found above). If you exceed this date, please contact us.
                    </p>
                    <%--<p>
                        <a style="font-weight: bold;">7. TRANSPORTATION:</a>
                         Please contact out front office @ 727-588-3746 to arrange possible transportation needs.
                    </p>--%>
                    <%--<p>--------------------------------------------------------------------------------</p>--%>
                    <p style="font-size: 14px;">Adults and staff may purchase a McDonald's lunch for $3.00. Student lunch is $3.00 which will be collected at school. We will invoice your school after your visit. If a student has medical issues, they can choose to bring a lunch. Any questions call 727-588-3746.</p>
                </div>

                <%--Out of County Letter--%>
                <div runat="server" id="outOfCountyLetter_div" visible="false">
                    <p><a style="font-weight: bold;">2. CHECKBOOKS AND DEBIT CARDS:</a> Check registers will be sent along with your cirriculum. Checkbooks should have the student's name and account number written on the front, along with their <a style="font-weight: bold;">first Deposit Ticket filled out and the Net Deposit recorded in their registers.</a> Debit cards and name tags will be issued at EV.</p>
                    <p><a style="font-weight: bold;">3. REMINDERS:</a> Each manager should have an envelope that contains their completed Business Workbook & checkbooks. Business Assignment Sheets and Volunteer List should be returned by the reply date below. All Volunteers must be Level 1 approved and all Teaching Kits must be returned in tact on the day of your visit.<a style="font-weight: bold;">****Directions for submitting student articles/stories are in the Teaching Kit.</a></p>
                    <p>
                        <a style="font-weight: bold;">4. VOLUNTEER TRAINING WILL BE HELD THE MORNING OF YOUR VISIT!</a> We ask that volunteers arrive 15 minutes before:
                        <asp:Label ID="vTrainingTime2_lbl" runat="server" Font-Bold="true"></asp:Label>.
                    </p>
                    <p>
                        <a style="font-weight: bold;">5. VOLUNTEERS NEEDED:
                        <asp:Label ID="vMin2_lbl" runat="server" Font-Bold="true"></asp:Label>
                            -
                        <asp:Label ID="vMax2_lbl" runat="server" Font-Bold="true"></asp:Label>&emsp; REPLY TO EV BEFORE:
                        <asp:Label ID="replyBy2_lbl" runat="server" Font-Bold="true"></asp:Label></a><br />
                        *Please do not send more volunteers than the number assigned! (Level 1 requirements)<br />
                        *Email EV Questions to Leslie at tomlinl@pcsb.org
                    </p>
                    <p>
                        <a style="font-weight: bold;">6. STUDENT BUSINESS ASSIGNMENTS AND ACCOUNT NUMBERS:</a>
                        Please go to <a style="font-weight: bold;">https://ev.pcsb.org</a> and log in with your standard <a style="font-weight: bold;">PCSB username and password</a> to assign your students to businesses and receive their individual account numbers. <a style="font-weight: bold;">Non-PCSB teachers</a> will log in with the assigned password emailed to them. This needs to be completed BEFORE YOUR SCHEDULED REPLY BY DATE (found above). If you exceed this date, please contact us.
                    </p>
                    <p>
                        <a style="font-weight: bold;">7. TRANSPORTATION:</a>
                        Transportation to and from Enterprise Village is <a style="font-weight: bold;">NOT</a> included in the student fee. Due to budget cuts our transportation for Private and Out of County schools is very limited. Please contact out front office @ 727-588-3746 to arrange possible transportation needs.
                    </p>
                    <%--<p>--------------------------------------------------------------------------------</p>--%>
                    <p style="font-size: 10px;">Adults and staff may purchase a McDonald's lunch for $3.00. Students do NOT pay separately for lunch - their lunch is included in the cost of the field trip. If a student has medical issues, they can choose to bring a lunch. Any questions call 727-588-3746.</p>
                </div>
                    <asp:DropDownList  CssClass="ddl" ID="businessCount_ddl" runat="server" Visible="false">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>21</asp:ListItem>
                        <asp:ListItem>22</asp:ListItem>
                        <asp:ListItem>23</asp:ListItem>
                        <asp:ListItem>24</asp:ListItem>
                    </asp:DropDownList>                            
            </div>
        </div>

        <asp:HiddenField ID="visitdate_hf" runat="server" />
        <asp:HiddenField ID="businessID_hf" runat="server" />
        <asp:HiddenField ID="teacherID_hf" runat="server" />
        <asp:HiddenField ID="schoolID_hf" runat="server" />
        <asp:HiddenField ID="schoolType_hf" runat="server" />

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

        <asp:SqlDataSource ID="Review_sds" runat="server"></asp:SqlDataSource>
    </form>
</body>
</html>


