
$(document).ready(function () {

    const jsCI_No = 0;
    const jsCI_Id = 1;
    const jsCI_Name = 2;

    const jsCI_EDIT = 3;
    const jsCI_REMOVE = 4;




    var dtList = $('#tbList').DataTable({
        paging: _dtPaging,
        pageLength: _dtPageLengthMiddle,
        pagingType: _dtPageType,
        dom: _dtDomListFilter,
        buttons: [
            {
                extend: 'csv',
                text: _dtBtnCsvText,
                className: _dtBtnCsvCss,
                charset: 'utf-8',
                titleAttr: _dtBtnCsvTitle,
                bom: true,
                exportOptions: {
                    columns: [jsCI_No, jsCI_Id, jsCI_Name],
                }
            },
            {
                extend: 'excel',
                text: _dtBtnXlsxText,
                className: _dtBtnXlsxCss,
                charset: 'utf-8',
                titleAttr: _dtBtnXlsxTitle,
                bom: true,
                exportOptions: {
                    columns: [jsCI_No, jsCI_Id, jsCI_Name],
                }
            }
        ],
        columnDefs: [
            { targets: jsCI_No, visible: _dtColumnDef_No_Visible, className: _dtColumnDef_No_ClassName },
            { targets: jsCI_Id, className: _dtColumnDef_Id_ClassName },
            { targets: jsCI_EDIT, orderable: false, visible: jsIsAllowEditing, className: _dtColumnDef_EDIT_ClassName, width: _dtColumnDef_EDIT_Width },
            { targets: jsCI_REMOVE, orderable: false, visible: jsIsAllowRemoval, className: _dtColumnDef_REMOVE_ClassName, width: _dtColumnDef_REMOVE_Width },
        ],
        processing: _dtIsProcessing,
        order: [],
        
        language: {
            paginate: {
                first: _dtLngPageFirst,
                next: _dtLngPageNext,
                last: _dtLngPageLast,
                previous: _dtLngPagePrevious
            },
            search: _dtLngSearch,
            searchPlaceholder: _dtLngSearchPlaceholder,
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


    //var data = dtList.buttons.exportData({
    //    columns: '.dt-head-id .' + _dtColumnDef_Id_ClassName
    //});

});