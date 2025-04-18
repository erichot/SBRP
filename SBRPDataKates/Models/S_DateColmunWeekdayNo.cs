using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("S_DateColmunWeekdayNo")]
[Index("DayValue", Name = "IX_S_DateColmunWeekdayNo_DayValue")]
[Index("MonthValue", Name = "IX_S_DateColmunWeekdayNo_MonthValue")]
[Index("WeekdayNo", Name = "IX_S_DateColmunWeekdayNo_WeekdayNo")]
[Index("YearValue", Name = "IX_S_DateColmunWeekdayNo_YearValue")]
public partial class S_DateColmunWeekdayNo
{
    [Key]
    [Column(TypeName = "datetime")]
    public DateTime DateColumn { get; set; }

    public short YearValue { get; set; }

    public byte MonthValue { get; set; }

    public byte DayValue { get; set; }

    public int WeekdayNo { get; set; }

    public short YearValueLastDay { get; set; }

    public byte MonthValueLastDay { get; set; }

    public byte DayValueLastDay { get; set; }
}
