using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
[Table("TMP_WorkCalendar_UNPIVOT")]
public partial class TMP_WorkCalendar_UNPIVOT
{
    [StringLength(12)]
    public string? UserID { get; set; }

    [StringLength(10)]
    public string? WorkDate { get; set; }

    [StringLength(6)]
    public string? ShiftCode { get; set; }
}
