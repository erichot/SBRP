using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VJN_Supplier_VGB_InventoryTransactionItem1612
{
    [StringLength(32)]
    public string SupplierID { get; set; } = null!;

    [StringLength(32)]
    [Unicode(false)]
    public string? ProductId { get; set; }

    public double? QuantitySum { get; set; }

    [StringLength(8)]
    [Unicode(false)]
    public string? MinTransactionDate { get; set; }

    [StringLength(8)]
    [Unicode(false)]
    public string? MaxTransactionDate { get; set; }
}
