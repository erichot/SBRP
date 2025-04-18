using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VGB_User_Add
{
    [StringLength(128)]
    public string? SlaveHost { get; set; }

    public int? SyncRowCounts { get; set; }
}
