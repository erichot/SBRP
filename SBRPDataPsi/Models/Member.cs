using SBRPData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Models
{
    
    [Table(nameof(Member), Schema = SBRPData.DbSystemModel.DB_Schema_psi)]
    public class Member
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberNo { get; set; }



        private string m_MemberId;
        [Display(Name = "會員代碼")]
        [Column(TypeName = "CHAR(36)")]
        [MaxLength(36)]
        public string MemberId
        {
            get { return m_MemberId.SafeTrim(); }
            set { m_MemberId = value.ToUpper(); }
        }
      


        public byte SIGNo { get; set; } = default(byte);




        [Display(Name = "會員姓名")]
        [StringLength(16)]
        [MaxLength(16)]
        public string MemberName { get; set; } 



        public int PersonNo { get; set; }














        [Display(Name = "價別")]
        public byte ProductPriceNo { get; set; }




        [Range(0, 12)]
        public byte? Birthday_Month { get; set; }

        [Range(0, 31)]
        public byte? Birthday_Day { get; set; }


        [Display(Name = "生日：月/日)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string? Birthday_MonthDay { get; set; }




        [Display(Name = "備註")]
        [StringLength(36)]
        [MaxLength(36)]
        public string? Remark { get; set; } = string.Empty;









        [Display(Name = "是否已停用")]
        public bool IsDisabled { get; set; }


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






        [ForeignKey(nameof(PersonNo))]
        public SBRPData.Models.Person? Person { get; set; }











        public void SetSIG(byte _sIGNo)
        {
            this.SIGNo = _sIGNo;
        }
        public void SetCreatePerson(short _userNo, DateTime? _createdDate = null)
        {
            this.CreatedPerson = _userNo;
            this.CreatedDate = _createdDate ?? DateTime.Now;
        }



        public void SetMonthDay(string _monthDay)
        {
            if (string.IsNullOrWhiteSpace(_monthDay)) return;

            var monthDayArray = _monthDay.Split('/');
            if (monthDayArray.Length == 2)
            {
                this.Birthday_Month = byte.Parse(monthDayArray[0]);
                this.Birthday_Day = byte.Parse(monthDayArray[1]);
            }
        }







        public void SyncToPerson()
        {
            if (this.Person != null)
            {
                this.Person.PersonNo = this.MemberNo;
                this.Person.PersonId = this.MemberId;
                this.Person.PersonName = this.MemberName;
                this.Person.Remark = this.Remark;
                this.Person.IsDisabled = this.IsDisabled;
                this.Person.IsDeleted = this.IsDeleted;
                this.Person.CreatedDate = this.CreatedDate;
                this.Person.CreatedPerson = this.CreatedPerson;
                this.Person.UpdatedDate = this.UpdatedDate;
                this.Person.UpdatedPerson = this.UpdatedPerson;

                if (this.Person.PersonContactPhones != null && this.Person.PersonContactPhones.Any())
                {
                    foreach (var item in this.Person.PersonContactPhones)
                    {
                        item.PersonNo = this.MemberNo;                        
                    }
                }
            }            
        }






        public static string GetDisplayName<TProperty>(Expression<Func<Member, TProperty>> expression)
        {
            return (new Member()).GetDisplayName(expression);
        }
    }









    public class MemberFilter
    {
        public Member ToEntity()
        {
            return new Member()
            {
            };
        }
    }

}
