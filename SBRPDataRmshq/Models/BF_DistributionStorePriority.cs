using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("BF_DistributionStorePriority")]
public partial class BF_DistributionStorePriority
{
    [Key]
    [StringLength(32)]
    public string StoreID { get; set; } = null!;

    public byte StorePriorityNo { get; set; }

    public bool InActive { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? UserLastModifiedID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeLastModified { get; set; }
}
