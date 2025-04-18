using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("TMP_StoreSafetyStockSettingPOPivot_Import")]
public partial class TMP_StoreSafetyStockSettingPOPivot_Import
{
    [Key]
    [StringLength(50)]
    [Unicode(false)]
    public string ProductCode { get; set; } = null!;

    [StringLength(50)]
    public string? ProductName { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? SupplierNo { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? OrderRemark { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? SupplierName { get; set; }

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
    public string? PreOrderSum { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? ArrivedQty { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? IsStockOut { get; set; }
}
