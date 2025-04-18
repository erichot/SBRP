using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VJN_Transactions_DailyMinMaxTranDateTime_WorkingStdTime
{
    [Column(TypeName = "datetime")]
    public DateTime? DateColumn { get; set; }

    public int? YearValue { get; set; }

    public int? MonthValue { get; set; }

    public int? DayValue { get; set; }

    public int? WeekdayNo { get; set; }

    [StringLength(10)]
    public string DepartmentID { get; set; } = null!;

    [StringLength(36)]
    public string? DepartmentName { get; set; }

    [StringLength(16)]
    public string? EmployeeTypeID { get; set; }

    public int UserSID { get; set; }

    [StringLength(14)]
    public string CardID { get; set; } = null!;

    [StringLength(64)]
    public string? UserName { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? WorkingStdTimeOn { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? WorkingStdTimeOff { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? MinTranDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? MaxTranDateTime { get; set; }
}
