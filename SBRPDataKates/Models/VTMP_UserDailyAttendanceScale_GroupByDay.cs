using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VTMP_UserDailyAttendanceScale_GroupByDay
{
    public int AppSID { get; set; }

    [StringLength(10)]
    public string DepartmentID { get; set; } = null!;

    public int UserSID { get; set; }

    public short YearValue { get; set; }

    public byte MonthValue { get; set; }

    public byte DayValue { get; set; }

    public int? ComputedAttendanceScale { get; set; }

    public int? ExpectedScale { get; set; }
}
