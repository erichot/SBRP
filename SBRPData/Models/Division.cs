using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPData.Models
{
    /// <summary>
    /// 部門組別：用於分類[Department]
    /// </summary>
    /// <remarks>
    /// [Department]的上層分類群組，不能直接容納[Employee]
    /// 只能容納[Department]（最上層的[Department]，非子部門。
    /// [Division]也可用於權限配置
    /// </remarks>
    [Table(nameof(Division), Schema = DbSystemModel.DB_Schema_common)]
    [Index(nameof(DivisionId))]
    public class Division
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short DivisionNo { get; set; }


        public byte SIGNo { get; set; } = default(byte);


        [Display(Name ="CHAR(12)")]
        public string DivisionId { get; set; }


        [Display(Name = "部門名稱")]
        [StringLength(24)]
        public string DivisionName { get; set; }


        [Display(Name = "部門簡稱")]
        [StringLength(8)]
        public string DivisionNameAbbr { get; set; }









        public bool IsSystemPredefined { get; set; }

        public bool IsInvisible { get; set; }

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
