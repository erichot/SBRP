using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("TransactionID", "ProductID")]
[Table("OR_StockAdjustment_Detail")]
public partial class OR_StockAdjustment_Detail
{
    [Key]
    [StringLength(32)]
    public string TransactionID { get; set; } = null!;

    [Key]
    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    public int Qty { get; set; }
}
