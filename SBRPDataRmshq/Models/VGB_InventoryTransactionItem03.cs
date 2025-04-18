using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VGB_InventoryTransactionItem03
{
    [StringLength(32)]
    public string? CashierClass { get; set; }

    [StringLength(32)]
    public string? ProductId { get; set; }

    public double? QuantitySum { get; set; }

    [StringLength(8)]
    public string? MinTransactionDate { get; set; }

    [StringLength(8)]
    public string? MaxTransactionDate { get; set; }
}
