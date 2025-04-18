using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VBF_Category
{
    [StringLength(32)]
    public string Class { get; set; } = null!;

    [StringLength(32)]
    public string Id { get; set; } = null!;

    public int? UpdateCount { get; set; }

    [StringLength(32)]
    public string? Code { get; set; }

    [StringLength(63)]
    public string? ListField { get; set; }

    public DateTime? LastSync { get; set; }

    [StringLength(30)]
    public string? Name { get; set; }

    [StringLength(32)]
    public string? NumberSeriesClass { get; set; }

    [StringLength(32)]
    public string? NumberSeriesId { get; set; }

    [StringLength(32)]
    public string? ParentClass { get; set; }

    [StringLength(32)]
    public string? ParentId { get; set; }
}
