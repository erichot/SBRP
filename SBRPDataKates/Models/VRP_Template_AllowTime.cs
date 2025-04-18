using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VRP_Template_AllowTime
{
    public byte AllowTimeStartHour { get; set; }

    public byte AllowTimeStartMinute { get; set; }

    public byte AllowTimeEndHour { get; set; }

    public byte AllowTimeEndMinute { get; set; }

    [StringLength(8)]
    public string? AllowTimeStart { get; set; }

    [StringLength(8)]
    public string? AllowTimeEnd { get; set; }

    public int? TimeInterval { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? AllowTimeTotal { get; set; }

    public int SourceTable { get; set; }
}
