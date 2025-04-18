using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VMT_ProductFlowStatistics_ByStore
{
    [StringLength(32)]
    public string StoreID { get; set; } = null!;

    [StringLength(30)]
    public string? StoreName { get; set; }

    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    [StringLength(32)]
    public string? ProductCode { get; set; }

    [StringLength(100)]
    public string? ProductName { get; set; }

    [StringLength(100)]
    public string? ImageSubFolderFileName1 { get; set; }

    public bool IsFavorite { get; set; }

    public bool IsStoped { get; set; }

    public DateOnly? InStockFirstDate { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? InStockFirstDateText { get; set; }

    public DateOnly? InStockLastDate { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? InStockLastDateText { get; set; }

    public int InStockSubTotal { get; set; }

    public int InStockSubWithoutReceived { get; set; }

    public int InStockSubWithReceived { get; set; }

    public DateOnly? TranInStockFirstDate { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? TranInStockFirstDateText { get; set; }

    public DateOnly? TranInStockLastDate { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? TranInStockLastDateText { get; set; }

    public int TranInStockSubTotal { get; set; }

    public int TranInStockWithoutReceived { get; set; }

    public int TranInStockWithReceived { get; set; }

    public DateOnly? TranOutStockFirstDate { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? TranOutStockFirstDateText { get; set; }

    public DateOnly? TranOutStockLastDate { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? TranOutStockLastDateText { get; set; }

    public int TranOutStockSubTotal { get; set; }

    public DateOnly? SaleFirstDate { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? SaleFirstDateText { get; set; }

    public DateOnly? SaleLastDate { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? SaleLastDateText { get; set; }

    public int SaleSubTotal { get; set; }

    public DateOnly? StockAdjustmentFirstDate { get; set; }

    public DateOnly? StockAdjustmentLastDate { get; set; }

    public int StockAdjustmentSubTotal { get; set; }

    public int StockSubTotal { get; set; }

    public int StockSubTotal_AboveOrEqualZero { get; set; }

    public int StockSubTotalWithReceived { get; set; }

    public int StockSubTotalWithoutReceived { get; set; }

    public int StockSubTotalWithReceivedWithoutCustomerOrder { get; set; }

    public int StockSubTotalWithReceivedWithoutCustomerOrder_AboveOrEqualZero { get; set; }

    public int CustomerOrderQty { get; set; }

    public int CustomerOrderQtyUnPackage { get; set; }

    public int CustomerOrderQtyPackaged { get; set; }

    public DateOnly? CustomerOrderFirstDate { get; set; }

    public DateOnly? CustomerOrderLastDate { get; set; }

    public DateTime TimeAddNew { get; set; }
}
