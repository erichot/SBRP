using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Models
{
    /// <summary>
    /// 
    /// 
    /// 
    /// </summary>
    /// <remarks>
    /// 第3組編組部門：自行定義人員組別
    /// </remarks>
    [Table(nameof(PermissionGroupAppUser), Schema = SBRPData.DbSystemModel.DB_Schema_psi)]
    [PrimaryKey(nameof(PermissionGroupNo), nameof(UserNo))]
    public class PermissionGroupAppUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short PermissionGroupNo { get; set; }

        public short UserNo { get; set; }











        [Display(Name = "建檔人員")]
        public short CreatedPerson { get; set; }

        [Display(Name = "建檔日期")]
        public DateTime CreatedDate { get; set; }



        [Display(Name = "異動人員")]
        public short? UpdatedPerson { get; set; }

        [Display(Name = "異動日期")]
        public DateTime? UpdatedDate { get; set; }






        [ForeignKey(nameof(PermissionGroupNo))]
        public virtual PermissionGroup PermissionGroup { get; set; }


        [ForeignKey(nameof(UserNo))]
        public virtual AppUser User { get; set; }


    }
}
