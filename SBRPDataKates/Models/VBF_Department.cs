using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VBF_Department
{
    [StringLength(10)]
    public string DepartmentID { get; set; } = null!;

    [StringLength(36)]
    public string? DepartmentName { get; set; }

    [StringLength(49)]
    public string? ListField { get; set; }

    [StringLength(10)]
    public string? DivisionID { get; set; }

    [StringLength(36)]
    public string? DivisionName { get; set; }
}
