using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VOR_EXPORT_SaleOrder_Head_Member
{
    public Guid ExportGID { get; set; }

    public int SerialNo { get; set; }

    [StringLength(32)]
    public string SaleOrderID { get; set; } = null!;

    [StringLength(128)]
    [Unicode(false)]
    public string? Email { get; set; }

    public int SubQty { get; set; }

    public DateOnly SaleDate { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? SaleDateText { get; set; }

    public int Total { get; set; }

    public int? ShoppingPointsUsed { get; set; }

    [StringLength(32)]
    public string? StoreID { get; set; }

    [StringLength(32)]
    public string? StoreName { get; set; }

    [StringLength(64)]
    [Unicode(false)]
    public string? MemberID { get; set; }

    public int? CountProductID { get; set; }

    public DateTime TimeAddNew { get; set; }
}
