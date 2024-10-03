﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Volunteer_Database.aspx.vb" Inherits="Enterprise_Village_2._0.Volunteer_Database" MaintainScrollPositionOnPostback="true" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>EV 2.0 - Volunteer Database</title>

    <link href="~/css/Styles.updated.css" rel="stylesheet" media="screen" type="text/css">
    <link href="~/css/Styles.print.css" rel="stylesheet" media="print" type="text/css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png" />

    <script src="https://code.jquery.com/jquery-1.10.2.js"></script>

    <style>
        .tg-hfk9 {
            font-size: 20px;
        }

        .td-float {
            float: right;
        }
    </style>

</head>

<body>
    <form autocomplete="off" id="EMS_Form" runat="server">

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
            <h2 class="h2">Volunteer Database</h2>
            <h3>This is the volunteer database where you can add a new volunteer to the list and view all the volunteers in the database. Enter a visit date or select a school name to get started.
            </h3>
            <asp:Button ID="addVol_btn" runat="server" CssClass="button3" Text="Add New Volunteer" />&ensp;
            <asp:Button ID="scheduleVol_btn" runat="server" CssClass="button3" Text="Schedule Volunteers" />&ensp;
            <asp:Button ID="checkIn_btn" runat="server" CssClass="button3" Text="Check In Volunteers" />&ensp;
            <asp:Button ID="viewVol_btn" runat="server" CssClass="button3" Text="View Volunteers" />&ensp;
            &ensp;|&ensp;
            <asp:Button ID="businessAssignments_btn" runat="server" CssClass="button3" Text="View Assignments (Opens New Tab)"></asp:Button>&ensp;|&ensp;
            <asp:Button ID="refresh_btn" runat="server" CssClass="button3" Text="Refresh" />&ensp;<asp:Label ID="error_lbl" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="Red"></asp:Label>

            <%--Add New Volunteer--%>
            <div id="addVol_div" runat="server" visible="false" style="border-bottom: 1px solid gray; padding-bottom: 10px;">
                <h3>Add New Volunteer:</h3>
                <p>First Name:</p>
                <asp:TextBox ID="firstName_tb" runat="server" CssClass="textbox"></asp:TextBox>
                <p>Last Name:</p>
                <asp:TextBox ID="lastName_tb" runat="server" CssClass="textbox"></asp:TextBox>
                <p>School Name:</p>
                <asp:DropDownList ID="schoolNameAdd_ddl" runat="server" CssClass="ddl"></asp:DropDownList>
                <p>PR:</p>
                <asp:DropDownList ID="pr_ddl" runat="server" CssClass="ddl">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Not Registered</asp:ListItem>
                    <asp:ListItem>Active</asp:ListItem>
                    <asp:ListItem>Inactive</asp:ListItem>
                    <asp:ListItem>Hold</asp:ListItem>
                    <asp:ListItem>Pending</asp:ListItem>
                    <asp:ListItem>Staff</asp:ListItem>
                </asp:DropDownList>
                <p>SV Hours:</p>
                <asp:TextBox ID="svHours_tb" runat="server" CssClass="textbox" TextMode="Number" Text="6" Width="70px"></asp:TextBox>
                <p>Regular?</p>
                <asp:DropDownList ID="regularVol_ddl" runat="server" CssClass="ddl" Width="70px">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>Corporate</asp:ListItem>
                </asp:DropDownList>
                <p>Notes:</p>
                <asp:TextBox ID="notes_tb" runat="server" CssClass="textbox"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="submit_btn" runat="server" CssClass="button3" Text="Submit" />
            </div>

            <%--Schedule Volunteers--%>
            <div id="scheduleVol_div" runat="server" visible="false" style="border-bottom: 1px solid gray; padding-bottom: 10px;">
                <h3>Schedule Volunteers:</h3>
                <p>Filter by School Name (Optional):</p>
                <asp:DropDownList ID="schoolNameSchedule_ddl" runat="server" AutoPostBack="true" CssClass="ddl"></asp:DropDownList>
                <p>Volunteer Name:</p>
                <asp:DropDownList ID="volNameSchedule_ddl" runat="server" CssClass="ddl" AutoPostBack="true"></asp:DropDownList>
                <br />
                <br />

                <%--Table of Volunteers--%>
                <div id="scheduledVol_div" runat="server" visible="false">
                    <asp:GridView ID="scheduledVol_dgv" runat="server" Font-Size="Medium" Visible="true" PageSize="20" CellPadding="5" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows"></asp:GridView>

                    <%--Visit Date Schedule--%>
                    <p>Visit Date:</p>
                    <asp:TextBox ID="visitDateSchedule_tb" runat="server" CssClass="textbox" TextMode="Date" AutoPostBack="true"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="submitSchedule_btn" runat="server" CssClass="button3" Text="Submit" />
                </div>


            </div>

            <%--Check In Volunteer--%>
            <div id="checkIn_div" runat="server" visible="true" style="border-bottom: 1px solid gray; padding-bottom: 10px;">
                <h3>Check In Volunteers:</h3>
                <p>Visit Date: &emsp;&emsp;&emsp;&emsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a id="schoolNameCheckin_a" runat="server" visible="false">Scheduled Schools for Selected Visit Date:</a></p>
                <asp:TextBox ID="visitDateCheckin_tb" runat="server" TextMode="Date" CssClass="textbox" AutoPostBack="true"></asp:TextBox>&emsp;&emsp;<asp:DropDownList ID="schoolNameCheckin_ddl" runat="server" AutoPostBack="true" CssClass="ddl" Visible="false"></asp:DropDownList>
                <br />
                <br />
                <table>
                    <tbody>
                        <tr>
                            <td class="tg-hfk9"><a id="ach_a" runat="server">Achieva Credit Union: </a>
                                <asp:CheckBox ID="ach1_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <asp:CheckBox ID="ach2_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <asp:CheckBox ID="ach3_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <asp:CheckBox ID="ach4_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <%--<asp:TextBox ID="ach_tb" runat="server" CssClass="textbox" TextMode="Number" Width="40" Enabled="false"></asp:TextBox>--%>&ensp;<asp:DropDownList ID="regVolAch_ddl" runat="server" CssClass="ddl td-float" Enabled="false"></asp:DropDownList></td>
                            <td class="tg-hfk9"><a id="cvs_a" runat="server">CVS: </a>
                                <asp:CheckBox ID="cvs1_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <asp:CheckBox ID="cvs2_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <asp:CheckBox ID="cvs3_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <%--<asp:TextBox ID="cvs_tb" runat="server" CssClass="textbox" TextMode="Number" Width="40" Enabled="false"></asp:TextBox>--%>&ensp;<asp:DropDownList ID="regVolCVS_ddl" runat="server" CssClass="ddl td-float" Enabled="false"></asp:DropDownList></td>
                            <td class="tg-hfk9"><a id="pcsw_a" runat="server">PCSW: </a>
                                <asp:CheckBox ID="pcsw1_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <asp:CheckBox ID="pcsw2_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <%--<asp:TextBox ID="pcsw_tb" runat="server" CssClass="textbox" TextMode="Number" Width="40" Enabled="false"></asp:TextBox>--%>&ensp;<asp:DropDownList ID="regVolPCSW_ddl" runat="server" CssClass="ddl td-float" Enabled="false"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td class="tg-hfk9"><a id="astro_a" runat="server">Astro Skate: </a>
                                <asp:CheckBox ID="astro1_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <asp:CheckBox ID="astro2_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <%--<asp:TextBox ID="astro_tb" runat="server" CssClass="textbox" TextMode="Number" Width="40" Enabled="false"></asp:TextBox>--%>&ensp;<asp:DropDownList ID="regVolAstro_ddl" runat="server" CssClass="ddl td-float" Enabled="false"></asp:DropDownList></td>
                            <td class="tg-hfk9"><a id="ditek_a" runat="server">Ditek: </a>
                                <asp:CheckBox ID="ditek1_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <asp:CheckBox ID="ditek2_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <%--<asp:TextBox ID="ditek_tb" runat="server" CssClass="textbox" TextMode="Number" Width="40" Enabled="false"></asp:TextBox>--%>&ensp;<asp:DropDownList ID="regVolDitek_ddl" runat="server" CssClass="ddl td-float" Enabled="false"></asp:DropDownList></td>
                            <td class="tg-hfk9"><a id="know_a" runat="server">KnowBe4: </a>
                                <asp:CheckBox ID="know1_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <asp:CheckBox ID="know2_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <%--<asp:TextBox ID="know_tb" runat="server" CssClass="textbox" TextMode="Number" Width="40" Enabled="false"></asp:TextBox>--%>&ensp;<asp:DropDownList ID="regVolKnow_ddl" runat="server" CssClass="ddl td-float" Enabled="false"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td class="tg-hfk9"><a id="baycare_a" runat="server">BayCare: </a>
                                <asp:CheckBox ID="baycare1_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <asp:CheckBox ID="baycare2_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <%--<asp:TextBox ID="baycare_tb" runat="server" CssClass="textbox" TextMode="Number" Width="40" Enabled="false"></asp:TextBox>--%>&ensp;<asp:DropDownList ID="regVolBaycare_ddl" runat="server" CssClass="ddl td-float" Enabled="false"></asp:DropDownList></td>
                            <td class="tg-hfk9"><a id="duke_a" runat="server">Duke Energy: </a>
                                <asp:CheckBox ID="duke1_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <asp:CheckBox ID="duke2_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <%--<asp:TextBox ID="duke_tb" runat="server" CssClass="textbox" TextMode="Number" Width="40" Enabled="false"></asp:TextBox>--%>&ensp;<asp:DropDownList ID="regVolDuke_ddl" runat="server" CssClass="ddl td-float" Enabled="false"></asp:DropDownList></td>
                            <td class="tg-hfk9"><a id="bucs_a" runat="server">Tampa Bay Bucs: </a>
                                <asp:CheckBox ID="bucs1_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <asp:CheckBox ID="bucs2_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <%--<asp:TextBox ID="bucs_tb" runat="server" CssClass="textbox" TextMode="Number" Width="40" Enabled="false"></asp:TextBox>--%>&ensp;<asp:DropDownList ID="regVolBucs_ddl" runat="server" CssClass="ddl td-float" Enabled="false"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td class="tg-hfk9"><a id="bbb_a" runat="server">BBB: </a>
                                <asp:CheckBox ID="bbb1_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <asp:CheckBox ID="bbb2_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <%--<asp:TextBox ID="bbb_tb" runat="server" CssClass="textbox" TextMode="Number" Width="40" Enabled="false"></asp:TextBox>--%>&ensp;<asp:DropDownList ID="regVolBBB_ddl" runat="server" CssClass="ddl td-float" Enabled="false"></asp:DropDownList></td>
                            <td class="tg-hfk9"><a id="pcsn_a" runat="server">PCS Newsroom: </a>
                                <asp:CheckBox ID="pcsn1_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <asp:CheckBox ID="pcsn2_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <%--<asp:TextBox ID="hsn_tb" runat="server" CssClass="textbox" TextMode="Number" Width="40" Enabled="false"></asp:TextBox>--%>&ensp;<asp:DropDownList ID="regVolPCSN_ddl" runat="server" CssClass="ddl td-float" Enabled="false"></asp:DropDownList></td>
                            <td class="tg-hfk9"><a id="rays_a" runat="server">Tampa Bay Rays: </a>
                                <asp:CheckBox ID="rays1_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <asp:CheckBox ID="rays2_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <asp:CheckBox ID="rays3_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <%--<asp:TextBox ID="rays_tb" runat="server" CssClass="textbox" TextMode="Number" Width="40" Enabled="false"></asp:TextBox>--%>&ensp;<asp:DropDownList ID="regVolRays_ddl" runat="server" CssClass="ddl td-float" Enabled="false"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td class="tg-hfk9"><a id="bic_a" runat="server">Koozie Group: </a>
                                <asp:CheckBox ID="bic1_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <asp:CheckBox ID="bic2_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <asp:CheckBox ID="bic3_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <%--<asp:TextBox ID="bic_tb" runat="server" CssClass="textbox" TextMode="Number" Width="40" Enabled="false"></asp:TextBox>--%>&ensp;<asp:DropDownList ID="regVolBic_ddl" runat="server" CssClass="ddl td-float" Enabled="false"></asp:DropDownList></td>
                            <td class="tg-hfk9"><a id="kanes_a" runat="server">Kane's: </a>
                                <asp:CheckBox ID="kanes1_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <asp:CheckBox ID="kanes2_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <%--<asp:TextBox ID="kanes_tb" runat="server" CssClass="textbox" TextMode="Number" Width="40" Enabled="false"></asp:TextBox>--%>&ensp;<asp:DropDownList ID="regVolKanes_ddl" runat="server" CssClass="ddl td-float" Enabled="false"></asp:DropDownList></td>
                            <td class="tg-hfk9"><a id="power_a" runat="server">Power Design: </a>
                                <asp:CheckBox ID="power1_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <asp:CheckBox ID="power2_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <asp:CheckBox ID="power3_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <%--<asp:TextBox ID="times_tb" runat="server" CssClass="textbox" TextMode="Number" Width="40" Enabled="false"></asp:TextBox>--%>&ensp;<asp:DropDownList ID="regVolPower_ddl" runat="server" CssClass="ddl td-float" Enabled="false"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td class="tg-hfk9"><a id="city_a" runat="server">City Hall: </a>
                                <asp:CheckBox ID="city1_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <asp:CheckBox ID="city2_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <asp:CheckBox ID="city3_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <%--<asp:TextBox ID="city_tb" runat="server" CssClass="textbox" TextMode="Number" Width="40" Enabled="false"></asp:TextBox>--%>&ensp;<asp:DropDownList ID="regVolCity_ddl" runat="server" CssClass="ddl td-float" Enabled="false"></asp:DropDownList></td>
                            <td class="tg-hfk9"><a id="mcdonalds_a" runat="server">McDonald's: </a>
                                <asp:CheckBox ID="mcd1_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <asp:CheckBox ID="mcd2_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <asp:CheckBox ID="mcd3_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <%--<asp:TextBox ID="mcdonalds_tb" runat="server" CssClass="textbox" TextMode="Number" Width="40" Enabled="false"></asp:TextBox>--%>&ensp;<asp:DropDownList ID="regVolMcdonalds_ddl" runat="server" CssClass="ddl td-float" Enabled="false"></asp:DropDownList></td>
                            <td class="tg-hfk9"><a id="td_a" runat="server">TD SYNNEX: </a>
                                <asp:CheckBox ID="td1_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <asp:CheckBox ID="td2_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <asp:CheckBox ID="td3_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <%--<asp:TextBox ID="td_tb" runat="server" CssClass="textbox" TextMode="Number" Width="40" Enabled="false"></asp:TextBox>--%>&ensp;<asp:DropDownList ID="regVolTD_ddl" runat="server" CssClass="ddl td-float" Enabled="false"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td class="tg-hfk9"><a id="mix_a" runat="server">Mix 100.7: </a>

                                <asp:CheckBox ID="mix1_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <asp:CheckBox ID="mix2_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <%--<asp:TextBox ID="mix_tb" runat="server" CssClass="textbox" TextMode="Number" Width="40" Enabled="false"></asp:TextBox>--%>&ensp;<asp:DropDownList ID="regVolMix_ddl" runat="server" CssClass="ddl td-float" Enabled="false"></asp:DropDownList></td>
                            <td class="tg-hfk9"><a id="united_a" runat="server">United Way: </a>
                                <asp:CheckBox ID="uw1_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <asp:CheckBox ID="uw2_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <asp:CheckBox ID="uw3_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <%--<asp:TextBox ID="united_tb" runat="server" CssClass="textbox" TextMode="Number" Width="40" Enabled="false"></asp:TextBox>--%>&ensp;<asp:DropDownList ID="regVolUnited_ddl" runat="server" CssClass="ddl td-float" Enabled="false"></asp:DropDownList></td>
                            <td class="tg-hfk9"><a id="pcu_a" runat="server">PCU: </a>
                                <asp:CheckBox ID="pcu1_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <asp:CheckBox ID="pcu2_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <%--<asp:TextBox ID="pcu_tb" runat="server" CssClass="textbox" TextMode="Number" Width="40" Enabled="false"></asp:TextBox>--%>&ensp;<asp:DropDownList ID="regVolPCU_ddl" runat="server" CssClass="ddl td-float" Enabled="false"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td class="tg-hfk9"><a id="ups_a" runat="server">UPS: </a>
                                <asp:CheckBox ID="ups_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <%--<asp:TextBox ID="ups_tb" runat="server" CssClass="textbox" TextMode="Number" Width="40" Enabled="false"></asp:TextBox>--%>&ensp;<asp:DropDownList ID="regVolUPS_ddl" runat="server" CssClass="ddl td-float" Enabled="false"></asp:DropDownList></td>
                            <td class="tg-hfk9"><a id="dali_a" runat="server">Dali: </a>
                                <asp:CheckBox ID="dali_chk" runat="server" AutoPostBack="true" Enabled="false" />
                                <%--<asp:TextBox ID="dali_tb" runat="server" CssClass="textbox" TextMode="Number" Width="40" Enabled="false"></asp:TextBox>--%>&ensp;<asp:DropDownList ID="regVolDali_ddl" runat="server" CssClass="ddl td-float" Enabled="false"></asp:DropDownList></td>
                            <td class="tg-hfk9"></td>
                        </tr>
                    </tbody>
                </table>
                <br />
                <asp:Button ID="submitCheckIn_btn" runat="server" CssClass="button3" Text="Submit" />
            </div>

            <%--View Volunteers Control--%>
            <div id="viewVolControls_div" runat="server" visible="false" style="border-bottom: 1px solid gray; padding-bottom: 10px;">
                <h3>View Volunteers:</h3>
                <p>Visit Date:</p>
                <asp:TextBox ID="visitDateViewVolCtrl_tb" runat="server" CssClass="textbox" TextMode="Date" AutoPostBack="true"></asp:TextBox>
                <p>or Volunteer Name:</p>
                <asp:DropDownList ID="volNameViewVolCtrl_ddl" runat="server" CssClass="ddl" AutoPostBack="true"></asp:DropDownList>
                <br />
                <br />

                <p>Total SV Hours:
                    <asp:Label ID="totalSVHoursCtrl_lbl" runat="server"></asp:Label></p>
                <div id="viewVolCtrlDGV_div" runat="server" visible="false">
                    <asp:GridView ID="viewVolCtrl_dgv" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" CellPadding="5" Height="50" AllowPaging="True" ShowHeaderWhenEmpty="True" Font-Size="Medium" Visible="true" PageSize="20" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="true" Visible="false" />
                            <asp:BoundField DataField="volunteerID" HeaderText="Volunteer ID" ReadOnly="true" Visible="true" />
                            <asp:BoundField DataField="firstName" HeaderText="First Name" ReadOnly="true" Visible="true" />
                            <asp:BoundField DataField="lastName" HeaderText="Last Name" ReadOnly="true" Visible="true" />
                            <asp:BoundField DataField="visitDate" HeaderText="Visit Date" ReadOnly="true" Visible="true" />
                            <asp:BoundField DataField="schoolName" HeaderText="School Name" ReadOnly="true" Visible="true" />
                            <asp:BoundField DataField="pr" HeaderText="PR" ReadOnly="true" Visible="true" />
                            <asp:BoundField DataField="svHours" HeaderText="SV Hours" ReadOnly="true" Visible="true" />
                            <asp:BoundField DataField="notes" HeaderText="Notes" ReadOnly="true" Visible="true" />
                            <asp:BoundField DataField="regular" HeaderText="Regular Volunteer?" ReadOnly="true" Visible="true" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

            <%--Volunteers Gridview--%>
            <div id="viewVol_div" runat="server" visible="true">
                <p>
                    Search by First or Last Name: 
                    <asp:TextBox ID="search_tb" runat="server" CssClass="textbox"></asp:TextBox>&ensp;<asp:Button ID="search_btn" runat="server" CssClass="button3" Text="Search" />&ensp;|&ensp;
                    Sort By:
                    <asp:DropDownList ID="sortBy_ddl" runat="server" CssClass="ddl">
                        <asp:ListItem>Last Name</asp:ListItem>
                        <asp:ListItem>First Name</asp:ListItem>
                        <asp:ListItem>Recently Added</asp:ListItem>
                        <asp:ListItem>Business Name</asp:ListItem>
                        <asp:ListItem>School Name</asp:ListItem>
                        <asp:ListItem>Visit Date</asp:ListItem>
                        <asp:ListItem>PR</asp:ListItem>
                        <asp:ListItem>SV Hours</asp:ListItem>
                        <asp:ListItem>Regular Volunteer</asp:ListItem>
                    </asp:DropDownList>
                    &ensp;
                    <asp:DropDownList ID="ascDesc_ddl" runat="server" CssClass="ddl">
                        <asp:ListItem>Ascending</asp:ListItem>
                        <asp:ListItem>Descending</asp:ListItem>
                    </asp:DropDownList>&ensp;<asp:Button ID="sortBy_btn" runat="server" CssClass="button3" Text="Sort" />
                    &ensp;
                    <a>Total SV Hours:
                        <asp:Label ID="totalSVHours_lbl" runat="server" Text="-"></asp:Label></a>
                </p>
                <div>
                    <asp:GridView ID="volunteers_dgv" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="true" AutoGenerateDeleteButton="true" DataKeyNames="ID" CellPadding="5" Height="50" AllowPaging="True" ShowHeaderWhenEmpty="True" Font-Size="Medium" Visible="true" PageSize="20" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows">
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
                                    <asp:TextBox ID="visitDateDGV_tb" runat="server" TextMode="Date" Text='<%#Bind("visitDate", "{0:yyyy-MM-dd}") %>' CssClass="textbox"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Assigned<br/>Business">
                                <ItemTemplate>
                                    <asp:Label ID="businessNameDGV_lbl" runat="server" Text='<%#Bind("businessID") %>' Visible="false"></asp:Label>
                                    <asp:DropDownList CssClass="ddl" ID="businessNameDGV_ddl" runat="server" Width="200px" ReadOnly="false"></asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="School Name">
                                <ItemTemplate>
                                    <asp:Label ID="schoolNameDGV_lbl" runat="server" Text='<%#Bind("schoolID") %>' Visible="false"></asp:Label>
                                    <asp:DropDownList CssClass="ddl" ID="schoolNameDGV_ddl" runat="server" Width="200px" ReadOnly="false"></asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PR">
                                <ItemTemplate>
                                    <asp:Label ID="prDGV_lbl" runat="server" Text='<%#Bind("pr")%>' Visible="false"></asp:Label>
                                    <asp:DropDownList CssClass="ddl" ID="prDGV_ddl" runat="server" ReadOnly="false">
                                        <asp:ListItem>PR</asp:ListItem>
                                        <asp:ListItem>Not Registered</asp:ListItem>
                                        <asp:ListItem>Active</asp:ListItem>
                                        <asp:ListItem>Inactive</asp:ListItem>
                                        <asp:ListItem>Hold</asp:ListItem>
                                        <asp:ListItem>Pending</asp:ListItem>
                                        <asp:ListItem>Staff</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SV Hours">
                                <ItemTemplate>
                                    <asp:TextBox ID="svHoursDGV_tb" runat="server" Width="50px" Text='<%#Bind("svHours") %>' TextMode="Number" CssClass="textbox"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Notes">
                                <ItemTemplate>
                                    <asp:TextBox ID="notesDGV_tb" runat="server" Width="150px" Text='<%#Bind("notes") %>' CssClass="textbox" TextMode="MultiLine"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Regular<br/>Volunteer?">
                                <ItemTemplate>
                                    <asp:CheckBox ID="regularDGV_chk" runat="server" Checked='<%#Bind("regular") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <br />
                    <br />
                    <br />
                </div>
            </div>




            <asp:DropDownList CssClass="ddl" ID="businessCount_ddl" runat="server" Visible="false">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
                <asp:ListItem>13</asp:ListItem>
                <asp:ListItem>14</asp:ListItem>
                <asp:ListItem>15</asp:ListItem>
                <asp:ListItem>16</asp:ListItem>
                <asp:ListItem>17</asp:ListItem>
                <asp:ListItem>18</asp:ListItem>
                <asp:ListItem>19</asp:ListItem>
                <asp:ListItem>20</asp:ListItem>
                <asp:ListItem>21</asp:ListItem>
                <asp:ListItem>22</asp:ListItem>
                <asp:ListItem>23</asp:ListItem>
                <asp:ListItem>24</asp:ListItem>
            </asp:DropDownList>
        </div>

        <asp:HiddenField ID="currentVisitID_hf" runat="server" />

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

        <%--Delete confirmation--%>
        <script>
            jQuery("a").filter(function () {
                return this.innerHTML.indexOf("Delete") == 0;
            }).click(function () {
                return confirm("Are you sure you want to delete this volunteer?");
            });
        </script>

        <asp:SqlDataSource ID="Review_sds" runat="server"></asp:SqlDataSource>
    </form>
</body>
</html>
