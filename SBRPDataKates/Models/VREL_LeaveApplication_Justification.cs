using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VREL_LeaveApplication_Justification
{
    [StringLength(10)]
    public string DepartmentID { get; set; } = null!;

    public int UserSID { get; set; }

    public DateOnly DateJustification { get; set; }

    [StringLength(12)]
    public string? LeaveTypeID1 { get; set; }

    [StringLength(24)]
    public string? LeaveTypeName1 { get; set; }

    public short? LeaveMinute1 { get; set; }

    [StringLength(12)]
    public string? LeaveTypeID2 { get; set; }

    [StringLength(24)]
    public string? LeaveTypeName2 { get; set; }

    public short? LeaveMinute2 { get; set; }

    [StringLength(12)]
    public string? LeaveTypeID3 { get; set; }

    [StringLength(24)]
    public string? LeaveTypeName3 { get; set; }

    public short? LeaveMinute3 { get; set; }

    public short? SubTotalMinute_PaidLeave { get; set; }

    public short? SubTotalMinute_UnPaidLeave { get; set; }
}
