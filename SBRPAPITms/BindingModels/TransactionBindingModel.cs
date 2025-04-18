using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SBRPAPITms.BindingModels
{

    public class TransactionBindingModel
    {
        /// <summary>
        /// [卡號]固定長度10位數值，且符合Integer數值型態。實際儲存將轉換為10碼長度字串，若不足10位則由API往左補0
        /// </summary>
        public int cardID { get; set; }

        /// <summary>
        /// [刷卡日期] 固定長度8位數值，格式為yyyyMMdd
        /// </summary>
        public int tranDate { get; set; }

        /// <summary>
        /// [刷卡時間]固定長度4位數值 ，格式hhss
        /// </summary>
        public short tranTime { get; set; }

        /// <summary>
        /// [設備代碼]2位數值
        /// </summary>
        public byte deviceID    { get; set; }


        /// <summary>
        /// 選擇欄位，用於內部識別該筆刷卡紀錄在卡鐘內的唯一識別碼（可忽略此欄位）
        /// </summary>
        [AllowNull]
        [ValidateNever]
        public int? clientTranSID { get; set; }
    }





    public class TransactionSimpleBindingModel
    {
        /// <summary>
        /// [卡號]固定長度10位數值，且符合Integer數值型態。實際儲存將轉換為10碼長度字串，若不足10位則由API往左補0
        /// </summary>
        public int cardID { get; set; }


        /// <summary>
        /// [設備代碼]2位數值
        /// </summary>
        public byte deviceID { get; set; }
    }



}
