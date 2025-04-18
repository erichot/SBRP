using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VOR_CompanyPreOrderInStore_Store
{
    public int OrderSID { get; set; }

    [StringLength(32)]
    public string StoreID { get; set; } = null!;

    [StringLength(32)]
    public string StoreName { get; set; } = null!;

    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    [StringLength(32)]
    public string? ProductCode { get; set; }

    [StringLength(100)]
    public string? ProductName { get; set; }

    public int? SafetyStockQty { get; set; }

    public int? StoreStockQty { get; set; }

    public int? PreOrderQty { get; set; }

    public int? PreOrderStockUpQty { get; set; }

    public int? PreOrderUnStockUpQty { get; set; }

    public int? StoreDemandQty { get; set; }

    public int? CompanyStockUpQty_Suggestion { get; set; }

    public int? CompanyStockUpQty { get; set; }

    public int? StorePreOrderItemCount { get; set; }
}
