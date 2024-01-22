<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Add_Remove_Amount.aspx.vb" Inherits="Enterprise_Village_2._0.Add_Remove_Amount" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>Add / Remove On Hand Amount</title>

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
                $("#nav-placeholder").load("navInv.html");
            });
        </script>

        <div class="content">
            <h2 class="h2 no-print">Add / Remove On Hand Amount</h2>
            <h3 class="no-print">Search for or select an item from the drop down menu to view more details about it and add or remove an amount from the database.
            </h3>
            <p>Item Name:</p>
            <asp:DropDownList CssClass="ddl" ID="items_ddl" runat="server" AutoPostBack="true"></asp:DropDownList>
            <p>Keyword Search:</p>
            <asp:TextBox ID="search_tb" runat="server" Visible="true" CssClass="textbox"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:Button ID="search_btn" runat="server" CssClass="button3" Text="Search" Visible="true" />
            <br />
            <asp:Label ID="error_lbl" runat="server" Font-Size="X-Large" ForeColor="Red"></asp:Label>
            <br />

            <%--Item Viewed--%>
            <div>
                <p style="border-bottom: 1px solid gray; padding-bottom: 10px; font-weight: bold;">
                    Item Name:
                    <asp:Label Font-Bold="false" Font-Underline="false" ID="itemName_lbl" runat="server"></asp:Label>&ensp;&ensp;
                    Merch Code: 
                    <asp:Label Font-Bold="false" Font-Underline="false" ID="merchCode_lbl" runat="server"></asp:Label>&ensp;&ensp;
                    Amount Used Daily: 
                    <asp:Label Font-Bold="false" Font-Underline="false" ID="usedDaily_lbl" runat="server"></asp:Label>
                </p>
                <div class="button_grid_inv" style="text-align: left; border-bottom: 1px solid gray; padding-bottom: 10px;">
                    <div class="button_item2">
                        <p style="font-weight: bold;">
                            Category:
                            <asp:Label Font-Bold="false" Font-Underline="false" ID="itemCategory_lbl" runat="server"></asp:Label>&ensp;&ensp;                          
                        </p>

                        <p style="font-weight: bold;">
                            Source:
                            <asp:Label Font-Bold="false" Font-Underline="false" ID="source_lbl" runat="server"></asp:Label>
                        </p>

                        <p style="font-weight: bold;">
                            Location:
                            <asp:Label Font-Bold="false" Font-Underline="false" ID="currentLocation_lbl" runat="server"></asp:Label>&ensp;&ensp;
                        </p>
                    </div>

                    <div class="button_item2">
                        <p style="font-weight: bold;">
                             Sub-Category:
                            <asp:Label Font-Bold="false" Font-Underline="false" ID="itemSubCat_lbl" runat="server"></asp:Label>&ensp;&ensp; 
                        </p>

                        <p style="font-weight: bold;">
                            Business Used:
                            <asp:Label Font-Bold="false" Font-Underline="false" ID="businessUsed_lbl" runat="server"></asp:Label>&ensp;&ensp;
                        </p>

                        <p style="font-weight: bold;">
                            Total Amount On Hand:
                            <asp:Label Font-Bold="false" Font-Underline="false" ID="onHand_lbl" runat="server"></asp:Label>&ensp;Previous Value: <asp:Label Font-Bold="false" Font-Underline="false" ID="previousOnHand_lbl" runat="server"></asp:Label>
                        </p>
                    </div>              
                </div>              
                <p style="font-weight: bold;">
                    Comments:
                    <asp:TextBox Font-Bold="false" Font-Underline="false" ID="comments_tb" runat="server" width="200px" Enabled="false" CssClass="textbox"></asp:TextBox>&ensp;&ensp;
                </p>

                <div class="button_grid_inv">
                    <div class="button_item2">
                        <p>Activity Date</p>
                        <asp:TextBox ID="date_tb" runat="server" TextMode="Date" CssClass="textbox"></asp:TextBox>
                    </div>

                    <div class="button_item2">
                        <p>Amount Being Added / Subtracted</p>
                        <asp:TextBox ID="amount_tb" runat="server" TextMode="Number" CssClass="textbox"></asp:TextBox>
                    </div>

                    <div class="button_item2">
                        <p>Additional Notes</p>
                        <asp:TextBox ID="notes_tb" runat="server" CssClass="textbox"></asp:TextBox>
                    </div> 

                    <div class="button_item2">
                        <br />
                        <br />
                        <asp:Button ID="enter_btn" runat="server" CssClass="button3" Text="Enter" />
                    </div>

                                                         
                </div>
                <br /> 

                <%--Timesheet Table--%>
                 <div class="button_item3">
                        <asp:GridView ID="items_dgv" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="true" DataKeyNames="ID" CellPadding="5" Height="50" AllowPaging="True" ShowHeaderWhenEmpty="True" Font-Size="Medium" Visible="true" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="Timestamp ID" ReadOnly="true" Visible="false" />
                                <asp:BoundField DataField="itemID" HeaderText="Item ID" Visible="false" />
                                <asp:BoundField DataField="itemName" HeaderText="Item Name" Visible="false" />
                                <asp:BoundField DataField="dateReceived" HeaderText="Date Received" Visible="false" />
                                <asp:TemplateField HeaderText="Date Received" Visible="true">
                                    <ItemTemplate>
                                        <asp:Textbox ID="dateReceiveddgv_tb" runat="server" Text='<%#Eval("dateReceived", "{0:MM/dd/yyyy}") %>' readonly="false" CssClass="textbox"></asp:Textbox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Notes">
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" ID="notesdgv_tb"  Text='<%#Bind("notes") %>' ReadOnly="false" Visible="true" CssClass="textbox" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="amount" HeaderText="Amount Being Added/Subtracted" Visible="true" />
                                <asp:BoundField DataField="lastEdited" HeaderText="Last Edited Date/Time" ReadOnly="true" Visible="true" />
                                <asp:BoundField DataField="lastEditedBy" HeaderText="Last Edited By" ReadOnly="true" Visible="true" />                               
                            </Columns>
                        </asp:GridView>
                    </div>
                <br />
            </div>
        </div>

        <asp:HiddenField ID="visitdate_hf" runat="server" />
        <asp:HiddenField ID="teachers_hf" runat="server" />
        <asp:HiddenField ID="itemID_hf" runat="server" />
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
