

$(document).ready(function () {

    const jsCI_No = 0;
    const jsCI_Id = 1;
    const jsCI_Name = 2;
    const jsCI_EDIT = 3;
    const jsCI_REMOVE = 4;


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
            { targets: jsCI_No, visible: _dtColumnDef_No_Visible },
            { targets: jsCI_EDIT, orderable: false, visible: jsIsAllowEditing, className: _dtColumnDef_EDIT_ClassName },
            { targets: jsCI_REMOVE, orderable: false, visible: jsIsAllowEditing, className: _dtColumnDef_REMOVE_ClassName },
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
            search: _dtLngSearch,
            searchPlaceholder: _dtLngSearchPlaceholder,
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