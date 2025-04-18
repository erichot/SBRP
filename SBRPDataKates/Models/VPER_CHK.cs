using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VPER_CHK
{
    [StringLength(10)]
    public string? DepartmentID { get; set; }

    [StringLength(36)]
    public string? DepartmentName { get; set; }

    [StringLength(64)]
    public string? UserName { get; set; }

    [StringLength(16)]
    public string EMP_CODE { get; set; } = null!;

    [StringLength(14)]
    public string CardID { get; set; } = null!;

    public int? CheckYear { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CHK_DATE { get; set; }

    [StringLength(20)]
    public string? CLASS_CODE { get; set; }

    public bool? CLOCK_CK { get; set; }

    [StringLength(10)]
    public string? LEAVE_CODE { get; set; }

    public bool? CHK { get; set; }

    [StringLength(30)]
    public string? CREATE_NAME { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CREATE_TIME { get; set; }

    [StringLength(30)]
    public string? BUILD_NAME { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? BUILD_TIME { get; set; }

    public byte? LIST_GRP { get; set; }

    [Precision(0)]
    public TimeOnly? WORK_TIME_START { get; set; }

    [Precision(0)]
    public TimeOnly? WORK_TIME_END { get; set; }

    [Precision(0)]
    public TimeOnly? WORK_TIME_LATE { get; set; }

    [Precision(0)]
    public TimeOnly? WORK_TIME_OVERTIME { get; set; }

    [Precision(0)]
    public TimeOnly? RELAX_TIME1 { get; set; }

    [Precision(0)]
    public TimeOnly? RELAX_TIME2 { get; set; }

    [Precision(0)]
    public TimeOnly? RELAX_TIME3 { get; set; }

    [Precision(0)]
    public TimeOnly? RELAX_TIME4 { get; set; }

    public double? TURN_OVERTIME { get; set; }

    public int? TURN_TIME { get; set; }

    [StringLength(20)]
    public string? CLASS_DESC { get; set; }
}
