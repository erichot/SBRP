using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// [PrimaryKey]欄位已有SIGNo的特性，不需再加入
    /// (1) 建立[Store] or [Product]時，同時建立[ProductStock]
    /// </remarks>
    [Table(nameof(ProductStock), Schema = SBRPData.DbSystemModel.DB_Schema_psi)]
    public class ProductStock
    {
        public short StockNo { get; set; }

        public int ProductNo { get; set; }








        
        
        // 調撥在途量（已調撥、未收貨（未入庫））
        [Display(Name = "在途量")]
        public short InTransitQty { get; set; }


        public short PreOrderQty { get; set; }




        // 庫存量（不包含在途量）／不理會客訂（也就是可能包含著客訂量）
        [Display(Name = "庫存量")]
        public int StockQty { get; set; }


        // 可銷量 = 庫存量 - 客訂量 
        [Display(Name = "可銷量")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int SellableQty { get; set; }







        public int OrderNo { get; set; }
        public int LogNo { get; set; }






        [BindNever]
        [JsonIgnore]
        [ValidateNever]
        [Display(Name = "建檔人員")]
        public short CreatedPerson { get; set; }

        [BindNever]
        [JsonIgnore]
        [ValidateNever]
        [Display(Name = "建檔日期")]
        public DateTime CreatedDate { get; set; }


        [BindNever]
        [JsonIgnore]
        [ValidateNever]
        [Display(Name = "異動人員")]
        public short? UpdatedPerson { get; set; }

        [BindNever]
        [JsonIgnore]
        [ValidateNever]
        [Display(Name = "異動日期")]
        public DateTime? UpdatedDate { get; set; }




    }









    public class ProductStockPivotReportFilter
    {
        public string UserID { get; set; }
        public string SearchKeywordArray { get; set; }



        public string StoreSelectionArray { get; set; }
        public bool IsGroupByColor { get; set; }
        public bool IsGroupBySize { get; set; }
    }


}
