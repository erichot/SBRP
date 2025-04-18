using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
[Table("BF_ProductCode_Preserved")]
public partial class BF_ProductCode_Preserved
{
    [StringLength(50)]
    public string? CustomCode { get; set; }
}
