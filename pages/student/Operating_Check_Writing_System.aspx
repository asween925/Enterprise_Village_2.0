<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Operating_Check_Writing_System.aspx.vb" Inherits="Enterprise_Village_2._0.Operating_Check_Writing_System" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!doctype html>
<html>
<head runat="server">

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">
    <title>Operating Check Writing System</title>
    <link href="~/css/Styles.Utility.css" rel="stylesheet" type="text/css">
    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png" />
</head>

<body>
    <form id="Online_Banking_Form" runat="server">
        <div id="site_wrap">
            <div class="header1 no-print">
                <img class="EV no-print" alt="Enterprise Village" src="../../../../Images/EV2.0_PCSB.png">
            </div>

            <div class="header2 no-print">
                <h2>Business Operating Checks</h2>
            </div>

            <div class="header3 no-print">
                <asp:Image ID="BusLogo_img" runat="server" Class="Business_logo" />
            </div>

            <%-- Main Content--%>
            <div class="main_base" id="check_system" runat="server">
                <br />
                 <%--Help Window--%>
                <div id="help_div" runat="server" visible="false" class="no-print">
                    <div id="help_header">
                        Business Operating Checks
                        <asp:Button ID="close_btn" runat="server" CssClass="close_button" Text="X" />
                    </div>
                    <ol class="help_list">
                        <li class="help_list_item">Select an Operating Group from the drop down menu directly below the yellow buttons.</li>
                        <li class="help_list_item">Follow the list on the right side of the screen and enter the check information.</li>
                            <ul>
                                <li class="help_list_item">The name of the business goes into the 'Pay to the order of:' box.</li>
                                <li class="help_list_item">The dollar amount goes into the smaller box next to the business name.</li>
                                <li class="help_list_item">Type out the amount of dollars in the box below the business name. (Example: One Dollar and 00/100)</li>
                                <li class="help_list_item">The memo is found on the right side of the '/' on the side bar, next to the dollar amount. Type that in the box next to where it says 'Memo' on the check.</li>
                            </ul>
                        <li class="help_list_item">Click the blue 'Save Check' button below the check.</li>
                        <li class="help_list_item">Repeat Steps 2 and 3 until you have FOUR checks saved.</li>
                        <li class="help_list_item">Click the green 'Review' button below the 'Save Check' button.</li>
                        <li class="help_list_item">Review your saved checks and make sure there are no errors. Use the black arrow buttons to cycle through your checks and click the red 'Delete' button to erase the check you see in the check window. (If you do delete a check, make sure you make the same one.)</li>
                        <li class="help_list_item">When you have finished reviewing the checks, click the green 'Print' button. (It is in the same spot as the 'Review' button.</li>
                        <li class="help_list_item">Click 'Print' when the print window appears.</li>
                        <li class="help_list_item">After printing, sign your checks.</li>
                        <li class="help_list_item">Select a new Operating Group from the drop down menu at the top and repeat Steps 2-9.</li>                   
                    </ol>
                </div>

                <%--Content--%>
                <asp:HyperLink ID="F1URL" runat="server" CssClass="ditek_print_button" Text="Payroll Checks"> </asp:HyperLink> 
                <asp:HyperLink ID="F2URL" runat="server" CssClass="ditek_print_button" Text="Online Banking"></asp:HyperLink>
                
                <div class="Check_counter">
                    <asp:Label ID="Label2" runat="server" Text="Number of Checks for Selected Operating Group: " Font-Bold="true" CssClass="no-print"></asp:Label>
                    <asp:Label ID="Check_que_lbl" runat="server" Text="0" CssClass=" no-print" ForeColor="Red" Font-Bold="true"></asp:Label>
                    <br /><br />
                    <asp:DropDownList ID="operating_selector_ddl" runat="server" AutoPostBack="True" Font-Size="Medium" CssClass="ddl no-print">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem Text="Operating Group 1" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Operating Group 2" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Operating Group 3" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <br />                           
                <div class="Account_area">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <%--<ajaxToolkit:MaskedEditExtender ID="deposit1_tb_MaskedEditExtender" runat="server" TargetControlID="checkAmount_tb" MaskType="Number" Mask="9.99" InputDirection="LeftToRight" ClearMaskOnLostFocus="false" />--%>
                    <%--Check--%>
                    <div class="Check_creation">
                        <asp:Label ID="Label1" runat="server" Text="    " CssClass="Check_number"></asp:Label>
                        <asp:Label ID="business_name_lbl" runat="server" Text="Business Name" CssClass="Check_business_name"></asp:Label>
                        <br />
                        <asp:Label ID="address_lbl" runat="server" Text="Business Address" CssClass="Business_address"></asp:Label>
                        <asp:Label ID="Label_date" runat="server" Text="1/01/2021" CssClass="Check_date" Font-Underline="True"></asp:Label>
                        <asp:Label ID="Label5" runat="server" Text="DATE" CssClass="Check_date_text"></asp:Label>
                        <br class="no_break"/><br class="no_break"/><br class="no-break1 no-break" />
                        <asp:Label ID="Label6" runat="server" Text="Pay to the order of:" CssClass="Pay_to_the"></asp:Label>
                        <asp:TextBox ID="business_tb" runat="server" Width="53%" CssClass="Student_name Check_textbox1"></asp:TextBox>
                        <asp:TextBox ID="checkAmount_tb" runat="server" Width="70px" CssClass="Check_textbox1 Amount_of_check"></asp:TextBox>
                        <br /><br />
                        <asp:TextBox ID="writtenAmount_tb" runat="server" CssClass="Check_amount_written Check_textbox2" ReadOnly="false"></asp:TextBox>
                        <asp:Label ID="Label8" runat="server" Text="DOLLARS" CssClass="Dollars_text"></asp:Label>
                        <br /><br />
                        <asp:Label ID="Memo" runat="server" Text="Memo" CssClass="Memo"></asp:Label>
                        <asp:TextBox ID="Memo_tb" runat="server" Text="" Width="100px" CssClass="Student_name1 Check_textbox1"></asp:TextBox>
                        <asp:Label ID="Label9" runat="server" Text="______________________________________________" CssClass="Sign_line" Font-Underline="True"></asp:Label>
                        <br />
                        <p class="Bottom_check">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;001001 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 011900357 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 12345678 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        </p>
                    </div>
                    <br />
                    <br class="no_break" />
                    <%--<asp:Button ID="New_check_btn" runat="server" Text="Clear Check" Height="40px" Width="120px" class="button3 no-print" ForeColor="white" />--%>
                    <asp:Button ID="save_check_btn" runat="server" Text="Save Check" class="button3 no-print" ForeColor="white" />&ensp;<asp:Button ID="help_btn" runat="server" Text="Help" class="button3_help no-print" />
                    <br />
                    <asp:Label ID="error_lbl" runat="server" ForeColor="Red" CssClass="error_lbl" Font-Bold="true"></asp:Label>
                    <asp:Label ID="error2_lbl" runat="server" ForeColor="Red" Font-Size="X-Large" Font-Bold="true"></asp:Label>

                    <%--Check review--%>
                    <div class="Check_edits_Operating">
                        <h3 class="no-print h3text">Check Review</h3>
                        <asp:Button ID="Print_checks_btn" runat="server" Text="Review" CssClass="print_button no-print" />
                        <br /><br />      
                        <asp:Button ID="Previous_btn" runat="server" Text="⬅" class="arrow_buttons no-print" ForeColor="White" OnClientClick="" />
                        <asp:Button ID="Next_btn" runat="server" Text="➡" class="arrow_buttons no-print" ForeColor="White" OnClientClick="" />
                        <br />
                        <asp:Button ID="Delete_Current_btn" runat="server" Text="Delete" class="delete_button no-print" />
                        <br />
                        <br />                     
                    </div>
                    <asp:DropDownList ID="checkgroup_ddl" runat="server" Font-Size="Medium" Visible="false" AutoPostBack="True" CssClass="ddl no-print"></asp:DropDownList>
                </div>
            </div>

            <%--Sidebar--%>
            <div class="second no-print">          
                <h5 class="operating_second5" style="border-bottom: 1px solid black">Create, print, and sign all of the checks below.</h5>
                <h6 id="row5" runat="server">5.<input id="Checkbox23" type="checkbox" class="Checkboxes" runat="server" /><asp:Label ID="operating1_lbl" runat="server"></asp:Label></h6>
                <h6>6.<asp:CheckBox ID="CheckBox1" runat="server" /><asp:Label ID="operating2_lbl" runat="server"></asp:Label></h6>
                <h6>7.<input id="Checkbox24" type="checkbox" runat="server" class="Checkboxes" /><asp:Label ID="operating3_lbl" runat="server"></asp:Label></h6>
                <h6>8.<asp:CheckBox ID="CheckBox2" runat="server" /><asp:Label ID="operating4_lbl" runat="server"></asp:Label></h6>

                <h5 class="operating_second5" style="border-bottom: 1px dashed black">Stop! Print and sign Operating Group 1 checks.</h5>

                <h6 style="color: green;">9.<input id="Checkbox32" type="checkbox" runat="server" class="Checkboxes" /><asp:Label ID="operating5_lbl" runat="server"></asp:Label></h6>
                <h6 style="color: green;">10.<asp:CheckBox ID="CheckBox3" runat="server" /><asp:Label ID="operating6_lbl" runat="server"></asp:Label></h6>
                <h6 runat="server" id="row7" style="color: green;">11.<input id="Checkbox44" type="checkbox" runat="server" class="Checkboxes" /><asp:Label ID="operating7_lbl" runat="server"></asp:Label></h6>
                <h6 runat="server" id="row8" style="color: green;">12.<asp:CheckBox ID="CheckBox4" runat="server" /><asp:Label ID="operating8_lbl" runat="server"></asp:Label></h6>

                <h5 class="operating_second5" style="border-bottom: 1px dashed black">Stop! Print and sign Operating Group 2 checks.</h5>

                <h6 runat="server" id="row9" style="color: blue;">13.<input id="Checkbox54" type="checkbox" runat="server" class="Checkboxes" /><asp:Label ID="operating9_lbl" runat="server"></asp:Label></h6>
                <h6 runat="server" id="row10" style="color: blue;">14.<asp:CheckBox ID="CheckBox5" runat="server" /><asp:Label ID="operating10_lbl" runat="server"></asp:Label></h6>
                <h6 runat="server" id="row11" style="color: blue;">15.<input id="Checkbox64" type="checkbox" runat="server" class="Checkboxes" /><asp:Label ID="operating11_lbl" runat="server"></asp:Label></h6>
                <h6 runat="server" id="row12" style="color: blue;">16.<asp:CheckBox ID="CheckBox6" runat="server" /><asp:Label ID="operating12_lbl" runat="server"></asp:Label></h6>

                <h5 class="operating_second5" runat="server" id="rowstop1">Stop! Print and sign Operating Group 3 checks.</h5>

            </div>
            <asp:GridView ID="existingChecks_dgv" runat="server" PageSize="100" Visible="false" ShowHeaderWhenEmpty="True"></asp:GridView>
        </div>

        <script src="../../Scripts.js"></script>
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
        <asp:HiddenField ID="tablerowIndex_hf" runat="server" Value="0" Visible="true" />
        <asp:HiddenField ID="businessID_hf" runat="server" />
    </form>
</body>
</html>
