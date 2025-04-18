using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("S_SlaveIP")]
[Index("IP", Name = "IX_S_SlaveIP", IsUnique = true)]
public partial class S_SlaveIP
{
    public short ID { get; set; }

    [StringLength(36)]
    public string IP { get; set; } = null!;

    [StringLength(16)]
    public string? IP_Internal { get; set; }

    [StringLength(30)]
    public string SlaveName { get; set; } = null!;

    [StringLength(255)]
    public string? SlaveDescription { get; set; }

    public bool IsEnabled { get; set; }

    public bool ResetToDefault { get; set; }

    public int SlaveCategoryID { get; set; }

    public bool IsServerMode { get; set; }

    public bool IsOnLine { get; set; }

    public int StatusCode { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeModifyLast { get; set; }

    [Key]
    public int SlaveSID { get; set; }

    public bool NotPropagateWithUsersByDefault { get; set; }

    public int CommuncationPin { get; set; }

    public int? SN { get; set; }

    [ForeignKey("SlaveCategoryID")]
    [InverseProperty("S_SlaveIPs")]
    public virtual BC_SlaveCategory SlaveCategory { get; set; } = null!;
}
