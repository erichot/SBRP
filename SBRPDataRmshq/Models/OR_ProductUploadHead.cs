using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("OR_ProductUploadHead")]
[Index("OrderID", Name = "IX_OR_ProductUploadHead_OrderID")]
public partial class OR_ProductUploadHead
{
    [Key]
    public int OrderSID { get; set; }

    [StringLength(32)]
    public string? StoreID { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string? OrderTypeID { get; set; }

    [StringLength(50)]
    public string? Remark { get; set; }

    public short? ItemCount { get; set; }

    public short? SubQty { get; set; }

    [StringLength(32)]
    public string? OrderID { get; set; }

    public bool? IsMatching { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? UserAddNewID { get; set; }

    public DateTime TimeAddNew { get; set; }
}
