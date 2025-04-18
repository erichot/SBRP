using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VMT_Attendance_GroupByTranTimeOffset
{
    public int UserSID { get; set; }

    [StringLength(16)]
    public string UserID { get; set; } = null!;

    public int? TranYearOffset { get; set; }

    public int? TranMonthOffset { get; set; }

    public int? TranDayOffset { get; set; }

    public int? MinTranSID { get; set; }

    public int? WeekdayNo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? WorkingTimeOn { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? WorkingTimeOff { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? WorkingTimeOnOffset { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? WorkingTimeOffOffset { get; set; }

    [StringLength(14)]
    public string CardID { get; set; } = null!;
}
