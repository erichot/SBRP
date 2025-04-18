using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VBC_SlaveCategory
{
    public short SlaveCategoryID { get; set; }

    [StringLength(16)]
    public string SlaveCategoryName { get; set; } = null!;

    [StringLength(24)]
    public string? ListField { get; set; }
}
