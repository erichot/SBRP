using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VBF_User
{
    public int UserSID { get; set; }

    [StringLength(16)]
    public string UserID { get; set; } = null!;

    [StringLength(83)]
    public string? ListField { get; set; }

    [StringLength(10)]
    public string DepartmentID { get; set; } = null!;

    [StringLength(36)]
    public string? DepartmentName { get; set; }

    [StringLength(64)]
    public string? UserName { get; set; }

    [StringLength(14)]
    public string CardID { get; set; } = null!;

    public byte AllowTimeStartHour { get; set; }

    public byte AllowTimeStartMinute { get; set; }

    public byte AllowTimeEndHour { get; set; }

    public byte AllowTimeEndMinute { get; set; }

    public int FingerPrint1 { get; set; }

    public int FingerPrint2 { get; set; }

    public byte Group1 { get; set; }

    public byte Group2 { get; set; }

    [StringLength(6)]
    public string UserPin { get; set; } = null!;

    [StringLength(6)]
    public string ValidDate { get; set; } = null!;

    public bool IsNative { get; set; }

    public bool IsReplicated { get; set; }

    public bool InActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    [StringLength(50)]
    public string UserPWD { get; set; } = null!;

    public bool IsLogon { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeLastLogout { get; set; }

    public short? GroupSID { get; set; }

    public byte UserPermissionTypeID { get; set; }

    public int? UserAddNewSID { get; set; }

    [StringLength(32)]
    public string? Email { get; set; }

    [StringLength(16)]
    public string? PhoneMobile { get; set; }

    public bool IsTaOrNot { get; set; }

    [StringLength(16)]
    public string? EmployeeTypeID { get; set; }

    [StringLength(36)]
    public string? EmployeeTypeName { get; set; }

    [StringLength(32)]
    public string? TitleName { get; set; }

    public bool NotPropagateToSlaveByDefault { get; set; }

    [StringLength(48)]
    [Unicode(false)]
    public string HeadShotFileName { get; set; } = null!;
}
