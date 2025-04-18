using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VBF_GlobalHolidaySetting_Detail
{
    public int GlobalHolidaySID { get; set; }

    public short YearValue { get; set; }

    public short MonthValue { get; set; }

    public short DayValue { get; set; }

    public DateOnly DateColumn { get; set; }

    public int? WeekdayNo { get; set; }

    public bool IsUnPaidHoliday { get; set; }
}
