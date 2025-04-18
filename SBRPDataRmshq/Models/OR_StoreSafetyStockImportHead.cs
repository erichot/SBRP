using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("OR_StoreSafetyStockImportHead")]
public partial class OR_StoreSafetyStockImportHead
{
    [Key]
    public int ImportHeaderSID { get; set; }

    [StringLength(60)]
    public string FileName { get; set; } = null!;

    public short? ItemCount { get; set; }

    [StringLength(32)]
    public string? StoreID { get; set; }

    public bool ImportCompleted { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string UserAddNewID { get; set; } = null!;

    public DateTime TimeAddNew { get; set; }

    public DateTime? TimeCompleted { get; set; }
}
