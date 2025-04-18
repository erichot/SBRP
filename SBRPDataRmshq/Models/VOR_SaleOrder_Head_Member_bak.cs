using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VOR_SaleOrder_Head_Member_bak
{
    public long? RowNumber { get; set; }

    [StringLength(32)]
    public string SaleOrderID { get; set; } = null!;

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

    [StringLength(30)]
    public string? StoreName { get; set; }

    [StringLength(22)]
    public string? Name { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? EMail { get; set; }

    public int? SubQty { get; set; }

    public int? CountProductID { get; set; }

    public int SaleOrderType { get; set; }

    public bool IsReturnToStore { get; set; }

    public bool IsSaleReturn { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? NewSaleOrderID { get; set; }

    [StringLength(32)]
    public string SaleOrderID_BeforeReturn { get; set; } = null!;

    public DateOnly? SaleOrderDate_BeforeReturn { get; set; }

    public bool? IsExported { get; set; }

    public DateTime? TimeExported { get; set; }
}
