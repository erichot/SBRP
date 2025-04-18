
$(document).ready(function () {


    var vEdThisID;
    var vEdFormMsg;
    var dtOrderColumn = [];
    var vItemNo_NewDefault = 0;
    var vItemNo_OnClickedRow = 0;
    var vTotalQuantity = 0;


    const jsCI_ItemNo = JS_GetEdFieldIndexByName(edFieldOptions, CN_ISOD_ItemNo);
    const jsCI_ProductId = JS_GetEdFieldIndexByName(edFieldOptions, CN_PRDT_ProductId);
    const jsCI_ProductName = JS_GetEdFieldIndexByName(edFieldOptions, CN_PRDT_ProductName)
    const jsCI_Quantity = JS_GetEdFieldIndexByName(edFieldOptions, CN_ISOD_Quantity);


    console.log('jsPG_No=', jsPG_No);
    if (jsPG_No == 0) {
        dtOrderColumn = [jsCI_ItemNo, 'desc']
        console.log('dtOrderColumn=', dtOrderColumn);
    };


    // #region "Part 1: Editor"
    // Editor field initial & options
    editorList = new $.fn.dataTable.Editor({
        ajax: {
            create: {
                url: jsApiUrlED,
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
                    renameKey(d, '0', 'id');
                    d.data.LogNo = jsPG_DraftNo;
                    d.data.OrderNo = jsPG_No;
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
                    if (d.data.ItemNo === undefined) d.data.ItemNo = vItemNo_OnClickedRow;
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
    $('#btnEdAddDetail').on('click', function () {
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
        
        $('#hndPtItemNo_Max').val(vItemNo_NewDefault);
        JS_fnNotification_Show(Form_Msg_NTF_OperationInserted);
        //dtList.rows().deselect();
        dtList.page.jumpToData(data[CN_PRDT_ProductId], JS_GetEdFieldIndexByName(edFieldOptions, CN_PRDT_ProductId));
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
            { data: CN_ISOD_Quantity },
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
            // The index ignore the hidden column : ProductNo
            $(tfoot).find('th').eq(jsCI_Quantity - 1).html(vTotalQuantity.toLocaleString('en-US'));
            $(tfoot).find('th').eq(jsCI_ItemNo).attr('colspan', 3);
            $(tfoot).find('th').eq(jsCI_ItemNo).nextAll().slice(0, 2).css('display', 'none');
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
    // #endregion "Part 2: DataTables"


    function DtList_Reload() {
        dtList.ajax.reload(null, false);
    };






    $("#btnEdRefresh").click(function () {
        //DtList.row(':eq(0)', { page: 'current' }).select();
        //DtList.row('#row_7022').select();
    });




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
                    set({ ProductName: data.ProductName });
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





    $('#txtProductId_SingleInput').on('keydown', function (event) {
        if (event.key === "Enter") {
            $('#btnProductId_SingleInput').click();
        }
    });


    $('#btnProductId_SingleInput').on('click', function () {
        var productId = $('#txtProductId_SingleInput').val().toUpperCase().trim();
        if (productId == '') return;

        var defaultQty = JS_fnParseNumber($('#txtQty_Default').val());
        if (defaultQty == 0) defaultQty = 1;

        vItemNo_NewDefault = JS_fnParseNumber($('#hndPtItemNo_Max').val()) + 1;

        editorList
            .create(false)
            .set(CN_ISOD_ItemNo, vItemNo_NewDefault)
            .set(CN_ISOD_Quantity, defaultQty)
            .set(CN_PRDT_ProductId, productId)
            .submit();

        $('#txtProductId_SingleInput').focus();
        $('#txtProductId_SingleInput').val('');
    })


    $('#btnRefreshDetail').on('click', function () {
        DtList_Reload();
    });
});