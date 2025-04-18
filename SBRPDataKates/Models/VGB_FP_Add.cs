using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VGB_FP_Add
{
    [StringLength(128)]
    public string? S_IPHost { get; set; }

    public int? SyncRowCounts { get; set; }
}
