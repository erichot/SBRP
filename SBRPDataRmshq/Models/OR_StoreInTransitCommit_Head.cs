using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("OR_StoreInTransitCommit_Head")]
[Index("InActive", Name = "IX_OR_StoreInTransitCommit_Head_InActive")]
[Index("OrderType", Name = "IX_OR_StoreInTransitCommit_Head_OrderType")]
[Index("StoreID", Name = "IX_OR_StoreInTransitCommit_Head_StoreID")]
[Index("TransactionID", Name = "IX_OR_StoreInTransitCommit_Head_TransactionID")]
public partial class OR_StoreInTransitCommit_Head
{
    [Key]
    public int OrderSID { get; set; }

    /// <summary>
    /// 1：入庫單；2：轉貨（TranIn）單
    /// </summary>
    public byte OrderType { get; set; }

    [StringLength(32)]
    public string StoreID { get; set; } = null!;

    [StringLength(32)]
    public string TransactionID { get; set; } = null!;

    public DateOnly OrderDate { get; set; }

    [StringLength(50)]
    public string? Remark { get; set; }

    public DateTime TimeAddNew { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string UserAddNewID { get; set; } = null!;

    public DateTime? TimeModified { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? UserModifiedID { get; set; }

    public bool InActive { get; set; }
}
