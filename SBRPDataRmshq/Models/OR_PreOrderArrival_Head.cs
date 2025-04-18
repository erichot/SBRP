using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("OR_PreOrderArrival_Head")]
[Index("InActive", Name = "IX_OR_PreOrderArrival_Head_InActive")]
[Index("OrderDate", Name = "IX_OR_PreOrderArrival_Head_OrderDate")]
[Index("StoreID", Name = "IX_OR_PreOrderArrival_Head_StoreID")]
public partial class OR_PreOrderArrival_Head
{
    [Key]
    public int OrderSID { get; set; }

    [StringLength(32)]
    public string StoreID { get; set; } = null!;

    public DateOnly OrderDate { get; set; }

    public int DetailedRowCount { get; set; }

    public int SubProductCount { get; set; }

    public int SubQty { get; set; }

    [StringLength(300)]
    public string Remark { get; set; } = null!;

    public bool InActive { get; set; }

    public int? OperationSID { get; set; }

    [StringLength(16)]
    [Unicode(false)]
    public string UserAddNewID { get; set; } = null!;

    public DateTime TimeAddNew { get; set; }

    [StringLength(16)]
    [Unicode(false)]
    public string? UserModifiedID { get; set; }

    public DateTime? TimeModified { get; set; }
}
