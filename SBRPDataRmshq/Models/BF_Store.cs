using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("BF_Store")]
public partial class BF_Store
{
    [Key]
    [StringLength(32)]
    public string StoreID { get; set; } = null!;

    [StringLength(32)]
    public string StoreName { get; set; } = null!;

    [StringLength(6)]
    public string StoreAbbreviation { get; set; } = null!;

    public bool IsVirtualForTransit { get; set; }

    [StringLength(32)]
    public string? TransitFromStoreID { get; set; }

    public bool IsFavorite { get; set; }

    public bool InActive { get; set; }

    public DateTime TimeAddNew { get; set; }

    public DateTime? TimeModified { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? UserModifiedID { get; set; }

    public short? OrderNo { get; set; }
}
