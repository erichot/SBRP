using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[PrimaryKey("UserSID", "SlaveSID")]
[Table("BFX_UserSlaveAllowTime")]
public partial class BFX_UserSlaveAllowTime
{
    public int UserSATID { get; set; }

    [Key]
    public int UserSID { get; set; }

    [Key]
    public int SlaveSID { get; set; }

    public short SlaveID { get; set; }

    [StringLength(14)]
    public string CardID { get; set; } = null!;

    public byte AllowTimeStartHour { get; set; }

    public byte AllowTimeStartMinute { get; set; }

    public byte AllowTimeEndHour { get; set; }

    public byte AllowTimeEndMinute { get; set; }

    public bool IsEnabled { get; set; }

    public bool IsReplicated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    public int UserAddNewSID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeModifyLast { get; set; }

    public int? UserModifyLastSID { get; set; }

    [StringLength(24)]
    public string? Note { get; set; }

    public byte GroupID { get; set; }
}
