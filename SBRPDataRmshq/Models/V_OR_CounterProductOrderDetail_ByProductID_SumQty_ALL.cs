using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class V_OR_CounterProductOrderDetail_ByProductID_SumQty_ALL
{
    [StringLength(32)]
    public string ProductId { get; set; } = null!;

    public int? SumQty { get; set; }
}
