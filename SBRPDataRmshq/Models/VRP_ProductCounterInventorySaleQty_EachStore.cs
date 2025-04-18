using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VRP_ProductCounterInventorySaleQty_EachStore
{
    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    [StringLength(32)]
    public string? ProductCode { get; set; }

    [StringLength(100)]
    public string? ProductName { get; set; }

    public int? InStockSubTotal { get; set; }

    public int? StockSubTotal { get; set; }

    public int? SaleSubTotal { get; set; }

    public DateOnly? InStockFirstDate00 { get; set; }

    public DateOnly? InStockLastDate00 { get; set; }

    public int? InStockSubTotal00 { get; set; }

    public int? StockSubTotal00 { get; set; }

    public DateOnly? SaleFirstDate00 { get; set; }

    public DateOnly? SaleLastDate00 { get; set; }

    public int? SaleSubTotal00 { get; set; }

    public DateOnly? InStockFirstDate01 { get; set; }

    public DateOnly? InStockLastDate01 { get; set; }

    public int? InStockSubTotal01 { get; set; }

    public int? StockSubTotal01 { get; set; }

    public DateOnly? SaleFirstDate01 { get; set; }

    public DateOnly? SaleLastDate01 { get; set; }

    public int? SaleSubTotal01 { get; set; }

    public DateOnly? InStockFirstDate02 { get; set; }

    public DateOnly? InStockLastDate02 { get; set; }

    public int? InStockSubTotal02 { get; set; }

    public int? StockSubTotal02 { get; set; }

    public DateOnly? SaleFirstDate02 { get; set; }

    public DateOnly? SaleLastDate02 { get; set; }

    public int? SaleSubTotal02 { get; set; }

    public DateOnly? InStockFirstDate03 { get; set; }

    public DateOnly? InStockLastDate03 { get; set; }

    public int? InStockSubTotal03 { get; set; }

    public int? StockSubTotal03 { get; set; }

    public DateOnly? SaleFirstDate03 { get; set; }

    public DateOnly? SaleLastDate03 { get; set; }

    public int? SaleSubTotal03 { get; set; }

    public DateOnly? InStockFirstDate1612 { get; set; }

    public DateOnly? InStockLastDate1612 { get; set; }

    public int? InStockSubTotal1612 { get; set; }

    public int? StockSubTotal1612 { get; set; }

    public DateOnly? SaleFirstDate1612 { get; set; }

    public DateOnly? SaleLastDate1612 { get; set; }

    public int? SaleSubTotal1612 { get; set; }

    [StringLength(50)]
    public string? ImageFileName1 { get; set; }

    [StringLength(100)]
    public string? ImageSubFolderFileName1 { get; set; }

    public bool IsFavorite { get; set; }
}
