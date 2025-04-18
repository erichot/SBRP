using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("UserID", "StoreID")]
[Table("BF_EmployeeStoreBelonging")]
[Index("IsFromSync", Name = "IX_BF_EmployeeStoreBelonging_IsFromSync")]
public partial class BF_EmployeeStoreBelonging
{
    [Key]
    [StringLength(32)]
    public string UserID { get; set; } = null!;

    [Key]
    [StringLength(32)]
    public string StoreID { get; set; } = null!;

    public bool IsDefault { get; set; }

    public int StoreOrderNo { get; set; }

    public bool IsFromSync { get; set; }

    public bool InActive { get; set; }

    public DateTime TimeAddNew { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? UserAddNewID { get; set; }

    public DateTime? TimeModified { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? UserModifiedID { get; set; }
}
