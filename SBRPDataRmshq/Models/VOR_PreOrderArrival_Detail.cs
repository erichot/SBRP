using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VOR_PreOrderArrival_Detail
{
    [StringLength(11)]
    [Unicode(false)]
    public string? PreOrderID { get; set; }

    public int OrderSID { get; set; }

    public int PreOrderSID { get; set; }

    public int PreOrderItemNo { get; set; }

    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    [StringLength(32)]
    public string? ProductCode { get; set; }

    [StringLength(100)]
    public string? ProductName { get; set; }

    [StringLength(100)]
    public string? ImageSubFolderFileName1 { get; set; }

    [Column(TypeName = "money")]
    public decimal? ListPrice { get; set; }

    [Column(TypeName = "money")]
    public decimal? Price { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? PriceText { get; set; }

    public int? PreOrderQty { get; set; }

    public int StockUpQty { get; set; }

    public int ToStockUpQty { get; set; }

    public DateOnly? PreOrderDate { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? PreOrderDateText { get; set; }

    [StringLength(32)]
    public string? StoreID { get; set; }

    [StringLength(16)]
    public string? MemberName { get; set; }

    public int? InStorePickUpQty { get; set; }

    [StringLength(16)]
    public string? ConsigneeName { get; set; }

    public int? PreOrderUnInStorePickUpQty { get; set; }
}
