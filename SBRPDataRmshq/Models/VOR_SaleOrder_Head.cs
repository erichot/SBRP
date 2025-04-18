using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VOR_SaleOrder_Head
{
    [StringLength(32)]
    public string SaleOrderID { get; set; } = null!;

    [StringLength(32)]
    public string StoreID { get; set; } = null!;

    [StringLength(32)]
    public string StoreName { get; set; } = null!;

    [StringLength(6)]
    public string StoreAbbreviation { get; set; } = null!;

    public DateOnly SaleDate { get; set; }

    public DateTime? SaleDateTime { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? SaleDateText { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? SaleDateTimeHourMinute { get; set; }

    [StringLength(32)]
    public string? CashierId { get; set; }

    [StringLength(16)]
    public string? CashierName { get; set; }

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

    public int MemberSID { get; set; }

    [StringLength(64)]
    [Unicode(false)]
    public string? Account { get; set; }

    [StringLength(16)]
    public string? MemberName { get; set; }

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

    [StringLength(8000)]
    [Unicode(false)]
    public string? OrderAmountText { get; set; }

    [StringLength(160)]
    public string? OrderRemark { get; set; }

    public float v2 { get; set; }

    public bool IsReturnToStore { get; set; }

    public bool IsSaleReturn { get; set; }

    [StringLength(32)]
    public string? SaleReturnOrderID { get; set; }

    [StringLength(32)]
    public string? SaleOrderID_BeforeReturn { get; set; }

    public DateOnly? SaleOrderDate_BeforeReturn { get; set; }

    public bool IsSaledToMember { get; set; }

    public short DetailedSubQty { get; set; }

    public short CountProductID { get; set; }

    public bool IsStartingExport { get; set; }

    public short TimeStartingExportOnHourMinute { get; set; }

    public bool IsExportedToAPI { get; set; }

    public Guid? ExportGID { get; set; }

    public DateTime? TimeExported { get; set; }

    public bool IsExportExclusive { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? TimeExportedHourMinute { get; set; }
}
