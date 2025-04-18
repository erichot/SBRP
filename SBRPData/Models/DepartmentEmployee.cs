using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPData.Models
{
    [Table(nameof(DepartmentEmployee), Schema = DbSystemModel.DB_Schema_common)]
    [PrimaryKey(nameof(DepartmentNo), nameof(EmployeeNo), nameof(StartDate))]
    public class DepartmentEmployee
    {
        public short DepartmentNo { get; set; }

        public short EmployeeNo { get; set; }   


        public DateOnly? StartDate { get; set; }





        public DateOnly? EndDate { get; set; }
















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











        [ForeignKey(nameof(DepartmentNo))]
        public virtual Department Department { get; set; }



        [ForeignKey(nameof(EmployeeNo))]
        public virtual Employee Employee { get; set; }  




    }
}
