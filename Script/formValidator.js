// JScript File
function isMoneyNumbKey(evt,txtBox){
    var bRet=false;
    var sText =document.getElementById(txtBox).value;
    var charCode = (evt.which) ? evt.which : event.keyCode;
    var Dot_Pos=sText.indexOf(".");
    if (charCode < 58 && charCode > 47){    
        if (Dot_Pos < 1){//no dot,add number
            bRet= true;
        }
        else{//previous dot exist
            if ((sText.length - Dot_Pos) > 2){
                bRet= false;
            }
            else{
                bRet= true;
            }                
        }            
    }
    else if (charCode == 46){
        if (Dot_Pos < 1){
            bRet= true;
        }
        else{//previous dot exist
            bRet= false;
        }
    }
    else{
        bRet= false;
    }
    return bRet
}
//convert naira & dollar OPEX value to functional value
function convertToFuncValue(t_Naira,t_Dollar,t_Functn,gRate){
        var gNaira =document.getElementById(t_Naira).value;
        var gDollar =document.getElementById(t_Dollar).value;
        var sRate;
        sRate=0;
        if (gNaira!=''){
            sRate=roundNumb(parseFloat(gNaira/gRate),2);
            //sRate=Math.round(100 * parseFloat(gNaira/gRate))/100;
        }
        if (gDollar!=''){
            sRate=parseFloat(gDollar) + parseFloat(sRate);
        }
        document.getElementById(t_Functn).value=sRate;
}    
//12 months phasing
function verifyMonthValues(gTotal,txt1,txt2,txt3,txt4,txt5,txt6,txt7,txt8,txt9,txt10,txt11,txt12){
    var bRet=false;
    var gSum = new Number(0);
    var sText =0;
    sText =document.getElementById(txt1).value;
    if (sText.length>0){gSum= gSum+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txt2).value;
    if (sText.length>0){gSum= gSum+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txt3).value;
    if (sText.length>0){gSum= gSum+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txt4).value;
    if (sText.length>0){gSum= gSum+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txt5).value;
    if (sText.length>0){gSum= gSum+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txt6).value;
    if (sText.length>0){gSum= gSum+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txt7).value;
    if (sText.length>0){gSum= gSum+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txt8).value;
    if (sText.length>0){gSum= gSum+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txt9).value;
    if (sText.length>0){gSum= gSum+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txt10).value;
    if (sText.length>0){gSum= gSum+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txt11).value;
    if (sText.length>0){gSum= gSum+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txt12).value;
    if (sText.length>0){gSum= gSum+roundNumb(parseFloat(sText),2)};
    if (roundNumb(gSum,2)==roundNumb(gTotal,2)){
        bRet=true
    }
    else{
        alert('Total F"$000 MUST BE $' + gTotal)
    };
    return bRet;
}
function verifyPhaseValues(gTotal,gSumNar,txtNar1,txtNar2,txtNar3,txtNar4,txtNar5,txtNar6,txtNar7,txtNar8,txtNar9,txtNar10,txtNar11,txtNar12,gSumDol,txtDol1,txtDol2,txtDol3,txtDol4,txtDol5,txtDol6,txtDol7,txtDol8,txtDol9,txtDol10,txtDol11,txtDol12){
    var bRet=false;
    var gAll_Nar = new Number(0);
    var gAll_Dol = new Number(0);
    var sText =0;
    sText =document.getElementById(txtNar1).value;
    if (sText.length>0){gAll_Nar= gAll_Nar+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txtNar2).value;
    if (sText.length>0){gAll_Nar= gAll_Nar+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txtNar3).value;
    if (sText.length>0){gAll_Nar= gAll_Nar+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txtNar4).value;
    if (sText.length>0){gAll_Nar= gAll_Nar+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txtNar5).value;
    if (sText.length>0){gAll_Nar= gAll_Nar+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txtNar6).value;
    if (sText.length>0){gAll_Nar= gAll_Nar+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txtNar7).value;
    if (sText.length>0){gAll_Nar= gAll_Nar+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txtNar8).value;
    if (sText.length>0){gAll_Nar= gAll_Nar+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txtNar9).value;
    if (sText.length>0){gAll_Nar= gAll_Nar+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txtNar10).value;
    if (sText.length>0){gAll_Nar= gAll_Nar+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txtNar11).value;
    if (sText.length>0){gAll_Nar= gAll_Nar+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txtNar12).value;
    if (sText.length>0){gAll_Nar= gAll_Nar+roundNumb(parseFloat(sText),2)};
    
    sText =document.getElementById(txtDol1).value;
    if (sText.length>0){gAll_Dol= gAll_Dol+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txtDol2).value;
    if (sText.length>0){gAll_Dol= gAll_Dol+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txtDol3).value;
    if (sText.length>0){gAll_Dol= gAll_Dol+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txtDol4).value;
    if (sText.length>0){gAll_Dol= gAll_Dol+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txtDol5).value;
    if (sText.length>0){gAll_Dol= gAll_Dol+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txtDol6).value;
    if (sText.length>0){gAll_Dol= gAll_Dol+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txtDol7).value;
    if (sText.length>0){gAll_Dol= gAll_Dol+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txtDol8).value;
    if (sText.length>0){gAll_Dol= gAll_Dol+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txtDol9).value;
    if (sText.length>0){gAll_Dol= gAll_Dol+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txtDol10).value;
    if (sText.length>0){gAll_Dol= gAll_Dol+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txtDol11).value;
    if (sText.length>0){gAll_Dol= gAll_Dol+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txtDol12).value;
    if (sText.length>0){gAll_Dol= gAll_Dol+roundNumb(parseFloat(sText),2)};

    if (roundNumb(gAll_Nar,2)==roundNumb(gSumNar,2) && roundNumb(gAll_Dol,2)==roundNumb(gSumDol,2)){
        bRet=true
    }
    else{
        alert('Total F"$000 MUST BE $' + gTotal)
    };
    return bRet;
}
//reamining value as opex phasing decreases
function calculateRemainValueXX(txtBox,txtRemain){  
    var gPot = new Number(document.getElementById(txtRemain).value);
    var gThis = new Number(0);
    var sText =document.getElementById(txtBox).value;
    if (sText.length>0){gThis = Number(sText)};
    gPot-=gThis;
    document.getElementById(txtRemain).value=gPot;
}
function calculateRemainValue(gTotal,txt1,txt2,txt3,txt4,txt5,txt6,txt7,txt8,txt9,txt10,txt11,txt12,txtRemain){
    var gSum = new Number(0);
    var sText =0;
    sText =document.getElementById(txt1).value;
    if (sText.length>0){gSum= gSum+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txt2).value;
    if (sText.length>0){gSum= gSum+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txt3).value;
    if (sText.length>0){gSum= gSum+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txt4).value;
    if (sText.length>0){gSum= gSum+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txt5).value;
    if (sText.length>0){gSum= gSum+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txt6).value;
    if (sText.length>0){gSum= gSum+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txt7).value;
    if (sText.length>0){gSum= gSum+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txt8).value;
    if (sText.length>0){gSum= gSum+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txt9).value;
    if (sText.length>0){gSum= gSum+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txt10).value;
    if (sText.length>0){gSum= gSum+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txt11).value;
    if (sText.length>0){gSum= gSum+roundNumb(parseFloat(sText),2)};
    sText =document.getElementById(txt12).value;
    if (sText.length>0){gSum= gSum+roundNumb(parseFloat(sText),2)};
    
    document.getElementById(txtRemain).value=roundNumb(parseFloat(gTotal)-gSum,2);
}
function roundNumb(gNumb,tDp){
    var gRet=Math.round(gNumb * Math.pow(10,tDp))/Math.pow(10,tDp);
    return gRet;
}    
function sumCommon34Values(t_Naira,t_Dollar,t_Functn,t_SumNaira,t_SumDollar,t_SumFunctn,gRate,t_TextBox_1,t_TextBox_2,t_TextBox_3,t_TextBox_4,t_TextBox_5,t_TextBox_6,t_TextBox_7,t_TextBox_8,t_TextBox_9,t_TextBox_10,t_TextBox_11,t_TextBox_12,t_TextBox_13,t_TextBox_14,t_TextBox_15,t_TextBox_16,t_TextBox_17,t_TextBox_18,t_TextBox_19,t_TextBox_20,t_TextBox_21,t_TextBox_22,t_TextBox_23,t_TextBox_24,t_TextBox_25,t_TextBox_26,t_TextBox_27,t_TextBox_28,t_TextBox_29,t_TextBox_30,t_TextBox){
        //process current functional value
        var gNaira =document.getElementById(t_Naira).value;
        var gDollar =document.getElementById(t_Dollar).value;
        var sRate;
        sRate=0;
        if (gNaira!=''){
            sRate=roundNumb(parseFloat(gNaira/gRate),2);
            //sRate=Math.round(100 * parseFloat(gNaira/gRate))/100;
        }
        if (gDollar!=''){
            sRate=parseFloat(gDollar) + parseFloat(sRate);
        }
        document.getElementById(t_Functn).value=sRate;
        //process sum values
        var gRet =0
        var gTextBox =0;
        if (document.getElementById(t_TextBox_1) != null){
            gTextBox =document.getElementById(t_TextBox_1).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_2) != null){
            gTextBox =document.getElementById(t_TextBox_2).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_3) != null){
            gTextBox =document.getElementById(t_TextBox_3).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_4) != null){
            gTextBox =document.getElementById(t_TextBox_4).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_5) != null){
            gTextBox =document.getElementById(t_TextBox_5).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_6) != null){
            gTextBox =document.getElementById(t_TextBox_6).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_7) != null){
            gTextBox =document.getElementById(t_TextBox_7).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_8) != null){
            gTextBox =document.getElementById(t_TextBox_8).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_9) != null){
            gTextBox =document.getElementById(t_TextBox_9).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_10) != null){
            gTextBox =document.getElementById(t_TextBox_10).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_11) != null){
            gTextBox =document.getElementById(t_TextBox_11).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_12) != null){
            gTextBox =document.getElementById(t_TextBox_12).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_13) != null){
            gTextBox =document.getElementById(t_TextBox_13).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_14) != null){
            gTextBox =document.getElementById(t_TextBox_14).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_15) != null){
            gTextBox =document.getElementById(t_TextBox_15).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_16) != null){
            gTextBox =document.getElementById(t_TextBox_16).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_17) != null){
            gTextBox =document.getElementById(t_TextBox_17).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_18) != null){
            gTextBox =document.getElementById(t_TextBox_18).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_19) != null){
            gTextBox =document.getElementById(t_TextBox_19).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_20) != null){
            gTextBox =document.getElementById(t_TextBox_20).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_21) != null){
            gTextBox =document.getElementById(t_TextBox_21).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_22) != null){
            gTextBox =document.getElementById(t_TextBox_22).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_23) != null){
            gTextBox =document.getElementById(t_TextBox_23).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_24) != null){
            gTextBox =document.getElementById(t_TextBox_24).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_25) != null){
            gTextBox =document.getElementById(t_TextBox_25).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_26) != null){
            gTextBox =document.getElementById(t_TextBox_26).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_27) != null){
            gTextBox =document.getElementById(t_TextBox_27).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_28) != null){
            gTextBox =document.getElementById(t_TextBox_28).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_29) != null){
            gTextBox =document.getElementById(t_TextBox_29).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_30) != null){
            gTextBox =document.getElementById(t_TextBox_30).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        document.getElementById(t_TextBox).value=gRet;
        
        //process current functional value
        var gNaira2 =document.getElementById(t_SumNaira).value;
        var gDollar2 =document.getElementById(t_SumDollar).value;
        //alert(gNaira2);
        //alert(gDollar2)
        var sRate2;
        sRate2=0;
        if (gNaira2!=''){
            sRate2=roundNumb(parseFloat(gNaira2/gRate),2);
        }
        if (gDollar2!=''){
            sRate2=parseFloat(gDollar2) + parseFloat(sRate2);
        }
        document.getElementById(t_SumFunctn).value=sRate2;        
}    
function sumCommon30Values(t_TextBox_1,t_TextBox_2,t_TextBox_3,t_TextBox_4,t_TextBox_5,t_TextBox_6,t_TextBox_7,t_TextBox_8,t_TextBox_9,t_TextBox_10,t_TextBox_11,t_TextBox_12,t_TextBox_13,t_TextBox_14,t_TextBox_15,t_TextBox_16,t_TextBox_17,t_TextBox_18,t_TextBox_19,t_TextBox_20,t_TextBox_21,t_TextBox_22,t_TextBox_23,t_TextBox_24,t_TextBox_25,t_TextBox_26,t_TextBox_27,t_TextBox_28,t_TextBox_29,t_TextBox_30,t_Sum){
        //process sum values
        var gRet =0
        var gTextBox =0;
        if (document.getElementById(t_TextBox_1) != null){
            gTextBox =document.getElementById(t_TextBox_1).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_2) != null){
            gTextBox =document.getElementById(t_TextBox_2).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_3) != null){
            gTextBox =document.getElementById(t_TextBox_3).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_4) != null){
            gTextBox =document.getElementById(t_TextBox_4).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_5) != null){
            gTextBox =document.getElementById(t_TextBox_5).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_6) != null){
            gTextBox =document.getElementById(t_TextBox_6).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_7) != null){
            gTextBox =document.getElementById(t_TextBox_7).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_8) != null){
            gTextBox =document.getElementById(t_TextBox_8).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_9) != null){
            gTextBox =document.getElementById(t_TextBox_9).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_10) != null){
            gTextBox =document.getElementById(t_TextBox_10).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_11) != null){
            gTextBox =document.getElementById(t_TextBox_11).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_12) != null){
            gTextBox =document.getElementById(t_TextBox_12).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_13) != null){
            gTextBox =document.getElementById(t_TextBox_13).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_14) != null){
            gTextBox =document.getElementById(t_TextBox_14).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_15) != null){
            gTextBox =document.getElementById(t_TextBox_15).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_16) != null){
            gTextBox =document.getElementById(t_TextBox_16).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_17) != null){
            gTextBox =document.getElementById(t_TextBox_17).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_18) != null){
            gTextBox =document.getElementById(t_TextBox_18).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_19) != null){
            gTextBox =document.getElementById(t_TextBox_19).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_20) != null){
            gTextBox =document.getElementById(t_TextBox_20).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_21) != null){
            gTextBox =document.getElementById(t_TextBox_21).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_22) != null){
            gTextBox =document.getElementById(t_TextBox_22).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_23) != null){
            gTextBox =document.getElementById(t_TextBox_23).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_24) != null){
            gTextBox =document.getElementById(t_TextBox_24).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_25) != null){
            gTextBox =document.getElementById(t_TextBox_25).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_26) != null){
            gTextBox =document.getElementById(t_TextBox_26).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_27) != null){
            gTextBox =document.getElementById(t_TextBox_27).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_28) != null){
            gTextBox =document.getElementById(t_TextBox_28).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_29) != null){
            gTextBox =document.getElementById(t_TextBox_29).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        if (document.getElementById(t_TextBox_30) != null){
            gTextBox =document.getElementById(t_TextBox_30).value;
            if (gTextBox.length>0){gRet= gRet+roundNumb(parseFloat(gTextBox),2)};            
        }
        document.getElementById(t_Sum).value=gRet;
    }
    
function reducCommon30Values(gSumFun,gSumBox,txtDisBox,bUseRate,txtBox_1,txtBox_2,txtBox_3,txtBox_4,txtBox_5,txtBox_6,txtBox_7,txtBox_8,txtBox_9,txtBox_10,txtBox_11,txtBox_12,txtRemainBox,txtExe,txtFun,gRate,txtFun_1,txtFun_2,txtFun_3,txtFun_4,txtFun_5,txtFun_6,txtFun_7,txtFun_8,txtFun_9,txtFun_10,txtFun_11,txtFun_12,txtRemainFun){
        calculateRemainValue(gSumBox,txtBox_1,txtBox_2,txtBox_3,txtBox_4,txtBox_5,txtBox_6,txtBox_7,txtBox_8,txtBox_9,txtBox_10,txtBox_11,txtBox_12,txtRemainBox);
        var gRet = new Number(0);
        var gDisTxt= new Number(0);
        var gExeTxt= new Number(0);
        
        if (document.getElementById(txtDisBox) != null){
            gDisTxt =document.getElementById(txtDisBox).value;         
        }
        if (document.getElementById(txtExe) != null){
            gExeTxt =document.getElementById(txtExe).value;         
        }
               
        if (bUseRate=='use#'){
            gRet=roundNumb(parseFloat(gDisTxt/gRate),2) + Number(gExeTxt);
        }
        else if(bUseRate=='$kal'){
            gRet=roundNumb(parseFloat(gExeTxt/gRate),2) + Number(gDisTxt);
        };
        
        document.getElementById(txtFun).value=roundNumb(gRet,2);
        calculateRemainValue(gSumFun,txtFun_1,txtFun_2,txtFun_3,txtFun_4,txtFun_5,txtFun_6,txtFun_7,txtFun_8,txtFun_9,txtFun_10,txtFun_11,txtFun_12,txtRemainFun);
    }

    function calculateMyValues(t_Naira, t_Dollar, t_Count, t_ItemsNo, t_NoOfTimesPerYear, t_SNaira, t_SDollar, t_SFunctn, gRate, hidSNaira, hidSDollar, hidFunctionalDollar) {
        //process current functional value
        var gNaira = document.getElementById(t_Naira).value;
        var gDollar = document.getElementById(t_Dollar).value;
        var gCount = document.getElementById(t_Count).value;
        var gItemsNo = document.getElementById(t_ItemsNo).value;
        var gNoOfTimesPerYear = document.getElementById(t_NoOfTimesPerYear).value;

        var sNRate = 0; //for SN'000 cal
        var sDRate = 0; //for S$'000 cal
        var sFCalc = 0;
        var FcalDollar = 0;
        var FcalNaira = 0;
        
        if (gNaira != '') {
            sNRate = gNaira;
        }        
        if ((gNaira != '') && (gCount != '')) {
            sNRate = parseFloat(gNaira * gCount);
        }
        if ((gNaira != '') && (gCount != '') && (gItemsNo != '')) {
            sNRate = parseFloat(sNRate * gItemsNo);
        }
        if ((gNaira != '') && (gCount != '') && (gItemsNo != '') && (gNoOfTimesPerYear != '')) {
            sNRate = parseFloat(sNRate * gNoOfTimesPerYear);
        }
        document.getElementById(t_SNaira).value = sNRate;
        document.getElementById(hidSNaira).value = sNRate;

        if (gDollar != '') {
            sDRate = gDollar;
        }
        if ((gDollar != '') && (gCount != '')) {
            sDRate = parseFloat(gDollar * gCount);
        }
        if ((gDollar != '') && (gCount != '') && (gItemsNo != '')) {
            sDRate = parseFloat(sDRate * gItemsNo);
        }
        if ((gDollar != '') && (gCount != '') && (gItemsNo != '') && (gNoOfTimesPerYear != '')) {
            sDRate = parseFloat(sDRate * gNoOfTimesPerYear);
        }
        document.getElementById(t_SDollar).value = sDRate;
        document.getElementById(hidSDollar).value = sDRate;

        if ((gNaira != '') && (gDollar != '') && (gCount != '') && (gItemsNo != '') && (gNoOfTimesPerYear != '')) {
            
            FcalNaira = roundNumb(parseFloat(parseFloat(gNaira * gCount * gItemsNo * gNoOfTimesPerYear) / gRate), 2);
            FcalDollar = parseFloat(gDollar * gCount * gItemsNo * gNoOfTimesPerYear);
            sFCalc = parseFloat(FcalNaira + FcalDollar);  
        }

        document.getElementById(t_SFunctn).value = sFCalc;
        document.getElementById(hidFunctionalDollar).value = sFCalc;
    }    

