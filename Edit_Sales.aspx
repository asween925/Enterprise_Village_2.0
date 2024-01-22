<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Edit_Sales.aspx.vb" Inherits="Enterprise_Village_2._0.Edit_Sales" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>EV 2.0 - Edit Sales</title>

    <link href="css/Styles.print.css" rel="stylesheet" media="print" type="text/css">
    <link href="css/Styles.updated.css" rel="stylesheet" media="screen" type="text/css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <link rel="shortcut icon" type="image/png" href="media/EV_favicon_2.png" />
<script src="https://code.jquery.com/jquery-1.10.2.js"></script>
</head>

<body>
    <form id="EMS_Form" runat="server">

        <%--Header information--%>
        <header class="headerTop"><a style="float: left; padding-top: 2px;">Enterprise Village 2.0</a><a style="float: right; padding-right: 30px; padding-top: 2px;"><asp:Label ID="headerSchoolName_lbl" Text="School Name Here" runat="server"></asp:Label></a></header>

     <%--Navigation bar--%>
        <div id="nav-placeholder">

        </div>

        <script>
            $(function () {
                $("#nav-placeholder").load("nav.html");
            });
        </script>

        

        <div class="content">
            <h2 class="h2 no-print">Edit Sales</h2>
            <h3 class="no-print">This page will allow you to edit transaction from a selected visit date and employee number.
            </h3>
            <p>Select Visit Date:</p>
            <asp:TextBox ID="visitDate_tb" runat="server" Textmode="Date" AutoPostBack="true" CssClass="textbox"></asp:TextBox>
            <p id="selectStudent_p" runat="server" visible="false">Select Student Name:</p>
            <asp:DropDownList CssClass="ddl" ID="studentName_ddl" runat="server" AutoPostBack="true" Visible="false"></asp:DropDownList>&emsp;&emsp;&emsp;<asp:Label ID="error_lbl" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="Red"></asp:Label>
            <p id="studentBalance_p" runat="server" visible="false">Student Balance: <asp:Label ID="balance_lbl" runat="server" Visible="false" Font-Bold="true" Font-Size="Large" Font-Underline="true"></asp:Label></p>           
            <%--<asp:Button ID="edit_btn" runat="server" Text="Submit" CssClass="button3 button3" />--%>
            <%--Edit Sales Table--%>
            <div>
                <asp:GridView ID="sales_dgv" runat="server" AutoGenerateColumns="False" PageSize="10" AutoGenerateEditButton="True" DataKeyNames="ID" CellPadding="5" AllowPaging="True" ShowHeaderWhenEmpty="True" Font-Size="Medium" Visible="false" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />
                        <asp:BoundField DataField="businessName" ReadOnly="true" HeaderText="Business" Visible="true" />   
                        <asp:TemplateField HeaderText="Sale #1" >
                            <ItemTemplate>
                                <asp:TextBox ID="saleAmount_tb" runat="server" Width="80px" Text='<%#Bind("saleAmount") %>' CssClass="textbox"></asp:TextBox>
                            </ItemTemplate>                         
                        </asp:TemplateField>                     
                        <asp:TemplateField HeaderText="Sale #2">
                            <ItemTemplate>
                                <asp:TextBox ID="saleAmount2_tb" runat="server" Width="80px" Text='<%#Bind("saleAmount2") %>' CssClass="textbox"></asp:TextBox>
                            </ItemTemplate>                         
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sale #3">
                            <ItemTemplate>
                                <asp:TextBox ID="saleAmount3_tb" runat="server" Width="80px" Text='<%#Bind("saleAmount3") %>' CssClass="textbox"></asp:TextBox>
                            </ItemTemplate>                         
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sale #4">
                            <ItemTemplate>
                                <asp:TextBox ID="saleAmount4_tb" runat="server" Width="80px" Text='<%#Bind("saleAmount4") %>' CssClass="textbox"></asp:TextBox>
                            </ItemTemplate>                         
                        </asp:TemplateField>                      
                    </Columns>
                </asp:GridView>
            </div>
            <br />
        </div>

        <asp:HiddenField ID="visitdate_hf" runat="server" />
        <asp:HiddenField ID="visitdateUpdate_hf" runat="server" />
        <asp:HiddenField ID="empID_hf" runat="server" />

        <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
        <script src="Scripts.js"></script>
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
