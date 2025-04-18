using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPData.Models
{
    /// <summary>
    /// 系統隔離群組
    /// </summary>
    /// <remarks>
    /// 需要預先建立特殊公司資料[Company]
    /// </remarks>
    [Table(nameof(SystemIsolationGroup), Schema = DbSystemModel.DB_Schema_common)]
    [Index(nameof(SIGId), IsUnique = true)] 
    public class SystemIsolationGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public byte SIGNo { get; set; }


        [Column(TypeName = "CHAR(12)")]
        public string SIGId { get; set; }


        [StringLength(24)]
        public string SIGName { get; set; }











        public short CompanyNo { get; set; }



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



    }
}
