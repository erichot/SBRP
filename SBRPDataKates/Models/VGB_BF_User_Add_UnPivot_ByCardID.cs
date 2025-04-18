using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VGB_BF_User_Add_UnPivot_ByCardID
{
    [StringLength(14)]
    public string? CardID { get; set; }

    public int? SlaveCounts { get; set; }
}
