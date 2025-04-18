using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("PrioritySettingID", "SettingTypeID", "StoreID")]
[Table("BF_StorePrioritySetting")]
public partial class BF_StorePrioritySetting
{
    [Key]
    [StringLength(32)]
    [Unicode(false)]
    public string PrioritySettingID { get; set; } = null!;

    [Key]
    [StringLength(1)]
    [Unicode(false)]
    public string SettingTypeID { get; set; } = null!;

    [Key]
    [StringLength(32)]
    public string StoreID { get; set; } = null!;

    public int OrderNo { get; set; }

    public bool InActive { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string UserAddNewID { get; set; } = null!;

    public DateTime TimeAddNew { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? UserModifiedID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeModified { get; set; }
}
