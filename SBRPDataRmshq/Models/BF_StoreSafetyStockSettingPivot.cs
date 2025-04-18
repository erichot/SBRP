using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("BF_StoreSafetyStockSettingPivot")]
public partial class BF_StoreSafetyStockSettingPivot
{
    [Key]
    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    public int? SafetyStockQty_00 { get; set; }

    [StringLength(16)]
    public string? Note_00 { get; set; }

    public int? SafetyStockQty_10 { get; set; }

    [StringLength(16)]
    public string? Note_10 { get; set; }

    public int? SafetyStockQty_11 { get; set; }

    [StringLength(16)]
    public string? Note_11 { get; set; }

    public int? SafetyStockQty_12 { get; set; }

    [StringLength(16)]
    public string? Note_12 { get; set; }

    public int? SafetyStockQty_13 { get; set; }

    [StringLength(16)]
    public string? Note_13 { get; set; }

    public int? SafetyStockQty_14 { get; set; }

    [StringLength(16)]
    public string? Note_14 { get; set; }

    public int? SafetyStockQty_15 { get; set; }

    [StringLength(16)]
    public string? Note_15 { get; set; }

    public int? SafetyStockQty_16 { get; set; }

    [StringLength(16)]
    public string? Note_16 { get; set; }

    public int? SafetyStockQty_17 { get; set; }

    [StringLength(16)]
    public string? Note_17 { get; set; }

    public int? SafetyStockQty_18 { get; set; }

    [StringLength(16)]
    public string? Note_18 { get; set; }

    public int? SafetyStockQty_19 { get; set; }

    [StringLength(16)]
    public string? Note_19 { get; set; }

    public int? SafetyStockQty_20 { get; set; }

    [StringLength(16)]
    public string? Note_20 { get; set; }

    public int? SafetyStockQty_21 { get; set; }

    [StringLength(16)]
    public string? Note_21 { get; set; }

    public int? SafetyStockQty_22 { get; set; }

    [StringLength(16)]
    public string? Note_22 { get; set; }

    public int? SafetyStockQty_23 { get; set; }

    [StringLength(16)]
    public string? Note_23 { get; set; }

    public int? SafetyStockQty_24 { get; set; }

    [StringLength(16)]
    public string? Note_24 { get; set; }

    public int? SafetyStockQty_25 { get; set; }

    [StringLength(16)]
    public string? Note_25 { get; set; }

    public int? SafetyStockQty_26 { get; set; }

    [StringLength(16)]
    public string? Note_26 { get; set; }

    public int? SafetyStockQty_27 { get; set; }

    [StringLength(16)]
    public string? Note_27 { get; set; }

    public int? SafetyStockQty_90 { get; set; }

    [StringLength(16)]
    public string? Note_90 { get; set; }

    public int? SafetyStockQty_91 { get; set; }

    [StringLength(16)]
    public string? Note_91 { get; set; }

    public int? SafetyStockQty_92 { get; set; }

    [StringLength(16)]
    public string? Note_92 { get; set; }

    public bool IsUploadFlag { get; set; }

    public DateTime? TimeAddNew { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? UserAddNewID { get; set; }

    public int? PreOrderSum { get; set; }

    public int? ArrivedQty { get; set; }

    public bool? IsStockOut { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? SupplierNo { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? OrderRemark { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? SupplierName { get; set; }
}
