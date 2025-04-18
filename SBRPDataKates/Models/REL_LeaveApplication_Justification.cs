using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[PrimaryKey("UserSID", "DateJustification")]
[Table("REL_LeaveApplication_Justification")]
public partial class REL_LeaveApplication_Justification
{
    [StringLength(10)]
    public string DepartmentID { get; set; } = null!;

    [Key]
    public int UserSID { get; set; }

    [Key]
    public DateOnly DateJustification { get; set; }

    [StringLength(12)]
    public string? LeaveTypeID1 { get; set; }

    public short? LeaveMinute1 { get; set; }

    [StringLength(12)]
    public string? LeaveTypeID2 { get; set; }

    public short? LeaveMinute2 { get; set; }

    [StringLength(12)]
    public string? LeaveTypeID3 { get; set; }

    public short? LeaveMinute3 { get; set; }

    public short? SubTotalMinute_PaidLeave { get; set; }

    public short? SubTotalMinute_UnPaidLeave { get; set; }
}
