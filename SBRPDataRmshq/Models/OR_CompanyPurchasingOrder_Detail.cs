using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("OrderSID", "ProductID")]
[Table("OR_CompanyPurchasingOrder_Detail")]
public partial class OR_CompanyPurchasingOrder_Detail
{
    [Key]
    [StringLength(10)]
    public string OrderSID { get; set; } = null!;

    [Key]
    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal? Price { get; set; }

    public int? StockSubTotal { get; set; }

    public int? CustomerOrderQty { get; set; }

    public int? CompanyPurchasingRemainQty { get; set; }

    public int? PurchasingSuggestionQty { get; set; }

    public int Qty { get; set; }

    [StringLength(50)]
    public string Remark { get; set; } = null!;

    public bool IsFinished { get; set; }

    public int InStockBeforeNextOrderQty { get; set; }

    public int RemainOrderQty { get; set; }

    public DateTime TimeAddNew { get; set; }

    public DateTime? TimeUpdateRemainQty { get; set; }

    [StringLength(16)]
    [Unicode(false)]
    public string? UserUpdateRemainQtyID { get; set; }
}
