using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VJN_WorkCalendar_Advance_DateColumnWeekdayNo
{
    [StringLength(10)]
    public string DepartmentID { get; set; } = null!;

    public int UserSID { get; set; }

    public short Year { get; set; }

    public byte Month { get; set; }

    public byte Day { get; set; }

    public int WorkShiftNo { get; set; }

    [StringLength(6)]
    public string ShiftCode { get; set; } = null!;

    public int ComputedAttendanceScale { get; set; }
}
