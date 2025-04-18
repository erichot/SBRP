
$(function() {
   

    var dtList = $('#tbList').DataTable({        
        order: [],
        paging: _dtPaging,
        pagingType: _dtPagingType,
        pageLength: _dtPageLength,
        columnDefs: [
            { targets: dtCI_No, className: 'dt-body-center' },
            { targets: dtCI_Id, className: 'dt-body-center' },
            { targets: dtCI_Name, className: 'dt-body-center' },
            { targets: dtCI_ItemIdMinLength, className: 'dt-body-center' },
            { targets: dtCI_ItemIdMaxLength, className: 'dt-body-center' },
            { targets: dtCI_OrderNo, className: 'dt-body-center' },
            { targets: dtCI_Remove, className: 'dt-body-center', orderable: false },
            { targets: dtCI_Edit, className: 'dt-body-center', orderable: false }
        ],
        dom: _dtDomEditorWithExport,
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