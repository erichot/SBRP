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
    /// 基礎的原始Page data，透過SP再分別依據SIG clone
    /// [BaseWebPageTemplate] DB開設之初，從Excel轉SQL INSERT    
    /// </remarks>
    [Table(nameof(BaseWebPageTemplate), Schema = SBRPData.DbSystemModel.DB_Schema_psi)]
    public class BaseWebPageTemplate
    {

        [Key]
        [Column(TypeName = "CHAR(8)")]
        public string PageId { get; set; }


    


        [Column(TypeName = "VARCHAR(16)")]
        public string SubFolder1 { get; set; }


        [Column(TypeName = "VARCHAR(28)")]
        public string SubFolder2 { get; set; }


        [Column(TypeName = "VARCHAR(32)")]
        public string PageName { get; set; }


        
        [Column(TypeName = "CHAR(8)")]
        public string? MenuitemNodeId { get; set; }

        
        [Column(TypeName = "CHAR(8)")]
        public string? ParentPageId { get; set; }


        [StringLength(16)]        
        public string? PageTitle { get; set; }


        [StringLength(32)]
        public string PageDescripion { get; set; }



    }
}
