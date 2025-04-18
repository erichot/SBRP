

const jsHtmlImgForSelect = "<img src='/css/icon/refresh.png' class='imgSelectWithRefresh' title='選擇清單項目時，將自動篩選並載入明細資料' />";
const jsUI_FullDateFormat = 'DD-MM-YYYY-MM';


const jsUI_ColumnLabel_IsDisabled = 'Inactive';

const jsUI_DisplayName_IsDisabledEnum_Disabled = 'Inactive';
const jsUI_DisplayName_IsDisabledEnum_Enabled = 'Active';



function JS_fnNotification_Show(_msg) {
    kdLayNotification.show(_msg);
};


function JS_fnFormatDateToString(_date) {
    //return Date().toLocaleDateString('en-us').toString();
    //return (new Date.parse(_date)).toLocaleDateString('en-US');
    if (_date == null) return '';
    return new Date(_date).toLocaleDateString('en-MY');
};
function JS_fnFormatDateToFullDateTimeString(_date) {
    if (_date == null) return '';
    return new Date(_date).toLocaleString('en-MY');
};
function JS_fnFormatDateToShortDateString(_date) {
    if (_date == null) return '';
    return moment(_date).format('DD-MM-YY');
};

function JS_fnGeneralAjaxErrorDisplayMessageHtml(jqXHR, textStatus, errorThrown) {


    var msg = "API發生例外（" + jqXHR.status + "）：";

    switch (jqXHR.status) {
        // 資料重複
        case 409:
            msg = jqXHR.responseText.replace(/\n/g, "<br />");
            break;

        default:
            msg += "" + jqXHR.responseText.replace(/\n/g, "<br />")
                + "<br/>[readyState]=" + jqXHR.readyState
                + "<br/>[statusText]=" + jqXHR.statusText
                + "<br/>[textStatus]=" + textStatus;
    }


    return msg;
};







function JS_fnBtnBackFromEntityProcess_Hide() {
    $('#btnBackFromEntityProcess').hide();
};





function JS_fnBtnShowSpinner(_this) {
    // your code to make the spinner start
    //var _this = $("#" + _elementID);
    var existingHTML = $(_this).html()
    var _btnText = 'loading...';
    $(_this).html(_btnText + '&nbsp;&nbsp;&nbsp;<div class="spinner-border"></div>');

    //setTimeout(function () {
    //        $(_this).html(existingHTML).prop('disabled', false) //show original HTML and enable
    //    }, 3000) //3 seconds
    return true;
};







function jsPageLoading_Show() {
    $('.pgloadarea').show();
};
function jsPageLoading_FadeOut(value) {
    $('.pgloadarea').show();
    $('.pgloadarea').fadeOut(value);
};
function jsPageLoading_Close() {
    $('.pgloadarea').fadeOut(500);
};
window.onload = (event) => {
    $('.pgloadarea').fadeOut(500);
};
$(window).blur(function () {
    $('.pgloadarea').fadeOut(500);
});













//HTML multiple column drop down with adjusted columns
//<select name="timezones" id="timezones">
//    <option value="1">Pacific/Auckland +12:00 </option>
//    <option value="2">Australia/Brisbane +10:00 </option>
//    <option value="3">Aust +10:00 </option>
//    <option value="3">A +10:00 </option>
//</select>
//var spacesToAdd = 5;
//var biggestLength = 0;
//$("#timezones option").each(function () {
//    var len = $(this).text().length;
//    if (len > biggestLength) {
//        biggestLength = len;
//    }
//});
//var padLength = biggestLength + spacesToAdd;
//$("#timezones option").each(function () {
//    var parts = $(this).text().split('+');
//    var strLength = parts[0].length;
//    for (var x = 0; x < (padLength - strLength); x++) {
//        parts[0] = parts[0] + ' ';
//    }
//    $(this).text(parts[0].replace(/ /g, '\u00a0') + '+' + parts[1]).text;
//});