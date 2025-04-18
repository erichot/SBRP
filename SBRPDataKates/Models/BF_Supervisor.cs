using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("BF_Supervisor")]
public partial class BF_Supervisor
{
    [Key]
    public int UserSID { get; set; }

    [StringLength(12)]
    public string UserID { get; set; } = null!;

    [StringLength(64)]
    public string? UserName { get; set; }

    [StringLength(128)]
    public string? UserPWD { get; set; }

    [StringLength(50)]
    public string? DepartmentID { get; set; }

    public short GroupSID { get; set; }

    public byte UserPermissionTypeID { get; set; }

    [StringLength(46)]
    public string? Email { get; set; }

    [StringLength(16)]
    public string? PhoneMobile { get; set; }

    [StringLength(64)]
    public string? Note { get; set; }

    public bool InActive { get; set; }

    public bool IsLogon { get; set; }

    public bool IsReadOnly { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeLastLogout { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    public int UserAddNewSID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeModifyLast { get; set; }

    public int? UserModifyLastSID { get; set; }
}
