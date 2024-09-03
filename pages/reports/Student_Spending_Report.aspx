<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Student_Spending_Report.aspx.vb" Inherits="Enterprise_Village_2._0.Student_Spending_Report" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>EV 2.0 - Student Spending Report</title>

    <link href="~/css/Styles.updated.css" rel="stylesheet" media="screen" type="text/css">
    <link href="~/css/Styles.print.css" rel="stylesheet" media="print" type="text/css">
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

        <%--Content--%>
        <div class="content">
            <h2 class="h2">Student Spending Report</h2>
            <h3 class="no-print">This page will allow you to view students's deposits, cash withdrawn, purchases at businesses, and more.<br />
                <br />
                To print this page as a PDF, click the 'Print' button below and select 'Print to PDF' under the Printer drop down list and click 'Save'.
            </h3>
            <p class="no-print">Enter a Visit Date:</p>
            <asp:TextBox ID="visitDate_tb" runat="server" AutoPostBack="true" TextMode="Date" CssClass="textbox no-print"></asp:TextBox>&emsp;&emsp;<asp:Label runat="server" ID="error_lbl" Font-Size="X-Large" Font-Bold="true" Visible="true" ForeColor="red" CssClass="no-print"></asp:Label>
            <p runat="server" id="selectschool_p" visible="false" class="no-print">Select School:</p>
            <asp:DropDownList ID="schools_ddl" runat="server" Visible="false" AutoPostBack="true" CssClass="ddl no-print"></asp:DropDownList>
            <br class="no-print" />
            <br class="no-print" />
            <asp:Button ID="print_btn" runat="server" CssClass="button3 button3 no-print" Text="Print" />
            <br class="no-print" />
            <br class="no-print" />
            <asp:Label ID="schoolName_lbl" runat="server" ForeColor="Black" Font-Size="XX-Large" Font-Bold="true"></asp:Label>
            <br />
            <br />
            <asp:GridView ID="students_dgv" runat="server" AutoGenerateColumns="False" CellPadding="5" CellSpacing="1" PageSize="20" Font-Size="Medium">
                <AlternatingRowStyle BackColor="#99CCFF" />
                <Columns>
                    <asp:BoundField DataField="accountNumber" HeaderText="Account Number" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="studentname" HeaderText="Name" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="Balance" HeaderText="Balance" ReadOnly="true" Visible="true" ItemStyle-Font-Bold="true" />
                    <asp:BoundField DataField="initialDeposit1" HeaderText="Deposit 1" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="initialDeposit2" HeaderText="Deposit 2" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="initialDeposit3" HeaderText="Deposit 3" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="initialDeposit4" HeaderText="Deposit 4" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="TotalDeposits" HeaderText="Total Deposits" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="TotalPurchases" HeaderText="Total Purchases" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="cbwTotal" HeaderText="Cash Withdrawn Total" ReadOnly="true" Visible="true" />
                    <asp:BoundField DataField="savings" HeaderText="Savings" ReadOnly="true" Visible="true" />
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <%--Astro Skate Sales--%>
            <div id="astro_div" runat="server" visible="false">
                <p runat="server">Astro Skate Sales:</p>
                <asp:GridView ID="astro_dgv" runat="server" AutoGenerateColumns="False" CellPadding="5" CellSpacing="1" PageSize="20" Font-Size="Medium">
                    <AlternatingRowStyle BackColor="#99CCFF" />
                    <Columns>
                        <asp:BoundField DataField="accountNumber" HeaderText="Account Number" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="studentName" HeaderText="Name" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="saleTotal" HeaderText="Total Purchases" ReadOnly="true" Visible="true" />
                    </Columns>
                </asp:GridView>
                <br />
            </div>

            <%--BBB Sales--%>
            <div id="bbb_div" runat="server" visible="false">
                <p runat="server">BBB Sales:</p>
                <asp:GridView ID="bbb_dgv" runat="server" AutoGenerateColumns="False" CellPadding="5" CellSpacing="1" PageSize="20" Font-Size="Medium">
                    <AlternatingRowStyle BackColor="#99CCFF" />
                    <Columns>
                        <asp:BoundField DataField="accountNumber" HeaderText="Account Number" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="studentName" HeaderText="Name" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="saleTotal" HeaderText="Total Purchases" ReadOnly="true" Visible="true" />
                    </Columns>
                </asp:GridView>
                <br />
            </div>

            <%--Koozie Group Sales--%>
            <div id="bic_div" runat="server" visible="false">
                <p runat="server">Koozie Group Sales:</p>
                <asp:GridView ID="bic_dgv" runat="server" AutoGenerateColumns="False" CellPadding="5" CellSpacing="1" PageSize="20" Font-Size="Medium">
                    <AlternatingRowStyle BackColor="#99CCFF" />
                    <Columns>
                        <asp:BoundField DataField="accountNumber" HeaderText="Account Number" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="studentName" HeaderText="Name" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="saleTotal" HeaderText="Total Purchases" ReadOnly="true" Visible="true" />
                    </Columns>
                </asp:GridView>
                <br />
            </div>

            <%--CVS Sales--%>
            <div id="cvs_div" runat="server" visible="false">
                <p runat="server">CVS Sales:</p>
                <asp:GridView ID="cvs_dgv" runat="server" AutoGenerateColumns="False" CellPadding="5" CellSpacing="1" PageSize="20" Font-Size="Medium">
                    <AlternatingRowStyle BackColor="#99CCFF" />
                    <Columns>
                        <asp:BoundField DataField="accountNumber" HeaderText="Account Number" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="studentName" HeaderText="Name" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="saleTotal" HeaderText="Total Purchases" ReadOnly="true" Visible="true" />
                    </Columns>
                </asp:GridView>
                <br />
            </div>

            <%--Ditek Sales--%>
            <div id="ditek_div" runat="server" visible="false">
                <p runat="server">Ditek Sales:</p>
                <asp:GridView ID="ditek_dgv" runat="server" AutoGenerateColumns="False" CellPadding="5" CellSpacing="1" PageSize="20" Font-Size="Medium">
                    <AlternatingRowStyle BackColor="#99CCFF" />
                    <Columns>
                        <asp:BoundField DataField="accountNumber" HeaderText="Account Number" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="studentName" HeaderText="Name" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="saleTotal" HeaderText="Total Purchases" ReadOnly="true" Visible="true" />
                    </Columns>
                </asp:GridView>
                <br />
            </div>

            <%--PCS Newsroom Sales--%>
            <div id="hsn_div" runat="server" visible="false">
                <p runat="server">PCS Newsroom Sales:</p>
                <asp:GridView ID="hsn_dgv" runat="server" AutoGenerateColumns="False" CellPadding="5" CellSpacing="1" PageSize="20" Font-Size="Medium">
                    <AlternatingRowStyle BackColor="#99CCFF" />
                    <Columns>
                        <asp:BoundField DataField="accountNumber" HeaderText="Account Number" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="studentName" HeaderText="Name" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="saleTotal" HeaderText="Total Purchases" ReadOnly="true" Visible="true" />
                    </Columns>
                </asp:GridView>
                <br />
            </div>

            <%--Kane's Sales--%>
            <div id="kanes_div" runat="server" visible="false">
                <p runat="server">Kane's Sales:</p>
                <asp:GridView ID="kanes_dgv" runat="server" AutoGenerateColumns="False" CellPadding="5" CellSpacing="1" PageSize="20" Font-Size="Medium">
                    <AlternatingRowStyle BackColor="#99CCFF" />
                    <Columns>
                        <asp:BoundField DataField="accountNumber" HeaderText="Account Number" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="studentName" HeaderText="Name" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="saleTotal" HeaderText="Total Purchases" ReadOnly="true" Visible="true" />
                    </Columns>
                </asp:GridView>
                <br />
            </div>

            <%--mcdonalds Sales--%>
            <div id="mcdonalds_div" runat="server" visible="false">
                <p runat="server">McDonald's Sales:</p>
                <asp:GridView ID="mcdonalds_dgv" runat="server" AutoGenerateColumns="False" CellPadding="5" CellSpacing="1" PageSize="20" Font-Size="Medium">
                    <AlternatingRowStyle BackColor="#99CCFF" />
                    <Columns>
                        <asp:BoundField DataField="accountNumber" HeaderText="Account Number" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="studentName" HeaderText="Name" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="saleTotal" HeaderText="Total Purchases" ReadOnly="true" Visible="true" />
                    </Columns>
                </asp:GridView>
                <br />
            </div>

            <%--bucs Sales--%>
            <div id="bucs_div" runat="server" visible="false">
                <p runat="server">Tampa Bay Bucs Sales:</p>
                <asp:GridView ID="bucs_dgv" runat="server" AutoGenerateColumns="False" CellPadding="5" CellSpacing="1" PageSize="20" Font-Size="Medium">
                    <AlternatingRowStyle BackColor="#99CCFF" />
                    <Columns>
                        <asp:BoundField DataField="accountNumber" HeaderText="Account Number" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="studentName" HeaderText="Name" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="saleTotal" HeaderText="Total Purchases" ReadOnly="true" Visible="true" />
                    </Columns>
                </asp:GridView>
                <br />
            </div>

            <%--Rays Sales--%>
            <div id="rays_div" runat="server" visible="false">
                <p runat="server">Tampa Bay Rays Sales:</p>
                <asp:GridView ID="rays_dgv" runat="server" AutoGenerateColumns="False" CellPadding="5" CellSpacing="1" PageSize="20" Font-Size="Medium">
                    <AlternatingRowStyle BackColor="#99CCFF" />
                    <Columns>
                        <asp:BoundField DataField="accountNumber" HeaderText="Account Number" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="studentName" HeaderText="Name" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="saleTotal" HeaderText="Total Purchases" ReadOnly="true" Visible="true" />
                    </Columns>
                </asp:GridView>
                <br />
            </div>

            <%--times Sales--%>
            <div id="times_div" runat="server" visible="false">
                <p runat="server">Power Design Sales:</p>
                <asp:GridView ID="times_dgv" runat="server" AutoGenerateColumns="False" CellPadding="5" CellSpacing="1" PageSize="20" Font-Size="Medium">
                    <AlternatingRowStyle BackColor="#99CCFF" />
                    <Columns>
                        <asp:BoundField DataField="accountNumber" HeaderText="Account Number" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="studentName" HeaderText="Name" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="saleTotal" HeaderText="Total Purchases" ReadOnly="true" Visible="true" />
                    </Columns>
                </asp:GridView>
                <br />
            </div>

            <%--TD SYNNEX Sales--%>
            <div id="techdata_div" runat="server" visible="false">
                <p runat="server">TD SYNNEX Sales:</p>
                <asp:GridView ID="techdata_dgv" runat="server" AutoGenerateColumns="False" CellPadding="5" CellSpacing="1" PageSize="20" Font-Size="Medium">
                    <AlternatingRowStyle BackColor="#99CCFF" />
                    <Columns>
                        <asp:BoundField DataField="accountNumber" HeaderText="Account Number" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="studentName" HeaderText="Name" ReadOnly="true" Visible="true" />
                        <asp:BoundField DataField="saleTotal" HeaderText="Total Purchases" ReadOnly="true" Visible="true" />
                    </Columns>
                </asp:GridView>
                <br />
            </div>

            <asp:HiddenField ID="visitdate_hf" runat="server" />
            <asp:HiddenField ID="businessID_hf" runat="server" />
            <asp:HiddenField ID="empnum_hf" runat="server" />
            <asp:HiddenField ID="rowsCount_hf" runat="server" />
        </div>

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
