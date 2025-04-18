using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VUP_FP_Add
{
    public int FpId { get; set; }

    [StringLength(10)]
    public string CardID { get; set; } = null!;

    public short IsSync { get; set; }

    [StringLength(128)]
    public string? S_IPHost { get; set; }
}
