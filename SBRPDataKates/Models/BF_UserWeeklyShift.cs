using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[PrimaryKey("UserSID", "WeekdayNo")]
[Table("BF_UserWeeklyShift")]
public partial class BF_UserWeeklyShift
{
    [Key]
    public int UserSID { get; set; }

    [Key]
    public byte WeekdayNo { get; set; }

    [StringLength(6)]
    public string ShiftCode { get; set; } = null!;

    [StringLength(6)]
    public string? ShiftCode_2nd { get; set; }

    [ForeignKey("UserSID")]
    [InverseProperty("BF_UserWeeklyShifts")]
    public virtual BF_User UserS { get; set; } = null!;
}
