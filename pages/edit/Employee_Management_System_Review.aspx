<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Employee_Management_System_Review.aspx.vb" Inherits="Enterprise_Village_2._0.Employee_Management_System_Review" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>EV 2.0 - EMS</title>

    <link href="~/css/Styles.print.css" rel="stylesheet" media="print" type="text/css">
    <link href="~/css/Styles.updated.css" rel="stylesheet" media="screen" type="text/css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png" />
    <script src="https://code.jquery.com/jquery-1.10.2.js"></script>
</head>

<body>
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

        <div class="content">
            <h2 class="h2 no-print">Employee Management System</h2>
            <h3 class="no-print">This page will allow you to add students or edit students for each visit date and business.
                <br />
                <br />
                Select the visit date and business name from the drop down menus. Click 'Edit' to edit a student's first name, last name, business, account number, or position to the database.               
            </h3>

            <%--Visit Date Entry--%>
            <div>
                <p class="no-print">Visit Date:</p>
                <asp:TextBox ID="date_tb" runat="server" AutoPostBack="true" TextMode="date" CssClass="textbox"></asp:TextBox>&ensp;<asp:Label ID="error_lbl" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                <br />
            </div>

            <%--Business Selection--%>
            <div id="selectBiz_div" runat="server" visible="false">
                <p class="no-print">Select Business:</p>
                <asp:DropDownList ID="business_ddl" runat="server" Width="200px" AutoPostBack="true" CssClass="ddl no-print"></asp:DropDownList>
            </div>

            <%--Student table--%>
            <div id="gridview_div" runat="server" visible="false" class="gridviewDiv">
                <p>Change school for ALL students in this business:</p>
                <asp:DropDownList ID="changeSchool_ddl" runat="server" CssClass="ddl" AutoPostBack="true"></asp:DropDownList>&ensp;<asp:Button ID="changeSchool_btn" runat="server" Text="Change School" CssClass="button3" />
                <br />
                <p style="font-weight: bold;">Businesses Closed: <asp:Label ID="closedBiz_lbl" runat="server" Font-Bold="false"></asp:Label></p>
                <br />

                <asp:GridView ID="Review_dgv" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="True" CellPadding="5" CellSpacing="1" PageSize="20" DataKeyNames="ID" AllowPaging="True" ShowHeaderWhenEmpty="True" CssClass="no-print" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                        <asp:TemplateField HeaderText="Business Name">
                            <ItemTemplate>
                                <asp:Label ID="business_lbl" runat="server" Text='<%#Bind("BusinessID") %>' Visible="false" />
                                <asp:DropDownList CssClass="ddl" ID="business_ddl" runat="server" Width="200px" OnSelectedIndexChanged="BusinessSelectedIndexChanged" AutoPostBack="true" ReadOnly="true">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Account Number">
                            <ItemTemplate>
                                <asp:TextBox ID="empNum_tb" runat="server" Width="100px" Text='<%#Bind("Employeenumber") %>' ReadOnly="false" CssClass="textbox"></asp:TextBox>
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
                        <asp:TemplateField HeaderText="Postion">
                            <ItemTemplate>
                                <asp:Label ID="job_lbl" runat="server" Text='<%#Bind("jobid") %>' Visible="false" />
                                <asp:DropDownList CssClass="ddl" ID="job_ddl" runat="server" Width="200px" ReadOnly="true">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="School Name">
                            <ItemTemplate>
                                <asp:Label ID="schoolID_lbl" runat="server" Text='<%#Bind("schoolID") %>' Visible="false" />
                                <asp:DropDownList CssClass="ddl" ID="schoolName_ddl" runat="server" Width="200px" ReadOnly="true">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
            </div>

            <%--Print Out Table--%>
            <div>
                <asp:GridView ID="print_dgv" runat="server" AutoGenerateColumns="False" CellPadding="5" CellSpacing="1" PageSize="20" Font-Size="Medium" CssClass="print_dgv">
                    <AlternatingRowStyle BackColor="#99CCFF" />
                    <Columns>
                        <asp:BoundField DataField="businessName" HeaderText="Business" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="jobTitle" HeaderText="Job Title" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="employeeNumber" HeaderText="Employee Number" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="firstName" HeaderText="First Name" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="lastName" HeaderText="Last Name" ReadOnly="true" Visible="true" />
                    </Columns>
                </asp:GridView>
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

        <asp:SqlDataSource ID="Review_sds" runat="server"></asp:SqlDataSource>
        <asp:SqlDataSource ID="print_sds" runat="server"></asp:SqlDataSource>
    </form>
</body>
</html>
