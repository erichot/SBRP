using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VBF_WorkCalendar_BAK
{
    [StringLength(10)]
    public string DepartmentID { get; set; } = null!;

    public int UserSID { get; set; }

    [StringLength(12)]
    public string UserID { get; set; } = null!;

    [StringLength(64)]
    public string? UserName { get; set; }

    [StringLength(10)]
    public string CardID { get; set; } = null!;

    public short Year { get; set; }

    public byte Month { get; set; }

    public byte Day { get; set; }

    [StringLength(30)]
    public string? WeekdayName { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? WorkDate { get; set; }

    public int WorkShiftNo { get; set; }

    [StringLength(6)]
    public string ShiftCode { get; set; } = null!;

    [StringLength(20)]
    public string? ShiftName { get; set; }

    public byte? StartTimeHour { get; set; }

    public byte? StartTimeMinute { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? WorkStartDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? WorkEndDateTime { get; set; }

    public byte? EndTimeHour { get; set; }

    public byte? EndTimeMinute { get; set; }

    public short? DeductBreakMinute { get; set; }

    public bool? IsDefault { get; set; }

    [StringLength(32)]
    public string? Note { get; set; }

    public bool? IsEndTimeNextDay { get; set; }
}
