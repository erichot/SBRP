using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VJN_Supplier_VGB_InventoryTransactionItemALL_VGB_Sum_ProductID
{
    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    public double? QuantitySum00 { get; set; }

    public double? QuantitySum01 { get; set; }

    public double? QuantitySum02 { get; set; }

    public double? QuantitySum03 { get; set; }

    public double QuantityALL { get; set; }
}
