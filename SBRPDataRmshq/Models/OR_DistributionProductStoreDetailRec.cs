using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("OrderSID", "ProductID", "ItemNo")]
[Table("OR_DistributionProductStoreDetailRec")]
public partial class OR_DistributionProductStoreDetailRec
{
    [Key]
    public int OrderSID { get; set; }

    [Key]
    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    [Key]
    public byte ItemNo { get; set; }

    [StringLength(32)]
    public string StoreID { get; set; } = null!;

    public byte StorePriorityNo { get; set; }

    public int SafetyStockQty { get; set; }

    public int CustomerOrderQty { get; set; }

    public int StockSubTotal { get; set; }

    public int? DemandQtyPO { get; set; }

    public int? DemandQtySSS { get; set; }

    public int? DistributionQtyPO { get; set; }

    public int? DistributionQtySSS { get; set; }

    public int? DistrStockRemainQtyForNext { get; set; }

    public int? DistrStockRemainQtyForNext2 { get; set; }

    public byte CurrentItemNoPO { get; set; }

    public byte CurrentItemNoSSS { get; set; }

    public int DistributionQtyPO_Deduct { get; set; }

    public int DistributionQtySSS_Deduct { get; set; }
}
