
$(function () {
    var DtList = $('#tbList').DataTable({
        paging: true,
        pageLength: _dtPageLengthMiddle,
        pagingType: _dtPagingType,
        //dom: _dtDomReport,
        buttons: [
            {
                extend: 'csv',
                text: _dtBtnCsvText,
                className: _dtBtnCsvCss,
                charset: 'utf-8',
                titleAttr: _dtBtnCsvTitle,
                bom: true
            },
            {
                extend: 'excel',
                text: _dtBtnXlsxText,
                className: _dtBtnXlsxCss,
                charset: 'utf-8',
                titleAttr: _dtBtnXlsxTitle,
                bom: true
            }
        ],
        columnDefs: [
            //{ targets: jsCI_No, visible: false },
            //{ targets: jsCI_EDIT, orderable: false, visible: jsIsAllowEditing, className: 'dt-body-center' },
            //{ targets: jsCI_REMOVE, orderable: false, visible: jsIsAllowEditing, className: 'dt-body-center' },
        ],
        processing: _dtIsProcessing,
        //order: [[jsCI_Id, 'desc']],
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
            lengthMenu: _dtLngLengthMenu,
            processing: _dtLngProcessing,
            zeroRecords: _dtLngZero,
            info: _dtLngInfo,
            infoFiltered: _dtLngInfoFiltered,
            loadingRecords: _dtLoadingRecordsText,
            infoEmpty: _dtLngEmpty
        }
    });
});

//$(document).ready(function () {
    

//    $(".cssPtPGCItemNo").kendoDropDownList({
//        autoBind: false,
//        filter: "contains",
//        dataTextField: "SelectItemText",
//        dataValueField: "SelectItemValue"
//    });


//    $(".cssPtPsSupplierNo").kendoDropDownList({
//        autoBind: false,
//        filter: "contains",
//        dataTextField: "SelectItemText",
//        dataValueField: "SelectItemValue",
//        dataSource: {
//            type: "jsonp",
//            serverFiltering: false,
//            transport: {
//                read: {
//                    url: jsApiUrlSupplierSIL,
//                    headers: {
//                        Authorization: 'Bearer ' + jsApiToken
//                    }
//                }
//            }
//        }
//    });



//    function selPtPsSupplier_restore(_index, _supplierNo) {
//        //$("#selPtPsSupplier_0").data("kendoDropDownList").value("5002");
//        //$("#selPtPsSupplier_1").data("kendoDropDownList").value("5003");
//        if (_supplierNo != null && _supplierNo > 0)
//            $("#selPtPsSupplier_" + _index.toString()).data("kendoDropDownList").value(_supplierNo.toString());
//    };

//    jsAryProductSupplier.forEach(item => selPtPsSupplier_restore(item.ItemNo, item.SupplierNo));
//    //selPtPsSupplier_restore(0, 5002);SupplierNo
//    //var abc = $("#selPtPsSupplier_0").data("kendoDropDownList");
    
//    //$(".cssPtPGCItemNo").kendoComboBox({
//    //    autoBind: true,
//    //    filter: "contains",
//    //    //placeholder: ",
//    //    dataTextField: "SelectItemText",
//    //    dataValueField: "SelectItemValue",
//    //    //dataBound: function () {
//    //    //    this.enable(!jsIsReadonly);
//    //    //},
//    //    //value: jsRelaBankBranchId_EditDefault
//    //}).data("kendoComboBox");
//    //KdComboRelaBankBranch = $("#selRelaBankBranch").data("kendoComboBox");


//    $('#btnPtPsAddDetail').on('click', function () {
//        console.log('btnPtPsAddDetail_onclick');
//        var trElementTemplate = '<tr>\
//    <td>\
//        <input type="number" name="ProductSuppliers[{index}].ItemNo" value="{index}" />\
//        <input type="hidden" name="ProductSuppliers[{index}].ProductNo">\
//        <label>{displayNo}</label>\
//    </td>\
//    <td>\
//        <select class="cssPtPsSupplierNo" id="selPtPsSupplier_{index}" name="ProductSuppliers[{index}].SupplierNo"></select>\
//    </td>\
//    <td>\
//        <input type="checkbox" id="ProductSuppliers_{index}__IsDefault" name="ProductSuppliers[{index}].IsDefault">\
//    </td>\
//    <td>\
//        <input type="checkbox" id="ProductSuppliers_{index}__EditForRemoving" name="ProductSuppliers[{index}].EditForRemoving">\
//    </td>\
//</tr>';

//        var index = $('#tbListSuppliers tr').length - 2;
//        var displayNo = $('#tbListSuppliers tr').length - 1;
//        var trElement = trElementTemplate.replace(/{index}/g, index).replace(/{displayNo}/g, displayNo);
//        $('#tbListSuppliers').append(trElement);


//        $("#selPtPsSupplier_" + index).kendoDropDownList({
//            autoBind: false,
//            filter: "contains",
//            dataTextField: "SelectItemText",
//            dataValueField: "SelectItemValue",
//            dataSource: {
//                type: "jsonp",
//                serverFiltering: false,
//                transport: {
//                    read: {
//                        url: jsApiUrlSupplierSIL,
//                        headers: {
//                            Authorization: 'Bearer ' + jsApiToken
//                        }
//                    }
//                }
//            }
//        });
//    });




//});