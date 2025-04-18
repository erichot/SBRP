using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VS_SlaveFace
{
    public short ID { get; set; }

    [StringLength(36)]
    public string IP { get; set; } = null!;

    [StringLength(16)]
    public string? IP_Internal { get; set; }

    public int? SlaveSID { get; set; }

    public bool NotPropagateWithUsersByDefault { get; set; }

    [StringLength(16)]
    [Unicode(false)]
    public string DeviceType { get; set; } = null!;

    [StringLength(30)]
    public string SlaveName { get; set; } = null!;
}
