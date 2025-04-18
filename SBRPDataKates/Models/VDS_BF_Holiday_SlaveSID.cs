using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VDS_BF_Holiday_SlaveSID
{
    public byte DoorID { get; set; }

    public int DoorHoliID { get; set; }

    public byte HoliMonth { get; set; }

    public byte HoliDay { get; set; }

    public byte HoliType { get; set; }

    [StringLength(20)]
    public string? Description { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    public int UserAddNewSID { get; set; }

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
