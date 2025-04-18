using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VBF_HourlyPay
{
    [StringLength(12)]
    [Unicode(false)]
    public string HourlyPayID { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal HourlyPay { get; set; }

    public double? HourlyPay_Float { get; set; }

    [StringLength(23)]
    [Unicode(false)]
    public string? ListField { get; set; }

    [StringLength(24)]
    public string? Note { get; set; }
}
