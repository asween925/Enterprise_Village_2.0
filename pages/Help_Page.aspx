<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Help_Page.aspx.vb" Inherits="Enterprise_Village_2._0.Help_Page" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>EV 2.0 - Help</title>

    <link href="~/css/Styles.updated.css" rel="stylesheet" media="screen" type="text/css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <link rel="shortcut icon" type="image/png" href="~/media/EV_favicon_2.png" />
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
                $("#nav-placeholder").load("../../nav.html");
            });
        </script>

        <%--Content--%>
        <div class="content">
            <h2 class="h2">Help</h2>
            <h3>This page is the help section. It contains helpful information on each page in EV 2.0. Hover over the buttons below and select a page you need help with.
            </h3>

            <%--Drop down menu header--%>
            <div>
                <asp:Button ID="magicComp_btn" runat="server" Text="Magic Computer" CssClass="button3" />
                <div class="dropdown">
                    <button class="dropbtn" style="text-decoration: underline;">Create</button>
                    <div class="dropdown-content">
                        <asp:Button ID="createVisit_btn" runat="server" Text="Create a Visit" CssClass="help_page_ddl_button"/><br />
                        <asp:Button ID="Button1" runat="server" Text="Create a School" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button2" runat="server" Text="Create a Teacher" CssClass="help_page_ddl_button"/><br/>
                    </div>
                </div>
                <div class="dropdown">
                    <button class="dropbtn" style="text-decoration: underline;">Edit</button>
                    <div class="dropdown-content">
                        <asp:Button ID="Button3" runat="server" Text="Edit Visit" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button4" runat="server" Text="Edit Open / Closed Status" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button5" runat="server" Text="Edit School" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button6" runat="server" Text="Edit Teacher" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button8" runat="server" Text="Employee Management System" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button9" runat="server" Text="Edit Profits" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button10" runat="server" Text="Edit Sales" CssClass="help_page_ddl_button"/><br/>
                    </div>
                </div>
                <div class="dropdown">
                    <button class="dropbtn" style="text-decoration: underline;">Tools</button>
                    <div class="dropdown-content">                                            
                                                                  
                        <asp:Button ID="Button11" runat="server" Text="Town Hall PowerPoint" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button12" runat="server" Text="School Visit Checklist" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button13" runat="server" Text="School Notes" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button14" runat="server" Text="Kit Inventory" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button47" runat="server" Text="Upload / Move Articles" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button15" runat="server" Text="Schedule Request Form Checklist" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button54" runat="server" Text="Volunteer Database" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button55" runat="server" Text="Requested Features and Bug Reports" CssClass="help_page_ddl_button"/><br/>
                    </div>
                </div>

                <div class="dropdown">
                    <button class="dropbtn" style="text-decoration: underline;">Reports</button>
                    <div class="dropdown-content">
                        <asp:Button ID="Button16" runat="server" Text="Business Sales Report" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button17" runat="server" Text="Student Spending Report" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button18" runat="server" Text="Amount Spent Report" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button19" runat="server" Text="Negative Balance Report" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button20" runat="server" Text="Profit Report" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button21" runat="server" Text="Duplicate Numbers Report" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button46" runat="server" Text="Duplicate Students Report" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button22" runat="server" Text="Student Report" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button23" runat="server" Text="School Report" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button24" runat="server" Text="Visit Report" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button25" runat="server" Text="Teacher Report" CssClass="help_page_ddl_button"/><br/>
                    </div>
                </div>

                <div class="dropdown">
                    <button class="dropbtn" style="text-decoration: underline;">Forms and Letters</button>
                    <div class="dropdown-content">                      
                        <asp:Button ID="Button26" runat="server" Text="Family & Community Liason Information" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button27" runat="server" Text="Teacher Letter" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button48" runat="server" Text="Parent Letter" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button28" runat="server" Text="EV Daily Forms" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button29" runat="server" Text="EV Lunch Forms" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button49" runat="server" Text="Staff List" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button50" runat="server" Text="Break Schedules" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button56" runat="server" Text="Bus Transportation" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button57" runat="server" Text="School Schedule" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button59" runat="server" Text="Closed Business Checks" CssClass="help_page_ddl_button"/><br/>
                    </div>
                </div>
                <asp:Button ID="bizDir_btn" runat="server" Text="Business Directory" CssClass="button3"/>
                <asp:Button ID="chkDir_btn" runat="server" Text="Checklist Directory" CssClass="button3"/>
                <div class="dropdown">
                    <button class="dropbtn" style="text-decoration: underline;">Student Pages</button>
                    <div class="dropdown-content">
                        <asp:Button ID="Button30" runat="server" Text="Payroll Check System" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button31" runat="server" Text="Operating Check System" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button32" runat="server" Text="Online Banking" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button33" runat="server" Text="Sales System" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button34" runat="server" Text="Teller System" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button35" runat="server" Text="ATM" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button36" runat="server" Text="Badge Creator" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button37" runat="server" Text="Badge History" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button38" runat="server" Text="Badge Printing" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button51" runat="server" Text="BayCare Admin Assistant" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button52" runat="server" Text="Voting System" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button58" runat="server" Text="Manager System" CssClass="help_page_ddl_button"/><br/>
                    </div>
                </div>
                <div class="dropdown">
                    <button class="dropbtn" style="text-decoration: underline;">Inventory</button>
                    <div class="dropdown-content">
                        <asp:Button ID="Button40" runat="server" Text="Inventory Home" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button41" runat="server" Text="Create an Item" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button42" runat="server" Text="Edit Item" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button43" runat="server" Text="Add / Remove On Hand Amount" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button44" runat="server" Text="Low Inventory Report" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button45" runat="server" Text="View All Items" CssClass="help_page_ddl_button"/><br/>
                    </div>
                </div>
                <div class="dropdown">
                    <button class="dropbtn" style="text-decoration: underline;">Other</button>
                    <div class="dropdown-content">
                        <asp:Button ID="Button39" runat="server" Text="Teacher Home (Non-GSI Teachers)" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button7" runat="server" Text="Input Student Information (Non-GSI Teachers)" CssClass="help_page_ddl_button"/><br/>
                        <asp:Button ID="Button53" runat="server" Text="Changelog" CssClass="help_page_ddl_button"/><br/>
                    </div>
                </div>
            </div>
            <br />

            <%--Seperate Divs For Each Page--%>
            <div id="pages_div" runat="server" style="line-height: 1.6; padding: 5px;">

                <%--Magic Computer--%>
                <div id="magicComp_div" runat="server" class="button_grid_home" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4">Magic Computer</h3>
                        <ul>
                            <li>This page will allow you to adjust account balance for a student.</li>
                            <li>First enter the student’s account number in the textbox under “Enter Account Number” at the top of the screen.</li>
                            <li>Click the blue ‘Search’ button next to the textbox when you’ve entered a number.</li>
                            <li>You can also select a student’s name from the drop down menu below that textbox. These students will be the same ones that you’ll see on the current day.</li>
                            <li>Below that drop down menu is the ‘Transfer To Savings’ button. Click that when you are ready to move the $1.50 into all student’s accounts. If it’s clicked by accident, you can click it again to remove the $1.50 from all accounts.</li>
                            <li>After selecting a student, under the Account Summary section you will see that student’s account information, including their total deposits, savings, current balance, and sales history.</li>
                            <li>You can update the student’s deposit by entering a number into the textbox next to the deposit you want to edit, and clicking the blue ‘Update’ button when finished. You can also add or remove cash.</li>
                        </ul>
                    </div>
                    <div class="button_item2">
                        <img src="Images/EV Screenshots/Magic%20Computer%20Top.jpg" alt="Magic Computer - Top" style="height: auto; width: 100%;" />
                        <img src="Images/EV Screenshots/Magic%20Computer%20Bottom.jpg" alt="Magic Computer - Account Summary" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%-----------CREATE-----------%>

                <%--Create a Visit--%>
                <div id="createVisit_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4">Create a Visit</h3>
                        <ul>
                            <li>This page is used to create a visit date for Enterprise Village.</li>
                            <li>The only required information to enter a visit date is the date of visit and the school name. All other fields can remain blank until that information is known.</li>
                            <li>The button at the top will redirect you to the page where you can close businesses for a date.</li>
                            <li>If you change contract received to yes, another box will appear under it allowing you to enter the invoice number of the school’s visit date.</li>
                            <li>Date of visit is the date of the school’s enterprise village arrival.</li>
                            <li>Reply by date is the date that the school has to enter in their student’s information into the Input Student Information page. Can be set to any date but should typically be 2 weeks BEFORE the visit date.</li>
                            <li>Visit time is the time the school opens. The Volunteer Training Time section can be filled in to a specific time, but if empty it will default to the time selected on the EV scheduling chart (ex. Visit time (school schedule) = 8:40 then the volunteer time will be 7:50)</li>
                            <li>Approximate Student Count is the number of students expected to be there.</li>
                            <li>Volunteer meeting lead is the person leading the volunteer meeting. Can be either Barbara, Monika, or Leslie.</li>
                            <li>School name is where you input the name of the school that will be visiting. Can add up to 5 schools.
                            <br />
                                School 1 must be filled in. On days where there is no school, you can select A1 No School Scheduled to still use many of the site’s features (particularly in the student side)</li>
                            <li>You can always edit this information later by going to ‘Edit Visit’.</li>
                            <li>Click submit at the bottom to enter in your information. When you do, it will show a message saying if it was successful or not and refresh the page.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Create%20a%20Visit.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--Create a School--%>
                <div id="createSchool_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4" id="createaschool">Create a School</h3>
                        <ul>
                            <li>This page allows you to create a new school that is not in the database. Before creating one, double check that it is already in the database by going to the school report page and scrolling through (or typing in ) the drop down menu. </li>
                            <li>Only the fields labeled 'Required' are needed to submit info.</li>
                            <li>You can always edit this afterwards by going to 'Edit School'.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Create%20a%20School.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--Create a Teacher--%>
                <div id="createTeacher_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4" id="createateacher">Create a Teacher</h3>
                        <ul>
                            <li>This page will let you add a teacher to the database.</li>
                            <li>Last name and school name are required fields.</li>
                            <li>The school name drop down menu is populated with schools from the database. If you do not see the school you need, you might have to create one from the 'Create a School' page.</li>
                            <li>Student Count is the approximate students they are bringing to EV.</li>
                            <li>Password is needed if the teacher does not have a PCSB email. This password will be used by them when they log into EV 2.0 using their email. The email they will need to use will be the same one saved in our database. Go to 'Teacher Report' or 'Edit Teacher' to view teacher's emails.</li>
                            <li>You can edit this information later by going to 'Edit Teacher'.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Create%20a%20Teacher.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%-----------EDIT PAGES-----------%>

                <%--Edit Visit--%>
                <div id="editVisit_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4" id="editvisit">Edit Visit</h3>
                        <ul>
                            <li>This page allows you to edit currently existing visit dates.</li>
                            <li>Select the visit date you want to edit, and a table will appear underneath the date selected.</li>
                            <li>Click on the 'Edit' button on the left side of the table to go into 'Edit Mode'. Now you can make changes to any field on the row. </li>
                            <li>Make sure you click 'Edit' before making any changes otherwise it will not save and you'll have to start over again. Click 'Update' to finish editing that row.</li>
                            <li>If you edit the visit date of the current date (if there is one created) then it will be changed to the edited visit date, and will not appear for the current day. In short, don't edit the same date as the current date.</li>
                            <li>The businesses closed will be reflected in the Town Hall Powerpoint for that date.</li>
                            <li>Closed businesses will not show up for the non-GSI teachers when they log into EV 2.0 and enter their students.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Edit%20Visit.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--Edit Open / Closed Status--%>
                <div id="editOpen_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4" id="editopen">Edit Open / Closed Status</h3>
                        <ul>
                            <li>This page is used to close businesses for a selected visit date.</li>
                            <li>Select the visit date you want to edit, and a table will appear underneath the date selected.</li>
                            <li>Click on the 'Edit' button on the left side of the table to go into 'Edit Mode'. Now you can make changes to any field on the row. </li>
                            <li>Make sure you click 'Edit' before making any changes otherwise it will not save and you'll have to start over again. Click 'Update' to finish editing that row.</li>
                            <li>Uncheck the 'Open Status' checkbox to close it.</li>
                            <li>The 'School Assigned' column shows schools that are scheduled to come in on that visit date. Go to 'Edit Visit' if the school you need is not on that list to double check if they are scheduled for  that date.</li>
                            <li>The businesses closed will be reflected in the Town Hall Powerpoint for that date.</li>
                            <li>Closed businesses will not show up for the non-GSI teachers when they log into EV 2.0 and enter their students.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Edit%20Open%20Closed%20Status.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--Edit School--%>
                <div id="editSchool_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4">Edit School</h3>
                        <ul>
                            <li>This page lets you edit information of a selected school in the database.</li>
                            <li>Select the school you want to edit from the drop down menu, or type in a school name in the search bar.</li>
                            <li>Click on the 'Edit' button on the left side of the table to go into 'Edit Mode'. Now you can make changes to any field on the row. </li>
                            <li>Make sure you click 'Edit' before making any changes otherwise it will not save and you'll have to start over again. Click 'Update' to finish editing that row.</li>
                            <li>If you want to view all schools in the table, click on 'Show All Schools'.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Edit%20School.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--Edit Teacher--%>
                <div id="editTeacher_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4" id="editteachers">Edit Teachers</h3>
                        <ul>
                            <li>This page lets you edit information of currently existing teachers.</li>
                            <li>Select the school of the teacher you want to edit, and a table will appear below the selected school.</li>
                            <li>Click on the 'Edit' button on the left side of the table to go into 'Edit Mode'. Now you can make changes to any field on the row. </li>
                            <li>Make sure you click 'Edit' before making any changes otherwise it will not save and you'll have to start over again. Click 'Update' to finish editing that row.</li>
                            <li>If you want to remove a teacher from the school and NOT move them to another school, you'll have to clear all the fields out.</li>
                            <li>Remember: here is where you can find the emails and passwords for the teachers to be able to log in to EV 2.0 and enter their students.</li>
                            <li>If they are NOT PCSB teachers, they will need a password.</li>
                            <li>The password criteria is the county name + school name.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Edit%20Teachers.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                 <%--Teacher Home--%>
                <div id="teacherHome_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4">Teacher Home (Non-GSI Teachers)</h3>
                        <ul>
                            <li>This is what the non-GSI teachers will see when they log in.</li>
                            <li>At the top, the teacher's name will appear in the header.</li>
                            <li>The school's visit date will appear at the top.</li>
                            <li>The large 'Enter Students' button will go to the ISI section, allowing the teachers to input their students into EV 2.0.</li>
                            <li>The 'Upload Newspaper Articles' section will allow teachers to select the newspaper articles in a Word document to upload into EV 2.0. They'll choose a Word document file by clicking 'Choose File' and click 'Upload'.</li>
                            <li>The 'Log Out' button goes back to the log in screen.</li>
                            <li>At the bottom of the page is where teachers can ask the GSI tech technician for help.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Teacher%20Home.jpg" alt="Teacher Home" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--ISI--%>
                <div id="isi_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4" id="isi">Input Student Information (Non-GSI Teachers)</h3>
                        <ul>
                            <li>This page will only be viewed by non-GSI teachers.</li>
                            <li>This page allows non-GSI teachers to enter in their student's names into our database for their scheduled visit date.</li>
                            <li>For them to access this page, they need to be sent an email containing a link: https://ev.pcsb.org
                                <br />
                                • At this page, they enter in their email used to contact us and a password:
                                <br />
                                &emsp;   ○ If the teacher is PCSB, they can use their normal credentials to log in.<br />
                                &emsp;  ○ If the teacher is non-PCSB, they must use the assigned password given to them in that same email containing the link. This password can be assigned to them on the 'Edit Teacher' page.
                                <br />
                                &emsp;   ○ The criteria for this password is county name + school name.</li>
                            <li>Only opened businesses assigned to the associated school of the teacher will appear.</li>
                            <li>When they log in, they should see their school name and scheduled visit date under the directions. </li>
                            <li>The teachers will then select the business they want to edit from the drop down menu.</li>
                            <li>When they click on the 'Edit' button on the left side of the table to go into 'Edit Mode'. Now they can make changes to any field on the row. </li>
                            <li>Make it clear to them that they need to click 'Edit' before making any changes otherwise it will not save and you'll have to start over again.</li>
                            <li>When they finish editing the name, click 'Update'. They will repeat this until they finish adding all of their student's in.</li>
                            <li>When they finish adding all student's in, they will click 'Submit'. This will direct them to a confirmation page, double checking if they are finished adding students in.</li>
                            <li>When they click 'Confirm', they will be redirected back to the log in screen.</li>
                            <li>They can get a print out of this page by clicking 'Print'.</li>
                            <li>They can click the link at the bottom of the page to open an email so they can ask a question.</li>
                            <li>They can also come back and make changes at a later date. They can log back in and follow the normal procedures (click Edit, click Update, click Submit, print out if they need).
                            <br />
                                • However, they can only make changes up until a certain date, the Reply By date, which is assigned by the GSI Teachers.<br />
                                • You can change this Reply By date by going to 'Edit Visit'.
                            <br />
                            </li>
                            <li>BE AWARE! If they pass this Reply By date, they cannot make any more changes and will have to contact us if they need to make a change.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/ISI.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--EMS--%>
                <div id="ems_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4" id="ems">Employee Management System</h3>
                        <ul>
                            <li>This page allows you to edit students from a selected business on a selected visit date.</li>
                            <li>Select an existing visit date from the visit date box, and then select a business from the drop down list below that. A table will appear under that menu.</li>
                            <li>Here you can change the student's business, account number, first and last name, job, and what school they belong to.</li>
                            <li>Click on the 'Edit' button on the left side of the table to go into 'Edit Mode'. Now you can make changes to any field on the row.</li>
                            <li>Make sure you click 'Edit' before making any changes otherwise it will not save and you'll have to start over again. Click 'Update' to finish editing that row.</li>
                            <li>Be aware that if you change the student's business, they will move to that business and you'll have to select that business from the drop down list to find them.</li>
                            <li>Be aware that you can set a duplicate account number. Check the 'Duplicate Number Report' under the 'Reports' menu on the side bar to see which numbers are duplicate.</li>
                            <li>The businesses that appear from the list are the ones that are set to open. Go to 'Edit Open / Closed Status' to close any business unwanted for that visit date.</li>
                            <li>You can also change the school for all the students in a selected business by selecting a school from the 'Change School Assigned...' drop down menu and clicking 'Change School'. This can be used as a backup in case all the schools get reset in the EMS. </li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/EMS.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--Edit Profits--%>
                <div id="editProfits_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4" id="editprofits">Edit Profits</h3>
                        <ul>
                            <li>This page will let you edit the profits of each business on the current date.</li>
                            <li>Click on the 'Edit' button on the left side of the table to go into 'Edit Mode'. Now you can make changes to any field on the row. </li>
                            <li>Make sure you click 'Edit' before making any changes otherwise it will not save and you'll have to start over again. Click 'Update' to finish editing that row.</li>
                            <li>Each business will update automatically from when the financial officer enter their profits in the Online Banking page in their business.</li>
                            <li>The Misc. Deposit
	                        • Also called Deposit 4 on some pages (online banking, etc.)<br />
                                • It will be used in the case of a business not achieving a positive profit at the end of the day.<br />
                                • The Misc. Deposit acts as a 4th deposit, so it will ADD to the total profit.<br />
                                • This will be displayed on the online banking page for the financial officer.</li>
                            <li>You can edit the profit directly by click in the box in the 'Profits' column:
                    <br />
                                • If you do this, be aware that if there is a Misc. Deposit, it will add to whatever number you enter in.<br />
                                &emsp;      ○ Example: If you enter in $40 for the misc. deposit, and decide to edit the profit to $30, the total profit will be $70 because the misc. deposit is adds to the total profit.
                    <br />
                                • To avoid this, change the misc. deposit to 0 and edit the profit manually, or just do some calculations to get the profit to what you want it to be.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Edit%20Profits.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--Edit Sales--%>
                <div id="editSales_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4">Edit Sales</h3>
                        <ul>
                            <li>This page allows you to edit the transactions of a student in EV.</li>
                            <li>Select a visit date from the textbox, then select a student from the drop down menu below the date to view their transactions.</li>
                            <li>In the table, you'll see a list of the business that the student has purchased an item from in the 'Business' column. There are 4 other columns for sales.</li>
                            <li>Click 'Edit' to edit a businesses' transactions. You can edit the 4 sales textboxes to any number you need. Click 'Update' to update the change.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Edit%20Sales.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%-----------TOOLS-----------%>

                <%--Town Hall--%>
                <div id="townHall_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4" id="powerpoint">Town Hall Powerpoint</h3>
                        <ul>
                            <li>This page will be used instead of the traditional PowerPoint slideshow that's from the shared folder.</li>
                            <li>The businesses that are OPEN will cycle through like a normal PowerPoint.</li>
                            <li>You will move the browser window to the screen displaying the PowerPoint (usually to the left or right of the screen, like you are using two monitors), and press F11 on the keyboard to go full screen.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Town%20Hall%20PP.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--School Visit Checklist--%>
                <div id="svc_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4" id="schoolvisitchecklist">School Visit Checklist</h3>
                        <ul>
                            <li>This page is for the teachers, bookkeeper, TA's, and front office staff to enter in additional information about the visit.</li>
                            <li>Each section of this page is blocked off unless the person before has filled out their information. For example, the front office staff (step 3) cannot enter their information unless the bookkeeper (step 2) has filled out their information first. The steps must go in order.</li>
                            <li>This page is unique in that it has an order of people who are allowed to enter in information. It is broken up into steps:<br />
                                • Step 1: Teachers Use Only<br />
                                &emsp;	○ Once you have created a visit date, click the link at the top of the Create a Visit page that says School Visit Checklist. You will arrive at this page<br />
                                &emsp;	○ You'll see a drop down menu that has all of the schools in the database and a print button. Select the school you just created.<br />
                                &emsp;	○ You'll see a few things pop up but only teachers will worry about Step 1. The Teacher's Only section contains information about the school and visit date, a drop down menu that has the type of school it is, and a Submit button.
                    <br />
                                &emsp;	○ Teachers will select the type of school it is and click Submit. The button will open your email application (Outlook) with an email pre-filled out and addressed to the bookkeeper. Click send. The teachers are done with this page.
                    <br />
                                • Step 2: Bookkeeper Only
                    <br />
                                &emsp;	○ After the teacher sends the email to the bookkeeper, the bookkeeper will now need to check two boxes in order for the next step to be unlocked for the Front Office staff.
                    <br />
                                &emsp;	○ Clicking 'Submit' will open the default email application (Outlook) with an email pre-filled out and addressed to the front office staff. Click send. The bookkeeper is now done with this page.<br />
                                • Step 3: Front Office Only (Part 1 of 2)<br />
                                &emsp;	○ Once the Front Office staff receives an email from the bookkeeper, they are now able to fill out the information in their section.<br />
                                &emsp;	○ Enter the contract received date, the invoice number, the delivery method, and any additional notes you may need to add.<br />
                                &emsp;	○ Clicking 'Submit' will open the default email application (Outlook) with an email pre-filled out and addressed to the TA staff. Click send. The front office staff must return to this page after an email has been received from the TA's.
                    <br />
                                • Step 4: TA's Only<br />
                                &emsp;	○ Once the TA staff receives an email from the front office staff, they are now able to fill out the information in their section.<br />
                                &emsp;	○ Click the drop down menu to select the total amount of kits being sent out for that school's visit, and enter the kit numbers on the line below. Use commas to separate them (ex: 124, 278, etc.).
                    <br />
                                &emsp;	○ After filling that information out, click 'Print Ticket'. This will print out a ticket with the information filled out up above.<br />
                                &emsp;	○ Clicking 'Submit' will open the default email application (Outlook) with an email pre-filled out and addressed to the front office staff. Click send. The TA's are done with this page.<br />
                                • Step 5: Front Office Only (Part 2 of 2)<br />
                                &emsp;	○ Once the Front Office staff receives an email from the TA's, they are now able to fill out the information in the final section.<br />
                                &emsp;	○ Enter the delivery accepted by date, and the date accepted.<br />
                                &emsp;	○ Clicking 'Submit' will open the default email application (Outlook) with an email pre-filled out and addressed to the bookkeeper. Click send. The front office is now done with this page.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/School%20Visit%20Checklist.jpg" alt="Create a Visit" style="height: auto; width: 100%;" /><br />
                        <img src="Images/EV Screenshots/School%20Visit%20Checklist%202.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--School Notes--%>
                <div id="schoolNotes_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4">School Notes</h3>
                        <ul>
                            <li>This page lets you add any notes to a school that are needed.</li>
                            <li>Select a school from the drop down menu and the school's information will be loaded in, things like the phone number, type of school, and number.</li>
                            <li>Below the information, is a textbox where you can enter in a note for the school and submit it into 2.0 with the 'Submit' button.</li>
                            <li>The note will appear in a table below, along with a timestamp and the user name it was added by.</li>
                            <li>You can edit the note and/or delete it by clicking 'Edit' or 'Delete' on the left side of the table.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/School%20Notes.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--Kit Inv--%>
                <div id="kit_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4">Kit Inventory</h3>
                        <ul>
                            <li>This page is where you can enter in a new kit inventory request to the system, or view all the kits being lent out.</li>
                            <li>On the page load, there are two buttons: the Data Entry button and the View Invnentory List.</li>
                            <li>Data Entry
                                <ul>
                                    <li>There are various fields to enter the kit info into 2.0. Fill all these out and click 'Submit' when finished.</li>
                                </ul>
                            </li>
                            <li>View Inventory List
                                <ul>
                                    <li>Clicking this button will load in all the kit inventory data into a table.</li>
                                    <li>At the top of the table, you'll see a few fields for sorting and searching.</li>
                                    <li>To search for a field, enter in a keyword and select what you want to search for from the drop down menu to the right of the textbox, and click 'Search'.</li>
                                    <li>To sort items, click on the ID drop down menu to select a column to sort by, and select either Ascending or Descending and click 'Sort'.</li>
                                    <li>The 'Refresh' button will return the table to its default state.</li>
                                    <li>You can edit a row by clicking 'Edit' and changing a field in the highlighted row. Update it by clicking 'Update'.</li>
                                </ul>
                            </li>
                        </ul>
                        
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Kit%20Inventory.jpg" alt="Create a Visit" style="height: auto; width: 100%;" /><br />
                        <img src="Images/EV Screenshots/Kit%20Inventory%20Table.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--Upload / Move Articles--%>
                <div id="moveArt_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4">Upload / Move Articles</h3>
                        <ul>
                            <li>If you have updated a visit date for a school, this page is designed to move the newspaper articles that the teacher has submitted to the updated visit date.</li>
                            <li>Enter the previous visit date in the textbox, and select the school that has been moved. Then enter the updated visit date and click 'Submit'.</li>
                            <li>If the teacher from the previous visit date has not uploaded their articles, a message will appear saying so. This means you can safely exit out of the page.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Move%20Articles.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--SRF Checklist--%>
                <div id="srf_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4">Schedule Request Form Checklist</h3>
                        <ul>
                            <li>This page allows you to check off which schools have completed their schedule request forms.</li>
                            <li>Click 'Edit' to check off a school and 'Update' when finished.</li>
                            <li>The 'Clear All Checkboxes' button will clear out all the checkboxes currently in the table. This is used at the beginning of the school year when no schools have returned their SRFs, so you can start fresh.</li>
                            <li>You can print this table by clicking 'Print'.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/SRF%20Checklist.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--Volunteer DB--%>
                <div id="volunteerDB_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4">Volunteer Database</h3>
                        <ul>
                            <li>This is the volunteer database where you can add a new volunteer to the list and view all the volunteers in the database.</li>
                            <li>To add a new volunteer, click the 'Add Volunteer' button. To view volunteers previously created, click the 'View Volunteers' button.</li>
                            <li>Click 'Edit' to check off a school and 'Update' when finished.</li>
                            <li>You can search for a name of a volunteer using the search bar, and/or you can sort the list of volunteers by various columns in ascending or descending order.</li>
                            <li>The 'Refresh' button will reload the page.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Volunteer%20DB.jpg" alt="Vol DB" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--Requested Features--%>
                <div id="requested_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4">Requested Features and Bug Reports</h3>
                        <ul>
                            <li>This page allows you to submit suggested features and report potential bugs or issues to the technology technician so they can incorporate it into EV 2.0.</li>
                            <li>The 'Create a Post' button will reveal a section where you can add a requested feature or report a bug. Click 'Submit' to submit the note.</li>
                            <li>The 'View Posts' button will reveal a table containing all the posts currently in the system. You can 'Edit' or 'Delete' your own posts.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Requested%20Features.jpg" alt="Request" style="height: auto; width: 100%;" />
                        <br />
                        <img src="Images/EV Screenshots/Requested%20Features%202.jpg" alt="Request2" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%-----------REPORTS-----------%>

                <%--Business Sales Report--%>
                <div id="bizSales_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4" id="businesssalesreport">Business Sales Report</h3>
                        <ul>
                            <li>This page will let you see the total sales and transactions of each business for the current visit date.</li>
                            <li>Select a business from the drop down menu to see the transactions and total sales of the business.</li>
                            <li>You can print out the table by selecting a business and clicking 'Print'.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Business%20Sales%20Report.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--Student Spending Report--%>
                <div id="studentSpendingReport_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4" id="studentspendingreport">Student Spending Report</h3>
                        <ul>
                            <li>This page is for sending the student report to teachers for a selected visit date. </li>
                            <li>Select a visit date and school name FROM that visit date to see all students assigned to that date and school.</li>
                            <li>You can view their balance, deposit information, cash withdrawn, savings, and how much they spent at each business.</li>
                            <li>This page is meant to be downloaded as a PDF. Click the 'Print' button and select 'Save to PDF' under the Printers section on the Print window. You will get to save a name for it. This PDF is then supposed to be emailed to the teacher of the school that requested it.</li>
                            <li>Keep in mind: When you select a school from the drop down menu, it only displays the students from that school. Remember to download a PDF for EACH SCHOOL that day. Select a school, click the 'Save to PDF' button, select Save as PDF under printer when the print window appears, click Save, and do it again with the other school(s). </li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Student%20Spending%20Report.jpg" alt="Create a Visit" style="height: auto; width: 100%;" /><br />
                        <img src="Images/EV Screenshots/Student%20Spending%20Report%202.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--Amount Spent--%>
                <div id="amountSpent_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4" id="amountspentreport">Amount Spent Report</h3>
                        <ul>
                            <li>This page allows you to view students that have spent their funds.</li>
                            <li>You can see their account number, name, total deposits, total purchases, balance.</li>
                            <li>You can print out a copy by clicking 'Print'.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Amount%20Spent%20Report.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--Negative Balance--%>
                <div id="negativeBalance_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4" id="negativebalancereport">Negative Balance Report</h3>
                        <ul>
                            <li>This page will show you students that have a negative balance.</li>
                            <li>You can adjust their balance by going to the Magic Computer for the account number displayed.</li>
                            <li>Note: this only displays students that have a negative balance due to a transaction. Transactions are controlled in a way so the student cannot buy an item with less money in their account than the item is worth. This page is only here as a precaution.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Negative%20Balance%20Report.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--Profit Report--%>
                <div id="profitReport_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4" id="profitreport">Profit Report</h3>
                        <ul>
                            <li>This page lets you view the profits for the current visit date.</li>
                            <li>You can print out a copy by clicking 'Print'.</li>
                            <li>To edit a profit, go to 'Edit Profits' under the Tools tab.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Profit%20Report.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--Dup Nums--%>
                <div id="dupNums_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4" id="duplicatenumbersreport">Duplicate Numbers Report</h3>
                        <ul>
                            <li>This page will let you see students in the current visit date that have duplicated account numbers.</li>
                            <li>The number that is duplicated will appear in a table. </li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Duplicate%20Number%20Report.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--Dup Students--%>
                <div id="dupStu_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4" id="duplicatestudentsreport">Duplicate Student Report</h3>
                        <ul>
                            <li>This page will let you see any students that have the same name in a selected visit date.</li>
                            <li>You can go to the EMS from this page and change the name if wanted.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Duplicate%20Students%20Report.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--Student Report--%>
                <div id="studentReport_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4" id="studentreport">Student Report</h3>
                        <ul>
                            <li>This page lets you view the students in the database under a selected visit date.</li>
                            <li>Enter a visit date, and a drop down menu and table will appear with the students scheduled to arrive that day.</li>
                            <li>If there is more than one school scheduled to arrive that day, you can select the students to view only from that school by selecting it from the drop down menu.</li>
                            <li>The 'Show Empty Names' button will show all the account numbers from the day, even when there is no student name entered for that id. </li>
                            <li>You can print out a copy by clicking 'Print'.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Student%20Report.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--School Report--%>
                <div id="schoolReport_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4" id="schoolreport">School Report</h3>
                        <ul>
                            <li>This page displays all the schools currently in the database.</li>
                            <li>Select a school from the drop down menu to see only that school.</li>
                            <li>Type in a keyword and click 'Search' to see rows with that keyword. </li>
                            <li>The 'Show All Schools' button will show all schools if you entered a keyword or selected a school.</li>
                            <li>Use the page numbers to navigate the table.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/School%20Report.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--Visit Report--%>
                <div id="visitReport_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4" id="visitreport">Visit Report</h3>
                        <ul>
                            <li>This page lets you view all scheduled visit dates in the database.</li>
                            <li>Click the page numbers to cycle through older dates.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Visit%20Report.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--teacher report--%>
                <div id="teacherReport_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4" id="teacherreport">Teacher Report</h3>
                        <ul>
                            <li>The page displays teachers associated with a selected school.</li>
                            <li>Select a school from the drop down menu to see the teachers of that school.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Teacher%20Report.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

         <%-----------FORMS AND LETTERS-----------%>

                <%--liason info--%>
                <div id="liason_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4">Family & Community Liason Information</h3>
                        <ul>
                            <li>This page is used to print out the Liason Information page of Enterprise Village.</li>
                            <li>Select a visit date and school from the textbox and drop down menu to view the letter.</li>
                            <li>The letter will load data from the visit date and school name selected, the liason name, volunteer range, and training time will load automatically.</li>
                            <li> The liason name and volunteer range can be changed on 'Edit School'. The training time is based on the visit time, which can also be change on the 'Edit School' page.</li>
                            <li>Print out this page by clicking 'Print' at the top of the page.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Family%20Community%20Info.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--Teacher Letter--%>
                <div id="teacherLetter_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4">Teacher Letter</h3>
                        <ul>
                            <li>This page will allow you to save the teacher letter of a selected school.</li>
                            <li>Select a visit date, school name, and teacher name (of selected school) to load the letter.</li>
                            <li>The page will automatically load various information based on the selected info, like the sharing schools, arrival and dismisal time, number of students, and businesses assigned to school.</li>
                            <li>The sharing schools, arrival and dismisal time can be edited in the 'Edit Visit' page. The businesses assigned can be edited on 'Edit Open / Closed Status'.</li>
                            <li>The 'Save as PDF' button will open the print window screen. Under Printers, select 'Save as PDF', then click Save at the bottom of the print window. Then you can choose where to save the PDF on your computer.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Teacher%20Letter.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--Parent Letter--%>
                <div id="parentLetter_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4">Parent Letter</h3>
                        <ul>
                            <li>This page will allow you to save the parent letter of a selected school.</li>
                            <li>Select a visit date to load the letter.</li>
                            <li>Click the 'Save as PDF' button to bring up the print window. From there, make sure you select 'Save as a PDF' under the Printers drop down menu to save it as a PDF.</li>
                            
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Parent%20Letter.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--Daily Forms--%>
                <div id="dailyForms_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4">EV Daily Forms</h3>
                        <ul>
                            <li>This page is for printing out the daily forms for Enterprise Village.</li>
                            <li>Select a visit date and school and the data for that visit date and school will be loaded into the form.</li>
                            <li>The form changes based on the type of school it is: either public or OOC. The OOC schools contain workbook and kit information, the PCSB schools do not.</li>
                            <li>Click the 'Print' button at the top to print out the form.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/EV%20Daily%20Forms.jpg" alt="Create a Visit" style="height: auto; width: 100%;" /><br />
                        <img src="Images/EV Screenshots/EV%20Daily%20Forms%20OOC.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--Lunch Forms--%>
                <div id="lunchForms_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4">EV Lunch Forms</h3>
                        <ul>
                            <li>This page is where you will print out the lunch forms for Enterprise Village, like the daily receipt and the monthly letter.</li>
                            <li>At the top, there will be options to print out the Daily Receipt or the Letter.</li>
                            <li>Daily Receipt
                                <ul>
                                    <li>When selecting the Daily Receipt, you will need to enter a visit date.</li>
                                    <li>After entering the date, the receipt will load containing the student count, volunteer range, and pick up time data automatically.</li>
                                    <li>Enter in the total amount of burgers and nuggets needed for the day, as well as any comments.</li>
                                    <li>Click 'Print' when all data is entered.</li>
                                </ul>
                            </li>
                            <li>Letter
                                <ul>
                                    <li>Select a month and year and the letter will load with all visit dats scheduled for that month and year.</li>
                                    <li>You will need to edit the amount of burgers and nuggets for each visit.</li>
                                    <li>The pick-up time will be different based on the scheduled visit time.</li>
                                    <li>After filling out the burgers and nuggets, print out the form by clicking 'Print' at the top.</li>
                                </ul>
                            </li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/EV%20Lunch%20Forms%20Letter.jpg" alt="Create a Visit" style="height: auto; width: 100%;" /><br />
                        <img src="Images/EV Screenshots/EV%20Lunch%20Forms%20Receipt.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--Staff List--%>
                <div id="staffList_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4">Staff List</h3>
                        <ul>
                            <li>This page is where you can view and print out a list of the staff members at GSI.</li>
                            <li>You can also create a new staff member to add by clicking the 'Add New Staff Member' button.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Staff%20List.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--Break Schedules--%>
                <div id="breakSch_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4">Break Schedules</h3>
                        <ul>
                            <li>This page is where you print out the business break schedules for the current day.</li>
                            <li>Select the business name from the drop down menu and then select the schoole schedule time. The form will automatically be filled out with the corrent break times based on the time selected.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Break%20Schedules.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--Bus Transportation--%>
                <div id="busTrans_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4">Bus Transportation</h3>
                        <ul>
                            <li>This is where you will print out the bus transportation information for EV.</li>
                            <li>Enter the visit date of the bus transportation to reveal the letter. The form will automatically be filled out with the corrent break times based on the time selected.</li>
                            <li>Click the 'Print' button to print out the letter.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Bus%20Transportation.jpg" alt="Bus Transport" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--School Schedule--%>
                <div id="schoolSch_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4">School Schedule</h3>
                        <ul>
                            <li>This is where you can view the schedule for EV for each school time slot.</li>
                            <li>Click the 'Print' button to print out a copy.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/School%20Schedule.jpg" alt="School Sched" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--Closed Business Checks--%>
                <div id="closedBizChecks_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4">Closed Business Checks</h3>
                        <ul>
                            <li>This page allows you to print out the business operating checks that are closed for the day.</li>
                            <li>Select a business you want to print checks for and the checks will automatically fill out for group 1.</li>
                            <li>Click the 'Show Group 2' or 'Show Group 3' buttons to show and print the other operating checks.</li>
                            <li>For Duke's operating checks, you will have to manually enter the amount assigned to each business before printing.</li>
                            <li>Click the 'Print' button to print out the checks. The printed checks are alligned to fit with the old, green check paper.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Closed%20Business%20Checks.jpg" alt="Closed Biz Checks" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%-----------DIRECTORIES-----------%>

                <%--Business Directory--%>
                <div id="bizDir_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4" id="businessdirectory">Business Directory</h3>
                        <ul>
                            <li>This page contains links to each businesses job.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Business%20Directory.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--Checklist Directory--%>
                <div id="chkDir_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4" id="checklistdirectory">Checklist Directory</h3>
                        <ul>
                            <li>This page contains links to each checklist for the iPads.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Checklist%20Directory.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%-----------STUDENT PAGES-----------%>

                <%--Payroll Checks--%>
                <div id="payChecks_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4">Payroll Check System</h3>
                        <ul>
                            <li>Layout:
                                <ol>
                                    <li>The Yellow buttons at the top of the page will redirect to the operating checks and online banking pages.</li>
                                    <li>The drop down menu below the yellow buttons is used to select a payroll group.</li>
                                    <li>This is where the financial officer will select the student they want to make a check for.</li>
                                    <li>This where the FO will select the dollar amount for the selected student.</li>
                                    <li>The written amount will appear automatically after selecting the dollar amount.</li>
                                    <li>The memo will fill out automatically when the payroll group is selected.</li>
                                    <li>The save check button is used to save a check in the database.</li>
                                    <li>This drop down menu is used to select the print group. Each print group contains 4 saved checks, and the FO will have to select each group in order to print all the saved checks out.</li>
                                    <li>The Review button is used to cycle through the saved checks so the FO can view them, delete them if a mistake was made, and to print them out. Once clicked, the button will turn into the print button, which is how the FO will print out the checks.</li>
                                    <li>The arrow buttons are used to cycle through the saved checks and view them before printing. The delete button will delete the currently viewed check after the FO clicks Review.</li>
                                    <li>The Help button displays a help window that guides the FO through the system.</li>
                                    <li>The side bar has a check list of things the FO needs to do in order to progress through their job. Clicking on them will let them know when they have completed a task.</li>
                                </ol>
                            </li>
                            <li>Flow of the Page:
                                <ul>
                                    <li>When the page loads, the FO will click the yellow Ditek check button.</li>
                                    <li>After printing and signing the Ditek check, the FO will then select Payroll 1 from the drop down menu at the top. They will not be able to click on anything until that is selected.</li>
                                    <li>After selecting the payroll group, the name and dollar amount drop down menus on the check will unlock.</li>
                                    <li>The FO will select the student name from the drop down list and their payment. The written amount field and the memo will automatically fill out.</li>
                                    <li>The FO will click 'Save Check' when they have filled out the information. If they try to save a blank check, it will give them an error message and will not save the check.</li>
                                    <li>The FO will repeat that step until they have a check saved for each person.</li>
                                    <li>When they have saved a check for each person, the 'Save Check' button will be disabled, and a message will appear telling them that they are ready to review the checks before printing them.</li>
                                    <li>The FO will click 'Review' and will be able to view and cycle through the saved checks before printing using the arrow buttons. If they made a mistake on one, they will have to delete the check, by clicking Delete, and click 'Add Check'.</li>
                                    <li>When they have finished reviewing the checks, they will select a print group from the drop down menu above the Print button.</li>
                                    <li>Select a group to print, and click Print. The print window will pop up and they will click print. After they print, if needed, they will select another print group from the drop down menu.</li>
                                    <li>They will now repeat this process for payroll group 2 and 3. When they have finished for each one, they will move on to the operating checks.</li>
                                </ul>
                            </li>
                            <li>Other Mentions:
                                <ul>
                                    <li>The student cannot save a check for the same person more than once.</li>
                                    <li>The student cannot add a check when a check has been saved for each person in the business.</li>
                                </ul>
                            </li>                                                       
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/payroll_checks.jpeg" alt="Payroll checks layout" style="width: 100%; height: auto;" />
                    </div>
                </div>

                <%--Operating Checks--%>
                <div id="operChecks_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4" id="operating">Operating Check System</h3>
                        <ul>
                            <li>Layout:</li>
                            <ol>
                                <li>The Yellow buttons at the top of the page will redirect to the payroll checks and online banking pages.</li>
                                <li>The drop down menu below the yellow buttons is used to select an operating group.</li>
                                <li>This is where the financial officer will type in the name of the business.</li>
                                <li>This where the FO will type in the dollar amount for the business.</li>
                                <li>The written amount will need to be typed in by the FO after entering a dollar amount and business name.</li>
                                <li>The memo will need to typed in by the FO.</li>
                                <li>The save check button is used to save a check in the database.</li>
                                <li>The Review button is used to cycle through the saved checks so the FO can view them, delete them if a mistake was made, and to print them out. Once clicked, the button will turn into the print button, which is how the FO will print out the checks.</li>
                                <li>The arrow buttons are used to cycle through the saved checks and view them before printing. The delete button will delete the currently viewed check after the FO clicks Review.</li>
                                <li>The Help button displays a help window that guides the FO through the system.</li>
                                <li>The side bar has a check list of things the FO needs to do in order to progress through their job. Clicking on them will let them know when they have completed a task</li>
                            </ol>
                        </ul>
                        <ul>
                            <li>Flow:</li>
                            <ul>
                                <li>When the FO clicks on the Business Operating Checks button on the payroll checks page, they will first need to select operating group 1.</li>
                                <li>When selected, the fields on the check will be enabled, allowing them to enter a business name, dollar amount, the written amount, and the memo.</li>
                                <li>The information they need to fill out is found on the side bar to the right of the check. </li>
                                <li>Once all fields are filled out (if all fields are not filled out, the check will not save), they will click save check. The FO will then save a check 3 more times to each business in operating group 1.</li>
                                <li>When 4 checks have been saved, one for each business under group 1, a message will appear saying they have all 4 checks in a group saved and must click the Review button to continue. The Save Check button will be disabled.</li>
                                <li>The FO will click 'Review' and will be able to view and cycle through the saved checks before printing using the arrow buttons. If they made a mistake on one, they will have to delete the check, by clicking Delete, and click 'Add Check'. </li>
                                <li>Once they are done reviewing the checks, they will click print. The print window will pop up and they will have to click the print button on that window.</li>
                                <li>Once printed, they will sign their checks, and repeat this process for the group 2 checks and group 3 checks.</li>
                            </ul>
                        </ul>
                        <ul>
                            <li>Other Mentions:</li>
                            <ul>
                                <li>The student cannot save a check for the same person more than once.</li>
                                <li>The student cannot add a check when a check has been saved for each person in the business.</li>
                            </ul>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/operating_checks.jpeg" alt="Operating checks layout" style="width: 100%; height: auto;" />
                    </div>
                </div>

                <%--Online Banking--%>
                <div id="onBank_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4" id="online">Online Banking</h3>
                        <ul>
                            <li>This is the Online Banking page that the Financial Officer will use.</li>
                            <li>The Yellow buttons at the top of the page will redirect to the payroll checks and operating check pages.</li>
                            <li>The Summary section details the total deposits for the business, the loan amount, and the current profit.</li>
                            <li>The FO will enter in the loan amount in the Updates section in the row titled 'Loan Amount' and by clicking 'Update'.</li>
                            <li>They will do the same when the deposits 1, 2, and 3 are confirmed.</li>
                            <li>The Misc Deposit (also called Deposit 4) will be available to view towards the end of the day once all three deposits are in and they have a negative or low profit.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Online%20Banking.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--Sales System--%>
                <div id="sales_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4" id="sales">Sales System</h3>
                        <ul>
                            <li>This is the sales system that the sales associates / managers will use.</li>
                            <li>The customer will swipe their card or have their account number be entered by the salesman. </li>
                            <li>The customer's account information will appear below the Enter Account button.</li>
                            <li>The sales associate / manager will enter the item price below the Purchases section for each item the customer is buying.</li>
                            <li>When entering an item price, the total will appear below item 4. It will update automatically.</li>
                            <li>They will click Enter Sale when they have finished. The print window will appear two times, in order to print two copies from the POS printer.</li>
                            <li>The Cancel Sale button clears out all information and refreshes the page.</li>
                            <li>The sales history will show a table of each persons transaction history for the associated business.</li>
                            <li>The Help button will display a help window.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Sales%20System.jpg" alt="Create a Visit" style="height: auto; width: 100%;" /><br />
                        <img src="Images/EV Screenshots/Sales%20System%20Help.jpg" alt="Create a Visit" style="height: auto; width: 100%;" /><br />
                        <img src="Images/EV Screenshots/Sales%20History.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--Teller--%>
                <div id="teller_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4" id="teller">Teller System</h3>
                        <ul>
                            <li>This page is used for the tellers at Achieva Credit Union (formerly Bank of America). It is meant to be used with iPads only, meaning it will not have certain functions available for a computer, like printing a receipt.</li>
                            <li>The teller enters in the customer's account number in the box at the top of the page and taps Enter.</li>
                            <li>The account number information will now be displayed in the sidebar to the left of the page.</li>
                            <li>The teller will then enter the check amount below by selecting it from the list at the top of the Check Deposit System section as well as any cash being withdrawn from the list under 'Check Amount'.</li>
                            <li>The Net Deposit will calculate automatically based on the selected numbers from the lists. When the teller is done, they will tap Enter Deposit.</li>
                            <li>A small window will pop up asking if they want to open PassPrnt. They will tap Open and it will print a receipt. The teller hands the receipt to the customer and moves on to the next person.</li>
                            <li>During deposit #2, the teller will see a section to open a savings account for the student. They'll select an amount to save, then a receipt will print out when they select "Open Savings Account".</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Teller%20System%20(Savings).jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--ATM--%>
                <div id="atm_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4" id="atm">ATM</h3>
                        <ul>
                            <li>The ATM page will let students find out their deposit information, total amount of deposits, total purchases, savings amount, current balance, and transaction history.</li>
                            <li>The student can swipe their debit card or tap the Open Keyboard button on the main page to open a small keypad on screen they can use to enter in their account number. </li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/ATM.jpg" alt="Create a Visit" style="height: auto; width: 100%;" /><br />
                        <img src="Images/EV Screenshots/ATM%20Student.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--Badge Creator--%>
                <div id="badgeCre_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4" id="badge">Badge Creator</h3>
                        <ul>
                            <li>Layout:</li>

                            <ul>
                                <li>The text box under 'Enter Account Number' is where the student will enter the account number of the person getting their photo taken.</li>
                                <li>The side bar to the left has instructions for the student on how to operate the page. The total number of badges created for that day will also appear here, in yellow text.</li>
                                <li>The account information of the student will appear after they enter an account number in the badge below the 'Enter' button, and a photo of the student will appear when they take a picture and click Upload Picture.</li>
                                <li>The camera section is to the right side. The live feed of the camera will appear on top, above the Take Picture button. The taken photo will appear under that, but above the button Upload Picture.</li>
                                <li>The button at the top labeled 'Badge Print' will go to the Badge Print page, where the badges will be printed. The 'Badge History' button will go to the Badge History page, where you can see all created badges and/or delete them.</li>
                            </ul>
                        </ul>
                        <ul>
                            <li>Flow:</li>
                            <ul>
                                <li>When the page loads, if there is 0 badges saved, an error message above the badge will say, 'No Badges Created.'</li>
                                <li>The TD SYNNEX employee will type in the customer's account number. The badge will populate the information of that customer and disable the textbox. The Enter button will be replaced by a New Badge button, which resets the page.</li>
                                <li>Then, they will ask them to stand in the designated spot to take a picture. When the customer is ready, they will click 'Take Picture.'</li>
                                <li>The picture taken will appear under the live feed of the camera. When the customer views it and is happy with it, the badge creator clicks the Upload Picture button. If they decide they want a different picture AFTER the badge creator clicks Upload, they will have to delete that badge from the Badge History page and start over.</li>
                                <li>The uploaded picture now goes into the badge and is saved in the database. The badge creator then enters another account number and repeats the steps until 4 badges have been saved.</li>
                                <li>When 4 badges have been saved, the student will click on the Badge Printing button at the top.</li>
                            </ul>
                        </ul>
                        <ul>
                            <li>Some notes on functionality:</li>
                            <ul>
                                <li>The upload picture button will download the photo to a folder on the network, which the database will then use to apply the picture to the badge.</li>
                                <li>The browser on that computer must be set to download images to this specific folder, which you can do by:<br />
                                    &emsp; □ Open the web browser (microsoft Edge)<br />
                                    &emsp;   □ Clicking the 3 dots in the top right corner<br />
                                    &emsp; □ Clicking on Settings<br />
                                    &emsp;  □ Clicking on Downloads<br />
                                    &emsp;  □ Find the section that says Location, and click Change<br />
                                    &emsp;  □ Navigate to this folder: X:\inetpub\wwwroot\EV\media\Badge Photos<br />
                                    &emsp;  □ Click Select Folder</li>
                                <li>When the picture is taken with the Take Picture button, the image is downloaded to that folder. When the Upload Picture button is clicked, the system will find that file name in that folder, and rename it to something more unique to reflect the photo taken of that specific person, using the information from their account number. This new name is used to find the badge photo when it prints.</li>
                            </ul>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Badge Creator.jpg" alt="Badge creator layout" style="width: 100%; height: auto;" />
                    </div>
                </div>

                <%--Badge History--%>
                <div id="badgeHis_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4">Badge History</h3>
                        <ul>
                            <li>Layout</li>
                            <ul>
                                <li>The 2 buttons at the top of the page navigate to the other pages in the Badge Creator System.</li>
                                <li>Use the page numbers at the bottom of the table to go through the saved pages. These are listed in order of most recently saved.</li>
                                <li>Click the 'Delete' button in the row of the badge you wish to delete to delete that badge from the system.</li>
                            </ul>

                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Badge History.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--Badge Print--%>
                <div id="badgePri_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4">Print Badges</h3>
                        <ul>
                            <li>Layout</li>
                            <ul>
                                <li>The 2 buttons at the top of the page navigate to the other pages in the Badge Creator System.</li>
                                <li>All saved badges appear in the drop down menu. The account number and name of the student is used here.</li>
                                <li>When you select a student, the badge data will appear in the first badge on the left.</li>
                                <li>Selecting another student will load badge data into the next badge.</li>
                                <li>The 'Print' button will cause a password box to appear. The password to print is 'gsi123'. After that the regular print window will appear and you can print out the 4 badges.</li>
                                <li>The 'Clear' button will clear out the 4 badges. They DO NOT get deleted from the database.</li>
                            </ul>

                            <li>Flow</li>
                            <ul>
                                <li>In the Badge Print page, the student will click on the students names from the drop down menu. These will load the students into the badges on the screen. The students loaded will be removed from the drop down menu.</li>
                                <li>After 4 have been loaded, a message will appear asking them to get a teacher to print it out. The drop down menu will also be disabled until they click the 'Clear' button.</li>
                                <li>When a staff member or volunteer clicks 'Print', they will be prompted for a password. The password is 'gsi123'. After entering the password, the print window will appear.</li>
                                <li>After printing, a message will appear asking the student to clear out the badges by clicking 'Clear'. They can then print more badges.</li>
                            </ul>

                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Badge%20Printing.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--BayCare Admin Assist.--%>
                <div id="baycare_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4">BayCare Admin Assistant</h3>
                        <ul>
                            <li>This is designed for the BayCare Administrative Assistant to check in patients, issue vouchers, and print out a final report.</li>
                            <li>The 3 buttons indicate which task they will be doing.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/BayCare%20Admin.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--Voting System--%>
                <div id="voting_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4">Voting System</h3>
                        <ul>
                            <li>This page is used for the iPads in the stands at various places in the village to cast votes.</li>
                            <li>The student will enter their account number in the textbox to start the voting process.</li>
                            <li>Then, 7 questions will appear and they will need to mark off each one and tap the button on the bottom to cast the vote.</li>
                            <li>Once they're finished, the page will revert back to the main screen.</li>
                            <li>The votes get tallied up and then can be viewed and printed out by the Mayor at the end of the day.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Voting%20System%201.jpg" alt="Create a Visit" style="height: auto; width: 100%;" /><br />
                        <img src="Images/EV Screenshots/Voting%20System%202.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />
                    </div>
                </div>

                <%--Manager System--%>
                <div id="manager_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4">Manager System</h3>
                        <ul>
                            <li>This page will be used by the Managers of each EV business. The contents of the page will vary depending on the business.</li>
                            <li>Sales Businesses: Manager's will answer a questionaire to keep them busy, the questions don't submit to anything, similar to the checklists.</li>
                            <li>Non-Sales: Just like the Sales manager system, but with slightly different questions.</li>
                            <li>Ditek: the manager will print out a sheet of each businesses inventory for the following day. The inventory is chosen by the Bus Drivers.</li>
                            <li>Duke Energy: the manager will select a business and enter their account number, meter number, and readings before printing out.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Manager%20System%201.jpg" alt="Create a Visit" style="height: auto; width: 100%;" /><br />
                        <%--<img src="Images/EV Screenshots/Voting%20System%202.jpg" alt="Create a Visit" style="height: auto; width: 100%;" />--%>
                    </div>
                </div>

                <%-----------INVENTORY-----------%>

                <%--Inv - Home--%>
                <div id="invHome_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4">Inventory - Home Page</h3>
                        <ul>
                            <li>This is the home page for the inventory system of EV 2.0. EV bus drivers will see this screen when they log in. The bookkeeper and technology technician can navigate to this page through the home page.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Inventory%20-%20Home.jpg" alt="Inventory Home Page" style="height: auto; width: 100%;" />                        
                    </div>
                </div>

                <%--Inv - Create--%>
                <div id="invCreate_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4">Inventory - Create an Item</h3>
                        <ul>
                            <li>This page is used to create a new item for the EV inventory.</li>
                            <li>Fill out the fields and click 'Submit' to add the item. The fields labeled (Required) must be entered before submission.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Inventory%20-%20Create.jpg" alt="Inventory Create Page" style="height: auto; width: 100%;" />  
                    </div>
                </div>

                <%--Inv - Edit--%>
                <div id="invEdit_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4">Inventory - Edit Item</h3>
                        <ul>
                            <li>This page is used to edit an existing item in the inventory system in EV 2.0.</li>
                            <li>The page automatically loads in all items into the table which you can scroll through using the page numbers at the bottom of the table.</li>
                            <li>You can search for an item name by typing in the textbox at the top and clicking 'Search'.</li>
                            <li>You can sort by using the 2 drop down menus next to the 'Search' button. The left menu is for the column name, the right is for ascending or descending. Click 'Sort' to sort the items.</li>
                            <li>The 'Refresh' button restores the table back to default.</li>
                            <li>To edit an item, click on the 'Edit' button next to the item name in the table. Change the field(s) you wish and then click 'Update' when finished.</li>
                            <li>To delete an item, click on the 'Delete' button next to the item name. NOTE: This action cannot be undone.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Inventory%20-%20Edit.jpg" alt="Inventory Edit Item" style="height: auto; width: 100%;" />  
                    </div>
                </div>

                <%--Inv - Add On Hand--%>
                <div id="invAdd_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4">Inventory - Add / Remove On Hand Amount</h3>
                        <ul>
                            <li>This page is used to add or remove the current on hand amount for an item in the inventory of EV 2.0.</li>
                            <li>Select an item either by the drop down menu or searching it in the textbox and clicking 'Search', and the item data will load into the fields below.</li>
                            <li>Below the data for the item, you can add or remove the on hand amount by filling in the 'Activity Date', 'Amount Being Added / Subtracted', and/or 'Additional Notes' fields and clicking 'Enter'.</li>
                            <li>After clicking 'Enter', you will see the log at the bottom in a table with the username and time stamp of when the request was submitted. This is to keep track of the removal or additions of the items.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Inventory%20-%20Add.jpg" alt="Inventory Add Remove Amount" style="height: auto; width: 100%;" />  
                    </div>
                </div>

                <%--Inv - Low Inv Report--%>
                <div id="invLow_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4">Inventory - Low Inventory Report</h3>
                        <ul>
                            <li>This page is used to view all the items in the EV inventory that are low stock, meaning less than 100 on hand items.</li>
                            <li>You can sort through the table by using the 2 drop down menus at the top. The left is for the column name, the right is for ascending or descending. Click 'Sort' to activate the sorting filter.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Inventory%20-%20Low%20Inventory%20Report.jpg" alt="Inventory Low Inv Report" style="height: auto; width: 100%;" />  
                    </div>
                </div>

                <%--Inv - View All--%>
                <div id="invView_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4">Inventory - View All Items</h3>
                        <ul>
                            <li>This page is used to view all the items in the inventory of EV 2.0.</li>
                            <li>You can search for an item using a keyword. This keyword can be an item name, category, sub-category, or anything else related to an item you can think of. Click 'Search' to initiate the search.</li>
                            <li>You can sort through the table by using the 2 drop down menus at the top. The left is for the column name, the right is for ascending or descending. Click 'Sort' to activate the sorting filter.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/Inventory%20-%20View%20All%20Items.jpg" alt="Inventory View All Items" style="height: auto; width: 100%;" />  
                    </div>
                </div>

                <%-----------OTHER-----------%>

                <%--Changelog--%>
                <div id="changelog_div" class="button_grid_home" runat="server" visible="false">
                    <div class="button_item2" style="text-align: left;">
                        <h3 class="h4">Changelog</h3>
                        <ul>
                            <li>This page contains a list of all previous changes made to EV 2.0. It's used for archival purposes. Click on an update to see more information about what was changed then.</li>
                        </ul>
                    </div>
                    <div class="button_item2" style="text-align: left;">
                        <img src="Images/EV Screenshots/changelog.jpg" alt="Inventory View All Items" style="height: auto; width: 100%;" />  
                    </div>
                </div>
            </div>
        </div>


        <asp:HiddenField ID="visitdate_hf" runat="server" />
        <asp:HiddenField ID="businessID_hf" runat="server" />

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

    </form>
</body>
</html>
