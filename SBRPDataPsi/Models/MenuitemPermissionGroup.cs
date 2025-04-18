using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Models
{
    /// <summary>
    /// 權限群組具有的功能選單項目
    /// </summary>
    [Table(nameof(MenuitemPermissionGroup), Schema = SBRPData.DbSystemModel.DB_Schema_psi)]
    [PrimaryKey(nameof(NodeNo), nameof(PermissionGroupNo))]
    public class MenuitemPermissionGroup
    {
        public short NodeNo { get; set; }

        public short PermissionGroupNo { get; set; }








        public bool IsReadonly { get; set; }











        [Display(Name = "建檔人員")]
        public short CreatedPerson { get; set; }

        [Display(Name = "建檔日期")]
        public DateTime CreatedDate { get; set; }



        [Display(Name = "異動人員")]
        public short? UpdatedPerson { get; set; }

        [Display(Name = "異動日期")]
        public DateTime? UpdatedDate { get; set; }












        [ForeignKey(nameof(NodeNo))]
        public virtual Menuitem Menuitem { get; set; }



        [ForeignKey(nameof(PermissionGroupNo))]
        public virtual PermissionGroup PermissionGroup { get; set; }


    }
}
