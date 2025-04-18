using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VJN_OR_ProductAdditionalOrderSource_CounterProductOrderDetail_VGB
{
    public Guid SessionGID { get; set; }

    [StringLength(32)]
    public string ProductId { get; set; } = null!;

    public int? QtySum { get; set; }
}
