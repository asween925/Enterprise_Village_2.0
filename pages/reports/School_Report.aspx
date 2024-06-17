<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="School_Report.aspx.vb" Inherits="Enterprise_Village_2._0.School_Report" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>EV 2.0 - School Report</title>

    <link href="~/css/Styles.print.css" rel="stylesheet" media="print" type="text/css">
    <link href="~/css/Styles.updated.css" rel="stylesheet" media="screen" type="text/css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png" />
<script src="https://code.jquery.com/jquery-1.10.2.js"></script>
</head>

<body>
    <form autocomplete="off"  id="EMS_Form" runat="server">

        <%--Header information--%>
        <header class="headerTop"><a style="float: left; padding-top: 2px;">Enterprise Village 2.0</a><a style="float: right; padding-right: 30px; padding-top: 2px;"><asp:Label ID="headerSchoolName_lbl" Text="School Name Here" runat="server"></asp:Label></a></header>

   <%--Navigation bar--%>
        <div id="nav-placeholder">

        </div>

        <script>
            $(function () {
                $("#nav-placeholder").load("../../nav.html");
            });
        </script>

        

        <div class="content">
            <h2 class="h2 no-print">School Report</h2>
            <h3 class="no-print">This page displays all schools in the database. Use the drop down menu to select a school you would like to view.
            </h3>
            <p>School Name:</p>
            <asp:DropDownList CssClass="ddl" ID="schoolNameSearch_ddl" runat="server" Width="200px" AutoPostBack="true"></asp:DropDownList> &ensp;<asp:Label ID="error_lbl" runat="server" Font-Size="X-Large" ForeColor="Red"></asp:Label>
            <p>Keyword Search:</p>
            <asp:TextBox ID="search_tb" runat="server" CssClass="textbox"></asp:TextBox> &nbsp;&nbsp; <asp:Button ID="search_btn" runat="server" CssClass="button3" text="Search"/>     
            <br /><br />            
            <asp:Button ID="refresh_btn" runat="server" CssClass="button3" text="Show All Schools"/>
            <br /><br />         

             <%--Print Out Table--%>           
            <div>
                <asp:GridView ID="schools_dgv" runat="server" AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="3" Height="50" Font-Size="Medium" Visible="true" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="schoolName" HeaderText="School Name" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="principalFirst" HeaderText="Administrator </br> First Name" ReadOnly="true" Visible="true" HtmlEncode="false" />
                        <asp:BoundField DataField="principalLast" HeaderText="Administrator </br> Last Name" ReadOnly="true" Visible="true" HtmlEncode="false" />
                        <asp:BoundField DataField="phone" HeaderText="Phone #" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="fax" HeaderText="Fax #" ReadOnly="true" Visible="false" />
                        <asp:BoundField DataField="schoolHours" HeaderText="Hours" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="schoolType" HeaderText="School Type" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="visitDate1" HeaderText="Visit Date #1" ReadOnly="true" Visible="false" DataFormatString="{0: MM-dd-yyyy }" />
                        <asp:BoundField DataField="visitDate2" HeaderText="Visit Date #2" ReadOnly="true" Visible="false" DataFormatString="{0: MM-dd-yyyy }"/>
                        <asp:BoundField DataField="visitDate3" HeaderText="Visit Date #3" ReadOnly="true" Visible="false" DataFormatString="{0: MM-dd-yyyy }"/>
                        <asp:BoundField DataField="visitDate4" HeaderText="Visit Date #4" ReadOnly="true" Visible="false" DataFormatString="{0: MM-dd-yyyy }"/>
                        <asp:BoundField DataField="dayCount1" HeaderText="Day Count" ReadOnly="true" Visible="false" />
                        <asp:BoundField DataField="futureRequestsEmail" HeaderText="Adminstrator </br> Email" ReadOnly="true" Visible="true" HtmlEncode="false" />
                        <asp:BoundField DataField="futureRequests" HeaderText="Notes" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="county" HeaderText="County" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="liaisonName" HeaderText="Liaison Name" ReadOnly="true" Visible="true" />
                    </Columns>
                </asp:GridView>
                <br />
            </div>           
        </div>
        
        <asp:HiddenField ID="visitdate_hf" runat="server" />
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

        <script type="text/javascript" language="javascript">
            $(document).ready(function () {
                $('#<%=schools_dgv.ClientID %>').Scrollable();})
        </script>


        <asp:SqlDataSource ID="Review_sds" runat="server"></asp:SqlDataSource>
        <asp:SqlDataSource ID="print_sds" runat="server"></asp:SqlDataSource>
    </form>
</body>
</html>
