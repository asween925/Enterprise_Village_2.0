<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Manager_System.aspx.vb" Inherits="Enterprise_Village_2._0.Manager_System" %>

<!doctype html>
<html>
<head runat="server">

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>Manager System</title>

    <link href="~/css/Styles.StudentPages.css" rel="stylesheet" type="text/css" media="screen">
    <link href="~/css/Styles.print.css" rel="stylesheet" type="text/css" media="print">
    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png" />

    <script src="../../Scripts.js"></script>

    <style>
        h4 {
            font-size: 26px;
            text-decoration: underline;
        }

        p {
            padding: 10px;
        }

        .dukeTextbox {
            resize: none; 
            height: 23px; 
            width: 100px; 
            text-align: center; 
            padding: 0px;
        }
    </style>

</head>
<body onafterprint="javascript:ResetPage();">
    <form autocomplete="off"  id="form1" runat="server">
        <div id="Site_Wrap_Header" style="overflow: hidden;">

            <%--Header--%>
            <div class="header1">
                <img class="EV_logo no-print" alt="Enterprise Village" src="../../Images/EV2.0_PCSB.png">
            </div>

            <div class="header2">
                <h2 id="headerText_h2" runat="server">Manager System</h2>
            </div>

            <div class="header3">
                <asp:Image ID="BusLogo_img" runat="server" Class="Business_logo no-print" />
            </div>

            <%--Content--%>
            <div class="main_base" runat="server" id="manager_system_div">

                <%--Ditek Manager--%>
                <div id="ditek_div" runat="server" visible="false">
                    <h4 class="no-print">Select a Business to View their Inventory:</h4>
                    <p style="font-weight: bold; padding: 0px;" class="no-print">Business Name:</p>
                    <asp:DropDownList ID="ditekBusinessDDL_ddl" runat="server" CssClass="ddl no-print" AutoPostBack="true"></asp:DropDownList>
                    <br class="no-print" />
                    <asp:Label ID="ditekError_lbl" runat="server" ForeColor="Red" Font-Size="X-Large" Font-Bold="true"></asp:Label>
                    <br />
                    <asp:Button ID="ditekPrint_btn" runat="server" CssClass="print_button no-print" Text="Print" />
                    <br />
                    <br class="no-print" />
                    <asp:GridView ID="items_dgv" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="false" DataKeyNames="ID" CellPadding="5" Height="50" AllowPaging="True" ShowHeaderWhenEmpty="True" Font-Size="Medium" Visible="true" HorizontalAlign="Center">
                        <AlternatingRowStyle BackColor="#99CCFF" />
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="true" Visible="false" />
                            <asp:BoundField DataField="merchCode" HeaderText="Merch Code" Visible="true" />
                            <asp:BoundField DataField="itemName" HeaderText="Item Name" Visible="true" />
                            <asp:BoundField DataField="usedDaily" HeaderText="Quantity" Visible="true" />
                            <asp:TemplateField HeaderText="Price Each">
                                <ItemTemplate>
                                    <asp:Label ID="blah" runat="server" CssClass="align-left">X _________________</asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount">
                                <ItemTemplate>
                                    <asp:Label ID="blah" runat="server" CssClass="align-left">= _________________</asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <br />
                    
                    <%--Profit Calculation--%>
                    <div id="ditekPricingCalc_div" runat="server" class="Manager_System_Ditek_Profit_Calc Manager_System_Ditek_Profit_Calc_Print">
                        <p style="font-size: 20px;">Potential Profit Calculation</p>
                        <p style="font-size: 14px;"><a style="float: left;">Total Possible Sales</a><a style="float: right;">__________________________</a></p>
                        <p style="font-size: 14px;"><a style="float: left;">Bank Loan (Business Cost Sheet)</a><a style="float: right;">Subtract (-) __________________________</a></p>
                        <p style="font-size: 14px;"><a style="float: left;">Possible Profit (should be $40.00 to $60.00 above bank loan)</a><a style="float: right;">__________________________</a></p>
                        <br />
                    </div>
                    <br /><br />
                    <%--Pricing key--%>
                    <div id="ditekPricingKey_div" runat="server" style="border: 2px solid black; margin-left: 40%; margin-right: 40%; text-align: center; font-weight: bold;" visible="false">
                        <p style="font-size: 20px;">Pricing Key</p>
                        <p style="padding: 1px;">$$$ = $9.00-$14.00</p>
                        <p style="padding: 1px;">$$ = $6.00-$8.50</p>
                        <p style="padding: 1px;">$ = $1.50-$5.50</p>
                        <p style="padding: 1px;">* = Already Priced</p>
                        <p style="padding: 1px;">IB = In Business</p>
                    </div>
                    <br /><br />
                </div>

                <%--Sales Manager--%>
                <div id="sales_div" runat="server" visible="false">
                    <h4>Please answer the following questions:</h4>
                    <asp:Label ID="salesError_lbl" runat="server" ForeColor="Red" Font-Size="X-Large" Font-Bold="true"></asp:Label>
                    <div class="Manager_System_QA_Block">
                        <div class="Manager_System_Questions">
                            <p>
                                <a style="float: left;">1. How many employees do you have today (including yourself)?</a>
                                <a style="float: right;">
                                    <asp:TextBox ID="Textbox2" runat="server" TextMode="Number" Width="70px"></asp:TextBox></a>
                            </p>
                            <p>
                                <a style="float: left;">2. Has promissory note been turned in to the bank manager?</a>
                                <a style="float: right;">
                                    <asp:RadioButton ID="RadioButton1" runat="server" Text="Yes" />&ensp;<asp:RadioButton ID="RadioButton2" runat="server" Text="No" /></a>
                            </p>
                            <p>
                                <a style="float: left;">3. Has loan application been turned in to the credit union manager?</a>
                                <a style="float: right;">
                                    <asp:RadioButton ID="RadioButton3" runat="server" Text="Yes" />&ensp;<asp:RadioButton ID="RadioButton4" runat="server" Text="No" /></a>
                            </p>
                            <p>
                                <a style="float: left;">4. Have you encouraged your employees to visit Baycare for a free wellness check?</a>
                                <a style="float: right;">
                                    <asp:RadioButton ID="RadioButton5" runat="server" Text="Yes" />&ensp;<asp:RadioButton ID="RadioButton6" runat="server" Text="No" /></a>
                            </p>
                            <p>
                                <a style="float: left;">5. Are your employees providing quality customer service?</a>
                                <a style="float: right;">
                                    <asp:RadioButton ID="RadioButton7" runat="server" Text="Yes" />&ensp;<asp:RadioButton ID="RadioButton8" runat="server" Text="No" /></a>
                            </p>
                            <p>
                                <a style="float: left;">6. Are employees completeing their tasks in a timely manner?</a>
                                <a style="float: right;">
                                    <asp:RadioButton ID="RadioButton9" runat="server" Text="Yes" />&ensp;<asp:RadioButton ID="RadioButton10" runat="server" Text="No" /></a>
                            </p>
                            <p>
                                <a style="float: left;">7. Has your financial officer made a least 1 business deposit today?</a>
                                <a style="float: right;">
                                    <asp:RadioButton ID="RadioButton11" runat="server" Text="Yes" />&ensp;<asp:RadioButton ID="RadioButton12" runat="server" Text="No" /></a>
                            </p>
                            <p>
                                <a style="float: left;">8. Have you encouraged your employees to vote today?</a>
                                <a style="float: right;">
                                    <asp:RadioButton ID="RadioButton13" runat="server" Text="Yes" />&ensp;<asp:RadioButton ID="RadioButton14" runat="server" Text="No" /></a>
                            </p>
                            <p>
                                <a style="float: left;">9. Are you supporting all of your employees when they need help?</a>
                                <a style="float: right;">
                                    <asp:RadioButton ID="RadioButton15" runat="server" Text="Yes" />&ensp;<asp:RadioButton ID="RadioButton16" runat="server" Text="No" /></a>
                            </p>
                            <p>
                                <a style="float: left;">10. Have you encouraged your employees to shop during their break times in Enterprise Village?</a>
                                <a style="float: right;">
                                    <asp:RadioButton ID="RadioButton17" runat="server" Text="Yes" />&ensp;<asp:RadioButton ID="RadioButton18" runat="server" Text="No" /></a>
                            </p>
                            <p>
                                <a style="float: left;">11. Supervise employees and encourage positive and polite conversations.</a>
                                <a style="float: right;">
                                    <asp:RadioButton ID="RadioButton19" runat="server" Text="Yes" />&ensp;<asp:RadioButton ID="RadioButton20" runat="server" Text="No" /></a>
                            </p>
                            <p>
                                <a style="float: left;">12. Are you and your staff keeping your business tidy and safe?</a>
                                <a style="float: right;">
                                    <asp:RadioButton ID="RadioButton21" runat="server" Text="Yes" />&ensp;<asp:RadioButton ID="RadioButton22" runat="server" Text="No" /></a>
                            </p>
                        </div>
                        <br />
                        <button onclick="myFunction()" class="submit_button">Submit</button>
                    </div>
                </div>

                <%--Non-Sales Manager--%>
                <div id="nonsales_div" runat="server" visible="false">
                    <h4>Please answer the following questions:</h4>
                    <asp:Label ID="nonSalesError_lbl" runat="server" ForeColor="Red" Font-Size="X-Large" Font-Bold="true"></asp:Label>
                    <div class="Manager_System_QA_Block">
                        <div class="Manager_System_Questions">
                            <p>
                                <a style="float: left;">1. How many employees do you have today (including yourself)?</a>
                                <a style="float: right;">
                                    <asp:TextBox ID="Textbox1" runat="server" TextMode="Number" Width="70px"></asp:TextBox></a>
                            </p>
                            <p>
                                <a style="float: left;">2. Has promissory note been turned in to the bank manager?</a>
                                <a style="float: right;">
                                    <asp:RadioButton ID="RadioButton23" runat="server" Text="Yes" />&ensp;<asp:RadioButton ID="RadioButton24" runat="server" Text="No" /></a>
                            </p>
                            <p>
                                <a style="float: left;">3. Has loan application been turned in to the credit union manager?</a>
                                <a style="float: right;">
                                    <asp:RadioButton ID="RadioButton25" runat="server" Text="Yes" />&ensp;<asp:RadioButton ID="RadioButton26" runat="server" Text="No" /></a>
                            </p>
                            <p>
                                <a style="float: left;">4. Have you encouraged your employees to visit Baycare for a free wellness check?</a>
                                <a style="float: right;">
                                    <asp:RadioButton ID="RadioButton27" runat="server" Text="Yes" />&ensp;<asp:RadioButton ID="RadioButton28" runat="server" Text="No" /></a>
                            </p>
                            <p>
                                <a style="float: left;">5. Are your employees providing quality customer service?</a>
                                <a style="float: right;">
                                    <asp:RadioButton ID="RadioButton29" runat="server" Text="Yes" />&ensp;<asp:RadioButton ID="RadioButton30" runat="server" Text="No" /></a>
                            </p>
                            <p>
                                <a style="float: left;">6. Are employees completeing their tasks in a timely manner?</a>
                                <a style="float: right;">
                                    <asp:RadioButton ID="RadioButton31" runat="server" Text="Yes" />&ensp;<asp:RadioButton ID="RadioButton32" runat="server" Text="No" /></a>
                            </p>
                            <p>
                                <a style="float: left;">7. Has your financial officer made a least 1 business deposit today?</a>
                                <a style="float: right;">
                                    <asp:RadioButton ID="RadioButton33" runat="server" Text="Yes" />&ensp;<asp:RadioButton ID="RadioButton34" runat="server" Text="No" /></a>
                            </p>
                            <p>
                                <a style="float: left;">8. Have you encouraged your employees to vote today?</a>
                                <a style="float: right;">
                                    <asp:RadioButton ID="RadioButton35" runat="server" Text="Yes" />&ensp;<asp:RadioButton ID="RadioButton36" runat="server" Text="No" /></a>
                            </p>
                            <p>
                                <a style="float: left;">9. Are you supporting all of your employees when they need help?</a>
                                <a style="float: right;">
                                    <asp:RadioButton ID="RadioButton37" runat="server" Text="Yes" />&ensp;<asp:RadioButton ID="RadioButton38" runat="server" Text="No" /></a>
                            </p>
                            <p>
                                <a style="float: left;">10. Have you encouraged your employees to shop during their break times in Enterprise Village?</a>
                                <a style="float: right;">
                                    <asp:RadioButton ID="RadioButton39" runat="server" Text="Yes" />&ensp;<asp:RadioButton ID="RadioButton40" runat="server" Text="No" /></a>
                            </p>
                            <p>
                                <a style="float: left;">11. Supervise employees and encourage positive and polite conversations.</a>
                                <a style="float: right;">
                                    <asp:RadioButton ID="RadioButton41" runat="server" Text="Yes" />&ensp;<asp:RadioButton ID="RadioButton42" runat="server" Text="No" /></a>
                            </p>
                            <p>
                                <a style="float: left;">12. Are you and your staff keeping your business tidy and safe?</a>
                                <a style="float: right;">
                                    <asp:RadioButton ID="RadioButton43" runat="server" Text="Yes" />&ensp;<asp:RadioButton ID="RadioButton44" runat="server" Text="No" /></a>
                            </p>
                        </div>
                        <br />
                        <button onclick="myFunction()" class="submit_button">Submit</button>
                    </div>
                </div>

                <%--Duke Manager--%>
                <div id="duke_div" runat="server" visible="false">
                    <asp:Label ID="dukeError_lbl" runat="server" ForeColor="Red" Font-Size="X-Large" Font-Bold="true"></asp:Label>
                    <p class="no-print">Select Business:</p>
                    <asp:DropDownList ID="dukeBusiness_ddl" runat="server" CssClass="ddl no-print" AutoPostBack="true"></asp:DropDownList>
                    <br class="no-print" /><br class="no-print" />
                    <asp:Button ID="dukePrint_btn" runat="server" CssClass="print_button no-print" Text="Print" />
                    <div class="Manager_System_Duke_Directions">
                        <p style="padding: 0px;">Direct all questions to the Duke Energy Office at Enterprise Village.</p>
                        <p style="padding: 0px;">Be sure to get involved with the Duke Energy energy audit. Conserve energy for the future!</p>
                    </div>
                    <div class="Manager_System_Duke_Middle">
                        <div class="Manager_System_Duke_Readings">
                            <p style="font-size: 20px; font-weight: bold; padding: 0px;">Readings</p>
                            <p style="text-align: left;">
                                Account Number &ensp; <span style="float: right;">
                                    <asp:TextBox ID="dukeAcctNum_tb" runat="server" CssClass="textbox dukeTextbox" ></asp:TextBox></span>
                            </p>
                            <p style="text-align: left;">
                                Meter Number <span style="float: right;">
                                    <asp:Textbox ID="meterNum_tb" runat="server" CssClass="textbox dukeTextbox"></asp:Textbox></span>
                            <p />
                            <p style="text-align: left;">
                                Yesterday &ensp; <span style="float: right;">
                                    <asp:Textbox ID="yesterday_tb" runat="server" CssClass="textbox dukeTextbox"></asp:Textbox></span>
                            </p>
                            <p style="text-align: left;">
                                Today &ensp; <span style="float: right;">
                                    <asp:Textbox ID="today_tb" runat="server" CssClass="textbox dukeTextbox"></asp:Textbox></span>
                            </p>
                            <p style="text-align: left;">
                                Energy Used &ensp; <span style="float: right;">
                                    <asp:TextBox ID="dukeEnergy_tb" runat="server" CssClass="textbox dukeTextbox" Enabled="false" ></asp:TextBox></span>
                            </p>
                            <p><span style="float: right;">
                               <asp:Button ID="dukeSave_btn" runat="server" CssClass="button3 no-print" Text="Save Readings" />&ensp;<asp:Button ID="dukeCalc_btn" runat="server" CssClass="button3" Text="Calculate" /></span></p>
                        </div>
                        <div class="Manager_System_Duke_Service">
                            <p style="font-size: 20px; font-weight: bold; padding: 0px;">Business Service</p>
                            <p>
                                <span style="float: left;">Customer Charges</span>
                                <span style="float: right;">$3.00</span>
                            </p>
                            <p>
                                <span style="float: left;">Kilowatt Hours Used</span>
                                <span style="float: right;"><asp:Label ID="dukeKiloHrs_lbl" runat="server" CssClass="Manager_System_Duke_Bottom_Text"></asp:Label> X $.04 = <asp:Label ID="dukeKiloCalc_lbl" runat="server"></asp:Label></span>
                            </p>
                            <p>
                                <span style="float: left;">Fuel Charge</span>
                                <span style="float: right;"><asp:Label ID="dukeFuel_lbl" runat="server" CssClass="Manager_System_Duke_Bottom_Text"></asp:Label> X $.02 = <asp:Label ID="dukeFuelCalc_lbl" runat="server"></asp:Label></span>
                            </p>
                            <br />
                            <p>
                                <span style="float: left;">Total Electric Cost</span>
                                <span style="float: right;"><asp:Label ID="dukeTotalElectric_lbl" runat="server" CssClass="Manager_System_Duke_Bottom_Text"></asp:Label></span>
                            </p>
                            <br />
                            <p>
                                <span style="float: left;">Franchise Fee</span>
                                <span style="float: right;">$1.00</span>
                            </p>
                            <p>
                                <span style="float: left;">Municpal Utility Tax</span>
                                <span style="float: right;">$1.00</span>
                            </p>
                            <br />
                            <p>
                                <span style="float: left;">Total Due This Statement</span>
                                <span style="float: right;"><asp:Label ID="dukeTotalDue_lbl" runat="server" CssClass="Manager_System_Duke_Bottom_Text"></asp:Label></span>
                            </p>
                        </div>
                    </div>

                    <div class="Manager_System_Duke_Bottom">
                        <p>Detach and Return with Payment</p>

                        <%--Total Due--%>
                        <div class="Manager_System_Duke_Bottom_Total">
                            <p style="border-bottom: 2px solid black; text-align: center; font-weight: bold;">TOTAL DUE:</p>
                            <asp:Label ID="dukeTotal_lbl" runat="server" CssClass="Manager_System_Duke_Bottom_Text"></asp:Label>
                            <br />
                            <p style="padding: 1px; border-bottom: 2px solid black;">DELINQUENT
                                <br />
                                AFTER THIRD BREAK</p>
                            <p style="padding: 1px;">TODAY!</p>
                            
                        </div>
                        <br /><br /><br />
                        <asp:Label ID="dukeBottomBusiness_lbl" runat="server" Text=""></asp:Label>
                        <br />
                        <p>_____________________________</p>
                        <asp:Label ID="dukeAcctNum_lbl" runat="server" Text="14-2378"></asp:Label>

                        <%--Duke Logo--%>
                        <asp:Image ID="DukeLogo_img" runat="server" ImageUrl="~\media\Logos\Duke\Duke.gif" CssClass="Manager_System_Duke_Bottom_Logo" Visible="true" />
                        <p class="Manager_System_Duke_Bottom_Logo" style="top: 75px; left: 8px;">DUKE ENERGY WILL PICK UP YOUR PAYMENTS</p>

                    </div>
                    
                </div>

            </div>
        </div>

        <script>
            function popup() {
                let text;
                let pswd = prompt("Please enter the password to print:", "");
                if (pswd == "gsi123") {
                    PrintPage();
                    location.reload();
                } else {
                    document.getElementById("error_lbl").innerHTML = "Password is incorrect. Please ask an Enterprise Village staff member for assistance.";
                }
            }
        </script>
    </form>
</body>
</html>
