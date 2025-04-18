

const jsHtmlImgForSelect = "<img src='/css/icon/refresh.png' class='imgSelectWithRefresh' title='選擇清單項目時，將自動篩選並載入明細資料' />";
const jsUI_FullDateFormat = 'DD-MM-YYYY-MM';


const jsUI_ColumnLabel_IsDisabled = 'Inactive';

const jsUI_DisplayName_IsDisabledEnum_Disabled = 'Inactive';
const jsUI_DisplayName_IsDisabledEnum_Enabled = 'Active';


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







