using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("MT_CompanyPurchasingOrder")]
public partial class MT_CompanyPurchasingOrder
{
    [Key]
    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    public int? Qty { get; set; }

    public int? InStockBeforeNextOrderQty { get; set; }

    public int? RemainOrderQty { get; set; }

    public DateOnly? FirstPurchasingDate { get; set; }

    public DateOnly? LasPurchasingDate { get; set; }
}
