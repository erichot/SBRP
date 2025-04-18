using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("OrderSID", "ProductID", "PriorityItemNo")]
[Table("OR_CompanyPreOrderInStore_Detail")]
[Index("IsStockUpItem", Name = "IX_OR_CompanyPreOrderInStore_Detail_IsStockUpItem")]
[Index("PreOrderSID", Name = "IX_OR_CompanyPreOrderInStore_Detail_PreOrderSID")]
public partial class OR_CompanyPreOrderInStore_Detail
{
    [Key]
    public int OrderSID { get; set; }

    [Key]
    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    [Key]
    public int PriorityItemNo { get; set; }

    public int PreOrderSID { get; set; }

    public int PreOrderItemNo { get; set; }

    public int? PreOrderQty { get; set; }

    public int? PreOrderUnStockUpQty { get; set; }

    /// <summary>
    /// 門市自身庫存分配量
    /// </summary>
    public int? SelfStoreToStockUpQty { get; set; }

    public int? SelfStoreStockRemainQty { get; set; }

    public int? CompanyStockUpQty_Suggestion { get; set; }

    public int? CompanyStockUpQty { get; set; }

    public int? CompanyRemainQty { get; set; }

    public bool IsStockUpItem { get; set; }
}
