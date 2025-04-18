using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VJN_OR_ProductAdditionalOrderSource_CounterProductOrderDetail
{
    public Guid SessionGID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    [StringLength(32)]
    public string UserAddNewID { get; set; } = null!;

    public int OrderSID { get; set; }

    [StringLength(32)]
    public string ProductId { get; set; } = null!;

    public int Qty { get; set; }
}
