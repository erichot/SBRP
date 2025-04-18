using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VRP_ProductAdditionalOrderInsert
{
    public Guid? SessionGID { get; set; }

    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    [StringLength(32)]
    public string? ProductCode { get; set; }

    [StringLength(100)]
    public string? ProductName { get; set; }

    [StringLength(32)]
    public string? SupplierId { get; set; }

    [StringLength(40)]
    public string? SupplierName { get; set; }

    [StringLength(60)]
    public string? OriginalPlace { get; set; }

    [StringLength(32)]
    public string? Barcode { get; set; }

    [StringLength(60)]
    public string? WholeSalePrice { get; set; }

    [StringLength(60)]
    public string? CurrencyID { get; set; }

    [Column(TypeName = "ntext")]
    public string? ExternalLink { get; set; }

    public double? SaleQty { get; set; }

    public float? StockQty { get; set; }

    public int? OrderQty { get; set; }

    public int? AdditionalOrderQty { get; set; }

    public int? RemainOrderQty { get; set; }

    [StringLength(50)]
    public string ImageSubFolder { get; set; } = null!;

    [StringLength(50)]
    public string? ImageFileName1 { get; set; }

    [StringLength(100)]
    public string? ImageSubFolderFileName1 { get; set; }
}
