using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("OR_StoreTransfer_Head")]
[Index("FromStoreID", Name = "IX_OR_StoreTransfer_Head_FromStoreID")]
[Index("InActive", Name = "IX_OR_StoreTransfer_Head_InActive")]
[Index("IsReceived", Name = "IX_OR_StoreTransfer_Head_IsReceived")]
[Index("ToStoreID", Name = "IX_OR_StoreTransfer_Head_ToStoreID")]
[Index("TransactionDate", Name = "IX_OR_StoreTransfer_Head_TransactionDate")]
public partial class OR_StoreTransfer_Head
{
    [Key]
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
