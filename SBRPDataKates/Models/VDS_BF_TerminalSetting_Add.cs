using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VDS_BF_TerminalSetting_Add
{
    public int SlaveSID { get; set; }

    [StringLength(36)]
    public string IP { get; set; } = null!;

    [StringLength(6)]
    [Unicode(false)]
    public string? FPManagePWD { get; set; }

    public bool InActive { get; set; }

    public int UserAddNewSID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    public int? UserModifiedLastSID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeModifiedLast { get; set; }

    public bool IsReplicated { get; set; }
}
