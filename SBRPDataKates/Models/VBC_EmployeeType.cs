using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VBC_EmployeeType
{
    [StringLength(55)]
    public string ListField { get; set; } = null!;

    [StringLength(16)]
    public string EmployeeTypeID { get; set; } = null!;

    [StringLength(36)]
    public string EmployeeTypeName { get; set; } = null!;

    public bool InActive { get; set; }
}
