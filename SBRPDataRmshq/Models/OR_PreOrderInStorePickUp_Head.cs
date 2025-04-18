using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("OR_PreOrderInStorePickUp_Head")]
[Index("InActive", Name = "IX_OR_PreOrderInStorePickUp_Head_InActive")]
[Index("IsFinishedToPreOrder", Name = "IX_OR_PreOrderInStorePickUp_Head_IsFinishedToPreOrder")]
[Index("PreOrderSID", Name = "IX_OR_PreOrderInStorePickUp_Head_PreOrderSID")]
public partial class OR_PreOrderInStorePickUp_Head
{
    [Key]
    public int OrderSID { get; set; }

    public int PreOrderSID { get; set; }

    public DateOnly OrderDate { get; set; }

    [StringLength(300)]
    public string Remark { get; set; } = null!;

    /// <summary>
    /// 本張單據成立之前，該預購單的累計已取貨量
    /// </summary>
    public int? InStorePickUpQty { get; set; }

    public int? SubToPickUpQty { get; set; }

    /// <summary>
    /// 本張預購單剩餘未取的數量
    /// </summary>
    public int? RemainQtyForInStorePickUp { get; set; }

    /// <summary>
    /// 本次取貨，造成預購單全部取貨完畢
    /// </summary>
    public bool IsFinishedToPreOrder { get; set; }

    public bool InActive { get; set; }

    [StringLength(16)]
    [Unicode(false)]
    public string UserAddNewID { get; set; } = null!;

    public DateTime TimeAddNew { get; set; }
}
