<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Account_Summary.aspx.vb" Inherits="Enterprise_Village_2._0.Account_Summary" %>

<!doctype html>
<html>
<head runat="server">

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>Account Summary</title>

    <link href="~/~/css/Styles.profit.css" rel="stylesheet" type="text/css">
    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png" />
</head>

<body>
    <form autocomplete="off"  id="Account_Summary_Form" runat="server" defaultbutton="Enter_btn">
        <div id="site_wrap_ATM">

            <%--Screen 1--%>
            <div id="Screen1">
                <div class="main_atm">
                    <asp:HiddenField ID="visitdate_hf" runat="server" />
                    <br />    
                    <asp:Label ID="Label2" runat="server" Text="ATM" Font-Size="100px"></asp:Label>
                    <br />
                    <p style="font-size: 25px;">Swipe your debit card, use the arrows in the box to select your account number,<br /> or tap 'Open Keyboard' to enter your account number manually.</p>
                    <br /><br />
                    
                    <asp:TextBox ID="employee_number" TextMode="Number" runat="server" Width="155px" Font-Size="80px"></asp:TextBox>
                    <br /><br />
                    
                    <asp:Button runat="server" ID="Enter_btn" Width="200px" Height="80px" Text="Enter" Font-Size="50px" CssClass="button button1" />
                    <br /><br />
                    
                    <asp:Button runat="server" ID="osk_btn"  Width="200px" Height="80px" Text="Open Keyboard" Font-Size="20px" CssClass="button button1" />
                    <br /><br />
                    
                    <%--ATM Keypad--%>
                    <div style="position: relative;">
                        <div class="ATM_keyboard">
                            <input type="button" class="numbutton" name="1" value="1" id="number1_btn" onclick="addNumber(this);" runat="server" visible="false" style="width: 80px;"/>
                            <input type="button" class="numbutton" name="2" value="2" id="number2_btn" onclick="addNumber(this);" runat="server" visible="false" style="width: 80px;"/>
                            <input type="button" class="numbutton" name="3" value="3" id="number3_btn" onclick="addNumber(this);" runat="server" visible="false" style="width: 80px;"/>
                            <br />
                            <input type="button" class="numbutton" name="4" value="4" id="number4_btn" onclick="addNumber(this);" runat="server" visible="false" style="width: 80px;"/>
                            <input type="button" class="numbutton" name="5" value="5" id="number5_btn" onclick="addNumber(this);" runat="server" visible="false" style="width: 80px;"/>
                            <input type="button" class="numbutton" name="6" value="6" id="number6_btn" onclick="addNumber(this);" runat="server" visible="false" style="width: 80px;"/>
                            <br />
                            <input type="button" class="numbutton" name="7" value="7" id="number7_btn" onclick="addNumber(this);" runat="server" visible="false" style="width: 80px;"/>
                            <input type="button" class="numbutton" name="8" value="8" id="number8_btn" onclick="addNumber(this);" runat="server" visible="false" style="width: 80px;"/>
                            <input type="button" class="numbutton" name="9" value="9" id="number9_btn" onclick="addNumber(this);" runat="server" visible="false" style="width: 80px;"/>
                            <input type="button" class="numbutton" name="0" value="0" id="number0_btn" onclick="addNumber(this);" runat="server" visible="false" style="width: 80px;"/>
                            <br />
                            <asp:Button ID="numberClear_btn" runat="server" Text="Clear" Visible="false" CssClass="numbutton" />                          
                        </div>
                    </div>
                    <br />
                    <asp:Label ID="error2_lbl" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="Red"></asp:Label>
                    <br /><br />
                </div>
            </div>

            <%--Screen 2--%>
            <div id="Screen2">
                <div class="main_atm">
                    <br /><br />  
                    <div class="Sales_header">
                        <div class="Business_name no-print">
                            <asp:Label ID="label21" runat="server" Text="Name: "></asp:Label>
                            <asp:Label ID="Name_lbl" runat="server"></asp:Label>&ensp;
                            <asp:Label ID="Label22" runat="server" Text="Employee Number: "></asp:Label><asp:Label ID="Employee_number_lbl" runat="server"></asp:Label>
                        </div>
                        <%--<div class="Customer_name">
                            <asp:Label ID="Label22" runat="server" Text="Employee Number: "></asp:Label><asp:Label ID="Employee_number_lbl" runat="server"></asp:Label>
                        </div>--%>
                    </div>
                    <br /><br /><br />       
                    <%--ATM Table--%>
                    <div class="business_name">
                        <div class="Summary">                         
                            <table class="Summary_table">
                                <tr>
                                    <td class="Table_row">
                                        <asp:Label ID="Label1" runat="server" Text="Deposit 1"></asp:Label></td>
                                    <td class="Table_row">
                                        <asp:Label ID="Deposit1_lbl" runat="server" Text=""></asp:Label></td>
                                    <td class="Table_row">
                                        <asp:Label ID="Label5" runat="server" Text="Total Deposits"></asp:Label></td>
                                    <td class="Table_row">
                                        <asp:Label ID="Total_deposit_lbl" runat="server" Text=""></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="Table_row">
                                        <asp:Label ID="Label7" runat="server" Text="Deposit 2"></asp:Label></td>
                                    <td class="Table_row">
                                        <asp:Label ID="Deposit2_lbl" runat="server" Text=""></asp:Label></td>
                                    <td class="Table_row">
                                        <asp:Label ID="Label9" runat="server" Text="Total Purchases"></asp:Label></td>
                                    <td class="Table_row">
                                        <asp:Label ID="Total_purchases_lbl" runat="server" Text=""></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="Table_row">
                                        <asp:Label ID="Label11" runat="server" Text="Deposit 3"></asp:Label></td>
                                    <td class="Table_row">
                                        <asp:Label ID="Deposit3_lbl" runat="server" Text=""></asp:Label></td>
                                    <td class="Table_row">
                                        <asp:Label ID="Label13" runat="server" Text="Savings"></asp:Label></td>
                                    <td class="Table_row">
                                        <asp:Label ID="Savings_lbl" runat="server" Text=""></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="Table_row">
                                        <asp:Label ID="Label15" runat="server" Text="Deposit 4"></asp:Label></td>
                                    <td class="Table_row">
                                        <asp:Label ID="Deposit4_lbl" runat="server" Text=""></asp:Label></td>
                                    <td class="Table_row">
                                        <asp:Label ID="Label17" runat="server" Text="Balance" Font-Bold="True" Font-Underline="True" BackColor="Yellow"></asp:Label></td>
                                    <td class="Table_row">
                                        <asp:Label ID="Balance_lbl" runat="server" Text="" Font-Bold="True" BackColor="Yellow" Font-Underline="True"></asp:Label></td>
                                </tr>
                            </table>

                            <asp:Label ID="error_lbl" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="Red"></asp:Label>
                        </div>

                        <%--Transactions--%>
                        <div class="ATM_transactions">
                            <asp:GridView ID="Transactions_dgv" HorizontalAlign="Center" CssClass="ATM_transactions_table" runat="server" AutoGenerateColumns="False" CellPadding="10" CellSpacing="1" PageSize="20" Visible="true" BorderColor="black">
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="true" Visible="false" />
                                    <asp:BoundField DataField="transactiontimestamp" HeaderText="Timestamp" ReadOnly="true" Visible="true" />
                                    <asp:BoundField DataField="BusinessName" HeaderText="Business" ReadOnly="true" Visible="true" />
                                    <asp:BoundField DataField="Saleamount" HeaderText="Sale Amount" ReadOnly="true" Visible="true" />
                                </Columns>
                            </asp:GridView>
                            <br /><br />                           
                            <asp:Button ID="exit_btn" runat="server" Width="250px" Height="105px" Text="Exit" Font-Size="60px" CssClass="button button1" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <script src="../../Scripts.js"></script>
        <script>
            function addNumber(element){
                document.getElementById('employee_number').value = document.getElementById('employee_number').value+element.value;
            }
        </script>

    </form>
</body>
</html>
