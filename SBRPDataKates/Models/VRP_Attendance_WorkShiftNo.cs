using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VRP_Attendance_WorkShiftNo
{
    public int? UserSID { get; set; }

    [StringLength(12)]
    public string? UserID { get; set; }

    [StringLength(10)]
    public string? DepartmentID { get; set; }

    [StringLength(36)]
    public string? DepartmentName { get; set; }

    [StringLength(64)]
    public string? UserName { get; set; }

    [StringLength(14)]
    public string CardID { get; set; } = null!;

    public int WorkShiftNo { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? WorkDateString { get; set; }

    [StringLength(30)]
    public string? WEEKDAYNAME { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? WorkingTimeOn { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? WorkingTimeOnString { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? WorkingTimeOff { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? WorkingTimeOffString { get; set; }

    public int? WorkingTimeTotal { get; set; }

    public byte TranType { get; set; }

    public byte DataType { get; set; }

    public bool IsByTranType { get; set; }

    public int? WorkingTimeTotal_DeductBreakTime { get; set; }

    [StringLength(4)]
    public string? JobCode { get; set; }
}
