using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VS_SlaveIP
{
    public int SlaveSID { get; set; }

    public short ID { get; set; }

    [StringLength(36)]
    public string IP { get; set; } = null!;

    [StringLength(151)]
    public string? ListField { get; set; }

    [StringLength(104)]
    [Unicode(false)]
    public string? SlaveHostColumn { get; set; }

    [StringLength(103)]
    [Unicode(false)]
    public string? SlaveHostColumn2 { get; set; }

    [StringLength(30)]
    public string SlaveName { get; set; } = null!;

    [StringLength(255)]
    public string? SlaveDescription { get; set; }

    public bool IsEnabled { get; set; }

    public bool ResetToDefault { get; set; }

    [StringLength(16)]
    public string? IP_Internal { get; set; }

    public int SlaveCategoryID { get; set; }

    [StringLength(16)]
    public string SlaveCategoryName { get; set; } = null!;

    public bool IsServerMode { get; set; }

    public bool IsOnLine { get; set; }

    public int StatusCode { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeModifyLast { get; set; }

    public bool NotPropagateWithUsersByDefault { get; set; }
}
