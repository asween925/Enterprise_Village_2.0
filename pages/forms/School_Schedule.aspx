<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="School_Schedule.aspx.vb" Inherits="Enterprise_Village_2._0.School_Schedule" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>EV 2.0 - School Schedule</title>

    <link href="~/css/Styles.updated.css" rel="stylesheet" media="screen" type="text/css">
    <link href="~/css/Styles.print.css" rel="stylesheet" media="print" type="text/css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png" />

    <script src="https://code.jquery.com/jquery-1.10.2.js"></script>
</head>

<body onafterprint="javascript:ResetPage();">
    <form id="EMS_Form" runat="server">

        <%--Header information--%>
        <header class="headerTop"><a style="float: left; padding-top: 2px;">Enterprise Village 2.0</a><a style="float: right; padding-right: 30px; padding-top: 2px;"><asp:Label ID="headerSchoolName_lbl" Text="School Name Here" runat="server"></asp:Label></a></header>

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
            <h2 class="h2">School Schedule</h2>
            <h3 class="no-print">This is where you can view the schedule for EV for each school time slot.
            </h3>            
            <asp:Button ID="print_btn" runat="server" Text="Print" CssClass="button3 no-print"></asp:Button>&ensp;<asp:Label ID="error_lbl" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="Red"></asp:Label>
            <br class="no-print" /><br class="no-print" />
            <div id="schoolNotes_div" runat="server" visible="true">
                <asp:GridView ID="schedule_dgv" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="true" DataKeyNames="ID" CellPadding="5" Height="50" AllowPaging="True" ShowHeaderWhenEmpty="True" Font-Size="Medium" Visible="false" PageSize="20" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" Visible="true" />
                        <asp:TemplateField HeaderText="School<br />Schedule" >
                            <ItemTemplate>
                                <asp:TextBox ID="schoolSchedule_tb" runat="server" ReadOnly="false" Width="100px" Text='<%#Bind("schoolSchedule") %>' CssClass="textbox"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Time<br />Volunteers<br />Arrive">
                            <ItemTemplate>
                               <asp:TextBox ID="timeVolArrive_tb" runat="server" ReadOnly="false" Width="100px" Text='<%#Bind("timeVolArrive") %>' CssClass="textbox"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Time<br />Students<br />Arrive">
                            <ItemTemplate>
                                <asp:Textbox ID="timeStudentsArrive_tb" runat="server" Text='<%#Bind("timeStudentsArrive") %>' Visible="true" Width="100px" ReadOnly="false" CssClass="textbox"></asp:Textbox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Time<br />Class<br />Begins">
                            <ItemTemplate>
                                <asp:Textbox ID="timeClassBegins_tb" runat="server" Text='<%#Bind("timeClassBegins") %>' Visible="true" Width="100px" ReadOnly="false" CssClass="textbox"></asp:Textbox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Students<br />Lunch<br />From/To">
                            <ItemTemplate>
                                <asp:Textbox ID="studentsLunch_tb" runat="server" Text='<%#Bind("studentsLunch") %>' Visible="true" Width="100px" ReadOnly="false" CssClass="textbox"></asp:Textbox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Town<br />Meeting<br />Begins">
                            <ItemTemplate>
                                <asp:Textbox ID="townMeetingBegins_tb" runat="server" Text='<%#Bind("townMeetingBegins") %>' Visible="true" Width="100px" ReadOnly="false" CssClass="textbox"></asp:Textbox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Leave EV">
                            <ItemTemplate>
                                <asp:Textbox ID="leaveEV_tb" runat="server" Text='<%#Bind("leaveEV") %>' Visible="true" Width="100px" ReadOnly="false" CssClass="textbox"></asp:Textbox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:GridView ID="schoolNotesPrint_dgv" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="false" DataKeyNames="ID" CellPadding="5" Height="50" AllowPaging="True" ShowHeaderWhenEmpty="True" Font-Size="Medium" Visible="true" PageSize="20">
                    <AlternatingRowStyle BackColor="#99CCFF" />
                    <RowStyle HorizontalAlign="Center" />
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />
                        <asp:BoundField DataField="schoolSchedule" HeaderText="School<br />Schedule" Visible="true" HtmlEncode="false" DataFormatString="{0:hh\:mm}"  />
                        <asp:BoundField DataField="timeVolArrive" HeaderText="Time<br />Volunteers<br />Arrive" Visible="true" HtmlEncode="false" DataFormatString="{0:hh\:mm}" />
                        <asp:BoundField DataField="timeStudentsArrive" HeaderText="Time<br />Students<br />Arrive" Visible="true" HtmlEncode="false" DataFormatString="{0:hh\:mm}" />
                        <asp:BoundField DataField="timeClassBegins" HeaderText="Time<br />Class<br />Begins" Visible="true" HtmlEncode="false" DataFormatString="{0:hh\:mm}" />
                        <asp:BoundField DataField="studentsLunch" HeaderText="Students<br />Lunch<br />From/To" Visible="true" HtmlEncode="false" />
                        <asp:BoundField DataField="townMeetingBegins" HeaderText="Town<br />Meeting<br />Begins" Visible="true" HtmlEncode="false" DataFormatString="{0:hh\:mm}" />
                        <asp:BoundField DataField="leaveEV" HeaderText="Leave EV" Visible="true" DataFormatString="{0:hh\:mm}" />
                    </Columns>
                </asp:GridView>
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
