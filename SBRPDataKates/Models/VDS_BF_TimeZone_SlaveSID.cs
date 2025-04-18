using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VDS_BF_TimeZone_SlaveSID
{
    public byte DoorID { get; set; }

    public byte TimeZoneID { get; set; }

    public byte Frame01 { get; set; }

    public byte Frame02 { get; set; }

    public byte Frame03 { get; set; }

    public byte Frame04 { get; set; }

    [StringLength(20)]
    public string? Description { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    public int UserAddNewSID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeModifyLast { get; set; }

    public int? UserModifyLastSID { get; set; }

    public int? SlaveSID { get; set; }

    public bool? IsReplicated { get; set; }

    public int? ReplicateReturnID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeReplicated { get; set; }

    public short? ID { get; set; }

    [StringLength(36)]
    public string? IP { get; set; }

    [StringLength(16)]
    public string? IP_Internal { get; set; }

    [StringLength(30)]
    public string? SlaveName { get; set; }

    [StringLength(255)]
    public string? SlaveDescription { get; set; }

    public bool? IsEnabled { get; set; }
}
