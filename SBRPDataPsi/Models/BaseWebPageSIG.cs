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
    /// Source: 從 [BaseWebPageTemplate] 透過SP轉存入
    /// SIG :   允許不同SIG客戶，對同一頁面設定不同的頁面標題
    /// </remarks>
    [Table(nameof(BaseWebPageSIG), Schema = SBRPData.DbSystemModel.DB_Schema_psi)]
    [Index(nameof(ParentSIGPageNo))]
    public class BaseWebPageSIG
    {
        // 唯一PageNo, 同一頁面但不同SIGNo的PageNo亦不同 => 允許各SIG自訂PageTitle
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short SIGPageNo { get; set; }



        // [PageId] 不允許[SIGNo]內重複
        [Column(TypeName = "CHAR(8)")]
        public string PageId { get; set; }


        public byte SIGNo { get; set; }

        
        public short? NodeNo { get; set; }


        
        public short? ParentSIGPageNo { get; set; }




        // 遮罩模式，預設為NULL，或可允許SIG客戶自訂
        [StringLength(16)]
        public string? PageTitle { get; set; }


        // 遮罩模式，預設為NULL，或可允許SIG客戶自訂
        [StringLength(32)]
        public string? PageDescripion { get; set; }




       


        public virtual MenuitemSIG? MenuitemSIG { get; set; }



        [ForeignKey(nameof(ParentSIGPageNo))]
        public virtual BaseWebPageSIG? ParentBaseWebPageSIG { get; set; }



        [ForeignKey(nameof(PageId))]
        public virtual BaseWebPageTemplate BaseWebPageTemplate { get; set; }

    }
}
