using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("OR_InStock_Head_Archive")]
[Index("StoreID", Name = "IX_OR_InStock_Head_Archive_StoreID")]
[Index("SupplierID", Name = "IX_OR_InStock_Head_Archive_SupplierID")]
[Index("TransactionDate", Name = "IX_OR_InStock_Head_Archive_TransactionDate")]
public partial class OR_InStock_Head_Archive
{
    [Key]
    [StringLength(32)]
    public string TransactionID { get; set; } = null!;

    public DateOnly TransactionDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TransactionDateTime { get; set; }

    [StringLength(32)]
    public string SupplierID { get; set; } = null!;

    [StringLength(32)]
    public string CashierId { get; set; } = null!;

    [StringLength(32)]
    public string StoreID { get; set; } = null!;

    public int SubTotalQty { get; set; }

    [StringLength(50)]
    public string? Remark { get; set; }

    public bool IsReceived { get; set; }

    public bool InActive { get; set; }
}
