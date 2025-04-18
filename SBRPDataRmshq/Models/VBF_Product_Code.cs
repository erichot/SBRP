using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VBF_Product_Code
{
    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    [StringLength(32)]
    public string? ProductCode { get; set; }

    [StringLength(32)]
    public string? ProductCodeHead { get; set; }

    [StringLength(32)]
    public string? ColorID { get; set; }

    [StringLength(32)]
    public string? ColorName { get; set; }

    [StringLength(32)]
    public string? SizeID { get; set; }

    [StringLength(32)]
    public string? SizeName { get; set; }

    public int? ColorIndex { get; set; }

    public int? SizeIndex { get; set; }

    [StringLength(32)]
    public string? ProductColorID { get; set; }

    [StringLength(32)]
    public string? ProductSizeID { get; set; }

    public int? TestIndex { get; set; }
}
