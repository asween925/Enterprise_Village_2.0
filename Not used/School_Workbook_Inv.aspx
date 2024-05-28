<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="School_Workbook_Inv.aspx.vb" Inherits="Enterprise_Village_2._0.School_Workbook_Inv" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>School Workbook Inventory</title>

    <link href="~/css/Styles.print.css" rel="stylesheet" media="print" type="text/css">
    <link href="~/css/Styles.updated.css" rel="stylesheet" media="screen" type="text/css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png" />

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
                $("#nav-placeholder").load("../../nav.html");
            });
        </script>

        

        <%--Content--%>
        <div class="content">
            <h2 class="h2 no-print">School Workbook Inventory</h2>
            <h3 class="no-print">This page will allow you to edit a school in the database. Use the drop down menu below to view a specific school. You can also use the textbox under that to search for names, emails, phone numbers, and anything else.
            </h3>
            <p>School Name:</p>
            <asp:DropDownList CssClass="ddl" ID="schoolNameSearch_ddl" runat="server" Width="200px" AutoPostBack="true"></asp:DropDownList> &ensp; <asp:Label ID="error_lbl" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="X-Large" Text=""></asp:Label>   
            <br /><br />
            
            <div id="school_div" runat="server" visible="false">
                <%--School Name Display--%>
                <p style="border-bottom: 1px solid gray; padding-bottom: 10px;"><asp:Label ID="schoolName_lbl" runat="server" Font-Bold="true"></asp:Label></p>

                <%--School Information Display--%>
                <div class="button_grid_inv" style="text-align: left; padding-bottom: 10px;">

                        <div class="button_item2">
                            <p style="font-weight: bold;">
                                Phone Number:
                                <asp:Label Font-Bold="false" Font-Underline="false" ID="phone_lbl" runat="server"></asp:Label>&ensp;&ensp;                          
                            </p>

                            <p style="font-weight: bold;">
                                Visit Date:
                                <asp:Label Font-Bold="false" Font-Underline="false" ID="visitDate_lbl" runat="server"></asp:Label>
                            </p>
                        </div>

                        <div class="button_item2">
                            <p style="font-weight: bold;">
                                Student Count:
                                <asp:Label Font-Bold="false" Font-Underline="false" ID="studentCount_lbl" runat="server"></asp:Label>&ensp;&ensp;                          
                            </p>

                            <p style="font-weight: bold;">
                                Contact:
                                <asp:Label Font-Bold="false" Font-Underline="false" ID="contactTeacher_lbl" runat="server"></asp:Label>
                            </p>
                        </div>

                    <div class="button_item2">
                        <p style="font-weight: bold;">
                                School Type:
                                <asp:Label Font-Bold="false" Font-Underline="false" ID="schoolType_lbl" runat="server"></asp:Label>&ensp;&ensp;                          
                            </p>

                            <p style="font-weight: bold;">
                                County:
                                <asp:Label Font-Bold="false" Font-Underline="false" ID="county_lbl" runat="server"></asp:Label>
                            </p>
                    </div>

                </div>

                <%--Workbook Requests and Delivery Input--%>
                <div class="button_grid_inv" style="text-align: left; padding-bottom: 10px;">

                    <div class="button_item2">
                        <p style="margin-top: 40px;">
                            <asp:Button ID="addRequest_btn" runat="server" CssClass="button3" Text="Add Request" />
                        </p>                     
                    </div>

                    <div class="button_item2">
                        <p>
                            Date Request:</p>
                            <asp:TextBox ID="dateRequest_tb" runat="server" TextMode="Date" style="margin-bottom: 4px;"></asp:TextBox>
                    </div>

                    <div class="button_item2">
                        <p>
                            Number Requested:</p>
                            <asp:TextBox ID="numRequest_tb" runat="server" TextMode="Number" Width="50px"></asp:TextBox>                                        
                    </div>
                </div>

                <%--Workbook Requests and Delivery Table--%>
                <div class="button_item3">
                    <asp:GridView ID="workbooks_dgv" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="true" DataKeyNames="ID" CellPadding="5" Height="50" AllowPaging="True" ShowHeaderWhenEmpty="True" Font-Size="Medium" Visible="true" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows">
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="true" Visible="true" />
                                    <asp:BoundField DataField="schoolName" HeaderText="School Name" ReadOnly="true" Visible="true" />
                                    <asp:TemplateField HeaderText="Date <br/> Requested" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="dgvDateReq_tb" runat="server" Width="100px" Text='<%#Eval("dateRequested", "{0:MM/dd/yyyy}") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Workbooks <br/> Requested" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="workbooksRequested_tb" runat="server" Width="80px" Text='<%#Bind("workbooksRequested") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date <br/> Delivered" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="dgvDateDel_tb" runat="server" Width="100px" Text='<%#Eval("dateDelivered", "{0:MM/dd/yyyy}") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Workbooks <br/> Delivered" Visible="true">
                                        <ItemTemplate>
                                            <asp:Textbox ID="workbooksDelivered_tb" runat="server" Width="80px" Text='<%# Bind("workbooksDelivered") %>'></asp:Textbox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                   </asp:GridView>
                </div>
            </div>
            
        </div>

        <asp:HiddenField ID="visitdate_hf" runat="server" />
        <asp:HiddenField ID="visitdateUpdate_hf" runat="server" />

        <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
        <script src="../../Scripts.js"></script> 

        <asp:SqlDataSource ID="Review_sds" runat="server"></asp:SqlDataSource>
        <asp:SqlDataSource ID="print_sds" runat="server"></asp:SqlDataSource>
    </form>
</body>
</html>
