using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VMT_ProductFlowStatistics_ByStore_1612
{
    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    public DateOnly? InStockFirstDate { get; set; }

    public DateOnly? InStockLastDate { get; set; }

    public int? InStockSubTotal { get; set; }

    public int? StockSubTotal { get; set; }

    public DateOnly? SaleFirstDate { get; set; }

    public DateOnly? SaleLastDate { get; set; }

    public int? SaleSubTotal { get; set; }

    public DateTime TimeAddNew { get; set; }
}
