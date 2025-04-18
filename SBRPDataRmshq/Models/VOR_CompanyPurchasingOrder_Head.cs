using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VOR_CompanyPurchasingOrder_Head
{
    public int OrderSID { get; set; }

    public DateOnly OrderDate { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? OrderDateText { get; set; }

    [StringLength(300)]
    public string Remark { get; set; } = null!;

    [StringLength(16)]
    [Unicode(false)]
    public string UserAddNewID { get; set; } = null!;

    [StringLength(16)]
    public string UserAddNewName { get; set; } = null!;

    public DateTime TimeAddNew { get; set; }

    public int DetailedRowCount { get; set; }

    public int SubQty { get; set; }

    [Column(TypeName = "money")]
    public decimal SubPrice { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? SubPriceText { get; set; }
}
