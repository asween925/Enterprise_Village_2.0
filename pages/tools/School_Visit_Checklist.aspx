<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="School_Visit_Checklist.aspx.vb" Inherits="Enterprise_Village_2._0.School_Visit_Checklist" MaintainScrollPositionOnPostback="true" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>EV 2.0 - School Visit Checklist</title>

    <link href="~/css/Styles.updated.css" rel="stylesheet" media="screen" type="text/css">
    <link href="~/css/Styles.print.css" rel="stylesheet" media="print" type="text/css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png" />

    <style>
        .p {
            font-weight: bold;
        }
    </style>
<script src="https://code.jquery.com/jquery-1.10.2.js"></script>
</head>

<body onafterprint="javascript:ResetPage();">
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
            <asp:Image ID="StavrosLogo_img" runat="server" ImageUrl="~\media\Stavros_logo.png" Visible="false" CssClass="stavros_logo_print" />
            <h2 class="h2 title_print" runat="server" id="h2_h2">               
                School Visit Checklist
            </h2>
            <h3 class="no-print">This page is used for filling out extra information for a school visit.
            </h3>
            <p class="no-print">Visit Date:</p>
            <asp:TextBox ID="visitDate_tb" runat="server" AutoPostBack="true" TextMode="Date" CssClass="textbox no-print"></asp:TextBox>
            <div id="schoolDDL_div" runat="server" visible="false" class="no-print">
                <p>School Name:</p>
                <asp:DropDownList CssClass="ddl" ID="schoolName_ddl" runat="server" Width="200px" AutoPostBack="true"></asp:DropDownList><a class="no-print">&emsp;</a><asp:Label runat="server" ID="error_lbl" Font-Size="X-Large" ForeColor="Red"></asp:Label>
                <br class="no-print"/>
                <br class="no-print"/>
                <asp:Button ID="print_btn" runat="server" Text="Print Full Checklist" CssClass="button3 button3 no-print" /><asp:Button ID="printTicket_btn" runat="server" Text="Print Ticket" CssClass="button3 button3 no-print" /><asp:Button ID="refresh_btn" runat="server" Text="Refresh" CssClass="button3 button3 no-print"  />
                <br class="no-print"/>
            </div>
            
            <div id="Tile1">

                <%--Step 1: Teacher Use--%>
                <div id="step1_div" runat="server" visible="false">
                    <h3>TEACHER ONLY <i id="I0" runat="server" visible="false">- COMPLETED</i></h3>
                    <p class="no-print">Last Edited By: <asp:Label ID="lastEdited1_lbl" runat="server" CssClass="no-print"></asp:Label></p>
                    <p class="p" runat="server" id="schoolType_p">School Type</p>
                    <asp:DropDownList CssClass="ddl" ID="schoolType_ddl" runat="server" Width="130px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Public / Charter</asp:ListItem>
                        <asp:ListItem>Other</asp:ListItem>
                    </asp:DropDownList>
                    <p class="p">School Name and Visit Date:</p>
                    <asp:Label ID="schoolName_lbl" runat="server"></asp:Label>&emsp;&emsp;<asp:Label ID="visitDate_lbl" runat="server"></asp:Label>
                    <p class="p">Contact Teacher Name and School Student Count:</p>
                    <asp:Label ID="contactTeacher_lbl" runat="server"></asp:Label>&emsp;&emsp;<asp:TextBox ID="schoolStudentCount_tb" runat="server" TextMode="Number" CssClass="textbox"></asp:TextBox><asp:Label ID="studentCountTotal_lbl" runat="server" Visible="false"></asp:Label>
                    <p class="p" runat="server" id="adminEmail_p">Administrator Email:</p>
                    <asp:Label ID="adminEmail_lbl" runat="server"></asp:Label>
                    <p class="p">Student Count Form Received:</p>
                    <asp:TextBox ID="studentCountFormReceived_tb" runat="server" TextMode="Date" CssClass="textbox"></asp:TextBox>
                    <br/>
                    <br/>
                    <asp:Button ID="step1Submit_btn" runat="server" Text="Submit" Visible="false" CssClass="button3 button3 no-print" />
                </div>

                <%--Step 2: Bookkeeper use--%>
                <div id="step2_div" runat="server" visible="false" class="school_visit_section school_visit_section_print">
                    <h3>BOOKKEEPER ONLY <i id="I1" runat="server" visible="false">- COMPLETED</i></h3>
                    <p class="no-print">Last Edited By: <asp:Label ID="lastEdited2_lbl" runat="server" CssClass="no-print"></asp:Label></p>
                    <asp:CheckBox ID="invoice_chk" runat="server" Text="Invoice # Issued" />&emsp;<asp:CheckBox ID="director_chk" Text="Director's Signature" runat="server" />&emsp;<asp:Label ID="step2Msg_lbl" runat="server" Font-Size="X-Large" ForeColor="Red"></asp:Label>
                    <br class="no-print"/>
                    <br class="no-print"/>
                    <asp:Button ID="step2Submit_btn" runat="server" Text="Submit" Visible="false" CssClass="button3 button3 no-print" />
                </div>

                <%--Step 3: Front Office Use--%>
                <div id="step3_div" visible="false" runat="server" class="school_visit_section school_visit_section_print">
                    <h3>FRONT OFFICE ONLY <i id="I2" runat="server" visible="false">- COMPLETED</i></h3>
                    <p class="no-print">Last Edited By: <asp:Label ID="lastEdited3_lbl" runat="server" CssClass="no-print"></asp:Label></p>
                    <p class="p" runat="server" id="contractReceived_p">Contract Received On:</p>
                    <asp:TextBox ID="contractRecieved_tb" TextMode="Date" runat="server" CssClass="textbox"></asp:TextBox><asp:Label ID="step3Msg_lbl" runat="server" Font-Size="X-Large" ForeColor="Red"></asp:Label>
                    <p class="p" runat="server" id="invoiceNum_p">Invoice #</p>
                    <asp:TextBox ID="invoiceNum_tb" TextMode="Number" runat="server" CssClass="textbox"></asp:TextBox>
                    <p class="p">Delivery Method:</p>
                    <asp:DropDownList CssClass="ddl" ID="delivery_ddl" runat="server" Width="100px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Pick Up</asp:ListItem>
                        <asp:ListItem>Pony</asp:ListItem>
                        <asp:ListItem>Delivery</asp:ListItem>
                        <asp:ListItem>Mailed</asp:ListItem>
                    </asp:DropDownList>
                    <p class="p" runat="server" id="notes_p">Notes:</p>
                    <asp:TextBox ID="notes_tb" runat="server" TextMode="MultiLine" Text="Notes" CssClass="textbox" Width="200px" Height="50px"></asp:TextBox>
                    <br class="no-print"/>
                    <br class="no-print"/>
                    <asp:Button ID="step3Submit_btn" runat="server" Text="Submit" Visible="false" CssClass="button3 button3 no-print" />
                </div>

                <%--Step 4: TA Use--%>
                <div id="step4_div" visible="false" runat="server" class="school_visit_section school_visit_section_print">
                    <h3>TA'S ONLY <i id="I3" runat="server" visible="false">- COMPLETED</i></h3>
                    <p class="no-print">Last Edited By: <asp:Label ID="lastEdited4_lbl" runat="server" CssClass="no-print"></asp:Label></p>
                    <p class="p">Total Amount of Kits Being Sent Out:</p>
                    <asp:DropDownList CssClass="ddl" ID="numOfKits_ddl" runat="server" AutoPostBack="true">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>0</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                    </asp:DropDownList>&emsp;<asp:Label ID="step4Msg_lbl" runat="server" Font-Size="X-Large" ForeColor="Red"></asp:Label>
                    <p class="p">Kit Numbers</p>
                    <asp:TextBox ID="kit1_tb" runat="server" Width="50px" Visible="false" CssClass="textbox"></asp:TextBox>&ensp;<asp:TextBox ID="kit2_tb" runat="server" Width="50px" Visible="false" CssClass="textbox"></asp:TextBox>&ensp;<asp:TextBox ID="kit3_tb" runat="server" Width="50px" Visible="false"  CssClass="textbox"></asp:TextBox>&ensp;<asp:TextBox ID="kit4_tb" runat="server" Width="50px" Visible="false" CssClass="textbox"></asp:TextBox>&ensp;<asp:TextBox ID="kit5_tb" runat="server" Width="50px" Visible="false" CssClass="textbox"></asp:TextBox>&ensp;<asp:TextBox ID="kit6_tb" runat="server" Width="50px" Visible="false" CssClass="textbox"></asp:TextBox>&ensp;<asp:TextBox ID="kit7_tb" runat="server" Width="50px" Visible="false" CssClass="textbox"></asp:TextBox>&ensp;<asp:TextBox ID="kit8_tb" runat="server" Width="50px" Visible="false" CssClass="textbox"></asp:TextBox>&ensp;<asp:TextBox ID="kit9_tb" runat="server" Width="50px" Visible="false" CssClass="textbox"></asp:TextBox>&ensp;<asp:TextBox ID="kit10_tb" runat="server" Width="50px" Visible="false" CssClass="textbox"></asp:TextBox>                                          
                    <p class="p">
                        Materials Included for 
                    <asp:Label ID="workbooks_lbl" runat="server" Font-Bold="true" Font-Underline="true"></asp:Label>
                        students.
                    </p>
                    <p class="p" runat="server" id="updateWorkbooks_p">Update the total number of workbooks (This number will override the number above):</p>
                    <asp:TextBox ID="workbooks_tb" runat="server" TextMode="Number" Width="70px" CssClass="textbox"></asp:TextBox>
                    <br  class="no-print" /><br  class="no-print" />
                    <asp:Button ID="step4Submit_btn" Text="Submit" runat="server" Visible="false" CssClass="button3 button3 no-print" /><asp:Button ID="refresh2_btn" runat="server" Text="Refresh" CssClass="button3 no-print" />
                </div>
            </div>

            <div>
                <%--Step 5: Front Office Use--%>
                <div id="step5_div" visible="false" runat="server" class="school_visit_section school_visit_section_print">
                    <h3>SCHOOL SIGNATURE REQUIRED <i id="I4" runat="server" visible="false">- COMPLETED</i></h3>
                    <p class="no-print">Last Edited By: <asp:Label ID="lastEdited5_lbl" runat="server" CssClass="no-print"></asp:Label></p>
                    <p class="p">Delivery Accepted By:&nbsp;
                        <asp:Label ID="deliveryAcceptedLine_lbl" runat="server" Visible="false">_____________________________________________________________________</asp:Label>
                    </p>
                    <asp:TextBox runat="server" ID="deliveryAccepted_tb" CssClass="textbox"></asp:TextBox><asp:Label ID="step5Msg_lbl" runat="server" Font-Size="X-Large" ForeColor="Red"></asp:Label>
                    <p class="p">Position:&nbsp;
                        <asp:Label ID="positionLine_lbl" runat="server" Visible="false">_________________________________________</asp:Label>
                    </p>
                    <asp:TextBox runat="server" ID="position_tb" CssClass="textbox"></asp:TextBox>
                    <p class="p">Date Accepted:&nbsp;
                        <asp:Label ID="dateAcceptedLine_lbl" runat="server" Visible="false">____________________________</asp:Label>
                    </p>
                    <asp:TextBox runat="server" ID="dateAccepted_tb" TextMode="Date" CssClass="textbox"></asp:TextBox>
                    <br class="no-print"/>
                    <br class="no-print"/>
                    <asp:Button ID="step5Submit_btn" runat="server" Text="Submit" Visible="false" CssClass="button3 button3 no-print" /><asp:Button ID="printTicket2_btn" runat="server" Text="Print Ticket" CssClass="button3 button3 no-print" />
                </div>
            </div>

           <%--EV Logo for Printing--%>        
            <asp:Image ID="EVLogo_img" runat="server" ImageUrl="~\media\EnterpriseVillage.png" ImageAlign="bottom" CssClass="EV_logo_print" Visible="false" />

        </div>

        <asp:HiddenField ID="currentVisitDate_hf" runat="server" />
        <asp:HiddenField ID="visitDate2_hf" runat="server" />
        <asp:HiddenField ID="businessID_hf" runat="server" />
        <asp:HiddenField ID="schoolID_hf" runat="server" />

        <asp:SqlDataSource ID="Review_sds" runat="server"></asp:SqlDataSource>

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

        <script>
            function printDiv1() {
                var divContents = document.getElementById("Tile1").innerHTML;
                var a = window.open();
                a.document.write('<html>');
                a.document.write('<body>');
                a.document.write(divContents);
                a.document.write('</body></html>');
                a.document.close();
                a.print();
                a.window.close();
            }

            function printDiv2() {
                var divContents = document.getElementById("Tile2").innerHTML;
                var a = window.open('', '', 'height=500, width=500');
                a.document.write('<html>');
                a.document.write('<body>');
                a.document.write(divContents);
                a.document.write('</body></html>');
                a.document.close();
                a.print();
            }

        </script>


    </form>
</body>
</html>
