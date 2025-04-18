using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[PrimaryKey("AppSID", "UserSID", "YearValue", "MonthValue")]
[Table("TMP_MonthlyColumnDataSheet")]
public partial class TMP_MonthlyColumnDataSheet
{
    [Key]
    public int AppSID { get; set; }

    [Key]
    public int UserSID { get; set; }

    [Key]
    public short YearValue { get; set; }

    [Key]
    public byte MonthValue { get; set; }

    [StringLength(10)]
    public string DepartmentID { get; set; } = null!;

    public int? Day01 { get; set; }

    public int? Day02 { get; set; }

    public int? Day03 { get; set; }

    public int? Day04 { get; set; }

    public int? Day05 { get; set; }

    public int? Day06 { get; set; }

    public int? Day07 { get; set; }

    public int? Day08 { get; set; }

    public int? Day09 { get; set; }

    public int? Day10 { get; set; }

    public int? Day11 { get; set; }

    public int? Day12 { get; set; }

    public int? Day13 { get; set; }

    public int? Day14 { get; set; }

    public int? Day15 { get; set; }

    public int? Day16 { get; set; }

    public int? Day17 { get; set; }

    public int? Day18 { get; set; }

    public int? Day19 { get; set; }

    public int? Day20 { get; set; }

    public int? Day21 { get; set; }

    public int? Day22 { get; set; }

    public int? Day23 { get; set; }

    public int? Day24 { get; set; }

    public int? Day25 { get; set; }

    public int? Day26 { get; set; }

    public int? Day27 { get; set; }

    public int? Day28 { get; set; }

    public int? Day29 { get; set; }

    public int? Day30 { get; set; }

    public int? Day31 { get; set; }

    public int ExpectedScaleTotal { get; set; }

    public int DaySubTotal { get; set; }

    public double? ActualAttendencePercent { get; set; }

    [StringLength(24)]
    public string? Remark { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    public int UserAddNewSID { get; set; }
}
