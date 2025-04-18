using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VOR_PreOrderInStorePickUp_Head
{
    public int OrderSID { get; set; }

    public DateOnly OrderDate { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? OrderDateText { get; set; }

    public int PreOrderSID { get; set; }

    [StringLength(11)]
    [Unicode(false)]
    public string? PreOrderID { get; set; }

    public DateOnly? PreOrderDate { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? PreOrderDateText { get; set; }

    [StringLength(64)]
    [Unicode(false)]
    public string? MemberAccount { get; set; }

    [StringLength(16)]
    public string? MemberName { get; set; }

    [StringLength(300)]
    public string Remark { get; set; } = null!;

    [StringLength(16)]
    [Unicode(false)]
    public string UserAddNewID { get; set; } = null!;

    public DateTime TimeAddNew { get; set; }

    [StringLength(16)]
    public string? UserAddNewName { get; set; }

    public int? PreOrderQty { get; set; }

    [StringLength(6)]
    public string? StoreAbbreviation { get; set; }

    public int? SubToPickUpQty { get; set; }

    [StringLength(16)]
    public string? ConsigneeName { get; set; }
}
