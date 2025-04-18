using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VS_DayTimeTable
{
    public byte ItemNo { get; set; }

    public byte HourValue { get; set; }

    public byte MinuteValue { get; set; }

    [StringLength(199)]
    [Unicode(false)]
    public string? HourMinuteString { get; set; }
}
