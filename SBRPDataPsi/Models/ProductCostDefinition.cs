using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Models
{
    /// <summary>
    /// Cost 0 入庫/進貨成本
    /// Cost 1 銷貨成本
    /// </summary>
    /// <history>
    /// 2025/3/16 Created
    /// </history>
    /// <remarks>
    /// 目前不提供給客戶指定
    /// INSERT  [psi].[uspINSERT_SystemIsolationGroup_SIGWithRelateDefault]
    /// </remarks>
    [Table(nameof(ProductCostDefinition), Schema = SBRPData.DbSystemModel.DB_Schema_psi)]
    public class ProductCostDefinition
    {
        public byte SIGNo { get; set; } = default(byte);




        [Display(Name = "系統序號")]
        public byte CostNo { get; set; }


      


        [Display(Name = "名稱")]
        [StringLength(12)]
        public string CostDefinitionName { get; set; }


     



        public static string GetDisplayName<TProperty>(Expression<Func<ProductCostDefinition, TProperty>> expression)
        {
            return (new ProductCostDefinition()).GetDisplayName(expression);
        }
    }
}
