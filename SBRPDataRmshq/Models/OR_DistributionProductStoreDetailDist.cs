using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("OrderSID", "ProductID")]
[Table("OR_DistributionProductStoreDetailDist")]
public partial class OR_DistributionProductStoreDetailDist
{
    [Key]
    public int OrderSID { get; set; }

    [Key]
    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    public int SafetyStockQty { get; set; }

    public int CustomerOrderQty { get; set; }

    public int StockSubTotal { get; set; }

    public int? DemandQtyPO { get; set; }

    public int? DemandQtyTotal { get; set; }

    public int? DistributionQty { get; set; }

    public int? StockRemainQty { get; set; }

    public int? StockRemainQtyForSSS { get; set; }
}
