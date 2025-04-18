using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("SaleOrderID", "StoreID")]
[Table("OR_EXPORT_SaleOrder_Exclusion")]
public partial class OR_EXPORT_SaleOrder_Exclusion
{
    [Key]
    [StringLength(32)]
    public string SaleOrderID { get; set; } = null!;

    [Key]
    [StringLength(32)]
    public string StoreID { get; set; } = null!;

    [StringLength(50)]
    public string? Remark { get; set; }

    public DateTime TimeAddNew { get; set; }

    [StringLength(16)]
    [Unicode(false)]
    public string UserAddNewID { get; set; } = null!;
}
