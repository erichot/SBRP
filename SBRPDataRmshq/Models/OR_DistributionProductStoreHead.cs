using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("OR_DistributionProductStoreHead")]
public partial class OR_DistributionProductStoreHead
{
    [Key]
    public int OrderSID { get; set; }

    [StringLength(32)]
    public string StoreID { get; set; } = null!;

    public int? VaildRowCount { get; set; }

    public int? SubTotalPoQty { get; set; }

    public int? SubTotalSSSQty { get; set; }

    public bool IsDraft { get; set; }

    public bool IsForDeduction { get; set; }

    public bool IsCalculatedWithDeduction { get; set; }

    public bool InActive { get; set; }

    [StringLength(64)]
    public string? Remark { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string UserAddNewID { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeModified { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? UserModifiedID { get; set; }
}
