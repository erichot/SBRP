using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VS_MonthlyCalendar
{
    public double? Year1 { get; set; }

    public double? Month1 { get; set; }

    public double? Week1 { get; set; }

    public double? Year2 { get; set; }

    public double? Month2 { get; set; }

    public double? Week2 { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? Sunday { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? Monday { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? Tuesday { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? Wednesday { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? Thursday { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? Friday { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? Saturday { get; set; }
}
