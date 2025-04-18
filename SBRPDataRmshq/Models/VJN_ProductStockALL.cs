using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VJN_ProductStockALL
{
    [StringLength(32)]
    public string Id { get; set; } = null!;

    [StringLength(32)]
    public string? CustomCode { get; set; }

    public float? Quantity00 { get; set; }

    public float? Quantity01 { get; set; }

    public float? Quantity02 { get; set; }

    public float? Quantity03 { get; set; }

    public float? Quantity1612 { get; set; }

    public float? QuantityALL { get; set; }
}
