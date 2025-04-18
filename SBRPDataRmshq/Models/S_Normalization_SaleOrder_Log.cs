using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("ReplicatedSID", "StoreID", "SaleOrderID")]
[Table("S_Normalization_SaleOrder_Log")]
public partial class S_Normalization_SaleOrder_Log
{
    [Key]
    public int ReplicatedSID { get; set; }

    [Key]
    [StringLength(4)]
    [Unicode(false)]
    public string StoreID { get; set; } = null!;

    [Key]
    [StringLength(32)]
    [Unicode(false)]
    public string SaleOrderID { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? TimeAddNew { get; set; }
}
