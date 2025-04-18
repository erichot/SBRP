using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("OR_StockAdjustment_Head")]
[Index("CashierId", Name = "IX_OR_StockAdjustment_Head_CashierId")]
[Index("InActive", Name = "IX_OR_StockAdjustment_Head_InActive")]
[Index("StoreID", Name = "IX_OR_StockAdjustment_Head_StoreID")]
[Index("TransactionDate", Name = "IX_OR_StockAdjustment_Head_TransactionDate")]
public partial class OR_StockAdjustment_Head
{
    [Key]
    [StringLength(32)]
    public string TransactionID { get; set; } = null!;

    public DateOnly TransactionDate { get; set; }

    [StringLength(32)]
    public string StoreID { get; set; } = null!;

    [StringLength(32)]
    public string? Class { get; set; }

    [StringLength(32)]
    public string CashierId { get; set; } = null!;

    public int TransactionType { get; set; }

    public bool InActive { get; set; }

    public DateTime? TimeAddNew { get; set; }
}
