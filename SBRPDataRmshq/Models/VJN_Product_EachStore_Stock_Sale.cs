using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VJN_Product_EachStore_Stock_Sale
{
    [StringLength(32)]
    public string Id { get; set; } = null!;

    [StringLength(32)]
    public string? ProductCode { get; set; }

    [StringLength(32)]
    public string? CustomCode { get; set; }

    [StringLength(100)]
    public string? Description { get; set; }

    public double? SaleQty00 { get; set; }

    public float? StockQty00 { get; set; }

    [StringLength(8)]
    public string? MinSaleDate00 { get; set; }

    [StringLength(8)]
    public string? MaxSaleDate00 { get; set; }

    [StringLength(8)]
    public string? MinInStockDate00 { get; set; }

    [StringLength(8)]
    public string? MaxInStockDate00 { get; set; }

    public double? SaleQty01 { get; set; }

    public float? StockQty01 { get; set; }

    [StringLength(8)]
    public string? MinSaleDate01 { get; set; }

    [StringLength(8)]
    public string? MaxSaleDate01 { get; set; }

    [StringLength(8)]
    public string? MinInStockDate01 { get; set; }

    [StringLength(8)]
    public string? MaxInStockDate01 { get; set; }

    public double? SaleQty02 { get; set; }

    public float? StockQty02 { get; set; }

    [StringLength(8)]
    public string? MinSaleDate02 { get; set; }

    [StringLength(8)]
    public string? MaxSaleDate02 { get; set; }

    [StringLength(8)]
    public string? MinInStockDate02 { get; set; }

    [StringLength(8)]
    public string? MaxInStockDate02 { get; set; }

    public double? SaleQty03 { get; set; }

    public float? StockQty03 { get; set; }

    [StringLength(8)]
    public string? MinSaleDate03 { get; set; }

    [StringLength(8)]
    public string? MaxSaleDate03 { get; set; }

    [StringLength(8)]
    public string? MinInStockDate03 { get; set; }

    [StringLength(8)]
    public string? MaxInStockDate03 { get; set; }

    public double? SaleQty1612 { get; set; }

    public float? StockQty1612 { get; set; }

    [StringLength(8)]
    [Unicode(false)]
    public string? MinSaleDate1612 { get; set; }

    [StringLength(8)]
    [Unicode(false)]
    public string? MaxSaleDate1612 { get; set; }

    [StringLength(8)]
    [Unicode(false)]
    public string? MinInStockDate1612 { get; set; }

    [StringLength(8)]
    [Unicode(false)]
    public string? MaxInStockDate1612 { get; set; }

    [StringLength(50)]
    public string ImageSubFolder { get; set; } = null!;

    [StringLength(50)]
    public string? ImageFileName1 { get; set; }

    [StringLength(100)]
    public string? ImageSubFolderFileName1 { get; set; }

    public double? SaleQtyAll { get; set; }

    public double? StockQtyAll { get; set; }

    public bool IsFavorite { get; set; }
}
