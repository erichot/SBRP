
$(document).ready(function () {
    
    const jsCI_No = 0;
    const jsCI_Id = 1;
    const jsCI_Name = 2;


    


    var DtList = $('#tbList').DataTable({
        //order: [[jsCI_Id, 'asc']],
        //order: false,
        select: true,
        search: true,
        paging: true,
        pagingType: _dtPagingType,
        pageLength: 10,
        dom: _dtDomFilter,
        processing: _dtIsProcessing,
        columnDefs: [
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




    //$("#txtTbContractId").on('keyup', function () {
    //    //console.log('this.value=' + this.value);
    //    DtList.column(jsCI_Id).search(this.value).draw();
    //});


    //$("#selTbContractStatus").on('click', function () {
    //    //console.log('this.value=' + this.value);
    //    DtList.column(jsCI_Id).search(this.value).draw();
    //});


    //$("#selTbContractStatus").change(function () {
    //    var optionSelected = $(this).find("option:selected");
    //    var valueSelected = optionSelected.val();
    //    var textSelected = optionSelected.text();
    //    //console.log('option:selected=' + textSelected);
    //    var searchStatus = "";
    //    if (valueSelected != "0") {
    //        //console.log('valueSelected=' + valueSelected);
    //        searchStatus = textSelected;
    //    }
            
    //    DtList.column(jsCI_ContractStatus).search(searchStatus).draw();

    //});


    ////$("#selTbContractStatus").val("1");
    //$("#selTbContractStatus").change();



    DtList.on('select', function (e, dt, type, indexes) {
        var contractNo = DtList.rows(indexes).data()[0][jsCI_No];
        var contractId = DtList.rows(indexes).data()[0][jsCI_Id];
        var customerName = DtList.rows(indexes).data()[0][jsCI_Name];
        //console.log("rowData0=" + contractNo);
        var selectedText = "" + contractId + " " + customerName;
        $('#hndSupplierNo').val(contractNo);
        $('#btnSubmit1').text(selectedText);
        $('#btnSubmit2').text(selectedText);
        //events.prepend('<div><b>' + type + ' selection</b> - ' + JSON.stringify(rowData) + '</div>');
    });


    $('#tbList tbody').on('dblclick', 'tr', function () {
        DtList.rows(this).select();
        $('#btnSubmit1').trigger('click');
    });


    $(document).bind('keypress', function (e) {
        if (e.keyCode == 13) {
            $('#btnSubmit1').trigger('click');
        }
    });


    //$('#btnRefreshList').click(function () {
    //    DtList.ajax.reload(null, true);
    //});







});