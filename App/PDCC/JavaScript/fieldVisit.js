//Disables back button
//window.history.forward(1);

//Logout Message
function LogoutMessage()
{
    var ht = document.getElementsByTagName("html");
    ht[0].style.filter="progid:DXImageTransform.Microsoft.BasicImage(grayscale=1)";
    if(confirm('Are you sure you want to log out of the application?')) {

        window.opener = self;
        window.close();
        return true;
    }
    else
    {
        ht[0].style.filter="";
        return false;
    }
}


//window.onload = toBottom;

function toBottom() {
    alert("Scrolling to bottom ...");
    window.scrollTo(0, document.body.scrollHeight);
}


function ChangeCalendarView(sender,args)
{
    sender._switchMode("years", true);
}

function checkDate(sender,args)
{
    if(sender._selectedDate < new Date)
    {
        alert("You cannot select a day earlier than today!");
        sender._selectedDate = new Date();
        sender._textbox.set_Value(sender._selectedDate.format(sender._format));
    }
}

function isMoneyNumbKey(evt, txtBox) {
    var bRet = false;
    var sText = document.getElementById(txtBox).value;
    var charCode = (evt.which) ? evt.which : event.keyCode;
    var Dot_Pos = sText.indexOf(".");
    if (charCode < 58 && charCode > 47) {
        if (Dot_Pos < 1) {//no dot,add number
            bRet = true;
        }
        else {//previous dot exist
            if ((sText.length - Dot_Pos) > 2) {
                bRet = false;
            }
            else {
                bRet = true;
            }
        }
    }
    else if (charCode == 46) {
        if (Dot_Pos < 1) {
            bRet = true;
        }
        else {//previous dot exist
            bRet = false;
        }
    }
    else {
        bRet = false;
    }
    return bRet
}

function onlyNumbersWithDot(e) {
    var charCode;
    if (e.keyCode > 0) {
        charCode = e.which || e.keyCode;
    }
    else if (typeof (e.charCode) != "undefined") {
        charCode = e.which || e.keyCode;
    }
    if (charCode == 46)
        return true
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;
    return true;
}

function numericOnly(elementRef) {
    var keyCodeEntered = (event.which) ? event.which : (window.event.keyCode) ? window.event.keyCode : -1;

    // Un-comment to discover a key that I have forgotten to take into account...
    //alert(keyCodeEntered);

    if ((keyCodeEntered >= 48) && (keyCodeEntered <= 57)) {
        return true;
    }
        // '+' sign...
    else if (keyCodeEntered == 43) {
        // Allow only 1 plus sign ('+')...
        if ((elementRef.value) && (elementRef.value.indexOf('+') >= 0))
            return false;
        else
            return true;
    }
        // '-' sign...
    else if (keyCodeEntered == 45) {
        // Allow only 1 minus sign ('-')...
        if ((elementRef.value) && (elementRef.value.indexOf('-') >= 0))
            return false;
        else
            return true;
    }
        // '.' decimal point...
    else if (keyCodeEntered == 46) {
        // Allow only 1 decimal point ('.')...
        if ((elementRef.value) && (elementRef.value.indexOf('.') >= 0))
            return false;
        else
            return true;
    }

    return false;
}



//.ajax__calendar_inactive  {color:#dddddd;}

//        //ADD DATE RANGE FEATURE JAVASCRIPT TO OVERRIDE CALENDAR.JS--%>
//        var minDate = new Date('<%= valDateMustBeWithinMinMaxRange.MinimumValue %>');
//        var maxDate = new Date('<%= valDateMustBeWithinMinMaxRange.MaximumValue %>');
//        Sys.Extended.UI.CalendarBehavior.prototype._button_onblur_original = Sys.Extended.UI.CalendarBehavior.prototype._button_onblur;
//        
//        //override the blur event so calendar doesn't close
//        Sys.Extended.UI.CalendarBehavior.prototype._button_onblur = function (e) {
//            if (!this._selectedDateChanging) {
//                this._button_onblur_original(e);
//            }
//        }
//        
//        Sys.Extended.UI.CalendarBehavior.prototype._cell_onclick_original = Sys.Extended.UI.CalendarBehavior.prototype._cell_onclick;
//        
//        //override the click event
//        Sys.Extended.UI.CalendarBehavior.prototype._cell_onclick = function (e) {
//            var selectedDate = e.target.date;

//            if (selectedDate < minDate || selectedDate > maxDate ) {
//                //alert('Do nothing. You can\'t choose that date.');
//                this._selectedDateChanging = false;
//                return;
//            }

//            this._cell_onclick_original(e);
//        }

//        Sys.Extended.UI.CalendarBehavior.prototype._getCssClass_original = Sys.Extended.UI.CalendarBehavior.prototype._getCssClass;
//        
//        Sys.Extended.UI.CalendarBehavior.prototype._getCssClass = function (date, part) {
//            var selectedDate = date;

//           if (selectedDate < minDate || selectedDate > maxDate ) {
//                return "ajax__calendar_inactive";
//            }
//            this._getCssClass_original(date, part);
//        }


function ValidateDateRange(fromDate, toDate) {

    var intFlag = 0;
    var strErrMsg = "Please complete the following field(s):\n\n";

    var dtFrom = document.getElementById(fromDate).value; // tbDate = name of text box
    var dtTo = document.getElementById(toDate).value; // tbDate = name of text box
    //var currentDate= getCalendarDate()

    if (dtFrom > dtTo) {
        strErrMsg = strErrMsg + "Invalid date range selected \n\nPlease select correct date range.\nThank you.";
        intFlag++;
    }

    // Display error message if a field is not completed
    if (intFlag != 0) {
        alert(strErrMsg);
        return false;
    }
    else
        return true;
}

function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if (charCode > 31 && (charCode < 46 || charCode > 57)) {
        return false;
    }
    else if (charCode == 47) {
        return false;
    }
    else {
        return true;
    }
}

function isKeyOnPress(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;

    return false;
}

function RerouteIP(LineManager)
{
    if(LineManager.value == -1)
     return alert("Line Team Lead not selected.");
}

function newWindow(msg) 
{	
    var newWindow =window.open("","","HEIGHT=400,WidTH=500,alwaysRaised")
    var newContent = "<html><title>Investment Proposal Help</title><body bgcolor=#CCCCCC>"
    newContent += msg
    newContent += "<FORM><INPUT TYPE='button' VALUE='OK'"
    newContent += "onClick='self.close()'></FORM></BODY></HTML>"
    newWindow.document.write(newContent)
    newWindow.document.close()    
}

function rndnum(num)
{
	var dec = 2;
	var result = Math.round(num*Math.pow(10,dec))/Math.pow(10,dec);
	return result;
}

function trimReviewers()
{
    //dir	
    boxlen=dir.options.length;
    for(i=0;i<=boxlen;++i)
    {
	    dir.options.remove(i);				
    }
	
    for(i=0;i<=dirers.options.length-1;++i)
    {
    //		if(dirers[i].value==selid){
        if(SS.value >= 2.0)
        {
		    if(dirers[i+1].text=="MD")
		    {
			    var newElem = document.createElement("option");
				newElem.text = dirers[i].text;
				newElem.value = dirers[i+1].value;
				dir.options.add(newElem,i);					
			}
		}
		else
		{
		    var newElem1 = document.createElement("option");
			newElem1.text = dirers[i].text;
			newElem1.value = dirers[i+1].value;
			dir.options.add(newElem1,i);
		}			
    }
}

function textboxMultilineMaxNumber(txt,maxLen)
{   
    try
    {   
      if(txt.value.length > (maxLen-1))
            return false;   
     }catch(e)
     {   
     
     }
 }

 function displayBOMRow(therow) {
     if (therow.style.display == 'none') {
         therow.style.display = 'block'; 
     }
     else {
         therow.style.display == 'none'; 
     }
 }

 function hideBOMRow(therow) {
     if (therow.style.display == 'block') {
         therow.style.display = 'none';
     }
     else {
         therow.style.display == 'block';
     }
 }
 
 function disptblrow(therow) 
 {
     if (therow.style.display == 'none') { therow.style.display = 'block'; }
     //else { therow.style.display = 'none'; }
     if (therow.style.display == 'block') { therow.style.display = 'block'; }
 }

function disptr(thebutton, therow1, therow2, SaveButton, RegionSaveButton)
{
    if (therow1.style.display=='none') { therow1.style.display='block'; }
    if (therow2.style.display=='none') {  therow2.style.display='block';}
    if (SaveButton.style.display=='block') { SaveButton.style.display='none';}
    if (RegionSaveButton.style.display=='none') {  RegionSaveButton.style.display='block';}
}
    
function undisptr(thebutton, therow1, therow2, SaveButton, RegionSaveButton)
{
    if (therow1.style.display=='block') { therow1.style.display='none'; }
    if (therow2.style.display=='block') { therow2.style.display='none'; }
    if (SaveButton.style.display=='none') { SaveButton.style.display='block'; }
    if (RegionSaveButton.style.display=='block') {  RegionSaveButton.style.display='none'; }
}

function PopupWindow(sUrl)
{
    //    var width = 600;
    //    var height = 1200;
    //    var left = parseInt((screen.availWidth/2) - (width/2));
    //    var top = parseInt((screen.availHeight/2) - (height/2));
    //    var windowFeatures = "modal = true, toolbar = no, width = " + width + ", height = " + height + ", resizable = no, scrollbars = yes, left = " + left + ", top = " + top + ", screenX = " + left + ", screenY = " + top;
    //    modal, toolbar = false, 
    //    window.open(sUrl, "MyWindowForm", windowFeatures); 
    
    //var ht = document.getElementsByTagName("html");
    //ht[0].style.filter="progid:DXImageTransform.Microsoft.BasicImage(grayscale=1)";

    //window.focus();
    
    window.open(sUrl, "MyWindowForm", "toolbar = no, scrollbars = yes, titlebar = yes, resizable = no, width=550, height=230");
}


var popupWindow = null;
function CenteredPopup(url, winName, w, h, scroll) {
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
    settings = 'height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',titlebar = yes,resizable = no'
    popupWindow = window.open(url, winName, settings)

}

function fnRandom(iModifier){
   return parseInt(Math.random()*iModifier);
}

function fnSetValues(oHeight) {
   var iHeight=oForm.oHeight.options[
      oForm.oHeight.selectedIndex].text;
   if(iHeight.indexOf("Random")>-1){
      iHeight=fnRandom(document.body.clientHeight);
   }
   var sFeatures="dialogHeight: " + iHeight + "px;";
   return sFeatures;}

function fnOpen(url, oHeight) {
    var sFeatures = fnSetValues(oHeight);
    window.showModalDialog(url, "", sFeatures)
}
      


function PopupDigitalSignWindow(MyURL)
{
    var width = 600;
    var height = 550;
    var left = parseInt((screen.availWidth/2) - (width/2));
    var top = parseInt((screen.availHeight/2) - (height/2));
    var windowFeatures = "width=" + width + "px, height=" + height + "px, status, resizable, scrollbars=yes, left=" + left + ", top=" + top + "screenX=" + left + "'screenY=" + top;
    //modal, toolbar = false, 
    window.open(MyUrl, "MyWindowForm", windowFeatures);   
}


function closeWindow()
{
    //window.opener.document.forms(0).submit();
    self.close();
}

function refreshPopupWindow()
{
    self.document.forms(0).submit();
}


// Amazing Frameless Popup Window - Version I
// (C) 2000 www.CodeLifter.com
// Free for all users, but leave in this  header

// set the popup window width and height

var windowW=214 // wide
var windowH=398 // high

// set the screen position where the popup should appear

var windowX = 260 // from left
var windowY = 100 // from top

// set the url of the page to show in the popup

//var urlPop = "yourpage.html"

// set the title of the page

//var title =  "This Is A Frameless Popup Window"

// set this to true if the popup should close
// upon leaving the launching page; else, false

var autoclose = false

// ============================
// do not edit below this line
// ============================

s = "width="+windowW+",height="+windowH;
var beIE = document.all?true:false

function openFrameless(urlPop, title){
  if (beIE){
    NFW = window.open("","popFrameless","fullscreen,"+s)     
    NFW.blur()
    window.focus()       
    NFW.resizeTo(windowW,windowH)
    NFW.moveTo(windowX,windowY)
    var frameString=""+
"<html>"+
"<head>"+
"<title>"+title+"</title>"+
"</head>"+
"<frameset rows='*,0' framespacing=0 border=0 frameborder=0>"+
"<frame name='top' src='"+urlPop+"' scrolling=auto>"+
"<frame name='bottom' src='about:blank' scrolling='no'>"+
"</frameset>"+
"</html>"
    NFW.document.open();
    NFW.document.write(frameString)
    NFW.document.close()
  } else {
    NFW=window.open(urlPop,"popFrameless","scrollbars,"+s)
    NFW.blur()
    window.focus() 
    NFW.resizeTo(windowW,windowH)
    NFW.moveTo(windowX,windowY)
  }   
  NFW.focus()   
  if (autoclose){
    window.onunload = function(){NFW.close()}
  }
}


function pickDate(Src) {
    window.open("DatePicker.aspx?src=" + Src, "_blank",
                "height=260, width=250, left=100, top=100, " +
                "location=no, menubar=no, resizeable=no, " +
                "scrollbars=no, titlebar=no, toolbar=no", true);
}

function refresh() {

    window.location.reload();
}



function validateDecimal(sender) {
    if (sender.value.match(/^(\d+)?\.\d$/))
        return true;
    //alert("YES");  Approval, No Message Required /^[+-]?(?:\d+\,?\d*|\d*\.?\d+)[\r\n]*$/
    else
        alert("There is an illegal character in your entry. Please enter decimal number only.");  //Can output a friendly message to the user here 
}
function checkForSecondDecimal(sender, e) {
    formatBox = document.getElementById(sender.id);
    strLen = sender.value.length;
    strVal = sender.value;
    hasDec = false;
    e = (e) ? e : (window.event) ? event : null;

    if (e) {
        var charCode = (e.charCode) ? e.charCode :
                            ((e.keyCode) ? e.keyCode :
                            ((e.which) ? e.which : 0));

        if ((charCode == 46) || (charCode == 110) || (charCode == 190)) {
            for (var i = 0; i < strLen; i++) {
                hasDec = (strVal.charAt(i) == '.');
                if (hasDec)
                    return false;
            }
        }
    }
    return true;
}