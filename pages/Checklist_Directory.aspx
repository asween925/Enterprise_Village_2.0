<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Checklist_Directory.aspx.vb" Inherits="Enterprise_Village_2._0.Checklist_Directory" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>Checklist Directory</title>

    <link href="~/css/Styles.updated.css" rel="stylesheet" media="screen" type="text/css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png" />
    <script src="https://code.jquery.com/jquery-1.10.2.js"></script>
</head>

<body>
    <form autocomplete="off"  id="EMS_Form" runat="server">

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
            <h2 class="h2">Checklist Directory</h2>
            <div class="button_grid">
                <div class="button_item">
                    <asp:Label ID="error_lbl" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                    <!---Astro Skate--->
                    <asp:Image ID="Image1" runat="server" Class="Business_logo" ImageUrl="~/media/logos/AstroSkate/astroskate.png" />
                    <br />
                    <asp:LinkButton ID="LinkButton11" runat="server" PostBackUrl="/pages/checklists/astro_skate_editorial.aspx" CssClass="button3">Editoral</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton12" runat="server" PostBackUrl="/pages/checklists/astro_skate_rink_manager_checklist.aspx" CssClass="button3">Rink Manager Checklist</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton18" runat="server" PostBackUrl="/pages/checklists/astro_skate_skate_attendant.aspx" CssClass="button3">Skate Attendant</asp:LinkButton>
                </div>

                <div class="button_item">
                    <!---Achieva Credit Union (formerly Bank of America)--->
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/media/logos/Achieva/achieva.png" Class="Business_logo" />
                    <br />
                    <asp:LinkButton ID="LinkButton9" runat="server" PostBackUrl="/pages/checklists/bank_of_america_manager_checklist.aspx" CssClass="button3">Branch Manager Checklist</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton10" runat="server" PostBackUrl="/pages/checklists/bank_of_america_representative_checklist.aspx" CssClass="button3">Representative Checklist</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton3" runat="server" PostBackUrl="/pages/checklists/bank_of_america_savings_officer_checklist.aspx" CssClass="button3">Savings Officer Checklist</asp:LinkButton>
                </div>

                <%--<br />--%>

                <div class="button_item">
                    <!---Bay Care--->
                    <asp:Image ID="Image15" runat="server" ImageUrl="~/media/logos/BayCare/bayCare.jpg" Class="Business_logo" />
                    <br />
                    <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="/pages/checklists/baycare_bill_collection_checklist.aspx" CssClass="button3">Bill Collection Checklist</asp:LinkButton>
                </div>

                <div class="button_item">
                    <!---BBB--->
                    <asp:Image ID="Image4" runat="server" ImageUrl="~/media/logos/bbb/bbb.png" Class="Business_logo" />
                    <br />
                    <asp:LinkButton ID="LinkButton15" runat="server" PostBackUrl="/pages/checklists/bbb_accreditation_specialist_checklist.aspx" CssClass="button3">BBB Accreditation Specialist Checklist</asp:LinkButton>
                    <br />
                    <%--<asp:LinkButton ID="LinkButton16" runat="server" PostBackUrl="bbb_information_specialist_checklist.aspx" CssClass="button3">BBB Information Specialist Checklist</asp:LinkButton>--%>
                </div>

                <%--<br />--%>

                <div class="button_item">
                    <!---Bic--->
                    <asp:Image ID="Image5" runat="server" ImageUrl="~/media/logos/Bic/Bic.jpg" Class="Business_logo" />
                    <br />
                    <asp:LinkButton ID="LinkButton17" runat="server" PostBackUrl="/pages/checklists/Bic_Graphic_Manager_Advertising_Letter_Checklist.aspx" CssClass="button3">Manager's Advertising Letter Checklist</asp:LinkButton>
                </div>
                <!---city Hall--->
                <div class="button_item">
                    <asp:Image ID="Image6" runat="server" ImageUrl="~/media/logos/city_hall/cityhall.jpg" Class="Business_logo" />
                    <br />
                    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="/pages/checklists/city_hall_mayor_checklist.aspx" CssClass="button3">Mayor's Population Count and Shopping Bad Delivery Checklist</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton39" runat="server" PostBackUrl="/pages/checklists/lawyer_promissory_note_checklist.aspx" CssClass="button3">Lawyer Promissory Note Checklist</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton7" runat="server" PostBackUrl="/pages/checklists/City_hall_PCU_Manager.aspx" CssClass="button3">PCU Water Manager Checklist</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton14" runat="server" PostBackUrl="/pages/checklists/Judgement_Case_Missing_Teddy_Bear.aspx" CssClass="button3">Judgement Case: Missing Teddy Bear</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton16" runat="server" PostBackUrl="/pages/checklists/Judgement_Case_Slippery_Pickle.aspx" CssClass="button3">Judgement Case: Slipper Pickle</asp:LinkButton>
                </div>

                <%--<br />--%>

                <%--<div class="button_item"><!---CVS--->
                        <asp:Image ID="Image7" runat="server" ImageUrl="~/media/logos/CVS/CVS.png" Class="Business_logo"/>
                        <br />
                        <asp:LinkButton ID="LinkButton21" runat="server" PostBackUrl="/pages/checklists/check_writing_system.aspx?b=3" CssClass="button3">Check Writing Startup</asp:LinkButton>
                        <br />
                        <asp:LinkButton ID="LinkButton22" runat="server" PostBackUrl="sales_system.aspx?b=3" CssClass="button3">Sales Startup</asp:LinkButton>
                    </div>--%>

                <div class="button_item">
                    <!---Ditek--->
                    <asp:Image ID="Image8" runat="server" ImageUrl="~/media/logos/Ditek/Ditek.jpg" Class="Business_logo" />
                    <br />
                    <asp:LinkButton ID="LinkButton23" runat="server" PostBackUrl="/pages/checklists/ditek_inventory_checklist.aspx" CssClass="button3">Inventory Control Specialist's Checklist</asp:LinkButton>
                </div>

                <%--<br />--%>

                <div class="button_item">
                    <!---Duke--->
                    <asp:Image ID="Image9" runat="server" ImageUrl="~/media/logos/Duke/Duke.gif" Class="Business_logo" />
                    <br />
                    <asp:LinkButton ID="LinkButton25" runat="server" PostBackUrl="/pages/checklists/duke_electric_bill_checklist.aspx" CssClass="button3">Energy Bill Checklist</asp:LinkButton>
                    <%--<br />
                    <asp:LinkButton ID="LinkButton4" runat="server" PostBackUrl="/pages/checklists/duke_meter_checklist.aspx" CssClass="button3">Meter Reader Checklist</asp:LinkButton>--%>
                    <br />
                    <asp:LinkButton ID="LinkButton5" runat="server" PostBackUrl="/pages/checklists/duke_energy_utility_engineer_energy_conservation_checklist.aspx" CssClass="button3">Utility Engineer Energy Conservation Checklist</asp:LinkButton>
                </div>

                <%--<div class="button_item"><!---HSN--->
                        <asp:Image ID="Image10" runat="server" ImageUrl="~/media/logos/HSN/HSN.png" Class="Business_logo"/>
                        <br />
                        <asp:LinkButton ID="LinkButton27" runat="server" PostBackUrl="/pages/checklists/check_writing_system.aspx?b=8" CssClass="button3">Check Writing Startup</asp:LinkButton>
                        <br />
                        <asp:LinkButton ID="LinkButton28" runat="server" PostBackUrl="sales_system.aspx?b=8" CssClass="button3">Sales Startup</asp:LinkButton>
                    </div>--%>

                <%--<br />--%>

                <%--<div class="button_item"><!---Kanes--->
                        <asp:Image ID="Image11" runat="server" ImageUrl="~/media/logos/Kanes/Kanes.png" Class="Business_logo"/>
                        <br />
                        <asp:LinkButton ID="LinkButton29" runat="server" PostBackUrl="/pages/checklists/check_writing_system.aspx?b=5" CssClass="button3">Check Writing Startup</asp:LinkButton>
                        <br />
                        <asp:LinkButton ID="LinkButton30" runat="server" PostBackUrl="sales_system.aspx?b=5" CssClass="button3">Sales Startup</asp:LinkButton>
                    </div>--%>

                <div class="button_item">
                    <!---KnowBe4--->
                    <asp:Image ID="Image11" runat="server" ImageUrl="~/media/logos/KnowBe4/KnowBe4 Full Logo Full Color (2).png" Class="Business_logo" />
                    <br />
                    <asp:LinkButton ID="LinkButton29" runat="server" PostBackUrl="/pages/checklists/KnowBe4_FO_Checklist.aspx" CssClass="button3">Financial Officer Checklist</asp:LinkButton>
                </div>

                <%-- <div class="button_item"><!---McDonalds--->
                        <asp:Image ID="Image12" runat="server" ImageUrl="~/media/logos/Mcdonalds/McDonalds.png" Class="Business_logo"/>
                        <br />
                        <asp:LinkButton ID="LinkButton31" runat="server" PostBackUrl="/pages/checklists/check_writing_system.aspx?b=17" CssClass="button3">Check Writing Startup</asp:LinkButton>
                    </div>--%>

                <%--<br />--%>

                <div class="button_item">
                    <!---Mix 100.7--->
                    <asp:Image ID="Image13" runat="server" ImageUrl="~/media/logos/Mix 1007/MIX100.7 Wide.png" Class="Business_logo" />
                    <br />
                    <asp:LinkButton ID="LinkButton33" runat="server" PostBackUrl="/pages/checklists/mix_100.7_marketing_representative_checklist.aspx" CssClass="button3">Marketing Representative Checklist</asp:LinkButton>
                </div>

                <div class="button_item">
                    <!---Solid Waste--->
                    <asp:Image ID="Image14" runat="server" ImageUrl="~/media/logos/solid_waste/solid_waste.png" Class="Business_logo" />
                    <br />
                    <asp:LinkButton ID="LinkButton35" runat="server" PostBackUrl="/pages/checklists/pinellas_county_utilities_checklist.aspx" CssClass="button3">Manager's Checklist</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton6" runat="server" PostBackUrl="/pages/checklists/pcsw_fo_checklist.aspx" CssClass="button3">Financial Officer Payment Checklist</asp:LinkButton>
                </div>

                <%--<br />--%>

                <%-- <div class="button_item">
                            <!---Professional Offices--->
                            <asp:Image ID="Image16" runat="server" ImageUrl="~/media/logos/Professional Offices/professionaloffice.jpg" Class="Business_logo" />
                            <br />
                            <asp:LinkButton ID="LinkButton39" runat="server" PostBackUrl="/pages/checklists/lawyer_promissory_note_checklist.aspx" CssClass="button3">Lawyer Promissory Note Checklist</asp:LinkButton>
                            <br />
                            <asp:LinkButton ID="LinkButton6" runat="server" PostBackUrl="/pages/checklists/professional_office_financial_officer_checklist.aspx" CssClass="button3">Professional Office Financial Officer</asp:LinkButton>
                        </div>--%>

                <%--<div class="button_item"><!---Bucs--->
                        <asp:Image ID="Image18" runat="server" ImageUrl="~/media/logos/Bucs/Bucs.png" Class="Business_logo"/>
                        <br />
                        <asp:LinkButton ID="LinkButton43" runat="server" PostBackUrl="/pages/checklists/check_writing_system.aspx?b=1" CssClass="button3">Check Writing Startup</asp:LinkButton>
                        <br />
                        <asp:LinkButton ID="LinkButton44" runat="server" PostBackUrl="sales_system.aspx?b=1" CssClass="button3">Sales Startup</asp:LinkButton>
                    </div>--%>

                <%--<br />--%>

                <%--<div class="button_item"><!---Rays--->
                        <asp:Image ID="Image19" runat="server" ImageUrl="~/media/logos/Rays/Rays.png" Class="Business_logo"/>
                        <br />
                        <asp:LinkButton ID="LinkButton45" runat="server" PostBackUrl="/pages/checklists/check_writing_system.aspx?b=2" CssClass="button3">Check Writing Startup</asp:LinkButton>
                        <br />
                        <asp:LinkButton ID="LinkButton46" runat="server" PostBackUrl="sales_system.aspx?b=2" CssClass="button3">Sales Startup</asp:LinkButton>
                    </div>--%>

                <div class="button_item">
                    <!---Times--->
                    <asp:Image ID="Image21" runat="server" ImageUrl="~/media/logos/Times/times_logo.jpg" Class="Business_logo" />
                    <br />
                    <asp:LinkButton ID="LinkButton49" runat="server" PostBackUrl="/pages/checklists/tampa_bay_times_graphic_artist_checklist.aspx" CssClass="button3">Times Graphic Artist Checklist</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton50" runat="server" PostBackUrl="tampa_bay_times_marketing_representative_checklist.aspx" CssClass="button3">Times Marketing Representative</asp:LinkButton>
                </div>

                <%--<br />--%>

                <div class="button_item">
                    <!---Techdata--->
                    <p>Other Checklists</p>
                    <br />
                    <asp:LinkButton ID="LinkButton51" runat="server" PostBackUrl="/pages/checklists/salvador_dali_museum_art_curator_checklist.aspx" CssClass="button3">Salavidor Dali Museum Art Curator</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton52" runat="server" PostBackUrl="/pages/checklists/unified_giving_director's_checklist.aspx" CssClass="button3">Unified Giving Director's Checklist</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="LinkButton13" runat="server" PostBackUrl="/pages/checklists/ups_package_handler_checklist.aspx" CssClass="button3">UPS Package Handler Checklist</asp:LinkButton>
                </div>

                <div class="button_item">
                    <!---Verizon--->
                    <asp:Image ID="Image23" runat="server" ImageUrl="~/media/logos/Verizon/verizon1.png" Class="Business_logo" />
                    <%--<br />
                            <asp:LinkButton ID="LinkButton53" runat="server" PostBackUrl="/pages/checklists/verizon_graphic_artist_checklist.aspx" CssClass="button3">Verizon Graphic Artist Checklist</asp:LinkButton>--%>

                    <%--<asp:LinkButton ID="LinkButton7" runat="server" PostBackUrl="/pages/checklists/verizon_manager's_checklist.aspx" CssClass="button3">Verizon Manager's Checklist</asp:LinkButton>--%>
                    <br />
                    <asp:LinkButton ID="LinkButton8" runat="server" PostBackUrl="/pages/checklists/verizon_telecommunication_engineer_checklist.aspx" CssClass="button3">Verizon Telecommunication Engineer Checklist</asp:LinkButton>
                </div>
            </div>
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
