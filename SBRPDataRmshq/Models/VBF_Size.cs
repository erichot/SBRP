using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VBF_Size
{
    [StringLength(32)]
    public string Id { get; set; } = null!;

    [StringLength(32)]
    public string? name { get; set; }

    [StringLength(10)]
    public string? flag { get; set; }

    [Column("class")]
    [StringLength(32)]
    public string? _class { get; set; }

    [StringLength(43)]
    public string? ListField { get; set; }
}
