using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("BF_TerminalSetting")]
public partial class BF_TerminalSetting
{
    [Key]
    public byte SettingID { get; set; }

    [StringLength(6)]
    [Unicode(false)]
    public string? FPManagePWD { get; set; }

    public int UserAddNewSID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    public int? UserModifiedLastSID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeModifiedLast { get; set; }
}
