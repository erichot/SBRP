using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VDS_BF_User_Add
{
    public int UserAddSID { get; set; }

    public int UserSID { get; set; }

    public int SlaveSID { get; set; }

    public bool InActive { get; set; }

    public bool IsReplicated { get; set; }

    public int ReplicateReturnID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeReplicated { get; set; }

    [StringLength(16)]
    public string UserID { get; set; } = null!;

    [StringLength(10)]
    public string DepartmentID { get; set; } = null!;

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

    [StringLength(36)]
    public string IP { get; set; } = null!;

    [StringLength(30)]
    public string SlaveName { get; set; } = null!;

    [StringLength(255)]
    public string? SlaveDescription { get; set; }

    public int SlaveCategoryID { get; set; }

    [StringLength(16)]
    public string? SlaveCategoryName { get; set; }

    [StringLength(36)]
    public string? DepartmentName { get; set; }

    [StringLength(16)]
    public string? EmployeeTypeID { get; set; }
}
