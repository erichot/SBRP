
$(document).ready(function () {

   
    var vEdThisID;
    var vEdFormMsg;



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
                    return JSON.stringify(d);
                }
            }
        },
        table: "#tbList",
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
                focus: JS_GetEdFieldIndexByName(edFieldOptions, CN_PGCItemId)
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
        editorList.field(CN_PGCItemNo).hide();
        editorList.field(CN_PGCategoryNo).hide();
    };


    // Editor on Add
    $('#btnEdAddDetail').on('click', function () {
        editorList
            .title(JS_LANG_Editor_Add_Window_Title)
            .buttons([
                { text: JS_LANG_Editor_Button_Cancel_Title, className: _edBtnCancelClassName, action: function () { this.close(); } }
                ,
                { text: JS_LANG_Editor_Button_Insert_Title, className: _edBtnInsertClassName, action: function () { this.submit(); } }
            ])
            .create();

        fnEdList_FieldHide();
        editorList.enable(CN_PGCItemId);
    });


    // Editor on Edit
    $('#tbList').on('click', 'td.' + _edDataTable_Column_Edit_ClassName, function () {
        var tr = this.parentNode;
        editorList
            .title(JS_LANG_Editor_Edit_Window_Title)
            .buttons([
                { text: JS_LANG_Editor_Button_Cancel_Title, className: _edBtnCancelClassName, action: function () { this.close(); } }
                ,
                { text: JS_LANG_Editor_Button_Update_Title, className: _edBtnUpdateClassName, action: function () { this.submit(); } }
            ])
            .edit(tr
                , {focus: JS_GetEdFieldIndexByName(edFieldOptions, CN_PGCItemName)});

        fnEdList_FieldHide();
        editorList.disable(CN_PGCItemId);
    });


    // Editor on Remove
    $('#tbList').on('click', 'td.' + _edDataTable_Column_Remove_ClassName, function (e) {
        e.preventDefault();

        editorList.remove($(this).closest('tr'), {
            title: JS_LANG_Editor_Remove_Window_Title,
            message: JS_ED_RemoveClick_GetMessage($(this).closest('tr')
                , JS_GetEdFieldIndexByName(edFieldOptions, CN_PGCItemId)
                , JS_GetEdFieldIndexByName(edFieldOptions, CN_PGCItemName)),
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
        JS_fnNotification_Show(Form_Msg_NTF_OperationInserted);
        dtList.page.jumpToData(data[CN_PGCItemId], JS_GetEdFieldIndexByName(edFieldOptions, CN_PGCItemId));        
        dtList.row('#' + id).select();
    });

    editorList.on(ED_EVENT_postEdit, function (e, json, data, id) {
        JS_fnNotification_Show(Form_Msg_NTF_OperationUpdated);
    });

    editorList.on(ED_EVENT_postRemove, function (e, json, ids) {
        JS_fnNotification_Show(Form_Msg_NTF_OperationDeleted);
    });
    // #endregion "Part 1: Editor"

    




    // #region "Part 2: DataTables"
    // Datatable Initial & Options
    dtList = $('#tbList').DataTable({
        ajax: {
            url: jsApiUrlDT,
            headers: {
                Authorization: 'Bearer ' + jsApiToken
            },
            type: "POST",
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            data: function (d) {
                d.PGCategoryNo = jsPGCategoryNo;
                return JSON.stringify(d);
            }
        },
        order: [],
        paging: _dtPaging,
        pagingType: _dtPagingType,
        pageLength: _dtPageLength,
        columns: [
            { data: CN_PGCItemNo, visible: _dtColumnDef_No_Visible },
            { data: CN_PGCategoryNo, visible: _dtColumnDef_FKNo_Visible },
            { data: CN_PGCItemId, className: _dtColumnDef_Id_ClassName },
            { data: CN_PGCItemName },            
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





    



    $("#btnEdRefresh").click(function () {
        //DtList.row(':eq(0)', { page: 'current' }).select();
        //DtList.row('#row_7022').select();
    });



});