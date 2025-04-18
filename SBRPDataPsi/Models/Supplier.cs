using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace SBRPDataPsi.Models
{

    [Table(nameof(Supplier), Schema = SBRPData.DbSystemModel.DB_Schema_psi)]
    [Index(nameof(CompanyNo))]
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short SupplierNo { get; set; }






        [Display(Name = "供應商代碼")]
        [Required]
        [Column(TypeName = "CHAR(16)")]
        [MaxLength(16)]
        public string SupplierId { get; set; }
        //{
        //    get {
        //        if (string.IsNullOrEmpty(m_SupplierId) && !string.IsNullOrEmpty(Company?.CompanyId))
        //            return Company.CompanyId.Trim();

        //        return m_SupplierId?.Trim();
        //    }
        //    set { m_SupplierId = value?.Trim(); }   
        //}

        public byte SIGNo { get; set; } = default(byte);




        public short CompanyNo { get; set; }



        public short SupplierGroupNo { get; set; }







        //private string m_SupplierName;
        [Required]
        [Display(Name = "供應商名稱")]
        [MaxLength(32)]
        [StringLength(32)]
        public string SupplierName { get; set; }
        //{
        //    get 
        //    { 
        //        if (string.IsNullOrEmpty(m_SupplierName) && !string.IsNullOrEmpty(Company?.CompanyName))
        //           return Company.CompanyName;

        //        return m_SupplierName?.Trim();
        //    }
        //    set { m_SupplierName = value?.Trim(); }
        //}



        //private string m_SupplierNameAbbr;
        [Required]
        [Display(Name = "簡稱")]
        [StringLength(12)]
        public string SupplierNameAbbr { get; set; }
        //{
        //    get
        //    {
        //        if (string.IsNullOrEmpty(m_SupplierNameAbbr) && !string.IsNullOrEmpty(Company?.CompanyNameAbbr))
        //            return Company.CompanyNameAbbr;

        //        return m_SupplierNameAbbr?.Trim();
        //    }
        //    set { m_SupplierNameAbbr = value?.Trim(); }
        //}







        // 不允許同一供應商使用不同幣別金額入庫
        [Display(Name = "外幣幣別")]
        public CurrencyEnum CurrencyNo { get; set; } = CurrencyEnum.TWD;



        [Display(Name = "結帳週期類型")]
        public DateRangeTypeEnum? BillingPeriodType { get; set; }


        [Display(Name = "結帳日")]
        [Range(1, 31)]
        public byte? BillingPeriodDay { get; set; }






        [Display(Name = "付款週期類型")]
        public DateRangeTypeEnum? PaymentPeriodType { get; set; }



        [Display(Name = "付款日")]
        [Range(1, 31)]
        public byte? PaymentPeriodDay { get; set; }



        [Display(Name = "保留未使用")]
        public short? StockNo_Default { get; set; }









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





















        // 預設供應商一定是公司，若為個人，則應建立虛擬假公司
        [ForeignKey(nameof(CompanyNo))]
        public virtual SBRPData.Models.Company Company { get; set; }














        [NotMapped]
        public int LogNo { get; set; }



        [NotMapped]
        public int LoginActionNo { get; set; }


        [NotMapped]
        public bool? IsDisabled_Filter { get; set; } = false;



        public void SetSupplierGroup(short _supplierGroupNo)
        {
            this.SupplierGroupNo = _supplierGroupNo;
        }

        public void SetSIG(byte _sIGNo)
        {
            this.SIGNo = _sIGNo;

            if (this.Company != null )
            {
                this.Company?.SetSIG(_sIGNo);
            }
        }



        public void SetCreatedPerson(short _userNo, DateTime? _createdDate = null)
        {
            this.CreatedDate = _createdDate??DateTime.Now;
            this.CreatedPerson = _userNo;

            if (this.Company != null && this.Company?.CreatedPerson == null)
            {
                this.Company?.SetCreatePerson(_userNo, this.CreatedDate);
            }
        }


        public static string GetDisplayName<TProperty>(Expression<Func<Supplier, TProperty>> expression)
        {
            return (new Supplier()).GetDisplayName(expression);
        }
    }








    [NotMapped]
    public class SupplierFilter
    {

        public short? SupplierNo { get; set; }

        public byte SIGNo { get; set; }


        public string SupplierId { get; set; }


        public string SupplierName { get; set; }




        public Supplier ToEntity()
        {
            return new Supplier()
            {
                SupplierNo = this.SupplierNo.ToShort(),
                SIGNo = this.SIGNo,
                SupplierId = this.SupplierId
            };
        }
    }
}
