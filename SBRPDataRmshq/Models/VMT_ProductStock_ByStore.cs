using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VMT_ProductStock_ByStore
{
    [StringLength(32)]
    public string? ProductID { get; set; }

    [StringLength(32)]
    public string? ProductCode { get; set; }

    [StringLength(100)]
    public string? ProductName { get; set; }

    [StringLength(32)]
    public string? StoreID { get; set; }

    public int? Qty { get; set; }

    [StringLength(32)]
    public string? StoreName { get; set; }
}
