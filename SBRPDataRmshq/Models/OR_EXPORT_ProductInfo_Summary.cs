using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("OR_EXPORT_ProductInfo_Summary")]
public partial class OR_EXPORT_ProductInfo_Summary
{
    [Key]
    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    public Guid ExportGID { get; set; }

    public int SerialNo { get; set; }

    public int SubStockQty { get; set; }

    public DateTime TimeAddNew { get; set; }

    public DateTime? TimeLastModified { get; set; }

    public bool IsExported { get; set; }

    public DateTime? TimeCompleteExported { get; set; }

    public bool IsForceToExportOnNext { get; set; }
}
