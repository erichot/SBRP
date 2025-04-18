using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SBRPData.Models
{
    // 適用於供應商、客戶
    // 不需完整的 [Person]，[Person]沒那麼重要，重要的是聯絡資料
    // 由於必定歸屬於CompanyNo，故不需SigIdn
    [Table(nameof(CompanyContactPerson), Schema = DbSystemModel.DB_Schema_common)]
    [PrimaryKey(nameof(CompanyNo), nameof(ContactItemNo))]
    public class CompanyContactPerson
    {

        public CompanyContactPerson() { }
        public CompanyContactPerson(short _contactItemNo)
        {
            ContactItemNo = _contactItemNo;
        }
        public CompanyContactPerson(short _companyNo, short _contactItemNo)
        {
            CompanyNo = _companyNo;
            ContactItemNo = _contactItemNo;
        }

        public short CompanyNo { get; set; }


        [Display(Name = "序")]
        public short ContactItemNo { get; set; }








        // 備用
        public int? PersonNo { get; set; }



     



        [Display(Name = "職稱")]
        [StringLength(16)]
        [MaxLength(16)]

        public string? Title { get; set; } = string.Empty;
















        [Display(Name = "聯絡人")]
        [StringLength(16)]
        [MaxLength(16)]
        public string? ContactName { get; set; } = string.Empty;


        [Display(Name = "聯絡地址")]
        [StringLength(64)]
        [MaxLength(64)]
        public string? ContactAddress { get; set; } = string.Empty;



        [Display(Name = "聯絡電話")]
        [Column(TypeName = "VARCHAR(16)")]
        [MaxLength(16)]
        public string? ContactPhone { get; set; } = string.Empty;




        [Display(Name = "行動電話")]
        [Column(TypeName = "VARCHAR(16)")]
        [MaxLength(16)]
        public string? MobilePhone { get; set; } = string.Empty;



        [EmailAddress]
        [Display(Name = "電子郵件")]
        [Column(TypeName = "VARCHAR(64)")]
        [MaxLength(64)]
        public string? EmailAddress { get; set; } = string.Empty;












        [Display(Name = "備註")]
        [StringLength(48)]
        [MaxLength(48)]
        public string? Remark { get; set; } = string.Empty;


        [Display(Name = "是否已刪除")]
        public bool IsDeleted { get; set; }






        [Display(Name = "建檔人員")]
        public int CreatedPerson { get; set; }

        [Display(Name = "建檔日期")]
        public DateTime CreatedDate { get; set; }



        [Display(Name = "異動人員")]
        public int? UpdatedPerson { get; set; }

        [Display(Name = "異動日期")]
        public DateTime? UpdatedDate { get; set; }






        [Display(Name = "刪除人員")]
        public int? DeletedPerson { get; set; }

        [Display(Name = "刪除日期")]
        public DateTime? DeletedDate { get; set; }















        // 必須要歸屬於某一間公司（的聯絡人）
        // 從新增的角度來看，要由 [Company] 作為Parent
        [ForeignKey(nameof(CompanyNo))]
        public virtual Company Company { get; set; }




        [ForeignKey(nameof(PersonNo))]
        public virtual Person? Person { get; set; }











        public void SetCreatePerson(short _userNo, DateTime? _createdDate = null)
        {
            this.CreatedDate = _createdDate ?? DateTime.Now;
            this.CreatedPerson = _userNo;
        }


        public static string GetDisplayName<TProperty>(Expression<Func<CompanyContactPerson, TProperty>> expression)
        {
            return (new CompanyContactPerson()).GetDisplayName(expression);
        }
    }
}
