using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VOR_CounterProductOrderDetail
{
    public int OrderSID { get; set; }

    [StringLength(32)]
    public string ProductId { get; set; } = null!;

    [StringLength(32)]
    public string? ProductCode { get; set; }

    public int SN { get; set; }

    public int Qty { get; set; }

    [StringLength(50)]
    public string? Remark { get; set; }

    [StringLength(32)]
    public string? CustomCode { get; set; }

    [StringLength(100)]
    public string? Description { get; set; }

    [StringLength(100)]
    public string? ImageSubFolderFileName1 { get; set; }
}
