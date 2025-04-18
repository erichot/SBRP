using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VJN_User_UserWeeklyShift_WorkShift
{
    public int UserSID { get; set; }

    [StringLength(12)]
    public string UserID { get; set; } = null!;

    [StringLength(10)]
    public string DepartmentID { get; set; } = null!;

    [StringLength(64)]
    public string? UserName { get; set; }

    [StringLength(14)]
    public string CardID { get; set; } = null!;

    public byte WeekdayNo { get; set; }

    [StringLength(6)]
    public string ShiftCode { get; set; } = null!;

    [StringLength(20)]
    public string? ShiftName { get; set; }

    public byte StartTimeHour { get; set; }

    public byte StartTimeMinute { get; set; }

    public byte EndTimeHour { get; set; }

    public byte EndTimeMinute { get; set; }

    public byte AcrossOffsetHour { get; set; }

    public short DeductBreakMinute { get; set; }

    public byte StartTimeHour_System { get; set; }

    public byte StartTimeMinute_System { get; set; }

    public byte StartTimeSecond_System { get; set; }

    public byte EndTimeHour_System { get; set; }

    public byte EndTimeMinute_System { get; set; }

    public byte EndTimeSecond_System { get; set; }
}
