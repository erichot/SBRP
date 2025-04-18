using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Models
{
    /// <summary>
    /// 整個基底系統的完整功能表項目
    /// </summary>
    [Table(nameof(Menuitem), Schema = SBRPData.DbSystemModel.DB_Schema_psi)]
    [Index(nameof(NodeId),IsUnique = true)]
    [Index(nameof(ParentNodeId))]
    public class Menuitem
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short NodeNo { get; set; }



        [Column(TypeName = "CHAR(8)")]    
        public string NodeId { get; set; } 


        public bool HasChildNode { get; set; }

        
        [Column(TypeName = "CHAR(8)")]
        public string? ParentNodeId { get; set; }


        [StringLength(16)]
        public string NodeName { get; set; }



        [Column(TypeName = "VARCHAR(48)")]
        public string AspPage { get; set; }





        [Column(TypeName = "VARCHAR(28)")]
        public string? AspController { get; set; }

        [Column(TypeName = "VARCHAR(16)")]
        public string? AspAction { get; set; }   

        public short AspRouteNo { get; set; }






        [Column(TypeName = "VARCHAR(16)")]
        public string DataFeather { get; set; }


        [StringLength(64)]
        public string? ItemDescription { get; set; }


        public short ThresholdPermissionValue { get; set; }


        public byte RoleTypeFlag { get; set; }






        public short OrderNo { get; set; }



        [Column(TypeName = "VARCHAR(8)")]
        public string Version { get; set; }


        [StringLength(32)]
        public string? Remark { get; set; }


        

        // 僅適用於指定SIG客戶
        public bool IsIsolated { get; set; }

        // 隱藏，但仍允許特殊使用
        public bool IsInvisible { get; set; }

        // 停用
        public bool IsDisabled { get; set; }





        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }










    }
}
