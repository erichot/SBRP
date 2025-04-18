
$(function() {


    var vEdThisID;
    var vEdFormMsg;
    var dtOrderColumn = [];
    var vItemNo_NewDefault = 0;
    var vItemNo_OnClickedRow = 0;
    var vTotalQuantity = 0, vTotalAmount = 0;

    const jsCI_ItemNo = JS_GetEdFieldIndexByName(edFieldOptions, CN_ISOD_ItemNo);
    const jsCI_ProductId = JS_GetEdFieldIndexByName(edFieldOptions, CN_PRDT_ProductId);
    const jsCI_ProductName = JS_GetEdFieldIndexByName(edFieldOptions, CN_PRDT_ProductName)
    const jsCI_Quantity = JS_GetEdFieldIndexByName(edFieldOptions, CN_ISOD_Quantity);
    const jsCI_SubAmount = JS_GetEdFieldIndexByName(edFieldOptions, CN_ISOD_SubAmount);


    console.log('jsPG_No=', jsPG_No);
    if (jsPG_No == 0) {
        dtOrderColumn = [jsCI_ItemNo, 'desc']
        console.log('dtOrderColumn=',dtOrderColumn);
    };


    // #region "Part 1: Editor"
    // Editor field initial & options
    editorList = new $.fn.dataTable.Editor({
        ajax: {
            create: {
                url: jsApiUrlEDWithCostNo,
                headers: {
                    Authorization: 'Bearer ' + jsApiToken
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    vEdFormMsg = JS_fnGeneralAjaxErrorDisplayMessageHtml(jqXHR, textStatus, errorThrown);
                    editorList.message(vEdFormMsg);
                },
                contentType: "application/json",
                method: 'post',
                data: function (d) {                    
                    console.log('#hndPtItemNo_Max=',JS_fnParseNumber($('#hndPtItemNo_Max').val()));
                    renameKey(d, '0', 'id');
                    d.data.LogNo = jsPG_DraftNo;
                    d.data.OrderNo = jsPG_No;
                    //d.data.ItemNo = JS_fnParseNumber($('#hndPtItemNo_Max').val()) + 2;
                    return JSON.stringify(d);
                }
            },
            edit: {
                url: jsApiUrlED,
                headers: {
                    Authorization: 'Bearer ' + jsApiToken
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    vEdFormMsg = JS_fnGeneralAjaxErrorDisplayMessageHtml(jqXHR, textStatus, errorThrown);
                    editorList.message(vEdFormMsg);
                },
                contentType: "application/json",
                method: 'put',
                replacements: {
                    controller: function (key, id, action, data) {
                        vEdThisID = id;
                        return id;
                    }
                },
                data: function (d) {                    
                    renameKey(d, vEdThisID, 'id');
                    d.data.LogNo = jsPG_DraftNo;
                    d.data.OrderNo = jsPG_No;
                    console.log('typeof d.data.ItemNo', typeof d.data.ItemNo);
                    console.log('vItemNo_OnClickedRow1=', vItemNo_OnClickedRow);
                    if (d.data.ItemNo === undefined) d.data.ItemNo = vItemNo_OnClickedRow;
                    //d.data.ItemNo = vItemNo_OnClickedRow;
                    //console.log('d.data', d.data);
                    //console.log('vItemNo_OnClickedRow=', vItemNo_OnClickedRow);
                    console.log('d.data.ItemNo=', d.data.ItemNo);
                    return JSON.stringify(d);
                }
            },
            remove: {
                url: jsApiUrlED,
                headers: {
                    Authorization: 'Bearer ' + jsApiToken
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    vEdFormMsg = JS_fnGeneralAjaxErrorDisplayMessageHtml(jqXHR, textStatus, errorThrown);
                    editorList.message(vEdFormMsg);
                },
                contentType: "application/json",
                method: 'delete',
                replacements: {
                    controller: function (key, id, action, data) {
                        vEdThisID = id;
                        return id;
                    }
                },
                data: function (d) {
                    renameKey(d, vEdThisID, 'id');
                    d.data.LogNo = jsPG_DraftNo;
                    d.data.OrderNo = jsPG_No;
                    return JSON.stringify(d);
                }
            }
        },
        table: "#tbPtList",
        fields: edFieldOptions.map(field => ({
            label: field.label,
            name: field.name,
            attr: field.attr,
            type: field.type,
            def: field.def,
            options: field.options,
            required: field.required
        })),
        formOptions: {
            main: {
                focus: jsCI_ProductId
            }
        },
        i18n: {
            error: {
                system: _edI18nErrorSystemMessage
            }
        }
    });


    editorList.on(ED_EVENT_initCreate, function () {
        editorList.show(); //Shows all fields
        fnEdList_FieldHide();
    });

    function fnEdList_FieldHide() {
        editorList.field(CN_ISOD_ProductNo).hide();
    };


    // Editor on Add
    $('#btnPtAddDetail').on('click', function () {        
        vItemNo_NewDefault = JS_fnParseNumber($('#hndPtItemNo_Max').val()) + 1;
        editorList
            .title(JS_LANG_Editor_Add_Window_Title)
            .buttons([
                { text: JS_LANG_Editor_Button_Cancel_Title, className: _edBtnCancelClassName, action: function () { this.close(); } }
                ,
                { text: JS_LANG_Editor_Button_Insert_Title, className: _edBtnInsertClassName, action: function () { this.submit(); } }
            ])
            .create()
            .field(CN_ISOD_ItemNo).val(vItemNo_NewDefault);
        
        fnEdList_FieldHide();
        editorList.field(CN_PRDT_ProductName).disable();        
    });


    // Editor on Edit
    $('#tbPtList').on('click', 'td.' + _edDataTable_Column_Edit_ClassName, function () {
        var tr = this.parentNode;
        editorList
            .title(JS_LANG_Editor_Edit_Window_Title)
            .buttons([
                { text: JS_LANG_Editor_Button_Cancel_Title, className: _edBtnCancelClassName, action: function () { this.close(); } }
                ,
                { text: JS_LANG_Editor_Button_Update_Title, className: _edBtnUpdateClassName, action: function () { this.submit(); } }
            ])
            .edit(tr
                , { focus: jsCI_ProductName });

        fnEdList_FieldHide();
        editorList.field(CN_PRDT_ProductName).disable();
    });

    // The index ignore the hidden column : ProductNo
    //$('#tbPtList').on('click', 'tbody td:eq(' + (jsCI_Quantity - 1) + ')', function (e) {
    //$('#tbPtList').on('click', 'tbody td:eq(4)', function (e) {
    $('#tbPtList').on('click', 'tbody td:nth-child(5)', function (e) {
        vItemNo_OnClickedRow = dtList.cells(this.parentNode, jsCI_ItemNo).cell().data();
        //console.log('e=', e);
        //console.log('indexes=', dtList.cells(this.parentNode, '*').indexes());
        //console.log('cells(0,2)=', dtList.cells(this.parentNode, jsCI_ItemNo).cell().data());
        //console.log('indexes2=', dtList.cells(this.parentNode, '*').cells(0, 2).cell().data());
        //console.log('indexes3=', dtList.cells(this.parentNode, '*').cells(1, 3).cell().data());
        //console.log('indexes4=', dtList.cells(this.parentNode, '*').cells(2,4).cell().data());
        //console.log('indexes=', dtList.cells(this.parentNode).indexes());
        //console.log('click tbody td:eq=', dtList.cell(this.parentNode, '*').index());
        //console.log('jsCI_ItemNo=', dtList.cells(this.parentNode, '*').cell('ItemNo').data());
        //console.log('jsCI_ItemNo=', dtList.cells(this.parentNode, '*').);
        //editorList.inline(this, {
        //    submit: 'allIfChanged'
        //});
        editorList.inline(this);
    });

    // Editor on Remove
    $('#tbPtList').on('click', 'td.' + _edDataTable_Column_Remove_ClassName, function (e) {
        e.preventDefault();
        vItemNo_NewDefault = JS_fnParseNumber($('#hndPtItemNo_Max').val()) + 1;

        editorList.remove($(this).closest('tr'), {
            title: JS_LANG_Editor_Remove_Window_Title,
            message: JS_ED_RemoveClick_GetMessage($(this).closest('tr')
                , jsCI_ProductId
                , jsCI_ProductName),
            buttons: ([
                { text: JS_LANG_Editor_Button_Cancel_Title, className: _edBtnCancelClassName, action: function () { this.close(); } }
                ,
                { text: JS_LANG_Editor_Button_Delete_Title, className: _edBtnDeleteClassName, action: function () { this.submit(); } }
            ])
        });
    });


    // Editor on Validation
    editorList.on(ED_EVENT_preSubmit, function (e, o, action) {
        return true;
        if (action !== 'remove') {

            //var vFrontId = this.field(CN_FrontId);
            //if (!vFrontId.isMultiValue()) {
            //    if (!vFrontId.val().trim()) {
            //        vFrontId.error('「前置碼」不允許空白');
            //    }

            //    if (vFrontId.val().trim().length > jsFmVd_CouponDetailSNFrontId_MaxLength) {
            //        vFrontId.error('「前置碼」長度不允許超過' + jsFmVd_CouponDetailSNFrontId_MaxLength + '個字元');
            //    }
            //};



            //var vLength = this.field(CN_Length);
            //if (!vLength.isMultiValue()) {
            //    if (!vLength.val().trim()) {
            //        vLength.error('「流水號長度」不允許空白');
            //    }

            //    var jsLength = JS_fnParseNumber(vLength.val());
            //    if (jsLength == 0) {
            //        vLength.error('「流水號長度」不正確');
            //    }
            //    else if (jsLength > jsFmVd_CouponDetailSNLength_MaxValue) {
            //        vLength.error('「流水號長度」不允許超過' + jsFmVd_CouponDetailSNLength_MaxValue + '碼長度');
            //    }
            //};



            if (this.inError()) {
                return false;
            };
        }
    });



    editorList.on(ED_EVENT_postCreate, function (e, json, data, id) {  
        // Editor 確定新增完成後，將方才新增所使用的 vItemNo_NewDefault 存入 BOM
        console.log('ED_EVENT_postCreate_vItemNo_NewDefault=', vItemNo_NewDefault);
        $('#hndPtItemNo_Max').val(vItemNo_NewDefault);
        //var jsItemNo_NewDefault = JS_fnParseNumber($('#hndPtItemNo_NewDefault').val()) + 1;
        //$('#hndPtItemNo_NewDefault').val(jsItemNo_NewDefault);
        JS_fnNotification_Show(Form_Msg_NTF_OperationInserted);
        //dtList.rows().deselect();
        dtList.page.jumpToData(data[CN_PRDT_ProductId], jsCI_ProductId);
        //dtList.row('#' + id).select();
    });

    


    editorList.on(ED_EVENT_postEdit, function (e, json, data, id) {
        JS_fnNotification_Show(Form_Msg_NTF_OperationUpdated);
    });

    editorList.on(ED_EVENT_postRemove, function (e, json, ids) {
        $('#hndPtItemNo_Max').val(vItemNo_NewDefault);
        JS_fnNotification_Show(Form_Msg_NTF_OperationDeleted);
        DtList_Reload();
    });
    // #endregion "Part 1: Editor"






    // #region "Part 2: DataTables"
    // Datatable Initial & Options
    //console.log('Datatable Initial & Options');
    dtList = $('#tbPtList').DataTable({
        ajax: {
            url: jsApiUrlDT,
            headers: {
                Authorization: 'Bearer ' + jsApiToken
            },
            type: "POST",
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            data: function (d) {
                return JSON.stringify(d);
            }
        },
        order: dtOrderColumn,
        paging: _dtPaging,
        pagingType: _dtPagingType,
        pageLength: _dtPageLength,
        columns: [
            { data: CN_ISOD_ItemNo, visible: _dtColumnDef_FKNo_Visible },
            { data: CN_ISOD_ProductNo, visible: false },
            { data: CN_PRDT_ProductId, className: _dtColumnDef_Id_ClassName },
            { data: CN_PRDT_ProductName },
            { data: CN_ISOD_UnitCost },
            { data: CN_ISOD_Quantity },
            { data: CN_ISOD_SubAmount },
            { data: CN_ISOD_Remark },
            {
                className: _edDataTable_Column_Remove_ClassName,
                width: _dtColumnDef_REMOVE_Width,
                orderable: false,
                data: null,
                visible: jsIsAllowRemoving,
                defaultContent: ''
            },
            {
                className: _edDataTable_Column_Edit_ClassName,
                width: _dtColumnDef_EDIT_Width,
                orderable: false,
                data: null,
                visible: jsIsAllowEditing,
                defaultContent: ''
            }
        ],
        columnDef: [
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
        processing: _dtIsProcessing,
        footerCallback: function (tfoot, data, start, end, display) {
            this.api().columns(jsCI_Quantity).every(function () {
                var column = this;
                vTotalQuantity = column
                    .data()
                    .reduce(function (a, b) {
                        var x = parseFloat(a) || 0;
                        var y = parseFloat(b) || 0;
                        return x + y;
                    }, 0);
            });
            this.api().columns(jsCI_SubAmount).every(function () {
                var column = this;
                vTotalAmount = column
                    .data()
                    .reduce(function (a, b) {
                        var x = parseFloat(a) || 0;
                        var y = parseFloat(b) || 0;
                        return x + y;
                    }, 0);
            });
            // The index ignore the hidden column : ProductNo
            $(tfoot).find('th').eq(jsCI_Quantity - 1).html(vTotalQuantity.toLocaleString('en-US'));
            $(tfoot).find('th').eq(jsCI_SubAmount - 1).html(vTotalAmount.toLocaleString('en-US'));
            $(tfoot).find('th').eq(jsCI_ItemNo).attr('colspan', 4);
            $(tfoot).find('th').eq(jsCI_ItemNo).nextAll().slice(0, 3).css('display', 'none');
            $(tfoot).find('th').eq(jsCI_SubAmount).attr('colspan', 3);
            $(tfoot).find('th').eq(jsCI_SubAmount + 1).css('display', 'none');
            $(tfoot).find('th').eq(jsCI_SubAmount + 2).css('display', 'none');
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
            lengthMenu: _dtLngLengthMenu,
            processing: _dtLngProcessing,
            zeroRecords: _dtLngZero,
            info: _dtLngInfo,
            infoFiltered: _dtLngInfoFiltered,
            loadingRecords: _dtLoadingRecordsText,
            infoEmpty: _dtLngEmpty
        }
    });


    function DtList_Reload() {
        dtList.ajax.reload(null, false);
    };
    // #endregion "Part 2: DataTables"
    //console.log('endregion "Part 2: DataTables');








    //$("#btnEdRefresh").click(function () {
    //    //DtList.row(':eq(0)', { page: 'current' }).select();
    //    //DtList.row('#row_7022').select();
    //});




    //function cas_nr_to_str(cas_nr, row, callback) {
    //    if (cas_nr == '') return null;
    //    $.ajax({
    //        url: jsApiUrlProductName + cas_nr,
    //        type: 'GET',
    //        dataType: 'json',
    //        async: false,
    //        success: function (data) {
    //            //console.log('data', data.ProductName
    //            return true;
    //            editorList.
    //                set({ ProductName: data.ProductName });
    //            return true;
    //        },
    //        error: function (error) {
    //            console.error('Error:', error);
    //        }
    //    });
    //};

    editorList.dependent(CN_PRDT_ProductId, function (val, data, callback) {
        if (val == '') return {};
        $.ajax({
            url: jsApiUrlProductName + val,
            type: 'GET',
            dataType: 'json',
            async: false,
            success: function (data) {
                if (data == null) return callback({});
                editorList.
                    set({
                        ProductName: data.ProductName,
                        UnitCost: data.UnitCost
                    });
                editorList.field(CN_ISOD_Quantity).focus();
                editorList.field(CN_ISOD_Quantity).input().select();
                return callback(data);
            },
            error: function (error) {
                console.error('Error:', error);
                // forgetting to return an object for Editor to process or not using its callback function.
                // will never complete. It should be either:
                return {};
            }
        });
    });












    $('#btnPtProductId_SingleInput').on('click', function () {
        var productId = $('#txtPtProductId_SingleInput').val().toUpperCase().trim();
        if (productId == '') return;
        console.log('productId', productId);

        var defaultQty = JS_fnParseNumber($('#txtPtQty_Default').val());
        if (defaultQty == 0) defaultQty = 1;
        console.log('defaultQty', defaultQty);

        // 新增前，將[vItemNo_NewDefault] + 1，並配給即將新增的明細data
        console.log('_btnProductId_SingleInput_onclick_$(#hndPtItemNo_Max).val()=', $('#hndPtItemNo_Max').val());
        vItemNo_NewDefault = JS_fnParseNumber($('#hndPtItemNo_Max').val()) + 1;
        editorList
            .create(false)
            .set(CN_ISOD_ItemNo, vItemNo_NewDefault)
            .set(CN_ISOD_Quantity, defaultQty)
            .set(CN_PRDT_ProductId, productId)
            .submit();


        $('#txtPtProductId_SingleInput').focus();
        $('#txtPtProductId_SingleInput').val('');
    });


    $('#btnPtRefreshDetail').on('click', function () {
        DtList_Reload();
    });
});