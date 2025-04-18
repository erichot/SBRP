// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//const JS_DateFormat = 'YYYY-MM-DD';





$("input[type='text']").focus(function (e) {
    this.select();
});





function renameKey(obj, oldKey, newKey) {
    obj["data"] = obj["data"][oldKey];
    delete obj["data"][oldKey];
};







function JS_InputText_OnInput(inputText) {

    if (inputText.maxLength > 0)
        inputText.value = inputText.value.slice(0, inputText.maxLength)
};







// ===========================================================
function JS_fnIsNumeric(_val) {
    return /^-?\d+$/.test(_val);
};




function JS_fnIsDate(_val) {
    var bits;
    var d;
    if (_val.includes("-")) {
        bits = _val.split('-');
        d = new Date(bits[0] + '-' + bits[1] + '-' + bits[2]);
    }
    else {
        bits = _val.split('/');
        d = new Date(bits[0] + '/' + bits[1] + '/' + bits[2]);
    }
    //console.log("bits=" + bits + " ;d=" + d);
    return !!(d && (d.getMonth() + 1) == bits[1] && d.getDate() == Number(bits[2]));
    //const moment = require('moment');
    //return moment.isDate(_val);
};





// ===========================================================
function JS_fnParseNumber(strg) {
    if (JS_fnIsNumeric(strg) == false) return 0;
    var strg = strg || "";
    var decimal = '.';
    strg = strg.toString().replace(/[^0-9$.,]/g, '');
    if (strg.indexOf(',') > strg.indexOf('.')) decimal = ',';
    if ((strg.match(new RegExp("\\" + decimal, "g")) || []).length > 1) decimal = "";
    if (decimal != "" && (strg.length - strg.indexOf(decimal) - 1 == 3) && strg.indexOf("0" + decimal) !== 0) decimal = "";
    strg = strg.replace(new RegExp("[^0-9$" + decimal + "]", "g"), "");
    strg = strg.replace(',', '.');
    return parseFloat(strg);
};


function JS_fnConvertToDate(inputText) {
    if (inputText == "")
        return null;

    // A number representing the milliseconds elapsed since January 1, 1970, 00:00:00 UTC
    var result = Date.parse(inputText);
    if (isNaN(result))
        return null;
    else
        return inputText;
};



function JS_fnConvertToBoolean(inputText) {
    if (inputText == null || inputText == "")
        return null;

    if (inputText == "false" || inputText == "False"  || inputText == "0")
        return false;

    return Boolean(inputText);
};





function JS_fnIsNullOrUndefined(value) {
    return value === undefined || value === null;
};




function JS_fnLeft(str, num) {
    return str.substring(0, num)
};


function JS_fnRight(str, num) {
    return str.substring(str.length - num, str.length)
};











function JS_fnCopyInputValueAbbr(_sourceInput, _targetInput) {
    if (_sourceInput instanceof HTMLInputElement && _targetInput instanceof HTMLInputElement) {
        if (_sourceInput.value != "" && _targetInput.value.trim() == "") {
            _targetInput.value = _sourceInput.value.substring(0, JS_INPUT_NameAbbr_MaxLength);
        }
    } else {
        console.error('Both parameters should be INPUT elements.');
    }
};


function JS_fnCopyInputValueTextClone(_sourceInput, _targetInput) {
    if (_sourceInput instanceof HTMLInputElement && _targetInput instanceof HTMLInputElement) {
        if (_sourceInput.value != "" && _targetInput.value.trim() == "") {
            _targetInput.value = _sourceInput.value;
        }
    } else {
        console.error('Both parameters should be INPUT elements.');
    }
};