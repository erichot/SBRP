using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VOR_CompanyPurchasingOrder_Detail
{
    [StringLength(10)]
    public string OrderSID { get; set; } = null!;

    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    [StringLength(32)]
    public string? ProductCode { get; set; }

    [StringLength(100)]
    public string? ProductName { get; set; }

    [StringLength(100)]
    public string? ImageSubFolderFileName1 { get; set; }

    [Column(TypeName = "money")]
    public decimal? Price { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? PriceText { get; set; }

    public int Qty { get; set; }

    [StringLength(50)]
    public string Remark { get; set; } = null!;

    public bool IsFinished { get; set; }

    public int InStockBeforeNextOrderQty { get; set; }

    public int RemainOrderQty { get; set; }

    public int? StockSubTotal { get; set; }

    public int? CustomerOrderQty { get; set; }

    public int? PurchasingSuggestionQty { get; set; }
}
