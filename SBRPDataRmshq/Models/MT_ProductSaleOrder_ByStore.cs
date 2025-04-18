using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("ProductID", "StoreID")]
[Table("MT_ProductSaleOrder_ByStore")]
public partial class MT_ProductSaleOrder_ByStore
{
    [Key]
    [StringLength(32)]
    public string StoreID { get; set; } = null!;

    [Key]
    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    public int? SaleQty { get; set; }

    public DateOnly? SaleFirstDate { get; set; }

    public DateOnly? SaleLastDate { get; set; }

    public DateTime TimeAddNew { get; set; }
}
