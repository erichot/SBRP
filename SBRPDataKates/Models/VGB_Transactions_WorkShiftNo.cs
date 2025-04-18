using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VGB_Transactions_WorkShiftNo
{
    [StringLength(14)]
    public string CardID { get; set; } = null!;

    public int WorkShiftNo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? WorkingTimeOn { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? WorkingTimeOff { get; set; }

    public int? WeekdayNo { get; set; }
}
