using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[PrimaryKey("AppSID", "UserSID", "YearValue")]
[Table("TMP_YearlyColumnDataSheet")]
public partial class TMP_YearlyColumnDataSheet
{
    [Key]
    public int AppSID { get; set; }

    [Key]
    public int UserSID { get; set; }

    [Key]
    public short YearValue { get; set; }

    [StringLength(10)]
    public string DepartmentID { get; set; } = null!;

    public int? Month01 { get; set; }

    public int? Month02 { get; set; }

    public int? Month03 { get; set; }

    public int? Month04 { get; set; }

    public int? Month05 { get; set; }

    public int? Month06 { get; set; }

    public int? Month07 { get; set; }

    public int? Month08 { get; set; }

    public int? Month09 { get; set; }

    public int? Month10 { get; set; }

    public int? Month11 { get; set; }

    public int? Month12 { get; set; }

    public int MonthSubTotal { get; set; }

    [StringLength(24)]
    public string? Remark { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    public int UserAddNewSID { get; set; }

    public int ExpectedScaleTotal { get; set; }

    public double? ActualAttendencePercent { get; set; }
}
