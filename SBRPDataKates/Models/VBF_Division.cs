using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VBF_Division
{
    [StringLength(10)]
    public string DivisionID { get; set; } = null!;

    [StringLength(36)]
    public string? DivisionName { get; set; }

    [StringLength(49)]
    public string? ListField { get; set; }
}
