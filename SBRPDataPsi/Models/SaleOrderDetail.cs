using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Models
{
    [Table(nameof(SaleOrderDetail), Schema = SBRPData.DbSystemModel.DB_Schema_psi)]
    public class SaleOrderDetail
    {
                


        [Display(Name = "OrderNo")]
        public int OrderNo { get; set; }


        [Display(Name ="項次")]
        public short ItemNo { get; set; }


        [Display(Name = "ProductNo")]
        public int ProductNo { get; set; }


        
        [Display(Name = "定價")]
        [Column(TypeName = "DECIMAL(8, 2)")]
        public decimal UnitPrice { get; set; }


        [Display(Name = "折數")]
        [Column(TypeName = "DECIMAL(3, 2)")]
        public decimal DiscountPercentage { get; set; }


        [Display(Name = "實售價")]
        [Column(TypeName = "DECIMAL(8, 2)")]
        public decimal ActualSellingPrice { get; set; }



        [Display(Name ="數量")]
        public int Quantity { get; set; }


        [Display(Name = "小計")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal SubAmount { get; set; }







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



        public static string GetDisplayName<TProperty>(Expression<Func<SaleOrderDetail, TProperty>> expression)
        {
            return (new SaleOrderDetail()).GetDisplayName(expression);
        }


    }
}
