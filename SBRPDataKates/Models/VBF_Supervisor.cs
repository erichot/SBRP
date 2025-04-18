using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VBF_Supervisor
{
    public int UserSID { get; set; }

    [StringLength(12)]
    public string UserID { get; set; } = null!;

    [StringLength(64)]
    public string? UserName { get; set; }

    [StringLength(79)]
    public string? ListField { get; set; }

    [StringLength(128)]
    public string? UserPWD { get; set; }

    [StringLength(50)]
    public string? DepartmentID { get; set; }

    [StringLength(36)]
    public string? DepartmentName { get; set; }

    public short GroupSID { get; set; }

    public byte UserPermissionTypeID { get; set; }

    [StringLength(16)]
    public string? UserPermissionTypeName { get; set; }

    [StringLength(16)]
    public string? UserPermissionTypeName_CN { get; set; }

    [StringLength(16)]
    public string? UserPermissionTypeName_TW { get; set; }

    [StringLength(46)]
    public string? Email { get; set; }

    [StringLength(16)]
    public string? PhoneMobile { get; set; }

    [StringLength(64)]
    public string? Note { get; set; }

    public bool IsReadOnly { get; set; }

    public bool InActive { get; set; }

    public bool IsLogon { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeLastLogout { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    public int UserAddNewSID { get; set; }

    [StringLength(64)]
    public string? UserAddNewName { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeModifyLast { get; set; }

    public int? UserModifyLastSID { get; set; }

    [StringLength(64)]
    public string? UserModifyLastName { get; set; }
}
