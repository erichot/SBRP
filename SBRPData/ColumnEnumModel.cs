using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SBRPData
{
    public class ColumnEnumModel
    {
    }







    #region "Basic Date & Time"
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DateRangeTypeEnum : byte
    {
        [Display(Name ="None")]
        None = 0,

        [Display(Name = "日")]
        Daily = 1,

        [Display(Name = "周")]
        Weekly = 7,

        [Display(Name = "月")]
        Monthly = 30,

        [Display(Name = "季")]
        Quarterly = 90,

        [Display(Name = "半年")]
        SemiAnnually = 180,

        [Display(Name = "年")]
        Annually = 255
    }
    #endregion









    public enum ContactPhoneTypeEnum : byte
    {
        [Display(Name = "手機")]
        Mobile = 1,
        [Display(Name = "市話")]
        Landline = 2,
        [Display(Name = "傳真")]
        Fax = 3,
        [Display(Name = "市話+分機")]
        LandlineWithExt = 21,        
    }












    public enum CurrencyEnum : byte
    {
        [Display(Name = "台幣")]
        TWD = 1,
        [Display(Name = "越南盾")]
        VND = 90,
        [Display(Name = "元人民幣")]
        CNY = 20,
        [Display(Name = "韓圜")]
        KRW = 40,
        [Display(Name = "美元")]
        USD = 100,
        [Display(Name = "港幣")]
        HKD = 60,
        [Display(Name = "馬來西亞林吉特")]
        MYR = 80,
        [Display(Name = "日圓")]
        JPY = 30,
        [Display(Name = "新加坡幣")]
        SGD = 100,
        [Display(Name = "銖")]
        THB = 80,
        [Display(Name = "澳門幣")]
        MOP = 70,

    }



    #region "SBRP system"
    public enum SBRP_AppIdEnum : byte
    {
        [Display(Name = "Unspecified")]
        Unspecified = 0,

        [Display(Name = "Portial入口")]
        Portial = 1,

        [Display(Name = "庫存")]
        PSI = 23
    }



    #endregion














    public enum SexEnum :byte
    {
        [Display(Name = "無")]
        None = 0,

        [Display(Name = "男")]
        Male = 1,

        [Display(Name = "女")]
        Female = 2,
    }
















    #region "UI & Form Action"

    // partial correspond the byte value of Web.Models.FormEditModeEnum (UserActionModel)
    public enum SubmitActionModeEnum : byte
    {
        [Display(Name = " ")]
        Read = 0,

        [Display(Name = "新增")]
        Add = 1,

        [Display(Name = "編輯")]
        Edit = 2,

        [Display(Name = "刪除")]
        Remove = 3
    }
    #endregion










}
