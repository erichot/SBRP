using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VGB_LeaveApplication_Justification_SubPaidLeaveMinute
{
    public int UserSID { get; set; }

    public DateOnly? DateJustification { get; set; }

    public int? SubLeaveMinute { get; set; }
}
