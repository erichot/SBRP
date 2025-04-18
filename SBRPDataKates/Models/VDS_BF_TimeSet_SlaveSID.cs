using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VDS_BF_TimeSet_SlaveSID
{
    public byte DoorID { get; set; }

    public byte TimeSetID { get; set; }

    public byte StartHour { get; set; }

    public byte StartMin { get; set; }

    public byte EndHour { get; set; }

    public byte EndMin { get; set; }

    [StringLength(20)]
    public string? Description { get; set; }

    public bool IsDefault1 { get; set; }

    public bool IsDefault2 { get; set; }

    public bool IsDefault3 { get; set; }

    public bool IsDefault4 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    public int UserAddNewSID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeModifyLast { get; set; }

    public int? UserModifyLastSID { get; set; }

    public int SlaveSID { get; set; }

    public bool IsReplicated { get; set; }

    public int ReplicateReturnID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeReplicated { get; set; }

    [StringLength(36)]
    public string IP { get; set; } = null!;

    [StringLength(16)]
    public string? IP_Internal { get; set; }

    [StringLength(30)]
    public string SlaveName { get; set; } = null!;

    [StringLength(255)]
    public string? SlaveDescription { get; set; }

    public bool IsEnabled { get; set; }
}
