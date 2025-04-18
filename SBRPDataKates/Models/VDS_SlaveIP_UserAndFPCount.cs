using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VDS_SlaveIP_UserAndFPCount
{
    [StringLength(16)]
    public string SlaveCategoryName { get; set; } = null!;

    public int SlaveSID { get; set; }

    [StringLength(36)]
    public string IP { get; set; } = null!;

    [StringLength(16)]
    public string? IP_Internal { get; set; }

    [StringLength(30)]
    public string SlaveName { get; set; } = null!;

    [StringLength(255)]
    public string? SlaveDescription { get; set; }

    public bool IsOnLine { get; set; }

    public int StatusCode { get; set; }

    public int? AllowedReplicationCount { get; set; }

    public int? UserCounts { get; set; }

    public int? FPCounts { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? StatusCodeDefinition { get; set; }

    [StringLength(100)]
    public string? Description_enUS { get; set; }

    [StringLength(100)]
    public string? Description_zhTW { get; set; }

    [StringLength(100)]
    public string? Description_zhCN { get; set; }

    [StringLength(100)]
    public string? Description_es { get; set; }

    [StringLength(100)]
    public string? Description_ko { get; set; }

    public int? FpPerUser { get; set; }
}
