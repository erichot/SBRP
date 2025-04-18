
// jQuery UI Accordion
const JS_UI_Accordion_Active_FormEditHistoryBrief = true;
const JS_UI_Accordion_Active_SignLogList = true;


// Note: 2024/12/31 Both jQuery UI and Bootstrap use tooltip for the name of the plugin. Use $.widget.bridge to create a different name for the jQuery UI version and allow the Bootstrap plugin to stay named tooltip
$.widget.bridge('uitooltip', $.ui.tooltip);
