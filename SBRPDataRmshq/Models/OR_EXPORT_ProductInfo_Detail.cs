using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("ExportGID", "ProductID")]
[Table("OR_EXPORT_ProductInfo_Detail")]
[Index("SerialNo", Name = "IX_OR_EXPORT_ProductInfo_Detail_SerialNo")]
public partial class OR_EXPORT_ProductInfo_Detail
{
    [Key]
    public Guid ExportGID { get; set; }

    [Key]
    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    public int SerialNo { get; set; }

    public int SubStockQty { get; set; }
}
