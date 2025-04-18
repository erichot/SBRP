using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[PrimaryKey("NUM", "SN")]
[Table("PER_LEAVE_D")]
public partial class PER_LEAVE_D
{
    [Key]
    [StringLength(20)]
    public string NUM { get; set; } = null!;

    [Key]
    public int SN { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LEAVE_DATE { get; set; }

    public double? TURN_HOUR { get; set; }

    public double? SUM_TIME { get; set; }

    [StringLength(30)]
    public string? CREATE_NAME { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CREATE_TIME { get; set; }

    [StringLength(30)]
    public string? BUILD_NAME { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? BUILD_TIME { get; set; }
}
