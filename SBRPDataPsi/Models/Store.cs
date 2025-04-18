using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Models
{
    /// <summary>
    /// 門市基本資料：具有實體地理位置，為銷貨的主體，受體是商品，銷貨的對象是顧客
    /// </summary>
    /// <remarks>
    /// 門市與倉庫幾乎是等同關係，但是倉庫是物流上的概念，門市是商業上的概念（銷貨單）
    /// </remarks>
    [Table(nameof(Store), Schema = SBRPData.DbSystemModel.DB_Schema_psi)]
    [Index(nameof(StoreId), nameof(SIGNo), IsUnique = true)]
    public class Store
    {
        // 倉庫代碼
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short StoreNo { get; set; }



        [Display(Name ="門市代碼")]
        [Required]
        [Column(TypeName = "CHAR(16)")]
        [MaxLength(16)]
        public string StoreId { get; set; }


        public byte SIGNo { get; set; }








        [Display(Name ="門市名稱")]
        [StringLength(32)]
        public string StoreName { get; set; }


        [Display(Name = "門市簡稱")]
        [StringLength(12)]
        public string StoreNameAbbr { get; set; }


        // 若該門市屬於中盤
        public short? CompanyNo { get; set; }




        // 門市子母概念，保留未使用
        public short? ParentStoreNo { get; set; }


        // 門市分區概念，保留未使用
        public short? StoreRegionNo { get; set; }







        public bool IsSystemPredefined { get; set; }


        [Display(Name = "是否為虛擬門市（無實體門市地址）")]
        public bool IsVirtualStore { get; set; }

        public bool IsDisabled { get; set; }




        [Display(Name = "備註")]
        [StringLength(48)]
        [MaxLength(48)]
        public string? Remark { get; set; } = string.Empty;

             
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













        // 若該門市屬於中盤
        [ForeignKey(nameof(CompanyNo))]
        public virtual SBRPData.Models.Company? Company { get; set; }


        [ForeignKey(nameof(StoreRegionNo))]
        public virtual StoreRegion? StoreRegion { get; set; }









        [NotMapped]
        public int LogNo { get; set; }

        [NotMapped]
        public int LoginActionNo { get; set; }


        [NotMapped]
        public Stock? Stock { get; set; }







        public void SetSIG(byte _sIGNo)
        {
            this.SIGNo = _sIGNo;

            if (this.Company != null)
            {
                this.Company?.SetSIG(_sIGNo);
            }
        }



        public void SetCreatePerson(short _userNo, DateTime? _createdDate = null)
        {
            this.CreatedDate = _createdDate ?? DateTime.Now;
            this.CreatedPerson = _userNo;

            if (this.Company != null && this.Company?.CreatedPerson == null)
            {
                this.Company?.SetCreatePerson(_userNo, this.CreatedDate);
            }
        }


        public static string GetDisplayName<TProperty>(Expression<Func<Store, TProperty>> expression)
        {
            return (new Store()).GetDisplayName(expression);
        }
    }










    public class StoreFilter
    {
        public string StoreId { get; set; }

        public string StoreName { get; set; }

        public Store ToEntity()
        {
            return new Store()
            {
                StoreId = StoreId,
                StoreName = StoreName
            };
        }
    }

}
