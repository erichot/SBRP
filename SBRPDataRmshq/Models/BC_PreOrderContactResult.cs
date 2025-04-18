using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("BC_PreOrderContactResult")]
public partial class BC_PreOrderContactResult
{
    [Key]
    public byte PreOrderContactResultNo { get; set; }

    [StringLength(10)]
    public string? PreOrderContactResultName { get; set; }
}
