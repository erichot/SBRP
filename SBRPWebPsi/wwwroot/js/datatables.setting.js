

const _dtDeferLoading = 0;
const _dtIsProcessing = true;

// ColumnDefs 個別欄位設定
const _dtColumnDef_No_Visible = false;
const _dtColumnDef_No_ClassName = 'dt-body-center';
const _dtColumnDef_FKNo_Visible = true;
const _dtColumnDef_FKNo_ClassName = 'dt-body-center';
const _dtColumnDef_Id_ClassName = null;
const _dtColumnDef_EDIT_ClassName = 'dt-body-center';
const _dtColumnDef_EDIT_Width = '4em';
const _dtColumnDef_REMOVE_ClassName = 'dt-body-center';
const _dtColumnDef_REMOVE_Width = '4em';



const _dtPageLengthShort = 5;
const _dtPageLengthMiddle = 10;
const _dtPageLengthLarger = 25;
const _dtPageLength = 10;
const _dtPaging = true;
const _dtPagingType = 'full_numbers';
const _dtLengthMenu = [[5, 10, 25, 50, -1], [5, 10, 25, 50, "ALL"]];

var _dtDom = 'rt' + '<"row"<"col-sm-3 fg-toolbar  ui-widget-header ui-helper-clearfix tfoot"i>' + '<"col-sm-2"l><"col-sm-7 pagination"p>>';

var _dtDomFilter = 'rft' + '<"row"<"col-sm-3 fg-toolbar  ui-widget-header ui-helper-clearfix tfoot"i>' + '<"col-sm-2"l><"col-sm-7 pagination"p>>';
var _dtDomEditor = 'rt' + '<"row"<"col-sm-3 fg-toolbar  ui-widget-header ui-helper-clearfix tfoot"i>' + '<"col-sm-2"l><"col-sm-7 pagination"p>>';
var _dtDomEditorWithExport = 'rt' + '<"row"<"col-sm-2 pt-2 fg-toolbar ui-widget-header ui-helper-clearfix tfoot"i>' + '<"col-sm-2"l><"col-sm-6 pagination"p>' + '<"col-sm-2 text-end"B>>';

//var _dtDomList = 'rt' + '<"row"<"col-sm-2 fg-toolbar   tfoot"i>' + '<"col-sm-2"l>"' + '<"col-sm-6 pagination"p>' + '<"col-sm-2"B>>';
var _dtDomList = 'rt' + '<"row"<"col-sm-2 fg-toolbar  ui-widget-header ui-helper-clearfix tfoot"i>' + '<"col-sm-2"l><"col-sm-6 pagination"p>' + '<"col-sm-2 text-end"B>>';
var _dtDomListFilter = 'rft' + '<"row"<"col-sm-2 fg-toolbar  ui-widget-header ui-helper-clearfix tfoot"i>' + '<"col-sm-2"l><"col-sm-6 pagination"p>' + '<"col-sm-2 text-end"B>>';
var _dtDomReport = 'rt' + '<"row"<"col-sm-2 fg-toolbar   tfoot"i>' + '<"col-sm-2"l>"' + '<"col-sm-6 pagination"p>' + '<"col-sm-2 text-right"B>>';

var _dtDomWithBtnAdd = '"Burt' + '<"row"<"col-sm-3 fg-toolbar  ui-widget-header ui-helper-clearfix tfoot"i>' + '<"col-sm-2"l><"col-sm-7 pagination"p>>';
var _dtDomFilterWithExport = 'rft' + '<"row"<"col-sm-2 fg-toolbar  ui-widget-header ui-helper-clearfix tfoot"i>' + '<"col-sm-2"l><"col-sm-6 pagination"p>' + '<"col-sm-2 text-right"B>>';
var _dtDomFilterWithWidthExport = 'rft' + '<"row"<"col-sm-2 fg-toolbar  ui-widget-header ui-helper-clearfix tfoot"i>' + '<"col-sm-2"l><"col-sm-5 pagination"p>' + '<"col-sm-3 text-right"B>>';

const _dtButonsExcel = ['excel'];
const _dtLoadingRecordsText = "loading please wait";
const _dtLngSelectRows = "";





//const _dtLngZero = "no data or waiting for loading";
const _dtLngZero = "no data or not loading yet";
const _dtLngInfo = "筆數: _MAX_";
const _dtLngInfoFiltered = "Filtered: _TOTAL_.";
const _dtLngEmpty = "無資料（或尚未查詢）";

//const _dtLngLengthMenu = "Page count： _MENU_";
const _dtLngLengthMenu = '每頁筆數 <select class="form-control">' +
    '<option value="10">10</option>' +
    '<option value="20">20</option>' +
    '<option value="30">30</option>' +
    '<option value="50">50</option>' +
    '<option value="100">100</option>' +
    '<option value="500">500</option>' +
    '<option value="1000">1000</option>' +    
    '</select> '
// '<option value="-1">所有</option>' +

const _dtLngPageFirst = "首頁";
const _dtLngPagePrevious = "<<";
const _dtLngPageNext = ">>";
const _dtLngPageLast = "末頁";

//const _dtLngProcessing = '<div style="position:fixed;top:50%;left:50%;"><span style="background-color: white;">載入中請稍等</span><i class="fa fa-spinner fa-spin fa-3x fa-fw"></i></div>';
//const _dtLngProcessing = '<div class="fa-3x"><i class="fas fa-spinner fa-spin"></i></div>';
const _dtLngProcessing = '<i class="fa fa-spinner fa-spin fa-3x fa-fw"></i><span class="sr-only">Loading..n.</span> ';
const _dtLngSearch = "快速篩選";
const _dtLngSearchPlaceholder = "現有明細資料內之字詞";



const _dtBtnCsvText = '<i class="fa fa-file-csv"></i>';
const _dtBtnCsvCss = 'dtExtBtn';
const _dtBtnCsvTitle = 'Export to CSV';

const _dtBtnXlsxText = '<i class="fa fa-file-excel"></i>';
const _dtBtnXlsxCss = 'dtExtBtn';
const _dtWidthBtnXlsxCss = 'dtWidthExtBtn';
const _dtBtnXlsxTitle = 'Export to Excel';

















function JS_fnGeneralAjaxErrorDisplayMessageHtml(jqXHR, textStatus, errorThrown) {


    var msg = "API exception（" + jqXHR.status + "）：";

    switch (jqXHR.status) {
        // ApiStatusCode.NotAcceptable
        case 406:
            msg = "［validation warrning］<br/>"  + jqXHR.responseText.replace(/\n/g, "<br />");
            break;


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