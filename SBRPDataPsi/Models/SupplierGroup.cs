using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Models
{
    [Table(nameof(SupplierGroup), Schema = SBRPData.DbSystemModel.DB_Schema_psi)]
    public class SupplierGroup
    {
        public short SupplierGroupNo { get; set; }


        [Column(TypeName = "CHAR(16)")]
        public string SupplierGroupId { get; set; }


        public byte SIGNo { get; set; } = default;


        [StringLength(32)]
        public string SupplierGroupName { get; set; }


        [Display(Name = "公司簡稱")]
        [StringLength(12)]
        [MaxLength(12)]
        public string SupplierGroupNameAbbr { get; set; } = string.Empty;






        public bool IsSystemPredefined { get; set; }

        public bool IsDisabled { get; set; }









        [Display(Name = "預設（入庫）倉庫")]
        public short? StockNo_Default { get; set; }








        [Display(Name = "備註")]
        [StringLength(48)]
        [MaxLength(48)]
        public string? Remark { get; set; } = string.Empty;


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








        [ForeignKey(nameof(StockNo_Default))]
        public virtual Stock? Stock_Default { get; set; }


    }
}
