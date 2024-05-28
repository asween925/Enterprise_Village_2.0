ReadMe

Welcome to the manual of EV 2.0! 
This is an all-in-one guide to everything you need to know about EV2.0: what it is, how to use it, and the future of it. EV 2.0 is a new system that we have created so it is still in its infancy, and thus will have some hiccups and quirks when using it, but the beauty of using this system is the fact that we can change it at will. 
This project started out to replace the previous system, FileMaker Pro 18. The system is still currently in use, at time of writing this, but is outdated and not flexible with its use. We decided that a brand-new system we could build from the ground up would be a better way of future-proofing the EV system. A system that we could continually improve and update whenever we need to. In 2021, Jak Dawson, a technology technician here at Stavros, started to create the beginning of the system. Using a combination of HTML, ASP.NET, Visual Basic, CSS, and JavaScript, he was able to make a very basic version of EV 2.0. In early 2022, Austin Sweeney was hired in place of Jak Dawson as Jak got a job at the admin building. From there, Austin and Jak worked together to create an Alpha version of EV 2.0 that had basic functionality with all its pages and systems. After that Alpha version was presented in April 2022, Austin continued to work on EV 2.0 until its official launch in October 2022. From there, we have continued to tweak and improve 2.0 and will continue to do so for the foreseeable future.

What is EV 2.0?

Enterprise Village 2.0, or EV 2.0, is the website / system that we use at the Stavros Institute to run and monitor the activities and database of Enterprise Village. We use EV 2.0 for scheduling visits with schools, entering students into the database, running each students’ jobs, students depositing money into the system, and much more. 
It is a web-based application which means it runs off a web browser like Microsoft Edge. Entering in the link to the website when connected to an approved PCSB network will gain access to the site. The site can be accessed from either tablet or computer, baring that it is approved for use by PCSB. This means that your personal phone or laptop, for example, cannot get access to EV 2.0. This is to prevent hackers or other malicious entities from abusing the site’s security. EV 2.0 can be accessed by anyone regardless of PCSB WiFi connection, this is so our out-of-district schools can enter their students’ information.
The system is used by both PCSB staff and students, with different web pages linking to a specific function within EV 2.0. For example, the Financial Officer of a business in EV will be using the Check Writing System within EV 2.0 to create and print out checks for the other students in the business. Meanwhile, a staff member could be accessing another student’s deposit information from a different computer in EV, using a different web page. EV 2.0 can be used by multiple people all at the same time using our server (A6351SEV).
Originally, it started development back in late 2021 headed up by the previous Technician (Jak) and was taken over by me (Austin) in early 2022 and officially launched on October 2022. It was created as a way to not use a program called FileMaker Pro 18 because the license of the program was going away and the district did not want to pay for it (supposedly). With EV 2.0 being entirely web based and on our own campus, we have total control over what we can do with it and we no longer have to rely on the restrictions of using a third-party application. However, EV 2.0 is very complex and involves programming, which nobody here except for the technology technician knows how to do. Thus, I've tried to take as many notes as I could during my time creating the site for not only myself, but the future technology technician to better understand how the site works.
 
2.0 is used by our staff, visiting students, and PCSB teachers that are scheduled to visit EV. Our staff uses it to create visits, edit those visits, edit student's sales and business profits, edit and add students to a visit date, and much more. Students use it in their assigned businesses for writing the payroll checks, selling an item, buying an item, depositing their checks, and creating badges in TD SYNNEX. PCSB outside teachers use it for entering in their students into our system directly, by logging in when they have a visit date.

First Time Use of EV 2.0

To access EV 2.0, head to this address: https://ev.pcsb.org
This will take you to the main log in page of the site. Enter your PCSB credentials (email and password) to gain access to the site. Feel free to explore the different pages of the site and see how they are structured, but be wary of making any changes within the site before reading about the page itself in this manual.
There is a development site as well:  http://10.106.4.94:1337/default.aspx
The Dev site is for making changes to the site so you can see them without effecting the main site in the middle of Enterprise Village. More information about the dev site can be found in the Editing the Site section of the manual.
First Time Log In
In order to log into EV 2.0, you must have a PCSB email and password set up and finalized. This is what you'll be using to log into the site. However, you must have your PCSB email entered in our EV database through SQL. 
1.	On your computer, launch SQL Server Management Studio. The window below should pop up:
 
2.	Make sure this information is what is on your screen and click 'Connect'. 
3.	Once it connects, you should see a sidebar. Expand the sections so it looks like this:
 
4.	Right-click on dbo.adminInfo and Select 'Edit Top 200 Rows'.
5.	At the bottom of the table, there should be a bunch of cells that are NULL. Enter your first name, last name, PCSB email, location (Stavros), invoice control (True), username (PCSB email without the @pcsb.org) and your job (Technology Technician). Hit Enter.
 
6.	Try logging into EV 2.0 now.

Logging In
EV 2.0 is not only used by GSI (Gus Stavros Institute) staff but also used by other teachers in the district. They log into EV 2.0 to enter their students names into the database when they have a visit scheduled coming up. Our teachers (primarily Barbara) sends out an email with the link to EV 2.0 and instructions on how to enter the names in. This is how it works:
•	EV 2.0 Log In is divided into two sections: GSI Staff and Non-GSI Staff
o	GSI Staff
•	Found in the adminInfo table in the database
•	Includes all staff that work at GSI that would use EV 2.0, with the exception of a few (Security guard, HPO)
•	If a GSI staff member logs into 2.0 using their PCSB email and password AND that email is entered into the adminInfo table, they are able to log into the main home page of EV 2.0 (reports.aspx) and have access to the full site.
o	Non-GSI Teachers
•	Found in the teacherInfo database
•	These are mostly made up of teachers from other schools in the district that come to EV once a year.
•	In order for them to log in, they must have their PCSB email entered into the teacherInfo database.
	The password they use is their PCSB password.
•	When they log in, they get to the Input Student Information (ISI) page which shows them their school name, visit date, and businesses that are open for that day. They can enter their students names into the businesses and submit them when they are finished.
•	More information can be found on this tab and on the Help section of EV 2.0.
Page List

Below is all of the pages currently, as of 12/14/23, that are in EV 2.0.
Home Page

 
https://ev.pcsb.org/Home_Page.aspx
This is the home page for EV 2.0. You will see this when you log in. At the top, it has today’s date, the student count of the visit (obtained from the amount of students entered by the non-GSI teacher), and the name of the school(s) visiting. Below that, are the main buttons which offer direct links to different “hubs” of EV 2.0, with the exception of the Magic Computer button and the Log Out buttons. Under those are drop down menus containing different pages pertaining to the category name of the drop down menu, which we will go over below. Then there is the weekly calendar, which shows all the schools that are arriving on the current week, Monday-Friday. You can click on the school names to go directly to the Student Report for that visit date and school. The current date on the calendar is highlighted in red. Finally at the bottom are the Latest Updates pop up, which contains all the past weeks worth of updates in a pop up window. The Changelog button is a direct link to the Changelog page, which contains a list of all previous updates to 2.0 up to 5/11/2023. The Get Joke pop up is just a fun thing I decided to add to practice coding stuff, it generates a random joke. At the very bottom is the current version number, the current visit ID (which is used by the Tech Tech), and the date last updated.
Business and Checklist Directory

 
https://ev.pcsb.org/directory.aspx https://ev.pcsb.org/Checklist_Directory.aspx 
These two pages contain links to each businesses job, on the Business Directory, and the checklists on the Checklist Directory.
Help Page

 
https://ev.pcsb.org/Help_page.aspx
This is the help page of EV 2.0. Click on this button to view all the pages of EV 2.0 and what they do, along with a photo. (To the tech tech: try to keep this updated with current photos and functions of each page. If you add a new page (that’s viewable by the staff), make sure you add it here.
Magic Computer

 
https://ev.pcsb.org/magic_computer.aspx
This is the Magic Computer. It is used daily by the teachers and teacher assistants during the village visits. It is responsible for quick updates to student accounts, initiating the direct deposit, enabling deposit 3, and viewing student’s purchases and deposits. To get started, enter a student’s account number OR select their name from the drop down list. The student’s information will load, like their current balance, their savings, their deposits, and how much they’ve spent at the businesses in EV. To change a students deposit or cash, type in a dollar amount from 6.00, 6.50, or 7.00 and click Update for the row.
In the village, the students’ second deposit is done via direct deposit, which is initiated on the Magic Computer. When ready, click the green Initiate Direct Deposit (Deposit #2) button towards the top of the page to automatically deposit their paychecks into the students’ accounts. Each direct deposit is correlated with how much they deposited from their first check, so the system will automatically know how much to deposit, without user input. You can double check if this was a success by loading a students info and checking the Deposit 2 dollar amount textbox. If this is pressed accidentally, it can be disabled by clicking on the button again (BE AWARE: if this button is activated too soon and the students have already spent their second check, they will have a negative balance on their account, which will need to be corrected on the Magic Computer.)
The Enable Deposit #3 button is a safety measure so that the students do not accidentally make all of their deposits at once. When ready, click the Enable Deposit #3 button to allow the Bank Tellers to deposit the students checks. If this button is not clicked, the Teller will receive a message saying that it is not time to deposit the 3rd checks. If this is pressed accidentally, it can be disabled by clicking on the button again.
Create
Create a Visit

 
https://ev.pcsb.org/Database.aspx
This page is used to create a visit date for Enterprise Village. Used primarily by the GSI teachers. The two buttons at the top are direct links to the Edit Open / Closed Status and School Visit Checklist pages. The only fields required are the visit date and at least 1 school. Changing the visit time will also change the volunteer training time to match the schedule (see the School Schedule page). In the school drop downs, you’ll see a school at the top called ‘A1 No School Scheduled’. This is for testing purposes if the tech tech needs to have a visit date created. It is also used as a placeholder is a school cancels or otherwise needs to be removed from the visit date.
Create a School

 
https://ev.pcsb.org/Create_School.aspx
This page is for creating a new school in EV 2.0. It would be rare for you to use this page as most schools in the state / district are already in our database. However, you can use this page to add a new school to our system.

Create a Teacher

 
https://ev.pcsb.org/teacher_input.aspx
This page will let you add a teacher to the database. Last name, school name, and email are the required fields. Make sure the teacher email field is the correct email they use to communicate with GSI teachers, otherwise, they may have difficulty logging in. The contact teacher checkbox is to determine if they will be receiving the EV media sent by the tech tech at the end of their visit and is also the primary contact for the GSI teachers.
Edit
Edit Visit

 
https://ev.pcsb.org/Edit_Visit.aspx
This page allows you to edit currently existing visit dates. The Upload / Move Articles button is a direct link to that page. Select the visit date you want to edit, and a table will appear underneath the date selected. Click on the 'Edit' button on the left side of the table to go into 'Edit Mode' and will highlight the row yellow. Now you can make changes to any field on the row. Make sure you click 'Edit' before making any changes otherwise it will not save and you'll have to start over again. Click 'Update' to finish editing that row and a warning message will appear to make sure to move any newspaper articles over to the new visit date (by clicking on the Upload / Move Articles button) if you changed the visit date and if there are any articles uploaded. If you edit the visit date of the current date (if there is one created) then it will be changed to the edited visit date and will not appear for the selected day. Do not edit the same date as the current date. The businesses closed will be reflected in the Town Hall PowerPoint for that date. Closed businesses will not show up for the non-GSI teachers when they log into EV 2.0 and enter their students.
Edit School

 
https://ev.pcsb.org/edit_school.aspx
This page allows you to edit information for schools in EV 2.0. You can view a single school by selecting one from the DDL or you can search for a keyword. The keyword works for school names, admin names, emails, counties, etc. The ‘Show All Schools’ button will reset your search to view all the schools in a table like the photo above. Click on the Edit button the left side of the table to go into ‘Edit Mode’ and it will highlight edited row yellow. Click Update when you made the changes.
Edit Teachers

 
https://ev.pcsb.org/Edit_Teacher.aspx
This page lets you edit information of currently existing teachers. You can select the school of the teacher you want to edit or search for a keyword. Keywords include their first or last names, schools, or emails. Click on the Edit button the left side of the table to go into ‘Edit Mode’ and it will highlight edited row yellow. Click Update when you made the changes. If you want to remove a teacher from the school, click on the Delete button. This action cannot be undone.
Remember: here is where you can find the emails and passwords for the teachers to be able to log in to EV 2.0 and enter their students. If they are NOT PCSB teachers, they will need a password. The password criteria is the county name + school name.
Edit Open / Closed Status

 
https://ev.pcsb.org/Open_Closed_Status.aspx
This page is used to open or close businesses for a selected visit date. Select the visit date you want to edit, and a table will appear underneath the date selected. Click on the Edit button the left side of the table to go into ‘Edit Mode’ and it will highlight edited row yellow. Click Update when you made the changes. Select either Open or Closed from the Open Status drop down menu to open or close the business. The 'School Assigned' column shows schools that are scheduled to come in on that visit date. Go to 'Edit Visit' if the school you need is not on that list to double check if they are scheduled for that date. The businesses closed will be reflected in the Town Hall PowerPoint for that date. Closed businesses will not show up for the non-GSI teachers when they log into EV 2.0 and enter their students. The volunteer minimum and maximum count are entered by the teachers.
Employee Management System (EMS)

 
https://ev.pcsb.org/employee_management_system_review.aspx
This page allows you to edit students from a selected business on a selected visit date. Select an existing visit date from the visit date box, and then select a business from the drop down list below that. A table will appear under that menu. Here you can change the student's business, account number, first and last name, job, and what school they belong to. Click on the Edit button the left side of the table to go into ‘Edit Mode’ and it will highlight edited row yellow. Click Update when you made the changes. Be aware that if you change the student's business, they will move to that business, and you'll have to select that business from the drop down list to find them. Also be aware that you can set a duplicate account number. Check the 'Duplicate Number Report' under the 'Reports' menu on the side bar to see which numbers are duplicate. The businesses that appear from the Select Business drop down menu are the ones that are set to open. Go to 'Edit Open / Closed Status' to close any business unwanted for that visit date. You can also change the school assigned to business by selecting a school from the drop down menu next to the Change School button, and clicking that button. It will change all the students schools in the selected business to the school you selected from that drop down menu.
Edit Profits

 
https://ev.pcsb.org/business_profit_updates.aspx
This page will let you edit the profits of each business on the current date. Click on the Edit button the left side of the table to go into ‘Edit Mode’ and it will highlight edited row yellow. Click Update when you made the changes. Each business will update automatically from when the financial officer enters their loan amount and deposits in the Online Banking page in their business. The table on the right contains the information about the starting amounts for the businesses. The Misc. Deposit field will add any amount entered to the Profits.
Edit Sales

 
https://ev.pcsb.org/Edit_sales.aspx
This page will let you directly edit the sales of a selected student in EV. Enter in the visit date and select a student’s name to load data from. Their account number is to the left of their name in the student DDL. Click on the Edit button the left side of the table to go into ‘Edit Mode’ and it will highlight edited row yellow. Click Update when you made the changes.
Edit Business

 
https://ev.pcsb.org/Edit_Business.aspx
This page allows you to edit the information of a business. Click on the Edit button the left side of the table to go into ‘Edit Mode’ and it will highlight edited row yellow. Click Update when you made the changes. You can change the jobs for the business here by selecting the job from the drop down menu and changing it. The starting balance for the jobs is also located here.

Tools
Town Hall PowerPoint

 
https://ev.pcsb.org/Profit_display.aspx
This page will be used instead of the traditional PowerPoint slideshow that's from the shared folder. The businesses that are OPEN will cycle through like a normal PowerPoint. You will move the browser window to the screen displaying the PowerPoint (usually to the left or right of the screen, like you are using two monitors), and press F11 on the keyboard to go full screen.
School Visit Checklist

 
https://ev.pcsb.org/School_Visit_Checklist.aspx
This page is for the teachers, bookkeeper, TA's, and front office staff to enter in additional information about the visit. It is currently not used as of 5/1/23.
Each section of this page is blocked off unless the person before has filled out their information. For example, the front office staff (step 3) cannot enter their information unless the bookkeeper (step 2) has filled out their information first. The steps must go in order.
•	This page is unique in that it has an order of people who are allowed to enter in information. It is broken up into steps:
•	Step 1: Teachers Use Only
o	Once you have created a visit date, click the link at the top of the Create a Visit page that says School Visit Checklist. You will arrive at this page.
o	You'll see a drop down menu that has all of the schools in the database and a print button. Select the school you just created.
o	You'll see a few things pop up but only teachers will worry about Step 1. The Teacher's Only section contains information about the school and visit date, a drop down menu that has the type of school it is, and a Submit button. 
o	Teachers will select the type of school it is and click Submit. The button will open your email application (Outlook) with an email pre-filled out and addressed to the bookkeeper. Click send. The teachers are done with this page.
•	Step 2: Bookkeeper Only
o	After the teacher sends the email to the bookkeeper, the bookkeeper will now need to check two boxes in order for the next step to be unlocked for the Front Office staff.
o	Clicking 'Submit' will open the default email application (Outlook) with an email pre-filled out and addressed to the front office staff. Click send. The bookkeeper is now done with this page.
•	Step 3: Front Office Only (Part 1 of 2)
o	Once the Front Office staff receives an email from the bookkeeper, they are now able to fill out the information in their section.
o	Enter the contract received date, the invoice number, the delivery method, and any additional notes you may need to add.
o	Clicking 'Submit' will open the default email application (Outlook) with an email pre-filled out and addressed to the TA staff. Click send. The front office staff must return to this page after an email has been received from the TA's.
•	Step 4: TA's Only
o	Once the TA staff receives an email from the front office staff, they are now able to fill out the information in their section.
o	Click the drop down menu to select the total amount of kits being sent out for that school's visit, and enter the kit numbers on the line below. Use commas to separate them (ex: 124, 278, etc.).
o	After filling that information out, click 'Print Ticket'. This will print out a ticket with the information filled out up above.
o	Clicking 'Submit' will open the default email application (Outlook) with an email pre-filled out and addressed to the front office staff. Click send. The TA's are done with this page.
•	Step 5: Front Office Only (Part 2 of 2)
o	Once the Front Office staff receives an email from the TA's, they are now able to fill out the information in the final section.
o	Enter the delivery accepted by date, and the date accepted.
o	Clicking 'Submit' will open the default email application (Outlook) with an email pre-filled out and addressed to the bookkeeper. Click send. The front office is now done with this page.
Kit Inventory

  
https://ev.pcsb.org/Kit_Inventory.aspx
The page is used to log and enter in new kits. It has two sections: the Data Entry screen and the Inventory List. Click on the buttons at the top to see the section. Used primarily by the Teacher Assistants. On the Inventory List, click on the Edit button the left side of the table to go into ‘Edit Mode’ and it will highlight edited row yellow. Click Update when you made the changes.
Upload / Move Articles

 
 
https://ev.pcsb.org/Upload_Move_Articles.aspx
This page is used by the staff to upload any articles that are sent over from the teacher via email and if they haven’t uploaded the articles themselves. It is also used to move already uploaded articles to a new visit date. It has 2 sections and you can click the Upload Articles button or the Move Articles button to access those sections. To upload an article, press the Upload Articles button, enter a visit date, select a school scheduled for that visit date, and click the Choose File button to open the File Explorer so you can select a word document to upload. The File must be a word Doc. Click Submit when finished. To Move Articles, click on the Move Articles button and enter in the original visit date of the date you need to move the articles from, then select the school name, and enter the new visit date. In order for this to work, there must be 1) a visit date created for the original visit date, 2) articles uploaded by a teacher for that visit date, and 3) a new visit date either created or that school assigned to a new existing visit date.
School Notes

 
https://ev.pcsb.org/School_Notes.aspx
This page is used for creating new notes for each school. This was a carry over from the FileMaker Pro database and is used by TAs. Select a school from the drop down menu and the school’s information and notes will appear. Click on the Edit button the left side of the table to go into ‘Edit Mode’ and it will highlight edited row yellow. Click Update when you made the changes. You can also delete a note by clicking the delete button.
Schedule Request Form Checklist

 
https://ev.pcsb.org/Schedule_request_form_checklist.aspx
This page is used by the teachers to mark off which schools have returned their Schedule Request Form. Click on the Edit button the left side of the table to go into ‘Edit Mode’ and it will highlight edited row yellow. Click Update when you made the changes. Click on the checkbox to mark off the school. There’s a Clear All Checkboxes button that will be used at the end / beginning of the school year in order to clear out all the checkboxes.
Volunteer Database (WiP)

 
https://ev.pcsb.org/volunteer_database.aspx
This is the volunteer database that will be used in place of FileMaker at some point. It is currently not used but will be used by Karen (or the new volunteer coordinator for Stavros).
Requested Features and Bug Reports

 
https://ev.pcsb.org/Requested_Features.aspx
This page allows users to submit a bug or request a new feature or addition to EV 2.0. This page is fully functional but is not currently used (due to the staff not wanting to learn it and use it correctly). Create a new post by clicking the Create New Post button to view the fields to enter. Select either an issue or requested feature, enter the issue in the note field, type in the page name, and the urgency level. Click Submit when finished. To edit or view your post, click on the View Posts button. 
Reports
Business Sales Report

 
https://ev.pcsb.org/Business_sales_report.aspx
This page will let you see the total sales and transactions of each business for the current visit date. Select a business from the drop down menu to see the transactions and total sales of the business. You can print out the table by selecting a business and clicking 'Print'.
Student Spending Report

 
https://ev.pcsb.org/Student_Spending_Report.aspx
This page is for sending the student report to teachers for a selected visit date. Select a visit date and school name FROM that visit date to see all students assigned to that date and school. You can view their balance, deposit information, cash withdrawn, savings, and how much they spent at each business. This page is meant to be downloaded as a PDF. Click the 'Print' button and select 'Save to PDF' under the Printers section on the Print window. You will get to save a name for it. This PDF is then supposed to be emailed to the teacher of the school that requested it. Keep in mind: When you select a school from the drop down menu, it only displays the students from that school. Remember to download a PDF for EACH SCHOOL that day. Select a school, click the 'Save to PDF' button, select Save as PDF under printer when the print window appears, click Save, and do it again with the other school(s).
Amount Spent Report

 
https://ev.pcsb.org/Amount_spend_report.aspx
This page allows you to view students that have spent their funds. You can see their account number, name, total deposits, total purchases, balance. You can print out a copy by clicking 'Print'.
Negative Balance Report

 
https://ev.pcsb.org/Negative_balance_report.aspx
This page will show you students that have a negative balance. You can adjust their balance by going to the Magic Computer for the account number displayed. 
Note: this only displays students that have a negative balance due to a transaction. Transactions are controlled in a way so the student cannot buy an item with less money in their account than the item is worth. This page is only here as a precaution.
Profit Report

 
https://ev.pcsb.org/Business_profit_report.aspx
This page lets you view the profits for the current visit date. You can print out a copy by clicking 'Print'. To edit a profit, go to 'Edit Profits' under the Tools tab.
Duplicate Numbers Report

 
https://ev.pcsb.org/Duplicate_numbers_report.aspx
This page will let you see students in the current visit date that have duplicated account numbers. The number that is duplicated will appear in a table.
Duplicate Student Report

 
https://ev.pcsb.org/Duplicate_Students.aspx
This page allows you to view potential duplicate student names in the system for a selected visit date. If so, it will show at least two names along with their account number. There’s a link to the Employee Management System if you need to change anything.
Student Report

 
https://ev.pcsb.org/Employee_Report.aspx
This page lets you view the students in the database under a selected visit date. Enter a visit date, and a drop down menu and table will appear with the students scheduled to arrive that day. If there is more than one school scheduled to arrive that day, you can select the students to view only from that school by selecting it from the drop down menu. The 'Show Empty Names' button will show all the account numbers from the day, even when there is no student name entered for that id. You can print out a copy by clicking 'Print'.
School Report

 
https://ev.pcsb.org/School_Report.aspx
This page displays all the schools currently in the database. Select a school from the drop down menu to see only that school. Type in a keyword and click 'Search' to see rows with that keyword. The 'Show All Schools' button will show all schools if you entered a keyword or selected a school. Use the page numbers to navigate the table.
Visit Report

 
https://ev.pcsb.org/Visit_Report.aspx
This page lets you view all scheduled visit dates in the database. Click the page numbers to cycle through older dates.
Teacher Report

 
https://ev.pcsb.org/Teacher_Report.aspx
The page displays teachers associated with a selected school. Select a school from the drop down menu to see the teachers of that school.
Forms and Letters
Family & Community Liaison Information

 
https://ev.pcsb.org/Liason_Information.aspx
This page fills out a form for the family and community liaison information which is used by Karen (or the volunteer coordinator). Enter the visit date and school name and click Print when the letter fills out.
Teacher Letter

 
https://ev.pcsb.org/Teacher_Letter.aspx
This page prints out a letter that is sent to the teachers. It contains information about their visit, including closed businesses, volunteers needed, and other reminders. Click Save as PDF to bring up the print window, then under the printer name, select Save as PDF and click Save to save the letter as a PDF (which can then be sent to the teacher via email.)
Parent Letter

 
https://ev.pcsb.org/Parent_Letter.aspx
This page allows you to save the parent letter of a selected school. Select a visit date to load the letter and click Save as PDF to bring up the print window. From there, select Save as a PDF under printer name to save it as a PDF. From there you can save it where you want and email it to the parents.
EV Daily Forms

 
https://ev.pcsb.org/EV_Daily_Forms.aspx
This is the page where the staff will print out a daily form. It displays a slightly different layout when the school is either a public or out of county school. Select a visit date and school from that date to load in data.
EV Lunch Forms

 
https://ev.pcsb.org/EV_Lunch_Forms.aspx
This page is used by the Front Office when printing out the lunch daily receipt and the monthly letter that is sent to McDonald’s. The user selects either the Daily Receipt or Letter button from the top. For the daily receipt, a visit date textbox appears below, and when a date is entered, the ticket appears. From here, the user will enter in the total amount of burgers and nuggets, along with a comment, needed for the day. The pick up time on the right side of the ticket is determined by the visit time, it is generally around 2-3 hours after the students arrive. The user then prints the ticket using the button above.
The letter is displayed by clicking the Letter button at the top of the page. A visit date textbox will also appear, as well as 2 drop down menus indicating a month and a year. This is to display all the visits for the selected month and year. After selecting them, the letter will appear with a table where the user can enter the amount of burgers and nuggets needed for the day. It can be printed out from the button above.
Staff List

 
https://ev.pcsb.org/Staff_List.aspx
This page contains a list of all current staff members at the Stavros Institute. You can also add a new member by clicking the Add New Member button at the top and filling in the fields that appear.
Break Schedules

 
https://ev.pcsb.org/Break_Schedules.aspx
This page is used to print out the break schedules for each business of a selected school schedule time. Select the business name and the time slot via the drop down menu to reveal the schedule. Click the Print on Legal Paper button to bring up the print window. Make sure you select the Legal option under More Settings > Paper Size in the print window before printing in order for it to come out correctly.
Bus Transportation

 
https://ev.pcsb.org/Bus_Transportation.aspx
This page is used to print out the bus transportation letter by the front office. Enter in a visit date and the letter will appear. Enter in the total mileage one way and the total time one way and click calculate to get the remaining values for the barn to barn and estimated total for 1-3 buses. Click Print to bring up the print window.
School Schedule

 
https://ev.pcsb.org/school_schedule.aspx
This page allows you to view and/or print the school schedule for EV. Changes to the schedule at this time must be made through the SQL database by the technology technician.
Closed Business Checks

 
https://ev.pcsb.org/closed_business_checks.aspx
This page is used to print out the payroll and operating checks for businesses that are closed in EV. Select a business name from the drop down menu and the payroll group 1 checks will reveal. You can switch the check type to Operating or Payroll via the check type drop down menu at the top. Click the Group buttons to change the group of the checks to payroll groups 1-3 or to cycle through all the operating checks for the selected business. Click the Show Ditek Checks button to reveal the Ditek checks for the selected business. Click print to bring up the print window. For the payroll checks, you can type in the textboxes of the checks for the name, dollar amount, and written amount fields before printing.
Visit Calendar

 
https://ev.pcsb.org/visit_calendar.aspx
Here you can quickly view all of the scheduled visits for a selected month. (As of 12/21/2023, the school names cannot be clicked but eventually I will add that function.)
Inventory

The EV 2.0 Inventory System is used primarily by the bus drivers and bookkeeper to organize, log, and track the items that are for sale in the businesses in EV. It was previously used in FileMaker but was migrated over into EV 2.0, which started in December ’22 and was launched in August ’23.
Inventory – Home Page

 
This is the home page for the inventory system in EV 2.0. From here, you’ll be able to access the Create an Item, Edit Item, and View Item pages from the buttons. It also shows the current date, student count, and school(s) of the day. If a bus driver logs in, they will see this screen. If a bookkeeper or tech tech logs in, they will get to the typical EV 2.0 home page but with an added link to go to the inventory system.
Inventory – Create an Item

 
This is where you’ll be able to create an item to add to the inventory system. Enter the currently known information of the item including the category, sub-category (if needed), the business tied to the item, current location, current location in EV (if applicable), amount on hand, the source, the merch code, and any additional comments or notes about the item. Press Submit at the bottom of the page to enter the item into the database.
Inventory – Edit Item

 
This is where you can edit or delete any items already entered into the database. This works in the same vein as the other edit pages in EV 2.0. Click the Edit button on the left side of the table to edit a item, and click Update when you are finished. The editable item will be highlighted in yellow. Before deleting an item, a pop up will appear and ask you again if you want to delete that item.
Inventory – View Item

 
This is where you can view more details of an item in the inventory system. Select an item from the drop down menu at the top of the screen and the details of the item will populate below. It will show the merch code, amount on hand, category and sub-category, and more.
It will also show the item’s timestamp. This is a way to log the amount on hand of the selected item that have been added or removed from the inventory system and will tell the viewer who added or removed the amount on hand of the selected item, when they did it, what item it was, and how much of it they removed. To add or remove an amount on hand, select an item from the drop down menu, enter a date in, the amount you want to add or remove (to remove an amount, make sure the number is negative and not positive), and add a note to the edit if you need to. Press Enter when you have filled out the data.
Inventory - Low Inventory Report

 
The Low Inventory Report shows items in the inventory that have a Total Amount On Hand amount of less than 100. 
Inventory – View All Items

 
This page is used to view all the items in the inventory in a easier format. You can search for specific items using the search bar, or sort all the items by columns by ascending or descending. 
Other Pages
Teacher Home

 
https://ev.pcsb.org/teacher_home.aspx
This page is a hub page used by non-GSI teachers when they log in. It allows them to navigate to the Input Student Information page (discussed in the next section) and to upload their newspaper articles. To upload articles, click on the Choose File button and select the Word document to upload (it must be a Word doc). Click OK and then click the Upload button. They will get a success message if everything goes well. For techs: you can see if they successfully uploaded their docs by going to this folder: X:\inetpub\wwwroot\EV\uploads\Articles and finding the folder with the school’s visit date. If you cannot find the school’s visit date, or the school name in that folder, then they have not uploaded their articles. You can manually put them in there if you follow the same folder name and hierarchy structure that’s set up with the other folders. You can also go to the Upload / Move Articles page and upload them there. Teachers can also click the ‘here’ link below to ask a question that will go to sweeneya@pcsb.org (future techs will need to change the behind code to reflect their PCSB email).
Input Student Information (PCSB-Teachers Only)

 

This page will only be viewed by non-GSI teachers. This page allows non-GSI teachers to enter in their student's names into our database for their scheduled visit date. For them to access this page, they need to be sent an email containing a link: https://ev.pcsb.org
•	At this page, they enter in their email used to contact us and a password:
  ○ If the teacher is PCSB, they can use their normal credentials to log in.
  ○ If the teacher is non-PCSB, they must use the assigned password given to them in that same email containing the link. This password can be assigned to them on the 'Edit Teacher' page.
  ○ The criteria for this password is county name + school name.
Only opened businesses assigned to the associated school of the teacher will appear. When they log in, they should see their school name and scheduled visit date under the directions. The teachers will then select the business they want to edit from the drop down menu. When they click on the 'Edit' button on the left side of the table to go into 'Edit Mode'. Now they can make changes to any field on the row. Make it clear to them that they need to click 'Edit' before making any changes otherwise it will not save and you'll have to start over again. When they finish editing the name, click 'Update'. They will repeat this until they finish adding all of their student's in. When they finish adding all student's in, they will click 'Submit'. This will direct them to a confirmation page, double checking if they are finished adding students in. When they click 'Confirm', they will be redirected back to the log in screen. They can get a print out of this page by clicking 'Print'. They can click the link at the bottom of the page to open an email so they can ask a question.
They can also come back and make changes at a later date. They can log back in and follow the normal procedures (click Edit, click Update, click Submit, print out if they need).
•	However, they can only make changes up until a certain date, the Reply By date, which is assigned by the GSI Teachers
•	You can change this Reply By date by going to 'Edit Visit'.
BE AWARE! If they pass this Reply By date, they cannot make any more changes and will have to contact us if they need to make a change.

Student Pages

The pages following are exclusively used by the students in Enterprise Village. The Check Writing System pages and the Online Banking page are used by the Financial Officer, the Sales System is used by the Salesman/woman, the ATM page is used by all students, and the Badge pages are used by the Badge Creator in TD SYNNEX only. The Manager System is currently in development as of 4/3/2023.

Payroll Check Writing System

 


Flow:
1.	When the page loads, the FO will click the yellow Ditek check button.
2.	After printing and signing the Ditek check, the FO will then select Payroll 1 from the drop down menu at the top. They will not be able to click on anything until that is selected.
3.	After selecting the payroll group, the name and dollar amount drop down menus on the check will unlock.
4.	The FO will select the student name from the drop down list and their payment. The written amount field and the memo will automatically fill out.
5.	The FO will click 'Save Check' when they have filled out the information. If they try to save a blank check, it will give them an error message and will not save the check.
6.	The FO will repeat that step until they have a check saved for each person.
7.	When they have saved a check for each person, the 'Save Check' button will be disabled, and a message will appear telling them that they are ready to review the checks before printing them.
8.	The FO will click 'Review' and will be able to view and cycle through the saved checks before printing using the arrow buttons. If they made a mistake on one, they will have to delete the check, by clicking Delete, and click 'Add Check'.
9.	When they have finished reviewing the checks, they will select a print group from the drop down menu above the Print button.
10.	Select a group to print, and click Print. The print window will pop up and they will click print. After they print, if needed, they will select another print group from the drop down menu.
11.	They will now repeat this process for payroll group 2 and 3. When they have finished for each one, they will move on to the operating checks.
Layout:
The Yellow buttons at the top of the page will redirect to the operating checks and online banking pages. The drop down menu below the yellow buttons is used to select a payroll group. This is where the financial officer will select the student they want to make a check for. This where the FO will select the dollar amount for the selected student. The written amount will appear automatically after selecting the dollar amount. The memo will fill out automatically when the payroll group is selected. The save check button is used to save a check in the database. This drop down menu is used to select the print group. Each print group contains 4 saved checks, and the FO will have to select each group in order to print all the saved checks out. The Review button is used to cycle through the saved checks so the FO can view them, delete them if a mistake was made, and to print them out. Once clicked, the button will turn into the print button, which is how the FO will print out the checks. The arrow buttons are used to cycle through the saved checks and view them before printing. The delete button will delete the currently viewed check after the FO clicks Review. The Help button displays a help window that guides the FO through the system. The side bar has a check list of things the FO needs to do in order to progress through their job. Clicking on them will let them know when they have completed a task.
Business Operating Check Writing System

 
Layout
The Yellow buttons at the top of the page will redirect to the payroll checks and online banking pages. The drop down menu below the yellow buttons is used to select an operating group. This is where the financial officer will type in the name of the business. This where the FO will type in the dollar amount for the business. The written amount will need to be typed in by the FO after entering a dollar amount and business name. The memo will need to typed in by the FO. The save check button is used to save a check in the database. The Review button is used to cycle through the saved checks so the FO can view them, delete them if a mistake was made, and to print them out. Once clicked, the button will turn into the print button, which is how the FO will print out the checks. The arrow buttons are used to cycle through the saved checks and view them before printing. The delete button will delete the currently viewed check after the FO clicks Review. The Help button displays a help window that guides the FO through the system. The side bar has a check list of things the FO needs to do in order to progress through their job. Clicking on them will let them know when they have completed a task.
Flow
1.	When the FO clicks on the Business Operating Checks button on the payroll checks page, they will first need to select operating group 1.
2.	When selected, the fields on the check will be enabled, allowing them to enter a business name, dollar amount, the written amount, and the memo.
3.	The information they need to fill out is found on the side bar to the right of the check.
4.	Once all fields are filled out (if all fields are not filled out, the check will not save), they will click save check. The FO will then save a check 3 more times to each business in operating group 1.
5.	When 4 checks have been saved, one for each business under group 1, a message will appear saying they have all 4 checks in a group saved and must click the Review button to continue. The Save Check button will be disabled.
6.	The FO will click 'Review' and will be able to view and cycle through the saved checks before printing using the arrow buttons. If they made a mistake on one, they will have to delete the check, by clicking Delete, and click 'Add Check'.
7.	Once they are done reviewing the checks, they will click print. The print window will pop up and they will have to click the print button on that window.
8.	Once printed, they will sign their checks, and repeat this process for the group 2 checks and group 3 checks.
Online Banking

 
This is the Online Banking page that the Financial Officer will use. The Yellow buttons at the top of the page will redirect to the payroll checks and operating check pages. The Summary section details the total deposits for the business, the loan amount, and the current profit. The FO will enter in the loan amount in the Updates section in the row titled 'Loan Amount' and by clicking 'Update'. They will do the same when the deposits 1, 2, and 3 are confirmed. The Misc Deposit (also called Deposit 4) will be available to view towards the end of the day once all three deposits are in and they have a negative or low profit.
Sales System

 
This is the sales system that the sales associates / managers will use. The customer will swipe their card or have their account number be entered by the salesman. The customer's account information will appear below the Enter Account button. The sales associate / manager will enter the item price below the Purchases section for each item the customer is buying. When entering an item price, the total will appear below item 4. It will update automatically. They will click Enter Sale when they have finished. The print window will appear two times, in order to print two copies from the POS printer. The Cancel Sale button clears out all information and refreshes the page. The sales history will show a table of each persons transaction history for the associated business. The Help button will display a help window.
Manager Inventory System (Work in Progress)

 
The Manager Inventory System is for the managers of each business to print out and calculate the total amount of items that have been sold at the end of the day. The Quantity column is determined by the # Used Daily column in the Edit Item page in the EV 2.0 Inventory System, which is entered in daily by the EV bus drivers. The student clicks the green Print button to print out the sheet.
ATM

  
The ATM page will let students find out their deposit information, total amount of deposits, total purchases, savings amount, current balance, and transaction history. The student can swipe their debit card or tap the Open Keyboard button on the main page to open a small keypad on screen they can use to enter in their account number.
Badge Creator

 
Layout:
•	The text box under 'Enter Account Number' is where the student will enter the account number of the person getting their photo taken.
•	The side bar to the left has instructions for the student on how to operate the page. The total number of badges created for that day will also appear here, in yellow text.
•	The account information of the student will appear after they enter an account number in the badge below the 'Enter' button, and a photo of the student will appear when they take a picture and click Upload Picture.
•	The camera section is to the right side. The live feed of the camera will appear on top, above the Take Picture button. The taken photo will appear under that, but above the button Upload Picture.
•	The button at the top labeled 'Badge Print' will go to the Badge Print page, where the badges will be printed. The 'Badge History' button will go to the Badge History page, where you can see all created badges and/or delete them.
Flow:
1.	When the page loads, if there is 0 badges saved, an error message above the badge will say, 'No Badges Created.'
2.	The TD SYNNEX employee will type in the customer's account number. The badge will populate the information of that customer and disable the textbox. The Enter button will be replaced by a New Badge button, which resets the page.
3.	Then, they will ask them to stand in the designated spot to take a picture. When the customer is ready, they will click 'Take Picture.'
4.	The picture taken will appear under the live feed of the camera. When the customer views it and is happy with it, the badge creator clicks the Upload Picture button. If they decide they want a different picture AFTER the badge creator clicks Upload, they will have to delete that badge from the Badge History page and start over.
5.	The uploaded picture now goes into the badge and is saved in the database. The badge creator then enters another account number and repeats the steps until 4 badges have been saved.
6.	When 4 badges have been saved, the student will click on the Badge Printing button at the top.
Some notes of functionality:
•	The upload picture button will download the photo to a folder on the network, which the database will then use to apply the picture to the badge.
•	The browser on that computer must be set to download images to this specific folder, which you can do by:
  □ Open the web browser (Microsoft Edge)
  □ Clicking the 3 dots in the top right corner
  □ Clicking on Settings
  □ Clicking on Downloads
  □ Find the section that says Location, and click Change
  □ Navigate to this folder: X:\inetpub\wwwroot\EV\media\Badge Photos
  □ Click Select Folder
•	When the picture is taken with the Take Picture button, the image is downloaded to that folder. When the Upload Picture button is clicked, the system will find that file name in that folder, and rename it to something more unique to reflect the photo taken of that specific person, using the information from their account number. This new name is used to find the badge photo when it prints.
Badge History

 
The 2 buttons at the top of the page navigate to the other pages in the Badge Creator System. Use the page numbers at the bottom of the table to go through the saved pages. These are listed in order of most recently saved. Click the 'Delete' button in the row of the badge you wish to delete to delete that badge from the system.
Badge Printing

 
Layout:
•	The 2 buttons at the top of the page navigate to the other pages in the Badge Creator System.
•	All saved badges appear in the drop down menu. The account number and name of the student is used here.
•	When you select a student, the badge data will appear in the first badge on the left.
•	Selecting another student will load badge data into the next badge.
•	The 'Print' button will cause a password box to appear. The password to print is 'gsi123'. After that the regular print window will appear and you can print out the 4 badges.
•	The 'Clear' button will clear out the 4 badges. They DO NOT get deleted from the database.
Flow:
1.	In the Badge Print page, the student will click on the students names from the drop down menu. These will load the students into the badges on the screen. The students loaded will be removed from the drop down menu.
2.	After 4 have been loaded, a message will appear asking them to get a teacher to print it out. The drop down menu will also be disabled until they click the 'Clear' button.
3.	When a staff member or volunteer clicks 'Print', they will be prompted for a password. The password is 'gsi123'. After entering the password, the print window will appear.
4.	After printing, a message will appear asking the student to clear out the badges by clicking 'Clear'. They can then print more badges.

Editing and Updating EV 2.0

Below are instructions and information on how to update and edit EV 2.0. It is a website by nature so we need a program to run HTML, ASP.NET, and VB.NET code, so we use the Visual Studio program. Launch it from the desktop to begin.
Visual Studio

Visual Studio is where I do all the coding for EV 2.0. It uses a combination of HTML, ASP.NET, VB.NET, CSS, Javascript, JQuery and SQL. I think VS is a pretty beginner friendly program to use when you are new to coding (which I was, at least in a professional level). You may already know how to use it, but below are some tips and things to understand VS.
•	Building the site:
o	In order for backend VB.NET (any page name ending with ".aspx.vb") changes to be reflected on the site, you must rebuild the site by pressing Ctrl+B.
o	The HTML / ASP.NET / CSS side of the site (ending with ".aspx" or ".css" can be saved without rebuilding the site by Ctrl+S.
o	All changes on the site must be reflected by a refresh. Click in the URL field and hit enter to get a full refresh of the page.
•	Designer files
o	Pages ending with .aspx.designer.vb I do not touch. These are updated automatically and if there's an issue with them, I would email Stephen Whitton (whittonst@pcsb.org) about it.
•	Creating a new page
o	If you want to or need to create a new page, I will copy an existing template page from either the Template Staff or Template Student pages.
o	Right-click a page, select copy, scroll up to the project name (Enterprise Village Dev), right-click and select 'Paste'. The new copied page name will have the same name as the page you copied, but with a "- Copy" at the end.
o	Be sure to rename the page by right-clicking and selecting 'Rename'. You also need to update the VB side and aspx side of the page with the new name.
•	Open the ASPX file of the new page you made.
•	On line 1, at the very top of the page, it has an address to the CodeBehind and Inherits. Change both of those addresses to the new name of the page.
•	Open the VB file of the new page.
•	Change the class name to the name of the website and press Ctrl + B to rebuild the site.

Editing / Updating EV 2.0

If you want or need to make changes to EV 2.0, either by request from a staff member or just because you think it could be improved in some way, you need to open the EV2Dev project from Visual Studio. This is the development site of EV 2.0 and is only used by you to make changes to the site and not have it reflect on the real side, which could be used by students during weekdays. 
 
A few things to keep track of:
•	Make sure you are making changes to the code in the EV 2.0 Dev project and NOT the main site. It can be confusing to figure out which one is which other than to make sure you open the correct file when launching Visual Studio.
•	Making changes in the database via SQL WILL EFFECT THE MAIN SITE. This is instant and will appear on BOTH the main site and dev site when a refresh occurs.
•	When making changes, make sure you have some sort of a changelog so you can tell what you made changes to and when. This is also so you can update the changelog on the website so the staff can see what you've been working on.
•	To update the main site, copy the files that you were working on from the Dev site and paste them into the main site folder. Here's how to do that:
o	Open File Explorer
o	On the sidebar, there should be a pinned folder called EV2Dev. Open that.
o	Scroll down until you see the page you were working on.
o	Select it and copy it
o	Now again on the sidebar, there should be a folder called EV. Open that.
o	Paste the files from EV2Dev into the EV folder.
o	A window asking you to replace a file in there should appear. Click yes.
•	Note: if you are making a big change to the site, be sure to back up the files into the back up folder in the Tech Tech folder. Click here on how to do that.
o	Open Visual Studio, open the EV main site project.
o	After it loads, press Ctrl+B to build the site. Check if there are any errors.
o	Open a tab on your browser and navigate to EV2.0 main site. Check to see if your changes have been made on the page you updated.
o	Now update the changelog on the home page (reports.aspx)
•	Note: I usually just update it from the main site project in visual studio, since it's a minor HTML change and has nothing to do with the code side of it. 
o	Copy the changes you made to the changelog from VB and close that project and open the Dev project.
o	Paste your changes to the home page (reports.aspx) so that it matches the main site.
Backing Up EV 2.0

To back up EV 2.0, you need to copy the files from the Dev site AND the main site into a backup folder located in the Tech Tech folder on the Shared folder. Name the folder the date of which the back up is from. I don't have a specific date of when I backup the files but I try to do it every month or so.
SQL

EV 2.0 uses SQL Server Management Studio for its database. The database uses SQL as its language, but the actual program is fairly user friendly so there's not much SQL coding you have to do to use it.
Starting SQL Server Management Studio

To start the application, click on the application and a connect window should appear. The information is usually automatically filled out, but because you are a new user, it might require you to log in with your PCSB username and password. Please make sure the connection window looks like it does in the picture below.
 
Locating the Tables

When you are in SQL Server Management Studio, you'll see a side bar called the Object Explorer. When you expand the Databases folder, you'll see the different databases on the a6351sev server. EV 2.0 is located in the EV_DB database so expand that (by clicking the plus icon). Then, expand the Tables folder and that is where you'll see all of the tables that EV 2.0 uses. The tables start with 'dbo.' 
 
Right-click on one of them and you'll see a wide variety of options. Select the 'Select Top XXXX' option and you can see the table filled with data (sorted from date of creation).
  
Understanding Each Table

Here is where I will explain what each table is used for briefly and the level of importance. For more information on how each of these tables functions within EV 2.0's code, see the Flow Chart page of the New Hire section.
 
Each table has either a Static or Updates rating meaning if the table does not get updated through EV 2.0 and its simply used to pull data, it has a Static rating. If data is being inserted regularly, it is an Updates rating.
 
•	adminInfo
o	This table houses the GSI (and some admin) staff that are allowed to access EV 2.0. Used to verify the log in credentials.
o	Static
o	Columns: firstName, lastName, email, location, invoiceControl, username, job
•	Badges
o	This table houses the data for the student's badges when they create one in TD SYNNEX.
o	Updates
o	Columns: id, employeeNumber, employeeName, businessName, position, businessID, date, photoPath, visitID
•	businessInfo
o	This table has all the static information that is used for the businesses in EV 2.0 such as the name, ID, job numbers, etc.
o	Static
o	Columns: id, businessName, logoPath, address, businessColor, startingBalance, active, selling, position1-11, operating1-13, printChecks
•	checksInfo
o	This table houses the data that is uploaded regarding the payroll and operating checks of the financial officer in EV.
o	Updates
o	Columns: id, business_ID, check_type, payee, check_amount, written_amount, memo, time_written, visit_ID, oper_bus_name, oper_group
•	EV_Inventory
o	This table is for the inventory system in EV 2.0. 
o	Updates (not frequently)
o	Columns: id, itemName, itemCategory, itemSubCat, currentLocation, source, onHand, businessUsed, comments, merchCode, section (currently unused), shelf (currently unused),  description (currently unused)
•	EV_InventoryTimesheet
o	This table is used for the timestamps for adding / removing items in the inventory, used by the bus drivers. It catalogs who updated, how much was taken out or in, when they did it, etc. 
o	Updates
o	Columns: id, itemID, itemName, dateReceived, amount, lastEdited, lastEditedBy, notes
•	Jobs
o	Contains the job information for all jobs in EV.
o	Static
o	Columns: id, jobTitle, jobSalary
•	onlineBanking
o	Used for housing deposit information from the Online Banking page on EV AND indicate open / closed status of businesses
o	Updates
o	Columns: visitID, visitDate, businessID, openstatus, startingAmount, loanAmount, deposit1-4, profit, sales, school, businessVMinCount, businessVMaxCount
•	onlineBanking_template
o	Used to construct new rows of the onlineBanking table 
o	Static
o	Columns: visitID, visitDate, businessID, openstatus, startingAmount, loanAmount, deposit1-4, profit, sales, school, businessVMinCount, businessVMaxCount
•	Salary
o	Houses data for the three tiers of salary in EV
o	Static
o	Columns: payTier, tierSalary
•	schoolInfo
o	Houses data for all the schools that visit EV
o	Updates
o	Columns: id, schoolName, principalFirst, principalLast, principalTitle, phone, fax, schoolNum, schoolHours, schoolType, visitDate1-4, dayCount1-4, sharingSchool1-4, dayActual1-4, futureRequestsEmail, futureRequests, schoolYear, active, county, visitTime, invoice, invoiceIssued, schoolType2, directorsSignature, contractReceived, deliveryMethod, notes, numberOfKits, deliveryAccepted, dateAccepted, kitNumbers, liaisonName
•	studentInfo
o	Houses student information for EV
o	Updates
o	Columns: id, employeeNumber, firstName, lastName, school, business, job, visit, teacher, savings, netDeposit1-4, cbw1-4, initialDeposit1-4, tellerTimestamp1-4, savingsTimestamp
•	studentInfo_template
o	Used to construct new rows of the studentInfo table
o	Static
o	Columns: id, employeeNumber, firstName, lastName, school, business, job, visit, teacher, savings, netDeposit1-4, cbw1-4, initialDeposit1-4, tellerTimestamp1-4, savingsTimestamp
•	teacherInfo
o	Used to house teacher data
o	Updates
o	Columns: id, title, studentCount, subject, emailAddress, kitNumber, isContact, password, county, schoolName, futureRequestsEmail, firstName, lastName
•	Transactions
o	Stores data for transactions in EV
o	Updates
o	Columns: id, employeeNumber, business, transactionTimeStamp, saleAmount, visitDate, item1-4, saleAmount2-4, transactionTimeStamp2-4
•	visitInfo
o	Stores data for visit information
o	Updates
o	Columns: id, school, ownTraining, vTrainingTime, replyBy, visitDate, sharing, studentCount, school2-4, vLead, floorFacilitator, backupTeacher, visitTime, school5, teacherCompleted, invoivce, lastEdited, schoolType2, invoiceIssued, directorsSignature, contractRecieved, deliveryMethod, notes, numberofKits, deliveryAccepted, dateAccepted, kitNumbers, vMinCount, vMaxCount
Importing Non-PCSB Students From an Excel Spreadsheet [ARCHIVE]

UPDATE (3/10/2023): EV 2.0 is now accessible by out-of-county teachers. This section is no longer used but here for archival purposes.
Out-of-county teachers cannot access EV2.0 in the same way that PCSB teachers can. Therefore, they cannot log in and enter their students in using the ISI. We have implemented a way of entering the students in using an excel spreadsheet that the teachers will fill out and email back to us. A teacher will email the tech technician the spreadsheet which they will convert to a CSV file and upload into the SQL server database. From there, the technician will copy the names of the students from CSV into the studentInfo table. Below are the step by step instructions:

Required Materials
•	visit ID of school you are importing (can be found on the 'Visit Report' page of EV 2.0). Look up the date of the visiting school
•	school ID of school you are importing (can be found on the 'School Report' page of EV 2.0). Look up the name of the visiting school
 
Part 1: Create and Import the CSV File 
1.	Get the excel spreadsheet from Barbara or one of the teachers.
2.	Open the excel file and confirm that the students have their first and last name entered in for each business
3.	Convert the excel file into a CSV file.
a.	Go to File
b.	Save a Copy
c.	Select CSV UTF-8 (comma indicated) from the drop down list under the name of the file
d.	Save to Desktop
4.	Open SQL Server. Connect to a6351sev (should already be inputted)
5.	Click the plus icon next to the server name, expand the Databases folder, right-click on EV_DB, select Tasks, select Import Flat File
6.	This will open the Import Flat File wizard. Click Next, select the CSV file you just created, rename the table (optional), click Next.
7.	Click Next, click Next, click Finish, click Close (you might get a warning here, but just ignore it). The table will now be in the database. Click the refresh icon at the top of the Object Explorer in SQL Server. It should be right above the database name. You should see the newly added CSV file in there.
 
Part 2: Cleaning up the Table
1.	Expand the Database and Right-click on the new table and click Select Top 1000 Rows. You should see all of the names and positions and employee numbers of the students. There should be red squiggly lines underneath the column names and table names. Clear those out by hitting Ctrl + Shift + R on your keyboard.
2.	First, we're going to delete the top few rows from the table. Type in the following command: DELETE TOP(#) FROM [TABLE NAME HERE]. It should delete the top # rows in the table, which should have some NULL values, and some other things we don't want. (Replace the # with the number of rows at the top that do not include the first name, last name, or position text) The top row should now have an employee number in column1, a name in column2, a last name in column 3, and the job title in column4.
a.	You may have extra columns in columns 5 - 10  and they should be all NULL values, so we don't need them. If this happens, Right-click on the table and select Design. Select columns 5-10 by holding Ctrl and Left-clicking each column. Right-click when columns 5-10 are selected, and click Delete.
3.	Now we're going to rename the 4 remaining columns. Column1 will be employeeNumber, column2 is firstName, column3 is lastName, and column4 is position. Right click the table name in the Object explorer (side bar) and click Design. Rename columns 1-4 to the names listed above. Hit Ctrl + S to save after you've finished.
4.	Now right-click on the table in the Object Explorer (side bar) and click Select to see the changes we made to the table. Columns 5-10 should be gone, and 1-4 should be renamed.
5.	Now we're going to alter the datatypes of the 4 remaining columns. Under the SELECT statement, type in the following:
a.	ALTER TABLE [TABLE NAME HERE] ALTER COLUMN employeeNumber int
b.	ALTER TABLE [TABLE NAME HERE] ALTER COLUMN firstName varchar(50)
c.	ALTER TABLE [TABLE NAME HERE] ALTER COLUMN lastName varchar(50)
d.	ALTER TABLE [TABLE NAME HERE] ALTER COLUMN position varchar(50)
6.	Once that's done, we're going to remove the NULL values from the employeeNumber column. Type in DELETE FROM [TABLE NAME HERE] WHERE employeeNumber IS NULL. You should get a confirmation message and then go ahead and run that SELECT statement again to see your updated changes.

Part 3: Importing the Data to the studentinfo Table
1.	Now that the table is finally cleaned up, we can import it into our studentInfo table. However, first we need to find the visit ID and school ID for the school we are importing. 
a.	If you haven't already, open your web browser and log into EV 2.0. Under reports, go to Visit Reports. Enter in the date of the visit you are importing (it should be at the top of the excel file or you can search by the school name) and locate the visit ID of that school when it loads.
b.	If you don't have the school ID yet, go to School Report under Reports, and search for the school you are importing. Locate the ID of the school.
2.	Go back to SQL Server and type in the following:
a.	UPDATE studentInfo
  SET lastName = t.lastName, school = [SCHOOL ID HERE]
  FROM studentInfo s, [EXCEL SPREADSHEET NAME HERE] t
  WHERE s.employeeNumber = t.employeeNumber AND s.visit=[VISIT ID OF SCHOOL HERE]
b.	There should be a confirmation message that appears saying how many rows you've updated.
3.	In the Object Window, right-click on the studentInfo table and click Select. At the bottom of the SELECT statement, type in WHERE visit=[VISIT ID HERE] and click Execute at the top. Make sure that the first names from the CSV table are in there properly, and navigate to the previous tab you were on.
4.	Type in this statement under the previous UPDATE statement you ran
a.	UPDATE studentInfo
  SET firstName = t.firstName, school = [SCHOOL ID HERE]
  FROM studentInfo s, [EXCEL SPREADSHEET NAME HERE] t
  WHERE s.employeeNumber = t.employeeNumber AND s.visit=[VISIT ID OF SCHOOL HERE]
5.	You are now done! Go back to EV 2.0 and navigate to the Student Report page to confirm that your changes are in the database and are viewable.

Commands for Copy/Pasting
DELETE TOP([NUMBER HERE]) FROM [TABLE NAME HERE]
 
ALTER TABLE [TABLE NAME HERE] ALTER COLUMN employeeNumber int
ALTER TABLE [TABLE NAME HERE] ALTER COLUMN firstName varchar(50)
ALTER TABLE [TABLE NAME HERE] ALTER COLUMN lastName varchar(50)
 
DELETE FROM [TABLE NAME HERE] WHERE employeeNumber IS NULL
 
UPDATE studentInfo
  SET lastName = t.lastName, school = [SCHOOL ID HERE]
  FROM studentInfo s, [EXCEL SPREADSHEET NAME HERE] t
  WHERE s.employeeNumber = t.employeeNumber AND s.visit=[VISIT ID OF SCHOOL HERE]
 
  UPDATE studentInfo
  SET firstName = t.firstName, school = [SCHOOL ID HERE]
  FROM studentInfo s, [EXCEL SPREADSHEET NAME HERE] t
  WHERE s.employeeNumber = t.employeeNumber AND s.visit=[VISIT ID OF SCHOOL HERE]

Some Basic Functions

•	Select Top 1000
o	Right-click on any table and select this option at the top of the list. 
o	Allows you to view the data from that table.
•	Design
o	Right-click on any table and select this option at the top of the list.
o	Allows you to manipulate the table itself. You can edit the datatype of columns, change the names of the columns, add a column, delete columns, change the primary keys, and more.
•	NOTE: This function can be very dangerous as it can cause damage if it is not handled correctly. Please use extra caution before clicking this option.
•	All things that the Design function can do, can be done by typing in the SQL command.
•	Edit Top 1000 Rows
o	Right-click on any table and select this option at the top of the list.
o	Allows you to edit the data from the tables as well as add rows to the table.
•	NOTE: Again, this function can be dangerous to use if not handled correctly. Please make sure that you are familiar with what editing a table not through EV 2.0 does.
•	Tip: If you need to make a cell blank or NULL, type it in all caps.
•	Tip: While in the Edit window, you can change the SQL statement by clicking the button above the coding window that just says 'SQL' or by pressing Ctrl + 3. You can add a WHERE clause, select only a specific row, etc. Press Ctrl + R after editing that code to run it, or press the button with the green arrow to the right of the SQL button.
•	Execute
o	Click the button with the green arrow at the top of the coding window. You can also press F5.
o	Runs the selected code.
•	Tip: If you highlight a piece of code and click Execute, it will only run that bit of code. I use this a lot when editing from SQL while simultaneously looking at the data from the table I'm editing.
•	New Query
o	Click the button in the toolbar that says 'New Query'.
o	Opens up a blank window.
Receipt Printers

EV 2.0 uses 2 different kinds of receipt printers: one for the desktops and one for the iPads. At the time of writing this, the plan is to switch all the desktops to iPads but as of right now they use different printers. 
 
The Desktops (AIOs) use a MJ 8250 POS-80 thermal printer, which connects via USB-B cable and needs a power cable to operate. The iPads use a newer microStar TSP100III thermal printer and a special piece of software on the iPads to operate.

Desktop Receipt Printers

To Install a POS-80 Printer:
1.	Plug in the printer to the computer and turn on the printer using the switch on the side.
2.	On the computer, open File Explorer and go to S6315D###-#### on the sidebar (the numbers are the number of the computer).
a.	Some computers do not have this folder. We have a backup of this folder on the Tech Flashdrive in the office.
3.	From there, go to the C: drive and there should be a folder called 11.2.2 POS-80 or something. Open that and scroll down until you see PrinterTestDemo and open that.
4.	On the drop down menu called Select Printer Type: and select POS-80.
5.	Click on the button that says USB Test Port. The printer should now print out a small text receipt.
6.	Click on Begin Setup. When finished you can close the application.
7.	Test out the printer by going to a sales page on EV 2.0 and opening the print window, selecting POS-80, and clicking print. The receipt should print out successfully.

iPads Receipt Printers (TSP100III)

To Install a TSP100III Printer:
1.	Select an iPad you want to use and add that device to the group "6351 - StarPass" on Intune (click here to learn how to add a device to Intune). This will add an app called StarPass to the iPad after it syncs. 
2.	It may take a while (15mins-1hr) for the app to show up on the iPad but when it doesn't, open the app.
3.	Connect the iPad to the printer via a USB to Lightning cable and a power cable to turn on the printer.
a.	If it’s connected successfully, the iPad will charge.
4.	Back on the app, click the button that says 'Search'. A window will appear. Select 'Bluetooth / USB'. If the printer is connected successfully, you should see the TSP100III printer name. Select it.
5.	After it finishes adding the printer, open Safari and open up the Teller System page from EV 2.0 and enter a test account number, select a dollar amount to deposit and select Enter Deposit. If the receipt prints out, you are all set.

Troubleshooting

•	POS-80 printer cannot print receipt
o	Sometimes a receipt will not print and will get stuck in the queue without any error (sometimes there is an error saying it can't print).
o	Fix:
•	Uninstall the printer and reinstall it again.
	To uninstall the printer via a student computer, type in 'Print Management' into the search bar and Open As Administrator. Enter your credentials and you'll find the POS-80 printer under the 'All Printers' folder in the application. Right-click and clear out the queue and then delete the printer.
	To reinstall it, follow the directions above to install a POS-80 printer.
•	TSP100III Printer cannot print receipt
o	Check to see if the cable to the printer is connected properly
o	Open the StarPass app and tap on 'Check Communication'.
•	Long receipt
o	Note: This fix I haven't been able to pin down fully why it happens, and when it does, I find that it sort of fixes itself after messing around with some of the settings for a bit. Until that issue happens again and I figure out a more concrete solution, here are some things you can do:
o	Check the page alignment
•	On the print window, check to make sure that the alignment is in Portrait mode and not Landscape
o	Close the browser window and open it again
o	Clear the cache
•	In the browser, click on the three dots in the top-right corner.
•	Click on Settings, towards the bottom of the menu
•	On the sidebar, click on Privacy, search, and services
•	Click on the box that says 'Balanced'
•	Under Clear Browsing Data, click Choose what to clear
•	Make sure Cached images and files is checked and click Clear now
•	Go back to the Sales screen and refresh the page
•	Press Ctrl+P to see the print window. If it looks like a normal receipt, its resolved.
o	Restart the computer
Appendix
Code Tips and Shortcuts
VB.Net / Asp.net (HTML)

Here are some shortcuts and useful lines of code that I’ve used throughout EV 2.0.
Description	Code
Gets school names for visitID into one string and removes the comma at the end	Try
            con.ConnectionString = connection_string
            con.Open()
            cmd.CommandText = "SELECT schools = STUFF((
                                SELECT ', ' + s.schoolName
                                FROM schoolInfo s 
                                INNER JOIN visitInfo v on s.ID = v.School OR s.id = v.school2 or s.id = v.school3 or s.id = v.school4 or s.id = v.school5 
                                WHERE v.id='" & visitID & "'
                                FOR XML PATH('')), 1, 1, '')"
            cmd.Connection = con
            dr = cmd.ExecuteReader
 
            While dr.Read()
                schoolName = dr("schools").ToString
 
                schoolName = schoolName.TrimEnd(",", " ")
 
                Schools_lbl.Text = schoolName
            End While
 
            cmd.Dispose()
            con.Close()
 
        Catch
            error_lbl.Text = "Error in loaddata(). Could not retrieve school name."
            Exit Sub
        Finally
            cmd.Dispose()
            con.Close()

Runs a javascript function inside VB.net	Page.ClientScript.RegisterStartupScript(Me.GetType(), "DepositSucessText", "DepositSucessText();", True)

OR

Me.ClientScript.RegisterClientScriptBlock(Me.[GetType](), "Close", "window.close()", True)
HTML Spaces	&nbsp;	One space
&ensp;	Two Spaces
&emsp;	Four Spaces

Redirect to another page in VB	Response.Redirect(".\default.aspx")
Link to print css in html	<link href="css/Styles.Print.css" rel="stylesheet" media="print" type="text/css">
Use Split to separate parts of a string	Dim teacherNameString As String = teacherName_ddl.SelectedValue.ToString
 
Dim teacherName() As String = teacherNameString.Split(New String() {" "}, StringSplitOptions.RemoveEmptyEntries)

Get name of computer client	System.Net.Dns.GetHostEntry(Request.ServerVariables.Item("REMOTE_HOST")).HostName
Replace character in a string	String = string.Replace("", "")
Change CSS Class from behind	check5_div.Attributes("class") = "check_print5"
Fills a gridview table	con.ConnectionString = connection_string
con.Open()
cmd = New SqlCommand
cmd.Connection = con
Dim da As New SqlDataAdapter
da.SelectCommand = cmd
Dim dt As New DataTable
da.Fill(dt)

Add an ‘N/A’ for each column that’s empty	While dr.Read()
   For i = 0 To Transactions_dgv.Rows.Count - 1
       If dr("transactionTimeStamp2").ToString = Nothing Then
          Transactions_dgv.Rows(i).Cells(4).Text = "N/A"
       End If
       If dr("transactionTimeStamp3").ToString = Nothing Then
          Transactions_dgv.Rows(i).Cells(6).Text = "N/A"
       End If
       If dr("transactionTimeStamp4").ToString = Nothing Then
          Transactions_dgv.Rows(i).Cells(8).Text = "N/A"
       End If
  Next
End While

Populate a DDL w/ a blank section at the top	cmd.Connection = con
dr = cmd.ExecuteReader
 
While dr.Read()
   schoolName_ddl.Items.Add(dr(0).ToString)
End While
 
schoolName_ddl.Items.Insert(0, "")

Makes the line not show up in print	class="no-print”   CssClass="no-print"
Get session username from log in page	Session("username") = "username"
Wait 3 seconds in VB	Threading.Thread.Sleep(3000)
Select an item in a DDL from behind	DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByValue(<value>))
	


SQL

Here are some basic SQL commands and statements that I use regularly whenever using SQL. If you are unfamiliar with SQL, I recommend speaking with Stephen Whitton (Whittons@pcsb.org) or Googling.
 
PS: W3 Schools is also a great website for teaching you basics of various languages
https://www.w3schools.com/sql/default.asp
Description	Code
Check how many connections are open on the server (useful for the connection errors)	SELECT DB_NAME(dbid) as DBName, COUNT(dbid) as NumberOfConnections, loginame as LoginName FROM sys.sysprocesses WHERE dbid > 0 GROUP BY dbid, loginame

	










