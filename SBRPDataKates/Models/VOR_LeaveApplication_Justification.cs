using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VOR_LeaveApplication_Justification
{
    public int LeaveApplicationHeadSID { get; set; }

    public int UserSID { get; set; }

    public DateOnly? DateJustification { get; set; }

    [StringLength(50)]
    public string Reason { get; set; } = null!;

    public bool IsApproved { get; set; }

    public bool IsRejected { get; set; }

    public bool IsNullified { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    public int UserAddNewSID { get; set; }

    public int LeaveApplicationDetailSID { get; set; }

    [StringLength(12)]
    public string LeaveTypeID { get; set; } = null!;

    [StringLength(24)]
    public string LeaveTypeName { get; set; } = null!;

    public bool IsUnPaidLeave { get; set; }

    public short LeaveMinute { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeModifyLast { get; set; }

    public int? UserModifyLastSID { get; set; }
}
