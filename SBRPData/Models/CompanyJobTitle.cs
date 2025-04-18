using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPData.Models
{
    [NotMapped]
    [Table(nameof(CompanyJobTitle), Schema = DbSystemModel.DB_Schema_common)]
    [Index(nameof(JobTitleId))]
    public class CompanyJobTitle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short JobTitleNo { get; set; }


        public byte SIGNo { get; set; } = default(byte);





        [Column(TypeName = "CHAR(12)")] 
        public string JobTitleId { get; set; }



      





        [Required]
        [StringLength(16)]
        public string JobTitleName { get; set; }








        public bool IsSystemPredefined { get; set; }











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








        [Display(Name = "是否已提交")]
        public bool? IsSubmitted { get; set; }

        [Display(Name = "提交人員")]
        public int? SubmittedPerson { get; set; }

        [Display(Name = "提交日期")]
        public DateTime? SubmittedDate { get; set; }









        [Display(Name = "是否已核准")]
        public bool? IsApproved { get; set; }

        [Display(Name = "核准主管")]
        public int? ApprovedPerson { get; set; }

        [Display(Name = "核准日期")]
        public DateTime? ApprovedDate { get; set; }












    }
}
