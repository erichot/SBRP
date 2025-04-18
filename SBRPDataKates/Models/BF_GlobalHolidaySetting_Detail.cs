using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[PrimaryKey("GlobalHolidaySID", "YearValue", "MonthValue", "DayValue")]
[Table("BF_GlobalHolidaySetting_Detail")]
[Index("DateColumn", Name = "IX_BF_GlobalHolidaySetting_Detail_DateColumn", IsUnique = true)]
public partial class BF_GlobalHolidaySetting_Detail
{
    [Key]
    public int GlobalHolidaySID { get; set; }

    [Key]
    public short YearValue { get; set; }

    [Key]
    public short MonthValue { get; set; }

    [Key]
    public short DayValue { get; set; }

    public DateOnly DateColumn { get; set; }

    public bool IsUnPaidHoliday { get; set; }

    [ForeignKey("GlobalHolidaySID")]
    [InverseProperty("BF_GlobalHolidaySetting_Details")]
    public virtual BF_GlobalHolidaySetting_Head GlobalHolidayS { get; set; } = null!;
}
