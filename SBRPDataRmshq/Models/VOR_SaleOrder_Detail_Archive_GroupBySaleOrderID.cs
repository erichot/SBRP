using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VOR_SaleOrder_Detail_Archive_GroupBySaleOrderID
{
    [StringLength(32)]
    public string SaleOrderID { get; set; } = null!;

    [StringLength(32)]
    public string StoreID { get; set; } = null!;

    public int? SubQty { get; set; }

    public int? CountProductID { get; set; }
}
