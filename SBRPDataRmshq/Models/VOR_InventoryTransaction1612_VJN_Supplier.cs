using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VOR_InventoryTransaction1612_VJN_Supplier
{
    [StringLength(32)]
    [Unicode(false)]
    public string Class { get; set; } = null!;

    [StringLength(32)]
    [Unicode(false)]
    public string Id { get; set; } = null!;

    public float? UpdateCount { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? CashierClass { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? CashierId { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? Code { get; set; }

    [Column(TypeName = "image")]
    public byte[]? Items { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? TheStoreClass { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? TheStoreId { get; set; }

    [StringLength(8)]
    [Unicode(false)]
    public string? TransactionDateText { get; set; }

    [StringLength(6)]
    [Unicode(false)]
    public string? TransactionTime { get; set; }

    public DateOnly? TransactionDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TransactionDateTime { get; set; }

    public float? payed { get; set; }

    public float? unpay { get; set; }
}
