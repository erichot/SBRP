using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[PrimaryKey("Version", "ItemNo")]
[Table("S_SystemUpdateLog")]
public partial class S_SystemUpdateLog
{
    [Key]
    [StringLength(10)]
    [Unicode(false)]
    public string Version { get; set; } = null!;

    [Key]
    public int ItemNo { get; set; }

    public DateOnly ReleaseDate { get; set; }

    public int CategoryID { get; set; }

    [StringLength(36)]
    public string? Form { get; set; }

    [StringLength(48)]
    [Unicode(false)]
    public string? AffectedObject { get; set; }

    [StringLength(500)]
    public string? BeforeUpdate { get; set; }

    [StringLength(500)]
    public string? AfterUpdated { get; set; }

    [StringLength(500)]
    public string? Description { get; set; }

    public DateTime TimeAddNew { get; set; }
}
