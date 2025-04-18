using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("MT_ProductFlowStatistics_ByProduct")]
public partial class MT_ProductFlowStatistics_ByProduct
{
    [Key]
    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    public int? CompanyPurchasingQty { get; set; }

    public int? CompanyPurchasingInStockBeforeNextOrderQty { get; set; }

    public int? CompanyPurchasingRemainQty { get; set; }

    public DateOnly? InStockFirstDate { get; set; }

    public DateOnly? InStockLastDate { get; set; }

    public int InStockSubTotal { get; set; }

    public int InStockSubWithoutReceived { get; set; }

    public int InStockSubWithReceived { get; set; }

    public DateOnly? SaleFirstDate { get; set; }

    public DateOnly? SaleLastDate { get; set; }

    public int SaleSubTotal { get; set; }

    public DateOnly? TranInStockFirstDate { get; set; }

    public DateOnly? TranInStockLastDate { get; set; }

    public int TranInStockSubTotal { get; set; }

    public int TranInStockWithoutReceived { get; set; }

    public int TranInStockWithReceived { get; set; }

    public DateOnly? TranOutStockFirstDate { get; set; }

    public DateOnly? TranOutStockLastDate { get; set; }

    public int TranOutStockSubTotal { get; set; }

    public DateOnly? StockAdjustmentFirstDate { get; set; }

    public DateOnly? StockAdjustmentLastDate { get; set; }

    public int StockAdjustmentSubTotal { get; set; }

    public int StockSubTotal { get; set; }

    public int CustomerOrderQty { get; set; }

    public int CustomerOrderQtyUnPackage { get; set; }

    public int CustomerOrderQtyPackaged { get; set; }

    public DateOnly? CustomerOrderFirstDate { get; set; }

    public DateOnly? CustomerOrderLastDate { get; set; }

    public DateTime TimeAddNew { get; set; }
}
