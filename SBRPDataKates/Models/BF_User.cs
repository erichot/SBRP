using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("BF_User")]
[Index("CardID", Name = "IX_BF_User_CardID", IsUnique = true)]
[Index("DepartmentID", Name = "IX_BF_User_DepartmentID")]
[Index("EmployeeTypeID", Name = "IX_BF_User_EmployeeTypeID")]
[Index("UserID", Name = "IX_BF_User_UserID", IsUnique = true)]
public partial class BF_User
{
    [Key]
    public int UserSID { get; set; }

    [StringLength(16)]
    public string UserID { get; set; } = null!;

    [StringLength(10)]
    public string DepartmentID { get; set; } = null!;

    [StringLength(64)]
    public string? UserName { get; set; }

    [StringLength(32)]
    public string? TitleName { get; set; }

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

    public bool InActive { get; set; }

    public bool IsReplicated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    public int? UserAddNewSID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeModifyLast { get; set; }

    public int? TimeModifyLastSID { get; set; }

    [StringLength(50)]
    public string UserPWD { get; set; } = null!;

    public bool IsLogon { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeLastLogout { get; set; }

    public short? GroupSID { get; set; }

    public byte UserPermissionTypeID { get; set; }

    [StringLength(32)]
    public string? Email { get; set; }

    [StringLength(16)]
    public string? PhoneMobile { get; set; }

    public bool IsTaOrNot { get; set; }

    [StringLength(16)]
    public string? EmployeeTypeID { get; set; }

    public bool NotPropagateToSlaveByDefault { get; set; }

    [StringLength(48)]
    [Unicode(false)]
    public string HeadShotFileName { get; set; } = null!;

    [InverseProperty("UserS")]
    public virtual ICollection<BFX_UserSlaveAddSync> BFX_UserSlaveAddSyncs { get; set; } = new List<BFX_UserSlaveAddSync>();

    [InverseProperty("UserS")]
    public virtual ICollection<BF_UserHourlyPay> BF_UserHourlyPays { get; set; } = new List<BF_UserHourlyPay>();

    [InverseProperty("UserS")]
    public virtual ICollection<BF_UserWeeklyShift> BF_UserWeeklyShifts { get; set; } = new List<BF_UserWeeklyShift>();

    [ForeignKey("DepartmentID")]
    [InverseProperty("BF_Users")]
    public virtual BF_Department Department { get; set; } = null!;
}
