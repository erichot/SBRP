using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("CHK_CLASS")]
public partial class CHK_CLASS
{
    [Key]
    [StringLength(10)]
    public string CLASS_CODE { get; set; } = null!;

    [StringLength(20)]
    public string? CLASS_DESC { get; set; }

    [Precision(0)]
    public TimeOnly? WORK_TIME_START { get; set; }

    [Precision(0)]
    public TimeOnly? WORK_TIME_END { get; set; }

    [Precision(0)]
    public TimeOnly? WORK_TIME_LATE { get; set; }

    [Precision(0)]
    public TimeOnly? WORK_TIME_OVERTIME { get; set; }

    public double? TURN_OVERTIME { get; set; }

    [Precision(0)]
    public TimeOnly? RELAX_TIME1 { get; set; }

    [Precision(0)]
    public TimeOnly? RELAX_TIME2 { get; set; }

    [Precision(0)]
    public TimeOnly? RELAX_TIME3 { get; set; }

    [Precision(0)]
    public TimeOnly? RELAX_TIME4 { get; set; }

    public int? TURN_TIME { get; set; }

    [StringLength(30)]
    public string? CREATE_NAME { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CREATE_TIME { get; set; }

    [StringLength(30)]
    public string? BUILD_NAME { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? BUILD_TIME { get; set; }

    public int? CLASS_AMT { get; set; }

    public bool? LEAVE_CK { get; set; }

    public double? LEAVE_HOURS { get; set; }
}
