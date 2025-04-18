using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("ProductID", "StoreID")]
[Table("BF_DistributionProductStorePriority")]
public partial class BF_DistributionProductStorePriority
{
    [Key]
    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    [Key]
    [StringLength(32)]
    public string StoreID { get; set; } = null!;

    public byte StorePriorityNo { get; set; }
}
