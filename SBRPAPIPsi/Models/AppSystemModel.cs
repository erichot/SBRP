using System.ComponentModel.DataAnnotations;

namespace SBRPAPIPsi.Models
{
    public class AppSystemModel
    {
    }



    public class AppSystem
    {
        public const string TD_UI_OnPageLoad_Message_Notification = "td_ui_msg_opageload_ntf";
    }







    public class AppSettingsModel
    {
        public string Portal_WEB_RootUrl { get; set; }



        // 以web client broswer 的角度來解析API url
        public string PSI_API_RootUrl { get; set; }

        // 以Web的角度來解析API url
        public string PSI_API_FromWeb_RootUrl { get; set; }

        public string PSI_WEB_RootUrl { get; set; }



        public int ApiLoginExpireTime { get; set; }

        public int WebLoginExpireTime { get; set; }
    }






    public class AppSystemRmshq
    {
        public const string VD_SEL_StoreList = "v_sel_store";
    }









    // correspond the byte value of BOPCMSData.Models.SubmitActionModeEnum
    // correspond the byte value of BOPCMSLogData.Models.LogTypeEnum
    // partial correspond the byte value of BOPCMSWeb.Models.Models.FormEditModeEnum (UserActionModel) 
    public enum FormEditModeEnum : byte
    {
        [Display(Name = "檢視")]
        Read = 0,

        [Display(Name = "新增")]
        Add = 1,

        [Display(Name = "編輯")]
        Edit = 2,

        [Display(Name = "刪除")]
        Remove = 3,

        [Display(Name = "清單列表")]
        List = 100
    }











    public static class WebBaseUI
    {
        public const string Form_Btn_Back = "返回前頁";
        public const string Form_Btn_BackToList = "返回列表";
        public const string Form_Btn_Refresh = "重新整理(R)";
        public const string Form_Btn_Export = "匯出(X)";


        public const string Form_Btn_Add = "新增(A)";
        public const string Form_Btn_AddWithContractSelector = "新增（選擇契約編號）";
        public const string Form_Btn_AddWithProjectCouponOutSelector = "新增（選擇專案券出庫）";
        public const string Form_Btn_Edit = "編輯";
        public const string Form_Btn_Remove = "刪除";

        public const string Form_Btn_Delete = "刪除送出";
        public const string Form_Btn_Insert = "新增送出";
        public const string Form_Btn_Update = "更新送出";

        public const string Form_Btn_SubmitForRemove = "刪除並送審(Enter)";
        public const string Form_Btn_SubmitForEdit = "修改並送審";

        public const string Form_Btn_Review = "覆核";
        public const string Form_Btn_Approve = "核准(Enter)";
        public const string Form_Btn_Reject = "駁回";

        public const string Form_Btn_AddDetailEntry = "新增明細(A)";

        public const string Form_Btn_Print = "列印(P)";

        public const string ColHeader_DataStatus = "資料狀態";
        public const string ColHeader_ControlField_Edit = "編輯";
        public const string ColHeader_ControlField_Remove = "刪除";
        public const string ColHeader_ControlField_Review = "覆核";
        public const string ColHeader_CreateDate = "建檔日期";
        public const string ColHeader_EditDate = "修改日期";
        public const string ColHeader_ApproveDate = "覆核日期";
        public const string ColHeader_CreatePerson = "建檔人員";
        public const string ColHeader_EditPerson = "修改人員";
        public const string ColHeader_ApprovePerson = "覆核人員";

        // Alert / Sweet alert
        public const string Form_Alt_Submitted_Title = "已提交";
        public const string Form_Alt_Submitted_Msg = "送審中";
        public const string Form_Alt_Review_Rejected_Title = "駁回";
        public const string Form_Alt_Review_Rejected_Msg = "已駁回完成";
        public const string Form_Alt_Review_Approved_Title = "核准";
        public const string Form_Alt_Review_Approved_Msg = "已核准完成";
        public const string Form_Alt_Signed_Title = "已簽收";
        public const string Form_Alt_Signed_Msg = "簽收完成";
        public const string Form_Alt_Checkouted_Title = "會計日結作業";
        public const string Form_Alt_Checkouted_Msg = "已完成";
        public const string Form_Alt_DataNotFound_Title = "查無資料";
        public const string Form_Alt_DataNotFound_Msg = "請嘗試再次操作";
        public const string Form_Alt_Prohibit_HasCheckedOutToday_Title = "禁止作業";
        public const string Form_Alt_Prohibit_HasCheckedOutToday_Msg = "本日已結帳";

        public const string Form_Msg_ModelStateInValid = "自動欄位檢核失敗，請檢查各表單欄位。";
        public const string Form_Msg_ModelStateRequired = "欄位不允許空白，請重新輸入";

        //Notification
        public const string Form_Msg_NTF_OperationInserted = "建檔完成";
        public const string Form_Msg_NTF_OperationUpdated = "更新完成";
        public const string Form_Msg_NTF_SubmitCompleted = "送審完成";
        public const string Form_Msg_NTF_SubmitError = "送審失敗。";
        public const string Form_Msg_NTF_ReviewCompleted = "覆核完成。";
        public const string Form_Msg_NTF_ReviewThenApproved = "已核准完成。";
        public const string Form_Msg_NTF_ReviewThenRejected = "已駁回完成。";
        public const string Form_Msg_NTF_SignCompleted = "簽收完成";
        public const string Form_Msg_NTF_WarningHasCheckedOutToday = "本日已結帳";

        public const string Form_MainInfo_Label_NoData = "無資料";



        public const string Tooltip_Btn_AddWithContractSelector = "開啟另一頁面，並選擇【信託契約】後，再繼續下一步作業";
    }



}
