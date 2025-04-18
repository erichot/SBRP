using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VBF_StorePrioritySetting
{
    [StringLength(32)]
    [Unicode(false)]
    public string PrioritySettingID { get; set; } = null!;

    [StringLength(1)]
    [Unicode(false)]
    public string SettingTypeID { get; set; } = null!;

    [StringLength(32)]
    public string StoreID { get; set; } = null!;

    public int OrderNo { get; set; }

    [StringLength(32)]
    public string StoreName { get; set; } = null!;

    [StringLength(6)]
    public string StoreAbbreviation { get; set; } = null!;
}
