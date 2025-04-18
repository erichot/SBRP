using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("TransactionID", "InStockItemID")]
[Table("OR_InStock_Detail_Archive")]
[Index("ProductID", Name = "IX_OR_InStock_Detail_Archive_ProductID")]
public partial class OR_InStock_Detail_Archive
{
    [Key]
    [StringLength(32)]
    public string TransactionID { get; set; } = null!;

    [Key]
    [StringLength(32)]
    public string InStockItemID { get; set; } = null!;

    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    public int Qty { get; set; }
}
