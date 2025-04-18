using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VOR_EXPORT_ProductInfo_Detail
{
    public Guid ExportGID { get; set; }

    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    public int SerialNo { get; set; }

    [StringLength(14)]
    [Unicode(false)]
    public string? KeyField1 { get; set; }

    [StringLength(32)]
    public string? ProductCode { get; set; }

    [StringLength(14)]
    [Unicode(false)]
    public string? KeyField2 { get; set; }

    public int SubStockQty { get; set; }
}
