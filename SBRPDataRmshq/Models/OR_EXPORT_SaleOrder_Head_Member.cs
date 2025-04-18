using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("ExportGID", "SerialNo")]
[Table("OR_EXPORT_SaleOrder_Head_Member")]
[Index("SaleOrderID", Name = "IX_OR_EXPORT_SaleOrder_Head_Member_SaleOrderID")]
[Index("StoreID", Name = "IX_OR_EXPORT_SaleOrder_Head_Member_StoreID")]
public partial class OR_EXPORT_SaleOrder_Head_Member
{
    [Key]
    public Guid ExportGID { get; set; }

    [Key]
    public int SerialNo { get; set; }

    [StringLength(32)]
    public string SaleOrderID { get; set; } = null!;

    [StringLength(128)]
    [Unicode(false)]
    public string? Email { get; set; }

    public int SubQty { get; set; }

    public DateOnly SaleDate { get; set; }

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
