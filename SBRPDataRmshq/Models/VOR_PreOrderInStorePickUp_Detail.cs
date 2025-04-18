using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VOR_PreOrderInStorePickUp_Detail
{
    public int OrderSID { get; set; }

    public short PreOrderItemNo { get; set; }

    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    public short PreOrderQty { get; set; }

    public short? StockUpQty { get; set; }

    public short? InStorePickUpQty { get; set; }

    public short ToPickUpQty { get; set; }

    [StringLength(50)]
    public string Remark { get; set; } = null!;

    [StringLength(32)]
    public string? ProductCode { get; set; }

    [StringLength(100)]
    public string? ProductName { get; set; }

    [StringLength(100)]
    public string? ImageSubFolderFileName1 { get; set; }

    public float? ListPrice { get; set; }

    [Column(TypeName = "money")]
    public decimal? Price { get; set; }

    [StringLength(8000)]
    [Unicode(false)]
    public string? PriceText { get; set; }
}
