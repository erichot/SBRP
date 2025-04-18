using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("OR_ProductUploadDetail")]
[Index("OrderSID", Name = "IX_OR_ProductUploadDetail_OrderSID")]
[Index("ProductID", Name = "IX_OR_ProductUploadDetail_ProductID")]
public partial class OR_ProductUploadDetail
{
    [Key]
    public int OrderItemSID { get; set; }

    public int OrderSID { get; set; }

    public int SN { get; set; }

    [StringLength(32)]
    public string? ProductID { get; set; }

    public int? Qty { get; set; }

    [StringLength(32)]
    public string? Remark { get; set; }

    public DateTime? TimeAddNew { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? UserAddNewID { get; set; }

    public DateTime? TimeModified { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? UserModifiedID { get; set; }
}
