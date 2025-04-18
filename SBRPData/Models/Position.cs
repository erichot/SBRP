using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPData.Models
{
    /// <summary>
    /// 通用類型的職位
    /// </summary>
    /// <remarks>
    /// 可用於配置權限，可搭配[Department] 或 [Division] 使用
    /// </remarks>
    [Table(nameof(Position), Schema = DbSystemModel.DB_Schema_common)]
    [Index(nameof(PositionId))]
    public class Position
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short PositionNo { get; set; }


        public byte SIGNo  { get; set; } = default(byte);






        [Column(TypeName = "CHAR(12)")]
        public string PositionId { get; set; }


        [StringLength(24)]
        public string PositionName { get; set; }


        [StringLength(8)]
        public string PositionNameAbbr { get; set; }







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
