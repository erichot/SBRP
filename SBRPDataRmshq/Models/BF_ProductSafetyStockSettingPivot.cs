using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("BF_ProductSafetyStockSettingPivot")]
public partial class BF_ProductSafetyStockSettingPivot
{
    [Key]
    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    [StringLength(50)]
    public string? SSSNoteP1 { get; set; }

    [StringLength(50)]
    public string? SSSNoteP2 { get; set; }

    [StringLength(50)]
    public string? SSSNoteP3 { get; set; }

    [StringLength(50)]
    public string? SSSNoteP4 { get; set; }
}
