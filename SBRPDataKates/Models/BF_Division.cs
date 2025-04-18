using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("BF_Division")]
public partial class BF_Division
{
    [Key]
    [StringLength(10)]
    public string DivisionID { get; set; } = null!;

    [StringLength(36)]
    public string? DivisionName { get; set; }

    public bool InActive { get; set; }

    public bool IsSystemPreserved { get; set; }
}
