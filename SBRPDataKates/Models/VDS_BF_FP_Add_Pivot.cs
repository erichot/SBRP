using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VDS_BF_FP_Add_Pivot
{
    public int SlaveSID { get; set; }

    [StringLength(14)]
    public string CardID { get; set; } = null!;

    public int? FP1 { get; set; }

    public int? FP2 { get; set; }

    public int IsReplicatedFP { get; set; }
}
