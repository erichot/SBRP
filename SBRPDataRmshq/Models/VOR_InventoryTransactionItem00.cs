using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VOR_InventoryTransactionItem00
{
    [StringLength(32)]
    public string Class { get; set; } = null!;

    [StringLength(32)]
    public string Id { get; set; } = null!;

    [StringLength(32)]
    public string? TheStoreClass { get; set; }

    [StringLength(32)]
    public string? InventoryTransactionId { get; set; }

    [StringLength(32)]
    public string? CashierClass { get; set; }

    public DateOnly? TransactionDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TransactionDateTime { get; set; }

    [StringLength(32)]
    public string? ProductId { get; set; }

    public float? quantity { get; set; }

    public float? UpdateCount { get; set; }

    [StringLength(32)]
    public string? TheStoreId { get; set; }
}
