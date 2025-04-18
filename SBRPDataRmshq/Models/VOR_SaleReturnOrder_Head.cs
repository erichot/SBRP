using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VOR_SaleReturnOrder_Head
{
    [StringLength(32)]
    public string SaleReturnOrderID { get; set; } = null!;

    [StringLength(32)]
    public string SaleOrderID { get; set; } = null!;

    [StringLength(32)]
    public string StoreID { get; set; } = null!;

    public DateOnly? SaleReturnDate { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? SaleReturnDateText { get; set; }

    public DateTime SaleReturnDateTime { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string CashierID { get; set; } = null!;

    [StringLength(50)]
    public string? OrderRemark { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? NewSaleOrderID { get; set; }

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
