using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("OR_CompanyPurchasingOrder_Head")]
public partial class OR_CompanyPurchasingOrder_Head
{
    [Key]
    public int OrderSID { get; set; }

    public DateOnly OrderDate { get; set; }

    [StringLength(300)]
    public string Remark { get; set; } = null!;

    public bool InActive { get; set; }

    public bool IsFinished { get; set; }

    public int DetailedRowCount { get; set; }

    public int SubQty { get; set; }

    [Column(TypeName = "money")]
    public decimal SubPrice { get; set; }

    [StringLength(16)]
    [Unicode(false)]
    public string UserAddNewID { get; set; } = null!;

    public DateTime TimeAddNew { get; set; }

    [StringLength(16)]
    [Unicode(false)]
    public string? UserUpdateRemainQtyID { get; set; }
}
