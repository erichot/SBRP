using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VJN_Transaction_UWS_2nd
{
    public int TranSID { get; set; }

    [StringLength(10)]
    public string? DepartmentID { get; set; }

    public int? UserSID { get; set; }

    [StringLength(16)]
    public string? UserID { get; set; }

    [StringLength(14)]
    public string CardID { get; set; } = null!;

    [Precision(0)]
    public TimeOnly? TranTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TranDateTime { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? TranDate_String { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TranDate_DateTime { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? TranDateOffset_String { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TranDateOffset { get; set; }

    [StringLength(6)]
    public string? ShiftCode { get; set; }

    [Precision(0)]
    public TimeOnly? StartTimeSystem_Time { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? StartDateTimeSystem_Time { get; set; }

    [Precision(0)]
    public TimeOnly? EndTimeSystem_Time { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EndDateTimeSystem_Time { get; set; }

    [StringLength(6)]
    public string? ShiftCode_2nd { get; set; }

    [Precision(0)]
    public TimeOnly? StartTimeSystem_Time_2nd { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? StartDateTimeSystem_Time_2nd { get; set; }

    [Precision(0)]
    public TimeOnly? EndTimeSystem_Time_2nd { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EndDateTimeSystem_Time_2nd { get; set; }

    [Precision(0)]
    public TimeOnly? StartTimeOver { get; set; }

    [Precision(0)]
    public TimeOnly? EndTimeOver { get; set; }

    [Precision(0)]
    public TimeOnly? StartTimeOver_2nd { get; set; }

    [Precision(0)]
    public TimeOnly? EndTimeOver_2nd { get; set; }

    public int? TimeDiffStart { get; set; }

    public int? TimeDiffEnd { get; set; }

    public int? TimeDiffStart_2nd { get; set; }

    public int? TimeDiffEnd_2nd { get; set; }

    public int WorkShiftNo { get; set; }

    public byte TranType { get; set; }
}
