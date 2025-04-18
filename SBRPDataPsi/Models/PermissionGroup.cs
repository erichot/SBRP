using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 第1總編組方式：系統預先定義組別
    ///             1-1 All Users   => ex.若將功能表對此組別開放，則代表對所有人開放=SIGNo
    ///                                 [psi].[uspINSERT_SystemIsolationGroup_SIGWithRelateDefault]
    ///             1-2 AppAdmin    => ex.系統管理者群組
    ///             1-3 大主管
    ///             1-4 小主管
    ///             1-5 一般員工
    ///             1-6 訪客／唯讀
    /// 第2種編組方式：直接從[Department] or [Position] 自動取得
    ///             2-1 [Department]    指定部門轄下（是否包含子部門?另開選項功能?）
    ///             2-2 [Position]      指定職位（不區分部門）
    ///             2-3 [Department] + [Position] 指定部門+職位
    /// 第3種編組方式：refer to [PermissionGroupAppUser]
    /// </remarks>
    [Table(nameof(PermissionGroup), Schema = SBRPData.DbSystemModel.DB_Schema_psi)]
    public class PermissionGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public short PermissionGroupNo { get; set; }


        public byte SIGNo { get; set; } = default(byte);



        // 利用此欄位來辨識預設的群組。由於可能會有部門+職位的組合，故長度給24碼
        [Required]
        [Column(TypeName = "CHAR(24)")]
        public string PermissionGroupId { get; set; }



        [StringLength(16)]
        public string PermissionGroupName { get; set; }







        public short? DepartmentNo { get; set; }

        public short? PositionNo { get; set; }






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










        [ForeignKey(nameof(DepartmentNo))]
        public SBRPData.Models.Department Department { get; set; }



        [ForeignKey(nameof(PositionNo))]
        public SBRPData.Models.Position Position { get; set; }


    }
}
