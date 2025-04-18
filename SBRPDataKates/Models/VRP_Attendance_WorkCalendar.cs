using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VRP_Attendance_WorkCalendar
{
    public int UserSID { get; set; }

    [StringLength(10)]
    public string? DepartmentID { get; set; }

    [StringLength(36)]
    public string? DepartmentName { get; set; }

    [StringLength(16)]
    public string? UserID { get; set; }

    [StringLength(64)]
    public string? UserName { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? Date { get; set; }

    public short Year { get; set; }

    public byte Month { get; set; }

    public byte Day { get; set; }

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

    public short DeductBreakMinute { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? WorkingStdTimeOn { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? WorkingStdTimeOff { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? WorkingTimeOn { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? WorkingDateTimeOn { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? WorkingTimeOff { get; set; }

    public int? WorkingTimeNormal { get; set; }

    public int? WorkingTimeTotal { get; set; }

    public int WorkLateCount { get; set; }

    public int? WorkLateMinute { get; set; }

    public int WorkLeaveEarlyCount { get; set; }

    public int? WorkLeaveEarlyMinute { get; set; }

    public int? WorkingTimeOver { get; set; }

    public int AbsenceCounts { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? DeductBreakStartDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeductBreakEndDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeductBreakStartDateTime2 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeductBreakEndDateTime2 { get; set; }
}
