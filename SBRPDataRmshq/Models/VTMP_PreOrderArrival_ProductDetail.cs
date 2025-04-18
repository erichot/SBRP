using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VTMP_PreOrderArrival_ProductDetail
{
    public int OperationSID { get; set; }

    [StringLength(11)]
    [Unicode(false)]
    public string? PreOrderID { get; set; }

    public int? MemberSID { get; set; }

    [StringLength(16)]
    public string? MemberName { get; set; }

    public bool ProductIsSelected { get; set; }

    public int ProductSerialNo { get; set; }

    public int PreOrderSID { get; set; }

    public DateOnly? PreOrderDate { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? PreOrderDateText { get; set; }

    public int PreOrderItemNo { get; set; }

    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    [StringLength(32)]
    public string? ProductCode { get; set; }

    [StringLength(100)]
    public string? ProductName { get; set; }

    [StringLength(100)]
    public string? ImageSubFolderFileName1 { get; set; }

    [Column(TypeName = "money")]
    public decimal Price { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? PriceText { get; set; }

    public int PreOrderQty { get; set; }

    public int StockUpQty { get; set; }

    public short StockUpTimes { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? DateStockUpFirstText { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? DateStockUpLastText { get; set; }

    public bool IsStockUpItem { get; set; }

    public int? ToStockUpQty { get; set; }

    public int? ProcessSerialNo { get; set; }

    public int? CurrentRemainQtyAfterStockUp { get; set; }

    public DateTime? TimeModified { get; set; }
}
