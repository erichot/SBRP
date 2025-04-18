using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VOR_InventoryTransaction01_VJN_Supplier
{
    [StringLength(32)]
    public string Class { get; set; } = null!;

    [StringLength(32)]
    public string Id { get; set; } = null!;

    public float? UpdateCount { get; set; }

    [StringLength(32)]
    public string? CashierClass { get; set; }

    [StringLength(32)]
    public string? CashierId { get; set; }

    [StringLength(32)]
    public string? Code { get; set; }

    [Column(TypeName = "image")]
    public byte[]? Items { get; set; }

    [StringLength(32)]
    public string? TheStoreClass { get; set; }

    [StringLength(32)]
    public string? TheStoreId { get; set; }

    [StringLength(8)]
    public string? TransactionDateText { get; set; }

    [StringLength(6)]
    public string? TransactionTime { get; set; }

    public DateOnly? TransactionDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TransactionDateTime { get; set; }

    public float? payed { get; set; }

    public float? unpay { get; set; }
}
