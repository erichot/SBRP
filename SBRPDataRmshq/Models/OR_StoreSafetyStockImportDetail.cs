using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("ImportHeaderSID", "ItemNo")]
[Table("OR_StoreSafetyStockImportDetail")]
public partial class OR_StoreSafetyStockImportDetail
{
    [Key]
    public int ImportHeaderSID { get; set; }

    [Key]
    public short ItemNo { get; set; }

    [StringLength(32)]
    public string? ProductCode { get; set; }

    [StringLength(32)]
    public string? StoreID { get; set; }

    public int? Qty { get; set; }
}
