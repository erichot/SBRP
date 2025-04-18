using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VJN_LeaveApplication_Justification
{
    [StringLength(10)]
    public string DepartmentID { get; set; } = null!;

    public int UserSID { get; set; }

    public DateOnly? DateJustification { get; set; }

    public byte? JustificationNo { get; set; }

    [StringLength(24)]
    public string LeaveTypeName { get; set; } = null!;

    [StringLength(12)]
    public string LeaveTypeID { get; set; } = null!;

    public bool IsUnPaidLeave { get; set; }

    public short LeaveMinute { get; set; }
}
