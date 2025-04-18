using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[PrimaryKey("AppSID", "UserSID", "YearValue", "MonthValue", "DayValue", "ShiftCode", "WorkShiftNo")]
[Table("TMP_UserDailyAttendanceScale")]
public partial class TMP_UserDailyAttendanceScale
{
    [Key]
    public int AppSID { get; set; }

    [Key]
    public int UserSID { get; set; }

    [Key]
    public short YearValue { get; set; }

    [Key]
    public byte MonthValue { get; set; }

    [Key]
    public byte DayValue { get; set; }

    [Key]
    [StringLength(6)]
    public string ShiftCode { get; set; } = null!;

    [Key]
    public int WorkShiftNo { get; set; }

    public byte WeekdayNo { get; set; }

    [StringLength(10)]
    public string DepartmentID { get; set; } = null!;

    public int TranInSID { get; set; }

    public int TranLateInSID { get; set; }

    public int TranOutSID { get; set; }

    public int ExpectedScale { get; set; }

    public int AttendanceScale { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    public int UserAddNewSID { get; set; }
}
