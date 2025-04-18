using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VMT_Attendance_WorkShiftNo
{
    public int TranSID { get; set; }

    [StringLength(14)]
    public string CardID { get; set; } = null!;

    public int WorkShiftNo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? WorkingTimeOn { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? WorkingTimeOff { get; set; }

    public byte TranType { get; set; }

    public byte DataType { get; set; }

    [StringLength(18)]
    public string? SlaveIP_Public { get; set; }

    public bool IsByTranType { get; set; }

    [StringLength(6)]
    public string? ShiftCode { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? WorkingBreakTimeStart { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? WorkingBreakTimeEnd { get; set; }
}
