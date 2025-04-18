using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("ProductID", "StoreID")]
[Table("MT_ProductStockAdjustment_ByStore")]
public partial class MT_ProductStockAdjustment_ByStore
{
    [Key]
    [StringLength(32)]
    public string StoreID { get; set; } = null!;

    [Key]
    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    public int StockAdjustmentQty { get; set; }

    public DateOnly? StockAdjustmentFirstDate { get; set; }

    public DateOnly? StockAdjustmentLastDate { get; set; }

    public DateTime TimeAddNew { get; set; }
}
