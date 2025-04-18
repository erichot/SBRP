using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VBF_GlobalHolidaySetting_Head
{
    public int GlobalHolidaySID { get; set; }

    public DateOnly DateStart { get; set; }

    public DateOnly DateEnd { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? DateStartString { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? DateEndString { get; set; }

    public int? NumberOfDays { get; set; }

    public int GlobalHolidayType { get; set; }

    [StringLength(50)]
    public string Description { get; set; } = null!;

    public bool InActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    public int UserAddNewSID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeModifyLast { get; set; }

    public int? UserModifyLastSID { get; set; }

    public bool IsUnPaidHoliday { get; set; }
}
