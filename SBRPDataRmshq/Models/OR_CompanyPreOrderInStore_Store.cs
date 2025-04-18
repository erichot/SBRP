using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("OrderSID", "StoreID", "ProductID")]
[Table("OR_CompanyPreOrderInStore_Store")]
[Index("SafetyStockQty", Name = "IX_OR_CompanyPreOrderInStore_Store_SafetyStockQty")]
[Index("StoreStockQty", Name = "IX_OR_CompanyPreOrderInStore_Store_StoreStockQty")]
public partial class OR_CompanyPreOrderInStore_Store
{
    [Key]
    public int OrderSID { get; set; }

    [Key]
    [StringLength(32)]
    public string StoreID { get; set; } = null!;

    [Key]
    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    public int SafetyStockQty { get; set; }

    public int StoreStockQty { get; set; }

    public int? PreOrderQty { get; set; }

    public int? PreOrderStockUpQty { get; set; }

    public int? PreOrderUnStockUpQty { get; set; }

    /// <summary>
    /// 門市淨需求量：如果未到貨量（門市需求）超過該門市的庫存
    /// </summary>
    public int? StoreDemandQty { get; set; }

    public int? StoreOverflowQty { get; set; }

    public int? CompanyStockUpQty_Suggestion { get; set; }

    public int? CompanyStockUpQty { get; set; }

    public int? StorePreOrderItemCount { get; set; }
}
