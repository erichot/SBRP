using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VOR_PreOrder_Detail
{
    public int OrderSID { get; set; }

    public short ItemNo { get; set; }

    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    [StringLength(32)]
    public string? ProductCode { get; set; }

    [StringLength(100)]
    public string? ProductName { get; set; }

    [StringLength(100)]
    public string? ImageSubFolderFileName1 { get; set; }

    public int Qty { get; set; }

    [Column(TypeName = "money")]
    public decimal? ListPrice { get; set; }

    [Column(TypeName = "money")]
    public decimal? Price { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? PriceText { get; set; }

    [StringLength(50)]
    public string? Remark { get; set; }

    public int StockUpQty { get; set; }

    public short StockUpTimes { get; set; }

    public DateTime? TimeStockUpFirst { get; set; }

    [StringLength(16)]
    [Unicode(false)]
    public string? UserStockUpFirstID { get; set; }

    public DateTime? TimeStockUpLast { get; set; }

    [StringLength(16)]
    [Unicode(false)]
    public string? UserStockUpLastID { get; set; }

    public int? InStorePickUpQty { get; set; }

    public bool IsAllowItemForInStorePickUp { get; set; }

    public bool IsFinishedItemForInStorePickUp { get; set; }

    public short? InStorePickUpTimes { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? TimeStockUpLastDateText { get; set; }

    public DateTime? TimeInStorePickUpLast { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? TimeInStorePickUpLastText { get; set; }

    public bool IsFinishedItemForStockUp { get; set; }

    [StringLength(1)]
    public string? IsFinishedItemForStockUpText { get; set; }

    [StringLength(1)]
    public string? IsAllowItemForInStorePickUpText { get; set; }

    [StringLength(1)]
    public string? IsFinishedItemForInStorePickUpText { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? TimeInStorePickUpLastDateText { get; set; }

    public string? PreOrderArrivalDetailedNote { get; set; }

    public string? InStorePickUpDetailedNote { get; set; }
}
