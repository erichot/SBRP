using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VJN_Transactions_UW
{
    public int TranSID { get; set; }

    public byte WeekdayNo { get; set; }

    public byte? WeekdayNo_LastDay { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TranAcrossDateTimeOffset { get; set; }

    public int UserSID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TranDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TranDateTimeOffset { get; set; }

    public byte AcrossOffsetHour { get; set; }

    [StringLength(14)]
    public string CardID { get; set; } = null!;

    [StringLength(6)]
    public string ShiftCode { get; set; } = null!;

    public int? TranYear { get; set; }

    public int? TranYearOffset { get; set; }

    public int? TranMonth { get; set; }

    public int? TranMonthOffset { get; set; }

    public int? TranDay { get; set; }

    public int? TranDayOffset { get; set; }

    public byte StartTimeHour_System { get; set; }

    public byte StartTimeMinute_System { get; set; }

    public byte StartTimeSecond_System { get; set; }

    public byte EndTimeHour_System { get; set; }

    public byte EndTimeMinute_System { get; set; }

    public byte EndTimeSecond_System { get; set; }

    [StringLength(6)]
    public string? ShiftCode_LastDay { get; set; }

    [StringLength(16)]
    public string UserID { get; set; } = null!;
}
