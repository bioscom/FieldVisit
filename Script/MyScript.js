//Disables back button
window.history.forward(1);


function DeleteProject() {
    
    if (confirm('Are you sure you want to delete this project?')) {
        return true;
    }
    else {
        return false;
    }
}


function HideShowDiv(divid) {
    var divlayer = document.getElementById(divid);
    if (divlayer.style.display == "block") {
        divlayer.style.display = "none";
    }
    else
        divlayer.style.display = "block"
}

function ChangeBg(tdid) {
    var td = document.getElementById(tdid);
    td.style.background = "#3399ff";
    td.style.color = "white";
}

function ReturnBg(tdid) {
    var td = document.getElementById(tdid);
    td.style.background = "white";
    td.style.color = "black";
}

//Logout Message
function LogoutMessage() {
    var ht = document.getElementsByTagName("html");
    ht[0].style.filter = "progid:DXImageTransform.Microsoft.BasicImage(grayscale=1)";
    if (confirm('Are you sure you want to log out?')) {

        window.opener = self;
        window.close();
        return true;
    }
    else {
        ht[0].style.filter = "";
        return false;
    }
}

function backButton() {

    window.history.back()
}

function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : evt.keyCode
    if (charCode > 31 && (charCode < 45 || charCode > 57)) {
        return false;
    }
    else if (charCode == 47) {
        return false;
    }
    else {
        return true;
    }
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

//Delete DeleteRequest
function DeleteRequest(Request) {
    if (confirm('Are you sure you want to delete ' + Request + ' Request? \nNote that any Request deleted, will be permanently removed from the system. \nConfirm Delete?')) {
        return true;
    }
    else {
        return false;
    }
}

//Delete Project
function CancelRequest(Request) {
    if (confirm('Are you sure you want to Cancel ' + Request + ' Request?')) {
        return true;
    }
    else {
        return false;
    }
}

function newWindow(msg) {
    var newWindow = window.open("", "", "HEIGHT=400,WidTH=500,alwaysRaised")

    var newContent = "<html><title>Flare Waiver Control</title><body bgcolor=#CCCCCC>"
    newContent += msg
    newContent += "<FORM><INPUT TYPE='button' VALUE='OK'"
    newContent += "onClick='self.close()'></FORM></BODY></HTML>"

    newWindow.document.write(newContent)
    newWindow.document.close()
}

var popupWindow = null;
function CenteredPopup(url, winName, w, h, scroll) {
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
    settings = 'height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',titlebar = yes,resizable = no'
    popupWindow = window.open(url, winName, settings)

}

function PopupDigitalSignWindow(MyURL) {
    var width = 600;
    var height = 550;
    var left = parseInt((screen.availWidth / 2) - (width / 2));
    var top = parseInt((screen.availHeight / 2) - (height / 2));
    var windowFeatures = "width=" + width + "px, height=" + height + "px, status, resizable, scrollbars=yes, left=" + left + ", top=" + top + "screenX=" + left + "'screenY=" + top;
    //modal, toolbar = false, 
    window.open(MyUrl, "MyWindowForm", windowFeatures);
}


function closeWindow() {
    //window.opener.document.forms(0).submit();
    self.close();
}

function refreshPopupWindow() {
    self.document.forms(0).submit();
}
