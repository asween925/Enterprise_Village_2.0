<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Z_Test_Page.aspx.vb" Inherits="Enterprise_Village_2._0.Z_Test_Page" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>Test page</title>

    <link href="~/css/Styles.updated.css" rel="stylesheet" media="screen" type="text/css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png" />
    <script src="https://code.jquery.com/jquery-1.10.2.js"></script>

    <style>
        .content_test {
            margin-left: 16%;
            padding: 1px 16px;
            margin-top: 47px;
        }
        .header {
            background: #116bfa;
            color: white;
            padding: 11px;
            position: fixed;
            top: 0px;
            width: 100%;
        }

        .body_test {
            margin: 0;
            padding: 0;
            font-family: 'Franklin Gothic Book', sans-serif;
            background: #262626;
            color: white;
        }

        .sidebar_test {
            background: #262626;
            color: white;
        }

        .nav {
            background: #0e0e0e;
            color: white;
        }
    </style>
</head>

<body class="body_test">
    <form autocomplete="off"  id="EMS_Form" runat="server">

        <%--Header information--%>
        <header class="headerTop"><a style="float: left; padding-top: 2px;">Enterprise Village 2.0</a><a style="float: right; padding-right: 30px; padding-top: 2px;"><asp:Label ID="headerSchoolName_lbl" Text="School Name Here" runat="server"></asp:Label></a></header>
        
        <%--Navigation bar--%>
        <div id="nav-placeholder" class="sidebar_test">
        </div>

        <script>
            $(function () {
                $("#nav-placeholder").load("../../nav.html");
            });
        </script>

        <%--Content--%>
        <div class="content_test">
            <%--<div style="max-height: 100%; overflow:auto;border:1px solid red;">
                <div style="height: 1000px; border:5px solid yellow;">--%>
                    <h2 class="h2">Checklist Directory</h2>
                    <p>Upload File:</p>
                    <asp:FileUpload ID="fileUpload_fu" runat="server" />
                    <br />
                    <asp:Button ID="upload_btn" runat="server" Text="Upload" />
                    <br />
            <asp:Button ID="print_btn" runat="server" Text="Print" />
                    <br />
                    <asp:Label ID="error_lbl" runat="server" Text="Test"></asp:Label>
                    <br />
                    <br />
                    <asp:TextBox ID="test_tb" runat="server" CssClass="textbox" TextMode="Date"></asp:TextBox>
                    <br />
                    <br />
                    <asp:GridView ID="items_dgv" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="false" DataKeyNames="ID" CellPadding="5" Height="50" AllowPaging="True" ShowHeaderWhenEmpty="True" Font-Size="Medium" Visible="true" PageSize="300" CssClass="gridview">
                        <AlternatingRowStyle BackColor="#99CCFF" />
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="true" Visible="true" />
                            <asp:BoundField DataField="itemName" HeaderText="Item Name" Visible="true" />
                            <asp:BoundField DataField="itemCategory" HeaderText="Item Category" Visible="true" />
                            <asp:BoundField DataField="itemSubCat" HeaderText="Item Sub-Category" Visible="true" />
                            <asp:BoundField DataField="currentLocation" HeaderText="Current Location" Visible="true" />
                            <asp:BoundField DataField="businessUsed" HeaderText="Current Location in EV" Visible="true" />
                            <asp:BoundField DataField="onHand" HeaderText="Total Amount On Hand" Visible="true" />
                            <asp:BoundField DataField="source" HeaderText="Source" Visible="true" />
                            <asp:BoundField DataField="merchCode" HeaderText="Merch Code" Visible="true" />
                            <asp:BoundField DataField="usedDaily" HeaderText="Amount Used Daily" Visible="true" />
                            <asp:BoundField DataField="comments" HeaderText="Comments" Visible="true" />
                        </Columns>
                    </asp:GridView>

                    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><p>Testtttttttt</p>
<%--                </div>
            </div>        --%>   
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
    </form>
</body>
</html>
