using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("OrderSID", "ProductID")]
[Table("OR_CompanyPreOrderInStore_Product")]
[Index("IsStockUpItem", Name = "IX_OR_CompanyPreOrderInStore_Product_IsStockUpItem")]
public partial class OR_CompanyPreOrderInStore_Product
{
    [Key]
    public int OrderSID { get; set; }

    [Key]
    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    public int? PreOrderQty { get; set; }

    public int? PreOrderStockUpQty { get; set; }

    public int? PreOrderUnStockUpQty { get; set; }

    public int? SafetyStockQty { get; set; }

    public int? StoreStockQty { get; set; }

    public int? StoreDemandQty { get; set; }

    public int? CompanySafetyStockQty { get; set; }

    public int CompanyStockQty { get; set; }

    public int? CompanyStockUpQty { get; set; }

    public int? CompanyUnStockUpQty { get; set; }

    public int? CompanyRemainQty { get; set; }

    public bool IsStockUpItem { get; set; }
}
