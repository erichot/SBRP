using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("OrderSID", "PreOrderItemNo")]
[Table("OR_PreOrderInStorePickUp_Detail")]
[Index("ProductID", Name = "IX_OR_PreOrderInStorePickUp_Detail_ProductID")]
public partial class OR_PreOrderInStorePickUp_Detail
{
    [Key]
    public int OrderSID { get; set; }

    [Key]
    public short PreOrderItemNo { get; set; }

    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    public short PreOrderQty { get; set; }

    public short? StockUpQty { get; set; }

    public short? InStorePickUpQty { get; set; }

    public short ToPickUpQty { get; set; }

    [StringLength(50)]
    public string Remark { get; set; } = null!;
}
