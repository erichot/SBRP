using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("StoreID", "ProductID", "UserID")]
[Table("TMP_StoreProductQty")]
[Index("ProductCode", Name = "IX_TMP_StoreProductQty_ProductCode")]
public partial class TMP_StoreProductQty
{
    [Key]
    [StringLength(2)]
    [Unicode(false)]
    public string StoreID { get; set; } = null!;

    [Key]
    [StringLength(36)]
    [Unicode(false)]
    public string ProductID { get; set; } = null!;

    [Key]
    [StringLength(8)]
    [Unicode(false)]
    public string UserID { get; set; } = null!;

    [StringLength(36)]
    [Unicode(false)]
    public string? ProductCode { get; set; }

    public int SaleQty { get; set; }
}
