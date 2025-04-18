using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("DS_BF_TerminalSetting_Add")]
public partial class DS_BF_TerminalSetting_Add
{
    [Key]
    public int SlaveSID { get; set; }

    public bool InActive { get; set; }

    public int UserAddNewSID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    public int? UserModifiedLastSID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeModifiedLast { get; set; }

    public bool IsReplicated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeReplicated { get; set; }
}
