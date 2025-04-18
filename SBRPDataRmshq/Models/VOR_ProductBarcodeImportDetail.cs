using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VOR_ProductBarcodeImportDetail
{
    public int ImportHeaderSID { get; set; }

    public short ItemNo { get; set; }

    [StringLength(32)]
    public string? CustomCode { get; set; }

    [StringLength(32)]
    public string? Barcode { get; set; }

    [StringLength(100)]
    public string? Description { get; set; }

    public float? SellingPrice { get; set; }

    public float? MemberPrice { get; set; }

    public float? PriceA { get; set; }

    public float? PriceB { get; set; }

    public float? PriceC { get; set; }

    public float? PriceD { get; set; }

    public float? PriceE { get; set; }

    public float? PriceF { get; set; }

    public float? PriceG { get; set; }

    public float? PriceH { get; set; }

    public float? PriceI { get; set; }

    public float? PriceJ { get; set; }

    [StringLength(254)]
    [Unicode(false)]
    public string? BrandName { get; set; }

    [StringLength(254)]
    [Unicode(false)]
    public string? SexName { get; set; }

    [StringLength(32)]
    public string? ColorName { get; set; }

    [StringLength(32)]
    public string? SizeName { get; set; }

    [StringLength(40)]
    public string? SupplierName { get; set; }

    public int? PrepaidPoints { get; set; }

    [StringLength(60)]
    public string? Notes { get; set; }

    [StringLength(60)]
    public string? Note2 { get; set; }

    [StringLength(60)]
    public string? Note3 { get; set; }

    [Column(TypeName = "ntext")]
    public string? note4 { get; set; }

    [Column(TypeName = "ntext")]
    public string? note5 { get; set; }

    [Column(TypeName = "ntext")]
    public string? note6 { get; set; }

    [Column(TypeName = "ntext")]
    public string? note7 { get; set; }

    [Column(TypeName = "ntext")]
    public string? note8 { get; set; }

    [Column(TypeName = "ntext")]
    public string? note9 { get; set; }

    [Column(TypeName = "ntext")]
    public string? note10 { get; set; }

    public float? cost1 { get; set; }

    public float? cost2 { get; set; }

    public float? cost3 { get; set; }

    public float? cost4 { get; set; }

    public float? cost5 { get; set; }

    public float? cost6 { get; set; }

    public float? cost7 { get; set; }

    public float? cost8 { get; set; }

    public int? Qty { get; set; }
}
