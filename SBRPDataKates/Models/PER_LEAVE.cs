using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("PER_LEAVE")]
public partial class PER_LEAVE
{
    [Key]
    [StringLength(20)]
    public string NUM { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? USE_DATE { get; set; }

    [StringLength(20)]
    public string? EMP_CODE { get; set; }

    public bool? SPHOLIDAY { get; set; }

    public bool? OVERDAY { get; set; }

    [StringLength(5)]
    public string? LEAVE_CODE { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LEAVE_DATE1 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LEAVE_DATE2 { get; set; }

    [Precision(0)]
    public TimeOnly? LEAVE_TIME1 { get; set; }

    [Precision(0)]
    public TimeOnly? LEAVE_TIME2 { get; set; }

    public double? SUM_TIME { get; set; }

    [StringLength(20)]
    public string? AGENT { get; set; }

    [StringLength(20)]
    public string? STATUS { get; set; }

    [StringLength(20)]
    public string? CFM_NAME { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CFM_TIME { get; set; }

    [StringLength(30)]
    public string? CREATE_NAME { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CREATE_TIME { get; set; }

    [StringLength(30)]
    public string? BUILD_NAME { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? BUILD_TIME { get; set; }
}
