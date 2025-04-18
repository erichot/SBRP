using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("BF_User")]
[Index("InActive", Name = "IX_BF_User_InActive")]
[Index("IsDenyLogin", Name = "IX_BF_User_IsDenyLogin")]
[Index("UserSID", Name = "IX_BF_User_UserSID", IsUnique = true)]
public partial class BF_User
{
    [StringLength(32)]
    [Unicode(false)]
    public string UserSID { get; set; } = null!;

    [Key]
    [StringLength(32)]
    [Unicode(false)]
    public string UserID { get; set; } = null!;

    [StringLength(16)]
    public string UserName { get; set; } = null!;

    [StringLength(128)]
    [Unicode(false)]
    public string UserPassword { get; set; } = null!;

    public byte UserPermissionTypeID { get; set; }

    [StringLength(64)]
    public string? Email { get; set; }

    [StringLength(16)]
    public string? MobilePhone { get; set; }

    [StringLength(32)]
    public string? StoreID_Default { get; set; }

    public bool IsDenyLogin { get; set; }

    public bool IsReadOnly { get; set; }

    public bool InActive { get; set; }

    [StringLength(50)]
    public string? Note { get; set; }

    public bool? IsCurrentLogon { get; set; }

    public DateTime? TimeLastLogin { get; set; }

    public DateTime? TimeLastLogout { get; set; }

    public DateTime TimeAddNew { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string UserAddNewID { get; set; } = null!;

    public DateTime? TimeModified { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? UserModifiedID { get; set; }
}
