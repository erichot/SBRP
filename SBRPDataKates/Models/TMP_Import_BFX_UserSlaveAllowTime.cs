using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
[Table("TMP_Import_BFX_UserSlaveAllowTime")]
public partial class TMP_Import_BFX_UserSlaveAllowTime
{
    [StringLength(64)]
    public string? UserID { get; set; }

    [StringLength(64)]
    public string? UserName { get; set; }

    [StringLength(64)]
    public string? CardID { get; set; }

    [StringLength(64)]
    public string? IP { get; set; }

    [StringLength(64)]
    public string? AllowTimeStartHour { get; set; }

    [StringLength(64)]
    public string? AllowTimeStartMinute { get; set; }

    [StringLength(64)]
    public string? AllowTimeEndHour { get; set; }

    [StringLength(64)]
    public string? AllowTimeEndMinute { get; set; }
}
