using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VBF_Product
{
    [StringLength(32)]
    public string Class { get; set; } = null!;

    [StringLength(32)]
    public string Id { get; set; } = null!;

    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    [StringLength(32)]
    public string? ProductCode { get; set; }

    [StringLength(135)]
    public string? ListField { get; set; }

    [StringLength(100)]
    public string? ProductName { get; set; }

    public int? UpdateCount { get; set; }

    public float? AverageCost { get; set; }

    [StringLength(32)]
    public string? Barcode { get; set; }

    public int? Bonus { get; set; }

    [StringLength(32)]
    public string? CategoryClass { get; set; }

    [StringLength(32)]
    public string? CategoryId { get; set; }

    [StringLength(32)]
    public string? CategoryCode { get; set; }

    [StringLength(30)]
    public string? CategoryName { get; set; }

    [StringLength(32)]
    public string? Code { get; set; }

    public float? Cost { get; set; }

    [StringLength(32)]
    public string? CustomCode { get; set; }

    [StringLength(32)]
    public string? DepartmentClass { get; set; }

    [StringLength(32)]
    public string? DepartmentId { get; set; }

    [StringLength(100)]
    public string? Description { get; set; }

    public float? LastCost { get; set; }

    [StringLength(7)]
    public string? LastReplenishment { get; set; }

    public DateTime? LastSync { get; set; }

    [StringLength(8)]
    public string? LastUpdate { get; set; }

    public float? MemberPrice { get; set; }

    [StringLength(60)]
    public string? Note1 { get; set; }

    [StringLength(60)]
    public string? Note2 { get; set; }

    [StringLength(60)]
    public string? Note3 { get; set; }

    [StringLength(60)]
    public string? Notes { get; set; }

    [Column(TypeName = "image")]
    public byte[]? Picture { get; set; }

    public int? PrepaidPoints { get; set; }

    public float? ListPrice { get; set; }

    public float? SellingPrice { get; set; }

    [StringLength(60)]
    public string? Specification { get; set; }

    [StringLength(32)]
    public string? SupplierClass { get; set; }

    [StringLength(32)]
    public string? SupplierId { get; set; }

    [StringLength(32)]
    public string? SupplierCode { get; set; }

    [StringLength(40)]
    public string? SupplierName { get; set; }

    [Column(TypeName = "image")]
    public byte[]? SupplierList { get; set; }

    [Column(TypeName = "numeric(3, 0)")]
    public decimal? Taxable { get; set; }

    public float? TaxRate { get; set; }

    [StringLength(6)]
    public string? UnitOfMeasure { get; set; }

    public float? VIPPrice { get; set; }

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

    [StringLength(32)]
    public string? ColorID { get; set; }

    [StringLength(32)]
    public string? ColorName { get; set; }

    [StringLength(32)]
    public string? SizeID { get; set; }

    [StringLength(32)]
    public string? SizeName { get; set; }

    [StringLength(32)]
    public string? sex { get; set; }

    [StringLength(32)]
    public string? season { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? SeasonName { get; set; }

    [StringLength(32)]
    public string? brand { get; set; }

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

    [Column(TypeName = "ntext")]
    public string? note11 { get; set; }

    public float? cost1 { get; set; }

    public float? cost2 { get; set; }

    public float? cost3 { get; set; }

    public float? cost4 { get; set; }

    public float? cost5 { get; set; }

    public float? cost6 { get; set; }

    public float? cost7 { get; set; }

    public float? cost8 { get; set; }

    [Column(TypeName = "ntext")]
    public string? note4 { get; set; }

    [Column(TypeName = "ntext")]
    public string? note5 { get; set; }

    public DateTime? winjet_last_update { get; set; }

    public DateTime? iicpos_last_update { get; set; }

    [StringLength(50)]
    public string ImageSubFolder { get; set; } = null!;

    [StringLength(50)]
    public string? ImageFileName1 { get; set; }

    [StringLength(100)]
    public string? ImageSubFolderFileName1 { get; set; }

    public bool IsFavorite { get; set; }

    public bool IsStoped { get; set; }

    [StringLength(50)]
    public string? SSSNoteP1 { get; set; }

    [StringLength(50)]
    public string? SSSNoteP2 { get; set; }

    [StringLength(50)]
    public string? SSSNoteP3 { get; set; }

    [StringLength(50)]
    public string? SSSNoteP4 { get; set; }

    [StringLength(254)]
    [Unicode(false)]
    public string? BrandName { get; set; }

    [StringLength(254)]
    [Unicode(false)]
    public string? SexName { get; set; }
}
