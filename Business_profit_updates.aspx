<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Business_profit_updates.aspx.vb" Inherits="Enterprise_Village_2._0.Business_profit_updates" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>EV 2.0 - Edit Profits</title>

    <link href="css/Styles.updated.css" rel="stylesheet" media="screen" type="text/css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <link rel="shortcut icon" type="image/png" href="media/EV_favicon_2.png" />

    <style type="text/css">
        .tg {
            border-collapse: collapse;
            border-spacing: 0;
            margin: 0px auto;
        }

            .tg td {
                border-color: black;
                border-style: solid;
                border-width: 1px;
                font-family: Arial, sans-serif;
                font-size: 14px;
                overflow: hidden;
                padding: 10px 5px;
                word-break: normal;
            }

            .tg th {
                border-color: black;
                border-style: solid;
                border-width: 1px;
                font-family: Arial, sans-serif;
                font-size: 14px;
                font-weight: normal;
                overflow: hidden;
                padding: 10px 5px;
                word-break: normal;
            }

            .tg .tg-2bn0 {
                font-size: 26px;
                text-align: center;
                vertical-align: top
            }

            .tg .tg-hqh2 {
                font-size: 20px;
                text-align: left;
                text-decoration: underline;
                vertical-align: top
            }

            .tg .tg-0lax {
                text-align: left;
                vertical-align: top
            }

        .deposit4table {
            position: absolute;
            top: -844px;
            left: 640px;
        }
    </style>
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

        <%--Content--%>
        <div class="content">
            <h2 class="h2">Edit Profits</h2>
            <h3>This page will allow you to edit the profits and the miscellaneous deposits for each business.
                <br />
                <br />
                Click 'Edit' on the row of the business you which to edit. Change the profit and click 'Update'. 
                The Misc. Deposit will add to the total profits and display on the Online Banking page for that business. If you want to edit the profit directly, make sure that Misc. Deposit is 0 so it doesn't add to the profit.
            </h3>
            <asp:Label ID="error_lbl" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="X-Large"></asp:Label>
            <br />
            <asp:GridView ID="businessProfit_dgv" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="True" DataKeyNames="ID" CellPadding="5" CellSpacing="1" PageSize="20" Font-Size="Medium" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />
                    <asp:BoundField DataField="businessName" HeaderText="Business" ReadOnly="true" Visible="true" />
                    <asp:TemplateField HeaderText="Profits">
                        <ItemTemplate>
                            <asp:TextBox ID="profits_tb" runat="server" Width="50px" Text='<%#Bind("profits") %>' CssClass="textbox"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Misc.<br/> Deposit">
                        <ItemTemplate>
                            <asp:TextBox ID="deposit4_tb" runat="server" Width="50px" Text='<%#Bind("deposit4") %>' CssClass="textbox"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="loan" HeaderText="Loan Amount" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="startingAmount" HeaderText="Starting Amount" ReadOnly="true" Visible="true" />
                </Columns>
            </asp:GridView>
            <br />
            <div style="position: relative;">
                <table class="tg deposit4table">
                    <thead>
                        <tr>
                            <th class="tg-2bn0" colspan="2"><span style="font-weight: bold; text-decoration: underline">Misc. Deposits (Starting Amount) Amounts</span></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td class="tg-hqh2">Dollar Amount</td>
                            <td class="tg-hqh2">Business Name</td>
                        </tr>
                        <tr>
                            <td class="tg-0lax">60</td>
                            <td class="tg-0lax">Koozie</td>
                        </tr>
                        <tr>
                            <td class="tg-0lax">40</td>
                            <td class="tg-0lax">Buc's</td>
                        </tr>
                        <tr>
                            <td class="tg-0lax">60</td>
                            <td class="tg-0lax">CVS</td>
                        </tr>
                        <tr>
                            <td class="tg-0lax">60</td>
                            <td class="tg-0lax">Ditek</td>
                        </tr>
                        <tr>
                            <td class="tg-0lax">75</td>
                            <td class="tg-0lax">HSN</td>
                        </tr>
                        <tr>
                            <td class="tg-0lax">100</td>
                            <td class="tg-0lax">Mix</td>
                        </tr>
                        <tr>
                            <td class="tg-0lax">60</td>
                            <td class="tg-0lax">KnowBe4</td>
                        </tr>
                        <tr>
                            <td class="tg-0lax">60</td>
                            <td class="tg-0lax">Ray's</td>
                        </tr>
                        <tr>
                            <td class="tg-0lax">100</td>
                            <td class="tg-0lax">Times</td>
                        </tr>
                        <tr>
                            <td class="tg-0lax">50</td>
                            <td class="tg-0lax">TD SYNNEX</td>
                        </tr>
                        <tr>
                            <td class="tg-0lax">40</td>
                            <td class="tg-0lax">Astro</td>
                        </tr>
                        <tr>
                            <td class="tg-0lax">100</td>
                            <td class="tg-0lax">McDonalds</td>
                        </tr>
                        <tr>
                            <td class="tg-0lax">100</td>
                            <td class="tg-0lax">BBB</td>
                        </tr>
                    </tbody>
                </table>
            </div>

        </div>

        <asp:HiddenField ID="visitdate_hf" runat="server" />
        <asp:HiddenField ID="businessID_hf" runat="server" />

        <asp:SqlDataSource ID="Review_sds" runat="server"></asp:SqlDataSource>

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
    </form>
</body>
</html>

