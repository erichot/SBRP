using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VMT_Attendance
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

    [StringLength(6)]
    public string? ShiftCode { get; set; }

    public byte? StartTimeHour_System { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? WorkingDate { get; set; }

    public byte? StartTimeMinute_System { get; set; }

    public byte? StartTimeSecond_System { get; set; }

    public byte? EndTimeHour_System { get; set; }

    public byte? EndTimeMinute_System { get; set; }

    public byte? EndTimeSecond_System { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? WorkingStdTimeOn { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? WorkingStdTimeOff { get; set; }
}
