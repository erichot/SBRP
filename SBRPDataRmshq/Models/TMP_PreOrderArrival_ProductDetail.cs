using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("OperationSID", "PreOrderSID", "PreOrderItemNo")]
[Table("TMP_PreOrderArrival_ProductDetail")]
[Index("PreOrderDate", Name = "IX_TMP_PreOrderArrival_ProductDetail_PreOrderDate")]
[Index("ProcessSerialNo", Name = "IX_TMP_PreOrderArrival_ProductDetail_ProcessSerialNo")]
[Index("ProductID", Name = "IX_TMP_PreOrderArrival_ProductDetail_ProductID")]
public partial class TMP_PreOrderArrival_ProductDetail
{
    [Key]
    public int OperationSID { get; set; }

    [Key]
    public int PreOrderSID { get; set; }

    [Key]
    public int PreOrderItemNo { get; set; }

    public DateOnly PreOrderDate { get; set; }

    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal? ListPrice { get; set; }

    [Column(TypeName = "money")]
    public decimal Price { get; set; }

    public int PreOrderQty { get; set; }

    public int StockUpQty { get; set; }

    public bool IsStockUpItem { get; set; }

    public int? ToStockUpQty { get; set; }

    public int? ProcessSerialNo { get; set; }

    public int? CurrentRemainQtyAfterStockUp { get; set; }

    public DateTime? TimeModified { get; set; }
}
