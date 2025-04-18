using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VGB_SaleItem1612_ProductId
{
    [StringLength(32)]
    [Unicode(false)]
    public string? ProductId { get; set; }

    public double? SumQuantity { get; set; }

    [StringLength(8)]
    [Unicode(false)]
    public string? MinSaleDate { get; set; }

    [StringLength(8)]
    [Unicode(false)]
    public string? MaxSaleDate { get; set; }
}
