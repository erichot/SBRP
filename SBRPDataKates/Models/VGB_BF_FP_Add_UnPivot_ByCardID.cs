using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VGB_BF_FP_Add_UnPivot_ByCardID
{
    [StringLength(14)]
    public string CardID { get; set; } = null!;

    public int? SlaveCounts { get; set; }
}
