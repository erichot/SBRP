using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VBFX_UserSlaveAllowTime
{
    public int UserSID { get; set; }

    [StringLength(16)]
    public string UserID { get; set; } = null!;

    [StringLength(83)]
    public string? ListFieldUser { get; set; }

    [StringLength(10)]
    public string DepartmentID { get; set; } = null!;

    [StringLength(36)]
    public string? DepartmentName { get; set; }

    [StringLength(64)]
    public string? UserName { get; set; }

    public short SlaveID { get; set; }

    [StringLength(14)]
    public string CardID { get; set; } = null!;

    [StringLength(36)]
    public string IP { get; set; } = null!;

    public byte AllowTimeStartHour { get; set; }

    public byte AllowTimeStartMinute { get; set; }

    public byte AllowTimeEndHour { get; set; }

    public byte AllowTimeEndMinute { get; set; }

    [StringLength(8)]
    public string? StartHourMinute { get; set; }

    [StringLength(8)]
    public string? EndHourMinute { get; set; }

    [StringLength(17)]
    public string? AllowTimeStartToEnd { get; set; }

    public bool IsEnabled { get; set; }

    public bool IsReplicated { get; set; }

    [StringLength(255)]
    public string? SlaveDescription { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    public int UserAddNewSID { get; set; }

    [StringLength(64)]
    public string? UserAddNewName { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeModifyLast { get; set; }

    public int? UserModifyLastSID { get; set; }

    [StringLength(64)]
    public string? UserModifyLastName { get; set; }

    [StringLength(24)]
    public string? Note { get; set; }

    public byte GroupID { get; set; }

    public int UserSATID { get; set; }

    public int SlaveSID { get; set; }

    public bool? IsAllOpened { get; set; }

    public bool? IsAllClosed { get; set; }
}
