using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VBF_WorkCalendar_BR
{
    [StringLength(16)]
    public string? UserID { get; set; }

    [StringLength(10)]
    public string? DepartmentID { get; set; }

    [StringLength(64)]
    public string? UserName { get; set; }

    [StringLength(14)]
    public string? CardID { get; set; }

    public int UserSID { get; set; }

    public short Year { get; set; }

    public byte Month { get; set; }

    public byte Day { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? WorkDate { get; set; }

    [StringLength(30)]
    public string? WeekdayName { get; set; }

    public int WorkShiftNo { get; set; }

    [StringLength(6)]
    public string ShiftCode { get; set; } = null!;

    [StringLength(20)]
    public string? ShiftName { get; set; }

    public byte StartTimeHour { get; set; }

    public byte StartTimeMinute { get; set; }

    public byte EndTimeHour { get; set; }

    public byte EndTimeMinute { get; set; }

    public byte AcrossOffsetHour { get; set; }

    public short DeductBreakMinute { get; set; }

    public short TolerateLateMinute { get; set; }

    public bool IsEndTimeNextDay { get; set; }

    public byte StartTimeHour_System { get; set; }

    public byte StartTimeMinute_System { get; set; }

    public byte StartTimeSecond_System { get; set; }

    public byte EndTimeHour_System { get; set; }

    public byte EndTimeMinute_System { get; set; }

    public byte EndTimeSecond_System { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? WorkStartDateTimeOnShift { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? WorkEndDateTimeOnShift { get; set; }

    public byte BreakStartTimeHour_System { get; set; }

    public byte BreakStartTimeMinute_System { get; set; }

    public byte BreakStartTimeSecond_System { get; set; }

    public byte BreakEndTimeHour_System { get; set; }

    public byte BreakEndTimeMinute_System { get; set; }

    public byte BreakEndTimeSecond_System { get; set; }

    public bool IsDeductBreakByPeiod { get; set; }

    public byte BreakStartTimeHour2_System { get; set; }

    public byte BreakStartTimeMinute2_System { get; set; }

    public byte BreakStartTimeSecond2_System { get; set; }

    public byte BreakEndTimeHour2_System { get; set; }

    public byte BreakEndTimeMinute2_System { get; set; }

    public byte BreakEndTimeSecond2_System { get; set; }

    public byte DeductBreakTypeID { get; set; }
}
