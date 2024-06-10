<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Changelog.aspx.vb" Inherits="Enterprise_Village_2._0.Changelog" %>

<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0; maximum-scale=2.0; user-scalable=0;">

    <title>EV 2.0 - Changelog</title>

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
            <h2 class="h2">Changelog</h2>
            <h3>This page contains the list of previous changes made to EV 2.0 It's used for archival purposes. Click on an update to see more information about what was changed then.              
            </h3>

            <%--template--%>
            <%--<div>
                <asp:Button ID="Button1_btn" runat="server" CssClass="button3" Text="2.2." />
                <br />
                <br />
                <div id="v22XX_div" runat="server" visible="false">
                    <span style="font-weight: bold; text-decoration: underline;">Last Updated: //2024 (v2.2.)</span>
                    
                </div>
            </div>--%>


            <%--v2.2.22--%>
            <div>
                <asp:Button ID="v2222_btn" runat="server" CssClass="button3" Text="2.2.22" />
                <br />
                <br />
                <div id="v2222_div" runat="server" visible="false">
                    <span style="font-weight: bold; text-decoration: underline;">Last Updated: 3/7/2024 (v2.2.22)</span>
                    <ul>
                        <li>Closed Business Checks
                            <ul>
                                <li>Direct Deposit forms now fit within the green check paper.</li>
                            </ul>
                                                    </li>
                                                    <li>EV Lunch Forms
                            <ul>
                                <li>Letter will no longer load dates with A1 No School Scheduled selected as the first school in the visit date.</li>
                            </ul>
                                                    </li>
                                                    <li>Volunteer Database
                            <ul>
                                <li>Updated font size of check in section</li>
                                <li>Updated colors of check in section</li>
                            </ul>
                        </li>

                    </ul>
                </div>
            </div>

            <%--v2.2.21--%>
            <div>
                <asp:Button ID="v2221_btn" runat="server" CssClass="button3" Text="2.2.21" />
                <br />
                <br />
                <div id="v2221_div" runat="server" visible="false">
                    <span style="font-weight: bold; text-decoration: underline;">Last Updated: 1/25/2024 (v2.2.21)</span>
                    <ul>
                        <li>Volunteer Database
                            <ul>
                                <li>Revamped this page for Karen's use next school year.</li>
                                <li>Visit the help page to see more information on what's new.</li>
                            </ul>		                            
                        </li>
                        <li>School Visit Checklist
                            <ul>
                                <li>Changed Sandi's email in the automated email to Maria's email.
                                </li>
                            </ul>
                        </li>
                        <li>Lawyer Promissory Note
                            <ul>
                                <li>Updated side bar text.</li>
                            </ul>
                        </li>
                        <li>Removed IT Specialist from TD SYNNEX</li>
                        <li>Various database changes and additions.</li>
                        <li>2.2.21a
                            <ul>
                                <li>Voting System
                                    <ul>
                                        <li>Updated questions and answers.</li>
                                    </ul>
                                </li>
                                <li>School Visit Checklist
                                    <ul>
                                        <li>Changed Sandi's email in the automated email to Maria's email.</li>
                                    </ul>
                                </li>
                            </ul>
                        </li>
                    </ul>
                </div>
            </div>

            <%--v2.2.20--%>
            <div>
                <asp:Button ID="v2220_btn" runat="server" CssClass="button3" Text="2.2.20" />
                <br />
                <br />
                <div id="v2220_div" runat="server" visible="false">
                    <span style="font-weight: bold; text-decoration: underline;">Last Updated: 1/11/2023 (v2.2.20)</span>
                    <ul>
                        <li>Teacher Home
                            <ul>
                                <li>Changed the amount of days a teacher can submit their articles from 3 days before visit date to 1 day before.</li>
                            </ul>
                                                        <li>Teacher Letter
                                <ul>
                                    <li>Updated text on the bottom of the public schools letter.</li>
                                </ul>
                                                        </li>
                                                        <li>Voting System
                                <ul>
                                    <li>Removed answers for questions 1, 2, 4, and 5</li>
                                </ul>
                                                        </li>
                                                        <li>Voting System Mayor
                                <ul>
                                    <li>Removed answers for questions 1, 2, 4, and 5</li>
                                </ul>
                            </li>
                        </li>
                    </ul>
                </div>
            </div>

            <%--2.2.19--%>
            <div>
                <asp:Button ID="v2219_btn" runat="server" CssClass="button3" Text="2.2.19" />
                <br />
                <br />
                <div id="v2219_div" runat="server" visible="false">
                    <span style="font-weight: bold; text-decoration: underline;">Last Updated: 1/9/2023 (v2.2.19)</span>

                </div>
            </div>

            <%--v2.2.18--%>
            <div>
                <asp:Button ID="v2218_btn" runat="server" CssClass="button3" Text="2.2.18" />
                <br />
                <br />
                <div id="v2218_div" runat="server" visible="false">
                    <span style="font-weight: bold; text-decoration: underline;">Last Updated: 12/14/2023 (v2.2.18)</span>
                    <ul>
                        <li>Voting System & Voting System Mayor
                            <ul>
                                <li>Replaced questions with updated ones.</li>
                                <li>Added more answers to questions 1, 2, and 5.</li>
                                <li>Removed question 6.</li>
                            </ul>
                        </li>
                        <li>Duplicate Students
                            <ul>
                                <li>Fixed an issue where it would display multiple account numbers with a blank name.</li>
                            </ul>
                        </li>
                        <li>UPS Package Handler Checklist
                            <ul>
                                <li>Changed PCSW to PC Solid Waste.</li>
                            </ul>
                        </li>
                        <li>Inventory Home
                            <ul>
                                <li>Student count now shows correct student count.</li>
                                <li>Decreased button size.</li>
                            </ul>
                        </li>
                        <li>Create a Visit
                            <ul>
                                <li>Updated description text.</li>
                                <li>Removed fields for volunteer lead, back up teacher, and floor facilitator.</li>
                            </ul>
                        </li>
                        <li>Edit Profits
                            <ul>
                                <li>Moved Misc. Deposits table up.</li>
                            </ul>
                        </li>
                        <li>Various backend fixes and improvements.</li>
                    </ul>
                </div>
            </div>

            <%--v2.2.17--%>
            <div>
                <asp:Button ID="v2217_btn" runat="server" CssClass="button3" Text="2.2.17" />
                <br />
                <br />
                <div id="v2217_div" runat="server" visible="false">
                    <span style="font-weight: bold; text-decoration: underline;">Last Updated: 12/7/2023 (v2.2.17)</span>
                    <ul>
                        <li>Edit School
		                            <ul>
                                        <li>Fixed an issue where the current and previous visit dates would not update when changing a visit date in Edit Visit.</li>
                                    </ul>
                        </li>
                        <li>Various backend fixes and improvements.</li>
                    </ul>
                </div>
            </div>

            <%--v2.2.16--%>
            <div>
                <asp:Button ID="v2216_btn" runat="server" CssClass="button3" Text="2.2.16" />
                <br />
                <br />
                <div id="v2216_div" runat="server" visible="false">
                    <span style="font-weight: bold; text-decoration: underline;">Last Updated: 11/30/2023 (v2.2.16)</span>
                    <ul>
                        <li>Newspaper Hub
		                            <ul>
                                        <li>Added uploaded date and time to the file name.</li>
                                    </ul>
                        </li>
                        <li>Closed Business Checks
		                            <ul>
                                        <li>Textboxes can now be typed in.</li>
                                    </ul>
                        </li>
                        <li>Teacher Home
		                            <ul>
                                        <li>Added a check for uploading articles. Teachers cannot upload articles if the current date is 3 days or less away from the visit date.</li>
                                    </ul>
                        </li>

                    </ul>
                </div>
            </div>

            <%--v2.2.15--%>
            <div>
                <asp:Button ID="v2215_btn" runat="server" CssClass="button3" Text="2.2.15" />
                <br />
                <br />
                <div id="v2215_div" runat="server" visible="false">
                    <span style="font-weight: bold; text-decoration: underline;">Last Updated: 11/16/2023 (v2.2.15)</span>
                    <ul>
                        <li>Teller System
		                            <ul>
                                        <li>Fixed an issue where the page would not automatically refresh after printing the savings receipt.</li>
                                    </ul>
                        </li>
                        <li>Closed Business Checks
		                            <ul>
                                        <li>Added the Direct Deposit form to the Payroll group 2</li>
                                    </ul>
                        </li>
                        <li>Input Student Info (Teacher Student Input)
		                            <ul>
                                        <li>Added an error message when the first name or last name is blank when the other one is not.</li>
                                    </ul>
                        </li>
                        <li>Tampa Bay Times Marketing Rep Checklist
		                    <ul>
                                <li>Enabled checkbox for PCSW and Times.</li>
                            </ul>
                        </li>
                        <li>New Page:
		                            <ul>
                                        <li>Visit Calendar (Found under Forms and Reports)
				                            <ul>
                                                <li>This page contains all the visiting schools in a selected month in a calendar view format, similar to Outlook.</li>
                                            </ul>
                                        </li>
                                    </ul>
                        </li>
                    </ul>
                </div>
            </div>

            <%--v2.2.14--%>
            <div>
                <asp:Button ID="v2214_btn" runat="server" CssClass="button3" Text="2.2.14" />
                <br />
                <br />
                <div id="v2214_div" runat="server" visible="false">
                    <span style="font-weight: bold; text-decoration: underline;">Last Updated: 11/9/2023 (v2.2.14)</span>
                    <ul>
                        <li>Teller System
		                            <ul>
                                        <li>Fixed an issue where the balance shown would not reflect transactions.</li>
                                    </ul>
                        </li>
                        <li>Upload / Move Articles
		                            <ul>
                                        <li>Fixed an issue with uploading articles.</li>
                                    </ul>
                        </li>
                        <li>Lawyer Promissory Note
		                            <ul>
                                        <li>Updated the sidebar help text.</li>
                                    </ul>
                        </li>
                        <li>EV Daily Forms
		                            <ul>
                                        <li>Added "kit returned… yes or no" line.</li>
                                        <li>Removed the top header bar from printing.</li>
                                    </ul>
                        </li>

                    </ul>
                </div>
            </div>

            <%--v2.2.13--%>
            <div>
                <asp:Button ID="v2213_btn" runat="server" CssClass="button3" Text="2.2.13" />
                <br />
                <br />
                <div id="v2213_div" runat="server" visible="false">
                    <span style="font-weight: bold; text-decoration: underline;">Last Updated: 11/02/2023 (v2.2.13)</span>
                    <ul>
                        <li>Teacher Home (Used by non-GSI teachers when they log into EV 2.0)
		                        <ul>
                                    <li>Fixed an issue where the articles would not upload if a visit date folder AND school name folder did not exist.</li>
                                </ul>
                        </li>
                        <li>Move Articles
		                        <ul>
                                    <li>The name of the page has been changed to Upload / Move Articles</li>
                                    <li>Can now upload newspaper articles from the staff side without having to sign in as the teacher.</li>
                                </ul>
                        </li>
                        <li>Ditek Inventory Checklist
		                        <ul>
                                    <li>Enabled BayCare surge protector checkbox</li>
                                </ul>
                        </li>
                        <li>Magic Computer
		                        <ul>
                                    <li>Added ability to edit savings amount for a student.</li>
                                </ul>
                        </li>
                    </ul>
                </div>
            </div>

            <%--v2.2.12--%>
            <div>
                <asp:Button ID="v2212_btn" runat="server" CssClass="button3" Text="2.2.12" />
                <br />
                <br />
                <div id="v2212_div" runat="server" visible="false">
                    <span style="font-weight: bold; text-decoration: underline;">Last Updated: 10/19/2023 (v2.2.12)</span>
                    <ul>
                        <li>Badge Creator
		                        <ul>
                                    <li>Fixed an issue where the first badge in a series would load after uploading a photo instead of the most recent one.</li>
                                </ul>
                        </li>
                        <li>Closed Business Checks
		                        <ul>
                                    <li>Added a drop down list to select which kind of check it's loading, payroll or operating.
                                    </li>
                                </ul>
                        </li>
                        <li>Home Page
		                        <ul>
                                    <li>When clicking on a school from the Weekly Calendar, it will now take you to the Employee Report page of that visit date and school.
                                    </li>
                                </ul>
                        </li>
                        <li>Magic Computer
		                        <ul>
                                    <li>Increased deposit amount max to $7.00.</li>
                                    <li>Fixed an issue where an error would appear when trying to edit a deposit with $0.50.</li>
                                </ul>
                        </li>
                        <li>Sales System
		                        <ul>
                                    <li>Increased minimum and maximum price to $1.50-$14.00.</li>
                                </ul>
                        </li>
                        <li>Duke Meter Reader Checklist
		                        <ul>
                                    <li>Replaced Bank of America with Achieva Credit Union and Bic Graphic with Koozie Group.</li>
                                </ul>
                        </li>
                        <li>Teacher Letter
		                        <ul>
                                    <li>Changed text from "REPLY BY" to "REPLY BEFORE".</li>
                                    <li>Updated text of McDonald's lunch directions.</li>
                                </ul>
                        </li>
                        <li>Newspaper Hub
		                        <ul>
                                    <li>Removed ability to delete articles.</li>
                                </ul>
                        </li>
                    </ul>
                </div>
            </div>

            <%--v2.2.11--%>
            <div>
                <asp:Button ID="v2211_btn" runat="server" CssClass="button3" Text="2.2.11" />
                <br />
                <br />
                <div id="v2211_div" runat="server" visible="false">
                    <span style="font-weight: bold; text-decoration: underline;">Last Updated: 10/2/2023 (v2.2.11a)</span>
                    <ul>
                        <li>Newspaper Hub
		                        <ul>
                                    <li>Added a visit date textbox in order to view articles uploaded ahead of the visit date</li>
                                </ul>
                        </li>
                        <li>Teacher Letter
		                        <ul>
                                    <li>Moved "Business assignment sheets and volunteer list should be returned by the reply date below" in section 3 (PCSB schools only)</li>
                                    <li>Removed "please do not send more volunteers than the number assigned" from section 5.</li>
                                    <li>Removed section 7 (transportation) from view.</li>
                                    <li>Made font size bigger on the lunch paragraph on the bottom of the letter.</li>
                                </ul>
                        </li>

                    </ul>
                    <ul>
                        <li>ATM
                                <ul>
                                    <li>Made textbox smaller so 3 numbers would fit in better.</li>
                                </ul>
                        </li>
                        <li>Judgement Case (Slipper Pickle)
                                <ul>
                                    <li>Attorney can now type their name into the field at the bottom.</li>
                                </ul>
                        </li>
                        <li>Duke Manager System
                                <ul>
                                    <li>Removed Duke, Dali, UPS, PCW, and PCSW from the business name drop down menu.</li>
                                    <li>Energy used is now calculated after the user enters todays and yesterday's readings automatically.</li>
                                </ul>
                        </li>
                        <li>McDonald's Sales System
                                <ul>
                                    <li>Fixed an bug where the teller would not reload the page after printing a receipt.</li>
                                    <li>Page now checks if a student name is associated with an account number, if the name is blank, then it will give an error message.</li>
                                </ul>
                        </li>
                        <li>Teller System
                                <ul>
                                    <li>Fixed an bug where the teller would not reload the page after printing a receipt.</li>
                                </ul>
                        </li>
                        <li>Voting System
                                <ul>
                                    <li>Added voting system to white stand iPads.</li>
                                    <li>Added a cancel button so they student can go back to the main page.</li>
                                </ul>
                        </li>
                        <li>Various backend improvements and fixes.</li>
                    </ul>
                </div>
            </div>

            <%--v2.2.10--%>
            <div>
                <asp:Button ID="v2210_btn" runat="server" CssClass="button3" Text="2.2.10" />
                <br />
                <br />
                <div id="v2210_div" runat="server" visible="false">
                    <span style="font-weight: bold; text-decoration: underline;">Last Updated: 9/20/2023 (v2.2.10)</span>
                    <ul>
                        <li>Update 2.2.10a
                            <ul>
                                <li>ATM
					                <ul>
                                        <li>Fixed an issue where the deposits would not load correctly</li>
                                    </ul>
                                </li>
                                <li>Checklists
					                <ul>
                                        <li>Added PCSW to some checklists and updated text.</li>
                                    </ul>
                                </li>
                            </ul>
                        </li>

                        <li>Family and Community Liaison Letter
					        <ul>
                                <li>Fixed the volunteer count being displayed on the letter.</li>
                            </ul>
                        </li>
                        <li>School Visit Checklist
					        <ul>
                                <li>Fixed an issue where if there was multiple entries with the same school name, it would incorrectly pull data from the wrong visit date.</li>
                            </ul>
                        </li>
                        <li>Various backend improvements and fixes.</li>
                    </ul>
                </div>
            </div>

            <%--v2.2.09--%>
            <div>
                <asp:Button ID="v2209_btn" runat="server" CssClass="button3" Text="2.2.09" />
                <br />
                <br />
                <div id="v2209_div" runat="server" visible="false">
                    <span style="font-weight: bold; text-decoration: underline;">Last Updated: 9/14/2023 (v2.2.09)</span>
                    <ul>
                        <li>Ditek Manager System
					            <ul>
                                    <li>Added 'Deliver to: Business Name' on top of page when printing.</li>
                                    <li>Fixed a bug where the pricing key would stay visible after switching from a selling business to a non-selling business.</li>
                                </ul>
                        </li>
                        <li>School Visit Checklist
					                <ul>
                                        <li>Changed 'Delivered' to 'Delivery' on Delivery Method.</li>
                                        <li>TAs can now update step 4 whenever.</li>
                                        <li>Added 'Last Edited By' line. Will show the username and date and time of the last time the section was edited.</li>
                                        <li>LoadData() error is fixed.</li>
                                    </ul>
                        </li>
                    </ul>
                </div>
            </div>

            <%--v2.2.08--%>
            <div>
                <asp:Button ID="v2208_btn" runat="server" CssClass="button3" Text="2.2.08" />
                <br />
                <br />
                <div id="v2208_div" runat="server" visible="false">
                    <span style="font-weight: bold; text-decoration: underline;">Last Updated: 9/12/2023 (v2.2.08b)</span>
                    <ul>
                        <li>Hotfix b (9/12/2023)
                                <ul>
                                    <li>Teacher Letter
                                        <ul>
                                            <li>Dismissal time now shows PM instead of AM.</li>
                                            <li>Made Non-PCSB letter the same as the PCSB letter.</li>
                                            <li>Updated text for section 3 and 6.</li>
                                        </ul>
                                    </li>
                                    <li>Inventory Home Page
                                        <ul>
                                            <li>Added link to EV 2.0 Main site.</li>
                                        </ul>
                                    </li>
                                    <li>Kit Inventory
                                        <ul>
                                            <li>Removed Teacher First and Last name columns from table and textboxes on Data Entry.</li>
                                            <li>Removed GSI Checked In on Data Entry.</li>
                                            <li>Added Delete button on kit inventory tables.</li>
                                            <li>Date In field will no longer show 01/01/1900 when updating the row IF the Date In field is blank.</li>
                                            <li>Replaced Charla with Michelle on GSI Checked In DDL.</li>
                                        </ul>
                                    </li>
                                    <li>School Notes
                                        <ul>
                                            <li>Added school addresses. If address does not show, edit it in the Edit School page.</li>
                                        </ul>
                                    </li>
                                </ul>
                        </li>
                        <li>Hotfix a (9/8/2023)
					        <ul>
                                <li>Edit Business
							        <ul>
                                        <li>Removed business name DDL.</li>
                                    </ul>
                                </li>
                                <li>Kit Inventory
							        <ul>
                                        <li>Kit number field can now be edited.</li>
                                        <li>Fixed a bug where it would not update if there was no date entered.</li>
                                    </ul>
                                </li>
                                <li>School Visit Checklist
							        <ul>
                                        <li>Front office can now edit step 3 is step 4 is completed.</li>
                                        <li>Added a textbox for the student count section in the teacher's only section. This is so the staff can manually enter in student count numbers for each school.</li>
                                    </ul>
                                </li>
                                <li>Parent Letter
							        <ul>
                                        <li>Added school name drop down list (used to get the volunteer range for the selected schools).</li>
                                    </ul>
                                </li>
                                <li>Teacher Letter
							        <ul>
                                        <li>The number of students section will now read the manually entered student count from the Teacher's Only section of the School Visit Checklist. Must be manually entered by a user. If the number can't be obtained, it will get the approximate student count from when the visit date was created (that goes for visits with multiple schools).</li>
                                    </ul>
                                </li>
                            </ul>
                        </li>
                        <li>Visit Report
					            <ul>
                                    <li>Added drop down list to view by month.</li>
                                    <li>Added print button.</li>
                                    <li>Moved student count column to fit in with print page.</li>
                                </ul>
                        </li>
                        <li>Family and Community Liaison Information
					            <ul>
                                    <li>Fixed an error where it would not load the volunteer dismissal time.</li>
                                    <li>Updated text on letter.</li>
                                </ul>
                        </li>
                        <li>Teacher Letter
					            <ul>
                                    <li>Updated text of paragraph 2 and 6.</li>
                                    <li>Fixed a bug where to would show 0 as the student count instead of the entered count from the Create a Visit page.</li>
                                </ul>
                        </li>
                        <li>Kit Inventory
					            <ul>
                                    <li>Removed Date In section from Data Entry.</li>
                                </ul>
                        </li>
                        <li>School Visit Checklist
					            <ul>
                                    <li>Front office staff can now view and click the Print Ticket button.</li>
                                    <li>Made notes textbox slightly bigger and wider. Can still be adjusted in size manually if needed.</li>
                                </ul>
                        </li>
                        <li>New Page
					            <ul>
                                    <li>Edit Business
							            <ul>
                                            <li>Used to edit various things about the businesses in EV (i.e. the name, address, jobs, and starting balance). Created this for future proofing reasons.</li>
                                        </ul>
                                    </li>
                                </ul>
                        </li>
                    </ul>
                </div>
            </div>

            <%--v2.2.07--%>
            <div>
                <asp:Button ID="v2207_btn" runat="server" CssClass="button3" Text="2.2.07" />
                <br />
                <br />
                <div id="v2207_div" runat="server" visible="false">
                    <span style="font-weight: bold; text-decoration: underline;">Last Updated: 8/25/2023 (v2.2.07)</span>
                    <ul>
                        <li>Closed Business Checks
					            <ul>
                                    <li>Removed "DOLLARS" from the written amount on the checks.</li>
                                    <li>Fixed an error where loading the checks of PC Solid Waste and PC Water would crash.</li>
                                    <li>Added a separate button for City Hall checks that assigns all 4 checks as ditek checks.</li>
                                </ul>
                        </li>
                        <li>Payroll Check Writing System
					            <ul>
                                    <li>Removed "DOLLARS" from the written amount on the checks.</li>
                                </ul>
                        </li>
                        <li>Edit Teachers
					            <ul>
                                    <li>Added Search text field.</li>
                                    <li>No longer need to select a school to few teachers, will automatically load a table of teachers upon page load.</li>
                                </ul>
                        </li>
                        <li>Sales System
					            <ul>
                                    <li>Fixed a typo on the help window, "receipts".</li>
                                </ul>
                        </li>
                        <li>Kit Inventory
					            <ul>
                                    <li>Cleared all previous kits.</li>
                                </ul>
                        </li>
                        <li>Miscellaneous
					            <ul>
                                    <li>Removed teachers from deleted schools in the database (i.e. Test School 907, Test School 917, Clearwater Intermediate, etc.)</li>
                                    <li>Fixed a Typo on the BBB address in checks.</li>
                                    <li>Updated background for student pages on Koozie Group.</li>
                                </ul>
                        </li>
                    </ul>
                </div>
            </div>

            <%--v2.2.06--%>
            <div>
                <asp:Button ID="v2206_btn" runat="server" CssClass="button3" Text="2.2.06" />
                <br />
                <br />
                <div id="v2206_div" runat="server" visible="false">
                    <span style="font-weight: bold; text-decoration: underline;">Last Updated: 8/22/2023 (v2.2.06)</span>
                    <ul>
                        <li>Break Schedules
					<ul>
                        <li>Added colors to each break time.</li>
                        <li>Added more schedule times to the bottom of the page.</li>
                    </ul>
                        </li>
                        <li>Closed Business Checks
					<ul>
                        <li>Added signature to checks.</li>
                    </ul>
                        </li>
                        <li>Payroll Check Writing System
					<ul>
                        <li>Fixed a typo on the sidebar.</li>
                    </ul>
                        </li>
                        <li>Edit Item
					<ul>
                        <li>Added "Filter By" drop down menu. Can use this to only view items in specific businesses.</li>
                        <li>Fixed an issue where it would not load the data correctly.</li>
                    </ul>
                        </li>
                        <li>Teacher Letter
					<ul>
                        <li>Arrival time for students is now correctly entered.</li>
                        <li>Dismissal time for students is now correctly entered.</li>
                        <li>Updated text in paragraph 3: "student articles/stories are in the Teaching Kit."</li>
                    </ul>
                        </li>
                        <li>Teller System
					<ul>
                        <li>Fixed various bugs relating to the savings window not appearing, deposit 3 not accepting, etc.</li>
                    </ul>
                        </li>
                        <li>Magic Computer
					<ul>
                        <li>Added the ability to remove the direct deposit if needed.</li>
                    </ul>
                        </li>
                        <li>Manager System
					<ul>
                        <li>Added pricing key to ditek inventory manager system.</li>
                    </ul>
                        </li>

                        <li>Operating Check Writing System
					<ul>
                        <li>Updated color of text on each groups.</li>
                    </ul>
                        </li>
                    </ul>
                </div>
            </div>

            <%--v2.2.05--%>
            <div>
                <asp:Button ID="v2205_btn" runat="server" CssClass="button3" Text="2.2.05" />
                <br />
                <br />
                <div id="v2205_div" runat="server" visible="false">
                    <span style="font-weight: bold; text-decoration: underline;">Last Updated: 8/17/2023 (v2.2.05)</span>
                    <ul>
                        <li>Bus Transportation
					<ul>
                        <li>Added calculations fields.</li>
                        <li>Increased text size and boldened the total cost fields, mileage fields, and time fields.</li>
                    </ul>
                        </li>
                        <li>Requested Feature
					<ul>
                        <li>When creating a new post, an email addressed to sweeneya@pcsb.org will open.</li>
                    </ul>
                        </li>
                        <li>School Visit Checklist
					<ul>
                        <li>Added 0 to the amount of kits you can select.</li>
                        <li>Replaced emails addressed to Mary with Sandy.</li>
                    </ul>
                        </li>
                        <li>Teller System
					<ul>
                        <li>Removed deposit section during 2nd deposit to only allow the teller to open a savings account for the customer.</li>
                    </ul>
                        </li>
                        <li>Business Directory
					<ul>
                        <li>Changed name of Manager Inventory System to just Manager System for all businesses.</li>
                    </ul>
                        </li>
                        <li>Teller System
					<ul>
                        <li>Removed deposit section during 2nd deposit to only allow the teller to open a savings account for the customer.</li>
                    </ul>
                        </li>
                        <li>Inventory Home
					<ul>
                        <li>Added link to the Ditek Manager System.</li>
                    </ul>
                        </li>
                    </ul>

                </div>
            </div>

            <%--v2.2.04--%>
            <div>
                <asp:Button ID="v2204_btn" runat="server" CssClass="button3" Text="2.2.04" />
                <br />
                <br />
                <div id="v2204_div" runat="server" visible="false">
                    <span style="font-weight: bold; text-decoration: underline;">Last Updated: 8/10/2023 (v2.2.04)</span>
                    <ul>
                        <li>Manager System
					        <ul>
                                <li>Added "Duke will collect your payment" in the duke manager system.</li>
                            </ul>
                        </li>
                        <li>Parent Letter
					        <ul>
                                <li>Fixed typos and increased McDonald's lunch price to $3.00.</li>
                            </ul>
                        </li>
                        <li>EV Lunch Forms
					        <ul>
                                <li>Fixed Stavros phone number on the letter.</li>
                            </ul>
                        </li>
                        <li>Teller System
					        <ul>
                                <li>Savings account window will no longer appear when the 3rd deposit is enabled.</li>
                            </ul>
                        </li>
                        <li>Bus Transport
					        <ul>
                                <li>Added ability to edit the mileage.</li>
                            </ul>
                        </li>
                        <li>Teacher Letter
					        <ul>
                                <li>Updated school lunch prices to $3 for students AND staff.</li>
                            </ul>
                        </li>
                        <li>School Visit Checklist
					        <ul>
                                <li>Changed student count value to reflect the entered approximate student count from Create a Visit.</li>
                            </ul>
                        </li>
                        <li>Break Schedules
					        <ul>
                                <li>Added different color font to each break.</li>
                            </ul>
                        </li>
                        <li>New Page: Closed Business Checks
					        <ul>
                                <li>Can be used to print out the operating checks on businesses that are closed.</li>
                            </ul>
                        </li>
                        <li>Various backend improvements.</li>
                    </ul>
                </div>
            </div>

            <%--v2.2.03--%>
            <div>
                <asp:Button ID="v2203_btn" runat="server" CssClass="button3" Text="2.2.03" />
                <br />
                <br />
                <div id="v2203_div" runat="server" visible="false">
                    <span style="font-weight: bold; text-decoration: underline;">Last Updated: 8/3/2023 (v2.2.03)</span>
                    <ul>
                        <li>ATM
					                <ul>
                                        <li>Fixed sizing.</li>
                                    </ul>
                        </li>
                        <li>Business Sales Report
					                <ul>
                                        <li>Removed check for visit date.</li>
                                    </ul>
                        </li>
                        <li>Various backend improvements.</li>
                    </ul>
                </div>
            </div>

            <%--v2.2.02--%>
            <div>
                <asp:Button ID="v2202_btn" runat="server" CssClass="button3" Text="2.2.02" />
                <br />
                <br />
                <div id="v2202_div" runat="server" visible="false">
                    <span style="font-weight: bold; text-decoration: underline;">Last Updated: 7/27/2023 (v2.2.02)</span>
                    <ul>
                        <li>Updated the look of the tables on multiple pages.</li>
                        <li>School Report
					                <ul>
                                        <li>Fixed an issue where the schools would not load upon loading the page.</li>
                                    </ul>
                        </li>
                        <li>Amount Spent Report
					                <ul>
                                        <li>Fixed an issue where the school would not load after selecting one from the DDL.</li>
                                    </ul>
                        </li>
                        <li>Manager System
					                <ul>
                                        <li>Added ability to save readings data for a business.</li>
                                    </ul>
                        </li>
                    </ul>

                </div>
            </div>

            <%--v2.2.01--%>
            <div>
                <asp:Button ID="v2201_btn" runat="server" CssClass="button3" Text="2.2.01" />
                <br />
                <br />
                <div id="v2201_div" runat="server" visible="false">
                    <span style="font-weight: bold; text-decoration: underline;">Last Updated: 7/20/2023 (v2.2.01)</span>
                    <ul>
                        <li>Bus Transport
					<ul>
                        <li>Visit date on letter formatted to mm/dd/yyyy.</li>
                        <li>Print button works now.</li>
                    </ul>
                        </li>
                        <li>Business Directory
					<ul>
                        <li>Added newspaper hub under Times.</li>
                    </ul>
                        </li>
                        <li>Business Sales Report
					<ul>
                        <li>Fixed table not displaying.</li>
                    </ul>
                        </li>
                        <li>Edit School
					<ul>
                        <li>Added editable columns for address, city, and zip code.</li>
                        <li>Removed ability to change school name, current and previous visit dates.</li>
                        <li>Moved columns around.</li>
                    </ul>
                        </li>
                        <li>Edit Visit
					<ul>
                        <li>Added a message when updating that lets the staff know that if they have updated the visit date, they must go to the move articles page to move the newspaper articles to update the location of the articles, if needed.</li>
                    </ul>
                        </li>
                        <li>Help Page
					<ul>
                        <li>Added photo for bus transportation.</li>
                        <li>Added photo for teller savings and description.</li>
                    </ul>
                        </li>
                        <li>Magic Computer
					<ul>
                        <li>Removed enable deposit #2 button.</li>
                        <li>Brought back the old deposit  update tables.</li>
                        <li>Increased deposit updates textboxes size.</li>
                        <li>Updated error label from "transfer to savings" to "direct deposit".</li>
                        <li>Fixed an issue where you could not update CBW for decimals.</li>
                    </ul>
                        </li>
                        <li>Manager System
					<ul>
                        <li>Duke: added print button</li>
                    </ul>
                        </li>
                        <li>SRF Checklist
					<ul>
                        <li>Added contact teacher's email.</li>
                    </ul>
                        </li>
                    </ul>
                </div>
            </div>

            <%--v2.2 Final Expansion Update--%>
            <div>
                <asp:Button ID="v22_btn" runat="server" CssClass="button3" Text="2.2" />
                <br />
                <br />
                <div id="v22_div" runat="server" visible="false">
                    <span style="font-weight: bold; text-decoration: underline;">Last Updated: 7/13/2023 (v2.2)</span>
                    <ul>
                        <li>Added "EV 2.0 - " to some pages, will finish adding them future updates.</li>
                        <li>Changed "BIC Graphics" to "Koozie Group" to all pages in EV 2.0.</li>
                        <li>Edit School
                                <ul>
                                    <li>Fixed an issue where it would not load or update the table.</li>
                                    <li>Dates now show only the date not the time.</li>
                                    <li>Added some width to some textboxes.</li>
                                </ul>
                        </li>
                        <li>School Schedule
	                            <ul>
                                    <li>Removed ability to edit the schedule. If the schedule needs to be changed, let the tech know.</li>
                                </ul>
                        </li>
                        <li>Volunteer Database
	                            <ul>
                                    <li>Added refresh button.</li>
                                </ul>
                        </li>
                        <li>New Pages
				                <ul>
                                    <li>Requested Features and Bug Reports
					                <ul>
                                        <li>This page will be used to ask for new feature or pages in EV 2.0, as well as report any sort of bug or issue .</li>
                                    </ul>
                                    </li>
                                </ul>
                        </li>
                        <li>Various backend updates.</li>
                    </ul>
                </div>
            </div>

            <%--v2.1.15--%>
            <div>
                <asp:Button ID="v2115_btn" runat="server" CssClass="button3" Text="2.1.15" />
                <br />
                <br />
                <div id="v2115_div" runat="server" visible="false">
                    <span style="font-weight: bold; text-decoration: underline;">Last Updated: 7/6/2023 (v2.1.15)</span>
                    <ul>
                        <li>Volunteer DB
                                <ul>
                                    <li>Finished work on the search function (will only search by first or last name).</li>
                                </ul>
                        </li>
                        <li>Home Page
	                            <ul>
                                    <li>Added volunteer DB to tools.</li>
                                </ul>
                        </li>
                        <li>Sidebar
	                            <ul>
                                    <li>Added volunteer DB to tools.</li>
                                </ul>
                        </li>
                        <li>Employee Management System (EMS)
	                            <ul>
                                    <li>Updated text on change school button paragraph.</li>
                                </ul>
                        </li>
                        <li>School Notes
	                            <ul>
                                    <li>Added highlighting editable rows.</li>
                                    <li>Table is now ordered by latest date and time.</li>
                                </ul>
                        </li>
                        <li>New Pages
				                <ul>
                                    <li>School Schedule
					                <ul>
                                        <li>Contains all the times for each school schedule time.</li>
                                    </ul>
                                    </li>
                                </ul>
                        </li>
                        <li>Various backend updates.</li>
                    </ul>
                </div>
            </div>

            <%--v2.1.14--%>
            <div>
                <asp:Button ID="v2114" runat="server" CssClass="button3" Text="2.1.14" />
                <br />
                <br />
                <div id="v2114_div" runat="server" visible="false">
                    <span style="font-weight: bold; text-decoration: underline;">Last Updated: 6/29/2023 (v2.1.14)</span>
                    <ul>
                        <li>Replaced all instances of Bank of America with Achieva Credit Union, including checklists.
                        </li>
                        <li>Bus Transportation
                                <ul>
                                    <li>Selecting a visit date now automatically loads the data without having to press Enter.</li>
                                </ul>
                        </li>
                        <li>Voting System Mayor
	                            <ul>
                                    <li>Added percentage signs to the vote numbers.</li>
                                </ul>
                        </li>
                        <li>Business Directory
	                            <ul>
                                    <li>Added voting system mayor to City Hall section.</li>
                                </ul>
                        </li>
                        <li>New Pages
				                <ul>
                                    <li>Volunteer Database
					                <ul>
                                        <li>This will be used to view and create volunteers for EV. All data is from the FileMaker Pro database.</li>
                                    </ul>
                                    </li>
                                </ul>
                        </li>
                        <li>Various backend updates.</li>
                    </ul>
                </div>
            </div>

            <%--v2.1.13--%>
            <div>
                <asp:Button ID="v2113" runat="server" CssClass="button3" Text="2.1.13" />
                <br />
                <br />
                <div id="v2113_div" runat="server" visible="false">
                    <span style="font-weight: bold; text-decoration: underline;">v2.1.13 (6/22/2023)</span>
                    <ul>
                        <li>Hotfix a
                                <ul>
                                    <li>Fixed an issue where the Badge Creator would not upload the photo correctly.</li>
                                </ul>
                        </li>
                        <li>Updated salaries to $6, 6.50, 7
                        </li>
                        <li>Home Page
                                <ul>
                                    <li>Fixed the like to Edit Profits.</li>
                                    <li>Added schedule request form checklist to Tools.</li>
                                </ul>
                        </li>
                        <li>Sidebar
	                            <ul>
                                    <li>Added new pages.</li>
                                </ul>
                        </li>
                        <li>Business Directory
	                            <ul>
                                    <li>Added voting system mayor to City Hall section.</li>
                                </ul>
                        </li>
                        <li>New Pages
				                <ul>
                                    <li>Bus Transportation
                                    </li>
                                    <li>Voting System Mayor
                                    </li>
                                </ul>
                        </li>
                        <li>Various backend updates.</li>
                    </ul>
                </div>
            </div>

            <%--v2.1.12--%>
            <div>
                <asp:Button ID="v2112_btn" runat="server" CssClass="button3" Text="2.1.12" />
                <br />
                <br />
                <div id="v2112_div" runat="server" visible="false">
                    <span style="font-weight: bold; text-decoration: underline;">v2.1.12 (6/15/2023)</span>
                    <ul>
                        <li>Add / Remove On Hand Amount
                                <ul>
                                    <li>Removed the ability to edit the amount being added/subtracted from the table. If the number needs to change, the user will have to submit another entry.</li>
                                </ul>
                        </li>
                        <li>Duplicate Students
                                <ul>
                                    <li>Finished work on it. Can now use it to find duplicate students in EV 2.0.</li>
                                </ul>
                        </li>
                        <li>Manager System
                                <ul>
                                    <li>Finished working on Duke.</li>
                                </ul>
                        </li>
                        <li>Teacher Letter
	                            <ul>
                                    <li>Removed 'am' at the end of group 4 because the time adds it automatically.</li>
                                </ul>
                        </li>
                        <li>Home Page
	                            <ul>
                                    <li>Added new pages.</li>
                                </ul>
                        </li>
                        <li>Sidebar
	                            <ul>
                                    <li>Added new pages.</li>
                                    <li>Added Reports pages.</li>
                                </ul>
                        </li>
                        <li>Business Directory
	                            <ul>
                                    <li>Added voting system to City Hall section.</li>
                                </ul>
                        </li>
                        <li>New Pages
				                <ul>
                                    <li>Parent Letter
						                <ul>
                                            <li>Will be sued to print out a PDF of the parent letter from FMP.</li>
                                        </ul>
                                    </li>
                                    <li>Voting System
						                <ul>
                                            <li>This will be used on the iPad stands in EV for students to case their votes.</li>
                                        </ul>
                                    </li>
                                </ul>
                        </li>
                        <li>Various backend updates.</li>
                    </ul>
                </div>
            </div>

            <%--v2.1.11--%>
            <div>
                <asp:Button ID="v2111_btn" runat="server" CssClass="button3" Text="2.1.11" />
                <br />
                <br />
                <div id="v2111_div" runat="server" visible="false">
                    <span style="font-weight: bold; text-decoration: underline;">v2.1.11 (6/8/2023)</span>
                    <ul>
                        <li>Home Page
                                        <ul>
                                            <li>Removed blank spaces in calendar.</li>
                                        </ul>
                        </li>
                        <li>Changelog
                                        <ul>
                                            <li>Updated changelog for v2.1.10.</li>
                                        </ul>
                        </li>
                        <li>Login Page
                                        <ul>
                                            <li>Textbox is rounded out.</li>
                                        </ul>
                        </li>
                        <li>Manager System
	                                    <ul>
                                            <li>Added questions for non-sales and sales businesses.</li>
                                            <li>Added functionality to Ditek system. </li>
                                            <li>Worked on Duke Energy manager system. </li>
                                        </ul>
                        </li>
                        <li>Business Directory
	                                    <ul>
                                            <li>Added Manager pages for each business.</li>
                                            <li>Added BayCare Admin Assist. to BayCare section.</li>
                                        </ul>
                        </li>
                        <li>Sidebar
	                                    <ul>
                                            <li>Added updated home page link layout to the sidebar.</li>
                                        </ul>
                        </li>
                        <li>New Pages
				                        <ul>
                                            <li>Duplicate Students
						                        <ul>
                                                    <li>Will show any duplicate students on a selected visit date.</li>
                                                </ul>
                                            </li>
                                        </ul>
                        </li>
                        <li>Various backend updates.</li>
                    </ul>
                </div>
            </div>

            <%--v2.1.10--%>
            <div>
                <asp:Button ID="v2110_btn" runat="server" CssClass="button3" Text="2.1.10" />
                <br />
                <br />
                <div id="v2110_div" runat="server" visible="false">
                    <span style="font-weight: bold; text-decoration: underline;">v2.1.10 (6/1/2023)</span>
                    <ul>
                        <li>Business Sales Report
                                <ul>
                                    <li>Textbox is rounded out.</li>
                                </ul>
                        </li>
                        <li>Check Writing System (Payroll)
                                <ul>
                                    <li>Payroll 2 checks will now print out the Direct Deposit slips instead of checks.</li>
                                </ul>
                        </li>
                        <li>Create a Visit
                                <ul>
                                    <li>Textbox is rounded out.</li>
                                </ul>
                        </li>
                        <li>Home Page
	                        <ul>
                                <li>Added a weekly visit calendar. This will show the current week's visiting schools. Will be adding ability to click on the school name to send you to that schools page.</li>
                                <li>Reorganized the links to the pages into drop down menus. </li>
                            </ul>
                        </li>
                        <li>Input Student Information
	                        <ul>
                                <li>Teachers that click the help button will now have their schools name in the subject line.</li>
                            </ul>
                        </li>
                        <li>Magic Computer
	                        <ul>
                                <li>Added direct deposit button.</li>
                            </ul>
                        </li>

                        <li>Teacher Letter
                                <ul>
                                    <li>Added clear for visit date textbox when selecting school name ddl, and vice versa.</li>
                                    <li>Textbox is rounded out.</li>
                                </ul>
                        </li>
                        <li>Teller System
	                        <ul>
                                <li>Added the savings system. Will only appear after the 2nd deposit is enabled.</li>
                            </ul>
                        </li>

                        <li>Visit Report
                                <ul>
                                    <li>Fixed sharing schools.</li>
                                </ul>
                        </li>
                        <li>New Pages
				            <ul>
                                <li>BayCare Admin Assist
						            <ul>
                                        <li>This is the FileMaker job ported over into EV 2.0.</li>
                                    </ul>
                                </li>
                                <li>Changelog
						            <ul>
                                        <li>This page will contain all previous update logs for EV 2.0. The latest updates will be at the bottom of the home page, and the update previous will be accessible on this page.</li>
                                    </ul>
                                </li>
                            </ul>
                        </li>
                        <li>Various backend updates.</li>
                    </ul>
                </div>
            </div>

            <%--v2.1.09--%>
            <div>
                <asp:Button ID="v2109_btn" runat="server" CssClass="button3" Text="2.1.09" />
                <br />
                <br />
                <div id="v2109_div" runat="server" visible="false">
                    <span style="font-weight: bold; text-decoration: underline;">v2.1.09 (5/18/2023)</span>
                    <ul>
                        <li>Hotfix a (5/22/23)
                                <ul>
                                    <li>Badge Printing & Badge Creator
                                        <ul>
                                            <li>Had to rebuild the main site during EV. Would not load photos because the photo path was not correct.</li>
                                        </ul>
                                    </li>
                                </ul>
                        </li>
                        <li>Help Page
                                    <ul>
                                        <li>Reworked the Help Page: Added more photos and a cleaner navigation system.</li>
                                        <li>Updated information on all pages, added new pages.</li>
                                    </ul>
                        </li>
                        <li>Amount Spent Report
                                    <ul>
                                        <li>Cleaned up the page a bit.</li>
                                    </ul>
                        </li>
                        <li>Payroll Check System
                                    <ul>
                                        <li>Fixed a bug where it would crash if the student had saved a check and then was moved to a new business. The system was checking if that student's check was for a student in the business and could not find them.</li>
                                    </ul>
                        </li>
                        <li>New Pages
				            <ul>
                                <li>Staff List
						            <ul>
                                        <li>Used to view and print out the Stavros staff list. Can also add new staff members.</li>
                                    </ul>
                                </li>
                            </ul>
                        </li>
                        <li>Various backend updates.</li>
                    </ul>

                </div>
            </div>

            <%--v2.1.08--%>
            <div>
                <asp:Button ID="v2108_btn" runat="server" CssClass="button3" Text="2.1.08" />
                <br />
                <br />
                <div id="v2108_div" runat="server" visible="false">
                    <span style="font-weight: bold; text-decoration: underline;">v2.1.08 (5/11/2023)</span>
                    <ul>
                        <li>Badge History
                                    <ul>
                                        <li>Fixed a bug where it would not load in the student names in the DDL.</li>
                                        <li>Added code to clear out DDL when loading the page.</li>
                                    </ul>
                        </li>
                        <li>Add / Remove On Hand Inventory (Inventory Only)
                                    <ul>
                                        <li>Fixed a bug where it would not update when an apostrophe is in the notes textbox.</li>
                                    </ul>
                        </li>
                        <li>Employee Management System
                                        <ul>
                                            <li>Added ability to easily change schools based on selected visit date and business. On the page, after you enter in a visit date and business, you'll see another drop down menu with a button that allows you to change the school assigned to the business. I added this because there were some instances where the school wasn't assigned to the correct businesses on this page, but was on the Edit Open / Closed Status page.</li>
                                        </ul>
                        </li>
                        <li>Family and Community Liaison Information
                                        <ul>
                                            <li>Added EV logo to bottom of page when printing.</li>
                                        </ul>
                        </li>
                        <li>New Pages
				                    <ul>
                                        <li>School Notes
						                    <ul>
                                                <li>This is the Data Notes section in the Schools EV 22-23 folder from FileMaker. You can select a school and add in notes for it.</li>
                                            </ul>
                                        </li>
                                        <li>Break Schedules
						                    <ul>
                                                <li>This is where you will print out the break schedules for each business and each school schedule time slot.</li>
                                            </ul>
                                        </li>
                                        <li>Move Articles
						                    <ul>
                                                <li>This page will be used to move the newspaper articles to their new visit date if an exisiting visit date has been changed. For example, if a teacher has submitted their student's articles on 4/10, but later they postpone their visit to 5/10, then you will come to the Move Articles page to move the articles to the correct folder in EV 2.0, so we can access it on their visit date in the newspaper business.</li>
                                            </ul>
                                        </li>
                                    </ul>
                        </li>
                        <li>Various backend updates.</li>
                    </ul>
                </div>
            </div>

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

        <asp:SqlDataSource ID="Review_sds" runat="server"></asp:SqlDataSource>
    </form>
</body>
</html>
