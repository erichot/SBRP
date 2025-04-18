using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VGB_Transactions_DailyMinMaxTranDateTime
{
    [Column(TypeName = "datetime")]
    public DateTime? DateColumn { get; set; }

    public int? YearValue { get; set; }

    public int? MonthValue { get; set; }

    public int? DayValue { get; set; }

    public int? WeekdayNo { get; set; }

    public int UserSID { get; set; }

    [StringLength(14)]
    public string CardID { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? MinTranDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? MaxTranDateTime { get; set; }
}
