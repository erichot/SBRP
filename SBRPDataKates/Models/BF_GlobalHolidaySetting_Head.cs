using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("BF_GlobalHolidaySetting_Head")]
public partial class BF_GlobalHolidaySetting_Head
{
    [Key]
    public int GlobalHolidaySID { get; set; }

    public DateOnly DateStart { get; set; }

    public DateOnly DateEnd { get; set; }

    public int GlobalHolidayType { get; set; }

    public bool IsUnPaidHoliday { get; set; }

    [StringLength(50)]
    public string? Description { get; set; }

    public bool InActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    public int UserAddNewSID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeModifyLast { get; set; }

    public int? UserModifyLastSID { get; set; }

    [InverseProperty("GlobalHolidayS")]
    public virtual ICollection<BF_GlobalHolidaySetting_Detail> BF_GlobalHolidaySetting_Details { get; set; } = new List<BF_GlobalHolidaySetting_Detail>();
}
