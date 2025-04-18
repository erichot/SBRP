using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[PrimaryKey("WORK_YEAR", "TURNWORK_GRP", "WORK_DATE")]
[Table("CHK_WORKLIST")]
public partial class CHK_WORKLIST
{
    [Key]
    public int WORK_YEAR { get; set; }

    [Key]
    [StringLength(10)]
    public string TURNWORK_GRP { get; set; } = null!;

    [Key]
    [Column(TypeName = "datetime")]
    public DateTime WORK_DATE { get; set; }

    [StringLength(20)]
    public string? WORK_WEEK { get; set; }

    [StringLength(20)]
    public string? CLASS_CODE { get; set; }

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
