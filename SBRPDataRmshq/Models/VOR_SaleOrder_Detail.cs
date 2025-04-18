using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VOR_SaleOrder_Detail
{
    [StringLength(32)]
    public string SaleOrderID { get; set; } = null!;

    [StringLength(32)]
    public string StoreID { get; set; } = null!;

    public int ItemNumber { get; set; }

    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    [StringLength(32)]
    public string? ProductCode { get; set; }

    [StringLength(100)]
    public string ProductName { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal SellingPrice { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? SellingPriceText { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? ListPriceText { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? PriceText { get; set; }

    [Column(TypeName = "money")]
    public decimal Cost { get; set; }

    [Column(TypeName = "money")]
    public decimal DiscountAmount { get; set; }

    [Column(TypeName = "money")]
    public decimal PercentValue { get; set; }

    [Column(TypeName = "money")]
    public decimal Price { get; set; }

    public int Qty { get; set; }

    [Column(TypeName = "money")]
    public decimal Total { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? TotalText { get; set; }

    [StringLength(200)]
    public string? Remark { get; set; }

    [StringLength(200)]
    public string? Remark2 { get; set; }

    public DateTime TimeAddNew { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? UserAddNewID { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? UserModifiedID { get; set; }

    [StringLength(32)]
    public string SaleItemID { get; set; } = null!;

    [StringLength(100)]
    public string? ImageSubFolderFileName1 { get; set; }

    public float? ListPrice { get; set; }
}
