<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Magic_Computer.aspx.vb" Inherits="Enterprise_Village_2._0.Magic_Computer" %>

<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>--%>
<%--<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>--%>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>EV 2.0 - Magic Computer</title>

    <link href="~/css/Styles.updated.css" rel="stylesheet" media="screen" type="text/css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png" />
    <script src="https://code.jquery.com/jquery-1.10.2.js"></script>
</head>

<body>
    <form autocomplete="off"  id="Account_Summary_Form" runat="server" defaultbutton="Enter_btn">

        <%--Header information--%>
        <header class="headerTop no-print"><a style="float: left; padding-top: 2px;">Enterprise Village 2.0</a><a style="float: right; padding-right: 30px; padding-top: 2px;"><asp:Label ID="headerSchoolName_lbl" Text="School Name Here" runat="server"></asp:Label></a></header>

        <%--Navigation bar--%>
        <div id="nav-placeholder">
        </div>

        <script>
            $(function () {
                $("#nav-placeholder").load("../nav.html");
            });
        </script>

        <asp:HiddenField ID="visitdate_hf" runat="server" />
        <asp:HiddenField ID="savingsCheck_hf" runat="server" />

        <%--Content--%>
        <div class="content">

            <%--Top Section--%>
            <h2 class="h2">Magic Computer</h2>
            <h3>This page will allow you to adjust account balance for a student, transfer direct deposit to all students, and to enable the 3rd deposit of the day.</h3>
            <p>Enter Account Number:</p>
            <asp:TextBox ID="accountNumber_tb" runat="server" TextMode="Number" Width="50px" CssClass="textbox"></asp:TextBox>
            &nbsp;&nbsp;
            <asp:Button runat="server" ID="Enter_btn" Text="Enter" CssClass="button3" />&emsp;<asp:Label ID="error_lbl" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="Red"></asp:Label>
            <p>or</p>
            <p>Select Student Name:</p>
            <asp:DropDownList ID="studentName_ddl" runat="server" AutoPostBack="true" CssClass="ddl"></asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="directDeposit_btn" runat="server" Text="Initiate Direct Deposit (Deposit #2)" CssClass="transfer_savings_btn" />
            <br />
            <br />
            <asp:Button ID="deposit3Enable_btn" runat="server" Text="Enable Deposit #3" CssClass="button3" />
            <br />
            <br />

            <%--Account Summary--%>
            <h2 class="h2">Account Summary</h2>
            <asp:Label ID="label21" runat="server" Font-Bold="true" Text="Name: " Font-Size="X-Large"></asp:Label><asp:Label ID="Name_lbl" runat="server" Font-Size="X-Large"></asp:Label>
            &nbsp; &nbsp;  &nbsp; &nbsp; &nbsp;              
            <asp:Label ID="Label22" runat="server" Font-Bold="true" Text="Account Number: " Font-Size="X-Large"></asp:Label><asp:Label ID="Employee_number_lbl" runat="server" Font-Size="X-Large"></asp:Label>
            <div>
                <br />
                <div>
                    <table>
                        <tr>
                            <td class="Table_row" style="border-bottom: 1px solid gray;">
                                <asp:Label ID="Label1" runat="server" Text="Deposit 1:   "></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label4" runat="server" Text="$"></asp:Label>
                                <asp:TextBox class="sales_tb" runat="server" ID="deposit1_tb" Width="50px" CssClass="textbox" TextMode="Number" step="any"></asp:TextBox>&nbsp;&nbsp;                              
                                <asp:Label ID="Label6" runat="server" Text="Cash:   "></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label19" runat="server" Text="$"></asp:Label>
                                <asp:TextBox ID="CBW1_tb" runat="server" Width="50px" CssClass="textbox" TextMode="Number" step="any"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button runat="server" ID="deposit1Update_btn" Text="Update" Font-Size="12px" Enabled="true" CssClass="button3" />
                            </td>
                        </tr>

                        <tr>
                            <td class="Table_row" style="border-bottom: 1px solid gray;">
                                <asp:Label ID="Label7" runat="server" Text="Deposit 2:   "></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label8" runat="server" Text="$"></asp:Label>
                                <asp:TextBox class="sales_tb" runat="server" ID="deposit2_tb" Width="50px" CssClass="textbox" TextMode="Number" step="any"></asp:TextBox>&nbsp;&nbsp;
                                <asp:Label ID="Label10" runat="server" Text="Cash:   "></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label14" runat="server" Text="$"></asp:Label>
                                <asp:TextBox class="sales_tb" runat="server" ID="CBW2_tb" Width="50px" CssClass="textbox" TextMode="Number" step="any"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button runat="server" ID="deposit2Update_btn" Text="Update" Enabled="true" Font-Size="12px" CssClass="button3" />
                            </td>
                        </tr>

                        <tr style="border-bottom: 1px solid black;">
                            <td class="Table_row" style="border-bottom: 1px solid gray;">
                                <asp:Label ID="Label11" runat="server" Text="Deposit 3:   "></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label12" runat="server" Text="$"></asp:Label>
                                <asp:TextBox class="sales_tb" runat="server" ID="Deposit3_tb" Width="50px" CssClass="textbox" TextMode="Number" step="any"></asp:TextBox>&nbsp;&nbsp;
                                <asp:Label ID="Label18" runat="server" Text="Cash:   "></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label3" runat="server" Text="$"></asp:Label>
                                <asp:TextBox class="sales_tb" runat="server" ID="CBW3_tb" Width="50px" CssClass="textbox" TextMode="Number" step="any"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button runat="server" ID="deposit3Update_btn" Text="Update" Enabled="true" Font-Size="12px" CssClass="button3" />
                            </td>
                        </tr>

                        <tr style="border-bottom: 1px solid black;">
                            <td class="Table_row" style="border-bottom: 1px solid gray;">
                                <asp:Label ID="Label15" runat="server" Text="Deposit 4:   "></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label16" runat="server" Text="$"></asp:Label>
                                <asp:TextBox class="sales_tb" runat="server" ID="Deposit4_tb" Width="50px" CssClass="textbox" TextMode="Number" step="any"></asp:TextBox>&nbsp;&nbsp;
                                <asp:Label ID="Label20" runat="server" Text="Cash:   "></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label2" runat="server" Text="$"></asp:Label>
                                <asp:TextBox class="sales_tb" runat="server" ID="CBW4_tb" Width="50px" CssClass="textbox" TextMode="Number" step="any"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button runat="server" ID="deposit4Update_btn" Text="Update" Enabled="true" Font-Size="12px" CssClass="button3" />
                            </td>
                        </tr>

                        <tr>
                            <td class="Table_row">
                                <asp:Label ID="Label24" runat="server" Text="Savings:   "></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label25" runat="server" Text="$"></asp:Label>
                                <asp:TextBox class="sales_tb" runat="server" ID="savings_tb" Width="50px" CssClass="textbox" TextMode="Number" step="any"></asp:TextBox>&nbsp;&nbsp;
                                <asp:Label ID="Label26" runat="server" Text="       "></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label27" runat="server" Text=" "></asp:Label>
                                &emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&nbsp;
                                <asp:Button runat="server" ID="savingsUpdate_btn" Text="Update" Enabled="true" Font-Size="12px" CssClass="button3" />
                                <br />
                                <br />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />

                    <%--Display Information--%>
                    <asp:Label ID="Label5" runat="server" Text="Total Deposits: "></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Total_deposit_lbl" runat="server" Text=""></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="Label9" runat="server" Text="Total Purchases: "></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                    <asp:Label ID="Total_purchases_lbl" runat="server" Text=""></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="Label13" runat="server" Text="Savings: "></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                    <i style="font-style: normal;" id="dollar_lbl" runat="server" visible="false">$</i><asp:Label ID="Savings_lbl" runat="server" Text=""></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="Label23" runat="server" Text="Cash Withdrawn: "></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    
                    <asp:Label ID="Cwd_lbl" runat="server" Text=""></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="Label17" runat="server" Text="Balance: " Font-Bold="True" BackColor="Yellow" Font-Underline="True"></asp:Label>

                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    
                    <asp:Label ID="Balance_lbl" runat="server" Text="" Font-Bold="True" BackColor="Yellow" Font-Underline="True"></asp:Label>
                    <br />
                    <br />
                    <br />
                </div>

                <%--Transactions--%>
                <asp:GridView ID="Transactions_dgv" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="false" CellPadding="5" CellSpacing="1" PageSize="20" Font-Size="Medium" DataKeyNames="ID" CssClass="transactions_dgv_table" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="true" Visible="false" />
                        <asp:BoundField DataField="Business" HeaderText="Business" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="saleAmount" HeaderText="Sale Amount 1" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="transactiontimestamp" HeaderText="Timestamp 1" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="saleAmount2" HeaderText="Sale Amount 2" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="transactiontimestamp2" HeaderText="Timestamp 2" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="saleAmount3" HeaderText="Sale Amount 3" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="transactiontimestamp3" HeaderText="Timestamp 3" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="saleAmount4" HeaderText="Sale Amount 4" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="transactiontimestamp4" HeaderText="Timestamp 4" ReadOnly="true" Visible="true" />
                        <asp:TemplateField HeaderText="Debit" Visible="false">
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="debit_dgvtb" TextMode="Number" Text='<%#Bind("saleAmount") %>' ReadOnly="true" Visible="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                <%--Negative Balance Table--%>
                <div>
                    <asp:GridView ID="businessProfit_dgv" runat="server" AutoGenerateColumns="False" CellPadding="5" CellSpacing="1" PageSize="20" Font-Size="Medium" Visible="false">
                        <AlternatingRowStyle BackColor="#99CCFF" />
                        <Columns>
                            <asp:BoundField DataField="employeeNumber" HeaderText="Account Number" ReadOnly="true" Visible="true" />
                            <asp:BoundField DataField="studentname" HeaderText="Name" ReadOnly="true" Visible="true" />
                            <asp:BoundField DataField="totaldeposits" HeaderText="Total Deposits" ReadOnly="true" Visible="true" />
                            <asp:BoundField DataField="totalpurchases" HeaderText="Total Purchases" ReadOnly="true" Visible="true" />
                            <asp:BoundField DataField="balance" HeaderText="Balance" ReadOnly="true" Visible="true" ControlStyle-Font-Bold="true" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>

        <asp:HiddenField ID="empnum_hf" runat="server" />
        <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
        <script src="../Scripts.js"></script>
        <script>
            /* Loop through all dropdown buttons to toggle between hiding and showing its dropdown content - This allows the user to have multiple dropdowns without any conflict */
            $(".sub-menu ul").hide();
            $(".sub-menu a").click(function () {
                $(this).parent(".sub-menu").children("ul").slideToggle("100");
                $(this).find(".right").toggleClass("fa-caret-up fa-caret-down");
            });
        </script>

    </form>
</body>
</html>

