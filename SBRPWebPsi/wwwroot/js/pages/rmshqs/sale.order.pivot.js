
function renderObjectsToTable(objects, target) {

    const uniquePropertyNames = [];
    objects.forEach(obj => {
        for (const prop in obj) {
            if (!uniquePropertyNames.includes(prop))
                uniquePropertyNames.push(prop);
        }
    });

    const header = buildTableHeader(uniquePropertyNames);
    const rows = buildTableBody(uniquePropertyNames, objects);
    const footers = buildTableFooter(uniquePropertyNames);

    const table = document.querySelector(target);
    table.querySelector('thead').append(header);
    table.querySelector('tbody').append(...rows);
    table.querySelector('tfoot').append(footers);
};


function buildTableHeader(propertyNames) {
    var hasRetrieveProductCode = false;
    var isRegistered = false;
    const headerRow = document.createElement('tr');
    let headerCelllProductCode;
    let headerCelllColorID, headerCelllSizeID;
    propertyNames.forEach(prop => {
        const headerCell = document.createElement('th');
        headerCell.innerText = prop;

        if (prop == "ProductCode" || prop == "ProductCodeHead" || prop == "貨號" || prop == "款式") {
            headerCelllProductCode = headerCell;
            headerRow.prepend(headerCelllProductCode);
        }
        else if (prop == "ColorID" || prop == "顏色") {
            headerCelllColorID = headerCell;
            headerRow.insertBefore(headerCell, headerCelllProductCode.nextSibling);
        }
        else if (prop == "SizeID" || prop == "尺寸") {
            headerCelllSizeID = headerCell;
            headerRow.insertBefore(headerCell, headerCelllProductCode.nextSibling);
        }
        else if (prop == "00" || prop == "總店") {
            if (headerCelllColorID != null)
                headerRow.insertBefore(headerCell, headerCelllColorID.nextSibling);
            else if (headerCelllSizeID != null)
                headerRow.insertBefore(headerCell, headerCelllSizeID.nextSibling);
            else
                headerRow.insertBefore(headerCell, headerCelllProductCode.nextSibling);
        }
        else {
            headerRow.append(headerCell);
        }
    });
    return headerRow;
};



function buildTableFooter(propertyNames) {

    const footerRow = document.createElement('tr');

    propertyNames.forEach(prop => {
        const footerCell = document.createElement('th');
        footerCell.innerText = '';
        footerCell.className = "text-end";
        footerRow.append(footerCell);
    });
    return footerRow;
};


function buildTableBody(propertyNames, objects) {
    const tableRows = [];
    let tableCellProductCode;
    let tableCellColorID, tableCellSizeID;
    objects.forEach(obj => {
        //debugger;
        const currentRow = document.createElement('tr');
        propertyNames.forEach(prop => {
            const tableCell = document.createElement('td');
            //debugger;
            const value = (obj[prop] === undefined) ? '' : obj[prop];
            tableCell.innerText = value;

            if (prop == "ProductCode" || prop == "ProductCodeHead" || prop == "貨號" || prop == "款式") {
                tableCellProductCode = tableCell;
                tableCellProductCode.className = "text-nowrap text-start";
                currentRow.prepend(tableCellProductCode);
            } 
            else if (prop == "ColorID" || prop == "顏色") {
                tableCellColorID = tableCell;
                tableCellColorID.className = "text-nowrap text-start";
                currentRow.insertBefore(tableCell, tableCellProductCode.nextSibling);
            }
            else if (prop == "SizeID" || prop == "尺寸") {
                tableCellSizeID = tableCell;
                tableCellSizeID.className = "text-nowrap text-start";
                currentRow.insertBefore(tableCell, tableCellProductCode.nextSibling);
            }
            else if (prop == "00" || prop == "總店") {
                tableCell.className = "text-end";
                if (tableCellColorID != null)
                    currentRow.insertBefore(tableCell, tableCellColorID.nextSibling);
                else if (tableCellSizeID != null)
                    currentRow.insertBefore(tableCell, tableCellSizeID.nextSibling);
                else
                    currentRow.insertBefore(tableCell, tableCellProductCode.nextSibling);
            }
            else {
                tableCell.className = "text-end";
                currentRow.append(tableCell);
            }
        });
        tableRows.push(currentRow);
    });
    return tableRows;
};

//function goWild() {
//    document.querySelector('#target thead').innerHTML = '';
//    document.querySelector('#target tbody').innerHTML = '';
//    const nodes = document.getElementById('wildList').childNodes;
//    renderObjectsToTable(nodes, '#target');
//};












// Start [服務狀態］複選清單：清除全部 -------------------------------------------------
function fnKendoMultiSelect_ClearAll(ID) {
    // 透過傳入ID名稱，取得 Kendo UI MultiSelect物件
    var objMultiSelect = $("#" + ID).data("kendoMultiSelect");

    objMultiSelect.input.val('');         // 清除Input中的篩選文字
    objMultiSelect.value('');             // 清除所有已選取的Checkbox                
    objMultiSelect.trigger('change');
}
// End fnKendoMultiSelect_ClearAll -------------------------------------------------------





// Start 轉換Object to Value array ---------------
function getMultiselectValues(data) {
    var values = new Array();
    if (data[0] != null) {
        for (var i = 0; i < data.length; i++) {
            if (data[i] == null)
                break;
            values[i] = data[i].value;
        }
    }
    return values;
}
// End getMultiselectValues ---------------------

//function OnSuccess(data) {

//    var values_val_EducationSchools = '';
//    $("#multi-select_EducationSchools :selected").each(function (i, sel) {



//        values_val_EducationSchools = values_val_EducationSchools + $(sel).val() + ',';



//    });
//};



//function delete_select(obj) {

//    $("#" + obj + "").remove();
//    var triggertarget = obj.split("select_")[1].split("_")[0];

//    var deletetarget = obj.split("select_EducationSchools_")[1];
//    $("#multi-select_EducationSchools :selected").each(function (i, sel) {
//        if ($(sel).val() == deletetarget) {
//            $('#multi-select_EducationSchools')[0].sumo.unSelectItem($(sel).val());
//        }
//    });
//};


var kdSelectStores;
// Start [服務狀態］複選清單：快速選取已篩選所得之項目 --------------------------------------
function fnKendoMultiSelect_FastSelect(ID) {
    // 透過傳入ID名稱，取得 Kendo UI MultiSelect物件
    var objMultiSelect = $("#" + ID).data("kendoMultiSelect");

    // 取得目前搜尋所得之item
    var objFilteredResult = objMultiSelect.dataSource.view();
    // 轉換已篩選項目的Object 為 Value
    var aryFilteredResultValue = getMultiselectValues(objFilteredResult);


    // 合併原來已選取之項目 + 搜尋所得之項目
    var aryCurrentSelectedValue = objMultiSelect.value();
    var aryNewSelectedValue = $.merge(aryFilteredResultValue, aryCurrentSelectedValue);

    // 將欲選取的項目，指定給kendoMultiSelect
    objMultiSelect.value(aryNewSelectedValue);

    // 由於kmsServiceStatus.value()會造成Filter清單清除，故手動執行search，以維持原有的filter清單畫面
    var strCurrentFilterString = objMultiSelect.input.val();
    objMultiSelect.search(strCurrentFilterString);

    kdSelectStores.close();
};
// End fnKendoMultiSelect_FastSelect -----------------------------------------------------------------------------------



function fnKendoMultiSelect_RevertSelect() {
    // 透過傳入ID名稱，取得 Kendo UI MultiSelect物件
    var objMultiSelect = $("#multi-select_EducationSchools").data("kendoMultiSelect");

    // 取得目前搜尋所得之item
    var objFilteredResult = objMultiSelect.dataSource.view();
    // 轉換已篩選項目的Object 為 Value
    var aryFilteredResultValue = getMultiselectValues(objFilteredResult);


    // 合併原來已選取之項目 + 搜尋所得之項目
    var aryCurrentSelectedValue = objMultiSelect.value();
    var aryNewSelectedValue = $.merge(aryFilteredResultValue, aryCurrentSelectedValue);

    // 將欲選取的項目，指定給kendoMultiSelect
    objMultiSelect.value(aryNewSelectedValue);


    // 由於kmsServiceStatus.value()會造成Filter清單清除，故手動執行search，以維持原有的filter清單畫面
    var strCurrentFilterString = objMultiSelect.input.val();
    objMultiSelect.search(strCurrentFilterString);

    kdSelectStores.close();
};












$(document).ready(function () {

    var checkInputs = function (elements) {
        //console.log('checkInputs');
        //console.log(elements);
        elements.each(function () {
            var element = $(this);
            var input = element.find("input[type='checkbox']").eq(0);
            //console.log(input);
            input.prop("checked", element.hasClass("k-selected"));
            //input.prop("checked", true);
        });
    };

    

    


    kdSelectStores = $("#multi-select_EducationSchools").kendoMultiSelect({        
        itemTemplate: "<input type='checkbox'/> #:data.text#",
        autoClose: false,
        downArrow: true,
        height: 400,
        dataBound: function () {
            var items = this.ul.find("li");
            setTimeout(function () {
                checkInputs(items);
            });
        },
        change: function () {
            var items = this.ul.find("li");
            checkInputs(items);
        },
        filter: "contains",
        headerTemplate: '<div><button type="button" class="btn btn-xs btn-info" id="btnKmsEducationSchools_FastSelect" onclick="fnKendoMultiSelect_FastSelect(\'multi-select_EducationSchools\');" data-toggle="tooltip"  data-placement="left" title="選取全部">'
            + '<img src="../../assets/img/icon/s/arrow-right18.png"/>全選</button>'
            + '&nbsp;&nbsp;'
            + '<button type="button" onclick="fnKendoMultiSelect_ClearAll(\'multi-select_EducationSchools\');" id="btnKmsEducationSchools_ClearAll" class="btn btn-xs btn-cancel btn-default btn-outline" data-toggle="tooltip"  data-placement="left" title="清除所有已選取的項目">'
            + '<img src="../../assets/img/icon/s/file-remove2.png" />清除</button>'
            + '<span><small><em>（鍵盤快速鍵：ESC => 收闔選單）</em></small></span>'
            + '</div>'
        


    }).data("kendoMultiSelect");


    
    
    
    


    

    
    var vTotalCount_SubTotal = 0;
    //new DataTable('#target');
    var DtList = $('#tbPivot').DataTable({
        paging: true,
        pageLength: _dtPageLengthLarger,
        pagingType: _dtPageType,
        processing: _dtIsProcessing,
        order: [],
        dom: _dtDomFilterWithExport,
        fixedColumns: true,
        fixedHeader: true,
        buttons: [
            {
                extend: 'excel',
                text: '匯出銷售數據',
                className: _dtWidthBtnXlsxCss,
                charset: 'utf-8',
                titleAttr: _dtBtnXlsxTitle,
                bom: true,
                filename: jsFileNameXlsx
            }
        ],
        footerCallback: function (tfoot, data, start, end, display) {
            var bodyColumnIndexStart = 1;
            var bodyColumnIndexEnd = this.api().columns().count() - 1;

            if (jsIsGroupBySize != jsIsGroupByColor) bodyColumnIndexStart = 2;

            for (let i = bodyColumnIndexStart; i <= bodyColumnIndexEnd; i++) {
                this.api().columns(i).every(function () {
                    var column = this;
                    vTotalCount_SubTotal = column
                        .data()
                        .reduce(function (a, b) {
                            var x = parseFloat(a) || 0;
                            var y = parseFloat(b) || 0;
                            return x + y;
                        }, 0);
                });
                $(tfoot).find('th').eq(i).html(vTotalCount_SubTotal.toLocaleString('en-US'));
            }
            $(tfoot).find('th').eq(0).html('全部合計：');
        },
        language: {
            paginate: {
                first: _dtLngPageFirst,
                next: _dtLngPageNext,
                last: _dtLngPageLast,
                previous: _dtLngPagePrevious
            },
            select: {
                rows: _dtLngSelectRows
            },
            search: _dtLngSearch,
            lengthMenu: _dtLngLengthMenu,
            processing: _dtLngProcessing,
            zeroRecords: _dtLngZero,
            info: _dtLngInfo,
            infoFiltered: _dtLngInfoFiltered,
            loadingRecords: _dtLoadingRecordsText,
            infoEmpty: _dtLngEmpty
        }
    });


    //fnKendoMultiSelect_FastSelect('multi-select_EducationSchools');

    //jsonData[0].forEach(element => console.log(element));

    //for (let element in jsonData[0]) {
    //    console.log('a', element);
    //}
    //jQuery.each(jsonData[0], function (kk, vv) {
    //    console.log(kk);
    //});


    //$.ajax({
    //    url: 'arrays_short.txt',
    //    success: function (json) {
    //        console.log('xxx');
    //        var tableHeaders;
    //        $.each(json.columns, function (i, val) {
    //            tableHeaders += "<th>" + val + "</th>";
    //        });

    //        $("#tableDiv").empty();
    //        $("#tableDiv").append('<table id="displayTable" class="display" cellspacing="0" width="100%"><thead><tr>' + tableHeaders + '</tr></thead></table>');
    //        //$("#tableDiv").find("table thead tr").append(tableHeaders);

    //        $('#displayTable').dataTable(json);
    //    },
    //    dataType: "json"
    //});





    //jQuery('#btnSubmit').click(function () {

    //    //jQuery("#selection").find(':selected').each(function (e) {
    //    //    var this_input = jQuery(this);
    //    //    if (this_input.is(':selected')) {
    //    //        data.push(this_input.val());
    //    //    }
    //    //});

    //    //$('#divResult').empty().append(PrintTable(data));
    //    $('#divResult').empty().append(PrintTable(jsonData));

    //    function PrintTable(data) {
    //        var html = '<table class="compTable"><thead><tr><th>';
    //        if (data && data.length) {
    //            html += '</th>';

    //            jQuery.each(data, function (i) {
    //                //getting heading at that key
    //                html += '<th>' + data[i].ColHeading + '</th>';
    //            });
    //            html += '</tr>';
    //            html += '<tbody>';
    //            jQuery.each(StatJSON[data[0]], function (k, v) {
    //                html += "<tr>"
    //                if (k != "ColHeading") {
    //                    html += "<td>" + k + "</td>"
    //                }

    //                jQuery.each(data, function (k2, v2) {
    //                    if (k != "ColHeading") {
    //                        html += '<td>' + StatJSON[data[k2]][k] + '</td>';
    //                    }
    //                });
    //                html += '</tr>';
    //            });
    //        } else {
    //            html += 'No results found</td></tr>';
    //        }
    //        html += '</tbody></table>';
    //        return html;
    //    }

    //});




   



});









function fnSearch_OnClick() {
    jsPageLoading_Show();
    var values_val_EducationSchools = '';
    $("#multi-select_EducationSchools :selected").each(function (i, sel) {

        values_val_EducationSchools = values_val_EducationSchools + $(sel).val() + ',';
        $("#hdnStoreSelection").val(values_val_EducationSchools);
        //console.log(sel);
    });
};





function fnDateRange_Set(_modeNo) {
    var date1 = null;
    var date2 = null;
   


    switch (_modeNo) {
        // 前周
        case 24:
            date1 = moment().clone().subtract(1, 'weeks').startOf('isoWeek');
            date2 = moment().clone().subtract(1, 'weeks').endOf('isoWeek');
            break;

        // 本周
        case 25:
            date1 = moment().week(moment().week()).startOf('week');
            date2 = moment().week(moment().week()).endOf('week');
            break;

        // 前月
        case 34:
            date1 = moment().month(moment().month() - 1).startOf('month');
            date2 = moment().month(moment().month() - 1).endOf('month');
            break;

        // 本月
        case 35:
            date1 = moment().startOf('month');
            date2 = moment().endOf('month');
            break;


        // 前一季月
        case 44:
            //date1 = moment().add(-1, 'Q').quarter();
            date1 = moment().quarter(moment().quarter()).startOf('quarter');
            date2 = moment().quarter(moment().quarter()).endOf('quarter');
            break;

        // 今年
        case 55:
            date1 = moment().startOf('year');
            date2 = moment().endOf('year');
            break;
    }

    // console.log(date1, date2);
    //$('#txtDate1').val(date1);

    if (_modeNo == 0) {
        $('#txtDate1').val(null);
        $('#txtDate2').val(null);
    }
    else {
        $('#txtDate1').val(date1.toDate().toLocaleDateString('en-CA'));
        $('#txtDate2').val(date2.toDate().toLocaleDateString('en-CA'));
    }
    
};





function btnGroupSizeOrColorRevert_Click() {

    var isGroupByColor = $('#chkIsGroupByColor').is(":checked");
    var isGroupBySize = $('#chkIsGroupBySize').is(":checked");

    $('#chkIsGroupByColor').prop('checked', !isGroupByColor);
    $('#chkIsGroupBySize').prop('checked', !isGroupBySize);

    //console.log(isGroupByColor, isGroupBySize);
};