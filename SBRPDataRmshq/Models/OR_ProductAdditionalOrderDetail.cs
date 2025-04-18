using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("OrderSID", "ProductID")]
[Table("OR_ProductAdditionalOrderDetail")]
[Index("IsFinished", Name = "IX_OR_ProductAdditionalOrderDetail_IsFinished")]
public partial class OR_ProductAdditionalOrderDetail
{
    [Key]
    public int OrderSID { get; set; }

    [Key]
    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    public int SN { get; set; }

    public int Qty { get; set; }

    [StringLength(32)]
    public string Remark { get; set; } = null!;

    public bool IsFinished { get; set; }

    public int InStockBeforeNextOrderQty { get; set; }

    public int RemainOrderQty { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    [StringLength(32)]
    public string UserAddNewID { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? TimeModified { get; set; }

    [StringLength(32)]
    public string? UserModifiedID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeUpdateRemainQty { get; set; }

    [StringLength(32)]
    public string? UserUpdateRemainQtyID { get; set; }
}
