using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VOR_InStock_Detail_UnionArchive
{
    [StringLength(32)]
    public string TransactionID { get; set; } = null!;

    [StringLength(32)]
    public string InStockItemID { get; set; } = null!;

    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    public int Qty { get; set; }
}
