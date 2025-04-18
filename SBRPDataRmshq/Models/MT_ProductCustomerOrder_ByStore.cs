using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("StoreID", "ProductID")]
[Table("MT_ProductCustomerOrder_ByStore")]
public partial class MT_ProductCustomerOrder_ByStore
{
    [Key]
    [StringLength(32)]
    public string StoreID { get; set; } = null!;

    [Key]
    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    public int CustomerOrderQty { get; set; }

    public int CustomerOrderQtyUnPackage { get; set; }

    public int CustomerOrderQtyPackaged { get; set; }

    public DateOnly? CustomerOrderFirstDate { get; set; }

    public DateOnly? CustomerOrderLastDate { get; set; }

    public DateTime TimeAddNew { get; set; }
}
