using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("S_SystemSetting_API")]
public partial class S_SystemSetting_API
{
    [Key]
    [StringLength(1)]
    [Unicode(false)]
    public string SettingID { get; set; } = null!;

    [StringLength(80)]
    [Unicode(false)]
    public string UrlPunchIn { get; set; } = null!;
}
