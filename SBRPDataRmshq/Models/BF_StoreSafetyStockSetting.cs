using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("ProductID", "StoreID")]
[Table("BF_StoreSafetyStockSetting")]
[Index("InActive", Name = "IX_BF_StoreSafetyStockSetting_InActive")]
public partial class BF_StoreSafetyStockSetting
{
    [Key]
    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    [Key]
    [StringLength(32)]
    public string StoreID { get; set; } = null!;

    public int? SafetyStockQty { get; set; }

    public int? SafetyStockQty_Previous { get; set; }

    public short? UploadFromItemNo { get; set; }

    [StringLength(30)]
    public string? Remark { get; set; }

    public bool InActive { get; set; }

    [StringLength(32)]
    public string UserAddNewID { get; set; } = null!;

    public DateTime TimeAddNew { get; set; }

    [StringLength(32)]
    public string? UserModifiedID { get; set; }

    public DateTime? TimeModified { get; set; }
}
