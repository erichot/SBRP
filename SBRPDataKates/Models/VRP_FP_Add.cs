using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VRP_FP_Add
{
    public short ID { get; set; }

    [StringLength(128)]
    public string? S_IPHost { get; set; }

    [StringLength(15)]
    public string IP { get; set; } = null!;

    public int? SyncRowCounts { get; set; }
}
