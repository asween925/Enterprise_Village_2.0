// JavaScript Document
function loadDB() {
    var connection = new ActiveXObject("ADODB.Connection");
    var connectionstring = "Data Source=A6351sfp.pinellas.local;Initial Catalog=ev_db;Persist Security Info=True;User ID=ev;Password=$t@vr0sSQL;Provider=SQLOLEDB";
    connection.Open(connectionstring);
    var rs = new ActiveXObject("ADODB.Recordset");
    rs.Open("select * from businessinfo", connection);
    rs.MoveFirst();
    var span = document.createElement("span");
    span.style.color = "Blue";
    span.innerText = " ID "+" businessname "+" logopath" +" businesscolor" +"startingbalance" +"active" ;
    document.body.appendChild(span);
    while (!rs.eof)
    {
    span.style.color = "green";
    span.innerText = "\n " + rs.fields(0) +" | "+ rs.fields(1) +" | "+ rs.fields(2) +" | "+ rs.fields(3) +" | "+ rs.fields(4) +" | "+ rs.fields(5) ;
    document.body.appendChild(span);
    rs.MoveNext();
    }
    rs.close();
    connection.close();
}

var pageWidth, pageHeight;

function capturesave() {
    document.getElementById('capturecanvas').getContext('2d').drawImage(videoCapture, 0, 0, 230, 230);

    var image = document.getElementById("capturecanvas").toDataURL('image/png').replace('image/png', 'image/octet-stream');
    var anchor = document.createElement('a');

    anchor.setAttribute('download', 'myPhoto.png');
    anchor.setAttribute('href', image);
    anchor.click();
}

//function capture() {
//    document.getElementById('capturecanvas').getContext('2d').drawImage(videoCapture, 0, 0, 230, 230);
//}

//function save() {
//    var image = document.getElementById("capturecanvas").toDataURL('image/png').replace('image/png', 'image/octet-stream');
//    var anchor = document.createElement('a');
//    var btn = document.getElementById('<%= upload_btn.ClientID %>');
//    document.getElementById(btn).disabled = false;
//    anchor.setAttribute('download', 'myPhoto.png');
//    anchor.setAttribute('href', image);
//    anchor.click();

    
//   /* myTimer();*/
//}

function myTimer() {
    var timeleft = 3;
    var downloadTimer = setInterval(function () {
        if (timeleft <= 0) {
            clearInterval(downloadTimer);
            document.getElementById("upload_btn").innerHTML = "Upload Picture";
        } else {
            document.getElementById("upload_btn").innerHTML = "(" + timeleft + ") Upload Picture";
        }
        timeleft -= 1;
    }, 1000);

    /*document.getElementById("upload_btn").innerHTML = */
}

function HideDiv() {
    var test = document.getElementById("invoice");
    test.hidden = hidden;
}

function DitekCheck() {

    var myWindow = window.open("https://ev.pcsb.org/pages/student/ditek_check.aspx");
    myWindow.print();
}

function DitekCheck2() {

    var myWindow = window.open("https://ev.pcsb.org/pages/student/ditek_check.aspx");
    myWindow.print();
}

function PrintPayrollChecks() {

    var myWindow = window.open("https://ev.pcsb.org/pages/print/print_checks.aspx");
    myWindow.print();
}

function PrintBadges() {
    window.print();
}

function focus() {
    document.getElementById('Debit_card_account').AutoPostBack = true;
    document.getElementById("Item1_tb").focus();
    document.getElementById("Item1_tb").select();
}

function OpenEmail() {
    const email = message.emailId;
    const subject = message.subject;
    const emailBody = "Hi " + message.from;
    document.location =
        "mailto:" + email + "?subject=" + subject + "&body=" + emailBody;
}


function CardSwipe() {
    var x = document.getElementById("Debit_card_swipe");
    var y = document.getElementById("Debit_card_swipe2");
    if (x.style.display === "none") {
        x.style.display = "inline-block";
    } else {
        x.style.display = "none";
        y.style.display = "inline-block";
        document.getElementById("Debit_card_account").focus();
        document.getElementById("Debit_card_account").select();
    }
}

function Enter_account() {
    var x = document.getElementById("Screen1");
    var y = document.getElementById("Screen2");
    if (x.style.display === "none") {
        x.style.display = "inline-block";
    } else {
        x.style.display = "none";
        y.style.display = "inline";

    }
}

function ISI_confirm() {
    var x = document.getElementById("Screen1");
    var y = document.getElementById("Screen2");
    if (x.style.display === "none") {
        x.style.display = "inline-block";
    } else {
        x.style.display = "none";
        y.style.display = "inherit";

    }
}

function BayCare_Admin_Switch_Vouchers() {
    var x = document.getElementById("BayCareAA_Main_Page");
    var y = document.getElementById("BayCareAA_Vouchers_Page");
    if (x.style.display === "none") {
        x.style.display = "inline-block";
    } else {
        x.style.display = "none";
        y.style.display = "inherit";

    }
}

function BayCare_Admin_Switch_CheckIn() {
    var x = document.getElementById("BayCareAA_Main_Page");
    var y = document.getElementById("BayCareAA_CheckIn_Page");
    if (x.style.display === "none") {
        x.style.display = "inline-block";
    } else {
        x.style.display = "none";
        y.style.display = "inherit";

    }
}

function BayCare_Admin_Switch_FinalReport() {
    var x = document.getElementById("BayCareAA_Main_Page");
    var y = document.getElementById("BayCareAA_Final_Report_Page");
    if (x.style.display === "none") {
        x.style.display = "inline-block";
    } else {
        x.style.display = "none";
        y.style.display = "inherit";

    }
}



function Enter_account() {
    var x = document.getElementById("Screen1");
    var y = document.getElementById("Screen2");
    if (x.style.display === "none") {
        x.style.display = "inline-block";
    } else {
        x.style.display = "none";
        y.style.display = "inline";

    }
}

function McDonalds_Sales() {
    var x = document.getElementById("Screen1");
    var y = document.getElementById("Screen2");
    if (x.style.display === "none") {
        x.style.display = "inline-block";
    } else {
        x.style.display = "none";
        y.style.display = "inherit";

    }
}

function Voting_System() {
    var x = document.getElementById("Voting_System_Main_Page");
    var y = document.getElementById("Voting_System_Questions_Page");
    if (x.style.display === "none") {
        x.style.display = "inline-block";
    } else {
        x.style.display = "none";
        y.style.display = "inline";

    }
}

async function getMedia(constraints) {
    let stream = null;

    try {
        stream = await navigator.mediaDevices.getUserMedia(constraints);
        /* use the stream */
    } catch (err) {
        /* handle the error */
    }
}

function Enter() {
    var x = document.getElementById("screen1");
    var y = document.getElementById("screen2");
    var z = document.getElementById("screen3");
    var a = document.getElementById("screen4");
    if (x.style.display === "none") {
        x.style.display = "inline-block";
    } else {
        x.style.display = "none";
        y.style.display = "inline-block";
        z.style.display = "none";
        a.style.display = "inline-block";
    }
}


function ManualEntry() {
    var txt;
    var person = prompt("Please enter your name:", "Harry Potter");
    if (person == null || person == "") {
        txt = "User cancelled the prompt.";
    } else {
        txt = "Hello " + person + "! How are you today?";
    }
    document.getElementById("demo").innerHTML = txt;
}


function DepositSucessText() {
    myVar = setTimeout(Enter, 0);
    text = "Deposit sucessful! Reloading the page...";
    document.getElementById("demo3").innerHTML = text;
    /*myVar = setTimeout(DepositSuccessText2, 3000);*/
}

function DepositSuccessText2() {
    window.print()
    /*myVar = setTimeout(ResetPage, 3000);*/
}

function ISISubmitSuccess() {
    myVar = setTimeout(Enter, 0);
    text = "Submission sucessful! Logging you out...";
    document.getElementById("demo3").innerHTML = text;
    myVar = setTimeout(ResetPage, 3000);
}

function SubmitSucessText() {
    myVar = setTimeout(Enter, 0);
    text = "Submission sucessful! Refreshing the page now...";
    document.getElementById("error_lbl").innerHTML = text;
    myVar = setTimeout(ResetPage, 3000);
}

function PrintPage() {
    window.print();
    document.onafterprint("demo3") = window.print();
}

function ShowSucessText() {
    myVar = setTimeout(Enter, 0);
    text = "Sale sucessful! Printing receipt...";
    document.getElementById("error_lbl").innerHTML = text;    
    myVar = setTimeout(Print, 1500);
    Print();
    //myVar = setTimeout(Print, 1500);
    myVar = setTimeout(ResetPage, 1500);
}

function SalesPrintPage() {
    myVar = setTimeout(hangout, 3000);
       
}

function Print() {
    window.print();
}

function OpenLinkInNewTab(url) {
    window.open(url);
}

function SalesPrintPage1() {
    text = "Sale sucessful";
    document.getElementById("error_lbl").innerHTML = text;

    myWindow.print();
    myVar = setTimeout(SalesPrintPage2(), 1000);

}




function SalesPrintPage2() {
    text = "Sale sucessful";
    document.getElementById("error_lbl").innerHTML = text;
    myVar = setTimeout(hangout, 3000);

    myWindow.print();
    myVar = setTimeout(SalesPrintPage2, 1000);

}

function SalesPrintPage3() {
    window.print();
    var url = window.location.href
    window.open(url, "_self")
}

function ResetPage() {
    var url = window.location.href
    window.open(url, "_self")
}

function Exit_account() {
    var x = document.getElementById("main_bbb");
    var y = document.getElementById("main_city");
    if (y.style.display = "none") {
        y.style.display = "normal";
    } else {
        y.style.display = "none";
        x.style.display = "normal";
    }
}


function sale_decline() {
    text = "Sale has been declined, please try again or ask a staff member for help";
    document.getElementById("error_lbl").innerHTML = text;
}

function sale_error() {
    text = "Please enter information into all required fields";
    document.getElementById("error_lbl").innerHTML = text;
}

function invalid() {
    text = "Account number is not valid, please try again or ask a staff member for help";
    document.getElementById("error_lbl").innerHTML = text;
}



function mult() {
    var x, text;
    var Check_amount_tb = document.getElementById('Check_amount_tb').value;
    var x = document.getElementById('cash_recieved_tb').value;
    var result = parseFloat(x) * -1;
    var result2 = (((parseFloat(Check_amount_tb) - parseFloat(x)) * 100) / 100).toFixed(2);

    if (x == 0.25 || x == 0.50 || x == 0.75 || x == 1 || x == 0) {

        document.getElementById('Net_tb').value = result2

        document.getElementById('Net_tb2').value = result2
        text = "";
        document.getElementById("demo").innerHTML = text;
    }


    else if (x == -0.25 || x == -0.50 || x == -0.75 || x == -1) {
        
    }

    else if (x == "") {
        document.getElementById('cash_recieved_tb').value = ""
    }

    else {
        text = "*Cash amount not valid";
        document.getElementById("demo").innerHTML = text;
    }

}

function add() {
    var y, text;
    var y = document.getElementById('Check_amount_tb').value;
    var x = document.getElementById('cash_recieved_tb').value;
    var result2 = parseFloat(y) + parseFloat(x);

    if (y == 5 || y == 5.50 || y == 6) {
        document.getElementById('Net_tb').value = result2
        document.getElementById('Net_tb2').value = result2
        text = "";
        document.getElementById("demo2").innerHTML = text;
    }

    else if (y == "") {
        document.getElementById('Check_amount_tb').value = ""
        text = "";
        document.getElementById("demo2").innerHTML = text;
    }


    else {
        text = "*Cash amount not valid";
        document.getElementById("demo2").innerHTML = text;
    }

}

function addfield1() {
    var w = document.getElementById("item1_tb");
    var x = document.getElementById("item2_tb");
    var y = document.getElementById("item3_tb");
    var z = document.getElementById("item4_tb");
    var ww = document.getElementById("item1_txt");
    var xx = document.getElementById("item2_txt");
    var yy = document.getElementById("item3_txt");
    var zz = document.getElementById("item4_txt");
    if (x.style.display === "none") {
        x.style.display = "inline-block";
    } else {
       // holding for now x.style.display = "none";
        x.style.display = "inline-block";
        xx.style.display = "inline-block";
        document.getElementById("item2_tb").focus();
        document.getElementById("item2_tb").select();
    }
}

function addfield2() {
    var w = document.getElementById("item1_tb");
    var x = document.getElementById("item2_tb");
    var y = document.getElementById("item3_tb");
    var z = document.getElementById("item4_tb");
    var ww = document.getElementById("item1_txt");
    var xx = document.getElementById("item2_txt");
    var yy = document.getElementById("item3_txt");
    var zz = document.getElementById("item4_txt");
    if (x.style.display === "none") {
        x.style.display = "inline-block";
    } else {
        // holding for now x.style.display = "none";
        y.style.display = "inline-block";
        yy.style.display = "inline-block";
        document.getElementById("item3_tb").focus();
        document.getElementById("item3_tb").select();
    }
}

function addfield3() {
    var w = document.getElementById("item1_tb");
    var x = document.getElementById("item2_tb");
    var y = document.getElementById("item3_tb");
    var z = document.getElementById("item4_tb");
    var ww = document.getElementById("item1_txt");
    var xx = document.getElementById("item2_txt");
    var yy = document.getElementById("item3_txt");
    var zz = document.getElementById("item4_txt");
    if (x.style.display === "none") {
        x.style.display = "inline-block";
    } else {
        // holding for now x.style.display = "none";
        z.style.display = "inline-block";
        zz.style.display = "inline-block";
        document.getElementById("item4_tb").focus();
        document.getElementById("item4_tb").select();
    }
}

function addsales() {
    var field1 = document.getElementById('item1_tb').value;
    var field2 = document.getElementById('item2_tb').value;
    var field3 = document.getElementById('item3_tb').value;
    var field4 = document.getElementById('item4_tb').value;
    var text;

    if (field1 > 0 && field2 == "") {
        document.getElementById("total_tb").value = field1
        document.getElementById("total_tb2").value = field1
        // myVar = setTimeout(addfield1, 250);
    }

    else if (field1 > 0 && field2 > 0 && field3 == "" && field4 == "") {
        var result2 = parseFloat(field1) + parseFloat(field2);
        document.getElementById("total_tb").value = result2
        document.getElementById("total_tb2").value = result2
        // myVar = setTimeout(addfield2, 250);
    }
    else if (field1 > 0 && field2 > 0 && field3 > 0 && field4 == "" > 0) {
        var result2 = parseFloat(field1) + parseFloat(field2) + parseFloat(field3);
        document.getElementById("total_tb").value = result2
        document.getElementById("total_tb2").value = result2
        // myVar = setTimeout(addfield3, 250);
    }
    else if (field1 > 0 && field2 > 0 && field3 > 0 && field4 > 0) {
        var result2 = parseFloat(field1) + parseFloat(field2) + parseFloat(field3) + parseFloat(field4);
        document.getElementById("total_tb").value = result2
        document.getElementById("total_tb2").value = result2
    }
        
    else if (field1 == "" || field2 == "" || field3 == "" || field4 == "") {
        document.getElementById("total_tb").value = ""
        document.getElementById("total_tb2").value = result2
    }

    else if (field1 > 0 || field2 == "" || field3 > 0 || field4 == "") {
        var result2 = parseFloat(field1) + parseFloat(field3);
        document.getElementById("total_tb").value = result2
        document.getElementById("total_tb2").value = result2
    }

    else {
        text = "*Cash amount not valid";
        document.getElementById("demo").innerHTML = text;
    }


}


function delayfunction() {
    myVar = setTimeout(mult, 1250);
}
function delayfunction2() {
    myVar = setTimeout(add, 1250);
}

function delayfunction3() {
    myVar = setTimeout(addsales, 2000);
}



function myFunction() {
  alert("Great job completing the task! Please continue with your next Nearpod instruction.");
}
function myFunction2() {
    alert("Great job completing the task! Please continue with your next Nearpod instruction.");
}


function CardSwipe() {
    var x = document.getElementById("Debit_card_swipe");
    var y = document.getElementById("Debit_card_swipe2");
    if (x.style.display === "none") {
        x.style.display = "inline-block";
    } else {
        x.style.display = "none";
        y.style.display = "inline-block";
        document.getElementById("Debit_card_account").focus();
        document.getElementById("Debit_card_account").select();
    }
}




function profits() {
    var x = document.getElementById("Message");
    var y = document.getElementById("Bus1");
    if (x.style.display === "none") {
        x.style.display = "inline-block";
    } else {
        x.style.display = "none";
        y.style.display = "inline-block";
        myVar = setTimeout(profits2, 5000);
    }
}

function profits1() {
    var x = document.getElementById("Message");
    var y = document.getElementById("Bus1");
    if (x.style.display === "none") {
        x.style.display = "inline-block";
    } else {
        x.style.display = "none";
        y.style.display = "inline-block";
        myVar = setTimeout(profits1, 5000);
    }
}

function profits2() {
    var x = document.getElementById("Bus1");
    var y = document.getElementById("Bus2");
    if (x.style.display === "none") {
        x.style.display = "inline-block";
    } else {
        x.style.display = "none";
        y.style.display = "inline-block";
        myVar = setTimeout(profits3, 5000);
    }
}

function profits3() {
    var x = document.getElementById("Bus2");
    var y = document.getElementById("Bus3");
    if (x.style.display === "none") {
        x.style.display = "inline-block";
    } else {
        x.style.display = "none";
        y.style.display = "inline-block";
        myVar = setTimeout(profits4, 5000);
    }
}

function profits4() {
    var x = document.getElementById("Bus3");
    var y = document.getElementById("Bus4");
    if (x.style.display === "none") {
        x.style.display = "inline-block";
    } else {
        x.style.display = "none";
        y.style.display = "inline-block";
        myVar = setTimeout(profits5, 5000);
    }
}
function profits5() {
    var x = document.getElementById("Bus4");
    var y = document.getElementById("Bus5");
    if (x.style.display === "none") {
        x.style.display = "inline-block";
    } else {
        x.style.display = "none";
        y.style.display = "inline-block";
        myVar = setTimeout(profits6, 5000);
    }
}
function profits6() {
    var x = document.getElementById("Bus5");
    var y = document.getElementById("Bus6");
    if (x.style.display === "none") {
        x.style.display = "inline-block";
    } else {
        x.style.display = "none";
        y.style.display = "inline-block";
        myVar = setTimeout(profits7, 5000);
    }
}
function profits7() {
    var x = document.getElementById("Bus6");
    var y = document.getElementById("Bus7");
    if (x.style.display === "none") {
        x.style.display = "inline-block";
    } else {
        x.style.display = "none";
        y.style.display = "inline-block";
        myVar = setTimeout(profits8, 5000);
    }
}
function profits8() {
    var x = document.getElementById("Bus7");
    var y = document.getElementById("Bus8");
    if (x.style.display === "none") {
        x.style.display = "inline-block";
    } else {
        x.style.display = "none";
        y.style.display = "inline-block";
        myVar = setTimeout(profits9, 5000);
    }
}
function profits9() {
    var x = document.getElementById("Bus8");
    var y = document.getElementById("Bus9");
    if (x.style.display === "none") {
        x.style.display = "inline-block";
    } else {
        x.style.display = "none";
        y.style.display = "inline-block";
        myVar = setTimeout(profits10, 5000);
    }
}
function profits10() {
    var x = document.getElementById("Bus9");
    var y = document.getElementById("Bus10");
    if (x.style.display === "none") {
        x.style.display = "inline-block";
    } else {
        x.style.display = "none";
        y.style.display = "inline-block";
        myVar = setTimeout(profits11, 5000);
    }
}
function profits11() {
    var x = document.getElementById("Bus10");
    var y = document.getElementById("Bus11");
    if (x.style.display === "none") {
        x.style.display = "inline-block";
    } else {
        x.style.display = "none";
        y.style.display = "inline-block";
        myVar = setTimeout(profits12, 5000);
    }
    }
    function profits12() {
        var x = document.getElementById("Bus11");
        var y = document.getElementById("Bus12");
        if (x.style.display === "none") {
            x.style.display = "inline-block";
        } else {
            x.style.display = "none";
            y.style.display = "inline-block";
            myVar = setTimeout(profits13, 5000);
        }
}

    function profits13() {
        var x = document.getElementById("Bus12");
        var y = document.getElementById("Bus13");
        if (x.style.display === "none") {
            x.style.display = "inline-block";
        } else {
            x.style.display = "none";
            y.style.display = "inline-block";
            myVar = setTimeout(profits14, 5000);
        }
}

    function profits14() {
        var x = document.getElementById("Bus13");
        var y = document.getElementById("Bus14");
        if (x.style.display === "none") {
            x.style.display = "inline-block";
        } else {
            x.style.display = "none";
            y.style.display = "inline-block";
            myVar = setTimeout(profits15, 5000);
        }
    }

function profits15() {
    var x = document.getElementById("Bus14");
    var y = document.getElementById("Bus15");
    if (x.style.display === "none") {
        x.style.display = "inline-block";
    } else {
        x.style.display = "none";
        y.style.display = "inline-block";
        myVar = setTimeout(profits16, 5000);
    }
}

function profits16() {
    var x = document.getElementById("Bus15");
    var y = document.getElementById("Bus16");
    if (x.style.display === "none") {
        x.style.display = "inline-block";
    } else {
        x.style.display = "none";
        y.style.display = "inline-block";
        myVar = setTimeout(profits17, 5000);
    }
}


function profits17() {
    var x = document.getElementById("Bus16");
    var y = document.getElementById("Bus17");
    if (x.style.display === "none") {
        x.style.display = "inline-block";
    } else {
        x.style.display = "none";
        y.style.display = "inline-block";
        myVar = setTimeout(profits18, 5000);
    }
}

function profits18() {
    var x = document.getElementById("Bus17");
    var y = document.getElementById("Message");
    if (x.style.display === "none") {
        x.style.display = "inline-block";
    } else {
        x.style.display = "none";
        y.style.display = "inline-block";
        myVar = setTimeout(profits, 5000);
    }
}


function delayfunction4() {
    myVar = setTimeout(profits, 5000);


}

// When the user clicks the button, the page scrolls to the top
function ScrollToTop() {
    window.scrollTo(500, 0);
}




var basePage = {
  width: 800,
  height: 600,
  scale: 1,
  scaleX: 1,
  scaleY: 1
};

$(function(){
  var $page = $('.page_content');
  
  getPageSize();
  scalePages($page, pageWidth, pageHeight);
  
  //using underscore to delay resize method till finished resizing window
  $(window).resize(_.debounce(function () {
    getPageSize();            
    scalePages($page, pageWidth, pageHeight);
  }, 150));
  

function getPageSize() {
  pageHeight = $('#container').height();
  pageWidth = $('#container').width();
}

function scalePages(page, maxWidth, maxHeight) {            
  var scaleX = 1, scaleY = 1;                      
  scaleX = maxWidth / basePage.width;
  scaleY = maxHeight / basePage.height;
  basePage.scaleX = scaleX;
  basePage.scaleY = scaleY;
  basePage.scale = (scaleX > scaleY) ? scaleY : scaleX;

  var newLeftPos = Math.abs(Math.floor(((basePage.width * basePage.scale) - maxWidth)/2));
  var newTopPos = Math.abs(Math.floor(((basePage.height * basePage.scale) - maxHeight)/2));

  page.attr('style', '-webkit-transform:scale(' + basePage.scale + ');left:' + newLeftPos + 'px;top:' + newTopPos + 'px;');
    }

    


});

