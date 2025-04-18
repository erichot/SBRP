using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VUN_SupervisorUser
{
    public int UnionType { get; set; }

    public int UserSID { get; set; }

    [StringLength(12)]
    public string UserID { get; set; } = null!;

    [StringLength(64)]
    public string? UserName { get; set; }

    [StringLength(128)]
    public string? UserPWD { get; set; }

    public short? GroupSID { get; set; }

    [StringLength(50)]
    public string? DepartmentID { get; set; }

    public int IsReadOnly { get; set; }

    public bool InActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    public int? UserAddNewSID { get; set; }

    public bool IsLogon { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeLastLogout { get; set; }

    public byte UserPermissionTypeID { get; set; }
}
