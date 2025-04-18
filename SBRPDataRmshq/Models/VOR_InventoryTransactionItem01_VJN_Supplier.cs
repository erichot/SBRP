using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VOR_InventoryTransactionItem01_VJN_Supplier
{
    [StringLength(32)]
    public string? InventoryTransactionId { get; set; }

    public DateOnly? TransactionDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TransactionDateTime { get; set; }

    public float? UpdateCount { get; set; }

    [StringLength(32)]
    public string? ProductId { get; set; }

    public float? quantity { get; set; }
}
