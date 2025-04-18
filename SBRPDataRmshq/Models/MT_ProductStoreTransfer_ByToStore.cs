using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("ProductSelectedGID", "ToStoreID", "ProductID")]
[Table("MT_ProductStoreTransfer_ByToStore")]
public partial class MT_ProductStoreTransfer_ByToStore
{
    [Key]
    public Guid ProductSelectedGID { get; set; }

    [Key]
    [StringLength(32)]
    public string ToStoreID { get; set; } = null!;

    [Key]
    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    public int TranInStockSubTotal { get; set; }

    public int TranInStockWithoutReceived { get; set; }

    public int TranInStockWithReceived { get; set; }

    public DateOnly? TranInStockFirstDate { get; set; }

    public DateOnly? TranInStockLastDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }
}
