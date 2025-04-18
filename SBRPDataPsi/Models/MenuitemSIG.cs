using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Models
{
    /// <summary>
    /// 客戶實際使用的功能表項目
    /// </summary>
    [Table(nameof(MenuitemSIG), Schema = SBRPData.DbSystemModel.DB_Schema_psi)]
    [PrimaryKey(nameof(NodeNo), nameof(SIGNo))]
    [Index(nameof(OrderNo))]
    public class MenuitemSIG
    {

        public short NodeNo { get; set; }

        public byte SIGNo { get; set; }





        // 允許不同的SIG客戶，指派不同的功能表名稱
        [StringLength(16)]
        public string? NodeName { get; set; }

        public short? OrderNo { get; set; }


        public bool? IsInvisible { get; set; }


        public bool? IsDisabled { get; set; }










        [Display(Name = "建檔人員")]
        public short CreatedPerson { get; set; }

        [Display(Name = "建檔日期")]
        public DateTime CreatedDate { get; set; }



        public short? UpdatedPerson { get; set; }

        public DateTime? UpdatedDate { get; set; }









        [ForeignKey(nameof(NodeNo))]
        public virtual Menuitem Menuitem { get; set; }

    }
}
