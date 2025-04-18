using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VJN_VGB_SaleItemALL
{
    [StringLength(32)]
    public string Id { get; set; } = null!;

    [StringLength(32)]
    public string? ProductCode { get; set; }

    public double? Quantity00 { get; set; }

    public double? Quantity01 { get; set; }

    public double? Quantity02 { get; set; }

    public double? Quantity03 { get; set; }

    public double? Quantity1612 { get; set; }

    public double QuantityALL { get; set; }
}
