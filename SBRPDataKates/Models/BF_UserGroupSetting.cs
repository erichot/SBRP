using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("BF_UserGroupSetting")]
[Index("GroupID", Name = "IX_BF_UserGroupSetting_GroupID")]
[Index("IsPropagated", Name = "IX_BF_UserGroupSetting_IsPropagated")]
public partial class BF_UserGroupSetting
{
    [Key]
    public int UserSID { get; set; }

    public byte GroupID { get; set; }

    public bool IsPropagated { get; set; }

    public int UserAddNewID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    public int? UserModifyLastID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeModifyLast { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimePropagated { get; set; }
}
