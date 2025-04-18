using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("OR_SaleReturnOrder_Head")]
[Index("NewSaleOrderID", Name = "IX_OR_SaleReturnOrder_Head_NewSaleOrderID")]
public partial class OR_SaleReturnOrder_Head
{
    [Key]
    [StringLength(32)]
    public string SaleReturnOrderID { get; set; } = null!;

    [StringLength(32)]
    public string SaleOrderID { get; set; } = null!;

    [StringLength(32)]
    public string StoreID { get; set; } = null!;

    public DateOnly? SaleOrderDate { get; set; }

    public DateOnly? SaleReturnDate { get; set; }

    public DateTime SaleReturnDateTime { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string CashierID { get; set; } = null!;

    [StringLength(50)]
    public string? OrderRemark { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? NewSaleOrderID { get; set; }

    [StringLength(64)]
    [Unicode(false)]
    public string? MemberID { get; set; }

    public int? MemberPointsWithSaleOrder { get; set; }

    public int? UpdatedMemberPoints { get; set; }

    public bool InActive { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string UserAddNewID { get; set; } = null!;

    public DateTime TimeAddNew { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? UserModifiedID { get; set; }

    public DateTime? TimeModified { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? UserNullified { get; set; }

    public DateTime? TimeNullified { get; set; }
}
