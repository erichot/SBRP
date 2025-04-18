
const ED_EVENT_initCreate = 'initCreate';
const ED_EVENT_preSubmit = 'preSubmit';
const ED_EVENT_postCreate = 'postCreate';
const ED_EVENT_postEdit = 'postEdit';
const ED_EVENT_postRemove = 'postRemove';

const _edDataTable_Column_Edit_ClassName = 'control-edit';
const _edDataTable_Column_Remove_ClassName = 'control-remove';

const _edBtnCreateClassName = "btn ml-5 btn-primary btn-outline-light";
const _edBtnEditClassName = "btn btn-primary btn-outline-light";
const _edBtnRemoveClassName = "btn px-2 btn btn-outline-light";


const _edBtnCancelClassName = "btn mr-5 btn-secondary btn-outline-light";

const _edBtnInsertClassName = "btn ml-5 btn-primary btn-outline-light";
const _edBtnUpdateClassName = "btn btn-primary btn-outline-light";
const _edBtnDeleteClassName = "btn px-2 btn-delete btn-outline-light";

//const _edLngCreateTitle = "Add Record";
//const _edLngEditTitle = "Edit";
//const _edLngRemoveTitle = "Remove";
//const _edLngRemoveButtonText = "Remove（Enter）";
//const _edLngCreateButtonText = "Insert (Enter）";
//const _edLngEditButtonText = "Update（Enter）";
//const _edLngCancelButtonText = "Cancel（ESC）";

const _edI18nErrorSystemMessage = "Please check error";




class JS_EdFieldModel {
    constructor(index, name, label
        , attr = null, def = null, options = null, required = false, type = 'text') {

        this.index = index;
        this.name = name;
        this.label = label;

        this.attr = attr;
        this.def = def;  
        this.options = options;  
        this.type = type;
        this.required = required;        
    }

    displayInfo() {
        console.log(`index:${this.index}, name: ${this.name}, label: ${this.label}`);
    }
};



const _edOptions_EnableDisable = [
    {
        label: "啟用",
        value: true
    },
    {
        label: "停用",
        value: false
    }
];



function JS_GetEdFieldByName(js_EdFieldModel, _name) {
    return js_EdFieldModel.find(element => element.name === _name);
};



function JS_GetEdFieldIndexByName(js_EdFieldModel, _name) {
    return (js_EdFieldModel.find(element => element.name === _name)).index;
};



function JS_ED_RemoveClick_GetMessage(trObject, idIndex, nameIndex) {

    var vId_Title = $(trObject).closest('table').find('thead th:eq(' + idIndex + ')').text().trim();
    var vName_Title = $(trObject).closest('table').find('thead th:eq(' + nameIndex + ')').text().trim();
    var vId = $(trObject).find('td:eq(' + idIndex + ')').text();
    var vName = $(trObject).find('td:eq(' + nameIndex + ')').text();

    return '確認刪除？ <br/><br/> ' + vId_Title + '：' + vId + ' <br/> ' + vName_Title + '：' + vName + '';

};
