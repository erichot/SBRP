using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VBF_UserGroupSetting
{
    public int UserSID { get; set; }

    [StringLength(16)]
    public string UserID { get; set; } = null!;

    [StringLength(10)]
    public string DepartmentID { get; set; } = null!;

    [StringLength(36)]
    public string? DepartmentName { get; set; }

    [StringLength(64)]
    public string? UserName { get; set; }

    [StringLength(14)]
    public string CardID { get; set; } = null!;

    public byte? GroupID { get; set; }

    public int? UserAddNewID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeAddNew { get; set; }

    public int? UserModifyLastID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeModifyLast { get; set; }

    public bool? IsPropagated { get; set; }
}
