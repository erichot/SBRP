using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[PrimaryKey("EMP_CODE", "CardID", "CHK_DATE")]
[Table("PER_CHK")]
public partial class PER_CHK
{
    [Key]
    [StringLength(16)]
    public string EMP_CODE { get; set; } = null!;

    [Key]
    [StringLength(14)]
    public string CardID { get; set; } = null!;

    [Key]
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
}
