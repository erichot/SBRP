using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VBF_DistributionStorePriority
{
    [StringLength(32)]
    public string StoreID { get; set; } = null!;

    [StringLength(32)]
    public string? StoreName { get; set; }

    [StringLength(6)]
    public string? StoreAbbreviation { get; set; }

    public byte StorePriorityNo { get; set; }

    public bool InActive { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? UserLastModifiedID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeLastModified { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? TimeLastModifiedText { get; set; }
}
