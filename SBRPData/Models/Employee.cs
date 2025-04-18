using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPData.Models
{
    // 內部員工：考勤、會計、薪資
    [NotMapped]
    [Table(nameof(Employee), Schema = DbSystemModel.DB_Schema_common)]
    [Index(nameof(EmployeeId))] 
    public class Employee
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public short EmployeeNo { get; set; }


        public byte SIGNo { get; set; } = default(byte);







        private string m_EmployeeId = string.Empty;
        [Display(Name = "員工編號")]
        [Column(TypeName = "CHAR(16)")]
        public string EmployeeId
        {
            get
            {
                if (string.IsNullOrEmpty(m_EmployeeId))
                    return Person.PersonId.Trim();

                return m_EmployeeId?.Trim()??string.Empty;
            }
            set { m_EmployeeId = value?.Trim() ?? string.Empty; }
        }



        //get { return Convert.ToInt32(Math.Floor(Convert.ToDecimal(EmployeeNo / 100_000))); }
        //public int CompanyNo { get; set; }


        public int PersonNo { get; set; }




        // get { return Convert.ToInt32(CompanyNo.ToString("000000").Right(5)); }
        //private int m_EmployeeItemNo;
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //public int EmployeeItemNo
        //{
        //    // 2,147,483,647
        //    // 21474 83647
        //    get { return m_EmployeeItemNo; }
        //    set { m_EmployeeItemNo = value; }
        //}











        [Display(Name = "職位")]
        public short? PositionNo { get; set; }


        //[Display(Name = "職稱")]
        //public short JobTitleNo { get; set; } = default(short);












        [Display(Name = "到職日")]
        public DateOnly? StartDate { get; set; }


        [Display(Name = "離職日")]
        public DateOnly? EndDate { get; set; }








        public bool IsSystemPredefined { get; set; }

        public bool IsInvisible { get; set; }


        public bool IsDisabled { get; set; }





        [Display(Name ="備註")]
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
















        //[ForeignKey(nameof(JobTitleNo))]
        //public virtual CompanyJobTitle CompanyJobTitle { get; set; }




        [ForeignKey(nameof(PersonNo))]
        public virtual Person Person { get; set; }









    }
}
