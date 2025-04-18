using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VOR_StoreTransfer_Head_UnionArchive
{
    [StringLength(32)]
    public string TransactionID { get; set; } = null!;

    public DateOnly TransactionDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TransactionDateTime { get; set; }

    [StringLength(32)]
    public string FromStoreID { get; set; } = null!;

    [StringLength(32)]
    public string ToStoreID { get; set; } = null!;

    [StringLength(32)]
    public string CashierId { get; set; } = null!;

    public int SubTotalQty { get; set; }

    [StringLength(50)]
    public string? Remark { get; set; }

    public bool IsReceived { get; set; }

    public bool InActive { get; set; }

    public DateTime? TimeAddNew { get; set; }
}
