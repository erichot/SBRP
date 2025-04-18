using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("TransactionID", "StoreTransferItemID")]
[Table("OR_StoreTransfer_Detail_Archive")]
public partial class OR_StoreTransfer_Detail_Archive
{
    [Key]
    [StringLength(32)]
    public string TransactionID { get; set; } = null!;

    [Key]
    [StringLength(32)]
    public string StoreTransferItemID { get; set; } = null!;

    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    public int Qty { get; set; }
}
