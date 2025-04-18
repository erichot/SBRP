using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
[Table("TMP_WorkCalendar_PIVOT")]
public partial class TMP_WorkCalendar_PIVOT
{
    [StringLength(24)]
    public string? UserID { get; set; }

    [Column("2016/07/01")]
    [StringLength(12)]
    public string? _2016_07_01 { get; set; }

    [Column("2016/07/02")]
    [StringLength(12)]
    public string? _2016_07_02 { get; set; }

    [Column("2016/07/03")]
    [StringLength(12)]
    public string? _2016_07_03 { get; set; }

    [Column("2016/07/04")]
    [StringLength(12)]
    public string? _2016_07_04 { get; set; }

    [Column("2016/07/05")]
    [StringLength(12)]
    public string? _2016_07_05 { get; set; }

    [Column("2016/07/06")]
    [StringLength(12)]
    public string? _2016_07_06 { get; set; }

    [Column("2016/07/07")]
    [StringLength(12)]
    public string? _2016_07_07 { get; set; }

    [Column("2016/07/08")]
    [StringLength(12)]
    public string? _2016_07_08 { get; set; }

    [Column("2016/07/09")]
    [StringLength(12)]
    public string? _2016_07_09 { get; set; }

    [Column("2016/07/10")]
    [StringLength(12)]
    public string? _2016_07_10 { get; set; }

    [Column("2016/07/11")]
    [StringLength(12)]
    public string? _2016_07_11 { get; set; }

    [Column("2016/07/12")]
    [StringLength(12)]
    public string? _2016_07_12 { get; set; }

    [Column("2016/07/13")]
    [StringLength(12)]
    public string? _2016_07_13 { get; set; }

    [Column("2016/07/14")]
    [StringLength(12)]
    public string? _2016_07_14 { get; set; }

    [Column("2016/07/15")]
    [StringLength(12)]
    public string? _2016_07_15 { get; set; }

    [Column("2016/07/16")]
    [StringLength(12)]
    public string? _2016_07_16 { get; set; }

    [Column("2016/07/17")]
    [StringLength(12)]
    public string? _2016_07_17 { get; set; }

    [Column("2016/07/18")]
    [StringLength(12)]
    public string? _2016_07_18 { get; set; }

    [Column("2016/07/19")]
    [StringLength(12)]
    public string? _2016_07_19 { get; set; }

    [Column("2016/07/20")]
    [StringLength(12)]
    public string? _2016_07_20 { get; set; }

    [Column("2016/07/21")]
    [StringLength(12)]
    public string? _2016_07_21 { get; set; }

    [Column("2016/07/22")]
    [StringLength(12)]
    public string? _2016_07_22 { get; set; }

    [Column("2016/07/23")]
    [StringLength(12)]
    public string? _2016_07_23 { get; set; }

    [Column("2016/07/24")]
    [StringLength(12)]
    public string? _2016_07_24 { get; set; }

    [Column("2016/07/25")]
    [StringLength(12)]
    public string? _2016_07_25 { get; set; }

    [Column("2016/07/26")]
    [StringLength(12)]
    public string? _2016_07_26 { get; set; }

    [Column("2016/07/27")]
    [StringLength(12)]
    public string? _2016_07_27 { get; set; }

    [Column("2016/07/28")]
    [StringLength(12)]
    public string? _2016_07_28 { get; set; }

    [Column("2016/07/29")]
    [StringLength(12)]
    public string? _2016_07_29 { get; set; }

    [Column("2016/07/30")]
    [StringLength(12)]
    public string? _2016_07_30 { get; set; }

    [Column("2016/07/31")]
    [StringLength(12)]
    public string? _2016_07_31 { get; set; }
}
