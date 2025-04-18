using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("TMP_StoreSafetyStockSettingPivot_Import")]
public partial class TMP_StoreSafetyStockSettingPivot_Import
{
    [Key]
    [StringLength(50)]
    [Unicode(false)]
    public string ProductCode { get; set; } = null!;

    [StringLength(50)]
    public string? ProductName { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? SSSNote_00 { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? SSSNote_10 { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? SSSNote_11 { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? SSSNote_12 { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? SSSNote_13 { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? SSSNote_14 { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? SSSNote_15 { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? SSSNote_16 { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? SSSNote_17 { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? SSSNote_18 { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? SSSNote_19 { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? SSSNote_20 { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? SSSNote_21 { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? SSSNote_22 { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? SSSNote_23 { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? SSSNote_24 { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? SSSNote_25 { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? SSSNote_26 { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? SSSNote_27 { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? SSSNote_90 { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? SSSNote_91 { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? SSSNote_92 { get; set; }

    [StringLength(50)]
    public string? SSSNoteP1 { get; set; }

    [StringLength(50)]
    public string? SSSNoteP2 { get; set; }

    [StringLength(50)]
    public string? SSSNoteP3 { get; set; }

    [StringLength(50)]
    public string? SSSNoteP4 { get; set; }
}
