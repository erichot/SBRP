using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("FromStoreID", "ToStoreID", "ProductID")]
[Table("MT_ProductStoreTransfer_ByStore")]
public partial class MT_ProductStoreTransfer_ByStore
{
    [Key]
    [StringLength(32)]
    public string FromStoreID { get; set; } = null!;

    [Key]
    [StringLength(32)]
    public string ToStoreID { get; set; } = null!;

    [Key]
    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    public int TransferQty { get; set; }

    public int TransferQtyWithoutReceived { get; set; }

    public int TransferQtyWithReceived { get; set; }

    public DateOnly? MinTransactionDate { get; set; }

    public DateOnly? MaxTransactionDate { get; set; }

    public DateTime TimeAddNew { get; set; }
}
