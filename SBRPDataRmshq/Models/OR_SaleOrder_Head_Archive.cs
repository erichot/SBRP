using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("SaleOrderID", "StoreID")]
[Table("OR_SaleOrder_Head_Archive")]
[Index("CashierId", Name = "IX_OR_SaleOrder_Head_Archive_CashierId")]
[Index("InvoiceStartNumber", Name = "IX_OR_SaleOrder_Head_Archive_InvoiceStartNumber")]
[Index("MemberID", Name = "IX_OR_SaleOrder_Head_Archive_MemberID")]
[Index("SaleDate", Name = "IX_OR_SaleOrder_Head_Archive_SaleDate")]
public partial class OR_SaleOrder_Head_Archive
{
    [Key]
    [StringLength(32)]
    public string SaleOrderID { get; set; } = null!;

    [Key]
    [StringLength(32)]
    public string StoreID { get; set; } = null!;

    public DateOnly SaleDate { get; set; }

    public DateTime? SaleDateTime { get; set; }

    [StringLength(32)]
    public string? CashierId { get; set; }

    public int CreditCard { get; set; }

    [StringLength(16)]
    [Unicode(false)]
    public string? CreditCardNumber { get; set; }

    [Column(TypeName = "decimal(5, 3)")]
    public decimal Discount { get; set; }

    [Column(TypeName = "money")]
    public decimal PercentOff { get; set; }

    [StringLength(10)]
    public string? InvoiceStartNumber { get; set; }

    [StringLength(10)]
    public string? InvoiceEndNumber { get; set; }

    [StringLength(160)]
    public string? MemberClass { get; set; }

    [StringLength(100)]
    public string MemberID { get; set; } = null!;

    [StringLength(32)]
    public string? POSTClass { get; set; }

    [StringLength(32)]
    public string? POSTId { get; set; }

    [Column(TypeName = "money")]
    public decimal TaxAmount { get; set; }

    [Column(TypeName = "decimal(5, 3)")]
    public decimal TaxRate { get; set; }

    [Column(TypeName = "money")]
    public decimal Cash { get; set; }

    [Column(TypeName = "money")]
    public decimal Coupon { get; set; }

    [Column(TypeName = "money")]
    public decimal PrepaidPoints { get; set; }

    [Column(TypeName = "money")]
    public decimal ShoppingPointsUsed { get; set; }

    [Column(TypeName = "money")]
    public decimal Total { get; set; }

    public bool InActive { get; set; }

    /// <summary>
    /// 該筆銷貨單是否有被產生對應的銷退單
    /// </summary>
    public bool IsReturnToStore { get; set; }

    /// <summary>
    /// 該筆單據銷退單（依據一筆先前實際發生的銷貨單）
    /// </summary>
    public bool IsSaleReturn { get; set; }

    [StringLength(6)]
    public string? SaleTime { get; set; }

    [StringLength(32)]
    public string? Class { get; set; }

    public int? UpdateCount { get; set; }

    [StringLength(32)]
    public string? CashierClass { get; set; }

    [StringLength(32)]
    public string? Code { get; set; }

    [StringLength(8)]
    public string? CompanyNumber { get; set; }

    [MaxLength(100)]
    public byte[]? Items { get; set; }

    [Column(TypeName = "numeric(3, 0)")]
    public decimal? Taxable { get; set; }

    public DateTime? LastSync { get; set; }

    [StringLength(32)]
    public string? TheStoreId { get; set; }

    [StringLength(32)]
    public string? TheStoreClass { get; set; }

    public float? v1 { get; set; }

    public float? v2 { get; set; }

    public float? v3 { get; set; }

    public float? v4 { get; set; }

    public float? v5 { get; set; }

    public DateTime TimeAddNew { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string UserAddNewID { get; set; } = null!;

    public DateTime? TimeModified { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? UserModifiedID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeNullified { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? UserNullified { get; set; }

    [StringLength(32)]
    public string? SaleReturnOrderID { get; set; }

    [StringLength(32)]
    public string? SaleOrderID_BeforeReturn { get; set; }

    public DateOnly? SaleOrderDate_BeforeReturn { get; set; }

    public bool IsSaledToMember { get; set; }

    [StringLength(64)]
    [Unicode(false)]
    public string? EMail { get; set; }

    public int DetailedSubQty { get; set; }

    public int CountProductID { get; set; }

    [StringLength(16)]
    public string? MemberName { get; set; }

    public bool IsExportExclusive { get; set; }

    public bool IsStartingExport { get; set; }

    public short TimeStartingExportOnHourMinute { get; set; }

    public bool HasErrorWhenExporting { get; set; }

    public bool IsExportedToAPI { get; set; }

    public Guid? ExportGID { get; set; }

    public DateTime? TimeExported { get; set; }
}
