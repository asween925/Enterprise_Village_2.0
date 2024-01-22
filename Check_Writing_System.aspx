<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Check_Writing_System.aspx.vb" Inherits="Enterprise_Village_2._0.Check_Writing_System" %>

<!doctype html>
<html>
<head runat="server">

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">
    <title>Check Writing System</title>

    <link href="css/Styles.Utility.css" rel="stylesheet" type="text/css">
    <link rel="shortcut icon" type="image/png" href="media/EV_favicon_2.png" />

    <style>
        .select {
        }

            .select option:checked {
                text-decoration: line-through;
            }
    </style>
</head>

<body>
    <form id="Online_Banking_Form" runat="server">
        <div id="site_wrap">
            <div class="header1 no-print">

                <img class="EV no-print" alt="Enterprise Village" src="Images/EV2.0_PCSB.png">
            </div>

            <div class="header2 no-print">
                <h2>Payroll Checks</h2>
            </div>

            <div class="header3 no-print">
                <asp:Image ID="BusLogo_img" runat="server" Class="Business_logo" />
            </div>

            <%--Content--%>
            <div class="main_base" runat="server" id="check_system">
                <br />

                <%--Help Window--%>
                <div id="help_div" runat="server" visible="false" class="no-print">
                    <div id="help_header">
                        Payroll Checks Directions
                        <asp:Button ID="close_btn" runat="server" CssClass="close_button" Text="X" />
                    </div>
                    <ol class="help_list">
                        <li class="help_list_item">Click the yellow 'Ditek Check' button.</li>
                        <li class="help_list_item">After printing and signing the Ditek check, select 'Payroll 1' from the drop down menu located under the yellow buttons.</li>
                        <li class="help_list_item">The drop down menu inside the check will be enabled. Select an employee from the list.</li>
                        <li class="help_list_item">Select their pay from the drop down menu to the right of the employee name.</li>
                        <li class="help_list_item">The written amount on the check will fill out automatically after selecting a pay. Click the blue 'Save Check' button below the check.</li>
                        <li class="help_list_item">Repeat Steps 3-5 until you have saved a check for each person in your business.</li>
                        <li class="help_list_item">When you have a check for each person, click the green 'Review' button.</li>
                        <li class="help_list_item">You can see your saved checks by using the arrow buttons. If you made a mistake, click the 'Delete' button on the check you messed up on and click the blue 'Add Check' button to make another check. .</li>
                        <li class="help_list_item">When you have finished reviewing the checks, select a group of names from the drop down menu above the 'Print' button and click 'Print'.</li>
                        <li class="help_list_item">Click 'Print' when the print screen appears.</li>
                        <li class="help_list_item">After printing, select a new Payroll group from the drop down menu at the top, and repeat Steps 3-10.</li>
                        <li class="help_list_item">After printing the checks from Payroll 1, 2, and 3, click the yellow 'Business Operation Checks' button at the top to continue.</li>
                    </ol>
                </div>

                <%--Content--%>
                <asp:HyperLink ID="F3URL" runat="server" CssClass="ditek_print_button" Text="Ditek Check"></asp:HyperLink>
                <asp:HyperLink ID="F1URL" runat="server" CssClass="ditek_print_button" Text="Business Operating Checks"> </asp:HyperLink>
                <asp:HyperLink ID="F2URL" runat="server" CssClass="ditek_print_button" Text="Online Banking"> </asp:HyperLink>

                <br />
                <div class="Check_counter">
                    <asp:Label ID="Label2" runat="server" Text="Number of Checks for Selected Pay Period: " Font-Bold="true" CssClass="no-print"></asp:Label>
                    <asp:Label ID="Check_que_lbl" runat="server" Text="0" CssClass=" no-print" ForeColor="Red" Font-Bold="true"></asp:Label>
                    <br />
                    <br />
                    <asp:DropDownList ID="Check_selector_ddl" runat="server" AutoPostBack="True" Font-Size="Medium" CssClass="ddl no-print">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem Text="Payroll 1" Value="Payroll 1"></asp:ListItem>
                        <asp:ListItem Text="Payroll 2" Value="Payroll 2"></asp:ListItem>
                        <asp:ListItem Text="Payroll 3" Value="Payroll 3"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <br />
                <div class="Account_area">

                    <%--Check--%>
                    <div class="Check_creation">
                        <asp:Label ID="Label1" runat="server" Text=" " CssClass="Check_number"></asp:Label>
                        <asp:Label ID="business_name_lbl" runat="server" Text="Business Name" CssClass="Check_business_name"></asp:Label>
                        <br />
                        <asp:Label ID="address_lbl" runat="server" Text="Business Address" CssClass="Business_address"></asp:Label>
                        <asp:Label ID="Label_date" runat="server" Text="1/01/2021" CssClass="Check_date" Font-Underline="True"></asp:Label>
                        <asp:Label ID="Label5" runat="server" Text="DATE" CssClass="Check_date_text"></asp:Label>
                        <br class="no_break" />
                        <br class="no_break" />
                        <br class="no-break1 no-break" />
                        <asp:Label ID="Label6" runat="server" Text="Pay to the order of: " CssClass="Pay_to_the"></asp:Label>
                        <asp:DropDownList ID="students_ddl" runat="server" Width="53%" CssClass="ddl2 Student_name" AutoPostBack="true">
                        </asp:DropDownList>
                        <asp:DropDownList ID="Position_ddl" runat="server" Width="70px" Style="text-align: center" CssClass="ddl2 Check_textbox1 Amount_of_check" text='<%#Bind("Employee_position") %>' AutoPostBack="True">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>$7.00</asp:ListItem>
                            <asp:ListItem>$6.50</asp:ListItem>
                            <asp:ListItem>$6.00</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <br />
                        <asp:TextBox ID="Written_amount_tb" runat="server" CssClass="Check_amount_written Check_textbox2" ReadOnly="True"></asp:TextBox>
                        <asp:Label ID="Label8" runat="server" Text="DOLLARS" CssClass="Dollars_text"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Memo" runat="server" Text="Memo" CssClass="Memo"></asp:Label>
                        <asp:DropDownList ID="memo_ddl" runat="server" Width="100px" CssClass="ddl2 Student_name1 Check_textbox1" text='<%#Bind("Employee_position") %>'>
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Payroll 1</asp:ListItem>
                            <asp:ListItem>Payroll 2</asp:ListItem>
                            <asp:ListItem>Payroll 3</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="Label9" runat="server" Text="__________________________________________________" CssClass="Sign_line" Font-Underline="True"></asp:Label>
                        <br>
                        <p class="Bottom_check">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;001001 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 011900357 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 12345678 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        </p>
                    </div>
                    <br />
                    <%--Check Controls--%>
                    <br class="no_break" />
                    <asp:Button ID="save_check_btn" runat="server" Text="Save Check" class="button3 no-print" ForeColor="white" />
                    &ensp;
                    <asp:Button ID="help_btn" runat="server" Text="Help" class="button3_help no-print" />
                    <br />
                    <asp:Label ID="error_lbl" runat="server" ForeColor="Red" Font-Bold="true" CssClass="error_lbl no-print"></asp:Label>
                    <asp:Label ID="Label3" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                    <div class="Check_edits">
                        <h3 class="no-print h3text">Check Review</h3>
                        <%--<asp:DropDownList ID="checkgroup_ddl" runat="server" Width="150px" Font-Size="Medium" AutoPostBack="True"></asp:DropDownList>
                        <br />
                        <br />--%>
                        <asp:Button ID="Print_checks_btn" runat="server" Text="Review" class="print_button no-print" />
                        <br />
                        <br />
                        <asp:Button ID="Previous_btn" runat="server" Text="⬅" class="arrow_buttons no-print" ForeColor="White" OnClientClick="" />
                        <asp:Button ID="Next_btn" runat="server" Text="➡" class="arrow_buttons no-print" ForeColor="White" OnClientClick="" />
                        <br />
                        <asp:Button ID="Delete_Current_btn" runat="server" Text="Delete" class="delete_button no-print" />
                        <br />
                        <br />

                    </div>

                </div>
            </div>

            <div class="second no-print">
                <asp:GridView ID="existingChecks_dgv" runat="server" PageSize="100" Visible="false" ShowHeaderWhenEmpty="True"></asp:GridView>
                <div id="ditekCheckLists_div" runat="server">
                    <h5>Step 1:<br />
                        Print Ditek check(s).
                    </h5>

                    <h6 class="check_second6" style="padding-bottom: 0px; margin-bottom: 0px;">1.&nbsp;<input id="Checkbox11" runat="server" type="checkbox" class="Checkboxes" />&nbsp;&nbsp;Ditek ($5.00 for supplies)</h6>
                    <h7 class="check_second7 no-print" runat="server" id="ditekdir" visible="false">
                        &emsp;&emsp;a.
                    <input id="Checkbox2" runat="server" type="checkbox" class="Checkboxes" />
                        UPS Ditek</h7><br />
                    <h7 class="check_second7 no-print" runat="server" id="ditekdir1" visible="false">
                        &emsp;&emsp;b.
                    <input id="Checkbox6" runat="server" type="checkbox" class="Checkboxes" />
                        Dali Ditek</h7><br />
                    <h7 class="check_second7 no-print" runat="server" id="ditekdir2" visible="false">
                        &emsp;&emsp;c.
                    <input id="Checkbox7" runat="server" type="checkbox" class="Checkboxes" />
                        PCU Ditek</h7>
                </div>
                <h5 style="border-top: 1px dashed black">Step <span id="step2header_h5" runat="server" >2</span>:
                    <br />
                    Fill out salary checks.
                </h5>

                <h6 class="check_second6">2.&nbsp;<asp:CheckBox ID="CheckBox1" runat="server" />&nbsp;&nbsp;Print and sign first set of <strong>Salary Checks </strong>(Payroll 1)</h6>
                <h6 class="check_second6">3.&nbsp;<asp:CheckBox ID="CheckBox3" runat="server" />&nbsp;&nbsp;Print <strong>DIRECT DEPOSIT</strong> receipts (Payroll 2)</h6>
                <h6 class="check_second6">4.&nbsp;<asp:CheckBox ID="CheckBox4" runat="server" />&nbsp;&nbsp;Print and sign third set of <strong>Salary Checks </strong>(Payroll 3)</h6>

                <h5 style="border-top: 1px dashed black">After printing and signing ALL of the Salary Checks, click on the yellow 'Business Operating Checks' button.</h5>

                <!--
          Need a way for user to acknowledge if the print was sucessful or not
          Need to consider ways to prompt after 4 checks
          <h4>Student dropdown list needs to pull for only the business and be ordered</h4>
      <h4>Check check number be random or change in increments</h4>
      <h4>MICR Fonts is font for text at bottom</h4>
      <h4>Have system work in batches of checks. After printing payroll 1, start fresh and work payroll 2.</h4> -->
                <asp:Label ID="strikeout_lbl" runat="server" Visible="true" Text=""></asp:Label>
            </div>

            <div class="footer3 no-print">
                <asp:HiddenField ID="visitdate_hf" runat="server" />
                <asp:HiddenField ID="businessID_hf" runat="server" />
                <asp:HiddenField ID="checkID_hf" runat="server" />
            </div>


        </div>
        <script src="Scripts.js"></script>
        <script type="text/javascript">
            function DitekCheck2() {
                javascript: var myWindow = window.open("a6351sfp:1337/ditek_check.aspx");
                javascript: myWindow.print();
            }
        </script>
        <script type="text/javascript">
            // Make the DIV element draggable:
            dragElement(document.getElementById("myDiv"));

            function dragElement(elmnt) {
                var pos1 = 0, pos2 = 0, pos3 = 0, pos4 = 0;
                if (document.getElementById(elmnt.id + "header")) {
                    // if present, the header is where you move the DIV from:
                    document.getElementById(elmnt.id + "header").onmousedown = dragMouseDown;
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
        </script>

        <asp:HiddenField ID="visitID_hf" runat="server" />
        <asp:HiddenField ID="tablemaxRow_hf" runat="server" Value="0" />
        <asp:HiddenField ID="tablerowIndex_hf" runat="server" Value="0" />
        <asp:HiddenField ID="strikeout_hf" runat="server" />
        <br />
    </form>
</body>
</html>
