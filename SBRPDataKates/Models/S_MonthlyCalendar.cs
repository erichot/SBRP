using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[PrimaryKey("Year1", "Month1", "Week1")]
[Table("S_MonthlyCalendar")]
public partial class S_MonthlyCalendar
{
    [Key]
    public double Year1 { get; set; }

    [Key]
    public double Month1 { get; set; }

    [Key]
    public double Week1 { get; set; }

    public double? Year2 { get; set; }

    public double? Month2 { get; set; }

    public double? Week2 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Sunday { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Monday { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Tuesday { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Wednesday { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Thursday { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Friday { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Saturday { get; set; }
}
