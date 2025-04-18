using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace SBRPData.Models
{
    // 系統本身所使用的公司，內部員工：Tms刷卡員工、HRM員工
    // psi:供應商、客戶、合作夥伴、代工
    // tms:
    // hrm:
    // pms:客戶、供應商、代工
    // acc:客戶、供應商、代工    
    [Table(nameof(Company), Schema = DbSystemModel.DB_Schema_common)]
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short CompanyNo { get; set; }


        private string m_CompanyId = string.Empty;
        [Required]
        [Column(TypeName ="CHAR(16)")]
        [MaxLength(16)]
        [Display(Name ="公司代碼")]
        public string CompanyId 
        { 
            get { return m_CompanyId.Trim(); }
            set { m_CompanyId = value; }
        }

        public byte SIGNo { get; set; } = default;




        [Display(Name = "統一編號")]
        [Column(TypeName = "CHAR(10)")]
        [MaxLength(10)]
        public string TaxId { get; set; } = string.Empty;




        [Display(Name = "公司名稱")]
        [StringLength(40)]
        [MaxLength(40)]
        public string CompanyName { get; set; } = string.Empty;




        [Display(Name = "公司簡稱")]
        [StringLength(12)]
        [MaxLength(12)]
        public string CompanyNameAbbr { get; set; } = string.Empty;







        [Display(Name = "負責人")]
        [StringLength(16)]
        [MaxLength(16)]
        public string? CompanyDirector { get; set; } = string.Empty;


        [Display(Name = "公司地址")]
        [StringLength(64)]
        [MaxLength(64)]
        public string? CompanyAddress { get; set; } = string.Empty;



        [Display(Name = "郵寄地址")]
        [StringLength(64)]
        [MaxLength(64)]
        public string? PostalAddress { get; set; } = string.Empty;




        [Display(Name = "公司電話")]
        [Column(TypeName = "VARCHAR(16)")]
        [MaxLength(16)]
        public string? CompanyPhone { get; set; } = string.Empty;



        [AllowNull]
        [Url]
        [Display(Name = "公司網站")]
        [Column(TypeName = "VARCHAR(64)")]
        [MaxLength(64)]
        public string? CompanyWeb { get; set; } = string.Empty;










        public bool IsSystemPredefined { get; set; }


        public bool IsDisabled { get; set; }





        [Display(Name = "備註")]
        [StringLength(48)]
        [MaxLength(48)]
        public string? Remark { get; set; } = string.Empty;


        [Display(Name = "是否已刪除")]
        public bool IsDeleted { get; set; }







        [Display(Name = "建檔人員")]
        public short CreatedPerson { get; set; }

        [Display(Name = "建檔日期")]
        public DateTime CreatedDate { get; set; }



        [Display(Name = "異動人員")]
        public short? UpdatedPerson { get; set; }

        [Display(Name = "異動日期")]
        public DateTime? UpdatedDate { get; set; }



        [Display(Name = "刪除人員")]
        public short? DeletedPerson { get; set; }

        [Display(Name = "刪除日期")]
        public DateTime? DeletedDate { get; set; }








        [Display(Name = "是否已提交")]
        public bool? IsSubmitted { get; set; }

        [Display(Name = "提交人員")]
        public short? SubmittedPerson { get; set; }

        [Display(Name = "提交日期")]
        public DateTime? SubmittedDate { get; set; }









        [Display(Name = "是否已核准")]
        public bool? IsApproved { get; set; }

        [Display(Name = "核准主管")]
        public short? ApprovedPerson { get; set; }

        [Display(Name = "核准日期")]
        public DateTime? ApprovedDate { get; set; }

















        [NotMapped]
        public int LogNo { get; set; }


        [NotMapped]
        public int LoginActionNo { get; set; }









        public virtual ICollection<CompanyContactPerson> CompanyContactPersons { get; set; }





        public void SetSIG(byte _sIGNo)
        {
            this.SIGNo = _sIGNo;
        }


        public void SetCreatePerson(short _userNo, DateTime? _createdDate = null)
        {
            this.CreatedDate = _createdDate??DateTime.Now;
            this.CreatedPerson = _userNo;

            if (this.CompanyContactPersons.Any())
            {
                this.CompanyContactPersons.ToList()
                    .ForEach(r =>
                        r.SetCreatePerson(_userNo, this.CreatedDate));
            }
        }

    }
}
