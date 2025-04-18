using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPBusiness.Models
{
    public class BusinessEnumModel
    {
    }




    // 需簽核作業資料載入政策
    public enum OperationEntityLoadingPolicyEnum : byte
    {


        // 指定載入原始資料
        [Display(Name = "原始資料")]
        Original = 0,

        // 自動判斷送審或原始資料
        [Display(Name = "自動判斷")]
        Auto = 1,

        // 載入原始資料並建立暫存編輯
        [Display(Name = "載入原始資料並建立暫存編輯")]
        LoadToDraftForEditing = 2,
    }

}
