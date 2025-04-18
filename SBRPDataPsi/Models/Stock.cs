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
    /// 門市與倉庫幾乎是等同關係，但是倉庫是物流上的概念，門市是商業上的概念（銷貨單）
    /// </remarks>
    [Table(nameof(Stock), Schema = SBRPData.DbSystemModel.DB_Schema_psi)]
    public class Stock
    {
        public Stock() { }


        /// <summary>
        /// 新增門市時，將門市資料複製到倉庫資料
        /// </summary>
        /// <param name="store"></param>
        // Write a Constructor accept [Store] parameter, then copy all property data which has the same or similar member name from the parameter to its own property.
        public Stock(Store store)
        {
            StockNo = store.StoreNo;
            StockId = store.StoreId;
            StockName = store.StoreName;
            StockNameAbbr = store.StoreNameAbbr;
            IsLinkToStore = true;
            ParentStockNo = store.ParentStoreNo;
            CreatedPerson = store.CreatedPerson;
            CreatedDate = store.CreatedDate;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <DefaultValue>
        /// (a) 獨立、特別倉 >= 1001 
        /// (b) 門市 StockNo = 倉庫 StoreNo
        /// </default>
        public short StockNo { get; set; }


        [Display(Name ="倉庫代碼")]
        [Required]
        [Column(TypeName = "CHAR(16)")]
        [MaxLength(16)]
        public string StockId { get; set; }


        public byte SIGNo { get; set; }





        [Display(Name = "倉庫名稱")]
        [StringLength(32)]
        public string StockName { get; set; }


        [Display(Name = "倉庫簡稱")]
        [StringLength(12)]
        public string StockNameAbbr { get; set; }




        // 保留未使用
        public short? ParentStockNo { get; set; }







        public bool IsLinkToStore { get; set; }

        public bool IsSystemPredefined { get; set; }

        public bool IsDisabled { get; set; }




        [Display(Name = "備註")]
        [StringLength(48)]
        [MaxLength(48)]
        public string? Remark { get; set; } = string.Empty;


        [Display(Name = "是否已刪除")]
        public bool IsDeleted { get; set; }










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


        [BindNever]
        [JsonIgnore]
        [ValidateNever]
        [Display(Name = "刪除人員")]
        public short? DeletedPerson { get; set; }

        [BindNever]
        [JsonIgnore]
        [ValidateNever]
        [Display(Name = "刪除日期")]
        public DateTime? DeletedDate { get; set; }








        // 保留未使用
        [ForeignKey(nameof(ParentStockNo))]
        public Stock? ParentStock { get; set; }




        [BindNever]
        [JsonIgnore]
        [ValidateNever]
        [NotMapped]
        public int LoginActionNo { get; set; }



        // 僅適用於前端 ViewModel 使用
        [BindNever]
        [JsonIgnore]
        [ValidateNever]
        [NotMapped]
        public StockOperationActionEnum StockOperationAction { get; set; }






        public void SetSIG(byte _sIGNo)
        {
            this.SIGNo = _sIGNo;
        }


        public static string GetDisplayName<TProperty>(Expression<Func<Stock, TProperty>> expression)
        {
            return (new Stock()).GetDisplayName(expression);
        }
    }











    public class StockFilter
    {
        public string StoreId { get; set; }

        public string StoreName { get; set; }


        public bool? IsSystemPredefined_Filter { get; set; } = false;

        public bool? IsDisabled_Filter { get; set; } = false;



        public Stock ToEntity()
        {
            return new Stock()
            {
            };
        }
    }
}
