using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VOR_LeaveApplication_Head
{
    public int LeaveApplicationHeadSID { get; set; }

    public int UserSID { get; set; }

    [StringLength(12)]
    public string UserID { get; set; } = null!;

    [StringLength(64)]
    public string? UserName { get; set; }

    [StringLength(10)]
    public string DepartmentID { get; set; } = null!;

    [StringLength(16)]
    public string? EmployeeTypeID { get; set; }

    public DateOnly? DateJustification { get; set; }

    [StringLength(50)]
    public string Reason { get; set; } = null!;

    public bool IsApproved { get; set; }

    public bool IsRejected { get; set; }

    public bool IsNullified { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    public int UserAddNewSID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeModifyLast { get; set; }

    public int? UserModifyLastSID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeApproved { get; set; }

    public int? UserApprovedSID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeRejected { get; set; }

    public int? UserRejectedSID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeNullified { get; set; }

    public int? UserNullifiedSID { get; set; }
}
