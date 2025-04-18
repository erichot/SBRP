using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VBF_Contact
{
    public int ContactSID { get; set; }

    [StringLength(10)]
    public string? DepartmentID { get; set; }

    [StringLength(16)]
    public string? EmployeeTypeID { get; set; }

    public int RelatedUserSID { get; set; }

    [StringLength(12)]
    public string? RelatedUserID { get; set; }

    [StringLength(64)]
    public string? RelatedUserName { get; set; }

    public short ContactType { get; set; }

    [StringLength(64)]
    public string ContactName { get; set; } = null!;

    [StringLength(32)]
    public string Email { get; set; } = null!;
}
