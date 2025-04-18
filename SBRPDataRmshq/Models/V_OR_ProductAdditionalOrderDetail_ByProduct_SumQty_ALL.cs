using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class V_OR_ProductAdditionalOrderDetail_ByProduct_SumQty_ALL
{
    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    public int? SumQty { get; set; }
}
