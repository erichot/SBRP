using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Models
{
    [Table(nameof(StockTransferOrderDetail), Schema = SBRPData.DbSystemModel.DB_Schema_psi)]
    public class StockTransferOrderDetail
    {
        [Display(Name = "OrderNo")]
        public int OrderNo { get; set; }


        [Display(Name = "項次")]
        public short ItemNo { get; set; }


        [Display(Name = "ProductNo")]
        public int ProductNo { get; set; }




        [Display(Name = "數量")]
        public int Quantity { get; set; }







        [Display(Name = "備註")]
        [StringLength(48)]
        [MaxLength(48)]
        public string? Remark { get; set; } = string.Empty;


















        [ForeignKey(nameof(ProductNo))]
        public Product Product { get; set; }









        [NotMapped]
        public int LogNo { get; set; }


        [NotMapped]
        public int LoginActionNo { get; set; }



        public static string GetDisplayName<TProperty>(Expression<Func<StockTransferOrderDetail, TProperty>> expression)
        {
            return (new StockTransferOrderDetail()).GetDisplayName(expression);
        }
    }
}
