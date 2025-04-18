using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("UpdatedLogSID", "OrderSID", "PreOrderSID", "PreOrderItemNo")]
[Table("OR_PreOrderArrival_Detail_UpdatedLog")]
public partial class OR_PreOrderArrival_Detail_UpdatedLog
{
    [Key]
    public int UpdatedLogSID { get; set; }

    [Key]
    public int OrderSID { get; set; }

    [Key]
    public int PreOrderSID { get; set; }

    [Key]
    public int PreOrderItemNo { get; set; }

    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    public int StockUpQty { get; set; }

    public int ToStockUpQty { get; set; }
}
