using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VCHANGE_CARD
{
    public int ChangeID { get; set; }

    public int SlaveSID { get; set; }

    [StringLength(14)]
    public string? OldCardID { get; set; }

    [StringLength(14)]
    public string? NewCardID { get; set; }
}
