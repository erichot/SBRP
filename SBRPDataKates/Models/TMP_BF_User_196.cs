using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
[Table("TMP_BF_User_196")]
public partial class TMP_BF_User_196
{
    [StringLength(64)]
    public string? UserID { get; set; }

    [StringLength(64)]
    public string? UserName { get; set; }

    [StringLength(64)]
    public string? DepartmentID { get; set; }

    [StringLength(64)]
    public string? DepartmentName { get; set; }

    [StringLength(64)]
    public string? CardID { get; set; }

    [StringLength(64)]
    public string? ValidDate { get; set; }

    [StringLength(64)]
    public string? AllowTimeStartHour { get; set; }

    [StringLength(64)]
    public string? AllowTimeStartMinute { get; set; }

    [StringLength(64)]
    public string? AllowTimeEndHour { get; set; }

    [StringLength(64)]
    public string? AllowTimeEndMinute { get; set; }

    [StringLength(64)]
    public string? Email { get; set; }

    [StringLength(64)]
    public string? PhoneMobile { get; set; }
}
