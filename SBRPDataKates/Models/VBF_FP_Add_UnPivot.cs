using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VBF_FP_Add_UnPivot
{
    [StringLength(14)]
    public string CardID { get; set; } = null!;

    public short? SlaveID { get; set; }

    public int FPId { get; set; }

    public short SlaveValue { get; set; }
}
