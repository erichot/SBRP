using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Models
{
    /// <summary>
    /// 貨號定價  
    /// </summary>
    [Table(nameof(ProductPrice), Schema = SBRPData.DbSystemModel.DB_Schema_psi)]
    public class ProductPrice
    {
        public ProductPrice() { }

        public ProductPrice(ProductPriceDefinition _ppd) 
        {
            PriceNo = _ppd.PriceNo;
            UnitPrice = 0;
        }

        public int ProductNo { get; set; }

        public byte PriceNo { get; set; }




        [Display(Name = "定價")]
        [Column(TypeName = "DECIMAL(8, 2)")]
        public decimal UnitPrice { get; set; }




        public virtual Product Product { get; set; }

    }
}
