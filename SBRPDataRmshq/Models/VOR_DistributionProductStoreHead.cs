using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VOR_DistributionProductStoreHead
{
    public int OrderSID { get; set; }

    [StringLength(32)]
    public string StoreID { get; set; } = null!;

    [StringLength(64)]
    public string? Remark { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string UserAddNewID { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? TimeAddNewText { get; set; }

    public int? VaildRowCount { get; set; }

    public int? SubTotalPoQty { get; set; }

    public int? SubTotalSSSQty { get; set; }

    public bool IsForDeduction { get; set; }

    public bool IsCalculatedWithDeduction { get; set; }

    public bool IsDraft { get; set; }

    public bool InActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeModified { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? TimeModifiedText { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? UserModifiedID { get; set; }
}
