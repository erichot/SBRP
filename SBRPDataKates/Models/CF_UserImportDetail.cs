using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[PrimaryKey("ImportOperationNo", "ItemNo")]
[Table("CF_UserImportDetail")]
public partial class CF_UserImportDetail
{
    [Key]
    public int ImportOperationNo { get; set; }

    [Key]
    public short ItemNo { get; set; }

    public int? UserSID { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UserID { get; set; }

    [StringLength(50)]
    public string? UserName { get; set; }

    [StringLength(50)]
    public string? EmployeeType { get; set; }

    [StringLength(50)]
    public string? CompanyName { get; set; }

    [StringLength(10)]
    public string? DepartmentID { get; set; }

    [StringLength(50)]
    public string? DepartmentName { get; set; }

    [StringLength(50)]
    public string? Sex { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CardID { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Email { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Phone { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ValidDate { get; set; }

    public bool InValid { get; set; }

    public bool IsDuplicated { get; set; }

    public bool IsImported { get; set; }

    public bool IsForOverwrite { get; set; }

    public bool HasError { get; set; }

    [StringLength(50)]
    public string? Remark { get; set; }

    [ForeignKey("ImportOperationNo")]
    [InverseProperty("CF_UserImportDetails")]
    public virtual CF_UserImportHead ImportOperationNoNavigation { get; set; } = null!;
}
