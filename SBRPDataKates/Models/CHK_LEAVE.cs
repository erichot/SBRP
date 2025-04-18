using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("CHK_LEAVE")]
public partial class CHK_LEAVE
{
    [Key]
    [StringLength(10)]
    public string LEAVE_CODE { get; set; } = null!;

    [StringLength(20)]
    public string? LEAVE_DESC { get; set; }

    public byte? CUT_MODE { get; set; }

    [StringLength(30)]
    public string? CREATE_NAME { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CREATE_TIME { get; set; }

    [StringLength(30)]
    public string? BUILD_NAME { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? BUILD_TIME { get; set; }

    public bool? CUT_ABS { get; set; }
}
