using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VGB_Transactions_WorkCalendar
{
    public int? UserSID { get; set; }

    public int? TranYearOffset { get; set; }

    public int? TranMonthOffset { get; set; }

    public int? TranDayOffset { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? MinTranDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? MaxTranDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? MinTranDateTimeOffset { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? MaxTranDateTimeOffset { get; set; }

    public int? MinTranSID { get; set; }

    public int? MaxTranSID { get; set; }

    public int? CountTranSID { get; set; }

    [StringLength(10)]
    public string? DepartmentID { get; set; }

    [StringLength(12)]
    public string? UserID { get; set; }

    [StringLength(64)]
    public string? UserName { get; set; }
}
