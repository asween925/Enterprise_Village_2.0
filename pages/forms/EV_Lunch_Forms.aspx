<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EV_Lunch_Forms.aspx.vb" Inherits="Enterprise_Village_2._0.EV_Lunch_Forms" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>EV 2.0 - EV Lunch Forms</title>

    <link href="~/css/Styles.updated.css" rel="stylesheet" media="screen" type="text/css">
    <link href="~/css/Styles.print.css" rel="stylesheet" media="print" type="text/css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png" />

    <script src="https://code.jquery.com/jquery-1.10.2.js"></script>
</head>

<body onafterprint="javascript:ResetPage();">
    <form autocomplete="off"  id="EMS_Form" runat="server">

        <%--Header information--%>
        <header class="headerTop no-print"><a style="float: left; padding-top: 2px;">Enterprise Village 2.0</a><a style="float: right; padding-right: 30px; padding-top: 2px;"><asp:Label ID="headerSchoolName_lbl" Text="School Name Here" runat="server"></asp:Label></a></header>

        <%--Navigation bar--%>
        <div id="nav-placeholder">
        </div>

        <script>
            $(function () {
                $("#nav-placeholder").load("../../nav.html");
            });
        </script>

        <%--Content--%>
        <div class="content">

            <%--Inputs and headers--%>
            <div class="no-print">
                <h2 class="h2 no-print">EV Lunch Forms</h2>
                <h3 class="no-print">This is where you will print out McDonald's lunch tickets.
                </h3>
                <asp:Button ID="dailyReceipt_btn" runat="server" Visible="true" CssClass="button3 no-print" Text="Daily Receipt" />
                &ensp;<asp:Button ID="letter_btn" runat="server" Visible="true" CssClass="button3 no-print" Text="Letter" />
                &ensp;<asp:Button ID="print_btn" runat="server" Text="Print" CssClass="button3 no-print" Visible="false" />
                &ensp;<asp:Label ID="error_lbl" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="Red" CssClass="no-print"></asp:Label>
            </div>

            <%--Visit Date (for daily receipt)--%>
            <div id="date_div" runat="server" visible="false">
                <p class="no-print">Visit Date:</p>
                <asp:TextBox ID="visitDate_tb" runat="server" TextMode="Date" CssClass="textbox no-print" AutoPostBack="true"></asp:TextBox>
            </div>

            <%--Letter--%>
            <div id="letterSection_div" runat="server" visible="false">
                <p class="no-print">Select a month and year:</p>

                <asp:DropDownList ID="month_ddl" runat="server" CssClass="ddl no-print" AutoPostBack="true">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>August</asp:ListItem>
                    <asp:ListItem>September</asp:ListItem>
                    <asp:ListItem>October</asp:ListItem>
                    <asp:ListItem>November</asp:ListItem>
                    <asp:ListItem>December</asp:ListItem>
                    <asp:ListItem>January</asp:ListItem>
                    <asp:ListItem>February</asp:ListItem>
                    <asp:ListItem>March</asp:ListItem>
                    <asp:ListItem>April</asp:ListItem>
                    <asp:ListItem>May</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="year_ddl" runat="server" CssClass="ddl no-print" AutoPostBack="true"></asp:DropDownList>

                <div id="letter_div" runat="server" visible="false" class="letter_print">
                    <asp:Image ID="StavrosLogo_img" runat="server" ImageUrl="~\media\Stavros_logo.png" Visible="false" CssClass="stavros_logo_print" />
                    <h3 style="text-align: center;">Gus A. Stavros Institute
                    <br />
                        Enterprise Village & Finance Park
                    </h3>

                    <p style="text-align: center; font-style: italic;">Programs of Pinellas County Schools and the Pinellas Education Foundation</p>

                    <h4 style="text-align: center; text-decoration: underline;">Ph. 727-588-3746 &ensp; 12100 Starkey Rd. Largo, FL 33773 &ensp; Fax 727-588-3748</h4>

                    <asp:Label ID="longDate_lbl" runat="server"></asp:Label>
                    <br />
                    <br />

                    <p style="margin: 0px;">McDonald's Restaurant</p>
                    <p style="margin: 0px;">Att: General Manager</p>
                    <p style="margin: 0px;">5170 Park Blvd.</p>
                    <p style="margin: 0px;">Pinellas Park, FL 33781</p>
                    <br />

                    <p>
                        Our lunch order for students during the month of
                        <asp:Label ID="month_lbl" runat="server"></asp:Label>
                        is as follows:
                    </p>

                    <asp:GridView ID="lunches_dgv" runat="server" GridLines="none" AutoGenerateColumns="False" AutoGenerateEditButton="false" CellPadding="2" CellSpacing="1" PageSize="20" Font-Size="14px" DataKeyNames="ID">
                        <RowStyle HorizontalAlign="Center" />
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="true" Visible="false" />
                            <asp:BoundField DataField="DateAndDay" HeaderText="Day/Date" ReadOnly="true" />
                            <asp:TemplateField HeaderText="Burgers" Visible="true">
                                <ItemTemplate>
                                    <asp:TextBox runat="server" ID="burgers_dgvtb" TextMode="Number" ReadOnly="false" Visible="true" Width="50px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nuggets" Visible="true">
                                <ItemTemplate>
                                    <asp:TextBox runat="server" ID="nuggets_dgvtb" TextMode="Number" ReadOnly="false" Visible="true" Width="60px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="pickUpTime" HeaderText="Pick-up Time" ReadOnly="true" />
                        </Columns>
                    </asp:GridView>
                    <br />
                    <br />
                    <p>Sincerely,</p>
                    <br />
                    <br />
                    <p style="margin: 0px;">Patricia Jeremiah-Pittman, Director</p>
                    <p style="margin: 0px;">Stavros Institute</p>
                </div>
            </div>

            <%--Daily Receipt--%>
            <div id="dailyReceipt_div" runat="server" visible="false">

                <div id="count_div" class="no-print">
                    <p style="font-weight: bold;">
                        Student Count: 
                    <asp:Label ID="studentCount_lbl" runat="server"></asp:Label>
                        &ensp;
                    Volunteer Count:
                    <asp:Label ID="volunteerCount_lbl" runat="server"></asp:Label>
                    </p>
                </div>

                <div class="daily_receipt">
                    <asp:Image ID="EVLogo_img" runat="server" ImageUrl="~\media\EnterpriseVillage.png" CssClass="EV_logo_lunches_receipt EV_logo_lunches_receipt_print" />
                    <p style="font-weight: bold;">
                        Visit Date:
                    <asp:Label ID="visitDate_lbl" runat="server"></asp:Label>

                    </p>
                    <br />
                    <p style="font-weight: bold; text-align: right;">
                        Pick-up Time:
                    <asp:Label ID="pickupTime_lbl" runat="server"></asp:Label>
                    </p>
                    <br />

                    <p style="font-weight: bold;">
                        Total Burgers:
                    <asp:TextBox ID="burgers_tb" runat="server" TextMode="Number" Width="80px"></asp:TextBox>
                        &ensp;
                    Total McNuggets:
                    <asp:TextBox ID="nuggets_tb" runat="server" TextMode="Number" Width="80px"></asp:TextBox>
                    </p>
                    <br class="no-print" />

                    <p style="font-weight: bold;">
                        Comments:
                    <br />
                        <br />
                        <asp:TextBox ID="comments_tb" runat="server" TextMode="MultiLine" Width="300px"></asp:TextBox>
                    </p>
                </div>

                <%--Signature Line--%>
                <div id="receiptSign_div" runat="server">
                    <p>__________________________________________</p>
                    <a>Ok to Pay</a>
                </div>
            </div>

        </div>

        <asp:HiddenField ID="currentVisitID_hf" runat="server" />

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
