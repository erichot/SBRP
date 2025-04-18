using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Models
{
    /// <summary>
    /// 成本、定價混用（用於單據新增明細時取出預設Price/Cost）
    /// 定義該客戶商品的價格欄位數量及各定價的初始計算比率，小數點位數
    /// PriceNo 0為預設欄位，其餘價格依比率來自於PriceNo 0
    /// Zero based
    /// </summary>
    [Table(nameof(ProductPriceDefinition), Schema = SBRPData.DbSystemModel.DB_Schema_psi)]
    public class ProductPriceDefinition
    {
        public byte SIGNo { get; set; } = default(byte);




        [Display(Name = "系統序號")]
        public byte PriceNo { get; set; }


       


        [Display(Name = "系統名稱")]
        [StringLength(12)]
        public string PriceDefinitionName { get; set; }




        [Display(Name = "顯示名稱")]
        [StringLength(12)]
        public string PriceDefinitionDisplayName { get; set; }




        // Default Price value from PriceNo 0
        [Display(Name = "依據來源")]
        public byte? ParentPriceNo { get; set; } 


        // Default Price value from PriceNo 0
        [Display(Name = "依據來源定價計算比率")]
        [Column(TypeName = "DECIMAL(5, 3)")]
        public decimal PercentageToParent { get; set; }



        // 小數點左側（整數金額）取位
        [Display(Name = "左側四捨五入進位數")]
        public byte RoundUpDigitNumber { get; set; }


        [Display(Name = "是否為初始定價")]
        public bool IsInitial { get; set; }




        public static string GetDisplayName<TProperty>(Expression<Func<ProductPriceDefinition, TProperty>> expression)
        {
            return (new ProductPriceDefinition()).GetDisplayName(expression);
        }
    }
}
