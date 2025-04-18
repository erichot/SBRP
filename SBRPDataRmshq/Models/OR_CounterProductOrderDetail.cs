using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("OrderSID", "ProductId")]
[Table("OR_CounterProductOrderDetail")]
public partial class OR_CounterProductOrderDetail
{
    [Key]
    public int OrderSID { get; set; }

    [Key]
    [StringLength(32)]
    public string ProductId { get; set; } = null!;

    public int SN { get; set; }

    public int Qty { get; set; }

    [StringLength(50)]
    public string? Remark { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    [StringLength(32)]
    public string UserAddNewID { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? TimeModified { get; set; }

    [StringLength(32)]
    public string? UserModifiedID { get; set; }
}
