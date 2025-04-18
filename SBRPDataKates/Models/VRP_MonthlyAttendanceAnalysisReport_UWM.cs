using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VRP_MonthlyAttendanceAnalysisReport_UWM
{
    public int AppSID { get; set; }

    public int UserSID { get; set; }

    [StringLength(12)]
    public string UserID { get; set; } = null!;

    [StringLength(64)]
    public string? UserName { get; set; }

    [StringLength(14)]
    public string CardID { get; set; } = null!;

    [StringLength(10)]
    public string DepartmentID { get; set; } = null!;

    public DateOnly DateColumn { get; set; }

    [StringLength(36)]
    public string? DepartmentName { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? DateIn { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? DateOut { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? RecIn { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? RecOut { get; set; }

    public int? AuthIn { get; set; }

    public int? AuthOut { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? WorkHour { get; set; }

    [Column("OT1.5")]
    public double? OT1_5 { get; set; }

    [Column("OT2.0")]
    public double? OT2_0 { get; set; }

    [Column("OT3.0")]
    public double? OT3_0 { get; set; }

    [StringLength(50)]
    public string? Status { get; set; }

    [StringLength(50)]
    public string? Leave { get; set; }

    public bool IsEarlyIn { get; set; }

    public bool IsEarlyOut { get; set; }

    public bool IsLateIn { get; set; }

    public bool IsLateOut { get; set; }

    public bool IsAbsence { get; set; }

    public bool IsOvertime { get; set; }

    public bool IsIncompleteDataIn { get; set; }

    public bool IsIncompleteDataOut { get; set; }

    public bool IsPublicHoliday { get; set; }

    public int Overtime1_5 { get; set; }

    public int Overtime2_0 { get; set; }

    public int Overtime3_0 { get; set; }

    public int WorkingTimeTotal { get; set; }

    [Column(TypeName = "smallmoney")]
    public decimal OTAL { get; set; }

    [Column(TypeName = "smallmoney")]
    public decimal SAL { get; set; }

    [Column(TypeName = "smallmoney")]
    public decimal TAL { get; set; }

    [Column(TypeName = "smallmoney")]
    public decimal BFAL { get; set; }

    [Column(TypeName = "smallmoney")]
    public decimal LAL { get; set; }

    [Column(TypeName = "smallmoney")]
    public decimal DAL { get; set; }

    [Column(TypeName = "smallmoney")]
    public decimal SUPV { get; set; }

    [Column(TypeName = "smallmoney")]
    public decimal TOTAL { get; set; }

    [StringLength(32)]
    public string? TitleName { get; set; }
}
