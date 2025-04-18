using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("BF_Department")]
public partial class BF_Department
{
    [Key]
    [StringLength(10)]
    public string DepartmentID { get; set; } = null!;

    [StringLength(36)]
    public string? DepartmentName { get; set; }

    public int SupervisorSID { get; set; }

    public int DepartmentSID { get; set; }

    public bool InActive { get; set; }

    [StringLength(10)]
    public string? DivisionID { get; set; }

    [InverseProperty("Department")]
    public virtual ICollection<BF_User> BF_Users { get; set; } = new List<BF_User>();
}
