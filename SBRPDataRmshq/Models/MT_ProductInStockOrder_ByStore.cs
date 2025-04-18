using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("StoreID", "ProductID")]
[Table("MT_ProductInStockOrder_ByStore")]
public partial class MT_ProductInStockOrder_ByStore
{
    [Key]
    [StringLength(32)]
    public string StoreID { get; set; } = null!;

    [Key]
    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    public int InStockQty { get; set; }

    public int InStockQtyWithoutReceived { get; set; }

    public int InStockQtyWithReceived { get; set; }

    public DateOnly? InStockFirstDate { get; set; }

    public DateOnly? InStockLastDate { get; set; }

    public DateTime TimeAddNew { get; set; }
}
