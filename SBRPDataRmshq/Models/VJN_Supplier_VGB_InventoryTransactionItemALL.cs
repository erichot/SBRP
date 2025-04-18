using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VJN_Supplier_VGB_InventoryTransactionItemALL
{
    [StringLength(32)]
    public string SupplierID { get; set; } = null!;

    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    public double? Quantity00 { get; set; }

    public double? Quantity01 { get; set; }

    public double? Quantity02 { get; set; }

    public double? Quantity03 { get; set; }

    public double? Quantity1612 { get; set; }

    public double? QuantityALL { get; set; }
}
