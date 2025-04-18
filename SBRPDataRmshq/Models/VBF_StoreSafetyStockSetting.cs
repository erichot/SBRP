using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VBF_StoreSafetyStockSetting
{
    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    [StringLength(32)]
    public string? ProductCode { get; set; }

    [StringLength(100)]
    public string? ProductName { get; set; }

    [StringLength(100)]
    public string? ImageSubFolderFileName1 { get; set; }

    [StringLength(32)]
    public string StoreID { get; set; } = null!;

    [StringLength(6)]
    public string StoreAbbreviation { get; set; } = null!;

    [StringLength(32)]
    public string StoreName { get; set; } = null!;

    public int SafetyStockQty { get; set; }

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

    [StringLength(32)]
    public string LastModifiedID { get; set; } = null!;

    public DateTime LastModifiedTime { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? LastModifiedTimeText { get; set; }
}
