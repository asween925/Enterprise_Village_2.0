<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Volunteer_Database.aspx.vb" Inherits="Enterprise_Village_2._0.Volunteer_Database" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>EV 2.0 - Volunteer Database</title>

    <link href="css/Styles.updated.css" rel="stylesheet" media="screen" type="text/css">
    <link href="css/Styles.Print.css" rel="stylesheet" media="print" type="text/css">
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

        <%--Content--%>
        <div class="content">
            <h2 class="h2">Volunteer Database</h2>
            <h3>This is the volunteer database where you can add a new volunteer to the list and view all the volunteers in the database. Enter a visit date or select a school name to get started.
            </h3>
            <asp:Button ID="visitDate_btn" runat="server" Text="Load by Visit Date" CssClass="button3" />&emsp;<asp:Button ID="schoolName_btn" runat="server" Text="Load by School Name" CssClass="button3" />&ensp;|&ensp;<asp:Button ID="businessAssignments_btn" runat="server" CssClass="button3" Text="View Assignments (Opens New Tab)"></asp:Button><asp:Label ID="error_lbl" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="Red"></asp:Label>
            
            <%--Visit Date--%>
            <div id="visitDate_div" runat="server" visible="false">
                <p>Visit Date:&emsp;&emsp;&emsp;&emsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a id="visitDateSchools_a" runat="server" visible="false">Scheduled Schools for Selected Visit Date:</a></p>
                <asp:TextBox ID="visitDate_tb" runat="server" CssClass="textbox" TextMode="Date" AutoPostBack="true"></asp:TextBox>&emsp;&emsp;<asp:DropDownList ID="visitDateSchools_ddl" runat="server" AutoPostBack="true" CssClass="ddl" Visible="false"></asp:DropDownList>
            </div>
            
            <%--School Name--%>
            <div id="schoolName_div" runat="server" visible="false">
                <p>School Name: &emsp;&emsp;&emsp;&emsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a id="schoolVisitDate_a" runat="server" visible="false">Scheduled Visit Dates for Selected School:</a></p>
                <asp:DropDownList ID="schoolName_ddl" runat="server" CssClass="ddl" AutoPostBack="true" ></asp:DropDownList>&emsp;&emsp;<asp:DropDownList ID="schoolVisitDate_ddl" runat="server" CssClass="ddl" AutoPostBack="true" Visible="false"></asp:DropDownList>
            </div>                        
            
            <%--Add Volunteer--%>
            <div id="addVol_div" runat="server" visible="true" style="border-bottom: 1px solid gray; padding-bottom: 10px;">
                <p style="border-top: 1px solid gray; padding-top: 10px;">Add Volunteer:</p>
                <asp:TextBox ID="firstName_tb" runat="server" CssClass="textbox" placeholder="First Name" ></asp:TextBox>
                &ensp;&ensp;
                <asp:TextBox ID="lastName_tb" runat="server" CssClass="textbox" placeholder="Last Name"></asp:TextBox> 
                &ensp;&ensp;            
                <asp:DropDownList ID="businessName_ddl" runat="server" CssClass="ddl"></asp:DropDownList>
                &ensp;&ensp;
                <asp:DropDownList ID="pr_ddl" runat="server" CssClass="ddl">
                    <asp:ListItem>PR</asp:ListItem>
                    <asp:ListItem>N</asp:ListItem>
                    <asp:ListItem>Y</asp:ListItem>
                    <asp:ListItem>I</asp:ListItem>
                    <asp:ListItem>H</asp:ListItem>
                    <asp:ListItem>P</asp:ListItem>
                    <asp:ListItem>A</asp:ListItem>
                    <asp:ListItem>S</asp:ListItem>
                </asp:DropDownList>
                &ensp;&ensp;
                <asp:TextBox ID="svHours_tb" runat="server" CssClass="textbox" TextMode="Number" placeholder="SV Hours"></asp:TextBox>
                &ensp;&ensp;
                <asp:Button ID="submit_btn" runat="server" CssClass="button3" Text="Submit" />
            &emsp;&emsp; Total SV Hours for School: <asp:Label ID="totalSVHours_lbl" runat="server" Text="0"></asp:Label>
            </div>

            <%--View Volunteers--%>
            <div id="viewVol_div" runat="server">
                <p>Search by First or Last Name: 
                    <asp:TextBox ID="search_tb" runat="server" CssClass="textbox"></asp:TextBox>&ensp;<asp:Button ID="search_btn" runat="server" CssClass="button3" Text="Search" />&ensp;|&ensp;
                    Sort By:
                    <asp:DropDownList ID="sortBy_ddl" runat="server" CssClass="ddl">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Recently Added</asp:ListItem>
                        <asp:ListItem>First Name</asp:ListItem>
                        <asp:ListItem>Last Name</asp:ListItem>
                        <asp:ListItem>Business Name</asp:ListItem>
                        <asp:ListItem>School Name</asp:ListItem>
                        <asp:ListItem>Visit Date</asp:ListItem>
                        <asp:ListItem>PR</asp:ListItem>
                        <asp:ListItem>SV Hours</asp:ListItem>
                    </asp:DropDownList>
                    &ensp;
                    <asp:DropDownList ID="ascDesc_ddl" runat="server" CssClass="ddl">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Ascending</asp:ListItem>
                        <asp:ListItem>Descending</asp:ListItem>
                    </asp:DropDownList>&ensp;<asp:Button ID="sortBy_btn" runat="server" CssClass="button3" Text="Sort" />
                    &ensp;|&ensp;
                    <asp:Button ID="refresh_btn" runat="server" CssClass="button3" Text="Reset" />
                </p>
                <div>
                     <asp:GridView ID="volunteers_dgv" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="true" AutoGenerateDeleteButton="true" DataKeyNames="ID" CellPadding="5" Height="50" AllowPaging="True" ShowHeaderWhenEmpty="True" Font-Size="Medium" Visible="true" PageSize="10" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="true" Visible="true" />
                                <%--<asp:BoundField DataField="visitDate" HeaderText="Visit Date" Visible="true" DataFormatString="{0: MM/dd/yyyy }" />--%>
                                <asp:TemplateField HeaderText="First Name">
                                    <ItemTemplate>
                                        <asp:TextBox ID="firstNameDGV_tb" runat="server" Width="80px" Text='<%#Bind("firstName") %>' CssClass="textbox"></asp:TextBox>
                                    </ItemTemplate>                         
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Last Name">
                                    <ItemTemplate>
                                        <asp:TextBox ID="lastNameDGV_tb" runat="server" Width="80px" Text='<%#Bind("lastName") %>' CssClass="textbox"></asp:TextBox>
                                    </ItemTemplate>                         
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Visit Date">
                                    <ItemTemplate>
                                        <asp:TextBox ID="visitDateDGV_tb" runat="server" Width="80px" Text='<%# Convert.ToDateTime(Eval("visitDate")).ToString("MM/dd/yyyy") %>' CssClass="textbox" ></asp:TextBox>
                                    </ItemTemplate>                         
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Business">
                                    <ItemTemplate>
                                        <asp:Label id="businessNameDGV_lbl" runat="server" Text='<%#Bind("businessName") %>' Visible="false"></asp:Label>
                                        <asp:DropDownList CssClass="ddl" ID="businessNameDGV_ddl" runat="server" Width="200px" ReadOnly="false"></asp:DropDownList>
                                    </ItemTemplate>                         
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="School Name">
                                    <ItemTemplate>
                                        <asp:Label id="schoolNameDGV_lbl" runat="server" Text='<%#Bind("schoolName") %>' Visible="false"></asp:Label>
                                        <asp:DropDownList CssClass="ddl" ID="schoolNameDGV_ddl" runat="server" Width="200px" ReadOnly="false"></asp:DropDownList>
                                    </ItemTemplate>                         
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PR">
                                    <ItemTemplate>
                                        <asp:DropDownList CssClass="ddl" ID="prDGV_ddl" runat="server" ReadOnly="false">
                                            <asp:ListItem>Y</asp:ListItem>
                                            <asp:ListItem>S</asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>                         
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SV Hours">
                                    <ItemTemplate>
                                        <asp:TextBox ID="svHoursDGV_tb" runat="server" Width="50px" Text='<%#Bind("svHours") %>' CssClass="textbox" ></asp:TextBox>
                                    </ItemTemplate>                         
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Notes">
                                    <ItemTemplate>
                                        <asp:TextBox ID="notesDGV_tb" runat="server" Width="150px" Text='<%#Bind("notes") %>' CssClass="textbox" ></asp:TextBox>
                                    </ItemTemplate>                         
                                </asp:TemplateField>
                            </Columns>
                         <%--<EmptyDataTemplate>
                             <tr>  
                                <th>Employee Name</th>  
                                <th>Gender</th>  
                                <th>Date of Birth</th>  
                                <th>Department</th>  
                                <th></th>  
                             </tr>
                             
                             <tr>  
                                <td><asp:TextBox runat="server" ID="txtEmpName" CssClass="text"></asp:TextBox></td>  
                                <td><asp:TextBox runat="server" ID="txtEmpGender" CssClass="text"></asp:TextBox></td>  
                                <td><asp:TextBox runat="server" ID="txtEmpDOB" CssClass="text"></asp:TextBox></td>  
                                <td><asp:TextBox runat="server" ID="txtEmpDpt" CssClass="text" ></asp:TextBox></td>  
                                <td><asp:Button runat="server" ID="btnSave" Text="SAVE NEW RECORD" CssClass="Gridbutton" CommandName="EmptyDataTemplate" /></td>  
                            </tr>
                         </EmptyDataTemplate>--%>
                        </asp:GridView>
                </div>
            </div>
        </div>

        <asp:HiddenField ID="currentVisitID_hf" runat="server" />

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
    </form>
</body>
</html>
