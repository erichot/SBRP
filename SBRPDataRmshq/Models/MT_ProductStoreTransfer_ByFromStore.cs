using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("ProductSelectedGID", "FromStoreID", "ProductID")]
[Table("MT_ProductStoreTransfer_ByFromStore")]
public partial class MT_ProductStoreTransfer_ByFromStore
{
    [Key]
    public Guid ProductSelectedGID { get; set; }

    [Key]
    [StringLength(32)]
    public string FromStoreID { get; set; } = null!;

    [Key]
    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    public int TranOutStockSubTotal { get; set; }

    public DateOnly? TranOutStockFirstDate { get; set; }

    public DateOnly? TranOutStockLastDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }
}
