using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Models
{
    [Table(nameof(Product), Schema = SBRPData.DbSystemModel.DB_Schema_psi)]
    [Index(nameof(ParentProductNo))]
    public class Product
    {
        public Product() 
        {
            this.ProductGeneralCategories = new HashSet<ProductGeneralCategory>();
            this.ProductSuppliers = new HashSet<ProductSupplier>();
        }



        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductNo { get; set; }



        private string m_ProductId;
        [Display(Name = "貨號")]
        [Column(TypeName = "CHAR(32)")]
        [MaxLength(32)]
        public string ProductId 
        { 
            get { return m_ProductId.SafeTrim(); }
            set { m_ProductId = value.ToUpper(); }
        }




        

        


        public byte SIGNo { get; set; } = default(byte);




        [Display(Name = "品名")]
        [StringLength(32)]
        [MaxLength(32)]
        public string ProductName { get; set; }





        private string m_Barcode;
        [Display(Name = "條碼")]
        [Column(TypeName = "CHAR(32)")]
        [MaxLength(32)]
        public string Barcode
        {
            get { return m_Barcode.SafeTrim(); }
            set { m_Barcode = value.ToUpper(); }
        }





        // 保留不使用
        //[Display(Name = "國際條碼")]
        //[Range(0,9999999999999)]
        //public long GTIN { get; set; }




        [Display(Name = "原廠編號")]
        [Column(TypeName = "CHAR(32)")]
        [MaxLength(32)]
        public string ProductIdFromSupplier { get; set; }



        public int? ParentProductNo { get; set; } 









        // 允許關聯商品貨號 => [ParentProductNo]
        [Display(Name = "商品貨號組頭")]
        public bool IsParentalProduct { get; set; }


        // 非實體商品貨號
        [Display(Name = "不允許參與單據作業")]
        public bool IsNotForOrderProcessing { get; set; }


        public bool IsSystemPredefined { get; set; }

        public bool IsInvisible { get; set; }

        public bool IsDisabled { get; set; }

     




        [Display(Name = "備註")]
        [StringLength(48)]
        [MaxLength(48)]
        public string? Remark { get; set; } = string.Empty;


        [BindNever]
        [JsonIgnore]
        [ValidateNever]
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









        public  ICollection<ProductCost> ProductCosts { get; set; }

        public  ICollection<ProductGeneralCategory> ProductGeneralCategories { get; set; }

        public  ICollection<ProductPrice> ProductPrices { get; set; }

        public  ICollection<ProductSupplier> ProductSuppliers { get; set; }















        



















        public void SetSIG(byte _sIGNo)
        {
            this.SIGNo = _sIGNo;
        }
        public void SetCreatePerson(short _userNo, DateTime? _createdDate = null)
        {
            this.CreatedPerson = _userNo;
            this.CreatedDate = _createdDate ?? DateTime.Now;
        }
        public void SetUpdatePerson(short _userNo, DateTime? _updatedDate = null)
        {
            this.UpdatedPerson = _userNo;
            this.UpdatedDate = _updatedDate ?? DateTime.Now;
        }
        public void SetDeletePerson(short _userNo, DateTime? _deletedDate = null)
        {
            this.DeletedPerson = _userNo;
            this.DeletedDate = _deletedDate ?? DateTime.Now;
        }

        public void MergeFrom(Product _source)
        {
           
        }







        public static string GetDisplayName<TProperty>(Expression<Func<Product, TProperty>> expression)
        {
            return (new Product()).GetDisplayName(expression);
        }
    }










    public class ProductFilter
    {
        public Product ToEntity()
        {
            return new Product()
            {
            };
        }
    }



}
