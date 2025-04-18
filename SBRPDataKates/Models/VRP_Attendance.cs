using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VRP_Attendance
{
    [StringLength(10)]
    public string DepartmentID { get; set; } = null!;

    [StringLength(36)]
    public string? DepartmentName { get; set; }

    public int UserSID { get; set; }

    [StringLength(12)]
    public string UserID { get; set; } = null!;

    [StringLength(64)]
    public string? UserName { get; set; }

    [StringLength(4)]
    public string? JobCode { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? Date { get; set; }

    [StringLength(30)]
    public string? WEEKDAYNAME { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? WorkingTimeOn { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? WorkingTimeOnDate { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? WorkingTimeOff { get; set; }

    public int? WorkingTimeTotal { get; set; }

    public int? WorkingTimeNormal { get; set; }

    public int? WorkingTimeLate { get; set; }

    public int? WorkingTimeLeaveEarly { get; set; }

    public int? WorkingTimeOver { get; set; }
}
