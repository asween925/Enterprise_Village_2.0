<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Edit_Visit.aspx.vb" Inherits="Enterprise_Village_2._0.Edit_Visit" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>EV 2.0 - Edit Visit</title>

    <link href="css/Styles.updated.css" rel="stylesheet" media="screen" type="text/css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <link rel="shortcut icon" type="image/png" href="media/EV_favicon_2.png" />
<script src="https://code.jquery.com/jquery-1.10.2.js"></script>
</head>

<body>
    <form id="EMS_Form" runat="server">

        <%--Header information--%>
        <header class="headerTop no-print"><a style="float: left; padding-top: 2px;">Enterprise Village 2.0</a><a style="float: right; padding-right: 30px; padding-top: 2px;"><asp:Label ID="headerSchoolName_lbl" Text="School Name Here" runat="server"></asp:Label></a></header>

    <%--Navigation bar--%>
        <div id="nav-placeholder">

        </div>

        <script>
            $(function () {
                $("#nav-placeholder").load("nav.html");
            });
        </script>
       
        <div class="content">
            <h2 class="h2">Edit Visit</h2>
            <h3>This page will allow you to edit the visit information of a visit date in the database.
                <br /><br />
                Enter an existing visit date in the textbox below, then click the 'Edit' button to edit a visit date.
            </h3>
            <p>Visit Date:</p>
            <asp:TextBox ID="date_tb" runat="server" AutoPostBack="true" CssClass="textbox" TextMode="Date" ></asp:TextBox>&ensp;<asp:Label ID="error_lbl" runat="server" Font-Size="X-Large" ForeColor="Red" Font-Bold="true"></asp:Label>
            <br /><br />
            <asp:LinkButton ID="LinkButton11" runat="server" PostBackUrl="/upload_move_articles.aspx" CssClass="button3">Upload / Move Articles</asp:LinkButton>
            <br /><br />

            <%--Edit Visit Table--%>             
            <div class="gridviewDiv" id="gridview_div" runat="server" visible="false">              
                <asp:GridView ID="visit_dgv" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="true" DataKeyNames="ID" CellPadding="5" Font-Size="Medium" Visible="true" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />
                        <asp:TemplateField HeaderText="Visit Date">
                            <ItemTemplate>
                                <asp:TextBox ID="visitDate_tb" runat="server" Width="75px" Text='<%#Bind("visitDate", "{0:d}") %>' CssClass="textbox" ></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Visit Time">
                            <ItemTemplate>
                                <asp:TextBox ID="visitTime_tb" runat="server" Width="64px" Text='<%#Bind("visitTime") %>' CssClass="textbox"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="School #1">
                            <ItemTemplate>
                                <asp:Label id="schoolName1_lbl" runat="server" Text='<%#Bind("schoolid1") %>' Visible="false"></asp:Label>
                                <asp:DropDownList CssClass="ddl" ID="school1_ddl" runat="server" AutoPostBack="true" Width="150px"></asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="School #2">
                            <ItemTemplate>
                                <asp:Label id="schoolName2_lbl" runat="server" Text='<%#Bind("schoolid2") %>' Visible="false"></asp:Label>
                                <asp:DropDownList CssClass="ddl" ID="school2_ddl" runat="server" AutoPostBack="true" Width="150px"></asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="School #3">
                            <ItemTemplate>
                                <asp:Label id="schoolName3_lbl" runat="server" Text='<%#Bind("schoolid3") %>' Visible="false"></asp:Label>
                                <asp:DropDownList CssClass="ddl" ID="school3_ddl" runat="server" AutoPostBack="true" Width="150px"></asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="School #4">
                            <ItemTemplate>
                                <asp:Label id="schoolName4_lbl" runat="server" Text='<%#Bind("schoolid4") %>' Visible="false"></asp:Label>
                                <asp:DropDownList CssClass="ddl" ID="school4_ddl" runat="server" AutoPostBack="true" Width="100px"></asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="School #5">
                            <ItemTemplate>
                                <asp:Label id="schoolName5_lbl" runat="server" Text='<%#Bind("schoolid5") %>' Visible="false"></asp:Label>
                                <asp:DropDownList CssClass="ddl" ID="school5_ddl" runat="server" AutoPostBack="true" Width="100px"></asp:DropDownList>                           
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Training </br> Time Start">
                            <ItemTemplate>
                                <asp:TextBox ID="vTrainingTime_tb" runat="server" Text='<%#Bind("vTrainingTime") %>' Width="75px" CssClass="textbox"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Volunteer Min Count">
                            <ItemTemplate>
                                <asp:TextBox ID="vMinCount_tb" runat="server" Text='<%#Bind("vMinCount") %>' Width="55px" CssClass="textbox"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Volunteer Max Count">
                            <ItemTemplate>
                                <asp:TextBox ID="vMaxCount_tb" runat="server" Text='<%#Bind("vMaxCount") %>' Width="55px" CssClass="textbox"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Reply By Date">
                            <ItemTemplate>
                                <asp:TextBox ID="replyBy_tb" runat="server" Text='<%#Bind("replyBy", "{0:d}") %> ' Width="75px" CssClass="textbox"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Student Count">
                            <ItemTemplate>
                                <asp:TextBox ID="studentCount_tb" runat="server" Text='<%#Bind("studentCount") %>' Width="30px" CssClass="textbox"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>                        
                    </Columns>
                </asp:GridView>
            </div>

            <asp:HiddenField ID="visitdate_hf" runat="server" />
            <asp:HiddenField ID="visitdateUpdate_hf" runat="server" />
            <asp:Label ID="visitID_lbl" runat="server" Visible="false"></asp:Label>

        </div>

        <script src="Scripts.js"></script>
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

        <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
    </form>
</body>
</html>
