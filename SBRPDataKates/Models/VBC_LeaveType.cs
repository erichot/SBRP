using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VBC_LeaveType
{
    [StringLength(12)]
    public string LeaveTypeID { get; set; } = null!;

    [StringLength(24)]
    public string LeaveTypeName { get; set; } = null!;

    [StringLength(37)]
    public string ListField { get; set; } = null!;

    public bool IsUnPaidLeave { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    public int UserAddNewSID { get; set; }
}
