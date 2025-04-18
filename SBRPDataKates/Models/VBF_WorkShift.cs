using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VBF_WorkShift
{
    [StringLength(6)]
    public string ShiftCode { get; set; } = null!;

    [StringLength(20)]
    public string? ShiftName { get; set; }

    [StringLength(48)]
    public string? ListField { get; set; }

    public byte StartTimeHour { get; set; }

    public byte StartTimeMinute { get; set; }

    public byte EndTimeHour { get; set; }

    public byte EndTimeMinute { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? TotalTimeString { get; set; }

    public byte AcrossOffsetHour { get; set; }

    public short DeductBreakMinute { get; set; }

    public bool IsDefault { get; set; }

    [Precision(0)]
    public TimeOnly? StartTimeSystem_Time { get; set; }

    [Precision(0)]
    public TimeOnly? EndTimeSystem_Time { get; set; }

    [StringLength(199)]
    [Unicode(false)]
    public string? StartTimeString { get; set; }

    [StringLength(199)]
    [Unicode(false)]
    public string? EndTimeString { get; set; }

    public short TolerateLateMinute { get; set; }

    public bool IsEndTimeNextDay { get; set; }

    public byte StartTimeHour_System { get; set; }

    public byte StartTimeMinute_System { get; set; }

    public byte StartTimeSecond_System { get; set; }

    public byte EndTimeHour_System { get; set; }

    public byte EndTimeMinute_System { get; set; }

    public byte EndTimeSecond_System { get; set; }

    public bool InActive { get; set; }

    [StringLength(10)]
    public string? DepartmentID { get; set; }

    public short? AllowWorkEarlyMinute { get; set; }

    public short? ForceSignOutAfterWorkOffMinute { get; set; }

    public bool IsIgnoreSignOut { get; set; }

    public byte WorkShiftTypeID { get; set; }

    public short WeightValue { get; set; }

    public byte BreakStartTimeHour { get; set; }

    public byte BreakStartTimeMinute { get; set; }

    public byte BreakEndTimeHour { get; set; }

    public byte BreakEndTimeMinute { get; set; }

    public bool IsDeductBreakByPeiod { get; set; }

    public byte BreakStartTimeHour2 { get; set; }

    public byte BreakStartTimeMinute2 { get; set; }

    public byte BreakEndTimeHour2 { get; set; }

    public byte BreakEndTimeMinute2 { get; set; }

    public byte DeductBreakTypeID { get; set; }
}
