using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VS_DateColumnWeekdayNo_User
{
    [StringLength(10)]
    public string DepartmentID { get; set; } = null!;

    public int UserSID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DateColumn { get; set; }

    public short YearValue { get; set; }

    public byte MonthValue { get; set; }

    public byte DayValue { get; set; }
}
