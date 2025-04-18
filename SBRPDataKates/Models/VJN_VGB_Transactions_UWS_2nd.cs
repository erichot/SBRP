using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VJN_VGB_Transactions_UWS_2nd
{
    public int? UserSID { get; set; }

    [StringLength(10)]
    public string CardID { get; set; } = null!;

    public int MinTranSID { get; set; }

    public int? WeekdayNo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? WorkingTimeOn { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? WorkingTimeOff { get; set; }

    [StringLength(6)]
    public string? ShiftCode { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? TranDateOffset { get; set; }

    public int? TranYearOffset { get; set; }

    public int? TranMonthOffset { get; set; }

    public int? TranDayOffset { get; set; }

    public int WorkShiftNo { get; set; }
}
