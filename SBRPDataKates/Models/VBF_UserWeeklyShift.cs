using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VBF_UserWeeklyShift
{
    public int UserSID { get; set; }

    public byte WeekdayNo { get; set; }

    [StringLength(30)]
    public string? WeekdayName { get; set; }

    [StringLength(6)]
    public string ShiftCode { get; set; } = null!;

    [StringLength(20)]
    public string? ShiftName { get; set; }

    [StringLength(199)]
    [Unicode(false)]
    public string? StartTimeString { get; set; }

    [StringLength(199)]
    [Unicode(false)]
    public string? EndTimeString { get; set; }
}
