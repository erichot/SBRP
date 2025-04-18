using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("ProductID", "StoreID")]
[Table("MT_ProductStock_ByStore")]
public partial class MT_ProductStock_ByStore
{
    [Key]
    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    [Key]
    [StringLength(32)]
    public string StoreID { get; set; } = null!;

    public int Qty { get; set; }
}
