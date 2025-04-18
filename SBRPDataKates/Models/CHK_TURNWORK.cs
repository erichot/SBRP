using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("CHK_TURNWORK")]
public partial class CHK_TURNWORK
{
    [Key]
    [StringLength(10)]
    public string TURNWORK_GRP { get; set; } = null!;

    [StringLength(20)]
    public string? TURNWORK_DESC { get; set; }

    [StringLength(10)]
    public string? CLASS_CODE1 { get; set; }

    [StringLength(10)]
    public string? CLASS_CODE2 { get; set; }

    [StringLength(10)]
    public string? CLASS_CODE3 { get; set; }

    [StringLength(10)]
    public string? CLASS_CODE4 { get; set; }

    [StringLength(10)]
    public string? CLASS_CODE5 { get; set; }

    [StringLength(10)]
    public string? CLASS_CODE6 { get; set; }

    [StringLength(10)]
    public string? CLASS_CODE7 { get; set; }

    [StringLength(30)]
    public string? CREATE_NAME { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CREATE_TIME { get; set; }

    [StringLength(30)]
    public string? BUILD_NAME { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? BUILD_TIME { get; set; }
}
