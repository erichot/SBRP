using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
[Table("OR_SaleOrder_Detail_Temp")]
public partial class OR_SaleOrder_Detail_Temp
{
    [StringLength(32)]
    public string SaleItemID { get; set; } = null!;

    [StringLength(32)]
    public string SaleOrderID { get; set; } = null!;

    [StringLength(32)]
    public string StoreID { get; set; } = null!;

    public int ItemNumber { get; set; }

    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal SellingPrice { get; set; }

    [Column(TypeName = "money")]
    public decimal? ListPrice { get; set; }

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

    [StringLength(200)]
    public string? Remark { get; set; }

    [StringLength(200)]
    public string? Remark2 { get; set; }

    [StringLength(32)]
    public string? Class { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastSync { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? ProductClass { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? ProductStockClass { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? ProductStockId { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? SaleClass { get; set; }

    public DateTime TimeAddNew { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? UserAddNewID { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? UserModifiedID { get; set; }

    public DateTime? TimeModified { get; set; }
}
