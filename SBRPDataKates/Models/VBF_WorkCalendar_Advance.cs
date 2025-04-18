using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VBF_WorkCalendar_Advance
{
    public int UserSID { get; set; }

    public short Year { get; set; }

    public byte Month { get; set; }

    public byte Day { get; set; }

    public int WorkShiftNo { get; set; }

    [StringLength(6)]
    public string ShiftCode { get; set; } = null!;

    [StringLength(20)]
    public string? ShiftName { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? WorkDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? WorkStartDateTime_AllowWorkEarlyMinute { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? WorkStartDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? WorkStartDateTime_TolerateLateMinute { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? WorkEndDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? WorkEndDateTime_ForceSignOutAfterWorkOffMinute { get; set; }

    public byte WorkShiftTypeID { get; set; }

    public short WeightValue { get; set; }

    [StringLength(10)]
    public string? DepartmentID { get; set; }

    public int ComputedTranInSID { get; set; }

    public int ComputedTranLateInSID { get; set; }

    public int ComputedTranOutSID { get; set; }

    public int ComputedAttendanceScale { get; set; }

    public bool IsComputed { get; set; }

    public int ComputedExpectedScale { get; set; }
}
