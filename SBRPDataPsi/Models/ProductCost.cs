using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Models
{
    /// <summary>
    /// 商品成本
    /// </summary>
    [Table(nameof(ProductCost), Schema = SBRPData.DbSystemModel.DB_Schema_psi)]
    public class ProductCost
    {
        public ProductCost() { }

        public ProductCost(ProductCostDefinition _ppd)
        {
            CostNo = _ppd.CostNo;
            UnitCost = 0;
        }

        public int ProductNo { get; set; }

        public byte CostNo { get; set; }




        [Display(Name = "成本")]
        [Column(TypeName = "DECIMAL(8, 2)")]
        public decimal UnitCost { get; set; }




        public  Product Product { get; set; }

    }
}
